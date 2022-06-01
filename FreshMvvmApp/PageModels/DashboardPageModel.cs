using FreshMvvm;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace KantimeEvv.PageModels
{
    public class DashboardPageModel : FreshBasePageModel
    {
      
        public DashboardPageModel()
        {


           

        }




        public Command SendCommand
        {
            get
            {
                return new Command(async () => {

                    //var page = FreshPageModelResolver.ResolvePageModel<ContactListPageModel>();
                    //var basicNavContainer = new FreshNavigationContainer(page);
                    await CoreMethods.PushPageModel<ContactListPageModel>();

                });
            }
        }
    }
}
