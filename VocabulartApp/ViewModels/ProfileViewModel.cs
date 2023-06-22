using Model;
using SmartBSU.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartBSU.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private User user;
        public Command ChangeCommand { get; }
        public Command BindingCommand { get; }
        public ProfileViewModel()
        {
            Title = "Profile";
            User = AppShell.User;
            ChangeCommand = new Command(OnChange);
            BindingCommand = new Command(OnBinding);
        }

        private async void OnBinding(object obj)
        {
            await Shell.Current.GoToAsync(nameof(CardDetectionPage));
        }

        private async void OnChange(object obj)
        {
            await Shell.Current.GoToAsync(nameof(ProfileChangePage));
            User = AppShell.User;
        }

        public User User
        {
            get { return user; }
            set
            {
                SetProperty(ref user, value);
                OnPropertyChanged();
            }
        }
    }
}
