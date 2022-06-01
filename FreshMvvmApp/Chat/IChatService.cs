using KantimeEvv.Chat.EventHandlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KantimeEvv.Chat
{
    public interface IChatService
    {
        event EventHandler<MessageEventArgs> OnConnectionClosed;
        event EventHandler<MessageEventArgs> OnEnteredOrExited;
        event EventHandler<MessageEventArgs> OnReceivedMessage;

        Task ConnectAsync();
        Task DisconnectAsync();
        List<string> GetRooms();
        void Init(string urlRoot, bool useHttps);
        Task JoinChannelAsync(string group, string userName);
        Task LeaveChannelAsync(string group, string userName);
        Task SendMessageAsync(string group, string userName, string message);
    }
}