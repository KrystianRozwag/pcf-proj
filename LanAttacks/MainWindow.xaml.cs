using System.Windows;
using LanAttacks.ViewModels;

namespace LanAttacks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }

        private void HomeView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        private void SpoofingView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new SpoofingViewModel();
        }

        private void SniffingView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new SniffingViewModel();
        }

        private void ICMPFloodingView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ICMPFloodingViewModel();
        }
    }
}
