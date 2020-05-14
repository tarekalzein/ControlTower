using ControlTower.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower
{
    class Flight
    {
        Airlines flightAirline;
        int flightNumber;
        string flightStatus;
        string flightImagePath;
        bool isStarted;
        public Flight()
        {
            flightAirline = FlightAirline;
            flightNumber = FlightNumber;
            flightStatus = FlightStatus;
            flightImagePath = FlightImagePath;
            isStarted = IsStarted;

        }
        public Airlines FlightAirline { get; set; }
        public string FlightStatus { get; set; }
        public string FlightImagePath { get; set; }
        public int FlightNumber { get; set; }

        public bool IsStarted { get; set; }
    }
}
