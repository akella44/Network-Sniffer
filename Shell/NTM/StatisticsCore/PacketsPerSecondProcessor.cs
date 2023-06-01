using Shell.NTM.StatisticsCore.Event_Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NTM.PacketsProcessor;
using NTM;
using Shell.NTM.NetworkProcessor.Event_Args;
using System.Windows;

namespace Shell.NTM.StatisticsCore
{
    public class PacketsPerSecondProcessor
    {
        public event EventHandler<MoreThenTresholdDetectedEventArgs> SuspTrafficDetected;
        public int Treshold { get; private set; }
        public int TimeInterval { get; private set; }
        public Dictionary<string, int> TrafficPerSecond;
        private object _dictionaryLock;
        
        private Task _trafficPerSecondProcessingTask;
        private CancellationTokenSource _cts;

        private PacketsProccesor _packetsProcessor;

        public PacketsPerSecondProcessor(int treshold, int timeInterval, PacketsProccesor packetsProccesor) 
        {
            TrafficPerSecond = new Dictionary<string, int>();
            Treshold = treshold;
            TimeInterval = timeInterval;
            _packetsProcessor = packetsProccesor;
            _dictionaryLock = new object();
        }

        public void StartCalculatePacketsPerSeconds()
        {
            _cts = new CancellationTokenSource();
            var ct = _cts.Token;
            _trafficPerSecondProcessingTask = new Task(() => _handlePackets(ct), ct);
            _trafficPerSecondProcessingTask.Start();
        }

        public void StopCalculatePacketsPerSeconds()
        {
            _cts.Cancel();
            TrafficPerSecond.Clear();
        }
        private void _handlePackets(CancellationToken ct)
        {
            while (true)
            {
                DateTime start = DateTime.Now;
                lock(_dictionaryLock)
                {
                    while ((DateTime.Now - start).TotalSeconds < TimeInterval)
                    {
                        _packetsProcessor.NetworkPacketArived += _handleNetworkPacket;
                    }
                }
                _packetsProcessor.NetworkPacketArived -= _handleNetworkPacket;
                lock (_dictionaryLock)
                {
                    foreach (var obj in TrafficPerSecond.Keys)
                    {
                        if (TrafficPerSecond[obj] > Treshold)
                        {
                            SuspTrafficDetected?.Invoke(this, new MoreThenTresholdDetectedEventArgs()
                            {
                                IpAdress = obj,
                                PacketsCountPerSecond = TrafficPerSecond[obj]
                            });
                        }
                    }
                }
                TrafficPerSecond.Clear();
                if (ct.IsCancellationRequested)
                {
                    return;
                }
            }
        }

        private void _handleNetworkPacket(object sender, NetworkPacketArivedEventArgs e)
        {
            lock (_dictionaryLock)
            {
                if (!TrafficPerSecond.Keys.AsParallel().Contains(e.Packet.DestinationIp))
                {
                    TrafficPerSecond.Add(e.Packet.DestinationIp, 0);
                }
                TrafficPerSecond[e.Packet.DestinationIp]++;
            }
        }
        
    }
}
