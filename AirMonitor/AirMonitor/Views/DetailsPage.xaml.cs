using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirMonitor.Models;
using AirMonitor.Services.AirlyApiService;
using AirMonitor.ViewModels;
using Xamarin.Forms;

namespace AirMonitor.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DetailsPage : ContentPage
    {
        private DetailsViewModel viewModel;
        public DetailsPage(Installation installation)
        {
            InitializeComponent();
            viewModel = new DetailsViewModel(new MeasurementsService());
            viewModel.Installation = installation;
            viewModel.GetMeasurementInfoAsync().GetAwaiter();
            BindingContext = viewModel;
        }

        private void Help_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Co to jest CAQI?", "Lorem ipsum.", "Zamknij");
        }
    }
}
