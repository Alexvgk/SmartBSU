using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBSU.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartBSU.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
    {
		public WelcomePage ()
		{
			InitializeComponent ();
            BindingContext = new WelcomeViewModel();
        }
    }
}
