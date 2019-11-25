using System;
using System.Net;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Linq;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        public static object JSON { get; private set; }
        static void Main(string[] args)

        {
            while (true)
            {
                Console.WriteLine("Please enter stop code");
                string userInput = Console.ReadLine();

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                {
                    var tflClient = new RestClient("https://api.tfl.gov.uk");
                    var arrivalsRequest = new RestRequest("/StopPoint/490008660N/Arrivals", Method.GET) { RequestFormat = DataFormat.Json };
                    IRestResponse arrivalsResponse = tflClient.Execute(arrivalsRequest);
                    string arrivalsContent = arrivalsResponse.Content;

                    List<Bus_Class> busList = JsonConvert.DeserializeObject<List<Bus_Class>>(arrivalsContent);
                    List<Bus_Class> sortedBusList = busList.OrderBy(o => o.timeToStation).ToList();

                    //Regex UserInput = new Regex(@"List\s\b(?<firstname>)");
                  
                    if (userInput == "490008660N")
                    {
                        foreach (var bus in sortedBusList)
                        {
                            Console.WriteLine($"{bus.id} + {bus.destinationName} + {bus.timeToStation}");
                        }                           
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    Console.ReadLine();

                    //Make it so that your console application takes a bus stop code as an input, and prints out the next 5 buses at that stop.

                    //Try to ensure you're using a sensible class structure with well-named methods. Remember to commit and push your changes as you go.
                }
            }    
        }   

    }
    
    
}
