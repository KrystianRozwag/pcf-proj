using Python.Runtime;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;

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

            if (obj.Text == "0" || obj.Text == "")
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
                    ResultLabel.Content = "This dst host does not exist.";
                }

            }
            PythonEngine.Shutdown();
        }
    }
}
