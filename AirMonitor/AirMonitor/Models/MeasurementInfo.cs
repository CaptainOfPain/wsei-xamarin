using System.Collections.Generic;

namespace AirMonitor.Models
{
    public class MeasurementInfo
    {
        public Measurement Current { get; set; }
        public IEnumerable<Measurement> History { get; set; }
        public IEnumerable<Measurement> Forecast { get; set; }
    }
}