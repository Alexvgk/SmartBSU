using Android.Preferences;
using Java.Util.Prefs;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Model;
using SmartBSU.Services.Loader;
using SmartBSU.Views;
using Xamarin.Forms;
using System.Collections.Generic;

namespace SmartBSU.ViewModels.Schedule
{
    public class ScheduleViewModel : BaseViewModel
    {
        private Model.Schedule _selectedItem;
        private LoaderSchedule _loaderSchedule;

        public ObservableCollection<DayScheduleItemModel> Items { get; set; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get;}
        public Command RefreshCommand { get; }
        public Command<Model.Schedule> ItemTapped { get; }


        public ScheduleViewModel()
        {
            Title = "Schedule";
            Items = new ObservableCollection<DayScheduleItemModel>();
            _loaderSchedule = new LoaderSchedule();
            _loaderSchedule.LoadSchedule();
            SetCarousel(_loaderSchedule.Schedules);
            RefreshCommand = new Command(OnRefresh);

            ItemTapped = new Command<Model.Schedule>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        private void OnRefresh(object obj)
        {
            IsBusy = true;
            Items.Clear();
             _loaderSchedule = new LoaderSchedule();
             _loaderSchedule.LoadSchedule();
             SetCarousel(_loaderSchedule.Schedules);
            IsBusy = false;
        }

        public void OnAppearing()
        {
             IsBusy = true;
            SelectedItem = null;
        }

        public Model.Schedule SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Model.Schedule item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.Navigation.PushAsync(new ItemDetailPage(item));
        }

        private void SetCarousel(IEnumerable<Model.Schedule> items)
        {
            Items.Clear();
            var page1 = new DayScheduleItemModel();
            page1.TitleDay = "Monday";
            page1.SetSchedule(items);
            Items.Add(page1);
            var page2 = new DayScheduleItemModel();
            page2.TitleDay = "Tuesday";
            page2.SetSchedule(items);
            Items.Add(page2);
            var page3 = new DayScheduleItemModel();
            page3.TitleDay = "Wednesday";
            page3.SetSchedule(items);
            Items.Add(page3);
            var page4 = new DayScheduleItemModel();
            page4.TitleDay = "Thursday";
            page4.SetSchedule(items);
            Items.Add(page4);
            var page5 = new DayScheduleItemModel();
            page5.TitleDay = "Friday";
            page5.SetSchedule(items);
            Items.Add(page5);
            var page6 = new DayScheduleItemModel();
            page6.TitleDay = "Saturday";
            page6.SetSchedule(items);
            Items.Add(page6);

        }                       
    }
}