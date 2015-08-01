using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class GCReconnectLogin : Packet
    {
        public string LoginServerIP;
        public uint LoginServerPort;

        public int AuthKey;

        public GCReconnectLogin(string loginip, uint loginport, int authkey)
        {
            this.ID = PacketID.GCReconnectLogin;
            this.BodySize = (uint)(1 + loginip.Length + 8);

            this.LoginServerIP = loginip;
            this.LoginServerPort = loginport;
            this.AuthKey = authkey;
        }

        public override void Write(ref NetworkStream stream)
        {
            // write id & size
            stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);
            stream.Write(BitConverter.GetBytes(this.BodySize), 0, 4);

            // write loginserverip
            stream.WriteByte((byte)this.LoginServerIP.Length);
            stream.Write(Encoding.ASCII.GetBytes(this.LoginServerIP), 0, this.LoginServerIP.Length);

            // write loginserverport
            stream.Write(BitConverter.GetBytes(this.LoginServerPort), 0, 4);

            // write authkey
            stream.Write(BitConverter.GetBytes(this.AuthKey), 0, 4);
        }
    }
}
