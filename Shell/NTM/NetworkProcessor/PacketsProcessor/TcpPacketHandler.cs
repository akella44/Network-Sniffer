using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTM.PacketsProcessor;
using NTM.Event_Args;
using System.Threading.Tasks;

namespace NTM.PacketsProcessor
{
    public class TcpPacketHandler
    {
        public event EventHandler<TcpPacketArivedEventArgs> TcpPacketArived;
        public event EventHandler<TcpSessionArivedEventArgs> TcpSessionArrived;

        private TcpSessionsBuilder _tcpSessionsBuilder;
        public bool BuildTcpSessions { get; set; }
        public TcpPacketHandler() 
        {
            _tcpSessionsBuilder = new TcpSessionsBuilder();
            BuildTcpSessions = true;    
        }

        public void TcpProcess(PacketDotNet.Packet packet)
        {
            try
            {
                var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
                if (tcpPacket != null)
                {
                    var ethPacket = packet.Extract<EthernetPacket>();
                    var ipPacket = (IPPacket)tcpPacket.ParentPacket;

                    NTM.Objects.TcpPacket Packet = new NTM.Objects.TcpPacket
                    {
                        SentTime = DateTime.Now,
                        SourcePort = tcpPacket.SourcePort,
                        DestinationPort = tcpPacket.DestinationPort,
                        SourceIp = ipPacket.SourceAddress.ToString(),
                        DestinationIp = ipPacket.DestinationAddress.ToString(),
                        Data = tcpPacket.PayloadData ?? new byte[] { },
                        Flag = tcpPacket.Flags,
                        Protocol = "Tcp"
                    };

                    TcpPacketArived?.Invoke(this, new TcpPacketArivedEventArgs()
                    {
                        Packet = Packet
                    });

                    this._tcpSessionsBuilder.HandlePacket(Packet);
                    _tcpSessionsBuilder.completedSessions.AsParallel().ForAll((session) =>
                    {
                        TcpSessionArrived?.Invoke(this, new TcpSessionArivedEventArgs()
                        {
                            TcpSession = session
                        });
                        _tcpSessionsBuilder.completedSessions.Remove(session);
                    });
                }
            }
            catch (Exception ex)
            {
                /*throw new Exception();*/
            }
        }

        public async Task /*void*/ HandleUnfinishedTcpSessions()
        {
            await Task.Run(() => {
                _tcpSessionsBuilder.Sessions.AsParallel().ForAll(session => TcpSessionArrived?.Invoke(this, new TcpSessionArivedEventArgs()
                {
                    TcpSession = session
                }));
            });
            
        }
    }
}
