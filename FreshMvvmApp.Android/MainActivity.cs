using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Plugin.CurrentActivity;
using Plugin.Fingerprint;
using KantimeEvv.Droid.Services;
using Android.Content;
using KantimeEvv.Models;
using Plugin.FirebasePushNotification;

namespace KantimeEvv.Droid
{
    [Activity(Label = "KantimeEvv", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Intent serviceIntent;
        private const int RequestCode = 5469;
        protected override void OnCreate(Bundle bundle)
        {

            DependencyService.Register<ChromeCustomTabsBrowser>();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            AppCenter.Start("d563d48d-269f-41e5-bc9d-0371b371205a",
                   typeof(Analytics), typeof(Crashes));

            serviceIntent = new Intent(this, typeof(LocationService));
            SetServiceMethods();
            Xamarin.Essentials.Platform.Init(this, bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            CrossFingerprint.SetCurrentActivityResolver(() => CrossCurrentActivity.Current.Activity);
            FirebasePushNotificationManager.ProcessIntent(this, Intent);
            LoadApplication(new App());

        }

        private void SetServiceMethods()
        {
            MessagingCenter.Subscribe<StartServiceMessage>(this, "ServiceStarted", message =>
            {
                if (!IsServiceRunning(typeof(LocationService)))
                {
                    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
                    {
                        StartForegroundService(serviceIntent);
                    }
                    else
                    {
                        StartService(serviceIntent);
                    }
                }
            });

            MessagingCenter.Subscribe<StopServiceMessage>(this, "ServiceStopped", message =>
            {
                if (IsServiceRunning(typeof(LocationService)))
                    StopService(serviceIntent);
            });
        }


        private bool IsServiceRunning(System.Type cls)
        {
            ActivityManager manager = (ActivityManager)GetSystemService(Context.ActivityService);
            foreach (var service in manager.GetRunningServices(int.MaxValue))
            {
                if (service.Service.ClassName.Equals(Java.Lang.Class.FromType(cls).CanonicalName))
                {
                    return true;
                }
            }
            return false;
        }

    }
}

