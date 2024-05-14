// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.DataValue`1
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class DataValue<T> : DataValueBase where T : IComparable, IConvertible, IComparable<T>, IEquatable<T>
  {
    private Stack<T> _undoValueList = new Stack<T>();
    private Stack<T> _redoValueList = new Stack<T>();
    private T _min;
    private T _max;

    public DataValue(SaveData owner, uint offset, Control control, T min, T max)
    {
      this._dataOffset = offset;
      this._relationalControl = control;
      this._min = min;
      this._max = max;
      this._owner = owner;
    }

    public override void Undo()
    {
      if (this._undoValueList.Count <= 0)
        return;
      T obj = this._undoValueList.Pop();
      this._redoValueList.Push(this.Value);
      this.InnerValue = obj;
    }

    public override void Redo()
    {
      if (this._redoValueList.Count <= 0)
        return;
      T obj = this._redoValueList.Pop();
      this._undoValueList.Push(this.Value);
      this.InnerValue = obj;
    }

    public T Min => this._min;

    public T Max => this._max;

    private unsafe T InnerValue
    {
      set
      {
        if (value.CompareTo(this._min) < 0 || value.CompareTo(this._max) > 0 || value.CompareTo(this.Value) == 0)
          return;
        int length = Marshal.SizeOf((object) value);
        byte[] numArray = new byte[length];
        fixed (byte* numPtr = &numArray[0])
        {
          IntPtr ptr = new IntPtr((void*) numPtr);
          Marshal.StructureToPtr((object) value, ptr, true);
        }
        if ((object) value is bool)
          length = 1;
        for (int index = 0; index < length; ++index)
          this._owner.Data[(long) this._dataOffset + (long) index] = numArray[index];
      }
    }

    public unsafe T Value
    {
      get
      {
        T min = this._min;
        T obj;
        fixed (byte* numPtr = &this._owner.Data[(int) this._dataOffset])
          obj = (T) Marshal.PtrToStructure(new IntPtr((void*) numPtr), min.GetType());
        if (obj.CompareTo(this._min) < 0)
          obj = this._min;
        if (obj.CompareTo(this._max) > 0)
          obj = this._max;
        return obj;
      }
      set
      {
        if (value.CompareTo(this._min) < 0 || value.CompareTo(this._max) > 0 || value.CompareTo(this.Value) == 0)
          return;
        if (this._redoValueList.Count > 0)
          this._redoValueList.Clear();
        this._undoValueList.Push(this.Value);
        int length = Marshal.SizeOf((object) value);
        byte[] numArray = new byte[length];
        fixed (byte* numPtr = &numArray[0])
        {
          IntPtr ptr = new IntPtr((void*) numPtr);
          Marshal.StructureToPtr((object) value, ptr, true);
        }
        if ((object) value is bool)
          length = 1;
        for (int index = 0; index < length; ++index)
          this._owner.Data[(long) this._dataOffset + (long) index] = numArray[index];
        SaveDataManager.Instance.UndoRedoMgr.Edited((UndoRedoElement) new UndoRedoDataValue((DataValueBase) this));
      }
    }
  }
}
