// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.TreasureMapData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class TreasureMapData
  {
    public const int DataSize = 28;
    private uint _dataOffset;
    private TreasureMapDetailData _treasureMapDetailData;
    private DataValue<byte> _typeState;
    private DataValueString _detector;
    private DataValueString _renewer;
    private DataValue<byte> _place;
    private DataValue<byte> _openProbability;
    private DataValue<byte> _rankDevilType;
    private DataValue<byte> _devilLevel;
    private DataValue<ushort> _seedDevilVictoryTurn;

    public TreasureMapData(SaveData owner, uint dataOffset)
    {
      this._dataOffset = dataOffset;
      this._typeState = new DataValue<byte>(owner, dataOffset, (Control) null, (byte) 0, byte.MaxValue);
      this._detector = new DataValueString(owner, dataOffset + 1U, (Control) null, 10, false, new byte[1]);
      this._renewer = new DataValueString(owner, dataOffset + 11U, (Control) null, 10, false, new byte[1]);
      this._place = new DataValue<byte>(owner, dataOffset + 21U, (Control) null, (byte) 0, byte.MaxValue);
      this._openProbability = new DataValue<byte>(owner, dataOffset + 22U, (Control) null, (byte) 0, byte.MaxValue);
      this._rankDevilType = new DataValue<byte>(owner, dataOffset + 23U, (Control) null, (byte) 0, byte.MaxValue);
      this._devilLevel = new DataValue<byte>(owner, dataOffset + 24U, (Control) null, (byte) 0, byte.MaxValue);
      this._seedDevilVictoryTurn = new DataValue<ushort>(owner, dataOffset + 26U, (Control) null, (ushort) 0, ushort.MaxValue);
      this._treasureMapDetailData = new TreasureMapDetailData();
    }

    public TreasureMapDetailData TreasureMapDetailData => this._treasureMapDetailData;

    public MapType MapType
    {
      get
      {
        byte num = (byte) ((uint) this._typeState.Value >> 3);
        if (((int) num & 1) != 0)
          return MapType.Normal;
        return ((int) num & 2) != 0 ? MapType.devil : MapType.Unknown;
      }
      set
      {
        this._typeState.Value = (byte) ((int) this._typeState.Value & 231 | (int) (byte) value << 3 & 24);
      }
    }

    public MapState MapState
    {
      get
      {
        if (((int) this._typeState.Value & 1) != 0)
          return MapState.NotDiscover;
        if (((int) this._typeState.Value & 2) != 0)
          return MapState.Discover;
        return ((int) this._typeState.Value & 4) != 0 ? MapState.Clear : MapState.Unknown;
      }
      set
      {
        this._typeState.Value = (byte) ((int) this._typeState.Value & 248 | (int) (byte) value & 7);
      }
    }

    public DataValueString Detector => this._detector;

    public DataValueString Renewer => this._renewer;

    public DataValue<byte> Place => this._place;

    public bool IsValid
    {
      get
      {
        return this._treasureMapDetailData.IsValidSeed && this._treasureMapDetailData.IsValidRank && this._treasureMapDetailData.IsValidPlace(this._place.Value);
      }
    }

    public bool IsValidSeed => this._treasureMapDetailData.IsValidSeed;

    public bool IsValidRank => this._treasureMapDetailData.IsValidRank;

    public bool IsValidPlace => this._treasureMapDetailData.IsValidPlace(this._place.Value);

    public ReadOnlyCollection<byte> ValidPlaceList => this._treasureMapDetailData.ValidPlaceList;

    public bool IsOpenProbability(int index)
    {
      return index >= 0 && index < 3 && ((int) this._openProbability.Value & 1 << index) != 0;
    }

    public void SetOpenProbability(int index, bool value)
    {
      if (index < 0 || index >= 3)
        return;
      byte num = (byte) (1 << index);
      this._openProbability.Value = (byte) ((int) this._openProbability.Value & (int) ~num | (value ? (int) num : 0));
    }

    public byte Rank
    {
      get => this._rankDevilType.Value;
      set
      {
        this._rankDevilType.Value = value;
        this._treasureMapDetailData.MapRank = value;
        this._treasureMapDetailData.CalculateDetail();
      }
    }

    public string MapName => this._treasureMapDetailData.MapName;

    public string MapName1 => this._treasureMapDetailData.MapName1;

    public string MapName2 => this._treasureMapDetailData.MapName2;

    public byte MapName2Index => this._treasureMapDetailData.MapName2Index;

    public string MapName3 => this._treasureMapDetailData.MapName3;

    public Devil DevilType
    {
      get
      {
        return this.MapType == MapType.devil ? DevilList.GetDevilFromIndex((int) this._rankDevilType.Value) : (Devil) null;
      }
      set
      {
        if (this.MapType != MapType.devil)
          return;
        this._rankDevilType.Value = (byte) value.Index;
      }
    }

    public int MapLevel
    {
      get
      {
        return this.MapType == MapType.devil ? (int) this._devilLevel.Value : this._treasureMapDetailData.MapLevel;
      }
    }

    public DataValue<byte> DevilLevel => this._devilLevel;

    public ushort Seed
    {
      get => this._seedDevilVictoryTurn.Value;
      set
      {
        this._seedDevilVictoryTurn.Value = value;
        this._treasureMapDetailData.MapSeed = value;
        this._treasureMapDetailData.CalculateDetail();
      }
    }

    public ushort DevilVictoryTurn
    {
      get
      {
        return this._seedDevilVictoryTurn.Value <= (ushort) 999 ? this._seedDevilVictoryTurn.Value : (ushort) 999;
      }
      set => this._seedDevilVictoryTurn.Value = value > (ushort) 999 ? (ushort) 999 : value;
    }

    public byte[] GetBytesData()
    {
      byte[] destinationArray = new byte[28];
      Array.Copy((Array) SaveDataManager.Instance.SaveData.Data, (long) this._dataOffset, (Array) destinationArray, 0L, 28L);
      return destinationArray;
    }

    public void Copy(byte[] srcData)
    {
      srcData.CopyTo((Array) SaveDataManager.Instance.SaveData.Data, (long) this._dataOffset);
      this._treasureMapDetailData.MapSeed = this.Seed;
      this._treasureMapDetailData.MapRank = this.Rank;
      this._treasureMapDetailData.CalculateDetail();
    }

    public void Clear()
    {
      SaveDataManager.Instance.UndoRedoMgr.Edited((UndoRedoElement) new UndoRedoTreasureMapClear(this._dataOffset));
      Array.Clear((Array) SaveDataManager.Instance.SaveData.Data, (int) this._dataOffset, 28);
    }

    public void InitNewMap()
    {
      this.Clear();
      this.Place.Value = (byte) 1;
      this.MapType = MapType.Normal;
      this.MapState = MapState.NotDiscover;
      this.Rank = (byte) 2;
      this.Seed = (ushort) 50;
      this.Place.Value = (byte) 5;
      this._treasureMapDetailData.MapSeed = this.Seed;
      this._treasureMapDetailData.MapRank = this.Rank;
      this._treasureMapDetailData.CalculateDetail();
    }

    public string GetTreasureBoxItem(int floor, int boxIndex, int second)
    {
      return this._treasureMapDetailData.GetTreasureBoxItem(floor, boxIndex, second);
    }

    public string BossName => this._treasureMapDetailData.BossName;

    public int FloorCount => this._treasureMapDetailData.FloorCount;

    public int MonsterRank => this._treasureMapDetailData.MonsterRank;

    public string MapTypeName => this._treasureMapDetailData.MapTypeName;

    public List<TreasureBoxInfo>[] TreasureBoxInfoList
    {
      get => this._treasureMapDetailData.TreasureBoxInfoList;
    }

    public int GetTreasureBoxCount(int rank)
    {
      return this._treasureMapDetailData.GetTreasureBoxCount(rank);
    }

    public int GetTreasureBoxRankPerFloor(int floor, int index)
    {
      return this._treasureMapDetailData.GetTreasureBoxRankPerFloor(floor, index);
    }

    public void GetTreasureBoxPosPerFloor(int floor, int index, out int x, out int y)
    {
      this._treasureMapDetailData.GetTreasureBoxPosPerFloor(floor, index, out x, out y);
    }

    public int GetTreasureBoxCountPerFloor(int floor)
    {
      return this._treasureMapDetailData.GetTreasureBoxCountPerFloor(floor);
    }

    public int GetFloorWidth(int floor) => this._treasureMapDetailData.GetFloorWidth(floor);

    public int GetFloorHeight(int floor) => this._treasureMapDetailData.GetFloorHeight(floor);

    public byte[,] GetFloorMap(int floor) => this._treasureMapDetailData.GetFloorMap(floor);

    public bool IsUpStep(int floor, int x, int y)
    {
      return this._treasureMapDetailData.IsUpStep(floor, x, y);
    }

    public int IsTreasureBoxRank(int floor, int x, int y)
    {
      return this._treasureMapDetailData.IsTreasureBoxRank(floor, x, y);
    }

    public int GetTreasureBoxIndex(int floor, int x, int y)
    {
      return this._treasureMapDetailData.GetTreasureBoxIndex(floor, x, y);
    }

    public void CalculateDetail()
    {
      this._treasureMapDetailData.MapSeed = this.Seed;
      this._treasureMapDetailData.MapRank = this.Rank;
      this._treasureMapDetailData.CalculateDetail(false);
    }

    public void CalculateDetail(bool floorDetail)
    {
      this._treasureMapDetailData.MapSeed = this.Seed;
      this._treasureMapDetailData.MapRank = this.Rank;
      this._treasureMapDetailData.CalculateDetail(floorDetail);
    }
  }
}
