using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class InstanceDungeonInfo
    {
        public byte Index;
        public string Name;

        public InstanceDungeonInfo()
        {
            this.Index = 0;
            this.Name = "ha";
        }

        public void Write(ref NetworkStream stream)
        {
            // write Index
            stream.Write(BitConverter.GetBytes(this.Index), 0, 4);

            // write Name
            stream.WriteByte((byte)this.Name.Length);
            byte[] _name = Encoding.ASCII.GetBytes(this.Name);
            stream.Write(_name, 0, _name.Length);
        }
    }
}
