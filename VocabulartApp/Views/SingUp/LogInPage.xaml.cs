using SmartBSU.ViewModels.Login;
using SmartBSU.ViewModels.Singup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartBSU.Views.SingUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
            BindingContext = new LogInViewModel();
        }

        private async void PasswordOutline_Unfocused(object sender, FocusEventArgs e)
        {
            await TranslatePasswordToPlaceHolder();
        }

        private async void PasswordOutline_Focused(object sender, FocusEventArgs e)
        {
            await TranslatePasswordToTitle();
        }

        async Task TranslatePasswordToTitle()
        {
            if (string.IsNullOrEmpty(PasswordOutline.Text))
            {
                var distance = GetPlaceholderDistance(PasswordLabel);
                await PasswordLabel.TranslateTo(0, -distance, 90);
            }

        }

        async Task TranslatePasswordToPlaceHolder()
        {
            if (string.IsNullOrEmpty(PasswordOutline.Text))
            {
                var distance = GetPlaceholderDistance(PasswordLabel);
                await PasswordLabel.TranslateTo(0, 0, 90);
            }
        }

        private async void EmailOutline_Focused(object sender, FocusEventArgs e)
        {
            await TranslateEmailToTitle();
        }

        private async void EmailOutline_Unfocused(object sender, FocusEventArgs e)
        {
            await TranslateEmailToPlaceHolder();
        }

        async Task TranslateEmailToTitle()
        {
            if (string.IsNullOrEmpty(EmailOutline.Text))
            {
                var distance = GetPlaceholderDistance(EmailLabel);
                await EmailLabel.TranslateTo(0, -distance, 90);
            }

        }

        async Task TranslateEmailToPlaceHolder()
        {
            if (string.IsNullOrEmpty(EmailOutline.Text))
            {
                var distance = GetPlaceholderDistance(EmailLabel);
                await EmailLabel.TranslateTo(0, 0, 90);
            }
        }

        private double GetPlaceholderDistance(Label control)
        {
            var distance = 0d;
            distance = 5;
            distance = control.Height + distance;
            return distance;
        }
    }
}