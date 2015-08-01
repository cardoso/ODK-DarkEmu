using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class LCLoginError : Packet
    {
        public ErrorID ErrorID;

        public LCLoginError()
        {
            this.ID = PacketID.LCLoginError;
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                // write id
                stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

                // write body size
                stream.Write(BitConverter.GetBytes(0), 0, 4);

                // write ErrorID
                stream.WriteByte((byte)this.ErrorID);

                // copy stream to netstream
                stream.Position = 0;
                stream.CopyTo(netstream);
            }
        }
    }
}
