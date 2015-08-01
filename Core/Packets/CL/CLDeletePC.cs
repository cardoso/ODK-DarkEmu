using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class CLDeletePC : Packet
    {
        public uint TimeStamp;

        public string Name;
        
        public Slot Slot;

        public string SSN;

        public CLDeletePC(Stream stream)
        {
            // read size
            this.BodySize = ReadUInt32(stream);

            // read timestamp
            this.TimeStamp = ReadUInt32(stream);

            // read name
            this.Name = ReadString(stream);

            // read Slot
            this.Slot = (Slot)stream.ReadByte();

            // read szSSN
            this.SSN = ReadString(stream);
        }

        public override void Write(ref NetworkStream stream)
        {

        }
    }
}
