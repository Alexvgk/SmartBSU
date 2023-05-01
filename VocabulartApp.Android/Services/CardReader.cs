using Android.App;
using Android.Content;
using Android.Nfc.Tech;
using Android.Nfc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartBSU.Views;
using Android.OS;
using SmartBSU.Services.Reservation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using SmartBSU.ViewModels.Singup;
using SmartBSU.ViewModels.Login;
using SmartBSU.Views.SingUp;

namespace SmartBSU.Droid.Services
{
    public class CardReader : Java.Lang.Object, NfcAdapter.IReaderCallback
    {

        public async void OnTagDiscovered(Tag tag)
        {
            if (tag != null && App.Current.MainPage.Navigation.ModalStack.Count != 0)
            {
                var tagIdBytes = tag.GetId();
                var tagIdString = ByteArrayToString(tagIdBytes);
                if(App.Current.MainPage.Navigation.ModalStack.Last().GetType() == typeof(CardDetectionPage))
                    await CardDetectionViewModel.DisplayAlertAsync(tagIdString);
                if (App.Current.MainPage.Navigation.ModalStack.Last().GetType() == typeof(CardDetectionLoginPage))
                    await CardDetectionLogInVM.DisplayAlertAsync(tagIdString);
                else
                    return;
            }
        }

        public static string ByteArrayToString(byte[] ba)
        {
            var shb = new SoapHexBinary(ba);
            return shb.ToString();
        }

    }
}