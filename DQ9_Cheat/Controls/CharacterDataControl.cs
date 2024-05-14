// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.CharacterDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls;

public class CharacterDataControl : DataControlBase
{
    private readonly VisionButton[] _button_SelectTools = new VisionButton[8];
    private readonly Label[] _label_Skills = new Label[5];
    private VisionNumericUpDown _numericUpDown_ReviseAttackMagic;
    private VisionNumericUpDown _numericUpDown_ReviseDefense;
    private VisionNumericUpDown _numericUpDown_ReviseFacility;
    private VisionNumericUpDown _numericUpDown_ReviseHP;
    private VisionNumericUpDown _numericUpDown_ReviseMP;
    private VisionNumericUpDown _numericUpDown_RevisePower;
    private VisionNumericUpDown _numericUpDown_ReviseQuick;
    private VisionNumericUpDown _numericUpDown_ReviseRevivalMagic;
    private VisionNumericUpDown _numericUpDown_ReviseSmart;
    private readonly VisionNumericUpDown[] _numericUpDown_Skills = new VisionNumericUpDown[5];
    private SafeNumericUpDown _numericUpDown_Transmigration;
    private int _selectedIndex;
    private VisionTextBox _textBox_CharacterName;
    private readonly VisionTextBox[] _textBox_Equipment = new VisionTextBox[8];
    private readonly VisionTextBox[] _textBox_Tools = new VisionTextBox[8];
    private Button button_FacePreset;
    private Button button_FigurePreset;
    private Button button_HairColorPreset;
    private Button button_HairPreset;
    private Button button_SelectAccessory;
    private Button button_SelectArm;
    private Button button_SelectHead;
    private Button button_SelectLowerBody;
    private Button button_SelectShield;
    private Button button_SelectShoe;
    private Button button_SelectUpperBody;
    private Button button_SelectWeapon;
    private CheckBox checkBox_Cheer;
    private CheckBox checkBox_Curse;
    private CheckBox checkBox_Die;
    private CheckBox checkBox_Poison;
    private CheckBox checkBox_Ruler;
    private CheckedListBox checkedListBox_Skill;
    private CheckedListBox checkedListBox_Specialty;
    private ComboBox comboBox_Color;
    private ComboBox comboBox_Job;
    private ComboBox comboBox_Rank;
    private ComboBox comboBox_Sex;
    private ComboBox comboBox_SkillSpecialty;
    private ComboBox comboBox_StatusEditJob;
    private ComboBox comboBox_Strategy;
    private IContainer components;
    private JS_GroupBox groupBox_Equipment;
    private JS_GroupBox groupBox_Figure;
    private JS_GroupBox groupBox_Skill;
    private JS_GroupBox GroupBox_SkillSpecialty;
    private JS_GroupBox GroupBox_State;
    private JS_GroupBox groupBox_Status;
    private JS_GroupBox groupBox_StatusRevise;
    private JS_GroupBox groupBox_Tool;
    private Label label_Job;
    private Label label_MaxHP;
    private Label label_MaxMP;
    private Label label_Name;
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
    private Label label19;
    private Label label2;
    private Label label20;
    private Label label21;
    private Label label22;
    private Label label23;
    private Label label24;
    private Label label25;
    private Label label26;
    private Label label27;
    private Label label28;
    private Label label29;
    private Label label3;
    private Label label30;
    private Label label31;
    private Label label32;
    private Label label33;
    private Label label34;
    private Label label35;
    private Label label36;
    private Label label37;
    private Label label38;
    private Label label39;
    private Label label4;
    private Label label40;
    private Label label41;
    private Label label42;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private ListBox listBox_PartyMember;
    private ListBox listBox_StandbyMember;
    private Panel panel1;
    private Panel panel2;
    private ToolStripButton toolButton_CreateMember;
    private ToolStripButton toolButton_DeleteMember;
    private ToolStripButton toolButton_PartyIn;
    private ToolStripButton toolButton_PartyMemberDown;
    private ToolStripButton toolButton_PartyMemberUp;
    private ToolStripButton toolButton_PartyOut;
    private ToolStripButton toolButton_RuidaMemberDown;
    private ToolStripButton toolButton_RuidaMemberUp;
    private ToolStrip toolStrip1;
    private ToolStrip toolStrip2;

    public CharacterDataControl()
    {
        AutoScaleMode = AutoScaleMode.None;
        InitializeComponent();
    }

    public SafeNumericUpDown NumericUpDown_Experience { get; private set; }

    public SafeNumericUpDown NumericUpDown_Level { get; private set; }

    public SafeNumericUpDown NumericUpDown_NowHP { get; private set; }

    public SafeNumericUpDown NumericUpDown_NowMP { get; private set; }

    public VisionNumericUpDown NumericUpDown_Hair { get; private set; }

    public VisionNumericUpDown NumericUpDown_FigureHeight { get; private set; }

    public VisionNumericUpDown NumericUpDown_FigureWidth { get; private set; }

    public VisionNumericUpDown NumericUpDown_EyeColor { get; private set; }

    public VisionNumericUpDown NumericUpDown_SkinColor { get; private set; }

    public VisionNumericUpDown NumericUpDown_Face { get; private set; }

    public VisionNumericUpDown NumericUpDown_HairColor { get; private set; }

    public VisionNumericUpDown NumericUpDown_SkillPoint { get; private set; }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        var componentResourceManager = new ComponentResourceManager(typeof(CharacterDataControl));
        listBox_PartyMember = new ListBox();
        label_Name = new Label();
        label_Job = new Label();
        comboBox_Job = new ComboBox();
        label1 = new Label();
        label2 = new Label();
        listBox_StandbyMember = new ListBox();
        label3 = new Label();
        panel1 = new Panel();
        toolStrip1 = new ToolStrip();
        toolButton_PartyMemberUp = new ToolStripButton();
        toolButton_PartyMemberDown = new ToolStripButton();
        toolButton_PartyOut = new ToolStripButton();
        panel2 = new Panel();
        toolStrip2 = new ToolStrip();
        toolButton_RuidaMemberUp = new ToolStripButton();
        toolButton_RuidaMemberDown = new ToolStripButton();
        toolButton_PartyIn = new ToolStripButton();
        toolButton_CreateMember = new ToolStripButton();
        toolButton_DeleteMember = new ToolStripButton();
        label4 = new Label();
        comboBox_Sex = new ComboBox();
        groupBox_Equipment = new JS_GroupBox();
        button_SelectAccessory = new Button();
        button_SelectShoe = new Button();
        button_SelectLowerBody = new Button();
        button_SelectArm = new Button();
        button_SelectUpperBody = new Button();
        button_SelectHead = new Button();
        button_SelectShield = new Button();
        button_SelectWeapon = new Button();
        label12 = new Label();
        label11 = new Label();
        label10 = new Label();
        label9 = new Label();
        label8 = new Label();
        label7 = new Label();
        label6 = new Label();
        label5 = new Label();
        groupBox_Figure = new JS_GroupBox();
        label21 = new Label();
        label20 = new Label();
        button_FacePreset = new Button();
        button_HairColorPreset = new Button();
        button_HairPreset = new Button();
        button_FigurePreset = new Button();
        label18 = new Label();
        label19 = new Label();
        label17 = new Label();
        label16 = new Label();
        label15 = new Label();
        label14 = new Label();
        label13 = new Label();
        label22 = new Label();
        label23 = new Label();
        comboBox_Rank = new ComboBox();
        label24 = new Label();
        comboBox_Strategy = new ComboBox();
        comboBox_Color = new ComboBox();
        label25 = new Label();
        groupBox_Tool = new JS_GroupBox();
        label26 = new Label();
        label27 = new Label();
        NumericUpDown_NowHP = new SafeNumericUpDown();
        NumericUpDown_NowMP = new SafeNumericUpDown();
        label_MaxHP = new Label();
        label_MaxMP = new Label();
        groupBox_Status = new JS_GroupBox();
        GroupBox_SkillSpecialty = new JS_GroupBox();
        comboBox_SkillSpecialty = new ComboBox();
        checkBox_Cheer = new CheckBox();
        checkBox_Ruler = new CheckBox();
        checkedListBox_Skill = new CheckedListBox();
        label42 = new Label();
        label41 = new Label();
        checkedListBox_Specialty = new CheckedListBox();
        _numericUpDown_Transmigration = new SafeNumericUpDown();
        label40 = new Label();
        groupBox_Skill = new JS_GroupBox();
        groupBox_StatusRevise = new JS_GroupBox();
        label38 = new Label();
        label34 = new Label();
        label31 = new Label();
        label36 = new Label();
        label32 = new Label();
        label37 = new Label();
        label33 = new Label();
        label39 = new Label();
        label35 = new Label();
        NumericUpDown_Experience = new SafeNumericUpDown();
        label30 = new Label();
        NumericUpDown_Level = new SafeNumericUpDown();
        label29 = new Label();
        comboBox_StatusEditJob = new ComboBox();
        label28 = new Label();
        GroupBox_State = new JS_GroupBox();
        checkBox_Curse = new CheckBox();
        checkBox_Poison = new CheckBox();
        checkBox_Die = new CheckBox();
        panel1.SuspendLayout();
        toolStrip1.SuspendLayout();
        panel2.SuspendLayout();
        toolStrip2.SuspendLayout();
        groupBox_Equipment.SuspendLayout();
        groupBox_Figure.SuspendLayout();
        NumericUpDown_NowHP.BeginInit();
        NumericUpDown_NowMP.BeginInit();
        groupBox_Status.SuspendLayout();
        GroupBox_SkillSpecialty.SuspendLayout();
        _numericUpDown_Transmigration.BeginInit();
        groupBox_StatusRevise.SuspendLayout();
        NumericUpDown_Experience.BeginInit();
        NumericUpDown_Level.BeginInit();
        GroupBox_State.SuspendLayout();
        SuspendLayout();
        listBox_PartyMember.Dock = DockStyle.Fill;
        listBox_PartyMember.FormattingEnabled = true;
        listBox_PartyMember.ItemHeight = 12;
        listBox_PartyMember.Location = new Point(0, 16);
        listBox_PartyMember.Name = "listBox_PartyMember";
        listBox_PartyMember.Size = new Size(116, 65);
        listBox_PartyMember.TabIndex = 0;
        listBox_PartyMember.SelectedIndexChanged += listBox_PartyMember_SelectedIndexChanged;
        label_Name.AutoSize = true;
        label_Name.Location = new Point(166, 20);
        label_Name.Name = "label_Name";
        label_Name.Size = new Size(29, 12);
        label_Name.TabIndex = 1;
        label_Name.Text = "Name";
        label_Job.AutoSize = true;
        label_Job.Location = new Point(402, 20);
        label_Job.Name = "label_Job";
        label_Job.Size = new Size(53, 12);
        label_Job.TabIndex = 3;
        label_Job.Text = "Vocation";
        comboBox_Job.DropDownHeight = 200;
        comboBox_Job.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Job.FormattingEnabled = true;
        comboBox_Job.IntegralHeight = false;
        comboBox_Job.Location = new Point(455, 16);
        comboBox_Job.Name = "comboBox_Job";
        comboBox_Job.Size = new Size(93, 20);
        comboBox_Job.TabIndex = 3;
        comboBox_Job.SelectedIndexChanged += comboBox_Job_SelectedIndexChanged;
        label1.Dock = DockStyle.Top;
        label1.Location = new Point(0, 0);
        label1.Name = "label1";
        label1.Size = new Size(116, 16);
        label1.TabIndex = 5;
        label1.Text = "Party Members";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        label2.Dock = DockStyle.Top;
        label2.Location = new Point(0, 0);
        label2.Name = "label2";
        label2.Size = new Size(116, 16);
        label2.TabIndex = 7;
        label2.Text = "Inn";
        label2.TextAlign = ContentAlignment.MiddleCenter;
        listBox_StandbyMember.Dock = DockStyle.Fill;
        listBox_StandbyMember.FormattingEnabled = true;
        listBox_StandbyMember.ItemHeight = 12;
        listBox_StandbyMember.Location = new Point(0, 16);
        listBox_StandbyMember.Name = "listBox_StandbyMember";
        listBox_StandbyMember.Size = new Size(116, 136);
        listBox_StandbyMember.TabIndex = 0;
        listBox_StandbyMember.SelectedIndexChanged += listBox_StandbyMember_SelectedIndexChanged;
        label3.AutoSize = true;
        label3.Location = new Point(0, 21);
        label3.Name = "label3";
        label3.Size = new Size(41, 12);
        label3.TabIndex = 8;
        label3.Text = "Hero";
        panel1.BorderStyle = BorderStyle.Fixed3D;
        panel1.Controls.Add(toolStrip1);
        panel1.Controls.Add(listBox_PartyMember);
        panel1.Controls.Add(label1);
        panel1.Location = new Point(43, 1);
        panel1.Name = "panel1";
        panel1.Size = new Size(120, 100);
        panel1.TabIndex = 0;
        toolStrip1.Dock = DockStyle.Bottom;
        toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
        toolStrip1.Items.AddRange(new ToolStripItem[3]
        {
            toolButton_PartyMemberUp,
            toolButton_PartyMemberDown,
            toolButton_PartyOut
        });
        toolStrip1.Location = new Point(0, 68);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new Size(116, 25);
        toolStrip1.TabIndex = 1;
        toolStrip1.Text = "toolStrip1";
        toolButton_PartyMemberUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_PartyMemberUp.Enabled = false;
        toolButton_PartyMemberUp.Image = (Image)componentResourceManager.GetObject("toolButton_PartyMemberUp.Image");
        toolButton_PartyMemberUp.ImageTransparentColor = Color.Magenta;
        toolButton_PartyMemberUp.Name = "toolButton_PartyMemberUp";
        toolButton_PartyMemberUp.Size = new Size(23, 22);
        toolButton_PartyMemberUp.Text = "toolStripButton1";
        toolButton_PartyMemberUp.ToolTipText = "Move Up";
        toolButton_PartyMemberUp.Click += toolButton_PartyMemberUp_Click;
        toolButton_PartyMemberDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_PartyMemberDown.Enabled = false;
        toolButton_PartyMemberDown.Image =
            (Image)componentResourceManager.GetObject("toolButton_PartyMemberDown.Image");
        toolButton_PartyMemberDown.ImageTransparentColor = Color.Magenta;
        toolButton_PartyMemberDown.Name = "toolButton_PartyMemberDown";
        toolButton_PartyMemberDown.Size = new Size(23, 22);
        toolButton_PartyMemberDown.Text = "toolStripButton3";
        toolButton_PartyMemberDown.ToolTipText = "Move Down";
        toolButton_PartyMemberDown.Click += toolButton_PartyMemberDown_Click;
        toolButton_PartyOut.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_PartyOut.Enabled = false;
        toolButton_PartyOut.Image = (Image)componentResourceManager.GetObject("toolButton_PartyOut.Image");
        toolButton_PartyOut.ImageTransparentColor = Color.Magenta;
        toolButton_PartyOut.Name = "toolButton_PartyOut";
        toolButton_PartyOut.Size = new Size(23, 22);
        toolButton_PartyOut.Text = "toolStripButton4";
        toolButton_PartyOut.ToolTipText = "Out of Party";
        toolButton_PartyOut.Click += toolButton_PartyOut_Click;
        panel2.BorderStyle = BorderStyle.Fixed3D;
        panel2.Controls.Add(listBox_StandbyMember);
        panel2.Controls.Add(toolStrip2);
        panel2.Controls.Add(label2);
        panel2.Location = new Point(43, 104);
        panel2.Name = "panel2";
        panel2.Size = new Size(120, 181);
        panel2.TabIndex = 1;
        toolStrip2.Dock = DockStyle.Bottom;
        toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
        toolStrip2.Items.AddRange(new ToolStripItem[5]
        {
            toolButton_RuidaMemberUp,
            toolButton_RuidaMemberDown,
            toolButton_PartyIn,
            toolButton_CreateMember,
            toolButton_DeleteMember
        });
        toolStrip2.Location = new Point(0, 152);
        toolStrip2.Name = "toolStrip2";
        toolStrip2.Size = new Size(116, 25);
        toolStrip2.TabIndex = 1;
        toolStrip2.Text = "toolStrip2";
        toolButton_RuidaMemberUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_RuidaMemberUp.Enabled = false;
        toolButton_RuidaMemberUp.Image = (Image)componentResourceManager.GetObject("toolButton_RuidaMemberUp.Image");
        toolButton_RuidaMemberUp.ImageTransparentColor = Color.Magenta;
        toolButton_RuidaMemberUp.Name = "toolButton_RuidaMemberUp";
        toolButton_RuidaMemberUp.Size = new Size(23, 22);
        toolButton_RuidaMemberUp.Text = "toolStripButton2";
        toolButton_RuidaMemberUp.ToolTipText = "Move Up";
        toolButton_RuidaMemberUp.Click += toolButton_RuidaMemberUp_Click;
        toolButton_RuidaMemberDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_RuidaMemberDown.Enabled = false;
        toolButton_RuidaMemberDown.Image =
            (Image)componentResourceManager.GetObject("toolButton_RuidaMemberDown.Image");
        toolButton_RuidaMemberDown.ImageTransparentColor = Color.Magenta;
        toolButton_RuidaMemberDown.Name = "toolButton_RuidaMemberDown";
        toolButton_RuidaMemberDown.Size = new Size(23, 22);
        toolButton_RuidaMemberDown.Text = "toolStripButton5";
        toolButton_RuidaMemberDown.ToolTipText = "Move Down";
        toolButton_RuidaMemberDown.Click += toolButton_RuidaMemberDown_Click;
        toolButton_PartyIn.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_PartyIn.Enabled = false;
        toolButton_PartyIn.Image = (Image)componentResourceManager.GetObject("toolButton_PartyIn.Image");
        toolButton_PartyIn.ImageTransparentColor = Color.Magenta;
        toolButton_PartyIn.Name = "toolButton_PartyIn";
        toolButton_PartyIn.Size = new Size(23, 22);
        toolButton_PartyIn.Text = "toolStripButton6";
        toolButton_PartyIn.ToolTipText = "Add Party Members";
        toolButton_PartyIn.Click += toolButton_PartyIn_Click;
        toolButton_CreateMember.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_CreateMember.Enabled = false;
        toolButton_CreateMember.Image = (Image)componentResourceManager.GetObject("toolButton_CreateMember.Image");
        toolButton_CreateMember.ImageTransparentColor = Color.Magenta;
        toolButton_CreateMember.Name = "toolButton_CreateMember";
        toolButton_CreateMember.Size = new Size(23, 22);
        toolButton_CreateMember.Text = "toolStripButton7";
        toolButton_CreateMember.ToolTipText = "Create a Character";
        toolButton_CreateMember.Click += toolButton_CreateMember_Click;
        toolButton_DeleteMember.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_DeleteMember.Enabled = false;
        toolButton_DeleteMember.Image = (Image)componentResourceManager.GetObject("toolButton_DeleteMember.Image");
        toolButton_DeleteMember.ImageTransparentColor = Color.Magenta;
        toolButton_DeleteMember.Name = "toolButton_DeleteMember";
        toolButton_DeleteMember.Size = new Size(23, 22);
        toolButton_DeleteMember.Text = "toolStripButton8";
        toolButton_DeleteMember.ToolTipText = "Delete Character";
        toolButton_DeleteMember.Click += toolButton_DeleteMember_Click;
        label4.AutoSize = true;
        label4.Location = new Point(314, 20);
        label4.Name = "label4";
        label4.Size = new Size(29, 12);
        label4.TabIndex = 12;
        label4.Text = "Sex";
        comboBox_Sex.DropDownHeight = 200;
        comboBox_Sex.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Sex.FormattingEnabled = true;
        comboBox_Sex.IntegralHeight = false;
        comboBox_Sex.Items.AddRange(new object[2]
        {
            "Male",
            "Female"
        });
        comboBox_Sex.Location = new Point(339, 16);
        comboBox_Sex.Name = "comboBox_Sex";
        comboBox_Sex.Size = new Size(58, 20);
        comboBox_Sex.TabIndex = 2;
        comboBox_Sex.SelectedIndexChanged += comboBox_Sex_SelectedIndexChanged;
        groupBox_Equipment.Controls.Add(button_SelectAccessory);
        groupBox_Equipment.Controls.Add(button_SelectShoe);
        groupBox_Equipment.Controls.Add(button_SelectLowerBody);
        groupBox_Equipment.Controls.Add(button_SelectArm);
        groupBox_Equipment.Controls.Add(button_SelectUpperBody);
        groupBox_Equipment.Controls.Add(button_SelectHead);
        groupBox_Equipment.Controls.Add(button_SelectShield);
        groupBox_Equipment.Controls.Add(button_SelectWeapon);
        groupBox_Equipment.Controls.Add(label12);
        groupBox_Equipment.Controls.Add(label11);
        groupBox_Equipment.Controls.Add(label10);
        groupBox_Equipment.Controls.Add(label9);
        groupBox_Equipment.Controls.Add(label8);
        groupBox_Equipment.Controls.Add(label7);
        groupBox_Equipment.Controls.Add(label6);
        groupBox_Equipment.Controls.Add(label5);
        groupBox_Equipment.Location = new Point(362, 73);
        groupBox_Equipment.Name = "groupBox_Equipment";
        groupBox_Equipment.Size = new Size(239, 201);
        groupBox_Equipment.TabIndex = 10;
        groupBox_Equipment.TabStop = false;
        groupBox_Equipment.Text = "Equip";
        button_SelectAccessory.Location = new Point(186, 167);
        button_SelectAccessory.Name = "button_SelectAccessory";
        button_SelectAccessory.Size = new Size(39, 19);
        button_SelectAccessory.TabIndex = 7;
        button_SelectAccessory.Text = "Set";
        button_SelectAccessory.UseVisualStyleBackColor = true;
        button_SelectAccessory.Click += button_SelectAccessory_Click;
        button_SelectShoe.Location = new Point(186, 146);
        button_SelectShoe.Name = "button_SelectShoe";
        button_SelectShoe.Size = new Size(39, 19);
        button_SelectShoe.TabIndex = 6;
        button_SelectShoe.Text = "Set";
        button_SelectShoe.UseVisualStyleBackColor = true;
        button_SelectShoe.Click += button_SelectShoe_Click;
        button_SelectLowerBody.Location = new Point(186, 125);
        button_SelectLowerBody.Name = "button_SelectLowerBody";
        button_SelectLowerBody.Size = new Size(39, 19);
        button_SelectLowerBody.TabIndex = 5;
        button_SelectLowerBody.Text = "Set";
        button_SelectLowerBody.UseVisualStyleBackColor = true;
        button_SelectLowerBody.Click += button_SelectLowerBody_Click;
        button_SelectArm.Location = new Point(186, 104);
        button_SelectArm.Name = "button_SelectArm";
        button_SelectArm.Size = new Size(39, 19);
        button_SelectArm.TabIndex = 4;
        button_SelectArm.Text = "Set";
        button_SelectArm.UseVisualStyleBackColor = true;
        button_SelectArm.Click += button_SelectArm_Click;
        button_SelectUpperBody.Location = new Point(186, 83);
        button_SelectUpperBody.Name = "button_SelectUpperBody";
        button_SelectUpperBody.Size = new Size(39, 19);
        button_SelectUpperBody.TabIndex = 3;
        button_SelectUpperBody.Text = "Set";
        button_SelectUpperBody.UseVisualStyleBackColor = true;
        button_SelectUpperBody.Click += button_SelectUpperBody_Click;
        button_SelectHead.Location = new Point(186, 62);
        button_SelectHead.Name = "button_SelectHead";
        button_SelectHead.Size = new Size(39, 19);
        button_SelectHead.TabIndex = 2;
        button_SelectHead.Text = "Set";
        button_SelectHead.UseVisualStyleBackColor = true;
        button_SelectHead.Click += button_SelectHead_Click;
        button_SelectShield.Location = new Point(186, 41);
        button_SelectShield.Name = "button_SelectShield";
        button_SelectShield.Size = new Size(39, 19);
        button_SelectShield.TabIndex = 1;
        button_SelectShield.Text = "Set";
        button_SelectShield.UseVisualStyleBackColor = true;
        button_SelectShield.Click += button_SelectShield_Click;
        button_SelectWeapon.Location = new Point(186, 20);
        button_SelectWeapon.Name = "button_SelectWeapon";
        button_SelectWeapon.Size = new Size(39, 19);
        button_SelectWeapon.TabIndex = 0;
        button_SelectWeapon.Text = "Set";
        button_SelectWeapon.UseVisualStyleBackColor = true;
        button_SelectWeapon.Click += button_SelectWeapon_Click;
        label12.AutoSize = true;
        label12.Location = new Point(14, 170);
        label12.Name = "label12";
        label12.Size = new Size(59, 12);
        label12.TabIndex = 7;
        label12.Text = "Accessory";
        label11.AutoSize = true;
        label11.Location = new Point(42, 149);
        label11.Name = "label11";
        label11.Size = new Size(17, 12);
        label11.TabIndex = 6;
        label11.Text = "Feet";
        label10.AutoSize = true;
        label10.Location = new Point(40, 128);
        label10.Name = "label10";
        label10.Size = new Size(41, 12);
        label10.TabIndex = 5;
        label10.Text = "Legs";
        label9.AutoSize = true;
        label9.Location = new Point(39, 107);
        label9.Name = "label9";
        label9.Size = new Size(17, 12);
        label9.TabIndex = 4;
        label9.Text = "Arms";
        label8.AutoSize = true;
        label8.Location = new Point(36, 86);
        label8.Name = "label8";
        label8.Size = new Size(17, 12);
        label8.TabIndex = 3;
        label8.Text = "Torso";
        label7.AutoSize = true;
        label7.Location = new Point(37, 65);
        label7.Name = "label7";
        label7.Size = new Size(17, 12);
        label7.TabIndex = 2;
        label7.Text = "Head";
        label6.AutoSize = true;
        label6.Location = new Point(34, 44);
        label6.Name = "label6";
        label6.Size = new Size(17, 12);
        label6.TabIndex = 1;
        label6.Text = "Shield";
        label5.AutoSize = true;
        label5.Location = new Point(22, 23);
        label5.Name = "label5";
        label5.Size = new Size(29, 12);
        label5.TabIndex = 0;
        label5.Text = "Weapon";
        groupBox_Figure.Controls.Add(label21);
        groupBox_Figure.Controls.Add(label20);
        groupBox_Figure.Controls.Add(button_FacePreset);
        groupBox_Figure.Controls.Add(button_HairColorPreset);
        groupBox_Figure.Controls.Add(button_HairPreset);
        groupBox_Figure.Controls.Add(button_FigurePreset);
        groupBox_Figure.Controls.Add(label18);
        groupBox_Figure.Controls.Add(label19);
        groupBox_Figure.Controls.Add(label17);
        groupBox_Figure.Controls.Add(label16);
        groupBox_Figure.Controls.Add(label15);
        groupBox_Figure.Controls.Add(label14);
        groupBox_Figure.Controls.Add(label13);
        groupBox_Figure.Location = new Point(608, 88);
        groupBox_Figure.Name = "groupBox_Figure";
        groupBox_Figure.Size = new Size(207, 186);
        groupBox_Figure.TabIndex = 11;
        groupBox_Figure.TabStop = false;
        groupBox_Figure.Text = "Appearance";
        label21.AutoSize = true;
        label21.Location = new Point(134, 150);
        label21.Name = "label21";
        label21.Size = new Size(51, 12);
        label21.TabIndex = 20;
        label21.Text = "(0 - 15)";
        label20.AutoSize = true;
        label20.Location = new Point(134, 129);
        label20.Name = "label20";
        label20.Size = new Size(45, 12);
        label20.TabIndex = 19;
        label20.Text = "(0 - 7)";
        button_FacePreset.Location = new Point(134, 106);
        button_FacePreset.Name = "button_FacePreset";
        button_FacePreset.Size = new Size(60, 19);
        button_FacePreset.TabIndex = 3;
        button_FacePreset.Text = "Preset";
        button_FacePreset.UseVisualStyleBackColor = true;
        button_FacePreset.Click += button_FacePreset_Click;
        button_HairColorPreset.Location = new Point(134, 85);
        button_HairColorPreset.Name = "button_HairColorPreset";
        button_HairColorPreset.Size = new Size(60, 19);
        button_HairColorPreset.TabIndex = 2;
        button_HairColorPreset.Text = "Preset";
        button_HairColorPreset.UseVisualStyleBackColor = true;
        button_HairColorPreset.Click += button_HairColorPreset_Click;
        button_HairPreset.Location = new Point(134, 64);
        button_HairPreset.Name = "button_HairPreset";
        button_HairPreset.Size = new Size(60, 19);
        button_HairPreset.TabIndex = 1;
        button_HairPreset.Text = "Preset";
        button_HairPreset.UseVisualStyleBackColor = true;
        button_HairPreset.Click += button_HairPreset_Click;
        button_FigurePreset.Location = new Point(134, 43);
        button_FigurePreset.Name = "button_FigurePreset";
        button_FigurePreset.Size = new Size(60, 19);
        button_FigurePreset.TabIndex = 0;
        button_FigurePreset.Text = "Preset";
        button_FigurePreset.UseVisualStyleBackColor = true;
        button_FigurePreset.Click += button_FigurePreset_Click;
        label18.AutoSize = true;
        label18.Location = new Point(20, 150);
        label18.Name = "label18";
        label18.Size = new Size(39, 12);
        label18.TabIndex = 6;
        label18.Text = "Eye Color";
        label19.AutoSize = true;
        label19.Location = new Point(17, 129);
        label19.Name = "label19";
        label19.Size = new Size(39, 12);
        label19.TabIndex = 5;
        label19.Text = "Skin Color";
        label17.AutoSize = true;
        label17.Location = new Point(40, 108);
        label17.Name = "label17";
        label17.Size = new Size(17, 12);
        label17.TabIndex = 4;
        label17.Text = "Face";
        label16.AutoSize = true;
        label16.Location = new Point(18, 87);
        label16.Name = "label16";
        label16.Size = new Size(39, 12);
        label16.TabIndex = 3;
        label16.Text = "Hair Color";
        label15.AutoSize = true;
        label15.Location = new Point(20, 66);
        label15.Name = "label15";
        label15.Size = new Size(29, 12);
        label15.TabIndex = 2;
        label15.Text = "Hair Style";
        label14.AutoSize = true;
        label14.Location = new Point(23, 45);
        label14.Name = "label14";
        label14.Size = new Size(53, 12);
        label14.TabIndex = 1;
        label14.Text = "Body (H)";
        label13.AutoSize = true;
        label13.Location = new Point(20, 24);
        label13.Name = "label13";
        label13.Size = new Size(53, 12);
        label13.TabIndex = 0;
        label13.Text = "Body (W)";
        label22.AutoSize = true;
        label22.Location = new Point(13, 22);
        label22.Name = "label22";
        label22.Size = new Size(70, 12);
        label22.TabIndex = 16;
        label22.Text = "Skill Points";
        label23.AutoSize = true;
        label23.Location = new Point(310, 45);
        label23.Name = "label23";
        label23.Size = new Size(29, 12);
        label23.TabIndex = 18;
        label23.Text = "Row";
        comboBox_Rank.DropDownHeight = 200;
        comboBox_Rank.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Rank.FormattingEnabled = true;
        comboBox_Rank.IntegralHeight = false;
        comboBox_Rank.Items.AddRange(new object[2]
        {
            "Front",
            "Back"
        });
        comboBox_Rank.Location = new Point(339, 41);
        comboBox_Rank.Name = "comboBox_Rank";
        comboBox_Rank.Size = new Size(58, 20);
        comboBox_Rank.TabIndex = 5;
        comboBox_Rank.SelectedIndexChanged += comboBox_Rank_SelectedIndexChanged;
        label24.AutoSize = true;
        label24.Location = new Point(162, 45);
        label24.Name = "label24";
        label24.Size = new Size(29, 12);
        label24.TabIndex = 20;
        label24.Text = "Tactics";
        comboBox_Strategy.DropDownHeight = 200;
        comboBox_Strategy.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Strategy.FormattingEnabled = true;
        comboBox_Strategy.IntegralHeight = false;
        comboBox_Strategy.Location = new Point(201, 41);
        comboBox_Strategy.Name = "comboBox_Strategy";
        comboBox_Strategy.Size = new Size(100, 20);
        comboBox_Strategy.TabIndex = 4;
        comboBox_Strategy.SelectedIndexChanged += comboBox_Strategy_SelectedIndexChanged;
        comboBox_Color.DropDownHeight = 200;
        comboBox_Color.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Color.FormattingEnabled = true;
        comboBox_Color.IntegralHeight = false;
        comboBox_Color.Items.AddRange(new object[16]
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
        comboBox_Color.Location = new Point(455, 42);
        comboBox_Color.Name = "comboBox_Color";
        comboBox_Color.Size = new Size(93, 20);
        comboBox_Color.TabIndex = 6;
        comboBox_Color.SelectedIndexChanged += comboBox_Color_SelectedIndexChanged;
        label25.AutoSize = true;
        label25.Location = new Point(418, 45);
        label25.Name = "label25";
        label25.Size = new Size(17, 12);
        label25.TabIndex = 22;
        label25.Text = "Color";
        groupBox_Tool.Location = new Point(172, 73);
        groupBox_Tool.Name = "groupBox_Tool";
        groupBox_Tool.Size = new Size(183, 201);
        groupBox_Tool.TabIndex = 9;
        groupBox_Tool.TabStop = false;
        groupBox_Tool.Text = "Items";
        label26.AutoSize = true;
        label26.Location = new Point(558, 20);
        label26.Name = "label26";
        label26.Size = new Size(20, 12);
        label26.TabIndex = 27;
        label26.Text = "HP";
        label27.AutoSize = true;
        label27.Location = new Point(558, 45);
        label27.Name = "label27";
        label27.Size = new Size(20, 12);
        label27.TabIndex = 28;
        label27.Text = "MP";
        NumericUpDown_NowHP.Location = new Point(579, 17);
        NumericUpDown_NowHP.Name = "NumericUpDown_NowHP";
        NumericUpDown_NowHP.Size = new Size(48, 19);
        NumericUpDown_NowHP.TabIndex = 7;
        NumericUpDown_NowHP.Value = new decimal(new int[4]);
        NumericUpDown_NowHP.ValueChanged += _numericUpDown_NowHP_ValueChanged;
        NumericUpDown_NowHP.Leave += _numericUpDown_NowHPMP_Leave;
        NumericUpDown_NowHP.Enter += _numericUpDown_NowHPMP_Enter;
        NumericUpDown_NowMP.Location = new Point(579, 42);
        NumericUpDown_NowMP.Name = "NumericUpDown_NowMP";
        NumericUpDown_NowMP.Size = new Size(48, 19);
        NumericUpDown_NowMP.TabIndex = 8;
        NumericUpDown_NowMP.Value = new decimal(new int[4]);
        NumericUpDown_NowMP.ValueChanged += _numericUpDown_NowMP_ValueChanged;
        NumericUpDown_NowMP.Leave += _numericUpDown_NowHPMP_Leave;
        NumericUpDown_NowMP.Enter += _numericUpDown_NowHPMP_Enter;
        label_MaxHP.AutoSize = true;
        label_MaxHP.Location = new Point(630, 20);
        label_MaxHP.Name = "label_MaxHP";
        label_MaxHP.Size = new Size(44, 12);
        label_MaxHP.TabIndex = 31;
        label_MaxHP.Text = "Max HP";
        label_MaxMP.AutoSize = true;
        label_MaxMP.Location = new Point(629, 45);
        label_MaxMP.Name = "label_MaxMP";
        label_MaxMP.Size = new Size(45, 12);
        label_MaxMP.TabIndex = 33;
        label_MaxMP.Text = "Max MP";
        groupBox_Status.Controls.Add(GroupBox_SkillSpecialty);
        groupBox_Status.Controls.Add(_numericUpDown_Transmigration);
        groupBox_Status.Controls.Add(label40);
        groupBox_Status.Controls.Add(groupBox_Skill);
        groupBox_Status.Controls.Add(groupBox_StatusRevise);
        groupBox_Status.Controls.Add(NumericUpDown_Experience);
        groupBox_Status.Controls.Add(label30);
        groupBox_Status.Controls.Add(NumericUpDown_Level);
        groupBox_Status.Controls.Add(label29);
        groupBox_Status.Controls.Add(comboBox_StatusEditJob);
        groupBox_Status.Controls.Add(label28);
        groupBox_Status.Controls.Add(label22);
        groupBox_Status.Location = new Point(112, 284);
        groupBox_Status.Name = "groupBox_Status";
        groupBox_Status.Size = new Size(703, 235);
        groupBox_Status.TabIndex = 12;
        groupBox_Status.TabStop = false;
        groupBox_Status.Text = "Status";
        GroupBox_SkillSpecialty.Controls.Add(comboBox_SkillSpecialty);
        GroupBox_SkillSpecialty.Controls.Add(checkBox_Cheer);
        GroupBox_SkillSpecialty.Controls.Add(checkBox_Ruler);
        GroupBox_SkillSpecialty.Controls.Add(checkedListBox_Skill);
        GroupBox_SkillSpecialty.Controls.Add(label42);
        GroupBox_SkillSpecialty.Controls.Add(label41);
        GroupBox_SkillSpecialty.Controls.Add(checkedListBox_Specialty);
        GroupBox_SkillSpecialty.Location = new Point(7, 43);
        GroupBox_SkillSpecialty.Name = "GroupBox_SkillSpecialty";
        GroupBox_SkillSpecialty.Size = new Size(354, 186);
        GroupBox_SkillSpecialty.TabIndex = 0;
        GroupBox_SkillSpecialty.TabStop = false;
        GroupBox_SkillSpecialty.Text = "Skills / Abilities Effects";
        comboBox_SkillSpecialty.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_SkillSpecialty.FormattingEnabled = true;
        comboBox_SkillSpecialty.Location = new Point(10, 44);
        comboBox_SkillSpecialty.Name = "comboBox_SkillSpecialty";
        comboBox_SkillSpecialty.Size = new Size(171, 20);
        comboBox_SkillSpecialty.TabIndex = 2;
        comboBox_SkillSpecialty.SelectedIndexChanged += comboBox_SkillSpecialty_SelectedIndexChanged;
        checkBox_Cheer.AutoSize = true;
        checkBox_Cheer.Location = new Point(72, 22);
        checkBox_Cheer.Name = "checkBox_Cheer";
        checkBox_Cheer.Size = new Size(60, 16);
        checkBox_Cheer.TabIndex = 1;
        checkBox_Cheer.Text = "Egg On";
        checkBox_Cheer.UseVisualStyleBackColor = true;
        checkBox_Cheer.CheckedChanged += checkBox_Cheer_CheckedChanged;
        checkBox_Ruler.AutoSize = true;
        checkBox_Ruler.Location = new Point(11, 22);
        checkBox_Ruler.Name = "checkBox_Ruler";
        checkBox_Ruler.Size = new Size(52, 16);
        checkBox_Ruler.TabIndex = 0;
        checkBox_Ruler.Text = "Zoom";
        checkBox_Ruler.UseVisualStyleBackColor = true;
        checkBox_Ruler.CheckedChanged += checkBox_Ruler_CheckedChanged;
        checkedListBox_Skill.FormattingEnabled = true;
        checkedListBox_Skill.Location = new Point(166, 88);
        checkedListBox_Skill.Name = "checkedListBox_Skill";
        checkedListBox_Skill.Size = new Size(177, 100);
        checkedListBox_Skill.TabIndex = 4;
        checkedListBox_Skill.ItemCheck += checkedListBox_Skill_ItemCheck;
        label42.AutoSize = true;
        label42.Location = new Point(164, 73);
        label42.Name = "label42";
        label42.Size = new Size(58, 12);
        label42.TabIndex = 43;
        label42.Text = "Traits";
        label41.AutoSize = true;
        label41.Location = new Point(11, 73);
        label41.Name = "label41";
        label41.Size = new Size(29, 12);
        label41.TabIndex = 45;
        label41.Text = "Abilities";
        checkedListBox_Specialty.FormattingEnabled = true;
        checkedListBox_Specialty.Location = new Point(10, 88);
        checkedListBox_Specialty.Name = "checkedListBox_Specialty";
        checkedListBox_Specialty.Size = new Size(147, 100);
        checkedListBox_Specialty.TabIndex = 3;
        checkedListBox_Specialty.ItemCheck += checkedListBox_Specialty_ItemCheck;
        _numericUpDown_Transmigration.Location = new Point(507, 44);
        _numericUpDown_Transmigration.Maximum = new decimal(new int[4]
        {
            10,
            0,
            0,
            0
        });
        _numericUpDown_Transmigration.Name = "_numericUpDown_Transmigration";
        _numericUpDown_Transmigration.Size = new Size(38, 19);
        _numericUpDown_Transmigration.TabIndex = 5;
        _numericUpDown_Transmigration.Value = new decimal(new int[4]);
        _numericUpDown_Transmigration.ValueChanged += _numericUpDown_Transmigration_ValueChanged;
        label40.AutoSize = true;
        label40.Location = new Point(441, 47);
        label40.Name = "label40";
        label40.Size = new Size(29, 12);
        label40.TabIndex = 41;
        label40.Text = "Revocations";
        groupBox_Skill.Location = new Point(369, 97);
        groupBox_Skill.Name = "groupBox_Skill";
        groupBox_Skill.Size = new Size(172, 132);
        groupBox_Skill.TabIndex = 1;
        groupBox_Skill.TabStop = false;
        groupBox_Skill.Text = "Skill";
        groupBox_StatusRevise.Controls.Add(label38);
        groupBox_StatusRevise.Controls.Add(label34);
        groupBox_StatusRevise.Controls.Add(label31);
        groupBox_StatusRevise.Controls.Add(label36);
        groupBox_StatusRevise.Controls.Add(label32);
        groupBox_StatusRevise.Controls.Add(label37);
        groupBox_StatusRevise.Controls.Add(label33);
        groupBox_StatusRevise.Controls.Add(label39);
        groupBox_StatusRevise.Controls.Add(label35);
        groupBox_StatusRevise.Location = new Point(553, 18);
        groupBox_StatusRevise.Name = "groupBox_StatusRevise";
        groupBox_StatusRevise.Size = new Size(141, 211);
        groupBox_StatusRevise.TabIndex = 2;
        groupBox_StatusRevise.TabStop = false;
        groupBox_StatusRevise.Text = "Seeds";
        label38.AutoSize = true;
        label38.Location = new Point(43, 147);
        label38.Name = "label38";
        label38.Size = new Size(37, 12);
        label38.TabIndex = 59;
        label38.Text = "Charm";
        label34.AutoSize = true;
        label34.Location = new Point(35, 21);
        label34.Name = "label34";
        label34.Size = new Size(44, 12);
        label34.TabIndex = 45;
        label34.Text = "Max HP";
        label31.AutoSize = true;
        label31.Location = new Point(32, 63);
        label31.Name = "label31";
        label31.Size = new Size(32, 12);
        label31.TabIndex = 41;
        label31.Text = "Strength";
        label36.AutoSize = true;
        label36.Location = new Point(7, 189);
        label36.Name = "label36";
        label36.Size = new Size(63, 12);
        label36.TabIndex = 57;
        label36.Text = "Magical Might";
        label32.AutoSize = true;
        label32.Location = new Point(31, 126);
        label32.Name = "label32";
        label32.Size = new Size(38, 12);
        label32.TabIndex = 43;
        label32.Text = "Deftness";
        label37.AutoSize = true;
        label37.Location = new Point(24, 105);
        label37.Name = "label37";
        label37.Size = new Size(50, 12);
        label37.TabIndex = 55;
        label37.Text = "Resilience";
        label33.AutoSize = true;
        label33.Location = new Point(34, 42);
        label33.Name = "label33";
        label33.Size = new Size(45, 12);
        label33.TabIndex = 47;
        label33.Text = "Max MP";
        label39.AutoSize = true;
        label39.Location = new Point(6, 168);
        label39.Name = "label39";
        label39.Size = new Size(65, 12);
        label39.TabIndex = 51;
        label39.Text = "Magical Mend";
        label35.AutoSize = true;
        label35.Location = new Point(45, 84);
        label35.Name = "label35";
        label35.Size = new Size(43, 12);
        label35.TabIndex = 49;
        label35.Text = "Agility";
        NumericUpDown_Experience.Location = new Point(465, 69);
        NumericUpDown_Experience.Name = "NumericUpDown_Experience";
        NumericUpDown_Experience.Size = new Size(80, 19);
        NumericUpDown_Experience.TabIndex = 6;
        NumericUpDown_Experience.Value = new decimal(new int[4]);
        NumericUpDown_Experience.ValueChanged += _numericUpDown_Experience_ValueChanged;
        label30.AutoSize = true;
        label30.Location = new Point(431, 73);
        label30.Name = "label30";
        label30.Size = new Size(41, 12);
        label30.TabIndex = 39;
        label30.Text = "Exp.";
        NumericUpDown_Level.Location = new Point(403, 44);
        NumericUpDown_Level.Name = "NumericUpDown_Level";
        NumericUpDown_Level.Size = new Size(38, 19);
        NumericUpDown_Level.TabIndex = 4;
        NumericUpDown_Level.Value = new decimal(new int[4]);
        NumericUpDown_Level.ValueChanged += _numericUpDown_Level_ValueChanged;
        label29.AutoSize = true;
        label29.Location = new Point(368, 48);
        label29.Name = "label29";
        label29.Size = new Size(34, 12);
        label29.TabIndex = 37;
        label29.Text = "Level";
        comboBox_StatusEditJob.DropDownHeight = 200;
        comboBox_StatusEditJob.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_StatusEditJob.FormattingEnabled = true;
        comboBox_StatusEditJob.IntegralHeight = false;
        comboBox_StatusEditJob.Location = new Point(453, 18);
        comboBox_StatusEditJob.Name = "comboBox_StatusEditJob";
        comboBox_StatusEditJob.Size = new Size(92, 20);
        comboBox_StatusEditJob.TabIndex = 3;
        comboBox_StatusEditJob.SelectedIndexChanged += comboBox_StatusEditJob_SelectedIndexChanged;
        label28.AutoSize = true;
        label28.Location = new Point(369, 22);
        label28.Name = "label28";
        label28.Size = new Size(72, 12);
        label28.TabIndex = 35;
        label28.Text = "Vocation to Edit";
        GroupBox_State.Controls.Add(checkBox_Curse);
        GroupBox_State.Controls.Add(checkBox_Poison);
        GroupBox_State.Controls.Add(checkBox_Die);
        GroupBox_State.Location = new Point(706, 5);
        GroupBox_State.Name = "GroupBox_State";
        GroupBox_State.Size = new Size(109, 67);
        GroupBox_State.TabIndex = 34;
        GroupBox_State.TabStop = false;
        GroupBox_State.Text = "State";
        checkBox_Curse.AutoSize = true;
        checkBox_Curse.Location = new Point(10, 41);
        checkBox_Curse.Name = "checkBox_Curse";
        checkBox_Curse.Size = new Size(53, 16);
        checkBox_Curse.TabIndex = 2;
        checkBox_Curse.Text = "Cursed";
        checkBox_Curse.UseVisualStyleBackColor = true;
        checkBox_Curse.CheckedChanged += checkBox_Curse_CheckedChanged;
        checkBox_Poison.AutoSize = true;
        checkBox_Poison.Location = new Point(57, 20);
        checkBox_Poison.Name = "checkBox_Poison";
        checkBox_Poison.Size = new Size(39, 16);
        checkBox_Poison.TabIndex = 1;
        checkBox_Poison.Text = "Poison";
        checkBox_Poison.UseVisualStyleBackColor = true;
        checkBox_Poison.CheckedChanged += checkBox_Poison_CheckedChanged;
        checkBox_Die.AutoSize = true;
        checkBox_Die.Location = new Point(10, 20);
        checkBox_Die.Name = "checkBox_Die";
        checkBox_Die.Size = new Size(42, 16);
        checkBox_Die.TabIndex = 0;
        checkBox_Die.Text = "Dead";
        checkBox_Die.UseVisualStyleBackColor = true;
        checkBox_Die.CheckedChanged += checkBox_Die_CheckedChanged;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(GroupBox_State);
        Controls.Add(groupBox_Status);
        Controls.Add(label_MaxMP);
        Controls.Add(label_MaxHP);
        Controls.Add(NumericUpDown_NowMP);
        Controls.Add(NumericUpDown_NowHP);
        Controls.Add(label27);
        Controls.Add(label26);
        Controls.Add(groupBox_Tool);
        Controls.Add(comboBox_Color);
        Controls.Add(label25);
        Controls.Add(comboBox_Strategy);
        Controls.Add(label24);
        Controls.Add(comboBox_Rank);
        Controls.Add(label23);
        Controls.Add(groupBox_Figure);
        Controls.Add(groupBox_Equipment);
        Controls.Add(comboBox_Sex);
        Controls.Add(label4);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Controls.Add(label3);
        Controls.Add(comboBox_Job);
        Controls.Add(label_Job);
        Controls.Add(label_Name);
        Name = nameof(CharacterDataControl);
        Size = new Size(846, 525);
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        toolStrip1.ResumeLayout(false);
        toolStrip1.PerformLayout();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        toolStrip2.ResumeLayout(false);
        toolStrip2.PerformLayout();
        groupBox_Equipment.ResumeLayout(false);
        groupBox_Equipment.PerformLayout();
        groupBox_Figure.ResumeLayout(false);
        groupBox_Figure.PerformLayout();
        NumericUpDown_NowHP.EndInit();
        NumericUpDown_NowMP.EndInit();
        groupBox_Status.ResumeLayout(false);
        groupBox_Status.PerformLayout();
        GroupBox_SkillSpecialty.ResumeLayout(false);
        GroupBox_SkillSpecialty.PerformLayout();
        _numericUpDown_Transmigration.EndInit();
        groupBox_StatusRevise.ResumeLayout(false);
        groupBox_StatusRevise.PerformLayout();
        NumericUpDown_Experience.EndInit();
        NumericUpDown_Level.EndInit();
        GroupBox_State.ResumeLayout(false);
        GroupBox_State.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    public void Initialize()
    {
        SuspendLayout();
        BeginUpdate();
        comboBox_Job.Items.Clear();
        comboBox_StatusEditJob.Items.Clear();
        foreach (var jobData in JobDataList.List)
        {
            comboBox_Job.Items.Add(jobData.Name);
            comboBox_StatusEditJob.Items.Add(jobData.Name);
        }

        comboBox_Job.SelectedIndex = 0;
        comboBox_StatusEditJob.SelectedIndex = 0;
        comboBox_Strategy.Items.Clear();
        foreach (object obj in StrategyList.List)
            comboBox_Strategy.Items.Add(obj);
        comboBox_Strategy.SelectedIndex = 0;
        for (var index = 0; index < 8; ++index)
        {
            _textBox_Tools[index] = new VisionTextBox(16, 20 + 21 * index, 110, 19);
            _textBox_Tools[index].ReadOnly = true;
            _textBox_Tools[index].TabStop = false;
            groupBox_Tool.AddVisionControl(_textBox_Tools[index]);
            _button_SelectTools[index] = new VisionButton(129, 20 + 21 * index, 39, 19);
            _button_SelectTools[index].Text = "Set";
            _button_SelectTools[index].Click += button_SelectTools_Click;
            _button_SelectTools[index].Tag = index;
            groupBox_Tool.AddVisionControl(_button_SelectTools[index]);
            _textBox_Equipment[index] = new VisionTextBox(70, 20 + 21 * index, 113, 19);
            _textBox_Equipment[index].ReadOnly = true;
            _textBox_Equipment[index].TabStop = false;
            groupBox_Equipment.AddVisionControl(_textBox_Equipment[index]);
        }

        for (var index = 0; index < 5; ++index)
        {
            _label_Skills[index] = new Label();
            _label_Skills[index].AutoSize = false;
            _label_Skills[index].TextAlign = ContentAlignment.MiddleRight;
            _label_Skills[index].Location = new Point(12, 23 + index * 21);
            _label_Skills[index].Size = new Size(90, 14);
            _numericUpDown_Skills[index] = new VisionNumericUpDown(103, 20 + index * 21, 50, 19);
            _numericUpDown_Skills[index].Tag = index;
            _numericUpDown_Skills[index].Minimum = 0M;
            _numericUpDown_Skills[index].Maximum = 100M;
            _numericUpDown_Skills[index].ValueChanged += NumericUpDown_Skill_ValueChanged;
            groupBox_Skill.Controls.Add(_label_Skills[index]);
            groupBox_Skill.AddVisionControl(_numericUpDown_Skills[index]);
        }

        groupBox_Tool.Enabled = false;
        _textBox_CharacterName = new VisionTextBox(201, 17, 100, 19);
        _textBox_CharacterName.TextChanged += textBox_CharacterName_TextChanged;
        _textBox_CharacterName.TabIndex = 1;
        AddVisionControl(_textBox_CharacterName);
        NumericUpDown_SkillPoint = new VisionNumericUpDown(87, 18, 56, 19);
        NumericUpDown_SkillPoint.ValueChanged += _numericUpDown_SkillPoint_ValueChanged;
        groupBox_Status.AddVisionControl(NumericUpDown_SkillPoint);
        var num1 = 1;
        int num2;
        NumericUpDown_FigureWidth = new VisionNumericUpDown(72, num2 = num1 + 21, 56, 19);
        NumericUpDown_FigureWidth.ValueChanged += _numericUpDown_FigureWidth_ValueChanged;
        groupBox_Figure.AddVisionControl(NumericUpDown_FigureWidth);
        int num3;
        NumericUpDown_FigureHeight = new VisionNumericUpDown(72, num3 = num2 + 21, 56, 19);
        NumericUpDown_FigureHeight.ValueChanged += _numericUpDown_FigureHeight_ValueChanged;
        groupBox_Figure.AddVisionControl(NumericUpDown_FigureHeight);
        int num4;
        NumericUpDown_Hair = new VisionNumericUpDown(72, num4 = num3 + 21, 56, 19);
        NumericUpDown_Hair.ValueChanged += _numericUpDown_Hair_ValueChanged;
        groupBox_Figure.AddVisionControl(NumericUpDown_Hair);
        int num5;
        NumericUpDown_HairColor = new VisionNumericUpDown(72, num5 = num4 + 21, 56, 19);
        NumericUpDown_HairColor.ValueChanged += _numericUpDown_HairColor_ValueChanged;
        groupBox_Figure.AddVisionControl(NumericUpDown_HairColor);
        int num6;
        NumericUpDown_Face = new VisionNumericUpDown(72, num6 = num5 + 21, 56, 19);
        NumericUpDown_Face.ValueChanged += _numericUpDown_Face_ValueChanged;
        groupBox_Figure.AddVisionControl(NumericUpDown_Face);
        int num7;
        NumericUpDown_SkinColor = new VisionNumericUpDown(72, num7 = num6 + 21, 56, 19);
        NumericUpDown_SkinColor.ValueChanged += _numericUpDown_SkinColor_ValueChanged;
        groupBox_Figure.AddVisionControl(NumericUpDown_SkinColor);
        int num8;
        NumericUpDown_EyeColor = new VisionNumericUpDown(72, num8 = num7 + 21, 56, 19);
        NumericUpDown_EyeColor.ValueChanged += _numericUpDown_EyeColor_ValueChanged;
        groupBox_Figure.AddVisionControl(NumericUpDown_EyeColor);
        var num9 = -4;
        int num10;
        _numericUpDown_ReviseHP = new VisionNumericUpDown(80, num10 = num9 + 21, 51, 19);
        _numericUpDown_ReviseHP.Minimum = 0M;
        _numericUpDown_ReviseHP.Maximum = 999M;
        _numericUpDown_ReviseHP.ValueChanged += _numericUpDown_ReviseHP_ValueChanged;
        groupBox_StatusRevise.AddVisionControl(_numericUpDown_ReviseHP);
        int num11;
        _numericUpDown_ReviseMP = new VisionNumericUpDown(80, num11 = num10 + 21, 51, 19);
        _numericUpDown_ReviseMP.Minimum = 0M;
        _numericUpDown_ReviseMP.Maximum = 999M;
        _numericUpDown_ReviseMP.ValueChanged += _numericUpDown_ReviseMP_ValueChanged;
        groupBox_StatusRevise.AddVisionControl(_numericUpDown_ReviseMP);
        int num12;
        _numericUpDown_RevisePower = new VisionNumericUpDown(80, num12 = num11 + 21, 51, 19);
        _numericUpDown_RevisePower.Minimum = 0M;
        _numericUpDown_RevisePower.Maximum = 999M;
        _numericUpDown_RevisePower.ValueChanged += _numericUpDown_RevisePower_ValueChanged;
        groupBox_StatusRevise.AddVisionControl(_numericUpDown_RevisePower);
        int num13;
        _numericUpDown_ReviseQuick = new VisionNumericUpDown(80, num13 = num12 + 21, 51, 19);
        _numericUpDown_ReviseQuick.Minimum = 0M;
        _numericUpDown_ReviseQuick.Maximum = 999M;
        _numericUpDown_ReviseQuick.ValueChanged += _numericUpDown_ReviseQuick_ValueChanged;
        groupBox_StatusRevise.AddVisionControl(_numericUpDown_ReviseQuick);
        int num14;
        _numericUpDown_ReviseDefense = new VisionNumericUpDown(80, num14 = num13 + 21, 51, 19);
        _numericUpDown_ReviseDefense.Minimum = 0M;
        _numericUpDown_ReviseDefense.Maximum = 999M;
        _numericUpDown_ReviseDefense.ValueChanged += _numericUpDown_ReviseDefense_ValueChanged;
        groupBox_StatusRevise.AddVisionControl(_numericUpDown_ReviseDefense);
        int num15;
        _numericUpDown_ReviseFacility = new VisionNumericUpDown(80, num15 = num14 + 21, 51, 19);
        _numericUpDown_ReviseFacility.Minimum = 0M;
        _numericUpDown_ReviseFacility.Maximum = 999M;
        _numericUpDown_ReviseFacility.ValueChanged += _numericUpDown_ReviseFacility_ValueChanged;
        groupBox_StatusRevise.AddVisionControl(_numericUpDown_ReviseFacility);
        int num16;
        _numericUpDown_ReviseSmart = new VisionNumericUpDown(80, num16 = num15 + 21, 51, 19);
        _numericUpDown_ReviseSmart.Minimum = 0M;
        _numericUpDown_ReviseSmart.Maximum = 999M;
        _numericUpDown_ReviseSmart.ValueChanged += _numericUpDown_ReviseSmart_ValueChanged;
        groupBox_StatusRevise.AddVisionControl(_numericUpDown_ReviseSmart);
        int num17;
        _numericUpDown_ReviseRevivalMagic = new VisionNumericUpDown(80, num17 = num16 + 21, 51, 19);
        _numericUpDown_ReviseRevivalMagic.Minimum = 0M;
        _numericUpDown_ReviseRevivalMagic.Maximum = 999M;
        _numericUpDown_ReviseRevivalMagic.ValueChanged += _numericUpDown_ReviseRevivalMagic_ValueChanged;
        groupBox_StatusRevise.AddVisionControl(_numericUpDown_ReviseRevivalMagic);
        _numericUpDown_ReviseAttackMagic = new VisionNumericUpDown(80, num8 = num17 + 21, 51, 19);
        _numericUpDown_ReviseAttackMagic.Minimum = 0M;
        _numericUpDown_ReviseAttackMagic.Maximum = 999M;
        _numericUpDown_ReviseAttackMagic.ValueChanged += _numericUpDown_ReviseAttackMagic_ValueChanged;
        groupBox_StatusRevise.AddVisionControl(_numericUpDown_ReviseAttackMagic);
        foreach (object obj in SkillDataList.List)
            comboBox_SkillSpecialty.Items.Add(obj);
        comboBox_SkillSpecialty.SelectedIndex = 0;
        RenewalSkillSpecialtyList();
        EndUpdate();
        ResumeLayout(false);
    }

    protected override void OnDataFileLoad()
    {
        _selectedIndex = SaveDataManager.Instance.SaveData.CharacterManager.CharacterStandbyCount;
        RenewalControl();
    }

    protected override void OnValueUpdate()
    {
        RenewalControl();
    }

    private void RenewalMemberListBox()
    {
        BeginUpdate();
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        listBox_PartyMember.BeginUpdate();
        listBox_StandbyMember.BeginUpdate();
        listBox_PartyMember.Items.Clear();
        listBox_StandbyMember.Items.Clear();
        var num = 0;
        for (var index = 0; index < characterManager.CharacterStandbyCount && index < 12; ++index)
            listBox_StandbyMember.Items.Add(characterManager.CharacterData[num++].Name.Value);
        for (var index = 0; index < characterManager.PartyCharacterCount && num < 13; ++index)
            listBox_PartyMember.Items.Add(characterManager.CharacterData[num++].Name.Value);
        if (_selectedIndex < listBox_StandbyMember.Items.Count)
            listBox_StandbyMember.SelectedIndex = _selectedIndex;
        else if (_selectedIndex - characterManager.CharacterStandbyCount < listBox_PartyMember.Items.Count)
            listBox_PartyMember.SelectedIndex = _selectedIndex - characterManager.CharacterStandbyCount;
        else
            listBox_PartyMember.SelectedIndex = listBox_PartyMember.Items.Count - 1;
        listBox_PartyMember.EndUpdate();
        listBox_StandbyMember.EndUpdate();
        EndUpdate();
    }

    private void RenewalJobStatus()
    {
        BeginUpdate();
        var characterData = SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex];
        var dataIndex = JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex;
        NumericUpDown_Level.Value = characterData.JobLevel[dataIndex].Value;
        NumericUpDown_Experience.Value = characterData.JobExperience[dataIndex].Value;
        _numericUpDown_Transmigration.Value = characterData.GetTransmigration(dataIndex);
        _numericUpDown_RevisePower.Value = characterData.GetRevisePower(dataIndex);
        _numericUpDown_ReviseQuick.Value = characterData.GetReviseQuick(dataIndex);
        _numericUpDown_ReviseDefense.Value = characterData.GetReviseDefense(dataIndex);
        _numericUpDown_ReviseFacility.Value = characterData.GetReviseFacility(dataIndex);
        _numericUpDown_ReviseSmart.Value = characterData.GetReviseSmart(dataIndex);
        _numericUpDown_ReviseRevivalMagic.Value = characterData.GetReviseRevivalMagic(dataIndex);
        _numericUpDown_ReviseAttackMagic.Value = characterData.GetReviseAttackMagic(dataIndex);
        _numericUpDown_ReviseHP.Value = characterData.GetReviseMaxHP(dataIndex);
        _numericUpDown_ReviseMP.Value = characterData.GetReviseMaxMP(dataIndex);
        var jobData = JobDataList.GetJobData(dataIndex);
        if (jobData.SkillList == null)
        {
            groupBox_Skill.Enabled = false;
            for (var index = 0; index < 5; ++index)
            {
                _label_Skills[index].Text = "-";
                _numericUpDown_Skills[index].Value = 0M;
            }
        }
        else
        {
            groupBox_Skill.Enabled = true;
            for (var index = 0; index < 5; ++index)
            {
                _label_Skills[index].Text = jobData.SkillList[index].Name;
                _numericUpDown_Skills[index].Value = characterData.JobSkillLevel[jobData.SkillList[index].Index].Value;
            }
        }

        EndUpdate();
    }

    private void RenewalSkillSpecialtyList()
    {
        if (!(comboBox_SkillSpecialty.SelectedItem is SkillData selectedItem))
            return;
        checkedListBox_Specialty.BeginUpdate();
        checkedListBox_Skill.BeginUpdate();
        checkedListBox_Specialty.Items.Clear();
        checkedListBox_Skill.Items.Clear();
        foreach (object skillSpecialty in selectedItem.SkillSpecialtyList)
            checkedListBox_Specialty.Items.Add(skillSpecialty);
        foreach (object skillEffect in selectedItem.SkillEffectList)
            checkedListBox_Skill.Items.Add(skillEffect);
        checkedListBox_Specialty.EndUpdate();
        checkedListBox_Skill.EndUpdate();
    }

    private void RenewalSkillSpecialtyListState()
    {
        BeginUpdate();
        if (comboBox_SkillSpecialty.SelectedItem is SkillData selectedItem)
        {
            var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
            var index1 = 0;
            foreach (var skillSpecialty in selectedItem.SkillSpecialtyList)
            {
                checkedListBox_Specialty.SetItemChecked(index1,
                    characterManager.CharacterData[_selectedIndex].IsLearnSkillSpecialtyEffect(skillSpecialty.Index));
                ++index1;
            }

            var index2 = 0;
            foreach (var skillEffect in selectedItem.SkillEffectList)
            {
                checkedListBox_Skill.SetItemChecked(index2,
                    characterManager.CharacterData[_selectedIndex].IsLearnSkillSpecialtyEffect(skillEffect.Index));
                ++index2;
            }
        }

        EndUpdate();
    }

    protected override void RenewalControl()
    {
        BeginUpdate();
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        RenewalMemberListBox();
        var characterData = characterManager.CharacterData[_selectedIndex];
        checkBox_Die.Checked = characterData.Die;
        checkBox_Poison.Checked = characterData.Poison;
        checkBox_Curse.Checked = characterData.Curse;
        _textBox_CharacterName.Text = characterData.Name.Value;
        comboBox_Sex.SelectedIndex = characterData.Sex;
        for (var index = 0; index < JobDataList.List.Count; ++index)
            if (JobDataList.List[index].DataIndex == characterData.Job.Value)
            {
                comboBox_Job.SelectedIndex = index;
                break;
            }

        RenewalJobStatus();
        NumericUpDown_NowHP.Value = characterData.NowHP;
        label_MaxHP.Text = string.Format("(Max HP {0})", characterData.MaxHP);
        NumericUpDown_NowMP.Value = characterData.NowMP;
        label_MaxMP.Text = string.Format("(Max MP {0})", characterData.MaxMP);
        NumericUpDown_FigureWidth.Value = characterData.FigureWidth.Value;
        NumericUpDown_FigureHeight.Value = characterData.FigureHeight.Value;
        NumericUpDown_Hair.Value = characterData.HairType.Value;
        NumericUpDown_HairColor.Value = characterData.HairColor.Value;
        NumericUpDown_Face.Value = characterData.FaceType.Value;
        NumericUpDown_SkinColor.Value = characterData.SkinColor;
        NumericUpDown_EyeColor.Value = characterData.EyeColor;
        NumericUpDown_SkillPoint.Value = characterData.SkillPoint.Value;
        var equipmentWeapon = characterData.EquipmentWeapon;
        _textBox_Equipment[0].Text = equipmentWeapon != null ? equipmentWeapon.Name : "Nothing";
        var equipmentShield = characterData.EquipmentShield;
        _textBox_Equipment[1].Text = equipmentShield != null ? equipmentShield.Name : "Nothing";
        var equipmentHead = characterData.EquipmentHead;
        _textBox_Equipment[2].Text = equipmentHead != null ? equipmentHead.Name : "Nothing";
        var equipmentUpperBody = characterData.EquipmentUpperBody;
        _textBox_Equipment[3].Text = equipmentUpperBody != null ? equipmentUpperBody.Name : "Nothing";
        var equipmentArm = characterData.EquipmentArm;
        _textBox_Equipment[4].Text = equipmentArm != null ? equipmentArm.Name : "Nothing";
        var equipmentLowerBody = characterData.EquipmentLowerBody;
        _textBox_Equipment[5].Text = equipmentLowerBody != null ? equipmentLowerBody.Name : "Nothing";
        var equipmentShoe = characterData.EquipmentShoe;
        _textBox_Equipment[6].Text = equipmentShoe != null ? equipmentShoe.Name : "Nothing";
        var equipmentAccessory = characterData.EquipmentAccessory;
        _textBox_Equipment[7].Text = equipmentAccessory != null ? equipmentAccessory.Name : "Nothing";
        if (_selectedIndex >= characterManager.CharacterStandbyCount)
        {
            groupBox_Tool.Enabled = true;
            var itemData = SaveDataManager.Instance.SaveData.ItemData;
            for (var toolIndex = 0; toolIndex < 8; ++toolIndex)
            {
                var tool = itemData.GetTool(_selectedIndex - characterManager.CharacterStandbyCount, toolIndex);
                _textBox_Tools[toolIndex].Text = tool != null ? tool.Name : "Empty";
            }
        }
        else
        {
            groupBox_Tool.Enabled = false;
            for (var index = 0; index < 8; ++index)
                _textBox_Tools[index].Text = string.Empty;
        }

        comboBox_Strategy.SelectedItem = characterData.Strategy;
        comboBox_Rank.SelectedIndex = characterData.Rank;
        comboBox_Color.SelectedIndex = characterData.Color;
        checkBox_Ruler.Checked = characterData.IsLearnRular();
        checkBox_Cheer.Checked = characterData.IsLearnCheer();
        RenewalSkillSpecialtyListState();
        RenewalCharacterToolbar();
        EndUpdate();
    }

    private void RenewalCharacterToolbar()
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (listBox_PartyMember.SelectedIndex == -1)
        {
            toolButton_PartyMemberUp.Enabled = false;
            toolButton_PartyMemberDown.Enabled = false;
            toolButton_PartyOut.Enabled = false;
        }
        else if (listBox_PartyMember.SelectedIndex == 0)
        {
            toolButton_PartyMemberUp.Enabled = false;
            toolButton_PartyMemberDown.Enabled = characterManager.PartyCharacterCount > 1;
            toolButton_PartyOut.Enabled = characterManager.PartyCharacterCount > 1;
        }
        else if (listBox_PartyMember.SelectedIndex == characterManager.PartyCharacterCount - 1)
        {
            toolButton_PartyMemberUp.Enabled = true;
            toolButton_PartyMemberDown.Enabled = false;
            toolButton_PartyOut.Enabled = true;
        }
        else
        {
            toolButton_PartyMemberUp.Enabled = true;
            toolButton_PartyMemberDown.Enabled = true;
            toolButton_PartyOut.Enabled = true;
        }

        toolButton_CreateMember.Enabled = characterManager.CharacterCount < 13;
        if (listBox_StandbyMember.SelectedIndex == -1)
        {
            toolButton_RuidaMemberUp.Enabled = false;
            toolButton_RuidaMemberDown.Enabled = false;
            toolButton_DeleteMember.Enabled = false;
            toolButton_PartyIn.Enabled = false;
        }
        else
        {
            toolButton_DeleteMember.Enabled = true;
            toolButton_PartyIn.Enabled = characterManager.PartyCharacterCount < 4;
            if (listBox_StandbyMember.SelectedIndex == 0)
            {
                toolButton_RuidaMemberUp.Enabled = false;
                toolButton_RuidaMemberDown.Enabled = characterManager.CharacterStandbyCount > 1;
            }
            else if (listBox_StandbyMember.SelectedIndex == characterManager.CharacterStandbyCount - 1)
            {
                toolButton_RuidaMemberUp.Enabled = true;
                toolButton_RuidaMemberDown.Enabled = false;
            }
            else
            {
                toolButton_RuidaMemberUp.Enabled = true;
                toolButton_RuidaMemberDown.Enabled = true;
            }
        }
    }

    private void textBox_CharacterName_TextChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        characterManager.CharacterData[_selectedIndex].Name.Value = _textBox_CharacterName.Text;
        _textBox_CharacterName.Text = characterManager.CharacterData[_selectedIndex].Name.Value;
        RenewalMemberListBox();
    }

    private void toolButton_PartyIn_Click(object sender, EventArgs e)
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (listBox_StandbyMember.SelectedIndex == -1)
            return;
        characterManager.PartyIn(listBox_StandbyMember.SelectedIndex);
        _selectedIndex = characterManager.CharacterCount - 1;
        RenewalControl();
    }

    private void toolButton_PartyMemberUp_Click(object sender, EventArgs e)
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (listBox_PartyMember.SelectedIndex <= 0)
            return;
        characterManager.PartyMemberUp(listBox_PartyMember.SelectedIndex);
        --_selectedIndex;
        RenewalControl();
    }

    private void toolButton_PartyMemberDown_Click(object sender, EventArgs e)
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (listBox_PartyMember.SelectedIndex >= characterManager.PartyCharacterCount - 1 ||
            listBox_PartyMember.SelectedIndex == -1)
            return;
        characterManager.PartyMemberDown(listBox_PartyMember.SelectedIndex);
        ++_selectedIndex;
        RenewalControl();
    }

    private void toolButton_RuidaMemberUp_Click(object sender, EventArgs e)
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (listBox_StandbyMember.SelectedIndex <= 0)
            return;
        characterManager.StandbyMemberUp(listBox_StandbyMember.SelectedIndex);
        --_selectedIndex;
        RenewalControl();
    }

    private void toolButton_RuidaMemberDown_Click(object sender, EventArgs e)
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (listBox_StandbyMember.SelectedIndex >= characterManager.CharacterStandbyCount - 1 ||
            listBox_StandbyMember.SelectedIndex == -1)
            return;
        characterManager.StandbyMemberDown(listBox_StandbyMember.SelectedIndex);
        ++_selectedIndex;
        RenewalControl();
    }

    private void toolButton_PartyOut_Click(object sender, EventArgs e)
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (characterManager.PartyCharacterCount < 2)
            return;
        characterManager.PartyOut(listBox_PartyMember.SelectedIndex);
        _selectedIndex = characterManager.CharacterStandbyCount - 1;
        RenewalControl();
    }

    private void toolButton_DeleteMember_Click(object sender, EventArgs e)
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        var selectedIndex = listBox_StandbyMember.SelectedIndex;
        if (selectedIndex == -1 ||
            MessageBox.Show(
                string.Format("キャラクター「{0}」を削除します。\nよろしいですか？", characterManager.CharacterData[selectedIndex].Name.Value),
                "确定", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
        characterManager.DeleteCharacter(selectedIndex);
        _selectedIndex = 0;
        RenewalControl();
    }

    private void toolButton_CreateMember_Click(object sender, EventArgs e)
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (characterManager.CharacterCount >= 13)
            return;
        characterManager.CreateCharacter();
        _selectedIndex = characterManager.CharacterStandbyCount - 1;
        RenewalControl();
    }

    private void listBox_PartyMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (_updateCount != 0 || listBox_PartyMember.SelectedIndex == -1)
            return;
        _selectedIndex = characterManager.CharacterStandbyCount + listBox_PartyMember.SelectedIndex;
        listBox_StandbyMember.SelectedIndex = -1;
        RenewalControl();
    }

    private void listBox_StandbyMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || listBox_StandbyMember.SelectedIndex == -1)
            return;
        _selectedIndex = listBox_StandbyMember.SelectedIndex;
        listBox_PartyMember.SelectedIndex = -1;
        RenewalControl();
    }

    private void _numericUpDown_FigureWidth_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].FigureWidth.Value =
            (ushort)NumericUpDown_FigureWidth.Value;
    }

    private void _numericUpDown_FigureHeight_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].FigureHeight.Value =
            (ushort)NumericUpDown_FigureHeight.Value;
    }

    private void _numericUpDown_Hair_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].HairType.Value =
            (byte)NumericUpDown_Hair.Value;
    }

    private void _numericUpDown_HairColor_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].HairColor.Value =
            (byte)NumericUpDown_HairColor.Value;
    }

    private void _numericUpDown_Face_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].FaceType.Value =
            (byte)NumericUpDown_Face.Value;
    }

    private void _numericUpDown_SkinColor_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SkinColor =
            (byte)NumericUpDown_SkinColor.Value;
    }

    private void _numericUpDown_EyeColor_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].EyeColor =
            (byte)NumericUpDown_EyeColor.Value;
    }

    private void button_FigurePreset_Click(object sender, EventArgs e)
    {
        using (var presetWindow = new PresetWindow(ListType.Figure))
        {
            presetWindow.Location =
                PointToScreen(new Point(groupBox_Figure.Right, groupBox_Figure.Top + button_FigurePreset.Bottom));
            if (presetWindow.ShowDialog() != DialogResult.OK ||
                !(presetWindow.SelectedPreset is PresetFigure selectedPreset))
                return;
            SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
            var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
            characterManager.CharacterData[_selectedIndex].FigureWidth.Value = selectedPreset.Width;
            characterManager.CharacterData[_selectedIndex].FigureHeight.Value = selectedPreset.Height;
            SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
            RenewalControl();
        }
    }

    private void button_HairPreset_Click(object sender, EventArgs e)
    {
        using (var presetWindow = new PresetWindow(ListType.HairType))
        {
            presetWindow.Location =
                PointToScreen(new Point(groupBox_Figure.Right, groupBox_Figure.Top + button_HairPreset.Bottom));
            if (presetWindow.ShowDialog() != DialogResult.OK || !(presetWindow.SelectedPreset is Preset selectedPreset))
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].HairType.Value =
                selectedPreset.Index;
            RenewalControl();
        }
    }

    private void button_HairColorPreset_Click(object sender, EventArgs e)
    {
        using (var presetWindow = new PresetWindow(ListType.HairColor))
        {
            presetWindow.Location = PointToScreen(new Point(groupBox_Figure.Right,
                groupBox_Figure.Top + button_HairColorPreset.Bottom));
            if (presetWindow.ShowDialog() != DialogResult.OK || !(presetWindow.SelectedPreset is Preset selectedPreset))
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].HairColor.Value =
                selectedPreset.Index;
            RenewalControl();
        }
    }

    private void button_FacePreset_Click(object sender, EventArgs e)
    {
        using (var presetWindow = new PresetWindow(ListType.FaceType))
        {
            presetWindow.Location =
                PointToScreen(new Point(groupBox_Figure.Right, groupBox_Figure.Top + button_FacePreset.Bottom));
            if (presetWindow.ShowDialog() != DialogResult.OK || !(presetWindow.SelectedPreset is Preset selectedPreset))
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].FaceType.Value =
                selectedPreset.Index;
            RenewalControl();
        }
    }

    private void button_SelectWeapon_Click(object sender, EventArgs e)
    {
        using (var itemSelectWindow = new ItemSelectWindow(ItemType.Weapon))
        {
            itemSelectWindow.Location = PointToScreen(new Point(groupBox_Equipment.Right,
                groupBox_Equipment.Top + button_SelectWeapon.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].EquipmentWeapon =
                itemSelectWindow.SelectedItem;
            RenewalControl();
        }
    }

    private void button_SelectShield_Click(object sender, EventArgs e)
    {
        using (var itemSelectWindow = new ItemSelectWindow(ItemType.Shield))
        {
            itemSelectWindow.Location = PointToScreen(new Point(groupBox_Equipment.Right,
                groupBox_Equipment.Top + button_SelectShield.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].EquipmentShield =
                itemSelectWindow.SelectedItem;
            RenewalControl();
        }
    }

    private void button_SelectHead_Click(object sender, EventArgs e)
    {
        using (var itemSelectWindow = new ItemSelectWindow(ItemType.Head))
        {
            itemSelectWindow.Location = PointToScreen(new Point(groupBox_Equipment.Right,
                groupBox_Equipment.Top + button_SelectHead.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].EquipmentHead =
                itemSelectWindow.SelectedItem;
            RenewalControl();
        }
    }

    private void button_SelectUpperBody_Click(object sender, EventArgs e)
    {
        using (var itemSelectWindow = new ItemSelectWindow(ItemType.UpperBody))
        {
            itemSelectWindow.Location = PointToScreen(new Point(groupBox_Equipment.Right,
                groupBox_Equipment.Top + button_SelectUpperBody.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].EquipmentUpperBody =
                itemSelectWindow.SelectedItem;
            RenewalControl();
        }
    }

    private void button_SelectArm_Click(object sender, EventArgs e)
    {
        using (var itemSelectWindow = new ItemSelectWindow(ItemType.Arm))
        {
            itemSelectWindow.Location = PointToScreen(new Point(groupBox_Equipment.Right,
                groupBox_Equipment.Top + button_SelectArm.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].EquipmentArm =
                itemSelectWindow.SelectedItem;
            RenewalControl();
        }
    }

    private void button_SelectLowerBody_Click(object sender, EventArgs e)
    {
        using (var itemSelectWindow = new ItemSelectWindow(ItemType.LowerBody))
        {
            itemSelectWindow.Location = PointToScreen(new Point(groupBox_Equipment.Right,
                groupBox_Equipment.Top + button_SelectLowerBody.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].EquipmentLowerBody =
                itemSelectWindow.SelectedItem;
            RenewalControl();
        }
    }

    private void button_SelectShoe_Click(object sender, EventArgs e)
    {
        using (var itemSelectWindow = new ItemSelectWindow(ItemType.Shoe))
        {
            itemSelectWindow.Location = PointToScreen(new Point(groupBox_Equipment.Right,
                groupBox_Equipment.Top + button_SelectShoe.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].EquipmentShoe =
                itemSelectWindow.SelectedItem;
            RenewalControl();
        }
    }

    private void button_SelectAccessory_Click(object sender, EventArgs e)
    {
        using (var itemSelectWindow = new ItemSelectWindow(ItemType.Accessory))
        {
            itemSelectWindow.Location = PointToScreen(new Point(groupBox_Equipment.Right,
                groupBox_Equipment.Top + button_SelectAccessory.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].EquipmentAccessory =
                itemSelectWindow.SelectedItem;
            RenewalControl();
        }
    }

    private void comboBox_Sex_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].Sex =
            (byte)comboBox_Sex.SelectedIndex;
    }

    private void comboBox_Job_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].Job.Value =
            (byte)JobDataList.List[comboBox_Job.SelectedIndex].DataIndex;
    }

    private void _numericUpDown_SkillPoint_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SkillPoint.Value =
            (ushort)NumericUpDown_SkillPoint.Value;
    }

    private void comboBox_Color_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].Color =
            (byte)comboBox_Color.SelectedIndex;
    }

    private void comboBox_Rank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].Rank =
            (byte)comboBox_Rank.SelectedIndex;
    }

    private void comboBox_Strategy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].Strategy =
            comboBox_Strategy.SelectedItem as Strategy;
    }

    private void button_SelectTools_Click(object sender, EventArgs e)
    {
        if (!(sender is VisionButton visionButton))
            return;
        using (var itemSelectWindow = new ItemSelectWindow(ItemType.Tool))
        {
            itemSelectWindow.Location =
                PointToScreen(new Point(groupBox_Tool.Right, groupBox_Tool.Top + visionButton.Bottom));
            if (itemSelectWindow.ShowDialog() != DialogResult.OK)
                return;
            var selectedItem = itemSelectWindow.SelectedItem;
            SaveDataManager.Instance.SaveData.ItemData.SetTool(
                _selectedIndex - SaveDataManager.Instance.SaveData.CharacterManager.CharacterStandbyCount,
                (int)visionButton.Tag, selectedItem);
            RenewalControl();
        }
    }

    private void NumericUpDown_Skill_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].JobSkillLevel[
            JobDataList.GetJobData(JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex)
                .SkillList[(int)visionNumericUpDown.Tag].Index].Value = (byte)visionNumericUpDown.Value;
    }

    private void _numericUpDown_NowHP_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].NowHP =
            (ushort)NumericUpDown_NowHP.Value;
    }

    private void _numericUpDown_NowMP_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].NowMP =
            (ushort)NumericUpDown_NowMP.Value;
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
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex]
                .JobLevel[JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex].Value =
            (byte)NumericUpDown_Level.Value;
    }

    private void _numericUpDown_Experience_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex]
                .JobExperience[JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex].Value =
            (uint)NumericUpDown_Experience.Value;
    }

    private void comboBox_StatusEditJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        RenewalJobStatus();
    }

    private void _numericUpDown_ReviseHP_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetReviseMaxHP(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort)_numericUpDown_ReviseHP.Value);
    }

    private void _numericUpDown_ReviseMP_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetReviseMaxMP(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort)_numericUpDown_ReviseMP.Value);
    }

    private void _numericUpDown_RevisePower_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetRevisePower(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort)_numericUpDown_RevisePower.Value);
    }

    private void _numericUpDown_ReviseFacility_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetReviseFacility(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex,
            (ushort)_numericUpDown_ReviseFacility.Value);
    }

    private void _numericUpDown_ReviseQuick_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetReviseQuick(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort)_numericUpDown_ReviseQuick.Value);
    }

    private void _numericUpDown_ReviseDefense_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetReviseDefense(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex,
            (ushort)_numericUpDown_ReviseDefense.Value);
    }

    private void _numericUpDown_ReviseAttackMagic_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetReviseAttackMagic(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex,
            (ushort)_numericUpDown_ReviseAttackMagic.Value);
    }

    private void _numericUpDown_ReviseRevivalMagic_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetReviseRevivalMagic(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex,
            (ushort)_numericUpDown_ReviseRevivalMagic.Value);
    }

    private void _numericUpDown_ReviseSmart_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetReviseSmart(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex, (ushort)_numericUpDown_ReviseSmart.Value);
    }

    private void _numericUpDown_Transmigration_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].SetTransmigration(
            JobDataList.List[comboBox_StatusEditJob.SelectedIndex].DataIndex,
            (byte)_numericUpDown_Transmigration.Value);
    }

    private void comboBox_SkillSpecialty_SelectedIndexChanged(object sender, EventArgs e)
    {
        RenewalSkillSpecialtyList();
        if (_updateCount != 0)
            return;
        RenewalSkillSpecialtyListState();
    }

    private void checkedListBox_Specialty_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (_updateCount != 0)
            return;
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (!(checkedListBox_Specialty.Items[e.Index] is SkillSpecialtyEffectData specialtyEffectData))
            return;
        characterManager.CharacterData[_selectedIndex]
            .SetLearnSkillSpecialtyEffect(specialtyEffectData.Index, e.NewValue == CheckState.Checked);
    }

    private void checkedListBox_Skill_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (_updateCount != 0)
            return;
        var characterManager = SaveDataManager.Instance.SaveData.CharacterManager;
        if (!(checkedListBox_Skill.Items[e.Index] is SkillSpecialtyEffectData specialtyEffectData))
            return;
        characterManager.CharacterData[_selectedIndex]
            .SetLearnSkillSpecialtyEffect(specialtyEffectData.Index, e.NewValue == CheckState.Checked);
    }

    private void checkBox_Ruler_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex]
            .SetLearnRular(checkBox_Ruler.Checked);
    }

    private void checkBox_Cheer_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex]
            .SetLearnCheer(checkBox_Cheer.Checked);
    }

    private void checkBox_Die_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].Die = checkBox_Die.Checked;
    }

    private void checkBox_Poison_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].Poison =
            checkBox_Poison.Checked;
    }

    private void checkBox_Curse_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.CharacterManager.CharacterData[_selectedIndex].Curse = checkBox_Curse.Checked;
    }
}