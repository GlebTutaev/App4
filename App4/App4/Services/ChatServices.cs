﻿using App4.Models;
using App4.Services;
using App4.WebSocketImplementation;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ChatServices))]
namespace App4.Services
{
    
    public class ChatServices : IChatServices
    {
        private readonly HubConnection _connection;
        private readonly IHubProxy _proxy;

        public event EventHandler<ChatMessage> OnMessageReceived;

        public ChatServices()
        {
            _connection = new HubConnection(App.SignalRUrl);
            _proxy = _connection.CreateHubProxy("chatGroupHub");
            _proxy.On("GetMessage", (string name, string message) => OnMessageReceived(this, new ChatMessage
            {
                Name = name,
                Message = message
            }));
        }

        #region IChatServices implementation

        public async Task Connect()
        {

            var http = new Microsoft.AspNet.SignalR.Client.Http.DefaultHttpClient();
            //var transports = new List<IClientTransport>()
            //                                                        {
            //                                                            new WebSocketTransportLayer(http),
            //                                                            new ServerSentEventsTransport(http),
            //                                                            new LongPollingTransport(http)
            //                                                        };
            /// Preparando la conexion
            //await _connection.Start(new AutoTransport(http, transports));
            await _connection.Start(new WebSocketTransportLayer(http));
        }

        public async Task Send(ChatMessage message, string roomName)
        {
            if (_connection.State == ConnectionState.Disconnected)
            {
                await Connect();
            }
            await _proxy.Invoke("SendMessage", message.Name, message.Message, roomName);
        }

        public async Task JoinGroup(string roomName)
        {
            if (_connection.State == ConnectionState.Disconnected)
            {
                await Connect();
            }
            await _proxy.Invoke("JoinGroup", roomName);
        }

        #endregion
    }
}
