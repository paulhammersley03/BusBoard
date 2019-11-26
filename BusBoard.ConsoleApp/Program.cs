using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        public static object JSON { get; private set; }
        static void Main(string[] args)

        {
            while (true)
            {
                Console.WriteLine("Please enter your postcode to see the next buses at the two nearest bus stops:");
                string userInput = Console.ReadLine();
                

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                {
                    var postcodeClient = new RestClient("http://api.postcodes.io");
                    var postcodeRequest = new RestRequest($"/postcodes/{userInput}", Method.GET) { RequestFormat = DataFormat.Json };
                    IRestResponse postcodeResponse = postcodeClient.Execute(postcodeRequest);
                    string postcodeContent = postcodeResponse.Content;


                    PostCodeResult postcodeObject = JsonConvert.DeserializeObject<PostCodeResult>(postcodeContent);

                    var tflClient = new RestClient("https://api.tfl.gov.uk");
                    var arrivalsRequest = new RestRequest("/StopPoint/490008660N/Arrivals", Method.GET) { RequestFormat = DataFormat.Json };
                    var stopPointRequest = new RestRequest($"StopPoint?stopTypes=NaptanOnstreetBusCoachStopPair&radius=200&lat={postcodeObject.result.latitude}&lon={postcodeObject.result.longitude}", Method.GET) { RequestFormat = DataFormat.Json };
                    IRestResponse arrivalsResponse = tflClient.Execute(arrivalsRequest);
                    IRestResponse stopPointResponse = tflClient.Execute(stopPointRequest);
                    string arrivalsContent = arrivalsResponse.Content;
                    string stopPointContent = stopPointResponse.Content;

                    List<Bus> busList = JsonConvert.DeserializeObject<List<Bus>>(arrivalsContent);
                    List<Bus> sortedBusList = busList.OrderBy(o => o.timeToStation).ToList();

                    StopPointResult stopPointObject = JsonConvert.DeserializeObject<StopPointResult>(stopPointContent);
                    //PostCode postcodeObject = JsonConvert.DeserializeObject<PostCode>(postcodeContent);

                  //var StopPoint.StopPointResults = new StopPoint(); 



                    Console.WriteLine($"{stopPointObject.stopPoints}");

                    Console.ReadLine();
                }
            }    
        }   
    }   
}
