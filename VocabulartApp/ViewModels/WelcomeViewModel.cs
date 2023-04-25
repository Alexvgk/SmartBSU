using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBSU.Views;
using Xamarin.Forms;

namespace SmartBSU.ViewModels
{
    class WelcomeViewModel : BaseViewModel
    {
        public Command StartCommand { get; }
        public WelcomeViewModel()
        {
            StartCommand = new Command(OnStart);

        }

        private void OnStart(object obj)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }
    }
}