using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SelectionCommittee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        private void Button_Message(object sender, EventArgs e)
        {
            if (PhoneE.Text != null && NameE.Text != null && MeesageE.Text != null)
            {
                DisplayAlert("Уведомление", "Сообщение успешно отправлено!", "Ok");
            }
            else { DisplayAlert("Уведомление", "Поле не заполнено или заполнено неверно!", "Ok"); }


        }
    }
}