using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class LCQueryResultCharacterName : Packet
    {
        public string Name;

        public bool Exists;

        public LCQueryResultCharacterName()
        {
            this.ID = PacketID.LCQueryResultCharacterName;
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                // write id
                stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

                // write temporary size
                stream.Write(BitConverter.GetBytes(0), 0, 4);

                // store header size
                int headersize = (int)stream.Position;

                // write name
                stream.WriteByte((byte)this.Name.Length);
                stream.Write(Encoding.ASCII.GetBytes(this.Name), 0, this.Name.Length);

                // write exists
                stream.WriteByte(BitConverter.GetBytes(this.Exists)[0]);

                // go back and write body size
                this.BodySize = (uint)(stream.Length - headersize);

                stream.Position = 2;
                stream.Write(BitConverter.GetBytes(this.BodySize), 0, 4);

                // copy stream to netstream
                stream.Position = 0;
                stream.CopyTo(netstream);
            }
        }
    }
}
