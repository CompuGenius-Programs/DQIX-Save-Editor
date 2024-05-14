// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.FirstClearDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;

namespace DQ9_Cheat.Controls;

public class FirstClearDataControl : DataControlBase
{
    private readonly VisionButton _button_SelectTitle;
    private readonly VisionTextBox _textBox_Title;
    private IContainer components;
    private Label label_Hour;
    private Label label_Minute;
    private Label label_PlayTime;
    private Label label_Second;
    private Label label1;
    private Label label10;
    private Label label11;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;

    public FirstClearDataControl()
    {
        AutoScaleMode = AutoScaleMode.None;
        InitializeComponent();
        NumericUpDown_Hour = new VisionNumericUpDown(146, 12, 60, 20);
        NumericUpDown_Hour.ValueChanged += _numericUpDown_Hour_ValueChanged;
        AddVisionControl(NumericUpDown_Hour);
        NumericUpDown_Minute = new VisionNumericUpDown(253, 12, 41, 20);
        NumericUpDown_Minute.ValueChanged += _numericUpDown_Minute_ValueChanged;
        AddVisionControl(NumericUpDown_Minute);
        NumericUpDown_Second = new VisionNumericUpDown(335, 12, 41, 20);
        NumericUpDown_Second.ValueChanged += _numericUpDown_Second_ValueChanged;
        AddVisionControl(NumericUpDown_Second);
        NumericUpDown_MultiPlayTimeHour = new VisionNumericUpDown(146, 40, 60, 20);
        NumericUpDown_MultiPlayTimeHour.ValueChanged += _numericUpDown_MultiPlayTimeHour_ValueChanged;
        AddVisionControl(NumericUpDown_MultiPlayTimeHour);
        NumericUpDown_MultiPlayTimeMinute = new VisionNumericUpDown(253, 40, 41, 20);
        NumericUpDown_MultiPlayTimeMinute.ValueChanged += _numericUpDown_MultiPlayTimeMinute_ValueChanged;
        AddVisionControl(NumericUpDown_MultiPlayTimeMinute);
        NumericUpDown_MultiPlayTimeSecond = new VisionNumericUpDown(335, 41, 41, 20);
        NumericUpDown_MultiPlayTimeSecond.ValueChanged += _numericUpDown_MultiPlayTimeSecond_ValueChanged;
        AddVisionControl(NumericUpDown_MultiPlayTimeSecond);
        NumericUpDown_VictoryCount = new VisionNumericUpDown(146, 80, 60, 20);
        NumericUpDown_VictoryCount.ValueChanged += _numericUpDown_VictoryCount_ValueChanged;
        AddVisionControl(NumericUpDown_VictoryCount);
        NumericUpDown_AlchemyCount = new VisionNumericUpDown(146, 103, 60, 20);
        NumericUpDown_AlchemyCount.ValueChanged += _numericUpDown_AlchemyCount_ValueChanged;
        AddVisionControl(NumericUpDown_AlchemyCount);
        NumericUpDown_TitleCount = new VisionNumericUpDown(146, 128, 60, 20);
        NumericUpDown_TitleCount.ValueChanged += _numericUpDown_TitleCount_ValueChanged;
        AddVisionControl(NumericUpDown_TitleCount);
        NumericUpDown_QuestCount = new VisionNumericUpDown(321, 80, 60, 20);
        NumericUpDown_QuestCount.ValueChanged += _numericUpDown_QuestCount_ValueChanged;
        AddVisionControl(NumericUpDown_QuestCount);
        NumericUpDown_TreasureMap = new VisionNumericUpDown(321, 103, 60, 20);
        NumericUpDown_TreasureMap.ValueChanged += _numericUpDown_TreasureMap_ValueChanged;
        AddVisionControl(NumericUpDown_TreasureMap);
        NumericUpDown_VisitorCount = new VisionNumericUpDown(321, 128, 60, 20);
        NumericUpDown_VisitorCount.ValueChanged += _numericUpDown_VisitorCount_ValueChanged;
        AddVisionControl(NumericUpDown_VisitorCount);
        _textBox_Title = new VisionTextBox(198, 164, 114, 20);
        _textBox_Title.ReadOnly = true;
        AddVisionControl(_textBox_Title);
        _button_SelectTitle = new VisionButton(321, 165, 39, 19);
        _button_SelectTitle.Text = "Set";
        _button_SelectTitle.Click += _button_SelectTitle_Click;
        AddVisionControl(_button_SelectTitle);
    }

    public VisionNumericUpDown NumericUpDown_Hour { get; }

    public VisionNumericUpDown NumericUpDown_Minute { get; }

    public VisionNumericUpDown NumericUpDown_Second { get; }

    public VisionNumericUpDown NumericUpDown_MultiPlayTimeHour { get; }

    public VisionNumericUpDown NumericUpDown_MultiPlayTimeMinute { get; }

    public VisionNumericUpDown NumericUpDown_MultiPlayTimeSecond { get; }

    public VisionNumericUpDown NumericUpDown_VictoryCount { get; }

    public VisionNumericUpDown NumericUpDown_AlchemyCount { get; }

    public VisionNumericUpDown NumericUpDown_TitleCount { get; }

    public VisionNumericUpDown NumericUpDown_QuestCount { get; }

    public VisionNumericUpDown NumericUpDown_TreasureMap { get; }

    public VisionNumericUpDown NumericUpDown_VisitorCount { get; }

    private void _button_SelectTitle_Click(object sender, EventArgs e)
    {
        var title = SaveDataManager.Instance.SaveData.FirstClearData.Title;
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        int sex = characterManager.CharacterData[characterManager.CharacterStandbyCount].Sex;
        var titleSelectWindow = new TitleSelectWindow(sex, true);
        titleSelectWindow.Location = PointToScreen(new Point(_button_SelectTitle.Right, _button_SelectTitle.Bottom));
        if (titleSelectWindow.ShowDialog() != DialogResult.OK)
            return;
        var selectedTitle = titleSelectWindow.SelectedTitle;
        SaveDataManager.Instance.SaveData.FirstClearData.Title = selectedTitle;
        if (selectedTitle != null)
            _textBox_Title.Text = sex == 0 ? selectedTitle.MaleTitleName : selectedTitle.LadyTitleName;
        else
            _textBox_Title.Text = string.Empty;
    }

    protected override void OnValueUpdate()
    {
        NumericUpDown_Hour.Value = SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeHour.Value;
        NumericUpDown_Minute.Value = SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeMinute.Value;
        NumericUpDown_Second.Value = SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeSecond.Value;
        NumericUpDown_MultiPlayTimeHour.Value =
            SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeHour.Value;
        NumericUpDown_MultiPlayTimeMinute.Value =
            SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeMinute.Value;
        NumericUpDown_MultiPlayTimeSecond.Value =
            SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeSecond.Value;
        NumericUpDown_VictoryCount.Value = SaveDataManager.Instance.SaveData.FirstClearData.VictoryCount.Value;
        NumericUpDown_AlchemyCount.Value = SaveDataManager.Instance.SaveData.FirstClearData.AlchemyCount.Value;
        NumericUpDown_TitleCount.Value = SaveDataManager.Instance.SaveData.FirstClearData.TitleCount;
        NumericUpDown_QuestCount.Value = SaveDataManager.Instance.SaveData.FirstClearData.QuestCount.Value;
        NumericUpDown_TreasureMap.Value = SaveDataManager.Instance.SaveData.FirstClearData.TreasureMap;
        NumericUpDown_VisitorCount.Value = SaveDataManager.Instance.SaveData.FirstClearData.VisitorCount;
        var title = SaveDataManager.Instance.SaveData.FirstClearData.Title;
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (title != null)
            _textBox_Title.Text = characterManager.CharacterData[characterManager.CharacterStandbyCount].Sex == 0
                ? title.MaleTitleName
                : title.LadyTitleName;
        else
            _textBox_Title.Text = string.Empty;
    }

    protected override void OnActivate()
    {
        var title = SaveDataManager.Instance.SaveData.FirstClearData.Title;
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (title != null)
            _textBox_Title.Text = characterManager.CharacterData[characterManager.CharacterStandbyCount].Sex == 0
                ? title.MaleTitleName
                : title.LadyTitleName;
        else
            _textBox_Title.Text = string.Empty;
    }

    private void _numericUpDown_Hour_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeHour.Value = (ushort)NumericUpDown_Hour.Value;
    }

    private void _numericUpDown_Minute_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeMinute.Value = (byte)NumericUpDown_Minute.Value;
    }

    private void _numericUpDown_Second_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeSecond.Value = (byte)NumericUpDown_Second.Value;
    }

    private void _numericUpDown_MultiPlayTimeHour_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeHour.Value =
            (ushort)NumericUpDown_MultiPlayTimeHour.Value;
    }

    private void _numericUpDown_MultiPlayTimeMinute_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeMinute.Value =
            (byte)NumericUpDown_MultiPlayTimeMinute.Value;
    }

    private void _numericUpDown_MultiPlayTimeSecond_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeSecond.Value =
            (byte)NumericUpDown_MultiPlayTimeSecond.Value;
    }

    private void _numericUpDown_VictoryCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.VictoryCount.Value = (ushort)NumericUpDown_VictoryCount.Value;
    }

    private void _numericUpDown_AlchemyCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.AlchemyCount.Value = (ushort)NumericUpDown_AlchemyCount.Value;
    }

    private void _numericUpDown_TitleCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.TitleCount = (ushort)NumericUpDown_TitleCount.Value;
    }

    private void _numericUpDown_QuestCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.QuestCount.Value = (byte)NumericUpDown_QuestCount.Value;
    }

    private void _numericUpDown_TreasureMap_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.TreasureMap = (ushort)NumericUpDown_TreasureMap.Value;
    }

    private void _numericUpDown_VisitorCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.FirstClearData.VisitorCount = (ushort)NumericUpDown_VisitorCount.Value;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        label_Second = new Label();
        label_Minute = new Label();
        label_Hour = new Label();
        label_PlayTime = new Label();
        label5 = new Label();
        label6 = new Label();
        label7 = new Label();
        label8 = new Label();
        label9 = new Label();
        label10 = new Label();
        label11 = new Label();
        SuspendLayout();
        label1.AutoSize = true;
        label1.Location = new Point(382, 43);
        label1.Name = "label1";
        label1.Size = new Size(31, 13);
        label1.TabIndex = 41;
        label1.Text = "Secs";
        label2.AutoSize = true;
        label2.Location = new Point(300, 42);
        label2.Name = "label2";
        label2.Size = new Size(29, 13);
        label2.TabIndex = 39;
        label2.Text = "Mins";
        label3.AutoSize = true;
        label3.Location = new Point(212, 43);
        label3.Name = "label3";
        label3.Size = new Size(35, 13);
        label3.TabIndex = 37;
        label3.Text = "Hours";
        label4.AutoSize = true;
        label4.Location = new Point(57, 43);
        label4.Name = "label4";
        label4.Size = new Size(83, 13);
        label4.TabIndex = 35;
        label4.Text = "Multiplayer Time";
        label_Second.AutoSize = true;
        label_Second.Location = new Point(382, 15);
        label_Second.Name = "label_Second";
        label_Second.Size = new Size(31, 13);
        label_Second.TabIndex = 34;
        label_Second.Text = "Secs";
        label_Minute.AutoSize = true;
        label_Minute.Location = new Point(300, 15);
        label_Minute.Name = "label_Minute";
        label_Minute.Size = new Size(29, 13);
        label_Minute.TabIndex = 32;
        label_Minute.Text = "Mins";
        label_Hour.AutoSize = true;
        label_Hour.Location = new Point(212, 15);
        label_Hour.Name = "label_Hour";
        label_Hour.Size = new Size(35, 13);
        label_Hour.TabIndex = 30;
        label_Hour.Text = "Hours";
        label_PlayTime.AutoSize = true;
        label_PlayTime.Location = new Point(87, 15);
        label_PlayTime.Name = "label_PlayTime";
        label_PlayTime.Size = new Size(53, 13);
        label_PlayTime.TabIndex = 28;
        label_PlayTime.Text = "Play Time";
        label5.AutoSize = true;
        label5.Location = new Point(63, 82);
        label5.Name = "label5";
        label5.Size = new Size(77, 13);
        label5.TabIndex = 42;
        label5.Text = "Battle Victories";
        label6.AutoSize = true;
        label6.Location = new Point(11, 105);
        label6.Name = "label6";
        label6.Size = new Size(129, 13);
        label6.TabIndex = 44;
        label6.Text = "Times Alchemy Performed";
        label7.AutoSize = true;
        label7.Location = new Point(55, 130);
        label7.Name = "label7";
        label7.Size = new Size(85, 13);
        label7.TabIndex = 46;
        label7.Text = "Accolades Earnt";
        label8.AutoSize = true;
        label8.Location = new Point(222, 82);
        label8.Name = "label8";
        label8.Size = new Size(93, 13);
        label8.TabIndex = 48;
        label8.Text = "Quests Completed";
        label9.AutoSize = true;
        label9.Location = new Point(215, 105);
        label9.Name = "label9";
        label9.Size = new Size(100, 13);
        label9.TabIndex = 50;
        label9.Text = "Grottoes Completed";
        label10.AutoSize = true;
        label10.Location = new Point(219, 130);
        label10.Name = "label10";
        label10.Size = new Size(96, 13);
        label10.TabIndex = 52;
        label10.Text = "Guests Canvassed";
        label11.AutoSize = true;
        label11.Location = new Point(140, 167);
        label11.Name = "label11";
        label11.Size = new Size(52, 13);
        label11.TabIndex = 53;
        label11.Text = "Accolade";
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(label11);
        Controls.Add(label10);
        Controls.Add(label9);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label1);
        Controls.Add(label2);
        Controls.Add(label3);
        Controls.Add(label4);
        Controls.Add(label_Second);
        Controls.Add(label_Minute);
        Controls.Add(label_Hour);
        Controls.Add(label_PlayTime);
        Name = nameof(FirstClearDataControl);
        Size = new Size(431, 208);
        ResumeLayout(false);
        PerformLayout();
    }
}