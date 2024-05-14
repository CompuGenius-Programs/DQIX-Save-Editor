// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.AlchemyData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class AlchemyData
  {
    private bool _onSaveArrangement;
    private DataValue<ushort> _compCount;
    private DataValue<ushort>[] _alchemyFlag = new DataValue<ushort>[471];

    public AlchemyData(SaveData owner)
    {
      this._compCount = new DataValue<ushort>(owner, 16042U, (Control) null, (ushort) 0, ushort.MaxValue);
      for (uint index = 0; (long) index < (long) this._alchemyFlag.Length; ++index)
        this._alchemyFlag[(int) index] = new DataValue<ushort>(owner, (uint) (15020 + (int) index * 2), (Control) null, (ushort) 0, ushort.MaxValue);
    }

    public ushort CompCount
    {
      get => (ushort) (((int) this._compCount.Value & 65408) >> 7);
      private set
      {
        this._compCount.Value = (ushort) ((int) this._compCount.Value & (int) sbyte.MaxValue | (int) value << 7 & 65408);
      }
    }

    public void OnLoaded() => this._onSaveArrangement = false;

    public void OnSaving()
    {
      if (!this._onSaveArrangement)
        return;
      this.Arrangement();
    }

    public AlchemyState GetAlchemyState(int alchemyIndex)
    {
      ushort num1 = (ushort) (alchemyIndex * 4 + 7);
      ushort num2 = (ushort) (alchemyIndex * 4 + 5);
      for (int index = 0; index < 471; ++index)
      {
        if ((int) this._alchemyFlag[index].Value == (int) num1)
          return AlchemyState.Created;
        if ((int) this._alchemyFlag[index].Value == (int) num2)
          return AlchemyState.Appear;
      }
      return AlchemyState.NotAppear;
    }

    public bool IsAlchemyCreated(int alchemyIndex)
    {
      return this.GetAlchemyState(alchemyIndex) == AlchemyState.Created;
    }

    public void SetAlchemyState(int alchemyIndex, AlchemyState value)
    {
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      ItemDataBase[] allAlchemyList = ItemDataList.GetAllAlchemyList();
      ushort num1 = (ushort) (alchemyIndex * 4 + 7);
      ushort num2 = (ushort) (alchemyIndex * 4 + 5);
      bool flag = false;
      foreach (ItemDataBase itemDataBase in allAlchemyList)
      {
        if (itemDataBase.AlchemyIndex == alchemyIndex)
        {
          flag = itemDataBase.AlchemyRate;
          break;
        }
      }
      if (value != AlchemyState.Created)
      {
        for (int index = 0; index < 471; ++index)
        {
          if ((int) this._alchemyFlag[index].Value == (int) num1)
          {
            this._alchemyFlag[index].Value = (ushort) 0;
            this._onSaveArrangement = true;
            if (flag)
            {
              --this.CompCount;
              flag = false;
            }
          }
        }
      }
      else
      {
        int index1 = -1;
        for (int index2 = 0; index2 < 471; ++index2)
        {
          if (index1 == -1 && this._alchemyFlag[index2].Value == (ushort) 0)
          {
            index1 = index2;
          }
          else
          {
            if ((int) this._alchemyFlag[index2].Value == (int) num1)
            {
              SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
              return;
            }
            if ((int) this._alchemyFlag[index2].Value == (int) num2)
            {
              this._alchemyFlag[index2].Value = num1;
              if (flag)
                ++this.CompCount;
              SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
              return;
            }
          }
        }
        if (index1 != -1)
        {
          this._alchemyFlag[index1].Value = num1;
          if (flag)
            ++this.CompCount;
        }
      }
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void Arrangement()
    {
      List<int> intList = new List<int>();
      ItemDataBase[] allAlchemyList = ItemDataList.GetAllAlchemyList();
      int index1 = -1;
      ushort num1 = 0;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      for (int index2 = 0; index2 < 471; ++index2)
      {
        if (this._alchemyFlag[index2].Value != (ushort) 0)
        {
          int num2 = 0;
          AlchemyState alchemyState;
          switch ((int) this._alchemyFlag[index2].Value % 4)
          {
            case 1:
              alchemyState = AlchemyState.Appear;
              num2 = ((int) this._alchemyFlag[index2].Value - 5) / 4;
              break;
            case 3:
              alchemyState = AlchemyState.Created;
              num2 = ((int) this._alchemyFlag[index2].Value - 7) / 4;
              break;
            default:
              alchemyState = AlchemyState.NotAppear;
              this._alchemyFlag[index2].Value = (ushort) 0;
              break;
          }
          if (alchemyState != AlchemyState.NotAppear)
          {
            if (intList.Contains(num2))
            {
              this._alchemyFlag[index2].Value = (ushort) 0;
            }
            else
            {
              foreach (ItemDataBase itemDataBase in allAlchemyList)
              {
                if (itemDataBase.AlchemyIndex == num2)
                {
                  if (itemDataBase.AlchemyRate && alchemyState == AlchemyState.Created)
                  {
                    ++num1;
                    break;
                  }
                  break;
                }
              }
              intList.Add(num2);
              if (index1 != -1)
              {
                this._alchemyFlag[index1].Value = this._alchemyFlag[index2].Value;
                this._alchemyFlag[index2].Value = (ushort) 0;
                ++index1;
              }
            }
          }
        }
        if (index1 == -1 && this._alchemyFlag[index2].Value == (ushort) 0)
          index1 = index2;
      }
      this.CompCount = num1;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      intList.Clear();
    }
  }
}
