using Python.Runtime;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.NetworkInformation;
using System.Net;
using System.ComponentModel;
namespace LanAttacks.Views
{
    public partial class SpoofingView : UserControl
    {
        private readonly ObservableObject? _observableObject;
        public SpoofingView()
        {
            InitializeComponent();
        }
        public SpoofingView(ObservableObject observableObject)
        {
            InitializeComponent();
            _observableObject = observableObject;
            _observableObject.PropertyChanged += OnObservableObjectPropertyChanged;
        }

        private void OnObservableObjectPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Language")
            {
                if (_observableObject != null && _observableObject.Language == "pl")
                {
                    spoofNumOfPacketsToSend.Content = "Liczba pakietów do wysłania";
                    spoofSourceIpAddress.Content = "Źródłowy adres IP";
                    spoofDestinationIpAddress.Content = "Docelowy adres IP";
                    spoofProtocol.Content = "Protokół sieciowy";
                    spoofBtn.Content = "Rozpocznij Spoofing";
                }
                else if (_observableObject != null && _observableObject.Language == "en")
                {
                    spoofNumOfPacketsToSend.Content = "Number of packets to send";
                    spoofSourceIpAddress.Content = "Source IP Address";
                    spoofDestinationIpAddress.Content = "Destination IP Address";
                    spoofProtocol.Content = "Network protocol";
                    spoofBtn.Content = "Start Spoofing";
                }
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

        private void SpoofingSubmit_Clicked(object sender, RoutedEventArgs e)
        {
            string formattedSrcFirstOctet = SrcFirstOctet.Text.Trim() != "" ? SrcFirstOctet.Text : "0";
            string formattedSrcSecondOctet = SrcSecondOctet.Text.Trim() != "" ? SrcSecondOctet.Text : "0";
            string formattedSrcThirdOctet = SrcThirdOctet.Text.Trim() != "" ? SrcThirdOctet.Text : "0";
            string formattedSrcFourthOctet = SrcFourthOctet.Text.Trim() != "" ? SrcFourthOctet.Text : "0";

            string formattedDstFirstOctet = DstFirstOctet.Text.Trim() != "" ? DstFirstOctet.Text : "0";
            string formattedDstSecondOctet = DstSecondOctet.Text.Trim() != "" ? DstSecondOctet.Text : "0";
            string formattedDstThirdOctet = DstThirdOctet.Text.Trim() != "" ? DstThirdOctet.Text : "0";
            string formattedDstFourthOctet = DstFourthOctet.Text.Trim() != "" ? DstFourthOctet.Text : "0";

            string formattedAmountOfPackets = AmountOfPackets.Text.Trim() != "" ? AmountOfPackets.Text : "1";

            if (formattedAmountOfPackets == "1") AmountOfPackets.Text = "1";

            string srcIpAddress = formattedSrcFirstOctet + "." + formattedSrcSecondOctet + "." + formattedSrcThirdOctet + "." + formattedSrcFourthOctet;
            string dstIpAddress = formattedDstFirstOctet + "." + formattedDstSecondOctet + "." + formattedDstThirdOctet + "." + formattedDstFourthOctet;

            //ResultLabel.Content = $"Spoofing {Protocol.Text} protocol from {srcIpAddress} to {dstIpAddress} with {formattedAmountOfPackets} packets.";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic collections = Py.Import("SpoofingModule");
                dynamic result = collections.spoof(srcIpAddress, dstIpAddress, Protocol.Text.ToUpper(), AmountOfPackets);
                if (result != null)
                {
                    ResultLabel.Content = ResultLabel.Content + "\n" + result;
                }
                else
                {
                    ResultLabel.Content = "This destination host does not exist.";
                }
                

            }
            PythonEngine.Shutdown();
        }
    }
}
