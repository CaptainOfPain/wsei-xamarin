using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using AirMonitor.Models;
using AirMonitor.Services.AirlyApiService;
using AirMonitor.Views;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;



namespace AirMonitor.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private readonly IInstallationsService _installationsService;

        public HomeViewModel(INavigation navigation, IInstallationsService installationsService)
        {
            _navigation = navigation;
            _installationsService = installationsService;

            Initialize();
        }

        private List<Installation> _items = new List<Installation>();
        public List<Installation> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private async Task Initialize()
        {
            var location = await GetLocation();
            var installations = await _installationsService.GetInstallations(location, maxResults: 7);

            Items = installations.ToList();
        }


        private async Task<Location> GetLocation()
        {
            Location location = await Geolocation.GetLastKnownLocationAsync();
            return location;
        }

        private ICommand _goToDetailsCommand;
        public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command<ItemTappedEventArgs>(OnGoToDetails));

        private void OnGoToDetails(ItemTappedEventArgs e)
        {
            _navigation.PushAsync(new DetailsPage(e.Item as Installation));
        }
    }
}