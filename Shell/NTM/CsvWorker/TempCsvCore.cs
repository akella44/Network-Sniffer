using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NTM.Event_Args;
using NTM.Objects;
namespace Shell.NTM.Statistics
{
    public class TempCsvCore
    {
        public CsvTempWriter<UdpSession, UdpStreamArivedEventArgs> UdpSessionCsv;
        public CsvTempWriter<UdpPacket, UdpPacketArivedEventArgs> UdpPacketCsv;
        public CsvTempWriter<TcpPacket, TcpPacketArivedEventArgs> TcpPacketCsv;
        public CsvTempWriter<TcpSession, TcpSessionArivedEventArgs> TcpSessionCsv;

        public TempCsvCore() 
        {
            UdpSessionCsv = new CsvTempWriter<UdpSession, UdpStreamArivedEventArgs>();
            UdpPacketCsv = new CsvTempWriter<UdpPacket, UdpPacketArivedEventArgs>();
            TcpPacketCsv = new CsvTempWriter<TcpPacket, TcpPacketArivedEventArgs>();
            TcpSessionCsv = new CsvTempWriter<TcpSession, TcpSessionArivedEventArgs>();
        }

        public void Dispose()
        {
            UdpSessionCsv.Dispose();
            UdpPacketCsv.Dispose();
            TcpPacketCsv.Dispose();
            TcpSessionCsv.Dispose();
        }
    }
}
