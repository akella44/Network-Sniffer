using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTM;
using NTM.PacketsProcessor;
using Shell.NTM.NetworkProcessor.Event_Args;
using Shell.NTM.StatisticsCore;
using Shell.NTM.StatisticsCore.Event_Args;

namespace Shell.NTM.CommonUi
{
    public partial class SuspTrafficForm : Form
    {
        private PacketsProccesor _packetsProccesor;
        private PacketsPerSecondProcessor _packetsPerSecondProcessor;
        private List<string> _suspTrafficIps;
        private List<int> _suspTrafficCounts;
        public SuspTrafficForm(PacketsProccesor packetsProccesor)
        {
            InitializeComponent();
            suspTrafficGridView.VirtualMode = true;
            _packetsProccesor = packetsProccesor;

            _suspTrafficIps = new List<string>();
            _suspTrafficCounts = new List<int>();

            _packetsPerSecondProcessor = new PacketsPerSecondProcessor(100, packetsProccesor);
            _packetsPerSecondProcessor.StartCalculatePacketsPerSeconds();
            _packetsPerSecondProcessor.SuspTrafficDetected += _handleSuspTraffic;

            Application.Idle += suspTrafficGridInvalidate;
            suspTrafficGridView.CellValueNeeded += stg_CellValueNeeded;
            
        }

        private void suspTrafficGridInvalidate(object sender, EventArgs e)
        {
            suspTrafficGridView.RowCount = _suspTrafficIps.Count + 1;
            suspTrafficGridView.Invalidate();
            
        }
        private void stg_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _suspTrafficIps.Count) return;
            switch (e.ColumnIndex)
            {
                case 0: e.Value = _suspTrafficIps[e.RowIndex]; break;
                case 1: e.Value = _suspTrafficCounts[e.RowIndex]; break;
            }
        }
        private void _handleSuspTraffic(object sender, MoreThenTresholdDetectedEventArgs e)
        {
            _suspTrafficIps.Add(e.IpAdress);
            _suspTrafficCounts.Add(e.PacketsCountPerSecond);
        }

        private void SuspTrafficForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            _packetsPerSecondProcessor.StartCalculatePacketsPerSeconds();
        }

        public void Dispose()
        {
            _packetsPerSecondProcessor.StopCalculatePacketsPerSeconds();
        }
    }
}
