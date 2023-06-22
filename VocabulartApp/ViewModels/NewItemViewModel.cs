using System;
using System.Linq;
using Java.Sql;
using Model;
using SmartBSU.Services.DataStore;
using Xamarin.Forms;

namespace SmartBSU.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string subject;
        private string form;
        private string lecture = null;
        private string classroom = null;
        private string day;
        private TimeSpan time;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(subject)
;
        }

        public string Subject
        {
            get => subject;
            set => SetProperty(ref subject, value);
        }
        public string Form
        {
            get => form;
            set => SetProperty(ref form, value);
        }
        public string Classroom
        {
            get => classroom;
            set => SetProperty(ref classroom, value);
        }
        public TimeSpan Time
        {
            get => time;
            set => SetProperty(ref time, value);
        }
        public string Day
        {
            get => day;
            set => SetProperty(ref day, value);
        }

        public string Lecture
        {
            get => lecture;
            set => SetProperty(ref lecture, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            if (String.IsNullOrWhiteSpace(subject) || String.IsNullOrWhiteSpace(day) || String.IsNullOrWhiteSpace(time.ToString()))
                return;
            //Model.DayTime dayTime = new DayTime() { Id = Guid.NewGuid(), Day = day, Time = time.ToString() };
            DBDataStore<LessonForm> Lessonstore = new DBDataStore<LessonForm>();
            var response =  Lessonstore.GetItemsAsync("/api/LessonForm");
            DBDataStore<DayTime> dayTimeStore = new DBDataStore<DayTime>();
            var DtResponse = dayTimeStore.GetItemsAsync("/api/DayTime");
            Model.Schedule schedule = new Model.Schedule()
            {
                Id = Guid.NewGuid(),
                Name = subject,
                Lecture = lecture,
                Classroom = Classroom,
                Time = time.ToString(),
                CGId = AppShell.User.IdCourseGroup,
                DayId = DtResponse.Result.FirstOrDefault(d => d.Day == day).Id,
                IdForm = response.Result.FirstOrDefault(w => w.Form == form).Id 
            };
            DBDataStore<Model.Schedule> dBDataStore = new DBDataStore<Model.Schedule>();
            var scheduleresponse = dBDataStore.AddItemAsync(schedule, "/api/Schedule");
            if (scheduleresponse.IsCompletedSuccessfully)
                await Shell.Current.GoToAsync("..");
            else
                await Shell.Current.GoToAsync("..");

            // await DataStore.AddItemAsync(newItem);

            // ReservationData reservationData = new ReservationData();
            //reservationData.WriteData(DataStore);
            //await Application.Current.SavePropertiesAsync();

            // This will pop the current page off the navigation stack
        }
    }
}
