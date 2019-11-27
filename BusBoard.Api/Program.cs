using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Linq;


namespace BusBoard.Api
{
   public class Program
    {
        public static object JSON { get; private set; }
        static void Main(string[] args)
        {
            {
                //use input
                Console.WriteLine("Please enter your postcode to see the next buses at the two nearest bus stops:");
                string userInput = Console.ReadLine();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                {
                    //pulls post code data from user input from postcodes API
                    var postcodeClient = new RestClient("http://api.postcodes.io");
                    var postcodeRequest = new RestRequest($"/postcodes/{userInput}", Method.GET) { RequestFormat = DataFormat.Json };
                    IRestResponse postcodeResponse = postcodeClient.Execute(postcodeRequest);
                    string postcodeContent = postcodeResponse.Content;
                    PostCodeResult postcodeObject = JsonConvert.DeserializeObject<PostCodeResult>(postcodeContent);

                    var tflClient = new RestClient("https://api.tfl.gov.uk");

                    //pulls stop point(bus stop) data from tfl API
                    var stopPointRequest = new RestRequest($"StopPoint?app_id=c14b5da6&app_key=5ad2ba32b5f80495e752142127f7384e&stopTypes=NaptanPublicBusCoachTram&radius=500&lat=" +
                        $"{postcodeObject.result.latitude}&lon={postcodeObject.result.longitude}", Method.GET) { RequestFormat = DataFormat.Json };
                    IRestResponse stopPointResponse = tflClient.Execute(stopPointRequest);
                    string stopPointContent = stopPointResponse.Content;
                    
                    //Creates lists for Bus Stops
                    StopPointResult stopPointObject = JsonConvert.DeserializeObject<StopPointResult>(stopPointContent);
                    List<StopPoint> stopPointList = stopPointObject.stopPoints;
                    
                    //Prints it all nicely
                    foreach (StopPoint busStop in stopPointList.Take(2))
                    {
                        //pulls arrivals data from tfl 
                        var arrivalsRequest = new RestRequest($"/StopPoint/{busStop.naptanId}/Arrivals?app_id=c14b5da6&app_key=5ad2ba32b5f80495e752142127f7384e",
                            Method.GET) { RequestFormat = DataFormat.Json };
                        IRestResponse arrivalsResponse = tflClient.Execute(arrivalsRequest);
                        string arrivalsContent = arrivalsResponse.Content;

                        //Creates lists for Arrivals
                        List<Arrivals> arrivalsList = JsonConvert.DeserializeObject<List<Arrivals>>(arrivalsContent);
                        List<Arrivals> sortedArrivalsList = arrivalsList.OrderBy(o => o.timeToStation).ToList();

                        Console.WriteLine($"The next buses at {busStop.commonName} are:");

                        foreach (var bus in sortedArrivalsList)
                        {
                            Console.WriteLine($"{bus.vehicleId} at {bus.expectedArrival}");
                        }
                    }
                        Console.ReadLine();
                    }
                }
            }
        }
    }
