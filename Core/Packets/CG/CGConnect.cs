using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class CGConnect : Packet
    {
        public uint TimeStamp;

        public int AuthKey;

        public PCType PCType;

        public string PCName;

        public PhysicalAddress MacAddress;

        public CGConnect(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);

            // read packet id
            this.ID = (PacketID)ReadUInt16(stream);

            // read size
            this.BodySize = ReadUInt32(stream);

            // read timestamp
            this.TimeStamp = ReadUInt32(stream);

            // check packet id
            if (this.ID == PacketID.CGConnect)
            {
                // read authkey
                this.AuthKey = ReadInt32(stream);

                // read PCType
                this.PCType = (PCType)stream.ReadByte();

                // read szPCName
                this.PCName = ReadString(stream);

                // read MacAddress
                this.MacAddress = ReadMacAddress(stream);

                _binit = true;
            }
        }

        public override void Write(ref NetworkStream stream)
        {

        }
    }
}
