using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public enum PCType
    {
        SLAYER,
        VAMPIRE,
        OUSTER,
        NONE
    }

    public enum Sex
    {
        FEMALE,
        MALE
    }

    public enum HairStyle
    {
        HAIR_STYLE1,
        HAIR_STYLE2,
        HAIR_STYLE3
    }

    public enum Slot
    {
        SLOT1,
        SLOT2,
        SLOT3
    }

    public enum SkillDomain
    {
        SKILL_DOMAIN_BLADE,
        SKILL_DOMAIN_SWORD,
        SKILL_DOMAIN_GUN,
        SKILL_DOMAIN_HEAL,
        SKILL_DOMAIN_ENCHANT,
        SKILL_DOMAIN_ETC,
        SKILL_DOMAIN_VAMPIRE,
        SKILL_DOMAIN_OUSTER,
    };

    public enum NicknameType
    {
		NICK_NONE = 0,		// 닉네임 없음
		NICK_BUILT_IN,		// 일반적으로 자동으로 주어지는 닉네임 (인덱스)
		NICK_QUEST,			// 퀘스트 클리어한 뒤 받는 닉네임 (인덱스)
		NICK_FORCED,		// 강제로 붙여진 닉네임 (인덱스)
		NICK_CUSTOM_FORCED,	// 강제로 붙여진 닉네임 (스트링)
		NICK_CUSTOM,		// 유저가 자유롭게 넣은 닉네임 (스트링)
		NICK_QUEST_2 		// 2nd PrideOfGuild 우승 자 
    }
}
