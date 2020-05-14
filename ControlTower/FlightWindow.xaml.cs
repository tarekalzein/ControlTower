using ControlTower.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControlTower
{
    /// <summary>
    /// Interaction logic for FlightWindow.xaml
    /// </summary>
    public partial class FlightWindow : Window
    {
        private Flight flight;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FlightWindow()
        {
            InitializeComponent();
        }
        public FlightWindow(Airlines airline, int flightNumber)
        {
            InitializeComponent();

            flight = new Flight
            {
                FlightAirline = airline,
                FlightNumber = flightNumber,
                FlightImagePath = ImagePathFinder(airline),
                IsStarted = false,
                FlightStatus = "Some status",
            };
            InitializeComponent();

            flightImage.Source = new BitmapImage(new Uri("/ControlTower;component"+flight.FlightImagePath, UriKind.Relative));
            flightNumberLbl.Content = flight.FlightAirline.ToString() + " " + flight.FlightNumber.ToString();
            landBtn.IsEnabled = false;
            statusCmb.IsEnabled = false;
            //while(!flight.IsStarted)
            //{


            //}

        }
        private string ImagePathFinder(Airlines airline)
        {
            string imagePath = "";
            switch (airline)
            {
                case Airlines.AY:
                    imagePath = "/Images/finnair.jpg";
                    break;
                case Airlines.BA:
                    imagePath = "/Images/british-airways.jpg";
                    break;
                case Airlines.FI:
                    imagePath = "/Images/ICE_2-984x554.jpg";
                    break;
                case Airlines.LH:
                    imagePath = "/Images/A350-900_Lufthansa.jpg";
                    break;
                case Airlines.SK:
                    imagePath = "/Images/SAS.jpg";
                    break;
                case Airlines.UX:
                    imagePath = "/Images/Air_Europa.jpg";
                    break;

            }
            return imagePath;
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            startBtn.IsEnabled = false;
            landBtn.IsEnabled = true;
            statusCmb.IsEnabled = true;
            flight.IsStarted = true;
        }
    }

}
