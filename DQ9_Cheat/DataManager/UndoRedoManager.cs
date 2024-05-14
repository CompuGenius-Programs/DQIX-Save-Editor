// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class UndoRedoManager
  {
    private Stack<UndoRedoInfo> _undoInfoList = new Stack<UndoRedoInfo>();
    private Stack<UndoRedoInfo> _redoInfoList = new Stack<UndoRedoInfo>();
    private int? _savedIndex = new int?(0);
    private bool _loading;
    private bool _executing;
    private int _pluralCount;
    private UndoRedoInfo _pluralUndoRedoInfo;

    public event UndoRedoManager.SavedIndexChangedHandler SavedIndexChanged;

    public void Initialize()
    {
      this._undoInfoList.Clear();
      this._redoInfoList.Clear();
      this._savedIndex = new int?(0);
    }

    public bool EditFlag
    {
      get
      {
        if (!this._savedIndex.HasValue)
          return true;
        int? savedIndex = this._savedIndex;
        return savedIndex.GetValueOrDefault() != 0 || !savedIndex.HasValue;
      }
    }

    public void OnSave() => this._savedIndex = new int?(0);

    public void OnLoading() => this._loading = true;

    public void OnLoaded()
    {
      this._loading = false;
      this.Initialize();
    }

    public bool IsUndo => this._undoInfoList.Count > 0;

    public bool IsRedo => this._redoInfoList.Count > 0;

    public void BeginPluralEdit()
    {
      if (this._executing || this._loading)
        return;
      if (this._pluralCount == 0)
        this._pluralUndoRedoInfo = new UndoRedoInfo();
      ++this._pluralCount;
    }

    public void EndPluralEdit()
    {
      if (this._executing || this._loading)
        return;
      --this._pluralCount;
      if (this._pluralCount < 0)
        this._pluralCount = 0;
      if (this._pluralCount != 0)
        return;
      if (this._pluralUndoRedoInfo.Count > 0)
      {
        if (this._redoInfoList.Count > 0)
        {
          this._redoInfoList.Clear();
          int? savedIndex = this._savedIndex;
          if ((savedIndex.GetValueOrDefault() <= 0 ? 0 : (savedIndex.HasValue ? 1 : 0)) != 0)
            this._savedIndex = new int?();
        }
        this._undoInfoList.Push(this._pluralUndoRedoInfo);
        if (this._savedIndex.HasValue)
        {
          UndoRedoManager undoRedoManager = this;
          int? savedIndex = undoRedoManager._savedIndex;
          undoRedoManager._savedIndex = savedIndex.HasValue ? new int?(savedIndex.GetValueOrDefault() - 1) : new int?();
          if (this.SavedIndexChanged != null)
            this.SavedIndexChanged();
        }
      }
      this._pluralUndoRedoInfo = (UndoRedoInfo) null;
    }

    public void CancelPluralEdit()
    {
      if (this._pluralUndoRedoInfo == null)
        return;
      this._pluralUndoRedoInfo.Dispose();
      this._pluralUndoRedoInfo = (UndoRedoInfo) null;
    }

    public void Edited(UndoRedoElement element)
    {
      if (this._executing || this._loading)
        return;
      if (this._pluralCount > 0)
      {
        this._pluralUndoRedoInfo.Add(element);
      }
      else
      {
        if (this._redoInfoList.Count > 0)
        {
          this._redoInfoList.Clear();
          int? savedIndex = this._savedIndex;
          if ((savedIndex.GetValueOrDefault() <= 0 ? 0 : (savedIndex.HasValue ? 1 : 0)) != 0)
            this._savedIndex = new int?();
        }
        UndoRedoInfo undoRedoInfo = new UndoRedoInfo();
        undoRedoInfo.Add(element);
        this._undoInfoList.Push(undoRedoInfo);
        if (!this._savedIndex.HasValue)
          return;
        UndoRedoManager undoRedoManager = this;
        int? savedIndex1 = undoRedoManager._savedIndex;
        undoRedoManager._savedIndex = savedIndex1.HasValue ? new int?(savedIndex1.GetValueOrDefault() - 1) : new int?();
        if (this.SavedIndexChanged == null)
          return;
        this.SavedIndexChanged();
      }
    }

    public bool Undo()
    {
      if (this._undoInfoList.Count <= 0)
        return false;
      this._executing = true;
      UndoRedoInfo undoRedoInfo = this._undoInfoList.Pop();
      undoRedoInfo.Undo();
      this._redoInfoList.Push(undoRedoInfo);
      if (this._savedIndex.HasValue)
      {
        UndoRedoManager undoRedoManager = this;
        int? savedIndex = undoRedoManager._savedIndex;
        undoRedoManager._savedIndex = savedIndex.HasValue ? new int?(savedIndex.GetValueOrDefault() + 1) : new int?();
        if (this.SavedIndexChanged != null)
          this.SavedIndexChanged();
      }
      this._executing = false;
      return true;
    }

    public bool Redo()
    {
      if (this._redoInfoList.Count <= 0)
        return false;
      this._executing = true;
      UndoRedoInfo undoRedoInfo = this._redoInfoList.Pop();
      undoRedoInfo.Redo();
      this._undoInfoList.Push(undoRedoInfo);
      if (this._savedIndex.HasValue)
      {
        UndoRedoManager undoRedoManager = this;
        int? savedIndex = undoRedoManager._savedIndex;
        undoRedoManager._savedIndex = savedIndex.HasValue ? new int?(savedIndex.GetValueOrDefault() - 1) : new int?();
        if (this.SavedIndexChanged != null)
          this.SavedIndexChanged();
      }
      this._executing = false;
      return true;
    }

    public delegate void SavedIndexChangedHandler();
  }
}
