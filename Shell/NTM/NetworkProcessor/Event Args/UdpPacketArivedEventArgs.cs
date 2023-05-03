using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTM.Objects;
namespace NTM.Event_Args
{
    public class UdpPacketArivedEventArgs : EventArgs
    {
        public UdpPacket Packet { get; set; }
    }
}
