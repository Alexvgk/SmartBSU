using Android.App;
using Rg.Plugins.Popup.Extensions;
using SmartBSU.ViewModels.PopupsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartBSU.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupUidShow : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupUidShow(Models.Person person)
        {
            InitializeComponent();
            BindingContext = new PopupUidViewModel(person);
            UID.Text = person.Uid;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}