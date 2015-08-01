using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class NPCInfo
    {
        public string Name;
        public ushort ID;
        public ushort X;
        public ushort Y;

        public void Write(ref NetworkStream stream)
        {
            throw new NotImplementedException();
        }
    }
}
