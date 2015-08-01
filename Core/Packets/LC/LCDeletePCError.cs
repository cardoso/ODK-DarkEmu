using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class LCDeletePCError : Packet
    {
        public ErrorID ErrorID;

        public LCDeletePCError()
        {
            this.ID = PacketID.LCDeletePCError;
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                // write id
                stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

                // write size
                stream.Write(BitConverter.GetBytes((uint)this.BodySize), 0, 4);

                // write errorid
                stream.WriteByte((byte)this.ErrorID);

                // copy stream to netstream
                stream.Position = 0;
                stream.CopyTo(netstream);
            }
        }
    }
}
