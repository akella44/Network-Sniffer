using NTM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTM.PacketsProcessor
{
    public class TcpSessionsBuilder
    {
        public List<TcpSession> _sessions;
        public List<TcpSession> completedSessions { get; set; }

        private int _indexOfCurrentSession;
        public IEnumerable<TcpSession> Sessions
        {
            get
            {
                return this._sessions.Select(kvp => new TcpSession()
                {
                    SourceIp = kvp.SourceIp,
                    DestinationIp = kvp.DestinationIp,
                    SourcePort = kvp.SourcePort,
                    DestinationPort = kvp.DestinationPort,
                    Packets = kvp.Packets
                });
            }
            private set { }
        }

        public TcpSessionsBuilder()
        {
            _sessions = new List<TcpSession>();
            completedSessions = new List<TcpSession>();
        }

        public void HandlePacket(TcpPacket tcpPacket)
        {

            var currentSession = new TcpSession()
            {
                SentTime = tcpPacket.SentTime,
                SourceIp = tcpPacket.SourceIp.ToString(),
                SourcePort = tcpPacket.SourcePort,
                DestinationIp = tcpPacket.DestinationIp.ToString(),
                DestinationPort = tcpPacket.DestinationPort
            };
            
            if (!_sessions.AsParallel().Contains(currentSession))
            {
                _sessions.Add(currentSession);
            }
            _indexOfCurrentSession = _sessions.FindIndex(session => currentSession.Equals(session));
            _sessions[_indexOfCurrentSession].Packets.Add(tcpPacket);

            if (tcpPacket.Flag == 17 || tcpPacket.Flag == 1)
            {
                foreach (var currentTcpPacket in _sessions[_indexOfCurrentSession].Packets)
                {

                    currentSession.Packets.Add(new TcpPacket()
                    {
                        SourceIp = currentTcpPacket.SourceIp,
                        SourcePort = currentTcpPacket.SourcePort,
                        DestinationIp = currentTcpPacket.DestinationIp,
                        DestinationPort = currentTcpPacket.DestinationPort,
                        Data = currentTcpPacket.Data,
                        SentTime = currentTcpPacket.SentTime,
                        Flag = tcpPacket.Flag
                    });
                }
                completedSessions.Add(currentSession);
                _sessions.Remove(currentSession);               
            }
        }

        public void Clear()
        {
            _sessions.Clear();
        }
    }

}