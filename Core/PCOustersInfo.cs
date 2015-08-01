using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class PCOusterInfo : PCInfo
    {
        /*enum OustersColors
	    {
		    OUSTERS_COLOR_COAT,
		    OUSTERS_COLOR_HAIR,
		    OUSTERS_COLOR_ARM,
		    OUSTERS_COLOR_BOOTS,
		    OUSTERS_COLOR_MAX
	    }*/
        public Slot Slot;

        public int Alignment;

        public ushort CoatColor;
        public ushort HairColor;
        public ushort ArmColor;
        public ushort BootsColor;

        public OusterCoatType CoatType;
        public OusterArmType ArmType;

        public byte Rank;

        public byte Level;

        public ushort STR;
        public ushort DEX;
        public ushort INT;

        public ushort HP;
        public ushort MaxHP;
        public ushort MP;
        public ushort MaxMP;

        public uint Exp;

        public uint Fame;

        public ushort Bonus;

        public ushort SkillBonus;

        public byte AdvancementLevel;

        public PCOusterInfo()
        {
            this.PCType = PCType.OUSTER;
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
            stream.WriteByte(0x0);   

            // Write Colors
            stream.Write(BitConverter.GetBytes(this.CoatColor), 0, 2);
            stream.Write(BitConverter.GetBytes(this.HairColor), 0, 2);
            stream.Write(BitConverter.GetBytes(this.ArmColor), 0, 2);
            stream.Write(BitConverter.GetBytes(this.BootsColor), 0, 2);

            // Write Shape
            byte shape = 0;
            shape = (byte)(((ushort)this.ArmType << 3) | (ushort)this.CoatType);
            stream.WriteByte(shape);

            // Write STR, DEX & INT
            stream.Write(BitConverter.GetBytes(this.STR), 0, 2);
            stream.Write(BitConverter.GetBytes(this.DEX), 0, 2);
            stream.Write(BitConverter.GetBytes(this.INT), 0, 2);

            // Write hp & maxhp
            stream.Write(BitConverter.GetBytes(this.HP), 0, 2);
            stream.Write(BitConverter.GetBytes(this.MaxHP), 0, 2);

            // Write mp & maxmp
            stream.Write(BitConverter.GetBytes(this.MP), 0, 2);
            stream.Write(BitConverter.GetBytes(this.MaxMP), 0, 2);

            // Write Level, Rank & Exp
            stream.WriteByte(this.Level);
            stream.WriteByte(this.Rank);
            stream.Write(BitConverter.GetBytes(this.Exp), 0, 4);

            // Write Fame
            stream.Write(BitConverter.GetBytes(this.Fame), 0, 4);

            // Write Bonus Point
            stream.Write(BitConverter.GetBytes(this.Bonus), 0, 2);
            stream.Write(BitConverter.GetBytes(this.SkillBonus), 0, 2);

            // Write Advancement Level
            stream.WriteByte(this.AdvancementLevel);
        }
    }
}
