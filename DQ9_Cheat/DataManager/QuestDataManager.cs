// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.QuestDataManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class QuestDataManager
  {
    private const int OrderCountMax = 8;
    private DataValue<byte> _clearCount;
    private DataValue<byte> _orderCount;
    private DataValue<ushort>[] _orderInfomation = new DataValue<ushort>[8];
    private QuestDataManager.QuestMatterData[] _questMatterData;

    public QuestDataManager(SaveData owner)
    {
      this._clearCount = new DataValue<byte>(owner, 16035U, (Control) null, (byte) 0, byte.MaxValue);
      this._orderCount = new DataValue<byte>(owner, 12404U, (Control) null, (byte) 0, (byte) 8);
      for (int index = 0; index < 8; ++index)
        this._orderInfomation[index] = new DataValue<ushort>(owner, (uint) (12408 + 16 * index), (Control) null, (ushort) 0, ushort.MaxValue);
      this._questMatterData = new QuestDataManager.QuestMatterData[QuestDataList.List.Count];
      for (int index = 0; index < QuestDataList.List.Count; ++index)
        this._questMatterData[index] = new QuestDataManager.QuestMatterData(owner, index);
    }

    public DataValue<byte> ClearCount => this._clearCount;

    public byte OrderCount => this._orderCount.Value;

    public void ReviseClearCount()
    {
      byte num = 0;
      foreach (QuestDataManager.QuestMatterData questMatterData in this._questMatterData)
      {
        if (questMatterData.State == QuestState.Clear)
          ++num;
      }
      this._clearCount.Value = num;
    }

    public void ReviseOrderCount()
    {
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      List<byte> byteList1 = new List<byte>();
      List<byte> byteList2 = new List<byte>();
      for (int index1 = 0; index1 < (int) this._orderCount.Value; ++index1)
      {
        byte num = (byte) ((uint) this._orderInfomation[index1].Value & (uint) byte.MaxValue);
        bool flag = false;
        for (int index2 = 0; index2 < QuestDataList.List.Count; ++index2)
        {
          if ((int) QuestDataList.List[index2].DataIndex == (int) num)
          {
            if (this._questMatterData[index2].State != QuestState.Order)
              byteList1.Add(num);
            else
              byteList2.Add(num);
            flag = true;
            break;
          }
        }
        if (!flag)
          byteList1.Add(num);
      }
      foreach (int dataIndex in byteList1)
        this.RemoveOrderInfomation(dataIndex);
      byteList1.Clear();
      for (int index = 0; index < this._questMatterData.Length && this._orderCount.Value < (byte) 8; ++index)
      {
        if (this._questMatterData[index].State == QuestState.Order && !byteList2.Contains(QuestDataList.List[index].DataIndex))
          this.AddOrderInformation((int) QuestDataList.List[index].DataIndex);
      }
      byteList2.Clear();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public QuestState GetState(int index)
    {
      return index >= 0 && index < this._questMatterData.Length ? this._questMatterData[index].State : QuestState.BeforeOrder;
    }

    public ushort GetYear(int index)
    {
      return index >= 0 && index < this._questMatterData.Length ? this._questMatterData[index].Year : (ushort) 0;
    }

    public byte GetMonth(int index)
    {
      return index >= 0 && index < this._questMatterData.Length ? this._questMatterData[index].Month : (byte) 0;
    }

    public byte GetDay(int index)
    {
      return index >= 0 && index < this._questMatterData.Length ? this._questMatterData[index].Day : (byte) 0;
    }

    public byte GetHour(int index)
    {
      return index >= 0 && index < this._questMatterData.Length ? this._questMatterData[index].Hour : (byte) 0;
    }

    public byte GetMinute(int index)
    {
      return index >= 0 && index < this._questMatterData.Length ? this._questMatterData[index].Minute : (byte) 0;
    }

    public void SetYear(int index, ushort value)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      this._questMatterData[index].Year = value;
    }

    public void SetMonth(int index, byte value)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      this._questMatterData[index].Month = value;
    }

    public void SetDay(int index, byte value)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      this._questMatterData[index].Day = value;
    }

    public void SetHour(int index, byte value)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      this._questMatterData[index].Hour = value;
    }

    public void SetMinute(int index, byte value)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      this._questMatterData[index].Minute = value;
    }

    public void SetStateNone(int index)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.RemoveOrderInfomation((int) QuestDataList.List[index].DataIndex);
      this._questMatterData[index].SetNone();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void SetStateAllowOrder(int index)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.RemoveOrderInfomation((int) QuestDataList.List[index].DataIndex);
      this._questMatterData[index].SetAllowOrder();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void SetStateOrder(int index)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.AddOrderInformation((int) QuestDataList.List[index].DataIndex);
      this._questMatterData[index].SetOrder();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void SetStateClear(int index)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.RemoveOrderInfomation((int) QuestDataList.List[index].DataIndex);
      this._questMatterData[index].SetClear();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void SetStateRecieve(int index)
    {
      if (index < 0 || index >= this._questMatterData.Length)
        return;
      QuestElement questElement = QuestDataList.List[index];
      if (!questElement.AdditionalQuest)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.RemoveOrderInfomation((int) questElement.DataIndex);
      this._questMatterData[index].SetRecieve();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    private void AddOrderInformation(int dataIndex)
    {
      if (this._orderCount.Value >= (byte) 8)
        return;
      for (int index = 0; index < (int) this._orderCount.Value; ++index)
      {
        if ((int) (byte) ((uint) this._orderInfomation[index].Value & (uint) byte.MaxValue) == dataIndex)
          return;
      }
      this._orderInfomation[(int) this._orderCount.Value].Value = (ushort) (dataIndex | 3072);
      ++this._orderCount.Value;
    }

    private void RemoveOrderInfomation(int dataIndex)
    {
      for (int index1 = 0; index1 < (int) this._orderCount.Value; ++index1)
      {
        if ((int) (byte) ((uint) this._orderInfomation[index1].Value & (uint) byte.MaxValue) == dataIndex)
        {
          for (int index2 = index1; index2 < (int) this._orderCount.Value; ++index2)
            this._orderInfomation[index2].Value = index2 != (int) this._orderCount.Value - 1 ? this._orderInfomation[index2 + 1].Value : (ushort) 0;
          --this._orderCount.Value;
        }
      }
    }

    private class QuestMatterData
    {
      private int _index;
      private DataValue<byte> _state;
      private DataValue<byte> _clearFlag;
      private DataValue<uint> _dateTime;

      public QuestMatterData(SaveData owner, int index)
      {
        this._index = index;
        QuestElement questElement = QuestDataList.List[index];
        this._state = new DataValue<byte>(owner, (uint) (12300 + (int) questElement.DataIndex / 2), (Control) null, (byte) 0, byte.MaxValue);
        this._clearFlag = new DataValue<byte>(owner, (uint) (12536 + (int) questElement.DataIndex / 8), (Control) null, (byte) 0, byte.MaxValue);
        this._dateTime = new DataValue<uint>(owner, (uint) (12564 + (int) questElement.DataIndex * 4), (Control) null, 0U, uint.MaxValue);
      }

      public QuestState State
      {
        get
        {
          QuestElement questElement = QuestDataList.List[this._index];
          byte num = ((int) questElement.DataIndex & 1) != 0 ? (byte) ((uint) this._state.Value >> 4) : (byte) ((uint) this._state.Value & 15U);
          QuestDataManager.QuestMatterData.InnerQuestState innerQuestState = (QuestDataManager.QuestMatterData.InnerQuestState) ((int) num & 7);
          if (questElement.AdditionalQuest)
          {
            if (innerQuestState != QuestDataManager.QuestMatterData.InnerQuestState.None)
            {
              if (((int) num & 8) == 0)
                innerQuestState = QuestDataManager.QuestMatterData.InnerQuestState.None;
            }
            else if (((int) num & 8) != 0)
              innerQuestState = QuestDataManager.QuestMatterData.InnerQuestState.Recieved;
          }
          if (this.ClearFlag)
            innerQuestState = QuestDataManager.QuestMatterData.InnerQuestState.Clear;
          switch (innerQuestState)
          {
            case QuestDataManager.QuestMatterData.InnerQuestState.AllowOrder:
              return QuestState.AllowOrder;
            case QuestDataManager.QuestMatterData.InnerQuestState.Order:
              return QuestState.Order;
            case QuestDataManager.QuestMatterData.InnerQuestState.Clear:
              return QuestState.Clear;
            case QuestDataManager.QuestMatterData.InnerQuestState.Recieved:
              return QuestState.BeforeOrder;
            default:
              return questElement.AdditionalQuest ? QuestState.NotRecieved : QuestState.BeforeOrder;
          }
        }
      }

      internal void SetNone()
      {
        QuestElement questElement = QuestDataList.List[this._index];
        if (((int) questElement.DataIndex & 1) == 0)
          this._state.Value &= (byte) 240;
        else
          this._state.Value &= (byte) 15;
        this._clearFlag.Value &= (byte) ~(1 << (int) questElement.DataIndex % 8);
      }

      internal void SetAllowOrder()
      {
        QuestElement questElement = QuestDataList.List[this._index];
        if (((int) questElement.DataIndex & 1) == 0)
          this._state.Value = (byte) ((int) this._state.Value & 240 | 1 | (questElement.AdditionalQuest ? 8 : 0));
        else
          this._state.Value = (byte) ((int) this._state.Value & 15 | 16 | (questElement.AdditionalQuest ? 128 : 0));
      }

      internal void SetOrder()
      {
        QuestElement questElement = QuestDataList.List[this._index];
        this._state.Value = ((int) questElement.DataIndex & 1) != 0 ? (byte) ((int) this._state.Value & 15 | 32 | (questElement.AdditionalQuest ? 128 : 0)) : (byte) ((int) this._state.Value & 240 | 2 | (questElement.AdditionalQuest ? 8 : 0));
        this._clearFlag.Value &= (byte) ~(1 << (int) questElement.DataIndex % 8);
      }

      internal void SetClear()
      {
        QuestElement questElement = QuestDataList.List[this._index];
        this._state.Value = ((int) questElement.DataIndex & 1) != 0 ? (byte) ((int) this._state.Value & 15 | 48 | (questElement.AdditionalQuest ? 128 : 0)) : (byte) ((int) this._state.Value & 240 | 3 | (questElement.AdditionalQuest ? 8 : 0));
        this._clearFlag.Value = (byte) ((int) this._clearFlag.Value & ~(1 << (int) questElement.DataIndex % 8) | 1 << (int) questElement.DataIndex % 8);
      }

      internal void SetRecieve()
      {
        QuestElement questElement = QuestDataList.List[this._index];
        if (!questElement.AdditionalQuest)
          return;
        this._state.Value = ((int) questElement.DataIndex & 1) != 0 ? (byte) ((int) this._state.Value & 15 | 128) : (byte) ((int) this._state.Value & 240 | 8);
        this._clearFlag.Value &= (byte) ~(1 << (int) questElement.DataIndex % 8);
      }

      private bool ClearFlag
      {
        get
        {
          return ((int) this._clearFlag.Value & 1 << (int) QuestDataList.List[this._index].DataIndex % 8) != 0;
        }
      }

      public ushort Year
      {
        get => (ushort) (2000 + ((int) this._dateTime.Value & (int) sbyte.MaxValue));
        set
        {
          this._dateTime.Value = (uint) ((int) this._dateTime.Value & (int) sbyte.MinValue | (int) value - 2000 & (int) sbyte.MaxValue);
        }
      }

      public byte Month
      {
        get => (byte) ((this._dateTime.Value & 1920U) >> 7);
        set
        {
          this._dateTime.Value = (uint) ((int) this._dateTime.Value & -1921 | (int) value << 7 & 1920);
        }
      }

      public byte Day
      {
        get => (byte) ((this._dateTime.Value & 63488U) >> 11);
        set
        {
          this._dateTime.Value = (uint) ((int) this._dateTime.Value & -63489 | (int) value << 11 & 63488);
        }
      }

      public byte Hour
      {
        get => (byte) ((this._dateTime.Value & 2031616U) >> 16);
        set
        {
          this._dateTime.Value = (uint) ((int) this._dateTime.Value & -2031617 | (int) value << 16 & 2031616);
        }
      }

      public byte Minute
      {
        get => (byte) ((this._dateTime.Value & 132120576U) >> 21);
        set
        {
          this._dateTime.Value = (uint) ((int) this._dateTime.Value & -132120577 | (int) value << 21 & 132120576);
        }
      }

      private enum InnerQuestState
      {
        None = 0,
        AllowOrder = 1,
        Order = 2,
        Clear = 3,
        Recieved = 8,
      }
    }
  }
}
