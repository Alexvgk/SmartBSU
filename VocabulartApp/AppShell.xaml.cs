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
        private static Models.User user;

        public static Models.User User {get { return user;}}
        public AppShell(Models.User loguser)
        {  
             user = loguser; 
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            //Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
           // Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
        }
    }
}
