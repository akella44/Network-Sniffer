using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Shell
{
    public partial class NetDeviceSelect : Form
    {
        private CaptureDeviceList devices;
        public static ILiveDevice device;
        private int hoveredIndex = -1;
        private System.Windows.Forms.ToolTip DeviceDesToolTip = new System.Windows.Forms.ToolTip();
        public NetDeviceSelect()
        {
            InitializeComponent();
            devicesList.DoubleClick += DevicesList_DoubleClick;
            devicesList.MouseMove += DevicesList_MouseMove;
        }

        private void NetDeviceSelect_Load(object sender, EventArgs e)
        { 
            devices = CaptureDeviceList.Instance;
            for (int i = 0; i < devices.Count; i++)
            {
                devicesList.Items.Add(devices[i].Description);
            }
        }

        private void DevicesList_MouseMove(object sender, MouseEventArgs e)
        {
            int newHoveredIndex = devicesList.IndexFromPoint(e.Location);

            if (hoveredIndex != newHoveredIndex)
            {
                hoveredIndex = newHoveredIndex;

                if (hoveredIndex > -1)
                {
                    DeviceDesToolTip.Active = false;
                    DeviceDesToolTip.SetToolTip(devicesList, $"Имя {devices[hoveredIndex].Name} {Environment.NewLine}Mac адрес {devices[hoveredIndex].MacAddress} "/*.LinkType.ToString()*/);
                    DeviceDesToolTip.Active = true;
                }
            }
        }
        private void DevicesList_DoubleClick(object sender, EventArgs e)
        {
            device = devices[devicesList.SelectedIndex];
            PacketMonitoring packetMonitoring = new PacketMonitoring(device);
            Hide();
            packetMonitoring.Show();
        }

        private void DevicesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FAQButton_Click(object sender, EventArgs e)
        {
                MessageBox.Show("Выберите устройтсво, с которого будет считываться сетевой трафик.");
        }
    }
}
