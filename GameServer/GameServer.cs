using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Core;
using Database;

namespace GameServer
{
    public static class GameServer
    {
        static TcpListener tcpListener;
        static Thread tListen;

        public static GameLSClient LoginServer;

        public static IPAddress IPAddressGame;
        public static int PortGame;
        public static IPAddress IPAddressLogin;
        public static int PortLogin;

        public static int PlayerCount = 0;

        public static Dictionary<int, string> AuthPlayers;

        public static void Initialize(IPAddress ip, int port, IPAddress loginip, int loginport)
        {
            IPAddressGame = ip;
            IPAddressLogin = loginip;
            PortLogin = loginport;
            PortGame = port;

            AuthPlayers = new Dictionary<int, string>();

            // Initialize DBManager
            DBManager.Initialize();

            // Initialize TCPListener
            tcpListener = new TcpListener(ip, port);

            // Connect to login server
            GConsole.WriteStatus("Connecting to LoginServer at {0}:{1}.", loginip, loginport);

            bool loop = true;
            while (loop)
            {
                try
                {
                    TcpClient tcpLSClient = new TcpClient(loginip.ToString(), loginport);
                    Thread tLSListen = new Thread(new ParameterizedThreadStart(HandleLSClient));
                    tLSListen.Start(tcpLSClient);

                    GConsole.WriteStatus("Connected to LoginServer.");

                    loop = false;
                }
                catch
                {
                    GConsole.WriteError("Failed connecting to LoginServer. Trying again in 5 seconds...");
                    Thread.Sleep(5000);
                }
            }
            
            // Listen for clients
            tListen = new Thread(new ThreadStart(ListenClients));
            tListen.Start();
        }

        private static void HandleLSClient(object client)
        {
            TcpClient tcpClient = (TcpClient)client;

            GameLSClient lsClient = new GameLSClient(tcpClient);
        }

        private static void ListenClients()
        {
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();

                PlayerCount++;

                Thread tClient = new Thread(new ParameterizedThreadStart(HandleClient));
                tClient.Start(client);
            }
        }

        private static void HandleClient(object client)
        {
            TcpClient tcpClient = (TcpClient)client;

            GameClient gameClient = new GameClient(tcpClient);
        }

        public static int GenerateAuthKey()
        {
            Random r = new Random();

            return r.Next(int.MinValue, int.MaxValue);
        }
    }
}
