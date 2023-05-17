using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTM.Objects
{
    public class TcpSession : NetworkSession<TcpPacket>
    {
        public override List<TcpPacket> Packets { get; set; }

        public int PacketCounter;
        public TcpSession()
        {
            this.Packets = new List<TcpPacket>();
            this.Protocol = "TCP";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TcpSession))
            {
                return false;
            }

            var session = obj as TcpSession;

            return (this.SourceIp == session.SourceIp &&
                    this.DestinationIp == session.DestinationIp &&
                    this.SourcePort == session.SourcePort &&
                    this.DestinationPort == session.DestinationPort) ||
                    (this.SourceIp == session.DestinationIp &&
                    this.DestinationIp == session.SourceIp &&
                    this.SourcePort == session.DestinationPort &&
                    this.DestinationPort == session.SourcePort);
        }

    }
}
