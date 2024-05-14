// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.TreasureMapData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DQ9_Cheat.GameData;

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
      _dataOffset = dataOffset;
      _typeState = new DataValue<byte>(owner, dataOffset, null, 0, byte.MaxValue);
      _detector = new DataValueString(owner, dataOffset + 1U, null, 10, false, new byte[1]);
      _renewer = new DataValueString(owner, dataOffset + 11U, null, 10, false, new byte[1]);
      _place = new DataValue<byte>(owner, dataOffset + 21U, null, 0, byte.MaxValue);
      _openProbability = new DataValue<byte>(owner, dataOffset + 22U, null, 0, byte.MaxValue);
      _rankDevilType = new DataValue<byte>(owner, dataOffset + 23U, null, 0, byte.MaxValue);
      _devilLevel = new DataValue<byte>(owner, dataOffset + 24U, null, 0, byte.MaxValue);
      _seedDevilVictoryTurn = new DataValue<ushort>(owner, dataOffset + 26U, null, 0, ushort.MaxValue);
      _treasureMapDetailData = new TreasureMapDetailData();
    }

    public TreasureMapDetailData TreasureMapDetailData => _treasureMapDetailData;

    public MapType MapType
    {
      get
      {
        byte num = (byte) ((uint) _typeState.Value >> 3);
        if ((num & 1) != 0)
          return MapType.Normal;
        return (num & 2) != 0 ? MapType.devil : MapType.Unknown;
      }
      set
      {
        _typeState.Value = (byte) (_typeState.Value & 231 | (byte) value << 3 & 24);
      }
    }

    public MapState MapState
    {
      get
      {
        if ((_typeState.Value & 1) != 0)
          return MapState.NotDiscover;
        if ((_typeState.Value & 2) != 0)
          return MapState.Discover;
        return (_typeState.Value & 4) != 0 ? MapState.Clear : MapState.Unknown;
      }
      set
      {
        _typeState.Value = (byte) (_typeState.Value & 248 | (byte) value & 7);
      }
    }

    public DataValueString Detector => _detector;

    public DataValueString Renewer => _renewer;

    public DataValue<byte> Place => _place;

    public bool IsValid
    {
      get
      {
        return _treasureMapDetailData.IsValidSeed && _treasureMapDetailData.IsValidRank && _treasureMapDetailData.IsValidPlace(_place.Value);
      }
    }

    public bool IsValidSeed => _treasureMapDetailData.IsValidSeed;

    public bool IsValidRank => _treasureMapDetailData.IsValidRank;

    public bool IsValidPlace => _treasureMapDetailData.IsValidPlace(_place.Value);

    public ReadOnlyCollection<byte> ValidPlaceList => _treasureMapDetailData.ValidPlaceList;

    public bool IsOpenProbability(int index)
    {
      return index >= 0 && index < 3 && (_openProbability.Value & 1 << index) != 0;
    }

    public void SetOpenProbability(int index, bool value)
    {
      if (index < 0 || index >= 3)
        return;
      byte num = (byte) (1 << index);
      _openProbability.Value = (byte) (_openProbability.Value & ~num | (value ? num : 0));
    }

    public byte Rank
    {
      get => _rankDevilType.Value;
      set
      {
        _rankDevilType.Value = value;
        _treasureMapDetailData.MapRank = value;
        _treasureMapDetailData.CalculateDetail();
      }
    }

    public string MapName => _treasureMapDetailData.MapName;

    public string MapName1 => _treasureMapDetailData.MapName1;

    public string MapName2 => _treasureMapDetailData.MapName2;

    public byte MapName2Index => _treasureMapDetailData.MapName2Index;

    public string MapName3 => _treasureMapDetailData.MapName3;

    public Devil DevilType
    {
      get
      {
        return MapType == MapType.devil ? DevilList.GetDevilFromIndex(_rankDevilType.Value) : null;
      }
      set
      {
        if (MapType != MapType.devil)
          return;
        _rankDevilType.Value = (byte) value.Index;
      }
    }

    public int MapLevel
    {
      get
      {
        return MapType == MapType.devil ? _devilLevel.Value : _treasureMapDetailData.MapLevel;
      }
    }

    public DataValue<byte> DevilLevel => _devilLevel;

    public ushort Seed
    {
      get => _seedDevilVictoryTurn.Value;
      set
      {
        _seedDevilVictoryTurn.Value = value;
        _treasureMapDetailData.MapSeed = value;
        _treasureMapDetailData.CalculateDetail();
      }
    }

    public ushort DevilVictoryTurn
    {
      get
      {
        return _seedDevilVictoryTurn.Value <= 999 ? _seedDevilVictoryTurn.Value : (ushort) 999;
      }
      set => _seedDevilVictoryTurn.Value = value > 999 ? (ushort) 999 : value;
    }

    public byte[] GetBytesData()
    {
      byte[] destinationArray = new byte[28];
      Array.Copy(SaveDataManager.Instance.SaveData.Data, _dataOffset, destinationArray, 0L, 28L);
      return destinationArray;
    }

    public void Copy(byte[] srcData)
    {
      srcData.CopyTo(SaveDataManager.Instance.SaveData.Data, _dataOffset);
      _treasureMapDetailData.MapSeed = Seed;
      _treasureMapDetailData.MapRank = Rank;
      _treasureMapDetailData.CalculateDetail();
    }

    public void Clear()
    {
      SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoTreasureMapClear(_dataOffset));
      Array.Clear(SaveDataManager.Instance.SaveData.Data, (int) _dataOffset, 28);
    }

    public void InitNewMap()
    {
      Clear();
      Place.Value = 1;
      MapType = MapType.Normal;
      MapState = MapState.NotDiscover;
      Rank = 2;
      Seed = 50;
      Place.Value = 5;
      _treasureMapDetailData.MapSeed = Seed;
      _treasureMapDetailData.MapRank = Rank;
      _treasureMapDetailData.CalculateDetail();
    }

    public string GetTreasureBoxItem(int floor, int boxIndex, int second)
    {
      return _treasureMapDetailData.GetTreasureBoxItem(floor, boxIndex, second);
    }

    public string BossName => _treasureMapDetailData.BossName;

    public int FloorCount => _treasureMapDetailData.FloorCount;

    public int MonsterRank => _treasureMapDetailData.MonsterRank;

    public string MapTypeName => _treasureMapDetailData.MapTypeName;

    public List<TreasureBoxInfo>[] TreasureBoxInfoList
    {
      get => _treasureMapDetailData.TreasureBoxInfoList;
    }

    public int GetTreasureBoxCount(int rank)
    {
      return _treasureMapDetailData.GetTreasureBoxCount(rank);
    }

    public int GetTreasureBoxRankPerFloor(int floor, int index)
    {
      return _treasureMapDetailData.GetTreasureBoxRankPerFloor(floor, index);
    }

    public void GetTreasureBoxPosPerFloor(int floor, int index, out int x, out int y)
    {
      _treasureMapDetailData.GetTreasureBoxPosPerFloor(floor, index, out x, out y);
    }

    public int GetTreasureBoxCountPerFloor(int floor)
    {
      return _treasureMapDetailData.GetTreasureBoxCountPerFloor(floor);
    }

    public int GetFloorWidth(int floor) => _treasureMapDetailData.GetFloorWidth(floor);

    public int GetFloorHeight(int floor) => _treasureMapDetailData.GetFloorHeight(floor);

    public byte[,] GetFloorMap(int floor) => _treasureMapDetailData.GetFloorMap(floor);

    public bool IsUpStep(int floor, int x, int y)
    {
      return _treasureMapDetailData.IsUpStep(floor, x, y);
    }

    public int IsTreasureBoxRank(int floor, int x, int y)
    {
      return _treasureMapDetailData.IsTreasureBoxRank(floor, x, y);
    }

    public int GetTreasureBoxIndex(int floor, int x, int y)
    {
      return _treasureMapDetailData.GetTreasureBoxIndex(floor, x, y);
    }

    public void CalculateDetail()
    {
      _treasureMapDetailData.MapSeed = Seed;
      _treasureMapDetailData.MapRank = Rank;
      _treasureMapDetailData.CalculateDetail(false);
    }

    public void CalculateDetail(bool floorDetail)
    {
      _treasureMapDetailData.MapSeed = Seed;
      _treasureMapDetailData.MapRank = Rank;
      _treasureMapDetailData.CalculateDetail(floorDetail);
    }
  }
}
