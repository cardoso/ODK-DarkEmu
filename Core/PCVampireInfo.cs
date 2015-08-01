using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    /*enum VampireBits
    {
        VAMPIRE_BIT_COAT1,
        VAMPIRE_BIT_COAT2,
        VAMPIRE_BIT_COAT3,
        VAMPIRE_BIT_MAX
    }

    enum VampireColors
    {
        VAMPIRE_COLOR_COAT,
        //2007 05 16
        VAMPIRE_COLOR_ARM,
        VAMPIRE_COLOR_MAX
    }*/
    public class PCVampireInfo : PCInfo
    {
        public Slot Slot;

        public int Alignment;

        public Sex Sex;

        public ushort BatColor;
        public ushort SkinColor;

        public ushort CoatType;
        public ushort CoatColor;

        public byte Rank;

        public byte Level;

        public ushort STR;
        public ushort DEX;
        public ushort INT;

        public ushort HP;
        public ushort MaxHP;

        public uint Exp;

        public VampireArmType ArmType;
        public ushort ArmColor;

        public uint Fame;

        public ushort Bonus;

        public byte AdvancementLevel;


        public PCVampireInfo()
        {
            this.PCType = PCType.VAMPIRE;
        }

        override public void Write(Stream stream)
        {
            // Write Name
            stream.WriteByte((byte)this.Name.Length);
            stream.Write(Encoding.ASCII.GetBytes(this.Name), 0, this.Name.Length);

            // Write Slot
            stream.WriteByte((byte)this.Slot);

            // Write Alignment
            stream.Write(BitConverter.GetBytes(this.Alignment), 0, 4);

            // Write Sex
            stream.WriteByte((byte)this.Sex);

            // Write Colors
            stream.Write(BitConverter.GetBytes(this.BatColor), 0, 2);
            stream.Write(BitConverter.GetBytes(this.SkinColor), 0, 2);

            // Write Shape
            byte coattype = 0;
            coattype = (byte)(((ushort)this.ArmType << 4) | this.CoatType);
            stream.WriteByte(coattype);
            stream.Write(BitConverter.GetBytes(this.CoatColor), 0, 2);

            // Write STR DEX & INT
            stream.Write(BitConverter.GetBytes(this.STR), 0, 2);
            stream.Write(BitConverter.GetBytes(this.DEX), 0, 2);
            stream.Write(BitConverter.GetBytes(this.INT), 0, 2);

            // Write HP
            stream.Write(BitConverter.GetBytes(this.HP), 0, 2);
            stream.Write(BitConverter.GetBytes(this.MaxHP), 0, 2);

            // Write Level Rank & Exp
            stream.WriteByte(this.Level);
            stream.WriteByte(this.Rank);
            stream.Write(BitConverter.GetBytes(this.Exp), 0, 4);

            // Write Fame
            stream.Write(BitConverter.GetBytes(this.Fame), 0, 4);

            // Write Bonus Point
            stream.Write(BitConverter.GetBytes(this.Bonus), 0, 2);

            // Write Advancement Level
            stream.WriteByte(this.AdvancementLevel);

            // Write ArmColor
            stream.Write(BitConverter.GetBytes(this.ArmColor), 0, 2);
        }
    }
}
