// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.BasisDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using FriedGinger.DQCheat;

namespace DQ9_Cheat.Controls;

public class BasisDataControl : DataControlBase
{
    private readonly VisionComboBox _comboBox_GestureDown1;
    private readonly VisionComboBox _comboBox_GestureDown2;
    private readonly VisionComboBox _comboBox_GestureDown3;
    private readonly VisionComboBox _comboBox_GestureDown4;
    private readonly VisionComboBox _comboBox_GestureLeft;
    private readonly VisionComboBox _comboBox_GestureRight;
    private readonly VisionComboBox _comboBox_GestureUp;
    private SafeNumericUpDown _numericUpDown_IntermissionX;
    private SafeNumericUpDown _numericUpDown_IntermissionY;
    private SafeNumericUpDown _numericUpDown_IntermissionZ;
    private TextBox _textBox_ProfileAddress;
    private TextBox _textBox_ProfileHandle;
    private TextBox _textBox_ProfileMessage;
    private TextBox _textbox_test = new();
    private Button button_SelectProfileAddress;
    private Button button_SelectProfileHandle;
    private Button button_SelectSavePlace;
    private CheckBox checkBox_Explanation;
    private CheckBox checkBox_ProfileSetting;
    private CheckBox checkBox_ToneSetting;
    private CheckedListBox checkedListBox_GestureLearn;
    private ComboBox comboBox_Sex;
    private ComboBox comboBox_Tone;
    private IContainer components;
    private JS_GroupBox groupBox_Gesture;
    private JS_GroupBox groupBox_IntermissionCoord;
    private GroupBox groupBox_Profile;
    private Label label_bankMoney;
    private Label label_BirthDay;
    private Label label_Day;
    private Label label_Hour;
    private Label label_medal;
    private Label label_Message;
    private Label label_Minute;
    private Label label_Money;
    private Label label_Month;
    private Label label_PlayTime;
    private Label label_SavePlace;
    private Label label_Second;
    private Label label_Year;
    private Label label1;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private Label label14;
    private Label label15;
    private Label label16;
    private Label label17;
    private Label label18;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private JS_Panel panel_Profile;
    private TextBox textBox_SavePlace;

    public BasisDataControl()
    {
        AutoScaleMode = AutoScaleMode.None;
        InitializeComponent();
        SuspendLayout();
        _comboBox_GestureUp = new VisionComboBox(81, 28, 125, 21);
        _comboBox_GestureUp.SelectedIndexChanged += comboBox_Gesture_SelectedIndexChanged;
        _comboBox_GestureLeft = new VisionComboBox(6, 69, 125, 21);
        _comboBox_GestureLeft.SelectedIndexChanged += comboBox_Gesture_SelectedIndexChanged;
        _comboBox_GestureRight = new VisionComboBox(148, 69, 125, 21);
        _comboBox_GestureRight.SelectedIndexChanged += comboBox_Gesture_SelectedIndexChanged;
        _comboBox_GestureDown1 = new VisionComboBox(81, 108, 125, 21);
        _comboBox_GestureDown1.SelectedIndexChanged += comboBox_Gesture_SelectedIndexChanged;
        _comboBox_GestureDown2 = new VisionComboBox(81, 132, 125, 21);
        _comboBox_GestureDown2.SelectedIndexChanged += comboBox_Gesture_SelectedIndexChanged;
        _comboBox_GestureDown3 = new VisionComboBox(81, 156, 125, 21);
        _comboBox_GestureDown3.SelectedIndexChanged += comboBox_Gesture_SelectedIndexChanged;
        _comboBox_GestureDown4 = new VisionComboBox(81, 180, 125, 21);
        _comboBox_GestureDown4.SelectedIndexChanged += comboBox_Gesture_SelectedIndexChanged;
        foreach (var gesture in GestureList.List)
        {
            _comboBox_GestureUp.Items.Add(gesture);
            _comboBox_GestureLeft.Items.Add(gesture);
            _comboBox_GestureRight.Items.Add(gesture);
            _comboBox_GestureDown1.Items.Add(gesture);
            _comboBox_GestureDown2.Items.Add(gesture);
            _comboBox_GestureDown3.Items.Add(gesture);
            _comboBox_GestureDown4.Items.Add(gesture);
        }

        var num1 = 0;
        var comboBoxGestureUp = _comboBox_GestureUp;
        var num2 = num1;
        var num3 = num2 + 1;
        // ISSUE: variable of a boxed type
        var local1 = num2;
        comboBoxGestureUp.Tag = local1;
        var comboBoxGestureLeft = _comboBox_GestureLeft;
        var num4 = num3;
        var num5 = num4 + 1;
        // ISSUE: variable of a boxed type
        var local2 = num4;
        comboBoxGestureLeft.Tag = local2;
        var comboBoxGestureRight = _comboBox_GestureRight;
        var num6 = num5;
        var num7 = num6 + 1;
        // ISSUE: variable of a boxed type
        var local3 = num6;
        comboBoxGestureRight.Tag = local3;
        var comboBoxGestureDown1 = _comboBox_GestureDown1;
        var num8 = num7;
        var num9 = num8 + 1;
        // ISSUE: variable of a boxed type
        var local4 = num8;
        comboBoxGestureDown1.Tag = local4;
        var comboBoxGestureDown2 = _comboBox_GestureDown2;
        var num10 = num9;
        var num11 = num10 + 1;
        // ISSUE: variable of a boxed type
        var local5 = num10;
        comboBoxGestureDown2.Tag = local5;
        var comboBoxGestureDown3 = _comboBox_GestureDown3;
        var num12 = num11;
        var num13 = num12 + 1;
        // ISSUE: variable of a boxed type
        var local6 = num12;
        comboBoxGestureDown3.Tag = local6;
        var comboBoxGestureDown4 = _comboBox_GestureDown4;
        var num14 = num13;
        var num15 = num14 + 1;
        // ISSUE: variable of a boxed type
        var local7 = num14;
        comboBoxGestureDown4.Tag = local7;
        groupBox_Gesture.AddVisionControl(_comboBox_GestureUp);
        groupBox_Gesture.AddVisionControl(_comboBox_GestureLeft);
        groupBox_Gesture.AddVisionControl(_comboBox_GestureRight);
        groupBox_Gesture.AddVisionControl(_comboBox_GestureDown1);
        groupBox_Gesture.AddVisionControl(_comboBox_GestureDown2);
        groupBox_Gesture.AddVisionControl(_comboBox_GestureDown3);
        groupBox_Gesture.AddVisionControl(_comboBox_GestureDown4);
        NumericUpDown_Hour = new VisionNumericUpDown(98, 12, 60, 20);
        NumericUpDown_Hour.ValueChanged += _numericUpDown_Hour_ValueChanged;
        AddVisionControl(NumericUpDown_Hour);
        NumericUpDown_Minute = new VisionNumericUpDown(199, 12, 41, 20);
        NumericUpDown_Minute.ValueChanged += _numericUpDown_Minute_ValueChanged;
        AddVisionControl(NumericUpDown_Minute);
        NumericUpDown_Second = new VisionNumericUpDown(273, 12, 41, 20);
        NumericUpDown_Second.ValueChanged += _numericUpDown_Second_ValueChanged;
        AddVisionControl(NumericUpDown_Second);
        NumericUpDown_MultiPlayTimeHour = new VisionNumericUpDown(98, 37, 60, 20);
        NumericUpDown_MultiPlayTimeHour.ValueChanged += _numericUpDown_MultiPlayTimeHour_ValueChanged;
        AddVisionControl(NumericUpDown_MultiPlayTimeHour);
        NumericUpDown_MultiPlayTimeMinute = new VisionNumericUpDown(199, 37, 41, 20);
        NumericUpDown_MultiPlayTimeMinute.ValueChanged += _numericUpDown_MultiPlayTimeMinute_ValueChanged;
        AddVisionControl(NumericUpDown_MultiPlayTimeMinute);
        NumericUpDown_MultiPlayTimeSecond = new VisionNumericUpDown(273, 37, 41, 20);
        NumericUpDown_MultiPlayTimeSecond.ValueChanged += _numericUpDown_MultiPlayTimeSecond_ValueChanged;
        AddVisionControl(NumericUpDown_MultiPlayTimeSecond);
        NumericUpDown_Money = new VisionNumericUpDown(98, 80, 80, 20);
        NumericUpDown_Money.ValueChanged += _numericUpDown_Money_ValueChanged;
        AddVisionControl(NumericUpDown_Money);
        NumericUpDown_BankMoney = new VisionNumericUpDown(98, 105, 80, 20);
        NumericUpDown_BankMoney.ValueChanged += _numericUpDown_BankMoney_ValueChanged;
        AddVisionControl(NumericUpDown_BankMoney);
        NumericUpDown_Medal = new VisionNumericUpDown(98, 130, 80, 20);
        NumericUpDown_Medal.ValueChanged += _numericUpDown_Medal_ValueChanged;
        AddVisionControl(NumericUpDown_Medal);
        NumericUpDown_AlchemyCount = new VisionNumericUpDown(98, 155, 80, 20);
        NumericUpDown_AlchemyCount.ValueChanged += _numericUpDown_AlchemyCount_ValueChanged;
        AddVisionControl(NumericUpDown_AlchemyCount);
        NumericUpDown_BattleCount = new VisionNumericUpDown(276, 80, 70, 20);
        NumericUpDown_BattleCount.ValueChanged += _numericUpDown_BattleCount_ValueChanged;
        AddVisionControl(NumericUpDown_BattleCount);
        NumericUpDown_LoseCount = new VisionNumericUpDown(276, 105, 70, 20);
        NumericUpDown_LoseCount.ValueChanged += _numericUpDown_LoseCount_ValueChanged;
        AddVisionControl(NumericUpDown_LoseCount);
        NumericUpDown_EscapeCount = new VisionNumericUpDown(276, 130, 70, 20);
        NumericUpDown_EscapeCount.ValueChanged += _numericUpDown_EscapeCount_ValueChanged;
        AddVisionControl(NumericUpDown_EscapeCount);
        NumericUpDown_EscapeSuccessCount = new VisionNumericUpDown(276, 155, 70, 20);
        NumericUpDown_EscapeSuccessCount.ValueChanged += _numericUpDown_EscapeSuccessCount_ValueChanged;
        AddVisionControl(NumericUpDown_EscapeSuccessCount);
        NumericUpDown_VictoryCount = new VisionNumericUpDown(276, 180, 70, 20);
        NumericUpDown_VictoryCount.ValueChanged += _numericUpDown_VictoryCount_ValueChanged;
        AddVisionControl(NumericUpDown_VictoryCount);
        NumericUpDown_ProfileBirthYear = new VisionNumericUpDown(88, 4, 58, 20);
        NumericUpDown_ProfileBirthYear.ValueChanged += _numericUpDown_ProfileBirthYear_ValueChanged;
        panel_Profile.AddVisionControl(NumericUpDown_ProfileBirthYear);
        NumericUpDown_ProfileBirthMonth = new VisionNumericUpDown(166, 4, 41, 20);
        NumericUpDown_ProfileBirthMonth.ValueChanged += _numericUpDown_ProfileBirthMonth_ValueChanged;
        panel_Profile.AddVisionControl(NumericUpDown_ProfileBirthMonth);
        NumericUpDown_ProfileBirthDay = new VisionNumericUpDown(230, 4, 41, 20);
        NumericUpDown_ProfileBirthDay.ValueChanged += _numericUpDown_ProfileBirthDay_ValueChanged;
        panel_Profile.AddVisionControl(NumericUpDown_ProfileBirthDay);
        ResumeLayout(false);
    }

    public VisionNumericUpDown NumericUpDown_Hour { get; }

    public VisionNumericUpDown NumericUpDown_Minute { get; }

    public VisionNumericUpDown NumericUpDown_Second { get; }

    public VisionNumericUpDown NumericUpDown_MultiPlayTimeHour { get; }

    public VisionNumericUpDown NumericUpDown_MultiPlayTimeMinute { get; }

    public VisionNumericUpDown NumericUpDown_MultiPlayTimeSecond { get; }

    public VisionNumericUpDown NumericUpDown_Money { get; }

    public VisionNumericUpDown NumericUpDown_BankMoney { get; }

    public VisionNumericUpDown NumericUpDown_Medal { get; }

    public VisionNumericUpDown NumericUpDown_BattleCount { get; }

    public VisionNumericUpDown NumericUpDown_LoseCount { get; }

    public VisionNumericUpDown NumericUpDown_EscapeCount { get; }

    public VisionNumericUpDown NumericUpDown_EscapeSuccessCount { get; }

    public VisionNumericUpDown NumericUpDown_VictoryCount { get; }

    public VisionNumericUpDown NumericUpDown_AlchemyCount { get; }

    public VisionNumericUpDown NumericUpDown_ProfileBirthYear { get; }

    public VisionNumericUpDown NumericUpDown_ProfileBirthMonth { get; }

    public VisionNumericUpDown NumericUpDown_ProfileBirthDay { get; }

    public CheckBox CheckBox_SecretAge { get; private set; }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        label_Second = new Label();
        label_Minute = new Label();
        label_Hour = new Label();
        label_PlayTime = new Label();
        label_Money = new Label();
        label_bankMoney = new Label();
        label_medal = new Label();
        groupBox_Profile = new GroupBox();
        panel_Profile = new JS_Panel();
        button_SelectProfileHandle = new Button();
        button_SelectProfileAddress = new Button();
        _textBox_ProfileHandle = new TextBox();
        label18 = new Label();
        _textBox_ProfileAddress = new TextBox();
        label14 = new Label();
        checkBox_ToneSetting = new CheckBox();
        label13 = new Label();
        comboBox_Tone = new ComboBox();
        label_BirthDay = new Label();
        label_Year = new Label();
        comboBox_Sex = new ComboBox();
        label12 = new Label();
        label_Month = new Label();
        CheckBox_SecretAge = new CheckBox();
        label_Message = new Label();
        label_Day = new Label();
        _textBox_ProfileMessage = new TextBox();
        checkBox_Explanation = new CheckBox();
        checkBox_ProfileSetting = new CheckBox();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        label6 = new Label();
        label7 = new Label();
        label8 = new Label();
        label9 = new Label();
        label10 = new Label();
        groupBox_Gesture = new JS_GroupBox();
        label11 = new Label();
        checkedListBox_GestureLearn = new CheckedListBox();
        label_SavePlace = new Label();
        button_SelectSavePlace = new Button();
        textBox_SavePlace = new TextBox();
        label15 = new Label();
        _numericUpDown_IntermissionX = new SafeNumericUpDown();
        _numericUpDown_IntermissionZ = new SafeNumericUpDown();
        label16 = new Label();
        _numericUpDown_IntermissionY = new SafeNumericUpDown();
        label17 = new Label();
        groupBox_IntermissionCoord = new JS_GroupBox();
        groupBox_Profile.SuspendLayout();
        panel_Profile.SuspendLayout();
        groupBox_Gesture.SuspendLayout();
        _numericUpDown_IntermissionX.BeginInit();
        _numericUpDown_IntermissionZ.BeginInit();
        _numericUpDown_IntermissionY.BeginInit();
        groupBox_IntermissionCoord.SuspendLayout();
        SuspendLayout();
        label_Second.AutoSize = true;
        label_Second.Location = new Point(316, 15);
        label_Second.Name = "label_Second";
        label_Second.Size = new Size(29, 13);
        label_Second.TabIndex = 13;
        label_Second.Text = "secs";
        label_Minute.AutoSize = true;
        label_Minute.Location = new Point(242, 15);
        label_Minute.Name = "label_Minute";
        label_Minute.Size = new Size(28, 13);
        label_Minute.TabIndex = 11;
        label_Minute.Text = "mins";
        label_Hour.AutoSize = true;
        label_Hour.Location = new Point(160, 15);
        label_Hour.Name = "label_Hour";
        label_Hour.Size = new Size(33, 13);
        label_Hour.TabIndex = 9;
        label_Hour.Text = "hours";
        label_PlayTime.AutoSize = true;
        label_PlayTime.Location = new Point(49, 15);
        label_PlayTime.Name = "label_PlayTime";
        label_PlayTime.Size = new Size(49, 13);
        label_PlayTime.TabIndex = 7;
        label_PlayTime.Text = "Play time";
        label_Money.AutoSize = true;
        label_Money.Location = new Point(57, 82);
        label_Money.Name = "label_Money";
        label_Money.Size = new Size(39, 13);
        label_Money.TabIndex = 14;
        label_Money.Text = "Money";
        label_bankMoney.AutoSize = true;
        label_bankMoney.Location = new Point(64, 107);
        label_bankMoney.Name = "label_bankMoney";
        label_bankMoney.Size = new Size(32, 13);
        label_bankMoney.TabIndex = 16;
        label_bankMoney.Text = "Bank";
        label_medal.AutoSize = true;
        label_medal.Location = new Point(34, 132);
        label_medal.Name = "label_medal";
        label_medal.Size = new Size(62, 13);
        label_medal.TabIndex = 18;
        label_medal.Text = "Mini medals";
        groupBox_Profile.Controls.Add(panel_Profile);
        groupBox_Profile.Controls.Add(checkBox_Explanation);
        groupBox_Profile.Controls.Add(checkBox_ProfileSetting);
        groupBox_Profile.Location = new Point(9, 203);
        groupBox_Profile.Name = "groupBox_Profile";
        groupBox_Profile.Size = new Size(324, 232);
        groupBox_Profile.TabIndex = 16;
        groupBox_Profile.TabStop = false;
        groupBox_Profile.Text = "Profile";
        panel_Profile.Controls.Add(button_SelectProfileHandle);
        panel_Profile.Controls.Add(button_SelectProfileAddress);
        panel_Profile.Controls.Add(_textBox_ProfileHandle);
        panel_Profile.Controls.Add(label18);
        panel_Profile.Controls.Add(_textBox_ProfileAddress);
        panel_Profile.Controls.Add(label14);
        panel_Profile.Controls.Add(checkBox_ToneSetting);
        panel_Profile.Controls.Add(label13);
        panel_Profile.Controls.Add(comboBox_Tone);
        panel_Profile.Controls.Add(label_BirthDay);
        panel_Profile.Controls.Add(label_Year);
        panel_Profile.Controls.Add(comboBox_Sex);
        panel_Profile.Controls.Add(label12);
        panel_Profile.Controls.Add(label_Month);
        panel_Profile.Controls.Add(CheckBox_SecretAge);
        panel_Profile.Controls.Add(label_Message);
        panel_Profile.Controls.Add(label_Day);
        panel_Profile.Controls.Add(_textBox_ProfileMessage);
        panel_Profile.Location = new Point(6, 35);
        panel_Profile.Name = "panel_Profile";
        panel_Profile.Size = new Size(305, 191);
        panel_Profile.TabIndex = 57;
        button_SelectProfileHandle.Location = new Point(215, 102);
        button_SelectProfileHandle.Name = "button_SelectProfileHandle";
        button_SelectProfileHandle.Size = new Size(45, 20);
        button_SelectProfileHandle.TabIndex = 59;
        button_SelectProfileHandle.Text = "Set";
        button_SelectProfileHandle.UseVisualStyleBackColor = true;
        button_SelectProfileHandle.Click += button_SelectProfileHandle_Click;
        button_SelectProfileAddress.Location = new Point(215, 79);
        button_SelectProfileAddress.Name = "button_SelectProfileAddress";
        button_SelectProfileAddress.Size = new Size(45, 20);
        button_SelectProfileAddress.TabIndex = 58;
        button_SelectProfileAddress.Text = "Set";
        button_SelectProfileAddress.UseVisualStyleBackColor = true;
        button_SelectProfileAddress.Click += button_SelectProfileAddress_Click;
        _textBox_ProfileHandle.Location = new Point(88, 102);
        _textBox_ProfileHandle.Name = "_textBox_ProfileHandle";
        _textBox_ProfileHandle.ReadOnly = true;
        _textBox_ProfileHandle.Size = new Size(121, 20);
        _textBox_ProfileHandle.TabIndex = 17;
        label18.AutoSize = true;
        label18.Location = new Point(60, 105);
        label18.Name = "label18";
        label18.Size = new Size(27, 13);
        label18.TabIndex = 16;
        label18.Text = "Title";
        _textBox_ProfileAddress.Location = new Point(88, 79);
        _textBox_ProfileAddress.Name = "_textBox_ProfileAddress";
        _textBox_ProfileAddress.ReadOnly = true;
        _textBox_ProfileAddress.Size = new Size(121, 20);
        _textBox_ProfileAddress.TabIndex = 15;
        label14.AutoSize = true;
        label14.Location = new Point(39, 82);
        label14.Name = "label14";
        label14.Size = new Size(48, 13);
        label14.TabIndex = 14;
        label14.Text = "Location";
        checkBox_ToneSetting.AutoSize = true;
        checkBox_ToneSetting.Location = new Point(215, 58);
        checkBox_ToneSetting.Name = "checkBox_ToneSetting";
        checkBox_ToneSetting.Size = new Size(77, 17);
        checkBox_ToneSetting.TabIndex = 13;
        checkBox_ToneSetting.Text = "Configured";
        checkBox_ToneSetting.UseVisualStyleBackColor = true;
        checkBox_ToneSetting.CheckedChanged += checkBox_ToneSetting_CheckedChanged;
        label13.AutoSize = true;
        label13.Location = new Point(17, 59);
        label13.Name = "label13";
        label13.Size = new Size(70, 13);
        label13.TabIndex = 12;
        label13.Text = "Speech Style";
        comboBox_Tone.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Tone.FormattingEnabled = true;
        comboBox_Tone.Items.AddRange([
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
            "Witch",
            "Nice Old Man",
            "Kind Old Woman",
            "Doddery Old Man",
            "Bored Teenager"
        ]);
        comboBox_Tone.Location = new Point(88, 55);
        comboBox_Tone.Name = "comboBox_Tone";
        comboBox_Tone.Size = new Size(121, 21);
        comboBox_Tone.TabIndex = 11;
        comboBox_Tone.SelectedIndexChanged += comboBox_Tone_SelectedIndexChanged;
        label_BirthDay.AutoSize = true;
        label_BirthDay.Location = new Point(41, 6);
        label_BirthDay.Name = "label_BirthDay";
        label_BirthDay.Size = new Size(45, 13);
        label_BirthDay.TabIndex = 0;
        label_BirthDay.Text = "Birthday";
        label_Year.AutoSize = true;
        label_Year.Location = new Point(147, 6);
        label_Year.Name = "label_Year";
        label_Year.Size = new Size(14, 13);
        label_Year.TabIndex = 2;
        label_Year.Text = "Y";
        comboBox_Sex.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Sex.FormattingEnabled = true;
        comboBox_Sex.Items.AddRange([
            "Male",
            "Female"
        ]);
        comboBox_Sex.Location = new Point(177, 31);
        comboBox_Sex.Name = "comboBox_Sex";
        comboBox_Sex.Size = new Size(64, 21);
        comboBox_Sex.TabIndex = 10;
        comboBox_Sex.SelectedIndexChanged += comboBox_Sex_SelectedIndexChanged;
        label12.AutoSize = true;
        label12.Location = new Point(134, 34);
        label12.Name = "label12";
        label12.Size = new Size(42, 13);
        label12.TabIndex = 9;
        label12.Text = "Gender";
        label_Month.AutoSize = true;
        label_Month.Location = new Point(208, 6);
        label_Month.Name = "label_Month";
        label_Month.Size = new Size(16, 13);
        label_Month.TabIndex = 4;
        label_Month.Text = "M";
        CheckBox_SecretAge.AutoSize = true;
        CheckBox_SecretAge.Location = new Point(22, 33);
        CheckBox_SecretAge.Name = "CheckBox_SecretAge";
        CheckBox_SecretAge.Size = new Size(95, 17);
        CheckBox_SecretAge.TabIndex = 3;
        CheckBox_SecretAge.Text = "Age is Secret?";
        CheckBox_SecretAge.UseVisualStyleBackColor = true;
        CheckBox_SecretAge.CheckedChanged += checkBox_SecretAge_CheckedChanged;
        label_Message.AutoSize = true;
        label_Message.Location = new Point(6, 126);
        label_Message.Name = "label_Message";
        label_Message.Size = new Size(114, 13);
        label_Message.TabIndex = 8;
        label_Message.Text = "Message (Inn Display):";
        label_Day.AutoSize = true;
        label_Day.Location = new Point(272, 6);
        label_Day.Name = "label_Day";
        label_Day.Size = new Size(15, 13);
        label_Day.TabIndex = 6;
        label_Day.Text = "D";
        _textBox_ProfileMessage.AcceptsReturn = true;
        _textBox_ProfileMessage.Location = new Point(7, 142);
        _textBox_ProfileMessage.MaxLength = 100;
        _textBox_ProfileMessage.Multiline = true;
        _textBox_ProfileMessage.Name = "_textBox_ProfileMessage";
        _textBox_ProfileMessage.Size = new Size(272, 45);
        _textBox_ProfileMessage.TabIndex = 4;
        _textBox_ProfileMessage.TextChanged += _textBox_ProfileMessage_TextChanged;
        checkBox_Explanation.AutoSize = true;
        checkBox_Explanation.Location = new Point(102, 19);
        checkBox_Explanation.Name = "checkBox_Explanation";
        checkBox_Explanation.Size = new Size(108, 17);
        checkBox_Explanation.TabIndex = 12;
        checkBox_Explanation.Text = "Explanation done";
        checkBox_Explanation.UseVisualStyleBackColor = true;
        checkBox_Explanation.CheckedChanged += checkBox_Explanation_CheckedChanged;
        checkBox_ProfileSetting.AutoSize = true;
        checkBox_ProfileSetting.Location = new Point(26, 19);
        checkBox_ProfileSetting.Name = "checkBox_ProfileSetting";
        checkBox_ProfileSetting.Size = new Size(77, 17);
        checkBox_ProfileSetting.TabIndex = 11;
        checkBox_ProfileSetting.Text = "Configured";
        checkBox_ProfileSetting.UseVisualStyleBackColor = true;
        checkBox_ProfileSetting.CheckedChanged += checkBox_ProfileSetting_CheckedChanged;
        label1.AutoSize = true;
        label1.Location = new Point(316, 40);
        label1.Name = "label1";
        label1.Size = new Size(29, 13);
        label1.TabIndex = 27;
        label1.Text = "secs";
        label2.AutoSize = true;
        label2.Location = new Point(242, 40);
        label2.Name = "label2";
        label2.Size = new Size(28, 13);
        label2.TabIndex = 25;
        label2.Text = "mins";
        label3.AutoSize = true;
        label3.Location = new Point(160, 40);
        label3.Name = "label3";
        label3.Size = new Size(33, 13);
        label3.TabIndex = 23;
        label3.Text = "hours";
        label4.AutoSize = true;
        label4.Location = new Point(19, 39);
        label4.Name = "label4";
        label4.Size = new Size(79, 13);
        label4.TabIndex = 21;
        label4.Text = "Multiplayer time";
        label5.AutoSize = true;
        label5.Location = new Point(209, 182);
        label5.Name = "label5";
        label5.Size = new Size(65, 13);
        label5.TabIndex = 44;
        label5.Text = "Battles Won";
        label6.AutoSize = true;
        label6.Location = new Point(49, 157);
        label6.Name = "label6";
        label6.Size = new Size(47, 13);
        label6.TabIndex = 46;
        label6.Text = "Alchemy";
        label7.AutoSize = true;
        label7.Location = new Point(235, 82);
        label7.Name = "label7";
        label7.Size = new Size(39, 13);
        label7.TabIndex = 48;
        label7.Text = "Battles";
        label8.AutoSize = true;
        label8.Location = new Point(233, 107);
        label8.Name = "label8";
        label8.Size = new Size(40, 13);
        label8.TabIndex = 50;
        label8.Text = "Losses";
        label9.AutoSize = true;
        label9.Location = new Point(203, 132);
        label9.Name = "label9";
        label9.Size = new Size(71, 13);
        label9.TabIndex = 52;
        label9.Text = "Run Attempts";
        label10.AutoSize = true;
        label10.Location = new Point(185, 157);
        label10.Name = "label10";
        label10.Size = new Size(89, 13);
        label10.TabIndex = 54;
        label10.Text = "Successfully Ran";
        groupBox_Gesture.Controls.Add(label11);
        groupBox_Gesture.Controls.Add(checkedListBox_GestureLearn);
        groupBox_Gesture.Location = new Point(362, 175);
        groupBox_Gesture.Name = "groupBox_Gesture";
        groupBox_Gesture.Size = new Size(432, 260);
        groupBox_Gesture.TabIndex = 15;
        groupBox_Gesture.TabStop = false;
        groupBox_Gesture.Text = "Party Tricks";
        label11.AutoSize = true;
        label11.Location = new Point(287, 7);
        label11.Name = "label11";
        label11.Size = new Size(105, 13);
        label11.TabIndex = 19;
        label11.Text = "Learned Party Tricks";
        checkedListBox_GestureLearn.FormattingEnabled = true;
        checkedListBox_GestureLearn.Items.AddRange(new object[15]
        {
            "Pray",
            "Pirouette",
            "Bow",
            "Belly Dance",
            "Royal Regards",
            "Swinedimples Salute",
            "Cap'n's Curtsy",
            "Sultry Dance",
            "Weird Dance",
            "Wallop",
            "Cheer",
            "Provoke",
            "Salute",
            "Inspiration",
            "Professor's Pose"
        });
        checkedListBox_GestureLearn.Location = new Point(290, 23);
        checkedListBox_GestureLearn.Name = "checkedListBox_GestureLearn";
        checkedListBox_GestureLearn.Size = new Size(128, 229);
        checkedListBox_GestureLearn.TabIndex = 7;
        checkedListBox_GestureLearn.ItemCheck += checkedListBox_GestureLearn_ItemCheck;
        label_SavePlace.Location = new Point(392, 15);
        label_SavePlace.Name = "label_SavePlace";
        label_SavePlace.Size = new Size(76, 13);
        label_SavePlace.TabIndex = 55;
        label_SavePlace.Text = "Save Location";
        label_SavePlace.TextAlign = ContentAlignment.MiddleRight;
        button_SelectSavePlace.SetBounds(701, 12, 45, 20);
        button_SelectSavePlace.Name = "button_SelectSavePlace";
        button_SelectSavePlace.TabIndex = 57;
        button_SelectSavePlace.Text = "Set";
        button_SelectSavePlace.UseVisualStyleBackColor = true;
        button_SelectSavePlace.Click += button_SelectSavePlace_Click;
        textBox_SavePlace.SetBounds(474, 12, 221, 20);
        textBox_SavePlace.Name = "textBox_SavePlace";
        textBox_SavePlace.ReadOnly = true;
        textBox_SavePlace.TabIndex = 59;
        label15.AutoSize = true;
        label15.Location = new Point(41, 21);
        label15.Name = "label15";
        label15.Size = new Size(48, 13);
        label15.TabIndex = 60;
        label15.Text = "X Coord:";
        _numericUpDown_IntermissionX.DecimalPlaces = 2;
        _numericUpDown_IntermissionX.Location = new Point(95, 19);
        _numericUpDown_IntermissionX.Maximum = new decimal([
            10000000,
            0,
            0,
            0
        ]);
        _numericUpDown_IntermissionX.Minimum = new decimal([
            10000000,
            0,
            0,
            int.MinValue
        ]);
        _numericUpDown_IntermissionX.Name = "_numericUpDown_IntermissionX";
        _numericUpDown_IntermissionX.Size = new Size(81, 20);
        _numericUpDown_IntermissionX.TabIndex = 61;
        _numericUpDown_IntermissionX.TextAlign = HorizontalAlignment.Right;
        _numericUpDown_IntermissionX.Value = new decimal(new int[4]);
        _numericUpDown_IntermissionX.ValueChanged += _numericUpDown_IntermissionX_ValueChanged;
        _numericUpDown_IntermissionZ.DecimalPlaces = 2;
        _numericUpDown_IntermissionZ.Location = new Point(95, 63);
        _numericUpDown_IntermissionZ.Maximum = new decimal([
            10000000,
            0,
            0,
            0
        ]);
        _numericUpDown_IntermissionZ.Minimum = new decimal([
            10000000,
            0,
            0,
            int.MinValue
        ]);
        _numericUpDown_IntermissionZ.Name = "_numericUpDown_IntermissionZ";
        _numericUpDown_IntermissionZ.Size = new Size(81, 20);
        _numericUpDown_IntermissionZ.TabIndex = 63;
        _numericUpDown_IntermissionZ.TextAlign = HorizontalAlignment.Right;
        _numericUpDown_IntermissionZ.Value = new decimal(new int[4]);
        _numericUpDown_IntermissionZ.ValueChanged += _numericUpDown_IntermissionZ_ValueChanged;
        label16.AutoSize = true;
        label16.Location = new Point(41, 65);
        label16.Name = "label16";
        label16.Size = new Size(48, 13);
        label16.TabIndex = 62;
        label16.Text = "Z Coord:";
        _numericUpDown_IntermissionY.DecimalPlaces = 2;
        _numericUpDown_IntermissionY.Location = new Point(95, 41);
        _numericUpDown_IntermissionY.Maximum = new decimal([
            10000000,
            0,
            0,
            0
        ]);
        _numericUpDown_IntermissionY.Minimum = new decimal([
            10000000,
            0,
            0,
            int.MinValue
        ]);
        _numericUpDown_IntermissionY.Name = "_numericUpDown_IntermissionY";
        _numericUpDown_IntermissionY.Size = new Size(81, 20);
        _numericUpDown_IntermissionY.TabIndex = 65;
        _numericUpDown_IntermissionY.TextAlign = HorizontalAlignment.Right;
        _numericUpDown_IntermissionY.Value = new decimal(new int[4]);
        _numericUpDown_IntermissionY.ValueChanged += _numericUpDown_IntermissionY_ValueChanged;
        label17.AutoSize = true;
        label17.Location = new Point(41, 43);
        label17.Name = "label17";
        label17.Size = new Size(48, 13);
        label17.TabIndex = 64;
        label17.Text = "Y Coord:";
        groupBox_IntermissionCoord.Controls.Add(_numericUpDown_IntermissionY);
        groupBox_IntermissionCoord.Controls.Add(_numericUpDown_IntermissionX);
        groupBox_IntermissionCoord.Controls.Add(_numericUpDown_IntermissionZ);
        groupBox_IntermissionCoord.Controls.Add(label15);
        groupBox_IntermissionCoord.Controls.Add(label17);
        groupBox_IntermissionCoord.Controls.Add(label16);
        groupBox_IntermissionCoord.Location = new Point(379, 45);
        groupBox_IntermissionCoord.Name = "groupBox_IntermissionCoord";
        groupBox_IntermissionCoord.Size = new Size(200, 94);
        groupBox_IntermissionCoord.TabIndex = 66;
        groupBox_IntermissionCoord.TabStop = false;
        groupBox_IntermissionCoord.Text = "Quick Save Coord";
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(groupBox_IntermissionCoord);
        Controls.Add(textBox_SavePlace);
        Controls.Add(button_SelectSavePlace);
        Controls.Add(label_SavePlace);
        Controls.Add(groupBox_Gesture);
        Controls.Add(groupBox_Profile);
        Controls.Add(label10);
        Controls.Add(label9);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label_medal);
        Controls.Add(label_bankMoney);
        Controls.Add(label_Money);
        Controls.Add(label1);
        Controls.Add(label2);
        Controls.Add(label3);
        Controls.Add(label4);
        Controls.Add(label_Second);
        Controls.Add(label_Minute);
        Controls.Add(label_Hour);
        Controls.Add(label_PlayTime);
        Name = nameof(BasisDataControl);
        Size = new Size(840, 507);
        groupBox_Profile.ResumeLayout(false);
        groupBox_Profile.PerformLayout();
        panel_Profile.ResumeLayout(false);
        panel_Profile.PerformLayout();
        groupBox_Gesture.ResumeLayout(false);
        groupBox_Gesture.PerformLayout();
        _numericUpDown_IntermissionX.EndInit();
        _numericUpDown_IntermissionZ.EndInit();
        _numericUpDown_IntermissionY.EndInit();
        groupBox_IntermissionCoord.ResumeLayout(false);
        groupBox_IntermissionCoord.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    protected override void OnValueUpdate()
    {
        var basisData = SaveDataManager.Instance.SaveData.BasisData;
        panel_Profile.Enabled = basisData.ProfileSetting;
        checkBox_ProfileSetting.Checked = basisData.ProfileSetting;
        checkBox_Explanation.Checked = basisData.ProfileExplanation;
        comboBox_Sex.SelectedIndex = basisData.ProfileSex;
        comboBox_Tone.SelectedIndex = basisData.ProfileTone;
        checkBox_ToneSetting.Checked = basisData.ProfileToneSetting;
        NumericUpDown_Hour.Value = basisData.PlayTimeHour.Value;
        NumericUpDown_Minute.Value = basisData.PlayTimeMinute.Value;
        NumericUpDown_Second.Value = basisData.PlayTimeSecond.Value;
        NumericUpDown_MultiPlayTimeHour.Value = basisData.MultiPlayTimeHour.Value;
        NumericUpDown_MultiPlayTimeMinute.Value = basisData.MultiPlayTimeMinute.Value;
        NumericUpDown_MultiPlayTimeSecond.Value = basisData.MultiPlayTimeSecond.Value;
        NumericUpDown_Money.Value = basisData.Money.Value;
        NumericUpDown_BankMoney.Value = basisData.BankMoney.Value;
        NumericUpDown_Medal.Value = basisData.Medal.Value;
        NumericUpDown_BattleCount.Value = basisData.BattleCount;
        NumericUpDown_LoseCount.Value = basisData.LoseCount;
        NumericUpDown_EscapeCount.Value = basisData.EscapeCount;
        NumericUpDown_EscapeSuccessCount.Value = basisData.EscapeSuccessCount;
        NumericUpDown_VictoryCount.Value = basisData.VictoryCount;
        NumericUpDown_AlchemyCount.Value = basisData.AlchemyCount.Value;
        NumericUpDown_ProfileBirthYear.Value = basisData.ProfileBirthYear;
        NumericUpDown_ProfileBirthMonth.Value = basisData.ProfileBirthMonth;
        NumericUpDown_ProfileBirthDay.Value = basisData.ProfileBirthDay;
        _textBox_ProfileAddress.Text = basisData.Address.Name;
        RenewalHanle(basisData);
        _textBox_ProfileMessage.Text = basisData.ProfileMessage.Value;
        CheckBox_SecretAge.Checked = basisData.ProfileSecretAge;
        _comboBox_GestureUp.SelectedIndex = GestureList.List[basisData.GestureUp].Index;
        _comboBox_GestureLeft.SelectedIndex = GestureList.List[basisData.GestureLeft].Index;
        _comboBox_GestureRight.SelectedIndex = GestureList.List[basisData.GestureRight].Index;
        _comboBox_GestureDown1.SelectedIndex = GestureList.List[basisData.GestureDown1].Index;
        _comboBox_GestureDown2.SelectedIndex = GestureList.List[basisData.GestureDown2].Index;
        _comboBox_GestureDown3.SelectedIndex = GestureList.List[basisData.GestureDown3].Index;
        _comboBox_GestureDown4.SelectedIndex = GestureList.List[basisData.GestureDown4].Index;
        for (var index = 0; index < 15; ++index)
            checkedListBox_GestureLearn.SetItemChecked(index, basisData.IsGestureLearn(index));
        if (SaveDataManager.Instance.SelectedDataIndex == 1)
        {
            label_SavePlace.Text = "Quicksave Loc.";
            if (basisData.IntermissionPlace != null)
                textBox_SavePlace.Text = basisData.IntermissionPlace.Name;
            else
                textBox_SavePlace.Text = string.Empty;
            groupBox_IntermissionCoord.Enabled = true;
            _numericUpDown_IntermissionX.Value = (decimal)(basisData.IntermissionX.Value / 100f);
            _numericUpDown_IntermissionY.Value = (decimal)(basisData.IntermissionY.Value / 100f);
            _numericUpDown_IntermissionZ.Value = (decimal)(basisData.IntermissionZ.Value / 100f);
        }
        else
        {
            label_SavePlace.Text = "Save Location";
            if (basisData.SavePlace != null)
                textBox_SavePlace.Text = basisData.SavePlace.Name;
            else
                textBox_SavePlace.Text = string.Empty;
            groupBox_IntermissionCoord.Enabled = false;
            _numericUpDown_IntermissionX.Value = 0M;
            _numericUpDown_IntermissionY.Value = 0M;
            _numericUpDown_IntermissionZ.Value = 0M;
        }
    }

    private void RenewalHanle(BasisData basisData)
    {
        _textBox_ProfileHandle.Text = string.Empty;
        if (basisData.Handle == null)
            return;
        if (basisData.Handle.Job != null)
        {
            _textBox_ProfileHandle.Text = basisData.Handle.Job.Name;
        }
        else
        {
            if (basisData.Handle.Title == null)
                return;
            if (basisData.ProfileSex == 0)
            {
                _textBox_ProfileHandle.Text = basisData.Handle.Title.MaleTitleName;
            }
            else
            {
                if (basisData.ProfileSex != 1)
                    return;
                _textBox_ProfileHandle.Text = basisData.Handle.Title.LadyTitleName;
            }
        }
    }

    private void _numericUpDown_Hour_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.PlayTimeHour.Value = (ushort)NumericUpDown_Hour.Value;
    }

    private void _numericUpDown_Minute_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.PlayTimeMinute.Value = (byte)NumericUpDown_Minute.Value;
    }

    private void _numericUpDown_Second_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.PlayTimeSecond.Value = (byte)NumericUpDown_Second.Value;
    }

    private void _numericUpDown_Money_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.Money.Value = (uint)NumericUpDown_Money.Value;
    }

    private void _numericUpDown_BankMoney_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.BankMoney.Value = (uint)NumericUpDown_BankMoney.Value;
    }

    private void _numericUpDown_Medal_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.Medal.Value = (uint)NumericUpDown_Medal.Value;
    }

    private void _numericUpDown_MultiPlayTimeHour_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.MultiPlayTimeHour.Value =
            (ushort)NumericUpDown_MultiPlayTimeHour.Value;
    }

    private void _numericUpDown_MultiPlayTimeMinute_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.MultiPlayTimeMinute.Value =
            (byte)NumericUpDown_MultiPlayTimeMinute.Value;
    }

    private void _numericUpDown_MultiPlayTimeSecond_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.MultiPlayTimeSecond.Value =
            (byte)NumericUpDown_MultiPlayTimeSecond.Value;
    }

    private void _numericUpDown_ProfileBirthYear_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileBirthYear = (ushort)NumericUpDown_ProfileBirthYear.Value;
    }

    private void _numericUpDown_ProfileBirthMonth_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileBirthMonth = (byte)NumericUpDown_ProfileBirthMonth.Value;
    }

    private void _numericUpDown_ProfileBirthDay_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileBirthDay = (byte)NumericUpDown_ProfileBirthDay.Value;
    }

    private void _textBox_ProfileMessage_TextChanged(object sender, EventArgs e)
    {
        Encoding encoding = new DQ9Encoding();
        var bytes = encoding.GetBytes(_textBox_ProfileMessage.Text);
        if (bytes.Length > SaveDataManager.Instance.SaveData.BasisData.ProfileMessage.MaxLength)
        {
            _textBox_ProfileMessage.Text = encoding.GetString(bytes, 0,
                SaveDataManager.Instance.SaveData.BasisData.ProfileMessage.MaxLength);
            _textBox_ProfileMessage.SelectionStart = _textBox_ProfileMessage.TextLength;
        }
        else
        {
            _textBox_ProfileMessage.Text = encoding.GetString(bytes, 0, bytes.Length);
        }

        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileMessage.Value = _textBox_ProfileMessage.Text;
    }

    private void checkBox_SecretAge_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileSecretAge = CheckBox_SecretAge.Checked;
    }

    private void _numericUpDown_VictoryCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.VictoryCount = (uint)NumericUpDown_VictoryCount.Value;
    }

    private void _numericUpDown_AlchemyCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.AlchemyCount.Value = (int)NumericUpDown_AlchemyCount.Value;
    }

    private void _numericUpDown_BattleCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.BattleCount = (uint)NumericUpDown_BattleCount.Value;
    }

    private void _numericUpDown_LoseCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.LoseCount = (uint)NumericUpDown_LoseCount.Value;
    }

    private void _numericUpDown_EscapeCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.EscapeCount = (uint)NumericUpDown_EscapeCount.Value;
    }

    private void _numericUpDown_EscapeSuccessCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.EscapeSuccessCount = (uint)NumericUpDown_EscapeSuccessCount.Value;
    }

    private void comboBox_Gesture_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || !(sender is VisionComboBox visionComboBox))
            return;
        switch ((int)visionComboBox.Tag)
        {
            case 0:
                SaveDataManager.Instance.SaveData.BasisData.GestureUp = (byte)visionComboBox.SelectedIndex;
                break;
            case 1:
                SaveDataManager.Instance.SaveData.BasisData.GestureLeft = (byte)visionComboBox.SelectedIndex;
                break;
            case 2:
                SaveDataManager.Instance.SaveData.BasisData.GestureRight = (byte)visionComboBox.SelectedIndex;
                break;
            case 3:
                SaveDataManager.Instance.SaveData.BasisData.GestureDown1 = (byte)visionComboBox.SelectedIndex;
                break;
            case 4:
                SaveDataManager.Instance.SaveData.BasisData.GestureDown2 = (byte)visionComboBox.SelectedIndex;
                break;
            case 5:
                SaveDataManager.Instance.SaveData.BasisData.GestureDown3 = (byte)visionComboBox.SelectedIndex;
                break;
            case 6:
                SaveDataManager.Instance.SaveData.BasisData.GestureDown4 = (byte)visionComboBox.SelectedIndex;
                break;
        }
    }

    private void checkedListBox_GestureLearn_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.SetGestureLearn(e.Index, e.NewValue == CheckState.Checked);
    }

    private void checkBox_ProfileSetting_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileSetting = checkBox_ProfileSetting.Checked;
        panel_Profile.Enabled = checkBox_ProfileSetting.Checked;
    }

    private void checkBox_Explanation_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileExplanation = checkBox_Explanation.Checked;
    }

    private void comboBox_Sex_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileSex = (byte)comboBox_Sex.SelectedIndex;
        RenewalHanle(SaveDataManager.Instance.SaveData.BasisData);
    }

    private void comboBox_Tone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileTone = (byte)comboBox_Tone.SelectedIndex;
    }

    private void checkBox_ToneSetting_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.ProfileToneSetting = checkBox_ToneSetting.Checked;
    }

    private void button_SelectSavePlace_Click(object sender, EventArgs e)
    {
        if (!(sender is Button button))
            return;
        using (var placeSelectWindow = new SavePlaceSelectWindow(SaveDataManager.Instance.SelectedDataIndex == 0))
        {
            placeSelectWindow.Location = PointToScreen(new Point(button.Right, button.Bottom));
            if (placeSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            var selectedSavePlace = placeSelectWindow.SelectedSavePlace;
            SaveDataManager.Instance.SaveData.BasisData.SavePlace = selectedSavePlace;
            textBox_SavePlace.Text = selectedSavePlace.Name;
        }
    }

    private void _numericUpDown_IntermissionX_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.IntermissionX.Value =
            (int)(_numericUpDown_IntermissionX.Value * 100M);
    }

    private void _numericUpDown_IntermissionY_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.IntermissionY.Value =
            (int)(_numericUpDown_IntermissionY.Value * 100M);
    }

    private void _numericUpDown_IntermissionZ_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.BasisData.IntermissionZ.Value =
            (int)(_numericUpDown_IntermissionZ.Value * 100M);
    }

    private void button_SelectProfileAddress_Click(object sender, EventArgs e)
    {
        using (var addressSelectWindow = new AddressSelectWindow())
        {
            addressSelectWindow.Location = PointToScreen(new Point(
                groupBox_Profile.Left + panel_Profile.Left + button_SelectProfileAddress.Right,
                groupBox_Profile.Top + panel_Profile.Top + button_SelectProfileAddress.Bottom));
            if (addressSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.BasisData.Address = addressSelectWindow.SelectedAddress;
            OnValueUpdate();
        }
    }

    private void button_SelectProfileHandle_Click(object sender, EventArgs e)
    {
        var basisData = SaveDataManager.Instance.SaveData.BasisData;
        using (var handleSelectWindow = new HandleSelectWindow(basisData.ProfileSex))
        {
            handleSelectWindow.Location = PointToScreen(new Point(
                groupBox_Profile.Left + panel_Profile.Left + button_SelectProfileHandle.Right,
                groupBox_Profile.Top + panel_Profile.Top + button_SelectProfileHandle.Bottom));
            if (handleSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            var selectedHandle = handleSelectWindow.SelectedHandle;
            basisData.Handle = selectedHandle;
            OnValueUpdate();
        }
    }
}