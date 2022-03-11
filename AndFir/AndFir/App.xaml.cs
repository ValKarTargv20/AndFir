using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndFir
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); //zamena nachalnoj stranicy
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
