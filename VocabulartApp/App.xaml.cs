using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartBSU.Models;
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
            if (Application.Current.Properties.ContainsKey("LoggedInUser"))
            {
                string userJson = (string)Application.Current.Properties["LoggedInUser"];
                Models.User loggedInUser = JsonConvert.DeserializeObject<Models.User>(userJson);
                MainPage = new AppShell(loggedInUser);
            }
            else
                MainPage = new WelcomePage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
