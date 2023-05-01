
#! /usr/bin/env python3

from collections import Counter
from scapy.all import sniff
def custom_action(packet):
    # Create tuple of Src/Dst in sorted order
    key = tuple(sorted([packet[0][1].src, packet[0][1].dst]))
    packet_counts.update([key])
    return f"Packet #{sum(packet_counts.values())}: {packet[0][1].src} ==> {packet[0][1].dst}"
## Create a Packet Counter
packet_counts = Counter()

## Define our Custom Action function
def do_sniffing(filterValue, interfaceValue, countValue):   

## Setup sniff, filtering for IP traffic
    sniff(iface=interfaceValue, filter=filterValue, prn=custom_action, count=countValue)

## Print out packet count per A <--> Z address pair
    print("\n".join(f"{f'{key[0]} <--> {key[1]}'}: {count}" for key, count in packet_counts.items()))
    return dict(packet_counts)