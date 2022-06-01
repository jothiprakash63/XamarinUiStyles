using FreshMvvm;
using KantimeEvv.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KantimeEvv.PageModels
{
    public class ScheduleListPageModel:FreshBasePageModel
    {
       public  ObservableCollection<ScheduleModel> schedules { get; set; }
        public ScheduleListPageModel()
        {
            //locationConsent = DependencyService.Get<ILocationConsent>();

            this.HandleReceivedMessages();
            schedules = new ObservableCollection<ScheduleModel>()
            {
                new ScheduleModel()
                {
                    ClientInitial="JD",
                     Address="#206 A City, Palm Beach County, Miami - Florida, 32104",
                    ClientName="John Doe",
                     ServiceName="RN Regular Visit",
                     DutiesPerformed="0/5 Duties Performed",
                     PlannedStartTime="09:00 Am",
                     PlannedEndTime="12:00 Pm",
                     SchedleStatus="Planned",
                     

                }
            };
        }
        public double _Latitude;
        public double Latitude
        {
            get
            {
                return _Latitude;
            }
            set
            {
                _Latitude = value;
                this.RaisePropertyChanged();
            }
        }

        public double _Longitude;
        public double Longitude
        {
            get
            {
                return _Longitude;
            }
            set
            {
                _Longitude = value;
                this.RaisePropertyChanged();
            }
        }
        public string _UserMessage;
        public string UserMessage
        {
            get
            {
                return _UserMessage;
            }
            set
            {
                _UserMessage = value;
                this.RaisePropertyChanged();
            }
        }



        public Command StartListeningLocation
        {
            get
            {
                return new Command(async () =>
                {

                    Start();
                });
            }
        }

        public void OnStartClick()
        {
            Start();
        }

        public void OnStopClick()
        {
            var message = new StopServiceMessage();
            MessagingCenter.Send(message, "ServiceStopped");
            UserMessage = "Location Service has been stopped!";

        }

      

        async void Start()
        {
           var status =  await Permissions.RequestAsync<Permissions.LocationAlways>();

            if (status == PermissionStatus.Granted)
            {
                var message = new StartServiceMessage();

                MessagingCenter.Send(message, "ServiceStarted");
                UserMessage = "Location Service has been started!";

            }

        }

        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<locationMessageModel>(this, "Location", message => {
                Device.BeginInvokeOnMainThread(() => {
                    Latitude = message.Latitude;
                    Longitude = message.Longitude;
                    UserMessage = "Location Updated";
                });
            });
            MessagingCenter.Subscribe<StopServiceMessage>(this, "ServiceStopped", message => {
                Device.BeginInvokeOnMainThread(() => {
                    UserMessage = "Location Service has been stopped!";
                });
            });
            MessagingCenter.Subscribe<LocationErrorMessage>(this, "LocationError", message => {
                Device.BeginInvokeOnMainThread(() => {
                    UserMessage = "There was an error updating location!";
                });
            });
        }

    }
}
