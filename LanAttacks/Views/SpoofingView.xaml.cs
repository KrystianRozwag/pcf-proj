using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LanAttacks.Views
{
    public partial class SpoofingView : UserControl
    {
        public SpoofingView()
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

            ResultLabel.Content = $"Spoofing {Protocol.Text} protocol from {srcIpAddress} to {dstIpAddress} with {formattedAmountOfPackets} packets.";
        }
    }
}
