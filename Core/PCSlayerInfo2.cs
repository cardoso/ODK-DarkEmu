using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class PCSlayerInfo2 : PCInfo
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

        public uint ObjectID;

        public Sex Sex;

        public HairStyle HairStyle;

        public ushort HairColor = 57;
        public ushort SkinColor = 480;

        public byte MasterEffectColor = 0;

        public int Alignment;

        public ushort STRCurrent = 8;
        public ushort DEXCurrent = 10;
        public ushort INTCurrent = 12;
        public ushort STRMax = 8;
        public ushort DEXMax = 10;
        public ushort INTMax = 12;
        public ushort STRBasic = 8;
        public ushort DEXBasic = 10;
        public ushort INTBasic = 12;

        public byte Rank;
        public uint RankGoalExp = 10700;
        public uint RankExp = 212;

        public uint STRGoalExp = 537;
        public uint STRExp;
        public uint DEXGoalExp = 774;
        public uint DEXExp;
        public uint INTGoalExp = 1078;
        public uint INTExp;

        public ushort HP;
        public ushort MaxHP;
        public ushort MP;
        public ushort MaxMP;

        public uint Fame;
        public uint Gold = 500;

        public byte DomainLevelBlade;
        public byte DomainLevelSword;
        public byte DomainLevelGun;
        public byte DomainLevelHeal;
        public byte DomainLevelEnchant;
        public byte DomainLevelEtc;

        public uint DomainLevelBladeGoalExp = 50;
        public uint DomainLevelSwordGoalExp = 51;
        public uint DomainLevelGunGoalExp = 52;
        public uint DomainLevelEnchantGoalExp = 54;
        public uint DomainLevelHealGoalExp = 53;
        public uint DomainLevelEtcGoalExp = 1000000;

        public uint DomainLevelBladeExp = 6;
        public uint DomainLevelSwordExp = 7;
        public uint DomainLevelGunExp = 8;
        public uint DomainLevelHealExp = 9;
        public uint DomainLevelEnchantExp = 10;
        public uint DomainLevelEtcExp = 11;

        public byte Sight = 13;

        public ushort[] HotKey = new ushort[] {0x0000, 0x0000, 0x0000};

        public byte Competence;

        public ushort GuildID = 0;
        public string GuildName = "";
        public byte GuildMemberRank = 0;

        public uint UnionID = 0;

        public byte AdvancementLevel;
        public uint AdvancementGoalExp = 1001;

        public ushort AttrBonus = 1024;

        public ushort AttackBloodBurstPoint = 99;
        public ushort DefenseBloodBurstPoint = 100;
        public ushort PartyBloodBurstPoint = 4;

        public ushort STRAdvanced = 71;
        public ushort DEXAdvanced = 72;
        public ushort INTAdvanced = 73;

        public int ContributePoint = 8;

        public int AttackSpeed = 9;

        public PCSlayerInfo2()
        {
            this.PCType = PCType.SLAYER;

            this.ObjectID = 10089;
        }

        override public void Write(Stream stream)
        {
            // write ObjectID
            stream.Write(BitConverter.GetBytes(this.ObjectID), 0, 4);

            // write Name
            stream.WriteByte((byte)this.Name.Length);
            stream.Write(Encoding.ASCII.GetBytes(this.Name), 0, this.Name.Length);

            // write Sex
            stream.WriteByte((byte)this.Sex);

            // write HairStyle
            stream.WriteByte((byte)this.HairStyle);

            // write Colors
            stream.Write(BitConverter.GetBytes(this.HairColor), 0, 2);
            stream.Write(BitConverter.GetBytes(this.SkinColor), 0, 2);
            stream.WriteByte(this.MasterEffectColor);

            // m_Born
            stream.WriteByte(0x05);

            // Write Alignment
            stream.Write(BitConverter.GetBytes(this.Alignment), 0, 4);

            // Write STR DEX & INT [3]
            stream.Write(BitConverter.GetBytes(this.STRCurrent), 0, 2);
            stream.Write(BitConverter.GetBytes(this.STRMax), 0, 2);
            stream.Write(BitConverter.GetBytes(this.STRBasic), 0, 2);
            stream.Write(BitConverter.GetBytes(this.DEXCurrent), 0, 2);
            stream.Write(BitConverter.GetBytes(this.DEXMax), 0, 2);
            stream.Write(BitConverter.GetBytes(this.DEXBasic), 0, 2);
            stream.Write(BitConverter.GetBytes(this.INTCurrent), 0, 2);
            stream.Write(BitConverter.GetBytes(this.INTMax), 0, 2);
            stream.Write(BitConverter.GetBytes(this.INTBasic), 0, 2);

            // Write Rank
            stream.WriteByte(this.Rank);

            // Write GoalExps
            stream.Write(BitConverter.GetBytes(this.RankGoalExp), 0, 4);
            stream.Write(BitConverter.GetBytes(this.STRGoalExp), 0, 4);
            stream.Write(BitConverter.GetBytes(this.DEXGoalExp), 0, 4);
            stream.Write(BitConverter.GetBytes(this.INTGoalExp), 0, 4);

            // Write HP MaxHP MP & MaxMP
            stream.Write(BitConverter.GetBytes(this.HP), 0, 2);
            stream.Write(BitConverter.GetBytes(this.MaxHP), 0, 2);
            stream.Write(BitConverter.GetBytes(this.MP), 0, 2);
            stream.Write(BitConverter.GetBytes(this.MaxMP), 0, 2);

            // Write Fame & Gold
            stream.Write(BitConverter.GetBytes(this.Fame), 0, 4);
            stream.Write(BitConverter.GetBytes(this.Gold), 0, 4);

            // Write DomainLevels & DomainLevelGoalExps
            stream.WriteByte(this.DomainLevelBlade);
            stream.Write(BitConverter.GetBytes(this.DomainLevelBladeGoalExp), 0, 4);
            stream.WriteByte(this.DomainLevelSword);
            stream.Write(BitConverter.GetBytes(this.DomainLevelSwordGoalExp), 0, 4);
            stream.WriteByte(this.DomainLevelGun);
            stream.Write(BitConverter.GetBytes(this.DomainLevelGunGoalExp), 0, 4);
            stream.WriteByte(this.DomainLevelEnchant);
            stream.Write(BitConverter.GetBytes(this.DomainLevelEnchantGoalExp), 0, 4);
            stream.WriteByte(this.DomainLevelHeal);
            stream.Write(BitConverter.GetBytes(this.DomainLevelHealGoalExp), 0, 4);
            stream.WriteByte(this.DomainLevelEtc);
            stream.Write(BitConverter.GetBytes(this.DomainLevelEtcGoalExp), 0, 4);

            // write Sight
            stream.WriteByte(this.Sight);

            // UnkString(8)
            stream.Write(Encoding.ASCII.GetBytes("Unknown8"), 0, 8);

            // UnkByte
            stream.WriteByte(this.Competence);

            // write GuildID
            stream.Write(BitConverter.GetBytes(this.GuildID), 0, 2);

            // write GuildName
            stream.WriteByte((byte)this.GuildName.Length);
            if(this.GuildName.Length > 0) stream.Write(Encoding.ASCII.GetBytes(this.GuildName), 0, this.GuildName.Length);

            // UnkInt
            stream.Write(BitConverter.GetBytes(4), 0, 4);
            stream.WriteByte(0);

            // Write Advancement Level & Exp
            stream.WriteByte(this.AdvancementLevel);
            stream.Write(BitConverter.GetBytes(this.AdvancementGoalExp), 0, 4);

            // Write AttrBonus
            stream.Write(BitConverter.GetBytes(this.AttrBonus), 0, 2);

            // write BloodBurstPoints
            stream.Write(BitConverter.GetBytes(this.AttackBloodBurstPoint), 0, 2);
            stream.Write(BitConverter.GetBytes(this.DefenseBloodBurstPoint), 0, 2);
            stream.Write(BitConverter.GetBytes(this.PartyBloodBurstPoint), 0, 2);

            // write AdvancedAttrs
            stream.Write(BitConverter.GetBytes(this.STRAdvanced), 0, 2);
            stream.Write(BitConverter.GetBytes(this.DEXAdvanced), 0, 2);
            stream.Write(BitConverter.GetBytes(this.INTAdvanced), 0, 2);

            // UnkInts
            stream.Write(BitConverter.GetBytes(0), 0, 4);
            stream.WriteByte(7);

            // Rank Exp
            //stream.Write(BitConverter.GetBytes(this.RankExp), 0, 4);

            // Write STR DEX & INT (EXP)
            //stream.Write(BitConverter.GetBytes(this.STRExp), 0, 4);
            
            //stream.Write(BitConverter.GetBytes(this.DEXExp), 0, 4);
            
            //stream.Write(BitConverter.GetBytes(this.INTExp), 0, 4);

            // write HotKey
            /*for (int i = 0; i < this.HotKey.Length; i ++ )
            {
                stream.Write(BitConverter.GetBytes(this.HotKey[i]), 0, 2);
            }*/

            // write GuildMemberRank
            //stream.WriteByte(this.GuildMemberRank);

            // write UnionID
            //stream.Write(BitConverter.GetBytes(this.UnionID), 0, 4);

            // write ContributePoint
            //stream.Write(BitConverter.GetBytes(this.ContributePoint), 0, 4);

            // write AttackSpeed
            //stream.Write(BitConverter.GetBytes(this.AttackSpeed), 0, 4);
        }
    }
}
