using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpPcap;
using SharpPcap.LibPcap;
using PacketDotNet;
using PacketDotNet.Ieee80211;
using NTM.Objects;
using NTM.Event_Args;
using NTM.PacketsProcessor;
using System.Threading.Tasks;
using System.Threading;
using Shell.NTM.NetworkProcessor.Event_Args;

namespace NTM
{
    public class PacketsProccesor
    {
        public event EventHandler<NetworkPacketArivedEventArgs> NetworkPacketArived;

        public event EventHandler<TcpPacketArivedEventArgs> TcpPacketArived;
        public event EventHandler<TcpSessionArivedEventArgs> TcpSessionArrived;
        private TcpSessionsBuilder _tcpSessionsBuilder;

        public event EventHandler<UdpPacketArivedEventArgs> UdpPacketArived;
        public event EventHandler<UdpStreamArivedEventArgs> UdpSessionArrived;
        private UdpStreamBuilder _udpStreamBuilder;

        private Queue<PacketDotNet.Packet> _packetsQueue;

        private object _packetsQueueLock;
        private Task _packetProcessingTask;
        private CancellationTokenSource _cts;
        
        public ILiveDevice Device { get; private set; }

        public PacketsProccesor(ILiveDevice device)
        {
            _udpStreamBuilder = new UdpStreamBuilder();
            _tcpSessionsBuilder = new TcpSessionsBuilder();

            Device = device;
            _packetsQueue = new Queue<PacketDotNet.Packet>();
            _packetsQueueLock = new object();
        }

        public async Task StartSniff()
        {
            Device.Open(DeviceModes.Promiscuous, 1000);
            Device.OnPacketArrival += AddPacketToQueue;
            await Task.Run(() => StartPacketProcessingThread());
            Device.StartCapture();
        }

        private void StartPacketProcessingThread()
        {
            _cts = new CancellationTokenSource();
            var ct = _cts.Token;
            _packetProcessingTask = new Task(() => ProcessPaketsFromQueue(ct), ct);
            _packetProcessingTask.Start();
        }
        public void StopPacketProcessing()
        {
            _cts.Cancel();
            Device.StopCapture();
            Device.Close();

            _handleUnfinishedSessions();
        }

        private void AddPacketToQueue(object sender, PacketCapture e)
        {

            var rawPacket = e.GetPacket();
            var packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            lock (_packetsQueueLock)
            {
                _packetsQueue.Enqueue(packet);
            }
        }
        private void ProcessPacket(PacketDotNet.Packet packet)
        {
            try
            {
                if (packet.Extract<PacketDotNet.UdpPacket>() != null | packet.Extract<PacketDotNet.TcpPacket>() != null)
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

                        NetworkPacketArived?.Invoke(this, new NetworkPacketArivedEventArgs()
                        {
                            Packet = Packet
                        });

                        UdpPacketArived?.Invoke(this, new UdpPacketArivedEventArgs()
                        {
                            Packet = Packet
                        });

                        this._udpStreamBuilder.HandlePacket(Packet);

                        foreach (var session in _udpStreamBuilder._sessions)
                        {
                            if ((session.Packets[session.Packets.Count - 1].SentTime - session.Packets[session.Packets.Count - 2].SentTime).TotalSeconds > 30)
                            {
                                UdpSessionArrived?.Invoke(this, new UdpStreamArivedEventArgs()
                                {
                                    UdpSession = session
                                });
                            }
                        }
                    }
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

                        NetworkPacketArived?.Invoke(this, new NetworkPacketArivedEventArgs()
                        {
                            Packet = Packet
                        });

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
                
            }
            catch (Exception ex)
            {
                /*throw new Exception();*/
            }
        }

        private void ProcessPaketsFromQueue(CancellationToken ct)
        {
            while (true)
            {
                lock (_packetsQueueLock)
                {
                    while (_packetsQueue.Count > 0)
                    {
                        var packet = _packetsQueue.Dequeue();
                        ProcessPacket(packet);
                        if (ct.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private async Task _handleUnfinishedSessions()
        {
            await Task.Run(() => {
                _udpStreamBuilder.Sessions.AsParallel().ForAll(session => UdpSessionArrived?.Invoke(this, new UdpStreamArivedEventArgs
                {
                    UdpSession = session
                }));

                _tcpSessionsBuilder.Sessions.AsParallel().ForAll(session => TcpSessionArrived?.Invoke(this, new TcpSessionArivedEventArgs()
                {
                    TcpSession = session
                }));
            });
        }


    }
}
