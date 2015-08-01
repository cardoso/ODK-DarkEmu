using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public abstract class Packet
    {
        public PacketID ID;
        
        protected uint BodySize = 0;

        protected byte[] _bytes;
        protected bool   _binit;

        abstract public void Write(ref NetworkStream stream);

        /*public void Send(NetworkStream ns)
        {
            byte[] res = this.GetBytes();
            ns.Write(res, 0, res.Length);
        }*/

        // Static (Helper) Methods

        static public uint ReadUInt32(Stream stream)
        {
            byte[] _uint = new byte[4];

            stream.Read(_uint, 0, _uint.Length);

            return BitConverter.ToUInt32(_uint, 0);
        }

        static public int ReadInt32(Stream stream)
        {
            byte[] _int = new byte[4];

            stream.Read(_int, 0, _int.Length);

            return BitConverter.ToInt32(_int, 0);
        }

        static public ushort ReadUInt16(Stream stream)
        {
            byte[] _ushort = new byte[2];

            stream.Read(_ushort, 0, _ushort.Length);

            return BitConverter.ToUInt16(_ushort, 0);
        }

        static public string ReadString(Stream stream)
        {
            byte _szstring = (byte)stream.ReadByte();

            byte[] _string = new byte[_szstring];

            stream.Read(_string, 0, _string.Length);

            return Encoding.ASCII.GetString(_string, 0, _string.Length);
        }

        static public PhysicalAddress ReadMacAddress(Stream stream)
        {
            byte[] _macaddress = new byte[6];

            for (int i = 0; i < _macaddress.Length; i++)
            {
                _macaddress[i] = (byte)stream.ReadByte();
            }

            return new PhysicalAddress(_macaddress);
        }
    }
}