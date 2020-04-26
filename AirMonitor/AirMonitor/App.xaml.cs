using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AirMonitor.Views;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace AirMonitor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitializeApp();
        }

        private async Task InitializeApp()
        {
            var builder = new ContainerBuilder();

            var container = builder.Build();

            DependencyResolver.ResolveUsing(type => container.IsRegistered(type) ? container.Resolve(type) : null);

            await LoadConfig();

            MainPage = new RootTabbedPage();
        }

        private static async Task LoadConfig()
        {
            var assembly = Assembly.GetAssembly(typeof(App));
            var resourceNames = assembly.GetManifestResourceNames();
            var configName = resourceNames.FirstOrDefault(s => s.Contains("config.json"));



            using (var stream = assembly.GetManifestResourceStream(configName))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = await reader.ReadToEndAsync();
                    var dynamicJson = JObject.Parse(json);

                    AirlyConfiguration.AirlyApiKey = dynamicJson["AirlyApiKey"].Value<string>();
                    AirlyConfiguration.AirlyApiUrl = dynamicJson["AirlyApiUrl"].Value<string>();
                    AirlyConfiguration.AirlyApiMeasurementUrl = dynamicJson["AirlyApiMeasurementUrl"].Value<string>();
                    AirlyConfiguration.AirlyApiInstallationUrl = dynamicJson["AirlyApiInstallationUrl"].Value<string>();
                }
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
