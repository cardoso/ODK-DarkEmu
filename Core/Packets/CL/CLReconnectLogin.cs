using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class CLReconnectLogin : Packet
    {
        public uint TimeStamp;

        public int AuthKey;

        public byte LoginMode;

        public CLReconnectLogin(Stream stream)
        {
            // read size
            this.BodySize = ReadUInt32(stream);

            // read timestamp
            this.TimeStamp = ReadUInt32(stream);

            // read AuthKey
            this.AuthKey = ReadInt32(stream);

            // read LoginMode
            this.LoginMode = (byte)stream.ReadByte();
        }

        public override void Write(ref NetworkStream stream)
        {

        }
    }
}
