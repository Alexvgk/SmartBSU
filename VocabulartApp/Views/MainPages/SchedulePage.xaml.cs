using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using SmartBSU.ViewModels;
using SmartBSU.ViewModels.Schedule;
using SmartBSU.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Content.ClipData;

namespace SmartBSU.Views
{
    public partial class SchedulePage : ContentPage
    {
        ScheduleViewModel _viewModel;

        public SchedulePage()
        {
            InitializeComponent();
            BindingContext = new DayScheduleItemModel();
            BindingContext = _viewModel = new ScheduleViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }
}