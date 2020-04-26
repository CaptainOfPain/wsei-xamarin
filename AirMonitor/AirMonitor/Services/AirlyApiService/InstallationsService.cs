using System.Collections.Generic;
using System.Threading.Tasks;
using AirMonitor.Models;
using Xamarin.Essentials;

namespace AirMonitor.Services.AirlyApiService
{
    public class InstallationsService : BaseApiService, IInstallationsService
    {
        public async Task<IEnumerable<Installation>> GetInstallations(Location location, double maxDistanceInKm = 3, int maxResults = -1)
        {
            if (location == null)
            {
                System.Diagnostics.Debug.WriteLine("No location data.");
                return null;
            }

            var query = GetQuery(new Dictionary<string, object>
            {
                { "lat", location.Latitude },
                { "lng", location.Longitude },
                { "maxDistanceKM", maxDistanceInKm },
                { "maxResults", maxResults }
            });
            var url = GetAirlyApiUrl(AirlyConfiguration.AirlyApiInstallationUrl, query);

            var response = await GetHttpResponseAsync<IEnumerable<Installation>>(url);
            return response;
        }
    }
}