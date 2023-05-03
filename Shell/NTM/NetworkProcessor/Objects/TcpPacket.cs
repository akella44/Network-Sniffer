using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NTM.Objects
{
    public class TcpPacket : NetworkPacket
    {
        public ushort Flag;
    }
}
