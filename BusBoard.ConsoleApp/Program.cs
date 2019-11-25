using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        public static object JSON { get; private set; }

        static void Main(string[] args)
        { Console.WriteLine("Where do you want to travel from?");
          Console.ReadLine();

          ServicePointManager.Expect100Continue = true;
          ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            {
                var tflClient = new RestClient("https://api.tfl.gov.uk");
                var arrivalsRequest = new RestRequest("/StopPoint/490008660N/Arrivals", Method.GET) { RequestFormat = DataFormat.Json };
                IRestResponse arrivalsResponse = tflClient.Execute(arrivalsRequest);
                string arrivalsContent = arrivalsResponse.Content;

                List<Bus_Class> busList = JsonConvert.DeserializeObject<List<Bus_Class>>(arrivalsContent);
                //Bus_Class Bus_Class = JsonConvert.DeserializeObject<Bus_Class>(arrivalsContent);

                foreach (var bus in busList)
                {
                    Console.WriteLine($"{bus.id} + {bus.destinationName} + {bus.timeToStation}");
                }               
                Console.ReadLine();
               
                //Make it so that your console application takes a bus stop code as an input, and prints out the next 5 buses at that stop.

                //Try to ensure you're using a sensible class structure with well-named methods. Remember to commit and push your changes as you go.



                
            }
            
        }   

    }
    
    
}
