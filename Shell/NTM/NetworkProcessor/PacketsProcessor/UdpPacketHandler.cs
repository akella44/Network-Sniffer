using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTM.Objects;
using NTM.PacketsProcessor;
using PacketDotNet;
using NTM.Event_Args;
namespace NTM.PacketsProcessor
{
    public class UdpPacketHandler
    {
        public delegate void UdpPacketArivedEventHandler(object sender, UdpPacketArivedEventArgs e);
        public event UdpPacketArivedEventHandler UdpPacketArived;
        public delegate void UdpSessionArrivedEventHandler(object sender, UdpStreamArivedEventArgs e);
        public event UdpSessionArrivedEventHandler UdpSessionArrived;
        private UdpStreamBuilder _udpStreamBuilder;
        public UdpPacketHandler() 
        {
            _udpStreamBuilder = new UdpStreamBuilder();
        }

        public void UdpProcess(PacketDotNet.Packet packet)
        {
            try
            {
                var udpPacket = packet.Extract<PacketDotNet.UdpPacket>();
                if (udpPacket != null)
                {
                    var ipPacket = packet.Extract<IPPacket>();
                    var ethPacket = packet.Extract<EthernetPacket>();

                    NTM.Objects.UdpPacket Packet = new NTM.Objects.UdpPacket
                    {
                        SentTime = DateTime.Now,
                        SourcePort = udpPacket.SourcePort,
                        DestinationPort = udpPacket.DestinationPort,
                        SourceIp = ipPacket.SourceAddress.ToString(),
                        DestinationIp = ipPacket.DestinationAddress.ToString(),
                        Data = udpPacket.PayloadData ?? new byte[] { },
                        Protocol = "Udp"
                    };

                    UdpPacketArived?.Invoke(this, new UdpPacketArivedEventArgs()
                    {
                        Packet = Packet
                    });

                    this._udpStreamBuilder.HandlePacket(Packet);
                    if (_udpStreamBuilder.completedSessions.Count != 0)
                    {
                        _udpStreamBuilder.completedSessions.AsParallel().ForAll((session) =>
                        {
                            UdpSessionArrived?.Invoke(this, new UdpStreamArivedEventArgs()
                            {
                                UdpSession = session
                            });
                            _udpStreamBuilder.completedSessions.Remove(session);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void HandleUnfinishedUdpSessions()
        {
            _udpStreamBuilder.Sessions.AsParallel().ForAll(session => UdpSessionArrived?.Invoke(this, new UdpStreamArivedEventArgs
            {
                UdpSession = session
            }));
        }
    }
}
