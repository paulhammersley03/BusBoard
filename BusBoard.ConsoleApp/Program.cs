using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        { Console.WriteLine("Where do you want to travel from?");
            Console.ReadLine();


            {
                //Have a look through the basic documentation of RestSharp on-line, and work out how to call the TfL API from your code.
                //You will need to read the result, convert it into some sort of object, and then display the buses.

                //Unless you're using .NET 4.6 or higher, you will need to add this to the top of your Main method 
                //(to enable TLS 1.2 for HTTPS security - this is required by TfL but not enabled by default under older versions of .NET):
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //Make it so that your console application takes a bus stop code as an input, and prints out the next 5 buses at that stop.

                //Try to ensure you're using a sensible class structure with well-named methods. Remember to commit and push your changes as you go.

                var client = new RestClient("https://api.tfl.gov.uk");
                var request = new RestRequest("/StopPoint/490008660N/Arrivals", Method.GET) { RequestFormat = DataFormat.Json };
                IRestResponse response = client.Execute(request);
                var content = response.Content;
                Console.WriteLine(response.Content);
                Console.ReadLine();

                //var response = _client.Execute<List<ServerDataModel>>(request);

                //if (response.Data == null)
                //throw new Exception(response.ErrorMessage);

                //Console.WriteLine( response.Data);
            }
            
        }   

    }
    
    
}
