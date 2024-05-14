// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoVisitorDataClear
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.DataManager
{
  internal class UndoRedoVisitorDataClear : UndoRedoElement
  {
    private uint _index;
    private byte[] _visitorData;

    public UndoRedoVisitorDataClear(uint index)
    {
      _index = index;
      _visitorData = GetSaveData().RikkaData.VisitorManager.VisitorData[(int) index].GetBytesData();
    }

    protected override void OnDispose() => _visitorData = null;

    public override void Undo()
    {
      GetSaveData().RikkaData.VisitorManager.VisitorData[(int) _index].Copy(_visitorData);
    }

    public override void Redo()
    {
      GetSaveData().RikkaData.VisitorManager.VisitorData[(int) _index].Copy(_visitorData);
    }
  }
}
