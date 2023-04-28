using Android.Nfc;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBSU.ViewModels;
using SmartBSU.Views.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartBSU.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardDetectionPage : ContentPage
	{
        public CardDetectionPage (string email)
		{
			InitializeComponent ();
			BindingContext = new CardDetectionViewModel(email);
		}

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }

}