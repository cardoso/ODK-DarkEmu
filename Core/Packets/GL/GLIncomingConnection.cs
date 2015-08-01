using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class GLIncomingConnection : Packet
    {
        public string UserID;
        public int AuthKey;

        public GLIncomingConnection(string userid, int authkey)
        {
            this.ID = PacketID.GLIncomingConnection;
            this.BodySize = (uint)(1 + userid.Length + 4);

            this.UserID = userid;
            this.AuthKey = authkey;
        }

        public GLIncomingConnection(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);

            // read packet id
            this.ID = (PacketID)ReadUInt16(stream);

            // read size
            this.BodySize = ReadUInt32(stream);

            if (this.ID == PacketID.GLIncomingConnection)
            {
                // read UserID
                this.UserID = ReadString(stream);

                // read AuthKey
                this.AuthKey = ReadInt32(stream);

                _binit = true;
            }
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                // write Packet ID
                stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

                // write Packet Size
                stream.Write(BitConverter.GetBytes(this.BodySize), 0, 4);

                // write UserID
                stream.WriteByte((byte)this.UserID.Length);
                stream.Write(Encoding.ASCII.GetBytes(this.UserID), 0, this.UserID.Length);

                // write AuthKey
                stream.Write(BitConverter.GetBytes(this.AuthKey), 0, 4);

                // copy stream to netstream
                stream.Position = 0;
                stream.CopyTo(netstream);
            }
        }
    }
}
