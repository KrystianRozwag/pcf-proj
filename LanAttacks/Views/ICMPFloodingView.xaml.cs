﻿using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net.Sockets;
using System.Net;
using System.Printing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.IO;
using LanAttacks.ViewModels;
using System.Net.NetworkInformation;
using System.Linq;

namespace LanAttacks.Views
{
    public partial class ICMPFloodingView : UserControl
    {

        public ICMPFloodingView()
        {
            InitializeComponent();
        }

        private void AmountInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox obj = (TextBox)sender;

            if (obj.Text == "0" || obj.Text == "")
            {
                obj.Text = "1";
            }
        }

        private string GetMACAddress(string ipAddress)
        {
            var nic = NetworkInterface.GetAllNetworkInterfaces()
            .FirstOrDefault(n => n.GetIPProperties().UnicastAddresses
                .Any(a => a.Address.Equals(IPAddress.Parse(ipAddress))));

            if (nic != null)
            {
                byte[] macAddressBytes = nic.GetPhysicalAddress().GetAddressBytes();
                return BitConverter.ToString(macAddressBytes);
            }
            else
            {
                return null;
            }
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
            
            //ResultLabel.Content = $"ICMP Flooding on the {dstIpAddress} with {formattedAmountOfPackets} packets.";
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic collections = Py.Import("SpoofingModule");
                dynamic result = collections.spoof("192.168.1.11", dstIpAddress, "ICMP", GetMACAddress(dstIpAddress), AmountOfPackets);
                if(result != null) {
                    foreach (dynamic key in result.keys())
                    {
                        ResultLabel.Content = ResultLabel.Content + "\n" + key + ":" + result[key];
                    }
                }
                else
                {
                    ResultLabel.Content = "This dst host does not exist.";
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
