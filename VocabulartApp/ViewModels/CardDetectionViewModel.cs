using Android.Nfc;
using Android;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using System.Threading.Tasks;
using SmartBSU.Services.Reservation;
using SmartBSU.Views;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using Rg.Plugins.Popup.Extensions;
using SmartBSU.Views.Popups;
using System.Linq;

namespace SmartBSU.ViewModels
{
    public class CardDetectionViewModel : BaseViewModel
    {
       // private static Models.Person person;
        private static string Email;
        private string  uid;

        public string Uid
        {
            get => uid;
            set => SetProperty(ref uid, value);
        }
        public Command ShowUID { get; }
        public CardDetectionViewModel(string email)
        {
            Email = email; 
        }
        public static async Task DisplayAlertAsync(string msg)
        {
            if (App.Current.MainPage.Navigation.ModalStack.Last().GetType() == typeof(CardDetectionPage))
            {
                MySQLConnector.MySQLConnector.SetUIDToDB(msg, Email);
                Email = null;
            }
                await Device.InvokeOnMainThreadAsync(async () => await App.Current.MainPage.Navigation.PushPopupAsync(new PopupUidShow(msg)));
        }
    }
}
