// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoInfo
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class UndoRedoInfo
  {
    private List<UndoRedoElement> _undoRedoElementList = new List<UndoRedoElement>();
    private bool _disposed;

    public void Add(UndoRedoElement element) => this._undoRedoElementList.Add(element);

    public int Count => this._undoRedoElementList.Count;

    public void Undo()
    {
      for (int index = this._undoRedoElementList.Count - 1; index >= 0; --index)
        this._undoRedoElementList[index].Undo();
    }

    public void Redo()
    {
      foreach (UndoRedoElement undoRedoElement in this._undoRedoElementList)
        undoRedoElement.Redo();
    }

    ~UndoRedoInfo() => this.Dispose(false);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this._disposed)
        return;
      foreach (UndoRedoElement undoRedoElement in this._undoRedoElementList)
        undoRedoElement.Dispose();
      this._undoRedoElementList.Clear();
      this._undoRedoElementList = (List<UndoRedoElement>) null;
      int num = disposing ? 1 : 0;
      this._disposed = true;
    }
  }
}
