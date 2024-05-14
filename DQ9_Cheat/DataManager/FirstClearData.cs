// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.FirstClearData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.DataManager;

internal class FirstClearData
{
    private readonly DataValue<ushort> _title;
    private readonly DataValue<ushort> _titleCount;
    private readonly DataValue<ushort> _treasureMap;
    private readonly DataValue<ushort> _visitorCount;

    public FirstClearData(SaveData owner)
    {
        var clearDataControl = MainWindow.Instance.FirstClearDataControl;
        clearDataControl.BeginUpdate();
        PlayTimeHour = new DataValue<ushort>(owner, 16168U, null, 0, ushort.MaxValue);
        clearDataControl.NumericUpDown_Hour.Maximum = PlayTimeHour.Max;
        clearDataControl.NumericUpDown_Hour.Minimum = PlayTimeHour.Min;
        PlayTimeMinute = new DataValue<byte>(owner, 16170U, null, 0, 59);
        clearDataControl.NumericUpDown_Minute.Maximum = PlayTimeMinute.Max;
        clearDataControl.NumericUpDown_Minute.Minimum = PlayTimeMinute.Min;
        PlayTimeSecond = new DataValue<byte>(owner, 16171U, null, 0, 59);
        clearDataControl.NumericUpDown_Second.Maximum = PlayTimeSecond.Max;
        clearDataControl.NumericUpDown_Second.Minimum = PlayTimeSecond.Min;
        MultiPlayTimeHour = new DataValue<ushort>(owner, 16172U, null, 0, ushort.MaxValue);
        clearDataControl.NumericUpDown_MultiPlayTimeHour.Maximum = MultiPlayTimeHour.Max;
        clearDataControl.NumericUpDown_MultiPlayTimeHour.Minimum = MultiPlayTimeHour.Min;
        MultiPlayTimeMinute = new DataValue<byte>(owner, 16174U, null, 0, 59);
        clearDataControl.NumericUpDown_MultiPlayTimeMinute.Maximum = MultiPlayTimeMinute.Max;
        clearDataControl.NumericUpDown_MultiPlayTimeMinute.Minimum = MultiPlayTimeMinute.Min;
        MultiPlayTimeSecond = new DataValue<byte>(owner, 16175U, null, 0, 59);
        clearDataControl.NumericUpDown_MultiPlayTimeSecond.Maximum = MultiPlayTimeSecond.Max;
        clearDataControl.NumericUpDown_MultiPlayTimeSecond.Minimum = MultiPlayTimeSecond.Min;
        VictoryCount = new DataValue<ushort>(owner, 16176U, null, 0, ushort.MaxValue);
        clearDataControl.NumericUpDown_VictoryCount.Minimum = VictoryCount.Min;
        clearDataControl.NumericUpDown_VictoryCount.Maximum = VictoryCount.Max;
        AlchemyCount = new DataValue<ushort>(owner, 16180U, null, 0, ushort.MaxValue);
        clearDataControl.NumericUpDown_AlchemyCount.Minimum = AlchemyCount.Min;
        clearDataControl.NumericUpDown_AlchemyCount.Maximum = AlchemyCount.Max;
        _titleCount = new DataValue<ushort>(owner, 16184U, null, 0, ushort.MaxValue);
        clearDataControl.NumericUpDown_TitleCount.Minimum = _titleCount.Min;
        clearDataControl.NumericUpDown_TitleCount.Maximum = 511M;
        QuestCount = new DataValue<byte>(owner, 16188U, null, 0, byte.MaxValue);
        clearDataControl.NumericUpDown_QuestCount.Minimum = QuestCount.Min;
        clearDataControl.NumericUpDown_QuestCount.Maximum = QuestCount.Max;
        _visitorCount = new DataValue<ushort>(owner, 16189U, null, 0, ushort.MaxValue);
        clearDataControl.NumericUpDown_VisitorCount.Minimum = 0M;
        clearDataControl.NumericUpDown_VisitorCount.Maximum = 16383M;
        _treasureMap = new DataValue<ushort>(owner, 16185U, null, 0, ushort.MaxValue);
        clearDataControl.NumericUpDown_TreasureMap.Minimum = _treasureMap.Min;
        clearDataControl.NumericUpDown_TreasureMap.Maximum = 16383M;
        _title = new DataValue<ushort>(owner, 16186U, null, 0, ushort.MaxValue);
        clearDataControl.EndUpdate();
    }

    public DataValue<ushort> PlayTimeHour { get; }

    public DataValue<byte> PlayTimeMinute { get; }

    public DataValue<byte> PlayTimeSecond { get; }

    public DataValue<ushort> MultiPlayTimeHour { get; }

    public DataValue<byte> MultiPlayTimeMinute { get; }

    public DataValue<byte> MultiPlayTimeSecond { get; }

    public DataValue<ushort> VictoryCount { get; }

    public DataValue<ushort> AlchemyCount { get; }

    public ushort TitleCount
    {
        get => (ushort)(_titleCount.Value & 511U);
        set => _titleCount.Value = (ushort)((_titleCount.Value & 65024) | (value & 511));
    }

    public DataValue<byte> QuestCount { get; }

    public ushort VisitorCount
    {
        get => (ushort)(_visitorCount.Value & 16383U);
        set => _visitorCount.Value = (ushort)((_visitorCount.Value & 49152) | (value & 16383));
    }

    public ushort TreasureMap
    {
        get => (ushort)((_treasureMap.Value & 32766) >> 1);
        set => _treasureMap.Value = (ushort)((_treasureMap.Value & 32769) | (value << 1));
    }

    public TitleElement Title
    {
        get => TitleDataList.GetTitleElement((_title.Value & 65408) >> 7);
        set => _title.Value = (ushort)((_title.Value & sbyte.MaxValue) | ((value.DataIndex << 7) & 65408));
    }
}