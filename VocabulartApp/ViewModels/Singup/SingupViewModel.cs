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
using System.Net.Mail;
using SmartBSU.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SmartBSU.ViewModels.Singup
{
    public class SingupViewModel : BaseViewModel
    {
        private User newPerson;
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

        public SingupViewModel()
        {
            newPerson = new User();
            LoginCommand = new Command(OnLoginClicked, ValidateSave);
            PropertyChanged +=
                (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(email);
        }
        private void CheckCodeState()
        {

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
                    // var regCode = new RegCode { RegistCode = code };
                    //MySQLConnector.MySQLConnector.SetEmailToDB(email, code);
                    // await App.Current.MainPage.Navigation.PushPopupAsync(new PopupCodeEnter(email));
                    IncorrectMailMessege = null;
                    using (var dbContext = new MyDbContext())
                    {
                        var regCode = new RegCode { RegistCode = code };
                        var newUser = new User { Email = email, RegCode = regCode };
                        dbContext.RegistCodes.Add(regCode);
                        dbContext.users.Add(newUser);
                        dbContext.SaveChanges();
                    }
                    await Application.Current.MainPage.Navigation.PushPopupAsync(new PopupCodeEnter(email));
                }
                //await App.Current.MainPage.Navigation.PushPopupAsync(new PopupCodeEnter(code,newPerson));
                else
                    IncorrectMailMessege = "not BSU email";
            }
            catch (IndexOutOfRangeException)
            {
                IncorrectMailMessege = "not email";
            }
            catch (MySqlException)
            {
                IncorrectMailMessege = "Something wrong";
            }
            catch (DbUpdateException)
            {
                IncorrectMailMessege = "This email is used";
            }
            catch (SmtpException e)
            {
                IncorrectMailMessege = e.Message;
            }

        }
    }
}
