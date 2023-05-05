using SharpPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTM;
using PacketDotNet;
using NTM.Event_Args;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Drawing.Text;
using NTM.Objects;
using System.Windows.Markup;
using System.Runtime.Remoting.Contexts;
using System.Linq.Expressions;
using Shell.NTM.Statistics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
namespace Shell
{
    public partial class PacketMonitoring : Form
    {
        private PacketsProcces _snif;
        private CancellationTokenSource _cts;
        private Task _sniffing;
        private List<NetworkPacket> PacketsView;

        private TempCsvCore _csvProcessor;

        public PacketMonitoring(ILiveDevice device)
        {
            _cts = new CancellationTokenSource();
            var _ct = _cts.Token;

            InitializeComponent();
            packetDataGrid.VirtualMode = true;

            saveCsvFilesDialog1.DefaultExt = ".csv";
            
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(packetDataGrid, true, null);

            _snif = new PacketsProcces(device);
            _snif.StartSniff();

            _csvProcessor = new TempCsvCore();

            sessionsToolStripMenuItem.DropDown.Closing += checkedItems_MenuUnclosing;
            paketsToolStripMenuItem.DropDown.Closing += checkedItems_MenuUnclosing;
            
            PacketsView = new List<NetworkPacket>();
            packetDataGrid.CellValueNeeded += dgv_CellValueNeeded;

            Application.Idle += PacketGridInvalidate;
            
            _snif._tcpHandler.TcpPacketArived += AddTcpPacketToList;
            _snif._udpHandler.UdpPacketArived += AddUdpPacketToList;

            startButton.Visible = false;

            ToolTip startToolTip = new ToolTip();
            startToolTip.SetToolTip(startButton, "Начать захват");
            ToolTip stopToolTip = new ToolTip();
            startToolTip.SetToolTip(stopButton, "Приостановить захват");
            ToolTip scrollDownToolTip = new ToolTip();
            scrollDownToolTip.SetToolTip(scrollDown, "Проматывать бесконечно вниз");
        }

        private void checkedItems_MenuUnclosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }
        private void PacketGridInvalidate(object sender, EventArgs e)
        {
            packetDataGrid.RowCount = PacketsView.Count;
            packetDataGrid.Invalidate();
            Thread.Sleep(200);
        }
        private void AddTcpPacketToList(object sender, TcpPacketArivedEventArgs e)
        {
            if (e.Packet.Data.Length != 0)
            {
                PacketsView.Add(e.Packet);
            }
        }

        private void AddUdpPacketToList(object sender, UdpPacketArivedEventArgs e)
        {
            if (e.Packet.Data.Length != 0)
            {
                PacketsView.Add(e.Packet);
            }

        }
        private void dgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= PacketsView.Count) return;
            switch (e.ColumnIndex)
            {
                case 0: e.Value = e.RowIndex; break;
                case 1: e.Value = PacketsView[e.RowIndex].SourceIp; break;
                case 2: e.Value = PacketsView[e.RowIndex].SourcePort; break;
                case 3: e.Value = PacketsView[e.RowIndex].DestinationIp; break;
                case 4: e.Value = PacketsView[e.RowIndex].DestinationPort; break;
                case 5: e.Value = PacketsView[e.RowIndex].Protocol; break;
                case 6: e.Value = PacketsView[e.RowIndex].Data.Length; break;
            }
            if (scrollDown.Checked)
            {
                packetDataGrid.FirstDisplayedScrollingRowIndex = packetDataGrid.RowCount - 1;
            }
            
        }

        private void udpSessionToolStripMenuItem_ChekedChanged(object sender, EventArgs e)
        {
            if (udpSessionToolStripMenuItem.Checked)
            {
                _csvProcessor.UdpSessionCsv.InitTempFile();
                _snif._udpHandler.UdpSessionArrived += _csvProcessor.UdpSessionCsv.AddObjToTempCsvFile;
            }
            else
            {
                _snif._udpHandler.UdpSessionArrived -= _csvProcessor.UdpSessionCsv.AddObjToTempCsvFile;
                _csvProcessor.UdpSessionCsv.Dispose();
            }
        }

        private void tcpSessionToolStripMenuItem_ChekedChanged(object sender, EventArgs e)
        {
            if (tcpSessionToolStripMenuItem.Checked)
            {
                _csvProcessor.TcpSessionCsv.InitTempFile();
                _snif._tcpHandler.TcpSessionArrived += _csvProcessor.TcpSessionCsv.AddObjToTempCsvFile;
            }
            else
            {
                _snif._tcpHandler.TcpSessionArrived -= _csvProcessor.TcpSessionCsv.AddObjToTempCsvFile;
                _csvProcessor.TcpSessionCsv.Dispose();
            }
        }

        private void udpPacketToolStripMenuItem_ChekedChanged(object sender, EventArgs e)
        {
            if (udpPacketToolStripMenuItem.Checked)
            {
                _csvProcessor.UdpPacketCsv.InitTempFile();
                _snif._udpHandler.UdpPacketArived += _csvProcessor.UdpPacketCsv.AddObjToTempCsvFile;
            }
            else
            {
                _snif._udpHandler.UdpPacketArived -= _csvProcessor.UdpPacketCsv.AddObjToTempCsvFile;
                _csvProcessor.UdpPacketCsv.Dispose();
            }
        }

        private void tcpPacketToolStripMenuItem_ChekedChanged(object sender, EventArgs e)
        {
            if (tcpPacketToolStripMenuItem.Checked)
            {
                _csvProcessor.TcpPacketCsv.InitTempFile();
                _snif._tcpHandler.TcpPacketArived += _csvProcessor.TcpPacketCsv.AddObjToTempCsvFile;
            }
            else
            {
                _snif._tcpHandler.TcpPacketArived -= _csvProcessor.TcpPacketCsv.AddObjToTempCsvFile;
                _csvProcessor.TcpPacketCsv.Dispose();
            }
        }


        private void strartButton_OnClick(object sender, EventArgs e)
        {
            stopButton.Visible = true;
            startButton.Visible = false;
            PacketsView.Clear();
            _snif.StartSniff();
        }

        private void stopButton_OnClick(object sender, EventArgs e)
        {
            startButton.Visible = true;
            stopButton.Visible = false;
            _snif.StopPacketProcessing();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Close();
        }

        private void saveFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(_csvProcessor.UdpSessionCsv.FileName))
            {
                if (saveCsvFilesDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = saveCsvFilesDialog1.FileName;
                _csvProcessor.UdpSessionCsv.FileInfo.CopyTo(filename);
            }

            if (File.Exists(_csvProcessor.TcpSessionCsv.FileName))
            {
                if (saveCsvFilesDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = saveCsvFilesDialog1.FileName;
                _csvProcessor.TcpSessionCsv.FileInfo.CopyTo(filename);
            }

            if (File.Exists(_csvProcessor.TcpPacketCsv.FileName))
            {
                if (saveCsvFilesDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = saveCsvFilesDialog1.FileName;
                _csvProcessor.TcpPacketCsv.FileInfo.CopyTo(filename);
            }

            if (File.Exists(_csvProcessor.UdpPacketCsv.FileName))
            {
                if (saveCsvFilesDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = saveCsvFilesDialog1.FileName;
                _csvProcessor.UdpPacketCsv.FileInfo.CopyTo(filename);
            }
        }

    }
}
