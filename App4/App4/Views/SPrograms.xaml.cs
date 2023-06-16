
using App4;
using App4.Models;
using App4.ViewModels;
using App4.Views; 
using System;
using System.Collections.Generic;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SelectionCommittee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SPrograms : ContentPage
    {
        public SPrograms()
        {
            InitializeComponent();
            BindingContext = new StudyingProgramsViewModel();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var items = MainCv.ItemsSource;
            List<StudyingPrograms> newItems = new List<StudyingPrograms>();

            foreach (var item in items) 
            {
                newItems.Add(item as StudyingPrograms);
            }
            var x = new StudyingProgramsViewModel();

            FilterPage filterPage = new FilterPage(newItems);
            filterPage.BindingContext = x;

            await Navigation.PushAsync(filterPage);                        
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection[0] as StudyingPrograms;
            if (item != null) 
                await Navigation.PushAsync(new ProgramPage(item));
        }
    }
}