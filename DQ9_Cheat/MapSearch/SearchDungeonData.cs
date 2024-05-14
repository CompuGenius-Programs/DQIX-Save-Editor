// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchDungeonData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchDungeonData
  {
    private int _index;
    private ushort _seed;
    private byte _rank;
    private byte[] _byteData;

    public SearchDungeonData(int index, byte[] byteData, ushort seed, byte rank)
    {
      this._index = index;
      this._seed = seed;
      this._rank = rank;
      this._byteData = byteData;
    }

    public static int Size => 12;

    public int Index => this._index;

    public ushort Seed => this._seed;

    public byte Rank => this._rank;

    internal void Calculate(TreasureMapDetailData treasureMapDetailData)
    {
      treasureMapDetailData.MapSeed = this._seed;
      treasureMapDetailData.MapRank = this._rank;
      treasureMapDetailData.CalculateDetail(true, true);
      this.MapName1Index = treasureMapDetailData.MapName1Index;
      this.MapName2Index = treasureMapDetailData.MapName2Index;
      this.MapName3Index = treasureMapDetailData.MapName3Index;
      this.MapType = treasureMapDetailData.MapTypeIndex;
      this.MapLevel = (byte) treasureMapDetailData.MapLevel;
      this.MonsterRank = (byte) treasureMapDetailData.MonsterRank;
      this.Boss = treasureMapDetailData.BossIndex;
      this.Depth = (byte) treasureMapDetailData.FloorCount;
      this.SBoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(10);
      this.ABoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(9);
      this.BBoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(8);
      this.CBoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(7);
      this.DBoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(6);
      this.EBoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(5);
      this.FBoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(4);
      this.GBoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(3);
      this.HBoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(2);
      this.IBoxCount = (byte) treasureMapDetailData.GetTreasureBoxCount(1);
      this.OnlyMonster = (byte) 0;
    }

    public string MapName
    {
      get
      {
        return string.Format("{0} {2} of {1} Lv. {3:D}", (object) TreasureMapDataTable.TreasureMapName1_Table[(int) this.MapName1Index], (object) TreasureMapDataTable.TreasureMapName2_Table[(int) this.MapName2Index], (object) TreasureMapDataTable.TreasureMapName3_Table[(int) this.MapName3Index], (object) this.MapLevel);
      }
    }

    public byte MapName1Index
    {
      get => (byte) ((uint) this._byteData[this._index] & 15U);
      set
      {
        this._byteData[this._index] = (byte) ((int) this._byteData[this._index] & 240 | (int) value & 15);
      }
    }

    public string MapName1 => TreasureMapDataTable.TreasureMapName1_Table[(int) this.MapName1Index];

    public byte MapName2Index
    {
      get => (byte) (((int) this._byteData[this._index] & 240) >> 4);
      set
      {
        this._byteData[this._index] = (byte) ((int) this._byteData[this._index] & 15 | (int) value << 4 & 240);
      }
    }

    public string MapName2 => TreasureMapDataTable.TreasureMapName2_Table[(int) this.MapName2Index];

    public byte MapName3Index
    {
      get => (byte) ((uint) this._byteData[this._index + 1] & 31U);
      set
      {
        this._byteData[this._index + 1] = (byte) ((int) this._byteData[this._index + 1] & 224 | (int) value & 31);
      }
    }

    public string MapName3 => TreasureMapDataTable.TreasureMapName3_Table[(int) this.MapName3Index];

    public byte MapType
    {
      get => (byte) (((int) this._byteData[this._index + 1] & 224) >> 5);
      set
      {
        this._byteData[this._index + 1] = (byte) ((int) this._byteData[this._index + 1] & 31 | (int) value << 5 & 224);
      }
    }

    public byte MapLevel
    {
      get => this._byteData[this._index + 2];
      set => this._byteData[this._index + 2] = value;
    }

    public byte MonsterRank
    {
      get => (byte) ((uint) this._byteData[this._index + 3] & 15U);
      set
      {
        this._byteData[this._index + 3] = (byte) ((int) this._byteData[this._index + 3] & 240 | (int) value & 15);
      }
    }

    public byte Boss
    {
      get => (byte) ((int) this._byteData[this._index + 3] >> 4 & 15);
      set
      {
        this._byteData[this._index + 3] = (byte) ((int) this._byteData[this._index + 3] & 15 | (int) value << 4 & 240);
      }
    }

    public byte Depth
    {
      get => (byte) (((int) this._byteData[this._index + 4] & 15) + 1);
      set
      {
        this._byteData[this._index + 4] = (byte) ((int) this._byteData[this._index + 4] & 240 | (int) value - 1 & 15);
      }
    }

    public unsafe byte SBoxCount
    {
      get
      {
        fixed (byte* numPtr = &this._byteData[this._index + 4])
          return (byte) (((int) *(ushort*) numPtr & 496) >> 4);
      }
      set
      {
        fixed (byte* numPtr = &this._byteData[this._index + 4])
          *(short*) numPtr = (short) (ushort) ((int) *(ushort*) numPtr & 65039 | (int) value << 4);
      }
    }

    public byte ABoxCount
    {
      get => (byte) (((int) this._byteData[this._index + 5] & 62) >> 1);
      set
      {
        this._byteData[this._index + 5] = (byte) ((int) this._byteData[this._index + 5] & 193 | (int) value << 1);
      }
    }

    public unsafe byte BBoxCount
    {
      get
      {
        fixed (byte* numPtr = &this._byteData[this._index + 5])
          return (byte) (((int) *(ushort*) numPtr & 1984) >> 6);
      }
      set
      {
        fixed (byte* numPtr = &this._byteData[this._index + 5])
          *(short*) numPtr = (short) (ushort) ((int) *(ushort*) numPtr & 63551 | (int) value << 6);
      }
    }

    public byte CBoxCount
    {
      get => (byte) (((int) this._byteData[this._index + 6] & 248) >> 3);
      set
      {
        this._byteData[this._index + 6] = (byte) ((int) this._byteData[this._index + 6] & 7 | (int) value << 3);
      }
    }

    public byte DBoxCount
    {
      get => (byte) ((uint) this._byteData[this._index + 7] & 31U);
      set
      {
        this._byteData[this._index + 7] = (byte) ((uint) this._byteData[this._index + 7] & 224U | (uint) value);
      }
    }

    public unsafe byte EBoxCount
    {
      get
      {
        fixed (byte* numPtr = &this._byteData[this._index + 7])
          return (byte) (((int) *(ushort*) numPtr & 992) >> 5);
      }
      set
      {
        fixed (byte* numPtr = &this._byteData[this._index + 7])
          *(short*) numPtr = (short) (ushort) ((int) *(ushort*) numPtr & 64543 | (int) value << 5);
      }
    }

    public byte FBoxCount
    {
      get => (byte) (((int) this._byteData[this._index + 8] & 124) >> 2);
      set
      {
        this._byteData[this._index + 8] = (byte) ((int) this._byteData[this._index + 8] & 131 | (int) value << 2);
      }
    }

    public unsafe byte GBoxCount
    {
      get
      {
        fixed (byte* numPtr = &this._byteData[this._index + 8])
          return (byte) (((int) *(ushort*) numPtr & 3968) >> 7);
      }
      set
      {
        fixed (byte* numPtr = &this._byteData[this._index + 8])
          *(short*) numPtr = (short) (ushort) ((int) *(ushort*) numPtr & 61567 | (int) value << 7);
      }
    }

    public unsafe byte HBoxCount
    {
      get
      {
        fixed (byte* numPtr = &this._byteData[this._index + 9])
          return (byte) (((int) *(ushort*) numPtr & 496) >> 4);
      }
      set
      {
        fixed (byte* numPtr = &this._byteData[this._index + 9])
          *(short*) numPtr = (short) (ushort) ((int) *(ushort*) numPtr & 65039 | (int) value << 4);
      }
    }

    public byte IBoxCount
    {
      get => (byte) (((int) this._byteData[this._index + 10] & 62) >> 1);
      set
      {
        this._byteData[this._index + 10] = (byte) ((int) this._byteData[this._index + 10] & 193 | (int) value << 1);
      }
    }

    public byte TotalBoxCount
    {
      get
      {
        return (byte) ((uint) this.SBoxCount + (uint) this.ABoxCount + (uint) this.BBoxCount + (uint) this.CBoxCount + (uint) this.DBoxCount + (uint) this.EBoxCount + (uint) this.FBoxCount + (uint) this.GBoxCount + (uint) this.HBoxCount + (uint) this.IBoxCount);
      }
    }

    public byte OnlyMonster
    {
      get => this._byteData[this._index + 11];
      set => this._byteData[this._index + 11] = value;
    }
  }
}
