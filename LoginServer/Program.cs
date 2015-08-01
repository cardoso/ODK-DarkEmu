using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Database;

namespace LoginServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start DatabaseManager
            DBManager.Initialize();

            //Start LoginServer
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            LoginServer.Initialize(ip, 9909);
        }
    }
}
