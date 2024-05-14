// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MonsterDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace DQ9_Cheat.Controls
{
  public class MonsterDataControl : DataControlBase
  {
    private const int ControlMarginWidth = 190;
    private const int ControlMarginHeight = 10;
    private const int Horizontal = 2;
    private const int Vertical = 10;
    private const int CheckBox_Width = 120;
    private const int CheckBox_Height = 20;
    private IContainer components;
    private JS_Panel panel;
    private VScrollBar _vScrollBar;
    private TextBox textBox_Dummy;
    private GroupBox groupBox1;
    private Label label_Lump;
    private NumericUpDown numericUpDown_LumpEditCount;
    private RadioButton radioButton_ItemCount2;
    private RadioButton radioButton_VictoryCount;
    private RadioButton radioButton_ItemCount1;
    private Button button_Execute;
    private Label label1;
    private Label label2;
    private Label label_CompRate;
    private Label label_VictoryCount;
    private RadioButton radioButton_UnCheckFindOUt;
    private RadioButton radioButton_CheckFindOUt;
    private Bitmap _panelBitmap;
    private Bitmap[] _checkBoxBitmap = new Bitmap[2];
    private int _lastMouseOverIndex;
    private VisionNumericUpDown[] _numericUpDown_VictoryCount = new VisionNumericUpDown[20];
    private VisionNumericUpDown[] _numericUpDown_Item1Count = new VisionNumericUpDown[20];
    private VisionNumericUpDown[] _numericUpDown_Item2Count = new VisionNumericUpDown[20];
    private bool[] _checkBox_Checked = new bool[20];

    public MonsterDataControl()
    {
      AutoScaleMode = AutoScaleMode.None;
      InitializeComponent();
      Initialize();
      panel.MouseWheel += panel_MouseWheel;
      panel.MouseMove += panel_MouseMove;
      panel.MouseDown += panel_MouseDown;
      panel.Paint += panel_Paint;
      _panelBitmap = new Bitmap(panel.Width, panel.Height);
      Disposed += MonsterDataControl_Disposed;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      panel = new JS_Panel();
      textBox_Dummy = new TextBox();
      _vScrollBar = new VScrollBar();
      groupBox1 = new GroupBox();
      radioButton_ItemCount1 = new RadioButton();
      radioButton_ItemCount2 = new RadioButton();
      label_Lump = new Label();
      radioButton_VictoryCount = new RadioButton();
      numericUpDown_LumpEditCount = new NumericUpDown();
      button_Execute = new Button();
      label1 = new Label();
      label2 = new Label();
      label_CompRate = new Label();
      label_VictoryCount = new Label();
      radioButton_CheckFindOUt = new RadioButton();
      radioButton_UnCheckFindOUt = new RadioButton();
      panel.SuspendLayout();
      groupBox1.SuspendLayout();
      numericUpDown_LumpEditCount.BeginInit();
      SuspendLayout();
      panel.BorderStyle = BorderStyle.Fixed3D;
      panel.Controls.Add(textBox_Dummy);
      panel.Controls.Add(_vScrollBar);
      panel.Location = new Point(8, 56);
      panel.Name = "panel";
      panel.Size = new Size(642, 359);
      panel.TabIndex = 1;
      panel.Click += panel_Click;
      textBox_Dummy.Location = new Point(-100, -100);
      textBox_Dummy.Name = "textBox_Dummy";
      textBox_Dummy.ReadOnly = true;
      textBox_Dummy.Size = new Size(100, 19);
      textBox_Dummy.TabIndex = 1;
      textBox_Dummy.KeyDown += textBox_Dummy_KeyDown;
      _vScrollBar.Dock = DockStyle.Right;
      _vScrollBar.Location = new Point(621, 0);
      _vScrollBar.Name = "_vScrollBar";
      _vScrollBar.Size = new Size(17, 355);
      _vScrollBar.TabIndex = 0;
      _vScrollBar.ValueChanged += _vScrollBar_ValueChanged;
      _vScrollBar.Scroll += vScrollBar_Scroll;
      groupBox1.Controls.Add(radioButton_UnCheckFindOUt);
      groupBox1.Controls.Add(radioButton_CheckFindOUt);
      groupBox1.Controls.Add(radioButton_ItemCount1);
      groupBox1.Controls.Add(radioButton_ItemCount2);
      groupBox1.Controls.Add(label_Lump);
      groupBox1.Controls.Add(radioButton_VictoryCount);
      groupBox1.Controls.Add(numericUpDown_LumpEditCount);
      groupBox1.Controls.Add(button_Execute);
      groupBox1.Location = new Point(656, 49);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new Size(173, 366);
      groupBox1.TabIndex = 2;
      groupBox1.TabStop = false;
      groupBox1.Text = "Bulk Edit";
      radioButton_ItemCount1.AutoSize = true;
      radioButton_ItemCount1.Location = new Point(14, 42);
      radioButton_ItemCount1.Name = "radioButton_ItemCount1";
      radioButton_ItemCount1.Size = new Size(153, 16);
      radioButton_ItemCount1.TabIndex = 8;
      radioButton_ItemCount1.TabStop = true;
      radioButton_ItemCount1.Text = "Common Item Drops";
      radioButton_ItemCount1.UseVisualStyleBackColor = true;
      radioButton_ItemCount1.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      radioButton_ItemCount2.AutoSize = true;
      radioButton_ItemCount2.Location = new Point(14, 63);
      radioButton_ItemCount2.Name = "radioButton_ItemCount2";
      radioButton_ItemCount2.Size = new Size(147, 16);
      radioButton_ItemCount2.TabIndex = 1;
      radioButton_ItemCount2.TabStop = true;
      radioButton_ItemCount2.Text = "Rare Item Drops";
      radioButton_ItemCount2.UseVisualStyleBackColor = true;
      radioButton_ItemCount2.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      label_Lump.AutoSize = true;
      label_Lump.Location = new Point(21, 139);
      label_Lump.Name = "label_Lump";
      label_Lump.Size = new Size(29, 12);
      label_Lump.TabIndex = 7;
      label_Lump.Text = "Qty";
      label_Lump.TextAlign = ContentAlignment.MiddleRight;
      radioButton_VictoryCount.AutoSize = true;
      radioButton_VictoryCount.Checked = true;
      radioButton_VictoryCount.Location = new Point(14, 21);
      radioButton_VictoryCount.Name = "radioButton_VictoryCount";
      radioButton_VictoryCount.Size = new Size(110, 16);
      radioButton_VictoryCount.TabIndex = 0;
      radioButton_VictoryCount.TabStop = true;
      radioButton_VictoryCount.Text = "Kills";
      radioButton_VictoryCount.UseVisualStyleBackColor = true;
      radioButton_VictoryCount.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      numericUpDown_LumpEditCount.Location = new Point(52, 136);
      numericUpDown_LumpEditCount.Maximum = new Decimal(new int[4]
      {
        999,
        0,
        0,
        0
      });
      numericUpDown_LumpEditCount.Name = "numericUpDown_LumpEditCount";
      numericUpDown_LumpEditCount.Size = new Size(41, 19);
      numericUpDown_LumpEditCount.TabIndex = 6;
      button_Execute.Location = new Point(99, 134);
      button_Execute.Name = "button_Execute";
      button_Execute.Size = new Size(49, 23);
      button_Execute.TabIndex = 4;
      button_Execute.Text = "Go";
      button_Execute.UseVisualStyleBackColor = true;
      button_Execute.Click += button_Execute_Click;
      label1.AutoSize = true;
      label1.Location = new Point(62, 11);
      label1.Name = "label1";
      label1.Size = new Size(136, 12);
      label1.TabIndex = 3;
      label1.Text = "Completion Rate";
      label2.AutoSize = true;
      label2.Location = new Point(23, 31);
      label2.Name = "label2";
      label2.Size = new Size(126, 12);
      label2.TabIndex = 4;
      label2.Text = "Monster Types Defeated";
      label_CompRate.AutoSize = true;
      label_CompRate.Location = new Point(155, 11);
      label_CompRate.Name = "label_CompRate";
      label_CompRate.Size = new Size(17, 12);
      label_CompRate.TabIndex = 5;
      label_CompRate.Text = "0%";
      label_VictoryCount.AutoSize = true;
      label_VictoryCount.Location = new Point(155, 31);
      label_VictoryCount.Name = "label_VictoryCount";
      label_VictoryCount.Size = new Size(35, 12);
      label_VictoryCount.TabIndex = 6;
      label_VictoryCount.Text = "0 Types";
      radioButton_CheckFindOUt.AutoSize = true;
      radioButton_CheckFindOUt.Location = new Point(14, 84);
      radioButton_CheckFindOUt.Name = "radioButton_CheckFindOUt";
      radioButton_CheckFindOUt.Size = new Size(144, 16);
      radioButton_CheckFindOUt.TabIndex = 9;
      radioButton_CheckFindOUt.TabStop = true;
      radioButton_CheckFindOUt.Text = "Check all";
      radioButton_CheckFindOUt.UseVisualStyleBackColor = true;
      radioButton_CheckFindOUt.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      radioButton_UnCheckFindOUt.AutoSize = true;
      radioButton_UnCheckFindOUt.Location = new Point(14, 105);
      radioButton_UnCheckFindOUt.Name = "radioButton_UnCheckFindOUt";
      radioButton_UnCheckFindOUt.Size = new Size(143, 16);
      radioButton_UnCheckFindOUt.TabIndex = 10;
      radioButton_UnCheckFindOUt.TabStop = true;
      radioButton_UnCheckFindOUt.Text = "Uncheck all";
      radioButton_UnCheckFindOUt.UseVisualStyleBackColor = true;
      radioButton_UnCheckFindOUt.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(label_VictoryCount);
      Controls.Add(label_CompRate);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(groupBox1);
      Controls.Add(panel);
      Name = nameof (MonsterDataControl);
      Size = new Size(840, 441);
      Click += ItemDataControl_Click;
      panel.ResumeLayout(false);
      panel.PerformLayout();
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      numericUpDown_LumpEditCount.EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    private void MonsterDataControl_Disposed(object sender, EventArgs e)
    {
      if (_panelBitmap == null)
        return;
      _panelBitmap.Dispose();
      _panelBitmap = null;
    }

    private void panel_Paint(object sender, PaintEventArgs e) => panelPaint(e.Graphics);

    private void panelPaint()
    {
      using (Graphics panelGraphics = Graphics.FromHwnd(panel.Handle))
        panelPaint(panelGraphics);
    }

    public void panelPaint(Graphics panelGraphics)
    {
      if (_panelBitmap == null)
        return;
      using (Graphics g = Graphics.FromImage(_panelBitmap))
      {
        using (Brush brush1 = new SolidBrush(ForeColor))
        {
          using (Brush brush2 = new SolidBrush(SystemColors.ControlLight))
          {
            using (Brush brush3 = new SolidBrush(SystemColors.Control))
            {
              g.FillRectangle(brush3, new Rectangle(0, 0, panel.Width, 40));
              g.FillRectangle(brush2, new Rectangle(0, panel.Height - 20, panel.Width, 20));
              using (Brush brush4 = new SolidBrush(ForeColor))
              {
                g.DrawString("Name", Font, brush4, 50f, 17f);
                g.DrawString("Kills", Font, brush4, 181f, 17f);
                g.DrawString("Items Dropped", Font, brush4, 223f, 8f);
                g.DrawString("Common", Font, brush4, 220f, 25f);
                g.DrawString("Rare", Font, brush4, 271f, 25f);
                g.DrawString("Name", Font, brush4, 365f, 17f);
                g.DrawString("Kills", Font, brush4, 485f, 17f);
                g.DrawString("Items Dropped", Font, brush4, 527f, 8f);
                g.DrawString("Common", Font, brush4, 524f, 25f);
                g.DrawString("Rare", Font, brush4, 575f, 25f);
                g.DrawString("Checked = Eye for Trouble used", Font, brush4, 0.0f, 0.0f);
              }
              int index1 = _vScrollBar.Value * 2;
              int index2 = 0;
              for (int index3 = 0; index3 < 10; ++index3)
              {
                g.FillRectangle((index3 & 1) == 0 ? brush2 : brush3, new Rectangle(0, 40 + index3 * 30, Width, 30));
                int num = 0;
                while (num < 2)
                {
                  if (index1 < MonsterDataList.List.Count)
                  {
                    string s = MonsterDataList.List[index1];
                    g.DrawString(string.Format("{0:D3}", index1 + 1), Font, brush1, 8 + num * 310, 49 + index3 * 30);
                    g.DrawString(s, Font, brush1, 50 + num * 310, 49 + index3 * 30);
                    DrawCheckBox(g, index2, _checkBox_Checked[index2] ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
                  }
                  ++index2;
                  ++num;
                  ++index1;
                }
              }
              RenewalVisionControl(g);
            }
          }
        }
      }
      panelGraphics.DrawImage(_panelBitmap, Point.Empty);
    }

    private void DrawCheckBox(Graphics g, int index, CheckBoxState state)
    {
      if (_vScrollBar.Value * 2 + index >= 307)
        return;
      int num1 = index % 2;
      int num2 = index / 2;
      int x = 35 + 310 * num1;
      int y = 49 + 30 * num2;
      if (g != null)
      {
        if (VisualStyleRenderer.IsSupported)
        {
          if (state == CheckBoxState.CheckedNormal)
            g.DrawImage(_checkBoxBitmap[1], new Point(x, y));
          else if (state == CheckBoxState.UncheckedNormal)
            g.DrawImage(_checkBoxBitmap[0], new Point(x, y));
          else
            CheckBoxRenderer.DrawCheckBox(g, new Point(x, y), state);
        }
        else if (state == CheckBoxState.CheckedHot || state == CheckBoxState.CheckedNormal)
          g.DrawImage(_checkBoxBitmap[1], new Point(x, y));
        else
          g.DrawImage(_checkBoxBitmap[0], new Point(x, y));
      }
      else
      {
        using (g = Graphics.FromHwnd(panel.Handle))
        {
          if (VisualStyleRenderer.IsSupported)
            CheckBoxRenderer.DrawCheckBox(g, new Point(x, y), state);
          else if (state == CheckBoxState.CheckedHot || state == CheckBoxState.CheckedNormal)
            ControlPaint.DrawCheckBox(g, x, y, 13, 13, ButtonState.Checked);
          else
            ControlPaint.DrawCheckBox(g, x, y, 13, 13, ButtonState.Normal);
        }
      }
    }

    private void RenewalLabelCompRate()
    {
      MonsterDataManager monsterDataManager = SaveDataManager.Instance.SaveData.MonsterDataManager;
      int num = (int) (monsterDataManager.CompCount / 307.0 * 100.0);
      if (num == 0 && monsterDataManager.CompCount != 0)
        num = 1;
      label_CompRate.Text = string.Format("{0}%", num);
      label_VictoryCount.Text = string.Format("{0} Types", monsterDataManager.CompCount);
    }

    protected override void OnValueUpdate()
    {
      SetMonsterData();
      panelPaint();
      RenewalLabelCompRate();
    }

    private void panel_MouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta < 0)
      {
        if (_vScrollBar.Value >= _vScrollBar.Maximum - _vScrollBar.LargeChange + 1)
          return;
        textBox_Dummy.Focus();
        ++_vScrollBar.Value;
        SetMonsterData();
      }
      else
      {
        if (_vScrollBar.Value <= _vScrollBar.Minimum)
          return;
        textBox_Dummy.Focus();
        --_vScrollBar.Value;
        SetMonsterData();
      }
    }

    private void panel_MouseDown(object sender, MouseEventArgs e)
    {
      int index1 = CheckBoxHitTest(e.X, e.Y);
      if (index1 == -1)
        return;
      int index2 = _vScrollBar.Value * 2 + index1;
      _checkBox_Checked[index1] = !_checkBox_Checked[index1];
      DrawCheckBox(null, index1, _checkBox_Checked[index1] ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot);
      SaveDataManager.Instance.SaveData.MonsterDataManager.SetFindOut(index2, _checkBox_Checked[index1]);
    }

    private void panel_MouseMove(object sender, MouseEventArgs e)
    {
      int index = CheckBoxHitTest(e.X, e.Y);
      if (_lastMouseOverIndex == index)
        return;
      if (_lastMouseOverIndex != -1)
        DrawCheckBox(null, _lastMouseOverIndex, _checkBox_Checked[_lastMouseOverIndex] ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
      _lastMouseOverIndex = index;
      if (index == -1)
        return;
      DrawCheckBox(null, index, _checkBox_Checked[index] ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot);
    }

    private int CheckBoxHitTest(int x, int y)
    {
      if (x < 35 || y < 45)
        return -1;
      x -= 35;
      y -= 45;
      if (x % 310 > 120 || y % 30 > 20)
        return -1;
      int num1 = x / 310;
      int num2 = y / 30;
      return num1 >= 2 || num2 >= 10 ? -1 : num2 * 2 + num1;
    }

    public void Initialize()
    {
      SuspendLayout();
      BeginUpdate();
      _vScrollBar.Maximum = 154;
      _vScrollBar.LargeChange = 10;
      int index1 = 0;
      int top = 46;
      for (int index2 = 0; index2 < 10; ++index2)
      {
        for (int index3 = 0; index3 < 2; ++index3)
        {
          _numericUpDown_VictoryCount[index1] = new VisionNumericUpDown(173 + index3 * 304, top, 44, 19);
          _numericUpDown_VictoryCount[index1].Minimum = 0M;
          _numericUpDown_VictoryCount[index1].Maximum = 999M;
          _numericUpDown_VictoryCount[index1].Tag = index1;
          _numericUpDown_VictoryCount[index1].ValueChanged += NumericUpDown_VictoryCount_ValueChanged;
          panel.AddVisionControl(_numericUpDown_VictoryCount[index1]);
          _numericUpDown_Item1Count[index1] = new VisionNumericUpDown(225 + index3 * 304, top, 38, 19);
          _numericUpDown_Item1Count[index1].Minimum = 0M;
          _numericUpDown_Item1Count[index1].Maximum = 99M;
          _numericUpDown_Item1Count[index1].Tag = index1;
          _numericUpDown_Item1Count[index1].ValueChanged += NumericUpDown_Item1Count_ValueChanged;
          panel.AddVisionControl(_numericUpDown_Item1Count[index1]);
          _numericUpDown_Item2Count[index1] = new VisionNumericUpDown(267 + index3 * 304, top, 38, 19);
          _numericUpDown_Item2Count[index1].Minimum = 0M;
          _numericUpDown_Item2Count[index1].Maximum = 99M;
          _numericUpDown_Item2Count[index1].Tag = index1;
          _numericUpDown_Item2Count[index1].ValueChanged += NumericUpDown_Item2Count_ValueChanged;
          panel.AddVisionControl(_numericUpDown_Item2Count[index1]);
          ++index1;
        }
        top += 30;
      }
      using (Graphics.FromHwnd(Handle))
      {
        int width = 20;
        int height = 20;
        for (int index4 = 0; index4 < 2; ++index4)
        {
          _checkBoxBitmap[index4] = new Bitmap(width, height);
          using (Graphics graphics = Graphics.FromImage(_checkBoxBitmap[index4]))
          {
            graphics.Clear(Color.Transparent);
            if (VisualStyleRenderer.IsSupported)
              CheckBoxRenderer.DrawCheckBox(graphics, new Point(0, 0), index4 == 0 ? CheckBoxState.UncheckedNormal : CheckBoxState.CheckedNormal);
            else if (index4 == 0)
              ControlPaint.DrawCheckBox(graphics, 0, 0, width, height, ButtonState.Normal);
            else
              ControlPaint.DrawCheckBox(graphics, 0, 0, width, height, ButtonState.Checked);
          }
        }
      }
      EndUpdate();
      ResumeLayout(false);
    }

    private void NumericUpDown_VictoryCount_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
        return;
      int index = _vScrollBar.Value * 2 + (int) visionNumericUpDown.Tag;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      MonsterDataManager monsterDataManager = SaveDataManager.Instance.SaveData.MonsterDataManager;
      monsterDataManager.SetVictoryCount(index, (ushort) visionNumericUpDown.Value);
      monsterDataManager.ReviseCompCount();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      RenewalLabelCompRate();
    }

    private void NumericUpDown_Item1Count_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.MonsterDataManager.SetItemCount1(_vScrollBar.Value * 2 + (int) visionNumericUpDown.Tag, (byte) visionNumericUpDown.Value);
    }

    private void NumericUpDown_Item2Count_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.MonsterDataManager.SetItemCount2(_vScrollBar.Value * 2 + (int) visionNumericUpDown.Tag, (byte) visionNumericUpDown.Value);
    }

    private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      if (_vScrollBar.Value > _vScrollBar.Maximum - _vScrollBar.LargeChange)
      {
        BeginUpdate();
        _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange;
        EndUpdate();
      }
      textBox_Dummy.Focus();
      SetMonsterData();
      panelPaint();
    }

    private void SetMonsterData()
    {
      BeginUpdate();
      if (_vScrollBar.Value > _vScrollBar.Maximum - _vScrollBar.LargeChange)
        _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange;
      int index1 = _vScrollBar.Value * 2;
      int index2 = 0;
      for (int index3 = 0; index3 < 10; ++index3)
      {
        for (int index4 = 0; index4 < 2; ++index4)
        {
          if (index1 >= MonsterDataList.List.Count)
          {
            _numericUpDown_VictoryCount[index2].Visible = false;
            _numericUpDown_Item1Count[index2].Visible = false;
            _numericUpDown_Item2Count[index2].Visible = false;
          }
          else
          {
            _numericUpDown_VictoryCount[index2].Visible = true;
            _numericUpDown_Item1Count[index2].Visible = true;
            _numericUpDown_Item2Count[index2].Visible = true;
            MonsterDataManager monsterDataManager = SaveDataManager.Instance.SaveData.MonsterDataManager;
            _numericUpDown_VictoryCount[index2].Value = monsterDataManager.GetVictoryCount(index1);
            _numericUpDown_Item1Count[index2].Value = monsterDataManager.GetItemCount1(index1);
            _numericUpDown_Item2Count[index2].Value = monsterDataManager.GetItemCount2(index1);
            _checkBox_Checked[index2] = monsterDataManager.IsFindOut(index1);
          }
          ++index1;
          ++index2;
        }
      }
      EndUpdate();
    }

    private void panel_Click(object sender, EventArgs e) => textBox_Dummy.Focus();

    private void textBox_Dummy_KeyDown(object sender, KeyEventArgs e)
    {
      if (_vScrollBar.Value != _vScrollBar.Minimum)
      {
        if (e.KeyCode == Keys.Home)
        {
          _vScrollBar.Value = _vScrollBar.Minimum;
          SetMonsterData();
        }
        else if (e.KeyCode == Keys.Prior)
        {
          if (_vScrollBar.Value - (_vScrollBar.LargeChange - 1) < _vScrollBar.Minimum)
            _vScrollBar.Value = _vScrollBar.Minimum;
          else
            _vScrollBar.Value -= _vScrollBar.LargeChange - 1;
          SetMonsterData();
        }
      }
      if (_vScrollBar.Value == _vScrollBar.Maximum - _vScrollBar.LargeChange + 2)
        return;
      if (e.KeyCode == Keys.End)
      {
        _vScrollBar.Value = _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1) + 1;
        SetMonsterData();
      }
      else
      {
        if (e.KeyCode != Keys.Next)
          return;
        if (_vScrollBar.Value + (_vScrollBar.LargeChange - 1) > _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1))
          _vScrollBar.Value = _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1) + 1;
        else
          _vScrollBar.Value += _vScrollBar.LargeChange - 1;
        SetMonsterData();
      }
    }

    private void ItemDataControl_Click(object sender, EventArgs e) => textBox_Dummy.Focus();

    private void button_Execute_Click(object sender, EventArgs e)
    {
      ushort num = (ushort) numericUpDown_LumpEditCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      MonsterDataManager monsterDataManager = SaveDataManager.Instance.SaveData.MonsterDataManager;
      for (int index = 0; index < 307; ++index)
      {
        if (radioButton_VictoryCount.Checked)
          monsterDataManager.SetVictoryCount(index, num);
        else if (radioButton_ItemCount1.Checked)
          monsterDataManager.SetItemCount1(index, (byte) num);
        else if (radioButton_ItemCount2.Checked)
          monsterDataManager.SetItemCount2(index, (byte) num);
        else if (radioButton_CheckFindOUt.Checked)
          monsterDataManager.SetFindOut(index, true);
        else if (radioButton_UnCheckFindOUt.Checked)
          monsterDataManager.SetFindOut(index, false);
      }
      monsterDataManager.ReviseCompCount();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      SetMonsterData();
      panelPaint();
      RenewalLabelCompRate();
    }

    private void radioButton_LumpEdit_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButton_VictoryCount.Checked)
      {
        label_Lump.Enabled = true;
        numericUpDown_LumpEditCount.Enabled = true;
        label_Lump.Text = "QTY";
        numericUpDown_LumpEditCount.Maximum = 999M;
      }
      else if (radioButton_CheckFindOUt.Checked || radioButton_UnCheckFindOUt.Checked)
      {
        label_Lump.Enabled = false;
        numericUpDown_LumpEditCount.Enabled = false;
      }
      else
      {
        label_Lump.Enabled = true;
        numericUpDown_LumpEditCount.Enabled = true;
        label_Lump.Text = "QTY";
        numericUpDown_LumpEditCount.Maximum = 99M;
      }
    }
  }
}
