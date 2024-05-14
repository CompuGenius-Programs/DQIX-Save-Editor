// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.RikkaData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.DataManager
{
  internal class RikkaData
  {
    private DataValue<ulong> _uid;
    private DataValue<byte> _grade;
    private DataValue<uint> _visitorRealCount;
    private DataValue<ushort> _visitorCount;
    private DataValue<uint> _historyCharacter;
    private VisitorManager _visitorManager;

    public RikkaData(SaveData owner)
    {
      RikkaInnDataControl rikkaInnDataControl = MainWindow.Instance.RikkaInnDataControl;
      rikkaInnDataControl.BeginUpdate();
      _visitorManager = new VisitorManager(owner);
      _uid = new DataValue<ulong>(owner, 11520U, null, 0UL, ulong.MaxValue);
      _grade = new DataValue<byte>(owner, 23172U, null, 0, byte.MaxValue);
      rikkaInnDataControl.NumericUpDownGrade.Maximum = 6M;
      rikkaInnDataControl.NumericUpDownGrade.Minimum = 1M;
      _visitorRealCount = new DataValue<uint>(owner, 23164U, null, 0U, uint.MaxValue);
      _visitorCount = new DataValue<ushort>(owner, 16041U, null, 0, ushort.MaxValue);
      rikkaInnDataControl.NumericUpDownVisitorCount.Maximum = 2147483647M;
      rikkaInnDataControl.NumericUpDownVisitorCount.Minimum = 0M;
      _historyCharacter = new DataValue<uint>(owner, 11528U, null, 0U, uint.MaxValue);
      rikkaInnDataControl.EndUpdate();
    }

    public ulong UID
    {
      get => _uid.Value & 281474976710655UL;
      set
      {
        _uid.Value = (ulong) ((long) _uid.Value & -281474976710656L | (long) value & 281474976710655L);
      }
    }

    public byte Grade
    {
      get => (_grade.Value & 7) > 6 ? (byte) 6 : (byte) (_grade.Value & 7);
      set
      {
        if (value > 6)
          value = 6;
        if (value < 1)
          value = 1;
        _grade.Value = (byte) (_grade.Value & 248U | value);
      }
    }

    public uint VisitorCount
    {
      get => _visitorRealCount.Value & int.MaxValue;
      set
      {
        _visitorRealCount.Value = value & int.MaxValue;
        _visitorCount.Value = (ushort) (_visitorCount.Value & 32769 | (ushort) value << 1);
      }
    }

    public bool IsHistoryCharacter(int index)
    {
      return index >= 0 && index < HistoryCharacterList.List.Count && (_historyCharacter.Value & 1 << HistoryCharacterList.List[index].Index) != 0L;
    }

    public void SetHistoryCharacter(int index, bool value)
    {
      if (index < 0 || index >= HistoryCharacterList.List.Count)
        return;
      int index1 = HistoryCharacterList.List[index].Index;
      _historyCharacter.Value = (uint) ((int) _historyCharacter.Value & ~(1 << index1) | (value ? 1 << index1 : 0));
    }

    public VisitorManager VisitorManager => _visitorManager;
  }
}
