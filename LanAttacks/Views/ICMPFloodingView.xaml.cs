using Python.Runtime;
using System;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.NetworkInformation;
using System.Linq;
using System.ComponentModel;

namespace LanAttacks.Views
{
    public partial class ICMPFloodingView : UserControl
    {
        private readonly ObservableObject? _observableObject;
        public ICMPFloodingView()
        {
            InitializeComponent();
        }
        public ICMPFloodingView(ObservableObject observableObject)
        {
            InitializeComponent();
            _observableObject = observableObject;
            _observableObject.PropertyChanged += OnObservableObjectPropertyChanged;
        }

        private void OnObservableObjectPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (_observableObject != null && _observableObject.Language == "pl")
            {
                icmpNumOfPacketsToSend.Content = "Liczba pakietów do wysłania";
                icmpDestinationIpAddress.Content = "Docelowy adres IP";
                icmpBtn.Content = "Rozpocznij ICMP Flooding";
            }
            else if (_observableObject != null && _observableObject.Language == "en")
            {
                icmpNumOfPacketsToSend.Content = "Number of packets to send";
                icmpDestinationIpAddress.Content = "Destination IP Address";
                icmpBtn.Content = "Start ICMP Flooding";
            }
        }
        private void AmountInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox obj = (TextBox)sender;

            if (obj.Text != "")
            {
                if (obj.Text == "0") obj.Text = "1";
                else
                {
                    int packetNumber = Int32.Parse(obj.Text);
                    int updatedNumber = packetNumber;

                    if (packetNumber > 100) updatedNumber = 100;

                    obj.Text = updatedNumber.ToString();
                }
            }
            else obj.Text = "1";
        }
        private void TextBox_focusHandler(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private string GetLocalIPAddress()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIPs)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }
            return null;
        }

        private void ICMPSubmit_Clicked(object sender, RoutedEventArgs e)
        {

            string formattedDstFirstOctet = DstFirstOctet.Text.Trim() != "" ? DstFirstOctet.Text : "0";
            string formattedDstSecondOctet = DstSecondOctet.Text.Trim() != "" ? DstSecondOctet.Text : "0";
            string formattedDstThirdOctet = DstThirdOctet.Text.Trim() != "" ? DstThirdOctet.Text : "0";
            string formattedDstFourthOctet = DstFourthOctet.Text.Trim() != "" ? DstFourthOctet.Text : "0";

            string formattedAmountOfPackets = AmountOfPackets.Text.Trim() != "" ? AmountOfPackets.Text : "1";

            if (formattedAmountOfPackets == "1") AmountOfPackets.Text = "1";

            string hostName = Dns.GetHostName();
            IPHostEntry host = Dns.GetHostEntry(hostName);
            string srcIpAddress = string.Empty;
            foreach (IPAddress address in host.AddressList)
            {
                if(address.AddressFamily == AddressFamily.InterNetwork)
                {
                    srcIpAddress = address.ToString();
                    break;
                }
            }

            string dstIpAddress = formattedDstFirstOctet + "." + formattedDstSecondOctet + "." + formattedDstThirdOctet + "." + formattedDstFourthOctet;


            // Set the module search path for pythonnet to include the directory of the executing assembly

            ResultLabel.Content = $"Flooding in progress ";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic collections = Py.Import("SpoofingModule");
                dynamic result = collections.spoof(GetLocalIPAddress(), dstIpAddress, "ICMP", AmountOfPackets);
                if(result != null) {
                    ResultLabel.Content = ResultLabel.Content + "\n" + result;
                }
                else
                {
                    ResultLabel.Content = "This destination host does not exist.";
                }
                

            }
            PythonEngine.Shutdown();
        }

        private void IpInputLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox obj = (TextBox)sender;

            if (obj.Text != "")
            {
                int octetNumber = Int32.Parse(obj.Text);
                int updatedNumber = octetNumber;

                if (octetNumber > 255) updatedNumber = 255;

                obj.Text = updatedNumber.ToString();
            } else
            {
                obj.Text = "0";
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
