using System;
using System.Collections.Generic;
using System.ComponentModel;
using SmartBSU.Models;
using SmartBSU.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartBSU.Views
{
    public partial class NewItemPage : ContentPage
    {
        public User Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}