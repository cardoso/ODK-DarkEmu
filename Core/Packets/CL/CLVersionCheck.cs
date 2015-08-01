using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class CLVersionCheck : Packet
    {
        public uint TimeStamp;

        public uint Version;

        public CLVersionCheck(Stream stream)
        {
            // read size
            this.BodySize = ReadUInt32(stream);

            // read timestamp
            this.TimeStamp = ReadUInt32(stream);

            // read Version
            this.Version = ReadUInt32(stream);
        }

        public override void Write(ref NetworkStream stream)
        {

        }
    }
}
