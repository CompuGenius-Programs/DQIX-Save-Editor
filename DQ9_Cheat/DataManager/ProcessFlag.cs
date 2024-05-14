// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.ProcessFlag
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class ProcessFlag
  {
    private DataValue<ushort> _allowChangeJob;
    private DataValue<byte> _disableRuler;
    private DataValue<uint> _destinationFlag;

    public ProcessFlag(SaveData owner)
    {
      this._allowChangeJob = new DataValue<ushort>(owner, 12276U, (Control) null, (ushort) 0, ushort.MaxValue);
      this._destinationFlag = new DataValue<uint>(owner, 11788U, (Control) null, 0U, uint.MaxValue);
      this._disableRuler = new DataValue<byte>(owner, 12275U, (Control) null, (byte) 0, byte.MaxValue);
    }

    public bool IsAllowChangeJob(int index)
    {
      return index >= 0 && index < 6 && ((int) this._allowChangeJob.Value & 1 << JobDataList.List[index + 7].DataIndex - 1) != 0;
    }

    public void SetAllowChangeJob(int index, bool value)
    {
      if (index < 0 || index >= 6)
        return;
      int num = JobDataList.List[index + 7].DataIndex - 1;
      this._allowChangeJob.Value = (ushort) ((int) this._allowChangeJob.Value & ~(1 << num) | (value ? 1 << num : 0));
    }

    public bool DisableRuler
    {
      get => ((int) this._disableRuler.Value & 4) != 0;
      set
      {
        this._disableRuler.Value = (byte) ((int) this._disableRuler.Value & 251 | (value ? 4 : 0));
      }
    }

    public bool IsAllowDestination(int index)
    {
      return index >= 0 && index < DestinationList.List.Count && ((long) this._destinationFlag.Value & (long) (1 << index)) != 0L;
    }

    public void SetAllowDestination(int index, bool value)
    {
      if (index < 0 || index >= DestinationList.List.Count)
        return;
      this._destinationFlag.Value = (uint) ((int) this._destinationFlag.Value & ~(1 << index) | (value ? 1 << index : 0));
    }
  }
}
