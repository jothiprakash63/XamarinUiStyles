using System;
using Xamarin.Forms;
using System.Collections.Generic;
using FreshMvvm;
using KantimeEvv.Services.Interfaces;
using KantimeEvv.PageModels;
using KantimeEvv.Services;
using Plugin.FirebasePushNotification;
using KantimeEvv.Chat;
using KantimeEvv.BL.Manager.Interfaces;
using KantimeEvv.BL.Manager;
//[assembly: ExportFont("FontAwesome-Regular.ttf", Alias = "FontAwesome_Regular")]
//[assembly: ExportFont("FontAwesome-Solid.ttf", Alias = "FontAwesome_Solid")]

namespace KantimeEvv
{


    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            CrossFirebasePushNotification.Current.Subscribe("all");
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            
            
            this.RegisterServices();
           

            this.LoadBasicNav();
        }



        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
       {
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
        }


        private void RegisterServices()
        {
            FreshIOC.Container.Register<IDatabaseService, DatabaseService>();
            FreshIOC.Container.Register<IChatService, ChatService>();
            FreshIOC.Container.Register<ILoginManager, LoginManager>();
            FreshIOC.Container.Register<IUserManager, UserManager>();
            
            //FreshIOC.Container.Register<IScheduleService, ScheduleService>();
        }

        public void LoadBasicNav()
        {
            var page = FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        public void LoadMasterDetail()
        {
            var masterDetailNav = new FreshMasterDetailNavigationContainer();
            masterDetailNav.Init("Menu", "Menu.png");
            masterDetailNav.AddPage<ContactListPageModel>("Contacts", null);
            masterDetailNav.AddPage<QuoteListPageModel>("Quotes", null);
            MainPage = masterDetailNav;
        }

        public void LoadTabbedNav()
        {
            var tabbedNavigation = new FreshTabbedNavigationContainer();
            tabbedNavigation.AddTab<ContactListPageModel>("Contacts", "contacts.png", null);
            tabbedNavigation.AddTab<QuoteListPageModel>("Quotes", "document.png", null);
            MainPage = tabbedNavigation;
        }

        public void LoadFOTabbedNav()
        {
            var tabbedNavigation = new FreshTabbedFONavigationContainer("CRM");
            tabbedNavigation.AddTab<ContactListPageModel>("Contacts", "contacts.png", null);
            tabbedNavigation.AddTab<QuoteListPageModel>("Quotes", "document.png", null);
            MainPage = tabbedNavigation;
        }

        public void LoadCustomNav()
        {
            MainPage = new CustomImplementedNav();
        }

        public void LoadMultipleNavigation()
        {
            var masterDetailsMultiple = new FlyoutPage(); //generic master detail page

            //we setup the first navigation container with ContactList
            var contactListPage = FreshPageModelResolver.ResolvePageModel<ContactListPageModel>();
            contactListPage.Title = "Contact List";
            //we setup the first navigation container with name MasterPageArea
            var masterPageArea = new FreshNavigationContainer(contactListPage, "MasterPageArea");
            masterPageArea.Title = "Menu";

            masterDetailsMultiple.Detail = masterPageArea; //set the first navigation container to the Master

            //we setup the second navigation container with the QuoteList 
            var quoteListPage = FreshPageModelResolver.ResolvePageModel<QuoteListPageModel>();
            quoteListPage.Title = "Quote List";
            //we setup the second navigation container with name DetailPageArea
            var detailPageArea = new FreshNavigationContainer(quoteListPage, "DetailPageArea");

            masterDetailsMultiple.Detail = detailPageArea; //set the second navigation container to the Detail

            MainPage = masterDetailsMultiple;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
           // App.Current.UserAppTheme = OSAppTheme.Dark;
        }
    }
}