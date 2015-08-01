using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using Core;
using Database;

namespace GameServer
{
    class GameClient
    {
        NetworkStream netstream;

        Stopwatch timer;

        string UserID;

        string PCName;

        public GameClient(TcpClient client)
        {
            netstream = client.GetStream();

            timer = new Stopwatch();

            byte[] message = new byte[4096];
            int msgsize = 0;

            while (true)
            {
                timer.Start();
                try { msgsize = netstream.Read(message, 0, 4096); }
                catch { break; } //socket error

                if (msgsize == 0)
                {

                    break; //client disconnected
                }

                //message received
                HandlePacket(message.Take(msgsize).ToArray());
            }

            GameServer.PlayerCount--;
            GConsole.WriteStatus("User '{0}' disconnected.", this.UserID);

            client.Close();
        }

        public void HandlePacket(byte[] packet)
        {
            ushort id = BitConverter.ToUInt16(packet.Take(2).ToArray(), 0);

            timer.Reset();

            switch ((PacketID)id)
            {
                case PacketID.CGLogout:
                    Logout(new CGLogout(packet));
                    break;
                case PacketID.CGSay:
                    Say(new CGSay(packet));
                    break;
                case PacketID.CGConnect:
                    Connect(new CGConnect(packet));
                    break;
                case PacketID.CGReady:
                    Ready(new CGReady(packet));
                    break;
            }
        }

        public void Logout(CGLogout packet)
        {
            int authkey = GameServer.GenerateAuthKey();

            GLIncomingConnection lsic = new GLIncomingConnection(this.UserID, authkey);

            lsic.Write(ref GameServer.LoginServer.netstream);

            GCReconnectLogin answer = new GCReconnectLogin(GameServer.IPAddressLogin.ToString(), (uint)GameServer.PortLogin, authkey);

            answer.Write(ref netstream);
        }

        public void Say(CGSay packet)
        {
            GConsole.WriteStatus("{0} says \"{1}\"", this.PCName, packet.Message);
        }

        public void Connect(CGConnect packet)
        {
            this.UserID = GameServer.AuthPlayers[packet.AuthKey];
            GameServer.AuthPlayers.Remove(packet.AuthKey);
            this.PCName = packet.PCName;

            GConsole.WriteStatus("Received CGConnectPacket: {0}:{1}:{2}", this.UserID, this.PCName, packet.AuthKey);

            PCSlayerInfo2 pc = DBManager.GetPCSlayerInfo2(packet.PCName);
            GCUpdateInfo answer = new GCUpdateInfo(pc);

            answer.Write(ref netstream);
        }

        public void Ready(CGReady packet)
        {
            GCSetPosition sp = new GCSetPosition(30, 22, 02);

            sp.Write(ref netstream);
        }
    }
}