using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenSimulation
{
    public class Token
    {
        public string Message { get; set; }
        public bool IsFree { get; set; }
        public string IPSource { get; set; }
        public string IPDestination { get; set; }
        public bool HasArrivedToDestination { get; set; }
        public Token()
        {
            IsFree = true;
        }


    }

}
