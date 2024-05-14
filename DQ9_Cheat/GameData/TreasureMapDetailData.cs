// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.TreasureMapDetailData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace DQ9_Cheat.GameData
{
  internal class TreasureMapDetailData
  {
    private const int FloorMapDataOffset = 792;
    private const uint ConstValue1 = 1103515245;
    private const uint ConstValue2 = 12345;
    private static List<byte> _candidateRank;
    private ushort _mapSeed;
    private byte _mapRank;
    private bool _validSeed;
    private List<byte> _validRankList = new List<byte>();
    private List<byte> _validPlaceList = new List<byte>();
    private List<byte> _lowRankValidPlaceList = new List<byte>();
    private List<byte> _middleRankValidPlaceList = new List<byte>();
    private List<byte> _highRankValidPlaceList = new List<byte>();
    private uint _seed;
    private byte[] _details = new byte[20];
    private byte[] _details2 = new byte[20];
    private byte _name3Index;
    [ThreadStatic]
    private static byte[,] _dungeonInfo;
    private List<TreasureBoxInfo>[] _treasureBoxInfoList = new List<TreasureBoxInfo>[16];

    public TreasureMapDetailData()
    {
      if (TreasureMapDetailData._dungeonInfo == null)
        TreasureMapDetailData._dungeonInfo = new byte[16, 1336];
      for (int index = 0; index < 16; ++index)
        this._treasureBoxInfoList[index] = new List<TreasureBoxInfo>();
      if (TreasureMapDetailData._candidateRank != null)
        return;
      TreasureMapDetailData._candidateRank = new List<byte>();
      for (int index1 = 1; index1 <= 99; ++index1)
      {
        for (int index2 = 0; index2 <= 50; index2 += 5)
        {
          for (int index3 = 1; index3 <= 99; ++index3)
          {
            byte num = (byte) (index1 + index2 + index3);
            if (!TreasureMapDetailData._candidateRank.Contains(num))
              TreasureMapDetailData._candidateRank.Add(num);
          }
        }
      }
    }

    public ushort MapSeed
    {
      get => this._mapSeed;
      set => this._mapSeed = value;
    }

    public byte MapRank
    {
      get => this._mapRank;
      set => this._mapRank = value;
    }

    public bool IsValidSeed => this._validSeed;

    public bool IsValidRank => this._validRankList.Contains(this._mapRank);

    public bool IsValidPlace(byte place) => this._validPlaceList.Contains(place);

    public ReadOnlyCollection<byte> ValidPlaceList => this._validPlaceList.AsReadOnly();

    public ReadOnlyCollection<byte> LowRankValidPlaceList
    {
      get => this._lowRankValidPlaceList.AsReadOnly();
    }

    public ReadOnlyCollection<byte> MiddleRankValidPlaceList
    {
      get => this._middleRankValidPlaceList.AsReadOnly();
    }

    public ReadOnlyCollection<byte> HighRankValidPlaceList
    {
      get => this._highRankValidPlaceList.AsReadOnly();
    }

    public string MapName
    {
      get
      {
        if (this.MapRank < (byte) 2 || this.MapRank > (byte) 248)
          return "Unknown";
        return string.Format("{0} {2} of {1} Lv. {3}", (object) TreasureMapDataTable.TreasureMapName1_Table[(int) this._details[5] - 1], (object) TreasureMapDataTable.TreasureMapName2_Table[(int) this._details[6] - 1], (object) TreasureMapDataTable.TreasureMapName3_Table[(int) this._name3Index], (object) this._details[4]);
      }
    }

    public string MapName1
    {
      get
      {
        return this.MapRank < (byte) 2 || this.MapRank > (byte) 248 ? "Unknown" : TreasureMapDataTable.TreasureMapName1_Table[(int) this._details[5] - 1];
      }
    }

    public byte MapName1Index => (byte) ((uint) this._details[5] - 1U);

    public string MapName2
    {
      get
      {
        return this.MapRank < (byte) 2 || this.MapRank > (byte) 248 ? "Unknown" : TreasureMapDataTable.TreasureMapName2_Table[(int) this._details[6] - 1];
      }
    }

    public byte MapName2Index => (byte) ((uint) this._details[6] - 1U);

    public string MapName3
    {
      get
      {
        return this.MapRank < (byte) 2 || this.MapRank > (byte) 248 ? "Unknown" : TreasureMapDataTable.TreasureMapName3_Table[(int) this._name3Index];
      }
    }

    public byte MapName3Index => this._name3Index;

    public int MapLevel
    {
      get => this.MapRank < (byte) 2 || this.MapRank > (byte) 248 ? 0 : (int) this._details[4];
    }

    private uint GenerateRandom()
    {
      this._seed *= 1103515245U;
      this._seed += 12345U;
      return this._seed >> 16 & (uint) short.MaxValue;
    }

    private uint GenerateRandom(uint div) => this.GenerateRandom() % div;

    private uint GetItemRank(uint value1, uint value2)
    {
      float num = (float) (int) this.GenerateRandom() - 1f;
      return (uint) (float) ((double) ((int) value2 - (int) value1 + 1) * (double) num / (double) short.MaxValue) + value1;
    }

    private uint Seek1(byte[] table, int tableSize)
    {
      uint random = this.GenerateRandom(100U);
      uint num = 0;
      for (int index = 0; index < tableSize; ++index)
      {
        num += (uint) table[index * 4 + 1];
        if (random < num)
          return (uint) table[index * 4];
      }
      return 0;
    }

    private uint Seek2(byte[] table, byte value, int tableSize)
    {
      for (int index = 0; index < tableSize; ++index)
      {
        if ((int) value >= (int) table[index * 4] && (int) value <= (int) table[index * 4 + 1])
          return this.Seek3(table[index * 4 + 2], table[index * 4 + 3]);
      }
      return 0;
    }

    private uint Seek3(byte val1, byte val2)
    {
      uint random = this.GenerateRandom();
      int num = (int) val2 - (int) val1 + 1;
      return num == 0 ? (uint) val1 : (uint) ((ulong) val1 + (ulong) random % (ulong) num);
    }

    private uint Seek4(byte[] table1, byte[] table2, int roopCount)
    {
      for (int index1 = 0; index1 < roopCount; ++index1)
      {
        if ((int) this.MapRank >= (int) table1[index1 * 4] && (int) this.MapRank <= (int) table1[index1 * 4 + 1])
        {
          int num1 = 0;
          for (int index2 = (int) table1[index1 * 4 + 2]; index2 <= (int) table1[index1 * 4 + 3]; ++index2)
            num1 += (int) table2[(index2 - 1) * 2 + 1];
          int num2 = (int) ((long) this.GenerateRandom() % (long) num1);
          int num3 = 0;
          for (int index3 = (int) table1[index1 * 4 + 2]; index3 <= (int) table1[index1 * 4 + 3]; ++index3)
          {
            num3 += (int) table2[(index3 - 1) * 2 + 1];
            if (num2 < num3)
              return (uint) index3;
          }
          break;
        }
      }
      return 0;
    }

    private unsafe void GenerateFloorMap(int floor, uint address)
    {
      int index1;
      fixed (byte* numPtr = &TreasureMapDetailData._dungeonInfo[(int) checked ((IntPtr) floor), (int) checked ((IntPtr) unchecked (address + 8U))])
        index1 = *(int*) numPtr;
      int index2 = (int) address;
      int num1 = ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] - (int) TreasureMapDetailData._dungeonInfo[floor, index1] + 1) / 2;
      int num2 = ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] - (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + 1) / 2;
      int num3 = 0;
      if (TreasureMapDetailData._dungeonInfo[floor, 1] == (byte) 0 && this.GenerateRandom(0U, 15U) == 0U)
        num3 = 1;
      int num4;
      int num5;
      int num6;
      int num7;
      if (num3 == 0)
      {
        num4 = (int) TreasureMapDetailData._dungeonInfo[floor, index2 + 3] - (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3];
        num5 = (int) TreasureMapDetailData._dungeonInfo[floor, index1] - (int) TreasureMapDetailData._dungeonInfo[floor, index2];
        num6 = (int) TreasureMapDetailData._dungeonInfo[floor, index2 + 2] - (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2];
        num7 = (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] - (int) TreasureMapDetailData._dungeonInfo[floor, index2 + 1];
      }
      else
      {
        num4 = (int) TreasureMapDetailData._dungeonInfo[floor, 3] - (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] - 1;
        num5 = (int) TreasureMapDetailData._dungeonInfo[floor, index1] - 1;
        num6 = (int) TreasureMapDetailData._dungeonInfo[floor, 2] - (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] - 1;
        num7 = (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] - 1;
        TreasureMapDetailData._dungeonInfo[floor, 1] = (byte) 1;
      }
      for (int index3 = (int) TreasureMapDetailData._dungeonInfo[floor, index1]; index3 <= (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2]; ++index3)
      {
        int num8 = (int) TreasureMapDetailData._dungeonInfo[floor, index3 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792];
        switch (num8)
        {
          case 1:
          case 3:
            continue;
          default:
            if (this.GenerateRandom(0U, 1U) == 0U)
            {
              if (num8 != 8)
              {
                switch (TreasureMapDetailData._dungeonInfo[floor, index3 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] - 1 << 4) + 792])
                {
                  case 1:
                  case 8:
                    continue;
                  default:
                    int random1 = (int) this.GenerateRandom(0U, (uint) num2);
                    int num9 = index3 - 1;
                    for (int index4 = 0; index4 < random1 && TreasureMapDetailData._dungeonInfo[floor, index3 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + index4 << 4) + 792] != (byte) 8 && TreasureMapDetailData._dungeonInfo[floor, index3 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + index4 + 1 << 4) + 792] != (byte) 1 && (TreasureMapDetailData._dungeonInfo[floor, ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + index4 << 4) + index3 + 1 + 792] == (byte) 1 || TreasureMapDetailData._dungeonInfo[floor, ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + index4 + 1 << 4) + index3 + 1 + 792] != (byte) 1) && (TreasureMapDetailData._dungeonInfo[floor, ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + index4 << 4) + num9 + 792] == (byte) 1 || TreasureMapDetailData._dungeonInfo[floor, num9 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + index4 + 1 << 4) + 792] != (byte) 1); ++index4)
                      TreasureMapDetailData._dungeonInfo[floor, index3 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + index4 << 4) + 792] = (byte) 1;
                    continue;
                }
              }
              else
                continue;
            }
            else
            {
              int random2 = (int) this.GenerateRandom(0U, (uint) num7);
              for (int index5 = 0; index5 < random2; ++index5)
              {
                int index6 = index3 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] - 1 - index5 << 4) + 792;
                if (TreasureMapDetailData._dungeonInfo[floor, index6] != (byte) 8)
                  TreasureMapDetailData._dungeonInfo[floor, index6] = (byte) 0;
              }
              continue;
            }
        }
      }
      for (int index7 = (int) TreasureMapDetailData._dungeonInfo[floor, index1]; index7 <= (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2]; ++index7)
      {
        int num10 = (int) TreasureMapDetailData._dungeonInfo[floor, index7 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] << 4) + 792];
        switch (num10)
        {
          case 1:
          case 3:
            continue;
          default:
            if (this.GenerateRandom(0U, 1U) != 0U)
            {
              int random = (int) this.GenerateRandom(0U, (uint) num4);
              for (int index8 = 0; index8 < random; ++index8)
              {
                if (TreasureMapDetailData._dungeonInfo[floor, index7 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] + index8 + 1 << 4) + 792] != (byte) 8)
                  TreasureMapDetailData._dungeonInfo[floor, index7 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] + index8 + 1 << 4) + 792] = (byte) 0;
              }
              continue;
            }
            if (num10 != 8)
            {
              switch (TreasureMapDetailData._dungeonInfo[floor, index7 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] + 1 << 4) + 792])
              {
                case 1:
                case 8:
                  continue;
                default:
                  int random3 = (int) this.GenerateRandom(0U, (uint) num2);
                  int num11 = index7 - 1;
                  for (int index9 = 0; index9 < random3 && TreasureMapDetailData._dungeonInfo[floor, index7 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] - index9 << 4) + 792] != (byte) 8 && TreasureMapDetailData._dungeonInfo[floor, index7 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] - index9 - 1 << 4) + 792] != (byte) 1 && (TreasureMapDetailData._dungeonInfo[floor, ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] - index9 << 4) + index7 + 1 + 792] == (byte) 1 || TreasureMapDetailData._dungeonInfo[floor, ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] - index9 - 1 << 4) + index7 + 1 + 792] != (byte) 1) && (TreasureMapDetailData._dungeonInfo[floor, num11 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] - index9 << 4) + 792] == (byte) 1 || TreasureMapDetailData._dungeonInfo[floor, num11 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] - index9 - 1 << 4) + 792] != (byte) 1); ++index9)
                    TreasureMapDetailData._dungeonInfo[floor, index7 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3] - index9 << 4) + 792] = (byte) 1;
                  continue;
              }
            }
            else
              continue;
        }
      }
      for (int index10 = (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1]; index10 <= (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3]; ++index10)
      {
        int num12 = (int) TreasureMapDetailData._dungeonInfo[floor, (index10 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]];
        switch (num12)
        {
          case 1:
          case 3:
            continue;
          default:
            if (this.GenerateRandom(0U, 1U) != 0U)
            {
              int random = (int) this.GenerateRandom(0U, (uint) num5);
              for (int index11 = 0; index11 < random; ++index11)
              {
                if (TreasureMapDetailData._dungeonInfo[floor, (index10 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1] - 1 - index11] != (byte) 8)
                  TreasureMapDetailData._dungeonInfo[floor, (index10 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1] - 1 - index11] = (byte) 0;
              }
              continue;
            }
            if (num12 != 8)
            {
              switch (TreasureMapDetailData._dungeonInfo[floor, (index10 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1] - 1])
              {
                case 1:
                case 8:
                  continue;
                default:
                  int random4 = (int) this.GenerateRandom(0U, (uint) num1);
                  int num13 = index10 - 1;
                  for (int index12 = 0; index12 < random4 && TreasureMapDetailData._dungeonInfo[floor, index12 + (index10 << 4) + (int) TreasureMapDetailData._dungeonInfo[floor, index1] + 792] != (byte) 8 && TreasureMapDetailData._dungeonInfo[floor, index12 + (index10 << 4) + (int) TreasureMapDetailData._dungeonInfo[floor, index1] + 792 + 1] != (byte) 1 && (TreasureMapDetailData._dungeonInfo[floor, index12 + (index10 + 1 << 4) + (int) TreasureMapDetailData._dungeonInfo[floor, index1] + 792] == (byte) 1 || TreasureMapDetailData._dungeonInfo[floor, index12 + (index10 + 1 << 4) + (int) TreasureMapDetailData._dungeonInfo[floor, index1] + 792 + 1] != (byte) 1) && (TreasureMapDetailData._dungeonInfo[floor, index12 + (num13 << 4) + (int) TreasureMapDetailData._dungeonInfo[floor, index1] + 792] == (byte) 1 || TreasureMapDetailData._dungeonInfo[floor, index12 + (num13 << 4) + (int) TreasureMapDetailData._dungeonInfo[floor, index1] + 792 + 1] != (byte) 1); ++index12)
                    TreasureMapDetailData._dungeonInfo[floor, index12 + (index10 << 4) + (int) TreasureMapDetailData._dungeonInfo[floor, index1] + 792] = (byte) 1;
                  continue;
              }
            }
            else
              continue;
        }
      }
      for (int index13 = (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1]; index13 <= (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 3]; ++index13)
      {
        int num14 = (int) TreasureMapDetailData._dungeonInfo[floor, (index13 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2]];
        switch (num14)
        {
          case 1:
          case 3:
            continue;
          default:
            if (this.GenerateRandom(0U, 1U) != 0U)
            {
              int random = (int) this.GenerateRandom(0U, (uint) num6);
              for (int index14 = 0; index14 < random; ++index14)
              {
                if (TreasureMapDetailData._dungeonInfo[floor, index14 + (index13 << 4) + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] + 792 + 1] != (byte) 8)
                  TreasureMapDetailData._dungeonInfo[floor, index14 + (index13 << 4) + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] + 792 + 1] = (byte) 0;
              }
              continue;
            }
            if (num14 != 8)
            {
              switch (TreasureMapDetailData._dungeonInfo[floor, (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + (index13 << 4) + 792 + 1])
              {
                case 1:
                case 8:
                  continue;
                default:
                  int random5 = (int) this.GenerateRandom(0U, (uint) num1);
                  int num15 = index13 - 1;
                  for (int index15 = 0; index15 < random5 && TreasureMapDetailData._dungeonInfo[floor, (index13 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] - index15] != (byte) 8 && TreasureMapDetailData._dungeonInfo[floor, (index13 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] - index15 - 1] != (byte) 1 && (TreasureMapDetailData._dungeonInfo[floor, (index13 + 1 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] - index15] == (byte) 1 || TreasureMapDetailData._dungeonInfo[floor, (index13 + 1 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] - index15 - 1] != (byte) 1) && (TreasureMapDetailData._dungeonInfo[floor, (num15 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] - index15] == (byte) 1 || TreasureMapDetailData._dungeonInfo[floor, (num15 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] - index15 - 1] != (byte) 1); ++index15)
                    TreasureMapDetailData._dungeonInfo[floor, (index13 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 2] - index15] = (byte) 1;
                  continue;
              }
            }
            else
              continue;
        }
      }
    }

    private unsafe void routine1(int floor, uint address, uint value1, uint value2)
    {
      if (value2 == 0U)
        return;
      uint num1 = value1;
      if (value2 >= 4U)
      {
        uint num2 = (value1 << 8) + value1;
        uint num3 = num2;
        num1 = (num2 << 16) + num3;
        for (uint index = value2 >> 2; index > 0U; --index)
        {
          fixed (byte* numPtr = &TreasureMapDetailData._dungeonInfo[(int) checked ((IntPtr) floor), (int) checked ((IntPtr) address)])
            *(int*) numPtr = (int) num1;
          address += 4U;
        }
      }
      if (value2 >= 4U && ((int) value2 & 3) == 0)
        return;
      for (value2 &= 3U; value2 > 0U; --value2)
      {
        TreasureMapDetailData._dungeonInfo[floor, address] = (byte) num1;
        ++address;
      }
    }

    private uint GenerateRandom(uint value1, uint value2)
    {
      if ((int) value1 == (int) value2)
        return value1;
      uint random = this.GenerateRandom();
      int num = (int) value2 - (int) value1 + 1;
      return num == 0 ? value1 : (uint) ((ulong) value1 + (ulong) random % (ulong) num);
    }

    private void SetValue(
      int floor,
      uint address,
      byte value1,
      byte value2,
      byte value3,
      byte value4)
    {
      TreasureMapDetailData._dungeonInfo[floor, address] = value1;
      TreasureMapDetailData._dungeonInfo[floor, address + 1U] = value2;
      TreasureMapDetailData._dungeonInfo[floor, address + 2U] = value3;
      TreasureMapDetailData._dungeonInfo[floor, address + 3U] = value4;
    }

    private unsafe bool routineA(int floor, uint address, uint value1, uint value2)
    {
      int num1 = (int) TreasureMapDetailData._dungeonInfo[floor, address + 3U] + 1 - (int) TreasureMapDetailData._dungeonInfo[floor, address + 1U];
      if (num1 < 7 || TreasureMapDetailData._dungeonInfo[floor, address + 4U] != (byte) 0)
        return false;
      int random = (int) this.GenerateRandom(0U, (uint) (num1 - 7));
      int num2 = (int) TreasureMapDetailData._dungeonInfo[floor, address + 1U] + random + 3;
      for (int index = (int) TreasureMapDetailData._dungeonInfo[floor, address]; index < (int) TreasureMapDetailData._dungeonInfo[floor, address + 2U] + 1; ++index)
        TreasureMapDetailData._dungeonInfo[floor, (num2 << 4) + index + 792] = (byte) 3;
      this.SetValue(floor, value2, TreasureMapDetailData._dungeonInfo[floor, address], (byte) num2, TreasureMapDetailData._dungeonInfo[floor, address + 2U], (byte) num2);
      this.SetValue(floor, value1, TreasureMapDetailData._dungeonInfo[floor, address], (byte) (num2 + 1), TreasureMapDetailData._dungeonInfo[floor, address + 2U], TreasureMapDetailData._dungeonInfo[floor, address + 3U]);
      TreasureMapDetailData._dungeonInfo[floor, value1 + 4U] = (byte) 0;
      TreasureMapDetailData._dungeonInfo[floor, value1 + 5U] = (byte) 0;
      TreasureMapDetailData._dungeonInfo[floor, address + 3U] = (byte) (num2 - 1);
      TreasureMapDetailData._dungeonInfo[floor, address + 4U] = (byte) 1;
      fixed (byte* numPtr = &TreasureMapDetailData._dungeonInfo[(int) checked ((IntPtr) floor), (int) checked ((IntPtr) value2)])
      {
        *(int*) (numPtr + 4) = (int) address;
        *(int*) (numPtr + 8) = (int) value1;
      }
      TreasureMapDetailData._dungeonInfo[floor, value2 + 12U] = (byte) 1;
      return true;
    }

    private void routineB(int floor, uint address)
    {
      int num = (int) TreasureMapDetailData._dungeonInfo[floor, 21];
      ++TreasureMapDetailData._dungeonInfo[floor, 21];
      ++TreasureMapDetailData._dungeonInfo[floor, 22];
      if (((int) this.GenerateRandom() & 1) != 0)
      {
        this.routineF(floor, address);
        this.routineF(floor, (uint) (num * 12 + 24));
      }
      else
      {
        this.routineF(floor, (uint) (num * 12 + 24));
        this.routineF(floor, address);
      }
    }

    private unsafe bool routineC(int floor, uint address1, uint address2)
    {
      if ((int) TreasureMapDetailData._dungeonInfo[floor, address1 + 2U] + 1 - (int) TreasureMapDetailData._dungeonInfo[floor, address1] < 3 || (int) TreasureMapDetailData._dungeonInfo[floor, address1 + 3U] + 1 - (int) TreasureMapDetailData._dungeonInfo[floor, address1 + 1U] < 3)
        return false;
      int num1 = (int) TreasureMapDetailData._dungeonInfo[floor, address1];
      int num2 = (int) TreasureMapDetailData._dungeonInfo[floor, address1 + 1U];
      int num3 = (int) TreasureMapDetailData._dungeonInfo[floor, address1 + 2U];
      int num4 = (int) TreasureMapDetailData._dungeonInfo[floor, address1 + 3U];
      int random1;
      int random2;
      if (this.GenerateRandom(0U, 1U) != 0U)
      {
        random1 = (int) this.GenerateRandom((uint) num1, (uint) (num1 + (num3 - num1 + 1) / 3));
        random2 = (int) this.GenerateRandom((uint) num2, (uint) (num2 + (num4 - num2 + 1) / 3));
      }
      else
      {
        random1 = (int) this.GenerateRandom((uint) (num1 + 1), (uint) (num1 + (num3 - num1 + 1) / 3));
        random2 = (int) this.GenerateRandom((uint) (num2 + 1), (uint) (num2 + (num4 - num2 + 1) / 3));
      }
      int random3;
      int random4;
      if (this.GenerateRandom(0U, 1U) != 0U)
      {
        random3 = (int) this.GenerateRandom((uint) (num1 + (num3 - num1 + 1) / 3 * 2), (uint) num3);
        random4 = (int) this.GenerateRandom((uint) (num2 + (num4 - num2 + 1) / 3 * 2), (uint) num4);
      }
      else
      {
        random3 = (int) this.GenerateRandom((uint) (num1 + (num3 - num1 + 1) / 3 * 2), (uint) (num3 - 1));
        random4 = (int) this.GenerateRandom((uint) (num2 + (num4 - num2 + 1) / 3 * 2), (uint) (num4 - 1));
      }
      this.SetValue(floor, address2, (byte) random1, (byte) random2, (byte) random3, (byte) random4);
      for (int index = 4; index < 20; ++index)
        TreasureMapDetailData._dungeonInfo[floor, (long) address2 + (long) index] = (byte) 0;
      fixed (byte* numPtr = &TreasureMapDetailData._dungeonInfo[(int) checked ((IntPtr) floor), (int) checked ((IntPtr) unchecked (address1 + 8U))])
        *(int*) numPtr = (int) address2;
      for (int index1 = random2; index1 <= random4; ++index1)
      {
        for (int index2 = random1; index2 <= random3; ++index2)
          TreasureMapDetailData._dungeonInfo[floor, index2 + (index1 << 4) + 792] = (byte) 0;
      }
      this.routineD(floor, address2);
      return true;
    }

    private bool routineD(int floor, uint address)
    {
      int num1 = (int) TreasureMapDetailData._dungeonInfo[floor, address];
      if (num1 == 0 || TreasureMapDetailData._dungeonInfo[floor, address + 1U] == (byte) 0)
        return false;
      int num2 = (int) TreasureMapDetailData._dungeonInfo[floor, address + 2U];
      if (num2 == 0 || TreasureMapDetailData._dungeonInfo[floor, address + 3U] == (byte) 0)
        return false;
      if (num2 - num1 + 1 < 5)
      {
        TreasureMapDetailData._dungeonInfo[floor, address + 12U] = (byte) this.GenerateRandom((uint) num1, (uint) num2);
        TreasureMapDetailData._dungeonInfo[floor, address + 13U] = TreasureMapDetailData._dungeonInfo[floor, address + 1U];
        TreasureMapDetailData._dungeonInfo[floor, address + 16U] = (byte) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, address], (uint) TreasureMapDetailData._dungeonInfo[floor, address + 2U]);
        TreasureMapDetailData._dungeonInfo[floor, address + 17U] = TreasureMapDetailData._dungeonInfo[floor, address + 3U];
        int index1 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 13U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 12U];
        TreasureMapDetailData._dungeonInfo[floor, index1] = (byte) 8;
        int index2 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 17U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 16U];
        TreasureMapDetailData._dungeonInfo[floor, index2] = (byte) 8;
      }
      else
      {
        int num3 = num1 + (num2 - num1 + 1) / 2 - 1;
        TreasureMapDetailData._dungeonInfo[floor, address + 12U] = (byte) this.GenerateRandom((uint) num1, (uint) num3);
        TreasureMapDetailData._dungeonInfo[floor, address + 13U] = TreasureMapDetailData._dungeonInfo[floor, address + 1U];
        TreasureMapDetailData._dungeonInfo[floor, address + 14U] = (byte) this.GenerateRandom((uint) (num3 + 1), (uint) TreasureMapDetailData._dungeonInfo[floor, address + 2U]);
        TreasureMapDetailData._dungeonInfo[floor, address + 15U] = TreasureMapDetailData._dungeonInfo[floor, address + 1U];
        TreasureMapDetailData._dungeonInfo[floor, address + 16U] = (byte) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, address], (uint) num3);
        TreasureMapDetailData._dungeonInfo[floor, address + 17U] = TreasureMapDetailData._dungeonInfo[floor, address + 3U];
        TreasureMapDetailData._dungeonInfo[floor, address + 18U] = (byte) this.GenerateRandom((uint) (num3 + 1), (uint) TreasureMapDetailData._dungeonInfo[floor, address + 2U]);
        TreasureMapDetailData._dungeonInfo[floor, address + 19U] = TreasureMapDetailData._dungeonInfo[floor, address + 3U];
        int index3 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 13U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 12U];
        TreasureMapDetailData._dungeonInfo[floor, index3] = (byte) 8;
        int index4 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 15U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 14U];
        TreasureMapDetailData._dungeonInfo[floor, index4] = (byte) 8;
        int index5 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 17U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 16U];
        TreasureMapDetailData._dungeonInfo[floor, index5] = (byte) 8;
        int index6 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 19U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 18U];
        TreasureMapDetailData._dungeonInfo[floor, index6] = (byte) 8;
      }
      if ((int) TreasureMapDetailData._dungeonInfo[floor, address + 3U] - (int) TreasureMapDetailData._dungeonInfo[floor, address + 1U] + 1 < 5)
      {
        TreasureMapDetailData._dungeonInfo[floor, address + 4U] = TreasureMapDetailData._dungeonInfo[floor, address];
        TreasureMapDetailData._dungeonInfo[floor, address + 5U] = (byte) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, address + 1U], (uint) TreasureMapDetailData._dungeonInfo[floor, address + 3U]);
        TreasureMapDetailData._dungeonInfo[floor, address + 8U] = TreasureMapDetailData._dungeonInfo[floor, address + 2U];
        TreasureMapDetailData._dungeonInfo[floor, address + 9U] = (byte) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, address + 1U], (uint) TreasureMapDetailData._dungeonInfo[floor, address + 3U]);
        int index7 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 5U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 4U];
        TreasureMapDetailData._dungeonInfo[floor, index7] = (byte) 8;
        int index8 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 9U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 8U];
        TreasureMapDetailData._dungeonInfo[floor, index8] = (byte) 8;
      }
      else
      {
        int num4 = (int) TreasureMapDetailData._dungeonInfo[floor, address + 1U];
        int num5 = num4 + ((int) TreasureMapDetailData._dungeonInfo[floor, address + 3U] + 1 - num4) / 2 - 1;
        TreasureMapDetailData._dungeonInfo[floor, address + 4U] = TreasureMapDetailData._dungeonInfo[floor, address];
        TreasureMapDetailData._dungeonInfo[floor, address + 5U] = (byte) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, address + 1U], (uint) num5);
        TreasureMapDetailData._dungeonInfo[floor, address + 6U] = TreasureMapDetailData._dungeonInfo[floor, address];
        TreasureMapDetailData._dungeonInfo[floor, address + 7U] = (byte) this.GenerateRandom((uint) (num5 + 1), (uint) TreasureMapDetailData._dungeonInfo[floor, address + 3U]);
        TreasureMapDetailData._dungeonInfo[floor, address + 8U] = TreasureMapDetailData._dungeonInfo[floor, address + 2U];
        TreasureMapDetailData._dungeonInfo[floor, address + 9U] = (byte) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, address + 1U], (uint) num5);
        TreasureMapDetailData._dungeonInfo[floor, address + 10U] = TreasureMapDetailData._dungeonInfo[floor, address + 2U];
        TreasureMapDetailData._dungeonInfo[floor, address + 11U] = (byte) this.GenerateRandom((uint) (num5 + 1), (uint) TreasureMapDetailData._dungeonInfo[floor, address + 3U]);
        int index9 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 5U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 4U];
        TreasureMapDetailData._dungeonInfo[floor, index9] = (byte) 8;
        int index10 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 7U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 6U];
        TreasureMapDetailData._dungeonInfo[floor, index10] = (byte) 8;
        int index11 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 9U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 8U];
        TreasureMapDetailData._dungeonInfo[floor, index11] = (byte) 8;
        int index12 = ((int) TreasureMapDetailData._dungeonInfo[floor, address + 11U] << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, address + 10U];
        TreasureMapDetailData._dungeonInfo[floor, index12] = (byte) 8;
      }
      return true;
    }

    private unsafe bool routineE(int floor, uint address, uint value1, uint value2)
    {
      int num1 = (int) TreasureMapDetailData._dungeonInfo[floor, address + 2U] + 1 - (int) TreasureMapDetailData._dungeonInfo[floor, address];
      if (num1 < 7 || TreasureMapDetailData._dungeonInfo[floor, address + 5U] != (byte) 0)
        return false;
      int random = (int) this.GenerateRandom(0U, (uint) (num1 - 7));
      int num2 = (int) TreasureMapDetailData._dungeonInfo[floor, address] + random + 3;
      for (int index = (int) TreasureMapDetailData._dungeonInfo[floor, address + 1U]; index < (int) TreasureMapDetailData._dungeonInfo[floor, address + 3U] + 1; ++index)
        TreasureMapDetailData._dungeonInfo[floor, (index << 4) + num2 + 792] = (byte) 3;
      this.SetValue(floor, value2, (byte) num2, TreasureMapDetailData._dungeonInfo[floor, address + 1U], (byte) num2, TreasureMapDetailData._dungeonInfo[floor, address + 3U]);
      this.SetValue(floor, value1, (byte) (num2 + 1), TreasureMapDetailData._dungeonInfo[floor, address + 1U], TreasureMapDetailData._dungeonInfo[floor, address + 2U], TreasureMapDetailData._dungeonInfo[floor, address + 3U]);
      TreasureMapDetailData._dungeonInfo[floor, value1 + 4U] = (byte) 0;
      TreasureMapDetailData._dungeonInfo[floor, value1 + 5U] = (byte) 0;
      TreasureMapDetailData._dungeonInfo[floor, address + 2U] = (byte) (num2 - 1);
      TreasureMapDetailData._dungeonInfo[floor, address + 5U] = (byte) 1;
      fixed (byte* numPtr = &TreasureMapDetailData._dungeonInfo[(int) checked ((IntPtr) floor), (int) checked ((IntPtr) value2)])
      {
        *(int*) (numPtr + 4) = (int) address;
        *(int*) (numPtr + 8) = (int) value1;
      }
      TreasureMapDetailData._dungeonInfo[floor, value2 + 12U] = (byte) 2;
      return true;
    }

    private void routineF(int floor, uint address)
    {
      if (TreasureMapDetailData._dungeonInfo[floor, 21] >= (byte) 15)
        return;
      if (TreasureMapDetailData._dungeonInfo[floor, address + 5U] != (byte) 0)
      {
        if (!this.routineA(floor, address, (uint) ((int) TreasureMapDetailData._dungeonInfo[floor, 21] * 12 + 24), (uint) (((int) TreasureMapDetailData._dungeonInfo[floor, 22] << 4) + 216)))
          return;
        this.routineB(floor, address);
      }
      else if (TreasureMapDetailData._dungeonInfo[floor, address + 4U] != (byte) 0)
      {
        if (!this.routineE(floor, address, (uint) ((int) TreasureMapDetailData._dungeonInfo[floor, 21] * 12 + 24), (uint) (((int) TreasureMapDetailData._dungeonInfo[floor, 22] << 4) + 216)))
          return;
        this.routineB(floor, address);
      }
      else if (((int) this.GenerateRandom() & 1) != 0)
      {
        if (!this.routineE(floor, address, (uint) ((int) TreasureMapDetailData._dungeonInfo[floor, 21] * 12 + 24), (uint) (((int) TreasureMapDetailData._dungeonInfo[floor, 22] << 4) + 216)))
          return;
        this.routineB(floor, address);
      }
      else
      {
        if (!this.routineA(floor, address, (uint) ((int) TreasureMapDetailData._dungeonInfo[floor, 21] * 12 + 24), (uint) (((int) TreasureMapDetailData._dungeonInfo[floor, 22] << 4) + 216)))
          return;
        this.routineB(floor, address);
      }
    }

    private unsafe int routineG(int floor, uint address)
    {
      int address3 = (int) address;
      if (TreasureMapDetailData._dungeonInfo[floor, address3 + 12] == (byte) 1)
      {
        int address1;
        int address2;
        fixed (byte* numPtr = &TreasureMapDetailData._dungeonInfo[floor, 0])
        {
          address1 = (int) *(uint*) (numPtr + (int) *(uint*) (numPtr + address3 + 4) + 8);
          address2 = (int) *(uint*) (numPtr + (int) *(uint*) (numPtr + address3 + 8) + 8);
        }
        int num1 = this.GenerateRandom(0U, 7U) == 0U ? 1 : 0;
        this.routineH(floor, (uint) address1, 16U, (uint) address2, 12U, (uint) address3, (uint) num1);
        int num2 = this.GenerateRandom(0U, 7U) == 0U ? 1 : 0;
        this.routineH(floor, (uint) address1, 18U, (uint) address2, 12U, (uint) address3, (uint) num2);
        int num3 = this.GenerateRandom(0U, 7U) == 0U ? 1 : 0;
        this.routineH(floor, (uint) address1, 16U, (uint) address2, 14U, (uint) address3, (uint) num3);
        int num4 = this.GenerateRandom(0U, 7U) == 0U ? 1 : 0;
        this.routineH(floor, (uint) address1, 18U, (uint) address2, 14U, (uint) address3, (uint) num4);
      }
      else if (TreasureMapDetailData._dungeonInfo[floor, address3 + 12] == (byte) 2)
      {
        int address1;
        int address2;
        fixed (byte* numPtr = &TreasureMapDetailData._dungeonInfo[floor, 0])
        {
          address1 = (int) *(uint*) (numPtr + (int) *(uint*) (numPtr + address3 + 4) + 8);
          address2 = (int) *(uint*) (numPtr + (int) *(uint*) (numPtr + address3 + 8) + 8);
        }
        int num5 = this.GenerateRandom(0U, 7U) == 0U ? 1 : 0;
        this.routineH(floor, (uint) address1, 8U, (uint) address2, 4U, (uint) address3, (uint) num5);
        int num6 = this.GenerateRandom(0U, 7U) == 0U ? 1 : 0;
        this.routineH(floor, (uint) address1, 10U, (uint) address2, 4U, (uint) address3, (uint) num6);
        int num7 = this.GenerateRandom(0U, 7U) == 0U ? 1 : 0;
        this.routineH(floor, (uint) address1, 8U, (uint) address2, 6U, (uint) address3, (uint) num7);
        int num8 = this.GenerateRandom(0U, 7U) == 0U ? 1 : 0;
        this.routineH(floor, (uint) address1, 10U, (uint) address2, 6U, (uint) address3, (uint) num8);
      }
      return 1;
    }

    private bool routineH(
      int floor,
      uint address1,
      uint value1,
      uint address2,
      uint value2,
      uint address3,
      uint value3)
    {
      int index1 = (int) address3;
      int num1 = (int) TreasureMapDetailData._dungeonInfo[floor, address1 + value1];
      int num2 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) address1 + (int) value1 + 1)];
      int num3 = (int) TreasureMapDetailData._dungeonInfo[floor, address2 + value2];
      int num4 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) address2 + (int) value2 + 1)];
      if (num1 == 0 || num2 == 0 || num3 == 0 || num4 == 0)
        return false;
      if (TreasureMapDetailData._dungeonInfo[floor, address3 + 12U] == (byte) 1)
      {
        for (int index2 = num2 + 1; index2 < (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] + 1; ++index2)
          TreasureMapDetailData._dungeonInfo[floor, (index2 << 4) + 792 + num1] = (byte) 2;
        for (int index3 = num4 - 1; index3 > (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1]; --index3)
          TreasureMapDetailData._dungeonInfo[floor, (index3 << 4) + 792 + num3] = (byte) 2;
        if (num1 < num3)
        {
          for (int index4 = num1; index4 < num3 + 1; ++index4)
            TreasureMapDetailData._dungeonInfo[floor, index4 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792] = (byte) 2;
        }
        else if (num1 > num3)
        {
          for (int index5 = num3; index5 < num1 + 1; ++index5)
            TreasureMapDetailData._dungeonInfo[floor, index5 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792] = (byte) 2;
        }
        if (value3 == 0U)
          return true;
        if (num1 < num3)
        {
          for (int index6 = num3 + 1; index6 < 16; ++index6)
          {
            switch (TreasureMapDetailData._dungeonInfo[floor, index6 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792])
            {
              case 1:
              case 3:
                continue;
              default:
                for (int index7 = num3 + 1; index7 < index6; ++index7)
                  TreasureMapDetailData._dungeonInfo[floor, index7 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792] = (byte) 2;
                goto label_27;
            }
          }
label_27:
          for (int index8 = num1 - 1; index8 >= 0; --index8)
          {
            switch (TreasureMapDetailData._dungeonInfo[floor, index8 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792])
            {
              case 1:
              case 3:
                continue;
              default:
                for (int index9 = num1 - 1; index9 > index8; --index9)
                  TreasureMapDetailData._dungeonInfo[floor, index9 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792] = (byte) 2;
                goto label_95;
            }
          }
        }
        else if (num1 >= num3)
        {
          for (int index10 = num1 + 1; index10 < 16; ++index10)
          {
            switch (TreasureMapDetailData._dungeonInfo[floor, index10 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792])
            {
              case 1:
              case 3:
                continue;
              default:
                for (int index11 = num1 + 1; index11 < index10; ++index11)
                  TreasureMapDetailData._dungeonInfo[floor, index11 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792] = (byte) 2;
                goto label_42;
            }
          }
label_42:
          for (int index12 = num3 - 1; index12 >= 0; --index12)
          {
            switch (TreasureMapDetailData._dungeonInfo[floor, index12 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792])
            {
              case 1:
              case 3:
                continue;
              default:
                for (int index13 = num3 - 1; index13 > index12; --index13)
                  TreasureMapDetailData._dungeonInfo[floor, index13 + ((int) TreasureMapDetailData._dungeonInfo[floor, index1 + 1] << 4) + 792] = (byte) 2;
                goto label_95;
            }
          }
        }
      }
      else if (TreasureMapDetailData._dungeonInfo[floor, address3 + 12U] == (byte) 2)
      {
        for (int index14 = num1 + 1; index14 < (int) TreasureMapDetailData._dungeonInfo[floor, index1] + 1; ++index14)
          TreasureMapDetailData._dungeonInfo[floor, index14 + (num2 << 4) + 792] = (byte) 2;
        for (int index15 = num3 - 1; index15 > (int) TreasureMapDetailData._dungeonInfo[floor, index1]; --index15)
          TreasureMapDetailData._dungeonInfo[floor, index15 + (num4 << 4) + 792] = (byte) 2;
        if (num2 < num4)
        {
          for (int index16 = num2; index16 < num4 + 1; ++index16)
            TreasureMapDetailData._dungeonInfo[floor, (index16 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]] = (byte) 2;
        }
        else if (num2 > num4)
        {
          for (int index17 = num4; index17 < num2 + 1; ++index17)
            TreasureMapDetailData._dungeonInfo[floor, (index17 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]] = (byte) 2;
        }
        if (value3 == 0U)
          return true;
        if (num2 < num4)
        {
          for (int index18 = num4 + 1; index18 < 16; ++index18)
          {
            switch (TreasureMapDetailData._dungeonInfo[floor, (index18 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]])
            {
              case 1:
              case 3:
                continue;
              default:
                for (int index19 = num4 + 1; index19 < index18; ++index19)
                  TreasureMapDetailData._dungeonInfo[floor, (index19 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]] = (byte) 2;
                goto label_74;
            }
          }
label_74:
          for (int index20 = num2 - 1; index20 >= 0; --index20)
          {
            switch (TreasureMapDetailData._dungeonInfo[floor, (index20 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]])
            {
              case 1:
              case 3:
                continue;
              default:
                for (int index21 = num2 - 1; index21 > index20; --index21)
                  TreasureMapDetailData._dungeonInfo[floor, (index21 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]] = (byte) 2;
                continue;
            }
          }
        }
        else
        {
          for (int index22 = num2 >= num4 ? num2 + 1 : num2; index22 < 16; ++index22)
          {
            switch (TreasureMapDetailData._dungeonInfo[floor, (index22 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]])
            {
              case 1:
              case 3:
                continue;
              default:
                for (int index23 = num2 + 1; index23 < index22; ++index23)
                  TreasureMapDetailData._dungeonInfo[floor, (index23 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]] = (byte) 2;
                goto label_88;
            }
          }
label_88:
          for (int index24 = num4 - 1; index24 >= 0; --index24)
          {
            switch (TreasureMapDetailData._dungeonInfo[floor, (index24 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]])
            {
              case 1:
              case 3:
                continue;
              default:
                for (int index25 = num4 - 1; index25 > index24; --index25)
                  TreasureMapDetailData._dungeonInfo[floor, (index25 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, index1]] = (byte) 2;
                goto label_95;
            }
          }
        }
      }
label_95:
      return true;
    }

    private uint routineI(int floor, uint value1, uint value2, uint value3)
    {
      int num1 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) value1 + ((int) value2 << 4) + 792)];
      switch (num1)
      {
        case 1:
        case 3:
          return (uint) byte.MaxValue;
        default:
          int num2 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) value1 + ((int) value2 - 1 << 4) + 792)];
          int num3 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) value1 + ((int) value2 - 1 << 4) + 792 - 1)];
          int num4 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) value1 + ((int) value2 - 1 << 4) + 792 + 1)];
          int num5 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) value1 + ((int) value2 << 4) + 792 + 1)];
          int num6 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) value1 + ((int) value2 + 1 << 4) + 792 + 1)];
          int num7 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) value1 + ((int) value2 + 1 << 4) + 792)];
          int num8 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) value1 + ((int) value2 + 1 << 4) + 792 - 1)];
          int num9 = (int) TreasureMapDetailData._dungeonInfo[floor, (uint) ((int) value1 + ((int) value2 << 4) + 792 - 1)];
          if (num1 != 0 && num1 != 2 && (num1 + 252 & (int) byte.MaxValue) > 4)
            return value3;
          if (num3 == 1 || num3 == 3)
            value3 |= 128U;
          else
            value3 &= (uint) sbyte.MaxValue;
          if (num4 == 1 || num4 == 3)
            value3 |= 32U;
          else
            value3 &= 223U;
          if (num6 == 1 || num6 == 3)
            value3 |= 8U;
          else
            value3 &= 247U;
          if (num8 == 1 || num8 == 3)
            value3 |= 2U;
          else
            value3 &= 253U;
          if (num2 == 1 || num2 == 3)
            value3 |= 224U;
          else
            value3 &= 191U;
          if (num5 == 1 || num5 == 3)
            value3 |= 56U;
          else
            value3 &= 239U;
          if (num7 == 1 || num7 == 3)
            value3 |= 14U;
          else
            value3 &= 251U;
          if (num9 == 1 || num9 == 3)
            value3 |= 131U;
          else
            value3 &= 254U;
          return value3;
      }
    }

    private void routineJ(int floor)
    {
      int num1 = 0;
      int num2 = 0;
      int random1 = 0;
      int random2 = 0;
      while (true)
      {
        int random3 = (int) this.GenerateRandom(0U, (uint) TreasureMapDetailData._dungeonInfo[floor, 23] - 1U);
        int index1 = random3 * 20 + 472;
        int random4 = (int) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, index1], (uint) TreasureMapDetailData._dungeonInfo[floor, index1 + 2]);
        int random5 = (int) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, index1 + 1], (uint) TreasureMapDetailData._dungeonInfo[floor, index1 + 3]);
        if (num2 < 100)
        {
          int num3 = (int) TreasureMapDetailData._dungeonInfo[floor, (random5 - 1 << 4) + random4 + 792];
          int num4 = (int) TreasureMapDetailData._dungeonInfo[floor, (random5 + 1 << 4) + random4 + 792];
          int num5 = (int) TreasureMapDetailData._dungeonInfo[floor, (random5 << 4) + 792 + random4 - 1];
          int num6 = (int) TreasureMapDetailData._dungeonInfo[floor, (random5 << 4) + 792 + random4 + 1];
          int num7 = num3 == 1 || num3 == 3 ? 1 : 0;
          int num8 = num4 == 1 || num4 == 3 ? 1 : 0;
          int num9 = num5 == 1 || num5 == 3 ? 1 : 0;
          int num10 = num6 == 1 || num6 == 3 ? 1 : 0;
          if (num7 != 0 && num8 != 0 && num9 != 0 && num10 != 0)
          {
            ++num2;
            continue;
          }
          if (num7 != 0 && num10 != 0)
          {
            ++num2;
            continue;
          }
          if (num7 != 0 && num9 != 0)
          {
            ++num2;
            continue;
          }
          if (num8 != 0 && num10 != 0)
          {
            ++num2;
            continue;
          }
          if (num8 != 0 && num9 != 0)
          {
            ++num2;
            continue;
          }
          switch ((int) this.routineI(floor, (uint) random4, (uint) random5, 0U) & (int) byte.MaxValue)
          {
            case 46:
            case 58:
            case 139:
            case 142:
            case 163:
            case 171:
            case 174:
            case 184:
            case 186:
            case 226:
            case 232:
            case 234:
              ++num2;
              continue;
          }
        }
        TreasureMapDetailData._dungeonInfo[floor, random4 + (random5 << 4) + 792] = (byte) 4;
        TreasureMapDetailData._dungeonInfo[floor, 4] = (byte) random4;
        TreasureMapDetailData._dungeonInfo[floor, 5] = (byte) random5;
        int num11 = random4;
        int num12 = random5;
        int num13 = 0;
        do
        {
          int random6 = (int) this.GenerateRandom(0U, (uint) TreasureMapDetailData._dungeonInfo[floor, 23] - 1U);
          if (random6 == (random3 & (int) byte.MaxValue) && (num1 & (int) byte.MaxValue) < 25)
          {
            ++num1;
          }
          else
          {
            int index2 = random6 * 20 + 472;
            random1 = (int) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, index2], (uint) TreasureMapDetailData._dungeonInfo[floor, index2 + 2]);
            num13 = random6;
            random2 = (int) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, index2 + 1], (uint) TreasureMapDetailData._dungeonInfo[floor, index2 + 3]);
          }
        }
        while ((random3 & (int) byte.MaxValue) == num13 && random1 == num11 && random2 == num12);
        int num14 = (int) TreasureMapDetailData._dungeonInfo[floor, random1 + (random2 - 1 << 4) + 792];
        int num15 = (int) TreasureMapDetailData._dungeonInfo[floor, random1 + (random2 + 1 << 4) + 792];
        int num16 = (int) TreasureMapDetailData._dungeonInfo[floor, random1 + (random2 << 4) + 792 - 1];
        int num17 = (int) TreasureMapDetailData._dungeonInfo[floor, random1 + (random2 << 4) + 792 + 1];
        int num18 = num14 == 1 || num14 == 3 ? 1 : 0;
        int num19 = num15 == 1 || num15 == 3 ? 1 : 0;
        int num20 = num16 == 1 || num16 == 3 ? 1 : 0;
        int num21 = num17 == 1 || num17 == 3 ? 1 : 0;
        if (num18 != 0 && num19 != 0 && num20 != 0 && num21 != 0)
          ++num2;
        else if (num18 != 0 && num21 != 0)
          ++num2;
        else if (num18 != 0 && num20 != 0)
          ++num2;
        else if (num19 != 0 && num21 != 0)
          ++num2;
        else if (num19 != 0 && num20 != 0)
          ++num2;
        else
          break;
      }
      TreasureMapDetailData._dungeonInfo[floor, random1 + (random2 << 4) + 792] = (byte) 5;
      TreasureMapDetailData._dungeonInfo[floor, 6] = (byte) random1;
      TreasureMapDetailData._dungeonInfo[floor, 7] = (byte) random2;
    }

    private int routineK(int floor)
    {
      int random1 = (int) this.GenerateRandom(1U, 3U);
      TreasureMapDetailData._dungeonInfo[floor, 8] = (byte) random1;
      int num1 = 0;
      int num2 = 0;
      do
      {
        int index = (int) this.GenerateRandom(0U, (uint) TreasureMapDetailData._dungeonInfo[floor, 23] - 1U) * 20 + 472;
        int random2 = (int) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, index], (uint) TreasureMapDetailData._dungeonInfo[floor, index + 2]);
        int random3 = (int) this.GenerateRandom((uint) TreasureMapDetailData._dungeonInfo[floor, index + 1], (uint) TreasureMapDetailData._dungeonInfo[floor, index + 3]);
        int num3 = (int) TreasureMapDetailData._dungeonInfo[floor, random2 + ((random3 & (int) byte.MaxValue) << 4) + 792];
        if (num1 < 100 && (TreasureMapDetailData._dungeonInfo[floor, 0] == (byte) 3 || TreasureMapDetailData._dungeonInfo[floor, 0] == (byte) 1))
          ++num1;
        else if (num3 == 6 || num3 == 4 || num3 == 5)
        {
          ++num1;
        }
        else
        {
          TreasureMapDetailData._dungeonInfo[floor, random2 + ((random3 & (int) byte.MaxValue) << 4) + 792] = (byte) 6;
          TreasureMapDetailData._dungeonInfo[floor, num2 * 2 + 13] = (byte) random2;
          TreasureMapDetailData._dungeonInfo[floor, num2 * 2 + 14] = (byte) random3;
          ++num2;
        }
      }
      while (num2 < (random1 & (int) byte.MaxValue));
      return 1;
    }

    private unsafe void CreateDungeonDetail(bool createSearchData)
    {
      for (int index1 = 1; index1 < (int) this._details[1] + 1; ++index1)
      {
        int floor = index1 - 1;
        TreasureMapDetailData._dungeonInfo[floor, 0] = (byte) index1;
        TreasureMapDetailData._dungeonInfo[floor, 8] = (byte) 0;
        this._seed = (uint) this.MapSeed + (uint) index1;
        if (!createSearchData || index1 > 2)
        {
          this.routine1(floor, 792U, 1U, 256U);
          TreasureMapDetailData._dungeonInfo[floor, 21] = (byte) 1;
          TreasureMapDetailData._dungeonInfo[floor, 22] = (byte) 0;
          TreasureMapDetailData._dungeonInfo[floor, 23] = (byte) 0;
          TreasureMapDetailData._dungeonInfo[floor, 1] = (byte) 0;
          this.SetValue(floor, 24U, (byte) 1, (byte) 1, (byte) ((uint) TreasureMapDetailData._dungeonInfo[floor, 2] - 2U), (byte) ((uint) TreasureMapDetailData._dungeonInfo[floor, 3] - 2U));
          TreasureMapDetailData._dungeonInfo[floor, 28] = (byte) 0;
          TreasureMapDetailData._dungeonInfo[floor, 29] = (byte) 0;
          this.routineF(floor, 24U);
          for (int index2 = 0; index2 < (int) TreasureMapDetailData._dungeonInfo[floor, 21]; ++index2)
          {
            if (this.routineC(floor, (uint) (index2 * 12 + 24), (uint) ((int) TreasureMapDetailData._dungeonInfo[floor, 23] * 20 + 472)))
              ++TreasureMapDetailData._dungeonInfo[floor, 23];
          }
          for (int index3 = 0; index3 < (int) TreasureMapDetailData._dungeonInfo[floor, 21]; ++index3)
            this.GenerateFloorMap(floor, (uint) (index3 * 12 + 24));
          for (int index4 = 0; index4 < (int) TreasureMapDetailData._dungeonInfo[floor, 22]; ++index4)
            this.routineG(floor, (uint) ((index4 << 4) + 216));
          for (int index5 = 0; index5 < (int) TreasureMapDetailData._dungeonInfo[floor, 2]; ++index5)
          {
            TreasureMapDetailData._dungeonInfo[floor, index5 + 792] = (byte) 1;
            TreasureMapDetailData._dungeonInfo[floor, ((int) TreasureMapDetailData._dungeonInfo[floor, 3] - 1 << 4) + index5 + 792] = (byte) 1;
          }
          for (int index6 = 0; index6 < (int) TreasureMapDetailData._dungeonInfo[floor, 3]; ++index6)
          {
            TreasureMapDetailData._dungeonInfo[floor, (index6 << 4) + 792] = (byte) 1;
            TreasureMapDetailData._dungeonInfo[floor, (index6 << 4) + 792 + (int) TreasureMapDetailData._dungeonInfo[floor, 2] - 1] = (byte) 1;
          }
          this.routineJ(floor);
          if (TreasureMapDetailData._dungeonInfo[floor, 0] <= (byte) 2)
            TreasureMapDetailData._dungeonInfo[floor, 8] = (byte) 0;
          else
            this.routineK(floor);
          if (!createSearchData)
          {
            TreasureMapDetailData._dungeonInfo[floor, 1306] = (byte) 0;
            TreasureMapDetailData._dungeonInfo[floor, 1307] = (byte) 0;
            for (int index7 = 1; index7 < 15; ++index7)
            {
              for (int index8 = 1; index8 < 15; ++index8)
              {
                switch (TreasureMapDetailData._dungeonInfo[floor, index8 + (index7 << 4) + 792])
                {
                  case 1:
                  case 3:
                    continue;
                  default:
                    ++TreasureMapDetailData._dungeonInfo[floor, 1306];
                    switch (TreasureMapDetailData._dungeonInfo[floor, index8 + (index7 - 1 << 4) + 792])
                    {
                      case 1:
                      case 3:
                        switch (TreasureMapDetailData._dungeonInfo[floor, (index7 << 4) + 792 + index8 - 1])
                        {
                          case 1:
                          case 3:
                            continue;
                          default:
                            ++TreasureMapDetailData._dungeonInfo[floor, 1307];
                            continue;
                        }
                      default:
                        ++TreasureMapDetailData._dungeonInfo[floor, 1307];
                        goto case 1;
                    }
                }
              }
            }
            TreasureMapDetailData._dungeonInfo[floor, 1304] = (byte) ((uint) this._details[2] + (uint) ((index1 - 1) / 4));
            int index9 = ((int) TreasureMapDataTable.TableJ[(int) this._details[3] - 1] * 12 + (int) TreasureMapDetailData._dungeonInfo[floor, 1304] - 1) * 18;
            TreasureMapDetailData._dungeonInfo[floor, 1305] = TreasureMapDataTable.TableK[index9];
            TreasureMapDetailData._dungeonInfo[floor, 1312] = (byte) 0;
            fixed (byte* numPtr1 = &TreasureMapDetailData._dungeonInfo[floor, 0])
            {
              *(int*) (numPtr1 + 1308) = ((int) numPtr1[1306] << 4) + 4896;
              int num1 = 4128 - (((int) numPtr1[1306] << 4) + (int) numPtr1[1307] * 8);
              if (num1 < 0)
              {
                byte* numPtr2 = numPtr1 + 1308;
                *(int*) numPtr2 = (int) *(uint*) numPtr2 + ((int) numPtr1[1307] + (num1 + 7) / 8 - 1) * 8;
              }
              else
              {
                byte* numPtr3 = numPtr1 + 1308;
                *(int*) numPtr3 = (int) *(uint*) numPtr3 + (int) numPtr1[1307] * 8;
              }
              byte* numPtr4 = numPtr1 + 1308;
              *(int*) numPtr4 = (int) *(uint*) numPtr4 + 4;
              byte* numPtr5 = numPtr1 + 1308;
              *(int*) numPtr5 = (int) *(uint*) numPtr5 + (int) numPtr1[1307] * 8;
              byte* numPtr6 = numPtr1 + 1308;
              *(int*) numPtr6 = (int) *(uint*) numPtr6 + (int) numPtr1[1305] * 20;
              for (int index10 = 0; index10 < (int) numPtr1[1305]; ++index10)
              {
                fixed (byte* numPtr7 = &TreasureMapDataTable.TableK[0])
                {
                  int num2 = (int) *(ushort*) (numPtr7 + (index9 + index10 * 2 + 2));
                  fixed (byte* numPtr8 = &TreasureMapDataTable.TableM[num2 * 2])
                  {
                    byte* numPtr9 = numPtr1 + 1308;
                    *(int*) numPtr9 = (int) *(uint*) numPtr9 + ((int) TreasureMapDataTable.TableL[(int) *(ushort*) numPtr8] + 8);
                  }
                }
              }
              int num3 = 11216;
              int num4 = (long) num3 < (long) *(uint*) (numPtr1 + 1308) ? 0 : (int) ((long) num3 - (long) *(uint*) (numPtr1 + 1308)) / 20;
              numPtr1[1313] = (byte) 0;
              int num5 = 0;
              for (int index11 = 0; index11 < (int) numPtr1[1305]; ++index11)
              {
                fixed (byte* numPtr10 = &TreasureMapDataTable.TableK[0])
                {
                  int num6 = (int) *(ushort*) (numPtr10 + (index9 + index11 * 2 + 2));
                  switch (num6)
                  {
                    case 38:
                    case 39:
                    case 40:
                      continue;
                    default:
                      if (index11 >= num4)
                      {
                        ++num5;
                        continue;
                      }
                      *(short*) (numPtr1 + ((int) numPtr1[1313] * 2 + 1314)) = (short) (ushort) num6;
                      byte* numPtr11 = numPtr1 + 1313;
                      *numPtr11 = (byte) ((uint) *numPtr11 + 1U);
                      continue;
                  }
                }
              }
              if (numPtr1[1313] == (byte) 0)
                numPtr1[1312] = (byte) ((uint) numPtr1[1312] | 1U);
              else if (numPtr1[1313] == (byte) 1)
                numPtr1[1312] = (byte) ((uint) numPtr1[1312] | 2U);
              else if (num5 > 0)
                numPtr1[1312] = (byte) ((uint) numPtr1[1312] | 4U);
              if (numPtr1[1313] == (byte) 1)
              {
                this._details2[14] = numPtr1[1314];
                this._details2[15] = numPtr1[1315];
              }
              else
                this._details2[12] = (byte) ((uint) this._details2[12] | (uint) numPtr1[1312]);
            }
          }
        }
      }
      for (int index12 = 2; index12 < (int) this._details[1]; ++index12)
      {
        this._seed = (uint) ((int) this.MapSeed + index12 + 1);
        for (int index13 = 0; index13 < (int) TreasureMapDetailData._dungeonInfo[index12, 8] << 1; ++index13)
        {
          int random = (int) this.GenerateRandom();
        }
        int num = (int) this._details[2] + index12 / 4;
        for (int index14 = 0; index14 < (int) TreasureMapDetailData._dungeonInfo[index12, 8]; ++index14)
        {
          TreasureMapDetailData._dungeonInfo[index12, index14 + 9] = (byte) this.GetItemRank((uint) TreasureMapDataTable.TableN[(num - 1) * 4 + 1], (uint) TreasureMapDataTable.TableN[(num - 1) * 4 + 2]);
          ++this._details2[(int) TreasureMapDetailData._dungeonInfo[index12, index14 + 9] - 1];
        }
        if (TreasureMapDetailData._dungeonInfo[index12, 8] > (byte) 0)
        {
          for (int index15 = 0; index15 < (int) TreasureMapDetailData._dungeonInfo[index12, 8]; ++index15)
          {
            TreasureBoxInfo treasureBoxInfo = new TreasureBoxInfo(index15, (int) TreasureMapDetailData._dungeonInfo[index12, 9 + index15], (int) TreasureMapDetailData._dungeonInfo[index12, index15 * 2 + 13], (int) TreasureMapDetailData._dungeonInfo[index12, index15 * 2 + 14]);
            int index16 = 0;
            while (index16 < this._treasureBoxInfoList[index12].Count && treasureBoxInfo.Rank <= this._treasureBoxInfoList[index12][index16].Rank)
              ++index16;
            this._treasureBoxInfoList[index12].Insert(index16, treasureBoxInfo);
          }
        }
      }
    }

    public string GetTreasureBoxItem(int floor, int boxIndex, int second)
    {
      this._seed = (uint) ((int) TreasureMapDetailData._dungeonInfo[floor, 0] + (int) this.MapSeed + second);
      for (int index1 = 0; index1 < (int) TreasureMapDetailData._dungeonInfo[floor, 8]; ++index1)
      {
        int num1 = (int) this.routineRandom(100U);
        if (index1 == boxIndex)
        {
          int index2 = (int) TreasureMapDetailData._dungeonInfo[floor, index1 + 9];
          int num2 = (int) TreasureMapDataTable.TableO[index2 - 1];
          int num3 = (int) TreasureMapDataTable.TableO[index2];
          int num4 = 0;
          for (int index3 = num2; index3 < num3; ++index3)
          {
            num4 += (int) TreasureMapDataTable.TableP[index3];
            if (num1 < num4)
              return TreasureMapDataTable.TableR[(int) TreasureMapDataTable.TableQ[index3]];
          }
        }
      }
      return (string) null;
    }

    private uint routineRandom(uint value)
    {
      return (uint) ((double) ((float) (int) this.GenerateRandom() - 1f) * (double) value / (double) short.MaxValue);
    }

    public void CalculateDetail() => this.CalculateDetail(false, false);

    public void CalculateDetail(bool floorDetail) => this.CalculateDetail(floorDetail, false);

    public void CalculateDetail(bool floorDetail, bool createSearchData)
    {
      this._validSeed = false;
      this._validPlaceList.Clear();
      this._lowRankValidPlaceList.Clear();
      this._middleRankValidPlaceList.Clear();
      this._highRankValidPlaceList.Clear();
      this._validRankList.Clear();
      for (int index = 0; index < 16; ++index)
        this._treasureBoxInfoList[index].Clear();
      Array.Clear((Array) this._details, 0, 20);
      Array.Clear((Array) this._details2, 0, 20);
      if (this.MapRank < (byte) 2 || this.MapRank > (byte) 248)
        return;
      this._seed = (uint) this.MapSeed;
      for (int index = 0; index < 12; ++index)
      {
        int random = (int) this.GenerateRandom(100U);
      }
      this._details[3] = (byte) this.Seek1(TreasureMapDataTable.TableA, 5);
      this._details[1] = (byte) this.Seek2(TreasureMapDataTable.TableB, this.MapRank, 9);
      this._details[2] = (byte) this.Seek2(TreasureMapDataTable.TableC, this.MapRank, 8);
      this._details[0] = (byte) this.Seek4(TreasureMapDataTable.TableD, TreasureMapDataTable.TableE, 9);
      for (int index = 0; index < 12; ++index)
        this._details[index + 1 + 7] = (byte) this.Seek3(TreasureMapDataTable.TableF[index * 4 + 1], TreasureMapDataTable.TableF[index * 4 + 2]);
      this._details[5] = (byte) this.Seek2(TreasureMapDataTable.TableH, this._details[2], 5);
      this._details[6] = (byte) this.Seek2(TreasureMapDataTable.TableI, this._details[0], 4);
      this._details[7] = (byte) this.Seek2(TreasureMapDataTable.TableG, this._details[1], 8);
      int num1 = ((int) this._details[0] + (int) this._details[1] + (int) this._details[2] - 4) * 3 + ((int) this.GenerateRandom(11U) - 5);
      if (num1 < 1)
        num1 = 1;
      if (num1 > 99)
        num1 = 99;
      this._details[4] = (byte) num1;
      this._name3Index = TreasureMapDataTable.TreasureMapName3_IndexTable[((int) this._details[7] - 1) * 5 + (int) this._details[3] - 1];
      if (!createSearchData)
      {
        ReadOnlyCollection<ushort> reverseSeedTable = TreasureMapDataTable.GetReverseSeedTable(this.MapSeed);
        if (reverseSeedTable != null)
        {
          this._validSeed = true;
          foreach (uint num2 in reverseSeedTable)
          {
            this._seed = num2;
            uint random1 = this.GenerateRandom();
            foreach (byte num3 in TreasureMapDetailData._candidateRank)
            {
              int num4 = (int) ((long) num3 + (long) random1 % (long) ((int) num3 / 10 * 2 + 1) - (long) ((int) num3 / 10));
              if (num4 > 248)
                num4 = 248;
              if (!this._validRankList.Contains((byte) num4))
                this._validRankList.Add((byte) num4);
            }
            this.GenerateRandom();
            uint random2 = this.GenerateRandom();
            uint num5 = this.MapRank > (byte) 50 ? (this.MapRank > (byte) 80 ? random2 % 150U + 1U : random2 % 131U + 1U) : random2 % 47U + 1U;
            if (!this._validPlaceList.Contains((byte) num5))
              this._validPlaceList.Add((byte) num5);
            uint num6 = random2 % 47U + 1U;
            if (!this._lowRankValidPlaceList.Contains((byte) num6))
              this._lowRankValidPlaceList.Add((byte) num6);
            uint num7 = random2 % 131U + 1U;
            if (!this._middleRankValidPlaceList.Contains((byte) num7))
              this._middleRankValidPlaceList.Add((byte) num7);
            uint num8 = random2 % 150U + 1U;
            if (!this._highRankValidPlaceList.Contains((byte) num8))
              this._highRankValidPlaceList.Add((byte) num8);
          }
          if (this.MapRank == (byte) 2 && this.MapSeed == (ushort) 50)
          {
            this._validPlaceList.Add((byte) 5);
            this._lowRankValidPlaceList.Add((byte) 5);
          }
        }
        else
        {
          this._validSeed = false;
          this._validPlaceList.Clear();
          this._validRankList.Clear();
        }
      }
      if (!floorDetail)
        return;
      for (int index = 1; index < (int) this._details[1] + 1; ++index)
      {
        int num9 = index > 4 ? (index > 8 ? (index > 12 ? 16 : ((int) this.MapSeed + index) % 3 + 14) : ((int) this.MapSeed + index) % 4 + 12) : ((int) this.MapSeed + index) % 5 + 10;
        TreasureMapDetailData._dungeonInfo[index - 1, 2] = (byte) num9;
        TreasureMapDetailData._dungeonInfo[index - 1, 3] = (byte) num9;
      }
      this.CreateDungeonDetail(createSearchData);
    }

    public string BossName => MonsterDataList.List[282 + (int) this._details[0] - 1];

    public byte BossIndex => (byte) ((uint) this._details[0] - 1U);

    public int FloorCount => (int) this._details[1];

    public int MonsterRank => (int) this._details[2];

    public string MapTypeName
    {
      get => TreasureMapDataTable.TreasureMapMapTypeName_Table[(int) this._details[3] - 1];
    }

    public byte MapTypeIndex => (byte) ((uint) this._details[3] - 1U);

    public List<TreasureBoxInfo>[] TreasureBoxInfoList => this._treasureBoxInfoList;

    public int GetTreasureBoxCount(int rank)
    {
      if (rank == 0)
      {
        int treasureBoxCount = 0;
        for (int index = 0; index < 10; ++index)
          treasureBoxCount += (int) this._details2[index];
        return treasureBoxCount;
      }
      return rank > 0 && rank <= 10 ? (int) this._details2[rank - 1] : 0;
    }

    public int GetTreasureBoxRankPerFloor(int floor, int index)
    {
      return floor < this.FloorCount && index < this.GetTreasureBoxCountPerFloor(floor) ? (int) TreasureMapDetailData._dungeonInfo[floor, 9 + index] : 0;
    }

    public void GetTreasureBoxPosPerFloor(int floor, int index, out int x, out int y)
    {
      x = -1;
      y = -1;
      if (floor >= this.FloorCount || index >= this.GetTreasureBoxCountPerFloor(floor))
        return;
      x = (int) TreasureMapDetailData._dungeonInfo[floor, index * 2 + 13];
      y = (int) TreasureMapDetailData._dungeonInfo[floor, index * 2 + 14];
    }

    public int GetTreasureBoxCountPerFloor(int floor)
    {
      return floor < this.FloorCount ? (int) TreasureMapDetailData._dungeonInfo[floor, 8] : 0;
    }

    public int GetFloorWidth(int floor)
    {
      return floor < this.FloorCount ? (int) TreasureMapDetailData._dungeonInfo[floor, 2] : 0;
    }

    public int GetFloorHeight(int floor)
    {
      return floor < this.FloorCount ? (int) TreasureMapDetailData._dungeonInfo[floor, 3] : 0;
    }

    public byte[,] GetFloorMap(int floor)
    {
      if (floor >= this.FloorCount)
        return (byte[,]) null;
      int floorHeight = this.GetFloorHeight(floor);
      int floorWidth = this.GetFloorWidth(floor);
      byte[,] destinationArray = new byte[floorWidth, floorHeight];
      int sourceIndex = floor * 1336 + 792;
      int destinationIndex = 0;
      for (int index = 0; index < floorHeight; ++index)
      {
        Array.Copy((Array) TreasureMapDetailData._dungeonInfo, sourceIndex, (Array) destinationArray, destinationIndex, floorWidth);
        sourceIndex += 16;
        destinationIndex += floorWidth;
      }
      return destinationArray;
    }

    public bool IsUpStep(int floor, int x, int y)
    {
      return floor < this.FloorCount && x < this.GetFloorWidth(floor) && y < this.GetFloorHeight(floor) && (int) TreasureMapDetailData._dungeonInfo[floor, 4] == x && (int) TreasureMapDetailData._dungeonInfo[floor, 5] == y;
    }

    public int IsTreasureBoxRank(int floor, int x, int y)
    {
      if (floor < this.FloorCount && x < this.GetFloorWidth(floor) && y < this.GetFloorHeight(floor))
      {
        for (int index = 0; index < this.GetTreasureBoxCountPerFloor(floor); ++index)
        {
          if ((int) TreasureMapDetailData._dungeonInfo[floor, index * 2 + 13] == x && (int) TreasureMapDetailData._dungeonInfo[floor, index * 2 + 14] == y)
            return (int) TreasureMapDetailData._dungeonInfo[floor, index + 9];
        }
      }
      return 0;
    }

    public int GetTreasureBoxIndex(int floor, int x, int y)
    {
      if (floor < this.FloorCount && x < this.GetFloorWidth(floor) && y < this.GetFloorHeight(floor))
      {
        for (int treasureBoxIndex = 0; treasureBoxIndex < this.GetTreasureBoxCountPerFloor(floor); ++treasureBoxIndex)
        {
          if ((int) TreasureMapDetailData._dungeonInfo[floor, treasureBoxIndex * 2 + 13] == x && (int) TreasureMapDetailData._dungeonInfo[floor, treasureBoxIndex * 2 + 14] == y)
            return treasureBoxIndex;
        }
      }
      return -1;
    }
  }
}
