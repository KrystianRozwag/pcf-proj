//using LanAttacks.ViewModels;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanAttacks.Views
{
    /// <summary>
    /// Logika interakcji dla klasy HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            Runtime.PythonDLL = @"C:\Users\kryst\AppData\Local\Programs\Python\Python310\python310.dll";
            //string EnvPath = @"C:\Users\kryst\AppData\Local\Programs\Python\Python310";
            //string pythonPath = @"C:\Users\kryst\AppData\Local\Programs\Python\Python310\Lib\site-packages\pythonnet";
            //Environment.SetEnvironmentVariable("PATH", EnvPath, EnvironmentVariableTarget.Process);
            //Environment.SetEnvironmentVariable("PYTHONHOME", EnvPath, EnvironmentVariableTarget.Process);
            //Environment.SetEnvironmentVariable("PYTHONPATH", pythonPath, EnvironmentVariableTarget.Process);
            //PythonEngine.PythonHome = Environment.GetEnvironmentVariable("PYTHONHOME", EnvironmentVariableTarget.Process);
            //PythonEngine.PythonPath = Environment.GetEnvironmentVariable("PYTHONPATH", EnvironmentVariableTarget.Process);
        }
    }
}
