// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.TitleData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class TitleData
  {
    private DataValue<byte>[] _titleFlag = new DataValue<byte>[TitleDataList.MaxDataIndex / 8 + 1];
    private DataValue<ushort> _titleCount;

    public TitleData(SaveData owner)
    {
      for (int index = 0; index < this._titleFlag.Length; ++index)
        this._titleFlag[index] = new DataValue<byte>(owner, (uint) (15964 + index), (Control) null, (byte) 0, byte.MaxValue);
      this._titleCount = new DataValue<ushort>(owner, 16040U, (Control) null, (ushort) 0, ushort.MaxValue);
    }

    public bool IsTitleHold(int index)
    {
      int dataIndex = TitleDataList.List[index].DataIndex;
      return ((int) this._titleFlag[dataIndex >> 3].Value & 1 << dataIndex % 8) != 0;
    }

    public void SetTitleHold(int index, bool value)
    {
      int dataIndex = TitleDataList.List[index].DataIndex;
      int index1 = dataIndex >> 3;
      int num = dataIndex % 8;
      DataValue<byte> dataValue = this._titleFlag[index1];
      dataValue.Value = (byte) ((int) dataValue.Value & ~(1 << num) | (value ? 1 << num : 0));
    }

    public ushort TitleCount
    {
      get => (ushort) ((uint) this._titleCount.Value & 511U);
      set
      {
        this._titleCount.Value = (ushort) ((int) this._titleCount.Value & 65024 | (int) value & 511);
      }
    }

    public void ReviseTitleCount()
    {
      ushort num = 0;
      for (int index = 0; index < TitleDataList.List.Count; ++index)
      {
        if (this.IsTitleHold(index))
          ++num;
      }
      this.TitleCount = num;
    }
  }
}
