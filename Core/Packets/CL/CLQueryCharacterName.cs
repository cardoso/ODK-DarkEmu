using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class CLQueryCharacterName : Packet
    {
        public uint TimeStamp;

        public string Name;

        public CLQueryCharacterName(Stream stream)
        {
            // read size
            this.BodySize = ReadUInt32(stream);

            // read timestamp
            this.TimeStamp = ReadUInt32(stream);

            // read name
            this.Name = ReadString(stream);

        }

        public override void Write(ref NetworkStream stream)
        {

        }
    }
}
