using Microsoft.EntityFrameworkCore;
using Model;
using MySqlConnector;
using Rg.Plugins.Popup.Extensions;
using SmartBSU.Services.DataStore;
using SmartBSU.Services.MailSender;
using SmartBSU.Views.Popups;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xamarin.Forms;

namespace SmartBSU.ViewModels.Singup
{
    public class PasswordViewModel: BaseViewModel
    {
        private Guid id;
        private string password;
        private string inccorectMessege = null;
        public Command SetCommand { get; }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string IncorrectMessege
        {
            get => inccorectMessege;
            set => SetProperty(ref inccorectMessege, value);
        }

        public PasswordViewModel(Guid guid)
        {
            id = guid;
            SetCommand = new Command(OnSetClicked, ValidateSave);
            PropertyChanged +=
                (_, __) => SetCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return (!string.IsNullOrWhiteSpace(password) && password.Length >= 8);
        }


        private async void OnSetClicked()
        {
            try
            {
            IncorrectMessege = null;
            DBDataStore<User> dataStore = new DBDataStore<User>();
            var user = await dataStore.GetItemAsync(id, "api/User");
                if(user != null)
                {
                user.Password = password;
                var response = dataStore.UpdateItemAsync(user,"api/User").Result;
                if(response) {
                        App.Current.MainPage = new AppShell(user);
                    }
                }

            }
            catch (IndexOutOfRangeException)
            {
                IncorrectMessege = "not email";
            }
            catch (DbUpdateException)
            {
                IncorrectMessege = "This email is used";
            }
            catch (SmtpException e)
            {
                IncorrectMessege = e.Message;
            }

        }
    }
}
