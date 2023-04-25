using Android.App;
using Android.Provider;
using Android.Widget;
using Javax.Security.Auth.Login;
using System;
using System.Threading.Tasks;
using SmartBSU.ViewModels;
using SmartBSU.Views.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartBSU.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            SmartBSU.Models.Person person = new SmartBSU.Models.Person();
            BindingContext = new LoginViewModel();
        }

        async void TextBox_Focused(object sender, FocusEventArgs e)
        {
            await TranslateLabelToTitle();
        }

        async void TextBox_Unfocused(object sender, FocusEventArgs e)
        {
            await TranslateLabelToPlaceHolder();
        }

        async Task TranslateLabelToTitle()
        {
            if (string.IsNullOrEmpty(EntryOutline.Text))
            {
                var distance = GetPlaceholderDistance(PlaceHolderLabel);
                await PlaceHolderLabel.TranslateTo(0, -distance, 90);
            }

        }

        async Task TranslateLabelToPlaceHolder()
        {
            if (string.IsNullOrEmpty(EntryOutline.Text))
            {
                var distance = GetPlaceholderDistance(PlaceHolderLabel);
                await PlaceHolderLabel.TranslateTo(0, 0, 90);
            }
        }

        private double GetPlaceholderDistance(Label control)
        {
            var distance = 0d;
            distance = 5;
            distance = control.Height + distance;
            return distance;
        }

        private async void SendMail_Clicked(object sender, EventArgs e)
        {
            await LoginImage.ScaleTo(1.6, 80);
            if (IncorrectMail.Text != null)
            {
                EntryFrame.BorderColor = Color.Red;
                IncorrectMail.IsVisible = true;
            }
            else
            {
                EntryFrame.BorderColor = PlaceHolderLabel.TextColor;
                IncorrectMail.IsVisible = false;
            }
            await LoginImage.ScaleTo(1.5, 100);
        }
    }
}