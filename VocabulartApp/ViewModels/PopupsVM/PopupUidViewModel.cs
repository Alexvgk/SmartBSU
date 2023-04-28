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
        private string uid;
        public Command FinishCommand { get; }
        public PopupUidViewModel(string uid)
        {         
            this.uid = uid;
            FinishCommand = new Command(OnFinish);
        }

        private async void OnFinish()
        {
            await App.Current.MainPage.Navigation.PopPopupAsync();
            App.Current.MainPage = new AppShell(uid);
        }
    }
}
