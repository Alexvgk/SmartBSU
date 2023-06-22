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
    public partial class PopupMessage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupMessage(string status, string message)
        {
            InitializeComponent();
            BindingContext = new PopupMessageViewModel(status,message);
        }
    }
}