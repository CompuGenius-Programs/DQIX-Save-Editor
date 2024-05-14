// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.StayingListGroupBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using FriedGinger.DQCheat;
using JS_Framework.Controls;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class StayingListGroupBox : JS_GroupBox
  {
    private int _updateCount;
    private int _selectedIndex = -1;
    private JS_Panel _panelVisitorEditArea;
    private JS_GroupBox _groupBox_CompRate;
    private JS_GroupBox _groupBox_Figure;
    private JS_GroupBox _groupBox_Equipment;
    private JS_GroupBox _groupBox_Profile;
    private JS_GroupBox _groupBox_TreasureMap;
    private VisionTextBox _textBoxName;
    private VisionNumericUpDown _numericUpDownLodgingYear;
    private VisionNumericUpDown _numericUpDownLodgingMonth;
    private VisionNumericUpDown _numericUpDownLodgingDay;
    private VisionComboBox _comboBoxPlace;
    private VisionNumericUpDown _numericUpDownSEQ;
    private VisionNumericUpDown _numericUpDownUID;
    private VisionTextBox _textBoxHandle;
    private VisionButton _buttonSelectHandle;
    private VisionTextBox _textBoxAddress;
    private VisionButton _buttonSelectAddress;
    private VisionComboBox _comboBoxSex;
    private VisionNumericUpDown _numericUpDownLV;
    private VisionComboBox _comboBoxJob;
    private VisionNumericUpDown _numericUpDownTransmigration;
    private VisionComboBox _comboBoxColor;
    private VisionComboBox _profileTone;
    private VisionNumericUpDown _numericUpDownBirthDayYear;
    private VisionNumericUpDown _numericUpDownBirthDayMonth;
    private VisionNumericUpDown _numericUpDownBirthDayDay;
    private VisionNumericUpDown _numericUpDownVictoryCount;
    private VisionNumericUpDown _numericUpDownMonsterCompRate;
    private VisionNumericUpDown _numericUpDownItemCompRate;
    private VisionNumericUpDown _numericUpDownFashionCompRate;
    private VisionNumericUpDown _numericUpDownQuestClearCount;
    private VisionNumericUpDown _numericUpDownVisitorCount;
    private VisionNumericUpDown _numericUpDownAlchemyCompRate;
    private VisionNumericUpDown _numericUpDownTitleCount;
    private VisionNumericUpDown _numericUpDownTreasureMapCount;
    private VisionNumericUpDown _numericUpDownAlchemyCount;
    private VisionNumericUpDown _numericUpDownPlayTimeHour;
    private VisionNumericUpDown _numericUpDownPlayTimeMinute;
    private VisionNumericUpDown _numericUpDownMultiPlayTimeHour;
    private VisionNumericUpDown _numericUpDownMultiPlayTimeMinute;
    private VisionButton[] _buttonPreset = new VisionButton[4];
    private VisionNumericUpDown _numericUpDownFigureWidth;
    private VisionNumericUpDown _numericUpDownFigureHeight;
    private VisionNumericUpDown _numericUpDownHairType;
    private VisionNumericUpDown _numericUpDownHairColor;
    private VisionNumericUpDown _numericUpDownFaceType;
    private VisionNumericUpDown _numericUpDownSkinColor;
    private VisionNumericUpDown _numericUpDownEyeColor;
    private VisionButton[] _buttonSelect = new VisionButton[8];
    private VisionTextBox _textBoxEquipmentWeapon;
    private VisionTextBox _textBoxEquipmentShield;
    private VisionTextBox _textBoxEquipmentHead;
    private VisionTextBox _textBoxEquipmentUpperBody;
    private VisionTextBox _textBoxEquipmentArm;
    private VisionTextBox _textBoxEquipmentLowerBody;
    private VisionTextBox _textBoxEquipmentShoe;
    private VisionTextBox _textBoxEquipmentAccessory;
    private RadioButton _radioButton_DevilMap;
    private RadioButton _radioButton_NormalMap;
    private TextBox _textBox_Detector;
    private TextBox _textBox_Renewer;
    private SafeNumericUpDown _numericUpDown_Place;
    private ComboBox _comboBox_State;
    private JS_GroupBox _groupBox_Probability;
    private CheckBox _checkBox_OpenProbability1;
    private CheckBox _checkBox_OpenProbability2;
    private CheckBox _checkBox_OpenProbability3;
    private DoubleBufferedPanel _panel_NormalMap;
    private DoubleBufferedPanel _panel_DevilMap;
    private SafeNumericUpDown _numericUpDown_MapNo1;
    private SafeNumericUpDown _numericUpDown_MapNo2;
    private CheckBox _checkBox_Hex;
    private CheckBox _checkBox_PlaceHex;
    private ComboBox _comboBox_Devil;
    private SafeNumericUpDown _numericUpDown_DevilLevel;
    private SafeNumericUpDown _numericUpDown_DevilVictoryTurn;
    private Button _button_CreateMap;
    private Button _button_DeleteMap;
    private CheckBox _checkBoxSecretAge;
    private TextBox _textBox_ProfileMessage;

    public StayingListGroupBox()
    {
      this.SuspendLayout();
      this._panelVisitorEditArea = new JS_Panel();
      this._panelVisitorEditArea.Size = this.Size;
      this._panelVisitorEditArea.Location = new Point(105, 0);
      this._panelVisitorEditArea.Paint += new PaintEventHandler(this._panelVisitorEditArea_Paint);
      this._panelVisitorEditArea.BackColor = Color.Transparent;
      this.Controls.Add((Control) this._panelVisitorEditArea);
      this.Controls.SetChildIndex((Control) this._panelVisitorEditArea, 0);
      this._groupBox_CompRate = new JS_GroupBox();
      this._groupBox_CompRate.Location = new Point(5, 200);
      this._groupBox_CompRate.Name = nameof (_groupBox_CompRate);
      this._groupBox_CompRate.Size = new Size(310, 62);
      this._groupBox_CompRate.Text = "Completion Rate";
      this._groupBox_CompRate.Paint += new PaintEventHandler(this._groupBox_CompRate_Paint);
      this._groupBox_Equipment = new JS_GroupBox();
      this._groupBox_Equipment.Location = new Point(322, 305);
      this._groupBox_Equipment.Name = nameof (_groupBox_Equipment);
      this._groupBox_Equipment.Size = new Size(222, 182);
      this._groupBox_Equipment.Text = "Equipment";
      this._groupBox_Equipment.Paint += new PaintEventHandler(this._groupBox_Equipment_Paint);
      this._groupBox_Figure = new JS_GroupBox();
      this._groupBox_Figure.Location = new Point(550, 305);
      this._groupBox_Figure.Name = nameof (_groupBox_Figure);
      this._groupBox_Figure.Size = new Size(199, 166);
      this._groupBox_Figure.Text = "Appearance";
      this._groupBox_Figure.Paint += new PaintEventHandler(this._groupBox_Figure_Paint);
      this._groupBox_Profile = new JS_GroupBox();
      this._groupBox_Profile.Location = new Point(5, 275);
      this._groupBox_Profile.Name = nameof (_groupBox_Profile);
      this._groupBox_Profile.Size = new Size(310, 212);
      this._groupBox_Profile.Text = "Profile";
      this._groupBox_Profile.Paint += new PaintEventHandler(this._groupBox_Profile_Paint);
      this._panelVisitorEditArea.Controls.Add((Control) this._groupBox_Profile);
      this._panelVisitorEditArea.Controls.Add((Control) this._groupBox_Equipment);
      this._panelVisitorEditArea.Controls.Add((Control) this._groupBox_Figure);
      this._panelVisitorEditArea.Controls.Add((Control) this._groupBox_CompRate);
      this._numericUpDownLodgingYear = new VisionNumericUpDown(78, 14, 49, 20);
      this._numericUpDownLodgingYear.Minimum = 2000M;
      this._numericUpDownLodgingYear.Maximum = 2127M;
      this._numericUpDownLodgingYear.ValueChanged += new EventHandler(this._numericUpDownLodgingYear_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownLodgingYear);
      this._numericUpDownLodgingMonth = new VisionNumericUpDown(148, 14, 37, 20);
      this._numericUpDownLodgingMonth.Minimum = 0M;
      this._numericUpDownLodgingMonth.Maximum = 15M;
      this._numericUpDownLodgingMonth.ValueChanged += new EventHandler(this._numericUpDownLodgingMonth_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownLodgingMonth);
      this._numericUpDownLodgingDay = new VisionNumericUpDown(206, 14, 37, 20);
      this._numericUpDownLodgingDay.Minimum = 0M;
      this._numericUpDownLodgingDay.Maximum = 31M;
      this._numericUpDownLodgingDay.ValueChanged += new EventHandler(this._numericUpDownLodgingDay_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownLodgingDay);
      this._comboBoxPlace = new VisionComboBox(321, 13, 103, 20);
      this._comboBoxPlace.Items.AddRange((object[]) new string[8]
      {
        "Location",
        "1st Floor",
        "2nd Floor A",
        "2nd Floor B",
        "3rd Floor A",
        "3rd Floor B",
        "Royal Suite A",
        "Royal Suite B"
      });
      this._comboBoxPlace.SelectedIndexChanged += new EventHandler(this._comboBoxPlace_SelectedIndexChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._comboBoxPlace);
      this._numericUpDownSEQ = new VisionNumericUpDown(462, 13, 100, 20);
      this._numericUpDownSEQ.Minimum = 1M;
      this._numericUpDownSEQ.Maximum = 1073741823M;
      this._numericUpDownSEQ.ValueChanged += new EventHandler(this._numericUpDownSEQ_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownSEQ);
      this._numericUpDownUID = new VisionNumericUpDown(596, 13, 110, 20);
      this._numericUpDownUID.Minimum = 1M;
      this._numericUpDownUID.Maximum = 281474976710655M;
      this._numericUpDownUID.Hexadecimal = true;
      this._numericUpDownUID.ValueChanged += new EventHandler(this._numericUpDownUID_ValueChanged);
      this._numericUpDownUID.Leave += new EventHandler(this._numericUpDownUID_Leave);
      this._numericUpDownUID.Enter += new EventHandler(this._numericUpDownUID_Enter);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownUID);
      this._textBoxName = new VisionTextBox(78, 38, 67, 21);
      this._textBoxName.TextChanged += new EventHandler(this._textBoxName_TextChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._textBoxName);
      this._comboBoxColor = new VisionComboBox(183, 38, 77, 21);
      this._comboBoxColor.Items.AddRange((object[]) new string[16]
      {
        "Orange",
        "Yellow",
        "Light Green",
        "Dark Green",
        "Red",
        "Pink",
        "Green",
        "Blue",
        "Dark Purple",
        "Light Purple",
        "Purple",
        "Turquoise",
        "Black",
        "Brown",
        "Gray",
        "White"
      });
      this._comboBoxColor.SelectedIndexChanged += new EventHandler(this._comboBoxColor_SelectedIndexChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._comboBoxColor);
      this._comboBoxJob = new VisionComboBox(321, 38, 88, 20);
      foreach (JobData jobData in JobDataList.List)
      {
        if (jobData.DataIndex == 0)
          this._comboBoxJob.Items.Add((object) "None");
        else
          this._comboBoxJob.Items.Add((object) jobData.Name);
      }
      this._comboBoxJob.SelectedIndexChanged += new EventHandler(this._comboBoxJob_SelectedIndexChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._comboBoxJob);
      this._numericUpDownLV = new VisionNumericUpDown(454, 39, 43, 20);
      this._numericUpDownLV.ValueChanged += new EventHandler(this._numericUpDownLV_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownLV);
      this._numericUpDownTransmigration = new VisionNumericUpDown(575, 39, 43, 20);
      this._numericUpDownTransmigration.ValueChanged += new EventHandler(this._numericUpDownTransmigration_ValueChanged);
      this._numericUpDownTransmigration.Minimum = 0M;
      this._numericUpDownTransmigration.Maximum = 15M;
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownTransmigration);
      this._numericUpDownPlayTimeHour = new VisionNumericUpDown(112, 72, 49, 20);
      this._numericUpDownPlayTimeHour.Minimum = 0M;
      this._numericUpDownPlayTimeHour.Maximum = 16383M;
      this._numericUpDownPlayTimeHour.ValueChanged += new EventHandler(this._numericUpDownPlayTimeHour_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownPlayTimeHour);
      this._numericUpDownPlayTimeMinute = new VisionNumericUpDown(197, 72, 49, 20);
      this._numericUpDownPlayTimeMinute.Minimum = 0M;
      this._numericUpDownPlayTimeMinute.Maximum = 59M;
      this._numericUpDownPlayTimeMinute.ValueChanged += new EventHandler(this._numericUpDownPlayTimeMinute_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownPlayTimeMinute);
      this._numericUpDownMultiPlayTimeHour = new VisionNumericUpDown(112, 97, 49, 20);
      this._numericUpDownMultiPlayTimeHour.Minimum = 0M;
      this._numericUpDownMultiPlayTimeHour.Maximum = 16383M;
      this._numericUpDownMultiPlayTimeHour.ValueChanged += new EventHandler(this._numericUpDownMultiPlayTimeHour_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownMultiPlayTimeHour);
      this._numericUpDownMultiPlayTimeMinute = new VisionNumericUpDown(197, 97, 49, 20);
      this._numericUpDownMultiPlayTimeMinute.Minimum = 0M;
      this._numericUpDownMultiPlayTimeMinute.Maximum = 59M;
      this._numericUpDownMultiPlayTimeMinute.ValueChanged += new EventHandler(this._numericUpDownMultiPlayTimeMinute_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownMultiPlayTimeMinute);
      this._numericUpDownVictoryCount = new VisionNumericUpDown(112, 133, 49, 20);
      this._numericUpDownVictoryCount.Minimum = 0M;
      this._numericUpDownVictoryCount.Maximum = 65535M;
      this._numericUpDownVictoryCount.ValueChanged += new EventHandler(this._numericUpDownVictoryCount_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownVictoryCount);
      this._numericUpDownAlchemyCount = new VisionNumericUpDown(266, 133, 49, 20);
      this._numericUpDownAlchemyCount.Maximum = 65535M;
      this._numericUpDownAlchemyCount.Minimum = 0M;
      this._numericUpDownAlchemyCount.ValueChanged += new EventHandler(this._numericUpDownAlchemyCount_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownAlchemyCount);
      this._numericUpDownTitleCount = new VisionNumericUpDown(112, 154, 49, 20);
      this._numericUpDownTitleCount.Maximum = 1023M;
      this._numericUpDownTitleCount.Minimum = 0M;
      this._numericUpDownTitleCount.ValueChanged += new EventHandler(this._numericUpDownTitleCount_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownTitleCount);
      this._numericUpDownQuestClearCount = new VisionNumericUpDown(266, 154, 49, 20);
      this._numericUpDownQuestClearCount.Maximum = 511M;
      this._numericUpDownQuestClearCount.Minimum = 0M;
      this._numericUpDownQuestClearCount.ValueChanged += new EventHandler(this._numericUpDownQuestClearCount_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownQuestClearCount);
      this._numericUpDownTreasureMapCount = new VisionNumericUpDown(112, 175, 49, 20);
      this._numericUpDownTreasureMapCount.Maximum = 16383M;
      this._numericUpDownTreasureMapCount.Minimum = 0M;
      this._numericUpDownTreasureMapCount.ValueChanged += new EventHandler(this._numericUpDownTreasureMapCount_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownTreasureMapCount);
      this._numericUpDownVisitorCount = new VisionNumericUpDown(266, 175, 49, 20);
      this._numericUpDownVisitorCount.Maximum = 16383M;
      this._numericUpDownVisitorCount.Minimum = 0M;
      this._numericUpDownVisitorCount.ValueChanged += new EventHandler(this._numericUpDownVisitorCount_ValueChanged);
      this._panelVisitorEditArea.AddVisionControl((VisionControlBase) this._numericUpDownVisitorCount);
      this._numericUpDownMonsterCompRate = new VisionNumericUpDown(111, 16, 49, 19);
      this._numericUpDownMonsterCompRate.Maximum = 127M;
      this._numericUpDownMonsterCompRate.Minimum = 0M;
      this._numericUpDownMonsterCompRate.ValueChanged += new EventHandler(this._numericUpDownMonsterCompRate_ValueChanged);
      this._groupBox_CompRate.AddVisionControl((VisionControlBase) this._numericUpDownMonsterCompRate);
      this._numericUpDownFashionCompRate = new VisionNumericUpDown(251, 16, 49, 19);
      this._numericUpDownFashionCompRate.Maximum = 127M;
      this._numericUpDownFashionCompRate.Minimum = 0M;
      this._numericUpDownFashionCompRate.ValueChanged += new EventHandler(this._numericUpDownFashionCompRate_ValueChanged);
      this._groupBox_CompRate.AddVisionControl((VisionControlBase) this._numericUpDownFashionCompRate);
      this._numericUpDownItemCompRate = new VisionNumericUpDown(111, 37, 49, 19);
      this._numericUpDownItemCompRate.Maximum = 127M;
      this._numericUpDownItemCompRate.Minimum = 0M;
      this._numericUpDownItemCompRate.ValueChanged += new EventHandler(this._numericUpDownItemCompRate_ValueChanged);
      this._groupBox_CompRate.AddVisionControl((VisionControlBase) this._numericUpDownItemCompRate);
      this._numericUpDownAlchemyCompRate = new VisionNumericUpDown(251, 37, 49, 19);
      this._numericUpDownAlchemyCompRate.Maximum = 127M;
      this._numericUpDownAlchemyCompRate.Minimum = 0M;
      this._numericUpDownAlchemyCompRate.ValueChanged += new EventHandler(this._numericUpDownAlchemyCompRate_ValueChanged);
      this._groupBox_CompRate.AddVisionControl((VisionControlBase) this._numericUpDownAlchemyCompRate);
      int num1 = 15;
      for (int index = 0; index < 4; ++index)
      {
        this._buttonPreset[index] = new VisionButton(129, num1 += 21, 60, 19);
        this._buttonPreset[index].Text = "Preset";
        this._buttonPreset[index].Tag = (object) index;
        this._buttonPreset[index].Click += new EventHandler(this.ButtonPreset_Click);
        this._groupBox_Figure.AddVisionControl((VisionControlBase) this._buttonPreset[index]);
      }
      this._numericUpDownFigureWidth = new VisionNumericUpDown(73, 16, 49, 19);
      this._numericUpDownFigureWidth.Maximum = 65535M;
      this._numericUpDownFigureWidth.Minimum = 0M;
      this._numericUpDownFigureWidth.ValueChanged += new EventHandler(this._numericUpDownFigureWidth_ValueChanged);
      this._groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDownFigureWidth);
      this._numericUpDownFigureHeight = new VisionNumericUpDown(73, 37, 49, 19);
      this._numericUpDownFigureHeight.Maximum = 65535M;
      this._numericUpDownFigureHeight.Minimum = 0M;
      this._numericUpDownFigureHeight.ValueChanged += new EventHandler(this._numericUpDownFigureHeight_ValueChanged);
      this._groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDownFigureHeight);
      this._numericUpDownHairType = new VisionNumericUpDown(73, 58, 49, 19);
      this._numericUpDownHairType.Maximum = 255M;
      this._numericUpDownHairType.Minimum = 0M;
      this._numericUpDownHairType.ValueChanged += new EventHandler(this._numericUpDownHairType_ValueChanged);
      this._groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDownHairType);
      this._numericUpDownHairColor = new VisionNumericUpDown(73, 79, 49, 19);
      this._numericUpDownHairColor.Maximum = 255M;
      this._numericUpDownHairColor.Minimum = 0M;
      this._numericUpDownHairColor.ValueChanged += new EventHandler(this._numericUpDownHairColor_ValueChanged);
      this._groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDownHairColor);
      this._numericUpDownFaceType = new VisionNumericUpDown(73, 100, 49, 19);
      this._numericUpDownFaceType.Maximum = 255M;
      this._numericUpDownFaceType.Minimum = 0M;
      this._numericUpDownFaceType.ValueChanged += new EventHandler(this._numericUpDownFaceType_ValueChanged);
      this._groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDownFaceType);
      this._numericUpDownSkinColor = new VisionNumericUpDown(73, 121, 49, 19);
      this._numericUpDownSkinColor.Maximum = 7M;
      this._numericUpDownSkinColor.Minimum = 0M;
      this._numericUpDownSkinColor.ValueChanged += new EventHandler(this._numericUpDownSkinColor_ValueChanged);
      this._groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDownSkinColor);
      this._numericUpDownEyeColor = new VisionNumericUpDown(73, 142, 49, 19);
      this._numericUpDownEyeColor.Maximum = 15M;
      this._numericUpDownEyeColor.Minimum = 0M;
      this._numericUpDownEyeColor.ValueChanged += new EventHandler(this._numericUpDownEyeColor_ValueChanged);
      this._groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDownEyeColor);
      int num2 = -5;
      for (int index = 0; index < 8; ++index)
      {
        this._buttonSelect[index] = new VisionButton(177, num2 += 20, 39, 19);
        this._buttonSelect[index].Text = "Set";
        this._buttonSelect[index].Tag = (object) index;
        this._buttonSelect[index].Click += new EventHandler(this.ButtonSelect_Click);
        this._groupBox_Equipment.AddVisionControl((VisionControlBase) this._buttonSelect[index]);
      }
      this._textBoxEquipmentWeapon = new VisionTextBox(62, 15, 113, 19);
      this._textBoxEquipmentWeapon.ReadOnly = true;
      this._groupBox_Equipment.AddVisionControl((VisionControlBase) this._textBoxEquipmentWeapon);
      this._textBoxEquipmentShield = new VisionTextBox(62, 35, 113, 19);
      this._textBoxEquipmentShield.ReadOnly = true;
      this._groupBox_Equipment.AddVisionControl((VisionControlBase) this._textBoxEquipmentShield);
      this._textBoxEquipmentHead = new VisionTextBox(62, 55, 113, 19);
      this._textBoxEquipmentHead.ReadOnly = true;
      this._groupBox_Equipment.AddVisionControl((VisionControlBase) this._textBoxEquipmentHead);
      this._textBoxEquipmentUpperBody = new VisionTextBox(62, 75, 113, 19);
      this._textBoxEquipmentUpperBody.ReadOnly = true;
      this._groupBox_Equipment.AddVisionControl((VisionControlBase) this._textBoxEquipmentUpperBody);
      this._textBoxEquipmentArm = new VisionTextBox(62, 95, 113, 19);
      this._textBoxEquipmentArm.ReadOnly = true;
      this._groupBox_Equipment.AddVisionControl((VisionControlBase) this._textBoxEquipmentArm);
      this._textBoxEquipmentLowerBody = new VisionTextBox(62, 115, 113, 19);
      this._textBoxEquipmentLowerBody.ReadOnly = true;
      this._groupBox_Equipment.AddVisionControl((VisionControlBase) this._textBoxEquipmentLowerBody);
      this._textBoxEquipmentShoe = new VisionTextBox(62, 135, 113, 19);
      this._textBoxEquipmentShoe.ReadOnly = true;
      this._groupBox_Equipment.AddVisionControl((VisionControlBase) this._textBoxEquipmentShoe);
      this._textBoxEquipmentAccessory = new VisionTextBox(62, 155, 113, 19);
      this._textBoxEquipmentAccessory.ReadOnly = true;
      this._groupBox_Equipment.AddVisionControl((VisionControlBase) this._textBoxEquipmentAccessory);
      this._numericUpDownBirthDayYear = new VisionNumericUpDown(68, 15, 56, 19);
      this._numericUpDownBirthDayYear.Maximum = 4096M;
      this._numericUpDownBirthDayYear.Minimum = 0M;
      this._numericUpDownBirthDayYear.ValueChanged += new EventHandler(this._numericUpDownBirthDayYear_ValueChanged);
      this._groupBox_Profile.AddVisionControl((VisionControlBase) this._numericUpDownBirthDayYear);
      this._numericUpDownBirthDayMonth = new VisionNumericUpDown(148, 15, 47, 19);
      this._numericUpDownBirthDayMonth.Maximum = 12M;
      this._numericUpDownBirthDayMonth.Minimum = 1M;
      this._numericUpDownBirthDayMonth.ValueChanged += new EventHandler(this._numericUpDownBirthDayMonth_ValueChanged);
      this._groupBox_Profile.AddVisionControl((VisionControlBase) this._numericUpDownBirthDayMonth);
      this._numericUpDownBirthDayDay = new VisionNumericUpDown(220, 15, 47, 19);
      this._numericUpDownBirthDayDay.Maximum = 31M;
      this._numericUpDownBirthDayDay.Minimum = 1M;
      this._numericUpDownBirthDayDay.ValueChanged += new EventHandler(this._numericUpDownBirthDayDay_ValueChanged);
      this._groupBox_Profile.AddVisionControl((VisionControlBase) this._numericUpDownBirthDayDay);
      this._comboBoxSex = new VisionComboBox(180, 40, 64, 20);
      this._comboBoxSex.Items.AddRange((object[]) new string[2]
      {
        "Male",
        "Female"
      });
      this._comboBoxSex.SelectedIndexChanged += new EventHandler(this._comboBoxSex_SelectedIndexChanged);
      this._groupBox_Profile.AddVisionControl((VisionControlBase) this._comboBoxSex);
      this._profileTone = new VisionComboBox(80, 65, 121, 20);
      this._profileTone.Items.AddRange(new object[16]
      {
        (object) "Chirpy Boy",
        (object) "Cute Girl",
        (object) "Timid Boy",
        (object) "Shy Girl",
        (object) "Serious Man",
        (object) "Prim Woman",
        (object) "Macho Man",
        (object) "Temptress",
        (object) "Smarmy Guy",
        (object) "Grumpy Woman",
        (object) "Demon King",
        (object) "Witch",
        (object) "Nice Old Man",
        (object) "Kind Old Woman",
        (object) "Doddery Old Man",
        (object) "Bored Teenager"
      });
      this._profileTone.SelectedIndexChanged += new EventHandler(this._profileTone_SelectedIndexChanged);
      this._groupBox_Profile.AddVisionControl((VisionControlBase) this._profileTone);
      this._textBoxAddress = new VisionTextBox(80, 90, 120, 20);
      this._textBoxAddress.ReadOnly = true;
      this._groupBox_Profile.AddVisionControl((VisionControlBase) this._textBoxAddress);
      this._buttonSelectAddress = new VisionButton(205, 90, 39, 19);
      this._buttonSelectAddress.Text = "Set";
      this._buttonSelectAddress.Click += new EventHandler(this._buttonSelectAddress_Click);
      this._groupBox_Profile.AddVisionControl((VisionControlBase) this._buttonSelectAddress);
      this._textBoxHandle = new VisionTextBox(80, 114, 120, 20);
      this._textBoxHandle.ReadOnly = true;
      this._groupBox_Profile.AddVisionControl((VisionControlBase) this._textBoxHandle);
      this._buttonSelectHandle = new VisionButton(205, 114, 39, 19);
      this._buttonSelectHandle.Text = "Set";
      this._buttonSelectHandle.Click += new EventHandler(this._buttonSelectHandle_Click);
      this._groupBox_Profile.AddVisionControl((VisionControlBase) this._buttonSelectHandle);
      this._checkBoxSecretAge = new CheckBox();
      this._checkBoxSecretAge.AutoSize = true;
      this._checkBoxSecretAge.Location = new Point(19, 43);
      this._checkBoxSecretAge.Name = "_checkBox_SecretAge";
      this._checkBoxSecretAge.Size = new Size(109, 16);
      this._checkBoxSecretAge.Text = "Age is Secret?";
      this._checkBoxSecretAge.UseVisualStyleBackColor = true;
      this._checkBoxSecretAge.CheckedChanged += new EventHandler(this._checkBoxSecretAge_CheckedChanged);
      this._groupBox_Profile.Controls.Add((Control) this._checkBoxSecretAge);
      this._textBox_ProfileMessage = new TextBox();
      this._textBox_ProfileMessage.AcceptsReturn = true;
      this._textBox_ProfileMessage.Location = new Point(19, 157);
      this._textBox_ProfileMessage.MaxLength = 100;
      this._textBox_ProfileMessage.Multiline = true;
      this._textBox_ProfileMessage.Name = nameof (_textBox_ProfileMessage);
      this._textBox_ProfileMessage.Size = new Size(272, 45);
      this._textBox_ProfileMessage.TextChanged += new EventHandler(this._textBox_ProfileMessage_TextChanged);
      this._groupBox_Profile.Controls.Add((Control) this._textBox_ProfileMessage);
      this._groupBox_TreasureMap = new JS_GroupBox();
      this._groupBox_TreasureMap.Text = "Treasure Map";
      this._groupBox_TreasureMap.Size = new Size(420, 231);
      this._groupBox_TreasureMap.Location = new Point(322, 65);
      this._groupBox_TreasureMap.Paint += new PaintEventHandler(this._groupBox_TreasureMap_Paint);
      this._panelVisitorEditArea.Controls.Add((Control) this._groupBox_TreasureMap);
      this._comboBox_State = new ComboBox();
      this._comboBox_State.DropDownStyle = ComboBoxStyle.DropDownList;
      this._comboBox_State.FormattingEnabled = true;
      this._comboBox_State.Items.AddRange(new object[3]
      {
        (object) "Not Found",
        (object) "Discovered",
        (object) "Clear"
      });
      this._comboBox_State.Location = new Point(248, 38);
      this._comboBox_State.Size = new Size(90, 21);
      this._comboBox_State.SelectedIndexChanged += new EventHandler(this._comboBox_State_SelectedIndexChanged);
      this._groupBox_TreasureMap.Controls.Add((Control) this._comboBox_State);
      this._radioButton_DevilMap = new RadioButton();
      this._radioButton_DevilMap.AutoSize = true;
      this._radioButton_DevilMap.Location = new Point(102, 18);
      this._radioButton_DevilMap.Size = new Size(81, 16);
      this._radioButton_DevilMap.Tag = (object) MapType.devil;
      this._radioButton_DevilMap.Text = "Legacy Boss";
      this._radioButton_DevilMap.UseVisualStyleBackColor = true;
      this._radioButton_DevilMap.CheckedChanged += new EventHandler(this.radioButton_MapType_CheckedChanged);
      this._groupBox_TreasureMap.Controls.Add((Control) this._radioButton_DevilMap);
      this._radioButton_NormalMap = new RadioButton();
      this._radioButton_NormalMap.AutoSize = true;
      this._radioButton_NormalMap.Location = new Point(20, 18);
      this._radioButton_NormalMap.Size = new Size(71, 16);
      this._radioButton_NormalMap.Tag = (object) MapType.Normal;
      this._radioButton_NormalMap.Text = "Normal Map";
      this._radioButton_NormalMap.UseVisualStyleBackColor = true;
      this._radioButton_NormalMap.CheckedChanged += new EventHandler(this.radioButton_MapType_CheckedChanged);
      this._groupBox_TreasureMap.Controls.Add((Control) this._radioButton_NormalMap);
      this._numericUpDown_MapNo2 = new SafeNumericUpDown();
      this._numericUpDown_MapNo2.Location = new Point(111, 10);
      this._numericUpDown_MapNo2.Maximum = 65535M;
      this._numericUpDown_MapNo2.Size = new Size(74, 19);
      this._numericUpDown_MapNo2.ValueChanged += new EventHandler(this._numericUpDown_MapNo2_ValueChanged);
      this._numericUpDown_MapNo1 = new SafeNumericUpDown();
      this._numericUpDown_MapNo1.Location = new Point(54, 10);
      this._numericUpDown_MapNo1.Maximum = 255M;
      this._numericUpDown_MapNo1.Size = new Size(51, 19);
      this._numericUpDown_MapNo1.ValueChanged += new EventHandler(this._numericUpDown_MapNo1_ValueChanged);
      this._checkBox_Hex = new CheckBox();
      this._checkBox_Hex.Location = new Point(190, 12);
      this._checkBox_Hex.AutoSize = true;
      this._checkBox_Hex.Text = "Hex";
      this._checkBox_Hex.CheckedChanged += new EventHandler(this._checkBox_Hex_CheckedChanged);
      this._checkBox_PlaceHex = new CheckBox();
      this._checkBox_PlaceHex.Location = new Point(305, 63);
      this._checkBox_PlaceHex.AutoSize = true;
      this._checkBox_PlaceHex.Text = "Hex";
      this._checkBox_PlaceHex.CheckedChanged += new EventHandler(this._checkBox_PlaceHex_CheckedChanged);
      this._groupBox_TreasureMap.Controls.Add((Control) this._checkBox_PlaceHex);
      this._numericUpDown_Place = new SafeNumericUpDown();
      this._numericUpDown_Place.Location = new Point(248, 61);
      this._numericUpDown_Place.Maximum = 255M;
      this._numericUpDown_Place.Size = new Size(51, 20);
      this._numericUpDown_Place.ValueChanged += new EventHandler(this._numericUpDown_Place_ValueChanged);
      this._groupBox_TreasureMap.Controls.Add((Control) this._numericUpDown_Place);
      this._comboBox_Devil = new ComboBox();
      this._comboBox_Devil.DropDownStyle = ComboBoxStyle.DropDownList;
      this._comboBox_Devil.FormattingEnabled = true;
      this._comboBox_Devil.Location = new Point(54, 10);
      this._comboBox_Devil.Size = new Size(121, 20);
      this._comboBox_Devil.SelectedIndexChanged += new EventHandler(this._comboBox_Devil_SelectedIndexChanged);
      foreach (object obj in DevilList.List)
        this._comboBox_Devil.Items.Add(obj);
      this._textBox_Renewer = new TextBox();
      this._textBox_Renewer.Location = new Point(97, 61);
      this._textBox_Renewer.Name = "textBox_Renewer";
      this._textBox_Renewer.Size = new Size(90, 20);
      this._textBox_Renewer.TextChanged += new EventHandler(this._textBox_Renewer_TextChanged);
      this._groupBox_TreasureMap.Controls.Add((Control) this._textBox_Renewer);
      this._textBox_Detector = new TextBox();
      this._textBox_Detector.Location = new Point(97, 38);
      this._textBox_Detector.Name = "textBox_Detector";
      this._textBox_Detector.Size = new Size(90, 20);
      this._textBox_Detector.TabIndex = 6;
      this._textBox_Detector.TextChanged += new EventHandler(this._textBox_Detector_TextChanged);
      this._groupBox_TreasureMap.Controls.Add((Control) this._textBox_Detector);
      this._numericUpDown_DevilVictoryTurn = new SafeNumericUpDown();
      this._numericUpDown_DevilVictoryTurn.Location = new Point(126, 56);
      this._numericUpDown_DevilVictoryTurn.Location = new Point(126, 56);
      this._numericUpDown_DevilVictoryTurn.Maximum = 999M;
      this._numericUpDown_DevilVictoryTurn.Size = new Size(49, 19);
      this._numericUpDown_DevilVictoryTurn.ValueChanged += new EventHandler(this._numericUpDown_DevilVictoryTurn_ValueChanged);
      this._numericUpDown_DevilLevel = new SafeNumericUpDown();
      this._numericUpDown_DevilLevel.Location = new Point(126, 34);
      this._numericUpDown_DevilLevel.Maximum = 255M;
      this._numericUpDown_DevilLevel.Size = new Size(49, 19);
      this._numericUpDown_DevilLevel.ValueChanged += new EventHandler(this._numericUpDown_DevilLevel_ValueChanged);
      this._panel_DevilMap = new DoubleBufferedPanel();
      this._panel_DevilMap.Controls.Add((Control) this._numericUpDown_DevilVictoryTurn);
      this._panel_DevilMap.Controls.Add((Control) this._numericUpDown_DevilLevel);
      this._panel_DevilMap.Controls.Add((Control) this._comboBox_Devil);
      this._panel_DevilMap.Location = new Point(12, 141);
      this._panel_DevilMap.Size = new Size(233, 80);
      this._panel_DevilMap.Paint += new PaintEventHandler(this._panel_DevilMap_Paint);
      this._groupBox_TreasureMap.Controls.Add((Control) this._panel_DevilMap);
      this._panel_NormalMap = new DoubleBufferedPanel();
      this._panel_NormalMap.Controls.Add((Control) this._numericUpDown_MapNo2);
      this._panel_NormalMap.Controls.Add((Control) this._numericUpDown_MapNo1);
      this._panel_NormalMap.Controls.Add((Control) this._checkBox_Hex);
      this._panel_NormalMap.Location = new Point(12, 141);
      this._panel_NormalMap.Size = new Size(233, 60);
      this._panel_NormalMap.Paint += new PaintEventHandler(this._panel_NormalMap_Paint);
      this._groupBox_TreasureMap.Controls.Add((Control) this._panel_NormalMap);
      this._checkBox_OpenProbability3 = new CheckBox();
      this._checkBox_OpenProbability3.AutoSize = true;
      this._checkBox_OpenProbability3.Location = new Point(153, 18);
      this._checkBox_OpenProbability3.Size = new Size(57, 16);
      this._checkBox_OpenProbability3.Tag = (object) 2;
      this._checkBox_OpenProbability3.Text = "Third";
      this._checkBox_OpenProbability3.UseVisualStyleBackColor = true;
      this._checkBox_OpenProbability3.CheckedChanged += new EventHandler(this._checkBox_OpenProbability_CheckedChanged);
      this._checkBox_OpenProbability2 = new CheckBox();
      this._checkBox_OpenProbability2.AutoSize = true;
      this._checkBox_OpenProbability2.Location = new Point(90, 18);
      this._checkBox_OpenProbability2.Size = new Size(57, 16);
      this._checkBox_OpenProbability2.Tag = (object) 1;
      this._checkBox_OpenProbability2.Text = "Second";
      this._checkBox_OpenProbability2.UseVisualStyleBackColor = true;
      this._checkBox_OpenProbability2.CheckedChanged += new EventHandler(this._checkBox_OpenProbability_CheckedChanged);
      this._checkBox_OpenProbability1 = new CheckBox();
      this._checkBox_OpenProbability1.AutoSize = true;
      this._checkBox_OpenProbability1.Location = new Point(27, 18);
      this._checkBox_OpenProbability1.Name = "checkBox_OpenProbability1";
      this._checkBox_OpenProbability1.Size = new Size(57, 16);
      this._checkBox_OpenProbability1.Tag = (object) 0;
      this._checkBox_OpenProbability1.Text = "First";
      this._checkBox_OpenProbability1.UseVisualStyleBackColor = true;
      this._checkBox_OpenProbability1.CheckedChanged += new EventHandler(this._checkBox_OpenProbability_CheckedChanged);
      this._groupBox_Probability = new JS_GroupBox();
      this._groupBox_Probability.Controls.Add((Control) this._checkBox_OpenProbability3);
      this._groupBox_Probability.Controls.Add((Control) this._checkBox_OpenProbability2);
      this._groupBox_Probability.Controls.Add((Control) this._checkBox_OpenProbability1);
      this._groupBox_Probability.Location = new Point(12, 89);
      this._groupBox_Probability.Size = new Size(231, 43);
      this._groupBox_Probability.Text = "Treasures Plundered";
      this._groupBox_TreasureMap.Controls.Add((Control) this._groupBox_Probability);
      this._button_CreateMap = new Button();
      this._button_CreateMap.Text = "Add";
      this._button_CreateMap.Location = new Point(545, 260);
      this._button_CreateMap.Size = new Size(50, 23);
      this._button_CreateMap.Click += new EventHandler(this._button_CreateMap_Click);
      this._panelVisitorEditArea.Controls.Add((Control) this._button_CreateMap);
      this._panelVisitorEditArea.Controls.SetChildIndex((Control) this._button_CreateMap, 0);
      this._button_DeleteMap = new Button();
      this._button_DeleteMap.Text = "Delete";
      this._button_DeleteMap.Location = new Point(600, 260);
      this._button_DeleteMap.Size = new Size(50, 23);
      this._button_DeleteMap.Click += new EventHandler(this._button_DeleteMap_Click);
      this._panelVisitorEditArea.Controls.Add((Control) this._button_DeleteMap);
      this._panelVisitorEditArea.Controls.SetChildIndex((Control) this._button_DeleteMap, 1);
      this._panel_DevilMap.Visible = false;
      this._panelVisitorEditArea.Enabled = false;
      this.ResumeLayout(false);
    }

    private void _button_DeleteMap_Click(object sender, EventArgs e)
    {
      VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
      TreasureMapData treasureMapData = visitorManager.VisitorData[this._selectedIndex].TreasureMapData;
      if (!visitorManager.VisitorData[this._selectedIndex].HaveTreasureMap)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      visitorManager.VisitorData[this._selectedIndex].HaveTreasureMap = false;
      treasureMapData.Clear();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.BeginUpdate();
      this._panel_DevilMap.Visible = false;
      this._panel_NormalMap.Visible = true;
      this._radioButton_NormalMap.Checked = true;
      this._comboBox_State.SelectedIndex = -1;
      this._numericUpDown_MapNo1.Value = 0M;
      this._numericUpDown_MapNo2.Value = 0M;
      this._numericUpDown_Place.Value = 0M;
      this._textBox_Detector.Text = string.Empty;
      this._textBox_Renewer.Text = string.Empty;
      this._checkBox_OpenProbability1.Checked = false;
      this._checkBox_OpenProbability2.Checked = false;
      this._checkBox_OpenProbability3.Checked = false;
      this._groupBox_TreasureMap.Enabled = false;
      this.EndUpdate();
      this._button_CreateMap.Enabled = true;
      this._button_DeleteMap.Enabled = false;
    }

    private void _button_CreateMap_Click(object sender, EventArgs e)
    {
      VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
      TreasureMapData treasureMapData = visitorManager.VisitorData[this._selectedIndex].TreasureMapData;
      if (visitorManager.VisitorData[this._selectedIndex].HaveTreasureMap && treasureMapData.MapType != MapType.Unknown)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      visitorManager.VisitorData[this._selectedIndex].HaveTreasureMap = true;
      treasureMapData.MapType = MapType.Normal;
      treasureMapData.Rank = (byte) 2;
      treasureMapData.Seed = (ushort) 1;
      treasureMapData.Place.Value = (byte) 0;
      treasureMapData.SetOpenProbability(0, false);
      treasureMapData.SetOpenProbability(1, false);
      treasureMapData.SetOpenProbability(2, false);
      treasureMapData.MapState = MapState.NotDiscover;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.BeginUpdate();
      this._panel_DevilMap.Visible = false;
      this._panel_NormalMap.Visible = true;
      this._panel_NormalMap.Invalidate();
      this._radioButton_NormalMap.Checked = true;
      this._comboBox_State.SelectedIndex = 0;
      this._numericUpDown_MapNo1.Value = 2M;
      this._numericUpDown_MapNo2.Value = 1M;
      this._numericUpDown_Place.Value = 0M;
      this._textBox_Detector.Text = string.Empty;
      this._textBox_Renewer.Text = string.Empty;
      this._checkBox_OpenProbability1.Checked = false;
      this._checkBox_OpenProbability2.Checked = false;
      this._checkBox_OpenProbability3.Checked = false;
      this._groupBox_TreasureMap.Enabled = true;
      this.EndUpdate();
      this._numericUpDown_Place.ForeColor = Color.Red;
      this._button_CreateMap.Enabled = false;
      this._button_DeleteMap.Enabled = true;
    }

    private void _numericUpDown_Place_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      TreasureMapData treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData;
      treasureMapData.Place.Value = (byte) this._numericUpDown_Place.Value;
      if (treasureMapData.MapType == MapType.devil || treasureMapData.IsValidPlace)
        this._numericUpDown_Place.ForeColor = Color.Black;
      else
        this._numericUpDown_Place.ForeColor = Color.Red;
      this._panel_NormalMap.Invalidate();
    }

    private void _comboBox_Devil_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._comboBox_Devil.SelectedIndex == -1 || !(this._comboBox_Devil.SelectedItem is Devil selectedItem))
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData.DevilType = selectedItem;
    }

    private void _numericUpDown_DevilLevel_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData.DevilLevel.Value = (byte) this._numericUpDown_DevilLevel.Value;
    }

    private void _numericUpDown_DevilVictoryTurn_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData.DevilVictoryTurn = (ushort) this._numericUpDown_DevilVictoryTurn.Value;
    }

    private void _checkBox_OpenProbability_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is CheckBox checkBox))
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData.SetOpenProbability((int) checkBox.Tag, checkBox.Checked);
    }

    private void _textBox_Detector_TextChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.BeginUpdate();
      TreasureMapData treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData;
      treasureMapData.Detector.Value = this._textBox_Detector.Text;
      this._textBox_Detector.Text = treasureMapData.Detector.Value;
      this.EndUpdate();
    }

    private void _textBox_Renewer_TextChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.BeginUpdate();
      TreasureMapData treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData;
      treasureMapData.Renewer.Value = this._textBox_Renewer.Text;
      this._textBox_Renewer.Text = treasureMapData.Renewer.Value;
      this.EndUpdate();
    }

    private void _numericUpDown_MapNo1_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount == 0)
      {
        TreasureMapData treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData;
        treasureMapData.Rank = (byte) this._numericUpDown_MapNo1.Value;
        if (treasureMapData.IsValidRank)
          this._numericUpDown_MapNo1.ForeColor = Color.Black;
        else
          this._numericUpDown_MapNo1.ForeColor = Color.Red;
        if (treasureMapData.IsValidPlace)
          this._numericUpDown_Place.ForeColor = Color.Black;
        else
          this._numericUpDown_Place.ForeColor = Color.Red;
        this._groupBox_TreasureMap.Invalidate();
      }
      this._panel_NormalMap.Invalidate();
    }

    private void _numericUpDown_MapNo2_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount == 0)
      {
        TreasureMapData treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData;
        treasureMapData.Seed = (ushort) this._numericUpDown_MapNo2.Value;
        if (treasureMapData.IsValidSeed)
          this._numericUpDown_MapNo2.ForeColor = Color.Black;
        else
          this._numericUpDown_MapNo2.ForeColor = Color.Red;
        if (treasureMapData.IsValidPlace)
          this._numericUpDown_Place.ForeColor = Color.Black;
        else
          this._numericUpDown_Place.ForeColor = Color.Red;
        this._groupBox_TreasureMap.Invalidate();
      }
      this._panel_NormalMap.Invalidate();
    }

    private void _checkBox_Hex_CheckedChanged(object sender, EventArgs e)
    {
      this._numericUpDown_MapNo1.Hexadecimal = this._checkBox_Hex.Checked;
      this._numericUpDown_MapNo2.Hexadecimal = this._checkBox_Hex.Checked;
    }

    private void _checkBox_PlaceHex_CheckedChanged(object sender, EventArgs e)
    {
      this._numericUpDown_Place.Hexadecimal = this._checkBox_PlaceHex.Checked;
      this._groupBox_TreasureMap.Invalidate();
    }

    private void radioButton_MapType_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is RadioButton radioButton))
        return;
      MapType tag = (MapType) radioButton.Tag;
      TreasureMapData treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      treasureMapData.MapType = tag;
      if (tag == MapType.Normal)
      {
        treasureMapData.Rank = (byte) 2;
        this._panel_NormalMap.Visible = true;
        this._panel_DevilMap.Visible = false;
        this._numericUpDown_MapNo1.Value = (Decimal) treasureMapData.Rank;
        this._numericUpDown_MapNo2.Value = (Decimal) treasureMapData.Seed;
        if (treasureMapData.IsValidRank)
          this._numericUpDown_MapNo1.ForeColor = Color.Black;
        else
          this._numericUpDown_MapNo1.ForeColor = Color.Red;
        if (treasureMapData.IsValidSeed)
          this._numericUpDown_MapNo2.ForeColor = Color.Black;
        else
          this._numericUpDown_MapNo2.ForeColor = Color.Red;
        if (treasureMapData.IsValidPlace)
          this._numericUpDown_Place.ForeColor = Color.Black;
        else
          this._numericUpDown_Place.ForeColor = Color.Red;
      }
      else
      {
        treasureMapData.Rank = (byte) 1;
        treasureMapData.DevilVictoryTurn = (ushort) 0;
        this._panel_NormalMap.Visible = false;
        this._panel_DevilMap.Visible = true;
        this._comboBox_Devil.SelectedItem = (object) treasureMapData.DevilType;
        this._numericUpDown_DevilLevel.Value = (Decimal) treasureMapData.DevilLevel.Value;
        this._numericUpDown_DevilVictoryTurn.Value = (Decimal) treasureMapData.DevilVictoryTurn;
        this._numericUpDown_Place.ForeColor = Color.Black;
      }
      this._groupBox_TreasureMap.Invalidate();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    private void _comboBox_State_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapData.MapState = (MapState) (1 << this._comboBox_State.SelectedIndex);
    }

    private void _panel_NormalMap_Paint(object sender, PaintEventArgs e)
    {
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        e.Graphics.DrawString("Map No.", this.Font, brush, 7f, 14f);
        if (this.DesignMode)
          return;
        VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        if (this._selectedIndex == -1 || !visitorManager.VisitorData[this._selectedIndex].HaveTreasureMap)
          return;
        TreasureMapData treasureMapData = visitorManager.VisitorData[this._selectedIndex].TreasureMapData;
        string s = !treasureMapData.IsValid ? string.Format("!{0}", (object) treasureMapData.MapName) : treasureMapData.MapName;
        e.Graphics.DrawString(s, this.Font, brush, 7f, 35f);
      }
    }

    private void _panel_DevilMap_Paint(object sender, PaintEventArgs e)
    {
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        e.Graphics.DrawString("Turns Defeated In", this.Font, brush, 31f, 58f);
        e.Graphics.DrawString("Level", this.Font, brush, 93f, 36f);
        e.Graphics.DrawString("Boss", this.Font, brush, 23f, 14f);
      }
    }

    private void _groupBox_TreasureMap_Paint(object sender, PaintEventArgs e)
    {
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        e.Graphics.DrawString("Location", this.Font, brush, 200f, 64f);
        e.Graphics.DrawString("Discovered by", this.Font, brush, 19f, 42f);
        e.Graphics.DrawString("Conquered by", this.Font, brush, 22f, 64f);
        e.Graphics.DrawString("Status", this.Font, brush, 211f, 42f);
        if (this.DesignMode)
          return;
        VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        if (this._selectedIndex == -1 || !visitorManager.VisitorData[this._selectedIndex].HaveTreasureMap)
          return;
        TreasureMapData treasureMapData = visitorManager.VisitorData[this._selectedIndex].TreasureMapData;
        if (treasureMapData.MapType != MapType.Normal)
          return;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Valid: ");
        ReadOnlyCollection<byte> validPlaceList = treasureMapData.ValidPlaceList;
        if (validPlaceList.Count > 0)
        {
          bool flag = true;
          foreach (byte num in validPlaceList)
          {
            if (!flag)
              stringBuilder.Append(", ");
            if (this._checkBox_PlaceHex.Checked)
              stringBuilder.AppendFormat("{0:X02}", (object) num);
            else
              stringBuilder.AppendFormat("{0:D}", (object) num);
            flag = false;
          }
        }
        else
          stringBuilder.Append("none");
        e.Graphics.DrawString(stringBuilder.ToString(), this.Font, brush, 247f, 83f);
      }
    }

    private void _buttonSelectHandle_Click(object sender, EventArgs e)
    {
      VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
      using (HandleSelectWindow handleSelectWindow = new HandleSelectWindow((int) visitorManager.VisitorData[this._selectedIndex].ProfileSex))
      {
        handleSelectWindow.Location = this.PointToScreen(new Point(this._groupBox_Profile.Left + this._buttonSelectHandle.Right, this._groupBox_Profile.Top + this._buttonSelectHandle.Bottom));
        if (handleSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        DQ9_Cheat.GameData.Handle selectedHandle = handleSelectWindow.SelectedHandle;
        visitorManager.VisitorData[this._selectedIndex].Handle = selectedHandle;
        this.OnValueUpdate();
      }
    }

    private void _buttonSelectAddress_Click(object sender, EventArgs e)
    {
      using (AddressSelectWindow addressSelectWindow = new AddressSelectWindow())
      {
        addressSelectWindow.Location = this.PointToScreen(new Point(this._groupBox_Profile.Left + this._buttonSelectAddress.Right, this._groupBox_Profile.Top + this._buttonSelectAddress.Bottom));
        if (addressSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].Address = addressSelectWindow.SelectedAddress;
        this.OnValueUpdate();
      }
    }

    private void _numericUpDownSEQ_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].SEQ = (uint) this._numericUpDownSEQ.Value;
    }

    private void _numericUpDownUID_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
      ulong num = (ulong) this._numericUpDownUID.Value;
      if ((long) visitorManager.VisitorData[this._selectedIndex].UID == (long) num)
        return;
      visitorManager.VisitorData[this._selectedIndex].UID = num;
    }

    private void _numericUpDownUID_Enter(object sender, EventArgs e)
    {
      MainWindow.Instance.StatusBarText.Text = "UIDは宿泊者の中でユニークになるように付けてください。";
    }

    private void _numericUpDownUID_Leave(object sender, EventArgs e)
    {
      MainWindow.Instance.StatusBarText.Text = string.Empty;
    }

    private void _numericUpDownEyeColor_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].EyeColor = (byte) this._numericUpDownEyeColor.Value;
    }

    private void _numericUpDownSkinColor_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].SkinColor = (byte) this._numericUpDownSkinColor.Value;
    }

    private void _numericUpDownFaceType_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].FaceType.Value = (byte) this._numericUpDownFaceType.Value;
    }

    private void _numericUpDownHairColor_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].HairColor.Value = (byte) this._numericUpDownHairColor.Value;
    }

    private void _numericUpDownHairType_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].HairType.Value = (byte) this._numericUpDownHairType.Value;
    }

    private void _numericUpDownFigureHeight_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].FigureHeight.Value = (ushort) this._numericUpDownFigureHeight.Value;
    }

    private void _numericUpDownFigureWidth_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].FigureWidth.Value = (ushort) this._numericUpDownFigureWidth.Value;
    }

    private void _numericUpDownBirthDayDay_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].ProfileBirthDay = (byte) this._numericUpDownBirthDayDay.Value;
    }

    private void _numericUpDownBirthDayMonth_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].ProfileBirthMonth = (byte) this._numericUpDownBirthDayMonth.Value;
    }

    private void _numericUpDownBirthDayYear_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].ProfileBirthYear = (ushort) this._numericUpDownBirthDayYear.Value;
    }

    private void _comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].Color = (byte) this._comboBoxColor.SelectedIndex;
    }

    private void _textBox_ProfileMessage_TextChanged(object sender, EventArgs e)
    {
      int maxLength = SaveDataManager.Instance.SaveData.BasisData.ProfileMessage.MaxLength;
      Encoding templateencoding = (Encoding) StringFixer.templateencoding;
      byte[] bytes = templateencoding.GetBytes(this._textBox_ProfileMessage.Text);
      if (bytes.Length > maxLength)
      {
        this._textBox_ProfileMessage.Text = templateencoding.GetString(bytes, 0, maxLength);
        this._textBox_ProfileMessage.SelectionStart = this._textBox_ProfileMessage.TextLength;
      }
      else
        this._textBox_ProfileMessage.Text = templateencoding.GetString(bytes, 0, bytes.Length);
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].ProfileMessage.Value = this._textBox_ProfileMessage.Text;
    }

    private void _checkBoxSecretAge_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].ProfileSecretAge = this._checkBoxSecretAge.Checked;
    }

    private void _profileTone_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].ProfileTone = (byte) this._profileTone.SelectedIndex;
    }

    private void _comboBoxSex_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
      visitorManager.VisitorData[this._selectedIndex].CharaSex = (byte) this._comboBoxSex.SelectedIndex;
      visitorManager.VisitorData[this._selectedIndex].ProfileSex = (byte) this._comboBoxSex.SelectedIndex;
      visitorManager.VisitorData[this._selectedIndex].Sex = (byte) this._comboBoxSex.SelectedIndex;
      this.RenewalHanle(visitorManager.VisitorData[this._selectedIndex]);
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    private void _numericUpDownAlchemyCompRate_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].AlchemyCompRate = (byte) this._numericUpDownAlchemyCompRate.Value;
    }

    private void _numericUpDownItemCompRate_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].ItemCompRate = (byte) this._numericUpDownItemCompRate.Value;
    }

    private void _numericUpDownFashionCompRate_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].FashionCompRate = (byte) this._numericUpDownFashionCompRate.Value;
    }

    private void _numericUpDownMonsterCompRate_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].MonsterCompRate = (byte) this._numericUpDownMonsterCompRate.Value;
    }

    private void _numericUpDownVisitorCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].VisitorCount = (ushort) this._numericUpDownVisitorCount.Value;
    }

    private void _numericUpDownTreasureMapCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TreasureMapCount = (ushort) this._numericUpDownTreasureMapCount.Value;
    }

    private void _numericUpDownQuestClearCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].QuestClearCount = (ushort) this._numericUpDownQuestClearCount.Value;
    }

    private void _numericUpDownTitleCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].TitleCount = (ushort) this._numericUpDownTitleCount.Value;
    }

    private void _numericUpDownAlchemyCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].AlchemyCount = (ushort) this._numericUpDownAlchemyCount.Value;
    }

    private void _numericUpDownVictoryCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].VictoryCount = (uint) (ushort) this._numericUpDownVictoryCount.Value;
    }

    private void _numericUpDownMultiPlayTimeMinute_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].MultiPlayTimeMinute = (byte) this._numericUpDownMultiPlayTimeMinute.Value;
    }

    private void _numericUpDownMultiPlayTimeHour_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].MultiPlayTimeHour = (ushort) this._numericUpDownMultiPlayTimeHour.Value;
    }

    private void _numericUpDownPlayTimeMinute_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].PlayTimeMinute = (byte) this._numericUpDownPlayTimeMinute.Value;
    }

    private void _numericUpDownPlayTimeHour_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].PlayTimeHour = (ushort) this._numericUpDownPlayTimeHour.Value;
    }

    private void _numericUpDownTransmigration_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].Transmigration = (byte) this._numericUpDownTransmigration.Value;
    }

    private void _numericUpDownLV_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].Level = (byte) this._numericUpDownLV.Value;
    }

    private void _comboBoxPlace_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].Place = (byte) this._comboBoxPlace.SelectedIndex;
    }

    private void _textBoxName_TextChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
      visitorManager.VisitorData[this._selectedIndex].Name.Value = this._textBoxName.Text;
      if (visitorManager.VisitorData[this._selectedIndex].Name.Value != this._textBoxName.Text)
      {
        this._textBoxName.Text = visitorManager.VisitorData[this._selectedIndex].Name.Value;
        this._textBoxName.SelectionStart = this._textBoxName.Text.Length;
      }
      if (!(this.Parent is RikkaInnDataControl parent))
        return;
      parent.RenewalListBox();
    }

    private void _comboBoxJob_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].Job = (byte) JobDataList.List[this._comboBoxJob.SelectedIndex].DataIndex;
    }

    private void _numericUpDownLodgingYear_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].LodgingDay_Year = (ushort) this._numericUpDownLodgingYear.Value;
    }

    private void _numericUpDownLodgingMonth_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].LodgingDay_Month = (byte) this._numericUpDownLodgingMonth.Value;
    }

    private void _numericUpDownLodgingDay_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedIndex == -1)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].LodgingDay_Day = (byte) this._numericUpDownLodgingDay.Value;
    }

    protected override void OnResize(EventArgs e) => this._panelVisitorEditArea.Size = this.Size;

    private void BeginUpdate() => ++this._updateCount;

    private void EndUpdate()
    {
      if (this._updateCount <= 0)
        return;
      --this._updateCount;
    }

    public void OnValueUpdate() => this.OnValueUpdate(this._selectedIndex);

    public void OnValueUpdate(int index)
    {
      this._selectedIndex = index;
      this.BeginUpdate();
      this.Invalidate();
      VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
      if (this._selectedIndex != -1)
      {
        this._panelVisitorEditArea.Enabled = true;
        VisitorData visitorData = visitorManager.VisitorData[this._selectedIndex];
        this._numericUpDownLodgingYear.Value = (Decimal) visitorData.LodgingDay_Year;
        this._numericUpDownLodgingMonth.Value = (Decimal) visitorData.LodgingDay_Month;
        this._numericUpDownLodgingDay.Value = (Decimal) visitorData.LodgingDay_Day;
        this._textBoxName.Text = visitorData.Name.Value;
        this._comboBoxColor.SelectedIndex = (int) visitorData.Color;
        for (int index1 = 0; index1 < JobDataList.List.Count; ++index1)
        {
          if (JobDataList.List[index1].DataIndex == (int) visitorData.Job)
          {
            this._comboBoxJob.SelectedIndex = index1;
            break;
          }
        }
        this._comboBoxPlace.SelectedIndex = (int) visitorData.Place;
        this._numericUpDownSEQ.Value = (Decimal) visitorData.SEQ;
        this._numericUpDownUID.Value = (Decimal) visitorData.UID;
        this._numericUpDownLV.Value = (Decimal) visitorData.Level;
        this._numericUpDownTransmigration.Value = (Decimal) visitorData.Transmigration;
        this._numericUpDownPlayTimeHour.Value = (Decimal) visitorData.PlayTimeHour;
        this._numericUpDownPlayTimeMinute.Value = (Decimal) visitorData.PlayTimeMinute;
        this._numericUpDownMultiPlayTimeHour.Value = (Decimal) visitorData.MultiPlayTimeHour;
        this._numericUpDownMultiPlayTimeMinute.Value = (Decimal) visitorData.MultiPlayTimeMinute;
        this._numericUpDownVictoryCount.Value = (Decimal) visitorData.VictoryCount;
        this._numericUpDownAlchemyCount.Value = (Decimal) visitorData.AlchemyCount;
        this._numericUpDownTitleCount.Value = (Decimal) visitorData.TitleCount;
        this._numericUpDownQuestClearCount.Value = (Decimal) visitorData.QuestClearCount;
        this._numericUpDownTreasureMapCount.Value = (Decimal) visitorData.TreasureMapCount;
        this._numericUpDownVisitorCount.Value = (Decimal) visitorData.VisitorCount;
        this._numericUpDownMonsterCompRate.Value = (Decimal) visitorData.MonsterCompRate;
        this._numericUpDownFashionCompRate.Value = (Decimal) visitorData.FashionCompRate;
        this._numericUpDownItemCompRate.Value = (Decimal) visitorData.ItemCompRate;
        this._numericUpDownAlchemyCompRate.Value = (Decimal) visitorData.AlchemyCompRate;
        this._numericUpDownFigureWidth.Value = (Decimal) visitorData.FigureWidth.Value;
        this._numericUpDownFigureHeight.Value = (Decimal) visitorData.FigureHeight.Value;
        this._numericUpDownHairType.Value = (Decimal) visitorData.HairType.Value;
        this._numericUpDownHairColor.Value = (Decimal) visitorData.HairColor.Value;
        this._numericUpDownFaceType.Value = (Decimal) visitorData.FaceType.Value;
        this._numericUpDownSkinColor.Value = (Decimal) visitorData.SkinColor;
        this._numericUpDownEyeColor.Value = (Decimal) visitorData.EyeColor;
        this._textBoxEquipmentWeapon.Text = visitorData.EquipmentWeapon == null ? "nothing" : visitorData.EquipmentWeapon.Name;
        this._textBoxEquipmentShield.Text = visitorData.EquipmentShield == null ? "nothing" : visitorData.EquipmentShield.Name;
        this._textBoxEquipmentHead.Text = visitorData.EquipmentHead == null ? "nothing" : visitorData.EquipmentHead.Name;
        this._textBoxEquipmentUpperBody.Text = visitorData.EquipmentUpperBody == null ? "nothing" : visitorData.EquipmentUpperBody.Name;
        this._textBoxEquipmentArm.Text = visitorData.EquipmentArm == null ? "nothing" : visitorData.EquipmentArm.Name;
        this._textBoxEquipmentLowerBody.Text = visitorData.EquipmentLowerBody == null ? "nothing" : visitorData.EquipmentLowerBody.Name;
        this._textBoxEquipmentShoe.Text = visitorData.EquipmentShoe == null ? "nothing" : visitorData.EquipmentShoe.Name;
        this._textBoxEquipmentAccessory.Text = visitorData.EquipmentAccessory == null ? "nothing" : visitorData.EquipmentAccessory.Name;
        this._numericUpDownBirthDayYear.Value = (Decimal) visitorData.ProfileBirthYear;
        this._numericUpDownBirthDayMonth.Value = (Decimal) visitorData.ProfileBirthMonth;
        this._numericUpDownBirthDayDay.Value = (Decimal) visitorData.ProfileBirthDay;
        this._checkBoxSecretAge.Checked = visitorData.ProfileSecretAge;
        this._comboBoxSex.SelectedIndex = (int) visitorData.CharaSex;
        this._profileTone.SelectedIndex = (int) visitorData.ProfileTone;
        this._textBoxAddress.Text = visitorData.Address.Name;
        this.RenewalHanle(visitorData);
        this._textBox_ProfileMessage.Text = visitorData.ProfileMessage.Value;
        if (!visitorData.HaveTreasureMap || visitorData.TreasureMapData.MapType == MapType.Unknown)
        {
          this._groupBox_TreasureMap.Enabled = false;
          this._panel_NormalMap.Visible = true;
          this._panel_DevilMap.Visible = false;
          this._numericUpDown_MapNo1.Value = 0M;
          this._numericUpDown_MapNo2.Value = 0M;
          this._numericUpDown_Place.Value = 0M;
          this._comboBox_State.SelectedIndex = -1;
          this._textBox_Detector.Text = string.Empty;
          this._textBox_Renewer.Text = string.Empty;
          this._button_CreateMap.Enabled = true;
          this._button_DeleteMap.Enabled = false;
        }
        else
        {
          this._groupBox_TreasureMap.Enabled = true;
          this._numericUpDown_Place.Value = (Decimal) visitorData.TreasureMapData.Place.Value;
          if (visitorData.TreasureMapData.MapType == MapType.Normal)
          {
            this._radioButton_NormalMap.Checked = true;
            this._panel_NormalMap.Visible = true;
            this._panel_DevilMap.Visible = false;
            this._numericUpDown_MapNo1.Value = (Decimal) visitorData.TreasureMapData.Rank;
            this._numericUpDown_MapNo2.Value = (Decimal) visitorData.TreasureMapData.Seed;
            if (visitorData.TreasureMapData.IsValidRank)
              this._numericUpDown_MapNo1.ForeColor = Color.Black;
            else
              this._numericUpDown_MapNo1.ForeColor = Color.Red;
            if (visitorData.TreasureMapData.IsValidSeed)
              this._numericUpDown_MapNo2.ForeColor = Color.Black;
            else
              this._numericUpDown_MapNo2.ForeColor = Color.Red;
            if (visitorData.TreasureMapData.IsValidPlace)
              this._numericUpDown_Place.ForeColor = Color.Black;
            else
              this._numericUpDown_Place.ForeColor = Color.Red;
          }
          else
          {
            this._radioButton_DevilMap.Checked = true;
            this._panel_NormalMap.Visible = false;
            this._panel_DevilMap.Visible = true;
            this._comboBox_Devil.SelectedItem = (object) visitorData.TreasureMapData.DevilType;
            this._numericUpDown_DevilLevel.Value = (Decimal) visitorData.TreasureMapData.DevilLevel.Value;
            this._numericUpDown_DevilVictoryTurn.Value = (Decimal) visitorData.TreasureMapData.DevilVictoryTurn;
            this._numericUpDown_Place.ForeColor = Color.Black;
          }
          this._textBox_Detector.Text = visitorData.TreasureMapData.Detector.Value;
          this._textBox_Renewer.Text = visitorData.TreasureMapData.Renewer.Value;
          if (visitorData.TreasureMapData.MapState == MapState.NotDiscover)
            this._comboBox_State.SelectedIndex = 0;
          else if (visitorData.TreasureMapData.MapState == MapState.Discover)
            this._comboBox_State.SelectedIndex = 1;
          else if (visitorData.TreasureMapData.MapState == MapState.Clear)
            this._comboBox_State.SelectedIndex = 2;
          else
            this._comboBox_State.SelectedIndex = -1;
          this._checkBox_OpenProbability1.Checked = visitorData.TreasureMapData.IsOpenProbability(0);
          this._checkBox_OpenProbability2.Checked = visitorData.TreasureMapData.IsOpenProbability(1);
          this._checkBox_OpenProbability3.Checked = visitorData.TreasureMapData.IsOpenProbability(2);
          this._button_CreateMap.Enabled = false;
          this._button_DeleteMap.Enabled = true;
        }
      }
      else
      {
        this._panelVisitorEditArea.Enabled = false;
        this._numericUpDownLodgingYear.Value = 2000M;
        this._numericUpDownLodgingMonth.Value = 1M;
        this._numericUpDownLodgingDay.Value = 1M;
        this._textBoxName.Text = string.Empty;
        this._comboBoxColor.SelectedIndex = -1;
        this._comboBoxJob.SelectedIndex = -1;
        this._comboBoxPlace.SelectedIndex = -1;
        this._numericUpDownSEQ.Value = 1M;
        this._numericUpDownLV.Value = 0M;
        this._numericUpDownTransmigration.Value = 0M;
        this._numericUpDownPlayTimeHour.Value = 0M;
        this._numericUpDownPlayTimeMinute.Value = 0M;
        this._numericUpDownMultiPlayTimeHour.Value = 0M;
        this._numericUpDownMultiPlayTimeMinute.Value = 0M;
        this._numericUpDownVictoryCount.Value = 0M;
        this._numericUpDownAlchemyCount.Value = 0M;
        this._numericUpDownTitleCount.Value = 0M;
        this._numericUpDownQuestClearCount.Value = 0M;
        this._numericUpDownTreasureMapCount.Value = 0M;
        this._numericUpDownVisitorCount.Value = 0M;
        this._numericUpDownMonsterCompRate.Value = 0M;
        this._numericUpDownFashionCompRate.Value = 0M;
        this._numericUpDownItemCompRate.Value = 0M;
        this._numericUpDownAlchemyCompRate.Value = 0M;
        this._numericUpDownFigureWidth.Value = 0M;
        this._numericUpDownFigureHeight.Value = 0M;
        this._numericUpDownHairType.Value = 0M;
        this._numericUpDownHairColor.Value = 0M;
        this._numericUpDownFaceType.Value = 0M;
        this._numericUpDownSkinColor.Value = 0M;
        this._numericUpDownEyeColor.Value = 0M;
        this._textBoxEquipmentWeapon.Text = string.Empty;
        this._textBoxEquipmentShield.Text = string.Empty;
        this._textBoxEquipmentHead.Text = string.Empty;
        this._textBoxEquipmentUpperBody.Text = string.Empty;
        this._textBoxEquipmentArm.Text = string.Empty;
        this._textBoxEquipmentLowerBody.Text = string.Empty;
        this._textBoxEquipmentShoe.Text = string.Empty;
        this._textBoxEquipmentAccessory.Text = string.Empty;
        this._numericUpDownBirthDayYear.Value = 0M;
        this._numericUpDownBirthDayMonth.Value = 0M;
        this._numericUpDownBirthDayDay.Value = 0M;
        this._checkBoxSecretAge.Checked = false;
        this._comboBoxSex.SelectedIndex = -1;
        this._profileTone.SelectedIndex = -1;
        this._textBoxAddress.Text = string.Empty;
        this._textBoxHandle.Text = string.Empty;
        this._textBox_ProfileMessage.Text = string.Empty;
        this._groupBox_TreasureMap.Enabled = false;
        this._panel_NormalMap.Visible = true;
        this._panel_DevilMap.Visible = false;
        this._numericUpDown_MapNo1.Value = 0M;
        this._numericUpDown_MapNo2.Value = 0M;
        this._numericUpDown_Place.Value = 0M;
        this._comboBox_State.SelectedIndex = -1;
        this._textBox_Detector.Text = string.Empty;
        this._textBox_Renewer.Text = string.Empty;
      }
      this.EndUpdate();
    }

    private void RenewalHanle(VisitorData visitorData)
    {
      this._textBoxHandle.Text = string.Empty;
      if (visitorData.Handle == null)
        return;
      if (visitorData.Handle.Job != null)
      {
        this._textBoxHandle.Text = visitorData.Handle.Job.Name;
      }
      else
      {
        if (visitorData.Handle.Title == null)
          return;
        if (visitorData.ProfileSex == (byte) 0)
        {
          this._textBoxHandle.Text = visitorData.Handle.Title.MaleTitleName;
        }
        else
        {
          if (visitorData.ProfileSex != (byte) 1)
            return;
          this._textBoxHandle.Text = visitorData.Handle.Title.LadyTitleName;
        }
      }
    }

    private void _groupBox_Profile_Paint(object sender, PaintEventArgs e)
    {
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        e.Graphics.DrawString("Birthday", this.Font, brush, 21f, 17f);
        e.Graphics.DrawString("Y", this.Font, brush, new PointF(125f, 17f));
        e.Graphics.DrawString("M", this.Font, brush, new PointF(196f, 16f));
        e.Graphics.DrawString("D", this.Font, brush, new PointF(268f, 16f));
        e.Graphics.DrawString("Gender", this.Font, brush, new PointF(138f, 44f));
        e.Graphics.DrawString("Speech Style", this.Font, brush, new PointF(11f, 70f));
        e.Graphics.DrawString("Location", this.Font, brush, new PointF(32f, 94f));
        e.Graphics.DrawString("Title", this.Font, brush, new PointF(52f, 118f));
        e.Graphics.DrawString("Greeting", this.Font, brush, new PointF(17f, 142f));
      }
    }

    private void _groupBox_Figure_Paint(object sender, PaintEventArgs e)
    {
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        e.Graphics.DrawString("Body (W)", this.Font, brush, 21f, 19f);
        e.Graphics.DrawString("Body (H)", this.Font, brush, 23f, 40f);
        e.Graphics.DrawString("Hair Style", this.Font, brush, 18f, 61f);
        e.Graphics.DrawString("Hair Color", this.Font, brush, 16f, 82f);
        e.Graphics.DrawString("Face", this.Font, brush, 42f, 103f);
        e.Graphics.DrawString("Skin Color", this.Font, brush, 15f, 124f);
        e.Graphics.DrawString("Eye Color", this.Font, brush, 18f, 145f);
        e.Graphics.DrawString("(0-7)", this.Font, brush, 129f, 124f);
        e.Graphics.DrawString("(0-15)", this.Font, brush, 129f, 145f);
      }
    }

    private void _groupBox_Equipment_Paint(object sender, PaintEventArgs e)
    {
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        e.Graphics.DrawString("Weapon", this.Font, brush, 15f, 19f);
        e.Graphics.DrawString("Shield", this.Font, brush, 24f, 39f);
        e.Graphics.DrawString("Head", this.Font, brush, 29f, 59f);
        e.Graphics.DrawString("Torso", this.Font, brush, 26f, 79f);
        e.Graphics.DrawString("Arms", this.Font, brush, 30f, 99f);
        e.Graphics.DrawString("Legs", this.Font, brush, 32f, 119f);
        e.Graphics.DrawString("Feet", this.Font, brush, 33f, 139f);
        e.Graphics.DrawString("Accessory", this.Font, brush, 3f, 159f);
      }
    }

    private void _groupBox_CompRate_Paint(object sender, PaintEventArgs e)
    {
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        e.Graphics.DrawString("Defeated Monsters", this.Font, brush, 12f, 18f);
        e.Graphics.DrawString("Wardrobe", this.Font, brush, 197f, 18f);
        e.Graphics.DrawString("Item List", this.Font, brush, 62f, 40f);
        e.Graphics.DrawString("Alchenomicon", this.Font, brush, 175f, 40f);
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        if (this.DesignMode || SaveDataManager.Instance.SaveData == null)
          return;
        int num = (int) SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorCount.Value;
        e.Graphics.DrawString(string.Format("({0} / 30)", (object) num), this.Font, brush, new PointF(16f, 274f));
      }
    }

    private void _panelVisitorEditArea_Paint(object sender, PaintEventArgs e)
    {
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        e.Graphics.DrawString("Lodging Date", this.Font, brush, 7f, 16f);
        e.Graphics.DrawString("Y", this.Font, brush, 129f, 16f);
        e.Graphics.DrawString("M", this.Font, brush, 187f, 16f);
        e.Graphics.DrawString("D", this.Font, brush, 245f, 16f);
        e.Graphics.DrawString("Location", this.Font, brush, 270f, 16f);
        e.Graphics.DrawString("SEQ", this.Font, brush, 433f, 16f);
        e.Graphics.DrawString("UID", this.Font, brush, 571f, 16f);
        e.Graphics.DrawString("Name", this.Font, brush, 43f, 41f);
        e.Graphics.DrawString("Color", this.Font, brush, 151f, 41f);
        e.Graphics.DrawString("Vocation", this.Font, brush, 269f, 41f);
        e.Graphics.DrawString("Level", this.Font, brush, 421f, 41f);
        e.Graphics.DrawString("Revocations", this.Font, brush, 508f, 41f);
        e.Graphics.DrawString("Play time", this.Font, brush, 60f, 74f);
        e.Graphics.DrawString("hours", this.Font, brush, 163f, 74f);
        e.Graphics.DrawString("min", this.Font, brush, 248f, 74f);
        e.Graphics.DrawString("Multiplayer time", this.Font, brush, 27f, 99f);
        e.Graphics.DrawString("hours", this.Font, brush, 163f, 99f);
        e.Graphics.DrawString("min", this.Font, brush, 248f, 99f);
        e.Graphics.DrawString("Battle Victories", this.Font, brush, 30f, 135f);
        e.Graphics.DrawString("Alchemy Performed", this.Font, brush, 163f, 135f);
        e.Graphics.DrawString("Accolades Earnt", this.Font, brush, 23f, 156f);
        e.Graphics.DrawString("Quests Completed", this.Font, brush, 168f, 156f);
        e.Graphics.DrawString("Grottoes Completed", this.Font, brush, 6f, 177f);
        e.Graphics.DrawString("Guests Canvassed", this.Font, brush, 165f, 177f);
      }
    }

    private void ButtonSelect_Click(object sender, EventArgs e)
    {
      if (!(sender is VisionButton visionButton))
        return;
      ItemType itemType = (ItemType) ((int) visionButton.Tag + 2);
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(itemType))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this._groupBox_Equipment.Right, this._groupBox_Equipment.Top + visionButton.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        ItemDataBase selectedItem = itemSelectWindow.SelectedItem;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[this._selectedIndex].SetEquipment(itemType, selectedItem);
        this.OnValueUpdate();
      }
    }

    private void ButtonPreset_Click(object sender, EventArgs e)
    {
      if (!(sender is VisionButton visionButton))
        return;
      ListType tag = (ListType) visionButton.Tag;
      using (PresetWindow presetWindow = new PresetWindow(tag))
      {
        presetWindow.Location = this.PointToScreen(new Point(this._groupBox_Figure.Right, this._groupBox_Figure.Top + visionButton.Bottom));
        if (presetWindow.ShowDialog() != DialogResult.OK)
          return;
        Preset selectedPreset1 = presetWindow.SelectedPreset as Preset;
        VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        switch (tag)
        {
          case ListType.Figure:
            if (!(presetWindow.SelectedPreset is PresetFigure selectedPreset2))
              break;
            SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
            visitorManager.VisitorData[this._selectedIndex].FigureWidth.Value = selectedPreset2.Width;
            visitorManager.VisitorData[this._selectedIndex].FigureHeight.Value = selectedPreset2.Height;
            SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
            this.OnValueUpdate();
            break;
          case ListType.HairType:
            if (selectedPreset1 == null)
              break;
            visitorManager.VisitorData[this._selectedIndex].HairType.Value = selectedPreset1.Index;
            this.OnValueUpdate();
            break;
          case ListType.HairColor:
            if (selectedPreset1 == null)
              break;
            visitorManager.VisitorData[this._selectedIndex].HairColor.Value = selectedPreset1.Index;
            this.OnValueUpdate();
            break;
          case ListType.FaceType:
            if (selectedPreset1 == null)
              break;
            visitorManager.VisitorData[this._selectedIndex].FaceType.Value = selectedPreset1.Index;
            this.OnValueUpdate();
            break;
        }
      }
    }
  }
}
