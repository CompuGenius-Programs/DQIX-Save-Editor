// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.QuestDataControl
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
  public class QuestDataControl : DataControlBase
  {
    private const int ControlCount = 12;
    private VisionComboBox[] _questStateComboBox = new VisionComboBox[12];
    private VisionNumericUpDown[] _questYearNumericUpDown = new VisionNumericUpDown[12];
    private VisionNumericUpDown[] _questMonthNumericUpDown = new VisionNumericUpDown[12];
    private VisionNumericUpDown[] _questDayNumericUpDown = new VisionNumericUpDown[12];
    private VisionNumericUpDown[] _questHourNumericUpDown = new VisionNumericUpDown[12];
    private VisionNumericUpDown[] _questMinuteNumericUpDown = new VisionNumericUpDown[12];
    private IContainer components;
    private QuestPanel panel;
    private VScrollBar _vScrollBar;
    private TextBox textBox_Dummy;
    private Label label1;
    private TextBox textBox_OrderCount;
    private Label label2;
    private Label label3;
    private Button button_ReviseOrderCount;
    private Button button_ReviceClearCount;
    private Label label4;
    private SafeNumericUpDown numericUpDown_ClearCount;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private CheckBox checkBox_LumpEditAdditional;
    private CheckBox checkBox_LumpEditNormal;
    private RadioButton radioButton_Cleared;
    private RadioButton radioButton_BeforeOrder;
    private RadioButton radioButton_NotRecieved;
    private Button button_Execute;

    public QuestDataControl()
    {
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      this.SuspendLayout();
      for (int index = 0; index < 12; ++index)
      {
        this._questStateComboBox[index] = new VisionComboBox(205, 24 + index * 28, 85, 20);
        this._questStateComboBox[index].Tag = (object) index;
        this._questStateComboBox[index].SelectedIndexChanged += new EventHandler(this.QuestStateComboBox_SelectedIndexChanged);
        this._questStateComboBox[index].Items.AddRange((object[]) new string[4]
        {
          "Unacquired",
          "Can Receive(?)",
          "In Progress",
          "Cleared"
        });
        this._questYearNumericUpDown[index] = new VisionNumericUpDown(300, 24 + index * 28, 50, 19);
        this._questYearNumericUpDown[index].Tag = (object) new int[2]
        {
          index,
          0
        };
        this._questYearNumericUpDown[index].Minimum = 2000M;
        this._questYearNumericUpDown[index].Maximum = 2127M;
        this._questYearNumericUpDown[index].ValueChanged += new EventHandler(this.QuestDateTimeNumericUpDown_ValueChanged);
        this._questMonthNumericUpDown[index] = new VisionNumericUpDown(360, 24 + index * 28, 40, 19);
        this._questMonthNumericUpDown[index].Tag = (object) new int[2]
        {
          index,
          1
        };
        this._questMonthNumericUpDown[index].Minimum = 0M;
        this._questMonthNumericUpDown[index].Maximum = 15M;
        this._questMonthNumericUpDown[index].ValueChanged += new EventHandler(this.QuestDateTimeNumericUpDown_ValueChanged);
        this._questDayNumericUpDown[index] = new VisionNumericUpDown(410, 24 + index * 28, 40, 19);
        this._questDayNumericUpDown[index].Tag = (object) new int[2]
        {
          index,
          2
        };
        this._questDayNumericUpDown[index].Minimum = 0M;
        this._questDayNumericUpDown[index].Maximum = 31M;
        this._questDayNumericUpDown[index].ValueChanged += new EventHandler(this.QuestDateTimeNumericUpDown_ValueChanged);
        this._questHourNumericUpDown[index] = new VisionNumericUpDown(460, 24 + index * 28, 40, 19);
        this._questHourNumericUpDown[index].Tag = (object) new int[2]
        {
          index,
          3
        };
        this._questHourNumericUpDown[index].Minimum = 0M;
        this._questHourNumericUpDown[index].Maximum = 31M;
        this._questHourNumericUpDown[index].ValueChanged += new EventHandler(this.QuestDateTimeNumericUpDown_ValueChanged);
        this._questMinuteNumericUpDown[index] = new VisionNumericUpDown(510, 24 + index * 28, 40, 19);
        this._questMinuteNumericUpDown[index].Tag = (object) new int[2]
        {
          index,
          4
        };
        this._questMinuteNumericUpDown[index].Minimum = 0M;
        this._questMinuteNumericUpDown[index].Maximum = 63M;
        this._questMinuteNumericUpDown[index].ValueChanged += new EventHandler(this.QuestDateTimeNumericUpDown_ValueChanged);
        this.panel.AddVisionControl((VisionControlBase) this._questStateComboBox[index]);
        this.panel.AddVisionControl((VisionControlBase) this._questYearNumericUpDown[index]);
        this.panel.AddVisionControl((VisionControlBase) this._questMonthNumericUpDown[index]);
        this.panel.AddVisionControl((VisionControlBase) this._questDayNumericUpDown[index]);
        this.panel.AddVisionControl((VisionControlBase) this._questHourNumericUpDown[index]);
        this.panel.AddVisionControl((VisionControlBase) this._questMinuteNumericUpDown[index]);
      }
      this.RenewalScrollBar();
      this.panel.MouseWheel += new MouseEventHandler(this.panel_MouseWheel);
      this.ResumeLayout(false);
    }

    private void panel_MouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta < 0)
      {
        if (this._vScrollBar.Value >= this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1)
          return;
        this.textBox_Dummy.Focus();
        ++this._vScrollBar.Value;
        this.OnValueUpdate();
      }
      else
      {
        if (this._vScrollBar.Value <= this._vScrollBar.Minimum)
          return;
        this.textBox_Dummy.Focus();
        --this._vScrollBar.Value;
        this.OnValueUpdate();
      }
    }

    private void QuestDateTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      // if (this._updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown) || !(visionNumericUpDown.Tag is int[] tag) && tag.Length != 2)
      //   return;
      if (this._updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown) || !(visionNumericUpDown.Tag is int[] tag))
        return;
      if (tag.Length != 2)
        return;
      int num = tag[1];
      int index = tag[0] + this._vScrollBar.Value;
      switch (num)
      {
        case 0:
          SaveDataManager.Instance.SaveData.QuestDataManager.SetYear(index, (ushort) visionNumericUpDown.Value);
          break;
        case 1:
          SaveDataManager.Instance.SaveData.QuestDataManager.SetMonth(index, (byte) visionNumericUpDown.Value);
          break;
        case 2:
          SaveDataManager.Instance.SaveData.QuestDataManager.SetDay(index, (byte) visionNumericUpDown.Value);
          break;
        case 3:
          SaveDataManager.Instance.SaveData.QuestDataManager.SetHour(index, (byte) visionNumericUpDown.Value);
          break;
        case 4:
          SaveDataManager.Instance.SaveData.QuestDataManager.SetMinute(index, (byte) visionNumericUpDown.Value);
          break;
      }
    }

    private void QuestStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is VisionComboBox visionComboBox))
        return;
      int index = (int) visionComboBox.Tag + this._vScrollBar.Value;
      QuestElement questElement = QuestDataList.List[index];
      switch (!questElement.AdditionalQuest ? visionComboBox.SelectedIndex + 1 : visionComboBox.SelectedIndex)
      {
        case 0:
          SaveDataManager.Instance.SaveData.QuestDataManager.SetStateNone(index);
          break;
        case 1:
          if (questElement.AdditionalQuest)
          {
            SaveDataManager.Instance.SaveData.QuestDataManager.SetStateRecieve(index);
            break;
          }
          SaveDataManager.Instance.SaveData.QuestDataManager.SetStateNone(index);
          break;
        case 2:
          SaveDataManager.Instance.SaveData.QuestDataManager.SetStateAllowOrder(index);
          break;
        case 3:
          SaveDataManager.Instance.SaveData.QuestDataManager.SetStateOrder(index);
          break;
        case 4:
          SaveDataManager.Instance.SaveData.QuestDataManager.SetStateClear(index);
          break;
      }
      this.textBox_OrderCount.Text = SaveDataManager.Instance.SaveData.QuestDataManager.OrderCount.ToString();
    }

    private void panel_Paint() => this.panel.panel_Paint();

    protected override void OnValueUpdate()
    {
      this.BeginUpdate();
      QuestDataManager questDataManager = SaveDataManager.Instance.SaveData.QuestDataManager;
      int index1 = 0;
      int index2 = this._vScrollBar.Value;
      if (this._vScrollBar.Value >= this._vScrollBar.Maximum - this._vScrollBar.LargeChange)
        index2 = this._vScrollBar.Maximum - this._vScrollBar.LargeChange - 1;
      for (int index3 = 0; index3 < 12; ++index3)
      {
        if (QuestDataList.List.Count > index2)
        {
          QuestElement questElement = QuestDataList.List[index2];
          if (questElement.AdditionalQuest)
          {
            if (this._questStateComboBox[index1].Items.Count == 4)
              this._questStateComboBox[index1].Items.Insert(0, (object) "Unavailable");
          }
          else if (this._questStateComboBox[index1].Items.Count == 5)
            this._questStateComboBox[index1].Items.RemoveAt(0);
          QuestState state = questDataManager.GetState(index2);
          this._questStateComboBox[index1].SelectedIndex = !questElement.AdditionalQuest ? (int) (state - 1) : (int) state;
          this._questYearNumericUpDown[index1].Value = (Decimal) questDataManager.GetYear(index2);
          this._questMonthNumericUpDown[index1].Value = (Decimal) questDataManager.GetMonth(index2);
          this._questDayNumericUpDown[index1].Value = (Decimal) questDataManager.GetDay(index2);
          this._questHourNumericUpDown[index1].Value = (Decimal) questDataManager.GetHour(index2);
          this._questMinuteNumericUpDown[index1].Value = (Decimal) questDataManager.GetMinute(index2);
          ++index2;
        }
        ++index1;
      }
      this.panel_Paint();
      this.textBox_OrderCount.Text = SaveDataManager.Instance.SaveData.QuestDataManager.OrderCount.ToString();
      this.numericUpDown_ClearCount.Value = (Decimal) SaveDataManager.Instance.SaveData.QuestDataManager.ClearCount.Value;
      this.EndUpdate();
    }

    private void QuestDataControl_Load(object sender, EventArgs e)
    {
    }

    private void RenewalScrollBar()
    {
      this._vScrollBar.Value = 0;
      this._vScrollBar.Maximum = QuestDataList.List.Count;
      this._vScrollBar.LargeChange = 11;
      if (this._vScrollBar.Maximum <= this._vScrollBar.LargeChange)
        this._vScrollBar.Visible = false;
      else
        this._vScrollBar.Visible = true;
    }

    private void _vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      if (this._vScrollBar.Value > this._vScrollBar.Maximum - this._vScrollBar.LargeChange - 1)
        this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange - 1;
      this.panel.QuestIndex = this._vScrollBar.Value;
      this.textBox_Dummy.Focus();
      this.OnValueUpdate();
    }

    private void panel_Click(object sender, EventArgs e) => this.textBox_Dummy.Focus();

    private void QuestDataControl_Click(object sender, EventArgs e) => this.textBox_Dummy.Focus();

    private void textBox_Dummy_KeyDown(object sender, KeyEventArgs e)
    {
      if (this._vScrollBar.Value != this._vScrollBar.Minimum)
      {
        if (e.KeyCode == Keys.Home)
        {
          this._vScrollBar.Value = this._vScrollBar.Minimum;
          this.OnValueUpdate();
        }
        else if (e.KeyCode == Keys.Prior)
        {
          if (this._vScrollBar.Value - (this._vScrollBar.LargeChange - 1) < this._vScrollBar.Minimum)
            this._vScrollBar.Value = this._vScrollBar.Minimum;
          else
            this._vScrollBar.Value -= this._vScrollBar.LargeChange - 1;
          this.OnValueUpdate();
        }
      }
      if (this._vScrollBar.Value == this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 2)
        return;
      if (e.KeyCode == Keys.End)
      {
        this._vScrollBar.Value = this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1) + 1;
        this.OnValueUpdate();
      }
      else
      {
        if (e.KeyCode != Keys.Next)
          return;
        if (this._vScrollBar.Value + (this._vScrollBar.LargeChange - 1) > this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1))
          this._vScrollBar.Value = this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1) + 1;
        else
          this._vScrollBar.Value += this._vScrollBar.LargeChange - 1;
        this.OnValueUpdate();
      }
    }

    private void button_ReviseOrderCount_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.SaveData.QuestDataManager.ReviseOrderCount();
      this.OnValueUpdate();
    }

    private void button_ReviceClearCount_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.SaveData.QuestDataManager.ReviseClearCount();
      this.OnValueUpdate();
    }

    private void numericUpDown_ClearCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.QuestDataManager.ClearCount.Value = (byte) this.numericUpDown_ClearCount.Value;
    }

    private void checkBox_LumpEditNormal_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox_LumpEditNormal.Checked)
      {
        this.radioButton_NotRecieved.Enabled = false;
        if (this.radioButton_NotRecieved.Checked)
        {
          this.radioButton_NotRecieved.Checked = false;
          this.button_Execute.Enabled = false;
        }
        else if (this.radioButton_Cleared.Checked || this.radioButton_BeforeOrder.Checked)
          this.button_Execute.Enabled = true;
        else
          this.button_Execute.Enabled = false;
      }
      else
      {
        this.radioButton_NotRecieved.Enabled = true;
        if (this.checkBox_LumpEditAdditional.Checked)
          return;
        this.button_Execute.Enabled = false;
      }
    }

    private void checkBox_LumpEditAdditional_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox_LumpEditAdditional.Checked)
      {
        this.radioButton_NotRecieved.Enabled = !this.checkBox_LumpEditNormal.Checked;
        if (this.radioButton_BeforeOrder.Checked || this.radioButton_Cleared.Checked || this.radioButton_NotRecieved.Checked)
          this.button_Execute.Enabled = true;
        else
          this.button_Execute.Enabled = false;
      }
      else
      {
        if (this.checkBox_LumpEditNormal.Checked)
          return;
        this.button_Execute.Enabled = false;
      }
    }

    private void radioButton_NotRecieved_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButton_NotRecieved.Checked)
      {
        this.checkBox_LumpEditNormal.Enabled = false;
        this.checkBox_LumpEditNormal.Checked = false;
        this.button_Execute.Enabled = this.checkBox_LumpEditAdditional.Checked;
      }
      else
      {
        this.checkBox_LumpEditNormal.Enabled = true;
        if ((this.checkBox_LumpEditAdditional.Checked || this.checkBox_LumpEditNormal.Checked) && (this.radioButton_BeforeOrder.Checked || this.radioButton_Cleared.Checked))
          this.button_Execute.Enabled = true;
        else
          this.button_Execute.Enabled = false;
      }
    }

    private void radioButton_LumpEdit_CheckedChanged(object sender, EventArgs e)
    {
      if (!(sender is RadioButton radioButton) || !radioButton.Checked)
        return;
      if (this.checkBox_LumpEditAdditional.Checked || this.checkBox_LumpEditNormal.Checked)
        this.button_Execute.Enabled = true;
      else
        this.button_Execute.Enabled = false;
    }

    private void button_Execute_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      if (this.radioButton_Cleared.Checked)
      {
        for (int index = 0; index < QuestDataList.List.Count; ++index)
        {
          QuestElement questElement = QuestDataList.List[index];
          if (!questElement.AdditionalQuest && this.checkBox_LumpEditNormal.Checked)
            SaveDataManager.Instance.SaveData.QuestDataManager.SetStateClear(index);
          else if (questElement.AdditionalQuest && this.checkBox_LumpEditAdditional.Checked)
            SaveDataManager.Instance.SaveData.QuestDataManager.SetStateClear(index);
        }
      }
      else if (this.radioButton_BeforeOrder.Checked)
      {
        for (int index = 0; index < QuestDataList.List.Count; ++index)
        {
          QuestElement questElement = QuestDataList.List[index];
          if (!questElement.AdditionalQuest && this.checkBox_LumpEditNormal.Checked)
            SaveDataManager.Instance.SaveData.QuestDataManager.SetStateNone(index);
          else if (questElement.AdditionalQuest && this.checkBox_LumpEditAdditional.Checked)
            SaveDataManager.Instance.SaveData.QuestDataManager.SetStateRecieve(index);
        }
      }
      else if (this.radioButton_NotRecieved.Checked)
      {
        for (int index = 0; index < QuestDataList.List.Count; ++index)
        {
          if (QuestDataList.List[index].AdditionalQuest && this.checkBox_LumpEditAdditional.Checked)
            SaveDataManager.Instance.SaveData.QuestDataManager.SetStateNone(index);
        }
      }
      SaveDataManager.Instance.SaveData.QuestDataManager.ReviseClearCount();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.OnValueUpdate();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panel = new QuestPanel();
      this.textBox_Dummy = new TextBox();
      this._vScrollBar = new VScrollBar();
      this.label1 = new Label();
      this.textBox_OrderCount = new TextBox();
      this.label2 = new Label();
      this.label3 = new Label();
      this.button_ReviseOrderCount = new Button();
      this.button_ReviceClearCount = new Button();
      this.label4 = new Label();
      this.numericUpDown_ClearCount = new SafeNumericUpDown();
      this.groupBox1 = new GroupBox();
      this.button_Execute = new Button();
      this.radioButton_Cleared = new RadioButton();
      this.radioButton_BeforeOrder = new RadioButton();
      this.radioButton_NotRecieved = new RadioButton();
      this.groupBox2 = new GroupBox();
      this.checkBox_LumpEditAdditional = new CheckBox();
      this.checkBox_LumpEditNormal = new CheckBox();
      this.panel.SuspendLayout();
      this.numericUpDown_ClearCount.BeginInit();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.panel.BorderStyle = BorderStyle.Fixed3D;
      this.panel.Controls.Add((Control) this.textBox_Dummy);
      this.panel.Controls.Add((Control) this._vScrollBar);
      this.panel.Location = new Point(22, 60);
      this.panel.Name = "panel";
      this.panel.QuestIndex = 0;
      this.panel.Size = new Size(622, 376);
      this.panel.TabIndex = 0;
      this.panel.Click += new EventHandler(this.panel_Click);
      this.textBox_Dummy.Location = new Point(-100, -100);
      this.textBox_Dummy.Name = "textBox_Dummy";
      this.textBox_Dummy.ReadOnly = true;
      this.textBox_Dummy.Size = new Size(100, 19);
      this.textBox_Dummy.TabIndex = 1;
      this.textBox_Dummy.KeyDown += new KeyEventHandler(this.textBox_Dummy_KeyDown);
      this._vScrollBar.Dock = DockStyle.Right;
      this._vScrollBar.Location = new Point(601, 0);
      this._vScrollBar.Name = "_vScrollBar";
      this._vScrollBar.Size = new Size(17, 372);
      this._vScrollBar.TabIndex = 0;
      this._vScrollBar.ValueChanged += new EventHandler(this._vScrollBar_ValueChanged);
      this._vScrollBar.Scroll += new ScrollEventHandler(this._vScrollBar_Scroll);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(36, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(96, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Quests In Progress";
      this.textBox_OrderCount.Location = new Point(134, 6);
      this.textBox_OrderCount.Name = "textBox_OrderCount";
      this.textBox_OrderCount.ReadOnly = true;
      this.textBox_OrderCount.Size = new Size(45, 20);
      this.textBox_OrderCount.TabIndex = 1;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(36, 29);
      this.label2.Name = "label2";
      this.label2.Size = new Size(175, 12);
      this.label2.TabIndex = 4;
      this.label2.Text = "You can have eight active quests at a time.";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(36, 43);
      this.label3.Name = "label3";
      this.label3.Size = new Size(328, 12);
      this.label3.TabIndex = 5;
      this.label3.Text = "If you set more than that, the description disappears.";
      this.button_ReviseOrderCount.Location = new Point(185, 5);
      this.button_ReviseOrderCount.Name = "button_ReviseOrderCount";
      this.button_ReviseOrderCount.Size = new Size(114, 22);
      this.button_ReviseOrderCount.TabIndex = 6;
      this.button_ReviseOrderCount.Text = "Recount";
      this.button_ReviseOrderCount.UseVisualStyleBackColor = true;
      this.button_ReviseOrderCount.Click += new EventHandler(this.button_ReviseOrderCount_Click);
      this.button_ReviceClearCount.Location = new Point(496, 5);
      this.button_ReviceClearCount.Name = "button_ReviceClearCount";
      this.button_ReviceClearCount.Size = new Size(139, 22);
      this.button_ReviceClearCount.TabIndex = 9;
      this.button_ReviceClearCount.Text = "Recount";
      this.button_ReviceClearCount.UseVisualStyleBackColor = true;
      this.button_ReviceClearCount.Click += new EventHandler(this.button_ReviceClearCount_Click);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(358, 9);
      this.label4.Name = "label4";
      this.label4.Size = new Size(79, 13);
      this.label4.TabIndex = 8;
      this.label4.Text = "Quests Cleared";
      this.numericUpDown_ClearCount.Location = new Point(439, 6);
      this.numericUpDown_ClearCount.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_ClearCount.Name = "numericUpDown_ClearCount";
      this.numericUpDown_ClearCount.Size = new Size(51, 20);
      this.numericUpDown_ClearCount.TabIndex = 10;
      this.numericUpDown_ClearCount.Value = new Decimal(new int[4]);
      this.numericUpDown_ClearCount.ValueChanged += new EventHandler(this.numericUpDown_ClearCount_ValueChanged);
      this.groupBox1.Controls.Add((Control) this.button_Execute);
      this.groupBox1.Controls.Add((Control) this.radioButton_Cleared);
      this.groupBox1.Controls.Add((Control) this.radioButton_BeforeOrder);
      this.groupBox1.Controls.Add((Control) this.radioButton_NotRecieved);
      this.groupBox1.Controls.Add((Control) this.groupBox2);
      this.groupBox1.Location = new Point(650, 53);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(176, 381);
      this.groupBox1.TabIndex = 11;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Bulk Edit";
      this.button_Execute.Enabled = false;
      this.button_Execute.Location = new Point(78, 155);
      this.button_Execute.Name = "button_Execute";
      this.button_Execute.Size = new Size(75, 23);
      this.button_Execute.TabIndex = 5;
      this.button_Execute.Text = "Go";
      this.button_Execute.UseVisualStyleBackColor = true;
      this.button_Execute.Click += new EventHandler(this.button_Execute_Click);
      this.radioButton_Cleared.AutoSize = true;
      this.radioButton_Cleared.Location = new Point(23, 130);
      this.radioButton_Cleared.Name = "radioButton_Cleared";
      this.radioButton_Cleared.Size = new Size(98, 16);
      this.radioButton_Cleared.TabIndex = 4;
      this.radioButton_Cleared.TabStop = true;
      this.radioButton_Cleared.Text = "Cleared";
      this.radioButton_Cleared.UseVisualStyleBackColor = true;
      this.radioButton_Cleared.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.radioButton_BeforeOrder.AutoSize = true;
      this.radioButton_BeforeOrder.Location = new Point(23, 108);
      this.radioButton_BeforeOrder.Name = "radioButton_BeforeOrder";
      this.radioButton_BeforeOrder.Size = new Size(87, 16);
      this.radioButton_BeforeOrder.TabIndex = 3;
      this.radioButton_BeforeOrder.TabStop = true;
      this.radioButton_BeforeOrder.Text = "Unacquired";
      this.radioButton_BeforeOrder.UseVisualStyleBackColor = true;
      this.radioButton_BeforeOrder.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.radioButton_NotRecieved.AutoSize = true;
      this.radioButton_NotRecieved.Enabled = false;
      this.radioButton_NotRecieved.Location = new Point(23, 86);
      this.radioButton_NotRecieved.Name = "radioButton_NotRecieved";
      this.radioButton_NotRecieved.Size = new Size(87, 16);
      this.radioButton_NotRecieved.TabIndex = 2;
      this.radioButton_NotRecieved.TabStop = true;
      this.radioButton_NotRecieved.Text = "Unavailable";
      this.radioButton_NotRecieved.UseVisualStyleBackColor = true;
      this.radioButton_NotRecieved.CheckedChanged += new EventHandler(this.radioButton_NotRecieved_CheckedChanged);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditAdditional);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditNormal);
      this.groupBox2.Location = new Point(23, 18);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(130, 62);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "To edit";
      this.checkBox_LumpEditAdditional.AutoSize = true;
      this.checkBox_LumpEditAdditional.Location = new Point(22, 36);
      this.checkBox_LumpEditAdditional.Name = "checkBox_LumpEditAdditional";
      this.checkBox_LumpEditAdditional.Size = new Size(82, 16);
      this.checkBox_LumpEditAdditional.TabIndex = 1;
      this.checkBox_LumpEditAdditional.Text = "DLC";
      this.checkBox_LumpEditAdditional.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditAdditional.CheckedChanged += new EventHandler(this.checkBox_LumpEditAdditional_CheckedChanged);
      this.checkBox_LumpEditNormal.AutoSize = true;
      this.checkBox_LumpEditNormal.Location = new Point(22, 19);
      this.checkBox_LumpEditNormal.Name = "checkBox_LumpEditNormal";
      this.checkBox_LumpEditNormal.Size = new Size(82, 16);
      this.checkBox_LumpEditNormal.TabIndex = 0;
      this.checkBox_LumpEditNormal.Text = "Normal";
      this.checkBox_LumpEditNormal.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditNormal.CheckedChanged += new EventHandler(this.checkBox_LumpEditNormal_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.numericUpDown_ClearCount);
      this.Controls.Add((Control) this.button_ReviceClearCount);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.button_ReviseOrderCount);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.textBox_OrderCount);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.panel);
      this.Name = nameof (QuestDataControl);
      this.Size = new Size(840, 452);
      this.Load += new EventHandler(this.QuestDataControl_Load);
      this.Click += new EventHandler(this.QuestDataControl_Click);
      this.panel.ResumeLayout(false);
      this.panel.PerformLayout();
      this.numericUpDown_ClearCount.EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
