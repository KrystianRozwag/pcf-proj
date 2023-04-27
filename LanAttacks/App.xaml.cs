using System.Threading;
using System.Windows;

namespace LanAttacks
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { 
           Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
       }
    }
}
