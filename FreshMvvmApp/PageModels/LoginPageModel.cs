using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.Extensions;
using KantimeEvv.Controls.CustomDialogs;
using Xamarin.Essentials;
using KantimeEvv.BL.Manager.Interfaces;
using Microsoft.AppCenter.Crashes;

namespace KantimeEvv.PageModels
{
    public class LoginPageModel : FreshBasePageModel
    {
        readonly ILoginManager _loginManager;
        public LoginPageModel(ILoginManager loginManager)
        {
            _loginManager =loginManager;
        }

        public Command LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    // this.LoadTabbedNav();
                    try
                    {
                        //var res = await _loginManager.Login(LoginId, Password);

                        var result = await this.CurrentPage.Navigation.ShowPopupAsync(new AllowBiometricDialog());

                        if (result != null)
                        {
                            if ((bool)result)
                            {
                                this.LoadTabbedNav();
                            }
                            else
                            {
                                this.LoadTabbedNav();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Crashes.TrackError(ex);
                    }
                });
            }
        }

        string accessToken = string.Empty;

        public string AuthToken
        {
            get => accessToken;
            set 
            { accessToken = value;
                this.RaisePropertyChanged();
            }

            
        }

        private string _LoginId;
        public string LoginId
        {
            get => _LoginId;
            set
            {
                if (value == null || value==_LoginId)
                    return;

                _LoginId = value;
                this.RaisePropertyChanged();
            }


        }
        private string _Password;
        public string Password
        {
            get => _Password;
            set
            {
                if (value == null || value == _Password)
                    return;

                _Password = value;
                this.RaisePropertyChanged();
            }


        }

        public Command GoogleLoginCommand
        {
            get
            {
                return new Command(async () =>
                {


                 //   var authResult = await WebAuthenticator.AuthenticateAsync(
                 //new Uri("https://192.168.43.252:5001/api/Accounts/Google"),
                 // new Uri("xamarinformsclients://"));
                    string authenticationUrl = "http://jothiprakash111-001-site1.ctempurl.com/api/Accounts/";
                    string scheme = "Google";
                    try
                    {
                        WebAuthenticatorResult r = null;

                        if (scheme.Equals("Apple")
                            && DeviceInfo.Platform == DevicePlatform.iOS
                            && DeviceInfo.Version.Major >= 13)
                        {
                            // Make sure to enable Apple Sign In in both the
                            // entitlements and the provisioning profile.
                            var options = new AppleSignInAuthenticator.Options
                            {
                                IncludeEmailScope = true,
                                IncludeFullNameScope = true,
                            };
                            r = await AppleSignInAuthenticator.AuthenticateAsync(options);
                        }
                        else
                        {
                            var authUrl = new Uri(authenticationUrl + scheme);
                            var callbackUrl = new Uri("xamarinformsclients://");

                            r = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);
                        }

                        AuthToken = string.Empty;
                        if (r.Properties.TryGetValue("name", out var name) && !string.IsNullOrEmpty(name))
                            AuthToken += $"Name: {name}{Environment.NewLine}";
                        if (r.Properties.TryGetValue("email", out var email) && !string.IsNullOrEmpty(email))
                            AuthToken += $"Email: {email}{Environment.NewLine}";
                        AuthToken += r?.AccessToken ?? r?.IdToken;
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("Login canceled.");

                        AuthToken = string.Empty;
                        //await DisplayAlertAsync("Login canceled.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed: {ex.Message}");

                        AuthToken = string.Empty;
                        //await DisplayAlertAsync($"Failed: {ex.Message}");
                    }
                
                });
            }
        }

        public void LoadTabbedNav()
        {
            var tabbedNavigation = new FreshTabbedNavigationContainer();
            tabbedNavigation.On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            tabbedNavigation.AddTab<DashboardPageModel>("Dashboard", "Dashboard.png", null);
            tabbedNavigation.AddTab<ScheduleListPageModel>("My Visits", "Schedule.png", null);
            tabbedNavigation.AddTab<NotificationListPageModel>("Notifications", "Notification.png", null);
            tabbedNavigation.AddTab<MorePageModel>("More", "More.png", null);
          
            App.Current.MainPage = tabbedNavigation;
        }
    }
}
