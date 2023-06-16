using App4.Models;
using App4.ViewModels;
using App4.Views;
using SelectionCommittee.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        

        public List<StudyingPrograms> Items { get; set; }

        public FilterPage(List<StudyingPrograms> newItems)
        {
            InitializeComponent();
            Items = newItems;
            BindingContext = new StudyingProgramsViewModel();
        }

        

        private async void Filter_Applications_Btn(object sender, EventArgs e)
        {

         var FT = Fulltime.IsEnabled;
         var PE = ParttimeEvening.IsEnabled;
         var D = Distance.IsEnabled;
         var M = Magistracy.IsEnabled;
         var C = College.IsEnabled;
         var HE = HigherEducation.IsEnabled;
         var newItems = Items; 
           if (FT)
            {
                newItems = newItems.Where(x => x.tvochno == "1").ToList();              
            }
            if (PE)
            {
                newItems = newItems.Where(x => x.tvzaochno == "1").ToList();                
            }
            if (D)
            {
                newItems = newItems.Where(x => x.tvdistant == "1").ToList();
               
            }
            if (M)
            {
                newItems = newItems.Where(x => x.tvdistant == "1").ToList();               
            }
            if (C)
            {
                newItems = newItems.Where(x => x.tvdistant == "1").ToList();              
            } 
            if (HE)
            {
                newItems = newItems.Where(x => x.tvdistant == "1").ToList();            
            }
            await Navigation.PushAsync(new SProgrmsSecond(newItems));
        }

        
        private async void Filter_Removes_Btn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SPrograms());
        }
    }
}