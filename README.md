


# Lan Attacks Tool

This is a basic attack tool which includes various attacks such as sniffing, spoofing and ICMP flooding. The application is written in C# using the WPF framework and Python with connection between them using Pythonnet.
## Installation

To use this application, you must have the following prerequisites installed on your system:

    Python 3.10
    WINPCAP
    Scapy module (pip install scapy)
    Pythonnet module (pip install pythonnet and in NuGet packages)

Clone the repository and open the solution in Visual Studio. Make sure to set the startup project to "Lan Attacks Tool".
## Usage

Upon launching the application, you will be presented with a user-friendly interface.
### Sniffing

The "Sniffing" tab allows you to sniff packets on a given interface. Select the interface you wish to sniff and click "Start". The packets will be displayed in the data grid below.
### Spoofing

The "Spoofing" tab allows you to spoof packets on a given interface. Select the interface you wish to spoof and enter the source and destination IP addresses and MAC addresses. Choose the type of packet you wish to send and click "Spoof". The packets will be sent to the target.
### ICMP Flooding

The "ICMP Flooding" tab allows you to flood a target with ICMP packets. Enter the target IP address and click "Start". The packets will be sent to the target.
## Contributing

If you find any bugs or issues, please submit an issue or pull request.
## License

This project is licensed under the MIT License. See the LICENSE file for details.
## Run Locally

Clone the project

```bash
  git clone https://github.com/KrystianRozwag/pcf-proj
```

Install dependencies

```bash
  Python 3.10
  [WINPCAP](https://www.winpcap.org/)
  Scapy module (pip install scapy)
  Pythonnet module (pip install pythonnet and in NuGet packages)
```
Run the application
