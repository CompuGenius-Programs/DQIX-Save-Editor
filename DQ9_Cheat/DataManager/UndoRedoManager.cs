// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;

namespace DQ9_Cheat.DataManager;

internal class UndoRedoManager
{
    public delegate void SavedIndexChangedHandler();

    private bool _executing;
    private bool _loading;
    private int _pluralCount;
    private UndoRedoInfo _pluralUndoRedoInfo;
    private readonly Stack<UndoRedoInfo> _redoInfoList = new();
    private int? _savedIndex = 0;
    private readonly Stack<UndoRedoInfo> _undoInfoList = new();

    public bool EditFlag
    {
        get
        {
            if (!_savedIndex.HasValue)
                return true;
            var savedIndex = _savedIndex;
            return savedIndex.GetValueOrDefault() != 0 || !savedIndex.HasValue;
        }
    }

    public bool IsUndo => _undoInfoList.Count > 0;

    public bool IsRedo => _redoInfoList.Count > 0;

    public event SavedIndexChangedHandler SavedIndexChanged;

    public void Initialize()
    {
        _undoInfoList.Clear();
        _redoInfoList.Clear();
        _savedIndex = 0;
    }

    public void OnSave()
    {
        _savedIndex = 0;
    }

    public void OnLoading()
    {
        _loading = true;
    }

    public void OnLoaded()
    {
        _loading = false;
        Initialize();
    }

    public void BeginPluralEdit()
    {
        if (_executing || _loading)
            return;
        if (_pluralCount == 0)
            _pluralUndoRedoInfo = new UndoRedoInfo();
        ++_pluralCount;
    }

    public void EndPluralEdit()
    {
        if (_executing || _loading)
            return;
        --_pluralCount;
        if (_pluralCount < 0)
            _pluralCount = 0;
        if (_pluralCount != 0)
            return;
        if (_pluralUndoRedoInfo.Count > 0)
        {
            if (_redoInfoList.Count > 0)
            {
                _redoInfoList.Clear();
                var savedIndex = _savedIndex;
                if ((savedIndex.GetValueOrDefault() <= 0 ? 0 : savedIndex.HasValue ? 1 : 0) != 0)
                    _savedIndex = new int?();
            }

            _undoInfoList.Push(_pluralUndoRedoInfo);
            if (_savedIndex.HasValue)
            {
                var undoRedoManager = this;
                var savedIndex = undoRedoManager._savedIndex;
                undoRedoManager._savedIndex = savedIndex.HasValue ? savedIndex.GetValueOrDefault() - 1 : new int?();
                if (SavedIndexChanged != null)
                    SavedIndexChanged();
            }
        }

        _pluralUndoRedoInfo = null;
    }

    public void CancelPluralEdit()
    {
        if (_pluralUndoRedoInfo == null)
            return;
        _pluralUndoRedoInfo.Dispose();
        _pluralUndoRedoInfo = null;
    }

    public void Edited(UndoRedoElement element)
    {
        if (_executing || _loading)
            return;
        if (_pluralCount > 0)
        {
            _pluralUndoRedoInfo.Add(element);
        }
        else
        {
            if (_redoInfoList.Count > 0)
            {
                _redoInfoList.Clear();
                var savedIndex = _savedIndex;
                if ((savedIndex.GetValueOrDefault() <= 0 ? 0 : savedIndex.HasValue ? 1 : 0) != 0)
                    _savedIndex = new int?();
            }

            var undoRedoInfo = new UndoRedoInfo();
            undoRedoInfo.Add(element);
            _undoInfoList.Push(undoRedoInfo);
            if (!_savedIndex.HasValue)
                return;
            var undoRedoManager = this;
            var savedIndex1 = undoRedoManager._savedIndex;
            undoRedoManager._savedIndex = savedIndex1.HasValue ? savedIndex1.GetValueOrDefault() - 1 : new int?();
            if (SavedIndexChanged == null)
                return;
            SavedIndexChanged();
        }
    }

    public bool Undo()
    {
        if (_undoInfoList.Count <= 0)
            return false;
        _executing = true;
        var undoRedoInfo = _undoInfoList.Pop();
        undoRedoInfo.Undo();
        _redoInfoList.Push(undoRedoInfo);
        if (_savedIndex.HasValue)
        {
            var undoRedoManager = this;
            var savedIndex = undoRedoManager._savedIndex;
            undoRedoManager._savedIndex = savedIndex.HasValue ? savedIndex.GetValueOrDefault() + 1 : new int?();
            if (SavedIndexChanged != null)
                SavedIndexChanged();
        }

        _executing = false;
        return true;
    }

    public bool Redo()
    {
        if (_redoInfoList.Count <= 0)
            return false;
        _executing = true;
        var undoRedoInfo = _redoInfoList.Pop();
        undoRedoInfo.Redo();
        _undoInfoList.Push(undoRedoInfo);
        if (_savedIndex.HasValue)
        {
            var undoRedoManager = this;
            var savedIndex = undoRedoManager._savedIndex;
            undoRedoManager._savedIndex = savedIndex.HasValue ? savedIndex.GetValueOrDefault() - 1 : new int?();
            if (SavedIndexChanged != null)
                SavedIndexChanged();
        }

        _executing = false;
        return true;
    }
}