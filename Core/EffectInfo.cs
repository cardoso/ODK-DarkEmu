using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class EffectInfo
    {
        public struct Status
        {
            public ushort val1; // effectid
            public uint val2; // length
        }

        public List<Status> EList;

        public EffectInfo()
        {
            this.EList = new List<Status>();
        }

        public void Write(Stream stream)
        {
            // write EList
            stream.WriteByte((byte)this.EList.Count);

            for(int i = 0; i < EList.Count; i++)
            {
                stream.Write(BitConverter.GetBytes(EList[i].val1), 0, 2);
                stream.Write(BitConverter.GetBytes(EList[i].val2), 0, 4);
            }
        }
    }
}
