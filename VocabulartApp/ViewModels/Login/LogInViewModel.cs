using Java.Net;
using Java.Util;
using Microsoft.EntityFrameworkCore;
using Model;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using SmartBSU.Services.DataStore;
using SmartBSU.Views.Popups;
using SmartBSU.Views.SingUp;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartBSU.ViewModels.Login
{
    public class LogInViewModel :BaseViewModel
    {
        private string email;
        private string password;
        private string inccorectMailMessege = null;
        public Command EnterCommand { get; }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string IncorrectMailMessege
        {
            get => inccorectMailMessege;
            set => SetProperty(ref inccorectMailMessege, value);
        }

        public LogInViewModel()
        {
            //newPerson = new User();
            EnterCommand = new Command(OnLoginClicked, ValidateSave);
            PropertyChanged +=
                (_, __) => EnterCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password));
        }

        private async void OnLoginClicked()
        {
            try
            {
                DBDataStore<User> dataStore = new DBDataStore<User>();
                var users = await dataStore.GetItemsAsync("api/User");
                if (users != null)
                {
                    var user = users.Where(x => x.Email == email).FirstOrDefault(m => m.Password == password);
                    if (user != null)
                    {
                        string userJson = JsonConvert.SerializeObject(user);
                        App.Current.Properties["LoggedInUser"] = userJson;
                        App.Current.MainPage = new AppShell(user);
                    }
                    else
                    {
                        IncorrectMailMessege = "No user with this email and password";
                    }
                }
            }
            catch (Java.Net.UnknownHostException)
            {
                await Device.InvokeOnMainThreadAsync(async ()
                                => await Xamarin.Forms.Application.Current.MainPage.Navigation
                                .PushPopupAsync(new PopupMessage("Fail", "no Internet connection")));
            }
        }

        public static async Task DisplayAlertAsync(string msg)
        {
            try
            {
                if (Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.Last().GetType() == typeof(LogInPage))
                {
                    DBDataStore<UID> dataStore = new DBDataStore<UID>();
                    var Uids = await dataStore.GetItemsAsync("api/Uid");
                    if (Uids != null)
                    {
                        var uid = Uids.FirstOrDefault(x => x.Uid == msg);
                        if (uid != null)
                        {
                            DBDataStore<User> DBuser = new DBDataStore<User>();
                            var user = DBuser.GetItemAsync(uid.UserId.Value, "api/User");
                            await Device.InvokeOnMainThreadAsync
                                (async () => await Xamarin.Forms.Application.Current.MainPage.Navigation.PushPopupAsync(new PopupUidShow(user.Result.Id)));
                        }
                        else
                        {
                            await Device.InvokeOnMainThreadAsync(async ()
                                => await Xamarin.Forms.Application.Current.MainPage.Navigation
                                .PushPopupAsync(new PopupMessage("Fail", "no user with this card")));
                        }

                    }
                }
            }
            catch (DbUpdateException)
            {
                msg = "This card is used";
            }
            catch(Java.Net.UnknownHostException)
            {
                await Device.InvokeOnMainThreadAsync(async ()
                                => await Xamarin.Forms.Application.Current.MainPage.Navigation
                                .PushPopupAsync(new PopupMessage("Fail", "no Internet connection")));
            }
        }
    }
}
