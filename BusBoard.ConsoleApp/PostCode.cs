using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    class PostCode
    {
        public int status { get; set; }
        public longLat result { get; set; }
        public class longLat
        {       
             public double longitude { get; set; }
             public double latitude { get; set; }

           
        }
      
    }
}
