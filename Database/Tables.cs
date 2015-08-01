using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database
{
    public enum TWorldInfo
    {
        ID = 0,
        Name,
        Status,
        IPAddress,
        Port
    }

    public enum TServerGroupInfo
    {
        WorldID = 0,
        ServerID,
        Name,
        Status,
        PKDisabled,
        SlayerCount,
        VampireCount,
        OusterCount
    }

    public enum TPlayer
    {
        UserID = 0,
        Password,
        Access,
        PCSlot1,
        PCSlot2,
        PCSlot3,
        SSN
    }

    public enum TPlayerChar
    {
        Name = 0,
        Race
    }

    public enum TSlayer
    {
        Name = 0,
        Sex,
        Alignment,
        STR,
        DEX,
        INT,
        Rank,
        STRExp,
        DEXExp,
        INTExp,
        HP,
        MaxHP,
        MP,
        MaxMP,
        Fame,
        BladeLevel,
        SwordLevel,
        GunLevel,
        HealLevel,
        EnchantLevel,
        ETCLevel,
        AdvancementLevel,
        HairStyle,
        Helmet,
        Jacket,
        Pants,
        Weapon,
        Shield,
        HairColor,
        SkinColor,
        HelmetColor,
        JacketColor,
        PantsColor,
        WeaponColor,
        ShieldColor,
    }

    public enum TVampire
    {
        Name = 0,
        Sex,
        Alignment,
        STR,
        DEX,
        INT,
        Rank,
        Level,
        AdvancementLevel,
        HP,
        MaxHP,
        BatColor,
        SkinColor,
        CoatType,
        CoatColor,
        EXP,
        ArmType,
        ArmColor,
        Fame,
        Bonus,
    }

    public enum TOuster
    {
        Name = 0,
        Alignment,
        Rank,
        Level,
        AdvancementLevel,
        STR,
        DEX,
        INT,
        HP,
        MaxHP,
        MP,
        MaxMP,
        EXP,
        Fame,
        Bonus,
        SkillBonus,
        CoatColor,
        HairColor,
        ArmColor,
        BootsColor,
        CoatType,
        ArmType
    }
}
