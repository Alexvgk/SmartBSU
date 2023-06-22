using Model;
using SmartBSU.Services.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static Android.Resource;

namespace SmartBSU.ViewModels
{
    public class ProfileChangeViewModel : BaseViewModel
    {
        private User user;
        private string course;
        private string group;
        public Command ChangeCommand { get; }

        public string Course
        {
            get => course;
            set => SetProperty(ref course, value);
        }
        public string Group
        {
            get => group;
            set => SetProperty(ref group, value);
        }

        public ProfileChangeViewModel()
        {
            Title = "Profile";
            user = AppShell.User;
            ChangeCommand = new Command(OnChange);
        }

        private async void OnChange(object obj)
        {
            int.TryParse(Course, out var intcourse);
            int.TryParse(Group, out var intgroup);
            if(intcourse >= 1 && intgroup >= 1 && intcourse <= 4 && intgroup <= 10)
            {
                DBDataStore<CourseGroup> CGStore = new DBDataStore<CourseGroup>();
                var response = CGStore.GetItemsAsync("/api/CorseGroup");
                if(response.Result != null)
                {
                    var courseGroupeId = response.Result.Where(g => g.Group == group).FirstOrDefault(c => c.Course == course).Id;
                    user.IdCourseGroup = courseGroupeId;
                }

            }
            DBDataStore<User> dataStore = new DBDataStore<User>();
            if (user != null)
            {
                var response = dataStore.UpdateItemAsync(user, "api/User").Result;
                if (response)
                {
                    AppShell.UpdateUser(user);  
                    await Shell.Current.GoToAsync("..");
                }
            }
        }

        public User User
        {
            get { return user; }
            set
            {
                SetProperty(ref user, value);
                OnPropertyChanged();
            }
        }
    }
}
