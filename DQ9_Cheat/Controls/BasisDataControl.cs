// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.BasisDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using FriedGinger.DQCheat;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class BasisDataControl : DataControlBase
  {
    private IContainer components;
    private Label label_Second;
    private Label label_Minute;
    private Label label_Hour;
    private Label label_PlayTime;
    private Label label_Money;
    private Label label_bankMoney;
    private Label label_medal;
    private GroupBox groupBox_Profile;
    private Label label_BirthDay;
    private Label label_Month;
    private Label label_Year;
    private Label label_Day;
    private Label label_Message;
    private TextBox _textBox_ProfileMessage;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private CheckBox _checkBox_SecretAge;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private JS_GroupBox groupBox_Gesture;
    private CheckedListBox checkedListBox_GestureLearn;
    private Label label11;
    private CheckBox checkBox_Explanation;
    private CheckBox checkBox_ProfileSetting;
    private ComboBox comboBox_Sex;
    private Label label12;
    private JS_Panel panel_Profile;
    private Label label13;
    private ComboBox comboBox_Tone;
    private CheckBox checkBox_ToneSetting;
    private Label label_SavePlace;
    private Button button_SelectSavePlace;
    private TextBox textBox_SavePlace;
    private Label label15;
    private SafeNumericUpDown _numericUpDown_IntermissionX;
    private SafeNumericUpDown _numericUpDown_IntermissionZ;
    private Label label16;
    private SafeNumericUpDown _numericUpDown_IntermissionY;
    private Label label17;
    private JS_GroupBox groupBox_IntermissionCoord;
    private Button button_SelectProfileHandle;
    private Button button_SelectProfileAddress;
    private TextBox _textBox_ProfileHandle;
    private Label label18;
    private TextBox _textBox_ProfileAddress;
    private Label label14;
    private TextBox _textbox_test = new TextBox();
    private VisionNumericUpDown _numericUpDown_Hour;
    private VisionNumericUpDown _numericUpDown_Minute;
    private VisionNumericUpDown _numericUpDown_Second;
    private VisionNumericUpDown _numericUpDown_MultiPlayTimeHour;
    private VisionNumericUpDown _numericUpDown_MultiPlayTimeMinute;
    private VisionNumericUpDown _numericUpDown_MultiPlayTimeSecond;
    private VisionNumericUpDown _numericUpDown_Money;
    private VisionNumericUpDown _numericUpDown_BankMoney;
    private VisionNumericUpDown _numericUpDown_Medal;
    private VisionNumericUpDown _numericUpDown_AlchemyCount;
    private VisionNumericUpDown _numericUpDown_BattleCount;
    private VisionNumericUpDown _numericUpDown_LoseCount;
    private VisionNumericUpDown _numericUpDown_EscapeCount;
    private VisionNumericUpDown _numericUpDown_EscapeSuccessCount;
    private VisionNumericUpDown _numericUpDown_VictoryCount;
    private VisionNumericUpDown _numericUpDown_ProfileBirthYear;
    private VisionNumericUpDown _numericUpDown_ProfileBirthMonth;
    private VisionNumericUpDown _numericUpDown_ProfileBirthDay;
    private VisionComboBox _comboBox_GestureUp;
    private VisionComboBox _comboBox_GestureLeft;
    private VisionComboBox _comboBox_GestureRight;
    private VisionComboBox _comboBox_GestureDown1;
    private VisionComboBox _comboBox_GestureDown2;
    private VisionComboBox _comboBox_GestureDown3;
    private VisionComboBox _comboBox_GestureDown4;

    public BasisDataControl()
    {
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      this.SuspendLayout();
      this._comboBox_GestureUp = new VisionComboBox(81, 28, 125, 21);
      this._comboBox_GestureUp.SelectedIndexChanged += new EventHandler(this.comboBox_Gesture_SelectedIndexChanged);
      this._comboBox_GestureLeft = new VisionComboBox(6, 69, 125, 21);
      this._comboBox_GestureLeft.SelectedIndexChanged += new EventHandler(this.comboBox_Gesture_SelectedIndexChanged);
      this._comboBox_GestureRight = new VisionComboBox(148, 69, 125, 21);
      this._comboBox_GestureRight.SelectedIndexChanged += new EventHandler(this.comboBox_Gesture_SelectedIndexChanged);
      this._comboBox_GestureDown1 = new VisionComboBox(81, 108, 125, 21);
      this._comboBox_GestureDown1.SelectedIndexChanged += new EventHandler(this.comboBox_Gesture_SelectedIndexChanged);
      this._comboBox_GestureDown2 = new VisionComboBox(81, 132, 125, 21);
      this._comboBox_GestureDown2.SelectedIndexChanged += new EventHandler(this.comboBox_Gesture_SelectedIndexChanged);
      this._comboBox_GestureDown3 = new VisionComboBox(81, 156, 125, 21);
      this._comboBox_GestureDown3.SelectedIndexChanged += new EventHandler(this.comboBox_Gesture_SelectedIndexChanged);
      this._comboBox_GestureDown4 = new VisionComboBox(81, 180, 125, 21);
      this._comboBox_GestureDown4.SelectedIndexChanged += new EventHandler(this.comboBox_Gesture_SelectedIndexChanged);
      foreach (Gesture gesture in GestureList.List)
      {
        this._comboBox_GestureUp.Items.Add((object) gesture);
        this._comboBox_GestureLeft.Items.Add((object) gesture);
        this._comboBox_GestureRight.Items.Add((object) gesture);
        this._comboBox_GestureDown1.Items.Add((object) gesture);
        this._comboBox_GestureDown2.Items.Add((object) gesture);
        this._comboBox_GestureDown3.Items.Add((object) gesture);
        this._comboBox_GestureDown4.Items.Add((object) gesture);
      }
      int num1 = 0;
      VisionComboBox comboBoxGestureUp = this._comboBox_GestureUp;
      int num2 = num1;
      int num3 = num2 + 1;
      // ISSUE: variable of a boxed type
      int local1 = num2;
      comboBoxGestureUp.Tag = (object) local1;
      VisionComboBox comboBoxGestureLeft = this._comboBox_GestureLeft;
      int num4 = num3;
      int num5 = num4 + 1;
      // ISSUE: variable of a boxed type
      int local2 = num4;
      comboBoxGestureLeft.Tag = (object) local2;
      VisionComboBox comboBoxGestureRight = this._comboBox_GestureRight;
      int num6 = num5;
      int num7 = num6 + 1;
      // ISSUE: variable of a boxed type
      int local3 = num6;
      comboBoxGestureRight.Tag = (object) local3;
      VisionComboBox comboBoxGestureDown1 = this._comboBox_GestureDown1;
      int num8 = num7;
      int num9 = num8 + 1;
      // ISSUE: variable of a boxed type
      int local4 = num8;
      comboBoxGestureDown1.Tag = (object) local4;
      VisionComboBox comboBoxGestureDown2 = this._comboBox_GestureDown2;
      int num10 = num9;
      int num11 = num10 + 1;
      // ISSUE: variable of a boxed type
      int local5 = num10;
      comboBoxGestureDown2.Tag = (object) local5;
      VisionComboBox comboBoxGestureDown3 = this._comboBox_GestureDown3;
      int num12 = num11;
      int num13 = num12 + 1;
      // ISSUE: variable of a boxed type
      int local6 = num12;
      comboBoxGestureDown3.Tag = (object) local6;
      VisionComboBox comboBoxGestureDown4 = this._comboBox_GestureDown4;
      int num14 = num13;
      int num15 = num14 + 1;
      // ISSUE: variable of a boxed type
      int local7 = num14;
      comboBoxGestureDown4.Tag = (object) local7;
      this.groupBox_Gesture.AddVisionControl((VisionControlBase) this._comboBox_GestureUp);
      this.groupBox_Gesture.AddVisionControl((VisionControlBase) this._comboBox_GestureLeft);
      this.groupBox_Gesture.AddVisionControl((VisionControlBase) this._comboBox_GestureRight);
      this.groupBox_Gesture.AddVisionControl((VisionControlBase) this._comboBox_GestureDown1);
      this.groupBox_Gesture.AddVisionControl((VisionControlBase) this._comboBox_GestureDown2);
      this.groupBox_Gesture.AddVisionControl((VisionControlBase) this._comboBox_GestureDown3);
      this.groupBox_Gesture.AddVisionControl((VisionControlBase) this._comboBox_GestureDown4);
      this._numericUpDown_Hour = new VisionNumericUpDown(98, 12, 60, 20);
      this._numericUpDown_Hour.ValueChanged += new EventHandler(this._numericUpDown_Hour_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_Hour);
      this._numericUpDown_Minute = new VisionNumericUpDown(199, 12, 41, 20);
      this._numericUpDown_Minute.ValueChanged += new EventHandler(this._numericUpDown_Minute_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_Minute);
      this._numericUpDown_Second = new VisionNumericUpDown(273, 12, 41, 20);
      this._numericUpDown_Second.ValueChanged += new EventHandler(this._numericUpDown_Second_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_Second);
      this._numericUpDown_MultiPlayTimeHour = new VisionNumericUpDown(98, 37, 60, 20);
      this._numericUpDown_MultiPlayTimeHour.ValueChanged += new EventHandler(this._numericUpDown_MultiPlayTimeHour_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_MultiPlayTimeHour);
      this._numericUpDown_MultiPlayTimeMinute = new VisionNumericUpDown(199, 37, 41, 20);
      this._numericUpDown_MultiPlayTimeMinute.ValueChanged += new EventHandler(this._numericUpDown_MultiPlayTimeMinute_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_MultiPlayTimeMinute);
      this._numericUpDown_MultiPlayTimeSecond = new VisionNumericUpDown(273, 37, 41, 20);
      this._numericUpDown_MultiPlayTimeSecond.ValueChanged += new EventHandler(this._numericUpDown_MultiPlayTimeSecond_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_MultiPlayTimeSecond);
      this._numericUpDown_Money = new VisionNumericUpDown(98, 80, 80, 20);
      this._numericUpDown_Money.ValueChanged += new EventHandler(this._numericUpDown_Money_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_Money);
      this._numericUpDown_BankMoney = new VisionNumericUpDown(98, 105, 80, 20);
      this._numericUpDown_BankMoney.ValueChanged += new EventHandler(this._numericUpDown_BankMoney_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_BankMoney);
      this._numericUpDown_Medal = new VisionNumericUpDown(98, 130, 80, 20);
      this._numericUpDown_Medal.ValueChanged += new EventHandler(this._numericUpDown_Medal_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_Medal);
      this._numericUpDown_AlchemyCount = new VisionNumericUpDown(98, 155, 80, 20);
      this._numericUpDown_AlchemyCount.ValueChanged += new EventHandler(this._numericUpDown_AlchemyCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_AlchemyCount);
      this._numericUpDown_BattleCount = new VisionNumericUpDown(276, 80, 70, 20);
      this._numericUpDown_BattleCount.ValueChanged += new EventHandler(this._numericUpDown_BattleCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_BattleCount);
      this._numericUpDown_LoseCount = new VisionNumericUpDown(276, 105, 70, 20);
      this._numericUpDown_LoseCount.ValueChanged += new EventHandler(this._numericUpDown_LoseCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_LoseCount);
      this._numericUpDown_EscapeCount = new VisionNumericUpDown(276, 130, 70, 20);
      this._numericUpDown_EscapeCount.ValueChanged += new EventHandler(this._numericUpDown_EscapeCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_EscapeCount);
      this._numericUpDown_EscapeSuccessCount = new VisionNumericUpDown(276, 155, 70, 20);
      this._numericUpDown_EscapeSuccessCount.ValueChanged += new EventHandler(this._numericUpDown_EscapeSuccessCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_EscapeSuccessCount);
      this._numericUpDown_VictoryCount = new VisionNumericUpDown(276, 180, 70, 20);
      this._numericUpDown_VictoryCount.ValueChanged += new EventHandler(this._numericUpDown_VictoryCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDown_VictoryCount);
      this._numericUpDown_ProfileBirthYear = new VisionNumericUpDown(88, 4, 58, 20);
      this._numericUpDown_ProfileBirthYear.ValueChanged += new EventHandler(this._numericUpDown_ProfileBirthYear_ValueChanged);
      this.panel_Profile.AddVisionControl((VisionControlBase) this._numericUpDown_ProfileBirthYear);
      this._numericUpDown_ProfileBirthMonth = new VisionNumericUpDown(166, 4, 41, 20);
      this._numericUpDown_ProfileBirthMonth.ValueChanged += new EventHandler(this._numericUpDown_ProfileBirthMonth_ValueChanged);
      this.panel_Profile.AddVisionControl((VisionControlBase) this._numericUpDown_ProfileBirthMonth);
      this._numericUpDown_ProfileBirthDay = new VisionNumericUpDown(230, 4, 41, 20);
      this._numericUpDown_ProfileBirthDay.ValueChanged += new EventHandler(this._numericUpDown_ProfileBirthDay_ValueChanged);
      this.panel_Profile.AddVisionControl((VisionControlBase) this._numericUpDown_ProfileBirthDay);
      this.ResumeLayout(false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label_Second = new Label();
      this.label_Minute = new Label();
      this.label_Hour = new Label();
      this.label_PlayTime = new Label();
      this.label_Money = new Label();
      this.label_bankMoney = new Label();
      this.label_medal = new Label();
      this.groupBox_Profile = new GroupBox();
      this.panel_Profile = new JS_Panel();
      this.button_SelectProfileHandle = new Button();
      this.button_SelectProfileAddress = new Button();
      this._textBox_ProfileHandle = new TextBox();
      this.label18 = new Label();
      this._textBox_ProfileAddress = new TextBox();
      this.label14 = new Label();
      this.checkBox_ToneSetting = new CheckBox();
      this.label13 = new Label();
      this.comboBox_Tone = new ComboBox();
      this.label_BirthDay = new Label();
      this.label_Year = new Label();
      this.comboBox_Sex = new ComboBox();
      this.label12 = new Label();
      this.label_Month = new Label();
      this._checkBox_SecretAge = new CheckBox();
      this.label_Message = new Label();
      this.label_Day = new Label();
      this._textBox_ProfileMessage = new TextBox();
      this.checkBox_Explanation = new CheckBox();
      this.checkBox_ProfileSetting = new CheckBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.groupBox_Gesture = new JS_GroupBox();
      this.label11 = new Label();
      this.checkedListBox_GestureLearn = new CheckedListBox();
      this.label_SavePlace = new Label();
      this.button_SelectSavePlace = new Button();
      this.textBox_SavePlace = new TextBox();
      this.label15 = new Label();
      this._numericUpDown_IntermissionX = new SafeNumericUpDown();
      this._numericUpDown_IntermissionZ = new SafeNumericUpDown();
      this.label16 = new Label();
      this._numericUpDown_IntermissionY = new SafeNumericUpDown();
      this.label17 = new Label();
      this.groupBox_IntermissionCoord = new JS_GroupBox();
      this.groupBox_Profile.SuspendLayout();
      this.panel_Profile.SuspendLayout();
      this.groupBox_Gesture.SuspendLayout();
      this._numericUpDown_IntermissionX.BeginInit();
      this._numericUpDown_IntermissionZ.BeginInit();
      this._numericUpDown_IntermissionY.BeginInit();
      this.groupBox_IntermissionCoord.SuspendLayout();
      this.SuspendLayout();
      this.label_Second.AutoSize = true;
      this.label_Second.Location = new Point(316, 15);
      this.label_Second.Name = "label_Second";
      this.label_Second.Size = new Size(29, 13);
      this.label_Second.TabIndex = 13;
      this.label_Second.Text = "secs";
      this.label_Minute.AutoSize = true;
      this.label_Minute.Location = new Point(242, 15);
      this.label_Minute.Name = "label_Minute";
      this.label_Minute.Size = new Size(28, 13);
      this.label_Minute.TabIndex = 11;
      this.label_Minute.Text = "mins";
      this.label_Hour.AutoSize = true;
      this.label_Hour.Location = new Point(160, 15);
      this.label_Hour.Name = "label_Hour";
      this.label_Hour.Size = new Size(33, 13);
      this.label_Hour.TabIndex = 9;
      this.label_Hour.Text = "hours";
      this.label_PlayTime.AutoSize = true;
      this.label_PlayTime.Location = new Point(49, 15);
      this.label_PlayTime.Name = "label_PlayTime";
      this.label_PlayTime.Size = new Size(49, 13);
      this.label_PlayTime.TabIndex = 7;
      this.label_PlayTime.Text = "Play time";
      this.label_Money.AutoSize = true;
      this.label_Money.Location = new Point(57, 82);
      this.label_Money.Name = "label_Money";
      this.label_Money.Size = new Size(39, 13);
      this.label_Money.TabIndex = 14;
      this.label_Money.Text = "Money";
      this.label_bankMoney.AutoSize = true;
      this.label_bankMoney.Location = new Point(64, 107);
      this.label_bankMoney.Name = "label_bankMoney";
      this.label_bankMoney.Size = new Size(32, 13);
      this.label_bankMoney.TabIndex = 16;
      this.label_bankMoney.Text = "Bank";
      this.label_medal.AutoSize = true;
      this.label_medal.Location = new Point(34, 132);
      this.label_medal.Name = "label_medal";
      this.label_medal.Size = new Size(62, 13);
      this.label_medal.TabIndex = 18;
      this.label_medal.Text = "Mini medals";
      this.groupBox_Profile.Controls.Add((Control) this.panel_Profile);
      this.groupBox_Profile.Controls.Add((Control) this.checkBox_Explanation);
      this.groupBox_Profile.Controls.Add((Control) this.checkBox_ProfileSetting);
      this.groupBox_Profile.Location = new Point(9, 203);
      this.groupBox_Profile.Name = "groupBox_Profile";
      this.groupBox_Profile.Size = new Size(324, 232);
      this.groupBox_Profile.TabIndex = 16;
      this.groupBox_Profile.TabStop = false;
      this.groupBox_Profile.Text = "Profile";
      this.panel_Profile.Controls.Add((Control) this.button_SelectProfileHandle);
      this.panel_Profile.Controls.Add((Control) this.button_SelectProfileAddress);
      this.panel_Profile.Controls.Add((Control) this._textBox_ProfileHandle);
      this.panel_Profile.Controls.Add((Control) this.label18);
      this.panel_Profile.Controls.Add((Control) this._textBox_ProfileAddress);
      this.panel_Profile.Controls.Add((Control) this.label14);
      this.panel_Profile.Controls.Add((Control) this.checkBox_ToneSetting);
      this.panel_Profile.Controls.Add((Control) this.label13);
      this.panel_Profile.Controls.Add((Control) this.comboBox_Tone);
      this.panel_Profile.Controls.Add((Control) this.label_BirthDay);
      this.panel_Profile.Controls.Add((Control) this.label_Year);
      this.panel_Profile.Controls.Add((Control) this.comboBox_Sex);
      this.panel_Profile.Controls.Add((Control) this.label12);
      this.panel_Profile.Controls.Add((Control) this.label_Month);
      this.panel_Profile.Controls.Add((Control) this._checkBox_SecretAge);
      this.panel_Profile.Controls.Add((Control) this.label_Message);
      this.panel_Profile.Controls.Add((Control) this.label_Day);
      this.panel_Profile.Controls.Add((Control) this._textBox_ProfileMessage);
      this.panel_Profile.Location = new Point(6, 35);
      this.panel_Profile.Name = "panel_Profile";
      this.panel_Profile.Size = new Size(305, 191);
      this.panel_Profile.TabIndex = 57;
      this.button_SelectProfileHandle.Location = new Point(215, 102);
      this.button_SelectProfileHandle.Name = "button_SelectProfileHandle";
      this.button_SelectProfileHandle.Size = new Size(45, 20);
      this.button_SelectProfileHandle.TabIndex = 59;
      this.button_SelectProfileHandle.Text = "Set";
      this.button_SelectProfileHandle.UseVisualStyleBackColor = true;
      this.button_SelectProfileHandle.Click += new EventHandler(this.button_SelectProfileHandle_Click);
      this.button_SelectProfileAddress.Location = new Point(215, 79);
      this.button_SelectProfileAddress.Name = "button_SelectProfileAddress";
      this.button_SelectProfileAddress.Size = new Size(45, 20);
      this.button_SelectProfileAddress.TabIndex = 58;
      this.button_SelectProfileAddress.Text = "Set";
      this.button_SelectProfileAddress.UseVisualStyleBackColor = true;
      this.button_SelectProfileAddress.Click += new EventHandler(this.button_SelectProfileAddress_Click);
      this._textBox_ProfileHandle.Location = new Point(88, 102);
      this._textBox_ProfileHandle.Name = "_textBox_ProfileHandle";
      this._textBox_ProfileHandle.ReadOnly = true;
      this._textBox_ProfileHandle.Size = new Size(121, 20);
      this._textBox_ProfileHandle.TabIndex = 17;
      this.label18.AutoSize = true;
      this.label18.Location = new Point(60, 105);
      this.label18.Name = "label18";
      this.label18.Size = new Size(27, 13);
      this.label18.TabIndex = 16;
      this.label18.Text = "Title";
      this._textBox_ProfileAddress.Location = new Point(88, 79);
      this._textBox_ProfileAddress.Name = "_textBox_ProfileAddress";
      this._textBox_ProfileAddress.ReadOnly = true;
      this._textBox_ProfileAddress.Size = new Size(121, 20);
      this._textBox_ProfileAddress.TabIndex = 15;
      this.label14.AutoSize = true;
      this.label14.Location = new Point(39, 82);
      this.label14.Name = "label14";
      this.label14.Size = new Size(48, 13);
      this.label14.TabIndex = 14;
      this.label14.Text = "Location";
      this.checkBox_ToneSetting.AutoSize = true;
      this.checkBox_ToneSetting.Location = new Point(215, 58);
      this.checkBox_ToneSetting.Name = "checkBox_ToneSetting";
      this.checkBox_ToneSetting.Size = new Size(77, 17);
      this.checkBox_ToneSetting.TabIndex = 13;
      this.checkBox_ToneSetting.Text = "Configured";
      this.checkBox_ToneSetting.UseVisualStyleBackColor = true;
      this.checkBox_ToneSetting.CheckedChanged += new EventHandler(this.checkBox_ToneSetting_CheckedChanged);
      this.label13.AutoSize = true;
      this.label13.Location = new Point(17, 59);
      this.label13.Name = "label13";
      this.label13.Size = new Size(70, 13);
      this.label13.TabIndex = 12;
      this.label13.Text = "Speech Style";
      this.comboBox_Tone.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Tone.FormattingEnabled = true;
      this.comboBox_Tone.Items.AddRange(new object[16]
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
      this.comboBox_Tone.Location = new Point(88, 55);
      this.comboBox_Tone.Name = "comboBox_Tone";
      this.comboBox_Tone.Size = new Size(121, 21);
      this.comboBox_Tone.TabIndex = 11;
      this.comboBox_Tone.SelectedIndexChanged += new EventHandler(this.comboBox_Tone_SelectedIndexChanged);
      this.label_BirthDay.AutoSize = true;
      this.label_BirthDay.Location = new Point(41, 6);
      this.label_BirthDay.Name = "label_BirthDay";
      this.label_BirthDay.Size = new Size(45, 13);
      this.label_BirthDay.TabIndex = 0;
      this.label_BirthDay.Text = "Birthday";
      this.label_Year.AutoSize = true;
      this.label_Year.Location = new Point(147, 6);
      this.label_Year.Name = "label_Year";
      this.label_Year.Size = new Size(14, 13);
      this.label_Year.TabIndex = 2;
      this.label_Year.Text = "Y";
      this.comboBox_Sex.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Sex.FormattingEnabled = true;
      this.comboBox_Sex.Items.AddRange(new object[2]
      {
        (object) "Male",
        (object) "Female"
      });
      this.comboBox_Sex.Location = new Point(177, 31);
      this.comboBox_Sex.Name = "comboBox_Sex";
      this.comboBox_Sex.Size = new Size(64, 21);
      this.comboBox_Sex.TabIndex = 10;
      this.comboBox_Sex.SelectedIndexChanged += new EventHandler(this.comboBox_Sex_SelectedIndexChanged);
      this.label12.AutoSize = true;
      this.label12.Location = new Point(134, 34);
      this.label12.Name = "label12";
      this.label12.Size = new Size(42, 13);
      this.label12.TabIndex = 9;
      this.label12.Text = "Gender";
      this.label_Month.AutoSize = true;
      this.label_Month.Location = new Point(208, 6);
      this.label_Month.Name = "label_Month";
      this.label_Month.Size = new Size(16, 13);
      this.label_Month.TabIndex = 4;
      this.label_Month.Text = "M";
      this._checkBox_SecretAge.AutoSize = true;
      this._checkBox_SecretAge.Location = new Point(22, 33);
      this._checkBox_SecretAge.Name = "_checkBox_SecretAge";
      this._checkBox_SecretAge.Size = new Size(95, 17);
      this._checkBox_SecretAge.TabIndex = 3;
      this._checkBox_SecretAge.Text = "Age is Secret?";
      this._checkBox_SecretAge.UseVisualStyleBackColor = true;
      this._checkBox_SecretAge.CheckedChanged += new EventHandler(this.checkBox_SecretAge_CheckedChanged);
      this.label_Message.AutoSize = true;
      this.label_Message.Location = new Point(6, 126);
      this.label_Message.Name = "label_Message";
      this.label_Message.Size = new Size(114, 13);
      this.label_Message.TabIndex = 8;
      this.label_Message.Text = "Message (Inn Display):";
      this.label_Day.AutoSize = true;
      this.label_Day.Location = new Point(272, 6);
      this.label_Day.Name = "label_Day";
      this.label_Day.Size = new Size(15, 13);
      this.label_Day.TabIndex = 6;
      this.label_Day.Text = "D";
      this._textBox_ProfileMessage.AcceptsReturn = true;
      this._textBox_ProfileMessage.Location = new Point(7, 142);
      this._textBox_ProfileMessage.MaxLength = 100;
      this._textBox_ProfileMessage.Multiline = true;
      this._textBox_ProfileMessage.Name = "_textBox_ProfileMessage";
      this._textBox_ProfileMessage.Size = new Size(272, 45);
      this._textBox_ProfileMessage.TabIndex = 4;
      this._textBox_ProfileMessage.TextChanged += new EventHandler(this._textBox_ProfileMessage_TextChanged);
      this.checkBox_Explanation.AutoSize = true;
      this.checkBox_Explanation.Location = new Point(102, 19);
      this.checkBox_Explanation.Name = "checkBox_Explanation";
      this.checkBox_Explanation.Size = new Size(108, 17);
      this.checkBox_Explanation.TabIndex = 12;
      this.checkBox_Explanation.Text = "Explanation done";
      this.checkBox_Explanation.UseVisualStyleBackColor = true;
      this.checkBox_Explanation.CheckedChanged += new EventHandler(this.checkBox_Explanation_CheckedChanged);
      this.checkBox_ProfileSetting.AutoSize = true;
      this.checkBox_ProfileSetting.Location = new Point(26, 19);
      this.checkBox_ProfileSetting.Name = "checkBox_ProfileSetting";
      this.checkBox_ProfileSetting.Size = new Size(77, 17);
      this.checkBox_ProfileSetting.TabIndex = 11;
      this.checkBox_ProfileSetting.Text = "Configured";
      this.checkBox_ProfileSetting.UseVisualStyleBackColor = true;
      this.checkBox_ProfileSetting.CheckedChanged += new EventHandler(this.checkBox_ProfileSetting_CheckedChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(316, 40);
      this.label1.Name = "label1";
      this.label1.Size = new Size(29, 13);
      this.label1.TabIndex = 27;
      this.label1.Text = "secs";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(242, 40);
      this.label2.Name = "label2";
      this.label2.Size = new Size(28, 13);
      this.label2.TabIndex = 25;
      this.label2.Text = "mins";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(160, 40);
      this.label3.Name = "label3";
      this.label3.Size = new Size(33, 13);
      this.label3.TabIndex = 23;
      this.label3.Text = "hours";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(19, 39);
      this.label4.Name = "label4";
      this.label4.Size = new Size(79, 13);
      this.label4.TabIndex = 21;
      this.label4.Text = "Multiplayer time";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(209, 182);
      this.label5.Name = "label5";
      this.label5.Size = new Size(65, 13);
      this.label5.TabIndex = 44;
      this.label5.Text = "Battles Won";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(49, 157);
      this.label6.Name = "label6";
      this.label6.Size = new Size(47, 13);
      this.label6.TabIndex = 46;
      this.label6.Text = "Alchemy";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(235, 82);
      this.label7.Name = "label7";
      this.label7.Size = new Size(39, 13);
      this.label7.TabIndex = 48;
      this.label7.Text = "Battles";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(233, 107);
      this.label8.Name = "label8";
      this.label8.Size = new Size(40, 13);
      this.label8.TabIndex = 50;
      this.label8.Text = "Losses";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(203, 132);
      this.label9.Name = "label9";
      this.label9.Size = new Size(71, 13);
      this.label9.TabIndex = 52;
      this.label9.Text = "Run Attempts";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(185, 157);
      this.label10.Name = "label10";
      this.label10.Size = new Size(89, 13);
      this.label10.TabIndex = 54;
      this.label10.Text = "Successfully Ran";
      this.groupBox_Gesture.Controls.Add((Control) this.label11);
      this.groupBox_Gesture.Controls.Add((Control) this.checkedListBox_GestureLearn);
      this.groupBox_Gesture.Location = new Point(362, 175);
      this.groupBox_Gesture.Name = "groupBox_Gesture";
      this.groupBox_Gesture.Size = new Size(432, 260);
      this.groupBox_Gesture.TabIndex = 15;
      this.groupBox_Gesture.TabStop = false;
      this.groupBox_Gesture.Text = "Party Tricks";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(287, 7);
      this.label11.Name = "label11";
      this.label11.Size = new Size(105, 13);
      this.label11.TabIndex = 19;
      this.label11.Text = "Learned Party Tricks";
      this.checkedListBox_GestureLearn.FormattingEnabled = true;
      this.checkedListBox_GestureLearn.Items.AddRange(new object[15]
      {
        (object) "Pray",
        (object) "Pirouette",
        (object) "Bow",
        (object) "Belly Dance",
        (object) "Royal Regards",
        (object) "Swinedimples Salute",
        (object) "Cap'n's Curtsy",
        (object) "Sultry Dance",
        (object) "Weird Dance",
        (object) "Wallop",
        (object) "Cheer",
        (object) "Provoke",
        (object) "Salute",
        (object) "Inspiration",
        (object) "Professor's Pose"
      });
      this.checkedListBox_GestureLearn.Location = new Point(290, 23);
      this.checkedListBox_GestureLearn.Name = "checkedListBox_GestureLearn";
      this.checkedListBox_GestureLearn.Size = new Size(128, 229);
      this.checkedListBox_GestureLearn.TabIndex = 7;
      this.checkedListBox_GestureLearn.ItemCheck += new ItemCheckEventHandler(this.checkedListBox_GestureLearn_ItemCheck);
      this.label_SavePlace.Location = new Point(392, 15);
      this.label_SavePlace.Name = "label_SavePlace";
      this.label_SavePlace.Size = new Size(76, 13);
      this.label_SavePlace.TabIndex = 55;
      this.label_SavePlace.Text = "Save Location";
      this.label_SavePlace.TextAlign = ContentAlignment.MiddleRight;
      this.button_SelectSavePlace.SetBounds(701, 12, 45, 20);
      this.button_SelectSavePlace.Name = "button_SelectSavePlace";
      this.button_SelectSavePlace.TabIndex = 57;
      this.button_SelectSavePlace.Text = "Set";
      this.button_SelectSavePlace.UseVisualStyleBackColor = true;
      this.button_SelectSavePlace.Click += new EventHandler(this.button_SelectSavePlace_Click);
      this.textBox_SavePlace.SetBounds(474, 12, 221, 20);
      this.textBox_SavePlace.Name = "textBox_SavePlace";
      this.textBox_SavePlace.ReadOnly = true;
      this.textBox_SavePlace.TabIndex = 59;
      this.label15.AutoSize = true;
      this.label15.Location = new Point(41, 21);
      this.label15.Name = "label15";
      this.label15.Size = new Size(48, 13);
      this.label15.TabIndex = 60;
      this.label15.Text = "X Coord:";
      this._numericUpDown_IntermissionX.DecimalPlaces = 2;
      this._numericUpDown_IntermissionX.Location = new Point(95, 19);
      this._numericUpDown_IntermissionX.Maximum = new Decimal(new int[4]
      {
        10000000,
        0,
        0,
        0
      });
      this._numericUpDown_IntermissionX.Minimum = new Decimal(new int[4]
      {
        10000000,
        0,
        0,
        int.MinValue
      });
      this._numericUpDown_IntermissionX.Name = "_numericUpDown_IntermissionX";
      this._numericUpDown_IntermissionX.Size = new Size(81, 20);
      this._numericUpDown_IntermissionX.TabIndex = 61;
      this._numericUpDown_IntermissionX.TextAlign = HorizontalAlignment.Right;
      this._numericUpDown_IntermissionX.Value = new Decimal(new int[4]);
      this._numericUpDown_IntermissionX.ValueChanged += new EventHandler(this._numericUpDown_IntermissionX_ValueChanged);
      this._numericUpDown_IntermissionZ.DecimalPlaces = 2;
      this._numericUpDown_IntermissionZ.Location = new Point(95, 63);
      this._numericUpDown_IntermissionZ.Maximum = new Decimal(new int[4]
      {
        10000000,
        0,
        0,
        0
      });
      this._numericUpDown_IntermissionZ.Minimum = new Decimal(new int[4]
      {
        10000000,
        0,
        0,
        int.MinValue
      });
      this._numericUpDown_IntermissionZ.Name = "_numericUpDown_IntermissionZ";
      this._numericUpDown_IntermissionZ.Size = new Size(81, 20);
      this._numericUpDown_IntermissionZ.TabIndex = 63;
      this._numericUpDown_IntermissionZ.TextAlign = HorizontalAlignment.Right;
      this._numericUpDown_IntermissionZ.Value = new Decimal(new int[4]);
      this._numericUpDown_IntermissionZ.ValueChanged += new EventHandler(this._numericUpDown_IntermissionZ_ValueChanged);
      this.label16.AutoSize = true;
      this.label16.Location = new Point(41, 65);
      this.label16.Name = "label16";
      this.label16.Size = new Size(48, 13);
      this.label16.TabIndex = 62;
      this.label16.Text = "Z Coord:";
      this._numericUpDown_IntermissionY.DecimalPlaces = 2;
      this._numericUpDown_IntermissionY.Location = new Point(95, 41);
      this._numericUpDown_IntermissionY.Maximum = new Decimal(new int[4]
      {
        10000000,
        0,
        0,
        0
      });
      this._numericUpDown_IntermissionY.Minimum = new Decimal(new int[4]
      {
        10000000,
        0,
        0,
        int.MinValue
      });
      this._numericUpDown_IntermissionY.Name = "_numericUpDown_IntermissionY";
      this._numericUpDown_IntermissionY.Size = new Size(81, 20);
      this._numericUpDown_IntermissionY.TabIndex = 65;
      this._numericUpDown_IntermissionY.TextAlign = HorizontalAlignment.Right;
      this._numericUpDown_IntermissionY.Value = new Decimal(new int[4]);
      this._numericUpDown_IntermissionY.ValueChanged += new EventHandler(this._numericUpDown_IntermissionY_ValueChanged);
      this.label17.AutoSize = true;
      this.label17.Location = new Point(41, 43);
      this.label17.Name = "label17";
      this.label17.Size = new Size(48, 13);
      this.label17.TabIndex = 64;
      this.label17.Text = "Y Coord:";
      this.groupBox_IntermissionCoord.Controls.Add((Control) this._numericUpDown_IntermissionY);
      this.groupBox_IntermissionCoord.Controls.Add((Control) this._numericUpDown_IntermissionX);
      this.groupBox_IntermissionCoord.Controls.Add((Control) this._numericUpDown_IntermissionZ);
      this.groupBox_IntermissionCoord.Controls.Add((Control) this.label15);
      this.groupBox_IntermissionCoord.Controls.Add((Control) this.label17);
      this.groupBox_IntermissionCoord.Controls.Add((Control) this.label16);
      this.groupBox_IntermissionCoord.Location = new Point(379, 45);
      this.groupBox_IntermissionCoord.Name = "groupBox_IntermissionCoord";
      this.groupBox_IntermissionCoord.Size = new Size(200, 94);
      this.groupBox_IntermissionCoord.TabIndex = 66;
      this.groupBox_IntermissionCoord.TabStop = false;
      this.groupBox_IntermissionCoord.Text = "Quick Save Coord";
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.groupBox_IntermissionCoord);
      this.Controls.Add((Control) this.textBox_SavePlace);
      this.Controls.Add((Control) this.button_SelectSavePlace);
      this.Controls.Add((Control) this.label_SavePlace);
      this.Controls.Add((Control) this.groupBox_Gesture);
      this.Controls.Add((Control) this.groupBox_Profile);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label_medal);
      this.Controls.Add((Control) this.label_bankMoney);
      this.Controls.Add((Control) this.label_Money);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label_Second);
      this.Controls.Add((Control) this.label_Minute);
      this.Controls.Add((Control) this.label_Hour);
      this.Controls.Add((Control) this.label_PlayTime);
      this.Name = nameof (BasisDataControl);
      this.Size = new Size(840, 507);
      this.groupBox_Profile.ResumeLayout(false);
      this.groupBox_Profile.PerformLayout();
      this.panel_Profile.ResumeLayout(false);
      this.panel_Profile.PerformLayout();
      this.groupBox_Gesture.ResumeLayout(false);
      this.groupBox_Gesture.PerformLayout();
      this._numericUpDown_IntermissionX.EndInit();
      this._numericUpDown_IntermissionZ.EndInit();
      this._numericUpDown_IntermissionY.EndInit();
      this.groupBox_IntermissionCoord.ResumeLayout(false);
      this.groupBox_IntermissionCoord.PerformLayout();
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

    public VisionNumericUpDown NumericUpDown_Money => this._numericUpDown_Money;

    public VisionNumericUpDown NumericUpDown_BankMoney => this._numericUpDown_BankMoney;

    public VisionNumericUpDown NumericUpDown_Medal => this._numericUpDown_Medal;

    public VisionNumericUpDown NumericUpDown_BattleCount => this._numericUpDown_BattleCount;

    public VisionNumericUpDown NumericUpDown_LoseCount => this._numericUpDown_LoseCount;

    public VisionNumericUpDown NumericUpDown_EscapeCount => this._numericUpDown_EscapeCount;

    public VisionNumericUpDown NumericUpDown_EscapeSuccessCount
    {
      get => this._numericUpDown_EscapeSuccessCount;
    }

    public VisionNumericUpDown NumericUpDown_VictoryCount => this._numericUpDown_VictoryCount;

    public VisionNumericUpDown NumericUpDown_AlchemyCount => this._numericUpDown_AlchemyCount;

    public VisionNumericUpDown NumericUpDown_ProfileBirthYear
    {
      get => this._numericUpDown_ProfileBirthYear;
    }

    public VisionNumericUpDown NumericUpDown_ProfileBirthMonth
    {
      get => this._numericUpDown_ProfileBirthMonth;
    }

    public VisionNumericUpDown NumericUpDown_ProfileBirthDay => this._numericUpDown_ProfileBirthDay;

    public CheckBox CheckBox_SecretAge => this._checkBox_SecretAge;

    protected override void OnValueUpdate()
    {
      BasisData basisData = SaveDataManager.Instance.SaveData.BasisData;
      this.panel_Profile.Enabled = basisData.ProfileSetting;
      this.checkBox_ProfileSetting.Checked = basisData.ProfileSetting;
      this.checkBox_Explanation.Checked = basisData.ProfileExplanation;
      this.comboBox_Sex.SelectedIndex = (int) basisData.ProfileSex;
      this.comboBox_Tone.SelectedIndex = (int) basisData.ProfileTone;
      this.checkBox_ToneSetting.Checked = basisData.ProfileToneSetting;
      this._numericUpDown_Hour.Value = (Decimal) basisData.PlayTimeHour.Value;
      this._numericUpDown_Minute.Value = (Decimal) basisData.PlayTimeMinute.Value;
      this._numericUpDown_Second.Value = (Decimal) basisData.PlayTimeSecond.Value;
      this._numericUpDown_MultiPlayTimeHour.Value = (Decimal) basisData.MultiPlayTimeHour.Value;
      this._numericUpDown_MultiPlayTimeMinute.Value = (Decimal) basisData.MultiPlayTimeMinute.Value;
      this._numericUpDown_MultiPlayTimeSecond.Value = (Decimal) basisData.MultiPlayTimeSecond.Value;
      this._numericUpDown_Money.Value = (Decimal) basisData.Money.Value;
      this._numericUpDown_BankMoney.Value = (Decimal) basisData.BankMoney.Value;
      this._numericUpDown_Medal.Value = (Decimal) basisData.Medal.Value;
      this._numericUpDown_BattleCount.Value = (Decimal) basisData.BattleCount;
      this._numericUpDown_LoseCount.Value = (Decimal) basisData.LoseCount;
      this._numericUpDown_EscapeCount.Value = (Decimal) basisData.EscapeCount;
      this._numericUpDown_EscapeSuccessCount.Value = (Decimal) basisData.EscapeSuccessCount;
      this._numericUpDown_VictoryCount.Value = (Decimal) basisData.VictoryCount;
      this._numericUpDown_AlchemyCount.Value = (Decimal) basisData.AlchemyCount.Value;
      this._numericUpDown_ProfileBirthYear.Value = (Decimal) basisData.ProfileBirthYear;
      this._numericUpDown_ProfileBirthMonth.Value = (Decimal) basisData.ProfileBirthMonth;
      this._numericUpDown_ProfileBirthDay.Value = (Decimal) basisData.ProfileBirthDay;
      this._textBox_ProfileAddress.Text = basisData.Address.Name;
      this.RenewalHanle(basisData);
      this._textBox_ProfileMessage.Text = basisData.ProfileMessage.Value;
      this._checkBox_SecretAge.Checked = basisData.ProfileSecretAge;
      this._comboBox_GestureUp.SelectedIndex = GestureList.List[(int) basisData.GestureUp].Index;
      this._comboBox_GestureLeft.SelectedIndex = GestureList.List[(int) basisData.GestureLeft].Index;
      this._comboBox_GestureRight.SelectedIndex = GestureList.List[(int) basisData.GestureRight].Index;
      this._comboBox_GestureDown1.SelectedIndex = GestureList.List[(int) basisData.GestureDown1].Index;
      this._comboBox_GestureDown2.SelectedIndex = GestureList.List[(int) basisData.GestureDown2].Index;
      this._comboBox_GestureDown3.SelectedIndex = GestureList.List[(int) basisData.GestureDown3].Index;
      this._comboBox_GestureDown4.SelectedIndex = GestureList.List[(int) basisData.GestureDown4].Index;
      for (int index = 0; index < 15; ++index)
        this.checkedListBox_GestureLearn.SetItemChecked(index, basisData.IsGestureLearn(index));
      if (SaveDataManager.Instance.SelectedDataIndex == 1)
      {
        this.label_SavePlace.Text = "Quicksave Loc.";
        if (basisData.IntermissionPlace != null)
          this.textBox_SavePlace.Text = basisData.IntermissionPlace.Name;
        else
          this.textBox_SavePlace.Text = string.Empty;
        this.groupBox_IntermissionCoord.Enabled = true;
        this._numericUpDown_IntermissionX.Value = (Decimal) ((float) basisData.IntermissionX.Value / 100f);
        this._numericUpDown_IntermissionY.Value = (Decimal) ((float) basisData.IntermissionY.Value / 100f);
        this._numericUpDown_IntermissionZ.Value = (Decimal) ((float) basisData.IntermissionZ.Value / 100f);
      }
      else
      {
        this.label_SavePlace.Text = "Save Location";
        if (basisData.SavePlace != null)
          this.textBox_SavePlace.Text = basisData.SavePlace.Name;
        else
          this.textBox_SavePlace.Text = string.Empty;
        this.groupBox_IntermissionCoord.Enabled = false;
        this._numericUpDown_IntermissionX.Value = 0M;
        this._numericUpDown_IntermissionY.Value = 0M;
        this._numericUpDown_IntermissionZ.Value = 0M;
      }
    }

    private void RenewalHanle(BasisData basisData)
    {
      this._textBox_ProfileHandle.Text = string.Empty;
      if (basisData.Handle == null)
        return;
      if (basisData.Handle.Job != null)
      {
        this._textBox_ProfileHandle.Text = basisData.Handle.Job.Name;
      }
      else
      {
        if (basisData.Handle.Title == null)
          return;
        if (basisData.ProfileSex == (byte) 0)
        {
          this._textBox_ProfileHandle.Text = basisData.Handle.Title.MaleTitleName;
        }
        else
        {
          if (basisData.ProfileSex != (byte) 1)
            return;
          this._textBox_ProfileHandle.Text = basisData.Handle.Title.LadyTitleName;
        }
      }
    }

    private void _numericUpDown_Hour_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.PlayTimeHour.Value = (ushort) this._numericUpDown_Hour.Value;
    }

    private void _numericUpDown_Minute_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.PlayTimeMinute.Value = (byte) this._numericUpDown_Minute.Value;
    }

    private void _numericUpDown_Second_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.PlayTimeSecond.Value = (byte) this._numericUpDown_Second.Value;
    }

    private void _numericUpDown_Money_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.Money.Value = (uint) this._numericUpDown_Money.Value;
    }

    private void _numericUpDown_BankMoney_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.BankMoney.Value = (uint) this._numericUpDown_BankMoney.Value;
    }

    private void _numericUpDown_Medal_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.Medal.Value = (uint) this._numericUpDown_Medal.Value;
    }

    private void _numericUpDown_MultiPlayTimeHour_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.MultiPlayTimeHour.Value = (ushort) this._numericUpDown_MultiPlayTimeHour.Value;
    }

    private void _numericUpDown_MultiPlayTimeMinute_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.MultiPlayTimeMinute.Value = (byte) this._numericUpDown_MultiPlayTimeMinute.Value;
    }

    private void _numericUpDown_MultiPlayTimeSecond_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.MultiPlayTimeSecond.Value = (byte) this._numericUpDown_MultiPlayTimeSecond.Value;
    }

    private void _numericUpDown_ProfileBirthYear_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileBirthYear = (ushort) this._numericUpDown_ProfileBirthYear.Value;
    }

    private void _numericUpDown_ProfileBirthMonth_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileBirthMonth = (byte) this._numericUpDown_ProfileBirthMonth.Value;
    }

    private void _numericUpDown_ProfileBirthDay_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileBirthDay = (byte) this._numericUpDown_ProfileBirthDay.Value;
    }

    private void _textBox_ProfileMessage_TextChanged(object sender, EventArgs e)
    {
      Encoding encoding = (Encoding) new DQ9Encoding();
      byte[] bytes = encoding.GetBytes(this._textBox_ProfileMessage.Text);
      if (bytes.Length > SaveDataManager.Instance.SaveData.BasisData.ProfileMessage.MaxLength)
      {
        this._textBox_ProfileMessage.Text = encoding.GetString(bytes, 0, SaveDataManager.Instance.SaveData.BasisData.ProfileMessage.MaxLength);
        this._textBox_ProfileMessage.SelectionStart = this._textBox_ProfileMessage.TextLength;
      }
      else
        this._textBox_ProfileMessage.Text = encoding.GetString(bytes, 0, bytes.Length);
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileMessage.Value = this._textBox_ProfileMessage.Text;
    }

    private void checkBox_SecretAge_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileSecretAge = this._checkBox_SecretAge.Checked;
    }

    private void _numericUpDown_VictoryCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.VictoryCount = (uint) this._numericUpDown_VictoryCount.Value;
    }

    private void _numericUpDown_AlchemyCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.AlchemyCount.Value = (int) this._numericUpDown_AlchemyCount.Value;
    }

    private void _numericUpDown_BattleCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.BattleCount = (uint) this._numericUpDown_BattleCount.Value;
    }

    private void _numericUpDown_LoseCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.LoseCount = (uint) this._numericUpDown_LoseCount.Value;
    }

    private void _numericUpDown_EscapeCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.EscapeCount = (uint) this._numericUpDown_EscapeCount.Value;
    }

    private void _numericUpDown_EscapeSuccessCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.EscapeSuccessCount = (uint) this._numericUpDown_EscapeSuccessCount.Value;
    }

    private void comboBox_Gesture_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is VisionComboBox visionComboBox))
        return;
      switch ((int) visionComboBox.Tag)
      {
        case 0:
          SaveDataManager.Instance.SaveData.BasisData.GestureUp = (byte) visionComboBox.SelectedIndex;
          break;
        case 1:
          SaveDataManager.Instance.SaveData.BasisData.GestureLeft = (byte) visionComboBox.SelectedIndex;
          break;
        case 2:
          SaveDataManager.Instance.SaveData.BasisData.GestureRight = (byte) visionComboBox.SelectedIndex;
          break;
        case 3:
          SaveDataManager.Instance.SaveData.BasisData.GestureDown1 = (byte) visionComboBox.SelectedIndex;
          break;
        case 4:
          SaveDataManager.Instance.SaveData.BasisData.GestureDown2 = (byte) visionComboBox.SelectedIndex;
          break;
        case 5:
          SaveDataManager.Instance.SaveData.BasisData.GestureDown3 = (byte) visionComboBox.SelectedIndex;
          break;
        case 6:
          SaveDataManager.Instance.SaveData.BasisData.GestureDown4 = (byte) visionComboBox.SelectedIndex;
          break;
      }
    }

    private void checkedListBox_GestureLearn_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.SetGestureLearn(e.Index, e.NewValue == CheckState.Checked);
    }

    private void checkBox_ProfileSetting_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileSetting = this.checkBox_ProfileSetting.Checked;
      this.panel_Profile.Enabled = this.checkBox_ProfileSetting.Checked;
    }

    private void checkBox_Explanation_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileExplanation = this.checkBox_Explanation.Checked;
    }

    private void comboBox_Sex_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileSex = (byte) this.comboBox_Sex.SelectedIndex;
      this.RenewalHanle(SaveDataManager.Instance.SaveData.BasisData);
    }

    private void comboBox_Tone_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileTone = (byte) this.comboBox_Tone.SelectedIndex;
    }

    private void checkBox_ToneSetting_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.ProfileToneSetting = this.checkBox_ToneSetting.Checked;
    }

    private void button_SelectSavePlace_Click(object sender, EventArgs e)
    {
      if (!(sender is Button button))
        return;
      using (SavePlaceSelectWindow placeSelectWindow = new SavePlaceSelectWindow(SaveDataManager.Instance.SelectedDataIndex == 0))
      {
        placeSelectWindow.Location = this.PointToScreen(new Point(button.Right, button.Bottom));
        if (placeSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SavePlace selectedSavePlace = placeSelectWindow.SelectedSavePlace;
        SaveDataManager.Instance.SaveData.BasisData.SavePlace = selectedSavePlace;
        this.textBox_SavePlace.Text = selectedSavePlace.Name;
      }
    }

    private void _numericUpDown_IntermissionX_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.IntermissionX.Value = (int) (this._numericUpDown_IntermissionX.Value * 100M);
    }

    private void _numericUpDown_IntermissionY_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.IntermissionY.Value = (int) (this._numericUpDown_IntermissionY.Value * 100M);
    }

    private void _numericUpDown_IntermissionZ_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.BasisData.IntermissionZ.Value = (int) (this._numericUpDown_IntermissionZ.Value * 100M);
    }

    private void button_SelectProfileAddress_Click(object sender, EventArgs e)
    {
      using (AddressSelectWindow addressSelectWindow = new AddressSelectWindow())
      {
        addressSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Profile.Left + this.panel_Profile.Left + this.button_SelectProfileAddress.Right, this.groupBox_Profile.Top + this.panel_Profile.Top + this.button_SelectProfileAddress.Bottom));
        if (addressSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.BasisData.Address = addressSelectWindow.SelectedAddress;
        this.OnValueUpdate();
      }
    }

    private void button_SelectProfileHandle_Click(object sender, EventArgs e)
    {
      BasisData basisData = SaveDataManager.Instance.SaveData.BasisData;
      using (HandleSelectWindow handleSelectWindow = new HandleSelectWindow((int) basisData.ProfileSex))
      {
        handleSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Profile.Left + this.panel_Profile.Left + this.button_SelectProfileHandle.Right, this.groupBox_Profile.Top + this.panel_Profile.Top + this.button_SelectProfileHandle.Bottom));
        if (handleSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        DQ9_Cheat.GameData.Handle selectedHandle = handleSelectWindow.SelectedHandle;
        basisData.Handle = selectedHandle;
        this.OnValueUpdate();
      }
    }
  }
}
