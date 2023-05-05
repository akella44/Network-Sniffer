using NTM.Event_Args;
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
            completedSessions = new List<UdpSession>();
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
            
            _indexOfCurrentSession = _sessions.FindIndex(session => currentSession.Equals(session));
            _sessions[_indexOfCurrentSession].Packets.Add(udpPacket);

            foreach (var session in _sessions)
            {
                if ((session.Packets[_sessions.Count - 1].SentTime - session.SentTime).TotalSeconds > 5)
                {
                    /*foreach (var currentUdpPacket in _sessions[_indexOfCurrentSession].Packets)
                    {

                        currentSession.Packets.Add(new NTM.Objects.UdpPacket()
                        {
                            SourceIp = currentUdpPacket.SourceIp,
                            SourcePort = currentUdpPacket.SourcePort,
                            DestinationIp = currentUdpPacket.DestinationIp,
                            DestinationPort = currentUdpPacket.DestinationPort,
                            Data = currentUdpPacket.Data,
                            SentTime = currentUdpPacket.SentTime
                        });
                    }*/
                    /*completedSessions.Add(session);
                    _sessions.Remove(session);*/
                }
            }
        }

        public void Clear()
        {
            _sessions.Clear();
        }

        /*public void Validate()
        {
            List<UdpSession> sessions = _sessions.FindAll(session => ((session.Packets[-1].SentTime - session.SentTime).Seconds > 10));
            sessions.AsParallel().ForAll((session) =>
            {
                completedSessions.Add(session);
                _sessions.Remove(session);
            });

        }*/
    }
}
