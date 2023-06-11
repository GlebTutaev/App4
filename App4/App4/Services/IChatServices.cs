using App4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App4.Services
{
    public interface IChatServices
    {
        Task Connect();
        Task Send(ChatMessage message, string roomName);
        Task JoinGroup(string roomName);
        event EventHandler<ChatMessage> OnMessageReceived;
    }
}
