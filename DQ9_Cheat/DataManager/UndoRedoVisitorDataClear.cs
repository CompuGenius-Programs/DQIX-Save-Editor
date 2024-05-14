// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoVisitorDataClear
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class UndoRedoVisitorDataClear : UndoRedoElement
  {
    private uint _index;
    private byte[] _visitorData;

    public UndoRedoVisitorDataClear(uint index)
    {
      this._index = index;
      this._visitorData = this.GetSaveData().RikkaData.VisitorManager.VisitorData[(int) index].GetBytesData();
    }

    protected override void OnDispose() => this._visitorData = (byte[]) null;

    public override void Undo()
    {
      this.GetSaveData().RikkaData.VisitorManager.VisitorData[(int) this._index].Copy(this._visitorData);
    }

    public override void Redo()
    {
      this.GetSaveData().RikkaData.VisitorManager.VisitorData[(int) this._index].Copy(this._visitorData);
    }
  }
}
