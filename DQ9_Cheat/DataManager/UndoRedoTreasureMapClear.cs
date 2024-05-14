// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoTreasureMapClear
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class UndoRedoTreasureMapClear : UndoRedoElement
  {
    private uint _dataOffset;
    private byte[] _treasureMapData;

    public UndoRedoTreasureMapClear(uint dataOffset)
    {
      this._dataOffset = dataOffset;
      this._treasureMapData = new byte[28];
      Array.Copy((Array) SaveDataManager.Instance.SaveData.Data, (long) this._dataOffset, (Array) this._treasureMapData, 0L, 28L);
    }

    protected override void OnDispose() => this._treasureMapData = (byte[]) null;

    public override void Undo()
    {
      Array.Copy((Array) this._treasureMapData, 0L, (Array) SaveDataManager.Instance.SaveData.Data, (long) this._dataOffset, 28L);
    }

    public override void Redo()
    {
      Array.Clear((Array) SaveDataManager.Instance.SaveData.Data, (int) this._dataOffset, 28);
    }
  }
}
