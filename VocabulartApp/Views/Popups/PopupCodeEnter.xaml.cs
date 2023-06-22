using Java.Lang;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBSU.ViewModels;
using SmartBSU.ViewModels.PopupsVM;
using Xamarin.Forms.Xaml;

namespace SmartBSU.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupCodeEnter : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupCodeEnter(Guid id)
        {
            InitializeComponent();
            BindingContext = new CodeViewModel(id);
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}