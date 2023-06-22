using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBSU.Views;
using Xamarin.Forms;
using Model;
using SmartBSU.Services.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartBSU.Services.DataStore;
using Model.Base;
using SmartBSU.Views.SingUp;

namespace SmartBSU.ViewModels.PopupsVM
{
    public class CodeViewModel : BaseViewModel {
        private Guid guid;
        private short occasions = 3;
        private string enteredCode;
        public Command CheckCodeCommand { get; }

        public string EnteredCode
        {
            get => enteredCode; 
            set => enteredCode = value;
        }

        public CodeViewModel(Guid guid)
        {
            CheckCodeCommand = new Command(OnOK);
            this.guid = guid;
        }

        private async void OnOK(object obj)
        {
            DBDataStore<RegCode> dataStore = new DBDataStore<RegCode>();
            var item = dataStore.GetItemAsync(guid, "api/RegCode");
            //code = item.Result.RegistCode;
            occasions--;
            if(occasions != 0 && enteredCode != null && enteredCode.CompareTo(item.Result.RegistCode) == 0)
            {
                 await App.Current.MainPage.Navigation.PopPopupAsync();
                 await App.Current.MainPage.Navigation.PushModalAsync(new PasswordPage(item.Result.UserId.Value));
            }
            else if (occasions == 0)
            {
                DBDataStore<BaseModel> deleteStore = new DBDataStore<BaseModel>();
                var responseCode = deleteStore.DeleteItemAsync(item.Result.Id, "api/RegCode");
                var responseUser = deleteStore.DeleteItemAsync(item.Result.UserId.Value, "api/User");
                await App.Current.MainPage.Navigation.PopPopupAsync();

            }
           
        }
    }

}
