using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public bool FilesExists()
        {
            if(TcpPacketCsv.FileInfo.Exists | UdpPacketCsv.FileInfo.Exists | UdpSessionCsv.FileInfo.Exists | TcpSessionCsv.FileInfo.Exists)
            {
                return true;
            }
            return false;
        }
        public void SaveFiles(string filename)
        {
            if (UdpSessionCsv.FileInfo.Exists)
            {
                UdpSessionCsv.FileInfo.CopyTo(_comparePath(filename, "UdpSession"));
            }

            if (TcpSessionCsv.FileInfo.Exists)
            {
                TcpSessionCsv.FileInfo.CopyTo(_comparePath(filename, "TcpSession"));
            }

            if (TcpPacketCsv.FileInfo.Exists)
            {
                TcpPacketCsv.FileInfo.CopyTo(_comparePath(filename, "TcpPacket"));
            }

            if (UdpPacketCsv.FileInfo.Exists)
            {
                UdpPacketCsv.FileInfo.CopyTo(_comparePath(filename, "UdpPacket"));
            }
        }
        private string _comparePath(string path, string prefix)
        {
            return Path.Combine(Path.GetDirectoryName(path), prefix + Path.GetFileName(path));
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
