// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.QuestDataManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.DataManager;

internal class QuestDataManager
{
    private const int OrderCountMax = 8;
    private readonly DataValue<byte> _orderCount;
    private readonly DataValue<ushort>[] _orderInfomation = new DataValue<ushort>[8];
    private readonly QuestMatterData[] _questMatterData;

    public QuestDataManager(SaveData owner)
    {
        ClearCount = new DataValue<byte>(owner, 16035U, null, 0, byte.MaxValue);
        _orderCount = new DataValue<byte>(owner, 12404U, null, 0, 8);
        for (var index = 0; index < 8; ++index)
            _orderInfomation[index] =
                new DataValue<ushort>(owner, (uint)(12408 + 16 * index), null, 0, ushort.MaxValue);
        _questMatterData = new QuestMatterData[QuestDataList.List.Count];
        for (var index = 0; index < QuestDataList.List.Count; ++index)
            _questMatterData[index] = new QuestMatterData(owner, index);
    }

    public DataValue<byte> ClearCount { get; }

    public byte OrderCount => _orderCount.Value;

    public void ReviseClearCount()
    {
        byte num = 0;
        foreach (var questMatterData in _questMatterData)
            if (questMatterData.State == QuestState.Clear)
                ++num;
        ClearCount.Value = num;
    }

    public void ReviseOrderCount()
    {
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        var byteList1 = new List<byte>();
        var byteList2 = new List<byte>();
        for (var index1 = 0; index1 < _orderCount.Value; ++index1)
        {
            var num = (byte)(_orderInfomation[index1].Value & (uint)byte.MaxValue);
            var flag = false;
            for (var index2 = 0; index2 < QuestDataList.List.Count; ++index2)
                if (QuestDataList.List[index2].DataIndex == num)
                {
                    if (_questMatterData[index2].State != QuestState.Order)
                        byteList1.Add(num);
                    else
                        byteList2.Add(num);
                    flag = true;
                    break;
                }

            if (!flag)
                byteList1.Add(num);
        }

        foreach (int dataIndex in byteList1)
            RemoveOrderInfomation(dataIndex);
        byteList1.Clear();
        for (var index = 0; index < _questMatterData.Length && _orderCount.Value < 8; ++index)
            if (_questMatterData[index].State == QuestState.Order &&
                !byteList2.Contains(QuestDataList.List[index].DataIndex))
                AddOrderInformation(QuestDataList.List[index].DataIndex);
        byteList2.Clear();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public QuestState GetState(int index)
    {
        return index >= 0 && index < _questMatterData.Length ? _questMatterData[index].State : QuestState.BeforeOrder;
    }

    public ushort GetYear(int index)
    {
        return index >= 0 && index < _questMatterData.Length ? _questMatterData[index].Year : (ushort)0;
    }

    public byte GetMonth(int index)
    {
        return index >= 0 && index < _questMatterData.Length ? _questMatterData[index].Month : (byte)0;
    }

    public byte GetDay(int index)
    {
        return index >= 0 && index < _questMatterData.Length ? _questMatterData[index].Day : (byte)0;
    }

    public byte GetHour(int index)
    {
        return index >= 0 && index < _questMatterData.Length ? _questMatterData[index].Hour : (byte)0;
    }

    public byte GetMinute(int index)
    {
        return index >= 0 && index < _questMatterData.Length ? _questMatterData[index].Minute : (byte)0;
    }

    public void SetYear(int index, ushort value)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        _questMatterData[index].Year = value;
    }

    public void SetMonth(int index, byte value)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        _questMatterData[index].Month = value;
    }

    public void SetDay(int index, byte value)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        _questMatterData[index].Day = value;
    }

    public void SetHour(int index, byte value)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        _questMatterData[index].Hour = value;
    }

    public void SetMinute(int index, byte value)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        _questMatterData[index].Minute = value;
    }

    public void SetStateNone(int index)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        RemoveOrderInfomation(QuestDataList.List[index].DataIndex);
        _questMatterData[index].SetNone();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void SetStateAllowOrder(int index)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        RemoveOrderInfomation(QuestDataList.List[index].DataIndex);
        _questMatterData[index].SetAllowOrder();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void SetStateOrder(int index)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        AddOrderInformation(QuestDataList.List[index].DataIndex);
        _questMatterData[index].SetOrder();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void SetStateClear(int index)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        RemoveOrderInfomation(QuestDataList.List[index].DataIndex);
        _questMatterData[index].SetClear();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void SetStateRecieve(int index)
    {
        if (index < 0 || index >= _questMatterData.Length)
            return;
        var questElement = QuestDataList.List[index];
        if (!questElement.AdditionalQuest)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        RemoveOrderInfomation(questElement.DataIndex);
        _questMatterData[index].SetRecieve();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    private void AddOrderInformation(int dataIndex)
    {
        if (_orderCount.Value >= 8)
            return;
        for (var index = 0; index < _orderCount.Value; ++index)
            if ((byte)(_orderInfomation[index].Value & (uint)byte.MaxValue) == dataIndex)
                return;
        _orderInfomation[_orderCount.Value].Value = (ushort)(dataIndex | 3072);
        ++_orderCount.Value;
    }

    private void RemoveOrderInfomation(int dataIndex)
    {
        for (var index1 = 0; index1 < _orderCount.Value; ++index1)
            if ((byte)(_orderInfomation[index1].Value & (uint)byte.MaxValue) == dataIndex)
            {
                for (var index2 = index1; index2 < _orderCount.Value; ++index2)
                    _orderInfomation[index2].Value = index2 != _orderCount.Value - 1
                        ? _orderInfomation[index2 + 1].Value
                        : (ushort)0;
                --_orderCount.Value;
            }
    }

    private class QuestMatterData
    {
        private readonly DataValue<byte> _clearFlag;
        private readonly DataValue<uint> _dateTime;
        private readonly int _index;
        private readonly DataValue<byte> _state;

        public QuestMatterData(SaveData owner, int index)
        {
            _index = index;
            var questElement = QuestDataList.List[index];
            _state = new DataValue<byte>(owner, (uint)(12300 + questElement.DataIndex / 2), null, 0, byte.MaxValue);
            _clearFlag = new DataValue<byte>(owner, (uint)(12536 + questElement.DataIndex / 8), null, 0, byte.MaxValue);
            _dateTime = new DataValue<uint>(owner, (uint)(12564 + questElement.DataIndex * 4), null, 0U, uint.MaxValue);
        }

        public QuestState State
        {
            get
            {
                var questElement = QuestDataList.List[_index];
                var num = (questElement.DataIndex & 1) != 0
                    ? (byte)((uint)_state.Value >> 4)
                    : (byte)(_state.Value & 15U);
                var innerQuestState = (InnerQuestState)(num & 7);
                if (questElement.AdditionalQuest)
                {
                    if (innerQuestState != InnerQuestState.None)
                    {
                        if ((num & 8) == 0)
                            innerQuestState = InnerQuestState.None;
                    }
                    else if ((num & 8) != 0)
                    {
                        innerQuestState = InnerQuestState.Recieved;
                    }
                }

                if (ClearFlag)
                    innerQuestState = InnerQuestState.Clear;
                switch (innerQuestState)
                {
                    case InnerQuestState.AllowOrder:
                        return QuestState.AllowOrder;
                    case InnerQuestState.Order:
                        return QuestState.Order;
                    case InnerQuestState.Clear:
                        return QuestState.Clear;
                    case InnerQuestState.Recieved:
                        return QuestState.BeforeOrder;
                    default:
                        return questElement.AdditionalQuest ? QuestState.NotRecieved : QuestState.BeforeOrder;
                }
            }
        }

        private bool ClearFlag => (_clearFlag.Value & (1 << (QuestDataList.List[_index].DataIndex % 8))) != 0;

        public ushort Year
        {
            get => (ushort)(2000 + ((int)_dateTime.Value & sbyte.MaxValue));
            set => _dateTime.Value =
                (uint)(((int)_dateTime.Value & sbyte.MinValue) | ((value - 2000) & sbyte.MaxValue));
        }

        public byte Month
        {
            get => (byte)((_dateTime.Value & 1920U) >> 7);
            set => _dateTime.Value = (uint)(((int)_dateTime.Value & -1921) | ((value << 7) & 1920));
        }

        public byte Day
        {
            get => (byte)((_dateTime.Value & 63488U) >> 11);
            set => _dateTime.Value = (uint)(((int)_dateTime.Value & -63489) | ((value << 11) & 63488));
        }

        public byte Hour
        {
            get => (byte)((_dateTime.Value & 2031616U) >> 16);
            set => _dateTime.Value = (uint)(((int)_dateTime.Value & -2031617) | ((value << 16) & 2031616));
        }

        public byte Minute
        {
            get => (byte)((_dateTime.Value & 132120576U) >> 21);
            set => _dateTime.Value = (uint)(((int)_dateTime.Value & -132120577) | ((value << 21) & 132120576));
        }

        internal void SetNone()
        {
            var questElement = QuestDataList.List[_index];
            if ((questElement.DataIndex & 1) == 0)
                _state.Value &= 240;
            else
                _state.Value &= 15;
            _clearFlag.Value &= (byte)~(1 << (questElement.DataIndex % 8));
        }

        internal void SetAllowOrder()
        {
            var questElement = QuestDataList.List[_index];
            if ((questElement.DataIndex & 1) == 0)
                _state.Value = (byte)((_state.Value & 240) | 1 | (questElement.AdditionalQuest ? 8 : 0));
            else
                _state.Value = (byte)((_state.Value & 15) | 16 | (questElement.AdditionalQuest ? 128 : 0));
        }

        internal void SetOrder()
        {
            var questElement = QuestDataList.List[_index];
            _state.Value = (questElement.DataIndex & 1) != 0
                ? (byte)((_state.Value & 15) | 32 | (questElement.AdditionalQuest ? 128 : 0))
                : (byte)((_state.Value & 240) | 2 | (questElement.AdditionalQuest ? 8 : 0));
            _clearFlag.Value &= (byte)~(1 << (questElement.DataIndex % 8));
        }

        internal void SetClear()
        {
            var questElement = QuestDataList.List[_index];
            _state.Value = (questElement.DataIndex & 1) != 0
                ? (byte)((_state.Value & 15) | 48 | (questElement.AdditionalQuest ? 128 : 0))
                : (byte)((_state.Value & 240) | 3 | (questElement.AdditionalQuest ? 8 : 0));
            _clearFlag.Value = (byte)((_clearFlag.Value & ~(1 << (questElement.DataIndex % 8))) |
                                      (1 << (questElement.DataIndex % 8)));
        }

        internal void SetRecieve()
        {
            var questElement = QuestDataList.List[_index];
            if (!questElement.AdditionalQuest)
                return;
            _state.Value = (questElement.DataIndex & 1) != 0
                ? (byte)((_state.Value & 15) | 128)
                : (byte)((_state.Value & 240) | 8);
            _clearFlag.Value &= (byte)~(1 << (questElement.DataIndex % 8));
        }

        private enum InnerQuestState
        {
            None = 0,
            AllowOrder = 1,
            Order = 2,
            Clear = 3,
            Recieved = 8
        }
    }
}