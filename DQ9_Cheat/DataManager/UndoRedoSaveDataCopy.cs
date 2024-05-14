// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoSaveDataCopy
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class UndoRedoSaveDataCopy : UndoRedoElement
  {
    private byte[] _data;
    private int _srcIndex;

    public UndoRedoSaveDataCopy(int srcIndex)
    {
      this._srcIndex = srcIndex;
      this._data = SaveDataManager.Instance.GetSaveData(this._srcIndex).GetData();
    }

    protected override void OnDispose() => this._data = (byte[]) null;

    public override void Undo()
    {
      SaveDataManager.Instance.GetSaveData(this._srcIndex).CopyData(this._data);
    }

    public override void Redo()
    {
      byte[] data = SaveDataManager.Instance.GetSaveData(this._srcIndex ^ 1).GetData();
      SaveDataManager.Instance.GetSaveData(this._srcIndex).CopyData(data);
    }
  }
}
