using System.ComponentModel;
using Python.Runtime;
using System.Reflection;
using System.Windows.Controls;
using System.IO;

namespace LanAttacks.Views
{
    /// <summary>
    /// Logika interakcji dla klasy HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private readonly ObservableObject? _observableObject;
        public HomeView()
        {
            InitializeComponent();
            /*string EnvPath = @"C:\Users\kryst\AppData\Local\Programs\Python\Python310";
            string pythonPath = @"C:\Users\kryst\AppData\Local\Programs\Python\Python310\Lib\site-packages\pythonnet";
            Environment.SetEnvironmentVariable("PATH", EnvPath, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("PYTHONHOME", EnvPath, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable("PYTHONPATH", pythonPath, EnvironmentVariableTarget.Process);
            PythonEngine.PythonHome = Environment.GetEnvironmentVariable("PYTHONHOME", EnvironmentVariableTarget.Process);
            PythonEngine.PythonPath = Environment.GetEnvironmentVariable("PYTHONPATH", EnvironmentVariableTarget.Process);*/
        }
        public HomeView(ObservableObject observableObject)
        {
            InitializeComponent();
            _observableObject = observableObject;
            _observableObject.PropertyChanged += OnObservableObjectPropertyChanged;
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
        }
        private void OnObservableObjectPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Language")
            {
                if (_observableObject != null && _observableObject.Language == "pl")
                {
                    homeTitle.Content = "Strona Główna";
                    homeDesc.Text = "Witaj w LanAttacks! LanAttacks to oprogramowanie pentestowe, które umożliwia testowanie Twojej sieci LAN. Dostępne są trzy różne rodzaje ataków:";
                    homeSpoofDesc.Text = "Spoofing - polega na fałszowaniu adresów źródłowych pakietów danych, aby wydawało się, że pochodzą one z innych adresów niż rzeczywiste. Atakujący może użyć tej techniki, aby ukryć swoją tożsamość lub wprowadzić w błąd systemy zabezpieczeń sieciowych.";
                    homeSpiffDesc.Text = "Sniffing - polega na podsłuchiwaniu ruchu sieciowego, aby uzyskać poufne informacje, takie jak hasła, nazwy użytkowników, numery kart kredytowych itp. Atakujący używa oprogramowania do przechwytywania pakietów danych przesyłanych w sieci.";
                    homeICMPDesc.Text = "ICMP Flooding - polega na przesyłaniu dużej liczby żądań ICMP (Internet Control Message Protocol) do urządzenia docelowego w celu zablokowania jego działania. Atakujący wysyła duże ilości pakietów ICMP, co może doprowadzić do przeciążenia sieci i spowodować niestabilność lub awarię systemu.";
                }
                else if (_observableObject != null && _observableObject.Language == "en")
                {
                    homeTitle.Content = "Home";
                    homeDesc.Text = "Welcome to LanAttacks! LanAttacks is a pentesting software that allows you to test your Local Area Network. There are 3 different types of attacks:";
                    homeSpoofDesc.Text = "Spoofing -  it involves falsifying the source addresses of data packets to make it appear that they originate from different addresses than the actual ones. Attackers can use this technique to hide their identity or deceive network security systems.";
                    homeSpiffDesc.Text = "Sniffing -  it refers to eavesdropping on network traffic in order to obtain sensitive information such as passwords, usernames, credit card numbers, etc. The attacker uses software to capture data packets transmitted on the network.";
                    homeICMPDesc.Text = "ICMP Flooding -  it involves sending a large number of Internet Control Message Protocol (ICMP) requests to a target device in order to disrupt its operation. Attackers send large amounts of ICMP packets, which can overload the network and cause system instability or failure.";
                }
            }
        }
    }
}

