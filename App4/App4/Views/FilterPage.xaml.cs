using Newtonsoft.Json;
using SelectionCommittee.Models;
using SelectionCommittee.Services;
using SelectionCommittee.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public FilterPage()
        {
            InitializeComponent();
        }

        public string Base_url = "https://mosap-orenburg.ru/output.json";

        public async Task<ObservableCollection<StudyingPrograms>> getProgram()
        {
            string url = Base_url;

            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(url);

            if (message.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await message.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<ObservableCollection<StudyingPrograms>>(result);

                return json;
            }

            return null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
         var FT = Fulltime.IsEnabled;

        var items = getProgram();
        
            
            if (FT)
            {
                
            }



        }
    }
}