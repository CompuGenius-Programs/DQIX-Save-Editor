// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.DataValueString
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using FriedGinger.DQCheat;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
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
      this._dataOffset = offset;
      this._addNull = addNull;
      this._relationalControl = control;
      this._maxLength = maxLength;
      this._owner = owner;
    }

    public DataValueString(
      SaveData owner,
      uint offset,
      Control control,
      int maxLength,
      bool addNull,
      byte[] fillData)
    {
      this._dataOffset = offset;
      this._addNull = addNull;
      this._relationalControl = control;
      this._maxLength = maxLength;
      this._owner = owner;
      this._defaultFillData = fillData;
    }

    public int MaxLength => this._maxLength;

    private string InnerValue
    {
      set
      {
        byte[] numArray = this._dataOffset == 23176U ? StringFixer.GetTemplateBytes(value) : StringFixer.GetBytes(value);
        for (int index = 0; index < this._maxLength; ++index)
        {
          if (numArray.Length > index)
            this._owner.Data[(long) this._dataOffset + (long) index] = numArray[index];
          else if (this._defaultFillData != null)
            this._owner.Data[(long) this._dataOffset + (long) index] = this._defaultFillData[index % this._defaultFillData.Length];
          else
            this._owner.Data[(long) this._dataOffset + (long) index] = (byte) 0;
        }
        if (!this._addNull)
          return;
        this._owner.Data[(long) this._dataOffset + (long) this._maxLength] = (byte) 0;
      }
    }

    public string Value
    {
      get
      {
        int count = 0;
        byte[] bytes = new byte[this._maxLength];
        for (int index = 0; index < this._maxLength; ++index)
        {
          bytes[index] = this._owner.Data[(long) this._dataOffset + (long) index];
          if (bytes[index] != (byte) 0)
            ++count;
          else if (bytes[index] == (byte) 0)
            break;
        }
        return this._dataOffset != 23176U ? StringFixer.GetString(bytes, count) : StringFixer.GetTemplateString(bytes, count);
      }
      set
      {
        if (this.Value != value)
        {
          if (this._redoValueList.Count > 0)
            this._redoValueList.Clear();
          this._undoValueList.Push(this.Value);
          byte[] numArray = this._dataOffset == 23176U ? StringFixer.GetTemplateBytes(value) : StringFixer.GetBytes(value);
          for (int index = 0; index < this._maxLength; ++index)
          {
            if (numArray.Length > index)
              this._owner.Data[(long) this._dataOffset + (long) index] = numArray[index];
            else
              this._owner.Data[(long) this._dataOffset + (long) index] = (byte) 0;
          }
          if (this._addNull)
            this._owner.Data[(long) this._dataOffset + (long) this._maxLength] = (byte) 0;
        }
        SaveDataManager.Instance.UndoRedoMgr.Edited((UndoRedoElement) new UndoRedoDataValue((DataValueBase) this));
      }
    }

    public override void Undo()
    {
      if (this._undoValueList.Count <= 0)
        return;
      string str = this._undoValueList.Pop();
      this._redoValueList.Push(this.Value);
      this.InnerValue = str;
    }

    public override void Redo()
    {
      if (this._redoValueList.Count <= 0)
        return;
      string str = this._redoValueList.Pop();
      this._undoValueList.Push(this.Value);
      this.InnerValue = str;
    }
  }
}
