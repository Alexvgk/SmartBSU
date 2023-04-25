using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartBSU.ViewModels;
using SmartBSU.Views;
using Xamarin.Forms;

namespace SmartBSU
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private Models.Person person;
        public AppShell(Models.Person person)
        {
            this.person = person;   
            InitializeComponent();
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
           // Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
        }
    }
}
