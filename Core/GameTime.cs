using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class GameTime
    {
        public ushort Year;
        public byte Month;
        public byte Day;

        public byte Hour;
        public byte Minute;
        public byte Second;

        public GameTime()
        {
            var dt = DateTime.Now;

            this.Year = (ushort)dt.Year;
            this.Month = (byte)dt.Month;
            this.Day = (byte)dt.Day;

            this.Hour = (byte)dt.Hour;
            this.Minute = (byte)dt.Minute;
            this.Second = (byte)dt.Second;
        }

        public void Write(ref NetworkStream stream)
        {
            // write all
            stream.Write(BitConverter.GetBytes(this.Year), 0, 2);
            stream.WriteByte(this.Month);
            stream.WriteByte(this.Day);
            stream.WriteByte(this.Hour);
            stream.WriteByte(this.Minute);
            stream.WriteByte(this.Second);
        }
    }
}
