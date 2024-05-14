// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.FirstClearData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls;
using DQ9_Cheat.GameData;

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
      _playTimeHour = new DataValue<ushort>(owner, 16168U, null, 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_Hour.Maximum = _playTimeHour.Max;
      clearDataControl.NumericUpDown_Hour.Minimum = _playTimeHour.Min;
      _playTimeMinute = new DataValue<byte>(owner, 16170U, null, 0, 59);
      clearDataControl.NumericUpDown_Minute.Maximum = _playTimeMinute.Max;
      clearDataControl.NumericUpDown_Minute.Minimum = _playTimeMinute.Min;
      _playTimeSecond = new DataValue<byte>(owner, 16171U, null, 0, 59);
      clearDataControl.NumericUpDown_Second.Maximum = _playTimeSecond.Max;
      clearDataControl.NumericUpDown_Second.Minimum = _playTimeSecond.Min;
      _multiPlayTimeHour = new DataValue<ushort>(owner, 16172U, null, 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_MultiPlayTimeHour.Maximum = _multiPlayTimeHour.Max;
      clearDataControl.NumericUpDown_MultiPlayTimeHour.Minimum = _multiPlayTimeHour.Min;
      _multiPlayTimeMinute = new DataValue<byte>(owner, 16174U, null, 0, 59);
      clearDataControl.NumericUpDown_MultiPlayTimeMinute.Maximum = _multiPlayTimeMinute.Max;
      clearDataControl.NumericUpDown_MultiPlayTimeMinute.Minimum = _multiPlayTimeMinute.Min;
      _multiPlayTimeSecond = new DataValue<byte>(owner, 16175U, null, 0, 59);
      clearDataControl.NumericUpDown_MultiPlayTimeSecond.Maximum = _multiPlayTimeSecond.Max;
      clearDataControl.NumericUpDown_MultiPlayTimeSecond.Minimum = _multiPlayTimeSecond.Min;
      _victoryCount = new DataValue<ushort>(owner, 16176U, null, 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_VictoryCount.Minimum = _victoryCount.Min;
      clearDataControl.NumericUpDown_VictoryCount.Maximum = _victoryCount.Max;
      _alchemyCount = new DataValue<ushort>(owner, 16180U, null, 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_AlchemyCount.Minimum = _alchemyCount.Min;
      clearDataControl.NumericUpDown_AlchemyCount.Maximum = _alchemyCount.Max;
      _titleCount = new DataValue<ushort>(owner, 16184U, null, 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_TitleCount.Minimum = _titleCount.Min;
      clearDataControl.NumericUpDown_TitleCount.Maximum = 511M;
      _questCount = new DataValue<byte>(owner, 16188U, null, 0, byte.MaxValue);
      clearDataControl.NumericUpDown_QuestCount.Minimum = _questCount.Min;
      clearDataControl.NumericUpDown_QuestCount.Maximum = _questCount.Max;
      _visitorCount = new DataValue<ushort>(owner, 16189U, null, 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_VisitorCount.Minimum = 0M;
      clearDataControl.NumericUpDown_VisitorCount.Maximum = 16383M;
      _treasureMap = new DataValue<ushort>(owner, 16185U, null, 0, ushort.MaxValue);
      clearDataControl.NumericUpDown_TreasureMap.Minimum = _treasureMap.Min;
      clearDataControl.NumericUpDown_TreasureMap.Maximum = 16383M;
      _title = new DataValue<ushort>(owner, 16186U, null, 0, ushort.MaxValue);
      clearDataControl.EndUpdate();
    }

    public DataValue<ushort> PlayTimeHour => _playTimeHour;

    public DataValue<byte> PlayTimeMinute => _playTimeMinute;

    public DataValue<byte> PlayTimeSecond => _playTimeSecond;

    public DataValue<ushort> MultiPlayTimeHour => _multiPlayTimeHour;

    public DataValue<byte> MultiPlayTimeMinute => _multiPlayTimeMinute;

    public DataValue<byte> MultiPlayTimeSecond => _multiPlayTimeSecond;

    public DataValue<ushort> VictoryCount => _victoryCount;

    public DataValue<ushort> AlchemyCount => _alchemyCount;

    public ushort TitleCount
    {
      get => (ushort) (_titleCount.Value & 511U);
      set
      {
        _titleCount.Value = (ushort) (_titleCount.Value & 65024 | value & 511);
      }
    }

    public DataValue<byte> QuestCount => _questCount;

    public ushort VisitorCount
    {
      get => (ushort) (_visitorCount.Value & 16383U);
      set
      {
        _visitorCount.Value = (ushort) (_visitorCount.Value & 49152 | value & 16383);
      }
    }

    public ushort TreasureMap
    {
      get => (ushort) ((_treasureMap.Value & 32766) >> 1);
      set
      {
        _treasureMap.Value = (ushort) (_treasureMap.Value & 32769 | value << 1);
      }
    }

    public TitleElement Title
    {
      get => TitleDataList.GetTitleElement((_title.Value & 65408) >> 7);
      set
      {
        _title.Value = (ushort) (_title.Value & sbyte.MaxValue | value.DataIndex << 7 & 65408);
      }
    }
  }
}
