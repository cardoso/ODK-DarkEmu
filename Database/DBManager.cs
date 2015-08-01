using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Core;

namespace Database
{
    public static class DBManager
    {
        static MySqlConnection mysqlconn;

        public static void Initialize()
        {
            string connstr = "Server=127.0.0.1;Database=darkemu;Uid=root;Pwd=123456;";
            mysqlconn = new MySqlConnection(connstr);
            mysqlconn.Open();
        }

        public static int CheckPlayerLogin(string user, string password)
        {
            int result = 0; // LoginOK

            // build query string
            string      _cmdstr = @"SELECT * FROM Player WHERE UserID = '{0}' AND Password = PASSWORD('{1}');";
            object[]    _objs   = new object[] { user, password };

            string cmdstr = String.Format(_cmdstr, _objs);

            // execute query
            MySqlCommand    cmd         = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader  = cmd.ExecuteReader();
            
            // read data
            datareader.Read();

            if(!datareader.HasRows) result = 1; // Wrong UserID or Password.

            if(result != 1) { if (datareader.GetString((int)TPlayer.Access) == "DENY") result = 2; } // Access denied.

            datareader.Close();

            // return result
            return result;
        }

        public static List<WorldInfo> GetWorldInfoList()
        {
            List<WorldInfo> result = new List<WorldInfo>();

            // build query string
            string cmdstr = @"SELECT * FROM WorldInfo";

            // execute query
            MySqlCommand    cmd         = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader  = cmd.ExecuteReader();

            // read data
            if(datareader.HasRows)
            {
                while(datareader.Read())
                {
                    byte    id     = datareader.GetByte((int)TWorldInfo.ID);
                    string  name   = datareader.GetString((int)TWorldInfo.Name);
                    byte    status = datareader.GetByte((int)TWorldInfo.Status);
                    string  ip     = datareader.GetString((int)TWorldInfo.IPAddress);
                    uint    port    = datareader.GetUInt32((int)TWorldInfo.Port);

                    WorldInfo world = new WorldInfo(id, name, status, ip, port);

                    result.Add(world);
                }
            }

            datareader.Close();

            // return result
            return result;
        }

        public static List<ServerGroupInfo> GetServerGroupInfoList(int worldid)
        {
            List<ServerGroupInfo> result = new List<ServerGroupInfo>();

            // build query string
            string cmdstr = String.Format(@"SELECT * FROM ServerGroupInfo WHERE WorldID = {0}", worldid);

            // execute query
            MySqlCommand    cmd = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader = cmd.ExecuteReader();

            // read data
            if(datareader.HasRows)
            {
                while(datareader.Read())
                {
                    byte   id     = datareader.GetByte((int)TServerGroupInfo.ServerID);
                    string name   = datareader.GetString((int)TServerGroupInfo.Name);

                    ServerGroupInfo sgi = new ServerGroupInfo(id, name);

                    sgi.Status = datareader.GetByte((int)TServerGroupInfo.Status);
                    sgi.PKDisabled = datareader.GetBoolean((int)TServerGroupInfo.PKDisabled);
                    sgi.SlayerNum = datareader.GetUInt16((int)TServerGroupInfo.SlayerCount);
                    sgi.VampNum = datareader.GetUInt16((int)TServerGroupInfo.VampireCount);
                    sgi.OusterNum = datareader.GetUInt16((int)TServerGroupInfo.OusterCount);

                    result.Add(sgi);
                }
            }

            datareader.Close();

            // return result
            return result;
        }

        public static PCInfo[] GetPCInfoList(string userid)
        {
            PCInfo[] result = new PCInfo[3];

            // build query string
            string cmdstr = String.Format(@"SELECT SLOT1, SLOT2, SLOT3 FROM Player WHERE UserID = '{0}'", userid);

            // execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader = cmd.ExecuteReader();

            // read data
            if(datareader.HasRows)
            {
                datareader.Read();


                string name1 = null;
                string name2 = null;
                string name3 = null;

                if(!datareader.IsDBNull(0)) { name1 = datareader.GetString(0); }
                if(!datareader.IsDBNull(1)) { name2 = datareader.GetString(1); }
                if(!datareader.IsDBNull(2)) { name3 = datareader.GetString(2); }

                datareader.Close();

                if(name1 != null)
                {
                    PCType pctype = GetPCType(name1);
                    if(pctype == PCType.SLAYER)
                    {
                        PCSlayerInfo pc = GetPCSlayerInfo(name1);
                        pc.Slot = Slot.SLOT1;

                        result[0] = pc;                       
                    }
                    else if(pctype == PCType.VAMPIRE)
                    {
                        PCVampireInfo pc = GetPCVampireInfo(name1);
                        pc.Slot = Slot.SLOT1;

                        result[0] = pc;
                    }
                    else if (pctype == PCType.OUSTER)
                    {
                        PCOusterInfo pc = GetPCOusterInfo(name1);
                        pc.Slot = Slot.SLOT1;

                        result[0] = pc;
                    }
                }

                if(name2 != null)
                {
                    PCType pctype = GetPCType(name2);
                    if (pctype == PCType.SLAYER)
                    {
                        PCSlayerInfo pc = GetPCSlayerInfo(name2);
                        pc.Slot = Slot.SLOT2;

                        result[1] = pc;      
                    }
                    else if (pctype == PCType.VAMPIRE)
                    {
                        PCVampireInfo pc = GetPCVampireInfo(name2);
                        pc.Slot = Slot.SLOT2;

                        result[1] = pc;
                    }
                    else if (pctype == PCType.OUSTER)
                    {
                        PCOusterInfo pc = GetPCOusterInfo(name2);
                        pc.Slot = Slot.SLOT2;

                        result[1] = pc;
                    }
                }

                if(name3 != null)
                {
                    PCType pctype = GetPCType(name3);
                    if (pctype == PCType.SLAYER)
                    {
                        PCSlayerInfo pc = GetPCSlayerInfo(name3);
                        pc.Slot = Slot.SLOT3;

                        result[2] = pc;    
                    }
                    else if(pctype == PCType.VAMPIRE)
                    {
                        PCVampireInfo pc = GetPCVampireInfo(name3);
                        pc.Slot = Slot.SLOT3;

                        result[2] = pc;
                    }
                    else if(pctype == PCType.OUSTER)
                    {
                        PCOusterInfo pc = GetPCOusterInfo(name3);
                        pc.Slot = Slot.SLOT3;

                        result[2] = pc;
                    }
                }
            }

            // return result
            return result;
        }

        public static PCType GetPCType(string pcname)
        {
            PCType result = PCType.NONE;

            //build query string
            string cmdstr = String.Format(@"SELECT Race FROM PlayerChar WHERE Name = '{0}'", pcname);

            //execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader = cmd.ExecuteReader();

            //read data
            if(datareader.HasRows)
            {
                datareader.Read();
                
                result = (PCType)Enum.Parse(typeof(PCType), datareader.GetString(0));
            }

            datareader.Close();

            //return result
            return result;
        }

        public static PCSlayerInfo GetPCSlayerInfo(string pcname)
        {
            PCSlayerInfo result = new PCSlayerInfo();

            //build query string
            string cmdstr = String.Format(@"SELECT * FROM Slayer WHERE Name = '{0}'", pcname);

            //execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader = cmd.ExecuteReader();

            //read data
            if(datareader.HasRows)
            {
                datareader.Read();

                // name
                result.Name = datareader.GetString((int)TSlayer.Name);

                // sex
                result.Sex = (Sex)Enum.Parse(typeof(Sex), datareader.GetString((int)TSlayer.Sex));

                // alignment
                result.Alignment = datareader.GetInt32((int)TSlayer.Alignment);

                // str dex & int
                result.STR = datareader.GetUInt16((int)TSlayer.STR);
                result.DEX = datareader.GetUInt16((int)TSlayer.DEX);
                result.INT = datareader.GetUInt16((int)TSlayer.INT);

                // rank
                result.Rank = datareader.GetByte((int)TSlayer.Rank);

                // strexp dexexp & int
                result.STRExp = datareader.GetUInt32((int)TSlayer.STRExp);
                result.INTExp = datareader.GetUInt32((int)TSlayer.INTExp);
                result.DEXExp = datareader.GetUInt32((int)TSlayer.DEXExp);

                // hp maxhp mp & maxmp
                result.HP = datareader.GetUInt16((int)TSlayer.HP);
                result.MaxHP = datareader.GetUInt16((int)TSlayer.MaxHP);
                result.MP = datareader.GetUInt16((int)TSlayer.MP);
                result.MaxMP = datareader.GetUInt16((int)TSlayer.MaxMP);
                
                // fame
                result.Fame = datareader.GetUInt32((int)TSlayer.Fame);
                
                // domainlevels (6)
                result.DomainLevelBlade = datareader.GetByte((int)TSlayer.BladeLevel);
                result.DomainLevelSword = datareader.GetByte((int)TSlayer.SwordLevel);
                result.DomainLevelGun = datareader.GetByte((int)TSlayer.GunLevel);
                result.DomainLevelHeal = datareader.GetByte((int)TSlayer.HealLevel);
                result.DomainLevelEnchant = datareader.GetByte((int)TSlayer.EnchantLevel);
                result.DomainLevelEtc = datareader.GetByte((int)TSlayer.ETCLevel);

                // shape
                //result.Shape = datareader.GetUInt32((int)TSlayer.Shape);
                result.HairStyle = (HairStyle)Enum.Parse(typeof(HairStyle), datareader.GetString((int)TSlayer.HairStyle));
                result.Helmet = datareader.GetByte((int)TSlayer.Helmet);
                result.Jacket = datareader.GetByte((int)TSlayer.Jacket);
                result.Pants = datareader.GetByte((int)TSlayer.Pants);
                result.Weapon = datareader.GetByte((int)TSlayer.Weapon);
                result.Shield = datareader.GetByte((int)TSlayer.Shield);

                // colors
                result.ColorHair = datareader.GetUInt16((int)TSlayer.HairColor);
                result.ColorSkin = datareader.GetUInt16((int)TSlayer.SkinColor);
                result.ColorHelmet = datareader.GetUInt16((int)TSlayer.HelmetColor);
                result.ColorJacket = datareader.GetUInt16((int)TSlayer.JacketColor);
                result.ColorPants = datareader.GetUInt16((int)TSlayer.PantsColor);
                result.ColorWeapon = datareader.GetUInt16((int)TSlayer.WeaponColor);
                result.ColorShield = datareader.GetUInt16((int)TSlayer.ShieldColor);

                // advancement level
                result.AdvancementLevel = datareader.GetByte((int)TSlayer.AdvancementLevel);
            }
            else { result = null; };

            datareader.Close();

            //return result
            return result;
        }

        public static PCVampireInfo GetPCVampireInfo(string pcname)
        {
            PCVampireInfo result = new PCVampireInfo();

            //build query string
            string cmdstr = String.Format(@"SELECT * FROM Vampire WHERE Name = '{0}'", pcname);

            //execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader = cmd.ExecuteReader();

            //read data
            if (datareader.HasRows)
            {
                datareader.Read();

                // name
                result.Name = datareader.GetString((int)TVampire.Name);

                // slot
                // result.Slot = (Slot)Enum.Parse(typeof(Slot), datareader.GetString((int)TVampire.Slot));

                // alignment
                result.Alignment = datareader.GetInt32((int)TVampire.Alignment);

                // sex
                result.Sex = (Sex)Enum.Parse(typeof(Sex), datareader.GetString((int)TVampire.Sex));

                // colors
                result.BatColor = datareader.GetUInt16((int)TVampire.BatColor);
                result.SkinColor = datareader.GetUInt16((int)TVampire.SkinColor);

                // coat type & coat color
                result.CoatType = datareader.GetUInt16((int)TVampire.CoatType);
                result.CoatColor = datareader.GetUInt16((int)TVampire.CoatColor);

                // rank
                result.Rank = datareader.GetByte((int)TVampire.Rank);

                // level
                result.Level = datareader.GetByte((int)TVampire.Level);

                // str dex & int
                result.STR = datareader.GetUInt16((int)TVampire.STR);
                result.DEX = datareader.GetUInt16((int)TVampire.DEX);
                result.INT = datareader.GetUInt16((int)TVampire.INT);

                // hp & maxhp
                result.HP = datareader.GetUInt16((int)TVampire.HP);
                result.MaxHP = datareader.GetUInt16((int)TVampire.MaxHP);

                // exp
                result.Exp = datareader.GetUInt32((int)TVampire.EXP);

                // armtype & armcolor
                result.ArmType = (VampireArmType)Enum.Parse(typeof(VampireArmType), datareader.GetString((int)TVampire.ArmType));
                result.ArmColor = datareader.GetUInt16((int)TVampire.ArmColor);

                // fame
                result.Fame = datareader.GetUInt32((int)TVampire.Fame);

                // bonus
                result.Bonus = datareader.GetUInt16((int)TVampire.Bonus);

                // advancementlevel
                result.AdvancementLevel = datareader.GetByte((int)TVampire.AdvancementLevel);
            }
            else { result = null; };

            datareader.Close();

            //return result
            return result;
        }

        public static PCOusterInfo GetPCOusterInfo(string pcname)
        {
            PCOusterInfo result = new PCOusterInfo();

            //build query string
            string cmdstr = String.Format(@"SELECT * FROM Ouster WHERE Name = '{0}'", pcname);

            //execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader = cmd.ExecuteReader();

            //read data
            if (datareader.HasRows)
            {
                datareader.Read();

                // name
                result.Name = datareader.GetString((int)TOuster.Name);

                // alignment
                result.Alignment = datareader.GetInt32((int)TOuster.Alignment);

                // colors
                result.CoatColor = datareader.GetUInt16((int)TOuster.CoatColor);
                result.HairColor = datareader.GetUInt16((int)TOuster.HairColor);
                result.ArmColor = datareader.GetUInt16((int)TOuster.ArmColor);
                result.BootsColor = datareader.GetUInt16((int)TOuster.BootsColor);

                // coat type & arm type
                result.CoatType = (OusterCoatType)Enum.Parse(typeof(OusterCoatType), datareader.GetString((int)TOuster.CoatType));
                result.ArmType = (OusterArmType)Enum.Parse(typeof(OusterArmType), datareader.GetString((int)TOuster.ArmType));

                // rank
                result.Rank = datareader.GetByte((int)TOuster.Rank);

                // level
                result.Level = datareader.GetByte((int)TOuster.Level);

                // str dex & int
                result.STR = datareader.GetUInt16((int)TOuster.STR);
                result.DEX = datareader.GetUInt16((int)TOuster.DEX);
                result.INT = datareader.GetUInt16((int)TOuster.INT);

                // hp maxhp mp & maxmp
                result.HP = datareader.GetUInt16((int)TOuster.HP);
                result.MaxHP = datareader.GetUInt16((int)TOuster.MaxHP);
                result.MP = datareader.GetUInt16((int)TOuster.MP);
                result.MaxMP = datareader.GetUInt16((int)TOuster.MaxMP);

                // exp
                result.Exp = datareader.GetUInt32((int)TOuster.EXP);

                // fame
                result.Fame = datareader.GetUInt32((int)TOuster.Fame);

                // bonus & skillbonus
                result.Bonus = datareader.GetUInt16((int)TOuster.Bonus);
                result.SkillBonus = datareader.GetUInt16((int)TOuster.SkillBonus);

                // advancementlevel
                result.AdvancementLevel = datareader.GetByte((int)TOuster.AdvancementLevel);
            }
            else { result = null; };

            datareader.Close();

            //return result
            return result;
        }

        public static PCSlayerInfo2 GetPCSlayerInfo2(string pcname)
        {
            PCSlayerInfo2 result = new PCSlayerInfo2();

            //build query string
            string cmdstr = String.Format(@"SELECT * FROM Slayer WHERE Name = '{0}'", pcname);

            //execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader = cmd.ExecuteReader();

            //read data
            if (datareader.HasRows)
            {
                datareader.Read();

                // name
                result.Name = datareader.GetString((int)TSlayer.Name);

                // sex
                result.Sex = (Sex)Enum.Parse(typeof(Sex), datareader.GetString((int)TSlayer.Sex));

                // alignment
                result.Alignment = datareader.GetInt32((int)TSlayer.Alignment);

                // str dex & int
                result.STRBasic = datareader.GetUInt16((int)TSlayer.STR);
                result.DEXBasic = datareader.GetUInt16((int)TSlayer.DEX);
                result.INTBasic = datareader.GetUInt16((int)TSlayer.INT);

                // rank
                result.Rank = datareader.GetByte((int)TSlayer.Rank);

                // strexp dexexp & int
                result.STRExp = datareader.GetUInt32((int)TSlayer.STRExp);
                result.INTExp = datareader.GetUInt32((int)TSlayer.INTExp);
                result.DEXExp = datareader.GetUInt32((int)TSlayer.DEXExp);

                // hp maxhp mp & maxmp
                result.HP = datareader.GetUInt16((int)TSlayer.HP);
                result.MaxHP = datareader.GetUInt16((int)TSlayer.MaxHP);
                result.MP = datareader.GetUInt16((int)TSlayer.MP);
                result.MaxMP = datareader.GetUInt16((int)TSlayer.MaxMP);

                // fame
                result.Fame = datareader.GetUInt32((int)TSlayer.Fame);

                // domainlevels (6)
                result.DomainLevelBlade = datareader.GetByte((int)TSlayer.BladeLevel);
                result.DomainLevelSword = datareader.GetByte((int)TSlayer.SwordLevel);
                result.DomainLevelGun = datareader.GetByte((int)TSlayer.GunLevel);
                result.DomainLevelHeal = datareader.GetByte((int)TSlayer.HealLevel);
                result.DomainLevelEnchant = datareader.GetByte((int)TSlayer.EnchantLevel);
                result.DomainLevelEtc = datareader.GetByte((int)TSlayer.ETCLevel);

                // advancement level
                result.AdvancementLevel = datareader.GetByte((int)TSlayer.AdvancementLevel);
            }
            else { result = null; };

            datareader.Close();

            //return result
            return result;
        }

        public static int DeletePC(string name, Slot slot, string ssn)
        {
            int result = 0;

            // build query string
            string cmdstr = String.Format("UPDATE Player SET {0} = NULL WHERE {0} = '{1}' AND SSN = '{2}'", slot, name, ssn);

            // execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            int cmdres = cmd.ExecuteNonQuery();

            // read data
            if (cmdres > 0) result = 1;

            //return result
            return result;
        }

        public static ErrorID CreatePC(string name, PCType race)
        {
            ErrorID result = ErrorID.None;

            // check if pc exists
            if (CheckPCExists(name)) return ErrorID.AlreadyRegisteredId;

            // build query string
            string cmdstr = String.Format("INSERT INTO PlayerChar (Name, Race) VALUES ('{0}', '{1}')", name, Enum.GetName(typeof(PCType), race));

            // execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            int cmdres = cmd.ExecuteNonQuery();

            // return result
            return result;
        }

        public static ErrorID CreatePCSlayer(string name, Sex sex = Sex.FEMALE,
                                             ushort str = 20, ushort dex = 20, ushort inte = 20, 
                                             HairStyle hairstyle = HairStyle.HAIR_STYLE1, ushort colorhair = 0, ushort colorskin = 0)
        {
            ErrorID result = ErrorID.None;

            // create pc
            result = CreatePC(name, PCType.SLAYER);
            if (result != ErrorID.None) return result;

            // build query string
            string _str = "INSERT INTO Slayer (Name, Sex, STR, DEX, INTE, HairStyle, HairColor, SkinColor) VALUES ('{0}', '{1}', {2}, {3}, {4}, '{5}', {6}, {7})";
            object[] _objs = new object[] { name, sex, str, dex, inte, hairstyle, colorhair, colorskin };

            string cmdstr = String.Format(_str, _objs);

            // execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            int cmdres = cmd.ExecuteNonQuery();

            // return result
            return result;
        }

        public static ErrorID CreatePCVampire(string name, Sex sex, ushort colorskin)
        {
            ErrorID result = ErrorID.None;

            // create pc
            result = CreatePC(name, PCType.VAMPIRE);
            if (result != ErrorID.None) return result;

            // build query string
            string cmdstr = String.Format("INSERT INTO Vampire (Name, Sex, SkinColor) VALUES ('{0}', '{1}' , {2})", name, sex, colorskin);

            // execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            int cmdres = cmd.ExecuteNonQuery();

            // return result
            return result;
        }

        public static ErrorID CreatePCOuster(string name, ushort str, ushort dex, ushort inte, ushort colorhair)
        {
            ErrorID result = ErrorID.None;

            // create pc
            result = CreatePC(name, PCType.OUSTER);
            if (result != ErrorID.None) return result;

            // build query string
            string _str = "INSERT INTO Ouster (Name, STR, DEX, INTE, HairColor) VALUES ('{0}', {1}, {2}, {3}, {4})";
            object[] _objs = new object[] { name, str, dex, inte, colorhair };

            string cmdstr = String.Format(_str, _objs);

            // execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            int cmdres = cmd.ExecuteNonQuery();

            // return result
            return result;
        }

        public static bool CheckPCExists(string pcname)
        {
            bool result = false;

            // build query string
            string cmdstr = String.Format("SELECT * FROM PlayerChar WHERE Name = '{0}'", pcname);

            // execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            MySqlDataReader datareader = cmd.ExecuteReader();

            // read data
            if(datareader.HasRows)
            {
                result = true;
            }

            datareader.Close();

            // return result
            return result;
        }

        public static void AssignPCToPlayer(string name, string pcname, Slot slot)
        {
            // build query string
            string cmdstr = String.Format("UPDATE Player SET {0} = '{1}' WHERE UserID = '{2}'", slot, pcname, name);

            // execute query
            MySqlCommand cmd = new MySqlCommand(cmdstr, mysqlconn);
            int cmdres = cmd.ExecuteNonQuery();
        }
    }
}