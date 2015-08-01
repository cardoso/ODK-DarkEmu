using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class GCUpdateInfo : Packet
    {
        public PCInfo PCInfo;

        public InventoryInfo InventoryInfo;

        public GearInfo GearInfo;

        public ExtraInfo ExtraInfo;

        public EffectInfo EffectInfo;

        public bool bHasMotorcycle = false;

        public ushort ZoneID;
        public byte ZoneX;
        public byte ZoneY;

        public GameTime GameTime;

        public Weather Weather;
        public byte WeatherLevel;

        public byte DarkLevel;
        public byte LightLevel;

        public List<ushort> NPCTypeList;
        public List<ushort> MonsterTypeList;

        public List<NPCInfo> NPCInfoList;

        public byte ServerStatus;

        public byte Premium;

        public uint SMSCharge;

        public NicknameInfo NicknameInfo;

        public byte NonPK;

        public uint GuildUnionID;
        public byte GuildUnionUserType;

        public BloodBibleSignInfo BloodBibleSignInfo;

        public uint PowerjjangPoint;

        // TODO

        public GCUpdateInfo(PCInfo pcinfo2)
        {
            this.ID = PacketID.GCUpdateInfo;

            this.PCInfo = pcinfo2;

            this.InventoryInfo = new InventoryInfo();
            this.GearInfo = new GearInfo();

            GearSlotInfo gsi1 = new GearSlotInfo();
            /*gsi1.ObjectID = 0x0B4F0;
            gsi1.ItemClass = 19;
            gsi1.ItemType = 1;
            gsi1.SlotID = 0;
            this.GearInfo.GearSlotInfoList.Add(gsi1);*/

            this.ExtraInfo = new ExtraInfo();

            /*ExtraSlotInfo esi1 = new ExtraSlotInfo();
            esi1.ObjectID = 0x0B4F0;
            esi1.ItemClass = 1;
            esi1.ItemType = 1;

            this.ExtraInfo.ExtraSlotInfoList.Add(esi1)*/;

            this.EffectInfo = new EffectInfo();
            EffectInfo.Status a;
            a.val1 = 0;
            a.val2 = 0;
            this.EffectInfo.EList.Add(a);

            this.ZoneID = 12;//12;5001
            this.ZoneX = 30;// 117;
            this.ZoneY = 22;//145;

            this.GameTime = new GameTime();

            this.Weather = Weather.WEATHER_RAINY;

            this.DarkLevel = 0;
            this.LightLevel = 0;

            this.NPCTypeList = new List<ushort>();
            this.MonsterTypeList = new List<ushort>();

            this.NPCInfoList = new List<NPCInfo>();

            this.Premium = 0;

            this.SMSCharge = 0;

            this.NicknameInfo = new NicknameInfo();

            this.NonPK = 0x0;

            this.GuildUnionID = 0;
            this.GuildUnionUserType = 0x0;

            this.BloodBibleSignInfo = new BloodBibleSignInfo();

            this.PowerjjangPoint = 0;
            // TODO
        }

        public override void Write(ref NetworkStream netstream)
        {
            using (Stream stream = new MemoryStream())
            {
                // write id
                stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

                // write size
                stream.Write(BitConverter.GetBytes(this.BodySize), 0, 4);

                // write pc character
                char pchar = '0';

                switch (PCInfo.PCType)
                {
                    case PCType.SLAYER:
                        pchar = 'S';
                        break;
                    case PCType.VAMPIRE:
                        pchar = 'V';
                        break;
                    case PCType.OUSTER:
                        pchar = 'O';
                        break;
                }

                stream.WriteByte((byte)pchar);

                // write PCInfo
                this.PCInfo.Write(stream);

                // write InventoryInfo
                this.InventoryInfo.Write(stream);

                // write GearInfo
                this.GearInfo.Write(stream);

                // write ExtraInfo
                this.ExtraInfo.Write(stream);

                // write EffectInfo
                /*byte[] efinf = this.EffectInfo.GetBytes();
                stream.Write(efinf, 0, efinf.Length);*/
                this.EffectInfo.Write(stream);

                // write unknown bytes
                byte[] unk = new byte[] {
                /*0xc8, 0xcd, 0x00, 0x00, 0x00, 0x00,*/ 0x01, 0x00, 0x02, 0x6d,
                0x00, 0x52, 0xdf, 0xf5, 0x05, 0xf1, 0x00, 0x52, 0xdf, 0xf5,
                0x05, 0x00, 0x89, 0x13, 0x01, 0x01, 0xc7, 0x07, 0x04, 0x06,
                0x0c, 0x15, 0x1c, 0x00, 0x00, 0x0f, 0x06, 0x00, 0x00, 0x00,
                0x00, 0x11, 0x00, 0x00, 0x00, 0x00, 0x75, 0xe3, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x01, 0x03, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00
            };
                stream.Write(unk, 0, unk.Length);

                #region stub

                /*
                // write bHasMotorcycle
                stream.WriteByte(BitConverter.GetBytes(this.bHasMotorcycle)[0]);

                // write RideMotorCycleInfo
                // TODO
                stream.Write(new byte[15], 0, 15);

                // write ZoneID, ZoneX & ZoneY
                stream.Write(BitConverter.GetBytes(this.ZoneID), 0, 2);
                stream.WriteByte(this.ZoneX);
                stream.WriteByte(this.ZoneY);

                // write GameTime
                byte[] gmtm = this.GameTime.GetBytes();
                stream.Write(gmtm, 0, gmtm.Length);

                // write Weather & Weather Level
                stream.WriteByte((byte)this.Weather);
                stream.WriteByte(this.WeatherLevel);

                // write Dark & Light Level
                stream.WriteByte(this.DarkLevel);
                stream.WriteByte(this.LightLevel);

                // write NPCTypeList
                stream.WriteByte((byte)this.NPCTypeList.Count);

                foreach(ushort n in this.NPCTypeList)
                {
                    stream.Write(BitConverter.GetBytes(n), 0, 2);
                }

                // write MonsterTypeList
                stream.WriteByte((byte)this.MonsterTypeList.Count);

                foreach(ushort n in this.MonsterTypeList)
                {
                    stream.Write(BitConverter.GetBytes(n), 0, 2);
                }

                // write NPCInfoList
                stream.WriteByte((byte)this.NPCInfoList.Count);

                foreach(NPCInfo n in this.NPCInfoList)
                {
                    byte[] npcinf = n.GetBytes();

                    stream.Write(npcinf, 0, npcinf.Length);
                }

                // write ServerStatus
                stream.WriteByte(this.ServerStatus);

                // write Premium
                stream.WriteByte(this.Premium);

                // write SMSCharge
                stream.Write(BitConverter.GetBytes(this.SMSCharge), 0, 4);

                // write NicknameInfo
                byte[] nni = this.NicknameInfo.GetBytes();
                stream.Write(nni, 0, nni.Length);

                // write NonPK
                stream.WriteByte(this.NonPK);

                // write GuildUnionID & GuildUnionUserType
                stream.Write(BitConverter.GetBytes(this.GuildUnionID), 0, 4);
                stream.WriteByte(this.GuildUnionUserType);

                // write BloodBibleSignInfo
                byte[] bbsi = this.BloodBibleSignInfo.GetBytes();
                stream.Write(bbsi, 0, bbsi.Length);

                // write Powerjjang
                stream.Write(BitConverter.GetBytes(this.PowerjjangPoint), 0, 4);
                */
                #endregion

                // fix Size
                this.BodySize = (uint)(stream.Length - 6);
                stream.Position = 2;
                stream.Write(BitConverter.GetBytes(this.BodySize), 0, 4);

                // copy stream to netstream
                stream.Position = 0;
                stream.CopyTo(netstream);
            }
        }
    }
}
