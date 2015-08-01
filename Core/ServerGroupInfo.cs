using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class ServerGroupInfo
    {
        public byte   ID;
        public string Name;
        public byte   Status = 0x0;
        public bool   PKDisabled = false;
        public ushort SlayerNum = 0;
        public ushort VampNum = 0;
        public ushort OusterNum = 0;

        public ServerGroupInfo(byte id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
