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
using SmartBSU.ViewModels;
using SmartBSU.Services.Reservation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace SmartBSU.Droid.Services
{
    public class CardReader : Java.Lang.Object, NfcAdapter.IReaderCallback
    {

        public async void OnTagDiscovered(Tag tag)
        {
            if (tag != null)
            {
                var tagIdBytes = tag.GetId();
                var tagIdString = ByteArrayToString(tagIdBytes);
                await CardDetectionViewModel.DisplayAlertAsync(tagIdString);
            }
        }

        public static string ByteArrayToString(byte[] ba)
        {
            var shb = new SoapHexBinary(ba);
            return shb.ToString();
        }

    }
}