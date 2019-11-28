using System;
using System.Net;
using System.Collections.Generic;
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
                    List<StopPoint> stopPointList = APIClass.GetAPIData(userInput);

                    //Prints it all nicely
                    foreach (StopPoint busStop in stopPointList.Take(2))
                    {
                        
                        var sortedArrivals = APIClass.GetArrivalsData(busStop.naptanId);

                        Console.WriteLine($"The next buses at {busStop.commonName} are:");

                        foreach (var bus in sortedArrivals)
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
