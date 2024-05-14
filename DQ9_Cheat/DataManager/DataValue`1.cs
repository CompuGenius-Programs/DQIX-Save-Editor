// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.DataValue`1
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DQ9_Cheat.DataManager;

internal class DataValue<T> : DataValueBase where T : IComparable, IConvertible, IComparable<T>, IEquatable<T>
{
    private readonly Stack<T> _redoValueList = new();
    private readonly Stack<T> _undoValueList = new();

    public DataValue(SaveData owner, uint offset, Control control, T min, T max)
    {
        _dataOffset = offset;
        _relationalControl = control;
        Min = min;
        Max = max;
        _owner = owner;
    }

    public T Min { get; }

    public T Max { get; }

    private unsafe T InnerValue
    {
        set
        {
            if (value.CompareTo(Min) < 0 || value.CompareTo(Max) > 0 || value.CompareTo(Value) == 0)
                return;
            var length = Marshal.SizeOf(value);
            var numArray = new byte[length];
            fixed (byte* numPtr = &numArray[0])
            {
                var ptr = new IntPtr(numPtr);
                Marshal.StructureToPtr(value, ptr, true);
            }

            if ((object)value is bool)
                length = 1;
            for (var index = 0; index < length; ++index)
                _owner.Data[_dataOffset + index] = numArray[index];
        }
    }

    public unsafe T Value
    {
        get
        {
            var min = Min;
            T obj;
            fixed (byte* numPtr = &_owner.Data[(int)_dataOffset])
            {
                obj = (T)Marshal.PtrToStructure(new IntPtr(numPtr), min.GetType());
            }

            if (obj.CompareTo(Min) < 0)
                obj = Min;
            if (obj.CompareTo(Max) > 0)
                obj = Max;
            return obj;
        }
        set
        {
            if (value.CompareTo(Min) < 0 || value.CompareTo(Max) > 0 || value.CompareTo(Value) == 0)
                return;
            if (_redoValueList.Count > 0)
                _redoValueList.Clear();
            _undoValueList.Push(Value);
            var length = Marshal.SizeOf(value);
            var numArray = new byte[length];
            fixed (byte* numPtr = &numArray[0])
            {
                var ptr = new IntPtr(numPtr);
                Marshal.StructureToPtr(value, ptr, true);
            }

            if ((object)value is bool)
                length = 1;
            for (var index = 0; index < length; ++index)
                _owner.Data[_dataOffset + index] = numArray[index];
            SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoDataValue(this));
        }
    }

    public override void Undo()
    {
        if (_undoValueList.Count <= 0)
            return;
        var obj = _undoValueList.Pop();
        _redoValueList.Push(Value);
        InnerValue = obj;
    }

    public override void Redo()
    {
        if (_redoValueList.Count <= 0)
            return;
        var obj = _redoValueList.Pop();
        _undoValueList.Push(Value);
        InnerValue = obj;
    }
}