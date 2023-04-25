using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBSU.Views;
using Xamarin.Forms;

namespace SmartBSU.ViewModels.PopupsVM
{
    public class CodeViewModel : BaseViewModel {
        private SmartBSU.Models.Person person;
        private short occasions = 3;
        private string enteredCode;
        private string code;
        public Command CheckCodeCommand { get; }

        public string EnteredCode
        {
            get => enteredCode; 
            set => enteredCode = value;
        }

        public CodeViewModel(string code,SmartBSU.Models.Person person)
        {
            this.code = code;   
            this.person = person;
            CheckCodeCommand = new Command(OnOK);
        }

        private async void OnOK(object obj)
        {
            occasions--;
            if(occasions != 0 && enteredCode != null && enteredCode.CompareTo(code) == 0)
            {
                 await App.Current.MainPage.Navigation.PopPopupAsync();
                 await App.Current.MainPage.Navigation.PushModalAsync(new CardDetectionPage(person));
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
