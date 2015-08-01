using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class LCServerList : Packet
    {
        public byte                     CurrentServerGroupID;
        public List<ServerGroupInfo>    ServerGroupInfoList;

        public LCServerList()
        {
            this.ID = PacketID.LCServerList;
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                /// write header ///

                // write id
                stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

                // write temporary size
                stream.Write(BitConverter.GetBytes(0), 0, 4);

                // write CurrentServerGroupID
                stream.WriteByte(this.CurrentServerGroupID);

                // write ServerGroupInfoListCount
                stream.WriteByte((byte)this.ServerGroupInfoList.Count);

                // store header size
                uint headersize = (uint)stream.Position;

                /// write body ///

                // write ServerGroupInfoList
                foreach (ServerGroupInfo sgi in this.ServerGroupInfoList)
                {
                    stream.WriteByte(sgi.ID);
                    stream.WriteByte((byte)sgi.Name.Length);

                    byte[] _name = Encoding.ASCII.GetBytes(sgi.Name);

                    stream.Write(_name, 0, _name.Length);

                    stream.WriteByte(sgi.Status);
                    stream.WriteByte(BitConverter.GetBytes(sgi.PKDisabled)[0]);

                    byte[] _slayernum = BitConverter.GetBytes(sgi.SlayerNum);
                    byte[] _vampnum = BitConverter.GetBytes(sgi.VampNum);
                    byte[] _oustnum = BitConverter.GetBytes(sgi.OusterNum);

                    stream.Write(_slayernum, 0, _slayernum.Length);
                    stream.Write(_vampnum, 0, _vampnum.Length);
                    stream.Write(_oustnum, 0, _oustnum.Length);
                }

                /// final touches ///

                // go back and write body size
                this.BodySize = (uint)(stream.Length - headersize);

                stream.Position = 2;
                stream.Write(BitConverter.GetBytes(this.BodySize), 0, 4);

                // write memorystream to networkstream
                stream.Position = 0;
                stream.CopyTo(netstream);
            }
        }
    }
}
