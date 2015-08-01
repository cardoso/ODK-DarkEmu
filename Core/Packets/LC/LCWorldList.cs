using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class LCWorldList : Packet
    {
        public byte            CurrentWorldID;
        public List<WorldInfo> WorldInfoList;
        public LCWorldList()
        {
            this.ID = PacketID.LCWorldList;
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                /// write header ///

                // write id
                stream.Write(BitConverter.GetBytes((uint)this.ID), 0, 2);

                // write temporary size
                stream.Write(BitConverter.GetBytes(0), 0, 4);

                // write CurrentWorldID
                stream.WriteByte(this.CurrentWorldID);

                // write WorldInfoListCount
                stream.WriteByte((byte)this.WorldInfoList.Count);

                // store header size
                uint headersize = (uint)stream.Position;
                
                /// write body ///

                // write WorldInfoList
                foreach (WorldInfo w in WorldInfoList)
                {
                    stream.WriteByte((byte)(w.ID + 1)); // +1 fix for array logic
                    stream.WriteByte((byte)w.Name.Length);

                    byte[] _name = Encoding.ASCII.GetBytes(w.Name);
                    stream.Write(_name, 0, _name.Length);

                    stream.WriteByte(w.Status);
                }

                /// final touches ///

                // go back and write body size
                this.BodySize = (uint)(stream.Position - headersize);
                byte[] _bdysize = BitConverter.GetBytes(this.BodySize);

                stream.Position = 2;
                stream.Write(_bdysize, 0, _bdysize.Length);

                // write memorystream to networkstream
                stream.Position = 0;
                stream.CopyTo(netstream, (int)stream.Length);
            }
        }
    }
}
