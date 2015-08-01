using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class CLGetServerList : Packet
    {
        public uint TimeStamp;

        public byte WorldID;

        public CLGetServerList(Stream stream)
        {
            // read size
            this.BodySize = ReadUInt32(stream);

            // read timestamp
            this.TimeStamp = ReadUInt32(stream);

            // read world id
            this.WorldID = (byte)(stream.ReadByte() - 1); // -1 to fix array logic.
        }

        public override void Write(ref NetworkStream stream)
        {

        }
    }
}
