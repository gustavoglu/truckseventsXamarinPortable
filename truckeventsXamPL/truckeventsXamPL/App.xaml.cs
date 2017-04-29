using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using truckeventsXamPL.Pages.Login;
using truckeventsXamPL.Pages.Registro;
using Xamarin.Forms;

namespace truckeventsXamPL
{
    public partial class App : Application
    {
        public static NavigationPage Nav { get; set; }

        public App()
        {
            InitializeComponent();
            Nav = new NavigationPage(new Registro_Page());
            MainPage = Nav; 
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
