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
    public class CLLogin : Packet
    {
        public uint TimeStamp;

        public uint unkuint; // ??
        public ushort unkushort; // probably real id of packet.
        public uint unkuint2; // probably real size of packet.
        public uint unkuint3; // another timestamp.

        public string UserID;

        public string Password;

        public PhysicalAddress MacAddress;

        public byte LoginMode;

        public IPAddress IPAddress;

        public CLLogin(Stream stream)
        {
            // read size
            this.BodySize = ReadUInt32(stream);

            // read timestamp
            this.TimeStamp = ReadUInt32(stream);

            // read UserID
            this.UserID = ReadString(stream);

            // read Password
            this.Password = ReadString(stream);

            // read MacAddress
            this.MacAddress = ReadMacAddress(stream);

            // read LoginMode
            this.LoginMode = (byte)stream.ReadByte();

            // read RealIPAddress
            this.IPAddress = new IPAddress(ReadUInt32(stream));
        }

        public override void Write(ref NetworkStream stream)
        {

        }
    }
}
