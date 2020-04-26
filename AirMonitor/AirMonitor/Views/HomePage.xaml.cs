using System;
using System.Collections.Generic;
using AirMonitor.Services.AirlyApiService;
using AirMonitor.ViewModels;
using Xamarin.Forms;

namespace AirMonitor.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel(Navigation, new InstallationsService());
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((HomeViewModel)BindingContext).GoToDetailsCommand.Execute(e);
        }
    }
}
