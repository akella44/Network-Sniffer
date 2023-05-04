﻿using SharpPcap;
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

namespace Shell
{
    public partial class PacketMonitoring : Form
    {
        private PacketsProcces _snif;
        private CancellationTokenSource _cts;
        private Task _sniffing;
        private List<NetworkPacket> PacketsView;

        /*private CsvTempWriter _statProcessor;*/
        public PacketMonitoring(ILiveDevice device)
        {
            _cts = new CancellationTokenSource();
            var _ct = _cts.Token;

            InitializeComponent();
            packetDataGrid.VirtualMode = true;
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(packetDataGrid, true, null);

            _snif = new PacketsProcces(device);
            _snif.StartSniff();

            sessionsToolStripMenuItem.DropDown.Closing += checkedItems_MenuUnclosing;
            paketsToolStripMenuItem.DropDown.Closing += checkedItems_MenuUnclosing;
            /*PathTextBox.Text = _statProcessor.FileName;*/

            PacketsView = new List<NetworkPacket>();
            packetDataGrid.CellValueNeeded += dgv_CellValueNeeded;

            Application.Idle += PacketGridInvalidate;
            
            _snif._tcpHandler.TcpPacketArived += AddTcpPacketToList;
            _snif._udpHandler.UdpPacketArived += AddUdpPacketToList;

            _snif._udpHandler.UdpSessionArrived += UdpSessionNotify;

            startButton.Visible = false;
            startButton.Click += strartButton_OnClick;
            stopButton.Click += stopButton_OnClick;

            udpToolStripMenuItem.ShowDropDown();

            ToolTip startToolTip = new ToolTip();
            startToolTip.SetToolTip(startButton, "Начать захват");
            ToolTip stopToolTip = new ToolTip();
            startToolTip.SetToolTip(stopButton, "Приостановить захват");
        }

        private void checkedItems_MenuUnclosing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }
        private void UdpSessionNotify(object sender, UdpStreamArivedEventArgs e)
        {
            MessageBox.Show("UdpSessionArrivedEvent");
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
            if (ScrollDown.Checked)
            {
                packetDataGrid.FirstDisplayedScrollingRowIndex = packetDataGrid.RowCount - 1;
            }

        }

        private void udpToolStripMenuItem_ChekedChanged(object sender, EventArgs e)
        {
            CsvTempWriter<UdpSession, UdpStreamArivedEventArgs> udpSessionCsv = new CsvTempWriter<UdpSession, UdpStreamArivedEventArgs>();
            if (udpToolStripMenuItem.Checked)
            {
                udpSessionCsv.InitTempFile();
                _snif._udpHandler.UdpSessionArrived += udpSessionCsv.AddObjToTempCsvFile;
            }
            else
            {
                _snif._udpHandler.UdpSessionArrived -= udpSessionCsv.AddObjToTempCsvFile;
                udpSessionCsv.Dispose();
            }
        }
        
        
        private void PacketMonitoring_Load(object sender, EventArgs e)
        {

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void formOfCaptureDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statisticsMenu_Click(object sender, EventArgs e)
        {

        }

        private void udpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
