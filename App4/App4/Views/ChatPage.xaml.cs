using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace SelectionCommittee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        private async void Button_Message(object sender, EventArgs e)
        {
            string phone = PhoneE.Text;
            string message = MeesageE.Text;
            string name = NameE.Text;


            string phonePattern = @"^((\+7|7|8)+([0-9]){10})$"; 

            if (PhoneE.Text == null && NameE.Text == null && MeesageE.Text == null)
            {

                DisplayAlert("Уведомление!", "Поле не заполнено или заполнено неверно!", "Ok");
            }
            else 
            {
                if (Regex.IsMatch(phone, phonePattern))
                {
                    var client = new HttpClient();

                    DisplayAlert("Уведомление!", "Сообщеие успешно отправлено!", "Ок");
                    ErrorLabel.Text = "";
                    var obj = new { message = message, phone = phone, name = name };
                    var json = JsonConvert.SerializeObject(obj);
                    HttpContent content = new StringContent(json);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    var response =  client.PostAsync("", content);
                }
                else
                {
                    ErrorLabel.Text = "Номер телефона введен неверно!";
                }
                 
            }


        }
    }
}