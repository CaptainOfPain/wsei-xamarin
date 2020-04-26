namespace AirMonitor.Models
{
    public class StandardInfo
    {
        public string Name { get; set; }
        public string Pollutant { get; set; }
        public decimal Limit { get; set; }
        public decimal Percent { get; set; }
        public string Averaging { get; set; }
    }
}