using NTM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Shell
{
    public class ViewFiltersBuilder
    {
        public string FilterRequest;

        private List<string> filterBlocks;
        public ViewFiltersBuilder(string filterRequest)
        {
            FilterRequest = filterRequest;
            filterBlocks = FilterRequest.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public bool ValidatePacket(NetworkPacket packet)
        {
            var flag = false;
            foreach (var obj in filterBlocks)
            {
                var tempList = obj.Split(new char[] { ':' }).ToList();
                if (tempList[0] == "DestinationPort")
                {
                    flag = ($"{packet.DestinationPort}" == tempList[1]);
                }
                if (tempList[0] == "SourcePort")
                {
                    flag = ($"{packet.SourcePort}" == tempList[1]);
                }
                if (tempList[0] == "DestinationIp")
                {
                    flag = ("{packet.DestinationIp}" == tempList[1]);
                }
                if (tempList[0] == "SourceIp")
                {
                    flag = ($"{packet.SourceIp}" == tempList[1]);
                }
                if (tempList[0] == "Protocol")
                {
                    flag = (packet.Protocol == tempList[1]);
                }
                else
                {

                }
            }
            return flag;
        }
    }
}
