using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using Core;
using Database;
using System.Net;

namespace GameServer
{
    public class GameLSClient
    {
        public NetworkStream netstream;

        public GameLSClient(TcpClient client)
        {
            GameServer.LoginServer = this;

            netstream = client.GetStream();

            byte[] message = new byte[4096];
            int msgsize = 0;

            while (true)
            {
                try { msgsize = netstream.Read(message, 0, 4096); }
                catch { break; } //socket error

                if (msgsize == 0)
                {
                    break; // lost connection to login server
                }

                //message received
                HandlePacket(message.Take(msgsize).ToArray());
            }

            GConsole.WriteError("Lost connection to loginserver.");

            client.Close();
        }

        public void HandlePacket(byte[] packet)
        {
            ushort id = BitConverter.ToUInt16(packet.Take(2).ToArray(), 0);

            switch ((PacketID)id)
            {
                case PacketID.LGIncomingConnection:
                    IncomingConnection(new LGIncomingConnection(packet));
                    break;
            }
        }

        public void IncomingConnection(LGIncomingConnection packet)
        {
            GameServer.AuthPlayers.Add(packet.AuthKey, packet.UserID);

            GConsole.WriteStatus("Received LGIncomingConnection: {0}:{1}:{2}", packet.UserID, packet.PCName, packet.AuthKey);
        }
    }
}