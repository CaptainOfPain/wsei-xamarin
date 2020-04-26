using System.Threading.Tasks;
using AirMonitor.Models;

namespace AirMonitor.Services.AirlyApiService
{
    public interface IMeasurementsService
    {
        Task<MeasurementInfo> GetMeasurementInfoByInstallationId(long id);
    }
}