using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Core;
using Database;

namespace LoginServer
{
    public static class LoginServer
    {
        static TcpListener tcpListener;
        static Thread      tListen;

        public static IPAddress IPAddressLogin;

        public static int PlayerCount = 0;

        public static List<WorldInfo> WorldInfoList;
        public static List<LoginGSClient> GameServerList;

        public static Dictionary<int, string> AuthPlayers;

        public static void Initialize(IPAddress ip, int port)
        {
            IPAddressLogin = ip;

            AuthPlayers = new Dictionary<int, string>();

            // Initialize TCPListener
            tcpListener = new TcpListener(ip, port);
            tcpListener.Start();

            // Initialize Worlds
            WorldInfoList = DBManager.GetWorldInfoList();
            LConsole.WriteStatus("Initializing {0} worlds.", WorldInfoList.Count);

            // Initialize ServerGroups
            GameServerList = new List<LoginGSClient>();

            foreach(WorldInfo w in WorldInfoList)
            {
                w.ServerGroupInfoList = DBManager.GetServerGroupInfoList(w.ID);

                LConsole.WriteStatus("Initializing world '{0}' with {1} server groups.", w.Name, w.ServerGroupInfoList.Count);
                LConsole.WriteStatus("Waiting for GameServer at '{0}'", w.IPAddress);

                bool loop = true;

                while (loop)
                {
                    TcpClient tcp = tcpListener.AcceptTcpClient();
                    
                    IPEndPoint endpoint = (tcp.Client.RemoteEndPoint as IPEndPoint);

                    if(endpoint.Address.ToString() == w.IPAddress)
                    {
                        Thread gsClient = new Thread(new ParameterizedThreadStart(HandleGSClient));
                        gsClient.Start(tcp);

                        loop = false;
                    }
                    else
                    {
                        LConsole.WriteWarning("Refusing connection from {0}:{1}, waiting for gameserver.", endpoint.Address, endpoint.Port);
                    }
                }

                LConsole.WriteStatus("Initialized world '{0}'", w.Name);
            }

            tListen = new Thread(new ThreadStart(ListenClients));
            tListen.Start();
        }

        private static void HandleGSClient(object client)
        {
            TcpClient tcpClient = (TcpClient)client;

            LoginGSClient loginGSClient = new LoginGSClient(tcpClient);
        }

        private static void ListenClients()
        {
            //tcpListener.Start();

            while(true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();

                Thread tClient = new Thread(new ParameterizedThreadStart(HandleClient));
                tClient.Start(client);
            }
        }

        private static void HandleClient(object client)
        {
            TcpClient tcpClient = (TcpClient)client;

            PlayerCount++;

            LoginClient loginClient = new LoginClient(tcpClient);
        }

        public static int GenerateAuthKey()
        {
            Random r = new Random();

            return r.Next(int.MinValue, int.MaxValue);
        }
    }
}
