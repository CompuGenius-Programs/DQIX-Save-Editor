// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MonsterDataControl
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
using System.Windows.Forms.VisualStyles;

#nullable disable
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
    private System.Windows.Forms.TextBox textBox_Dummy;
    private System.Windows.Forms.GroupBox groupBox1;
    private Label label_Lump;
    private NumericUpDown numericUpDown_LumpEditCount;
    private System.Windows.Forms.RadioButton radioButton_ItemCount2;
    private System.Windows.Forms.RadioButton radioButton_VictoryCount;
    private System.Windows.Forms.RadioButton radioButton_ItemCount1;
    private System.Windows.Forms.Button button_Execute;
    private Label label1;
    private Label label2;
    private Label label_CompRate;
    private Label label_VictoryCount;
    private System.Windows.Forms.RadioButton radioButton_UnCheckFindOUt;
    private System.Windows.Forms.RadioButton radioButton_CheckFindOUt;
    private Bitmap _panelBitmap;
    private Bitmap[] _checkBoxBitmap = new Bitmap[2];
    private int _lastMouseOverIndex;
    private VisionNumericUpDown[] _numericUpDown_VictoryCount = new VisionNumericUpDown[20];
    private VisionNumericUpDown[] _numericUpDown_Item1Count = new VisionNumericUpDown[20];
    private VisionNumericUpDown[] _numericUpDown_Item2Count = new VisionNumericUpDown[20];
    private bool[] _checkBox_Checked = new bool[20];

    public MonsterDataControl()
    {
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      this.Initialize();
      this.panel.MouseWheel += new MouseEventHandler(this.panel_MouseWheel);
      this.panel.MouseMove += new MouseEventHandler(this.panel_MouseMove);
      this.panel.MouseDown += new MouseEventHandler(this.panel_MouseDown);
      this.panel.Paint += new PaintEventHandler(this.panel_Paint);
      this._panelBitmap = new Bitmap(this.panel.Width, this.panel.Height);
      this.Disposed += new EventHandler(this.MonsterDataControl_Disposed);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panel = new JS_Panel();
      this.textBox_Dummy = new System.Windows.Forms.TextBox();
      this._vScrollBar = new VScrollBar();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.radioButton_ItemCount1 = new System.Windows.Forms.RadioButton();
      this.radioButton_ItemCount2 = new System.Windows.Forms.RadioButton();
      this.label_Lump = new Label();
      this.radioButton_VictoryCount = new System.Windows.Forms.RadioButton();
      this.numericUpDown_LumpEditCount = new NumericUpDown();
      this.button_Execute = new System.Windows.Forms.Button();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label_CompRate = new Label();
      this.label_VictoryCount = new Label();
      this.radioButton_CheckFindOUt = new System.Windows.Forms.RadioButton();
      this.radioButton_UnCheckFindOUt = new System.Windows.Forms.RadioButton();
      this.panel.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.numericUpDown_LumpEditCount.BeginInit();
      this.SuspendLayout();
      this.panel.BorderStyle = BorderStyle.Fixed3D;
      this.panel.Controls.Add((Control) this.textBox_Dummy);
      this.panel.Controls.Add((Control) this._vScrollBar);
      this.panel.Location = new Point(8, 56);
      this.panel.Name = "panel";
      this.panel.Size = new Size(642, 359);
      this.panel.TabIndex = 1;
      this.panel.Click += new EventHandler(this.panel_Click);
      this.textBox_Dummy.Location = new Point(-100, -100);
      this.textBox_Dummy.Name = "textBox_Dummy";
      this.textBox_Dummy.ReadOnly = true;
      this.textBox_Dummy.Size = new Size(100, 19);
      this.textBox_Dummy.TabIndex = 1;
      this.textBox_Dummy.KeyDown += new KeyEventHandler(this.textBox_Dummy_KeyDown);
      this._vScrollBar.Dock = DockStyle.Right;
      this._vScrollBar.Location = new Point(621, 0);
      this._vScrollBar.Name = "_vScrollBar";
      this._vScrollBar.Size = new Size(17, 355);
      this._vScrollBar.TabIndex = 0;
      this._vScrollBar.ValueChanged += new EventHandler(this._vScrollBar_ValueChanged);
      this._vScrollBar.Scroll += new ScrollEventHandler(this.vScrollBar_Scroll);
      this.groupBox1.Controls.Add((Control) this.radioButton_UnCheckFindOUt);
      this.groupBox1.Controls.Add((Control) this.radioButton_CheckFindOUt);
      this.groupBox1.Controls.Add((Control) this.radioButton_ItemCount1);
      this.groupBox1.Controls.Add((Control) this.radioButton_ItemCount2);
      this.groupBox1.Controls.Add((Control) this.label_Lump);
      this.groupBox1.Controls.Add((Control) this.radioButton_VictoryCount);
      this.groupBox1.Controls.Add((Control) this.numericUpDown_LumpEditCount);
      this.groupBox1.Controls.Add((Control) this.button_Execute);
      this.groupBox1.Location = new Point(656, 49);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(173, 366);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Bulk Edit";
      this.radioButton_ItemCount1.AutoSize = true;
      this.radioButton_ItemCount1.Location = new Point(14, 42);
      this.radioButton_ItemCount1.Name = "radioButton_ItemCount1";
      this.radioButton_ItemCount1.Size = new Size(153, 16);
      this.radioButton_ItemCount1.TabIndex = 8;
      this.radioButton_ItemCount1.TabStop = true;
      this.radioButton_ItemCount1.Text = "Common Item Drops";
      this.radioButton_ItemCount1.UseVisualStyleBackColor = true;
      this.radioButton_ItemCount1.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.radioButton_ItemCount2.AutoSize = true;
      this.radioButton_ItemCount2.Location = new Point(14, 63);
      this.radioButton_ItemCount2.Name = "radioButton_ItemCount2";
      this.radioButton_ItemCount2.Size = new Size(147, 16);
      this.radioButton_ItemCount2.TabIndex = 1;
      this.radioButton_ItemCount2.TabStop = true;
      this.radioButton_ItemCount2.Text = "Rare Item Drops";
      this.radioButton_ItemCount2.UseVisualStyleBackColor = true;
      this.radioButton_ItemCount2.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.label_Lump.AutoSize = true;
      this.label_Lump.Location = new Point(21, 139);
      this.label_Lump.Name = "label_Lump";
      this.label_Lump.Size = new Size(29, 12);
      this.label_Lump.TabIndex = 7;
      this.label_Lump.Text = "Qty";
      this.label_Lump.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.radioButton_VictoryCount.AutoSize = true;
      this.radioButton_VictoryCount.Checked = true;
      this.radioButton_VictoryCount.Location = new Point(14, 21);
      this.radioButton_VictoryCount.Name = "radioButton_VictoryCount";
      this.radioButton_VictoryCount.Size = new Size(110, 16);
      this.radioButton_VictoryCount.TabIndex = 0;
      this.radioButton_VictoryCount.TabStop = true;
      this.radioButton_VictoryCount.Text = "Kills";
      this.radioButton_VictoryCount.UseVisualStyleBackColor = true;
      this.radioButton_VictoryCount.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.numericUpDown_LumpEditCount.Location = new Point(52, 136);
      this.numericUpDown_LumpEditCount.Maximum = new Decimal(new int[4]
      {
        999,
        0,
        0,
        0
      });
      this.numericUpDown_LumpEditCount.Name = "numericUpDown_LumpEditCount";
      this.numericUpDown_LumpEditCount.Size = new Size(41, 19);
      this.numericUpDown_LumpEditCount.TabIndex = 6;
      this.button_Execute.Location = new Point(99, 134);
      this.button_Execute.Name = "button_Execute";
      this.button_Execute.Size = new Size(49, 23);
      this.button_Execute.TabIndex = 4;
      this.button_Execute.Text = "Go";
      this.button_Execute.UseVisualStyleBackColor = true;
      this.button_Execute.Click += new EventHandler(this.button_Execute_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(62, 11);
      this.label1.Name = "label1";
      this.label1.Size = new Size(136, 12);
      this.label1.TabIndex = 3;
      this.label1.Text = "Completion Rate";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(23, 31);
      this.label2.Name = "label2";
      this.label2.Size = new Size(126, 12);
      this.label2.TabIndex = 4;
      this.label2.Text = "Monster Types Defeated";
      this.label_CompRate.AutoSize = true;
      this.label_CompRate.Location = new Point(155, 11);
      this.label_CompRate.Name = "label_CompRate";
      this.label_CompRate.Size = new Size(17, 12);
      this.label_CompRate.TabIndex = 5;
      this.label_CompRate.Text = "0%";
      this.label_VictoryCount.AutoSize = true;
      this.label_VictoryCount.Location = new Point(155, 31);
      this.label_VictoryCount.Name = "label_VictoryCount";
      this.label_VictoryCount.Size = new Size(35, 12);
      this.label_VictoryCount.TabIndex = 6;
      this.label_VictoryCount.Text = "0 Types";
      this.radioButton_CheckFindOUt.AutoSize = true;
      this.radioButton_CheckFindOUt.Location = new Point(14, 84);
      this.radioButton_CheckFindOUt.Name = "radioButton_CheckFindOUt";
      this.radioButton_CheckFindOUt.Size = new Size(144, 16);
      this.radioButton_CheckFindOUt.TabIndex = 9;
      this.radioButton_CheckFindOUt.TabStop = true;
      this.radioButton_CheckFindOUt.Text = "Check all";
      this.radioButton_CheckFindOUt.UseVisualStyleBackColor = true;
      this.radioButton_CheckFindOUt.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.radioButton_UnCheckFindOUt.AutoSize = true;
      this.radioButton_UnCheckFindOUt.Location = new Point(14, 105);
      this.radioButton_UnCheckFindOUt.Name = "radioButton_UnCheckFindOUt";
      this.radioButton_UnCheckFindOUt.Size = new Size(143, 16);
      this.radioButton_UnCheckFindOUt.TabIndex = 10;
      this.radioButton_UnCheckFindOUt.TabStop = true;
      this.radioButton_UnCheckFindOUt.Text = "Uncheck all";
      this.radioButton_UnCheckFindOUt.UseVisualStyleBackColor = true;
      this.radioButton_UnCheckFindOUt.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.label_VictoryCount);
      this.Controls.Add((Control) this.label_CompRate);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.panel);
      this.Name = nameof (MonsterDataControl);
      this.Size = new Size(840, 441);
      this.Click += new EventHandler(this.ItemDataControl_Click);
      this.panel.ResumeLayout(false);
      this.panel.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numericUpDown_LumpEditCount.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void MonsterDataControl_Disposed(object sender, EventArgs e)
    {
      if (this._panelBitmap == null)
        return;
      this._panelBitmap.Dispose();
      this._panelBitmap = (Bitmap) null;
    }

    private void panel_Paint(object sender, PaintEventArgs e) => this.panelPaint(e.Graphics);

    private void panelPaint()
    {
      using (Graphics panelGraphics = Graphics.FromHwnd(this.panel.Handle))
        this.panelPaint(panelGraphics);
    }

    public void panelPaint(Graphics panelGraphics)
    {
      if (this._panelBitmap == null)
        return;
      using (Graphics g = Graphics.FromImage((Image) this._panelBitmap))
      {
        using (Brush brush1 = (Brush) new SolidBrush(this.ForeColor))
        {
          using (Brush brush2 = (Brush) new SolidBrush(SystemColors.ControlLight))
          {
            using (Brush brush3 = (Brush) new SolidBrush(SystemColors.Control))
            {
              g.FillRectangle(brush3, new Rectangle(0, 0, this.panel.Width, 40));
              g.FillRectangle(brush2, new Rectangle(0, this.panel.Height - 20, this.panel.Width, 20));
              using (Brush brush4 = (Brush) new SolidBrush(this.ForeColor))
              {
                g.DrawString("Name", this.Font, brush4, 50f, 17f);
                g.DrawString("Kills", this.Font, brush4, 181f, 17f);
                g.DrawString("Items Dropped", this.Font, brush4, 223f, 8f);
                g.DrawString("Common", this.Font, brush4, 220f, 25f);
                g.DrawString("Rare", this.Font, brush4, 271f, 25f);
                g.DrawString("Name", this.Font, brush4, 365f, 17f);
                g.DrawString("Kills", this.Font, brush4, 485f, 17f);
                g.DrawString("Items Dropped", this.Font, brush4, 527f, 8f);
                g.DrawString("Common", this.Font, brush4, 524f, 25f);
                g.DrawString("Rare", this.Font, brush4, 575f, 25f);
                g.DrawString("Checked = Eye for Trouble used", this.Font, brush4, 0.0f, 0.0f);
              }
              int index1 = this._vScrollBar.Value * 2;
              int index2 = 0;
              for (int index3 = 0; index3 < 10; ++index3)
              {
                g.FillRectangle((index3 & 1) == 0 ? brush2 : brush3, new Rectangle(0, 40 + index3 * 30, this.Width, 30));
                int num = 0;
                while (num < 2)
                {
                  if (index1 < MonsterDataList.List.Count)
                  {
                    string s = MonsterDataList.List[index1];
                    g.DrawString(string.Format("{0:D3}", (object) (index1 + 1)), this.Font, brush1, (float) (8 + num * 310), (float) (49 + index3 * 30));
                    g.DrawString(s, this.Font, brush1, (float) (50 + num * 310), (float) (49 + index3 * 30));
                    this.DrawCheckBox(g, index2, this._checkBox_Checked[index2] ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
                  }
                  ++index2;
                  ++num;
                  ++index1;
                }
              }
              this.RenewalVisionControl(g);
            }
          }
        }
      }
      panelGraphics.DrawImage((Image) this._panelBitmap, Point.Empty);
    }

    private void DrawCheckBox(Graphics g, int index, CheckBoxState state)
    {
      if (this._vScrollBar.Value * 2 + index >= 307)
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
            g.DrawImage((Image) this._checkBoxBitmap[1], new Point(x, y));
          else if (state == CheckBoxState.UncheckedNormal)
            g.DrawImage((Image) this._checkBoxBitmap[0], new Point(x, y));
          else
            CheckBoxRenderer.DrawCheckBox(g, new Point(x, y), state);
        }
        else if (state == CheckBoxState.CheckedHot || state == CheckBoxState.CheckedNormal)
          g.DrawImage((Image) this._checkBoxBitmap[1], new Point(x, y));
        else
          g.DrawImage((Image) this._checkBoxBitmap[0], new Point(x, y));
      }
      else
      {
        using (g = Graphics.FromHwnd(this.panel.Handle))
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
      int num = (int) ((double) monsterDataManager.CompCount / 307.0 * 100.0);
      if (num == 0 && monsterDataManager.CompCount != (ushort) 0)
        num = 1;
      this.label_CompRate.Text = string.Format("{0}%", (object) num);
      this.label_VictoryCount.Text = string.Format("{0} Types", (object) monsterDataManager.CompCount);
    }

    protected override void OnValueUpdate()
    {
      this.SetMonsterData();
      this.panelPaint();
      this.RenewalLabelCompRate();
    }

    private void panel_MouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta < 0)
      {
        if (this._vScrollBar.Value >= this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1)
          return;
        this.textBox_Dummy.Focus();
        ++this._vScrollBar.Value;
        this.SetMonsterData();
      }
      else
      {
        if (this._vScrollBar.Value <= this._vScrollBar.Minimum)
          return;
        this.textBox_Dummy.Focus();
        --this._vScrollBar.Value;
        this.SetMonsterData();
      }
    }

    private void panel_MouseDown(object sender, MouseEventArgs e)
    {
      int index1 = this.CheckBoxHitTest(e.X, e.Y);
      if (index1 == -1)
        return;
      int index2 = this._vScrollBar.Value * 2 + index1;
      this._checkBox_Checked[index1] = !this._checkBox_Checked[index1];
      this.DrawCheckBox((Graphics) null, index1, this._checkBox_Checked[index1] ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot);
      SaveDataManager.Instance.SaveData.MonsterDataManager.SetFindOut(index2, this._checkBox_Checked[index1]);
    }

    private void panel_MouseMove(object sender, MouseEventArgs e)
    {
      int index = this.CheckBoxHitTest(e.X, e.Y);
      if (this._lastMouseOverIndex == index)
        return;
      if (this._lastMouseOverIndex != -1)
        this.DrawCheckBox((Graphics) null, this._lastMouseOverIndex, this._checkBox_Checked[this._lastMouseOverIndex] ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
      this._lastMouseOverIndex = index;
      if (index == -1)
        return;
      this.DrawCheckBox((Graphics) null, index, this._checkBox_Checked[index] ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot);
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
      this.SuspendLayout();
      this.BeginUpdate();
      this._vScrollBar.Maximum = 154;
      this._vScrollBar.LargeChange = 10;
      int index1 = 0;
      int top = 46;
      for (int index2 = 0; index2 < 10; ++index2)
      {
        for (int index3 = 0; index3 < 2; ++index3)
        {
          this._numericUpDown_VictoryCount[index1] = new VisionNumericUpDown(173 + index3 * 304, top, 44, 19);
          this._numericUpDown_VictoryCount[index1].Minimum = 0M;
          this._numericUpDown_VictoryCount[index1].Maximum = 999M;
          this._numericUpDown_VictoryCount[index1].Tag = (object) index1;
          this._numericUpDown_VictoryCount[index1].ValueChanged += new EventHandler(this.NumericUpDown_VictoryCount_ValueChanged);
          this.panel.AddVisionControl((VisionControlBase) this._numericUpDown_VictoryCount[index1]);
          this._numericUpDown_Item1Count[index1] = new VisionNumericUpDown(225 + index3 * 304, top, 38, 19);
          this._numericUpDown_Item1Count[index1].Minimum = 0M;
          this._numericUpDown_Item1Count[index1].Maximum = 99M;
          this._numericUpDown_Item1Count[index1].Tag = (object) index1;
          this._numericUpDown_Item1Count[index1].ValueChanged += new EventHandler(this.NumericUpDown_Item1Count_ValueChanged);
          this.panel.AddVisionControl((VisionControlBase) this._numericUpDown_Item1Count[index1]);
          this._numericUpDown_Item2Count[index1] = new VisionNumericUpDown(267 + index3 * 304, top, 38, 19);
          this._numericUpDown_Item2Count[index1].Minimum = 0M;
          this._numericUpDown_Item2Count[index1].Maximum = 99M;
          this._numericUpDown_Item2Count[index1].Tag = (object) index1;
          this._numericUpDown_Item2Count[index1].ValueChanged += new EventHandler(this.NumericUpDown_Item2Count_ValueChanged);
          this.panel.AddVisionControl((VisionControlBase) this._numericUpDown_Item2Count[index1]);
          ++index1;
        }
        top += 30;
      }
      using (Graphics.FromHwnd(this.Handle))
      {
        int width = 20;
        int height = 20;
        for (int index4 = 0; index4 < 2; ++index4)
        {
          this._checkBoxBitmap[index4] = new Bitmap(width, height);
          using (Graphics graphics = Graphics.FromImage((Image) this._checkBoxBitmap[index4]))
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
      this.EndUpdate();
      this.ResumeLayout(false);
    }

    private void NumericUpDown_VictoryCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
        return;
      int index = this._vScrollBar.Value * 2 + (int) visionNumericUpDown.Tag;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      MonsterDataManager monsterDataManager = SaveDataManager.Instance.SaveData.MonsterDataManager;
      monsterDataManager.SetVictoryCount(index, (ushort) visionNumericUpDown.Value);
      monsterDataManager.ReviseCompCount();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.RenewalLabelCompRate();
    }

    private void NumericUpDown_Item1Count_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.MonsterDataManager.SetItemCount1(this._vScrollBar.Value * 2 + (int) visionNumericUpDown.Tag, (byte) visionNumericUpDown.Value);
    }

    private void NumericUpDown_Item2Count_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.MonsterDataManager.SetItemCount2(this._vScrollBar.Value * 2 + (int) visionNumericUpDown.Tag, (byte) visionNumericUpDown.Value);
    }

    private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      if (this._vScrollBar.Value > this._vScrollBar.Maximum - this._vScrollBar.LargeChange)
      {
        this.BeginUpdate();
        this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange;
        this.EndUpdate();
      }
      this.textBox_Dummy.Focus();
      this.SetMonsterData();
      this.panelPaint();
    }

    private void SetMonsterData()
    {
      this.BeginUpdate();
      if (this._vScrollBar.Value > this._vScrollBar.Maximum - this._vScrollBar.LargeChange)
        this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange;
      int index1 = this._vScrollBar.Value * 2;
      int index2 = 0;
      for (int index3 = 0; index3 < 10; ++index3)
      {
        for (int index4 = 0; index4 < 2; ++index4)
        {
          if (index1 >= MonsterDataList.List.Count)
          {
            this._numericUpDown_VictoryCount[index2].Visible = false;
            this._numericUpDown_Item1Count[index2].Visible = false;
            this._numericUpDown_Item2Count[index2].Visible = false;
          }
          else
          {
            this._numericUpDown_VictoryCount[index2].Visible = true;
            this._numericUpDown_Item1Count[index2].Visible = true;
            this._numericUpDown_Item2Count[index2].Visible = true;
            MonsterDataManager monsterDataManager = SaveDataManager.Instance.SaveData.MonsterDataManager;
            this._numericUpDown_VictoryCount[index2].Value = (Decimal) monsterDataManager.GetVictoryCount(index1);
            this._numericUpDown_Item1Count[index2].Value = (Decimal) monsterDataManager.GetItemCount1(index1);
            this._numericUpDown_Item2Count[index2].Value = (Decimal) monsterDataManager.GetItemCount2(index1);
            this._checkBox_Checked[index2] = monsterDataManager.IsFindOut(index1);
          }
          ++index1;
          ++index2;
        }
      }
      this.EndUpdate();
    }

    private void panel_Click(object sender, EventArgs e) => this.textBox_Dummy.Focus();

    private void textBox_Dummy_KeyDown(object sender, KeyEventArgs e)
    {
      if (this._vScrollBar.Value != this._vScrollBar.Minimum)
      {
        if (e.KeyCode == Keys.Home)
        {
          this._vScrollBar.Value = this._vScrollBar.Minimum;
          this.SetMonsterData();
        }
        else if (e.KeyCode == Keys.Prior)
        {
          if (this._vScrollBar.Value - (this._vScrollBar.LargeChange - 1) < this._vScrollBar.Minimum)
            this._vScrollBar.Value = this._vScrollBar.Minimum;
          else
            this._vScrollBar.Value -= this._vScrollBar.LargeChange - 1;
          this.SetMonsterData();
        }
      }
      if (this._vScrollBar.Value == this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 2)
        return;
      if (e.KeyCode == Keys.End)
      {
        this._vScrollBar.Value = this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1) + 1;
        this.SetMonsterData();
      }
      else
      {
        if (e.KeyCode != Keys.Next)
          return;
        if (this._vScrollBar.Value + (this._vScrollBar.LargeChange - 1) > this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1))
          this._vScrollBar.Value = this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1) + 1;
        else
          this._vScrollBar.Value += this._vScrollBar.LargeChange - 1;
        this.SetMonsterData();
      }
    }

    private void ItemDataControl_Click(object sender, EventArgs e) => this.textBox_Dummy.Focus();

    private void button_Execute_Click(object sender, EventArgs e)
    {
      ushort num = (ushort) this.numericUpDown_LumpEditCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      MonsterDataManager monsterDataManager = SaveDataManager.Instance.SaveData.MonsterDataManager;
      for (int index = 0; index < 307; ++index)
      {
        if (this.radioButton_VictoryCount.Checked)
          monsterDataManager.SetVictoryCount(index, num);
        else if (this.radioButton_ItemCount1.Checked)
          monsterDataManager.SetItemCount1(index, (byte) num);
        else if (this.radioButton_ItemCount2.Checked)
          monsterDataManager.SetItemCount2(index, (byte) num);
        else if (this.radioButton_CheckFindOUt.Checked)
          monsterDataManager.SetFindOut(index, true);
        else if (this.radioButton_UnCheckFindOUt.Checked)
          monsterDataManager.SetFindOut(index, false);
      }
      monsterDataManager.ReviseCompCount();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.SetMonsterData();
      this.panelPaint();
      this.RenewalLabelCompRate();
    }

    private void radioButton_LumpEdit_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButton_VictoryCount.Checked)
      {
        this.label_Lump.Enabled = true;
        this.numericUpDown_LumpEditCount.Enabled = true;
        this.label_Lump.Text = "QTY";
        this.numericUpDown_LumpEditCount.Maximum = 999M;
      }
      else if (this.radioButton_CheckFindOUt.Checked || this.radioButton_UnCheckFindOUt.Checked)
      {
        this.label_Lump.Enabled = false;
        this.numericUpDown_LumpEditCount.Enabled = false;
      }
      else
      {
        this.label_Lump.Enabled = true;
        this.numericUpDown_LumpEditCount.Enabled = true;
        this.label_Lump.Text = "QTY";
        this.numericUpDown_LumpEditCount.Maximum = 99M;
      }
    }
  }
}
