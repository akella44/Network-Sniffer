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
using Shell.NTM.NetworkProcessor.Event_Args;

namespace Shell
{
    public partial class PacketMonitoring : Form
    {
        private PacketsProcces _sniffer;
        private CancellationTokenSource _cts;
        private Task _sniffing;
        private List<NetworkPacket> _packetsView;

        private ViewFiltersBuilder _filters;
        private TempCsvCore _csvProcessor;

        public PacketMonitoring(ILiveDevice device)
        {
            _filters = null;

            _cts = new CancellationTokenSource();
            var _ct = _cts.Token;

            InitializeComponent();
            packetDataGrid.VirtualMode = true;

            saveCsvFilesDialog1.DefaultExt = ".csv";
            
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(packetDataGrid, true, null);
            packetDataGrid.ReadOnly = true;

            _sniffer = new PacketsProcces(device);
            _sniffer.StartSniff();

            _csvProcessor = new TempCsvCore();

            sessionsToolStripMenuItem.DropDown.Closing += checkedItems_MenuUnclosing;
            paketsToolStripMenuItem.DropDown.Closing += checkedItems_MenuUnclosing;
            
            _packetsView = new List<NetworkPacket>();
            packetDataGrid.CellValueNeeded += dgv_CellValueNeeded;

            Application.Idle += PacketGridInvalidate;

            _sniffer.NetworkPacketArived += AddNetworkPacketToViewList;

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
            packetDataGrid.RowCount = _packetsView.Count;
            packetDataGrid.Invalidate();
            Thread.Sleep(200);
        }

        private void AddNetworkPacketToViewList(object sender, NetworkPacketArivedEventArgs e)
        {
            if (e.Packet.Data.Length != 0)
            {
                if (_filters != null)
                {
                    if (_filters.ValidatePacket(e.Packet))
                        _packetsView.Add(e.Packet);
                }
                else
                {
                    _packetsView.Add(e.Packet);
                }   
            }
        }

        private void dgv_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _packetsView.Count) return;
            switch (e.ColumnIndex)
            {
                case 0: e.Value = e.RowIndex; break;
                case 1: e.Value = _packetsView[e.RowIndex].SourceIp; break;
                case 2: e.Value = _packetsView[e.RowIndex].SourcePort; break;
                case 3: e.Value = _packetsView[e.RowIndex].DestinationIp; break;
                case 4: e.Value = _packetsView[e.RowIndex].DestinationPort; break;
                case 5: e.Value = _packetsView[e.RowIndex].Protocol; break;
                case 6: e.Value = _packetsView[e.RowIndex].Data.Length; break;
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
                _sniffer.UdpSessionArrived += _csvProcessor.UdpSessionCsv.AddObjToTempCsvFile;
            }
            else
            {
                _sniffer.UdpSessionArrived -= _csvProcessor.UdpSessionCsv.AddObjToTempCsvFile;
                _csvProcessor.UdpSessionCsv.Dispose();
            }
        }

        private void tcpSessionToolStripMenuItem_ChekedChanged(object sender, EventArgs e)
        {
            if (tcpSessionToolStripMenuItem.Checked)
            {
                _csvProcessor.TcpSessionCsv.InitTempFile();
                _sniffer.TcpSessionArrived += _csvProcessor.TcpSessionCsv.AddObjToTempCsvFile;
            }
            else
            {
                _sniffer.TcpSessionArrived -= _csvProcessor.TcpSessionCsv.AddObjToTempCsvFile;
                _csvProcessor.TcpSessionCsv.Dispose();
            }
        }

        private void udpPacketToolStripMenuItem_ChekedChanged(object sender, EventArgs e)
        {
            if (udpPacketToolStripMenuItem.Checked)
            {
                _csvProcessor.UdpPacketCsv.InitTempFile();
                _sniffer.UdpPacketArived += _csvProcessor.UdpPacketCsv.AddObjToTempCsvFile;
            }
            else
            {
                _sniffer.UdpPacketArived -= _csvProcessor.UdpPacketCsv.AddObjToTempCsvFile;
                _csvProcessor.UdpPacketCsv.Dispose();
            }
        }

        private void tcpPacketToolStripMenuItem_ChekedChanged(object sender, EventArgs e)
        {
            if (tcpPacketToolStripMenuItem.Checked)
            {
                _csvProcessor.TcpPacketCsv.InitTempFile();
                _sniffer.TcpPacketArived += _csvProcessor.TcpPacketCsv.AddObjToTempCsvFile;
            }
            else
            {
                _sniffer.TcpPacketArived -= _csvProcessor.TcpPacketCsv.AddObjToTempCsvFile;
                _csvProcessor.TcpPacketCsv.Dispose();
            }
        }


        private async void strartButton_OnClick(object sender, EventArgs e)
        {
            stopButton.Visible = true;
            startButton.Visible = false;
            _packetsView.Clear();
            await _sniffer.StartSniff();
        }

        private void stopButton_OnClick(object sender, EventArgs e)
        {
            startButton.Visible = true;
            stopButton.Visible = false;
            _sniffer.StopPacketProcessing();
        }

        private void saveFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sniffer.StopPacketProcessing();
            startButton.Visible = true;
            stopButton.Visible = false;

            if (_csvProcessor.FilesExists())
            {
                if (saveCsvFilesDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                string filename = saveCsvFilesDialog1.FileName;
                _csvProcessor.SaveFiles(filename);
            }
            else
            {
                MessageBox.Show("Csv файлов для сохранения не найдено");
            }
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (filterTextBox.Text.Length > 0)
            {
                _filters = new ViewFiltersBuilder(filterTextBox.Text);
            }
            else
            {
                _filters = null;
            }
        }

        private void PacketMonitoring_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sniffer.StopPacketProcessing();
            _packetsView.Clear();
            _csvProcessor.Dispose();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            string filters = "Доступные фильрты:";
            filters += Environment.NewLine;
            foreach(var obj in ViewFiltersBuilder.Filters.Keys)
            {
                filters += obj;
                filters += Environment.NewLine;
            } 
            MessageBox.Show(filters);
        }
    }
}
