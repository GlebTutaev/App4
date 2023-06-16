using App4.Models;
using App4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SProgrmsSecond : ContentPage
	{
		public SProgrmsSecond (List<StudyingPrograms> newItems)
		{
			InitializeComponent ();
			MainCvSecond.ItemsSource = newItems;
		}

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var item = e.CurrentSelection[0] as StudyingPrograms;
            if (item != null)
                await Navigation.PushAsync(new ProgramPage(item));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //string x;
            //MainCv.ItemsSource = new StudyingPrograms().ToString();  
            //x = MainCv.ItemsSource.ToString();

            var items = MainCvSecond.ItemsSource;

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
    }
}