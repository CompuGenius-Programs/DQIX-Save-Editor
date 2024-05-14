// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoElement
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;

namespace DQ9_Cheat.DataManager;

internal abstract class UndoRedoElement
{
    private readonly int _dataIndex;
    private bool _disposed;

    protected UndoRedoElement()
    {
        _dataIndex = SaveDataManager.Instance.SelectedDataIndex;
    }

    public string Title { get; set; } = string.Empty;

    protected SaveData GetSaveData()
    {
        return SaveDataManager.Instance.GetSaveData(_dataIndex);
    }

    public abstract void Undo();

    public abstract void Redo();

    ~UndoRedoElement()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        OnDispose();
        var num = disposing ? 1 : 0;
        _disposed = true;
    }

    protected virtual void OnDispose()
    {
    }
}