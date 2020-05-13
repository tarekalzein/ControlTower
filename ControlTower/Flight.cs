using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    class Flight
    {
        string flightCode;
        string flightStatus;
        string flightImage;
        public Flight()
        {
            flightCode = FlightCode;
            flightStatus = FlightStatus;
            flightImage = FlightImage;

        }
        public string FlightCode { get; set; }
        public string FlightStatus { get; set; }
        public string FlightImage { get; set; }
    }
}
