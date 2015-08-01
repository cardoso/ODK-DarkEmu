using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class CGReady : Packet
    {
        public uint TimeStamp;

        public CGReady(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);

            // read packet id
            this.ID = (PacketID)ReadUInt16(stream);

            // read size
            this.BodySize = ReadUInt32(stream);

            // read timestamp
            this.TimeStamp = ReadUInt32(stream);

            // check packet id
            if (this.ID == PacketID.CGReady)
            {
                _binit = true;
            }
        }

        public override void Write(ref NetworkStream stream)
        {

        }
    }
}
