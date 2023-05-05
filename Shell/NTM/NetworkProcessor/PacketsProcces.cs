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

namespace NTM
{
    public class PacketsProcces
    {
        public TcpPacketHandler _tcpHandler;
        public UdpPacketHandler _udpHandler;
        private Queue<PacketDotNet.Packet> _packetsQueue;
        private object _packetsQueueLock;
        private Task _packetProcessingTask;
        private CancellationTokenSource _cts;
        
        public ILiveDevice Device { get; private set; }

        public PacketsProcces(ILiveDevice device)
        {
            _tcpHandler = new TcpPacketHandler();
            _udpHandler = new UdpPacketHandler();
            Device = device;
            _packetsQueue = new Queue<PacketDotNet.Packet>();
            _packetsQueueLock = new object();
        }

        public async void StartSniff()
        {
            Device.Open(DeviceModes.Promiscuous, 1000);
            Device.OnPacketArrival += AddPacketToQueue;
            StartPacketProcessingThread();
            Device.StartCapture();
        }

        /*private void WaitForStopSniffingSignal(CancellationToken ct)
        {
            while (true)
            {
                Thread.Sleep(1000);

                if (ct.IsCancellationRequested)
                {
                    break;
                }
            }
        }*/

        private async Task StartPacketProcessingThread()
        {
            _cts = new CancellationTokenSource();
            var ct = _cts.Token;
            /*_packetProcessingTask = new Task(() => ProcessPaketsFromQueue(ct), ct);
            _packetProcessingTask.Start();*/
            await Task.Run(() => ProcessPaketsFromQueue(ct), ct);
        }
        public /*async*/ void StopPacketProcessing()
        {
            _cts.Cancel();
            Device.StopCapture();
            Device.Close();
            /*HandleUnfinishedSessions();*/
            /*await*/ _udpHandler.HandleUnfinishedUdpSessions();
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
            _tcpHandler.TcpProcess(packet);
            _udpHandler.UdpProcess(packet);
        }


        /*private void HandleUnfinishedSessions()
        {
            _tcpSessionsBuilder.Sessions.AsParallel().ForAll(session => TcpSessionArrived?.Invoke(this, new TcpSessionArivedEventArgs()
            {
                TcpSession = session
            }));

            _udpStreamBuilder.Sessions.AsParallel().ForAll(session => UdpSessionArrived?.Invoke(this, new UdpSessionArrivedEventArgs()
            {
                UdpSession = session
            }));
        }*/
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

    }
}
