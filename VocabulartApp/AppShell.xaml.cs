using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartBSU.ViewModels;
using SmartBSU.Views;
using Xamarin.Forms;
using Model;

namespace SmartBSU
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private static User user;

        public static User User {get { return user;}}
        public AppShell(User loguser)
        {  
            user = loguser; 
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(CardDetectionPage), typeof(CardDetectionPage));
            Routing.RegisterRoute(nameof(ProfileChangePage), typeof(ProfileChangePage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));

        }

        public static void UpdateUser(User chUser)
        {
            user = chUser;
        }
    }
}
