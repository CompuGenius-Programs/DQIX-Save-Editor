// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchDungeonData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.MapSearch;

public class SearchDungeonData
{
    private readonly byte[] _byteData;

    public SearchDungeonData(int index, byte[] byteData, ushort seed, byte rank)
    {
        Index = index;
        Seed = seed;
        Rank = rank;
        _byteData = byteData;
    }

    public static int Size => 12;

    public int Index { get; }

    public ushort Seed { get; }

    public byte Rank { get; }

    public string MapName => string.Format("{0} {2} of {1} Lv. {3:D}",
        TreasureMapDataTable.TreasureMapName1_Table[MapName1Index],
        TreasureMapDataTable.TreasureMapName2_Table[MapName2Index],
        TreasureMapDataTable.TreasureMapName3_Table[MapName3Index], MapLevel);

    public byte MapName1Index
    {
        get => (byte)(_byteData[Index] & 15U);
        set => _byteData[Index] = (byte)((_byteData[Index] & 240) | (value & 15));
    }

    public string MapName1 => TreasureMapDataTable.TreasureMapName1_Table[MapName1Index];

    public byte MapName2Index
    {
        get => (byte)((_byteData[Index] & 240) >> 4);
        set => _byteData[Index] = (byte)((_byteData[Index] & 15) | ((value << 4) & 240));
    }

    public string MapName2 => TreasureMapDataTable.TreasureMapName2_Table[MapName2Index];

    public byte MapName3Index
    {
        get => (byte)(_byteData[Index + 1] & 31U);
        set => _byteData[Index + 1] = (byte)((_byteData[Index + 1] & 224) | (value & 31));
    }

    public string MapName3 => TreasureMapDataTable.TreasureMapName3_Table[MapName3Index];

    public byte MapType
    {
        get => (byte)((_byteData[Index + 1] & 224) >> 5);
        set => _byteData[Index + 1] = (byte)((_byteData[Index + 1] & 31) | ((value << 5) & 224));
    }

    public byte MapLevel
    {
        get => _byteData[Index + 2];
        set => _byteData[Index + 2] = value;
    }

    public byte MonsterRank
    {
        get => (byte)(_byteData[Index + 3] & 15U);
        set => _byteData[Index + 3] = (byte)((_byteData[Index + 3] & 240) | (value & 15));
    }

    public byte Boss
    {
        get => (byte)((_byteData[Index + 3] >> 4) & 15);
        set => _byteData[Index + 3] = (byte)((_byteData[Index + 3] & 15) | ((value << 4) & 240));
    }

    public byte Depth
    {
        get => (byte)((_byteData[Index + 4] & 15) + 1);
        set => _byteData[Index + 4] = (byte)((_byteData[Index + 4] & 240) | ((value - 1) & 15));
    }

    public unsafe byte SBoxCount
    {
        get
        {
            fixed (byte* numPtr = &_byteData[Index + 4])
            {
                return (byte)((*(ushort*)numPtr & 496) >> 4);
            }
        }
        set
        {
            fixed (byte* numPtr = &_byteData[Index + 4])
            {
                *(short*)numPtr = (short)(ushort)((*(ushort*)numPtr & 65039) | (value << 4));
            }
        }
    }

    public byte ABoxCount
    {
        get => (byte)((_byteData[Index + 5] & 62) >> 1);
        set => _byteData[Index + 5] = (byte)((_byteData[Index + 5] & 193) | (value << 1));
    }

    public unsafe byte BBoxCount
    {
        get
        {
            fixed (byte* numPtr = &_byteData[Index + 5])
            {
                return (byte)((*(ushort*)numPtr & 1984) >> 6);
            }
        }
        set
        {
            fixed (byte* numPtr = &_byteData[Index + 5])
            {
                *(short*)numPtr = (short)(ushort)((*(ushort*)numPtr & 63551) | (value << 6));
            }
        }
    }

    public byte CBoxCount
    {
        get => (byte)((_byteData[Index + 6] & 248) >> 3);
        set => _byteData[Index + 6] = (byte)((_byteData[Index + 6] & 7) | (value << 3));
    }

    public byte DBoxCount
    {
        get => (byte)(_byteData[Index + 7] & 31U);
        set => _byteData[Index + 7] = (byte)((_byteData[Index + 7] & 224U) | value);
    }

    public unsafe byte EBoxCount
    {
        get
        {
            fixed (byte* numPtr = &_byteData[Index + 7])
            {
                return (byte)((*(ushort*)numPtr & 992) >> 5);
            }
        }
        set
        {
            fixed (byte* numPtr = &_byteData[Index + 7])
            {
                *(short*)numPtr = (short)(ushort)((*(ushort*)numPtr & 64543) | (value << 5));
            }
        }
    }

    public byte FBoxCount
    {
        get => (byte)((_byteData[Index + 8] & 124) >> 2);
        set => _byteData[Index + 8] = (byte)((_byteData[Index + 8] & 131) | (value << 2));
    }

    public unsafe byte GBoxCount
    {
        get
        {
            fixed (byte* numPtr = &_byteData[Index + 8])
            {
                return (byte)((*(ushort*)numPtr & 3968) >> 7);
            }
        }
        set
        {
            fixed (byte* numPtr = &_byteData[Index + 8])
            {
                *(short*)numPtr = (short)(ushort)((*(ushort*)numPtr & 61567) | (value << 7));
            }
        }
    }

    public unsafe byte HBoxCount
    {
        get
        {
            fixed (byte* numPtr = &_byteData[Index + 9])
            {
                return (byte)((*(ushort*)numPtr & 496) >> 4);
            }
        }
        set
        {
            fixed (byte* numPtr = &_byteData[Index + 9])
            {
                *(short*)numPtr = (short)(ushort)((*(ushort*)numPtr & 65039) | (value << 4));
            }
        }
    }

    public byte IBoxCount
    {
        get => (byte)((_byteData[Index + 10] & 62) >> 1);
        set => _byteData[Index + 10] = (byte)((_byteData[Index + 10] & 193) | (value << 1));
    }

    public byte TotalBoxCount => (byte)(SBoxCount + (uint)ABoxCount + BBoxCount + CBoxCount + DBoxCount + EBoxCount +
                                        FBoxCount + GBoxCount + HBoxCount + IBoxCount);

    public byte OnlyMonster
    {
        get => _byteData[Index + 11];
        set => _byteData[Index + 11] = value;
    }

    internal void Calculate(TreasureMapDetailData treasureMapDetailData)
    {
        treasureMapDetailData.MapSeed = Seed;
        treasureMapDetailData.MapRank = Rank;
        treasureMapDetailData.CalculateDetail(true, true);
        MapName1Index = treasureMapDetailData.MapName1Index;
        MapName2Index = treasureMapDetailData.MapName2Index;
        MapName3Index = treasureMapDetailData.MapName3Index;
        MapType = treasureMapDetailData.MapTypeIndex;
        MapLevel = (byte)treasureMapDetailData.MapLevel;
        MonsterRank = (byte)treasureMapDetailData.MonsterRank;
        Boss = treasureMapDetailData.BossIndex;
        Depth = (byte)treasureMapDetailData.FloorCount;
        SBoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(10);
        ABoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(9);
        BBoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(8);
        CBoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(7);
        DBoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(6);
        EBoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(5);
        FBoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(4);
        GBoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(3);
        HBoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(2);
        IBoxCount = (byte)treasureMapDetailData.GetTreasureBoxCount(1);
        OnlyMonster = 0;
    }
}