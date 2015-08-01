using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class BloodBibleSignInfo
    {
        public uint OpenCount;

        public List<ushort> SignList;

        public BloodBibleSignInfo()
        {
            OpenCount = 0;

            this.SignList = new List<ushort>();
        }

        public void Write(ref NetworkStream stream)
        {
            // write OpenCount
            stream.Write(BitConverter.GetBytes(this.OpenCount), 0, 4);

            // write SignList
            stream.WriteByte((byte)this.SignList.Count);

            foreach(ushort n in this.SignList)
            {
                stream.Write(BitConverter.GetBytes(n), 0, 2);
            }
        }
    }
}
