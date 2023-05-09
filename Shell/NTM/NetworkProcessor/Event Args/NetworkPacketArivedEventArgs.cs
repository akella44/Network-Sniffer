using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTM.Objects;
namespace Shell.NTM.NetworkProcessor.Event_Args
{
    public class NetworkPacketArivedEventArgs : EventArgs
    {
        public NetworkPacket Packet { set; get; }
    }
}
