using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenSimulation
{
    internal class Token
    {
        private string SourceIp { get; set; }
        private string DestinationIp { get; set; }
        private string Message { get; set; }
        private bool IsFree { get; set; }

        public Token()
        {
            IsFree = true;
        }


    }

}
