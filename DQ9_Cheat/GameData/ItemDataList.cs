// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.ItemDataList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DQ9_Cheat.GameData;

internal static class ItemDataList
{
    public const int SmartItemMaxCount = 944;
    public const int ItemCollectionMaxCount = 232;
    public const int AlchemyCount = 471;
    public const int AlchemyRateCount = 448;
    private static readonly List<ItemDataBase> _toolList = [];
    private static readonly List<ItemDataBase> _importantList = [];
    private static readonly List<ItemDataBase> _weaponList = [];
    private static readonly List<ItemDataBase> _shieldList = [];
    private static readonly List<ItemDataBase> _headList = [];
    private static readonly List<ItemDataBase> _upperBodyList = [];
    private static readonly List<ItemDataBase> _armList = [];
    private static readonly List<ItemDataBase> _lowerBodyList = [];
    private static readonly List<ItemDataBase> _shoeList = [];
    private static readonly List<ItemDataBase> _accessoryList = [];
    private static readonly List<ItemDataBase> _alchemyToolList = [];
    private static readonly List<ItemDataBase> _alchemyWeaponList = [];
    private static readonly List<ItemDataBase> _alchemyShieldList = [];
    private static readonly List<ItemDataBase> _alchemyHeadList = [];
    private static readonly List<ItemDataBase> _alchemyUpperBodyList = [];
    private static readonly List<ItemDataBase> _alchemyArmList = [];
    private static readonly List<ItemDataBase> _alchemyLowerBodyList = [];
    private static readonly List<ItemDataBase> _alchemyShoeList = [];
    private static readonly List<ItemDataBase> _alchemyAccessoryList = [];

    static ItemDataList()
    {
        var dataIndex1 = 7;
        InitializeWeaponDataList(ref dataIndex1);
        InitializeShieldDataList(ref dataIndex1);
        InitializeHeadDataList(ref dataIndex1);
        InitializeUpperBodyDataList(ref dataIndex1);
        InitializeArmDataList(ref dataIndex1);
        InitializeLowerBodyDataList(ref dataIndex1);
        InitializeShoeDataList(ref dataIndex1);
        InitializeAccessoryDataList(ref dataIndex1);
        MaxSmartndex = dataIndex1 - 1;
        var dataIndex2 = 7;
        InitializeToolDataList(ref dataIndex2);
        InitializeImportantDataList(ref dataIndex2);
        MaxItemCollectionIndex = dataIndex2 - 1;
    }

    public static int MaxSmartndex { get; }

    public static int MaxItemCollectionIndex { get; }

    private static void InitializeToolDataList(ref int dataIndex)
    {
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22000, "Medicinal herb"));
        _toolList.Add(new ItemDataBase(dataIndex++, 439, true, ItemType.Tool, 22001, "Strong medicine"));
        _toolList.Add(new ItemDataBase(dataIndex++, 440, true, ItemType.Tool, 22002, "Special medicine"));
        _toolList.Add(new ItemDataBase(dataIndex++, 441, true, ItemType.Tool, 22003, "Superior medicine"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22004, "Antidotal herb"));
        _toolList.Add(new ItemDataBase(dataIndex++, 442, true, ItemType.Tool, 22005, "Strong antidote"));
        _toolList.Add(new ItemDataBase(dataIndex++, 443, true, ItemType.Tool, 22006, "Special antidote"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22007, "Moonwort bulb"));
        _toolList.Add(new ItemDataBase(dataIndex++, 444, true, ItemType.Tool, 22008, "Softwort"));
        _toolList.Add(new ItemDataBase(dataIndex++, 445, true, ItemType.Tool, 22009, "Lunaria"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22010, "Angel bell"));
        _toolList.Add(new ItemDataBase(dataIndex++, 447, true, ItemType.Tool, 22011, "Panacea"));
        _toolList.Add(new ItemDataBase(dataIndex++, 448, true, ItemType.Tool, 22012, "Perfect panacea"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22013, "Yggdrasil leaf"));
        _toolList.Add(new ItemDataBase(dataIndex++, 449, true, ItemType.Tool, 22014, "Yggdrasil dew"));
        _toolList.Add(new ItemDataBase(dataIndex++, 450, true, ItemType.Tool, 22015, "Magic water"));
        _toolList.Add(new ItemDataBase(dataIndex++, 451, true, ItemType.Tool, 22016, "Sage's elixir"));
        _toolList.Add(new ItemDataBase(dataIndex++, 452, true, ItemType.Tool, 22017, "Elfin elixir"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22018, "Holy water"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22019, "Chimaera wing"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22257, "Evac-u-bell"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22021, "Coagulant"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22022, "Tangleweb"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22023, "Sleeping hibiscus"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22024, "Wakerobin"));
        _toolList.Add(new ItemDataBase(dataIndex++, 453, true, ItemType.Tool, 22020, "Mystifying mixture"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22033, "Rockbomb shard"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22025, "Party popper"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22026, "Festive feast "));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22027, "Block o' choc"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22028, "Choice chocolate"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22029, "Basic biscuits"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22030, "Posh biscuits"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22031, "Christmas cake"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22032, "Birthday cake"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22034, "Watcher's wings"));
        _toolList.Add(new ItemDataBase(dataIndex++, 454, true, ItemType.Tool, 22035, "Sage's stone"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22036, "Gleeban groat"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22037, "Gleeban guinea"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22038, "Gleeban gold piece"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22041, "Pretty betsy"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22045, "Seed of life"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22046, "Seed of magic"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22047, "Seed of strength"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22048, "Seed of deftness"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22049, "Seed of agility"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22050, "Seed of defence"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22051, "Seed of sorcery"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22052, "Seed of therapeusis"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22053, "Seed of skill"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22039, "Mini medal"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22256, "Sterling's whistle"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22078, "Cowpat"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22079, "Horse manure"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22093, "Lava lump"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22094, "Fresh water"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22095, "Flurry feather"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22096, "Royal soil"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22097, "Ice crystal"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22098, "Thunderball"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22099, "Evencloth"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22100, "Brighten rock"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22070, "Iron nails"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22071, "Iron ore"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22072, "Platinum ore"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22073, "Mythril ore"));
        _toolList.Add(new ItemDataBase(dataIndex++, 455, true, ItemType.Tool, 22074, "Densinium"));
        _toolList.Add(new ItemDataBase(dataIndex++, 456, true, ItemType.Tool, 22075, "Gold bar"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22076, "Orichalcum"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22106, "Corundum"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22115, "Flintstone"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22112, "Resurrock"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22113, "Mirrorstone"));
        _toolList.Add(new ItemDataBase(dataIndex++, 466, true, ItemType.Tool, 22114, "Sunstone"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22083, "Wing of bat"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22085, "Magic beast hide"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22086, "Magic beast horn"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22087, "Slimedrop"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22101, "Tortoiseshell"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22102, "Toad oil"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22103, "Lambswool"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22104, "Snakeskin"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22105, "Manky mud"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22089, "Kitty litter"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22090, "Glass frit"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22091, "Belle cap"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22092, "Fisticup"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22088, "Butterfly wing"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22117, "Slipweed"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22118, "Thinkincense"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22119, "Narspicious"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22120, "Seashell"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22121, "Crimson coral"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22122, "Emerald moss"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22141, "Nectar"));
        _toolList.Add(new ItemDataBase(dataIndex++, 446, true, ItemType.Tool, 22142, "Birdsong nectar"));
        _toolList.Add(new ItemDataBase(dataIndex++, 468, true, ItemType.Tool, 22123, "Finessence"));
        _toolList.Add(new ItemDataBase(dataIndex++, 469, true, ItemType.Tool, 22124, "Aggressence"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22143, "Grubby bandage"));
        _toolList.Add(new ItemDataBase(dataIndex++, 462, true, ItemType.Tool, 22144, "Technicolour dreamcloth"));
        _toolList.Add(new ItemDataBase(dataIndex++, 457, true, ItemType.Tool, 22077, "Hephaestus' flame"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22080, "Saint's ashes"));
        _toolList.Add(new ItemDataBase(dataIndex++, 467, true, ItemType.Tool, 22116, "Malicite"));
        _toolList.Add(new ItemDataBase(dataIndex++, 458, true, ItemType.Tool, 22081, "Enchanted stone"));
        _toolList.Add(new ItemDataBase(dataIndex++, 459, true, ItemType.Tool, 22082, "Ethereal stone"));
        _toolList.Add(new ItemDataBase(dataIndex++, 461, true, ItemType.Tool, 22108, "Celestial skein"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22107, "Reset stone"));
        _toolList.Add(new ItemDataBase(dataIndex++, 460, true, ItemType.Tool, 22084, "Astral plume"));
        _toolList.Add(new ItemDataBase(dataIndex++, 463, true, ItemType.Tool, 22109, "Sainted soma"));
        _toolList.Add(new ItemDataBase(dataIndex++, 464, true, ItemType.Tool, 22110, "Lucida shard"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22258, "Chronocrystal"));
        _toolList.Add(new ItemDataBase(dataIndex++, 465, true, ItemType.Tool, 22111, "Agate of evolution"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22259, "Red orb"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22260, "Blue orb"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22261, "Yellow orb"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22262, "Green orb"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22263, "Purple orb"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22264, "Silver orb"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22265, "'Swordcraft in Summary'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22266, "'Clear Spear Theory'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22267, "'Knifing Know-How'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22268, "'Wands and Beyond'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22269, "'Working with Whips'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22270, "'Staff Studies'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22271, "'The Core of the Claw'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22272, "'Further Fanmanship'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22273, "'Advanced Axecraft'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22274, "'Hardcore Hammering'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22275, "'The Boomerang Bible'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22276, "'Archery for the Adept'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22277, "'Fearsome Fisticuffing'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22278, "'Secrets of the Shield'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22279, "'Warrior's Workbook'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22280, "'Priest's Primer'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22281, "'Mage's Manual'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22282, "'Martial Artist's Manual'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22283, "'Thief's Theory'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22284, "'Minstrel's Manual'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22285, "'Gladiator's Manual'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22286, "'Paladin's Primer'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22287, "'Armamentalist's Album'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22288, "'Ranger's Revelations'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22289, "'Sage's Scripture'"));
        _toolList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22290, "'Luminary's Lore'"));
        _toolList.Add(new ItemDataBase(-1, -1, false, ItemType.Tool, 22125, "MIMIC STONE"));
        _toolList.Add(new ItemDataBase(-1, -1, false, ItemType.Tool, 22126, "BLARNEY STONE"));
        _alchemyToolList.Add(_toolList[1]);
        _alchemyToolList.Add(_toolList[2]);
        _alchemyToolList.Add(_toolList[3]);
        _alchemyToolList.Add(_toolList[5]);
        _alchemyToolList.Add(_toolList[6]);
        _alchemyToolList.Add(_toolList[8]);
        _alchemyToolList.Add(_toolList[9]);
        _alchemyToolList.Add(_toolList[95]);
        _alchemyToolList.Add(_toolList[11]);
        _alchemyToolList.Add(_toolList[12]);
        _alchemyToolList.Add(_toolList[14]);
        _alchemyToolList.Add(_toolList[15]);
        _alchemyToolList.Add(_toolList[16]);
        _alchemyToolList.Add(_toolList[17]);
        _alchemyToolList.Add(_toolList[25]);
        _alchemyToolList.Add(_toolList[36]);
        _alchemyToolList.Add(_toolList[66]);
        _alchemyToolList.Add(_toolList[67]);
        _alchemyToolList.Add(_toolList[100]);
        _alchemyToolList.Add(_toolList[103]);
        _alchemyToolList.Add(_toolList[104]);
        _alchemyToolList.Add(_toolList[107]);
        _alchemyToolList.Add(_toolList[105]);
        _alchemyToolList.Add(_toolList[99]);
        _alchemyToolList.Add(_toolList[108]);
        _alchemyToolList.Add(_toolList[109]);
        _alchemyToolList.Add(_toolList[111]);
        _alchemyToolList.Add(_toolList[73]);
        _alchemyToolList.Add(_toolList[102]);
        _alchemyToolList.Add(_toolList[96]);
        _alchemyToolList.Add(_toolList[97]);
    }

    private static void InitializeImportantDataList(ref int dataIndex)
    {
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22042, "Thief's key"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22043, "Magic key"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22044, "Ultimate key"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22158, "Keepsake ring"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22159, "Benevolessence"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22160, "Inny"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22162, "Quarantomb key"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22164, "Bodura grass"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22165, "Serene necklace"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22166, "Wyrmlight bow"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22167, "Drunken Dragon"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22168, "Gittish seal"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22169, "Fygg"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22170, "Friendant"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22129, "Platinum pick"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22171, "Nightmare nurse"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22131, "Little key"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22172, "Guestbook"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22173, "Encyclopaedia Gittanica"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22174, "Royal seal"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22175, "Cheer-me-up"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22176, "Stamp card"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22177, "Driver's licence"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22178, "Yggdrasil bud"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22179, "Stellar medicine"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22180, "Brilliant biscuits"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22181, "Crown jewel"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22182, "Dragon's tear"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22183, "Nod's tear"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22184, "Prayer pearl"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22132, "Angel's Tears"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22185, "Tycoon's trove"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22186, "Lunar diamond"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22187, "Hocus chimaera feather"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22188, "Duneberry"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22189, "Broken blade"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22190, "Backscratcher"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22191, "Hammerfang"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22192, "Mirror of reflection"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22193, "Max's axe"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22194, "Tinny tail feather"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22195, "Freezing feather"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22196, "Wobbly jelly"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22197, "Bloomingdale badge"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22198, "Gleeba badge"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22199, "Angel Falls badge"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22200, "Coffinwell badge"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22201, "Snowberian badge"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22202, "Molten magma"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22203, "Staff scroll"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22204, "Catwright's parcel"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22205, "'Bonzer Boomeranging'"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22206, "'Better Boomeranging'"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22207, "'Basic Boomeranging'"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22208, "Teeny sanguini scarf"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22209, "Pink sanguini scarf"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22210, "Genie sanguini scarf"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22211, "Packed lunch"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22212, "Crumpled note"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22213, "Goododendron"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22214, "Crumpled letter"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22216, "Beardy weirdy"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22217, "Torn exam paper 1"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22218, "Torn exam paper 2"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22219, "Torn exam paper 3"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22220, "Dead man's dagger"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22221, "Package from Ma"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22222, "Rag doll"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22223, "Magmalice handprint"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22224, "Mega moai headprint"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22225, "Memento necklace"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22226, "Titanic tincture"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22227, "Larrrst letter"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22228, "Hexite"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22229, "Drakulord's tooth"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22230, "Heavenly horseshoe"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22231, "Gratite"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22232, "Plum stone"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22233, "Clump of cloud"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22234, "Rankened phial"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22235, "Grundies"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22246, "Jewellery box"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22247, "Terrordise tail feather"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22249, "Old ring"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22250, "'Wisdom of the Ancients'"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22251, "Dirtbag"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22253, "Bone chimer"));
        _importantList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Tool, 22255, "Turbo toad oil"));
    }

    private static void InitializeWeaponDataList(ref int dataIndex)
    {
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20004,
            "Copper sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20005,
            "Soldier's sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 0, true, ItemType.Weapon, WeaponType.Sword, 20000,
            "Warrior's sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20003, "Rapier"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 3, true, ItemType.Weapon, WeaponType.Sword, 20009,
            "Fizzle foil"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20006,
            "Iron broadsword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 1, true, ItemType.Weapon, WeaponType.Sword, 20007,
            "Steel broadsword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 2, true, ItemType.Weapon, WeaponType.Sword, 20008,
            "Gigasteel broadsword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20010,
            "Cautery sword"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 4, true, ItemType.Weapon, WeaponType.Sword, 20011, "Aurora blade"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 5, true, ItemType.Weapon, WeaponType.Sword, 20012,
            "Platinum sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20001,
            "Bandit blade"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20002,
            "Valkyrie sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20013,
            "Dragonsbane"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 6, true, ItemType.Weapon, WeaponType.Sword, 20014,
            "Dragon slayer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20015,
            "Falcon blade"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 7, true, ItemType.Weapon, WeaponType.Sword, 20016,
            "Über falcon blade"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20017,
            "Miracle sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 8, true, ItemType.Weapon, WeaponType.Sword, 20018,
            "Über miracle sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 9, true, ItemType.Weapon, WeaponType.Sword, 20019, "Fire blade"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 10, true, ItemType.Weapon, WeaponType.Sword, 20020,
            "Inferno blade"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20021,
            "Metal slime sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 11, true, ItemType.Weapon, WeaponType.Sword, 20022,
            "Liquid metal sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 12, true, ItemType.Weapon, WeaponType.Sword, 20023,
            "Metal king sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Sword, 20024,
            "Rusty sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 13, true, ItemType.Weapon, WeaponType.Sword, 20025,
            "Erdrick's sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 14, true, ItemType.Weapon, WeaponType.Sword, 20026,
            "Stardust sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 15, true, ItemType.Weapon, WeaponType.Sword, 20027,
            "Nebula sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 16, true, ItemType.Weapon, WeaponType.Sword, 20028,
            "Supernova sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 17, false, ItemType.Weapon, WeaponType.Sword, 20029,
            "Hypernova sword"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Spear, 20500,
            "Bamboo lance"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Spear, 20503, "Iron lance"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 18, true, ItemType.Weapon, WeaponType.Spear, 20504, "Steel lance"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 19, true, ItemType.Weapon, WeaponType.Spear, 20505,
            "Gigasteel lance"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Spear, 20506, "Long spear"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 20, true, ItemType.Weapon, WeaponType.Spear, 20501,
            "Celestial spear"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 21, true, ItemType.Weapon, WeaponType.Spear, 20507,
            "Holy lance"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Spear, 20508,
            "Battle fork"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 22, true, ItemType.Weapon, WeaponType.Spear, 20509, "Trident"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 23, true, ItemType.Weapon, WeaponType.Spear, 20510,
            "Grace's trident"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 25, true, ItemType.Weapon, WeaponType.Spear, 20511,
            "Sandstorm spear"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Spear, 20502, "Partisan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 24, true, ItemType.Weapon, WeaponType.Spear, 20512, "Halberd"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 26, true, ItemType.Weapon, WeaponType.Spear, 20513,
            "Lightning lance"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 27, true, ItemType.Weapon, WeaponType.Spear, 20514, "Storm spear"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 28, true, ItemType.Weapon, WeaponType.Spear, 20515, "Demon spear"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Spear, 20516, "Hero spear"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Spear, 20517,
            "Metal slime spear"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 29, true, ItemType.Weapon, WeaponType.Spear, 20518,
            "Liquid metal spear"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 30, true, ItemType.Weapon, WeaponType.Spear, 20519,
            "Metal king spear"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 31, true, ItemType.Weapon, WeaponType.Spear, 20520, "Poker"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 32, true, ItemType.Weapon, WeaponType.Spear, 20521,
            "Stud poker"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 33, true, ItemType.Weapon, WeaponType.Spear, 20522,
            "Split-pot poker"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 34, false, ItemType.Weapon, WeaponType.Spear, 20523,
            "Red-hot poker"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Dagger, 19050,
            "Paring knife"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Dagger, 19051,
            "Bronze knife"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 35, true, ItemType.Weapon, WeaponType.Dagger, 19052,
            "Divine dagger"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 36, true, ItemType.Weapon, WeaponType.Dagger, 19053,
            "Poison moth knife"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 37, true, ItemType.Weapon, WeaponType.Dagger, 19054,
            "Batterfly knife"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 38, true, ItemType.Weapon, WeaponType.Dagger, 19055,
            "Dread dagger"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 39, true, ItemType.Weapon, WeaponType.Dagger, 19057,
            "Poison needle"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Dagger, 19061,
            "Deadly nightblade"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 44, true, ItemType.Weapon, WeaponType.Dagger, 19064,
            "Falcon knife earring"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 40, true, ItemType.Weapon, WeaponType.Dagger, 19058,
            "Assassin's dagger"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 41, true, ItemType.Weapon, WeaponType.Dagger, 19059,
            "Icicle dirk"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 42, true, ItemType.Weapon, WeaponType.Dagger, 19060,
            "Fenrir fang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Dagger, 19062,
            "Sword breaker"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 43, true, ItemType.Weapon, WeaponType.Dagger, 19063,
            "Soul breaker"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 45, true, ItemType.Weapon, WeaponType.Dagger, 19065, "Gladius"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 46, true, ItemType.Weapon, WeaponType.Dagger, 19066, "Flame tang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Dagger, 19067,
            "Pruning knife"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 47, true, ItemType.Weapon, WeaponType.Dagger, 19068,
            "Deft dagger"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 48, true, ItemType.Weapon, WeaponType.Dagger, 19069,
            "Darting dagger"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 49, true, ItemType.Weapon, WeaponType.Dagger, 19070,
            "Dashing dagger"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 50, false, ItemType.Weapon, WeaponType.Dagger, 19071,
            "Dynamo dagger"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Wand, 20403, "Oak staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Wand, 20494,
            "Wizard's staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 51, true, ItemType.Weapon, WeaponType.Wand, 20404,
            "Staff of sentencing"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 52, true, ItemType.Weapon, WeaponType.Wand, 20405,
            "Staff of divine wrath"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Wand, 20406,
            "Stolos' staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 56, true, ItemType.Weapon, WeaponType.Wand, 20408,
            "Watermaul wand"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 57, true, ItemType.Weapon, WeaponType.Wand, 20409,
            "Tsunami staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 53, true, ItemType.Weapon, WeaponType.Wand, 20495,
            "Lightning staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 54, true, ItemType.Weapon, WeaponType.Wand, 20407,
            "Lightning conductor"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 55, true, ItemType.Weapon, WeaponType.Wand, 20496,
            "Magma staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Wand, 20419,
            "Faerie staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Wand, 20402,
            "Brouhaha boomstick"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 58, true, ItemType.Weapon, WeaponType.Wand, 20410, "Rune staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 59, true, ItemType.Weapon, WeaponType.Wand, 20400,
            "Hieroglyph staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Wand, 20493,
            "Magical mace"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 60, true, ItemType.Weapon, WeaponType.Wand, 20411,
            "Mega-magical mace"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Wand, 20412,
            "Sceptre of Gitt"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Wand, 20401,
            "Sage's staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 61, true, ItemType.Weapon, WeaponType.Wand, 20413,
            "Savant's staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Wand, 20414, "Wyrmwand"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 62, true, ItemType.Weapon, WeaponType.Wand, 20415, "Bright staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 63, true, ItemType.Weapon, WeaponType.Wand, 20416,
            "Shining staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 64, true, ItemType.Weapon, WeaponType.Wand, 20417,
            "Brilliant staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 65, false, ItemType.Weapon, WeaponType.Wand, 20418,
            "Aurora staff"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Whip, 20300,
            "Leather whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Whip, 20301,
            "Thorn whip"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Whip, 20302, "Battle whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 66, true, ItemType.Weapon, WeaponType.Whip, 20303,
            "Snakeskin whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 67, true, ItemType.Weapon, WeaponType.Whip, 20304,
            "Serpentine whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 68, true, ItemType.Weapon, WeaponType.Whip, 20305, "Sidewinder"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Whip, 20306,
            "Chain whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Whip, 20307, "Iron whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 69, true, ItemType.Weapon, WeaponType.Whip, 20308,
            "Spiked steel whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 70, true, ItemType.Weapon, WeaponType.Whip, 20309,
            "Gigaspike whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 71, true, ItemType.Weapon, WeaponType.Whip, 20310,
            "Dragontail whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 72, true, ItemType.Weapon, WeaponType.Whip, 20311, "Demon whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 73, true, ItemType.Weapon, WeaponType.Whip, 20312,
            "Archdemon whip"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 74, true, ItemType.Weapon, WeaponType.Whip, 20313, "Scourge whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Whip, 20314,
            "Queen's whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 75, true, ItemType.Weapon, WeaponType.Whip, 20315,
            "Empress's whip"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 76, true, ItemType.Weapon, WeaponType.Whip, 20316, "Goddess whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Whip, 20317,
            "Wizadly whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 77, true, ItemType.Weapon, WeaponType.Whip, 20318,
            "Gringham whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 78, true, ItemType.Weapon, WeaponType.Whip, 20319,
            "Mega Gringham Whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 79, true, ItemType.Weapon, WeaponType.Whip, 20320,
            "Giga Gringham whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 80, false, ItemType.Weapon, WeaponType.Whip, 20321,
            "Über Gringham whip"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Club, 20600,
            "Laundry pole"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Club, 20601,
            "Carrying pole"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Club, 20602,
            "Oaken pole"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Club, 20603, "Iron bar"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 81, true, ItemType.Weapon, WeaponType.Club, 20604, "Steel bar"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 82, true, ItemType.Weapon, WeaponType.Club, 20605,
            "Gigasteel bar"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 83, true, ItemType.Weapon, WeaponType.Club, 20606,
            "Pillar of strength"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Club, 20609,
            "Driller pillar"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 85, true, ItemType.Weapon, WeaponType.Club, 20610,
            "Killer pillar"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Club, 20607,
            "Sleepy stick"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 84, true, ItemType.Weapon, WeaponType.Club, 20608,
            "Slumber stick"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 86, true, ItemType.Weapon, WeaponType.Club, 20611, "Mistick"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 87, true, ItemType.Weapon, WeaponType.Club, 20612,
            "Optimistick"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 88, true, ItemType.Weapon, WeaponType.Club, 20613, "Ballistick"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Club, 20614, "Sadistick"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Club, 20615,
            "Dragon rod"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 89, true, ItemType.Weapon, WeaponType.Club, 20616, "Xenlon rod"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 90, true, ItemType.Weapon, WeaponType.Club, 20617,
            "Orichalcudgel"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 91, true, ItemType.Weapon, WeaponType.Club, 20618, "Knockout rod"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 92, true, ItemType.Weapon, WeaponType.Club, 20619,
            "Senseless stick"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 93, true, ItemType.Weapon, WeaponType.Club, 20620,
            "Catatonic cosh"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 94, false, ItemType.Weapon, WeaponType.Club, 20621, "Coma cudgel"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Crow, 20800, "Stone claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Crow, 20801,
            "Iron claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 95, true, ItemType.Weapon, WeaponType.Crow, 20802,
            "Steel claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 96, true, ItemType.Weapon, WeaponType.Crow, 20803,
            "Gigasteel claws"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Crow, 20805, "Razor claws"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 97, true, ItemType.Weapon, WeaponType.Crow, 20804, "Sacred claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Crow, 20806,
            "Crow's claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 98, true, ItemType.Weapon, WeaponType.Crow, 20807,
            "Kestrel claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 99, true, ItemType.Weapon, WeaponType.Crow, 20808, "Kite claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Crow, 20809, "Handrills"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 100, true, ItemType.Weapon, WeaponType.Crow, 20810,
            "Hammer handrills"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Crow, 20811,
            "Dragon claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 101, true, ItemType.Weapon, WeaponType.Crow, 20812,
            "Fire claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 102, true, ItemType.Weapon, WeaponType.Crow, 20813,
            "Combusticlaws"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Crow, 20814, "Cobra claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 103, true, ItemType.Weapon, WeaponType.Crow, 20815,
            "King cobra claws"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Crow, 20816, "Beast claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 104, true, ItemType.Weapon, WeaponType.Crow, 20817,
            "Beastmaster claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 105, true, ItemType.Weapon, WeaponType.Crow, 20818,
            "Orichalcum claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 106, true, ItemType.Weapon, WeaponType.Crow, 20819,
            "Dragonlord claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 107, true, ItemType.Weapon, WeaponType.Crow, 20820,
            "Dragovian claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 108, true, ItemType.Weapon, WeaponType.Crow, 20821,
            "Dragovian lord claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 109, false, ItemType.Weapon, WeaponType.Crow, 20822,
            "Xenion claws"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Fan, 20100,
            "Feather fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Fan, 20101, "Iron fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 110, true, ItemType.Weapon, WeaponType.Fan, 20102, "Steel fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 111, true, ItemType.Weapon, WeaponType.Fan, 20103,
            "Gigasteel fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Fan, 20104, "War fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 112, true, ItemType.Weapon, WeaponType.Fan, 20105, "Foehn fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 113, true, ItemType.Weapon, WeaponType.Fan, 20106,
            "Gale force fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 120, true, ItemType.Weapon, WeaponType.Fan, 20113, "Cobra fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 121, true, ItemType.Weapon, WeaponType.Fan, 20114,
            "Azure Dragon fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 118, true, ItemType.Weapon, WeaponType.Fan, 20111, "Fowl fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 119, true, ItemType.Weapon, WeaponType.Fan, 20112,
            "Vermillion Bird fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 116, true, ItemType.Weapon, WeaponType.Fan, 20109, "Feline fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 117, true, ItemType.Weapon, WeaponType.Fan, 20110,
            "White Tiger fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 114, true, ItemType.Weapon, WeaponType.Fan, 20107,
            "Tortoiseshell fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 115, true, ItemType.Weapon, WeaponType.Fan, 20108,
            "Black Tortoise fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Fan, 20115,
            "Stellar fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 122, true, ItemType.Weapon, WeaponType.Fan, 20116, "Lunar fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 123, true, ItemType.Weapon, WeaponType.Fan, 20117, "Solar fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Fan, 20124,
            "White bouquet"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 124, true, ItemType.Weapon, WeaponType.Fan, 20118, "Friendly fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Fan, 20119,
            "Attribeauty"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 125, true, ItemType.Weapon, WeaponType.Fan, 20120, "Critical fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 126, true, ItemType.Weapon, WeaponType.Fan, 20121,
            "Overcritical fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, sbyte.MaxValue, true, ItemType.Weapon, WeaponType.Fan, 20122,
            "Hypercritical fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 128, false, ItemType.Weapon, WeaponType.Fan, 20123,
            "Dire critical fan"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Axe, 20293, "Iron axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 129, true, ItemType.Weapon, WeaponType.Axe, 20202, "Steel axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 130, true, ItemType.Weapon, WeaponType.Axe, 20203,
            "Gigasteel axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 131, true, ItemType.Weapon, WeaponType.Axe, 20204, "Golden axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Axe, 20200, "Battle-axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 132, true, ItemType.Weapon, WeaponType.Axe, 20205, "Moon axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 133, true, ItemType.Weapon, WeaponType.Axe, 20206,
            "Full moon axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 134, true, ItemType.Weapon, WeaponType.Axe, 20291, "King axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 135, true, ItemType.Weapon, WeaponType.Axe, 20207, "Kaiser axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Axe, 20201, "Pro's axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Axe, 20208,
            "Headsman's axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 136, true, ItemType.Weapon, WeaponType.Axe, 20209,
            "Executioner's axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 137, true, ItemType.Weapon, WeaponType.Axe, 20210, "Ice axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 138, true, ItemType.Weapon, WeaponType.Axe, 20211,
            "Avalanche axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Axe, 20212,
            "Heavy hatchet"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 139, true, ItemType.Weapon, WeaponType.Axe, 20213, "Bad axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 140, true, ItemType.Weapon, WeaponType.Axe, 20214, "Maxi axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 141, true, ItemType.Weapon, WeaponType.Axe, 20215, "Climaxe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 142, false, ItemType.Weapon, WeaponType.Axe, 20216,
            "Galaxy axe"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Hammer, 19150,
            "Oaken club"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 143, true, ItemType.Weapon, WeaponType.Hammer, 19151,
            "Ace of clubs"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Hammer, 19152,
            "Sledgehammer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Hammer, 19153,
            "War hammer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 144, true, ItemType.Weapon, WeaponType.Hammer, 19154,
            "Über war hammer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Hammer, 19155,
            "Giant wrench"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 145, true, ItemType.Weapon, WeaponType.Hammer, 19156,
            "Terra tamper"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 146, true, ItemType.Weapon, WeaponType.Hammer, 19157,
            "Terra firmer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 147, true, ItemType.Weapon, WeaponType.Hammer, 19158,
            "Terra hammer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Hammer, 19159,
            "Marauder's maul"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Hammer, 19161,
            "Giant's hammer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 148, true, ItemType.Weapon, WeaponType.Hammer, 19162,
            "Titan's hammer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Hammer, 19160,
            "Hela's hammer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 149, true, ItemType.Weapon, WeaponType.Hammer, 19163,
            "Megaton hammer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 150, true, ItemType.Weapon, WeaponType.Hammer, 19164,
            "Warlord's hammer"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 151, true, ItemType.Weapon, WeaponType.Hammer, 19165,
            "Groundbreaker"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 152, true, ItemType.Weapon, WeaponType.Hammer, 19166,
            "Earthsplitter"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 153, true, ItemType.Weapon, WeaponType.Hammer, 19167,
            "Moonmasher"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 154, false, ItemType.Weapon, WeaponType.Hammer, 19168,
            "Starsmasher"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Boomerang, 20700,
            "Boomerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 155, true, ItemType.Weapon, WeaponType.Boomerang, 20701,
            "Reinforced boomerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Boomerang, 20702,
            "Edged boomerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 156, true, ItemType.Weapon, WeaponType.Boomerang, 20703,
            "Cutting-edge boomerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 157, true, ItemType.Weapon, WeaponType.Boomerang, 20704,
            "Crucerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Boomerang, 20705,
            "Razor-wing boomerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 158, true, ItemType.Weapon, WeaponType.Boomerang, 20706,
            "Razer-wing boomerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 159, true, ItemType.Weapon, WeaponType.Boomerang, 20707,
            "Erazor-wing boomerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Boomerang, 20708,
            "Swallowtail"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 160, true, ItemType.Weapon, WeaponType.Boomerang, 20709,
            "Eaglewing"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 161, true, ItemType.Weapon, WeaponType.Boomerang, 20710,
            "Gustarang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 162, true, ItemType.Weapon, WeaponType.Boomerang, 20711,
            "Blusterang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 163, true, ItemType.Weapon, WeaponType.Boomerang, 20712,
            "Flametang boomerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 164, true, ItemType.Weapon, WeaponType.Boomerang, 20713,
            "Banefire boomerang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 165, true, ItemType.Weapon, WeaponType.Boomerang, 20714,
            "Pentarang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 166, true, ItemType.Weapon, WeaponType.Boomerang, 20715,
            "Hexarang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 167, true, ItemType.Weapon, WeaponType.Boomerang, 20716,
            "Meteorang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 168, true, ItemType.Weapon, WeaponType.Boomerang, 20717,
            "Asterang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 169, true, ItemType.Weapon, WeaponType.Boomerang, 20718,
            "Stellarang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 170, false, ItemType.Weapon, WeaponType.Boomerang, 20719,
            "Galaxarang"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Bow, 20901, "Short bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 171, true, ItemType.Weapon, WeaponType.Bow, 20902, "Longbow"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 172, true, ItemType.Weapon, WeaponType.Bow, 20903, "Hunter's bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Bow, 20904, "Fuddle bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Bow, 20900,
            "Potshot bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 173, true, ItemType.Weapon, WeaponType.Bow, 20906,
            "Hotshot bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 174, true, ItemType.Weapon, WeaponType.Bow, 20907, "Blowy bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 175, true, ItemType.Weapon, WeaponType.Bow, 20908,
            "Billowing bow"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 176, true, ItemType.Weapon, WeaponType.Bow, 20909, "Blustery bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Bow, 20905,
            "Cheiron's bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Weapon, WeaponType.Bow, 20910, "Great bow"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 177, true, ItemType.Weapon, WeaponType.Bow, 20911, "Purblind bow"));
        _weaponList.Add(
            new ItemDataBase(dataIndex++, 178, true, ItemType.Weapon, WeaponType.Bow, 20912, "Blinding bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 179, true, ItemType.Weapon, WeaponType.Bow, 20913, "Oh-no bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 180, true, ItemType.Weapon, WeaponType.Bow, 20914, "Odin's bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 181, true, ItemType.Weapon, WeaponType.Bow, 20915,
            "Angel's bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 182, true, ItemType.Weapon, WeaponType.Bow, 20916,
            "Archangel's bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 183, true, ItemType.Weapon, WeaponType.Bow, 20917, "Aeon's bow"));
        _weaponList.Add(new ItemDataBase(dataIndex++, 184, false, ItemType.Weapon, WeaponType.Bow, 20918,
            "Seraph's bow"));
        _alchemyWeaponList.Add(_weaponList[2]);
        _alchemyWeaponList.Add(_weaponList[6]);
        _alchemyWeaponList.Add(_weaponList[7]);
        _alchemyWeaponList.Add(_weaponList[4]);
        _alchemyWeaponList.Add(_weaponList[9]);
        _alchemyWeaponList.Add(_weaponList[10]);
        _alchemyWeaponList.Add(_weaponList[14]);
        _alchemyWeaponList.Add(_weaponList[16]);
        _alchemyWeaponList.Add(_weaponList[18]);
        _alchemyWeaponList.Add(_weaponList[19]);
        _alchemyWeaponList.Add(_weaponList[20]);
        _alchemyWeaponList.Add(_weaponList[22]);
        _alchemyWeaponList.Add(_weaponList[23]);
        _alchemyWeaponList.Add(_weaponList[25]);
        _alchemyWeaponList.Add(_weaponList[26]);
        _alchemyWeaponList.Add(_weaponList[27]);
        _alchemyWeaponList.Add(_weaponList[28]);
        _alchemyWeaponList.Add(_weaponList[29]);
        _alchemyWeaponList.Add(_weaponList[32]);
        _alchemyWeaponList.Add(_weaponList[33]);
        _alchemyWeaponList.Add(_weaponList[35]);
        _alchemyWeaponList.Add(_weaponList[36]);
        _alchemyWeaponList.Add(_weaponList[38]);
        _alchemyWeaponList.Add(_weaponList[39]);
        _alchemyWeaponList.Add(_weaponList[42]);
        _alchemyWeaponList.Add(_weaponList[40]);
        _alchemyWeaponList.Add(_weaponList[43]);
        _alchemyWeaponList.Add(_weaponList[44]);
        _alchemyWeaponList.Add(_weaponList[45]);
        _alchemyWeaponList.Add(_weaponList[48]);
        _alchemyWeaponList.Add(_weaponList[49]);
        _alchemyWeaponList.Add(_weaponList[50]);
        _alchemyWeaponList.Add(_weaponList[51]);
        _alchemyWeaponList.Add(_weaponList[52]);
        _alchemyWeaponList.Add(_weaponList[53]);
        _alchemyWeaponList.Add(_weaponList[56]);
        _alchemyWeaponList.Add(_weaponList[57]);
        _alchemyWeaponList.Add(_weaponList[58]);
        _alchemyWeaponList.Add(_weaponList[59]);
        _alchemyWeaponList.Add(_weaponList[60]);
        _alchemyWeaponList.Add(_weaponList[63]);
        _alchemyWeaponList.Add(_weaponList[64]);
        _alchemyWeaponList.Add(_weaponList[65]);
        _alchemyWeaponList.Add(_weaponList[67]);
        _alchemyWeaponList.Add(_weaponList[62]);
        _alchemyWeaponList.Add(_weaponList[68]);
        _alchemyWeaponList.Add(_weaponList[69]);
        _alchemyWeaponList.Add(_weaponList[71]);
        _alchemyWeaponList.Add(_weaponList[72]);
        _alchemyWeaponList.Add(_weaponList[73]);
        _alchemyWeaponList.Add(_weaponList[74]);
        _alchemyWeaponList.Add(_weaponList[77]);
        _alchemyWeaponList.Add(_weaponList[78]);
        _alchemyWeaponList.Add(_weaponList[82]);
        _alchemyWeaponList.Add(_weaponList[83]);
        _alchemyWeaponList.Add(_weaponList[84]);
        _alchemyWeaponList.Add(_weaponList[80]);
        _alchemyWeaponList.Add(_weaponList[81]);
        _alchemyWeaponList.Add(_weaponList[87]);
        _alchemyWeaponList.Add(_weaponList[88]);
        _alchemyWeaponList.Add(_weaponList[90]);
        _alchemyWeaponList.Add(_weaponList[93]);
        _alchemyWeaponList.Add(_weaponList[95]);
        _alchemyWeaponList.Add(_weaponList[96]);
        _alchemyWeaponList.Add(_weaponList[97]);
        _alchemyWeaponList.Add(_weaponList[98]);
        _alchemyWeaponList.Add(_weaponList[102]);
        _alchemyWeaponList.Add(_weaponList[103]);
        _alchemyWeaponList.Add(_weaponList[104]);
        _alchemyWeaponList.Add(_weaponList[107]);
        _alchemyWeaponList.Add(_weaponList[108]);
        _alchemyWeaponList.Add(_weaponList[109]);
        _alchemyWeaponList.Add(_weaponList[110]);
        _alchemyWeaponList.Add(_weaponList[111]);
        _alchemyWeaponList.Add(_weaponList[112]);
        _alchemyWeaponList.Add(_weaponList[114]);
        _alchemyWeaponList.Add(_weaponList[115]);
        _alchemyWeaponList.Add(_weaponList[117]);
        _alchemyWeaponList.Add(_weaponList[118]);
        _alchemyWeaponList.Add(_weaponList[119]);
        _alchemyWeaponList.Add(_weaponList[120]);
        _alchemyWeaponList.Add(_weaponList[125]);
        _alchemyWeaponList.Add(_weaponList[126]);
        _alchemyWeaponList.Add(_weaponList[sbyte.MaxValue]);
        _alchemyWeaponList.Add(_weaponList[131]);
        _alchemyWeaponList.Add(_weaponList[129]);
        _alchemyWeaponList.Add(_weaponList[132]);
        _alchemyWeaponList.Add(_weaponList[133]);
        _alchemyWeaponList.Add(_weaponList[134]);
        _alchemyWeaponList.Add(_weaponList[137]);
        _alchemyWeaponList.Add(_weaponList[138]);
        _alchemyWeaponList.Add(_weaponList[139]);
        _alchemyWeaponList.Add(_weaponList[140]);
        _alchemyWeaponList.Add(_weaponList[141]);
        _alchemyWeaponList.Add(_weaponList[142]);
        _alchemyWeaponList.Add(_weaponList[145]);
        _alchemyWeaponList.Add(_weaponList[146]);
        _alchemyWeaponList.Add(_weaponList[148]);
        _alchemyWeaponList.Add(_weaponList[150]);
        _alchemyWeaponList.Add(_weaponList[151]);
        _alchemyWeaponList.Add(_weaponList[153]);
        _alchemyWeaponList.Add(_weaponList[155]);
        _alchemyWeaponList.Add(_weaponList[156]);
        _alchemyWeaponList.Add(_weaponList[158]);
        _alchemyWeaponList.Add(_weaponList[160]);
        _alchemyWeaponList.Add(_weaponList[161]);
        _alchemyWeaponList.Add(_weaponList[162]);
        _alchemyWeaponList.Add(_weaponList[163]);
        _alchemyWeaponList.Add(_weaponList[164]);
        _alchemyWeaponList.Add(_weaponList[165]);
        _alchemyWeaponList.Add(_weaponList[168]);
        _alchemyWeaponList.Add(_weaponList[169]);
        _alchemyWeaponList.Add(_weaponList[171]);
        _alchemyWeaponList.Add(_weaponList[172]);
        _alchemyWeaponList.Add(_weaponList[179]);
        _alchemyWeaponList.Add(_weaponList[180]);
        _alchemyWeaponList.Add(_weaponList[177]);
        _alchemyWeaponList.Add(_weaponList[178]);
        _alchemyWeaponList.Add(_weaponList[175]);
        _alchemyWeaponList.Add(_weaponList[176]);
        _alchemyWeaponList.Add(_weaponList[173]);
        _alchemyWeaponList.Add(_weaponList[174]);
        _alchemyWeaponList.Add(_weaponList[182]);
        _alchemyWeaponList.Add(_weaponList[183]);
        _alchemyWeaponList.Add(_weaponList[185]);
        _alchemyWeaponList.Add(_weaponList[187]);
        _alchemyWeaponList.Add(_weaponList[188]);
        _alchemyWeaponList.Add(_weaponList[189]);
        _alchemyWeaponList.Add(_weaponList[190]);
        _alchemyWeaponList.Add(_weaponList[192]);
        _alchemyWeaponList.Add(_weaponList[193]);
        _alchemyWeaponList.Add(_weaponList[194]);
        _alchemyWeaponList.Add(_weaponList[196]);
        _alchemyWeaponList.Add(_weaponList[197]);
        _alchemyWeaponList.Add(_weaponList[198]);
        _alchemyWeaponList.Add(_weaponList[199]);
        _alchemyWeaponList.Add(_weaponList[202]);
        _alchemyWeaponList.Add(_weaponList[203]);
        _alchemyWeaponList.Add(_weaponList[204]);
        _alchemyWeaponList.Add(_weaponList[206]);
        _alchemyWeaponList.Add(_weaponList[207]);
        _alchemyWeaponList.Add(_weaponList[208]);
        _alchemyWeaponList.Add(_weaponList[209]);
        _alchemyWeaponList.Add(_weaponList[211]);
        _alchemyWeaponList.Add(_weaponList[214]);
        _alchemyWeaponList.Add(_weaponList[216]);
        _alchemyWeaponList.Add(_weaponList[217]);
        _alchemyWeaponList.Add(_weaponList[218]);
        _alchemyWeaponList.Add(_weaponList[221]);
        _alchemyWeaponList.Add(_weaponList[223]);
        _alchemyWeaponList.Add(_weaponList[224]);
        _alchemyWeaponList.Add(_weaponList[225]);
        _alchemyWeaponList.Add(_weaponList[226]);
        _alchemyWeaponList.Add(_weaponList[227]);
        _alchemyWeaponList.Add(_weaponList[228]);
        _alchemyWeaponList.Add(_weaponList[230]);
        _alchemyWeaponList.Add(_weaponList[232]);
        _alchemyWeaponList.Add(_weaponList[233]);
        _alchemyWeaponList.Add(_weaponList[235]);
        _alchemyWeaponList.Add(_weaponList[236]);
        _alchemyWeaponList.Add(_weaponList[238]);
        _alchemyWeaponList.Add(_weaponList[239]);
        _alchemyWeaponList.Add(_weaponList[240]);
        _alchemyWeaponList.Add(_weaponList[241]);
        _alchemyWeaponList.Add(_weaponList[242]);
        _alchemyWeaponList.Add(_weaponList[243]);
        _alchemyWeaponList.Add(_weaponList[244]);
        _alchemyWeaponList.Add(_weaponList[245]);
        _alchemyWeaponList.Add(_weaponList[246]);
        _alchemyWeaponList.Add(_weaponList[247]);
        _alchemyWeaponList.Add(_weaponList[248]);
        _alchemyWeaponList.Add(_weaponList[250]);
        _alchemyWeaponList.Add(_weaponList[251]);
        _alchemyWeaponList.Add(_weaponList[254]);
        _alchemyWeaponList.Add(_weaponList[byte.MaxValue]);
        _alchemyWeaponList.Add(_weaponList[256]);
        _alchemyWeaponList.Add(_weaponList[257]);
        _alchemyWeaponList.Add(_weaponList[260]);
        _alchemyWeaponList.Add(_weaponList[261]);
        _alchemyWeaponList.Add(_weaponList[262]);
        _alchemyWeaponList.Add(_weaponList[263]);
        _alchemyWeaponList.Add(_weaponList[264]);
        _alchemyWeaponList.Add(_weaponList[265]);
        _alchemyWeaponList.Add(_weaponList[266]);
        _alchemyWeaponList.Add(_weaponList[267]);
    }

    private static void InitializeShieldDataList(ref int dataIndex)
    {
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21296, "Pot lid"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21291, "Leather shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21192, "Scale shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21297, "Silver platter"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 185, true, ItemType.Shield, 21298, "Gold platter"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 186, true, ItemType.Shield, 21299, "Platinum platter"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21091, "Bronze shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 187, true, ItemType.Shield, 21001, "Shell shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21092, "Iron shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 188, true, ItemType.Shield, 21093, "Steel shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 189, true, ItemType.Shield, 21095, "Gigasteel shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21004, "Light shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 190, true, ItemType.Shield, 21002, "Kitty shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 191, true, ItemType.Shield, 21003, "Catty shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 197, true, ItemType.Shield, 21005, "Platinum shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21014, "Slime shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21290, "Magic shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 193, true, ItemType.Shield, 21280, "Enchanted shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 194, true, ItemType.Shield, 21281, "Ethereal shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 195, true, ItemType.Shield, 21390, "Flame shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 196, true, ItemType.Shield, 21395, "Ice shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 192, true, ItemType.Shield, 21295, "White shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21000, "Warrior's shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 198, true, ItemType.Shield, 21391, "Dragon shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 199, true, ItemType.Shield, 21006, "Tempest shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 202, true, ItemType.Shield, 21200, "White knight's shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 200, true, ItemType.Shield, 21292, "Power shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 201, true, ItemType.Shield, 21282, "Empowered shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21396, "Dark shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 203, true, ItemType.Shield, 21394, "Ogre shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21392, "Boss shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 205, true, ItemType.Shield, 21397, "Big boss shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 204, true, ItemType.Shield, 21294, "Silver shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21393, "Ruinous shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 206, true, ItemType.Shield, 21007, "Saintess shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 207, true, ItemType.Shield, 21008, "Goddess shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21190, "Metal slime shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 208, true, ItemType.Shield, 21193, "Liquid metal shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 209, true, ItemType.Shield, 21194, "Metal king shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shield, 21009, "Rusty shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 210, true, ItemType.Shield, 21191, "Erdrick's shield"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 211, true, ItemType.Shield, 21010, "Brain drainer"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 212, true, ItemType.Shield, 21011, "Psyche swiper"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 213, true, ItemType.Shield, 21012, "Devilry drinker"));
        _shieldList.Add(new ItemDataBase(dataIndex++, 214, false, ItemType.Shield, 21013, "Soul sucker"));
        _alchemyShieldList.Add(_shieldList[4]);
        _alchemyShieldList.Add(_shieldList[5]);
        _alchemyShieldList.Add(_shieldList[7]);
        _alchemyShieldList.Add(_shieldList[9]);
        _alchemyShieldList.Add(_shieldList[10]);
        _alchemyShieldList.Add(_shieldList[12]);
        _alchemyShieldList.Add(_shieldList[13]);
        _alchemyShieldList.Add(_shieldList[21]);
        _alchemyShieldList.Add(_shieldList[17]);
        _alchemyShieldList.Add(_shieldList[18]);
        _alchemyShieldList.Add(_shieldList[19]);
        _alchemyShieldList.Add(_shieldList[20]);
        _alchemyShieldList.Add(_shieldList[14]);
        _alchemyShieldList.Add(_shieldList[23]);
        _alchemyShieldList.Add(_shieldList[24]);
        _alchemyShieldList.Add(_shieldList[26]);
        _alchemyShieldList.Add(_shieldList[27]);
        _alchemyShieldList.Add(_shieldList[25]);
        _alchemyShieldList.Add(_shieldList[29]);
        _alchemyShieldList.Add(_shieldList[32]);
        _alchemyShieldList.Add(_shieldList[31]);
        _alchemyShieldList.Add(_shieldList[34]);
        _alchemyShieldList.Add(_shieldList[35]);
        _alchemyShieldList.Add(_shieldList[37]);
        _alchemyShieldList.Add(_shieldList[38]);
        _alchemyShieldList.Add(_shieldList[40]);
        _alchemyShieldList.Add(_shieldList[41]);
        _alchemyShieldList.Add(_shieldList[42]);
        _alchemyShieldList.Add(_shieldList[43]);
        _alchemyShieldList.Add(_shieldList[44]);
    }

    private static void InitializeHeadDataList(ref int dataIndex)
    {
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12191, "Iron helmet"));
        _headList.Add(new ItemDataBase(dataIndex++, 307, true, ItemType.Head, 12198, "Steel helmet"));
        _headList.Add(new ItemDataBase(dataIndex++, 308, true, ItemType.Head, 12199, "Gigasteel helmet"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12497, "Slime crown"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12790, "Iron mask"));
        _headList.Add(new ItemDataBase(dataIndex++, 309, true, ItemType.Head, 12791, "Filigree mask"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12785, "Dragon warrior helm"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12400, "Warrior's helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 310, true, ItemType.Head, 12792, "Platinum headgear"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12702, "Mail coif"));
        _headList.Add(new ItemDataBase(dataIndex++, 311, true, ItemType.Head, 12793, "Mythril coif"));
        _headList.Add(new ItemDataBase(dataIndex++, 312, true, ItemType.Head, 12295, "Thinking cap"));
        _headList.Add(new ItemDataBase(dataIndex++, 313, true, ItemType.Head, 12296, "Scholar's circlet"));
        _headList.Add(new ItemDataBase(dataIndex++, 314, true, ItemType.Head, 12180, "Raging bull helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 315, true, ItemType.Head, 12181, "Minotaur helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 316, true, ItemType.Head, 12794, "Hades' helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 318, true, ItemType.Head, 12182, "Great helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 317, true, ItemType.Head, 12795, "Mythril helm"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12183, "Veteran's helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 319, true, ItemType.Head, 12206, "Crown of clarity"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12207, "Steely sweatband"));
        _headList.Add(new ItemDataBase(dataIndex++, 320, true, ItemType.Head, 12184, "Skull helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 321, true, ItemType.Head, 12412, "Sun crown"));
        _headList.Add(new ItemDataBase(dataIndex++, 322, true, ItemType.Head, 12413, "Apollo's crown"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12197, "Metal slime helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 323, true, ItemType.Head, 12185, "Liquid metal helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 324, true, ItemType.Head, 12186, "Metal king helm"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12187, "Rusty helmet"));
        _headList.Add(new ItemDataBase(dataIndex++, 325, true, ItemType.Head, 12194, "Erdrick's helmet"));
        _headList.Add(new ItemDataBase(dataIndex++, 326, true, ItemType.Head, 12188, "Hallowed helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 327, true, ItemType.Head, 12189, "Blessed helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 328, true, ItemType.Head, 12170, "Wonder helm"));
        _headList.Add(new ItemDataBase(dataIndex++, 329, false, ItemType.Head, 12171, "Heavenly helm"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12410, "Bandana"));
        _headList.Add(new ItemDataBase(dataIndex++, 330, true, ItemType.Head, 12414, "Trailblazing bandana"));
        _headList.Add(new ItemDataBase(dataIndex++, 331, true, ItemType.Head, 12415, "Mercury's bandana"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12205, "Hairband"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12498, "Leather hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12411, "Hardwood headwear"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12208, "Silver tiara"));
        _headList.Add(new ItemDataBase(dataIndex++, 337, true, ItemType.Head, 12209, "Golden tiara"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12495, "Turban"));
        _headList.Add(new ItemDataBase(dataIndex++, 332, true, ItemType.Head, 12416, "Feathered cap"));
        _headList.Add(new ItemDataBase(dataIndex++, 335, true, ItemType.Head, 12796, "Fur hood"));
        _headList.Add(new ItemDataBase(dataIndex++, 336, true, ItemType.Head, 12496, "Pointy hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 333, true, ItemType.Head, 12800, "Bunny ears"));
        _headList.Add(new ItemDataBase(dataIndex++, 334, true, ItemType.Head, 12801, "Cat ears"));
        _headList.Add(new ItemDataBase(dataIndex++, 338, true, ItemType.Head, 12797, "Slood"));
        _headList.Add(new ItemDataBase(dataIndex++, 339, true, ItemType.Head, 12200, "Feather headband"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12201, "Circlet"));
        _headList.Add(new ItemDataBase(dataIndex++, 342, true, ItemType.Head, 12211, "Gold circlet"));
        _headList.Add(new ItemDataBase(dataIndex++, 343, true, ItemType.Head, 12212, "Star circlet"));
        _headList.Add(new ItemDataBase(dataIndex++, 340, true, ItemType.Head, 12407, "Hunter's hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 341, true, ItemType.Head, 12408, "Ear cosy"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12429, "Holy hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12402, "Hermetic hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12401, "Hocus hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 344, true, ItemType.Head, 12600, "Tricy turban"));
        _headList.Add(new ItemDataBase(dataIndex++, 345, true, ItemType.Head, 12700, "Thief's turban"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12701, "Disturbin' turban"));
        _headList.Add(new ItemDataBase(dataIndex++, 346, true, ItemType.Head, 12807, "Malleable mask"));
        _headList.Add(new ItemDataBase(dataIndex++, 347, true, ItemType.Head, 12808, "Papillon mask"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12417, "Magical hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 350, true, ItemType.Head, 12418, "Mega-magical hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 349, true, ItemType.Head, 12403, "Musketeer hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12404, "Cavalier hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12202, "Battler's band"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12405, "Minerva's mitre"));
        _headList.Add(new ItemDataBase(dataIndex++, 348, true, ItemType.Head, 12406, "Canny cap"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12409, "Top hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12204, "Ravishing ribbon"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12499, "Wizard's hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12419, "Witch's hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12480, "Mitre"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12420, "Unhappy hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 351, true, ItemType.Head, 12421, "Happy hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 352, true, ItemType.Head, 12291, "Spellward circlet"));
        _headList.Add(new ItemDataBase(dataIndex++, 353, true, ItemType.Head, 12802, "Phantom mask"));
        _headList.Add(new ItemDataBase(dataIndex++, 354, true, ItemType.Head, 12422, "Spring breeze hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 355, true, ItemType.Head, 12423, "Summer cloud hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 356, true, ItemType.Head, 12424, "Autumn shower hat"));
        _headList.Add(new ItemDataBase(dataIndex++, 357, true, ItemType.Head, 12425, "Winter sky hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12500, "Thug's mug"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12809, "Maid's mop"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12805, "Halo"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12433, "Tip-top topper"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12434, "Proper topper"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12810, "Silken veil"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12428, "Santa's hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12811, "Supernatural specs"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12814, "X-ray specs"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12815, "Silver specs"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12812, "Sharp shades"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12813, "Monarchic moustache"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12503, "Skull cap"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12436, "Swashbuckler's bonnet"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12502, "Pumpkin head"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12916, "Brown afro"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12917, "Red afro"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12193, "Alefgard helm"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12195, "Midenhall helm"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12290, "Aliahan headpiece"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12292, "Zenithian helm"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12492, "Gothan turban"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12900, "Somnia hear"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12493, "Estard hood"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12491, "Trodain bandana"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12901, "Cannock helm"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12780, "Moonbrooke hood"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12192, "Ragnar's helm"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12494, "Alena's hat"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12426, "Kiryl's kamilavka"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12902, "Borya's bouffant"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12430, "Torneko's cap"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12903, "Maya's mane"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12904, "Meena's mane"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12907, "Bianca's braid"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12908, "Nera's hair"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12806, "Debora's damasks"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12909, "Carver's hair"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12910, "Milly's hair"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12911, "Ashlynn's hair"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12912, "Kiefer's hair"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12781, "Maribel's hood"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12501, "Trodeface"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12431, "Yangus's tiffer"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12913, "Jess's tresses"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12914, "Templar's tresses"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12915, "Morrie's mullet"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12804, "Fleurette's floret"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12803, "Stellar starflower"));
        _headList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Head, 12432, "Erinn's headkerchief"));
        _alchemyHeadList.Add(_headList[1]);
        _alchemyHeadList.Add(_headList[2]);
        _alchemyHeadList.Add(_headList[5]);
        _alchemyHeadList.Add(_headList[8]);
        _alchemyHeadList.Add(_headList[10]);
        _alchemyHeadList.Add(_headList[11]);
        _alchemyHeadList.Add(_headList[12]);
        _alchemyHeadList.Add(_headList[13]);
        _alchemyHeadList.Add(_headList[14]);
        _alchemyHeadList.Add(_headList[15]);
        _alchemyHeadList.Add(_headList[17]);
        _alchemyHeadList.Add(_headList[16]);
        _alchemyHeadList.Add(_headList[19]);
        _alchemyHeadList.Add(_headList[21]);
        _alchemyHeadList.Add(_headList[22]);
        _alchemyHeadList.Add(_headList[23]);
        _alchemyHeadList.Add(_headList[25]);
        _alchemyHeadList.Add(_headList[26]);
        _alchemyHeadList.Add(_headList[28]);
        _alchemyHeadList.Add(_headList[29]);
        _alchemyHeadList.Add(_headList[30]);
        _alchemyHeadList.Add(_headList[31]);
        _alchemyHeadList.Add(_headList[32]);
        _alchemyHeadList.Add(_headList[34]);
        _alchemyHeadList.Add(_headList[35]);
        _alchemyHeadList.Add(_headList[42]);
        _alchemyHeadList.Add(_headList[45]);
        _alchemyHeadList.Add(_headList[46]);
        _alchemyHeadList.Add(_headList[43]);
        _alchemyHeadList.Add(_headList[44]);
        _alchemyHeadList.Add(_headList[40]);
        _alchemyHeadList.Add(_headList[47]);
        _alchemyHeadList.Add(_headList[48]);
        _alchemyHeadList.Add(_headList[52]);
        _alchemyHeadList.Add(_headList[53]);
        _alchemyHeadList.Add(_headList[50]);
        _alchemyHeadList.Add(_headList[51]);
        _alchemyHeadList.Add(_headList[57]);
        _alchemyHeadList.Add(_headList[58]);
        _alchemyHeadList.Add(_headList[60]);
        _alchemyHeadList.Add(_headList[61]);
        _alchemyHeadList.Add(_headList[68]);
        _alchemyHeadList.Add(_headList[64]);
        _alchemyHeadList.Add(_headList[63]);
        _alchemyHeadList.Add(_headList[75]);
        _alchemyHeadList.Add(_headList[76]);
        _alchemyHeadList.Add(_headList[77]);
        _alchemyHeadList.Add(_headList[78]);
        _alchemyHeadList.Add(_headList[79]);
        _alchemyHeadList.Add(_headList[80]);
        _alchemyHeadList.Add(_headList[81]);
    }

    private static void InitializeUpperBodyDataList(ref int dataIndex)
    {
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13101, "Leather armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13102, "Scale armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 215, true, ItemType.UpperBody, 13196, "Large-scale armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13103, "Chain mail"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13197, "Bronze armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13790, "Iron cuirass"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 216, true, ItemType.UpperBody, 13793, "Silver cuirass"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13192, "Iron armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 217, true, ItemType.UpperBody, 13198, "Full plate armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 218, true, ItemType.UpperBody, 13199, "Gigasteel armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 219, true, ItemType.UpperBody, 13791, "Tortoise shell"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 220, true, ItemType.UpperBody, 13794, "Tortoiseshell armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13180, "Silver mail"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 221, true, ItemType.UpperBody, 13181, "Gold mail"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 222, true, ItemType.UpperBody, 13182, "Platinum mail"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13183, "Heavy armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13000, "Warrior's armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13601, "Femiscyran mail"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13184, "Magic armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 223, true, ItemType.UpperBody, 13185, "Enchanted armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 224, true, ItemType.UpperBody, 13186, "Ethereal armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 226, true, ItemType.UpperBody, 13188, "Spiked armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 225, true, ItemType.UpperBody, 13187, "Dragon mail"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13100, "Tactical vest"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13602, "Brawling byrnie"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 227, true, ItemType.UpperBody, 13200, "Holy mail"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13603, "Holy femail"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13162,
            "Dragon warrior armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13189, "Sacred armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 228, true, ItemType.UpperBody, 13170, "Sacrosanct armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13171, "Veteran's armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 229, true, ItemType.UpperBody, 13172, "Mirror armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 230, true, ItemType.UpperBody, 13173, "Catoptric armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13174, "Gigant armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13190, "Metal slime armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 231, true, ItemType.UpperBody, 13175, "Liquid metal armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 232, true, ItemType.UpperBody, 13176, "Metal king armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13177, "Rusty armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 233, true, ItemType.UpperBody, 13195, "Erdrick's armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 234, true, ItemType.UpperBody, 13178, "Victorious armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 235, true, ItemType.UpperBody, 13179, "Glorious armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 236, true, ItemType.UpperBody, 13160, "Mythical armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 237, false, ItemType.UpperBody, 13161, "Legendary armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13005, "Plain clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13095, "Wayfarer's clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13519, "Leather dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13520, "Plain dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13521, "Summer dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13522, "Jaguarment"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13006, "Training top"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 238, true, ItemType.UpperBody, 13010, "Tracksuit top"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13203, "Leather cape"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13009, "Swinedimples blazer"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13605, "Dancer's costume"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13011, "Garish garb"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 239, true, ItemType.UpperBody, 13204, "Fur poncho"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13039, "White t-shirt"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13040, "Jolly roger jumper"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13041, "Shipmate's shirt"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13012, "Cloak of evasion"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 240, true, ItemType.UpperBody, 13013, "Cloak of concealment"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 241, true, ItemType.UpperBody, 13014, "Gooey gear"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13606, "Bunny suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13015, "Smart suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13504, "Spangled dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13205, "Velvet cape"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 242, true, ItemType.UpperBody, 13206, "Majestic mantle"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 243, true, ItemType.UpperBody, 13001, "Tussler's top"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13500, "Strongsam"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 244, true, ItemType.UpperBody, 13505, "Dragon dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 245, true, ItemType.UpperBody, 13002, "Flamenco shirt"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 246, true, ItemType.UpperBody, 13502, "Dancer's dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13301, "Rogue's robes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13302, "Roguess's robes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 247, true, ItemType.UpperBody, 13003, "Fur vest"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13202, "Nomadic deel"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13004, "Star's suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 248, true, ItemType.UpperBody, 13016, "Superstar's suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13604, "Tint-tastic tutu"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 249, true, ItemType.UpperBody, 13607, "Technicolour tutu"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13608, "Dangerous bikini top"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 250, true, ItemType.UpperBody, 13609, "Hot bikini top"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 251, true, ItemType.UpperBody, 13610, "Sizzling bikini top"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 252, true, ItemType.UpperBody, 13017, "Dragon top"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 253, true, ItemType.UpperBody, 13207, "Dark robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 254, true, ItemType.UpperBody, 13208, "Macabre mantle"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13018, "Combat top"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13627, "Combat costume"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, byte.MaxValue, true, ItemType.UpperBody, 13020,
            "Twinkling tuxedo"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 256, true, ItemType.UpperBody, 13506, "Shimmering dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 257, true, ItemType.UpperBody, 13612, "Dangerous bustier"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 258, true, ItemType.UpperBody, 13613, "Silk bustier"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 259, true, ItemType.UpperBody, 13614, "Divine bustier"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13209, "Pallium Regale"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 260, true, ItemType.UpperBody, 13021, "Troptoga"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 261, true, ItemType.UpperBody, 13022, "Startotoga"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 262, true, ItemType.UpperBody, 13023, "Mesotoga"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 263, false, ItemType.UpperBody, 13024, "Exotoga"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13305, "Silk robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13306, "Robe of serenity"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 264, true, ItemType.UpperBody, 13324, "Robe of sweet dreams"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13032, "Best vest"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13325, "Magical robes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 265, true, ItemType.UpperBody, 13326, "Enchanted robes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 266, true, ItemType.UpperBody, 13327, "Ethereal robes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13300, "Ascetic robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 267, true, ItemType.UpperBody, 13328, "Saintly robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13501, "Priestess's pinafore"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13700,
            "Fizzle-retardant suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 268, true, ItemType.UpperBody, 13701, "Fizzle-proof suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13600,
            "Fizzle-retardant blouse"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13033, "Glombolero"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13303, "Fencing jacket"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13201, "Fencing frock"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 269, true, ItemType.UpperBody, 13304, "Sage's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13503, "Maiden's mantle"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 270, true, ItemType.UpperBody, 13329, "Flowing dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13390, "Wizard's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13391, "Witch's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13490, "Surplice"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 271, true, ItemType.UpperBody, 13210, "Cape of good karma"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13292, "Divine dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 275, true, ItemType.UpperBody, 13509, "Prince's pea coat"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 276, true, ItemType.UpperBody, 13510, "King's coat"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 277, true, ItemType.UpperBody, 13511, "Emperor's attire"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 272, true, ItemType.UpperBody, 13590, "Princess's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 273, true, ItemType.UpperBody, 13507, "Queen's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 274, true, ItemType.UpperBody, 13508, "Empress's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13307, "Nightmare gown"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 470, true, ItemType.UpperBody, 13308, "Celestria's gown"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 278, true, ItemType.UpperBody, 13309, "Celestria's raiment"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13310, "Dragon robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 279, true, ItemType.UpperBody, 13311, "Xenlon robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 280, true, ItemType.UpperBody, 13312, "Angel's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 281, true, ItemType.UpperBody, 13313, "Archangel's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 282, true, ItemType.UpperBody, 13314, "Aeon's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, 283, false, ItemType.UpperBody, 13315, "Seraph's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13031, "Muscle belt"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13620, "Maid outfit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13007, "Celestial suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13035, "White tuxedo"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13625, "Wedding dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13036, "Santa suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13626,
            "Santa's little helper suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13037, "Skeleton suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13038, "Captain's coat"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13194, "Alefgard armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13080, "Midenhall garb"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13290, "Aliahan clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13099, "Zenithian clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13695, "Zenithian leotard"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13291, "Gothan robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13097, "Somnia clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13098, "Estard clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13096, "Trodain togs"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13491, "Cannock cloak"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13513, "Moonbrooke dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13193, "Ragnar's armour"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13696, "Alena's dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13316, "Kiryl's clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13317, "Borya's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13318, "Torneko's clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13615, "Maya's outfit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13514, "Meena's robe"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13616, "Bianca's clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13515, "Nera's dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13621, "Debora's dress"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13025, "Carver's vest"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13516, "Milly's clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13617, "Ashlynn's clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13026, "Kiefer's clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13517, "Maribel's clothes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13320, "Trode's robes"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13027, "Yangus's billy"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13518, "Jessica's frock"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13211, "Templar's togs"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13028, "GUSTO garb"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13619, "Fleurette's frock"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13618, "Stellar suit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13622, "Erinn's outfit"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13623, "Patty's dirndl"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13624, "Sellma's frock"));
        _upperBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.UpperBody, 13034, "Aquila's armour"));
        _alchemyUpperBodyList.Add(_upperBodyList[2]);
        _alchemyUpperBodyList.Add(_upperBodyList[6]);
        _alchemyUpperBodyList.Add(_upperBodyList[8]);
        _alchemyUpperBodyList.Add(_upperBodyList[9]);
        _alchemyUpperBodyList.Add(_upperBodyList[10]);
        _alchemyUpperBodyList.Add(_upperBodyList[11]);
        _alchemyUpperBodyList.Add(_upperBodyList[13]);
        _alchemyUpperBodyList.Add(_upperBodyList[14]);
        _alchemyUpperBodyList.Add(_upperBodyList[19]);
        _alchemyUpperBodyList.Add(_upperBodyList[20]);
        _alchemyUpperBodyList.Add(_upperBodyList[22]);
        _alchemyUpperBodyList.Add(_upperBodyList[21]);
        _alchemyUpperBodyList.Add(_upperBodyList[25]);
        _alchemyUpperBodyList.Add(_upperBodyList[29]);
        _alchemyUpperBodyList.Add(_upperBodyList[31]);
        _alchemyUpperBodyList.Add(_upperBodyList[32]);
        _alchemyUpperBodyList.Add(_upperBodyList[35]);
        _alchemyUpperBodyList.Add(_upperBodyList[36]);
        _alchemyUpperBodyList.Add(_upperBodyList[38]);
        _alchemyUpperBodyList.Add(_upperBodyList[39]);
        _alchemyUpperBodyList.Add(_upperBodyList[40]);
        _alchemyUpperBodyList.Add(_upperBodyList[41]);
        _alchemyUpperBodyList.Add(_upperBodyList[42]);
        _alchemyUpperBodyList.Add(_upperBodyList[50]);
        _alchemyUpperBodyList.Add(_upperBodyList[55]);
        _alchemyUpperBodyList.Add(_upperBodyList[60]);
        _alchemyUpperBodyList.Add(_upperBodyList[61]);
        _alchemyUpperBodyList.Add(_upperBodyList[66]);
        _alchemyUpperBodyList.Add(_upperBodyList[67]);
        _alchemyUpperBodyList.Add(_upperBodyList[69]);
        _alchemyUpperBodyList.Add(_upperBodyList[70]);
        _alchemyUpperBodyList.Add(_upperBodyList[71]);
        _alchemyUpperBodyList.Add(_upperBodyList[74]);
        _alchemyUpperBodyList.Add(_upperBodyList[77]);
        _alchemyUpperBodyList.Add(_upperBodyList[79]);
        _alchemyUpperBodyList.Add(_upperBodyList[81]);
        _alchemyUpperBodyList.Add(_upperBodyList[82]);
        _alchemyUpperBodyList.Add(_upperBodyList[83]);
        _alchemyUpperBodyList.Add(_upperBodyList[84]);
        _alchemyUpperBodyList.Add(_upperBodyList[85]);
        _alchemyUpperBodyList.Add(_upperBodyList[88]);
        _alchemyUpperBodyList.Add(_upperBodyList[89]);
        _alchemyUpperBodyList.Add(_upperBodyList[90]);
        _alchemyUpperBodyList.Add(_upperBodyList[91]);
        _alchemyUpperBodyList.Add(_upperBodyList[92]);
        _alchemyUpperBodyList.Add(_upperBodyList[94]);
        _alchemyUpperBodyList.Add(_upperBodyList[95]);
        _alchemyUpperBodyList.Add(_upperBodyList[96]);
        _alchemyUpperBodyList.Add(_upperBodyList[97]);
        _alchemyUpperBodyList.Add(_upperBodyList[100]);
        _alchemyUpperBodyList.Add(_upperBodyList[103]);
        _alchemyUpperBodyList.Add(_upperBodyList[104]);
        _alchemyUpperBodyList.Add(_upperBodyList[106]);
        _alchemyUpperBodyList.Add(_upperBodyList[109]);
        _alchemyUpperBodyList.Add(_upperBodyList[114]);
        _alchemyUpperBodyList.Add(_upperBodyList[116]);
        _alchemyUpperBodyList.Add(_upperBodyList[120]);
        _alchemyUpperBodyList.Add(_upperBodyList[125]);
        _alchemyUpperBodyList.Add(_upperBodyList[126]);
        _alchemyUpperBodyList.Add(_upperBodyList[sbyte.MaxValue]);
        _alchemyUpperBodyList.Add(_upperBodyList[122]);
        _alchemyUpperBodyList.Add(_upperBodyList[123]);
        _alchemyUpperBodyList.Add(_upperBodyList[124]);
        _alchemyUpperBodyList.Add(_upperBodyList[129]);
        _alchemyUpperBodyList.Add(_upperBodyList[130]);
        _alchemyUpperBodyList.Add(_upperBodyList[132]);
        _alchemyUpperBodyList.Add(_upperBodyList[133]);
        _alchemyUpperBodyList.Add(_upperBodyList[134]);
        _alchemyUpperBodyList.Add(_upperBodyList[135]);
        _alchemyUpperBodyList.Add(_upperBodyList[136]);
    }

    private static void InitializeArmDataList(ref int dataIndex)
    {
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15200, "Leather gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15291, "Iron gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 359, true, ItemType.Arm, 15293, "Steel gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 360, true, ItemType.Arm, 15294, "Gigasteel gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15033, "Silver bracelets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15298, "Magic mittens"));
        _armList.Add(new ItemDataBase(dataIndex++, 361, true, ItemType.Arm, 15299, "Enchanted gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, 362, true, ItemType.Arm, 15280, "Ethereal gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15102, "Femiscyran fingerwear"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15101, "Bruiser's bracers"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15286, "Dragon warrior gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15105, "Light gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 363, true, ItemType.Arm, 15107, "Sturdy gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 364, true, ItemType.Arm, 15108, "Heavy gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15103, "Metallic mitts"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15043, "Battler's bracers"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15007, "Riotous wristbands"));
        _armList.Add(new ItemDataBase(dataIndex++, 365, true, ItemType.Arm, 15008, "Blessed bindings"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15295, "Metal slime gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 366, true, ItemType.Arm, 15296, "Liquid metal slime gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, 367, true, ItemType.Arm, 15297, "Metal king slime gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15281, "Rusty gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 368, true, ItemType.Arm, 15292, "Erdrick's gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 369, true, ItemType.Arm, 15282, "Vesta gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 370, true, ItemType.Arm, 15283, "Diana gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 371, true, ItemType.Arm, 15284, "Tempestes gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 372, false, ItemType.Arm, 15285, "Sol Invictus gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15003, "Cotton gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15004, "Linen gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, 373, true, ItemType.Arm, 15005, "Leather gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15009, "Rubber gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15010, "Wayfarer's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15039, "Ultramarine mittens"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15000, "Warrior's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15048, "Lockpicker's mitts"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15100, "Fingerless gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15106, "Archer's armguard"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15001, "Gorgeous gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15002, "Mental mittens"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15045, "Einhänder"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15013, "Mayoress's mittens"));
        _armList.Add(new ItemDataBase(dataIndex++, 374, true, ItemType.Arm, 15014, "Marquess's mittens"));
        _armList.Add(new ItemDataBase(dataIndex++, 375, true, ItemType.Arm, 15015, "Monarch's mittens"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15032, "Heavy handwear"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15016, "Veteran's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15017, "Enchantress's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15018, "Minister's mittens"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15109, "Fingerless gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15019, "Glommer's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, 376, true, ItemType.Arm, 15020, "Guru's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15047, "Crimson gauntlets"));
        _armList.Add(new ItemDataBase(dataIndex++, 377, true, ItemType.Arm, 15021, "Gloomy gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, 378, true, ItemType.Arm, 15022, "Murky mittens"));
        _armList.Add(new ItemDataBase(dataIndex++, 379, true, ItemType.Arm, 15023, "Matador's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, 380, true, ItemType.Arm, 15024, "Apprentice's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, 381, true, ItemType.Arm, 15025, "Master's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, 382, true, ItemType.Arm, 15026, "Grandmaster's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, 383, false, ItemType.Arm, 15027, "Godly gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15092, "Alefgard gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15093, "Midenhall gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15095, "Aliahan gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15028, "Zenithian gauntlet"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15029, "Gothan wristbands"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15190, "Somnia gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15094, "Cannock gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15096, "McRyan's mittens"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15097, "Alena's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15030, "Maya's bracelets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15031, "Meena's bracelets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15034, "Bianca's bracelets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15035, "Nera's bracelets"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15036, "Carver's bracers"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15037, "Milly's bracers"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15038, "Ashlynn's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15091, "Kiefer's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15040, "Blindin' bracers"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15041, "Angelo's gloves"));
        _armList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Arm, 15042, "Grandissimo gloves"));
        _alchemyArmList.Add(_armList[2]);
        _alchemyArmList.Add(_armList[3]);
        _alchemyArmList.Add(_armList[6]);
        _alchemyArmList.Add(_armList[7]);
        _alchemyArmList.Add(_armList[12]);
        _alchemyArmList.Add(_armList[13]);
        _alchemyArmList.Add(_armList[17]);
        _alchemyArmList.Add(_armList[19]);
        _alchemyArmList.Add(_armList[20]);
        _alchemyArmList.Add(_armList[22]);
        _alchemyArmList.Add(_armList[23]);
        _alchemyArmList.Add(_armList[24]);
        _alchemyArmList.Add(_armList[25]);
        _alchemyArmList.Add(_armList[26]);
        _alchemyArmList.Add(_armList[29]);
        _alchemyArmList.Add(_armList[41]);
        _alchemyArmList.Add(_armList[42]);
        _alchemyArmList.Add(_armList[49]);
        _alchemyArmList.Add(_armList[51]);
        _alchemyArmList.Add(_armList[52]);
        _alchemyArmList.Add(_armList[53]);
        _alchemyArmList.Add(_armList[54]);
        _alchemyArmList.Add(_armList[55]);
        _alchemyArmList.Add(_armList[56]);
        _alchemyArmList.Add(_armList[57]);
    }

    private static void InitializeLowerBodyDataList(ref int dataIndex)
    {
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16094, "Boxer shorts"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 284, true, ItemType.LowerBody, 16095, "Leather kilt"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16213, "Cotton trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16307, "Red skirt"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16308, "Blue skirt"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16309, "Kiltlet"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16316, "Springtime skirt"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16317, "Snazzy skirt"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16318, "Magical skirt"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16319, "Seabreeze skirt"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16258, "Swinedimples slacks"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16306, "Swinedimples skirt"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16214, "Training trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 285, true, ItemType.LowerBody, 16255, "Tracky bottoms"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16104, "Pop socks"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16302, "Fishnet stockings"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 286, true, ItemType.LowerBody, 16216, "Boomer briefs"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 287, true, ItemType.LowerBody, 16217, "Wonder pants"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16312, "Blue knickers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16313, "Black knickers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16218, "Iron kneecaps"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 288, true, ItemType.LowerBody, 16219, "Steel kneecaps"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 289, true, ItemType.LowerBody, 16220, "Gigasteel kneecaps"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16200, "Warrior's trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16100, "Femiscyran bottoms"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16204, "Wizard's trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 292, true, ItemType.LowerBody, 16211, "Blessed bottoms"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16300, "Sorcerer's slacks"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 293, true, ItemType.LowerBody, 16203, "Tussler's trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16301, "Slick slacks"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16202, "Nicker's knickers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16205, "Loud trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 294, true, ItemType.LowerBody, 16221, "Fancy pants"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16263, "Blue jeans"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16311, "Denim skirt"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16206, "Battle britches"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 295, true, ItemType.LowerBody, 16103, "Chainmail socks"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16207, "Swordsman's slacks"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16210, "Steppe steppers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 296, true, ItemType.LowerBody, 16208, "Red tights"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 297, true, ItemType.LowerBody, 16209, "Green tights"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 298, true, ItemType.LowerBody, 16212, "White tights"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 299, true, ItemType.LowerBody, 16222, "Transparent tights"));
        _lowerBodyList.Add(
            new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16303, "Dangerous midriff wrap"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 290, true, ItemType.LowerBody, 16304, "Hot bikini bottoms"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 291, true, ItemType.LowerBody, 16305,
            "Sizzling bikini bottoms"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16256,
            "Dragon warrior trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 300, true, ItemType.LowerBody, 16223, "Dragon trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16283, "Trinity tights"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16224, "Combat trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 301, true, ItemType.LowerBody, 16228, "Tantric trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16229, "Sturdy slacks"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 302, true, ItemType.LowerBody, 16230, "Impregnable leggings"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 303, true, ItemType.LowerBody, 16231, "Invincible trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 304, true, ItemType.LowerBody, 16232, "Immortal trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 305, true, ItemType.LowerBody, 16233, "Eternity trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, 306, false, ItemType.LowerBody, 16234, "Infinity trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16251, "Toughie trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16215, "Celestial stockings"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16259,
            "White tuxedo trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16260, "Santa's slacks"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16261, "Skeletal slacks"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16262, "Pirate pantaloons"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16287, "Alefgard trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16286, "Midenhall trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16288, "Aliahan trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16289, "Zenithian trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16191, "Zenithian leggings"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16093, "Somnia shorts"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16290, "Estard trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16291, "Trodain trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16235, "Cannock trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16390, "Alena's tights"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16236, "Kiryl's trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16237, "Torneko's trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16310, "Maya's bottoms"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16240, "Carver's shorts"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16241, "Milly's pants"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16243, "Kiefer's trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16244, "Cor blimey trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16252, "Templar's trousers"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16245, "PASSION tights"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16248,
            "Fleurette's chaussettes"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16246, "Stellar stockings"));
        _lowerBodyList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.LowerBody, 16257, "Aquila's trousers"));
        _alchemyLowerBodyList.Add(_lowerBodyList[1]);
        _alchemyLowerBodyList.Add(_lowerBodyList[13]);
        _alchemyLowerBodyList.Add(_lowerBodyList[16]);
        _alchemyLowerBodyList.Add(_lowerBodyList[17]);
        _alchemyLowerBodyList.Add(_lowerBodyList[21]);
        _alchemyLowerBodyList.Add(_lowerBodyList[22]);
        _alchemyLowerBodyList.Add(_lowerBodyList[44]);
        _alchemyLowerBodyList.Add(_lowerBodyList[45]);
        _alchemyLowerBodyList.Add(_lowerBodyList[26]);
        _alchemyLowerBodyList.Add(_lowerBodyList[28]);
        _alchemyLowerBodyList.Add(_lowerBodyList[32]);
        _alchemyLowerBodyList.Add(_lowerBodyList[36]);
        _alchemyLowerBodyList.Add(_lowerBodyList[39]);
        _alchemyLowerBodyList.Add(_lowerBodyList[40]);
        _alchemyLowerBodyList.Add(_lowerBodyList[41]);
        _alchemyLowerBodyList.Add(_lowerBodyList[42]);
        _alchemyLowerBodyList.Add(_lowerBodyList[47]);
        _alchemyLowerBodyList.Add(_lowerBodyList[50]);
        _alchemyLowerBodyList.Add(_lowerBodyList[52]);
        _alchemyLowerBodyList.Add(_lowerBodyList[53]);
        _alchemyLowerBodyList.Add(_lowerBodyList[54]);
        _alchemyLowerBodyList.Add(_lowerBodyList[55]);
        _alchemyLowerBodyList.Add(_lowerBodyList[56]);
    }

    private static void InitializeShoeDataList(ref int dataIndex)
    {
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17118, "Leather boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 384, true, ItemType.Shoe, 17195, "Hobnail boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17119, "Wellington boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17391, "Iron sabatons"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 385, true, ItemType.Shoe, 17395, "Steel sabatons"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 386, true, ItemType.Shoe, 17396, "Gigasteel sabatons"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17100, "Warrior's boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17108, "Femiscyran footwear"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17101, "Frugal footwear"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17105, "Wizard wellies"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17102, "Bandit boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17106, "Acroboots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 387, true, ItemType.Shoe, 17300, "Payback pumps"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17109, "Cowboy boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17110, "Hip boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17302, "Saintly sollerets"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17112, "Clever clogs"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17117, "Crimson boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17114, "Agiliboots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17115, "Hiking boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17303, "Dragon warrior boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17103, "Sneakers"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17196, "Veteran's boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17198, "She-mage shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17199, "Blessed boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17197, "Combat boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 388, true, ItemType.Shoe, 17181, "Brahman boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17394, "Metal slime sollerets"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 389, true, ItemType.Shoe, 17397, "Liquid metal slime boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 390, true, ItemType.Shoe, 17398, "Metal king slime boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 391, true, ItemType.Shoe, 17182, "Hero's boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 392, true, ItemType.Shoe, 17183, "Basilic boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 393, true, ItemType.Shoe, 17184, "Emperor's boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 394, false, ItemType.Shoe, 17185, "Boots of beatitude"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17406, "Sandals"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17404, "Leather shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17408, "High heels"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 396, true, ItemType.Shoe, 17409, "Stiletto heels"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 397, true, ItemType.Shoe, 17410, "Highness heels"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17405, "Clogs"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 395, true, ItemType.Shoe, 17407, "Classy clogs"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17411, "Galvanised geta"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17402, "Sheepskin shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17400, "Siren sandals"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 398, true, ItemType.Shoe, 17412, "Sorceress sandals"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17403, "Starlet sandals"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17104, "Kung fu shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 399, true, ItemType.Shoe, 17107, "Wu shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17401, "She-fu shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17111, "Safety shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 400, true, ItemType.Shoe, 17186, "Safer shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 401, true, ItemType.Shoe, 17187, "Safest shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17113, "Shaman shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17116, "Bardic boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17159, "Spellspadrilles"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17188, "Depressing shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 402, true, ItemType.Shoe, 17189, "Elevating shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 403, true, ItemType.Shoe, 17170, "Pixie boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 404, true, ItemType.Shoe, 17171, "Tricksie boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 405, true, ItemType.Shoe, 17414, "Sensible sandles"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 406, true, ItemType.Shoe, 17415, "Sagacious sandles"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 407, true, ItemType.Shoe, 17416, "Sapient sandals"));
        _shoeList.Add(new ItemDataBase(dataIndex++, 408, false, ItemType.Shoe, 17417, "Sentient sandals"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17155, "Thug boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17120, "Celestial shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17143, "White wing-tips"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17413, "High-class heels"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17192, "Alefgard boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17193, "Midenhall boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17095, "Aliahan boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17094, "Zenithian boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17091, "Gothan gumboots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17092, "Somnia boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17093, "Estard shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17096, "Trodainers"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17194, "Cannock boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17172, "Moonbrooke shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17392, "Highland boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17191, "Valenki"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17173, "Kiryl's boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17158, "Borya's boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17419, "Torneko's sandals"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17420, "Sattriya sandals"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17421, "Samhita sandals"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17176, "Bianca's boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17177, "Nera's boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17178, "Carver's shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17179, "Milly's shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17160, "Ashlynn's shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17163, "Kiefer's shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17164, "Maribel's shoes"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17165, "Trode's treads"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17166, "Bovver boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17167, "Posh pumps"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17168, "Templar boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17169, "Casanova clogs"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17152, "Chic chaussures"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17150, "Blahnolo Maniks"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17140, "Erinn's boots"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17141, "Patty's pumps"));
        _shoeList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Shoe, 17142, "Aquila's boots"));
        _alchemyShoeList.Add(_shoeList[1]);
        _alchemyShoeList.Add(_shoeList[4]);
        _alchemyShoeList.Add(_shoeList[5]);
        _alchemyShoeList.Add(_shoeList[12]);
        _alchemyShoeList.Add(_shoeList[26]);
        _alchemyShoeList.Add(_shoeList[28]);
        _alchemyShoeList.Add(_shoeList[29]);
        _alchemyShoeList.Add(_shoeList[30]);
        _alchemyShoeList.Add(_shoeList[31]);
        _alchemyShoeList.Add(_shoeList[32]);
        _alchemyShoeList.Add(_shoeList[33]);
        _alchemyShoeList.Add(_shoeList[40]);
        _alchemyShoeList.Add(_shoeList[37]);
        _alchemyShoeList.Add(_shoeList[38]);
        _alchemyShoeList.Add(_shoeList[44]);
        _alchemyShoeList.Add(_shoeList[47]);
        _alchemyShoeList.Add(_shoeList[50]);
        _alchemyShoeList.Add(_shoeList[51]);
        _alchemyShoeList.Add(_shoeList[56]);
        _alchemyShoeList.Add(_shoeList[57]);
        _alchemyShoeList.Add(_shoeList[58]);
        _alchemyShoeList.Add(_shoeList[59]);
        _alchemyShoeList.Add(_shoeList[60]);
        _alchemyShoeList.Add(_shoeList[61]);
        _alchemyShoeList.Add(_shoeList[62]);
    }

    private static void InitializeAccessoryDataList(ref int dataIndex)
    {
        _accessoryList.Add(new ItemDataBase(dataIndex++, 409, true, ItemType.Accessory, 18000, "Strength ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 410, true, ItemType.Accessory, 18001, "Tough guy tattoo"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 411, true, ItemType.Accessory, 18002, "Raging ruby"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 412, true, ItemType.Accessory, 18003, "Mighty armlet"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18007, "Gold ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18004, "Gold bracer"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 413, true, ItemType.Accessory, 18005, "Slime earrings"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18006, "Dragon scale"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 414, true, ItemType.Accessory, 18008, "Ruby of protection"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18009, "Bunny tail"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 416, true, ItemType.Accessory, 18012, "Utility belt"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 417, true, ItemType.Accessory, 18013, "Agility ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 418, true, ItemType.Accessory, 18014, "Meteorite bracer"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 419, true, ItemType.Accessory, 18015, "Sorcerer's ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18016, "Gold rosary"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 420, true, ItemType.Accessory, 18017, "Rosary"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18018, "Sorcerer's stone"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 421, true, ItemType.Accessory, 18019, "Brainy bracer"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 424, true, ItemType.Accessory, 18022, "Monarchic mark"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 422, true, ItemType.Accessory, 18020, "Life bracer"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 423, true, ItemType.Accessory, 18021, "Spirit bracer"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 425, true, ItemType.Accessory, 18023, "Prayer ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 426, true, ItemType.Accessory, 18024, "Holy talisman"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 427, true, ItemType.Accessory, 18025, "Sober ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 428, true, ItemType.Accessory, 18026, "Contra band"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 429, true, ItemType.Accessory, 18027, "Full moon ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 430, true, ItemType.Accessory, 18028, "Rousing ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 431, true, ItemType.Accessory, 18029, "Ring of clarity"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 432, true, ItemType.Accessory, 18030, "Catholicon ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18055, "Wedding ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 434, true, ItemType.Accessory, 18033, "Elfin charm"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 435, true, ItemType.Accessory, 18034, "Life ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 436, true, ItemType.Accessory, 18035, "Goddess ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18031, "Terrible tattoo"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 433, true, ItemType.Accessory, 18032, "Skull ring"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 437, true, ItemType.Accessory, 18038, "Reckless necklace"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 438, true, ItemType.Accessory, 18039, "Lucky pendant"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18010, "Pink pearl"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, 415, true, ItemType.Accessory, 18011, "Bow tie"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18040, "Venus's tear"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18043, "Soldier's medal"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18044, "Lifesaving medal"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18045, "Mager achievement"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18046, "Mercury prize"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18047, "Honour among thieves"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18048, "Wear-with-all award"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18049, "Critical acclaim"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18050, "Order of chivalry"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18051, "Combat action medal"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18052, "Medal of freedom"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18053, "Legion of merit"));
        _accessoryList.Add(new ItemDataBase(dataIndex++, -1, false, ItemType.Accessory, 18054, "Noscar"));
        _alchemyAccessoryList.Add(_accessoryList[0]);
        _alchemyAccessoryList.Add(_accessoryList[1]);
        _alchemyAccessoryList.Add(_accessoryList[2]);
        _alchemyAccessoryList.Add(_accessoryList[3]);
        _alchemyAccessoryList.Add(_accessoryList[6]);
        _alchemyAccessoryList.Add(_accessoryList[8]);
        _alchemyAccessoryList.Add(_accessoryList[38]);
        _alchemyAccessoryList.Add(_accessoryList[10]);
        _alchemyAccessoryList.Add(_accessoryList[11]);
        _alchemyAccessoryList.Add(_accessoryList[12]);
        _alchemyAccessoryList.Add(_accessoryList[13]);
        _alchemyAccessoryList.Add(_accessoryList[15]);
        _alchemyAccessoryList.Add(_accessoryList[17]);
        _alchemyAccessoryList.Add(_accessoryList[19]);
        _alchemyAccessoryList.Add(_accessoryList[20]);
        _alchemyAccessoryList.Add(_accessoryList[18]);
        _alchemyAccessoryList.Add(_accessoryList[21]);
        _alchemyAccessoryList.Add(_accessoryList[22]);
        _alchemyAccessoryList.Add(_accessoryList[23]);
        _alchemyAccessoryList.Add(_accessoryList[24]);
        _alchemyAccessoryList.Add(_accessoryList[25]);
        _alchemyAccessoryList.Add(_accessoryList[26]);
        _alchemyAccessoryList.Add(_accessoryList[27]);
        _alchemyAccessoryList.Add(_accessoryList[28]);
        _alchemyAccessoryList.Add(_accessoryList[34]);
        _alchemyAccessoryList.Add(_accessoryList[30]);
        _alchemyAccessoryList.Add(_accessoryList[31]);
        _alchemyAccessoryList.Add(_accessoryList[32]);
        _alchemyAccessoryList.Add(_accessoryList[35]);
        _alchemyAccessoryList.Add(_accessoryList[36]);
    }

    public static ItemDataBase[] GetList(ItemType itemType, string search)
    {
        var list = GetList(itemType);
        if (list == null)
            return null;
        if (search == null)
            return list.ToArray();
        var regex = new Regex(search, RegexOptions.IgnoreCase);
        var itemDataBaseList = new List<ItemDataBase>();
        foreach (var itemDataBase in list)
            if (regex.IsMatch(itemDataBase.Name))
                itemDataBaseList.Add(itemDataBase);
        return itemDataBaseList.ToArray();
    }

    private static List<ItemDataBase> GetList(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Tool:
                return _toolList;
            case ItemType.important:
                return _importantList;
            case ItemType.Weapon:
                return _weaponList;
            case ItemType.Shield:
                return _shieldList;
            case ItemType.Head:
                return _headList;
            case ItemType.UpperBody:
                return _upperBodyList;
            case ItemType.Arm:
                return _armList;
            case ItemType.LowerBody:
                return _lowerBodyList;
            case ItemType.Shoe:
                return _shoeList;
            case ItemType.Accessory:
                return _accessoryList;
            default:
                return null;
        }
    }

    public static ItemDataBase[] GetAllCollectionList()
    {
        var itemDataBaseList = new List<ItemDataBase>();
        itemDataBaseList.AddRange(_toolList);
        itemDataBaseList.RemoveAt(itemDataBaseList.Count - 1);
        itemDataBaseList.RemoveAt(itemDataBaseList.Count - 1);
        itemDataBaseList.AddRange(_importantList);
        return itemDataBaseList.ToArray();
    }

    public static ItemDataBase[] GetAllSmartList()
    {
        var itemDataBaseList = new List<ItemDataBase>();
        itemDataBaseList.AddRange(_weaponList);
        itemDataBaseList.AddRange(_shieldList);
        itemDataBaseList.AddRange(_headList);
        itemDataBaseList.AddRange(_upperBodyList);
        itemDataBaseList.AddRange(_armList);
        itemDataBaseList.AddRange(_lowerBodyList);
        itemDataBaseList.AddRange(_shoeList);
        itemDataBaseList.AddRange(_accessoryList);
        return itemDataBaseList.ToArray();
    }

    public static ItemDataBase[] GetAlchemyList(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Tool:
                return _alchemyToolList.ToArray();
            case ItemType.Weapon:
                return _alchemyWeaponList.ToArray();
            case ItemType.Shield:
                return _alchemyShieldList.ToArray();
            case ItemType.Head:
                return _alchemyHeadList.ToArray();
            case ItemType.UpperBody:
                return _alchemyUpperBodyList.ToArray();
            case ItemType.Arm:
                return _alchemyArmList.ToArray();
            case ItemType.LowerBody:
                return _alchemyLowerBodyList.ToArray();
            case ItemType.Shoe:
                return _alchemyShoeList.ToArray();
            case ItemType.Accessory:
                return _alchemyAccessoryList.ToArray();
            default:
                return null;
        }
    }

    public static ItemDataBase[] GetAlchemyWeaponList(WeaponType weaponType)
    {
        var itemDataBaseList = new List<ItemDataBase>();
        foreach (var alchemyWeapon in _alchemyWeaponList)
            if (alchemyWeapon.WeaponType == weaponType)
                itemDataBaseList.Add(alchemyWeapon);
        return itemDataBaseList.ToArray();
    }

    public static ItemDataBase[] GetAllAlchemyList()
    {
        var itemDataBaseList = new List<ItemDataBase>();
        itemDataBaseList.AddRange(_alchemyWeaponList);
        itemDataBaseList.AddRange(_alchemyShieldList);
        itemDataBaseList.AddRange(_alchemyHeadList);
        itemDataBaseList.AddRange(_alchemyUpperBodyList);
        itemDataBaseList.AddRange(_alchemyArmList);
        itemDataBaseList.AddRange(_alchemyLowerBodyList);
        itemDataBaseList.AddRange(_alchemyShoeList);
        itemDataBaseList.AddRange(_alchemyAccessoryList);
        itemDataBaseList.AddRange(_alchemyToolList);
        return itemDataBaseList.ToArray();
    }

    public static ItemDataBase[] GetWeaponList(WeaponType weaponType)
    {
        var itemDataBaseList = new List<ItemDataBase>();
        foreach (var weapon in _weaponList)
            if (weapon.WeaponType == weaponType)
                itemDataBaseList.Add(weapon);
        return itemDataBaseList.ToArray();
    }

    public static ItemDataBase GetItem(ItemType itemType, ushort itemValue)
    {
        var list = GetList(itemType);
        if (list != null)
            foreach (var itemDataBase in list)
                if (itemDataBase.Value == itemValue)
                    return itemDataBase;
        return null;
    }

    public static ItemDataBase GetItem(ushort itemValue)
    {
        for (var index = 0; index < 10; ++index)
        {
            var list = GetList((ItemType)index);
            if (list != null)
                foreach (var itemDataBase in list)
                    if (itemDataBase.Value == itemValue)
                        return itemDataBase;
        }

        return null;
    }

    public static ItemDataBase GetSmartItemFromIndex(int dataIndex)
    {
        dataIndex -= 7;
        var num = 0;
        for (var itemType = ItemType.Weapon; itemType < ItemType.MAX; ++itemType)
        {
            var list = GetList(itemType);
            num += list.Count;
            if (num > dataIndex)
                foreach (var smartItemFromIndex in list)
                    if (smartItemFromIndex.DataIndex == dataIndex)
                        return smartItemFromIndex;
        }

        return null;
    }
}