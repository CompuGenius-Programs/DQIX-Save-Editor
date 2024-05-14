// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.DataValue`1
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
      _dataOffset = offset;
      _relationalControl = control;
      _min = min;
      _max = max;
      _owner = owner;
    }

    public override void Undo()
    {
      if (_undoValueList.Count <= 0)
        return;
      T obj = _undoValueList.Pop();
      _redoValueList.Push(Value);
      InnerValue = obj;
    }

    public override void Redo()
    {
      if (_redoValueList.Count <= 0)
        return;
      T obj = _redoValueList.Pop();
      _undoValueList.Push(Value);
      InnerValue = obj;
    }

    public T Min => _min;

    public T Max => _max;

    private unsafe T InnerValue
    {
      set
      {
        if (value.CompareTo(_min) < 0 || value.CompareTo(_max) > 0 || value.CompareTo(Value) == 0)
          return;
        int length = Marshal.SizeOf(value);
        byte[] numArray = new byte[length];
        fixed (byte* numPtr = &numArray[0])
        {
          IntPtr ptr = new IntPtr(numPtr);
          Marshal.StructureToPtr(value, ptr, true);
        }
        if ((object) value is bool)
          length = 1;
        for (int index = 0; index < length; ++index)
          _owner.Data[_dataOffset + index] = numArray[index];
      }
    }

    public unsafe T Value
    {
      get
      {
        T min = _min;
        T obj;
        fixed (byte* numPtr = &_owner.Data[(int) _dataOffset])
          obj = (T) Marshal.PtrToStructure(new IntPtr(numPtr), min.GetType());
        if (obj.CompareTo(_min) < 0)
          obj = _min;
        if (obj.CompareTo(_max) > 0)
          obj = _max;
        return obj;
      }
      set
      {
        if (value.CompareTo(_min) < 0 || value.CompareTo(_max) > 0 || value.CompareTo(Value) == 0)
          return;
        if (_redoValueList.Count > 0)
          _redoValueList.Clear();
        _undoValueList.Push(Value);
        int length = Marshal.SizeOf(value);
        byte[] numArray = new byte[length];
        fixed (byte* numPtr = &numArray[0])
        {
          IntPtr ptr = new IntPtr(numPtr);
          Marshal.StructureToPtr(value, ptr, true);
        }
        if ((object) value is bool)
          length = 1;
        for (int index = 0; index < length; ++index)
          _owner.Data[_dataOffset + index] = numArray[index];
        SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoDataValue(this));
      }
    }
  }
}
