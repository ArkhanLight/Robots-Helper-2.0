using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace Robots_Helper_2._0
{
    public struct HashCodeData
    {
        public int Value;
        public string Type;
        public string Description;
        public bool IsUnused;

        public HashCodeData(int value, string type, string description, bool isUnused = false)
        {
            Value = value;
            Type = type;
            Description = description;
            IsUnused = isUnused;
        }
    }

    public static class EntityTypes
    {
        public const string player = "Player";
        public const string enemy = "Enemy";
        public const string npc = "NPC";
    }

    public class HashCodesEntity
    {
        public HashCodeData P01_Rodney = new HashCodeData(0x01000002, EntityTypes.player, "Adult Rodney");
        public HashCodeData EQ01_DogBot = new HashCodeData(0x01000007, EntityTypes.enemy, "Red Dog");
        public HashCodeData EW01_2Rockets = new HashCodeData(0x0100000b, EntityTypes.enemy, "Green Wheels");
        public HashCodeData EB01_SpikeBot = new HashCodeData(0x01000010, EntityTypes.enemy, "Orange Spike Bot", true);
        public HashCodeData P02_WatchBot = new HashCodeData(0x0100001e, EntityTypes.player, "Wonderbot (bad load)");
        public HashCodeData EW02_SawBot = new HashCodeData(0x0100001f, EntityTypes.enemy, "Yellow Saw Bot");
        public HashCodeData EB02_ShellBot = new HashCodeData(0x01000020, EntityTypes.enemy, "Spiky Green Shell");
        public HashCodeData EW03_ShuntBot = new HashCodeData(0x01000021, EntityTypes.enemy, "Yellow Construction");
        public HashCodeData EP01_Turret = new HashCodeData(0x01000024, EntityTypes.enemy, "Trashcan");
        public HashCodeData EB03_JailBot = new HashCodeData(0x01000027, EntityTypes.enemy, "Big Heavy Hands");
        public HashCodeData EB04_ConstructionBot = new HashCodeData(0x01000028, EntityTypes.enemy, "Orange Construction");
        public HashCodeData EB05_GuardBot = new HashCodeData(0x01000029, EntityTypes.enemy, "Tim (indeed no NPC)");
        public HashCodeData EB06_ShieldBot = new HashCodeData(0x0100002a, EntityTypes.enemy, "Green Shield Bot");
        public HashCodeData EW04_SecurityBot = new HashCodeData(0x0100002d, EntityTypes.enemy, "Security Bot");
        public HashCodeData EP03_SpinTop = new HashCodeData(0x0100002e, EntityTypes.enemy, "Yellow Spinner");
        public HashCodeData EQ02_MineBot = new HashCodeData(0x0100002f, EntityTypes.enemy, "Animal Bot", true);
        public HashCodeData EB07_MineBot = new HashCodeData(0x01000030, EntityTypes.enemy, "Mine Laying Bot");
        public HashCodeData EW05_ThiefBot = new HashCodeData(0x01000031, EntityTypes.enemy, "Vacuum", true);
        public HashCodeData P03_Morph_Test = new HashCodeData(0x01000033, EntityTypes.player, "!!!! CRASH !!!!", true);
        public HashCodeData EW06_Sweeper = new HashCodeData(0x01000034, EntityTypes.enemy, "Small Sweeper", true);
        public HashCodeData EP05_Turret = new HashCodeData(0x01000035, EntityTypes.enemy, "???? WTF ????", true);
        public HashCodeData EP02_Turret = new HashCodeData(0x01000036, EntityTypes.enemy, "Rocket Launcher");
        public HashCodeData EB09_MalfBot = new HashCodeData(0x01000039, EntityTypes.enemy, "Small Green Bot");
        public HashCodeData EP06_Turret = new HashCodeData(0x0100003a, EntityTypes.enemy, "Yellow Spiky Canon");
        public HashCodeData EW08_Flambe = new HashCodeData(0x0100003b, EntityTypes.enemy, "Flame Throwing Vacuum");
        public HashCodeData EW07_Dodgem = new HashCodeData(0x0100003c, EntityTypes.enemy, "Spiky BumperCar");
        public HashCodeData EP04_Turret = new HashCodeData(0x0100003e, EntityTypes.enemy, "Big Rocket Bot");
        public HashCodeData EW08_Armoured = new HashCodeData(0x01000044, EntityTypes.enemy, "!!!! CRASH !!!!", true);
        public HashCodeData EW09_Armoured = new HashCodeData(0x01000045, EntityTypes.enemy, "Giant One Wheel");
        public HashCodeData EB10_RollerBot = new HashCodeData(0x01000046, EntityTypes.enemy, "Rollerblader", true);
        public HashCodeData EB11_MagnaBot = new HashCodeData(0x01000047, EntityTypes.enemy, "Big Red Bot");
        public HashCodeData EF01_Mine = new HashCodeData(0x01000048, EntityTypes.enemy, "Hovering Exploding Ball");
        public HashCodeData P03_Ball = new HashCodeData(0x01000049, EntityTypes.player, "Rodney Ball (bad load)");
        public HashCodeData EQ03_Spider = new HashCodeData(0x0100004b, EntityTypes.enemy, "Big Spider", true);
        public HashCodeData EB12_EvilBot = new HashCodeData(0x0100004c, EntityTypes.enemy, "Frog Face");
        public HashCodeData EQ04_Mine = new HashCodeData(0x0100004d, EntityTypes.enemy, "Small Mine Spider", true);
        public HashCodeData EB13_KnightBot = new HashCodeData(0x0100004e, EntityTypes.enemy, "Yellow Silver Shield Bot");
        public HashCodeData EW10_Minion = new HashCodeData(0x0100004f, EntityTypes.enemy, "Chopshop Big Hammer");
        public HashCodeData NB11_Ratchet = new HashCodeData(0x01000051, EntityTypes.npc, "Ratchet");
        public HashCodeData EB14_Minion = new HashCodeData(0x01000056, EntityTypes.enemy, "Chopshop Big Hand");
        public HashCodeData EF03_EvilBot = new HashCodeData(0x01000057, EntityTypes.enemy, "Hovering Backpack Bot");
        public HashCodeData NB05_JackHammer = new HashCodeData(0x01000058, EntityTypes.npc, "Jack Hammer");
        public HashCodeData EB15_Launcher = new HashCodeData(0x01000059, EntityTypes.enemy, "Large Missile Launcher Bot");
        public HashCodeData EW11_FatBot = new HashCodeData(0x0100005a, EntityTypes.enemy, "Big Round Security Bot");
        public HashCodeData NB02_Lug = new HashCodeData(0x0100005b, EntityTypes.npc, "Lug");
        public HashCodeData EB16_KnuckleBot = new HashCodeData(0x0100005f, EntityTypes.enemy, "Skinny Bot Big Spiky Hands", true);
        public HashCodeData EM06_PiranhaBot = new HashCodeData(0x01000061, EntityTypes.enemy, "!!!! CRASH !!!", true);
        public HashCodeData NB01_BigWeld = new HashCodeData(0x01000062, EntityTypes.npc, "!!!! CRASH !!!", true);
        public HashCodeData NB04_Generic_Male = new HashCodeData(0x01000065, EntityTypes.npc, "Generic Male");
        public HashCodeData EM07_PiranhaBot = new HashCodeData(0x01000066, EntityTypes.enemy, "Piranha Bot");
        public HashCodeData P04_Shop = new HashCodeData(0x01000067, EntityTypes.player, "???? !!!! CRASH !!!!");
        public HashCodeData NW01_BigWeld = new HashCodeData(0x01000068, EntityTypes.npc, "BigWeld");
        public HashCodeData NW03_Generic_Female = new HashCodeData(0x0100006d, EntityTypes.npc, "Generic Female");
        public HashCodeData NB13_Dad = new HashCodeData(0x01000070, EntityTypes.npc, "Rodney's Dad");
        public HashCodeData EF02_DropShip = new HashCodeData(0x0100007b, EntityTypes.enemy, "!!!! CRASH !!!!");
        public HashCodeData P05_Seven = new HashCodeData(0x0100007c, EntityTypes.player, "Kid Rodney");
        public HashCodeData P06_BigWeldAndRodney = new HashCodeData(0x0100007e, EntityTypes.player, "!!!! CRASH !!!!");
        public HashCodeData Chase_BigWeld = new HashCodeData(0x0100007f, EntityTypes.player, "!!!! CRASH !!!!");
        public HashCodeData NB07_Cappy = new HashCodeData(0x01000083, EntityTypes.npc, "Cappy");
        public HashCodeData P06_Chase = new HashCodeData(0x01000086, EntityTypes.player, "!!!! CRASH !!!!");
        public HashCodeData NB14_OldBot = new HashCodeData(0x01000096, EntityTypes.npc, "Old Grandpa Bot");

    }
}
