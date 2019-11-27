using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Linq;
using BusBoard.Api;


namespace BusBoard.ConsoleApp
{
    class Program
    {
        public static object JSON { get; private set; }
        static void Main(string[] args)
        {
            {
                //user input
                Console.WriteLine("Please enter your postcode to see the next buses at the two nearest bus stops:");
                string userInput = Console.ReadLine();              
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                {                    
                    RestClient tflClient;
                    List<StopPoint> stopPointList;
                    APIClass.GetAPIData(userInput, out tflClient, out stopPointList);

                    //Prints it all nicely
                    foreach (StopPoint busStop in stopPointList.Take(2))
                    {
                        //pulls arrivals data from tfl 
                        var arrivalsRequest = new RestRequest($"/StopPoint/{busStop.naptanId}/Arrivals?app_id=c14b5da6&app_key=5ad2ba32b5f80495e752142127f7384e",
                            Method.GET)
                        { RequestFormat = DataFormat.Json };
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
