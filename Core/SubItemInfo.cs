using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class SubItemInfo
    {
        public uint ObjectID;

        public byte Class;

        public ushort Type;

        public byte Count;

        public byte SlotID;

        public SubItemInfo()
        {

        }

        public void Write(Stream stream)
        {
            
        }
    }
}
