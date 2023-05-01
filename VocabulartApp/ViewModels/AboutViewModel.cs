using SmartBSU.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartBSU.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://vk.com/tcemi"));
            ExitCommand = new Command(OnExit);
        }

        private async void OnExit(object obj)
        {
            if (Application.Current.Properties.ContainsKey("LoggedInUser"))
            {
                Application.Current.Properties.Remove("LoggedInUser");
                await Application.Current.SavePropertiesAsync();
                App.Current.MainPage = new WelcomePage();
            }
        }

        public ICommand OpenWebCommand { get; }
        public ICommand ExitCommand { get; }
    }
}