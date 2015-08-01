using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class LCReconnect : Packet
    {
        public string GameServerIP;
        public uint GameServerPort;

        public int AuthKey;

        public LCReconnect()
        {
            this.ID = PacketID.LCReconnect;
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                // write id
                stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

                // write temporary size
                stream.Write(BitConverter.GetBytes(0), 0, 4);

                // store header size
                int headersize = (int)stream.Position;

                // write gameserverip
                stream.WriteByte((byte)this.GameServerIP.Length);
                stream.Write(Encoding.ASCII.GetBytes(this.GameServerIP), 0, this.GameServerIP.Length);

                // write gameserverport
                stream.Write(BitConverter.GetBytes(this.GameServerPort), 0, 4);

                // write authkey
                stream.Write(BitConverter.GetBytes(this.AuthKey), 0, 4);

                // go back and write body size
                this.BodySize = (uint)(stream.Length - headersize);

                stream.Position = 2;
                stream.Write(BitConverter.GetBytes(this.BodySize), 0, 4);

                // copy stream to netstream
                stream.Position = 0;
                stream.CopyTo(netstream);
            }
        }
    }
}
