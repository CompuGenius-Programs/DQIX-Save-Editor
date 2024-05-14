// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.RikkaData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls;
using DQ9_Cheat.GameData;
using System.Windows.Forms;

#nullable disable
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
      this._visitorManager = new VisitorManager(owner);
      this._uid = new DataValue<ulong>(owner, 11520U, (Control) null, 0UL, ulong.MaxValue);
      this._grade = new DataValue<byte>(owner, 23172U, (Control) null, (byte) 0, byte.MaxValue);
      rikkaInnDataControl.NumericUpDownGrade.Maximum = 6M;
      rikkaInnDataControl.NumericUpDownGrade.Minimum = 1M;
      this._visitorRealCount = new DataValue<uint>(owner, 23164U, (Control) null, 0U, uint.MaxValue);
      this._visitorCount = new DataValue<ushort>(owner, 16041U, (Control) null, (ushort) 0, ushort.MaxValue);
      rikkaInnDataControl.NumericUpDownVisitorCount.Maximum = 2147483647M;
      rikkaInnDataControl.NumericUpDownVisitorCount.Minimum = 0M;
      this._historyCharacter = new DataValue<uint>(owner, 11528U, (Control) null, 0U, uint.MaxValue);
      rikkaInnDataControl.EndUpdate();
    }

    public ulong UID
    {
      get => this._uid.Value & 281474976710655UL;
      set
      {
        this._uid.Value = (ulong) ((long) this._uid.Value & -281474976710656L | (long) value & 281474976710655L);
      }
    }

    public byte Grade
    {
      get => ((int) this._grade.Value & 7) > 6 ? (byte) 6 : (byte) ((int) this._grade.Value & 7);
      set
      {
        if (value > (byte) 6)
          value = (byte) 6;
        if (value < (byte) 1)
          value = (byte) 1;
        this._grade.Value = (byte) ((uint) this._grade.Value & 248U | (uint) value);
      }
    }

    public uint VisitorCount
    {
      get => this._visitorRealCount.Value & (uint) int.MaxValue;
      set
      {
        this._visitorRealCount.Value = value & (uint) int.MaxValue;
        this._visitorCount.Value = (ushort) ((int) this._visitorCount.Value & 32769 | (int) (ushort) value << 1);
      }
    }

    public bool IsHistoryCharacter(int index)
    {
      return index >= 0 && index < HistoryCharacterList.List.Count && ((long) this._historyCharacter.Value & (long) (1 << HistoryCharacterList.List[index].Index)) != 0L;
    }

    public void SetHistoryCharacter(int index, bool value)
    {
      if (index < 0 || index >= HistoryCharacterList.List.Count)
        return;
      int index1 = HistoryCharacterList.List[index].Index;
      this._historyCharacter.Value = (uint) ((int) this._historyCharacter.Value & ~(1 << index1) | (value ? 1 << index1 : 0));
    }

    public VisitorManager VisitorManager => this._visitorManager;
  }
}
