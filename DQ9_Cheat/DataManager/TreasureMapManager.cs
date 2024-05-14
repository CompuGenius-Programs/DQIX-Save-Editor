// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.TreasureMapManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.DataManager
{
  internal class TreasureMapManager
  {
    public const int MapCountMax = 99;
    private DataValue<uint> _clearCount;
    private DataValue<byte> _mapCount;
    private TreasureMapData[] _mapData = new TreasureMapData[99];

    public TreasureMapManager(SaveData owner)
    {
      _clearCount = new DataValue<uint>(owner, 16037U, null, 0U, uint.MaxValue);
      _mapCount = new DataValue<byte>(owner, 24204U, null, 0, 99);
      for (int index = 0; index < 99; ++index)
        _mapData[index] = new TreasureMapData(owner, (uint) (24206 + 28 * index));
    }

    public ushort ClearCount
    {
      get => (ushort) ((_clearCount.Value & 1048512U) >> 6);
      set
      {
        _clearCount.Value = (uint) ((int) _clearCount.Value & -1048513 | value << 6 & 1048512);
      }
    }

    public byte MapCount => _mapCount.Value;

    public TreasureMapData GetMapData(int index)
    {
      return index >= 0 && index < _mapCount.Value ? _mapData[index] : null;
    }

    public bool CreateMapData()
    {
      if (_mapCount.Value >= 99)
        return false;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      ++_mapCount.Value;
      _mapData[_mapCount.Value - 1].InitNewMap();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      return true;
    }

    public void DeleteMapData(int index)
    {
      if (index < 0 || index >= _mapCount.Value)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      MoveTo(index, _mapCount.Value - 1);
      _mapData[_mapCount.Value - 1].Clear();
      --_mapCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void MoveTo(int srcIndex, int toIndex)
    {
      if (srcIndex >= _mapCount.Value || toIndex >= _mapCount.Value || srcIndex == toIndex)
        return;
      byte[] bytesData = _mapData[srcIndex].GetBytesData();
      if (srcIndex > toIndex)
      {
        for (int index = srcIndex; index > toIndex; --index)
          _mapData[index].Copy(_mapData[index - 1].GetBytesData());
      }
      else if (srcIndex < toIndex)
      {
        for (int index = srcIndex; index < toIndex; ++index)
          _mapData[index].Copy(_mapData[index + 1].GetBytesData());
      }
      _mapData[toIndex].Copy(bytesData);
      SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoTreasureMapIndexChanged(srcIndex, toIndex));
    }

    public void OnLoaded()
    {
      for (int index = 0; index < 99; ++index)
        _mapData[index].CalculateDetail();
    }

    public void OnUndo()
    {
      for (int index = 0; index < 99; ++index)
        _mapData[index].CalculateDetail();
    }

    public void OnRedo()
    {
      for (int index = 0; index < 99; ++index)
        _mapData[index].CalculateDetail();
    }
  }
}
