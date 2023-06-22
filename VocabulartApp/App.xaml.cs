using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Model;
using SmartBSU.Services.DataStore;
using SmartBSU.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartBSU.Views.SingUp;
using Model.Base;

namespace SmartBSU
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Configuration config = ConfigurationManager.OpenExeConfiguration(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.config"));
            DependencyService.Register<DBDataStore<BaseModel>>();
            MainPage = new WelcomePage();
        }

        protected override void OnStart()
        {
            if (Application.Current.Properties.ContainsKey("LoggedInUser"))
            {
                string userJson = (string)Application.Current.Properties["LoggedInUser"];
                User loggedInUser = JsonConvert.DeserializeObject<User>(userJson);
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
