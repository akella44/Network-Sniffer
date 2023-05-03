using NTM.Objects;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;

namespace NTM.PacketsProcessor
{
    public class UdpStreamBuilder
    {
        public List<UdpSession> _sessions;
        public List<UdpSession> completedSessions { get; set; }

        private int _indexOfCurrentSession;
        public IEnumerable<UdpSession> Sessions
        {
            get
            {
                return this._sessions.Select(kvp => new UdpSession()
                {
                    SentTime = kvp.SentTime,
                    SourceIp = kvp.SourceIp,
                    DestinationIp = kvp.DestinationIp,
                    SourcePort = kvp.SourcePort,
                    DestinationPort = kvp.DestinationPort,
                    Data = kvp.Data,
                    Packets = kvp.Packets
                });
            }
            private set { }
        }

        public UdpStreamBuilder()
        {
            _sessions = new List<UdpSession>();
        }

        public void HandlePacket(Objects.UdpPacket udpPacket)
        {
            var currentSession = new UdpSession()
            {
                SentTime = udpPacket.SentTime,
                SourceIp = udpPacket.SourceIp,
                SourcePort = udpPacket.SourcePort,
                DestinationIp = udpPacket.DestinationIp,
                DestinationPort = udpPacket.DestinationPort,
            };

            if (!_sessions.AsParallel().Contains(currentSession))
            {
                _sessions.Add(currentSession);
            }
            /*foreach (var session in _sessions)
            {
                if ((session).Equals(currentSession))
                {
                    break;
                }
                if((session.Packets[-1].SentTime - session.SentTime).TotalMinutes > 2)
                {
                    completedSessions.Add(session);
                }
            }*/
            _indexOfCurrentSession = _sessions.FindIndex(session => currentSession.Equals(session));
            _sessions[_indexOfCurrentSession].Packets.Add(udpPacket);
        }

        public void Clear()
        {
            _sessions.Clear();
        }

        /*public void Validate()
        {
            List<int> lk = new List<int>();
            lk = _sessions.FindAll(session => ((session.Packets[-1].SentTime - session.SentTime).Minutes > 2));
        }*/
    }
}
