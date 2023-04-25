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
        private string code;
        public PopupCodeEnter()
        {
            InitializeComponent();
        }
        public PopupCodeEnter(string code, SmartBSU.Models.Person person){
            InitializeComponent();  
            this.code = code;
            BindingContext = new CodeViewModel(code , person);
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }
}