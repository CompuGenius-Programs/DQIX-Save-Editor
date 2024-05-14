// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.ItemCollectionData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class ItemCollectionData
  {
    private DataValue<ushort> _compCount;
    private DataValue<byte>[] _itemCollectionFlag = new DataValue<byte>[ItemDataList.MaxItemCollectionIndex / 8 + 1];

    public ItemCollectionData(SaveData owner)
    {
      this._compCount = new DataValue<ushort>(owner, 16045U, (Control) null, (ushort) 0, ushort.MaxValue);
      for (uint index = 0; (long) index < (long) this._itemCollectionFlag.Length; ++index)
        this._itemCollectionFlag[(int) index] = new DataValue<byte>(owner, 12240U + index, (Control) null, (byte) 0, byte.MaxValue);
    }

    public ushort CompCount => (ushort) (((int) this._compCount.Value & 1022) >> 1);

    public void ReviseCompCount()
    {
      ushort num = 0;
      for (int dataIndex = 7; dataIndex <= ItemDataList.MaxItemCollectionIndex; ++dataIndex)
      {
        if (this.IsItemCollectionHold(dataIndex))
          ++num;
      }
      this._compCount.Value = (ushort) ((int) this._compCount.Value & 64513 | (int) num << 1 & 1022);
    }

    public bool IsItemCollectionHold(int dataIndex)
    {
      return ((int) this._itemCollectionFlag[dataIndex >> 3].Value & 1 << dataIndex % 8) != 0;
    }

    public void SetItemCollectionHold(int dataIndex, bool value)
    {
      int index = dataIndex >> 3;
      int num = dataIndex % 8;
      DataValue<byte> dataValue = this._itemCollectionFlag[index];
      dataValue.Value = (byte) ((int) dataValue.Value & ~(1 << num) | (value ? 1 << num : 0));
    }
  }
}
