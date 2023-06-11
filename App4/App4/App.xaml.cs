using App4.Pages;
using App4.Services;
using App4.ViewModel;
using SelectionCommittee.Services;
using SelectionCommittee.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    public partial class App : Application
    {
        public static string SignalRUrl { get { return "http://192.168.0.8:62265/"; } }
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IStudyingProgramsServices, StudyingProgramsServices>();

            MainPage = new NavigationPage(  new MainPage());
            NavigationPage.SetHasNavigationBar(this, false);
            //MainPage = new ChatPage { BindingContext = new ChatViewModel() };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
