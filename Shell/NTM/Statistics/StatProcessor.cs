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
using System.Threading;
namespace Shell.NTM.Statistics
{
    public class StatProcessor
    {
        private PacketsProcces _snif;
        public string FileName { get; private set; }
        public string FileName2 { get; private set; }
        public StatProcessor(PacketsProcces snif)
        {
            _snif = snif;

            FileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
            FileName2 = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";

            using (var StreamWriter = new StreamWriter(File.Open(FileName, FileMode.Append)))
            {
                using (var CsvWriter = new CsvWriter(StreamWriter, CultureInfo.InvariantCulture))
                {
                    CsvWriter.WriteHeader<NetworkSession<NetworkPacket>>();
                    CsvWriter.NextRecord();
                }
            }

            /*_snif._udpHandler.UdpPacketArived += AddUdpPacketToTempCsvFile;
            _snif._tcpHandler.TcpPacketArived += AddTcpPacketToTempCsvFile;*/
            _snif._udpHandler.UdpSessionArrived += AddUdpSessionToTempCsvFile;
            _snif._tcpHandler.TcpSessionArrived += AddTcpSessionToTempCsvFile;
        }

        public void AddUdpPacketToTempCsvFile(object sender, UdpPacketArivedEventArgs e)
        {
            writeToCsvFile(FileName, e);
        }

        public void AddTcpSessionToTempCsvFile(object sender, TcpSessionArivedEventArgs e)
        {
            writeToCsvFile(FileName, e);
        }
        public void AddTcpPacketToTempCsvFile(object sender, TcpPacketArivedEventArgs e)
        {
            writeToCsvFile(FileName, e);
        }

        public void AddUdpSessionToTempCsvFile(object sender, UdpStreamArivedEventArgs e)
        {
            writeToCsvFile(FileName2, e);
        }
        private void writeToCsvFile(string fileName, object data) 
        {
            try
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
            catch (Exception ex)
            {
                Thread.Sleep(10);
            }
        }
    }
}
