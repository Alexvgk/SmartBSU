using Android.Nfc;
using Android;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using System.Threading.Tasks;
using SmartBSU.Services.Reservation;
using SmartBSU.Views;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;
using Rg.Plugins.Popup.Extensions;
using SmartBSU.Views.Popups;
using System.Linq;
using SmartBSU.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartBSU.ViewModels.Singup
{
    public class CardDetectionViewModel : BaseViewModel
    {
        // private static Models.Person person;
        private static string Email;
        private string uid;

        public string Uid
        {
            get => uid;
            set => SetProperty(ref uid, value);
        }
        public Command ShowUID { get; }
        public CardDetectionViewModel(string email)
        {
            Email = email;
        }
        public static async Task DisplayAlertAsync(string msg)
        {
            try {
                if (Xamarin.Forms.Application.Current.MainPage.Navigation.ModalStack.Last().GetType() == typeof(CardDetectionPage))
                {
                    using var dbContext = new MyDbContext();
                    {
                        var user = dbContext.users.Include(u => u.RegCode).FirstOrDefault(u => u.Email == Email);
                        user.Uid = msg;
                        await dbContext.SaveChangesAsync();
                    }
                    Email = null;
                }
            }
            catch (DbUpdateException ex) {
                msg = "This card is used";
            }
            await Device.InvokeOnMainThreadAsync(async () => await Xamarin.Forms.Application.Current.MainPage.Navigation.PushPopupAsync(new PopupUidShow(msg)));
        }

    }
}
