using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using Core;
using Database;
using System.Net;

namespace LoginServer
{
    public class LoginGSClient
    {
        public NetworkStream netstream;

        public LoginGSClient(TcpClient client)
        {
            LoginServer.GameServerList.Add(this);

            netstream = client.GetStream();

            byte[] message = new byte[4096];
            int msgsize = 0;

            while (true)
            {
                try { msgsize = netstream.Read(message, 0, 4096); }
                catch { break; } //socket error

                if (msgsize == 0)
                {
                    LConsole.WriteError("Lost connection to gameserver.");
                    break; // lost connection to gameserver.
                }

                //message received
                HandlePacket(message.Take(msgsize).ToArray());
            }

            LConsole.WriteError("Lost connection to gameserver.");

            client.Close();
        }

        public void HandlePacket(byte[] packet)
        {
            ushort id = BitConverter.ToUInt16(packet.Take(2).ToArray(), 0);

            switch ((PacketID)id)
            {
                case PacketID.GLIncomingConnection:
                    IncomingConnection(new GLIncomingConnection(packet));
                    break;
            }
        }

        public void IncomingConnection(GLIncomingConnection packet)
        {
            LConsole.WriteStatus("Received GLIncomingConnection {0}:{1}", packet.UserID, packet.AuthKey);
            LoginServer.AuthPlayers.Add(packet.AuthKey, packet.UserID);
        }
    }
}