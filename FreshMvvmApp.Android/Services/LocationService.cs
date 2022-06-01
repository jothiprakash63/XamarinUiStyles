using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForms.LocationService.Droid.Helpers;
using XamarinForms.LocationService.Services;
using OperationCanceledException = System.OperationCanceledException;

namespace KantimeEvv.Droid.Services
{
	[Service]
    public class LocationService : Service
	{
		CancellationTokenSource _cts;
		public const int SERVICE_RUNNING_NOTIFICATION_ID = 10000;

		public override IBinder OnBind(Intent intent)
		{
			return null;
		}

        public override void OnCreate()
        {
            base.OnCreate();
			Notification notif = DependencyService.Get<INotification>().ReturnNotif();
			StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notif);
		}

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
		{
			_cts = new CancellationTokenSource();

            Notification notif = DependencyService.Get<INotification>().ReturnNotif();
            StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notif);

            Task.Run(() => {
				try
				{
					var locShared = new Location();
					locShared.Run(_cts.Token).Wait();
				}
				catch (OperationCanceledException ex)
				{
				}
				finally
				{
					if (_cts.IsCancellationRequested)
					{
						//var message = new StopServiceMessage();
						//Device.BeginInvokeOnMainThread(
						//	() => MessagingCenter.Send(message, "ServiceStopped")
						//);
					}
				}
			}, _cts.Token);

			return StartCommandResult.Sticky;
		}

		public override void OnDestroy()
		{
			if (_cts != null)
			{
				_cts.Token.ThrowIfCancellationRequested();
				_cts.Cancel();
			}
			base.OnDestroy();
		}
	}
}