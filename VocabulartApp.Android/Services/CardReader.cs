
using Android.Nfc;
using System.Linq;
using SmartBSU.Views;
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
                else if (App.Current.MainPage.Navigation.ModalStack.Last().GetType() == typeof(LogInPage))
                    await LogInViewModel.DisplayAlertAsync(tagIdString);
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