using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public class FlightStatusChangeEvent :EventArgs
    {

        public Flight Flight{ get; set; }
        public string Status { get; set; }
    }
}
