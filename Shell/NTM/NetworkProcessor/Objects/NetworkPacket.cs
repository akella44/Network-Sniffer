using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NTM.Objects
{
    public interface INetworkPacket
    {
         string SourceIp { get; set; }
         string DestinationIp { get; set; }
         int SourcePort { get; set; }
         int DestinationPort { get; set; }
         byte[] Data { get; set; }
         DateTime SentTime { get; set; }
         string Protocol { get; set; }
    }

    public abstract class NetworkPacket : INetworkPacket
    {
        public string SourceIp { get; set; }
        public string DestinationIp { get; set; }
        public int SourcePort { get; set; }
        public int DestinationPort { get; set; }
        public byte[] Data { get; set; }
        public DateTime SentTime { get; set; }
        public string Protocol { get; set; }
    }
}
