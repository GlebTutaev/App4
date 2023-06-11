
using App4;
using App4.Views;
using SelectionCommittee.Models;
using SelectionCommittee.ViewModels;
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
    public partial class SPrograms : ContentPage
    {
        public SPrograms()
        {
            InitializeComponent();
            BindingContext = new StudyingProgramsViewModel();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync( new FilterPage());
            
             
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var item = e.CurrentSelection[0] as StudyingPrograms;
            if (item != null) 
                await Navigation.PushAsync(new ProgramPage(item));
        }
    }
}