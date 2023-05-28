using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.NTM.StatisticsCore.Event_Args
{
    public class MoreThenTresholdDetectedEventArgs : EventArgs
    {
        public string IpAdress;
        public int PacketsCountPerSecond;
    }
}
