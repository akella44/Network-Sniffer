using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTM.Objects;
using NTM.PacketsProcessor;
using PacketDotNet;
using NTM.Event_Args;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
namespace NTM.PacketsProcessor
{
    public class UdpPacketHandler
    {
        public event EventHandler<UdpPacketArivedEventArgs> UdpPacketArived;
        public event EventHandler<UdpStreamArivedEventArgs> UdpSessionArrived;
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
                    foreach (var session in _udpStreamBuilder._sessions)
                    {
                        if ((session.Packets[session.Packets.Count - 1].SentTime - session.Packets[session.Packets.Count - 2].SentTime).TotalMinutes > 2)
                        {
                            UdpSessionArrived?.Invoke(this, new UdpStreamArivedEventArgs()
                            {
                                UdpSession = session
                            });
                        }
                    }
                    /*_udpStreamBuilder.completedSessions.AsParallel().ForAll((session) =>
                    {
                        UdpSessionArrived?.Invoke(this, new UdpStreamArivedEventArgs()
                        {
                            UdpSession = session
                        });
                        _udpStreamBuilder.completedSessions.Remove(session);
                    });*/
                }
            }
            catch (Exception ex)
            {
                /*throw new Exception();*/
            }
        }

        public async Task HandleUnfinishedUdpSessions()
        {
            await Task.Run(() => {
                _udpStreamBuilder.Sessions.AsParallel().ForAll(session => UdpSessionArrived?.Invoke(this, new UdpStreamArivedEventArgs
                {
                    UdpSession = session
                }));
            });
        }
    }
}
