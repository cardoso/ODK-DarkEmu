using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class PCSlayerInfo : PCInfo
    {
        /*enum SlayerBits
        {
            SLAYER_BIT_SEX,
            SLAYER_BIT_HAIRSTYLE1,
            SLAYER_BIT_HAIRSTYLE2,
            SLAYER_BIT_HELMET1,
            SLAYER_BIT_HELMET2,
            SLAYER_BIT_JACKET1,
            SLAYER_BIT_JACKET2,
            SLAYER_BIT_JACKET3,
            SLAYER_BIT_PANTS1,
            SLAYER_BIT_PANTS2,
            SLAYER_BIT_PANTS3,
            SLAYER_BIT_WEAPON1,
            SLAYER_BIT_WEAPON2,
            SLAYER_BIT_WEAPON3,
            SLAYER_BIT_WEAPON4,
            SLAYER_BIT_SHIELD1,
            SLAYER_BIT_SHIELD2,
            SLAYER_BIT_MAX
            //SLAYER_BIT_WEAPON4,
        };*/

        /*enum SlayerColors
        {
            SLAYER_COLOR_HAIR,
            SLAYER_COLOR_SKIN,
            SLAYER_COLOR_HELMET,
            SLAYER_COLOR_JACKET,
            SLAYER_COLOR_PANTS,
            SLAYER_COLOR_WEAPON,
            SLAYER_COLOR_SHIELD,
            SLAYER_COLOR_MAX
        };*/
        public Slot Slot;

        public int Alignment;

        public ushort STR;
        public ushort DEX;
        public ushort INT;

        public uint STRExp;
        public uint DEXExp;
        public uint INTExp;

        public byte Rank;

        public ushort HP;
        public ushort MaxHP;
        public ushort MP;
        public ushort MaxMP;

        public uint Fame;

        public byte DomainLevelBlade;
        public byte DomainLevelSword;
        public byte DomainLevelGun;
        public byte DomainLevelHeal;
        public byte DomainLevelEnchant;
        public byte DomainLevelEtc;

        // Shape
        public Sex Sex; // 1 bit
        public HairStyle HairStyle; // 2 bits
        public byte Helmet; // 2 bits
        public byte Jacket; // 3 bits
        public byte Pants; // 3 bits
        public byte Weapon; // 4 bits
        public byte Shield; // 2 bits

        public ushort ColorHair;
        public ushort ColorSkin;
        public ushort ColorHelmet;
        public ushort ColorJacket;
        public ushort ColorPants;
        public ushort ColorWeapon;
        public ushort ColorShield;

        public byte AdvancementLevel;
        public PCSlayerInfo()
        {
            this.PCType = PCType.SLAYER;
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

            // Write STR DEX & INT
            stream.Write(BitConverter.GetBytes(this.STR), 0, 2);
            stream.Write(BitConverter.GetBytes(this.DEX), 0, 2);
            stream.Write(BitConverter.GetBytes(this.INT), 0, 2);

            // Write Rank
            stream.WriteByte(this.Rank);

            // Write STRExp DEXExp & INTExp
            stream.Write(BitConverter.GetBytes(this.STRExp), 0, 4);
            stream.Write(BitConverter.GetBytes(this.DEXExp), 0, 4);
            stream.Write(BitConverter.GetBytes(this.INTExp), 0, 4);

            // Write HP MaxHP MP & MaxMP
            stream.Write(BitConverter.GetBytes(this.HP), 0, 2);
            stream.Write(BitConverter.GetBytes(this.MaxHP), 0, 2);
            stream.Write(BitConverter.GetBytes(this.MP), 0, 2);
            stream.Write(BitConverter.GetBytes(this.MaxMP), 0, 2);

            // Write Fame
            stream.Write(BitConverter.GetBytes(this.Fame), 0, 4);

            // Write DomainLevels
            stream.WriteByte(this.DomainLevelBlade);
            stream.WriteByte(this.DomainLevelSword);
            stream.WriteByte(this.DomainLevelGun);
            stream.WriteByte(this.DomainLevelHeal);
            stream.WriteByte(this.DomainLevelEnchant);
            stream.WriteByte(this.DomainLevelEtc);

            // Write Shape
            stream.Write(BitConverter.GetBytes(this.GetShape()), 0, 4);

            // Write Colors
            stream.Write(BitConverter.GetBytes(this.ColorHair), 0, 2);
            stream.Write(BitConverter.GetBytes(this.ColorSkin), 0, 2);
            stream.Write(BitConverter.GetBytes(this.ColorHelmet), 0, 2);
            stream.Write(BitConverter.GetBytes(this.ColorJacket), 0, 2);
            stream.Write(BitConverter.GetBytes(this.ColorPants), 0, 2);
            stream.Write(BitConverter.GetBytes(this.ColorWeapon), 0, 2);
            stream.Write(BitConverter.GetBytes(this.ColorShield), 0, 2);

            // Write Advancement Level
            stream.WriteByte(this.AdvancementLevel);
        }

        public uint GetShape()
        {
            uint res = 0;

            res = (uint)(this.Shield) << 15 | (uint)(this.Weapon) << 11 | (uint)this.Pants << 8 | (uint)(this.Jacket) << 5 | (uint)(this.Helmet) << 3 | (uint)(this.HairStyle) << 1 | (uint)(this.Sex);

            return res;
        }
    }
}
