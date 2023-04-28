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
using SmartBSU.Services.Data;
using MySqlConnector;
using SmartBSU.MySQLConnector;
using System.Net.Mail;

namespace SmartBSU.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private Models.Person newPerson;
        private string email;
        private string code;
        private string inccorectMailMessege = null;
        public Command LoginCommand { get; }

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
            LoginCommand = new Command(OnLoginClicked, ValidateSave);
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

        private async void OnLoginClicked()
        {
            try
            {
                //IInternetConnection connection = new CheckInternetConnection();
                var splitmail = email;
                if (splitmail.Split('@')[1] == "bsu.by")
                {
                    IMailSender sender = new BasicMailSender();
                    sender.SendMail(email, out double code_d);
                    code = code_d.ToString();
                    MySQLConnector.MySQLConnector.SetEmailToDB(email, code);
                    //await App.Current.MainPage.Navigation.PushPopupAsync(new PopupCodeEnter(email));
                    IncorrectMailMessege = null;

                    // using (UserContext uc = new UserContext()) {
                    //   uc.Persons.Add(newPerson);
                    //   uc.SaveChanges();
                }
                //await App.Current.MainPage.Navigation.PushPopupAsync(new PopupCodeEnter(code,newPerson));
                else
                    IncorrectMailMessege = "not BSU email";
            }
            catch (IndexOutOfRangeException)
            {
                IncorrectMailMessege = "not email";
            }
            catch (MySqlConnector.MySqlException)
            {
                IncorrectMailMessege = "You're already registered";
            }
            catch (SmtpException e)
            {
                IncorrectMailMessege = e.Message;
            }

        } 
    }
}
