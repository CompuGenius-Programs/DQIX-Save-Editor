// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.FirstClearData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls;
using DQ9_Cheat.GameData;
using System;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class FirstClearData
  {
    private DataValue<ushort> _playTimeHour;
    private DataValue<byte> _playTimeMinute;
    private DataValue<byte> _playTimeSecond;
    private DataValue<ushort> _multiPlayTimeHour;
    private DataValue<byte> _multiPlayTimeMinute;
    private DataValue<byte> _multiPlayTimeSecond;
    private DataValue<ushort> _victoryCount;
    private DataValue<ushort> _alchemyCount;
    private DataValue<ushort> _titleCount;
    private DataValue<byte> _questCount;
    private DataValue<ushort> _visitorCount;
    private DataValue<ushort> _treasureMap;
    private DataValue<ushort> _title;

    public FirstClearData(SaveData owner)
    {
      FirstClearDataControl clearDataControl = MainWindow.Instance.FirstClearDataControl;
      clearDataControl.BeginUpdate();
      this._playTimeHour = new DataValue<ushort>(owner, 16168U, (Control) null, (ushort) 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_Hour.Maximum = (Decimal) this._playTimeHour.Max;
      clearDataControl.NumericUpDown_Hour.Minimum = (Decimal) this._playTimeHour.Min;
      this._playTimeMinute = new DataValue<byte>(owner, 16170U, (Control) null, (byte) 0, (byte) 59);
      clearDataControl.NumericUpDown_Minute.Maximum = (Decimal) this._playTimeMinute.Max;
      clearDataControl.NumericUpDown_Minute.Minimum = (Decimal) this._playTimeMinute.Min;
      this._playTimeSecond = new DataValue<byte>(owner, 16171U, (Control) null, (byte) 0, (byte) 59);
      clearDataControl.NumericUpDown_Second.Maximum = (Decimal) this._playTimeSecond.Max;
      clearDataControl.NumericUpDown_Second.Minimum = (Decimal) this._playTimeSecond.Min;
      this._multiPlayTimeHour = new DataValue<ushort>(owner, 16172U, (Control) null, (ushort) 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_MultiPlayTimeHour.Maximum = (Decimal) this._multiPlayTimeHour.Max;
      clearDataControl.NumericUpDown_MultiPlayTimeHour.Minimum = (Decimal) this._multiPlayTimeHour.Min;
      this._multiPlayTimeMinute = new DataValue<byte>(owner, 16174U, (Control) null, (byte) 0, (byte) 59);
      clearDataControl.NumericUpDown_MultiPlayTimeMinute.Maximum = (Decimal) this._multiPlayTimeMinute.Max;
      clearDataControl.NumericUpDown_MultiPlayTimeMinute.Minimum = (Decimal) this._multiPlayTimeMinute.Min;
      this._multiPlayTimeSecond = new DataValue<byte>(owner, 16175U, (Control) null, (byte) 0, (byte) 59);
      clearDataControl.NumericUpDown_MultiPlayTimeSecond.Maximum = (Decimal) this._multiPlayTimeSecond.Max;
      clearDataControl.NumericUpDown_MultiPlayTimeSecond.Minimum = (Decimal) this._multiPlayTimeSecond.Min;
      this._victoryCount = new DataValue<ushort>(owner, 16176U, (Control) null, (ushort) 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_VictoryCount.Minimum = (Decimal) this._victoryCount.Min;
      clearDataControl.NumericUpDown_VictoryCount.Maximum = (Decimal) this._victoryCount.Max;
      this._alchemyCount = new DataValue<ushort>(owner, 16180U, (Control) null, (ushort) 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_AlchemyCount.Minimum = (Decimal) this._alchemyCount.Min;
      clearDataControl.NumericUpDown_AlchemyCount.Maximum = (Decimal) this._alchemyCount.Max;
      this._titleCount = new DataValue<ushort>(owner, 16184U, (Control) null, (ushort) 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_TitleCount.Minimum = (Decimal) this._titleCount.Min;
      clearDataControl.NumericUpDown_TitleCount.Maximum = 511M;
      this._questCount = new DataValue<byte>(owner, 16188U, (Control) null, (byte) 0, byte.MaxValue);
      clearDataControl.NumericUpDown_QuestCount.Minimum = (Decimal) this._questCount.Min;
      clearDataControl.NumericUpDown_QuestCount.Maximum = (Decimal) this._questCount.Max;
      this._visitorCount = new DataValue<ushort>(owner, 16189U, (Control) null, (ushort) 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_VisitorCount.Minimum = 0M;
      clearDataControl.NumericUpDown_VisitorCount.Maximum = 16383M;
      this._treasureMap = new DataValue<ushort>(owner, 16185U, (Control) null, (ushort) 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_TreasureMap.Minimum = (Decimal) this._treasureMap.Min;
      clearDataControl.NumericUpDown_TreasureMap.Maximum = 16383M;
      this._title = new DataValue<ushort>(owner, 16186U, (Control) null, (ushort) 0, ushort.MaxValue);
      clearDataControl.EndUpdate();
    }

    public DataValue<ushort> PlayTimeHour => this._playTimeHour;

    public DataValue<byte> PlayTimeMinute => this._playTimeMinute;

    public DataValue<byte> PlayTimeSecond => this._playTimeSecond;

    public DataValue<ushort> MultiPlayTimeHour => this._multiPlayTimeHour;

    public DataValue<byte> MultiPlayTimeMinute => this._multiPlayTimeMinute;

    public DataValue<byte> MultiPlayTimeSecond => this._multiPlayTimeSecond;

    public DataValue<ushort> VictoryCount => this._victoryCount;

    public DataValue<ushort> AlchemyCount => this._alchemyCount;

    public ushort TitleCount
    {
      get => (ushort) ((uint) this._titleCount.Value & 511U);
      set
      {
        this._titleCount.Value = (ushort) ((int) this._titleCount.Value & 65024 | (int) value & 511);
      }
    }

    public DataValue<byte> QuestCount => this._questCount;

    public ushort VisitorCount
    {
      get => (ushort) ((uint) this._visitorCount.Value & 16383U);
      set
      {
        this._visitorCount.Value = (ushort) ((int) this._visitorCount.Value & 49152 | (int) value & 16383);
      }
    }

    public ushort TreasureMap
    {
      get => (ushort) (((int) this._treasureMap.Value & 32766) >> 1);
      set
      {
        this._treasureMap.Value = (ushort) ((int) this._treasureMap.Value & 32769 | (int) value << 1);
      }
    }

    public TitleElement Title
    {
      get => TitleDataList.GetTitleElement(((int) this._title.Value & 65408) >> 7);
      set
      {
        this._title.Value = (ushort) ((int) this._title.Value & (int) sbyte.MaxValue | value.DataIndex << 7 & 65408);
      }
    }
  }
}
