using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class PCItemInfo
    {
        public uint ObjectID;

        public byte ItemClass;
        
        public ushort ItemType;

        public List<byte> OptionTypeList;

        public uint Durability;

        public ushort Silver;

        public int Grade;

        public byte EnchantLevel;

        public byte Count;

        public ushort MainColor;

        public List<SubItemInfo> SubItemInfoList;

        public List<byte> ThirdOptionTypeList;

        public byte ThirdEnchantType;

        public byte AddedInfo1;
        public byte AddedInfo2;

        public List<byte> MixOptionTypeList;


        public PCItemInfo()
        {
            this.ObjectID = 0;
            this.ItemClass = 0;
            this.ItemType = 0;

            this.OptionTypeList = new List<byte>();
            this.ThirdOptionTypeList = new List<byte>();
            this.MixOptionTypeList = new List<byte>();
            this.SubItemInfoList = new List<SubItemInfo>();

            this.Durability = 0;
            this.Silver = 0;
            this.Grade = 0;
            this.EnchantLevel = 0;
            this.Count = 0;
            this.MainColor = 0;
            this.ThirdEnchantType = 0;
            this.AddedInfo1 = 0;
            this.AddedInfo2 = 0;
        }

        public void Write(Stream stream)
        {
            // write ObjectID
            stream.Write(BitConverter.GetBytes(this.ObjectID), 0, 4);

            // write Class
            stream.WriteByte(this.ItemClass);

            // write ItemType
            stream.Write(BitConverter.GetBytes(this.ItemType), 0, 2);

            // write OptionTypeList
            stream.WriteByte((byte)this.OptionTypeList.Count);

            foreach (byte b in this.OptionTypeList)
                stream.WriteByte(b);

            // write Durability
            stream.Write(BitConverter.GetBytes(this.Durability), 0, 4);

            // write Silver
            stream.Write(BitConverter.GetBytes(this.Silver), 0, 2);

            // write Grade
            stream.Write(BitConverter.GetBytes(this.Grade), 0, 4);

            // write EnchantLevel
            stream.WriteByte(this.EnchantLevel);

            // write Count
            stream.WriteByte(this.Count);

            // write MainColor
            stream.Write(BitConverter.GetBytes(this.MainColor), 0, 2);

            // write SubItemInfoList
            stream.WriteByte((byte)this.SubItemInfoList.Count);

            foreach (SubItemInfo si in this.SubItemInfoList)
                si.Write(stream);

            // write ThirdOptionTypeList
            stream.WriteByte((byte)this.ThirdOptionTypeList.Count);

            foreach (byte b in this.ThirdOptionTypeList)
                stream.WriteByte(b);

            // write ThirdEnchantType
            stream.WriteByte(this.ThirdEnchantType);

            // write AddedInfo1 & AddedInfo2
            stream.WriteByte(this.AddedInfo1);
            stream.WriteByte(this.AddedInfo2);

            // write MixOptionTypeList
            stream.WriteByte((byte)this.MixOptionTypeList.Count);

            foreach (byte b in this.MixOptionTypeList)
                stream.WriteByte(b);

            // write Type
            /*byte[] bytes = new byte[] {0x35, 0x27, 0x00, 0x00, 0x22, 0x20, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00,
                                        0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00,
                                        0xFF, 0xFF, 0xFF, 0x00 };*/
        }
    }
}
