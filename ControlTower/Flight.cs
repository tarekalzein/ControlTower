using ControlTower.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    public class Flight
    {
        //TODO: Check if there is any need for flight status.
        string flightCode;
        string flightImagePath;
        public Flight()
        {
            flightCode = FlightCode;
            flightImagePath = FlightImagePath;

        }
        public Airlines FlightAirline { get; set; }
        public string FlightImagePath { get; set; }
        public string FlightCode { get; set; }
    }
}
