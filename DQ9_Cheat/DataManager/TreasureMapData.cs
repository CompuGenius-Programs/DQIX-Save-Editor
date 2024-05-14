// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.TreasureMapData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.DataManager;

internal class TreasureMapData
{
    public const int DataSize = 28;
    private readonly uint _dataOffset;
    private readonly DataValue<byte> _openProbability;
    private readonly DataValue<byte> _rankDevilType;
    private readonly DataValue<ushort> _seedDevilVictoryTurn;
    private readonly DataValue<byte> _typeState;

    public TreasureMapData(SaveData owner, uint dataOffset)
    {
        _dataOffset = dataOffset;
        _typeState = new DataValue<byte>(owner, dataOffset, null, 0, byte.MaxValue);
        Detector = new DataValueString(owner, dataOffset + 1U, null, 10, false, new byte[1]);
        Renewer = new DataValueString(owner, dataOffset + 11U, null, 10, false, new byte[1]);
        Place = new DataValue<byte>(owner, dataOffset + 21U, null, 0, byte.MaxValue);
        _openProbability = new DataValue<byte>(owner, dataOffset + 22U, null, 0, byte.MaxValue);
        _rankDevilType = new DataValue<byte>(owner, dataOffset + 23U, null, 0, byte.MaxValue);
        DevilLevel = new DataValue<byte>(owner, dataOffset + 24U, null, 0, byte.MaxValue);
        _seedDevilVictoryTurn = new DataValue<ushort>(owner, dataOffset + 26U, null, 0, ushort.MaxValue);
        TreasureMapDetailData = new TreasureMapDetailData();
    }

    public TreasureMapDetailData TreasureMapDetailData { get; }

    public MapType MapType
    {
        get
        {
            var num = (byte)((uint)_typeState.Value >> 3);
            if ((num & 1) != 0)
                return MapType.Normal;
            return (num & 2) != 0 ? MapType.devil : MapType.Unknown;
        }
        set => _typeState.Value = (byte)((_typeState.Value & 231) | (((byte)value << 3) & 24));
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
        set => _typeState.Value = (byte)((_typeState.Value & 248) | ((byte)value & 7));
    }

    public DataValueString Detector { get; }

    public DataValueString Renewer { get; }

    public DataValue<byte> Place { get; }

    public bool IsValid => TreasureMapDetailData.IsValidSeed && TreasureMapDetailData.IsValidRank &&
                           TreasureMapDetailData.IsValidPlace(Place.Value);

    public bool IsValidSeed => TreasureMapDetailData.IsValidSeed;

    public bool IsValidRank => TreasureMapDetailData.IsValidRank;

    public bool IsValidPlace => TreasureMapDetailData.IsValidPlace(Place.Value);

    public ReadOnlyCollection<byte> ValidPlaceList => TreasureMapDetailData.ValidPlaceList;

    public byte Rank
    {
        get => _rankDevilType.Value;
        set
        {
            _rankDevilType.Value = value;
            TreasureMapDetailData.MapRank = value;
            TreasureMapDetailData.CalculateDetail();
        }
    }

    public string MapName => TreasureMapDetailData.MapName;

    public string MapName1 => TreasureMapDetailData.MapName1;

    public string MapName2 => TreasureMapDetailData.MapName2;

    public byte MapName2Index => TreasureMapDetailData.MapName2Index;

    public string MapName3 => TreasureMapDetailData.MapName3;

    public Devil DevilType
    {
        get => MapType == MapType.devil ? DevilList.GetDevilFromIndex(_rankDevilType.Value) : null;
        set
        {
            if (MapType != MapType.devil)
                return;
            _rankDevilType.Value = (byte)value.Index;
        }
    }

    public int MapLevel => MapType == MapType.devil ? DevilLevel.Value : TreasureMapDetailData.MapLevel;

    public DataValue<byte> DevilLevel { get; }

    public ushort Seed
    {
        get => _seedDevilVictoryTurn.Value;
        set
        {
            _seedDevilVictoryTurn.Value = value;
            TreasureMapDetailData.MapSeed = value;
            TreasureMapDetailData.CalculateDetail();
        }
    }

    public ushort DevilVictoryTurn
    {
        get => _seedDevilVictoryTurn.Value <= 999 ? _seedDevilVictoryTurn.Value : (ushort)999;
        set => _seedDevilVictoryTurn.Value = value > 999 ? (ushort)999 : value;
    }

    public string BossName => TreasureMapDetailData.BossName;

    public int FloorCount => TreasureMapDetailData.FloorCount;

    public int MonsterRank => TreasureMapDetailData.MonsterRank;

    public string MapTypeName => TreasureMapDetailData.MapTypeName;

    public List<TreasureBoxInfo>[] TreasureBoxInfoList => TreasureMapDetailData.TreasureBoxInfoList;

    public bool IsOpenProbability(int index)
    {
        return index >= 0 && index < 3 && (_openProbability.Value & (1 << index)) != 0;
    }

    public void SetOpenProbability(int index, bool value)
    {
        if (index < 0 || index >= 3)
            return;
        var num = (byte)(1 << index);
        _openProbability.Value = (byte)((_openProbability.Value & ~num) | (value ? num : 0));
    }

    public byte[] GetBytesData()
    {
        var destinationArray = new byte[28];
        Array.Copy(SaveDataManager.Instance.SaveData.Data, _dataOffset, destinationArray, 0L, 28L);
        return destinationArray;
    }

    public void Copy(byte[] srcData)
    {
        srcData.CopyTo(SaveDataManager.Instance.SaveData.Data, _dataOffset);
        TreasureMapDetailData.MapSeed = Seed;
        TreasureMapDetailData.MapRank = Rank;
        TreasureMapDetailData.CalculateDetail();
    }

    public void Clear()
    {
        SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoTreasureMapClear(_dataOffset));
        Array.Clear(SaveDataManager.Instance.SaveData.Data, (int)_dataOffset, 28);
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
        TreasureMapDetailData.MapSeed = Seed;
        TreasureMapDetailData.MapRank = Rank;
        TreasureMapDetailData.CalculateDetail();
    }

    public string GetTreasureBoxItem(int floor, int boxIndex, int second)
    {
        return TreasureMapDetailData.GetTreasureBoxItem(floor, boxIndex, second);
    }

    public int GetTreasureBoxCount(int rank)
    {
        return TreasureMapDetailData.GetTreasureBoxCount(rank);
    }

    public int GetTreasureBoxRankPerFloor(int floor, int index)
    {
        return TreasureMapDetailData.GetTreasureBoxRankPerFloor(floor, index);
    }

    public void GetTreasureBoxPosPerFloor(int floor, int index, out int x, out int y)
    {
        TreasureMapDetailData.GetTreasureBoxPosPerFloor(floor, index, out x, out y);
    }

    public int GetTreasureBoxCountPerFloor(int floor)
    {
        return TreasureMapDetailData.GetTreasureBoxCountPerFloor(floor);
    }

    public int GetFloorWidth(int floor)
    {
        return TreasureMapDetailData.GetFloorWidth(floor);
    }

    public int GetFloorHeight(int floor)
    {
        return TreasureMapDetailData.GetFloorHeight(floor);
    }

    public byte[,] GetFloorMap(int floor)
    {
        return TreasureMapDetailData.GetFloorMap(floor);
    }

    public bool IsUpStep(int floor, int x, int y)
    {
        return TreasureMapDetailData.IsUpStep(floor, x, y);
    }

    public int IsTreasureBoxRank(int floor, int x, int y)
    {
        return TreasureMapDetailData.IsTreasureBoxRank(floor, x, y);
    }

    public int GetTreasureBoxIndex(int floor, int x, int y)
    {
        return TreasureMapDetailData.GetTreasureBoxIndex(floor, x, y);
    }

    public void CalculateDetail()
    {
        TreasureMapDetailData.MapSeed = Seed;
        TreasureMapDetailData.MapRank = Rank;
        TreasureMapDetailData.CalculateDetail(false);
    }

    public void CalculateDetail(bool floorDetail)
    {
        TreasureMapDetailData.MapSeed = Seed;
        TreasureMapDetailData.MapRank = Rank;
        TreasureMapDetailData.CalculateDetail(floorDetail);
    }
}