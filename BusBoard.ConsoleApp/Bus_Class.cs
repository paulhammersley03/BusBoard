using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    public class Bus_Class
    {
        public string __invalid_name__type { get; set; }
        public string id { get; set; }
        public int operationType { get; set; }
        public string vehicleId { get; set; }
        public string naptanId { get; set; }
        public string stationName { get; set; }
        public string lineId { get; set; }
        public string lineName { get; set; }
        public string platformName { get; set; }
        public string direction { get; set; }
        public string bearing { get; set; }
        public string destinationNaptanId { get; set; }
        public string destinationName { get; set; }
        public DateTime timestamp { get; set; }
        public int timeToStation { get; set; }
        public string currentLocation { get; set; }
        public string towards { get; set; }
        public DateTime expectedArrival { get; set; }
        public DateTime timeToLive { get; set; }
        public string modeName { get; set; }
        //public Timing TimingT { get; set; }
}
}
