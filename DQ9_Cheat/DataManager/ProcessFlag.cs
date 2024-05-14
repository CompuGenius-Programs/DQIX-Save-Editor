// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.ProcessFlag
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.DataManager
{
  internal class ProcessFlag
  {
    private DataValue<ushort> _allowChangeJob;
    private DataValue<byte> _disableRuler;
    private DataValue<uint> _destinationFlag;

    public ProcessFlag(SaveData owner)
    {
      _allowChangeJob = new DataValue<ushort>(owner, 12276U, null, 0, ushort.MaxValue);
      _destinationFlag = new DataValue<uint>(owner, 11788U, null, 0U, uint.MaxValue);
      _disableRuler = new DataValue<byte>(owner, 12275U, null, 0, byte.MaxValue);
    }

    public bool IsAllowChangeJob(int index)
    {
      return index >= 0 && index < 6 && (_allowChangeJob.Value & 1 << JobDataList.List[index + 7].DataIndex - 1) != 0;
    }

    public void SetAllowChangeJob(int index, bool value)
    {
      if (index < 0 || index >= 6)
        return;
      int num = JobDataList.List[index + 7].DataIndex - 1;
      _allowChangeJob.Value = (ushort) (_allowChangeJob.Value & ~(1 << num) | (value ? 1 << num : 0));
    }

    public bool DisableRuler
    {
      get => (_disableRuler.Value & 4) != 0;
      set
      {
        _disableRuler.Value = (byte) (_disableRuler.Value & 251 | (value ? 4 : 0));
      }
    }

    public bool IsAllowDestination(int index)
    {
      return index >= 0 && index < DestinationList.List.Count && (_destinationFlag.Value & 1 << index) != 0L;
    }

    public void SetAllowDestination(int index, bool value)
    {
      if (index < 0 || index >= DestinationList.List.Count)
        return;
      _destinationFlag.Value = (uint) ((int) _destinationFlag.Value & ~(1 << index) | (value ? 1 << index : 0));
    }
  }
}
