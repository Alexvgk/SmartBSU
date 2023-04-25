using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartBSU.ViewModels.PopupsVM
{
    public class PopupUidViewModel : BaseViewModel
    {
        Models.Person person;
        public Command FinishCommand { get; }
        public PopupUidViewModel(Models.Person person)
        {         
            this.person = person;
            FinishCommand = new Command(OnFinish);
        }

        private async void OnFinish()
        {
            await App.Current.MainPage.Navigation.PopPopupAsync();
            App.Current.MainPage = new AppShell(person);
        }
    }
}
