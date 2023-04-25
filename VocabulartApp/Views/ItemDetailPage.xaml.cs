using System.ComponentModel;
using SmartBSU.ViewModels;
using Xamarin.Forms;

namespace SmartBSU.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}