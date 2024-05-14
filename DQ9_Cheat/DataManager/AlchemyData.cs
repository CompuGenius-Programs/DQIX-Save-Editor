// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.AlchemyData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.DataManager;

internal class AlchemyData
{
    private readonly DataValue<ushort>[] _alchemyFlag = new DataValue<ushort>[471];
    private readonly DataValue<ushort> _compCount;
    private bool _onSaveArrangement;

    public AlchemyData(SaveData owner)
    {
        _compCount = new DataValue<ushort>(owner, 16042U, null, 0, ushort.MaxValue);
        for (uint index = 0; index < _alchemyFlag.Length; ++index)
            _alchemyFlag[(int)index] =
                new DataValue<ushort>(owner, (uint)(15020 + (int)index * 2), null, 0, ushort.MaxValue);
    }

    public ushort CompCount
    {
        get => (ushort)((_compCount.Value & 65408) >> 7);
        private set => _compCount.Value = (ushort)((_compCount.Value & sbyte.MaxValue) | ((value << 7) & 65408));
    }

    public void OnLoaded()
    {
        _onSaveArrangement = false;
    }

    public void OnSaving()
    {
        if (!_onSaveArrangement)
            return;
        Arrangement();
    }

    public AlchemyState GetAlchemyState(int alchemyIndex)
    {
        var num1 = (ushort)(alchemyIndex * 4 + 7);
        var num2 = (ushort)(alchemyIndex * 4 + 5);
        for (var index = 0; index < 471; ++index)
        {
            if (_alchemyFlag[index].Value == num1)
                return AlchemyState.Created;
            if (_alchemyFlag[index].Value == num2)
                return AlchemyState.Appear;
        }

        return AlchemyState.NotAppear;
    }

    public bool IsAlchemyCreated(int alchemyIndex)
    {
        return GetAlchemyState(alchemyIndex) == AlchemyState.Created;
    }

    public void SetAlchemyState(int alchemyIndex, AlchemyState value)
    {
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        var allAlchemyList = ItemDataList.GetAllAlchemyList();
        var num1 = (ushort)(alchemyIndex * 4 + 7);
        var num2 = (ushort)(alchemyIndex * 4 + 5);
        var flag = false;
        foreach (var itemDataBase in allAlchemyList)
            if (itemDataBase.AlchemyIndex == alchemyIndex)
            {
                flag = itemDataBase.AlchemyRate;
                break;
            }

        if (value != AlchemyState.Created)
        {
            for (var index = 0; index < 471; ++index)
                if (_alchemyFlag[index].Value == num1)
                {
                    _alchemyFlag[index].Value = 0;
                    _onSaveArrangement = true;
                    if (flag)
                    {
                        --CompCount;
                        flag = false;
                    }
                }
        }
        else
        {
            var index1 = -1;
            for (var index2 = 0; index2 < 471; ++index2)
                if (index1 == -1 && _alchemyFlag[index2].Value == 0)
                {
                    index1 = index2;
                }
                else
                {
                    if (_alchemyFlag[index2].Value == num1)
                    {
                        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
                        return;
                    }

                    if (_alchemyFlag[index2].Value == num2)
                    {
                        _alchemyFlag[index2].Value = num1;
                        if (flag)
                            ++CompCount;
                        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
                        return;
                    }
                }

            if (index1 != -1)
            {
                _alchemyFlag[index1].Value = num1;
                if (flag)
                    ++CompCount;
            }
        }

        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void Arrangement()
    {
        var intList = new List<int>();
        var allAlchemyList = ItemDataList.GetAllAlchemyList();
        var index1 = -1;
        ushort num1 = 0;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        for (var index2 = 0; index2 < 471; ++index2)
        {
            if (_alchemyFlag[index2].Value != 0)
            {
                var num2 = 0;
                AlchemyState alchemyState;
                switch (_alchemyFlag[index2].Value % 4)
                {
                    case 1:
                        alchemyState = AlchemyState.Appear;
                        num2 = (_alchemyFlag[index2].Value - 5) / 4;
                        break;
                    case 3:
                        alchemyState = AlchemyState.Created;
                        num2 = (_alchemyFlag[index2].Value - 7) / 4;
                        break;
                    default:
                        alchemyState = AlchemyState.NotAppear;
                        _alchemyFlag[index2].Value = 0;
                        break;
                }

                if (alchemyState != AlchemyState.NotAppear)
                {
                    if (intList.Contains(num2))
                    {
                        _alchemyFlag[index2].Value = 0;
                    }
                    else
                    {
                        foreach (var itemDataBase in allAlchemyList)
                            if (itemDataBase.AlchemyIndex == num2)
                            {
                                if (itemDataBase.AlchemyRate && alchemyState == AlchemyState.Created) ++num1;
                                break;
                            }

                        intList.Add(num2);
                        if (index1 != -1)
                        {
                            _alchemyFlag[index1].Value = _alchemyFlag[index2].Value;
                            _alchemyFlag[index2].Value = 0;
                            ++index1;
                        }
                    }
                }
            }

            if (index1 == -1 && _alchemyFlag[index2].Value == 0)
                index1 = index2;
        }

        CompCount = num1;
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        intList.Clear();
    }
}