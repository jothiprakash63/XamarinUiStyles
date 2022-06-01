using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using System;


namespace KantimeEvv.Droid
{

    [Activity(Label = "OidcCallbackActivity",NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
        [IntentFilter(new[] { Intent.ActionView },
            Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
            DataScheme = "xamarinformsclients")]
           // DataHost = "callback")]
        public class OidcCallbackActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {
            public static event Action<string> Callbacks;

            public OidcCallbackActivity()
            {
                Log.Debug("OidcCallbackActivity", "constructing OidcCallbackActivity");
            }

            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);

                Callbacks?.Invoke(Intent.DataString);

                Finish();
            
                StartActivity(typeof(MainActivity));
            }
        }
    }