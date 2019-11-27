using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{

    public class StopPointResult
    {
        public List<StopPoint> stopPoints { get; set; }
    }   
    public class StopPoint
    {
        public string naptanId { get; set; }
        public string stationNaptan { get; set; }
        public string id { get; set; }
        public string commonName { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
 
