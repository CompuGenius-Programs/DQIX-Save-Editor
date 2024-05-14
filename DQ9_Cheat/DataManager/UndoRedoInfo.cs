// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoInfo
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;

namespace DQ9_Cheat.DataManager;

internal class UndoRedoInfo
{
    private bool _disposed;
    private List<UndoRedoElement> _undoRedoElementList = [];

    public int Count => _undoRedoElementList.Count;

    public void Add(UndoRedoElement element)
    {
        _undoRedoElementList.Add(element);
    }

    public void Undo()
    {
        for (var index = _undoRedoElementList.Count - 1; index >= 0; --index)
            _undoRedoElementList[index].Undo();
    }

    public void Redo()
    {
        foreach (var undoRedoElement in _undoRedoElementList)
            undoRedoElement.Redo();
    }

    ~UndoRedoInfo()
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
        foreach (var undoRedoElement in _undoRedoElementList)
            undoRedoElement.Dispose();
        _undoRedoElementList.Clear();
        _undoRedoElementList = null;
        var num = disposing ? 1 : 0;
        _disposed = true;
    }
}