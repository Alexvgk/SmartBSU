using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBSU.Views;
using Xamarin.Forms;

namespace SmartBSU.ViewModels.PopupsVM
{
    public class CodeViewModel : BaseViewModel {
        private string email;
        private short occasions = 3;
        private string enteredCode;
        private string code;
        public Command CheckCodeCommand { get; }

        public string EnteredCode
        {
            get => enteredCode; 
            set => enteredCode = value;
        }

        public CodeViewModel(string email)
        {
            CheckCodeCommand = new Command(OnOK);
            this.email = email;
        }

        private async void OnOK(object obj)
        {
            if(code == null)
            {
                code = MySQLConnector.MySQLConnector.GetCodeFormDB(email);
            }
            occasions--;
            if(occasions != 0 && enteredCode != null && enteredCode.CompareTo(code) == 0)
            {
                 await App.Current.MainPage.Navigation.PopPopupAsync();
                 await App.Current.MainPage.Navigation.PushModalAsync(new CardDetectionPage(email));
            }
            else
            {
                if(occasions == 0)
                {
                     await App.Current.MainPage.Navigation.PopPopupAsync();
                }
            }
           
        }
    }

}
