using FreshMvvm;
using KantimeEvv.BL.Manager.Interfaces;
using KantimeEvv.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace KantimeEvv.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ChatContactsPageModel : FreshBasePageModel
    {
        IUserManager _UserManager { get; set; }
        public ObservableCollection<User> chatContacts { get; set; }
        public ChatContactsPageModel(IUserManager userManager)
        {
            _UserManager = userManager;
            GetUsersCommand.Execute(null);
        }

     

        public Command GetUsersCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await this.GetUsers();
                });
            }
        }

        private User _selectedItem;
        public User SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (value != null)
                    SelectedItemChangedCommand.Execute(value);
            }
        }

        public Command<User> SelectedItemChangedCommand
        {
            get
            {
                return new Command<User>(async (e) => {

                   await  CoreMethods.PushPageModel<ChatPageModel>(e);

                });
            }
        }



        public async Task GetUsers()
        {
            var list =  await _UserManager.GetUsers();
            this.chatContacts = new ObservableCollection<User>(list);
        }


    }
}
