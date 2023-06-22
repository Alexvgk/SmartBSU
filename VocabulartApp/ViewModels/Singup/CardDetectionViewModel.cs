using Android.Nfc;
using Android;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using System.Threading.Tasks;
using SmartBSU.Views;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using Rg.Plugins.Popup.Extensions;
using SmartBSU.Views.Popups;
using System.Linq;
using SmartBSU.Services.Data;
using Microsoft.EntityFrameworkCore;
using Model;
using SmartBSU.Services.DataStore;
using SmartBSU.Views.SingUp;

namespace SmartBSU.ViewModels.Singup
{
    public class CardDetectionViewModel : BaseViewModel
    {
        // private static Models.Person person;
       // private static Guid GuId;
        private string uid;

        public string Uid
        {
            get => uid;
            set => SetProperty(ref uid, value);
        }
        public Command ShowUID { get; }
        public CardDetectionViewModel()
        {
        }
        public static async Task DisplayAlertAsync(string msg)
        {
            try
            {
                if (Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.Last().GetType() == typeof(CardDetectionPage))
                {
                    DBDataStore<UID> dataStore = new DBDataStore<UID>();
                    var uid = new UID() { Id = Guid.NewGuid(), Uid = msg, UserId = AppShell.User.Id };
                    var response = await dataStore.AddItemAsync(uid, "api/Uid");
                    if (response)
                    {
                        await Device.InvokeOnMainThreadAsync(async ()
                                 => await Xamarin.Forms.Application.Current.MainPage.Navigation
                                 .PushPopupAsync(new PopupMessage("Card bind", "your UID\n"+msg)));
                        await Shell.Current.GoToAsync("..");
                    }
                    else {
                        await Device.InvokeOnMainThreadAsync(async ()
                                => await Xamarin.Forms.Application.Current.MainPage.Navigation
                                .PushPopupAsync(new PopupMessage("Fail", "this card is used")));
                    }
                }
            }
            catch (Exception)
            {
                msg = "This card is used";
            }
        }

    }
}
