// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoElement
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal abstract class UndoRedoElement
  {
    private int _dataIndex;
    private string _title = string.Empty;
    private bool _disposed;

    protected UndoRedoElement() => this._dataIndex = SaveDataManager.Instance.SelectedDataIndex;

    protected SaveData GetSaveData() => SaveDataManager.Instance.GetSaveData(this._dataIndex);

    public string Title
    {
      get => this._title;
      set => this._title = value;
    }

    public abstract void Undo();

    public abstract void Redo();

    ~UndoRedoElement() => this.Dispose(false);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this._disposed)
        return;
      this.OnDispose();
      int num = disposing ? 1 : 0;
      this._disposed = true;
    }

    protected virtual void OnDispose()
    {
    }
  }
}
