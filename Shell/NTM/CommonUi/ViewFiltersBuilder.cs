using NTM.Objects;
using PacketDotNet;
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

        private List<string> _filterBlocks;

        public static Dictionary<string, string> Filters = new Dictionary<string, string>
        {
            { "ПортНазначения", "" },
            { "ПортИсточника", "" },
            { "IpНазначения", "" },
            { "IpИсточника", "" },
            { "Длина", "" },
            { "Протокол", "" }
        };
        public ViewFiltersBuilder(string filterRequest)
        {
            FilterRequest = filterRequest;
            _filterBlocks = FilterRequest.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
        }

        private void _setFiltersDictionaryValue(NetworkPacket packet)
        {
            Filters["ПортНазначения"] = $"{packet.DestinationPort}";
            Filters["ПортИсточника"] = $"{packet.SourcePort}";
            Filters["IpНазначения"] = packet.DestinationIp;
            Filters["IpИсточника"] = packet.SourceIp;
            Filters["Длина"] = $"{packet.Data.Length}";
            Filters["Протокол"] = packet.Protocol;
        }
        public bool ValidatePacket(NetworkPacket packet)
        {
            bool flag = false;
            _setFiltersDictionaryValue(packet);

            foreach (var iter in _filterBlocks)
            {
                var tempList = iter.Split(new char[] { ':' }).ToList();
                var subTempList = tempList[1].Split(new char[] { ',' }).ToList();

                if (subTempList.Count <= 1)
                {
                    if (Filters[tempList[0]] != tempList[1])
                    {
                        return false;
                    }
                    flag = true;
                }
                else
                {
                    for (int i = 0; i < subTempList.Count; i++)
                    {
                        if (Filters[tempList[0]] == subTempList[i])
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
