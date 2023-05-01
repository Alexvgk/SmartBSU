using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Nfc;
using Android.Content;
using SmartBSU.Droid.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Android.Content.Res;
using SmartBSU.Services.Data;
using Pomelo.EntityFrameworkCore.MySql;

namespace SmartBSU.Droid
{
    
   [Activity(Label = "SmartBSU", Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
   [IntentFilter(new[] { NfcAdapter.ActionNdefDiscovered, NfcAdapter.ActionTagDiscovered, Intent.CategoryDefault })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public CardReader cardReader;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Rg.Plugins.Popup.Popup.Init(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //var serviceProvider = new ServiceCollection();
           // .AddDbContext<MyDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("MyConnection")))
        //.AddTransient<MyService>()
        //.BuildServiceProvider();

          //  var myService = serviceProvider.GetService<MyService>();
            cardReader = new CardReader();
            EnableReaderMode();
            LoadApplication(new App());
        }



        private void EnableReaderMode()
        {
            var nfc = NfcAdapter.GetDefaultAdapter(this);
            if (nfc != null) nfc.EnableReaderMode(this, cardReader, NfcReaderFlags.NfcA | NfcReaderFlags.NfcB | NfcReaderFlags.NfcF, null);
        }

        private void DisableReaderMode()
        {
            var nfc = NfcAdapter.GetDefaultAdapter(this);
            if (nfc != null) nfc.DisableReaderMode(this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            DisableReaderMode();
        }

        protected override void OnResume()
        {
            base.OnResume();
            EnableReaderMode();
        }
    }
}