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
            //while (true)
            {
               // Console.WriteLine("Please enter stop code");
                string userInput = Console.ReadLine();

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                {
                    var tflClient = new RestClient("https://api.tfl.gov.uk");
                    var arrivalsRequest = new RestRequest("/StopPoint/490008660N/Arrivals", Method.GET) { RequestFormat = DataFormat.Json };
                    var stopPointRequest = new RestRequest("StopPoint?stopTypes=NaptanOnstreetBusCoachStopPair&radius=200&lat=51.553935&lon=-0.144754", Method.GET) { RequestFormat = DataFormat.Json };
                    IRestResponse arrivalsResponse = tflClient.Execute(arrivalsRequest);
                    IRestResponse stopPointResponse = tflClient.Execute(stopPointRequest);
                    string arrivalsContent = arrivalsResponse.Content;
                    string stopPointContent = stopPointResponse.Content;

                    List<Bus> busList = JsonConvert.DeserializeObject<List<Bus>>(arrivalsContent);
                    List<Bus> sortedBusList = busList.OrderBy(o => o.timeToStation).ToList();               

                    //Regex UserInput = new Regex(@"List\s\b(?<firstname>)");
                  
                    //if (userInput == "490008660N")
                    //{
                    //    foreach (var bus in sortedBusList.Take(5))
                    //    {
                    //        Console.WriteLine($"{bus.id} + {bus.destinationName} + {bus.timeToStation}");
                    //    }                           
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Invalid Input");
                    //}

                    var postcodeClient = new RestClient("http://api.postcodes.io");
                    var postcodeRequest = new RestRequest("/postcodes/NW5 1TL", Method.GET) { RequestFormat = DataFormat.Json };
                    IRestResponse postcodeResponse = postcodeClient.Execute(postcodeRequest);
                    var postcodeContent = postcodeResponse.Content;


                   List<PostCode> postcodeList = JsonConvert.DeserializeObject<List<PostCode>>(postcodeContent);
                    //ArrayList postCodeList = new ArrayList();
                    // var postCode = JsonConvert.DeserializeObject<PostCode>(postcodeContent);
                    //ArrayList  busList = JsonConvert.DeserializeObject<List<Bus>>(arrivalsContent);
                    //JObject p = JObject.Parse(postcodeContent);




                    //foreach (var postCode1 in postcodeContent)
                    //{
                    PostCode.longLat test1 = new PostCode.longLat();
                    Console.WriteLine(test1);
                    //}

                    Console.ReadLine();

                   

                    //Try to ensure you're using a sensible class structure with well-named methods. Remember to commit and push your changes as you go.
                }
            }    
        }   
    }   
}
