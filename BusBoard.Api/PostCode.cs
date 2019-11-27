using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.Api
{
    public class PostCodeResult
    {
        public int status { get; set; }
        public PostCode result { get; set; }
    }
    public class PostCode
    { 
        public string longitude { get; set; }
        public string latitude { get; set; }    
    }    
}

