// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoTreasureMapClear
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;

namespace DQ9_Cheat.DataManager
{
  internal class UndoRedoTreasureMapClear : UndoRedoElement
  {
    private uint _dataOffset;
    private byte[] _treasureMapData;

    public UndoRedoTreasureMapClear(uint dataOffset)
    {
      _dataOffset = dataOffset;
      _treasureMapData = new byte[28];
      Array.Copy(SaveDataManager.Instance.SaveData.Data, _dataOffset, _treasureMapData, 0L, 28L);
    }

    protected override void OnDispose() => _treasureMapData = null;

    public override void Undo()
    {
      Array.Copy(_treasureMapData, 0L, SaveDataManager.Instance.SaveData.Data, _dataOffset, 28L);
    }

    public override void Redo()
    {
      Array.Clear(SaveDataManager.Instance.SaveData.Data, (int) _dataOffset, 28);
    }
  }
}
