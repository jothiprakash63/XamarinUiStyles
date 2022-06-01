using FreshMvvm;
using KantimeEvv.Chat;
using KantimeEvv.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KantimeEvv.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ChatPageModel : FreshBasePageModel
    {
        public User user { get; set; }
        public ChatPageModel(IChatService chatService)
        {
            this.ChatService = chatService;
            this.ChatService.OnReceivedMessage += ChatService_OnReceivedMessage;
            ChatList = new ObservableCollection<ChatMessage>();
            ConnectChatServer.Execute(null);

        }


        public override void Init(object initData)
        {
            user=initData as User;
            base.Init(initData);
        }
        private void ChatService_OnReceivedMessage(object sender, Chat.EventHandlers.MessageEventArgs e)
        {
        
            ChatList.Add(new ChatMessage() { Message = e.Message, IsSent = false });
        }

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                if (_Message != value)
                    _Message = value;

                this.RaisePropertyChanged();
            }
        }

        private IChatService ChatService { get; set; }
        public ObservableCollection<ChatMessage> ChatList { get; set; }

        public Command ConnectChatServer
        {
            get
            {
                return new Command(async () =>
                {

                    await this.ChatService.ConnectAsync();
                    await this.ChatService.JoinChannelAsync(user.UserName, DeviceInfo.Name);
                });
            }
        }

        public Command SendMessage
        {
            get
            {
                return new Command(async () =>
                {
                    await this.ChatService.SendMessageAsync(user.UserName, DeviceInfo.Name, Message);
                    ChatList.Add(new ChatMessage() { Message = Message, IsSent = true });
                });
            }
        }

    }
}
