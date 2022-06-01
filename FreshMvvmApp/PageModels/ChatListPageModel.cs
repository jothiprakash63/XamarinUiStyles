using FreshMvvm;
using KantimeEvv.Chat;
using KantimeEvv.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace KantimeEvv.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ChatListPageModel:FreshBasePageModel
    {
        public ChatListPageModel()
        {
         
             ChatHistory =new ObservableCollection<ChatHistoryModel> ()
            { 
                new ChatHistoryModel(){Id=4,ChatName="Xamarin", Initial ="GM"},
                new ChatHistoryModel(){  Id=1, ChatName="Alex Fergusson", Initial="AF", LastMessage="Lorem ipsum dolor sit amet, consetetu Lorem ipsum dolor sit amet,", SentTime="Today,10:15 am"},
            new ChatHistoryModel(){  Id=2, ChatName="John Doe", Initial="JD", LastMessage="Lorem ipsum dolor sit amet, consetetu Lorem ipsum dolor sit amet,", SentTime="Today,10:15 am"},
            new ChatHistoryModel(){  Id=3, ChatName="Alex Morgan", Initial="AM", LastMessage="Lorem ipsum dolor sit amet, consetetu Lorem ipsum dolor sit amet,", SentTime="Today,10:15 am"}

            };
        }

    
        public ObservableCollection<ChatHistoryModel> ChatHistory { get; set; }




        private ChatHistoryModel _selectedItem;
        public ChatHistoryModel SelectedItem
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

        public Command<ChatHistoryModel> SelectedItemChangedCommand
        {
            get
            {
                return new Command<ChatHistoryModel>(async (e) => {



                });
            }
        }

        public Command Command_NewChat
        {
            get
            {
                return new Command(async () => {

                   await  CoreMethods.PushPageModel<ChatContactsPageModel>();

                });
            }
        }

        

    }


}
