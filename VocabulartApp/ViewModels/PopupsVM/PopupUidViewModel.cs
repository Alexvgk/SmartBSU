using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Model;
using SmartBSU.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static Java.Util.Jar.Attributes;
using SmartBSU.Services.DataStore;

namespace SmartBSU.ViewModels.PopupsVM
{
    public class PopupUidViewModel : BaseViewModel
    {
        private Guid id;
        private string viewId;
        public Command FinishCommand { get; }

        public string ViewId
        {
            get => viewId;
            set => SetProperty(ref viewId, value);
        }

        public PopupUidViewModel(Guid uid)
        {
            this.id = uid;
            viewId = uid.ToString();
            FinishCommand = new Command(OnFinish);
        }

        private async void OnFinish()
        {
            await App.Current.MainPage.Navigation.PopPopupAsync();
            DBDataStore<User> dataStore = new DBDataStore<User>();
            var user = await dataStore.GetItemAsync(id, "api/User");
            if (user != null)
            {
                string userJson = JsonConvert.SerializeObject(user);
                App.Current.Properties["LoggedInUser"] = userJson;
                App.Current.MainPage = new AppShell(user);
            }
        }
    }
}
