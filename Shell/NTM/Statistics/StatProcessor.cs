using NTM.Event_Args;
using NTM.Objects;
using NTM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
namespace Shell.NTM.Statistics
{
    public class StatProcessor
    {
        private PacketsProcces _snif;
        public string FileName { get; private set; }

        public StatProcessor(PacketsProcces snif)
        {
            _snif = snif;

            FileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";

            using (var StreamWriter = new StreamWriter(File.Open(FileName, FileMode.Append)))
            {
                using (var CsvWriter = new CsvWriter(StreamWriter, CultureInfo.InvariantCulture))
                {
                    CsvWriter.WriteHeader<TcpPacket>();
                    CsvWriter.NextRecord();
                }
            }

            _snif._udpHandler.UdpPacketArived += AddUdpPacketToTempCsvFile;
            _snif._tcpHandler.TcpPacketArived += AddTcpPacketToTempCsvFile;
        }

        public void AddUdpPacketToTempCsvFile(object sender, UdpPacketArivedEventArgs e)
        {
            writeToCsvFile(FileName, e);
        }

        public void AddTcpPacketToTempCsvFile(object sender, TcpPacketArivedEventArgs e)
        {
            writeToCsvFile(FileName, e);
        }

        private void writeToCsvFile(string fileName, object data) 
        {
            using (var StreamWriter = new StreamWriter(File.Open(fileName, FileMode.Append)))
            {
                using (var CsvWriter = new CsvWriter(StreamWriter, CultureInfo.InvariantCulture))
                {
                    CsvWriter.WriteRecord(data);
                    CsvWriter.NextRecord();
                }
            }
        }
    }
}
