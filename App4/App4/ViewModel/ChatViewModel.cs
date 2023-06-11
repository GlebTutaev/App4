﻿using App4.Models;
using App4.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App4.ViewModel
{
    public class ChatViewModel : BaseViewModel
    {
        private IChatServices _chatServices;
        private string _roomName = "PrivateRoom";


        #region ViewModel Properties

        private ObservableCollection<ChatMessageViewModel> _messages;

        public ObservableCollection<ChatMessageViewModel> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged("Messages");
            }
        }

        private ChatMessageViewModel _chatMessage;
        public ChatMessageViewModel ChatMessage
        {
            get { return _chatMessage; }
            set
            {
                _chatMessage = value;
                OnPropertyChanged("ChatMessage");
            }
        }


        #endregion

        public ChatViewModel()
        {
            _chatServices = DependencyService.Get<IChatServices>();
            _chatMessage = new ChatMessageViewModel();

            _messages = new ObservableCollection<ChatMessageViewModel>();
            _chatServices.Connect();
            _chatServices.OnMessageReceived += _chatServices_OnMessageReceived;
        }

        void _chatServices_OnMessageReceived(object sender, ChatMessage e)
        {
            _messages.Add(new ChatMessageViewModel { Name = e.Name, Message = e.Message, IsMine = _messages.Count % 2 == 0 });
        }

        #region Send Message Command

        Command sendMessageCommand;

        /// <summary>
        /// Command to Send Message
        /// </summary>
        public Command SendMessageCommand
        {
            get
            {
                return sendMessageCommand ??
                (sendMessageCommand = new Command(ExecuteSendMessageCommand));
            }
        }

        async void ExecuteSendMessageCommand()
        {
            IsBusy = true;
            await _chatServices.Send(new ChatMessage { Name = _chatMessage.Name, Message = _chatMessage.Message }, _roomName);
            IsBusy = false;
        }

        #endregion

        #region Join Room Command

        Command joinRoomCommand;

        /// <summary>
        /// Command to Send Message
        /// </summary>
        public Command JoinRoomCommand
        {
            get
            {
                return joinRoomCommand ??
                    (joinRoomCommand = new Command(ExecuteJoinRoomCommand));
            }
        }

        async void ExecuteJoinRoomCommand()
        {
            IsBusy = true;
            await _chatServices.JoinGroup(_roomName);
            IsBusy = false;
        }

        #endregion
    }
}
