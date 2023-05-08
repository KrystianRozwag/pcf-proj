import scapy.all as scapy
import time
import random
  
 
def spoof(spoof_ip, target_ip, protocol, packet_amount):
    src_port = random.randint(1024, 65535)  
    packet = None
    response = None
    try:
        if(protocol == "TCP/IP"):
            packet = scapy.IP(src = spoof_ip, dst = target_ip)/scapy.TCP(sport = src_port, dport = 80, flags='S')
        elif(protocol == "ARP"):
            packet = scapy.ARP(op = 1, pdst = target_ip)
            response = scapy.sr1(packet, verbose = False)
        elif(protocol == "UDP"):
            packet = scapy.IP(src = spoof_ip, dst = target_ip)/scapy.UDP(sport = src_port, dport = 53)
        elif(protocol == "ICMP"):
            packet = scapy.IP(src = spoof_ip, dst = target_ip)/scapy.ICMP()
    except Exception as e:
        print(e)
    if response:
        return f"{response.summary()}"
    else:
        return f"{packet.summary()}"
    #return packet

    
    scapy.send(packet, verbose = False)
    
    return
