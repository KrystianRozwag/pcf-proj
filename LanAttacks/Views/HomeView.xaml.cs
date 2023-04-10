//using LanAttacks.ViewModels;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.IO;
using System.Windows.Media.TextFormatting;

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
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string pythonDLLPath = File.ReadAllText(assemblyPath + "\\python3_path.txt");
            Runtime.PythonDLL = pythonDLLPath;

            PythonEngine.Initialize();
            string newPath = "";
            using (Py.GIL())
            {
                dynamic separatedString = assemblyPath.Split("\\");
                foreach (dynamic pathItem in separatedString)
                {
                    newPath = newPath + pathItem + "\\";
                    if (pathItem == "LanAttacks")
                    {
                        newPath = newPath + "PythonModules";
                        break;
                    }
                }
                dynamic sys = Py.Import("sys");
                sys.path.append(newPath);

            }
            PythonEngine.Shutdown();

            /*string EnvPath = @"C:\Users\kryst\AppData\Local\Programs\Python\Python310";
            string pythonPath = @"C:\Users\kryst\AppData\Local\Programs\Python\Python310\Lib\site-packages\pythonnet";
            Environment.SetEnvironmentVariable("PATH", EnvPath, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("PYTHONHOME", EnvPath, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("PYTHONPATH", pythonPath, EnvironmentVariableTarget.Process);
            PythonEngine.PythonHome = Environment.GetEnvironmentVariable("PYTHONHOME", EnvironmentVariableTarget.Process);
            PythonEngine.PythonPath = Environment.GetEnvironmentVariable("PYTHONPATH", EnvironmentVariableTarget.Process);*/
        }
    }
}
