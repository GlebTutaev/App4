using SelectionCommittee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.AppleSignInAuthenticator;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgramPage : ContentPage
    {
        public ProgramPage(StudyingPrograms item)
        {
            InitializeComponent();

            if (item.tvimg != "")
            {
                ImageField.Source = "https://mosap-orenburg.ru/" + item.tvimg;
            }
            else
            {
                ImageField.Source = "https://img.uxwing.com/wp-content/themes/uxwing/download/web-app-development/image-not-found-icon.svg";
            }


            Introtext.Text = item.introtext;
            if (Introtext.Text == "")
            {

                IntrotextFrame.IsVisible = false;
            }

            Price.Text = item.tvprice;

            Pagetitle.Text = item.pagetitle;

            
            

            Ochno.Text = item.tvochno == "" ? null : "Очная";
            Zaochno.Text = item.tvzaochno == "" ? null : "Заочная";
            Distant.Text = item.tvdistant == "" ? null : "Дистанционная";

            if (Ochno.Text is null && Zaochno.Text is null && Distant.Text is null)
            {
                EducationForm.IsVisible = false;
            }

            if (item.tvexamen is null) return;
            Exam_1.Text = item.tvexamen[0].predmet;
            Exam_2.Text = item.tvexamen[1].predmet;
            Exam_3.Text = item.tvexamen[2].predmet;

            string word = item.tvexamen[1].predmet;
            string cleaned = word.Replace("\n", "").Replace("\r", "");
            Exam_2.Text = cleaned;

            if (item.tvoptions is null) return;

            Options_1.Text = item.tvoptions[0].option1 == "" ? item.tvoptions[0].option2 : item.tvoptions[0].option1;
            Options_2.Text = item.tvoptions[1].option1 == "" ? item.tvoptions[1].option2 : item.tvoptions[1].option1;
            Options_3.Text = item.tvoptions[2].option1 == "" ? item.tvoptions[2].option2 : item.tvoptions[2].option1;

           

            
        }
    }
}