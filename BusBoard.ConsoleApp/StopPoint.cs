using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    
    public class StopPoint
    {
        public string __invalid_name__$type { get; set; }
        public List<double> centrePoint { get; set; }
        public List<StopPoint> stopPoints { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
        public int page { get; set; }
    }   

    public class Crowding
    {
        public string __invalid_name__$type { get; set; }
    }

    public class Line
    {
        public string __invalid_name__$type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
        public Crowding crowding { get; set; }
        public string routeType { get; set; }
        public string status { get; set; }
    }

    public class LineGroup
    {
        public string __invalid_name__$type { get; set; }
        public string naptanIdReference { get; set; }
        public string stationAtcoCode { get; set; }
        public List<string> lineIdentifier { get; set; }
    }

    public class LineModeGroup
    {
        public string __invalid_name__$type { get; set; }
        public string modeName { get; set; }
        public List<string> lineIdentifier { get; set; }
    }

    public class Child
    {
        public string __invalid_name__$type { get; set; }
        public string naptanId { get; set; }
        public string indicator { get; set; }
        public string stopLetter { get; set; }
        public List<object> modes { get; set; }
        public string icsCode { get; set; }
        public string stationNaptan { get; set; }
        public List<object> lines { get; set; }
        public List<object> lineGroup { get; set; }
        public List<object> lineModeGroups { get; set; }
        public bool status { get; set; }
        public string id { get; set; }
        public string commonName { get; set; }
        public string placeType { get; set; }
        public List<object> additionalProperties { get; set; }
        public List<object> children { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class StopPoint
    {
        public string __invalid_name__$type { get; set; }
        public string naptanId { get; set; }
        public List<string> modes { get; set; }
        public string icsCode { get; set; }
        public string stopType { get; set; }
        public string stationNaptan { get; set; }
        public List<Line> lines { get; set; }
        public List<LineGroup> lineGroup { get; set; }
        public List<LineModeGroup> lineModeGroups { get; set; }
        public bool status { get; set; }
        public string id { get; set; }
        public string commonName { get; set; }
        public double distance { get; set; }
        public string placeType { get; set; }
        public List<object> additionalProperties { get; set; }
        public List<Child> children { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
 
