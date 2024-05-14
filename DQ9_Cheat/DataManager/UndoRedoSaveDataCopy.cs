// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoSaveDataCopy
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.DataManager;

internal class UndoRedoSaveDataCopy : UndoRedoElement
{
    private byte[] _data;
    private readonly int _srcIndex;

    public UndoRedoSaveDataCopy(int srcIndex)
    {
        _srcIndex = srcIndex;
        _data = SaveDataManager.Instance.GetSaveData(_srcIndex).GetData();
    }

    protected override void OnDispose()
    {
        _data = null;
    }

    public override void Undo()
    {
        SaveDataManager.Instance.GetSaveData(_srcIndex).CopyData(_data);
    }

    public override void Redo()
    {
        var data = SaveDataManager.Instance.GetSaveData(_srcIndex ^ 1).GetData();
        SaveDataManager.Instance.GetSaveData(_srcIndex).CopyData(data);
    }
}