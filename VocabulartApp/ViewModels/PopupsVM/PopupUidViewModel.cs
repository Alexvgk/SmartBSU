using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using SmartBSU.Models;
using SmartBSU.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static Java.Util.Jar.Attributes;

namespace SmartBSU.ViewModels.PopupsVM
{
    public class PopupUidViewModel : BaseViewModel
    {
        private string uid;
        public Command FinishCommand { get; }
        public PopupUidViewModel(string uid)
        {         
            this.uid = uid;
            FinishCommand = new Command(OnFinish);
        }

        private async void OnFinish()
        {
            await App.Current.MainPage.Navigation.PopPopupAsync();
            if (uid != "This card is used")
            {
                using (var dbContext = new MyDbContext())
                {
                    var user = dbContext.users.FirstOrDefault(u => u.Uid == uid);
                    string userJson = JsonConvert.SerializeObject(user);
                    App.Current.Properties["LoggedInUser"] = userJson;
                    App.Current.MainPage = new AppShell(user);
                }
            }

            //App.Current.MainPage = new AppShell(user);
        }
    }
}
