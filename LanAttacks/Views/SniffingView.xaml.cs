using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LanAttacks.Views
{
    public partial class SniffingView : UserControl
    {
        public SniffingView()
        {
            InitializeComponent();
            PopulateNetworkInterfaceComboBox();
        }

        private void AmountInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox obj = (TextBox)sender;

            if (obj.Text != "")
            {
                int number = Int32.Parse(obj.Text);
                if (number == 0) number = 1;

                obj.Text = number.ToString();
            }
            else
            {
                obj.Text = "1";
            }
        }

        private void PopulateNetworkInterfaceComboBox()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in interfaces)
            {
                networkInterfaceComboBox.Items.Add(networkInterface.Name);
            }
            networkInterfaceComboBox.SelectedIndex = 0;
        }

        private void SniffingSubmit_Clicked(object sender, RoutedEventArgs e)
        {
            string formattedAmountOfPackets = AmountOfPackets.Text.Trim() != "" ? AmountOfPackets.Text : "1";
            string formattedFilterPackets = FilterPackets.Text.Trim().ToUpper();

            if (formattedAmountOfPackets == "1") AmountOfPackets.Text = "1";

            ResultLabel.Content = $"Sniffing {formattedAmountOfPackets} packets on '{networkInterfaceComboBox.Text}' with '{formattedFilterPackets}' filter ";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
