using Python.Runtime;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System;

namespace LanAttacks.Views
{
    public partial class SniffingView : UserControl
    {
        private readonly ObservableObject? _observableObject;
        public SniffingView()
        {
            InitializeComponent();
            PopulateNetworkInterfaceComboBox();
        }
        public SniffingView(ObservableObject observableObject)
        {
            InitializeComponent();
            PopulateNetworkInterfaceComboBox();
            _observableObject = observableObject;
            _observableObject.PropertyChanged += OnObservableObjectPropertyChanged;
        }

        private void OnObservableObjectPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (_observableObject != null && _observableObject.Language == "pl")
            {
                sniffNumOfPacketsToSearch.Content = "Liczba pakietów do przechwycenia";
                sniffFilterPackets.Content = "Filtr pakietów";
                sniffNetworkInterface.Content = "Interfejs sieciowy";
                sniffBtn.Content = "Rozpocznij Sniffing";
            }
            else if (_observableObject != null && _observableObject.Language == "en")
            {
                sniffNumOfPacketsToSearch.Content = "Number of packets to search";
                sniffFilterPackets.Content = "Filter packets";
                sniffNetworkInterface.Content = "Network interface";
                sniffBtn.Content = "Start Sniffing";
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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
            string formattedInterface = networkInterfaceComboBox.Text;
            

            string formattedFilterPackets = FilterPackets.Text.Trim().ToUpper();

            if (formattedAmountOfPackets == "1") AmountOfPackets.Text = "1";

            //ResultLabel.Content = $"Sniffing {formattedAmountOfPackets} packets on '{networkInterfaceComboBox.Text}' with '{formattedFilterPackets}' filter ";

            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic collections = Py.Import("SniffingModule");
                dynamic result = collections.do_sniffing(formattedFilterPackets.ToLower(), formattedInterface, int.Parse(formattedAmountOfPackets));
                if (result != null)
                {
                    foreach (dynamic key in result.keys())
                    {
                        ResultLabel.Content = ResultLabel.Content + "\n" + key + ":" + result[key];
                    }
                }
                else
                {
                    ResultLabel.Content = "Sniffing attack has failed.";
                }

            }
            PythonEngine.Shutdown();
        }
        private void TextBox_focusHandler(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }
}
