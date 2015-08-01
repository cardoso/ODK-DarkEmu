using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {

            //Start GameServer
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPAddress loginip = IPAddress.Parse("127.0.0.1");
            GameServer.Initialize(ip, 9998, loginip, 9909);
        }
    }
}
