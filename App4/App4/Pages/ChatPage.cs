using App4.Controls;
using App4.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App4.Pages
{
    public class ChatPage : BasePage<ChatViewModel>
    {
        private Entry nameEntry;
        private Entry messageEntry;
        private Button sendMessageButton;
        private Button joinButton;

        public ChatPage()
        {
           

            //Init Name Entry
            nameEntry = new Entry
            {
                TextColor = Color.Black
            };
            nameEntry.SetBinding(Entry.TextProperty, "ChatMessage.Name", BindingMode.TwoWay);
            nameEntry.Text = "BaseRoom";
            //Init Message Entry
            messageEntry = new Entry
            {
                TextColor = Color.Black
            };
            messageEntry.SetBinding(Entry.TextProperty, "ChatMessage.Message");
            messageEntry.Text = "Write your message";
            sendMessageButton = new Button
            {
                Text = "Send Message"
            };
            sendMessageButton.SetBinding(Button.CommandProperty, "SendMessageCommand");

            var messageList = new ChatListView();
            messageList.VerticalOptions = LayoutOptions.FillAndExpand;
            messageList.SetBinding(ChatListView.ItemsSourceProperty, new Binding("Messages"));
            messageList.ItemTemplate = new DataTemplate(CreateMessageCell);

            var stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(5, 20, 5, 10),
                Children = {                   
                    nameEntry,
                    messageEntry,
                    sendMessageButton
                }
            };

            Content = new StackLayout
            {
                Children =
                {
                    stackLayout,
                    messageList
                }
            };
        }

        private Cell CreateMessageCell()
        {
            var timestampLabel = new Label();
            timestampLabel.SetBinding(Label.TextProperty, new Binding("Timestamp", stringFormat: "[{0:HH:mm}]"));
            timestampLabel.TextColor = Color.Silver;
            timestampLabel.FontSize = 14;

            var authorLabel = new Label();
            authorLabel.SetBinding(Label.TextProperty, new Binding("ChatMessage.Name", stringFormat: "{0}: "));
            authorLabel.TextColor = Device.OnPlatform(Color.Blue, Color.Yellow, Color.Yellow);
            authorLabel.FontSize = 14;

            var messageLabel = new Label();
            messageLabel.SetBinding(Label.TextProperty, new Binding("ChatMessage.Message"));
            messageLabel.FontSize = 14;

            var stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { authorLabel, messageLabel }
            };

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                stack.Children.Insert(0, timestampLabel);
            }

            var view = new MessageViewCell
            {
                View = stack
            };
            return view;
        }
    }
}
