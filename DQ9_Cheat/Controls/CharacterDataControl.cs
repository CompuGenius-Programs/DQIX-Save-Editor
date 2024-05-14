// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.CharacterDataControl
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
  public class CharacterDataControl : DataControlBase
  {
    private IContainer components;
    private ListBox listBox_PartyMember;
    private Label label_Name;
    private Label label_Job;
    private ComboBox comboBox_Job;
    private Label label1;
    private Label label2;
    private ListBox listBox_StandbyMember;
    private Label label3;
    private Panel panel1;
    private ToolStrip toolStrip1;
    private ToolStripButton toolButton_PartyMemberUp;
    private Panel panel2;
    private ToolStrip toolStrip2;
    private ToolStripButton toolButton_PartyMemberDown;
    private ToolStripButton toolButton_PartyOut;
    private ToolStripButton toolButton_RuidaMemberUp;
    private ToolStripButton toolButton_RuidaMemberDown;
    private ToolStripButton toolButton_PartyIn;
    private ToolStripButton toolButton_CreateMember;
    private ToolStripButton toolButton_DeleteMember;
    private Label label4;
    private ComboBox comboBox_Sex;
    private JS_GroupBox groupBox_Equipment;
    private Label label11;
    private Label label10;
    private Label label9;
    private Label label8;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label12;
    private JS_GroupBox groupBox_Figure;
    private Label label14;
    private Label label13;
    private Label label18;
    private Label label19;
    private Label label17;
    private Label label16;
    private Label label15;
    private Button button_FacePreset;
    private Button button_HairColorPreset;
    private Button button_HairPreset;
    private Button button_FigurePreset;
    private Label label21;
    private Label label20;
    private Button button_SelectWeapon;
    private Button button_SelectAccessory;
    private Button button_SelectShoe;
    private Button button_SelectLowerBody;
    private Button button_SelectArm;
    private Button button_SelectUpperBody;
    private Button button_SelectHead;
    private Button button_SelectShield;
    private Label label22;
    private Label label23;
    private ComboBox comboBox_Rank;
    private Label label24;
    private ComboBox comboBox_Strategy;
    private ComboBox comboBox_Color;
    private Label label25;
    private JS_GroupBox groupBox_Tool;
    private Label label26;
    private Label label27;
    private SafeNumericUpDown _numericUpDown_NowHP;
    private SafeNumericUpDown _numericUpDown_NowMP;
    private Label label_MaxHP;
    private Label label_MaxMP;
    private JS_GroupBox groupBox_Status;
    private Label label32;
    private Label label31;
    private SafeNumericUpDown _numericUpDown_Experience;
    private Label label30;
    private SafeNumericUpDown _numericUpDown_Level;
    private Label label29;
    private ComboBox comboBox_StatusEditJob;
    private Label label28;
    private Label label36;
    private Label label37;
    private Label label39;
    private Label label35;
    private Label label33;
    private Label label34;
    private JS_GroupBox groupBox_StatusRevise;
    private Label label38;
    private JS_GroupBox groupBox_Skill;
    private SafeNumericUpDown _numericUpDown_Transmigration;
    private Label label40;
    private Label label41;
    private CheckedListBox checkedListBox_Specialty;
    private Label label42;
    private CheckedListBox checkedListBox_Skill;
    private ComboBox comboBox_SkillSpecialty;
    private CheckBox checkBox_Cheer;
    private CheckBox checkBox_Ruler;
    private JS_GroupBox GroupBox_SkillSpecialty;
    private JS_GroupBox GroupBox_State;
    private CheckBox checkBox_Curse;
    private CheckBox checkBox_Poison;
    private CheckBox checkBox_Die;
    private int _selectedIndex;
    private VisionTextBox[] _textBox_Tools = new VisionTextBox[8];
    private VisionTextBox[] _textBox_Equipment = new VisionTextBox[8];
    private VisionButton[] _button_SelectTools = new VisionButton[8];
    private Label[] _label_Skills = new Label[5];
    private VisionNumericUpDown[] _numericUpDown_Skills = new VisionNumericUpDown[5];
    private VisionTextBox _textBox_CharacterName;
    private VisionNumericUpDown _numericUpDown_ReviseHP;
    private VisionNumericUpDown _numericUpDown_ReviseMP;
    private VisionNumericUpDown _numericUpDown_RevisePower;
    private VisionNumericUpDown _numericUpDown_ReviseFacility;
    private VisionNumericUpDown _numericUpDown_ReviseQuick;
    private VisionNumericUpDown _numericUpDown_ReviseDefense;
    private VisionNumericUpDown _numericUpDown_ReviseSmart;
    private VisionNumericUpDown _numericUpDown_ReviseAttackMagic;
    private VisionNumericUpDown _numericUpDown_ReviseRevivalMagic;
    private VisionNumericUpDown _numericUpDown_FigureWidth;
    private VisionNumericUpDown _numericUpDown_FigureHeight;
    private VisionNumericUpDown _numericUpDown_Hair;
    private VisionNumericUpDown _numericUpDown_HairColor;
    private VisionNumericUpDown _numericUpDown_Face;
    private VisionNumericUpDown _numericUpDown_SkinColor;
    private VisionNumericUpDown _numericUpDown_EyeColor;
    private VisionNumericUpDown _numericUpDown_SkillPoint;

    public CharacterDataControl()
    {
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CharacterDataControl));
      this.listBox_PartyMember = new ListBox();
      this.label_Name = new Label();
      this.label_Job = new Label();
      this.comboBox_Job = new ComboBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.listBox_StandbyMember = new ListBox();
      this.label3 = new Label();
      this.panel1 = new Panel();
      this.toolStrip1 = new ToolStrip();
      this.toolButton_PartyMemberUp = new ToolStripButton();
      this.toolButton_PartyMemberDown = new ToolStripButton();
      this.toolButton_PartyOut = new ToolStripButton();
      this.panel2 = new Panel();
      this.toolStrip2 = new ToolStrip();
      this.toolButton_RuidaMemberUp = new ToolStripButton();
      this.toolButton_RuidaMemberDown = new ToolStripButton();
      this.toolButton_PartyIn = new ToolStripButton();
      this.toolButton_CreateMember = new ToolStripButton();
      this.toolButton_DeleteMember = new ToolStripButton();
      this.label4 = new Label();
      this.comboBox_Sex = new ComboBox();
      this.groupBox_Equipment = new JS_GroupBox();
      this.button_SelectAccessory = new Button();
      this.button_SelectShoe = new Button();
      this.button_SelectLowerBody = new Button();
      this.button_SelectArm = new Button();
      this.button_SelectUpperBody = new Button();
      this.button_SelectHead = new Button();
      this.button_SelectShield = new Button();
      this.button_SelectWeapon = new Button();
      this.label12 = new Label();
      this.label11 = new Label();
      this.label10 = new Label();
      this.label9 = new Label();
      this.label8 = new Label();
      this.label7 = new Label();
      this.label6 = new Label();
      this.label5 = new Label();
      this.groupBox_Figure = new JS_GroupBox();
      this.label21 = new Label();
      this.label20 = new Label();
      this.button_FacePreset = new Button();
      this.button_HairColorPreset = new Button();
      this.button_HairPreset = new Button();
      this.button_FigurePreset = new Button();
      this.label18 = new Label();
      this.label19 = new Label();
      this.label17 = new Label();
      this.label16 = new Label();
      this.label15 = new Label();
      this.label14 = new Label();
      this.label13 = new Label();
      this.label22 = new Label();
      this.label23 = new Label();
      this.comboBox_Rank = new ComboBox();
      this.label24 = new Label();
      this.comboBox_Strategy = new ComboBox();
      this.comboBox_Color = new ComboBox();
      this.label25 = new Label();
      this.groupBox_Tool = new JS_GroupBox();
      this.label26 = new Label();
      this.label27 = new Label();
      this._numericUpDown_NowHP = new SafeNumericUpDown();
      this._numericUpDown_NowMP = new SafeNumericUpDown();
      this.label_MaxHP = new Label();
      this.label_MaxMP = new Label();
      this.groupBox_Status = new JS_GroupBox();
      this.GroupBox_SkillSpecialty = new JS_GroupBox();
      this.comboBox_SkillSpecialty = new ComboBox();
      this.checkBox_Cheer = new CheckBox();
      this.checkBox_Ruler = new CheckBox();
      this.checkedListBox_Skill = new CheckedListBox();
      this.label42 = new Label();
      this.label41 = new Label();
      this.checkedListBox_Specialty = new CheckedListBox();
      this._numericUpDown_Transmigration = new SafeNumericUpDown();
      this.label40 = new Label();
      this.groupBox_Skill = new JS_GroupBox();
      this.groupBox_StatusRevise = new JS_GroupBox();
      this.label38 = new Label();
      this.label34 = new Label();
      this.label31 = new Label();
      this.label36 = new Label();
      this.label32 = new Label();
      this.label37 = new Label();
      this.label33 = new Label();
      this.label39 = new Label();
      this.label35 = new Label();
      this._numericUpDown_Experience = new SafeNumericUpDown();
      this.label30 = new Label();
      this._numericUpDown_Level = new SafeNumericUpDown();
      this.label29 = new Label();
      this.comboBox_StatusEditJob = new ComboBox();
      this.label28 = new Label();
      this.GroupBox_State = new JS_GroupBox();
      this.checkBox_Curse = new CheckBox();
      this.checkBox_Poison = new CheckBox();
      this.checkBox_Die = new CheckBox();
      this.panel1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.groupBox_Equipment.SuspendLayout();
      this.groupBox_Figure.SuspendLayout();
      this._numericUpDown_NowHP.BeginInit();
      this._numericUpDown_NowMP.BeginInit();
      this.groupBox_Status.SuspendLayout();
      this.GroupBox_SkillSpecialty.SuspendLayout();
      this._numericUpDown_Transmigration.BeginInit();
      this.groupBox_StatusRevise.SuspendLayout();
      this._numericUpDown_Experience.BeginInit();
      this._numericUpDown_Level.BeginInit();
      this.GroupBox_State.SuspendLayout();
      this.SuspendLayout();
      this.listBox_PartyMember.Dock = DockStyle.Fill;
      this.listBox_PartyMember.FormattingEnabled = true;
      this.listBox_PartyMember.ItemHeight = 12;
      this.listBox_PartyMember.Location = new Point(0, 16);
      this.listBox_PartyMember.Name = "listBox_PartyMember";
      this.listBox_PartyMember.Size = new Size(116, 65);
      this.listBox_PartyMember.TabIndex = 0;
      this.listBox_PartyMember.SelectedIndexChanged += new EventHandler(this.listBox_PartyMember_SelectedIndexChanged);
      this.label_Name.AutoSize = true;
      this.label_Name.Location = new Point(166, 20);
      this.label_Name.Name = "label_Name";
      this.label_Name.Size = new Size(29, 12);
      this.label_Name.TabIndex = 1;
      this.label_Name.Text = "Name";
      this.label_Job.AutoSize = true;
      this.label_Job.Location = new Point(402, 20);
      this.label_Job.Name = "label_Job";
      this.label_Job.Size = new Size(53, 12);
      this.label_Job.TabIndex = 3;
      this.label_Job.Text = "Vocation";
      this.comboBox_Job.DropDownHeight = 200;
      this.comboBox_Job.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Job.FormattingEnabled = true;
      this.comboBox_Job.IntegralHeight = false;
      this.comboBox_Job.Location = new Point(455, 16);
      this.comboBox_Job.Name = "comboBox_Job";
      this.comboBox_Job.Size = new Size(93, 20);
      this.comboBox_Job.TabIndex = 3;
      this.comboBox_Job.SelectedIndexChanged += new EventHandler(this.comboBox_Job_SelectedIndexChanged);
      this.label1.Dock = DockStyle.Top;
      this.label1.Location = new Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(116, 16);
      this.label1.TabIndex = 5;
      this.label1.Text = "Party Members";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.label2.Dock = DockStyle.Top;
      this.label2.Location = new Point(0, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(116, 16);
      this.label2.TabIndex = 7;
      this.label2.Text = "Inn";
      this.label2.TextAlign = ContentAlignment.MiddleCenter;
      this.listBox_StandbyMember.Dock = DockStyle.Fill;
      this.listBox_StandbyMember.FormattingEnabled = true;
      this.listBox_StandbyMember.ItemHeight = 12;
      this.listBox_StandbyMember.Location = new Point(0, 16);
      this.listBox_StandbyMember.Name = "listBox_StandbyMember";
      this.listBox_StandbyMember.Size = new Size(116, 136);
      this.listBox_StandbyMember.TabIndex = 0;
      this.listBox_StandbyMember.SelectedIndexChanged += new EventHandler(this.listBox_StandbyMember_SelectedIndexChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(0, 21);
      this.label3.Name = "label3";
      this.label3.Size = new Size(41, 12);
      this.label3.TabIndex = 8;
      this.label3.Text = "Hero";
      this.panel1.BorderStyle = BorderStyle.Fixed3D;
      this.panel1.Controls.Add((Control) this.toolStrip1);
      this.panel1.Controls.Add((Control) this.listBox_PartyMember);
      this.panel1.Controls.Add((Control) this.label1);
      this.panel1.Location = new Point(43, 1);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(120, 100);
      this.panel1.TabIndex = 0;
      this.toolStrip1.Dock = DockStyle.Bottom;
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.toolButton_PartyMemberUp,
        (ToolStripItem) this.toolButton_PartyMemberDown,
        (ToolStripItem) this.toolButton_PartyOut
      });
      this.toolStrip1.Location = new Point(0, 68);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(116, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      this.toolButton_PartyMemberUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_PartyMemberUp.Enabled = false;
      this.toolButton_PartyMemberUp.Image = (Image) componentResourceManager.GetObject("toolButton_PartyMemberUp.Image");
      this.toolButton_PartyMemberUp.ImageTransparentColor = Color.Magenta;
      this.toolButton_PartyMemberUp.Name = "toolButton_PartyMemberUp";
      this.toolButton_PartyMemberUp.Size = new Size(23, 22);
      this.toolButton_PartyMemberUp.Text = "toolStripButton1";
      this.toolButton_PartyMemberUp.ToolTipText = "Move Up";
      this.toolButton_PartyMemberUp.Click += new EventHandler(this.toolButton_PartyMemberUp_Click);
      this.toolButton_PartyMemberDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_PartyMemberDown.Enabled = false;
      this.toolButton_PartyMemberDown.Image = (Image) componentResourceManager.GetObject("toolButton_PartyMemberDown.Image");
      this.toolButton_PartyMemberDown.ImageTransparentColor = Color.Magenta;
      this.toolButton_PartyMemberDown.Name = "toolButton_PartyMemberDown";
      this.toolButton_PartyMemberDown.Size = new Size(23, 22);
      this.toolButton_PartyMemberDown.Text = "toolStripButton3";
      this.toolButton_PartyMemberDown.ToolTipText = "Move Down";
      this.toolButton_PartyMemberDown.Click += new EventHandler(this.toolButton_PartyMemberDown_Click);
      this.toolButton_PartyOut.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_PartyOut.Enabled = false;
      this.toolButton_PartyOut.Image = (Image) componentResourceManager.GetObject("toolButton_PartyOut.Image");
      this.toolButton_PartyOut.ImageTransparentColor = Color.Magenta;
      this.toolButton_PartyOut.Name = "toolButton_PartyOut";
      this.toolButton_PartyOut.Size = new Size(23, 22);
      this.toolButton_PartyOut.Text = "toolStripButton4";
      this.toolButton_PartyOut.ToolTipText = "Out of Party";
      this.toolButton_PartyOut.Click += new EventHandler(this.toolButton_PartyOut_Click);
      this.panel2.BorderStyle = BorderStyle.Fixed3D;
      this.panel2.Controls.Add((Control) this.listBox_StandbyMember);
      this.panel2.Controls.Add((Control) this.toolStrip2);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Location = new Point(43, 104);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(120, 181);
      this.panel2.TabIndex = 1;
      this.toolStrip2.Dock = DockStyle.Bottom;
      this.toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip2.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.toolButton_RuidaMemberUp,
        (ToolStripItem) this.toolButton_RuidaMemberDown,
        (ToolStripItem) this.toolButton_PartyIn,
        (ToolStripItem) this.toolButton_CreateMember,
        (ToolStripItem) this.toolButton_DeleteMember
      });
      this.toolStrip2.Location = new Point(0, 152);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.Size = new Size(116, 25);
      this.toolStrip2.TabIndex = 1;
      this.toolStrip2.Text = "toolStrip2";
      this.toolButton_RuidaMemberUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_RuidaMemberUp.Enabled = false;
      this.toolButton_RuidaMemberUp.Image = (Image) componentResourceManager.GetObject("toolButton_RuidaMemberUp.Image");
      this.toolButton_RuidaMemberUp.ImageTransparentColor = Color.Magenta;
      this.toolButton_RuidaMemberUp.Name = "toolButton_RuidaMemberUp";
      this.toolButton_RuidaMemberUp.Size = new Size(23, 22);
      this.toolButton_RuidaMemberUp.Text = "toolStripButton2";
      this.toolButton_RuidaMemberUp.ToolTipText = "Move Up";
      this.toolButton_RuidaMemberUp.Click += new EventHandler(this.toolButton_RuidaMemberUp_Click);
      this.toolButton_RuidaMemberDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_RuidaMemberDown.Enabled = false;
      this.toolButton_RuidaMemberDown.Image = (Image) componentResourceManager.GetObject("toolButton_RuidaMemberDown.Image");
      this.toolButton_RuidaMemberDown.ImageTransparentColor = Color.Magenta;
      this.toolButton_RuidaMemberDown.Name = "toolButton_RuidaMemberDown";
      this.toolButton_RuidaMemberDown.Size = new Size(23, 22);
      this.toolButton_RuidaMemberDown.Text = "toolStripButton5";
      this.toolButton_RuidaMemberDown.ToolTipText = "Move Down";
      this.toolButton_RuidaMemberDown.Click += new EventHandler(this.toolButton_RuidaMemberDown_Click);
      this.toolButton_PartyIn.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_PartyIn.Enabled = false;
      this.toolButton_PartyIn.Image = (Image) componentResourceManager.GetObject("toolButton_PartyIn.Image");
      this.toolButton_PartyIn.ImageTransparentColor = Color.Magenta;
      this.toolButton_PartyIn.Name = "toolButton_PartyIn";
      this.toolButton_PartyIn.Size = new Size(23, 22);
      this.toolButton_PartyIn.Text = "toolStripButton6";
      this.toolButton_PartyIn.ToolTipText = "Add Party Members";
      this.toolButton_PartyIn.Click += new EventHandler(this.toolButton_PartyIn_Click);
      this.toolButton_CreateMember.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_CreateMember.Enabled = false;
      this.toolButton_CreateMember.Image = (Image) componentResourceManager.GetObject("toolButton_CreateMember.Image");
      this.toolButton_CreateMember.ImageTransparentColor = Color.Magenta;
      this.toolButton_CreateMember.Name = "toolButton_CreateMember";
      this.toolButton_CreateMember.Size = new Size(23, 22);
      this.toolButton_CreateMember.Text = "toolStripButton7";
      this.toolButton_CreateMember.ToolTipText = "Create a Character";
      this.toolButton_CreateMember.Click += new EventHandler(this.toolButton_CreateMember_Click);
      this.toolButton_DeleteMember.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_DeleteMember.Enabled = false;
      this.toolButton_DeleteMember.Image = (Image) componentResourceManager.GetObject("toolButton_DeleteMember.Image");
      this.toolButton_DeleteMember.ImageTransparentColor = Color.Magenta;
      this.toolButton_DeleteMember.Name = "toolButton_DeleteMember";
      this.toolButton_DeleteMember.Size = new Size(23, 22);
      this.toolButton_DeleteMember.Text = "toolStripButton8";
      this.toolButton_DeleteMember.ToolTipText = "Delete Character";
      this.toolButton_DeleteMember.Click += new EventHandler(this.toolButton_DeleteMember_Click);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(314, 20);
      this.label4.Name = "label4";
      this.label4.Size = new Size(29, 12);
      this.label4.TabIndex = 12;
      this.label4.Text = "Sex";
      this.comboBox_Sex.DropDownHeight = 200;
      this.comboBox_Sex.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Sex.FormattingEnabled = true;
      this.comboBox_Sex.IntegralHeight = false;
      this.comboBox_Sex.Items.AddRange(new object[2]
      {
        (object) "Male",
        (object) "Female"
      });
      this.comboBox_Sex.Location = new Point(339, 16);
      this.comboBox_Sex.Name = "comboBox_Sex";
      this.comboBox_Sex.Size = new Size(58, 20);
      this.comboBox_Sex.TabIndex = 2;
      this.comboBox_Sex.SelectedIndexChanged += new EventHandler(this.comboBox_Sex_SelectedIndexChanged);
      this.groupBox_Equipment.Controls.Add((Control) this.button_SelectAccessory);
      this.groupBox_Equipment.Controls.Add((Control) this.button_SelectShoe);
      this.groupBox_Equipment.Controls.Add((Control) this.button_SelectLowerBody);
      this.groupBox_Equipment.Controls.Add((Control) this.button_SelectArm);
      this.groupBox_Equipment.Controls.Add((Control) this.button_SelectUpperBody);
      this.groupBox_Equipment.Controls.Add((Control) this.button_SelectHead);
      this.groupBox_Equipment.Controls.Add((Control) this.button_SelectShield);
      this.groupBox_Equipment.Controls.Add((Control) this.button_SelectWeapon);
      this.groupBox_Equipment.Controls.Add((Control) this.label12);
      this.groupBox_Equipment.Controls.Add((Control) this.label11);
      this.groupBox_Equipment.Controls.Add((Control) this.label10);
      this.groupBox_Equipment.Controls.Add((Control) this.label9);
      this.groupBox_Equipment.Controls.Add((Control) this.label8);
      this.groupBox_Equipment.Controls.Add((Control) this.label7);
      this.groupBox_Equipment.Controls.Add((Control) this.label6);
      this.groupBox_Equipment.Controls.Add((Control) this.label5);
      this.groupBox_Equipment.Location = new Point(362, 73);
      this.groupBox_Equipment.Name = "groupBox_Equipment";
      this.groupBox_Equipment.Size = new Size(239, 201);
      this.groupBox_Equipment.TabIndex = 10;
      this.groupBox_Equipment.TabStop = false;
      this.groupBox_Equipment.Text = "Equip";
      this.button_SelectAccessory.Location = new Point(186, 167);
      this.button_SelectAccessory.Name = "button_SelectAccessory";
      this.button_SelectAccessory.Size = new Size(39, 19);
      this.button_SelectAccessory.TabIndex = 7;
      this.button_SelectAccessory.Text = "Set";
      this.button_SelectAccessory.UseVisualStyleBackColor = true;
      this.button_SelectAccessory.Click += new EventHandler(this.button_SelectAccessory_Click);
      this.button_SelectShoe.Location = new Point(186, 146);
      this.button_SelectShoe.Name = "button_SelectShoe";
      this.button_SelectShoe.Size = new Size(39, 19);
      this.button_SelectShoe.TabIndex = 6;
      this.button_SelectShoe.Text = "Set";
      this.button_SelectShoe.UseVisualStyleBackColor = true;
      this.button_SelectShoe.Click += new EventHandler(this.button_SelectShoe_Click);
      this.button_SelectLowerBody.Location = new Point(186, 125);
      this.button_SelectLowerBody.Name = "button_SelectLowerBody";
      this.button_SelectLowerBody.Size = new Size(39, 19);
      this.button_SelectLowerBody.TabIndex = 5;
      this.button_SelectLowerBody.Text = "Set";
      this.button_SelectLowerBody.UseVisualStyleBackColor = true;
      this.button_SelectLowerBody.Click += new EventHandler(this.button_SelectLowerBody_Click);
      this.button_SelectArm.Location = new Point(186, 104);
      this.button_SelectArm.Name = "button_SelectArm";
      this.button_SelectArm.Size = new Size(39, 19);
      this.button_SelectArm.TabIndex = 4;
      this.button_SelectArm.Text = "Set";
      this.button_SelectArm.UseVisualStyleBackColor = true;
      this.button_SelectArm.Click += new EventHandler(this.button_SelectArm_Click);
      this.button_SelectUpperBody.Location = new Point(186, 83);
      this.button_SelectUpperBody.Name = "button_SelectUpperBody";
      this.button_SelectUpperBody.Size = new Size(39, 19);
      this.button_SelectUpperBody.TabIndex = 3;
      this.button_SelectUpperBody.Text = "Set";
      this.button_SelectUpperBody.UseVisualStyleBackColor = true;
      this.button_SelectUpperBody.Click += new EventHandler(this.button_SelectUpperBody_Click);
      this.button_SelectHead.Location = new Point(186, 62);
      this.button_SelectHead.Name = "button_SelectHead";
      this.button_SelectHead.Size = new Size(39, 19);
      this.button_SelectHead.TabIndex = 2;
      this.button_SelectHead.Text = "Set";
      this.button_SelectHead.UseVisualStyleBackColor = true;
      this.button_SelectHead.Click += new EventHandler(this.button_SelectHead_Click);
      this.button_SelectShield.Location = new Point(186, 41);
      this.button_SelectShield.Name = "button_SelectShield";
      this.button_SelectShield.Size = new Size(39, 19);
      this.button_SelectShield.TabIndex = 1;
      this.button_SelectShield.Text = "Set";
      this.button_SelectShield.UseVisualStyleBackColor = true;
      this.button_SelectShield.Click += new EventHandler(this.button_SelectShield_Click);
      this.button_SelectWeapon.Location = new Point(186, 20);
      this.button_SelectWeapon.Name = "button_SelectWeapon";
      this.button_SelectWeapon.Size = new Size(39, 19);
      this.button_SelectWeapon.TabIndex = 0;
      this.button_SelectWeapon.Text = "Set";
      this.button_SelectWeapon.UseVisualStyleBackColor = true;
      this.button_SelectWeapon.Click += new EventHandler(this.button_SelectWeapon_Click);
      this.label12.AutoSize = true;
      this.label12.Location = new Point(14, 170);
      this.label12.Name = "label12";
      this.label12.Size = new Size(59, 12);
      this.label12.TabIndex = 7;
      this.label12.Text = "Accessory";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(42, 149);
      this.label11.Name = "label11";
      this.label11.Size = new Size(17, 12);
      this.label11.TabIndex = 6;
      this.label11.Text = "Feet";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(40, 128);
      this.label10.Name = "label10";
      this.label10.Size = new Size(41, 12);
      this.label10.TabIndex = 5;
      this.label10.Text = "Legs";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(39, 107);
      this.label9.Name = "label9";
      this.label9.Size = new Size(17, 12);
      this.label9.TabIndex = 4;
      this.label9.Text = "Arms";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(36, 86);
      this.label8.Name = "label8";
      this.label8.Size = new Size(17, 12);
      this.label8.TabIndex = 3;
      this.label8.Text = "Torso";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(37, 65);
      this.label7.Name = "label7";
      this.label7.Size = new Size(17, 12);
      this.label7.TabIndex = 2;
      this.label7.Text = "Head";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(34, 44);
      this.label6.Name = "label6";
      this.label6.Size = new Size(17, 12);
      this.label6.TabIndex = 1;
      this.label6.Text = "Shield";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(22, 23);
      this.label5.Name = "label5";
      this.label5.Size = new Size(29, 12);
      this.label5.TabIndex = 0;
      this.label5.Text = "Weapon";
      this.groupBox_Figure.Controls.Add((Control) this.label21);
      this.groupBox_Figure.Controls.Add((Control) this.label20);
      this.groupBox_Figure.Controls.Add((Control) this.button_FacePreset);
      this.groupBox_Figure.Controls.Add((Control) this.button_HairColorPreset);
      this.groupBox_Figure.Controls.Add((Control) this.button_HairPreset);
      this.groupBox_Figure.Controls.Add((Control) this.button_FigurePreset);
      this.groupBox_Figure.Controls.Add((Control) this.label18);
      this.groupBox_Figure.Controls.Add((Control) this.label19);
      this.groupBox_Figure.Controls.Add((Control) this.label17);
      this.groupBox_Figure.Controls.Add((Control) this.label16);
      this.groupBox_Figure.Controls.Add((Control) this.label15);
      this.groupBox_Figure.Controls.Add((Control) this.label14);
      this.groupBox_Figure.Controls.Add((Control) this.label13);
      this.groupBox_Figure.Location = new Point(608, 88);
      this.groupBox_Figure.Name = "groupBox_Figure";
      this.groupBox_Figure.Size = new Size(207, 186);
      this.groupBox_Figure.TabIndex = 11;
      this.groupBox_Figure.TabStop = false;
      this.groupBox_Figure.Text = "Appearance";
      this.label21.AutoSize = true;
      this.label21.Location = new Point(134, 150);
      this.label21.Name = "label21";
      this.label21.Size = new Size(51, 12);
      this.label21.TabIndex = 20;
      this.label21.Text = "(0 - 15)";
      this.label20.AutoSize = true;
      this.label20.Location = new Point(134, 129);
      this.label20.Name = "label20";
      this.label20.Size = new Size(45, 12);
      this.label20.TabIndex = 19;
      this.label20.Text = "(0 - 7)";
      this.button_FacePreset.Location = new Point(134, 106);
      this.button_FacePreset.Name = "button_FacePreset";
      this.button_FacePreset.Size = new Size(60, 19);
      this.button_FacePreset.TabIndex = 3;
      this.button_FacePreset.Text = "Preset";
      this.button_FacePreset.UseVisualStyleBackColor = true;
      this.button_FacePreset.Click += new EventHandler(this.button_FacePreset_Click);
      this.button_HairColorPreset.Location = new Point(134, 85);
      this.button_HairColorPreset.Name = "button_HairColorPreset";
      this.button_HairColorPreset.Size = new Size(60, 19);
      this.button_HairColorPreset.TabIndex = 2;
      this.button_HairColorPreset.Text = "Preset";
      this.button_HairColorPreset.UseVisualStyleBackColor = true;
      this.button_HairColorPreset.Click += new EventHandler(this.button_HairColorPreset_Click);
      this.button_HairPreset.Location = new Point(134, 64);
      this.button_HairPreset.Name = "button_HairPreset";
      this.button_HairPreset.Size = new Size(60, 19);
      this.button_HairPreset.TabIndex = 1;
      this.button_HairPreset.Text = "Preset";
      this.button_HairPreset.UseVisualStyleBackColor = true;
      this.button_HairPreset.Click += new EventHandler(this.button_HairPreset_Click);
      this.button_FigurePreset.Location = new Point(134, 43);
      this.button_FigurePreset.Name = "button_FigurePreset";
      this.button_FigurePreset.Size = new Size(60, 19);
      this.button_FigurePreset.TabIndex = 0;
      this.button_FigurePreset.Text = "Preset";
      this.button_FigurePreset.UseVisualStyleBackColor = true;
      this.button_FigurePreset.Click += new EventHandler(this.button_FigurePreset_Click);
      this.label18.AutoSize = true;
      this.label18.Location = new Point(20, 150);
      this.label18.Name = "label18";
      this.label18.Size = new Size(39, 12);
      this.label18.TabIndex = 6;
      this.label18.Text = "Eye Color";
      this.label19.AutoSize = true;
      this.label19.Location = new Point(17, 129);
      this.label19.Name = "label19";
      this.label19.Size = new Size(39, 12);
      this.label19.TabIndex = 5;
      this.label19.Text = "Skin Color";
      this.label17.AutoSize = true;
      this.label17.Location = new Point(40, 108);
      this.label17.Name = "label17";
      this.label17.Size = new Size(17, 12);
      this.label17.TabIndex = 4;
      this.label17.Text = "Face";
      this.label16.AutoSize = true;
      this.label16.Location = new Point(18, 87);
      this.label16.Name = "label16";
      this.label16.Size = new Size(39, 12);
      this.label16.TabIndex = 3;
      this.label16.Text = "Hair Color";
      this.label15.AutoSize = true;
      this.label15.Location = new Point(20, 66);
      this.label15.Name = "label15";
      this.label15.Size = new Size(29, 12);
      this.label15.TabIndex = 2;
      this.label15.Text = "Hair Style";
      this.label14.AutoSize = true;
      this.label14.Location = new Point(23, 45);
      this.label14.Name = "label14";
      this.label14.Size = new Size(53, 12);
      this.label14.TabIndex = 1;
      this.label14.Text = "Body (H)";
      this.label13.AutoSize = true;
      this.label13.Location = new Point(20, 24);
      this.label13.Name = "label13";
      this.label13.Size = new Size(53, 12);
      this.label13.TabIndex = 0;
      this.label13.Text = "Body (W)";
      this.label22.AutoSize = true;
      this.label22.Location = new Point(13, 22);
      this.label22.Name = "label22";
      this.label22.Size = new Size(70, 12);
      this.label22.TabIndex = 16;
      this.label22.Text = "Skill Points";
      this.label23.AutoSize = true;
      this.label23.Location = new Point(310, 45);
      this.label23.Name = "label23";
      this.label23.Size = new Size(29, 12);
      this.label23.TabIndex = 18;
      this.label23.Text = "Row";
      this.comboBox_Rank.DropDownHeight = 200;
      this.comboBox_Rank.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Rank.FormattingEnabled = true;
      this.comboBox_Rank.IntegralHeight = false;
      this.comboBox_Rank.Items.AddRange(new object[2]
      {
        (object) "Front",
        (object) "Back"
      });
      this.comboBox_Rank.Location = new Point(339, 41);
      this.comboBox_Rank.Name = "comboBox_Rank";
      this.comboBox_Rank.Size = new Size(58, 20);
      this.comboBox_Rank.TabIndex = 5;
      this.comboBox_Rank.SelectedIndexChanged += new EventHandler(this.comboBox_Rank_SelectedIndexChanged);
      this.label24.AutoSize = true;
      this.label24.Location = new Point(162, 45);
      this.label24.Name = "label24";
      this.label24.Size = new Size(29, 12);
      this.label24.TabIndex = 20;
      this.label24.Text = "Tactics";
      this.comboBox_Strategy.DropDownHeight = 200;
      this.comboBox_Strategy.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Strategy.FormattingEnabled = true;
      this.comboBox_Strategy.IntegralHeight = false;
      this.comboBox_Strategy.Location = new Point(201, 41);
      this.comboBox_Strategy.Name = "comboBox_Strategy";
      this.comboBox_Strategy.Size = new Size(100, 20);
      this.comboBox_Strategy.TabIndex = 4;
      this.comboBox_Strategy.SelectedIndexChanged += new EventHandler(this.comboBox_Strategy_SelectedIndexChanged);
      this.comboBox_Color.DropDownHeight = 200;
      this.comboBox_Color.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Color.FormattingEnabled = true;
      this.comboBox_Color.IntegralHeight = false;
      this.comboBox_Color.Items.AddRange(new object[16]
      {
        (object) "Orange",
        (object) "Yellow",
        (object) "Light Green",
        (object) "Dark Green",
        (object) "Red",
        (object) "Pink",
        (object) "Green",
        (object) "Blue",
        (object) "Dark Purple",
        (object) "Light Purple",
        (object) "Purple",
        (object) "Turquoise",
        (object) "Black",
        (object) "Brown",
        (object) "Gray",
        (object) "White"
      });
      this.comboBox_Color.Location = new Point(455, 42);
      this.comboBox_Color.Name = "comboBox_Color";
      this.comboBox_Color.Size = new Size(93, 20);
      this.comboBox_Color.TabIndex = 6;
      this.comboBox_Color.SelectedIndexChanged += new EventHandler(this.comboBox_Color_SelectedIndexChanged);
      this.label25.AutoSize = true;
      this.label25.Location = new Point(418, 45);
      this.label25.Name = "label25";
      this.label25.Size = new Size(17, 12);
      this.label25.TabIndex = 22;
      this.label25.Text = "Color";
      this.groupBox_Tool.Location = new Point(172, 73);
      this.groupBox_Tool.Name = "groupBox_Tool";
      this.groupBox_Tool.Size = new Size(183, 201);
      this.groupBox_Tool.TabIndex = 9;
      this.groupBox_Tool.TabStop = false;
      this.groupBox_Tool.Text = "Items";
      this.label26.AutoSize = true;
      this.label26.Location = new Point(558, 20);
      this.label26.Name = "label26";
      this.label26.Size = new Size(20, 12);
      this.label26.TabIndex = 27;
      this.label26.Text = "HP";
      this.label27.AutoSize = true;
      this.label27.Location = new Point(558, 45);
      this.label27.Name = "label27";
      this.label27.Size = new Size(20, 12);
      this.label27.TabIndex = 28;
      this.label27.Text = "MP";
      this._numericUpDown_NowHP.Location = new Point(579, 17);
      this._numericUpDown_NowHP.Name = "_numericUpDown_NowHP";
      this._numericUpDown_NowHP.Size = new Size(48, 19);
      this._numericUpDown_NowHP.TabIndex = 7;
      this._numericUpDown_NowHP.Value = new Decimal(new int[4]);
      this._numericUpDown_NowHP.ValueChanged += new EventHandler(this._numericUpDown_NowHP_ValueChanged);
      this._numericUpDown_NowHP.Leave += new EventHandler(this._numericUpDown_NowHPMP_Leave);
      this._numericUpDown_NowHP.Enter += new EventHandler(this._numericUpDown_NowHPMP_Enter);
      this._numericUpDown_NowMP.Location = new Point(579, 42);
      this._numericUpDown_NowMP.Name = "_numericUpDown_NowMP";
      this._numericUpDown_NowMP.Size = new Size(48, 19);
      this._numericUpDown_NowMP.TabIndex = 8;
      this._numericUpDown_NowMP.Value = new Decimal(new int[4]);
      this._numericUpDown_NowMP.ValueChanged += new EventHandler(this._numericUpDown_NowMP_ValueChanged);
      this._numericUpDown_NowMP.Leave += new EventHandler(this._numericUpDown_NowHPMP_Leave);
      this._numericUpDown_NowMP.Enter += new EventHandler(this._numericUpDown_NowHPMP_Enter);
      this.label_MaxHP.AutoSize = true;
      this.label_MaxHP.Location = new Point(630, 20);
      this.label_MaxHP.Name = "label_MaxHP";
      this.label_MaxHP.Size = new Size(44, 12);
      this.label_MaxHP.TabIndex = 31;
      this.label_MaxHP.Text = "Max HP";
      this.label_MaxMP.AutoSize = true;
      this.label_MaxMP.Location = new Point(629, 45);
      this.label_MaxMP.Name = "label_MaxMP";
      this.label_MaxMP.Size = new Size(45, 12);
      this.label_MaxMP.TabIndex = 33;
      this.label_MaxMP.Text = "Max MP";
      this.groupBox_Status.Controls.Add((Control) this.GroupBox_SkillSpecialty);
      this.groupBox_Status.Controls.Add((Control) this._numericUpDown_Transmigration);
      this.groupBox_Status.Controls.Add((Control) this.label40);
      this.groupBox_Status.Controls.Add((Control) this.groupBox_Skill);
      this.groupBox_Status.Controls.Add((Control) this.groupBox_StatusRevise);
      this.groupBox_Status.Controls.Add((Control) this._numericUpDown_Experience);
      this.groupBox_Status.Controls.Add((Control) this.label30);
      this.groupBox_Status.Controls.Add((Control) this._numericUpDown_Level);
      this.groupBox_Status.Controls.Add((Control) this.label29);
      this.groupBox_Status.Controls.Add((Control) this.comboBox_StatusEditJob);
      this.groupBox_Status.Controls.Add((Control) this.label28);
      this.groupBox_Status.Controls.Add((Control) this.label22);
      this.groupBox_Status.Location = new Point(112, 284);
      this.groupBox_Status.Name = "groupBox_Status";
      this.groupBox_Status.Size = new Size(703, 235);
      this.groupBox_Status.TabIndex = 12;
      this.groupBox_Status.TabStop = false;
      this.groupBox_Status.Text = "Status";
      this.GroupBox_SkillSpecialty.Controls.Add((Control) this.comboBox_SkillSpecialty);
      this.GroupBox_SkillSpecialty.Controls.Add((Control) this.checkBox_Cheer);
      this.GroupBox_SkillSpecialty.Controls.Add((Control) this.checkBox_Ruler);
      this.GroupBox_SkillSpecialty.Controls.Add((Control) this.checkedListBox_Skill);
      this.GroupBox_SkillSpecialty.Controls.Add((Control) this.label42);
      this.GroupBox_SkillSpecialty.Controls.Add((Control) this.label41);
      this.GroupBox_SkillSpecialty.Controls.Add((Control) this.checkedListBox_Specialty);
      this.GroupBox_SkillSpecialty.Location = new Point(7, 43);
      this.GroupBox_SkillSpecialty.Name = "GroupBox_SkillSpecialty";
      this.GroupBox_SkillSpecialty.Size = new Size(354, 186);
      this.GroupBox_SkillSpecialty.TabIndex = 0;
      this.GroupBox_SkillSpecialty.TabStop = false;
      this.GroupBox_SkillSpecialty.Text = "Skills / Abilities Effects";
      this.comboBox_SkillSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_SkillSpecialty.FormattingEnabled = true;
      this.comboBox_SkillSpecialty.Location = new Point(10, 44);
      this.comboBox_SkillSpecialty.Name = "comboBox_SkillSpecialty";
      this.comboBox_SkillSpecialty.Size = new Size(171, 20);
      this.comboBox_SkillSpecialty.TabIndex = 2;
      this.comboBox_SkillSpecialty.SelectedIndexChanged += new EventHandler(this.comboBox_SkillSpecialty_SelectedIndexChanged);
      this.checkBox_Cheer.AutoSize = true;
      this.checkBox_Cheer.Location = new Point(72, 22);
      this.checkBox_Cheer.Name = "checkBox_Cheer";
      this.checkBox_Cheer.Size = new Size(60, 16);
      this.checkBox_Cheer.TabIndex = 1;
      this.checkBox_Cheer.Text = "Egg On";
      this.checkBox_Cheer.UseVisualStyleBackColor = true;
      this.checkBox_Cheer.CheckedChanged += new EventHandler(this.checkBox_Cheer_CheckedChanged);
      this.checkBox_Ruler.AutoSize = true;
      this.checkBox_Ruler.Location = new Point(11, 22);
      this.checkBox_Ruler.Name = "checkBox_Ruler";
      this.checkBox_Ruler.Size = new Size(52, 16);
      this.checkBox_Ruler.TabIndex = 0;
      this.checkBox_Ruler.Text = "Zoom";
      this.checkBox_Ruler.UseVisualStyleBackColor = true;
      this.checkBox_Ruler.CheckedChanged += new EventHandler(this.checkBox_Ruler_CheckedChanged);
      this.checkedListBox_Skill.FormattingEnabled = true;
      this.checkedListBox_Skill.Location = new Point(166, 88);
      this.checkedListBox_Skill.Name = "checkedListBox_Skill";
      this.checkedListBox_Skill.Size = new Size(177, 100);
      this.checkedListBox_Skill.TabIndex = 4;
      this.checkedListBox_Skill.ItemCheck += new ItemCheckEventHandler(this.checkedListBox_Skill_ItemCheck);
      this.label42.AutoSize = true;
      this.label42.Location = new Point(164, 73);
      this.label42.Name = "label42";
      this.label42.Size = new Size(58, 12);
      this.label42.TabIndex = 43;
      this.label42.Text = "Traits";
      this.label41.AutoSize = true;
      this.label41.Location = new Point(11, 73);
      this.label41.Name = "label41";
      this.label41.Size = new Size(29, 12);
      this.label41.TabIndex = 45;
      this.label41.Text = "Abilities";
      this.checkedListBox_Specialty.FormattingEnabled = true;
      this.checkedListBox_Specialty.Location = new Point(10, 88);
      this.checkedListBox_Specialty.Name = "checkedListBox_Specialty";
      this.checkedListBox_Specialty.Size = new Size(147, 100);
      this.checkedListBox_Specialty.TabIndex = 3;
      this.checkedListBox_Specialty.ItemCheck += new ItemCheckEventHandler(this.checkedListBox_Specialty_ItemCheck);
      this._numericUpDown_Transmigration.Location = new Point(507, 44);
      this._numericUpDown_Transmigration.Maximum = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this._numericUpDown_Transmigration.Name = "_numericUpDown_Transmigration";
      this._numericUpDown_Transmigration.Size = new Size(38, 19);
      this._numericUpDown_Transmigration.TabIndex = 5;
      this._numericUpDown_Transmigration.Value = new Decimal(new int[4]);
      this._numericUpDown_Transmigration.ValueChanged += new EventHandler(this._numericUpDown_Transmigration_ValueChanged);
      this.label40.AutoSize = true;
      this.label40.Location = new Point(441, 47);
      this.label40.Name = "label40";
      this.label40.Size = new Size(29, 12);
      this.label40.TabIndex = 41;
      this.label40.Text = "Revocations";
      this.groupBox_Skill.Location = new Point(369, 97);
      this.groupBox_Skill.Name = "groupBox_Skill";
      this.groupBox_Skill.Size = new Size(172, 132);
      this.groupBox_Skill.TabIndex = 1;
      this.groupBox_Skill.TabStop = false;
      this.groupBox_Skill.Text = "Skill";
      this.groupBox_StatusRevise.Controls.Add((Control) this.label38);
      this.groupBox_StatusRevise.Controls.Add((Control) this.label34);
      this.groupBox_StatusRevise.Controls.Add((Control) this.label31);
      this.groupBox_StatusRevise.Controls.Add((Control) this.label36);
      this.groupBox_StatusRevise.Controls.Add((Control) this.label32);
      this.groupBox_StatusRevise.Controls.Add((Control) this.label37);
      this.groupBox_StatusRevise.Controls.Add((Control) this.label33);
      this.groupBox_StatusRevise.Controls.Add((Control) this.label39);
      this.groupBox_StatusRevise.Controls.Add((Control) this.label35);
      this.groupBox_StatusRevise.Location = new Point(553, 18);
      this.groupBox_StatusRevise.Name = "groupBox_StatusRevise";
      this.groupBox_StatusRevise.Size = new Size(141, 211);
      this.groupBox_StatusRevise.TabIndex = 2;
      this.groupBox_StatusRevise.TabStop = false;
      this.groupBox_StatusRevise.Text = "Seeds";
      this.label38.AutoSize = true;
      this.label38.Location = new Point(43, 147);
      this.label38.Name = "label38";
      this.label38.Size = new Size(37, 12);
      this.label38.TabIndex = 59;
      this.label38.Text = "Charm";
      this.label34.AutoSize = true;
      this.label34.Location = new Point(35, 21);
      this.label34.Name = "label34";
      this.label34.Size = new Size(44, 12);
      this.label34.TabIndex = 45;
      this.label34.Text = "Max HP";
      this.label31.AutoSize = true;
      this.label31.Location = new Point(32, 63);
      this.label31.Name = "label31";
      this.label31.Size = new Size(32, 12);
      this.label31.TabIndex = 41;
      this.label31.Text = "Strength";
      this.label36.AutoSize = true;
      this.label36.Location = new Point(7, 189);
      this.label36.Name = "label36";
      this.label36.Size = new Size(63, 12);
      this.label36.TabIndex = 57;
      this.label36.Text = "Magical Might";
      this.label32.AutoSize = true;
      this.label32.Location = new Point(31, 126);
      this.label32.Name = "label32";
      this.label32.Size = new Size(38, 12);
      this.label32.TabIndex = 43;
      this.label32.Text = "Deftness";
      this.label37.AutoSize = true;
      this.label37.Location = new Point(24, 105);
      this.label37.Name = "label37";
      this.label37.Size = new Size(50, 12);
      this.label37.TabIndex = 55;
      this.label37.Text = "Resilience";
      this.label33.AutoSize = true;
      this.label33.Location = new Point(34, 42);
      this.label33.Name = "label33";
      this.label33.Size = new Size(45, 12);
      this.label33.TabIndex = 47;
      this.label33.Text = "Max MP";
      this.label39.AutoSize = true;
      this.label39.Location = new Point(6, 168);
      this.label39.Name = "label39";
      this.label39.Size = new Size(65, 12);
      this.label39.TabIndex = 51;
      this.label39.Text = "Magical Mend";
      this.label35.AutoSize = true;
      this.label35.Location = new Point(45, 84);
      this.label35.Name = "label35";
      this.label35.Size = new Size(43, 12);
      this.label35.TabIndex = 49;
      this.label35.Text = "Agility";
      this._numericUpDown_Experience.Location = new Point(465, 69);
      this._numericUpDown_Experience.Name = "_numericUpDown_Experience";
      this._numericUpDown_Experience.Size = new Size(80, 19);
      this._numericUpDown_Experience.TabIndex = 6;
      this._numericUpDown_Experience.Value = new Decimal(new int[4]);
      this._numericUpDown_Experience.ValueChanged += new EventHandler(this._numericUpDown_Experience_ValueChanged);
      this.label30.AutoSize = true;
      this.label30.Location = new Point(431, 73);
      this.label30.Name = "label30";
      this.label30.Size = new Size(41, 12);
      this.label30.TabIndex = 39;
      this.label30.Text = "Exp.";
      this._numericUpDown_Level.Location = new Point(403, 44);
      this._numericUpDown_Level.Name = "_numericUpDown_Level";
      this._numericUpDown_Level.Size = new Size(38, 19);
      this._numericUpDown_Level.TabIndex = 4;
      this._numericUpDown_Level.Value = new Decimal(new int[4]);
      this._numericUpDown_Level.ValueChanged += new EventHandler(this._numericUpDown_Level_ValueChanged);
      this.label29.AutoSize = true;
      this.label29.Location = new Point(368, 48);
      this.label29.Name = "label29";
      this.label29.Size = new Size(34, 12);
      this.label29.TabIndex = 37;
      this.label29.Text = "Level";
      this.comboBox_StatusEditJob.DropDownHeight = 200;
      this.comboBox_StatusEditJob.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_StatusEditJob.FormattingEnabled = true;
      this.comboBox_StatusEditJob.IntegralHeight = false;
      this.comboBox_StatusEditJob.Location = new Point(453, 18);
      this.comboBox_StatusEditJob.Name = "comboBox_StatusEditJob";
      this.comboBox_StatusEditJob.Size = new Size(92, 20);
      this.comboBox_StatusEditJob.TabIndex = 3;
      this.comboBox_StatusEditJob.SelectedIndexChanged += new EventHandler(this.comboBox_StatusEditJob_SelectedIndexChanged);
      this.label28.AutoSize = true;
      this.label28.Location = new Point(369, 22);
      this.label28.Name = "label28";
      this.label28.Size = new Size(72, 12);
      this.label28.TabIndex = 35;
      this.label28.Text = "Vocation to Edit";
      this.GroupBox_State.Controls.Add((Control) this.checkBox_Curse);
      this.GroupBox_State.Controls.Add((Control) this.checkBox_Poison);
      this.GroupBox_State.Controls.Add((Control) this.checkBox_Die);
      this.GroupBox_State.Location = new Point(706, 5);
      this.GroupBox_State.Name = "GroupBox_State";
      this.GroupBox_State.Size = new Size(109, 67);
      this.GroupBox_State.TabIndex = 34;
      this.GroupBox_State.TabStop = false;
      this.GroupBox_State.Text = "State";
      this.checkBox_Curse.AutoSize = true;
      this.checkBox_Curse.Location = new Point(10, 41);
      this.checkBox_Curse.Name = "checkBox_Curse";
      this.checkBox_Curse.Size = new Size(53, 16);
      this.checkBox_Curse.TabIndex = 2;
      this.checkBox_Curse.Text = "Cursed";
      this.checkBox_Curse.UseVisualStyleBackColor = true;
      this.checkBox_Curse.CheckedChanged += new EventHandler(this.checkBox_Curse_CheckedChanged);
      this.checkBox_Poison.AutoSize = true;
      this.checkBox_Poison.Location = new Point(57, 20);
      this.checkBox_Poison.Name = "checkBox_Poison";
      this.checkBox_Poison.Size = new Size(39, 16);
      this.checkBox_Poison.TabIndex = 1;
      this.checkBox_Poison.Text = "Poison";
      this.checkBox_Poison.UseVisualStyleBackColor = true;
      this.checkBox_Poison.CheckedChanged += new EventHandler(this.checkBox_Poison_CheckedChanged);
      this.checkBox_Die.AutoSize = true;
      this.checkBox_Die.Location = new Point(10, 20);
      this.checkBox_Die.Name = "checkBox_Die";
      this.checkBox_Die.Size = new Size(42, 16);
      this.checkBox_Die.TabIndex = 0;
      this.checkBox_Die.Text = "Dead";
      this.checkBox_Die.UseVisualStyleBackColor = true;
      this.checkBox_Die.CheckedChanged += new EventHandler(this.checkBox_Die_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.GroupBox_State);
      this.Controls.Add((Control) this.groupBox_Status);
      this.Controls.Add((Control) this.label_MaxMP);
      this.Controls.Add((Control) this.label_MaxHP);
      this.Controls.Add((Control) this._numericUpDown_NowMP);
      this.Controls.Add((Control) this._numericUpDown_NowHP);
      this.Controls.Add((Control) this.label27);
      this.Controls.Add((Control) this.label26);
      this.Controls.Add((Control) this.groupBox_Tool);
      this.Controls.Add((Control) this.comboBox_Color);
      this.Controls.Add((Control) this.label25);
      this.Controls.Add((Control) this.comboBox_Strategy);
      this.Controls.Add((Control) this.label24);
      this.Controls.Add((Control) this.comboBox_Rank);
      this.Controls.Add((Control) this.label23);
      this.Controls.Add((Control) this.groupBox_Figure);
      this.Controls.Add((Control) this.groupBox_Equipment);
      this.Controls.Add((Control) this.comboBox_Sex);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.comboBox_Job);
      this.Controls.Add((Control) this.label_Job);
      this.Controls.Add((Control) this.label_Name);
      this.Name = nameof (CharacterDataControl);
      this.Size = new Size(846, 525);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.groupBox_Equipment.ResumeLayout(false);
      this.groupBox_Equipment.PerformLayout();
      this.groupBox_Figure.ResumeLayout(false);
      this.groupBox_Figure.PerformLayout();
      this._numericUpDown_NowHP.EndInit();
      this._numericUpDown_NowMP.EndInit();
      this.groupBox_Status.ResumeLayout(false);
      this.groupBox_Status.PerformLayout();
      this.GroupBox_SkillSpecialty.ResumeLayout(false);
      this.GroupBox_SkillSpecialty.PerformLayout();
      this._numericUpDown_Transmigration.EndInit();
      this.groupBox_StatusRevise.ResumeLayout(false);
      this.groupBox_StatusRevise.PerformLayout();
      this._numericUpDown_Experience.EndInit();
      this._numericUpDown_Level.EndInit();
      this.GroupBox_State.ResumeLayout(false);
      this.GroupBox_State.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public SafeNumericUpDown NumericUpDown_Experience => this._numericUpDown_Experience;

    public SafeNumericUpDown NumericUpDown_Level => this._numericUpDown_Level;

    public SafeNumericUpDown NumericUpDown_NowHP => this._numericUpDown_NowHP;

    public SafeNumericUpDown NumericUpDown_NowMP => this._numericUpDown_NowMP;

    public VisionNumericUpDown NumericUpDown_Hair => this._numericUpDown_Hair;

    public VisionNumericUpDown NumericUpDown_FigureHeight => this._numericUpDown_FigureHeight;

    public VisionNumericUpDown NumericUpDown_FigureWidth => this._numericUpDown_FigureWidth;

    public VisionNumericUpDown NumericUpDown_EyeColor => this._numericUpDown_EyeColor;

    public VisionNumericUpDown NumericUpDown_SkinColor => this._numericUpDown_SkinColor;

    public VisionNumericUpDown NumericUpDown_Face => this._numericUpDown_Face;

    public VisionNumericUpDown NumericUpDown_HairColor => this._numericUpDown_HairColor;

    public VisionNumericUpDown NumericUpDown_SkillPoint => this._numericUpDown_SkillPoint;

    public void Initialize()
    {
      this.SuspendLayout();
      this.BeginUpdate();
      this.comboBox_Job.Items.Clear();
      this.comboBox_StatusEditJob.Items.Clear();
      foreach (JobData jobData in JobDataList.List)
      {
        this.comboBox_Job.Items.Add((object) jobData.Name);
        this.comboBox_StatusEditJob.Items.Add((object) jobData.Name);
      }
      this.comboBox_Job.SelectedIndex = 0;
      this.comboBox_StatusEditJob.SelectedIndex = 0;
      this.comboBox_Strategy.Items.Clear();
      foreach (object obj in StrategyList.List)
        this.comboBox_Strategy.Items.Add(obj);
      this.comboBox_Strategy.SelectedIndex = 0;
      for (int index = 0; index < 8; ++index)
      {
        this._textBox_Tools[index] = new VisionTextBox(16, 20 + 21 * index, 110, 19);
        this._textBox_Tools[index].ReadOnly = true;
        this._textBox_Tools[index].TabStop = false;
        this.groupBox_Tool.AddVisionControl((VisionControlBase) this._textBox_Tools[index]);
        this._button_SelectTools[index] = new VisionButton(129, 20 + 21 * index, 39, 19);
        this._button_SelectTools[index].Text = "Set";
        this._button_SelectTools[index].Click += new EventHandler(this.button_SelectTools_Click);
        this._button_SelectTools[index].Tag = (object) index;
        this.groupBox_Tool.AddVisionControl((VisionControlBase) this._button_SelectTools[index]);
        this._textBox_Equipment[index] = new VisionTextBox(70, 20 + 21 * index, 113, 19);
        this._textBox_Equipment[index].ReadOnly = true;
        this._textBox_Equipment[index].TabStop = false;
        this.groupBox_Equipment.AddVisionControl((VisionControlBase) this._textBox_Equipment[index]);
      }
      for (int index = 0; index < 5; ++index)
      {
        this._label_Skills[index] = new Label();
        this._label_Skills[index].AutoSize = false;
        this._label_Skills[index].TextAlign = ContentAlignment.MiddleRight;
        this._label_Skills[index].Location = new Point(12, 23 + index * 21);
        this._label_Skills[index].Size = new Size(90, 14);
        this._numericUpDown_Skills[index] = new VisionNumericUpDown(103, 20 + index * 21, 50, 19);
        this._numericUpDown_Skills[index].Tag = (object) index;
        this._numericUpDown_Skills[index].Minimum = 0M;
        this._numericUpDown_Skills[index].Maximum = 100M;
        this._numericUpDown_Skills[index].ValueChanged += new EventHandler(this.NumericUpDown_Skill_ValueChanged);
        this.groupBox_Skill.Controls.Add((Control) this._label_Skills[index]);
        this.groupBox_Skill.AddVisionControl((VisionControlBase) this._numericUpDown_Skills[index]);
      }
      this.groupBox_Tool.Enabled = false;
      this._textBox_CharacterName = new VisionTextBox(201, 17, 100, 19);
      this._textBox_CharacterName.TextChanged += new EventHandler(this.textBox_CharacterName_TextChanged);
      this._textBox_CharacterName.TabIndex = 1;
      this.AddVisionControl((VisionControlBase) this._textBox_CharacterName);
      this._numericUpDown_SkillPoint = new VisionNumericUpDown(87, 18, 56, 19);
      this._numericUpDown_SkillPoint.ValueChanged += new EventHandler(this._numericUpDown_SkillPoint_ValueChanged);
      this.groupBox_Status.AddVisionControl((VisionControlBase) this._numericUpDown_SkillPoint);
      int num1 = 1;
      int num2;
      this._numericUpDown_FigureWidth = new VisionNumericUpDown(72, num2 = num1 + 21, 56, 19);
      this._numericUpDown_FigureWidth.ValueChanged += new EventHandler(this._numericUpDown_FigureWidth_ValueChanged);
      this.groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDown_FigureWidth);
      int num3;
      this._numericUpDown_FigureHeight = new VisionNumericUpDown(72, num3 = num2 + 21, 56, 19);
      this._numericUpDown_FigureHeight.ValueChanged += new EventHandler(this._numericUpDown_FigureHeight_ValueChanged);
      this.groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDown_FigureHeight);
      int num4;
      this._numericUpDown_Hair = new VisionNumericUpDown(72, num4 = num3 + 21, 56, 19);
      this._numericUpDown_Hair.ValueChanged += new EventHandler(this._numericUpDown_Hair_ValueChanged);
      this.groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDown_Hair);
      int num5;
      this._numericUpDown_HairColor = new VisionNumericUpDown(72, num5 = num4 + 21, 56, 19);
      this._numericUpDown_HairColor.ValueChanged += new EventHandler(this._numericUpDown_HairColor_ValueChanged);
      this.groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDown_HairColor);
      int num6;
      this._numericUpDown_Face = new VisionNumericUpDown(72, num6 = num5 + 21, 56, 19);
      this._numericUpDown_Face.ValueChanged += new EventHandler(this._numericUpDown_Face_ValueChanged);
      this.groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDown_Face);
      int num7;
      this._numericUpDown_SkinColor = new VisionNumericUpDown(72, num7 = num6 + 21, 56, 19);
      this._numericUpDown_SkinColor.ValueChanged += new EventHandler(this._numericUpDown_SkinColor_ValueChanged);
      this.groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDown_SkinColor);
      int num8;
      this._numericUpDown_EyeColor = new VisionNumericUpDown(72, num8 = num7 + 21, 56, 19);
      this._numericUpDown_EyeColor.ValueChanged += new EventHandler(this._numericUpDown_EyeColor_ValueChanged);
      this.groupBox_Figure.AddVisionControl((VisionControlBase) this._numericUpDown_EyeColor);
      int num9 = -4;
      int num10;
      this._numericUpDown_ReviseHP = new VisionNumericUpDown(80, num10 = num9 + 21, 51, 19);
      this._numericUpDown_ReviseHP.Minimum = 0M;
      this._numericUpDown_ReviseHP.Maximum = 999M;
      this._numericUpDown_ReviseHP.ValueChanged += new EventHandler(this._numericUpDown_ReviseHP_ValueChanged);
      this.groupBox_StatusRevise.AddVisionControl((VisionControlBase) this._numericUpDown_ReviseHP);
      int num11;
      this._numericUpDown_ReviseMP = new VisionNumericUpDown(80, num11 = num10 + 21, 51, 19);
      this._numericUpDown_ReviseMP.Minimum = 0M;
      this._numericUpDown_ReviseMP.Maximum = 999M;
      this._numericUpDown_ReviseMP.ValueChanged += new EventHandler(this._numericUpDown_ReviseMP_ValueChanged);
      this.groupBox_StatusRevise.AddVisionControl((VisionControlBase) this._numericUpDown_ReviseMP);
      int num12;
      this._numericUpDown_RevisePower = new VisionNumericUpDown(80, num12 = num11 + 21, 51, 19);
      this._numericUpDown_RevisePower.Minimum = 0M;
      this._numericUpDown_RevisePower.Maximum = 999M;
      this._numericUpDown_RevisePower.ValueChanged += new EventHandler(this._numericUpDown_RevisePower_ValueChanged);
      this.groupBox_StatusRevise.AddVisionControl((VisionControlBase) this._numericUpDown_RevisePower);
      int num13;
      this._numericUpDown_ReviseQuick = new VisionNumericUpDown(80, num13 = num12 + 21, 51, 19);
      this._numericUpDown_ReviseQuick.Minimum = 0M;
      this._numericUpDown_ReviseQuick.Maximum = 999M;
      this._numericUpDown_ReviseQuick.ValueChanged += new EventHandler(this._numericUpDown_ReviseQuick_ValueChanged);
      this.groupBox_StatusRevise.AddVisionControl((VisionControlBase) this._numericUpDown_ReviseQuick);
      int num14;
      this._numericUpDown_ReviseDefense = new VisionNumericUpDown(80, num14 = num13 + 21, 51, 19);
      this._numericUpDown_ReviseDefense.Minimum = 0M;
      this._numericUpDown_ReviseDefense.Maximum = 999M;
      this._numericUpDown_ReviseDefense.ValueChanged += new EventHandler(this._numericUpDown_ReviseDefense_ValueChanged);
      this.groupBox_StatusRevise.AddVisionControl((VisionControlBase) this._numericUpDown_ReviseDefense);
      int num15;
      this._numericUpDown_ReviseFacility = new VisionNumericUpDown(80, num15 = num14 + 21, 51, 19);
      this._numericUpDown_ReviseFacility.Minimum = 0M;
      this._numericUpDown_ReviseFacility.Maximum = 999M;
      this._numericUpDown_ReviseFacility.ValueChanged += new EventHandler(this._numericUpDown_ReviseFacility_ValueChanged);
      this.groupBox_StatusRevise.AddVisionControl((VisionControlBase) this._numericUpDown_ReviseFacility);
      int num16;
      this._numericUpDown_ReviseSmart = new VisionNumericUpDown(80, num16 = num15 + 21, 51, 19);
      this._numericUpDown_ReviseSmart.Minimum = 0M;
      this._numericUpDown_ReviseSmart.Maximum = 999M;
      this._numericUpDown_ReviseSmart.ValueChanged += new EventHandler(this._numericUpDown_ReviseSmart_ValueChanged);
      this.groupBox_StatusRevise.AddVisionControl((VisionControlBase) this._numericUpDown_ReviseSmart);
      int num17;
      this._numericUpDown_ReviseRevivalMagic = new VisionNumericUpDown(80, num17 = num16 + 21, 51, 19);
      this._numericUpDown_ReviseRevivalMagic.Minimum = 0M;
      this._numericUpDown_ReviseRevivalMagic.Maximum = 999M;
      this._numericUpDown_ReviseRevivalMagic.ValueChanged += new EventHandler(this._numericUpDown_ReviseRevivalMagic_ValueChanged);
      this.groupBox_StatusRevise.AddVisionControl((VisionControlBase) this._numericUpDown_ReviseRevivalMagic);
      this._numericUpDown_ReviseAttackMagic = new VisionNumericUpDown(80, num8 = num17 + 21, 51, 19);
      this._numericUpDown_ReviseAttackMagic.Minimum = 0M;
      this._numericUpDown_ReviseAttackMagic.Maximum = 999M;
      this._numericUpDown_ReviseAttackMagic.ValueChanged += new EventHandler(this._numericUpDown_ReviseAttackMagic_ValueChanged);
      this.groupBox_StatusRevise.AddVisionControl((VisionControlBase) this._numericUpDown_ReviseAttackMagic);
      foreach (object obj in SkillDataList.List)
        this.comboBox_SkillSpecialty.Items.Add(obj);
      this.comboBox_SkillSpecialty.SelectedIndex = 0;
      this.RenewalSkillSpecialtyList();
      this.EndUpdate();
      this.ResumeLayout(false);
    }

    protected override void OnDataFileLoad()
    {
      this._selectedIndex = (int) SaveDataManager.Instance.SaveData.CharacterManager.CharacterStandbyCount;
      this.RenewalControl();
    }

    protected override void OnValueUpdate() => this.RenewalControl();

    private void RenewalMemberListBox()
    {
      this.BeginUpdate();
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      this.listBox_PartyMember.BeginUpdate();
      this.listBox_StandbyMember.BeginUpdate();
      this.listBox_PartyMember.Items.Clear();
      this.listBox_StandbyMember.Items.Clear();
      int num = 0;
      for (int index = 0; index < (int) characterManager.CharacterStandbyCount && index < 12; ++index)
        this.listBox_StandbyMember.Items.Add((object) characterManager.CharacterData[num++].Name.Value);
      for (int index = 0; index < (int) characterManager.PartyCharacterCount && num < 13; ++index)
        this.listBox_PartyMember.Items.Add((object) characterManager.CharacterData[num++].Name.Value);
      if (this._selectedIndex < this.listBox_StandbyMember.Items.Count)
        this.listBox_StandbyMember.SelectedIndex = this._selectedIndex;
      else if (this._selectedIndex - (int) characterManager.CharacterStandbyCount < this.listBox_PartyMember.Items.Count)
        this.listBox_PartyMember.SelectedIndex = this._selectedIndex - (int) characterManager.CharacterStandbyCount;
      else
        this.listBox_PartyMember.SelectedIndex = this.listBox_PartyMember.Items.Count - 1;
      this.listBox_PartyMember.EndUpdate();
      this.listBox_StandbyMember.EndUpdate();
      this.EndUpdate();
    }

    private void RenewalJobStatus()
    {
      this.BeginUpdate();
      CharacterData characterData = SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex];
      int dataIndex = JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex;
      this._numericUpDown_Level.Value = (Decimal) characterData.JobLevel[dataIndex].Value;
      this._numericUpDown_Experience.Value = (Decimal) characterData.JobExperience[dataIndex].Value;
      this._numericUpDown_Transmigration.Value = (Decimal) characterData.GetTransmigration(dataIndex);
      this._numericUpDown_RevisePower.Value = (Decimal) characterData.GetRevisePower(dataIndex);
      this._numericUpDown_ReviseQuick.Value = (Decimal) characterData.GetReviseQuick(dataIndex);
      this._numericUpDown_ReviseDefense.Value = (Decimal) characterData.GetReviseDefense(dataIndex);
      this._numericUpDown_ReviseFacility.Value = (Decimal) characterData.GetReviseFacility(dataIndex);
      this._numericUpDown_ReviseSmart.Value = (Decimal) characterData.GetReviseSmart(dataIndex);
      this._numericUpDown_ReviseRevivalMagic.Value = (Decimal) characterData.GetReviseRevivalMagic(dataIndex);
      this._numericUpDown_ReviseAttackMagic.Value = (Decimal) characterData.GetReviseAttackMagic(dataIndex);
      this._numericUpDown_ReviseHP.Value = (Decimal) characterData.GetReviseMaxHP(dataIndex);
      this._numericUpDown_ReviseMP.Value = (Decimal) characterData.GetReviseMaxMP(dataIndex);
      JobData jobData = JobDataList.GetJobData(dataIndex);
      if (jobData.SkillList == null)
      {
        this.groupBox_Skill.Enabled = false;
        for (int index = 0; index < 5; ++index)
        {
          this._label_Skills[index].Text = "-";
          this._numericUpDown_Skills[index].Value = 0M;
        }
      }
      else
      {
        this.groupBox_Skill.Enabled = true;
        for (int index = 0; index < 5; ++index)
        {
          this._label_Skills[index].Text = jobData.SkillList[index].Name;
          this._numericUpDown_Skills[index].Value = (Decimal) characterData.JobSkillLevel[jobData.SkillList[index].Index].Value;
        }
      }
      this.EndUpdate();
    }

    private void RenewalSkillSpecialtyList()
    {
      if (!(this.comboBox_SkillSpecialty.SelectedItem is SkillData selectedItem))
        return;
      this.checkedListBox_Specialty.BeginUpdate();
      this.checkedListBox_Skill.BeginUpdate();
      this.checkedListBox_Specialty.Items.Clear();
      this.checkedListBox_Skill.Items.Clear();
      foreach (object skillSpecialty in selectedItem.SkillSpecialtyList)
        this.checkedListBox_Specialty.Items.Add(skillSpecialty);
      foreach (object skillEffect in selectedItem.SkillEffectList)
        this.checkedListBox_Skill.Items.Add(skillEffect);
      this.checkedListBox_Specialty.EndUpdate();
      this.checkedListBox_Skill.EndUpdate();
    }

    private void RenewalSkillSpecialtyListState()
    {
      this.BeginUpdate();
      if (this.comboBox_SkillSpecialty.SelectedItem is SkillData selectedItem)
      {
        CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        int index1 = 0;
        foreach (SkillSpecialtyEffectData skillSpecialty in selectedItem.SkillSpecialtyList)
        {
          this.checkedListBox_Specialty.SetItemChecked(index1, characterManager.CharacterData[this._selectedIndex].IsLearnSkillSpecialtyEffect(skillSpecialty.Index));
          ++index1;
        }
        int index2 = 0;
        foreach (SkillSpecialtyEffectData skillEffect in selectedItem.SkillEffectList)
        {
          this.checkedListBox_Skill.SetItemChecked(index2, characterManager.CharacterData[this._selectedIndex].IsLearnSkillSpecialtyEffect(skillEffect.Index));
          ++index2;
        }
      }
      this.EndUpdate();
    }

    protected override void RenewalControl()
    {
      this.BeginUpdate();
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      this.RenewalMemberListBox();
      CharacterData characterData = characterManager.CharacterData[this._selectedIndex];
      this.checkBox_Die.Checked = characterData.Die;
      this.checkBox_Poison.Checked = characterData.Poison;
      this.checkBox_Curse.Checked = characterData.Curse;
      this._textBox_CharacterName.Text = characterData.Name.Value;
      this.comboBox_Sex.SelectedIndex = (int) characterData.Sex;
      for (int index = 0; index < JobDataList.List.Count; ++index)
      {
        if (JobDataList.List[index].DataIndex == (int) characterData.Job.Value)
        {
          this.comboBox_Job.SelectedIndex = index;
          break;
        }
      }
      this.RenewalJobStatus();
      this._numericUpDown_NowHP.Value = (Decimal) characterData.NowHP;
      this.label_MaxHP.Text = string.Format("(Max HP {0})", (object) characterData.MaxHP);
      this._numericUpDown_NowMP.Value = (Decimal) characterData.NowMP;
      this.label_MaxMP.Text = string.Format("(Max MP {0})", (object) characterData.MaxMP);
      this._numericUpDown_FigureWidth.Value = (Decimal) characterData.FigureWidth.Value;
      this._numericUpDown_FigureHeight.Value = (Decimal) characterData.FigureHeight.Value;
      this._numericUpDown_Hair.Value = (Decimal) characterData.HairType.Value;
      this._numericUpDown_HairColor.Value = (Decimal) characterData.HairColor.Value;
      this._numericUpDown_Face.Value = (Decimal) characterData.FaceType.Value;
      this._numericUpDown_SkinColor.Value = (Decimal) characterData.SkinColor;
      this._numericUpDown_EyeColor.Value = (Decimal) characterData.EyeColor;
      this._numericUpDown_SkillPoint.Value = (Decimal) characterData.SkillPoint.Value;
      ItemDataBase equipmentWeapon = characterData.EquipmentWeapon;
      this._textBox_Equipment[0].Text = equipmentWeapon != null ? equipmentWeapon.Name : "Nothing";
      ItemDataBase equipmentShield = characterData.EquipmentShield;
      this._textBox_Equipment[1].Text = equipmentShield != null ? equipmentShield.Name : "Nothing";
      ItemDataBase equipmentHead = characterData.EquipmentHead;
      this._textBox_Equipment[2].Text = equipmentHead != null ? equipmentHead.Name : "Nothing";
      ItemDataBase equipmentUpperBody = characterData.EquipmentUpperBody;
      this._textBox_Equipment[3].Text = equipmentUpperBody != null ? equipmentUpperBody.Name : "Nothing";
      ItemDataBase equipmentArm = characterData.EquipmentArm;
      this._textBox_Equipment[4].Text = equipmentArm != null ? equipmentArm.Name : "Nothing";
      ItemDataBase equipmentLowerBody = characterData.EquipmentLowerBody;
      this._textBox_Equipment[5].Text = equipmentLowerBody != null ? equipmentLowerBody.Name : "Nothing";
      ItemDataBase equipmentShoe = characterData.EquipmentShoe;
      this._textBox_Equipment[6].Text = equipmentShoe != null ? equipmentShoe.Name : "Nothing";
      ItemDataBase equipmentAccessory = characterData.EquipmentAccessory;
      this._textBox_Equipment[7].Text = equipmentAccessory != null ? equipmentAccessory.Name : "Nothing";
      if (this._selectedIndex >= (int) characterManager.CharacterStandbyCount)
      {
        this.groupBox_Tool.Enabled = true;
        ItemData itemData = SaveDataManager.Instance.SaveData.ItemData;
        for (int toolIndex = 0; toolIndex < 8; ++toolIndex)
        {
          ItemDataBase tool = itemData.GetTool(this._selectedIndex - (int) characterManager.CharacterStandbyCount, toolIndex);
          this._textBox_Tools[toolIndex].Text = tool != null ? tool.Name : "Empty";
        }
      }
      else
      {
        this.groupBox_Tool.Enabled = false;
        for (int index = 0; index < 8; ++index)
          this._textBox_Tools[index].Text = string.Empty;
      }
      this.comboBox_Strategy.SelectedItem = (object) characterData.Strategy;
      this.comboBox_Rank.SelectedIndex = (int) characterData.Rank;
      this.comboBox_Color.SelectedIndex = (int) characterData.Color;
      this.checkBox_Ruler.Checked = characterData.IsLearnRular();
      this.checkBox_Cheer.Checked = characterData.IsLearnCheer();
      this.RenewalSkillSpecialtyListState();
      this.RenewalCharacterToolbar();
      this.EndUpdate();
    }

    private void RenewalCharacterToolbar()
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (this.listBox_PartyMember.SelectedIndex == -1)
      {
        this.toolButton_PartyMemberUp.Enabled = false;
        this.toolButton_PartyMemberDown.Enabled = false;
        this.toolButton_PartyOut.Enabled = false;
      }
      else if (this.listBox_PartyMember.SelectedIndex == 0)
      {
        this.toolButton_PartyMemberUp.Enabled = false;
        this.toolButton_PartyMemberDown.Enabled = characterManager.PartyCharacterCount > (byte) 1;
        this.toolButton_PartyOut.Enabled = characterManager.PartyCharacterCount > (byte) 1;
      }
      else if (this.listBox_PartyMember.SelectedIndex == (int) characterManager.PartyCharacterCount - 1)
      {
        this.toolButton_PartyMemberUp.Enabled = true;
        this.toolButton_PartyMemberDown.Enabled = false;
        this.toolButton_PartyOut.Enabled = true;
      }
      else
      {
        this.toolButton_PartyMemberUp.Enabled = true;
        this.toolButton_PartyMemberDown.Enabled = true;
        this.toolButton_PartyOut.Enabled = true;
      }
      this.toolButton_CreateMember.Enabled = characterManager.CharacterCount < (byte) 13;
      if (this.listBox_StandbyMember.SelectedIndex == -1)
      {
        this.toolButton_RuidaMemberUp.Enabled = false;
        this.toolButton_RuidaMemberDown.Enabled = false;
        this.toolButton_DeleteMember.Enabled = false;
        this.toolButton_PartyIn.Enabled = false;
      }
      else
      {
        this.toolButton_DeleteMember.Enabled = true;
        this.toolButton_PartyIn.Enabled = characterManager.PartyCharacterCount < (byte) 4;
        if (this.listBox_StandbyMember.SelectedIndex == 0)
        {
          this.toolButton_RuidaMemberUp.Enabled = false;
          this.toolButton_RuidaMemberDown.Enabled = characterManager.CharacterStandbyCount > (byte) 1;
        }
        else if (this.listBox_StandbyMember.SelectedIndex == (int) characterManager.CharacterStandbyCount - 1)
        {
          this.toolButton_RuidaMemberUp.Enabled = true;
          this.toolButton_RuidaMemberDown.Enabled = false;
        }
        else
        {
          this.toolButton_RuidaMemberUp.Enabled = true;
          this.toolButton_RuidaMemberDown.Enabled = true;
        }
      }
    }

    private void textBox_CharacterName_TextChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      characterManager.CharacterData[this._selectedIndex].Name.Value = this._textBox_CharacterName.Text;
      this._textBox_CharacterName.Text = characterManager.CharacterData[this._selectedIndex].Name.Value;
      this.RenewalMemberListBox();
    }

    private void toolButton_PartyIn_Click(object sender, EventArgs e)
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (this.listBox_StandbyMember.SelectedIndex == -1)
        return;
      characterManager.PartyIn(this.listBox_StandbyMember.SelectedIndex);
      this._selectedIndex = (int) characterManager.CharacterCount - 1;
      this.RenewalControl();
    }

    private void toolButton_PartyMemberUp_Click(object sender, EventArgs e)
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (this.listBox_PartyMember.SelectedIndex <= 0)
        return;
      characterManager.PartyMemberUp(this.listBox_PartyMember.SelectedIndex);
      --this._selectedIndex;
      this.RenewalControl();
    }

    private void toolButton_PartyMemberDown_Click(object sender, EventArgs e)
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (this.listBox_PartyMember.SelectedIndex >= (int) characterManager.PartyCharacterCount - 1 || this.listBox_PartyMember.SelectedIndex == -1)
        return;
      characterManager.PartyMemberDown(this.listBox_PartyMember.SelectedIndex);
      ++this._selectedIndex;
      this.RenewalControl();
    }

    private void toolButton_RuidaMemberUp_Click(object sender, EventArgs e)
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (this.listBox_StandbyMember.SelectedIndex <= 0)
        return;
      characterManager.StandbyMemberUp(this.listBox_StandbyMember.SelectedIndex);
      --this._selectedIndex;
      this.RenewalControl();
    }

    private void toolButton_RuidaMemberDown_Click(object sender, EventArgs e)
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (this.listBox_StandbyMember.SelectedIndex >= (int) characterManager.CharacterStandbyCount - 1 || this.listBox_StandbyMember.SelectedIndex == -1)
        return;
      characterManager.StandbyMemberDown(this.listBox_StandbyMember.SelectedIndex);
      ++this._selectedIndex;
      this.RenewalControl();
    }

    private void toolButton_PartyOut_Click(object sender, EventArgs e)
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (characterManager.PartyCharacterCount < (byte) 2)
        return;
      characterManager.PartyOut(this.listBox_PartyMember.SelectedIndex);
      this._selectedIndex = (int) characterManager.CharacterStandbyCount - 1;
      this.RenewalControl();
    }

    private void toolButton_DeleteMember_Click(object sender, EventArgs e)
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      int selectedIndex = this.listBox_StandbyMember.SelectedIndex;
      if (selectedIndex == -1 || MessageBox.Show(string.Format("キャラクター「{0}」を削除します。\nよろしいですか？", (object) characterManager.CharacterData[selectedIndex].Name.Value), "确定", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      characterManager.DeleteCharacter(selectedIndex);
      this._selectedIndex = 0;
      this.RenewalControl();
    }

    private void toolButton_CreateMember_Click(object sender, EventArgs e)
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (characterManager.CharacterCount >= (byte) 13)
        return;
      characterManager.CreateCharacter();
      this._selectedIndex = (int) characterManager.CharacterStandbyCount - 1;
      this.RenewalControl();
    }

    private void listBox_PartyMember_SelectedIndexChanged(object sender, EventArgs e)
    {
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (this._updateCount != 0 || this.listBox_PartyMember.SelectedIndex == -1)
        return;
      this._selectedIndex = (int) characterManager.CharacterStandbyCount + this.listBox_PartyMember.SelectedIndex;
      this.listBox_StandbyMember.SelectedIndex = -1;
      this.RenewalControl();
    }

    private void listBox_StandbyMember_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this.listBox_StandbyMember.SelectedIndex == -1)
        return;
      this._selectedIndex = this.listBox_StandbyMember.SelectedIndex;
      this.listBox_PartyMember.SelectedIndex = -1;
      this.RenewalControl();
    }

    private void _numericUpDown_FigureWidth_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].FigureWidth.Value = (ushort) this._numericUpDown_FigureWidth.Value;
    }

    private void _numericUpDown_FigureHeight_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].FigureHeight.Value = (ushort) this._numericUpDown_FigureHeight.Value;
    }

    private void _numericUpDown_Hair_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].HairType.Value = (byte) this._numericUpDown_Hair.Value;
    }

    private void _numericUpDown_HairColor_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].HairColor.Value = (byte) this._numericUpDown_HairColor.Value;
    }

    private void _numericUpDown_Face_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].FaceType.Value = (byte) this._numericUpDown_Face.Value;
    }

    private void _numericUpDown_SkinColor_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SkinColor = (byte) this._numericUpDown_SkinColor.Value;
    }

    private void _numericUpDown_EyeColor_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].EyeColor = (byte) this._numericUpDown_EyeColor.Value;
    }

    private void button_FigurePreset_Click(object sender, EventArgs e)
    {
      using (PresetWindow presetWindow = new PresetWindow(ListType.Figure))
      {
        presetWindow.Location = this.PointToScreen(new Point(this.groupBox_Figure.Right, this.groupBox_Figure.Top + this.button_FigurePreset.Bottom));
        if (presetWindow.ShowDialog() != DialogResult.OK || !(presetWindow.SelectedPreset is PresetFigure selectedPreset))
          return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        characterManager.CharacterData[this._selectedIndex].FigureWidth.Value = selectedPreset.Width;
        characterManager.CharacterData[this._selectedIndex].FigureHeight.Value = selectedPreset.Height;
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        this.RenewalControl();
      }
    }

    private void button_HairPreset_Click(object sender, EventArgs e)
    {
      using (PresetWindow presetWindow = new PresetWindow(ListType.HairType))
      {
        presetWindow.Location = this.PointToScreen(new Point(this.groupBox_Figure.Right, this.groupBox_Figure.Top + this.button_HairPreset.Bottom));
        if (presetWindow.ShowDialog() != DialogResult.OK || !(presetWindow.SelectedPreset is Preset selectedPreset))
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].HairType.Value = selectedPreset.Index;
        this.RenewalControl();
      }
    }

    private void button_HairColorPreset_Click(object sender, EventArgs e)
    {
      using (PresetWindow presetWindow = new PresetWindow(ListType.HairColor))
      {
        presetWindow.Location = this.PointToScreen(new Point(this.groupBox_Figure.Right, this.groupBox_Figure.Top + this.button_HairColorPreset.Bottom));
        if (presetWindow.ShowDialog() != DialogResult.OK || !(presetWindow.SelectedPreset is Preset selectedPreset))
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].HairColor.Value = selectedPreset.Index;
        this.RenewalControl();
      }
    }

    private void button_FacePreset_Click(object sender, EventArgs e)
    {
      using (PresetWindow presetWindow = new PresetWindow(ListType.FaceType))
      {
        presetWindow.Location = this.PointToScreen(new Point(this.groupBox_Figure.Right, this.groupBox_Figure.Top + this.button_FacePreset.Bottom));
        if (presetWindow.ShowDialog() != DialogResult.OK || !(presetWindow.SelectedPreset is Preset selectedPreset))
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].FaceType.Value = selectedPreset.Index;
        this.RenewalControl();
      }
    }

    private void button_SelectWeapon_Click(object sender, EventArgs e)
    {
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(ItemType.Weapon))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Equipment.Right, this.groupBox_Equipment.Top + this.button_SelectWeapon.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].EquipmentWeapon = itemSelectWindow.SelectedItem;
        this.RenewalControl();
      }
    }

    private void button_SelectShield_Click(object sender, EventArgs e)
    {
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(ItemType.Shield))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Equipment.Right, this.groupBox_Equipment.Top + this.button_SelectShield.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].EquipmentShield = itemSelectWindow.SelectedItem;
        this.RenewalControl();
      }
    }

    private void button_SelectHead_Click(object sender, EventArgs e)
    {
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(ItemType.Head))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Equipment.Right, this.groupBox_Equipment.Top + this.button_SelectHead.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].EquipmentHead = itemSelectWindow.SelectedItem;
        this.RenewalControl();
      }
    }

    private void button_SelectUpperBody_Click(object sender, EventArgs e)
    {
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(ItemType.UpperBody))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Equipment.Right, this.groupBox_Equipment.Top + this.button_SelectUpperBody.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].EquipmentUpperBody = itemSelectWindow.SelectedItem;
        this.RenewalControl();
      }
    }

    private void button_SelectArm_Click(object sender, EventArgs e)
    {
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(ItemType.Arm))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Equipment.Right, this.groupBox_Equipment.Top + this.button_SelectArm.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].EquipmentArm = itemSelectWindow.SelectedItem;
        this.RenewalControl();
      }
    }

    private void button_SelectLowerBody_Click(object sender, EventArgs e)
    {
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(ItemType.LowerBody))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Equipment.Right, this.groupBox_Equipment.Top + this.button_SelectLowerBody.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].EquipmentLowerBody = itemSelectWindow.SelectedItem;
        this.RenewalControl();
      }
    }

    private void button_SelectShoe_Click(object sender, EventArgs e)
    {
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(ItemType.Shoe))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Equipment.Right, this.groupBox_Equipment.Top + this.button_SelectShoe.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].EquipmentShoe = itemSelectWindow.SelectedItem;
        this.RenewalControl();
      }
    }

    private void button_SelectAccessory_Click(object sender, EventArgs e)
    {
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(ItemType.Accessory))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Equipment.Right, this.groupBox_Equipment.Top + this.button_SelectAccessory.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].EquipmentAccessory = itemSelectWindow.SelectedItem;
        this.RenewalControl();
      }
    }

    private void comboBox_Sex_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].Sex = (byte) this.comboBox_Sex.SelectedIndex;
    }

    private void comboBox_Job_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].Job.Value = (byte) JobDataList.List[this.comboBox_Job.SelectedIndex].DataIndex;
    }

    private void _numericUpDown_SkillPoint_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SkillPoint.Value = (ushort) this._numericUpDown_SkillPoint.Value;
    }

    private void comboBox_Color_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].Color = (byte) this.comboBox_Color.SelectedIndex;
    }

    private void comboBox_Rank_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].Rank = (byte) this.comboBox_Rank.SelectedIndex;
    }

    private void comboBox_Strategy_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].Strategy = this.comboBox_Strategy.SelectedItem as Strategy;
    }

    private void button_SelectTools_Click(object sender, EventArgs e)
    {
      if (!(sender is VisionButton visionButton))
        return;
      using (ItemSelectWindow itemSelectWindow = new ItemSelectWindow(ItemType.Tool))
      {
        itemSelectWindow.Location = this.PointToScreen(new Point(this.groupBox_Tool.Right, this.groupBox_Tool.Top + visionButton.Bottom));
        if (itemSelectWindow.ShowDialog() != DialogResult.OK)
          return;
        ItemDataBase selectedItem = itemSelectWindow.SelectedItem;
        SaveDataManager.Instance.SaveData.ItemData.SetTool(this._selectedIndex - (int) SaveDataManager.Instance.SaveData.CharacterManager.CharacterStandbyCount, (int) visionButton.Tag, selectedItem);
        this.RenewalControl();
      }
    }

    private void NumericUpDown_Skill_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].JobSkillLevel[JobDataList.GetJobData(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex).SkillList[(int) visionNumericUpDown.Tag].Index].Value = (byte) visionNumericUpDown.Value;
    }

    private void _numericUpDown_NowHP_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].NowHP = (ushort) this._numericUpDown_NowHP.Value;
    }

    private void _numericUpDown_NowMP_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].NowMP = (ushort) this._numericUpDown_NowMP.Value;
    }

    private void _numericUpDown_NowHPMP_Enter(object sender, EventArgs e)
    {
      MainWindow.Instance.StatusBarText.Text = "最大値より大きな値を設定した場合、ゲーム開始時に最大値に丸められます。";
    }

    private void _numericUpDown_NowHPMP_Leave(object sender, EventArgs e)
    {
      MainWindow.Instance.StatusBarText.Text = string.Empty;
    }

    private void _numericUpDown_Level_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].JobLevel[JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex].Value = (byte) this._numericUpDown_Level.Value;
    }

    private void _numericUpDown_Experience_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].JobExperience[JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex].Value = (uint) this._numericUpDown_Experience.Value;
    }

    private void comboBox_StatusEditJob_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.RenewalJobStatus();
    }

    private void _numericUpDown_ReviseHP_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetReviseMaxHP(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort) this._numericUpDown_ReviseHP.Value);
    }

    private void _numericUpDown_ReviseMP_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetReviseMaxMP(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort) this._numericUpDown_ReviseMP.Value);
    }

    private void _numericUpDown_RevisePower_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetRevisePower(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort) this._numericUpDown_RevisePower.Value);
    }

    private void _numericUpDown_ReviseFacility_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetReviseFacility(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort) this._numericUpDown_ReviseFacility.Value);
    }

    private void _numericUpDown_ReviseQuick_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetReviseQuick(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort) this._numericUpDown_ReviseQuick.Value);
    }

    private void _numericUpDown_ReviseDefense_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetReviseDefense(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort) this._numericUpDown_ReviseDefense.Value);
    }

    private void _numericUpDown_ReviseAttackMagic_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetReviseAttackMagic(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort) this._numericUpDown_ReviseAttackMagic.Value);
    }

    private void _numericUpDown_ReviseRevivalMagic_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetReviseRevivalMagic(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort) this._numericUpDown_ReviseRevivalMagic.Value);
    }

    private void _numericUpDown_ReviseSmart_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetReviseSmart(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort) this._numericUpDown_ReviseSmart.Value);
    }

    private void _numericUpDown_Transmigration_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetTransmigration(JobDataList.List[this.comboBox_StatusEditJob.SelectedIndex].DataIndex, (byte) this._numericUpDown_Transmigration.Value);
    }

    private void comboBox_SkillSpecialty_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RenewalSkillSpecialtyList();
      if (this._updateCount != 0)
        return;
      this.RenewalSkillSpecialtyListState();
    }

    private void checkedListBox_Specialty_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (this._updateCount != 0)
        return;
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (!(this.checkedListBox_Specialty.Items[e.Index] is SkillSpecialtyEffectData specialtyEffectData))
        return;
      characterManager.CharacterData[this._selectedIndex].SetLearnSkillSpecialtyEffect(specialtyEffectData.Index, e.NewValue == CheckState.Checked);
    }

    private void checkedListBox_Skill_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (this._updateCount != 0)
        return;
      CharacterManager characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
      if (!(this.checkedListBox_Skill.Items[e.Index] is SkillSpecialtyEffectData specialtyEffectData))
        return;
      characterManager.CharacterData[this._selectedIndex].SetLearnSkillSpecialtyEffect(specialtyEffectData.Index, e.NewValue == CheckState.Checked);
    }

    private void checkBox_Ruler_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetLearnRular(this.checkBox_Ruler.Checked);
    }

    private void checkBox_Cheer_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].SetLearnCheer(this.checkBox_Cheer.Checked);
    }

    private void checkBox_Die_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].Die = this.checkBox_Die.Checked;
    }

    private void checkBox_Poison_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].Poison = this.checkBox_Poison.Checked;
    }

    private void checkBox_Curse_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[this._selectedIndex].Curse = this.checkBox_Curse.Checked;
    }
  }
}
