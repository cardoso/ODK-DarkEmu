using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using Core;
using Database;
using System.Net;
using System.IO;

namespace LoginServer
{
    class LoginClient
    {
        NetworkStream netstream;

        Stopwatch timer;

        string UserID;
        int WorldID;

        public LoginClient(TcpClient client)
        {
            netstream = client.GetStream();
            //this.IPAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address;

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

            LoginServer.PlayerCount--;
            LConsole.WriteStatus("User '{0}' disconnected.", this.UserID);

            client.Close();
        }

        public void HandlePacket(byte[] packet)
        {
            //ushort id = BitConverter.ToUInt16(packet.Take(2).ToArray(), 0);

            //Console.WriteLine("[LoginServer] Time since last packet: {0}ms", timer.ElapsedMilliseconds);

            timer.Reset();

            using (Stream stream = new MemoryStream(packet))
            {
                while (stream.Length - stream.Position > 7)
                {
                    PacketID id = (PacketID)Packet.ReadUInt16(stream);

                    switch (id)
                    {
                        case PacketID.CLVersionCheck:
                            VersionCheck(new CLVersionCheck(stream));
                            break;
                        case PacketID.CLCreatePC:
                            CreatePC(new CLCreatePC(stream));
                            break;
                        case PacketID.CLDeletePC:
                            DeletePC(new CLDeletePC(stream));
                            break;
                        case PacketID.CLLogin:
                            Login(new CLLogin(stream));
                            break;
                        case PacketID.CLGetWorldList:
                            GetWorldList(new CLGetWorldList(stream));
                            break;
                        case PacketID.CLGetServerList:
                            GetServerList(new CLGetServerList(stream));
                            break;
                        case PacketID.CLGetPCList:
                        case PacketID.CLGetPCList2: // ??
                            GetPCList(new CLGetPCList(stream));
                            break;
                        case PacketID.CLQueryCharacterName:
                            QueryCharacterName(new CLQueryCharacterName(stream));
                            break;
                        case PacketID.CLSelectPC:
                            SelectPC(new CLSelectPC(stream));
                            break;
                        case PacketID.CLReconnectLogin:
                            ReconnectLogin(new CLReconnectLogin(stream));
                            break;
                    }
                }
            }
        }

        private void VersionCheck(CLVersionCheck packet)
        {
            Packet answer;

            if (packet.Version == 369)
            {
                answer = new LCVersionCheckOK();
            }
            else
            {
                answer = new LCVersionCheckError();
            }

            answer.Write(ref netstream);
        }

        public void Login(CLLogin packet)
        {
            Packet answer;

            int result = DBManager.CheckPlayerLogin(packet.UserID, packet.Password);

            if(result == 0) // LoginOK
            {
                answer = new LCLoginOK();

                answer.Write(ref netstream);

                LConsole.WriteStatus("User '{0}' logged in ", packet.UserID);

                this.UserID = packet.UserID;
            }
            else
            {
                answer = new LCLoginError();

                if(result == 1) // Wrong UserID or Password
                {
                    ((LCLoginError)answer).ErrorID = ErrorID.WrongUserOrPassword;

                    LConsole.WriteWarning("User '{0}' failed to log in with password '{1}'", packet.UserID, packet.Password);

                    answer.Write(ref netstream);
                }
                else if(result == 2) // Access Denied
                {
                    ((LCLoginError)answer).ErrorID = ErrorID.AccessDenied;

                    LConsole.WriteWarning("Banned user '{0}' tried to log in but was rejected.", packet.ID);
                }
            }

            answer.Write(ref netstream);
        }

        public void GetWorldList(CLGetWorldList packet)
        {
            LCWorldList answer = new LCWorldList();

            answer.WorldInfoList = LoginServer.WorldInfoList;
            answer.CurrentWorldID = 0;

            answer.Write(ref netstream);
        }

        public void GetServerList(CLGetServerList packet)
        {
            this.WorldID = packet.WorldID;

            LCServerList answer = new LCServerList();
            answer.CurrentServerGroupID = packet.WorldID;
            answer.ServerGroupInfoList = LoginServer.WorldInfoList[packet.WorldID].ServerGroupInfoList;

            answer.Write(ref netstream);
        }

        public void GetPCList(CLGetPCList packet)
        {
            LCPCList answer = new LCPCList();

            PCInfo[] pcinfo = DBManager.GetPCInfoList(this.UserID);

            answer.Slot1 = pcinfo[0];
            answer.Slot2 = pcinfo[1];
            answer.Slot3 = pcinfo[2];

            answer.Write(ref netstream);
        }

        public void CreatePC(CLCreatePC packet)
        {
            Packet answer;

            ErrorID dbres = ErrorID.None;

            if(packet.PCType == PCType.SLAYER)
            {
                dbres = DBManager.CreatePCSlayer(packet.Name, packet.GetSex(), packet.STR, packet.DEX, packet.INT,
                                                 packet.GetHairStyle(), packet.ColorHair, packet.ColorSkin);
            }
            else if(packet.PCType == PCType.VAMPIRE)
            {
                dbres = DBManager.CreatePCVampire(packet.Name, packet.GetSex(), packet.ColorSkin);
            }
            else if(packet.PCType == PCType.OUSTER)
            {
                dbres = DBManager.CreatePCOuster(packet.Name, packet.STR, packet.DEX, packet.INT, packet.ColorHair);
            }

            if(dbres == ErrorID.None)
            {
                DBManager.AssignPCToPlayer(this.UserID, packet.Name, packet.Slot);

                answer = new LCCreatePCOK();
            }
            else
            {
                answer = new LCCreatePCError();

                ((LCCreatePCError)(answer)).ErrorID = dbres;
            }

            answer.Write(ref netstream);

            LConsole.WriteStatus("Created PC with name '{0}', race '{1}', sex '{2}' and hairstyle '{3}'", packet.Name, packet.PCType, packet.GetSex(), packet.GetHairStyle());
        }

        public void DeletePC(CLDeletePC packet)
        {
            Packet answer;

            int dbres = DBManager.DeletePC(packet.Name, packet.Slot, packet.SSN);

            if(dbres == 1)
            {
                answer = new LCDeletePCOK();
            }
            else
            {
                answer = new LCDeletePCError();

                ((LCDeletePCError)answer).ErrorID = ErrorID.InvalidSSN;
            }

            answer.Write(ref netstream);
        }

        public void QueryCharacterName(CLQueryCharacterName packet)
        {
            bool bExists = DBManager.CheckPCExists(packet.Name);

            LCQueryResultCharacterName answer = new LCQueryResultCharacterName();//(packet.Name, bExists);

            answer.Name = packet.Name;
            answer.Exists = bExists;

            answer.Write(ref netstream);
        }

        public void SelectPC(CLSelectPC packet)
        {
            int authkey = LoginServer.GenerateAuthKey();

            LGIncomingConnection gsic = new LGIncomingConnection(this.UserID, packet.Name, /*this.IPAddress.ToString(),*/ authkey);

            gsic.Write(ref LoginServer.GameServerList[this.WorldID].netstream);

            WorldInfo world = LoginServer.WorldInfoList[this.WorldID];

            LCReconnect answer = new LCReconnect();

            answer.GameServerIP = world.IPAddress;
            answer.GameServerPort = world.Port;
            answer.AuthKey = authkey;

            answer.Write(ref netstream);
        }

        public void ReconnectLogin(CLReconnectLogin packet)
        {
            LCPCList answer = new LCPCList();

            this.UserID = LoginServer.AuthPlayers[packet.AuthKey];

            PCInfo[] pcinfo = DBManager.GetPCInfoList(this.UserID);

            answer.Slot1 = pcinfo[0];
            answer.Slot2 = pcinfo[1];
            answer.Slot3 = pcinfo[2];

            LoginServer.AuthPlayers.Remove(packet.AuthKey);

            answer.Write(ref netstream);
        }
    }
}