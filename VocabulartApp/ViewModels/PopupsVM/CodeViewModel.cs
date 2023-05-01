using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBSU.Views;
using Xamarin.Forms;
using SmartBSU.Models;
using SmartBSU.Services.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SmartBSU.ViewModels.PopupsVM
{
    public class CodeViewModel : BaseViewModel {
        private string email;
        private short occasions = 3;
        private string enteredCode;
        private string code;
        public Command CheckCodeCommand { get; }

        public string EnteredCode
        {
            get => enteredCode; 
            set => enteredCode = value;
        }

        public CodeViewModel(string email)
        {
            CheckCodeCommand = new Command(OnOK);
            this.email = email;
        }

        private async void OnOK(object obj)
        {
            if(code == null)
            {
                using var dbContext = new MyDbContext();
                {
                    var user = dbContext.users.Include(u => u.RegCode).FirstOrDefault(u => u.Email == email);
                    code = user.RegCode.RegistCode;
                }
            }
            occasions--;
            if(occasions != 0 && enteredCode != null && enteredCode.CompareTo(code) == 0)
            {
                 await App.Current.MainPage.Navigation.PopPopupAsync();
                 await App.Current.MainPage.Navigation.PushModalAsync(new CardDetectionPage(email));
            }
            else
            {
                if(occasions == 0)
                {
                    using var dbContext = new MyDbContext();
                    {
                        var user = dbContext.users.Include(u => u.RegCode).FirstOrDefault(u => u.Email == email);
                        dbContext.Remove(user);
                        dbContext.SaveChanges();
                    }
                    await App.Current.MainPage.Navigation.PopPopupAsync();
                }
            }
           
        }
    }

}
