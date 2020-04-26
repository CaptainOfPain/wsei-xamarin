using System;
using System.Collections.Generic;

namespace AirMonitor.Models
{
    public class Measurement
    {
        public DateTime FromDateTime { get; set; }
        public DateTime TillDateTime { get; set; }
        public IEnumerable<PmValue> Values { get; set; }
        public IEnumerable<CaqiInfo> Indexes { get; set; }
        public IEnumerable<StandardInfo> Standards { get; set; }
    }
}