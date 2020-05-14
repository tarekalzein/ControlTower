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

        // Step 1 - Create a delegate
        public delegate void FlightEventHandler(object source, FlightEventInfo eventInfo);

        //Step 2- create Events
        public event FlightEventHandler FlightStarted;
        public event FlightEventHandler FlightStatusChanged;
        public event FlightEventHandler FlightLanded;

        //Step 3- Raise the events

        protected virtual void OnFlightStarted(Flight flight)
        {
            if(FlightStarted!=null)
            {
                FlightStarted(this, new FlightEventInfo() { Flight=flight });
            }
        }

        protected virtual void OnFlightStatusChanged(Flight flight, string status)
        {
            if(FlightStatusChanged!=null)
            {                
                FlightStatusChanged(this, new FlightEventInfo(){Flight=flight,Status=status } );
            }
        }

        protected virtual void OnFlightLanded(Flight flight)
        {
            if(FlightLanded!=null)
            {
                FlightLanded(this, new FlightEventInfo() { Flight = flight });
            }
        }

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

            //Create the Flight object for this window.
            flight = new Flight
            {
                FlightAirline = airline,
                FlightCode = airline.ToString() + " " + flightNumber.ToString(),
                FlightImagePath = ImagePathFinder(airline),
            };
            InitializeComponent();

            //Set GUI items.
            flightImage.Source = new BitmapImage(new Uri("/ControlTower;component"+flight.FlightImagePath, UriKind.Relative));
            flightNumberLbl.Content = flight.FlightCode;
            for (int i=0;i<181;i+=10)
            {
                statusCmb.Items.Add(i + " deg");
            }    


            //Disable Combobox and Land button by default on start.
            landBtn.IsEnabled = false;
            statusCmb.IsEnabled = false;

        }
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            //Toggle buttons after Flight Start is initiated.
            startBtn.IsEnabled = false;
            landBtn.IsEnabled = true;
            statusCmb.IsEnabled = true;

            //Publish : Flight Start.
            OnFlightStarted(flight);
        }

        private void statusCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: Check if not null.
            OnFlightStatusChanged(flight,statusCmb.SelectedItem.ToString());
        }

        private void landBtn_Click(object sender, RoutedEventArgs e)
        {
            OnFlightLanded(flight); 
            this.Close();
        }



        #region "Helper Function"

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

        #endregion


    }

}
