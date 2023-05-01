using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using SmartBSU.Models;
using SmartBSU.Services.Reservation;
using Xamarin.Forms;

namespace SmartBSU.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            TranslateCommand = new Command(OnTranslate);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
;
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command TranslateCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            if (String.IsNullOrWhiteSpace(description))
                description = "Empty";
            User newItem = new User()
            {
               // Id = Guid.NewGuid().ToString(),
                //EngishWord = Text,
                //Translation = Description
            };

            await DataStore.AddItemAsync(newItem);

             ReservationData reservationData = new ReservationData();
            reservationData.WriteData(DataStore);
            //await Application.Current.SavePropertiesAsync();

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private void OnTranslate() 
        {
            
        } 
    }
}
