using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AirMonitor.Models;
using AirMonitor.Services.AirlyApiService;

namespace AirMonitor.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        private readonly IMeasurementsService _measurementsService;

        public DetailsViewModel(IMeasurementsService measurementsService)
        {
            _measurementsService = measurementsService;
        }

        private decimal _caqiValue = 57;
        public decimal CaqiValue
        {
            get => _caqiValue;
            set => SetProperty(ref _caqiValue, value);
        }

        private string _caqiTitle = "Świetna jakość!";
        public string CaqiTitle
        {
            get => _caqiTitle;
            set => SetProperty(ref _caqiTitle, value);
        }

        private string _caqiDescription = "Możesz bezpiecznie wyjść z domu bez swojej maski anty-smogowej i nie bać się o swoje zdrowie.";
        public string CaqiDescription
        {
            get => _caqiDescription;
            set => SetProperty(ref _caqiDescription, value);
        }

        private decimal _pm25Value = 34;
        public decimal Pm25Value
        {
            get => _pm25Value;
            set => SetProperty(ref _pm25Value, value);
        }

        private decimal _pm25Percent = 137;
        public decimal Pm25Percent
        {
            get => _pm25Percent;
            set => SetProperty(ref _pm25Percent, value);
        }

        private decimal _pm10Value = 67;
        public decimal Pm10Value
        {
            get => _pm10Value;
            set => SetProperty(ref _pm10Value, value);
        }

        private decimal _pm10Percent = 135;
        public decimal Pm10Percent
        {
            get => _pm10Percent;
            set => SetProperty(ref _pm10Percent, value);
        }

        private decimal _humidityValue = 0.95m;
        public decimal HumidityValue
        {
            get => _humidityValue;
            set => SetProperty(ref _humidityValue, value);
        }

        private decimal _pressureValue = 1027;
        public decimal PressureValue
        {
            get => _pressureValue;
            set => SetProperty(ref _pressureValue, value);
        }

        public Installation Installation { get; set; }
        public MeasurementInfo MeasurementInfo { get; set; }

        public async Task GetMeasurementInfoAsync()
        {
            MeasurementInfo = await _measurementsService.GetMeasurementInfoByInstallationId(Installation.Id);
            CaqiValue = Math.Round(MeasurementInfo.Current.Indexes.FirstOrDefault()?.Value ?? 0m);
            CaqiTitle = MeasurementInfo.Current.Indexes.FirstOrDefault()?.Name;
            CaqiDescription = MeasurementInfo.Current.Indexes.FirstOrDefault()?.Description;

            var pm10 = MeasurementInfo.Current.Values.FirstOrDefault(x => x.Name.ToLowerInvariant() == "pm10");
            Pm10Value = pm10?.Value ?? 0m;

            var pm25 = MeasurementInfo.Current.Values.FirstOrDefault(x => x.Name.ToLowerInvariant() == "pm25");
            Pm25Value = pm25?.Value ?? 0m;

            var humidity = MeasurementInfo.Current.Values.FirstOrDefault(x => x.Name.ToLowerInvariant() == "humidity");
            HumidityValue = humidity?.Value / 100m ?? 0m;

            var pressure = MeasurementInfo.Current.Values.FirstOrDefault(x => x.Name.ToLowerInvariant() == "pressure");
            PressureValue = pressure?.Value ?? 0m;
        }

    }
}
