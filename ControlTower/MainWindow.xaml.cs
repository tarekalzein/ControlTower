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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ControlTower.Enums;

namespace ControlTower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            airlinesCombobox.ItemsSource = Enum.GetValues(typeof(Airlines)).Cast<Airlines>();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int flightNumber;
            if(int.TryParse(flightNumberTxt.Text, out flightNumber))
            {
                Airlines airline = (Airlines)Enum.Parse(typeof(Airlines), airlinesCombobox.Text);
                FlightWindow flightWindow = new FlightWindow(airline, flightNumber);
                flightWindow.Show();

                flightsLv.Items.Add(new { FlightCode = airline.ToString() + " " + flightNumber, FlightStatus = "Sent to runway", Time = DateTime.Now }); ;

                flightWindow.FlightStarted += OnFlightStarted;
                flightWindow.FlightStatusChanged += OnOnFlightStatusChanged;
                flightWindow.FlightLanded += OnFlightLanded;
            }
            else
            {
                MessageBox.Show("Please enter a valid flight number. Only Digits Allowed.");
            }
            
        }

        public void OnFlightStarted(object source, FlightEventInfo e)
        {
            flightsLv.Items.Add(new { FlightCode=e.Flight.FlightCode,FlightStatus="Started", Time=DateTime.Now});
        }

        public void OnOnFlightStatusChanged(object source, FlightEventInfo e)
        {
            flightsLv.Items.Add(new { FlightCode = e.Flight.FlightCode, FlightStatus = e.Status, Time = DateTime.Now });

        }
        public void OnFlightLanded(object source, FlightEventInfo e)
        {
            flightsLv.Items.Add(new { FlightCode = e.Flight.FlightCode, FlightStatus = "Landed", Time = DateTime.Now });

        }

    }
}
