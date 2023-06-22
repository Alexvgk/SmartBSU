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
using Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;
using SmartBSU.Services.DataStore;
using static Android.Telephony.CarrierConfigManager;

namespace SmartBSU.ViewModels.Singup
{
    public class SingupViewModel : BaseViewModel
    {
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
            //newPerson = new User();
            LoginCommand = new Command(OnLoginClicked, ValidateSave);
            PropertyChanged +=
                (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(email);
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
                    IncorrectMailMessege = null;
                    var regCode = new RegCode { Id = Guid.NewGuid(), RegistCode = code };
                    var newUser = new User { Id = Guid.NewGuid(), Email = email, RegCode = regCode};
                    //regCode.User = newUser;
                    DBDataStore<User> dataStore = new DBDataStore<User>();
                    if (await dataStore.AddItemAsync(newUser, "api/User"))
                    {
                        await App.Current.MainPage.Navigation.PushPopupAsync(new PopupCodeEnter(regCode.Id));
                    }
                      //  var json_user = JsonConvert.SerializeObject(newUser);
                       // var json_code = JsonConvert.SerializeObject(regCode);
                       // http.BaseAddress = new Uri("https://smart.dev.rfct.info");
                        //var relativeUri = "api/User";
                        // Создаем контент запроса
                        //var content_user = new StringContent(json_user, Encoding.UTF8, "application/json");
                        // Отправка POST-запроса
                        //var response = await http.PostAsync(relativeUri, content_user);
                       // if (response.IsSuccessStatusCode)
                       // {
                            // Получение ответа в виде строки
                        //    var responseContent = await response.Content.ReadAsStringAsync();

                            // Десериализация ответа в объект пользователя
                         //   var createdUser = JsonConvert.DeserializeObject<User>(responseContent);

                          //  Console.WriteLine($"User {createdUser.Id} was created successfully.");
                   // }

                       // var regCode = new RegCode { Id = Guid.NewGuid(), RegistCode = code };
                       // var newUser = new User { Id = Guid.NewGuid(), Email = email, RegCode = regCode };
                        //http.PostAsync(newUser)
                        //id = newUser.Id;
                        //dbContext.RegistCodes.Add(regCode);
                        //dbContext.users.Add(newUser);
                        //dbContext.SaveChanges();
                  //  }
                 //   await Application.Current.MainPage.Navigation.PushPopupAsync(new PopupCodeEnter(id));
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
