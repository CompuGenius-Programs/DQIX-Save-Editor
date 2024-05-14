// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.SmartItemData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class SmartItemData
  {
    private DataValue<ushort> _compCount;
    private DataValue<byte>[] _smartFlag = new DataValue<byte>[ItemDataList.MaxSmartndex / 8 + 1];

    public SmartItemData(SaveData owner)
    {
      this._compCount = new DataValue<ushort>(owner, 16046U, (Control) null, (ushort) 0, ushort.MaxValue);
      for (uint index = 0; (long) index < (long) this._smartFlag.Length; ++index)
        this._smartFlag[(int) index] = new DataValue<byte>(owner, 12122U + index, (Control) null, (byte) 0, byte.MaxValue);
    }

    public ushort CompCount => (ushort) (((int) this._compCount.Value & 8188) >> 2);

    public void ReviseCompCount()
    {
      ushort num = 0;
      for (int dataIndex = 7; dataIndex <= ItemDataList.MaxSmartndex; ++dataIndex)
      {
        if (this.IsSmartItemHold(dataIndex))
          ++num;
      }
      this._compCount.Value = (ushort) ((int) this._compCount.Value & 57347 | (int) num << 2 & 8188);
    }

    public bool IsSmartItemHold(int dataIndex)
    {
      switch (dataIndex)
      {
        case 68:
          dataIndex = 72;
          break;
        case 69:
        case 70:
        case 71:
        case 72:
          --dataIndex;
          break;
      }
      return ((int) this._smartFlag[dataIndex >> 3].Value & 1 << dataIndex % 8) != 0;
    }

    public void SetSmartItemHold(int dataIndex, bool value)
    {
      switch (dataIndex)
      {
        case 68:
          dataIndex = 72;
          break;
        case 69:
        case 70:
        case 71:
        case 72:
          --dataIndex;
          break;
      }
      int index = dataIndex >> 3;
      int num = dataIndex % 8;
      DataValue<byte> dataValue = this._smartFlag[index];
      dataValue.Value = (byte) ((int) dataValue.Value & ~(1 << num) | (value ? 1 << num : 0));
    }
  }
}
