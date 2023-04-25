using System;
using System.Threading.Tasks;
using SmartBSU.Services.DataStore;
using SmartBSU.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartBSU
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new WelcomePage();
        }

        protected override void OnStart()
        {
            //await Shell.Current.Navigation.PushAsync(new WelcomePage());  
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
