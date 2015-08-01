using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class LCLoginOK : Packet
    {
        bool isAdult; // unused in dklegend client

        bool UnderFifteen; // unused in dklegend client

        bool Family;

        byte Status;

        ushort LastDay;

        byte PayType;

        public LCLoginOK()
        {
            this.ID = PacketID.LCLoginOK;
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                // write id
                stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

                // write body size
                stream.Write(BitConverter.GetBytes(0), 0, 4);

                // write isAdult
                stream.WriteByte(BitConverter.GetBytes(this.isAdult)[0]);

                // write UnderFifteen
                stream.WriteByte(BitConverter.GetBytes(this.UnderFifteen)[0]);

                // write Family
                stream.WriteByte(BitConverter.GetBytes(this.Family)[0]);

                // write Status
                stream.WriteByte(this.Status);

                // write LastDay
                stream.Write(BitConverter.GetBytes(this.LastDay), 0, 2);

                // write PayType
                stream.WriteByte(this.PayType);

                // copy stream to netstream
                stream.Position = 0;
                stream.CopyTo(netstream);
            }
        }
    }
}
