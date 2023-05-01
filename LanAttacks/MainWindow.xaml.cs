using LanAttacks.Views;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LanAttacks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableObject _observableObject = new ObservableObject();
        readonly SolidColorBrush highlightBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#252836"));
        readonly SolidColorBrush standardBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1f1d2b"));
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new HomeView(_observableObject);
        }

        private void HomeView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeView(_observableObject);

            homeNav.Background = highlightBackgroundColor;
            spoofNav.Background = standardBackgroundColor;
            sniffNav.Background = standardBackgroundColor;
            icmpNav.Background = standardBackgroundColor;
        }
        private void ICMPFloodingView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ICMPFloodingView(_observableObject);

            homeNav.Background = standardBackgroundColor;
            spoofNav.Background = standardBackgroundColor;
            sniffNav.Background = standardBackgroundColor;
            icmpNav.Background = highlightBackgroundColor;
        }

        private void SniffingView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new SniffingView(_observableObject);

            homeNav.Background = standardBackgroundColor;
            spoofNav.Background = standardBackgroundColor;
            sniffNav.Background = highlightBackgroundColor;
            icmpNav.Background = standardBackgroundColor;
        }
        private void SpoofingView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new SpoofingView(_observableObject);

            homeNav.Background = standardBackgroundColor;
            spoofNav.Background = highlightBackgroundColor;
            sniffNav.Background = standardBackgroundColor;
            icmpNav.Background = standardBackgroundColor;
        }

        private void ChangeLanguageHandler(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == 0)
            {
                ChangeToEnglish();
            }
            else if (comboBox.SelectedIndex == 1)
            {
                ChangeToPolish();
            }
        }

        private void ChangeToEnglish()
        {
            _observableObject.Language = "en";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            Button? homeButton = (Button)FindName("homeNav");
            Label? languageLabel = (Label)FindName("languageOpt");

            if (homeButton != null && languageLabel != null)
            {
                homeButton.Content = Properties.Translations.Lang.navHome;
                languageLabel.Content = Properties.Translations.Lang.language;
            }
        }

        private void ChangeToPolish()
        {
            _observableObject.Language = "pl";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");

            Button? homeButton = (Button)FindName("homeNav");
            Label? languageLabel = (Label)FindName("languageOpt");

            if (homeButton != null && languageLabel != null)
            {
                homeButton.Content = Properties.Translations.Lang.navHome;
                languageLabel.Content = Properties.Translations.Lang.language;
            }
        }
    }
}