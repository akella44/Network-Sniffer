using NTM.Objects;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
        private Dictionary<string, string> filters;
        public ViewFiltersBuilder(string filterRequest)
        {
            FilterRequest = filterRequest;
            filterBlocks = FilterRequest.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private Dictionary<string, string> _initFiltersDictionary(NetworkPacket packet)
        {
            var filters = new Dictionary<string, string>()
            {
                { "DestinationPort", $"{packet.DestinationPort}" },
                { "SourcePort", $"{packet.SourcePort}" },
                { "DestinationIp", packet.DestinationIp },
                { "SourceIp", packet.SourceIp },
                { "Lenght", $"{packet.Data.Length}" },
                { "Protocol", packet.Protocol }
            };

            return filters;
        }
        public bool ValidatePacket(NetworkPacket packet)
        {
            bool flag = false;
            filters = _initFiltersDictionary(packet);

            foreach (var iter in filterBlocks)
            {
                var tempList = iter.Split(new char[] { ':' }).ToList();
                var subTempList = tempList[1].Split(new char[] { ',' }).ToList();

                if (subTempList.Count <= 1)
                {
                    if (filters[tempList[0]] != tempList[1])
                    {
                        return false;
                    }
                    flag = true;
                }
                else
                {
                    for (int i = 0; i < subTempList.Count; i++)
                    {
                        if (filters[tempList[0]] == subTempList[i])
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
            }
            return flag;
        }
    }
}
