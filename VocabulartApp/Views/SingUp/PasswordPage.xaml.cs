using SmartBSU.ViewModels.Login;
using SmartBSU.ViewModels.Singup;
using SmartBSU.Views.Controls;
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
    public partial class PasswordPage : ContentPage
    {
        public PasswordPage(Guid guid)
        {
            InitializeComponent();
            BindingContext = new PasswordViewModel(guid);
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
                var distance = GetPlaceholderDistance(PasswordLabel);
                await PasswordLabel.TranslateTo(0, -distance, 90);
            }

        }

        async Task TranslateLabelToPlaceHolder()
        {
            if (string.IsNullOrEmpty(EntryOutline.Text))
            {
                var distance = GetPlaceholderDistance(PasswordLabel);
                await PasswordLabel.TranslateTo(0, 0, 90);
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