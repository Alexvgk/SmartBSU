using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBSU.Views;
using Xamarin.Forms;
using SmartBSU.Views.SingUp;

namespace SmartBSU.ViewModels
{
    class WelcomeViewModel : BaseViewModel
    {
        public Command SingupCommand { get; }
        public Command LoginCommand { get; }
        public WelcomeViewModel()
        {
            SingupCommand = new Command(OnSingup);
            LoginCommand = new Command(OnLogin);
        }

        private void OnLogin(object obj)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new LogInPage());
        }

        private void OnSingup(object obj)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new SingupPage());
        }
    }
}