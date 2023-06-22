using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Model;
using SmartBSU.Services.Data;
using SmartBSU.Views;
using SmartBSU.Views.Popups;
using SmartBSU.Views.SingUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartBSU.ViewModels.Login
{
    public class CardDetectionLogInVM : BaseViewModel
    {
        private string uid;

        public string Uid
        {
            get => uid;
            set => SetProperty(ref uid, value);
        }
        public Command ShowUID { get; }
        public static async Task DisplayAlertAsync(string msg)
        {
            if (Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.Last().GetType() == typeof(CardDetectionLoginPage) )
            {
                User user = new User();
                using var dbContext = new MyDbContext();
                {
                    try
                    {
                     //   user = dbContext.users.FirstOrDefault(u => u.Uid == msg);
 
                    }
                    catch (NullReferenceException)
                    {

                    }
                    string userJson = JsonConvert.SerializeObject(user);
                    App.Current.Properties["LoggedInUser"] = userJson;
                    await Device.InvokeOnMainThreadAsync(async () => App.Current.MainPage = new AppShell(user));
                }
            }
            //await Device.InvokeOnMainThreadAsync(async () => await Xamarin.Forms.Application.Current.MainPage.Navigation.PushPopupAsync(new PopupUidShow(msg)));
        }
    }
}
