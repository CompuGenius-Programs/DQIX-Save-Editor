// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.StayingListGroupBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using FriedGinger.DQCheat;
using JS_Framework.Controls;

namespace DQ9_Cheat.Controls;

public class StayingListGroupBox : JS_GroupBox
{
    private readonly Button _button_CreateMap;
    private readonly Button _button_DeleteMap;
    private readonly VisionButton[] _buttonPreset = new VisionButton[4];
    private readonly VisionButton[] _buttonSelect = new VisionButton[8];
    private readonly VisionButton _buttonSelectAddress;
    private readonly VisionButton _buttonSelectHandle;
    private readonly CheckBox _checkBox_Hex;
    private readonly CheckBox _checkBox_OpenProbability1;
    private readonly CheckBox _checkBox_OpenProbability2;
    private readonly CheckBox _checkBox_OpenProbability3;
    private readonly CheckBox _checkBox_PlaceHex;
    private readonly CheckBox _checkBoxSecretAge;
    private readonly ComboBox _comboBox_Devil;
    private readonly ComboBox _comboBox_State;
    private readonly VisionComboBox _comboBoxColor;
    private readonly VisionComboBox _comboBoxJob;
    private readonly VisionComboBox _comboBoxPlace;
    private readonly VisionComboBox _comboBoxSex;
    private JS_GroupBox _groupBox_CompRate;
    private JS_GroupBox _groupBox_Equipment;
    private JS_GroupBox _groupBox_Figure;
    private readonly JS_GroupBox _groupBox_Probability;
    private JS_GroupBox _groupBox_Profile;
    private readonly JS_GroupBox _groupBox_TreasureMap;
    private readonly SafeNumericUpDown _numericUpDown_DevilLevel;
    private readonly SafeNumericUpDown _numericUpDown_DevilVictoryTurn;
    private readonly SafeNumericUpDown _numericUpDown_MapNo1;
    private readonly SafeNumericUpDown _numericUpDown_MapNo2;
    private readonly SafeNumericUpDown _numericUpDown_Place;
    private readonly VisionNumericUpDown _numericUpDownAlchemyCompRate;
    private readonly VisionNumericUpDown _numericUpDownAlchemyCount;
    private readonly VisionNumericUpDown _numericUpDownBirthDayDay;
    private readonly VisionNumericUpDown _numericUpDownBirthDayMonth;
    private readonly VisionNumericUpDown _numericUpDownBirthDayYear;
    private readonly VisionNumericUpDown _numericUpDownEyeColor;
    private readonly VisionNumericUpDown _numericUpDownFaceType;
    private readonly VisionNumericUpDown _numericUpDownFashionCompRate;
    private readonly VisionNumericUpDown _numericUpDownFigureHeight;
    private readonly VisionNumericUpDown _numericUpDownFigureWidth;
    private readonly VisionNumericUpDown _numericUpDownHairColor;
    private readonly VisionNumericUpDown _numericUpDownHairType;
    private readonly VisionNumericUpDown _numericUpDownItemCompRate;
    private readonly VisionNumericUpDown _numericUpDownLodgingDay;
    private readonly VisionNumericUpDown _numericUpDownLodgingMonth;
    private readonly VisionNumericUpDown _numericUpDownLodgingYear;
    private readonly VisionNumericUpDown _numericUpDownLV;
    private readonly VisionNumericUpDown _numericUpDownMonsterCompRate;
    private readonly VisionNumericUpDown _numericUpDownMultiPlayTimeHour;
    private readonly VisionNumericUpDown _numericUpDownMultiPlayTimeMinute;
    private readonly VisionNumericUpDown _numericUpDownPlayTimeHour;
    private readonly VisionNumericUpDown _numericUpDownPlayTimeMinute;
    private readonly VisionNumericUpDown _numericUpDownQuestClearCount;
    private readonly VisionNumericUpDown _numericUpDownSEQ;
    private readonly VisionNumericUpDown _numericUpDownSkinColor;
    private readonly VisionNumericUpDown _numericUpDownTitleCount;
    private readonly VisionNumericUpDown _numericUpDownTransmigration;
    private readonly VisionNumericUpDown _numericUpDownTreasureMapCount;
    private readonly VisionNumericUpDown _numericUpDownUID;
    private readonly VisionNumericUpDown _numericUpDownVictoryCount;
    private readonly VisionNumericUpDown _numericUpDownVisitorCount;
    private readonly DoubleBufferedPanel _panel_DevilMap;
    private readonly DoubleBufferedPanel _panel_NormalMap;
    private readonly JS_Panel _panelVisitorEditArea;
    private readonly VisionComboBox _profileTone;
    private readonly RadioButton _radioButton_DevilMap;
    private readonly RadioButton _radioButton_NormalMap;
    private int _selectedIndex = -1;
    private readonly TextBox _textBox_Detector;
    private TextBox _textBox_ProfileMessage;
    private readonly TextBox _textBox_Renewer;
    private readonly VisionTextBox _textBoxAddress;
    private readonly VisionTextBox _textBoxEquipmentAccessory;
    private readonly VisionTextBox _textBoxEquipmentArm;
    private readonly VisionTextBox _textBoxEquipmentHead;
    private readonly VisionTextBox _textBoxEquipmentLowerBody;
    private readonly VisionTextBox _textBoxEquipmentShield;
    private readonly VisionTextBox _textBoxEquipmentShoe;
    private readonly VisionTextBox _textBoxEquipmentUpperBody;
    private readonly VisionTextBox _textBoxEquipmentWeapon;
    private readonly VisionTextBox _textBoxHandle;
    private readonly VisionTextBox _textBoxName;
    private int _updateCount;

    public StayingListGroupBox()
    {
        SuspendLayout();
        _panelVisitorEditArea = new JS_Panel();
        _panelVisitorEditArea.Size = Size;
        _panelVisitorEditArea.Location = new Point(105, 0);
        _panelVisitorEditArea.Paint += _panelVisitorEditArea_Paint;
        _panelVisitorEditArea.BackColor = Color.Transparent;
        Controls.Add(_panelVisitorEditArea);
        Controls.SetChildIndex(_panelVisitorEditArea, 0);
        _groupBox_CompRate = new JS_GroupBox();
        _groupBox_CompRate.Location = new Point(5, 200);
        _groupBox_CompRate.Name = nameof(_groupBox_CompRate);
        _groupBox_CompRate.Size = new Size(310, 62);
        _groupBox_CompRate.Text = "Completion Rate";
        _groupBox_CompRate.Paint += _groupBox_CompRate_Paint;
        _groupBox_Equipment = new JS_GroupBox();
        _groupBox_Equipment.Location = new Point(322, 305);
        _groupBox_Equipment.Name = nameof(_groupBox_Equipment);
        _groupBox_Equipment.Size = new Size(222, 182);
        _groupBox_Equipment.Text = "Equipment";
        _groupBox_Equipment.Paint += _groupBox_Equipment_Paint;
        _groupBox_Figure = new JS_GroupBox();
        _groupBox_Figure.Location = new Point(550, 305);
        _groupBox_Figure.Name = nameof(_groupBox_Figure);
        _groupBox_Figure.Size = new Size(199, 166);
        _groupBox_Figure.Text = "Appearance";
        _groupBox_Figure.Paint += _groupBox_Figure_Paint;
        _groupBox_Profile = new JS_GroupBox();
        _groupBox_Profile.Location = new Point(5, 275);
        _groupBox_Profile.Name = nameof(_groupBox_Profile);
        _groupBox_Profile.Size = new Size(310, 212);
        _groupBox_Profile.Text = "Profile";
        _groupBox_Profile.Paint += _groupBox_Profile_Paint;
        _panelVisitorEditArea.Controls.Add(_groupBox_Profile);
        _panelVisitorEditArea.Controls.Add(_groupBox_Equipment);
        _panelVisitorEditArea.Controls.Add(_groupBox_Figure);
        _panelVisitorEditArea.Controls.Add(_groupBox_CompRate);
        _numericUpDownLodgingYear = new VisionNumericUpDown(78, 14, 49, 20);
        _numericUpDownLodgingYear.Minimum = 2000M;
        _numericUpDownLodgingYear.Maximum = 2127M;
        _numericUpDownLodgingYear.ValueChanged += _numericUpDownLodgingYear_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownLodgingYear);
        _numericUpDownLodgingMonth = new VisionNumericUpDown(148, 14, 37, 20);
        _numericUpDownLodgingMonth.Minimum = 0M;
        _numericUpDownLodgingMonth.Maximum = 15M;
        _numericUpDownLodgingMonth.ValueChanged += _numericUpDownLodgingMonth_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownLodgingMonth);
        _numericUpDownLodgingDay = new VisionNumericUpDown(206, 14, 37, 20);
        _numericUpDownLodgingDay.Minimum = 0M;
        _numericUpDownLodgingDay.Maximum = 31M;
        _numericUpDownLodgingDay.ValueChanged += _numericUpDownLodgingDay_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownLodgingDay);
        _comboBoxPlace = new VisionComboBox(321, 13, 103, 20);
        _comboBoxPlace.Items.AddRange(new string[8]
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
        _comboBoxPlace.SelectedIndexChanged += _comboBoxPlace_SelectedIndexChanged;
        _panelVisitorEditArea.AddVisionControl(_comboBoxPlace);
        _numericUpDownSEQ = new VisionNumericUpDown(462, 13, 100, 20);
        _numericUpDownSEQ.Minimum = 1M;
        _numericUpDownSEQ.Maximum = 1073741823M;
        _numericUpDownSEQ.ValueChanged += _numericUpDownSEQ_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownSEQ);
        _numericUpDownUID = new VisionNumericUpDown(596, 13, 110, 20);
        _numericUpDownUID.Minimum = 1M;
        _numericUpDownUID.Maximum = 281474976710655M;
        _numericUpDownUID.Hexadecimal = true;
        _numericUpDownUID.ValueChanged += _numericUpDownUID_ValueChanged;
        _numericUpDownUID.Leave += _numericUpDownUID_Leave;
        _numericUpDownUID.Enter += _numericUpDownUID_Enter;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownUID);
        _textBoxName = new VisionTextBox(78, 38, 67, 21);
        _textBoxName.TextChanged += _textBoxName_TextChanged;
        _panelVisitorEditArea.AddVisionControl(_textBoxName);
        _comboBoxColor = new VisionComboBox(183, 38, 77, 21);
        _comboBoxColor.Items.AddRange(new string[16]
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
        _comboBoxColor.SelectedIndexChanged += _comboBoxColor_SelectedIndexChanged;
        _panelVisitorEditArea.AddVisionControl(_comboBoxColor);
        _comboBoxJob = new VisionComboBox(321, 38, 88, 20);
        foreach (var jobData in JobDataList.List)
            if (jobData.DataIndex == 0)
                _comboBoxJob.Items.Add("None");
            else
                _comboBoxJob.Items.Add(jobData.Name);
        _comboBoxJob.SelectedIndexChanged += _comboBoxJob_SelectedIndexChanged;
        _panelVisitorEditArea.AddVisionControl(_comboBoxJob);
        _numericUpDownLV = new VisionNumericUpDown(454, 39, 43, 20);
        _numericUpDownLV.ValueChanged += _numericUpDownLV_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownLV);
        _numericUpDownTransmigration = new VisionNumericUpDown(575, 39, 43, 20);
        _numericUpDownTransmigration.ValueChanged += _numericUpDownTransmigration_ValueChanged;
        _numericUpDownTransmigration.Minimum = 0M;
        _numericUpDownTransmigration.Maximum = 15M;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownTransmigration);
        _numericUpDownPlayTimeHour = new VisionNumericUpDown(112, 72, 49, 20);
        _numericUpDownPlayTimeHour.Minimum = 0M;
        _numericUpDownPlayTimeHour.Maximum = 16383M;
        _numericUpDownPlayTimeHour.ValueChanged += _numericUpDownPlayTimeHour_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownPlayTimeHour);
        _numericUpDownPlayTimeMinute = new VisionNumericUpDown(197, 72, 49, 20);
        _numericUpDownPlayTimeMinute.Minimum = 0M;
        _numericUpDownPlayTimeMinute.Maximum = 59M;
        _numericUpDownPlayTimeMinute.ValueChanged += _numericUpDownPlayTimeMinute_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownPlayTimeMinute);
        _numericUpDownMultiPlayTimeHour = new VisionNumericUpDown(112, 97, 49, 20);
        _numericUpDownMultiPlayTimeHour.Minimum = 0M;
        _numericUpDownMultiPlayTimeHour.Maximum = 16383M;
        _numericUpDownMultiPlayTimeHour.ValueChanged += _numericUpDownMultiPlayTimeHour_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownMultiPlayTimeHour);
        _numericUpDownMultiPlayTimeMinute = new VisionNumericUpDown(197, 97, 49, 20);
        _numericUpDownMultiPlayTimeMinute.Minimum = 0M;
        _numericUpDownMultiPlayTimeMinute.Maximum = 59M;
        _numericUpDownMultiPlayTimeMinute.ValueChanged += _numericUpDownMultiPlayTimeMinute_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownMultiPlayTimeMinute);
        _numericUpDownVictoryCount = new VisionNumericUpDown(112, 133, 49, 20);
        _numericUpDownVictoryCount.Minimum = 0M;
        _numericUpDownVictoryCount.Maximum = 65535M;
        _numericUpDownVictoryCount.ValueChanged += _numericUpDownVictoryCount_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownVictoryCount);
        _numericUpDownAlchemyCount = new VisionNumericUpDown(266, 133, 49, 20);
        _numericUpDownAlchemyCount.Maximum = 65535M;
        _numericUpDownAlchemyCount.Minimum = 0M;
        _numericUpDownAlchemyCount.ValueChanged += _numericUpDownAlchemyCount_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownAlchemyCount);
        _numericUpDownTitleCount = new VisionNumericUpDown(112, 154, 49, 20);
        _numericUpDownTitleCount.Maximum = 1023M;
        _numericUpDownTitleCount.Minimum = 0M;
        _numericUpDownTitleCount.ValueChanged += _numericUpDownTitleCount_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownTitleCount);
        _numericUpDownQuestClearCount = new VisionNumericUpDown(266, 154, 49, 20);
        _numericUpDownQuestClearCount.Maximum = 511M;
        _numericUpDownQuestClearCount.Minimum = 0M;
        _numericUpDownQuestClearCount.ValueChanged += _numericUpDownQuestClearCount_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownQuestClearCount);
        _numericUpDownTreasureMapCount = new VisionNumericUpDown(112, 175, 49, 20);
        _numericUpDownTreasureMapCount.Maximum = 16383M;
        _numericUpDownTreasureMapCount.Minimum = 0M;
        _numericUpDownTreasureMapCount.ValueChanged += _numericUpDownTreasureMapCount_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownTreasureMapCount);
        _numericUpDownVisitorCount = new VisionNumericUpDown(266, 175, 49, 20);
        _numericUpDownVisitorCount.Maximum = 16383M;
        _numericUpDownVisitorCount.Minimum = 0M;
        _numericUpDownVisitorCount.ValueChanged += _numericUpDownVisitorCount_ValueChanged;
        _panelVisitorEditArea.AddVisionControl(_numericUpDownVisitorCount);
        _numericUpDownMonsterCompRate = new VisionNumericUpDown(111, 16, 49, 19);
        _numericUpDownMonsterCompRate.Maximum = 127M;
        _numericUpDownMonsterCompRate.Minimum = 0M;
        _numericUpDownMonsterCompRate.ValueChanged += _numericUpDownMonsterCompRate_ValueChanged;
        _groupBox_CompRate.AddVisionControl(_numericUpDownMonsterCompRate);
        _numericUpDownFashionCompRate = new VisionNumericUpDown(251, 16, 49, 19);
        _numericUpDownFashionCompRate.Maximum = 127M;
        _numericUpDownFashionCompRate.Minimum = 0M;
        _numericUpDownFashionCompRate.ValueChanged += _numericUpDownFashionCompRate_ValueChanged;
        _groupBox_CompRate.AddVisionControl(_numericUpDownFashionCompRate);
        _numericUpDownItemCompRate = new VisionNumericUpDown(111, 37, 49, 19);
        _numericUpDownItemCompRate.Maximum = 127M;
        _numericUpDownItemCompRate.Minimum = 0M;
        _numericUpDownItemCompRate.ValueChanged += _numericUpDownItemCompRate_ValueChanged;
        _groupBox_CompRate.AddVisionControl(_numericUpDownItemCompRate);
        _numericUpDownAlchemyCompRate = new VisionNumericUpDown(251, 37, 49, 19);
        _numericUpDownAlchemyCompRate.Maximum = 127M;
        _numericUpDownAlchemyCompRate.Minimum = 0M;
        _numericUpDownAlchemyCompRate.ValueChanged += _numericUpDownAlchemyCompRate_ValueChanged;
        _groupBox_CompRate.AddVisionControl(_numericUpDownAlchemyCompRate);
        var num1 = 15;
        for (var index = 0; index < 4; ++index)
        {
            _buttonPreset[index] = new VisionButton(129, num1 += 21, 60, 19);
            _buttonPreset[index].Text = "Preset";
            _buttonPreset[index].Tag = index;
            _buttonPreset[index].Click += ButtonPreset_Click;
            _groupBox_Figure.AddVisionControl(_buttonPreset[index]);
        }

        _numericUpDownFigureWidth = new VisionNumericUpDown(73, 16, 49, 19);
        _numericUpDownFigureWidth.Maximum = 65535M;
        _numericUpDownFigureWidth.Minimum = 0M;
        _numericUpDownFigureWidth.ValueChanged += _numericUpDownFigureWidth_ValueChanged;
        _groupBox_Figure.AddVisionControl(_numericUpDownFigureWidth);
        _numericUpDownFigureHeight = new VisionNumericUpDown(73, 37, 49, 19);
        _numericUpDownFigureHeight.Maximum = 65535M;
        _numericUpDownFigureHeight.Minimum = 0M;
        _numericUpDownFigureHeight.ValueChanged += _numericUpDownFigureHeight_ValueChanged;
        _groupBox_Figure.AddVisionControl(_numericUpDownFigureHeight);
        _numericUpDownHairType = new VisionNumericUpDown(73, 58, 49, 19);
        _numericUpDownHairType.Maximum = 255M;
        _numericUpDownHairType.Minimum = 0M;
        _numericUpDownHairType.ValueChanged += _numericUpDownHairType_ValueChanged;
        _groupBox_Figure.AddVisionControl(_numericUpDownHairType);
        _numericUpDownHairColor = new VisionNumericUpDown(73, 79, 49, 19);
        _numericUpDownHairColor.Maximum = 255M;
        _numericUpDownHairColor.Minimum = 0M;
        _numericUpDownHairColor.ValueChanged += _numericUpDownHairColor_ValueChanged;
        _groupBox_Figure.AddVisionControl(_numericUpDownHairColor);
        _numericUpDownFaceType = new VisionNumericUpDown(73, 100, 49, 19);
        _numericUpDownFaceType.Maximum = 255M;
        _numericUpDownFaceType.Minimum = 0M;
        _numericUpDownFaceType.ValueChanged += _numericUpDownFaceType_ValueChanged;
        _groupBox_Figure.AddVisionControl(_numericUpDownFaceType);
        _numericUpDownSkinColor = new VisionNumericUpDown(73, 121, 49, 19);
        _numericUpDownSkinColor.Maximum = 7M;
        _numericUpDownSkinColor.Minimum = 0M;
        _numericUpDownSkinColor.ValueChanged += _numericUpDownSkinColor_ValueChanged;
        _groupBox_Figure.AddVisionControl(_numericUpDownSkinColor);
        _numericUpDownEyeColor = new VisionNumericUpDown(73, 142, 49, 19);
        _numericUpDownEyeColor.Maximum = 15M;
        _numericUpDownEyeColor.Minimum = 0M;
        _numericUpDownEyeColor.ValueChanged += _numericUpDownEyeColor_ValueChanged;
        _groupBox_Figure.AddVisionControl(_numericUpDownEyeColor);
        var num2 = -5;
        for (var index = 0; index < 8; ++index)
        {
            _buttonSelect[index] = new VisionButton(177, num2 += 20, 39, 19);
            _buttonSelect[index].Text = "Set";
            _buttonSelect[index].Tag = index;
            _buttonSelect[index].Click += ButtonSelect_Click;
            _groupBox_Equipment.AddVisionControl(_buttonSelect[index]);
        }

        _textBoxEquipmentWeapon = new VisionTextBox(62, 15, 113, 19);
        _textBoxEquipmentWeapon.ReadOnly = true;
        _groupBox_Equipment.AddVisionControl(_textBoxEquipmentWeapon);
        _textBoxEquipmentShield = new VisionTextBox(62, 35, 113, 19);
        _textBoxEquipmentShield.ReadOnly = true;
        _groupBox_Equipment.AddVisionControl(_textBoxEquipmentShield);
        _textBoxEquipmentHead = new VisionTextBox(62, 55, 113, 19);
        _textBoxEquipmentHead.ReadOnly = true;
        _groupBox_Equipment.AddVisionControl(_textBoxEquipmentHead);
        _textBoxEquipmentUpperBody = new VisionTextBox(62, 75, 113, 19);
        _textBoxEquipmentUpperBody.ReadOnly = true;
        _groupBox_Equipment.AddVisionControl(_textBoxEquipmentUpperBody);
        _textBoxEquipmentArm = new VisionTextBox(62, 95, 113, 19);
        _textBoxEquipmentArm.ReadOnly = true;
        _groupBox_Equipment.AddVisionControl(_textBoxEquipmentArm);
        _textBoxEquipmentLowerBody = new VisionTextBox(62, 115, 113, 19);
        _textBoxEquipmentLowerBody.ReadOnly = true;
        _groupBox_Equipment.AddVisionControl(_textBoxEquipmentLowerBody);
        _textBoxEquipmentShoe = new VisionTextBox(62, 135, 113, 19);
        _textBoxEquipmentShoe.ReadOnly = true;
        _groupBox_Equipment.AddVisionControl(_textBoxEquipmentShoe);
        _textBoxEquipmentAccessory = new VisionTextBox(62, 155, 113, 19);
        _textBoxEquipmentAccessory.ReadOnly = true;
        _groupBox_Equipment.AddVisionControl(_textBoxEquipmentAccessory);
        _numericUpDownBirthDayYear = new VisionNumericUpDown(68, 15, 56, 19);
        _numericUpDownBirthDayYear.Maximum = 4096M;
        _numericUpDownBirthDayYear.Minimum = 0M;
        _numericUpDownBirthDayYear.ValueChanged += _numericUpDownBirthDayYear_ValueChanged;
        _groupBox_Profile.AddVisionControl(_numericUpDownBirthDayYear);
        _numericUpDownBirthDayMonth = new VisionNumericUpDown(148, 15, 47, 19);
        _numericUpDownBirthDayMonth.Maximum = 12M;
        _numericUpDownBirthDayMonth.Minimum = 1M;
        _numericUpDownBirthDayMonth.ValueChanged += _numericUpDownBirthDayMonth_ValueChanged;
        _groupBox_Profile.AddVisionControl(_numericUpDownBirthDayMonth);
        _numericUpDownBirthDayDay = new VisionNumericUpDown(220, 15, 47, 19);
        _numericUpDownBirthDayDay.Maximum = 31M;
        _numericUpDownBirthDayDay.Minimum = 1M;
        _numericUpDownBirthDayDay.ValueChanged += _numericUpDownBirthDayDay_ValueChanged;
        _groupBox_Profile.AddVisionControl(_numericUpDownBirthDayDay);
        _comboBoxSex = new VisionComboBox(180, 40, 64, 20);
        _comboBoxSex.Items.AddRange(new string[2]
        {
            "Male",
            "Female"
        });
        _comboBoxSex.SelectedIndexChanged += _comboBoxSex_SelectedIndexChanged;
        _groupBox_Profile.AddVisionControl(_comboBoxSex);
        _profileTone = new VisionComboBox(80, 65, 121, 20);
        _profileTone.Items.AddRange(new object[16]
        {
            "Chirpy Boy",
            "Cute Girl",
            "Timid Boy",
            "Shy Girl",
            "Serious Man",
            "Prim Woman",
            "Macho Man",
            "Temptress",
            "Smarmy Guy",
            "Grumpy Woman",
            "Demon King",
            (object)"Witch",
            (object)"Nice Old Man",
            (object)"Kind Old Woman",
            (object)"Doddery Old Man",
            (object)"Bored Teenager"
        });
        _profileTone.SelectedIndexChanged += _profileTone_SelectedIndexChanged;
        _groupBox_Profile.AddVisionControl(_profileTone);
        _textBoxAddress = new VisionTextBox(80, 90, 120, 20);
        _textBoxAddress.ReadOnly = true;
        _groupBox_Profile.AddVisionControl(_textBoxAddress);
        _buttonSelectAddress = new VisionButton(205, 90, 39, 19);
        _buttonSelectAddress.Text = "Set";
        _buttonSelectAddress.Click += _buttonSelectAddress_Click;
        _groupBox_Profile.AddVisionControl(_buttonSelectAddress);
        _textBoxHandle = new VisionTextBox(80, 114, 120, 20);
        _textBoxHandle.ReadOnly = true;
        _groupBox_Profile.AddVisionControl(_textBoxHandle);
        _buttonSelectHandle = new VisionButton(205, 114, 39, 19);
        _buttonSelectHandle.Text = "Set";
        _buttonSelectHandle.Click += _buttonSelectHandle_Click;
        _groupBox_Profile.AddVisionControl(_buttonSelectHandle);
        _checkBoxSecretAge = new CheckBox();
        _checkBoxSecretAge.AutoSize = true;
        _checkBoxSecretAge.Location = new Point(19, 43);
        _checkBoxSecretAge.Name = "_checkBox_SecretAge";
        _checkBoxSecretAge.Size = new Size(109, 16);
        _checkBoxSecretAge.Text = "Age is Secret?";
        _checkBoxSecretAge.UseVisualStyleBackColor = true;
        _checkBoxSecretAge.CheckedChanged += _checkBoxSecretAge_CheckedChanged;
        _groupBox_Profile.Controls.Add(_checkBoxSecretAge);
        _textBox_ProfileMessage = new TextBox();
        _textBox_ProfileMessage.AcceptsReturn = true;
        _textBox_ProfileMessage.Location = new Point(19, 157);
        _textBox_ProfileMessage.MaxLength = 100;
        _textBox_ProfileMessage.Multiline = true;
        _textBox_ProfileMessage.Name = nameof(_textBox_ProfileMessage);
        _textBox_ProfileMessage.Size = new Size(272, 45);
        _textBox_ProfileMessage.TextChanged += _textBox_ProfileMessage_TextChanged;
        _groupBox_Profile.Controls.Add(_textBox_ProfileMessage);
        _groupBox_TreasureMap = new JS_GroupBox();
        _groupBox_TreasureMap.Text = "Treasure Map";
        _groupBox_TreasureMap.Size = new Size(420, 231);
        _groupBox_TreasureMap.Location = new Point(322, 65);
        _groupBox_TreasureMap.Paint += _groupBox_TreasureMap_Paint;
        _panelVisitorEditArea.Controls.Add(_groupBox_TreasureMap);
        _comboBox_State = new ComboBox();
        _comboBox_State.DropDownStyle = ComboBoxStyle.DropDownList;
        _comboBox_State.FormattingEnabled = true;
        _comboBox_State.Items.AddRange(new object[3]
        {
            "Not Found",
            "Discovered",
            "Clear"
        });
        _comboBox_State.Location = new Point(248, 38);
        _comboBox_State.Size = new Size(90, 21);
        _comboBox_State.SelectedIndexChanged += _comboBox_State_SelectedIndexChanged;
        _groupBox_TreasureMap.Controls.Add(_comboBox_State);
        _radioButton_DevilMap = new RadioButton();
        _radioButton_DevilMap.AutoSize = true;
        _radioButton_DevilMap.Location = new Point(102, 18);
        _radioButton_DevilMap.Size = new Size(81, 16);
        _radioButton_DevilMap.Tag = MapType.devil;
        _radioButton_DevilMap.Text = "Legacy Boss";
        _radioButton_DevilMap.UseVisualStyleBackColor = true;
        _radioButton_DevilMap.CheckedChanged += radioButton_MapType_CheckedChanged;
        _groupBox_TreasureMap.Controls.Add(_radioButton_DevilMap);
        _radioButton_NormalMap = new RadioButton();
        _radioButton_NormalMap.AutoSize = true;
        _radioButton_NormalMap.Location = new Point(20, 18);
        _radioButton_NormalMap.Size = new Size(71, 16);
        _radioButton_NormalMap.Tag = MapType.Normal;
        _radioButton_NormalMap.Text = "Normal Map";
        _radioButton_NormalMap.UseVisualStyleBackColor = true;
        _radioButton_NormalMap.CheckedChanged += radioButton_MapType_CheckedChanged;
        _groupBox_TreasureMap.Controls.Add(_radioButton_NormalMap);
        _numericUpDown_MapNo2 = new SafeNumericUpDown();
        _numericUpDown_MapNo2.Location = new Point(111, 10);
        _numericUpDown_MapNo2.Maximum = 65535M;
        _numericUpDown_MapNo2.Size = new Size(74, 19);
        _numericUpDown_MapNo2.ValueChanged += _numericUpDown_MapNo2_ValueChanged;
        _numericUpDown_MapNo1 = new SafeNumericUpDown();
        _numericUpDown_MapNo1.Location = new Point(54, 10);
        _numericUpDown_MapNo1.Maximum = 255M;
        _numericUpDown_MapNo1.Size = new Size(51, 19);
        _numericUpDown_MapNo1.ValueChanged += _numericUpDown_MapNo1_ValueChanged;
        _checkBox_Hex = new CheckBox();
        _checkBox_Hex.Location = new Point(190, 12);
        _checkBox_Hex.AutoSize = true;
        _checkBox_Hex.Text = "Hex";
        _checkBox_Hex.CheckedChanged += _checkBox_Hex_CheckedChanged;
        _checkBox_PlaceHex = new CheckBox();
        _checkBox_PlaceHex.Location = new Point(305, 63);
        _checkBox_PlaceHex.AutoSize = true;
        _checkBox_PlaceHex.Text = "Hex";
        _checkBox_PlaceHex.CheckedChanged += _checkBox_PlaceHex_CheckedChanged;
        _groupBox_TreasureMap.Controls.Add(_checkBox_PlaceHex);
        _numericUpDown_Place = new SafeNumericUpDown();
        _numericUpDown_Place.Location = new Point(248, 61);
        _numericUpDown_Place.Maximum = 255M;
        _numericUpDown_Place.Size = new Size(51, 20);
        _numericUpDown_Place.ValueChanged += _numericUpDown_Place_ValueChanged;
        _groupBox_TreasureMap.Controls.Add(_numericUpDown_Place);
        _comboBox_Devil = new ComboBox();
        _comboBox_Devil.DropDownStyle = ComboBoxStyle.DropDownList;
        _comboBox_Devil.FormattingEnabled = true;
        _comboBox_Devil.Location = new Point(54, 10);
        _comboBox_Devil.Size = new Size(121, 20);
        _comboBox_Devil.SelectedIndexChanged += _comboBox_Devil_SelectedIndexChanged;
        foreach (object obj in DevilList.List)
            _comboBox_Devil.Items.Add(obj);
        _textBox_Renewer = new TextBox();
        _textBox_Renewer.Location = new Point(97, 61);
        _textBox_Renewer.Name = "textBox_Renewer";
        _textBox_Renewer.Size = new Size(90, 20);
        _textBox_Renewer.TextChanged += _textBox_Renewer_TextChanged;
        _groupBox_TreasureMap.Controls.Add(_textBox_Renewer);
        _textBox_Detector = new TextBox();
        _textBox_Detector.Location = new Point(97, 38);
        _textBox_Detector.Name = "textBox_Detector";
        _textBox_Detector.Size = new Size(90, 20);
        _textBox_Detector.TabIndex = 6;
        _textBox_Detector.TextChanged += _textBox_Detector_TextChanged;
        _groupBox_TreasureMap.Controls.Add(_textBox_Detector);
        _numericUpDown_DevilVictoryTurn = new SafeNumericUpDown();
        _numericUpDown_DevilVictoryTurn.Location = new Point(126, 56);
        _numericUpDown_DevilVictoryTurn.Location = new Point(126, 56);
        _numericUpDown_DevilVictoryTurn.Maximum = 999M;
        _numericUpDown_DevilVictoryTurn.Size = new Size(49, 19);
        _numericUpDown_DevilVictoryTurn.ValueChanged += _numericUpDown_DevilVictoryTurn_ValueChanged;
        _numericUpDown_DevilLevel = new SafeNumericUpDown();
        _numericUpDown_DevilLevel.Location = new Point(126, 34);
        _numericUpDown_DevilLevel.Maximum = 255M;
        _numericUpDown_DevilLevel.Size = new Size(49, 19);
        _numericUpDown_DevilLevel.ValueChanged += _numericUpDown_DevilLevel_ValueChanged;
        _panel_DevilMap = new DoubleBufferedPanel();
        _panel_DevilMap.Controls.Add(_numericUpDown_DevilVictoryTurn);
        _panel_DevilMap.Controls.Add(_numericUpDown_DevilLevel);
        _panel_DevilMap.Controls.Add(_comboBox_Devil);
        _panel_DevilMap.Location = new Point(12, 141);
        _panel_DevilMap.Size = new Size(233, 80);
        _panel_DevilMap.Paint += _panel_DevilMap_Paint;
        _groupBox_TreasureMap.Controls.Add(_panel_DevilMap);
        _panel_NormalMap = new DoubleBufferedPanel();
        _panel_NormalMap.Controls.Add(_numericUpDown_MapNo2);
        _panel_NormalMap.Controls.Add(_numericUpDown_MapNo1);
        _panel_NormalMap.Controls.Add(_checkBox_Hex);
        _panel_NormalMap.Location = new Point(12, 141);
        _panel_NormalMap.Size = new Size(233, 60);
        _panel_NormalMap.Paint += _panel_NormalMap_Paint;
        _groupBox_TreasureMap.Controls.Add(_panel_NormalMap);
        _checkBox_OpenProbability3 = new CheckBox();
        _checkBox_OpenProbability3.AutoSize = true;
        _checkBox_OpenProbability3.Location = new Point(153, 18);
        _checkBox_OpenProbability3.Size = new Size(57, 16);
        _checkBox_OpenProbability3.Tag = 2;
        _checkBox_OpenProbability3.Text = "Third";
        _checkBox_OpenProbability3.UseVisualStyleBackColor = true;
        _checkBox_OpenProbability3.CheckedChanged += _checkBox_OpenProbability_CheckedChanged;
        _checkBox_OpenProbability2 = new CheckBox();
        _checkBox_OpenProbability2.AutoSize = true;
        _checkBox_OpenProbability2.Location = new Point(90, 18);
        _checkBox_OpenProbability2.Size = new Size(57, 16);
        _checkBox_OpenProbability2.Tag = 1;
        _checkBox_OpenProbability2.Text = "Second";
        _checkBox_OpenProbability2.UseVisualStyleBackColor = true;
        _checkBox_OpenProbability2.CheckedChanged += _checkBox_OpenProbability_CheckedChanged;
        _checkBox_OpenProbability1 = new CheckBox();
        _checkBox_OpenProbability1.AutoSize = true;
        _checkBox_OpenProbability1.Location = new Point(27, 18);
        _checkBox_OpenProbability1.Name = "checkBox_OpenProbability1";
        _checkBox_OpenProbability1.Size = new Size(57, 16);
        _checkBox_OpenProbability1.Tag = 0;
        _checkBox_OpenProbability1.Text = "First";
        _checkBox_OpenProbability1.UseVisualStyleBackColor = true;
        _checkBox_OpenProbability1.CheckedChanged += _checkBox_OpenProbability_CheckedChanged;
        _groupBox_Probability = new JS_GroupBox();
        _groupBox_Probability.Controls.Add(_checkBox_OpenProbability3);
        _groupBox_Probability.Controls.Add(_checkBox_OpenProbability2);
        _groupBox_Probability.Controls.Add(_checkBox_OpenProbability1);
        _groupBox_Probability.Location = new Point(12, 89);
        _groupBox_Probability.Size = new Size(231, 43);
        _groupBox_Probability.Text = "Treasures Plundered";
        _groupBox_TreasureMap.Controls.Add(_groupBox_Probability);
        _button_CreateMap = new Button();
        _button_CreateMap.Text = "Add";
        _button_CreateMap.Location = new Point(545, 260);
        _button_CreateMap.Size = new Size(50, 23);
        _button_CreateMap.Click += _button_CreateMap_Click;
        _panelVisitorEditArea.Controls.Add(_button_CreateMap);
        _panelVisitorEditArea.Controls.SetChildIndex(_button_CreateMap, 0);
        _button_DeleteMap = new Button();
        _button_DeleteMap.Text = "Delete";
        _button_DeleteMap.Location = new Point(600, 260);
        _button_DeleteMap.Size = new Size(50, 23);
        _button_DeleteMap.Click += _button_DeleteMap_Click;
        _panelVisitorEditArea.Controls.Add(_button_DeleteMap);
        _panelVisitorEditArea.Controls.SetChildIndex(_button_DeleteMap, 1);
        _panel_DevilMap.Visible = false;
        _panelVisitorEditArea.Enabled = false;
        ResumeLayout(false);
    }

    private void _button_DeleteMap_Click(object sender, EventArgs e)
    {
        var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        var treasureMapData = visitorManager.VisitorData[_selectedIndex].TreasureMapData;
        if (!visitorManager.VisitorData[_selectedIndex].HaveTreasureMap)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        visitorManager.VisitorData[_selectedIndex].HaveTreasureMap = false;
        treasureMapData.Clear();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        BeginUpdate();
        _panel_DevilMap.Visible = false;
        _panel_NormalMap.Visible = true;
        _radioButton_NormalMap.Checked = true;
        _comboBox_State.SelectedIndex = -1;
        _numericUpDown_MapNo1.Value = 0M;
        _numericUpDown_MapNo2.Value = 0M;
        _numericUpDown_Place.Value = 0M;
        _textBox_Detector.Text = string.Empty;
        _textBox_Renewer.Text = string.Empty;
        _checkBox_OpenProbability1.Checked = false;
        _checkBox_OpenProbability2.Checked = false;
        _checkBox_OpenProbability3.Checked = false;
        _groupBox_TreasureMap.Enabled = false;
        EndUpdate();
        _button_CreateMap.Enabled = true;
        _button_DeleteMap.Enabled = false;
    }

    private void _button_CreateMap_Click(object sender, EventArgs e)
    {
        var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        var treasureMapData = visitorManager.VisitorData[_selectedIndex].TreasureMapData;
        if (visitorManager.VisitorData[_selectedIndex].HaveTreasureMap && treasureMapData.MapType != MapType.Unknown)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        visitorManager.VisitorData[_selectedIndex].HaveTreasureMap = true;
        treasureMapData.MapType = MapType.Normal;
        treasureMapData.Rank = 2;
        treasureMapData.Seed = 1;
        treasureMapData.Place.Value = 0;
        treasureMapData.SetOpenProbability(0, false);
        treasureMapData.SetOpenProbability(1, false);
        treasureMapData.SetOpenProbability(2, false);
        treasureMapData.MapState = MapState.NotDiscover;
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        BeginUpdate();
        _panel_DevilMap.Visible = false;
        _panel_NormalMap.Visible = true;
        _panel_NormalMap.Invalidate();
        _radioButton_NormalMap.Checked = true;
        _comboBox_State.SelectedIndex = 0;
        _numericUpDown_MapNo1.Value = 2M;
        _numericUpDown_MapNo2.Value = 1M;
        _numericUpDown_Place.Value = 0M;
        _textBox_Detector.Text = string.Empty;
        _textBox_Renewer.Text = string.Empty;
        _checkBox_OpenProbability1.Checked = false;
        _checkBox_OpenProbability2.Checked = false;
        _checkBox_OpenProbability3.Checked = false;
        _groupBox_TreasureMap.Enabled = true;
        EndUpdate();
        _numericUpDown_Place.ForeColor = Color.Red;
        _button_CreateMap.Enabled = false;
        _button_DeleteMap.Enabled = true;
    }

    private void _numericUpDown_Place_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        var treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex]
            .TreasureMapData;
        treasureMapData.Place.Value = (byte)_numericUpDown_Place.Value;
        if (treasureMapData.MapType == MapType.devil || treasureMapData.IsValidPlace)
            _numericUpDown_Place.ForeColor = Color.Black;
        else
            _numericUpDown_Place.ForeColor = Color.Red;
        _panel_NormalMap.Invalidate();
    }

    private void _comboBox_Devil_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _comboBox_Devil.SelectedIndex == -1 ||
            !(_comboBox_Devil.SelectedItem is Devil selectedItem))
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].TreasureMapData
            .DevilType = selectedItem;
    }

    private void _numericUpDown_DevilLevel_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].TreasureMapData
            .DevilLevel.Value = (byte)_numericUpDown_DevilLevel.Value;
    }

    private void _numericUpDown_DevilVictoryTurn_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].TreasureMapData
            .DevilVictoryTurn = (ushort)_numericUpDown_DevilVictoryTurn.Value;
    }

    private void _checkBox_OpenProbability_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || !(sender is CheckBox checkBox))
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].TreasureMapData
            .SetOpenProbability((int)checkBox.Tag, checkBox.Checked);
    }

    private void _textBox_Detector_TextChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        BeginUpdate();
        var treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex]
            .TreasureMapData;
        treasureMapData.Detector.Value = _textBox_Detector.Text;
        _textBox_Detector.Text = treasureMapData.Detector.Value;
        EndUpdate();
    }

    private void _textBox_Renewer_TextChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        BeginUpdate();
        var treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex]
            .TreasureMapData;
        treasureMapData.Renewer.Value = _textBox_Renewer.Text;
        _textBox_Renewer.Text = treasureMapData.Renewer.Value;
        EndUpdate();
    }

    private void _numericUpDown_MapNo1_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount == 0)
        {
            var treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex]
                .TreasureMapData;
            treasureMapData.Rank = (byte)_numericUpDown_MapNo1.Value;
            if (treasureMapData.IsValidRank)
                _numericUpDown_MapNo1.ForeColor = Color.Black;
            else
                _numericUpDown_MapNo1.ForeColor = Color.Red;
            if (treasureMapData.IsValidPlace)
                _numericUpDown_Place.ForeColor = Color.Black;
            else
                _numericUpDown_Place.ForeColor = Color.Red;
            _groupBox_TreasureMap.Invalidate();
        }

        _panel_NormalMap.Invalidate();
    }

    private void _numericUpDown_MapNo2_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount == 0)
        {
            var treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex]
                .TreasureMapData;
            treasureMapData.Seed = (ushort)_numericUpDown_MapNo2.Value;
            if (treasureMapData.IsValidSeed)
                _numericUpDown_MapNo2.ForeColor = Color.Black;
            else
                _numericUpDown_MapNo2.ForeColor = Color.Red;
            if (treasureMapData.IsValidPlace)
                _numericUpDown_Place.ForeColor = Color.Black;
            else
                _numericUpDown_Place.ForeColor = Color.Red;
            _groupBox_TreasureMap.Invalidate();
        }

        _panel_NormalMap.Invalidate();
    }

    private void _checkBox_Hex_CheckedChanged(object sender, EventArgs e)
    {
        _numericUpDown_MapNo1.Hexadecimal = _checkBox_Hex.Checked;
        _numericUpDown_MapNo2.Hexadecimal = _checkBox_Hex.Checked;
    }

    private void _checkBox_PlaceHex_CheckedChanged(object sender, EventArgs e)
    {
        _numericUpDown_Place.Hexadecimal = _checkBox_PlaceHex.Checked;
        _groupBox_TreasureMap.Invalidate();
    }

    private void radioButton_MapType_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || !(sender is RadioButton radioButton))
            return;
        var tag = (MapType)radioButton.Tag;
        var treasureMapData = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex]
            .TreasureMapData;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        treasureMapData.MapType = tag;
        if (tag == MapType.Normal)
        {
            treasureMapData.Rank = 2;
            _panel_NormalMap.Visible = true;
            _panel_DevilMap.Visible = false;
            _numericUpDown_MapNo1.Value = treasureMapData.Rank;
            _numericUpDown_MapNo2.Value = treasureMapData.Seed;
            if (treasureMapData.IsValidRank)
                _numericUpDown_MapNo1.ForeColor = Color.Black;
            else
                _numericUpDown_MapNo1.ForeColor = Color.Red;
            if (treasureMapData.IsValidSeed)
                _numericUpDown_MapNo2.ForeColor = Color.Black;
            else
                _numericUpDown_MapNo2.ForeColor = Color.Red;
            if (treasureMapData.IsValidPlace)
                _numericUpDown_Place.ForeColor = Color.Black;
            else
                _numericUpDown_Place.ForeColor = Color.Red;
        }
        else
        {
            treasureMapData.Rank = 1;
            treasureMapData.DevilVictoryTurn = 0;
            _panel_NormalMap.Visible = false;
            _panel_DevilMap.Visible = true;
            _comboBox_Devil.SelectedItem = treasureMapData.DevilType;
            _numericUpDown_DevilLevel.Value = treasureMapData.DevilLevel.Value;
            _numericUpDown_DevilVictoryTurn.Value = treasureMapData.DevilVictoryTurn;
            _numericUpDown_Place.ForeColor = Color.Black;
        }

        _groupBox_TreasureMap.Invalidate();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    private void _comboBox_State_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].TreasureMapData
            .MapState = (MapState)(1 << _comboBox_State.SelectedIndex);
    }

    private void _panel_NormalMap_Paint(object sender, PaintEventArgs e)
    {
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            e.Graphics.DrawString("Map No.", Font, brush, 7f, 14f);
            if (DesignMode)
                return;
            var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
            if (_selectedIndex == -1 || !visitorManager.VisitorData[_selectedIndex].HaveTreasureMap)
                return;
            var treasureMapData = visitorManager.VisitorData[_selectedIndex].TreasureMapData;
            var s = !treasureMapData.IsValid ? string.Format("!{0}", treasureMapData.MapName) : treasureMapData.MapName;
            e.Graphics.DrawString(s, Font, brush, 7f, 35f);
        }
    }

    private void _panel_DevilMap_Paint(object sender, PaintEventArgs e)
    {
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            e.Graphics.DrawString("Turns Defeated In", Font, brush, 31f, 58f);
            e.Graphics.DrawString("Level", Font, brush, 93f, 36f);
            e.Graphics.DrawString("Boss", Font, brush, 23f, 14f);
        }
    }

    private void _groupBox_TreasureMap_Paint(object sender, PaintEventArgs e)
    {
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            e.Graphics.DrawString("Location", Font, brush, 200f, 64f);
            e.Graphics.DrawString("Discovered by", Font, brush, 19f, 42f);
            e.Graphics.DrawString("Conquered by", Font, brush, 22f, 64f);
            e.Graphics.DrawString("Status", Font, brush, 211f, 42f);
            if (DesignMode)
                return;
            var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
            if (_selectedIndex == -1 || !visitorManager.VisitorData[_selectedIndex].HaveTreasureMap)
                return;
            var treasureMapData = visitorManager.VisitorData[_selectedIndex].TreasureMapData;
            if (treasureMapData.MapType != MapType.Normal)
                return;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Valid: ");
            var validPlaceList = treasureMapData.ValidPlaceList;
            if (validPlaceList.Count > 0)
            {
                var flag = true;
                foreach (var num in validPlaceList)
                {
                    if (!flag)
                        stringBuilder.Append(", ");
                    if (_checkBox_PlaceHex.Checked)
                        stringBuilder.AppendFormat("{0:X02}", num);
                    else
                        stringBuilder.AppendFormat("{0:D}", num);
                    flag = false;
                }
            }
            else
            {
                stringBuilder.Append("none");
            }

            e.Graphics.DrawString(stringBuilder.ToString(), Font, brush, 247f, 83f);
        }
    }

    private void _buttonSelectHandle_Click(object sender, EventArgs e)
    {
        var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        using (var handleSelectWindow = new HandleSelectWindow(visitorManager.VisitorData[_selectedIndex].ProfileSex))
        {
            handleSelectWindow.Location = PointToScreen(new Point(_groupBox_Profile.Left + _buttonSelectHandle.Right,
                _groupBox_Profile.Top + _buttonSelectHandle.Bottom));
            if (handleSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            var selectedHandle = handleSelectWindow.SelectedHandle;
            visitorManager.VisitorData[_selectedIndex].Handle = selectedHandle;
            OnValueUpdate();
        }
    }

    private void _buttonSelectAddress_Click(object sender, EventArgs e)
    {
        using (var addressSelectWindow = new AddressSelectWindow())
        {
            addressSelectWindow.Location = PointToScreen(new Point(_groupBox_Profile.Left + _buttonSelectAddress.Right,
                _groupBox_Profile.Top + _buttonSelectAddress.Bottom));
            if (addressSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].Address =
                addressSelectWindow.SelectedAddress;
            OnValueUpdate();
        }
    }

    private void _numericUpDownSEQ_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].SEQ =
            (uint)_numericUpDownSEQ.Value;
    }

    private void _numericUpDownUID_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        var num = (ulong)_numericUpDownUID.Value;
        if ((long)visitorManager.VisitorData[_selectedIndex].UID == (long)num)
            return;
        visitorManager.VisitorData[_selectedIndex].UID = num;
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
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].EyeColor =
            (byte)_numericUpDownEyeColor.Value;
    }

    private void _numericUpDownSkinColor_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].SkinColor =
            (byte)_numericUpDownSkinColor.Value;
    }

    private void _numericUpDownFaceType_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].FaceType.Value =
            (byte)_numericUpDownFaceType.Value;
    }

    private void _numericUpDownHairColor_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].HairColor.Value =
            (byte)_numericUpDownHairColor.Value;
    }

    private void _numericUpDownHairType_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].HairType.Value =
            (byte)_numericUpDownHairType.Value;
    }

    private void _numericUpDownFigureHeight_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].FigureHeight.Value =
            (ushort)_numericUpDownFigureHeight.Value;
    }

    private void _numericUpDownFigureWidth_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].FigureWidth.Value =
            (ushort)_numericUpDownFigureWidth.Value;
    }

    private void _numericUpDownBirthDayDay_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].ProfileBirthDay =
            (byte)_numericUpDownBirthDayDay.Value;
    }

    private void _numericUpDownBirthDayMonth_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].ProfileBirthMonth =
            (byte)_numericUpDownBirthDayMonth.Value;
    }

    private void _numericUpDownBirthDayYear_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].ProfileBirthYear =
            (ushort)_numericUpDownBirthDayYear.Value;
    }

    private void _comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].Color =
            (byte)_comboBoxColor.SelectedIndex;
    }

    private void _textBox_ProfileMessage_TextChanged(object sender, EventArgs e)
    {
        var maxLength = SaveDataManager.Instance.SaveData.BasisData.ProfileMessage.MaxLength;
        Encoding templateencoding = StringFixer.templateencoding;
        var bytes = templateencoding.GetBytes(_textBox_ProfileMessage.Text);
        if (bytes.Length > maxLength)
        {
            _textBox_ProfileMessage.Text = templateencoding.GetString(bytes, 0, maxLength);
            _textBox_ProfileMessage.SelectionStart = _textBox_ProfileMessage.TextLength;
        }
        else
        {
            _textBox_ProfileMessage.Text = templateencoding.GetString(bytes, 0, bytes.Length);
        }

        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].ProfileMessage.Value =
            _textBox_ProfileMessage.Text;
    }

    private void _checkBoxSecretAge_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].ProfileSecretAge =
            _checkBoxSecretAge.Checked;
    }

    private void _profileTone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].ProfileTone =
            (byte)_profileTone.SelectedIndex;
    }

    private void _comboBoxSex_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        visitorManager.VisitorData[_selectedIndex].CharaSex = (byte)_comboBoxSex.SelectedIndex;
        visitorManager.VisitorData[_selectedIndex].ProfileSex = (byte)_comboBoxSex.SelectedIndex;
        visitorManager.VisitorData[_selectedIndex].Sex = (byte)_comboBoxSex.SelectedIndex;
        RenewalHanle(visitorManager.VisitorData[_selectedIndex]);
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    private void _numericUpDownAlchemyCompRate_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].AlchemyCompRate =
            (byte)_numericUpDownAlchemyCompRate.Value;
    }

    private void _numericUpDownItemCompRate_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].ItemCompRate =
            (byte)_numericUpDownItemCompRate.Value;
    }

    private void _numericUpDownFashionCompRate_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].FashionCompRate =
            (byte)_numericUpDownFashionCompRate.Value;
    }

    private void _numericUpDownMonsterCompRate_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].MonsterCompRate =
            (byte)_numericUpDownMonsterCompRate.Value;
    }

    private void _numericUpDownVisitorCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].VisitorCount =
            (ushort)_numericUpDownVisitorCount.Value;
    }

    private void _numericUpDownTreasureMapCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].TreasureMapCount =
            (ushort)_numericUpDownTreasureMapCount.Value;
    }

    private void _numericUpDownQuestClearCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].QuestClearCount =
            (ushort)_numericUpDownQuestClearCount.Value;
    }

    private void _numericUpDownTitleCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].TitleCount =
            (ushort)_numericUpDownTitleCount.Value;
    }

    private void _numericUpDownAlchemyCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].AlchemyCount =
            (ushort)_numericUpDownAlchemyCount.Value;
    }

    private void _numericUpDownVictoryCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].VictoryCount =
            (ushort)_numericUpDownVictoryCount.Value;
    }

    private void _numericUpDownMultiPlayTimeMinute_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].MultiPlayTimeMinute =
            (byte)_numericUpDownMultiPlayTimeMinute.Value;
    }

    private void _numericUpDownMultiPlayTimeHour_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].MultiPlayTimeHour =
            (ushort)_numericUpDownMultiPlayTimeHour.Value;
    }

    private void _numericUpDownPlayTimeMinute_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].PlayTimeMinute =
            (byte)_numericUpDownPlayTimeMinute.Value;
    }

    private void _numericUpDownPlayTimeHour_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].PlayTimeHour =
            (ushort)_numericUpDownPlayTimeHour.Value;
    }

    private void _numericUpDownTransmigration_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].Transmigration =
            (byte)_numericUpDownTransmigration.Value;
    }

    private void _numericUpDownLV_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].Level =
            (byte)_numericUpDownLV.Value;
    }

    private void _comboBoxPlace_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].Place =
            (byte)_comboBoxPlace.SelectedIndex;
    }

    private void _textBoxName_TextChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        visitorManager.VisitorData[_selectedIndex].Name.Value = _textBoxName.Text;
        if (visitorManager.VisitorData[_selectedIndex].Name.Value != _textBoxName.Text)
        {
            _textBoxName.Text = visitorManager.VisitorData[_selectedIndex].Name.Value;
            _textBoxName.SelectionStart = _textBoxName.Text.Length;
        }

        if (!(Parent is RikkaInnDataControl parent))
            return;
        parent.RenewalListBox();
    }

    private void _comboBoxJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].Job =
            (byte)JobDataList.List[_comboBoxJob.SelectedIndex].DataIndex;
    }

    private void _numericUpDownLodgingYear_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].LodgingDay_Year =
            (ushort)_numericUpDownLodgingYear.Value;
    }

    private void _numericUpDownLodgingMonth_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].LodgingDay_Month =
            (byte)_numericUpDownLodgingMonth.Value;
    }

    private void _numericUpDownLodgingDay_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || _selectedIndex == -1)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex].LodgingDay_Day =
            (byte)_numericUpDownLodgingDay.Value;
    }

    protected override void OnResize(EventArgs e)
    {
        _panelVisitorEditArea.Size = Size;
    }

    private void BeginUpdate()
    {
        ++_updateCount;
    }

    private void EndUpdate()
    {
        if (_updateCount <= 0)
            return;
        --_updateCount;
    }

    public void OnValueUpdate()
    {
        OnValueUpdate(_selectedIndex);
    }

    public void OnValueUpdate(int index)
    {
        _selectedIndex = index;
        BeginUpdate();
        Invalidate();
        var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        if (_selectedIndex != -1)
        {
            _panelVisitorEditArea.Enabled = true;
            var visitorData = visitorManager.VisitorData[_selectedIndex];
            _numericUpDownLodgingYear.Value = visitorData.LodgingDay_Year;
            _numericUpDownLodgingMonth.Value = visitorData.LodgingDay_Month;
            _numericUpDownLodgingDay.Value = visitorData.LodgingDay_Day;
            _textBoxName.Text = visitorData.Name.Value;
            _comboBoxColor.SelectedIndex = visitorData.Color;
            for (var index1 = 0; index1 < JobDataList.List.Count; ++index1)
                if (JobDataList.List[index1].DataIndex == visitorData.Job)
                {
                    _comboBoxJob.SelectedIndex = index1;
                    break;
                }

            _comboBoxPlace.SelectedIndex = visitorData.Place;
            _numericUpDownSEQ.Value = visitorData.SEQ;
            _numericUpDownUID.Value = visitorData.UID;
            _numericUpDownLV.Value = visitorData.Level;
            _numericUpDownTransmigration.Value = visitorData.Transmigration;
            _numericUpDownPlayTimeHour.Value = visitorData.PlayTimeHour;
            _numericUpDownPlayTimeMinute.Value = visitorData.PlayTimeMinute;
            _numericUpDownMultiPlayTimeHour.Value = visitorData.MultiPlayTimeHour;
            _numericUpDownMultiPlayTimeMinute.Value = visitorData.MultiPlayTimeMinute;
            _numericUpDownVictoryCount.Value = visitorData.VictoryCount;
            _numericUpDownAlchemyCount.Value = visitorData.AlchemyCount;
            _numericUpDownTitleCount.Value = visitorData.TitleCount;
            _numericUpDownQuestClearCount.Value = visitorData.QuestClearCount;
            _numericUpDownTreasureMapCount.Value = visitorData.TreasureMapCount;
            _numericUpDownVisitorCount.Value = visitorData.VisitorCount;
            _numericUpDownMonsterCompRate.Value = visitorData.MonsterCompRate;
            _numericUpDownFashionCompRate.Value = visitorData.FashionCompRate;
            _numericUpDownItemCompRate.Value = visitorData.ItemCompRate;
            _numericUpDownAlchemyCompRate.Value = visitorData.AlchemyCompRate;
            _numericUpDownFigureWidth.Value = visitorData.FigureWidth.Value;
            _numericUpDownFigureHeight.Value = visitorData.FigureHeight.Value;
            _numericUpDownHairType.Value = visitorData.HairType.Value;
            _numericUpDownHairColor.Value = visitorData.HairColor.Value;
            _numericUpDownFaceType.Value = visitorData.FaceType.Value;
            _numericUpDownSkinColor.Value = visitorData.SkinColor;
            _numericUpDownEyeColor.Value = visitorData.EyeColor;
            _textBoxEquipmentWeapon.Text =
                visitorData.EquipmentWeapon == null ? "nothing" : visitorData.EquipmentWeapon.Name;
            _textBoxEquipmentShield.Text =
                visitorData.EquipmentShield == null ? "nothing" : visitorData.EquipmentShield.Name;
            _textBoxEquipmentHead.Text = visitorData.EquipmentHead == null ? "nothing" : visitorData.EquipmentHead.Name;
            _textBoxEquipmentUpperBody.Text = visitorData.EquipmentUpperBody == null
                ? "nothing"
                : visitorData.EquipmentUpperBody.Name;
            _textBoxEquipmentArm.Text = visitorData.EquipmentArm == null ? "nothing" : visitorData.EquipmentArm.Name;
            _textBoxEquipmentLowerBody.Text = visitorData.EquipmentLowerBody == null
                ? "nothing"
                : visitorData.EquipmentLowerBody.Name;
            _textBoxEquipmentShoe.Text = visitorData.EquipmentShoe == null ? "nothing" : visitorData.EquipmentShoe.Name;
            _textBoxEquipmentAccessory.Text = visitorData.EquipmentAccessory == null
                ? "nothing"
                : visitorData.EquipmentAccessory.Name;
            _numericUpDownBirthDayYear.Value = visitorData.ProfileBirthYear;
            _numericUpDownBirthDayMonth.Value = visitorData.ProfileBirthMonth;
            _numericUpDownBirthDayDay.Value = visitorData.ProfileBirthDay;
            _checkBoxSecretAge.Checked = visitorData.ProfileSecretAge;
            _comboBoxSex.SelectedIndex = visitorData.CharaSex;
            _profileTone.SelectedIndex = visitorData.ProfileTone;
            _textBoxAddress.Text = visitorData.Address.Name;
            RenewalHanle(visitorData);
            _textBox_ProfileMessage.Text = visitorData.ProfileMessage.Value;
            if (!visitorData.HaveTreasureMap || visitorData.TreasureMapData.MapType == MapType.Unknown)
            {
                _groupBox_TreasureMap.Enabled = false;
                _panel_NormalMap.Visible = true;
                _panel_DevilMap.Visible = false;
                _numericUpDown_MapNo1.Value = 0M;
                _numericUpDown_MapNo2.Value = 0M;
                _numericUpDown_Place.Value = 0M;
                _comboBox_State.SelectedIndex = -1;
                _textBox_Detector.Text = string.Empty;
                _textBox_Renewer.Text = string.Empty;
                _button_CreateMap.Enabled = true;
                _button_DeleteMap.Enabled = false;
            }
            else
            {
                _groupBox_TreasureMap.Enabled = true;
                _numericUpDown_Place.Value = visitorData.TreasureMapData.Place.Value;
                if (visitorData.TreasureMapData.MapType == MapType.Normal)
                {
                    _radioButton_NormalMap.Checked = true;
                    _panel_NormalMap.Visible = true;
                    _panel_DevilMap.Visible = false;
                    _numericUpDown_MapNo1.Value = visitorData.TreasureMapData.Rank;
                    _numericUpDown_MapNo2.Value = visitorData.TreasureMapData.Seed;
                    if (visitorData.TreasureMapData.IsValidRank)
                        _numericUpDown_MapNo1.ForeColor = Color.Black;
                    else
                        _numericUpDown_MapNo1.ForeColor = Color.Red;
                    if (visitorData.TreasureMapData.IsValidSeed)
                        _numericUpDown_MapNo2.ForeColor = Color.Black;
                    else
                        _numericUpDown_MapNo2.ForeColor = Color.Red;
                    if (visitorData.TreasureMapData.IsValidPlace)
                        _numericUpDown_Place.ForeColor = Color.Black;
                    else
                        _numericUpDown_Place.ForeColor = Color.Red;
                }
                else
                {
                    _radioButton_DevilMap.Checked = true;
                    _panel_NormalMap.Visible = false;
                    _panel_DevilMap.Visible = true;
                    _comboBox_Devil.SelectedItem = visitorData.TreasureMapData.DevilType;
                    _numericUpDown_DevilLevel.Value = visitorData.TreasureMapData.DevilLevel.Value;
                    _numericUpDown_DevilVictoryTurn.Value = visitorData.TreasureMapData.DevilVictoryTurn;
                    _numericUpDown_Place.ForeColor = Color.Black;
                }

                _textBox_Detector.Text = visitorData.TreasureMapData.Detector.Value;
                _textBox_Renewer.Text = visitorData.TreasureMapData.Renewer.Value;
                if (visitorData.TreasureMapData.MapState == MapState.NotDiscover)
                    _comboBox_State.SelectedIndex = 0;
                else if (visitorData.TreasureMapData.MapState == MapState.Discover)
                    _comboBox_State.SelectedIndex = 1;
                else if (visitorData.TreasureMapData.MapState == MapState.Clear)
                    _comboBox_State.SelectedIndex = 2;
                else
                    _comboBox_State.SelectedIndex = -1;
                _checkBox_OpenProbability1.Checked = visitorData.TreasureMapData.IsOpenProbability(0);
                _checkBox_OpenProbability2.Checked = visitorData.TreasureMapData.IsOpenProbability(1);
                _checkBox_OpenProbability3.Checked = visitorData.TreasureMapData.IsOpenProbability(2);
                _button_CreateMap.Enabled = false;
                _button_DeleteMap.Enabled = true;
            }
        }
        else
        {
            _panelVisitorEditArea.Enabled = false;
            _numericUpDownLodgingYear.Value = 2000M;
            _numericUpDownLodgingMonth.Value = 1M;
            _numericUpDownLodgingDay.Value = 1M;
            _textBoxName.Text = string.Empty;
            _comboBoxColor.SelectedIndex = -1;
            _comboBoxJob.SelectedIndex = -1;
            _comboBoxPlace.SelectedIndex = -1;
            _numericUpDownSEQ.Value = 1M;
            _numericUpDownLV.Value = 0M;
            _numericUpDownTransmigration.Value = 0M;
            _numericUpDownPlayTimeHour.Value = 0M;
            _numericUpDownPlayTimeMinute.Value = 0M;
            _numericUpDownMultiPlayTimeHour.Value = 0M;
            _numericUpDownMultiPlayTimeMinute.Value = 0M;
            _numericUpDownVictoryCount.Value = 0M;
            _numericUpDownAlchemyCount.Value = 0M;
            _numericUpDownTitleCount.Value = 0M;
            _numericUpDownQuestClearCount.Value = 0M;
            _numericUpDownTreasureMapCount.Value = 0M;
            _numericUpDownVisitorCount.Value = 0M;
            _numericUpDownMonsterCompRate.Value = 0M;
            _numericUpDownFashionCompRate.Value = 0M;
            _numericUpDownItemCompRate.Value = 0M;
            _numericUpDownAlchemyCompRate.Value = 0M;
            _numericUpDownFigureWidth.Value = 0M;
            _numericUpDownFigureHeight.Value = 0M;
            _numericUpDownHairType.Value = 0M;
            _numericUpDownHairColor.Value = 0M;
            _numericUpDownFaceType.Value = 0M;
            _numericUpDownSkinColor.Value = 0M;
            _numericUpDownEyeColor.Value = 0M;
            _textBoxEquipmentWeapon.Text = string.Empty;
            _textBoxEquipmentShield.Text = string.Empty;
            _textBoxEquipmentHead.Text = string.Empty;
            _textBoxEquipmentUpperBody.Text = string.Empty;
            _textBoxEquipmentArm.Text = string.Empty;
            _textBoxEquipmentLowerBody.Text = string.Empty;
            _textBoxEquipmentShoe.Text = string.Empty;
            _textBoxEquipmentAccessory.Text = string.Empty;
            _numericUpDownBirthDayYear.Value = 0M;
            _numericUpDownBirthDayMonth.Value = 0M;
            _numericUpDownBirthDayDay.Value = 0M;
            _checkBoxSecretAge.Checked = false;
            _comboBoxSex.SelectedIndex = -1;
            _profileTone.SelectedIndex = -1;
            _textBoxAddress.Text = string.Empty;
            _textBoxHandle.Text = string.Empty;
            _textBox_ProfileMessage.Text = string.Empty;
            _groupBox_TreasureMap.Enabled = false;
            _panel_NormalMap.Visible = true;
            _panel_DevilMap.Visible = false;
            _numericUpDown_MapNo1.Value = 0M;
            _numericUpDown_MapNo2.Value = 0M;
            _numericUpDown_Place.Value = 0M;
            _comboBox_State.SelectedIndex = -1;
            _textBox_Detector.Text = string.Empty;
            _textBox_Renewer.Text = string.Empty;
        }

        EndUpdate();
    }

    private void RenewalHanle(VisitorData visitorData)
    {
        _textBoxHandle.Text = string.Empty;
        if (visitorData.Handle == null)
            return;
        if (visitorData.Handle.Job != null)
        {
            _textBoxHandle.Text = visitorData.Handle.Job.Name;
        }
        else
        {
            if (visitorData.Handle.Title == null)
                return;
            if (visitorData.ProfileSex == 0)
            {
                _textBoxHandle.Text = visitorData.Handle.Title.MaleTitleName;
            }
            else
            {
                if (visitorData.ProfileSex != 1)
                    return;
                _textBoxHandle.Text = visitorData.Handle.Title.LadyTitleName;
            }
        }
    }

    private void _groupBox_Profile_Paint(object sender, PaintEventArgs e)
    {
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            e.Graphics.DrawString("Birthday", Font, brush, 21f, 17f);
            e.Graphics.DrawString("Y", Font, brush, new PointF(125f, 17f));
            e.Graphics.DrawString("M", Font, brush, new PointF(196f, 16f));
            e.Graphics.DrawString("D", Font, brush, new PointF(268f, 16f));
            e.Graphics.DrawString("Gender", Font, brush, new PointF(138f, 44f));
            e.Graphics.DrawString("Speech Style", Font, brush, new PointF(11f, 70f));
            e.Graphics.DrawString("Location", Font, brush, new PointF(32f, 94f));
            e.Graphics.DrawString("Title", Font, brush, new PointF(52f, 118f));
            e.Graphics.DrawString("Greeting", Font, brush, new PointF(17f, 142f));
        }
    }

    private void _groupBox_Figure_Paint(object sender, PaintEventArgs e)
    {
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            e.Graphics.DrawString("Body (W)", Font, brush, 21f, 19f);
            e.Graphics.DrawString("Body (H)", Font, brush, 23f, 40f);
            e.Graphics.DrawString("Hair Style", Font, brush, 18f, 61f);
            e.Graphics.DrawString("Hair Color", Font, brush, 16f, 82f);
            e.Graphics.DrawString("Face", Font, brush, 42f, 103f);
            e.Graphics.DrawString("Skin Color", Font, brush, 15f, 124f);
            e.Graphics.DrawString("Eye Color", Font, brush, 18f, 145f);
            e.Graphics.DrawString("(0-7)", Font, brush, 129f, 124f);
            e.Graphics.DrawString("(0-15)", Font, brush, 129f, 145f);
        }
    }

    private void _groupBox_Equipment_Paint(object sender, PaintEventArgs e)
    {
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            e.Graphics.DrawString("Weapon", Font, brush, 15f, 19f);
            e.Graphics.DrawString("Shield", Font, brush, 24f, 39f);
            e.Graphics.DrawString("Head", Font, brush, 29f, 59f);
            e.Graphics.DrawString("Torso", Font, brush, 26f, 79f);
            e.Graphics.DrawString("Arms", Font, brush, 30f, 99f);
            e.Graphics.DrawString("Legs", Font, brush, 32f, 119f);
            e.Graphics.DrawString("Feet", Font, brush, 33f, 139f);
            e.Graphics.DrawString("Accessory", Font, brush, 3f, 159f);
        }
    }

    private void _groupBox_CompRate_Paint(object sender, PaintEventArgs e)
    {
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            e.Graphics.DrawString("Defeated Monsters", Font, brush, 12f, 18f);
            e.Graphics.DrawString("Wardrobe", Font, brush, 197f, 18f);
            e.Graphics.DrawString("Item List", Font, brush, 62f, 40f);
            e.Graphics.DrawString("Alchenomicon", Font, brush, 175f, 40f);
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            if (DesignMode || SaveDataManager.Instance.SaveData == null)
                return;
            int num = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorCount.Value;
            e.Graphics.DrawString(string.Format("({0} / 30)", num), Font, brush, new PointF(16f, 274f));
        }
    }

    private void _panelVisitorEditArea_Paint(object sender, PaintEventArgs e)
    {
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            e.Graphics.DrawString("Lodging Date", Font, brush, 7f, 16f);
            e.Graphics.DrawString("Y", Font, brush, 129f, 16f);
            e.Graphics.DrawString("M", Font, brush, 187f, 16f);
            e.Graphics.DrawString("D", Font, brush, 245f, 16f);
            e.Graphics.DrawString("Location", Font, brush, 270f, 16f);
            e.Graphics.DrawString("SEQ", Font, brush, 433f, 16f);
            e.Graphics.DrawString("UID", Font, brush, 571f, 16f);
            e.Graphics.DrawString("Name", Font, brush, 43f, 41f);
            e.Graphics.DrawString("Color", Font, brush, 151f, 41f);
            e.Graphics.DrawString("Vocation", Font, brush, 269f, 41f);
            e.Graphics.DrawString("Level", Font, brush, 421f, 41f);
            e.Graphics.DrawString("Revocations", Font, brush, 508f, 41f);
            e.Graphics.DrawString("Play time", Font, brush, 60f, 74f);
            e.Graphics.DrawString("hours", Font, brush, 163f, 74f);
            e.Graphics.DrawString("min", Font, brush, 248f, 74f);
            e.Graphics.DrawString("Multiplayer time", Font, brush, 27f, 99f);
            e.Graphics.DrawString("hours", Font, brush, 163f, 99f);
            e.Graphics.DrawString("min", Font, brush, 248f, 99f);
            e.Graphics.DrawString("Battle Victories", Font, brush, 30f, 135f);
            e.Graphics.DrawString("Alchemy Performed", Font, brush, 163f, 135f);
            e.Graphics.DrawString("Accolades Earnt", Font, brush, 23f, 156f);
            e.Graphics.DrawString("Quests Completed", Font, brush, 168f, 156f);
            e.Graphics.DrawString("Grottoes Completed", Font, brush, 6f, 177f);
            e.Graphics.DrawString("Guests Canvassed", Font, brush, 165f, 177f);
        }
    }

    private void ButtonSelect_Click(object sender, EventArgs e)
    {
        if (!(sender is VisionButton visionButton))
            return;
        var itemType = (ItemType)((int)visionButton.Tag + 2);
        using (var itemSelectWindow = new ItemSelectWindow(itemType))
        {
            itemSelectWindow.Location =
                PointToScreen(new Point(_groupBox_Equipment.Right, _groupBox_Equipment.Top + visionButton.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            var selectedItem = itemSelectWindow.SelectedItem;
            SaveDataManager.Instance.SaveData.RikkaData.VisitorManager.VisitorData[_selectedIndex]
                .SetEquipment(itemType, selectedItem);
            OnValueUpdate();
        }
    }

    private void ButtonPreset_Click(object sender, EventArgs e)
    {
        if (!(sender is VisionButton visionButton))
            return;
        var tag = (ListType)visionButton.Tag;
        using (var presetWindow = new PresetWindow(tag))
        {
            presetWindow.Location =
                PointToScreen(new Point(_groupBox_Figure.Right, _groupBox_Figure.Top + visionButton.Bottom));
            if (presetWindow.ShowDialog() != DialogResult.OK)
                return;
            var selectedPreset1 = presetWindow.SelectedPreset as Preset;
            var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
            switch (tag)
            {
                case ListType.Figure:
                    if (!(presetWindow.SelectedPreset is PresetFigure selectedPreset2))
                        break;
                    SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
                    visitorManager.VisitorData[_selectedIndex].FigureWidth.Value = selectedPreset2.Width;
                    visitorManager.VisitorData[_selectedIndex].FigureHeight.Value = selectedPreset2.Height;
                    SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
                    OnValueUpdate();
                    break;
                case ListType.HairType:
                    if (selectedPreset1 == null)
                        break;
                    visitorManager.VisitorData[_selectedIndex].HairType.Value = selectedPreset1.Index;
                    OnValueUpdate();
                    break;
                case ListType.HairColor:
                    if (selectedPreset1 == null)
                        break;
                    visitorManager.VisitorData[_selectedIndex].HairColor.Value = selectedPreset1.Index;
                    OnValueUpdate();
                    break;
                case ListType.FaceType:
                    if (selectedPreset1 == null)
                        break;
                    visitorManager.VisitorData[_selectedIndex].FaceType.Value = selectedPreset1.Index;
                    OnValueUpdate();
                    break;
            }
        }
    }
}