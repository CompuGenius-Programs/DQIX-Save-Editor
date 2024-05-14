// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.DataValueString
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using System.Windows.Forms;
using FriedGinger.DQCheat;

namespace DQ9_Cheat.DataManager
{
  internal class DataValueString : DataValueBase
  {
    private int _maxLength;
    private bool _addNull;
    private byte[] _defaultFillData;
    private Stack<string> _undoValueList = new Stack<string>();
    private Stack<string> _redoValueList = new Stack<string>();

    public DataValueString(
      SaveData owner,
      uint offset,
      Control control,
      int maxLength,
      bool addNull)
    {
      _dataOffset = offset;
      _addNull = addNull;
      _relationalControl = control;
      _maxLength = maxLength;
      _owner = owner;
    }

    public DataValueString(
      SaveData owner,
      uint offset,
      Control control,
      int maxLength,
      bool addNull,
      byte[] fillData)
    {
      _dataOffset = offset;
      _addNull = addNull;
      _relationalControl = control;
      _maxLength = maxLength;
      _owner = owner;
      _defaultFillData = fillData;
    }

    public int MaxLength => _maxLength;

    private string InnerValue
    {
      set
      {
        byte[] numArray = _dataOffset == 23176U ? StringFixer.GetTemplateBytes(value) : StringFixer.GetBytes(value);
        for (int index = 0; index < _maxLength; ++index)
        {
          if (numArray.Length > index)
            _owner.Data[_dataOffset + index] = numArray[index];
          else if (_defaultFillData != null)
            _owner.Data[_dataOffset + index] = _defaultFillData[index % _defaultFillData.Length];
          else
            _owner.Data[_dataOffset + index] = 0;
        }
        if (!_addNull)
          return;
        _owner.Data[_dataOffset + _maxLength] = 0;
      }
    }

    public string Value
    {
      get
      {
        int count = 0;
        byte[] bytes = new byte[_maxLength];
        for (int index = 0; index < _maxLength; ++index)
        {
          bytes[index] = _owner.Data[_dataOffset + index];
          if (bytes[index] != 0)
            ++count;
          else if (bytes[index] == 0)
            break;
        }
        return _dataOffset != 23176U ? StringFixer.GetString(bytes, count) : StringFixer.GetTemplateString(bytes, count);
      }
      set
      {
        if (Value != value)
        {
          if (_redoValueList.Count > 0)
            _redoValueList.Clear();
          _undoValueList.Push(Value);
          byte[] numArray = _dataOffset == 23176U ? StringFixer.GetTemplateBytes(value) : StringFixer.GetBytes(value);
          for (int index = 0; index < _maxLength; ++index)
          {
            if (numArray.Length > index)
              _owner.Data[_dataOffset + index] = numArray[index];
            else
              _owner.Data[_dataOffset + index] = 0;
          }
          if (_addNull)
            _owner.Data[_dataOffset + _maxLength] = 0;
        }
        SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoDataValue(this));
      }
    }

    public override void Undo()
    {
      if (_undoValueList.Count <= 0)
        return;
      string str = _undoValueList.Pop();
      _redoValueList.Push(Value);
      InnerValue = str;
    }

    public override void Redo()
    {
      if (_redoValueList.Count <= 0)
        return;
      string str = _redoValueList.Pop();
      _undoValueList.Push(Value);
      InnerValue = str;
    }
  }
}
