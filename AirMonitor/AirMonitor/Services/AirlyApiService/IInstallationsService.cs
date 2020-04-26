using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirMonitor.Models;
using Xamarin.Essentials;

namespace AirMonitor.Services.AirlyApiService
{
    public interface IInstallationsService
    {
        Task<IEnumerable<Installation>> GetInstallations(Location location, double maxDistanceInKm = 3, int maxResults = -1);
    }
}
