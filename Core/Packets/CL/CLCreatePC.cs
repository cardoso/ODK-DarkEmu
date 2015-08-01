using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class CLCreatePC : Packet
    {

        public uint TimeStamp;

        public string Name;

        public Slot Slot;

        public byte BitSet;

        public ushort ColorHair;
        public ushort ColorSkin;
        public ushort ColorShirt;
        public ushort ColorShirt2;
        public ushort ColorJeans;
        public ushort ColorJeans2;

        public ushort STR;
        public ushort DEX;
        public ushort INT;

        public PCType PCType;

        public CLCreatePC(Stream stream)
        {
            // read size
            this.BodySize = ReadUInt32(stream);

            // read timestamp
            this.TimeStamp = ReadUInt32(stream);

            // read Name
            this.Name = ReadString(stream);

            // read Slot
            this.Slot = (Slot)stream.ReadByte();

            // read BitSet
            this.BitSet = (byte)stream.ReadByte();

            // read Colors
            this.ColorHair = ReadUInt16(stream);
            this.ColorSkin = ReadUInt16(stream);
            this.ColorShirt = ReadUInt16(stream);
            this.ColorShirt2 = ReadUInt16(stream);
            this.ColorJeans = ReadUInt16(stream);
            this.ColorJeans2 = ReadUInt16(stream);

            // read STR DEX & INT
            this.STR = ReadUInt16(stream);
            this.DEX = ReadUInt16(stream);
            this.INT = ReadUInt16(stream);

            // read PCType
            this.PCType = (PCType)stream.ReadByte();
        }

        public Sex GetSex()
        {
            Sex result = Sex.FEMALE;

            byte _sex = (byte)(BitSet << 7);

            if (_sex != 0) result = Sex.MALE;

            return result;
        }

        public HairStyle GetHairStyle()
        {
            byte result = (byte)(this.BitSet >> 1);

            return (HairStyle)result;
        }

        public override void Write(ref NetworkStream stream)
        {

        }
    }
}
