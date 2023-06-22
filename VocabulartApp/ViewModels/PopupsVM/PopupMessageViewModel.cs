using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartBSU.ViewModels.PopupsVM
{
    public class PopupMessageViewModel : BaseViewModel
    {
        private string status;
        private string message;
        public Command OkCommand { get; }

        public string Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public PopupMessageViewModel(string status, string message)
        {
            this.message = message;
            this.status = status;
            OkCommand = new Command(OnOk);
        }

        private async void OnOk(object obj)
        {
            await App.Current.MainPage.Navigation.PopPopupAsync(); ;
        }
    }
}
