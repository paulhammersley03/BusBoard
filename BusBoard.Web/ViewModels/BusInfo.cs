using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {
        public BusInfo(string postCode)
        {
            PostCode = postCode;
        }

        public string PostCode { get; set; }
        public StopPoint BusStop1 { get; set; }
        public StopPoint BusStop2 { get; set; }
        public List<Arrivals> Arrivals1 { get; set; }  
        public List<Arrivals> Arrivals2 { get; set; }
    }
}