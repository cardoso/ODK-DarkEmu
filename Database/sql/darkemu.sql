/*
Navicat MySQL Data Transfer

Source Server         : Local
Source Server Version : 50524
Source Host           : 127.0.0.1:3306
Source Database       : darkemu

Target Server Type    : MYSQL
Target Server Version : 50524
File Encoding         : 65001

Date: 2015-08-01 17:22:04
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for ClientInfo
-- ----------------------------
DROP TABLE IF EXISTS `ClientInfo`;
CREATE TABLE `ClientInfo` (
  `Version` smallint(5) unsigned DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ClientInfo
-- ----------------------------
INSERT INTO `ClientInfo` VALUES ('360');

-- ----------------------------
-- Table structure for HelmInfo
-- ----------------------------
DROP TABLE IF EXISTS `HelmInfo`;
CREATE TABLE `HelmInfo` (
  `ItemType` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `NextItemType` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Name` varchar(30) NOT NULL DEFAULT '',
  `EName` varchar(30) NOT NULL DEFAULT '',
  `Price` int(10) unsigned NOT NULL DEFAULT '0',
  `Volume` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Weight` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Ratio` int(11) NOT NULL DEFAULT '0',
  `Durability` smallint(5) unsigned NOT NULL DEFAULT '0',
  `Defense` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Protection` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `ReqAbility` varchar(50) NOT NULL DEFAULT '',
  `ItemLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `DefaultOption` varchar(50) NOT NULL DEFAULT '',
  `UpgradeCrashPercent` tinyint(4) NOT NULL DEFAULT '0',
  `UpgradeRatio` smallint(6) NOT NULL DEFAULT '0',
  `NextOptionRatio` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `DowngradeRatio` smallint(6) NOT NULL DEFAULT '0',
  `Race` tinyint(1) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`ItemType`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of HelmInfo
-- ----------------------------
INSERT INTO `HelmInfo` VALUES ('0', '1', 'ÈÄµå', 'Hood', '100', '5', '2', '70000', '100', '1', '0', '(SUM,30)', '0', '', '50', '130', '18', '62', '1');
INSERT INTO `HelmInfo` VALUES ('1', '2', '¾ÆÀÌ¾ð Çï¸ä', 'Iron Helmet', '1000', '5', '6', '20000', '700', '5', '2', '(SUM,40)', '1', '', '45', '120', '15', '60', '1');
INSERT INTO `HelmInfo` VALUES ('2', '3', 'ÀÎÇÁ¶ó·¹µå Çï¸ä', 'Infrared Helmet', '3000', '5', '4', '9000', '1100', '8', '3', '(SUM,50)', '2', '', '40', '110', '13', '58', '1');
INSERT INTO `HelmInfo` VALUES ('3', '4', '¿¡ÀÓ Çï¸ä', 'Aim Helmet', '9000', '5', '5', '550', '1400', '11', '3', '(SUM,60)', '3', '', '35', '100', '11', '56', '1');
INSERT INTO `HelmInfo` VALUES ('4', '5', 'ÄÄ¹î Çï¸ä', 'Combat Helmet', '20000', '5', '6', '320', '2000', '15', '5', '(SUM,70)', '4', '', '30', '90', '9', '54', '1');
INSERT INTO `HelmInfo` VALUES ('5', '6', 'Çìµå±â¾î', 'HeadGear', '40000', '5', '6', '100', '2000', '17', '6', '(SUM,90)', '5', '', '25', '80', '7', '52', '1');
INSERT INTO `HelmInfo` VALUES ('6', '7', 'ÄÄ¹î Çìµå±â¾î', 'Combat HeadGear', '80000', '5', '6', '20', '2500', '20', '10', '(SUM,120)', '6', '', '20', '70', '4', '50', '1');
INSERT INTO `HelmInfo` VALUES ('7', '8', 'ÀÎÇÁ¶ó·¹µå ½ºÄ³´× Çï¸ä', 'Infrared Scanning Helmet', '160000', '5', '6', '8', '2700', '23', '12', '(SUM,160)', '7', '', '10', '60', '3', '48', '1');
INSERT INTO `HelmInfo` VALUES ('8', '10', '¿ö ÇÃ·¹ÀÌÆ® Çï¸§', 'War Plate Helm', '300000', '5', '6', '2', '3000', '27', '17', '(SUM,225)', '8', '', '5', '50', '1', '46', '1');
INSERT INTO `HelmInfo` VALUES ('10', '11', 'ÄÄºñ³×ÀÌ¼Ç ÄÄºª Çï¸§', 'Combination Combat Helm', '500000', '5', '6', '2', '4500', '30', '20', '(SUM,265)', '9', '', '3', '40', '1', '44', '1');
INSERT INTO `HelmInfo` VALUES ('11', '12', '½ºÆÎ°Õ Çï¸ä', 'Spangen Helmet', '750000', '5', '6', '1', '5000', '33', '23', '(SUM,285)', '10', '', '2', '30', '1', '42', '1');
INSERT INTO `HelmInfo` VALUES ('12', '13', '¹ö°Å³Ý Çï¸ä', 'Burgonet Helmet', '850000', '5', '6', '0', '10000', '36', '26', '(SUM,305)', '11', '', '1', '20', '1', '40', '1');
INSERT INTO `HelmInfo` VALUES ('13', '14', '¸¶¿îÆ® °í±Û', 'Mount Goggle', '5000000', '5', '6', '0', '15000', '37', '27', '(ADV,1)', '12', '', '0', '0', '0', '0', '1');
INSERT INTO `HelmInfo` VALUES ('14', '16', '¸ÖÆ¼ ½ºÄ«¿ìÅÍ', 'Multi Scouter', '5900000', '5', '6', '0', '15800', '40', '29', '(ADV,11)', '13', '', '0', '0', '0', '0', '1');
INSERT INTO `HelmInfo` VALUES ('9', '9', 'µàÅ© Çï¸§', 'Duke Helm', '999999', '5', '6', '0', '4000', '34', '25', '(SUM,160)', '255', 'RES+5,ATTR+3', '0', '0', '0', '0', '1');
INSERT INTO `HelmInfo` VALUES ('15', '15', 'Ä®¸® Çï¸ä', 'Khali\'s Helmet', '500000', '5', '6', '2', '4500', '30', '20', '(SUM,30)', '9', '', '3', '40', '1', '44', '1');
INSERT INTO `HelmInfo` VALUES ('16', '17', 'ESS ÅÃÆ¼ÄÃ °í±Û', 'ESS Tactical Goggles', '6800000', '6', '15', '0', '16600', '43', '31', '(ADV,21)', '14', '', '0', '0', '0', '0', '1');
INSERT INTO `HelmInfo` VALUES ('17', '17', '¹Ì½º¸± Çï¸ä', 'Mithril Helm', '7700000', '6', '15', '0', '17400', '46', '33', '(ADV,31)', '15', '', '0', '0', '0', '0', '1');

-- ----------------------------
-- Table structure for ItemClass
-- ----------------------------
DROP TABLE IF EXISTS `ItemClass`;
CREATE TABLE `ItemClass` (
  `ItemClass` double DEFAULT NULL,
  `Name` varchar(20) DEFAULT NULL,
  `EnchantClass1` double DEFAULT NULL,
  `EnchantClass2` double DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ItemClass
-- ----------------------------
INSERT INTO `ItemClass` VALUES ('0', 'MOTORCYCLE', '0', '0');
INSERT INTO `ItemClass` VALUES ('1', 'POTION', '0', '0');
INSERT INTO `ItemClass` VALUES ('2', 'WATER', '0', '0');
INSERT INTO `ItemClass` VALUES ('3', 'HOLYWATER', '0', '0');
INSERT INTO `ItemClass` VALUES ('4', 'MAGAZINE', '0', '0');
INSERT INTO `ItemClass` VALUES ('5', 'BOMB_MATER', '0', '0');
INSERT INTO `ItemClass` VALUES ('6', 'ETC', '0', '0');
INSERT INTO `ItemClass` VALUES ('7', 'KEY', '0', '0');
INSERT INTO `ItemClass` VALUES ('8', 'RING', '3', '0');
INSERT INTO `ItemClass` VALUES ('9', 'BRACELET', '3', '0');
INSERT INTO `ItemClass` VALUES ('10', 'NECKLACE', '3', '0');
INSERT INTO `ItemClass` VALUES ('11', 'COAT', '3', '0');
INSERT INTO `ItemClass` VALUES ('12', 'TROUSER', '3', '0');
INSERT INTO `ItemClass` VALUES ('13', 'SHOES', '3', '0');
INSERT INTO `ItemClass` VALUES ('14', 'SWORD', '1', '0');
INSERT INTO `ItemClass` VALUES ('15', 'BLADE', '1', '0');
INSERT INTO `ItemClass` VALUES ('16', 'SHIELD', '3', '0');
INSERT INTO `ItemClass` VALUES ('17', 'CROSS', '2', '0');
INSERT INTO `ItemClass` VALUES ('18', 'GLOVE', '3', '0');
INSERT INTO `ItemClass` VALUES ('19', 'HELM', '3', '0');
INSERT INTO `ItemClass` VALUES ('20', 'SG', '1', '0');
INSERT INTO `ItemClass` VALUES ('21', 'SMG', '1', '0');
INSERT INTO `ItemClass` VALUES ('22', 'AR', '1', '0');
INSERT INTO `ItemClass` VALUES ('23', 'SR', '1', '0');
INSERT INTO `ItemClass` VALUES ('24', 'BOMB', '0', '0');
INSERT INTO `ItemClass` VALUES ('25', 'MINE', '0', '0');
INSERT INTO `ItemClass` VALUES ('26', 'BELT', '3', '0');
INSERT INTO `ItemClass` VALUES ('27', 'LEARNINGIT', '0', '0');
INSERT INTO `ItemClass` VALUES ('28', 'MONEY', '0', '0');
INSERT INTO `ItemClass` VALUES ('29', 'CORPSE', '0', '0');
INSERT INTO `ItemClass` VALUES ('30', 'VAMPIRE_RI', '3', '0');
INSERT INTO `ItemClass` VALUES ('31', 'VAMPIRE_BR', '3', '0');
INSERT INTO `ItemClass` VALUES ('32', 'VAMPIRE_NE', '3', '0');
INSERT INTO `ItemClass` VALUES ('33', 'VAMPIRE_CO', '3', '0');
INSERT INTO `ItemClass` VALUES ('34', 'SKULL', '0', '0');
INSERT INTO `ItemClass` VALUES ('35', 'MACE', '2', '0');
INSERT INTO `ItemClass` VALUES ('36', 'SERUM', '0', '0');
INSERT INTO `ItemClass` VALUES ('37', 'VAMPIRE_ET', '0', '0');
INSERT INTO `ItemClass` VALUES ('38', 'SLAYER_POR', '0', '0');
INSERT INTO `ItemClass` VALUES ('39', 'VAMPIRE_PO', '0', '0');
INSERT INTO `ItemClass` VALUES ('40', 'EVENT_GIFT', '0', '0');
INSERT INTO `ItemClass` VALUES ('41', 'EVENT_STAR', '0', '0');
INSERT INTO `ItemClass` VALUES ('42', 'VAMPIRE_EA', '3', '0');
INSERT INTO `ItemClass` VALUES ('43', 'RELIC', '0', '0');
INSERT INTO `ItemClass` VALUES ('44', 'VAMPIRE_WE', '2', '1');
INSERT INTO `ItemClass` VALUES ('45', 'VAMPIRE_AM', '3', '0');
INSERT INTO `ItemClass` VALUES ('46', 'QUEST_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('47', 'EVENT_TREE', '0', '0');
INSERT INTO `ItemClass` VALUES ('48', 'EVENT_ETC', '0', '0');
INSERT INTO `ItemClass` VALUES ('49', 'BLOOD_BIBL', '0', '0');
INSERT INTO `ItemClass` VALUES ('50', 'CASTLE_SYM', '0', '0');
INSERT INTO `ItemClass` VALUES ('51', 'COUPLE_RIN', '0', '0');
INSERT INTO `ItemClass` VALUES ('52', 'VAMPIRE_CO', '3', '0');
INSERT INTO `ItemClass` VALUES ('53', 'EVENT_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('54', 'DYE_POTION', '0', '0');
INSERT INTO `ItemClass` VALUES ('55', 'RESURRECT_', '0', '0');
INSERT INTO `ItemClass` VALUES ('56', 'MIXING_ITE', '0', '0');
INSERT INTO `ItemClass` VALUES ('57', 'OUSTERS_AR', '3', '0');
INSERT INTO `ItemClass` VALUES ('58', 'OUSTERS_BO', '3', '0');
INSERT INTO `ItemClass` VALUES ('59', 'OUSTERS_CH', '1', '0');
INSERT INTO `ItemClass` VALUES ('60', 'OUSTERS_CI', '3', '0');
INSERT INTO `ItemClass` VALUES ('61', 'OUSTERS_CO', '3', '0');
INSERT INTO `ItemClass` VALUES ('62', 'OUSTERS_PE', '3', '0');
INSERT INTO `ItemClass` VALUES ('63', 'OUSTERS_RI', '3', '0');
INSERT INTO `ItemClass` VALUES ('64', 'OUSTERS_ST', '3', '0');
INSERT INTO `ItemClass` VALUES ('65', 'OUSTERS_WR', '2', '0');
INSERT INTO `ItemClass` VALUES ('66', 'LARVA', '0', '0');
INSERT INTO `ItemClass` VALUES ('67', 'PUPA', '0', '0');
INSERT INTO `ItemClass` VALUES ('68', 'COMPOS_MEI', '0', '0');
INSERT INTO `ItemClass` VALUES ('69', 'OUSTERS_SU', '0', '0');
INSERT INTO `ItemClass` VALUES ('70', 'EFFECT_ITE', '0', '0');
INSERT INTO `ItemClass` VALUES ('71', 'CODE_SHEET', '0', '0');
INSERT INTO `ItemClass` VALUES ('72', 'MOON_CARD', '0', '0');
INSERT INTO `ItemClass` VALUES ('73', 'SWEEPER', '0', '0');
INSERT INTO `ItemClass` VALUES ('74', 'PET_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('75', 'PET_FOOD', '0', '0');
INSERT INTO `ItemClass` VALUES ('76', 'PET_ENCHAN', '0', '0');
INSERT INTO `ItemClass` VALUES ('77', 'LUCKY_BAG', '0', '0');
INSERT INTO `ItemClass` VALUES ('78', 'SMS_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('79', 'CORE_ZAP', '0', '0');
INSERT INTO `ItemClass` VALUES ('80', 'GQUEST_ITE', '0', '0');
INSERT INTO `ItemClass` VALUES ('81', 'TRAP_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('82', 'BLOOD_BIBL', '0', '0');
INSERT INTO `ItemClass` VALUES ('83', 'WAR_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('84', 'CARRYING_R', '3', '0');
INSERT INTO `ItemClass` VALUES ('85', 'SHOULDER_A', '3', '0');
INSERT INTO `ItemClass` VALUES ('86', 'DERMIS', '3', '0');
INSERT INTO `ItemClass` VALUES ('87', 'PERSONA', '3', '0');
INSERT INTO `ItemClass` VALUES ('88', 'FASCIA', '3', '0');
INSERT INTO `ItemClass` VALUES ('89', 'MITTEN', '3', '0');
INSERT INTO `ItemClass` VALUES ('90', 'SUB_INVENT', '0', '0');
INSERT INTO `ItemClass` VALUES ('91', 'COMMON_QUE', '0', '0');
INSERT INTO `ItemClass` VALUES ('92', 'ETHEREAL_C', '0', '0');
INSERT INTO `ItemClass` VALUES ('93', 'OUSTERS_HA_PE', '0', '0');
INSERT INTO `ItemClass` VALUES ('94', 'CHECK_MONEY', '0', '0');
INSERT INTO `ItemClass` VALUES ('95', 'CUE_OF_ADAM', '0', '0');
INSERT INTO `ItemClass` VALUES ('96', 'CONTRACT_OF_BLOOD', '0', '0');
INSERT INTO `ItemClass` VALUES ('97', 'SKILL_BOOK', '0', '0');
INSERT INTO `ItemClass` VALUES ('98', 'VAMPIRE_WING_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('99', 'OUSTERS_WING_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('100', 'SLAYER_TUNNING_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('101', 'VAMPIRE_TUNNING_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('102', 'OUSTERS_TUNNING_ITEM', '0', '0');
INSERT INTO `ItemClass` VALUES ('103', 'CALLNPC_CARD', '0', '0');

-- ----------------------------
-- Table structure for Ouster
-- ----------------------------
DROP TABLE IF EXISTS `Ouster`;
CREATE TABLE `Ouster` (
  `Name` varchar(10) DEFAULT NULL,
  `Alignment` int(11) NOT NULL DEFAULT '7500',
  `Rank` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `Level` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `AdvancementLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `STR` smallint(5) unsigned NOT NULL DEFAULT '20',
  `DEX` smallint(5) unsigned NOT NULL DEFAULT '20',
  `INTE` smallint(5) unsigned NOT NULL DEFAULT '20',
  `HP` smallint(5) unsigned NOT NULL DEFAULT '200',
  `MaxHP` smallint(5) unsigned NOT NULL DEFAULT '200',
  `MP` smallint(5) unsigned NOT NULL DEFAULT '200',
  `MaxMP` smallint(5) unsigned NOT NULL DEFAULT '200',
  `EXP` int(10) unsigned NOT NULL DEFAULT '0',
  `Fame` int(10) unsigned NOT NULL DEFAULT '0',
  `Bonus` smallint(5) unsigned NOT NULL DEFAULT '0',
  `SkillBonus` smallint(5) unsigned NOT NULL DEFAULT '0',
  `CoatColor` smallint(5) unsigned NOT NULL DEFAULT '377',
  `HairColor` smallint(5) unsigned NOT NULL DEFAULT '377',
  `ArmColor` smallint(5) unsigned NOT NULL DEFAULT '377',
  `BootsColor` smallint(5) unsigned NOT NULL DEFAULT '377',
  `CoatType` enum('OUSTERS_COAT_BASIC','OUSTERS_COAT1','OUSTERS_COAT2','OUSTERS_COAT3','OUSTERS_COAT4','OUSTERS_COAT5','OUSTERS_COAT6') NOT NULL,
  `ArmType` enum('OUSTERS_ARM_GAUNTLET','OUSTERS_ARM_CHAKRAM','OUSTERS_ARM_CHAKRAM_171','OUSTERS_ARM_CHAKRAM_181') NOT NULL,
  KEY `fk_ousters_name_playerchar_name` (`Name`),
  CONSTRAINT `fk_ousters_name_playerchar_name` FOREIGN KEY (`Name`) REFERENCES `PlayerChar` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of Ouster
-- ----------------------------
INSERT INTO `Ouster` VALUES ('vadia', '7500', '1', '1', '0', '10', '25', '10', '200', '200', '200', '200', '0', '0', '0', '0', '377', '283', '377', '377', 'OUSTERS_COAT_BASIC', 'OUSTERS_ARM_GAUNTLET');
INSERT INTO `Ouster` VALUES ('Vadiuska', '7500', '1', '1', '0', '10', '10', '25', '200', '200', '200', '200', '0', '0', '0', '0', '377', '70', '377', '377', 'OUSTERS_COAT_BASIC', 'OUSTERS_ARM_GAUNTLET');
INSERT INTO `Ouster` VALUES ('Vish', '7500', '1', '1', '0', '25', '10', '10', '200', '200', '200', '200', '0', '0', '0', '0', '377', '101', '377', '377', 'OUSTERS_COAT_BASIC', 'OUSTERS_ARM_GAUNTLET');
INSERT INTO `Ouster` VALUES ('vadia2', '7500', '1', '1', '0', '10', '10', '25', '200', '200', '200', '200', '0', '0', '0', '0', '377', '400', '377', '377', 'OUSTERS_COAT_BASIC', 'OUSTERS_ARM_GAUNTLET');

-- ----------------------------
-- Table structure for Player
-- ----------------------------
DROP TABLE IF EXISTS `Player`;
CREATE TABLE `Player` (
  `UserID` varchar(10) NOT NULL,
  `Password` varchar(41) DEFAULT NULL,
  `Access` enum('ALLOW','DENY') DEFAULT NULL,
  `SLOT1` varchar(10) DEFAULT NULL,
  `SLOT2` varchar(10) DEFAULT NULL,
  `SLOT3` varchar(10) DEFAULT NULL,
  `SSN` varchar(14) DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  KEY `fk_player_slot1_playerchar_name` (`SLOT1`),
  KEY `fk_player_slot2_playerchar_name` (`SLOT2`),
  KEY `fk_player_slot3_playerchar_name` (`SLOT3`),
  CONSTRAINT `fk_player_slot1_playerchar_name` FOREIGN KEY (`SLOT1`) REFERENCES `PlayerChar` (`Name`),
  CONSTRAINT `fk_player_slot2_playerchar_name` FOREIGN KEY (`SLOT2`) REFERENCES `PlayerChar` (`Name`),
  CONSTRAINT `fk_player_slot3_playerchar_name` FOREIGN KEY (`SLOT3`) REFERENCES `PlayerChar` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of Player
-- ----------------------------
INSERT INTO `Player` VALUES ('admin', '*4ACFE3202A5FF5CF467898FC58AAB1D615029441', 'ALLOW', 'Slayers', 'asdasdasd', null, '123456-1234567');
INSERT INTO `Player` VALUES ('admin2', '*4ACFE3202A5FF5CF467898FC58AAB1D615029441', 'ALLOW', 'Vish', 'habitches', null, '123456-1234567');

-- ----------------------------
-- Table structure for PlayerChar
-- ----------------------------
DROP TABLE IF EXISTS `PlayerChar`;
CREATE TABLE `PlayerChar` (
  `Name` varchar(10) NOT NULL,
  `Race` enum('SLAYER','VAMPIRE','OUSTER') NOT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of PlayerChar
-- ----------------------------
INSERT INTO `PlayerChar` VALUES ('asdasdasd', 'VAMPIRE');
INSERT INTO `PlayerChar` VALUES ('asddd', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('Bathory', 'VAMPIRE');
INSERT INTO `PlayerChar` VALUES ('Dracula1', 'VAMPIRE');
INSERT INTO `PlayerChar` VALUES ('Draculah', 'VAMPIRE');
INSERT INTO `PlayerChar` VALUES ('fgdfgdfg', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('gaaay', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('gayfag', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('habitches', 'VAMPIRE');
INSERT INTO `PlayerChar` VALUES ('Hair01', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('HAIR02', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('HAIR03', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('Hair1', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('Ouster', 'OUSTER');
INSERT INTO `PlayerChar` VALUES ('Pink', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('sasha', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('Slayer', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('Slayers', 'SLAYER');
INSERT INTO `PlayerChar` VALUES ('vadia', 'OUSTER');
INSERT INTO `PlayerChar` VALUES ('vadia2', 'OUSTER');
INSERT INTO `PlayerChar` VALUES ('Vadiuska', 'OUSTER');
INSERT INTO `PlayerChar` VALUES ('Vampire', 'VAMPIRE');
INSERT INTO `PlayerChar` VALUES ('Vampire2', 'VAMPIRE');
INSERT INTO `PlayerChar` VALUES ('Vish', 'OUSTER');

-- ----------------------------
-- Table structure for ServerGroupInfo
-- ----------------------------
DROP TABLE IF EXISTS `ServerGroupInfo`;
CREATE TABLE `ServerGroupInfo` (
  `WorldID` tinyint(4) DEFAULT NULL,
  `ServerID` tinyint(4) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Status` tinyint(4) DEFAULT NULL,
  `PKDisabled` tinyint(1) DEFAULT NULL,
  `SlayerCount` smallint(6) DEFAULT NULL,
  `VampireCount` smallint(6) DEFAULT NULL,
  `OusterCount` smallint(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of ServerGroupInfo
-- ----------------------------
INSERT INTO `ServerGroupInfo` VALUES ('0', '0', 'Free', '0', '0', '30', '32', '20');
INSERT INTO `ServerGroupInfo` VALUES ('0', '1', 'Premium', '0', '0', '51', '42', '39');

-- ----------------------------
-- Table structure for Slayer
-- ----------------------------
DROP TABLE IF EXISTS `Slayer`;
CREATE TABLE `Slayer` (
  `Name` varchar(10) NOT NULL,
  `Sex` enum('FEMALE','MALE') NOT NULL,
  `Alignment` int(11) NOT NULL DEFAULT '7500',
  `STR` smallint(5) unsigned NOT NULL DEFAULT '20',
  `DEX` smallint(5) unsigned NOT NULL DEFAULT '20',
  `INTE` smallint(5) unsigned NOT NULL DEFAULT '20',
  `Rank` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `STRExp` int(10) unsigned NOT NULL DEFAULT '0',
  `DEXExp` int(10) unsigned NOT NULL DEFAULT '0',
  `INTExp` int(10) unsigned NOT NULL DEFAULT '0',
  `HP` smallint(5) unsigned NOT NULL DEFAULT '20',
  `MaxHP` smallint(5) unsigned NOT NULL DEFAULT '20',
  `MP` smallint(5) unsigned NOT NULL DEFAULT '20',
  `MaxMP` smallint(5) unsigned NOT NULL DEFAULT '20',
  `Fame` int(10) unsigned NOT NULL DEFAULT '0',
  `BladeLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `SwordLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `GunLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `HealLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `EnchantLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `ETCLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `AdvancementLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `HairStyle` enum('HAIR_STYLE1','HAIR_STYLE2','HAIR_STYLE3') NOT NULL,
  `Helmet` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Jacket` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Pants` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Weapon` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `Shield` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `HairColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `SkinColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `HelmetColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `JacketColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `PantsColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `WeaponColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `ShieldColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  UNIQUE KEY `Name` (`Name`),
  CONSTRAINT `fk_slayer_name_playerchar_name` FOREIGN KEY (`Name`) REFERENCES `PlayerChar` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of Slayer
-- ----------------------------
INSERT INTO `Slayer` VALUES ('fgdfgdfg', 'MALE', '7500', '8', '15', '7', '1', '0', '0', '0', '20', '20', '20', '20', '0', '0', '0', '0', '0', '0', '0', '0', 'HAIR_STYLE3', '0', '0', '0', '0', '0', '400', '487', '0', '0', '0', '0', '0');
INSERT INTO `Slayer` VALUES ('gayfag', 'MALE', '7500', '18', '7', '5', '1', '0', '0', '0', '20', '20', '20', '20', '0', '0', '0', '0', '0', '0', '0', '0', 'HAIR_STYLE3', '0', '0', '0', '0', '0', '400', '451', '0', '0', '0', '0', '0');
INSERT INTO `Slayer` VALUES ('Hair01', 'MALE', '7500', '5', '16', '9', '1', '0', '0', '0', '20', '20', '20', '20', '0', '0', '0', '0', '0', '0', '0', '0', 'HAIR_STYLE3', '0', '0', '0', '0', '0', '57', '479', '0', '0', '0', '0', '0');
INSERT INTO `Slayer` VALUES ('HAIR02', 'MALE', '7500', '5', '19', '6', '1', '0', '0', '0', '20', '20', '20', '20', '0', '0', '0', '0', '0', '0', '0', '0', 'HAIR_STYLE1', '0', '0', '0', '0', '0', '57', '455', '0', '0', '0', '0', '0');
INSERT INTO `Slayer` VALUES ('HAIR03', 'MALE', '7500', '5', '9', '16', '1', '0', '0', '0', '20', '20', '20', '20', '0', '0', '0', '0', '0', '0', '0', '0', 'HAIR_STYLE2', '0', '0', '0', '0', '0', '57', '480', '0', '0', '0', '0', '0');
INSERT INTO `Slayer` VALUES ('Pink', 'FEMALE', '7500', '14', '6', '10', '1', '0', '0', '0', '20', '20', '20', '20', '0', '0', '0', '0', '0', '0', '0', '0', 'HAIR_STYLE2', '0', '0', '0', '0', '0', '70', '451', '0', '0', '0', '0', '0');
INSERT INTO `Slayer` VALUES ('sasha', 'FEMALE', '7500', '17', '8', '5', '1', '0', '0', '0', '20', '20', '20', '20', '0', '0', '0', '0', '0', '0', '0', '0', 'HAIR_STYLE3', '0', '0', '0', '0', '0', '57', '480', '0', '0', '0', '0', '0');
INSERT INTO `Slayer` VALUES ('Slayers', 'MALE', '7500', '8', '10', '12', '2', '1937', '3119', '4806', '16', '24', '24', '34', '0', '1', '2', '3', '4', '5', '6', '0', 'HAIR_STYLE3', '0', '0', '0', '0', '0', '57', '480', '0', '0', '0', '0', '0');

-- ----------------------------
-- Table structure for Vampire
-- ----------------------------
DROP TABLE IF EXISTS `Vampire`;
CREATE TABLE `Vampire` (
  `Name` varchar(10) NOT NULL,
  `Sex` enum('FEMALE','MALE') NOT NULL,
  `Alignment` int(11) NOT NULL DEFAULT '7500',
  `STR` smallint(5) unsigned NOT NULL DEFAULT '20',
  `DEX` smallint(5) unsigned NOT NULL DEFAULT '20',
  `INTE` smallint(5) unsigned NOT NULL DEFAULT '20',
  `Rank` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `Level` tinyint(3) unsigned NOT NULL DEFAULT '1',
  `AdvancementLevel` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `HP` smallint(5) unsigned NOT NULL DEFAULT '200',
  `MaxHP` smallint(5) unsigned NOT NULL DEFAULT '200',
  `BatColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `SkinColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `CoatType` smallint(5) unsigned NOT NULL DEFAULT '1',
  `CoatColor` smallint(5) unsigned NOT NULL DEFAULT '377',
  `EXP` int(10) unsigned NOT NULL DEFAULT '0',
  `ArmType` enum('VAMPIRE_ARM_NONE','VAMPIRE_ARM_WEAPON','VAMPIRE_ARM_WEAPON2','VAMPIRE_ARM_WEAPON3') NOT NULL,
  `ArmColor` smallint(5) unsigned NOT NULL DEFAULT '0',
  `Fame` int(10) unsigned NOT NULL DEFAULT '0',
  `Bonus` smallint(5) unsigned NOT NULL DEFAULT '0',
  UNIQUE KEY `Name` (`Name`),
  CONSTRAINT `fk_vampire_name_playerchar_name` FOREIGN KEY (`Name`) REFERENCES `PlayerChar` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of Vampire
-- ----------------------------
INSERT INTO `Vampire` VALUES ('asdasdasd', 'MALE', '7500', '20', '20', '20', '1', '1', '0', '200', '200', '0', '364', '1', '377', '0', 'VAMPIRE_ARM_WEAPON3', '0', '0', '0');
INSERT INTO `Vampire` VALUES ('habitches', 'FEMALE', '7500', '20', '20', '20', '1', '1', '0', '200', '200', '0', '455', '1', '377', '0', 'VAMPIRE_ARM_NONE', '0', '0', '0');
INSERT INTO `Vampire` VALUES ('Vampire2', 'MALE', '7500', '20', '20', '20', '1', '1', '0', '200', '200', '0', '480', '1', '377', '0', 'VAMPIRE_ARM_NONE', '0', '0', '0');

-- ----------------------------
-- Table structure for WorldInfo
-- ----------------------------
DROP TABLE IF EXISTS `WorldInfo`;
CREATE TABLE `WorldInfo` (
  `ID` tinyint(4) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Status` tinyint(4) NOT NULL DEFAULT '0',
  `IPAddress` varchar(15) NOT NULL DEFAULT '127.0.0.1',
  `Port` int(11) NOT NULL DEFAULT '9998',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of WorldInfo
-- ----------------------------
INSERT INTO `WorldInfo` VALUES ('0', 'Tepez', '0', '127.0.0.1', '9998');
