using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace BusBoard.Api
{
   public class APIClass
    {
        public static void GetAPIData(string userInput, out RestClient tflClient, out List<StopPoint> stopPointList)
        {
            //pulls post code data from user input from postcodes API
            var postcodeClient = new RestClient("http://api.postcodes.io");
            var postcodeRequest = new RestRequest($"/postcodes/{userInput}", Method.GET) { RequestFormat = DataFormat.Json };
            IRestResponse postcodeResponse = postcodeClient.Execute(postcodeRequest);
            string postcodeContent = postcodeResponse.Content;
            PostCodeResult postcodeObject = JsonConvert.DeserializeObject<PostCodeResult>(postcodeContent);

            tflClient = new RestClient("https://api.tfl.gov.uk");

            //pulls stop point(bus stop) data from tfl API
            var stopPointRequest = new RestRequest($"StopPoint?app_id=c14b5da6&app_key=5ad2ba32b5f80495e752142127f7384e&stopTypes=NaptanPublicBusCoachTram&radius=500&lat=" +
                $"{postcodeObject.result.latitude}&lon={postcodeObject.result.longitude}", Method.GET)
            { RequestFormat = DataFormat.Json };
            IRestResponse stopPointResponse = tflClient.Execute(stopPointRequest);
            string stopPointContent = stopPointResponse.Content;

            //Creates lists for Bus Stops
            StopPointResult stopPointObject = JsonConvert.DeserializeObject<StopPointResult>(stopPointContent);
            stopPointList = stopPointObject.stopPoints;
        }
    }
}
