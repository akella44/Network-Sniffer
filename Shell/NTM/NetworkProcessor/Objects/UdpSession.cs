using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTM.Objects
{
    public class UdpSession : NetworkSession<UdpPacket>
    {
        public override List<UdpPacket> Packets { get; set; }

        public UdpSession()
        {
            this.Packets = new List<UdpPacket>();
            this.Protocol = "UDP";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is UdpSession))
            {
                return false;
            }

            var session = obj as UdpSession;

            return (this.SourceIp == session.SourceIp &&
                    this.DestinationIp == session.DestinationIp &&
                    this.SourcePort == session.SourcePort &&
                    this.DestinationPort == session.DestinationPort) ||
                    (this.SourceIp == session.DestinationIp &&
                    this.DestinationIp == session.SourceIp &&
                    this.SourcePort == session.DestinationPort &&
                    this.DestinationPort == session.SourcePort);
        }

        public override int GetHashCode()
        {
            return this.SourceIp.GetHashCode() ^
                   this.SourcePort.GetHashCode() ^
                   this.DestinationPort.GetHashCode() ^
                   this.DestinationIp.GetHashCode();
        }
    }
}
