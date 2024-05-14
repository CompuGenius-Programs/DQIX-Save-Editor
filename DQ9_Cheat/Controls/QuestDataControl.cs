// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.QuestDataControl
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

public class QuestDataControl : DataControlBase
{
    private const int ControlCount = 12;
    private readonly VisionNumericUpDown[] _questDayNumericUpDown = new VisionNumericUpDown[12];
    private readonly VisionNumericUpDown[] _questHourNumericUpDown = new VisionNumericUpDown[12];
    private readonly VisionNumericUpDown[] _questMinuteNumericUpDown = new VisionNumericUpDown[12];
    private readonly VisionNumericUpDown[] _questMonthNumericUpDown = new VisionNumericUpDown[12];
    private readonly VisionComboBox[] _questStateComboBox = new VisionComboBox[12];
    private readonly VisionNumericUpDown[] _questYearNumericUpDown = new VisionNumericUpDown[12];
    private VScrollBar _vScrollBar;
    private Button button_Execute;
    private Button button_ReviceClearCount;
    private Button button_ReviseOrderCount;
    private CheckBox checkBox_LumpEditAdditional;
    private CheckBox checkBox_LumpEditNormal;
    private IContainer components;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private SafeNumericUpDown numericUpDown_ClearCount;
    private QuestPanel panel;
    private RadioButton radioButton_BeforeOrder;
    private RadioButton radioButton_Cleared;
    private RadioButton radioButton_NotRecieved;
    private TextBox textBox_Dummy;
    private TextBox textBox_OrderCount;

    public QuestDataControl()
    {
        AutoScaleMode = AutoScaleMode.None;
        InitializeComponent();
        SuspendLayout();
        for (var index = 0; index < 12; ++index)
        {
            _questStateComboBox[index] = new VisionComboBox(205, 24 + index * 28, 85, 20);
            _questStateComboBox[index].Tag = index;
            _questStateComboBox[index].SelectedIndexChanged += QuestStateComboBox_SelectedIndexChanged;
            _questStateComboBox[index].Items.AddRange(new string[4]
            {
                "Unacquired",
                "Can Receive(?)",
                "In Progress",
                "Cleared"
            });
            _questYearNumericUpDown[index] = new VisionNumericUpDown(300, 24 + index * 28, 50, 19);
            _questYearNumericUpDown[index].Tag = new int[2]
            {
                index,
                0
            };
            _questYearNumericUpDown[index].Minimum = 2000M;
            _questYearNumericUpDown[index].Maximum = 2127M;
            _questYearNumericUpDown[index].ValueChanged += QuestDateTimeNumericUpDown_ValueChanged;
            _questMonthNumericUpDown[index] = new VisionNumericUpDown(360, 24 + index * 28, 40, 19);
            _questMonthNumericUpDown[index].Tag = new int[2]
            {
                index,
                1
            };
            _questMonthNumericUpDown[index].Minimum = 0M;
            _questMonthNumericUpDown[index].Maximum = 15M;
            _questMonthNumericUpDown[index].ValueChanged += QuestDateTimeNumericUpDown_ValueChanged;
            _questDayNumericUpDown[index] = new VisionNumericUpDown(410, 24 + index * 28, 40, 19);
            _questDayNumericUpDown[index].Tag = new int[2]
            {
                index,
                2
            };
            _questDayNumericUpDown[index].Minimum = 0M;
            _questDayNumericUpDown[index].Maximum = 31M;
            _questDayNumericUpDown[index].ValueChanged += QuestDateTimeNumericUpDown_ValueChanged;
            _questHourNumericUpDown[index] = new VisionNumericUpDown(460, 24 + index * 28, 40, 19);
            _questHourNumericUpDown[index].Tag = new int[2]
            {
                index,
                3
            };
            _questHourNumericUpDown[index].Minimum = 0M;
            _questHourNumericUpDown[index].Maximum = 31M;
            _questHourNumericUpDown[index].ValueChanged += QuestDateTimeNumericUpDown_ValueChanged;
            _questMinuteNumericUpDown[index] = new VisionNumericUpDown(510, 24 + index * 28, 40, 19);
            _questMinuteNumericUpDown[index].Tag = new int[2]
            {
                index,
                4
            };
            _questMinuteNumericUpDown[index].Minimum = 0M;
            _questMinuteNumericUpDown[index].Maximum = 63M;
            _questMinuteNumericUpDown[index].ValueChanged += QuestDateTimeNumericUpDown_ValueChanged;
            panel.AddVisionControl(_questStateComboBox[index]);
            panel.AddVisionControl(_questYearNumericUpDown[index]);
            panel.AddVisionControl(_questMonthNumericUpDown[index]);
            panel.AddVisionControl(_questDayNumericUpDown[index]);
            panel.AddVisionControl(_questHourNumericUpDown[index]);
            panel.AddVisionControl(_questMinuteNumericUpDown[index]);
        }

        RenewalScrollBar();
        panel.MouseWheel += panel_MouseWheel;
        ResumeLayout(false);
    }

    private void panel_MouseWheel(object sender, MouseEventArgs e)
    {
        if (e.Delta < 0)
        {
            if (_vScrollBar.Value >= _vScrollBar.Maximum - _vScrollBar.LargeChange + 1)
                return;
            textBox_Dummy.Focus();
            ++_vScrollBar.Value;
            OnValueUpdate();
        }
        else
        {
            if (_vScrollBar.Value <= _vScrollBar.Minimum)
                return;
            textBox_Dummy.Focus();
            --_vScrollBar.Value;
            OnValueUpdate();
        }
    }

    private void QuestDateTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
        // if (this._updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown) || !(visionNumericUpDown.Tag is int[] tag) && tag.Length != 2)
        //   return;
        if (_updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown) ||
            !(visionNumericUpDown.Tag is int[] tag))
            return;
        if (tag.Length != 2)
            return;
        var num = tag[1];
        var index = tag[0] + _vScrollBar.Value;
        switch (num)
        {
            case 0:
                SaveDataManager.Instance.SaveData.QuestDataManager.SetYear(index, (ushort)visionNumericUpDown.Value);
                break;
            case 1:
                SaveDataManager.Instance.SaveData.QuestDataManager.SetMonth(index, (byte)visionNumericUpDown.Value);
                break;
            case 2:
                SaveDataManager.Instance.SaveData.QuestDataManager.SetDay(index, (byte)visionNumericUpDown.Value);
                break;
            case 3:
                SaveDataManager.Instance.SaveData.QuestDataManager.SetHour(index, (byte)visionNumericUpDown.Value);
                break;
            case 4:
                SaveDataManager.Instance.SaveData.QuestDataManager.SetMinute(index, (byte)visionNumericUpDown.Value);
                break;
        }
    }

    private void QuestStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0 || !(sender is VisionComboBox visionComboBox))
            return;
        var index = (int)visionComboBox.Tag + _vScrollBar.Value;
        var questElement = QuestDataList.List[index];
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

        textBox_OrderCount.Text = SaveDataManager.Instance.SaveData.QuestDataManager.OrderCount.ToString();
    }

    private void panel_Paint()
    {
        panel.panel_Paint();
    }

    protected override void OnValueUpdate()
    {
        BeginUpdate();
        var questDataManager = SaveDataManager.Instance.SaveData.QuestDataManager;
        var index1 = 0;
        var index2 = _vScrollBar.Value;
        if (_vScrollBar.Value >= _vScrollBar.Maximum - _vScrollBar.LargeChange)
            index2 = _vScrollBar.Maximum - _vScrollBar.LargeChange - 1;
        for (var index3 = 0; index3 < 12; ++index3)
        {
            if (QuestDataList.List.Count > index2)
            {
                var questElement = QuestDataList.List[index2];
                if (questElement.AdditionalQuest)
                {
                    if (_questStateComboBox[index1].Items.Count == 4)
                        _questStateComboBox[index1].Items.Insert(0, "Unavailable");
                }
                else if (_questStateComboBox[index1].Items.Count == 5)
                {
                    _questStateComboBox[index1].Items.RemoveAt(0);
                }

                var state = questDataManager.GetState(index2);
                _questStateComboBox[index1].SelectedIndex =
                    !questElement.AdditionalQuest ? (int)(state - 1) : (int)state;
                _questYearNumericUpDown[index1].Value = questDataManager.GetYear(index2);
                _questMonthNumericUpDown[index1].Value = questDataManager.GetMonth(index2);
                _questDayNumericUpDown[index1].Value = questDataManager.GetDay(index2);
                _questHourNumericUpDown[index1].Value = questDataManager.GetHour(index2);
                _questMinuteNumericUpDown[index1].Value = questDataManager.GetMinute(index2);
                ++index2;
            }

            ++index1;
        }

        panel_Paint();
        textBox_OrderCount.Text = SaveDataManager.Instance.SaveData.QuestDataManager.OrderCount.ToString();
        numericUpDown_ClearCount.Value = SaveDataManager.Instance.SaveData.QuestDataManager.ClearCount.Value;
        EndUpdate();
    }

    private void QuestDataControl_Load(object sender, EventArgs e)
    {
    }

    private void RenewalScrollBar()
    {
        _vScrollBar.Value = 0;
        _vScrollBar.Maximum = QuestDataList.List.Count;
        _vScrollBar.LargeChange = 11;
        if (_vScrollBar.Maximum <= _vScrollBar.LargeChange)
            _vScrollBar.Visible = false;
        else
            _vScrollBar.Visible = true;
    }

    private void _vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        if (_vScrollBar.Value > _vScrollBar.Maximum - _vScrollBar.LargeChange - 1)
            _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange - 1;
        panel.QuestIndex = _vScrollBar.Value;
        textBox_Dummy.Focus();
        OnValueUpdate();
    }

    private void panel_Click(object sender, EventArgs e)
    {
        textBox_Dummy.Focus();
    }

    private void QuestDataControl_Click(object sender, EventArgs e)
    {
        textBox_Dummy.Focus();
    }

    private void textBox_Dummy_KeyDown(object sender, KeyEventArgs e)
    {
        if (_vScrollBar.Value != _vScrollBar.Minimum)
        {
            if (e.KeyCode == Keys.Home)
            {
                _vScrollBar.Value = _vScrollBar.Minimum;
                OnValueUpdate();
            }
            else if (e.KeyCode == Keys.Prior)
            {
                if (_vScrollBar.Value - (_vScrollBar.LargeChange - 1) < _vScrollBar.Minimum)
                    _vScrollBar.Value = _vScrollBar.Minimum;
                else
                    _vScrollBar.Value -= _vScrollBar.LargeChange - 1;
                OnValueUpdate();
            }
        }

        if (_vScrollBar.Value == _vScrollBar.Maximum - _vScrollBar.LargeChange + 2)
            return;
        if (e.KeyCode == Keys.End)
        {
            _vScrollBar.Value = _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1) + 1;
            OnValueUpdate();
        }
        else
        {
            if (e.KeyCode != Keys.Next)
                return;
            if (_vScrollBar.Value + (_vScrollBar.LargeChange - 1) > _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1))
                _vScrollBar.Value = _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1) + 1;
            else
                _vScrollBar.Value += _vScrollBar.LargeChange - 1;
            OnValueUpdate();
        }
    }

    private void button_ReviseOrderCount_Click(object sender, EventArgs e)
    {
        SaveDataManager.Instance.SaveData.QuestDataManager.ReviseOrderCount();
        OnValueUpdate();
    }

    private void button_ReviceClearCount_Click(object sender, EventArgs e)
    {
        SaveDataManager.Instance.SaveData.QuestDataManager.ReviseClearCount();
        OnValueUpdate();
    }

    private void numericUpDown_ClearCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.QuestDataManager.ClearCount.Value = (byte)numericUpDown_ClearCount.Value;
    }

    private void checkBox_LumpEditNormal_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox_LumpEditNormal.Checked)
        {
            radioButton_NotRecieved.Enabled = false;
            if (radioButton_NotRecieved.Checked)
            {
                radioButton_NotRecieved.Checked = false;
                button_Execute.Enabled = false;
            }
            else if (radioButton_Cleared.Checked || radioButton_BeforeOrder.Checked)
            {
                button_Execute.Enabled = true;
            }
            else
            {
                button_Execute.Enabled = false;
            }
        }
        else
        {
            radioButton_NotRecieved.Enabled = true;
            if (checkBox_LumpEditAdditional.Checked)
                return;
            button_Execute.Enabled = false;
        }
    }

    private void checkBox_LumpEditAdditional_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox_LumpEditAdditional.Checked)
        {
            radioButton_NotRecieved.Enabled = !checkBox_LumpEditNormal.Checked;
            if (radioButton_BeforeOrder.Checked || radioButton_Cleared.Checked || radioButton_NotRecieved.Checked)
                button_Execute.Enabled = true;
            else
                button_Execute.Enabled = false;
        }
        else
        {
            if (checkBox_LumpEditNormal.Checked)
                return;
            button_Execute.Enabled = false;
        }
    }

    private void radioButton_NotRecieved_CheckedChanged(object sender, EventArgs e)
    {
        if (radioButton_NotRecieved.Checked)
        {
            checkBox_LumpEditNormal.Enabled = false;
            checkBox_LumpEditNormal.Checked = false;
            button_Execute.Enabled = checkBox_LumpEditAdditional.Checked;
        }
        else
        {
            checkBox_LumpEditNormal.Enabled = true;
            if ((checkBox_LumpEditAdditional.Checked || checkBox_LumpEditNormal.Checked) &&
                (radioButton_BeforeOrder.Checked || radioButton_Cleared.Checked))
                button_Execute.Enabled = true;
            else
                button_Execute.Enabled = false;
        }
    }

    private void radioButton_LumpEdit_CheckedChanged(object sender, EventArgs e)
    {
        if (!(sender is RadioButton radioButton) || !radioButton.Checked)
            return;
        if (checkBox_LumpEditAdditional.Checked || checkBox_LumpEditNormal.Checked)
            button_Execute.Enabled = true;
        else
            button_Execute.Enabled = false;
    }

    private void button_Execute_Click(object sender, EventArgs e)
    {
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        if (radioButton_Cleared.Checked)
            for (var index = 0; index < QuestDataList.List.Count; ++index)
            {
                var questElement = QuestDataList.List[index];
                if (!questElement.AdditionalQuest && checkBox_LumpEditNormal.Checked)
                    SaveDataManager.Instance.SaveData.QuestDataManager.SetStateClear(index);
                else if (questElement.AdditionalQuest && checkBox_LumpEditAdditional.Checked)
                    SaveDataManager.Instance.SaveData.QuestDataManager.SetStateClear(index);
            }
        else if (radioButton_BeforeOrder.Checked)
            for (var index = 0; index < QuestDataList.List.Count; ++index)
            {
                var questElement = QuestDataList.List[index];
                if (!questElement.AdditionalQuest && checkBox_LumpEditNormal.Checked)
                    SaveDataManager.Instance.SaveData.QuestDataManager.SetStateNone(index);
                else if (questElement.AdditionalQuest && checkBox_LumpEditAdditional.Checked)
                    SaveDataManager.Instance.SaveData.QuestDataManager.SetStateRecieve(index);
            }
        else if (radioButton_NotRecieved.Checked)
            for (var index = 0; index < QuestDataList.List.Count; ++index)
                if (QuestDataList.List[index].AdditionalQuest && checkBox_LumpEditAdditional.Checked)
                    SaveDataManager.Instance.SaveData.QuestDataManager.SetStateNone(index);

        SaveDataManager.Instance.SaveData.QuestDataManager.ReviseClearCount();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        OnValueUpdate();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panel = new QuestPanel();
        textBox_Dummy = new TextBox();
        _vScrollBar = new VScrollBar();
        label1 = new Label();
        textBox_OrderCount = new TextBox();
        label2 = new Label();
        label3 = new Label();
        button_ReviseOrderCount = new Button();
        button_ReviceClearCount = new Button();
        label4 = new Label();
        numericUpDown_ClearCount = new SafeNumericUpDown();
        groupBox1 = new GroupBox();
        button_Execute = new Button();
        radioButton_Cleared = new RadioButton();
        radioButton_BeforeOrder = new RadioButton();
        radioButton_NotRecieved = new RadioButton();
        groupBox2 = new GroupBox();
        checkBox_LumpEditAdditional = new CheckBox();
        checkBox_LumpEditNormal = new CheckBox();
        panel.SuspendLayout();
        numericUpDown_ClearCount.BeginInit();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        SuspendLayout();
        panel.BorderStyle = BorderStyle.Fixed3D;
        panel.Controls.Add(textBox_Dummy);
        panel.Controls.Add(_vScrollBar);
        panel.Location = new Point(22, 60);
        panel.Name = "panel";
        panel.QuestIndex = 0;
        panel.Size = new Size(622, 376);
        panel.TabIndex = 0;
        panel.Click += panel_Click;
        textBox_Dummy.Location = new Point(-100, -100);
        textBox_Dummy.Name = "textBox_Dummy";
        textBox_Dummy.ReadOnly = true;
        textBox_Dummy.Size = new Size(100, 19);
        textBox_Dummy.TabIndex = 1;
        textBox_Dummy.KeyDown += textBox_Dummy_KeyDown;
        _vScrollBar.Dock = DockStyle.Right;
        _vScrollBar.Location = new Point(601, 0);
        _vScrollBar.Name = "_vScrollBar";
        _vScrollBar.Size = new Size(17, 372);
        _vScrollBar.TabIndex = 0;
        _vScrollBar.ValueChanged += _vScrollBar_ValueChanged;
        _vScrollBar.Scroll += _vScrollBar_Scroll;
        label1.AutoSize = true;
        label1.Location = new Point(36, 9);
        label1.Name = "label1";
        label1.Size = new Size(96, 13);
        label1.TabIndex = 2;
        label1.Text = "Quests In Progress";
        textBox_OrderCount.Location = new Point(134, 6);
        textBox_OrderCount.Name = "textBox_OrderCount";
        textBox_OrderCount.ReadOnly = true;
        textBox_OrderCount.Size = new Size(45, 20);
        textBox_OrderCount.TabIndex = 1;
        label2.AutoSize = true;
        label2.Location = new Point(36, 29);
        label2.Name = "label2";
        label2.Size = new Size(175, 12);
        label2.TabIndex = 4;
        label2.Text = "You can have eight active quests at a time.";
        label3.AutoSize = true;
        label3.Location = new Point(36, 43);
        label3.Name = "label3";
        label3.Size = new Size(328, 12);
        label3.TabIndex = 5;
        label3.Text = "If you set more than that, the description disappears.";
        button_ReviseOrderCount.Location = new Point(185, 5);
        button_ReviseOrderCount.Name = "button_ReviseOrderCount";
        button_ReviseOrderCount.Size = new Size(114, 22);
        button_ReviseOrderCount.TabIndex = 6;
        button_ReviseOrderCount.Text = "Recount";
        button_ReviseOrderCount.UseVisualStyleBackColor = true;
        button_ReviseOrderCount.Click += button_ReviseOrderCount_Click;
        button_ReviceClearCount.Location = new Point(496, 5);
        button_ReviceClearCount.Name = "button_ReviceClearCount";
        button_ReviceClearCount.Size = new Size(139, 22);
        button_ReviceClearCount.TabIndex = 9;
        button_ReviceClearCount.Text = "Recount";
        button_ReviceClearCount.UseVisualStyleBackColor = true;
        button_ReviceClearCount.Click += button_ReviceClearCount_Click;
        label4.AutoSize = true;
        label4.Location = new Point(358, 9);
        label4.Name = "label4";
        label4.Size = new Size(79, 13);
        label4.TabIndex = 8;
        label4.Text = "Quests Cleared";
        numericUpDown_ClearCount.Location = new Point(439, 6);
        numericUpDown_ClearCount.Maximum = new decimal([
            byte.MaxValue,
            0,
            0,
            0
        ]);
        numericUpDown_ClearCount.Name = "numericUpDown_ClearCount";
        numericUpDown_ClearCount.Size = new Size(51, 20);
        numericUpDown_ClearCount.TabIndex = 10;
        numericUpDown_ClearCount.Value = new decimal(new int[4]);
        numericUpDown_ClearCount.ValueChanged += numericUpDown_ClearCount_ValueChanged;
        groupBox1.Controls.Add(button_Execute);
        groupBox1.Controls.Add(radioButton_Cleared);
        groupBox1.Controls.Add(radioButton_BeforeOrder);
        groupBox1.Controls.Add(radioButton_NotRecieved);
        groupBox1.Controls.Add(groupBox2);
        groupBox1.Location = new Point(650, 53);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(176, 381);
        groupBox1.TabIndex = 11;
        groupBox1.TabStop = false;
        groupBox1.Text = "Bulk Edit";
        button_Execute.Enabled = false;
        button_Execute.Location = new Point(78, 155);
        button_Execute.Name = "button_Execute";
        button_Execute.Size = new Size(75, 23);
        button_Execute.TabIndex = 5;
        button_Execute.Text = "Go";
        button_Execute.UseVisualStyleBackColor = true;
        button_Execute.Click += button_Execute_Click;
        radioButton_Cleared.AutoSize = true;
        radioButton_Cleared.Location = new Point(23, 130);
        radioButton_Cleared.Name = "radioButton_Cleared";
        radioButton_Cleared.Size = new Size(98, 16);
        radioButton_Cleared.TabIndex = 4;
        radioButton_Cleared.TabStop = true;
        radioButton_Cleared.Text = "Cleared";
        radioButton_Cleared.UseVisualStyleBackColor = true;
        radioButton_Cleared.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
        radioButton_BeforeOrder.AutoSize = true;
        radioButton_BeforeOrder.Location = new Point(23, 108);
        radioButton_BeforeOrder.Name = "radioButton_BeforeOrder";
        radioButton_BeforeOrder.Size = new Size(87, 16);
        radioButton_BeforeOrder.TabIndex = 3;
        radioButton_BeforeOrder.TabStop = true;
        radioButton_BeforeOrder.Text = "Unacquired";
        radioButton_BeforeOrder.UseVisualStyleBackColor = true;
        radioButton_BeforeOrder.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
        radioButton_NotRecieved.AutoSize = true;
        radioButton_NotRecieved.Enabled = false;
        radioButton_NotRecieved.Location = new Point(23, 86);
        radioButton_NotRecieved.Name = "radioButton_NotRecieved";
        radioButton_NotRecieved.Size = new Size(87, 16);
        radioButton_NotRecieved.TabIndex = 2;
        radioButton_NotRecieved.TabStop = true;
        radioButton_NotRecieved.Text = "Unavailable";
        radioButton_NotRecieved.UseVisualStyleBackColor = true;
        radioButton_NotRecieved.CheckedChanged += radioButton_NotRecieved_CheckedChanged;
        groupBox2.Controls.Add(checkBox_LumpEditAdditional);
        groupBox2.Controls.Add(checkBox_LumpEditNormal);
        groupBox2.Location = new Point(23, 18);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(130, 62);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        groupBox2.Text = "To edit";
        checkBox_LumpEditAdditional.AutoSize = true;
        checkBox_LumpEditAdditional.Location = new Point(22, 36);
        checkBox_LumpEditAdditional.Name = "checkBox_LumpEditAdditional";
        checkBox_LumpEditAdditional.Size = new Size(82, 16);
        checkBox_LumpEditAdditional.TabIndex = 1;
        checkBox_LumpEditAdditional.Text = "DLC";
        checkBox_LumpEditAdditional.UseVisualStyleBackColor = true;
        checkBox_LumpEditAdditional.CheckedChanged += checkBox_LumpEditAdditional_CheckedChanged;
        checkBox_LumpEditNormal.AutoSize = true;
        checkBox_LumpEditNormal.Location = new Point(22, 19);
        checkBox_LumpEditNormal.Name = "checkBox_LumpEditNormal";
        checkBox_LumpEditNormal.Size = new Size(82, 16);
        checkBox_LumpEditNormal.TabIndex = 0;
        checkBox_LumpEditNormal.Text = "Normal";
        checkBox_LumpEditNormal.UseVisualStyleBackColor = true;
        checkBox_LumpEditNormal.CheckedChanged += checkBox_LumpEditNormal_CheckedChanged;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(groupBox1);
        Controls.Add(numericUpDown_ClearCount);
        Controls.Add(button_ReviceClearCount);
        Controls.Add(label4);
        Controls.Add(button_ReviseOrderCount);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(textBox_OrderCount);
        Controls.Add(label1);
        Controls.Add(panel);
        Name = nameof(QuestDataControl);
        Size = new Size(840, 452);
        Load += QuestDataControl_Load;
        Click += QuestDataControl_Click;
        panel.ResumeLayout(false);
        panel.PerformLayout();
        numericUpDown_ClearCount.EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}