using Android.Views.Animations;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBSU.Views;
using Xamarin.Forms;
using SmartBSU.Services.MailSender;
using SmartBSU.Services.InternetConnection;
using SmartBSU.Views.Popups;
using Rg.Plugins.Popup.Extensions;

namespace SmartBSU.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private SmartBSU.Models.Person newPerson;
        private string email;   
        private string code;
        private string inccorectMailMessege = null;
        public Command LoginCommand { get;}

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Code
        {
            get => code;
            set => SetProperty(ref code, value);
        }

        public string IncorrectMailMessege
        {
            get => inccorectMailMessege;
            set => SetProperty(ref inccorectMailMessege, value);
        }

        public LoginViewModel()
        {
            newPerson = new SmartBSU.Models.Person();
            LoginCommand = new Command(OnLoginClicked,ValidateSave);
            this.PropertyChanged +=
                (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(email);
        }
        private void CheckCodeState() {

            if (code.CompareTo(code) == 0)
            {
                Shell.Current.GoToAsync(nameof(CardDetectionPage));
            }
        }

        private async  void OnLoginClicked()
        {
            try
            {
                 IInternetConnection connection = new CheckInternetConnection();
                if (connection.IsConnected())
                {
                    var splitmail = email;
                    if (splitmail.Split('@')[1] == "bsu.by")
                    {
                        IMailSender sender = new BasicMailSender();
                        sender.SendMail(email,out double code_d);
                        code = code_d.ToString();
                        IncorrectMailMessege = null;
                        newPerson.Email = email;
                        await App.Current.MainPage.Navigation.PushPopupAsync(new PopupCodeEnter(code,newPerson));
                    }
                    else
                        IncorrectMailMessege = "not BSU email";
                }
                else
                    IncorrectMailMessege = "no Internet connection";
            }
            catch (IndexOutOfRangeException)
            {
                IncorrectMailMessege =  "not email";
            }

        }
    }
}
