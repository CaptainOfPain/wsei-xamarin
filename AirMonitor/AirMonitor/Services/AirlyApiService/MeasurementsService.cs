using System.Collections.Generic;
using System.Threading.Tasks;
using AirMonitor.Models;

namespace AirMonitor.Services.AirlyApiService
{
    public class MeasurementsService : BaseApiService, IMeasurementsService
    {
        public async Task<MeasurementInfo> GetMeasurementInfoByInstallationId(long installationId)
        {

            var query = GetQuery(new Dictionary<string, object>
            {
                { "installationId", installationId },
                {"indexType", "AIRLY_CAQI"} 
            });
            var url = GetAirlyApiUrl(AirlyConfiguration.AirlyApiMeasurementUrl, query);

            var response = await GetHttpResponseAsync<MeasurementInfo>(url);
            return response;
        }
    }
}