using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginServer
{
    public static class LConsole
    {
        public static void WriteStatus(string msg, params object[] args)
        {
            Console.Write('[');
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Status");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("] {0}\n", String.Format(msg, args));
        }

        public static void WriteWarning(string msg, params object[] args)
        {
            Console.Write('[');
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Warn");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("] {0}\n", String.Format(msg, args));
        }

        public static void WriteError(string msg, params object[] args)
        {
            Console.Write('[');
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Error");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("] {0}\n", String.Format(msg, args));
        }
    }
}
