using FreshMvvm;
using KantimeEvv.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace KantimeEvv.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class MorePageModel : FreshBasePageModel
    {
        
        public  MorePageModel()
        {
            moreModels=new ObservableCollection<MoreModel> { 
                new MoreModel(){ Icon ="account.svg",Name="Account"},
                 new MoreModel(){ Icon ="clients.svg",Name="Clients"},
                  new MoreModel(){ Icon ="mail.svg",Name="Messages",BadgeValue=3},
                   new MoreModel(){ Icon ="calender.svg",Name="Calender"},
                    new MoreModel(){ Icon ="holidays.svg",Name="Holdays"},
                 new MoreModel(){ Icon ="payroll.svg",Name="Payroll"},
                  new MoreModel(){ Icon ="information.svg",Name="Informations"},
                   new MoreModel(){ Icon ="messages.svg",Name="Chat",BadgeValue=10},

            };
        }

        public ObservableCollection<MoreModel> moreModels { get; set; }

        private MoreModel _selectedItem;
        public MoreModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (value != null)
                    MoreItemCommand.Execute(value);
            }
        }

        public Command<MoreModel> MoreItemCommand
        {
            get
            {
                return new Command<MoreModel>(async (e) => {
                   
                    //var x=  e as SelectedItemChangedEventArgs;
                    switch (e.Name)
                    {
                        case "Messages":
                            var page = FreshPageModelResolver.ResolvePageModel<MailListPageModel>();
                            var basicNavContainer = new FreshNavigationContainer(page, Guid.NewGuid().ToString());
                            await CoreMethods.PushPageModel<MailListPageModel>(basicNavContainer);

                            
                            break;

                        case "Chat":
                            var chatPage = FreshPageModelResolver.ResolvePageModel<ChatListPageModel>();
                            var basicNavContainer1 = new FreshNavigationContainer(chatPage, Guid.NewGuid().ToString());
                            await CoreMethods.PushNewNavigationServiceModal(basicNavContainer1, new FreshBasePageModel[] { chatPage.GetModel() });
                            break;

                        default:
                            break;

                       
                    }
                    SelectedItem = null;

                });
            }
        }
    }
}
