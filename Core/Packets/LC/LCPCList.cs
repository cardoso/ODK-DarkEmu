using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class LCPCList : Packet
    {
        #region slots
        private PCInfo _slot1;
        public PCInfo Slot1
        {
            get { return this._slot1; }
            set
            {
                if (value != null)
                {
                    switch (value.PCType)
                    {
                        case PCType.SLAYER:
                            _pctypes[0] = 'S';
                            break;
                        case PCType.VAMPIRE:
                            _pctypes[0] = 'V';
                            break;
                        case PCType.OUSTER:
                            _pctypes[0] = 'O';
                            break;
                    }
                }

                this._slot1 = value;
            }
        }

        private PCInfo _slot2;
        public PCInfo Slot2
        {
            get { return this._slot2; }
            set
            {
                if (value != null)
                {
                    switch (value.PCType)
                    {
                        case PCType.SLAYER:
                            _pctypes[1] = 'S';
                            break;
                        case PCType.VAMPIRE:
                            _pctypes[1] = 'V';
                            break;
                        case PCType.OUSTER:
                            _pctypes[1] = 'O';
                            break;
                    }
                }

                this._slot2 = value;
            }
        }

        private PCInfo _slot3;
        public PCInfo Slot3 
        {
            get { return this._slot3; }
            set 
            {
                if (value != null)
                {
                    switch (value.PCType)
                    {
                        case PCType.SLAYER:
                            _pctypes[2] = 'S';
                            break;
                        case PCType.VAMPIRE:
                            _pctypes[2] = 'V';
                            break;
                        case PCType.OUSTER:
                            _pctypes[2] = 'O';
                            break;
                    }
                }

                this._slot3 = value;
            }
        }

        char[] _pctypes = { '0', '0', '0' };
        #endregion

        public LCPCList()
        {
            this.ID = PacketID.LCPCList;
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                // write id
                stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

                // write temporary size
                stream.Write(BitConverter.GetBytes(0), 0, 4);

                // write pctypes
                stream.WriteByte((byte)_pctypes[0]);
                stream.WriteByte((byte)_pctypes[1]);
                stream.WriteByte((byte)_pctypes[2]);

                // store header size
                int headersize = (int)stream.Position;

                // write slots
                if (Slot1 != null)
                    Slot1.Write(stream);

                if (Slot2 != null)
                    Slot2.Write(stream);

                if (Slot3 != null)
                    Slot3.Write(stream);

                byte[] result = new byte[stream.Length];

                // go back and write body size
                this.BodySize = (uint)(stream.Length - headersize);

                stream.Position = 2;
                stream.Write(BitConverter.GetBytes(this.BodySize), 0, 4);

                // write memorystream to networkstream
                stream.Position = 0;
                stream.CopyTo(netstream);
            }
        }
    }
}
