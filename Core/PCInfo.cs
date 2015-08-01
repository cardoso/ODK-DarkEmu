using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public abstract class PCInfo
    {
        public PCType PCType;

        public string Name;

        abstract public void Write(Stream stream);
    }
}
