using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class WorldInfo
    {
        public byte   ID;
        public string Name;
        public byte   Status; // 0 = open | 1 = closed
        public string IPAddress;
        public uint    Port;

        public List<ServerGroupInfo> ServerGroupInfoList;

        public WorldInfo(byte id, string name, byte status, string ip, uint port)
        {
            this.ID        = id;
            this.Name      = name;
            this.Status    = status;
            this.IPAddress = ip;
            this.Port      = port;
        }
    }
}
