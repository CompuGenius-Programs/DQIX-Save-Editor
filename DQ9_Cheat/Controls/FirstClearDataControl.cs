// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.FirstClearDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class FirstClearDataControl : DataControlBase
  {
    private VisionNumericUpDown _numericUpDown_Hour;
    private VisionNumericUpDown _numericUpDown_Minute;
    private VisionNumericUpDown _numericUpDown_Second;
    private VisionNumericUpDown _numericUpDown_MultiPlayTimeHour;
    private VisionNumericUpDown _numericUpDown_MultiPlayTimeMinute;
    private VisionNumericUpDown _numericUpDown_MultiPlayTimeSecond;
    private VisionNumericUpDown _numericUpDown_VictoryCount;
    private VisionNumericUpDown _numericUpDown_AlchemyCount;
    private VisionNumericUpDown _numericUpDown_TitleCount;
    private VisionNumericUpDown _numericUpDown_QuestCount;
    private VisionNumericUpDown _numericUpDown_TreasureMap;
    private VisionNumericUpDown _numericUpDown_VisitorCount;
    private VisionTextBox _textBox_Title;
    private VisionButton _button_SelectTitle;
    private IContainer components;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label_Second;
    private Label label_Minute;
    private Label label_Hour;
    private Label label_PlayTime;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;

    public FirstClearDataControl()
    {
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      this._numericUpDown_Hour = new VisionNumericUpDown(146, 12, 60, 20);
      this._numericUpDown_Hour.ValueChanged += new EventHandler(this._numericUpDown_Hour_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_Hour);
      this._numericUpDown_Minute = new VisionNumericUpDown(253, 12, 41, 20);
      this._numericUpDown_Minute.ValueChanged += new EventHandler(this._numericUpDown_Minute_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_Minute);
      this._numericUpDown_Second = new VisionNumericUpDown(335, 12, 41, 20);
      this._numericUpDown_Second.ValueChanged += new EventHandler(this._numericUpDown_Second_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_Second);
      this._numericUpDown_MultiPlayTimeHour = new VisionNumericUpDown(146, 40, 60, 20);
      this._numericUpDown_MultiPlayTimeHour.ValueChanged += new EventHandler(this._numericUpDown_MultiPlayTimeHour_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_MultiPlayTimeHour);
      this._numericUpDown_MultiPlayTimeMinute = new VisionNumericUpDown(253, 40, 41, 20);
      this._numericUpDown_MultiPlayTimeMinute.ValueChanged += new EventHandler(this._numericUpDown_MultiPlayTimeMinute_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_MultiPlayTimeMinute);
      this._numericUpDown_MultiPlayTimeSecond = new VisionNumericUpDown(335, 41, 41, 20);
      this._numericUpDown_MultiPlayTimeSecond.ValueChanged += new EventHandler(this._numericUpDown_MultiPlayTimeSecond_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_MultiPlayTimeSecond);
      this._numericUpDown_VictoryCount = new VisionNumericUpDown(146, 80, 60, 20);
      this._numericUpDown_VictoryCount.ValueChanged += new EventHandler(this._numericUpDown_VictoryCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_VictoryCount);
      this._numericUpDown_AlchemyCount = new VisionNumericUpDown(146, 103, 60, 20);
      this._numericUpDown_AlchemyCount.ValueChanged += new EventHandler(this._numericUpDown_AlchemyCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_AlchemyCount);
      this._numericUpDown_TitleCount = new VisionNumericUpDown(146, 128, 60, 20);
      this._numericUpDown_TitleCount.ValueChanged += new EventHandler(this._numericUpDown_TitleCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_TitleCount);
      this._numericUpDown_QuestCount = new VisionNumericUpDown(321, 80, 60, 20);
      this._numericUpDown_QuestCount.ValueChanged += new EventHandler(this._numericUpDown_QuestCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_QuestCount);
      this._numericUpDown_TreasureMap = new VisionNumericUpDown(321, 103, 60, 20);
      this._numericUpDown_TreasureMap.ValueChanged += new EventHandler(this._numericUpDown_TreasureMap_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_TreasureMap);
      this._numericUpDown_VisitorCount = new VisionNumericUpDown(321, 128, 60, 20);
      this._numericUpDown_VisitorCount.ValueChanged += new EventHandler(this._numericUpDown_VisitorCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_VisitorCount);
      this._textBox_Title = new VisionTextBox(198, 164, 114, 20);
      this._textBox_Title.ReadOnly = true;
      this.AddVisionControl((VisionControlBase) this._textBox_Title);
      this._button_SelectTitle = new VisionButton(321, 165, 39, 19);
      this._button_SelectTitle.Text = "Set";
      this._button_SelectTitle.Click += new EventHandler(this._button_SelectTitle_Click);
      this.AddVisionControl((VisionControlBase) this._button_SelectTitle);
    }

    private void _button_SelectTitle_Click(object sender, EventArgs e)
    {
      TitleElement title = SaveDataManager.Instance.SaveData.FirstClearData.Title;
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      int sex = (int) characterManager.CharacterData[(int) characterManager.CharacterStandbyCount].Sex;
      TitleSelectWindow titleSelectWindow = new TitleSelectWindow(sex, true);
      titleSelectWindow.Location = this.PointToScreen(new Point(this._button_SelectTitle.Right, this._button_SelectTitle.Bottom));
      if (titleSelectWindow.ShowDialog() != DialogResult.OK)
        return;
      TitleElement selectedTitle = titleSelectWindow.SelectedTitle;
      SaveDataManager.Instance.SaveData.FirstClearData.Title = selectedTitle;
      if (selectedTitle != null)
        this._textBox_Title.Text = sex == 0 ? selectedTitle.MaleTitleName : selectedTitle.LadyTitleName;
      else
        this._textBox_Title.Text = string.Empty;
    }

    protected override void OnValueUpdate()
    {
      this._numericUpDown_Hour.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeHour.Value;
      this._numericUpDown_Minute.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeMinute.Value;
      this._numericUpDown_Second.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeSecond.Value;
      this._numericUpDown_MultiPlayTimeHour.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeHour.Value;
      this._numericUpDown_MultiPlayTimeMinute.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeMinute.Value;
      this._numericUpDown_MultiPlayTimeSecond.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeSecond.Value;
      this._numericUpDown_VictoryCount.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.VictoryCount.Value;
      this._numericUpDown_AlchemyCount.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.AlchemyCount.Value;
      this._numericUpDown_TitleCount.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.TitleCount;
      this._numericUpDown_QuestCount.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.QuestCount.Value;
      this._numericUpDown_TreasureMap.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.TreasureMap;
      this._numericUpDown_VisitorCount.Value = (Decimal) SaveDataManager.Instance.SaveData.FirstClearData.VisitorCount;
      TitleElement title = SaveDataManager.Instance.SaveData.FirstClearData.Title;
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (title != null)
        this._textBox_Title.Text = characterManager.CharacterData[(int) characterManager.CharacterStandbyCount].Sex == (byte) 0 ? title.MaleTitleName : title.LadyTitleName;
      else
        this._textBox_Title.Text = string.Empty;
    }

    protected override void OnActivate()
    {
      TitleElement title = SaveDataManager.Instance.SaveData.FirstClearData.Title;
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (title != null)
        this._textBox_Title.Text = characterManager.CharacterData[(int) characterManager.CharacterStandbyCount].Sex == (byte) 0 ? title.MaleTitleName : title.LadyTitleName;
      else
        this._textBox_Title.Text = string.Empty;
    }

    private void _numericUpDown_Hour_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeHour.Value = (ushort) this._numericUpDown_Hour.Value;
    }

    private void _numericUpDown_Minute_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeMinute.Value = (byte) this._numericUpDown_Minute.Value;
    }

    private void _numericUpDown_Second_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.PlayTimeSecond.Value = (byte) this._numericUpDown_Second.Value;
    }

    private void _numericUpDown_MultiPlayTimeHour_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeHour.Value = (ushort) this._numericUpDown_MultiPlayTimeHour.Value;
    }

    private void _numericUpDown_MultiPlayTimeMinute_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeMinute.Value = (byte) this._numericUpDown_MultiPlayTimeMinute.Value;
    }

    private void _numericUpDown_MultiPlayTimeSecond_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.MultiPlayTimeSecond.Value = (byte) this._numericUpDown_MultiPlayTimeSecond.Value;
    }

    private void _numericUpDown_VictoryCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.VictoryCount.Value = (ushort) this._numericUpDown_VictoryCount.Value;
    }

    private void _numericUpDown_AlchemyCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.AlchemyCount.Value = (ushort) this._numericUpDown_AlchemyCount.Value;
    }

    private void _numericUpDown_TitleCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.TitleCount = (ushort) this._numericUpDown_TitleCount.Value;
    }

    private void _numericUpDown_QuestCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.QuestCount.Value = (byte) this._numericUpDown_QuestCount.Value;
    }

    private void _numericUpDown_TreasureMap_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.TreasureMap = (ushort) this._numericUpDown_TreasureMap.Value;
    }

    private void _numericUpDown_VisitorCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.FirstClearData.VisitorCount = (ushort) this._numericUpDown_VisitorCount.Value;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label_Second = new Label();
      this.label_Minute = new Label();
      this.label_Hour = new Label();
      this.label_PlayTime = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(382, 43);
      this.label1.Name = "label1";
      this.label1.Size = new Size(31, 13);
      this.label1.TabIndex = 41;
      this.label1.Text = "Secs";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(300, 42);
      this.label2.Name = "label2";
      this.label2.Size = new Size(29, 13);
      this.label2.TabIndex = 39;
      this.label2.Text = "Mins";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(212, 43);
      this.label3.Name = "label3";
      this.label3.Size = new Size(35, 13);
      this.label3.TabIndex = 37;
      this.label3.Text = "Hours";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(57, 43);
      this.label4.Name = "label4";
      this.label4.Size = new Size(83, 13);
      this.label4.TabIndex = 35;
      this.label4.Text = "Multiplayer Time";
      this.label_Second.AutoSize = true;
      this.label_Second.Location = new Point(382, 15);
      this.label_Second.Name = "label_Second";
      this.label_Second.Size = new Size(31, 13);
      this.label_Second.TabIndex = 34;
      this.label_Second.Text = "Secs";
      this.label_Minute.AutoSize = true;
      this.label_Minute.Location = new Point(300, 15);
      this.label_Minute.Name = "label_Minute";
      this.label_Minute.Size = new Size(29, 13);
      this.label_Minute.TabIndex = 32;
      this.label_Minute.Text = "Mins";
      this.label_Hour.AutoSize = true;
      this.label_Hour.Location = new Point(212, 15);
      this.label_Hour.Name = "label_Hour";
      this.label_Hour.Size = new Size(35, 13);
      this.label_Hour.TabIndex = 30;
      this.label_Hour.Text = "Hours";
      this.label_PlayTime.AutoSize = true;
      this.label_PlayTime.Location = new Point(87, 15);
      this.label_PlayTime.Name = "label_PlayTime";
      this.label_PlayTime.Size = new Size(53, 13);
      this.label_PlayTime.TabIndex = 28;
      this.label_PlayTime.Text = "Play Time";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(63, 82);
      this.label5.Name = "label5";
      this.label5.Size = new Size(77, 13);
      this.label5.TabIndex = 42;
      this.label5.Text = "Battle Victories";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(11, 105);
      this.label6.Name = "label6";
      this.label6.Size = new Size(129, 13);
      this.label6.TabIndex = 44;
      this.label6.Text = "Times Alchemy Performed";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(55, 130);
      this.label7.Name = "label7";
      this.label7.Size = new Size(85, 13);
      this.label7.TabIndex = 46;
      this.label7.Text = "Accolades Earnt";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(222, 82);
      this.label8.Name = "label8";
      this.label8.Size = new Size(93, 13);
      this.label8.TabIndex = 48;
      this.label8.Text = "Quests Completed";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(215, 105);
      this.label9.Name = "label9";
      this.label9.Size = new Size(100, 13);
      this.label9.TabIndex = 50;
      this.label9.Text = "Grottoes Completed";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(219, 130);
      this.label10.Name = "label10";
      this.label10.Size = new Size(96, 13);
      this.label10.TabIndex = 52;
      this.label10.Text = "Guests Canvassed";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(140, 167);
      this.label11.Name = "label11";
      this.label11.Size = new Size(52, 13);
      this.label11.TabIndex = 53;
      this.label11.Text = "Accolade";
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label_Second);
      this.Controls.Add((Control) this.label_Minute);
      this.Controls.Add((Control) this.label_Hour);
      this.Controls.Add((Control) this.label_PlayTime);
      this.Name = nameof (FirstClearDataControl);
      this.Size = new Size(431, 208);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public VisionNumericUpDown NumericUpDown_Hour => this._numericUpDown_Hour;

    public VisionNumericUpDown NumericUpDown_Minute => this._numericUpDown_Minute;

    public VisionNumericUpDown NumericUpDown_Second => this._numericUpDown_Second;

    public VisionNumericUpDown NumericUpDown_MultiPlayTimeHour
    {
      get => this._numericUpDown_MultiPlayTimeHour;
    }

    public VisionNumericUpDown NumericUpDown_MultiPlayTimeMinute
    {
      get => this._numericUpDown_MultiPlayTimeMinute;
    }

    public VisionNumericUpDown NumericUpDown_MultiPlayTimeSecond
    {
      get => this._numericUpDown_MultiPlayTimeSecond;
    }

    public VisionNumericUpDown NumericUpDown_VictoryCount => this._numericUpDown_VictoryCount;

    public VisionNumericUpDown NumericUpDown_AlchemyCount => this._numericUpDown_AlchemyCount;

    public VisionNumericUpDown NumericUpDown_TitleCount => this._numericUpDown_TitleCount;

    public VisionNumericUpDown NumericUpDown_QuestCount => this._numericUpDown_QuestCount;

    public VisionNumericUpDown NumericUpDown_TreasureMap => this._numericUpDown_TreasureMap;

    public VisionNumericUpDown NumericUpDown_VisitorCount => this._numericUpDown_VisitorCount;
  }
}
