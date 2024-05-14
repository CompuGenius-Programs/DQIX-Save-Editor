// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.TitleDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using JS_Framework.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class TitleDataControl : DataControlBase
  {
    private const int ControlMarginLeft = 40;
    private const int ControlMarginTop = 32;
    private const int ControlMarginWidth = 40;
    private const int ControlMarginHeight = 5;
    private const int Horizontal = 3;
    private const int Vertical = 10;
    private const int ControlCount = 30;
    private const int CheckBox_Width = 160;
    private const int CheckBox_Height = 30;
    private IContainer components;
    private DoubleBufferedPanel panel;
    private VScrollBar _vScrollBar;
    private Label label_TitleCount;
    private System.Windows.Forms.TextBox textBox_TitleCount;
    private Label label1;
    private System.Windows.Forms.TextBox textBox_Dummy;
    private System.Windows.Forms.Button button_AllCheck;
    private System.Windows.Forms.Button button_AllUncheck;
    private bool[] _checkBox_Checked = new bool[30];
    private Bitmap _panelBitmap;
    private Bitmap[] _checkBoxBitmap = new Bitmap[2];
    private int _lastMouseOverIndex;
    private bool _reviseCount;

    public TitleDataControl()
    {
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      this.Disposed += new EventHandler(this.TitleDataControl_Disposed);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panel = new DoubleBufferedPanel();
      this.textBox_Dummy = new System.Windows.Forms.TextBox();
      this._vScrollBar = new VScrollBar();
      this.label_TitleCount = new Label();
      this.textBox_TitleCount = new System.Windows.Forms.TextBox();
      this.label1 = new Label();
      this.button_AllCheck = new System.Windows.Forms.Button();
      this.button_AllUncheck = new System.Windows.Forms.Button();
      this.panel.SuspendLayout();
      this.SuspendLayout();
      this.panel.BorderStyle = BorderStyle.Fixed3D;
      this.panel.Controls.Add((Control) this.textBox_Dummy);
      this.panel.Controls.Add((Control) this._vScrollBar);
      this.panel.Location = new Point(42, 38);
      this.panel.Name = "panel";
      this.panel.Size = new Size(619, 386);
      this.panel.TabIndex = 0;
      this.panel.Paint += new PaintEventHandler(this.panel_Paint);
      this.panel.Click += new EventHandler(this.panel_Click);
      this.panel.MouseDown += new MouseEventHandler(this.panel_MouseDown);
      this.textBox_Dummy.Location = new Point(-100, -100);
      this.textBox_Dummy.Name = "textBox_Dummy";
      this.textBox_Dummy.ReadOnly = true;
      this.textBox_Dummy.Size = new Size(100, 19);
      this.textBox_Dummy.TabIndex = 1;
      this.textBox_Dummy.KeyDown += new KeyEventHandler(this.textBox_Dummy_KeyDown);
      this._vScrollBar.Dock = DockStyle.Right;
      this._vScrollBar.Location = new Point(598, 0);
      this._vScrollBar.Name = "_vScrollBar";
      this._vScrollBar.Size = new Size(17, 382);
      this._vScrollBar.TabIndex = 0;
      this._vScrollBar.ValueChanged += new EventHandler(this._vScrollBar_ValueChanged);
      this.label_TitleCount.AutoSize = true;
      this.label_TitleCount.Location = new Point(40, 16);
      this.label_TitleCount.Name = "label_TitleCount";
      this.label_TitleCount.Size = new Size(65, 12);
      this.label_TitleCount.TabIndex = 1;
      this.label_TitleCount.Text = "Accolades";
      this.textBox_TitleCount.Location = new Point(111, 12);
      this.textBox_TitleCount.Name = "textBox_TitleCount";
      this.textBox_TitleCount.ReadOnly = true;
      this.textBox_TitleCount.Size = new Size(100, 19);
      this.textBox_TitleCount.TabIndex = 2;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(40, 421);
      this.label1.Name = "label1";
      this.label1.Size = new Size(364, 12);
      this.label1.TabIndex = 3;
      this.label1.Text = "The top name is for male characters, the bottom is for females.";
      this.button_AllCheck.Location = new Point(234, 10);
      this.button_AllCheck.Name = "button_AllCheck";
      this.button_AllCheck.Size = new Size(133, 23);
      this.button_AllCheck.TabIndex = 4;
      this.button_AllCheck.Text = "Check all";
      this.button_AllCheck.UseVisualStyleBackColor = true;
      this.button_AllCheck.Click += new EventHandler(this.button_AllCheck_Click);
      this.button_AllUncheck.Location = new Point(373, 10);
      this.button_AllUncheck.Name = "button_AllUncheck";
      this.button_AllUncheck.Size = new Size(133, 23);
      this.button_AllUncheck.TabIndex = 5;
      this.button_AllUncheck.Text = "Uncheck all";
      this.button_AllUncheck.UseVisualStyleBackColor = true;
      this.button_AllUncheck.Click += new EventHandler(this.button_AllUncheck_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.button_AllUncheck);
      this.Controls.Add((Control) this.button_AllCheck);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textBox_TitleCount);
      this.Controls.Add((Control) this.label_TitleCount);
      this.Controls.Add((Control) this.panel);
      this.DoubleBuffered = true;
      this.Name = nameof (TitleDataControl);
      this.Size = new Size(698, 500);
      this.Click += new EventHandler(this.TitleDataControl_Click);
      this.panel.ResumeLayout(false);
      this.panel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void TitleDataControl_Disposed(object sender, EventArgs e)
    {
      for (int index = 0; index < 2; ++index)
      {
        if (this._checkBoxBitmap[index] != null)
        {
          this._checkBoxBitmap[index].Dispose();
          this._checkBoxBitmap[index] = (Bitmap) null;
        }
      }
      this._checkBoxBitmap = (Bitmap[]) null;
      if (this._panelBitmap == null)
        return;
      this._panelBitmap.Dispose();
      this._panelBitmap = (Bitmap) null;
    }

    public void Initialize()
    {
      for (int index = 0; index < 30; ++index)
        this._checkBox_Checked[index] = false;
      this.RenewalScrollBar();
      this._panelBitmap = new Bitmap(this.panel.Width, this.panel.Height);
      this.panel.MouseMove += new MouseEventHandler(this.panel_MouseMove);
      this.panel.MouseWheel += new MouseEventHandler(this.panel_MouseWheel);
      int width = 20;
      int height = 20;
      for (int index = 0; index < 2; ++index)
      {
        this._checkBoxBitmap[index] = new Bitmap(width, height);
        using (Graphics graphics = Graphics.FromImage((Image) this._checkBoxBitmap[index]))
        {
          graphics.Clear(Color.Transparent);
          if (VisualStyleRenderer.IsSupported)
            CheckBoxRenderer.DrawCheckBox(graphics, new Point(0, 0), index == 0 ? CheckBoxState.UncheckedNormal : CheckBoxState.CheckedNormal);
          else if (index == 0)
            ControlPaint.DrawCheckBox(graphics, 0, 0, width, height, ButtonState.Normal);
          else
            ControlPaint.DrawCheckBox(graphics, 0, 0, width, height, ButtonState.Checked);
        }
      }
    }

    private void RenewalTitleCount()
    {
      this.textBox_TitleCount.Text = SaveDataManager.Instance.SaveData.TitleData.TitleCount.ToString();
    }

    private int CheckBoxHitTest(int x, int y)
    {
      if (x < 40 || y < 20)
        return -1;
      x -= 40;
      y -= 20;
      if (x % 200 > 160 || y % 35 > 30)
        return -1;
      int num1 = x / 200;
      int num2 = y / 35;
      return num1 >= 3 || num2 >= 10 ? -1 : num2 * 3 + num1;
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

    private void panel_MouseDown(object sender, MouseEventArgs e)
    {
      int index1 = this.CheckBoxHitTest(e.X, e.Y);
      if (index1 == -1)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      int index2 = this._vScrollBar.Value * 3 + index1;
      this._checkBox_Checked[index1] = !this._checkBox_Checked[index1];
      this.DrawCheckBox((Graphics) null, index1, this._checkBox_Checked[index1] ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot);
      SaveDataManager.Instance.SaveData.TitleData.SetTitleHold(index2, this._checkBox_Checked[index1]);
      if (this._reviseCount)
      {
        if (this._checkBox_Checked[index1])
          ++SaveDataManager.Instance.SaveData.TitleData.TitleCount;
        else
          --SaveDataManager.Instance.SaveData.TitleData.TitleCount;
      }
      else
        SaveDataManager.Instance.SaveData.TitleData.ReviseTitleCount();
      this.RenewalTitleCount();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
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

    private void CheckBox_TitleHold_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected override void OnDataFileLoad() => this._reviseCount = false;

    protected override void OnValueUpdate()
    {
      this.BeginUpdate();
      TitleData titleData = SaveDataManager.Instance.SaveData.TitleData;
      int index1 = 0;
      int index2 = this._vScrollBar.Value * 3;
      for (int index3 = 0; index3 < 10; ++index3)
      {
        for (int index4 = 0; index4 < 3; ++index4)
        {
          if (index2 < TitleDataList.List.Count)
            this._checkBox_Checked[index1] = titleData.IsTitleHold(index2);
          ++index1;
          ++index2;
        }
      }
      this.panelPaint();
      this.RenewalTitleCount();
      this.EndUpdate();
    }

    private void panel_Paint(object sender, PaintEventArgs e) => this.panelPaint(e.Graphics);

    private void panelPaint()
    {
      using (Graphics panelGraphics = Graphics.FromHwnd(this.panel.Handle))
        this.panelPaint(panelGraphics);
    }

    private void panelPaint(Graphics panelGraphics)
    {
      using (Graphics g = Graphics.FromImage((Image) this._panelBitmap))
      {
        using (Brush brush1 = (Brush) new SolidBrush(this.ForeColor))
        {
          using (Brush brush2 = (Brush) new SolidBrush(SystemColors.ControlLight))
          {
            using (Brush brush3 = (Brush) new SolidBrush(SystemColors.Control))
            {
              g.FillRectangle(brush3, new Rectangle(0, 0, this.panel.Width, 20));
              g.FillRectangle(brush2, new Rectangle(0, this.panel.Height - 20, this.panel.Width, this.panel.Height));
              int index1 = this._vScrollBar.Value < this._vScrollBar.Maximum - this._vScrollBar.LargeChange ? this._vScrollBar.Value * 3 : (this._vScrollBar.Maximum - this._vScrollBar.LargeChange - 1) * 3;
              int index2 = 0;
              int y = 25;
              for (int index3 = 0; index3 < 10; ++index3)
              {
                g.FillRectangle((index3 & 1) == 0 ? brush2 : brush3, new Rectangle(0, 20 + index3 * 35, this.panel.Width, 35));
                int x = 58;
                for (int index4 = 0; index4 < 3; ++index4)
                {
                  if (index1 < TitleDataList.List.Count)
                  {
                    TitleElement titleElement = TitleDataList.List[index1];
                    g.DrawString(titleElement.MaleTitleName, this.Font, brush1, (float) x, (float) y);
                    g.DrawString(titleElement.LadyTitleName, this.Font, brush1, (float) x, (float) (y + 14));
                    this.DrawCheckBox(g, index2, this._checkBox_Checked[index2] ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
                  }
                  x += 200;
                  ++index1;
                  ++index2;
                }
                y += 35;
              }
            }
          }
        }
      }
      panelGraphics.DrawImage((Image) this._panelBitmap, Point.Empty);
    }

    private void textBox_Dummy_KeyDown(object sender, KeyEventArgs e)
    {
      this.BeginUpdate();
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
      if (this._vScrollBar.Value != this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 2)
      {
        if (e.KeyCode == Keys.End)
        {
          this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange - 1;
          this.OnValueUpdate();
        }
        else if (e.KeyCode == Keys.Next)
        {
          if (this._vScrollBar.Value + (this._vScrollBar.LargeChange - 1) > this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1))
            this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange - 1;
          else
            this._vScrollBar.Value += this._vScrollBar.LargeChange - 1;
          this.OnValueUpdate();
        }
      }
      this.EndUpdate();
    }

    public void DrawCheckBox(Graphics g, int index, CheckBoxState state)
    {
      int x = 40 + 200 * (index % 3);
      int y = 32 + 35 * (index / 3);
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
      }
    }

    private void RenewalScrollBar()
    {
      this._vScrollBar.Value = 0;
      this._vScrollBar.Maximum = TitleDataList.List.Count / 3;
      if (TitleDataList.List.Count % 3 != 0)
        ++this._vScrollBar.Maximum;
      this._vScrollBar.LargeChange = 9;
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      if (this._vScrollBar.Value > this._vScrollBar.Maximum - this._vScrollBar.LargeChange - 1)
        this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange - 1;
      this.textBox_Dummy.Focus();
      this.OnValueUpdate();
    }

    private void TitleDataControl_Click(object sender, EventArgs e) => this.textBox_Dummy.Focus();

    private void panel_Click(object sender, EventArgs e) => this.textBox_Dummy.Focus();

    private void button_AllCheck_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      for (int index = 0; index < TitleDataList.List.Count; ++index)
        SaveDataManager.Instance.SaveData.TitleData.SetTitleHold(index, true);
      SaveDataManager.Instance.SaveData.TitleData.TitleCount = (ushort) TitleDataList.List.Count;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.OnValueUpdate();
    }

    private void button_AllUncheck_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      for (int index = 0; index < TitleDataList.List.Count; ++index)
        SaveDataManager.Instance.SaveData.TitleData.SetTitleHold(index, false);
      SaveDataManager.Instance.SaveData.TitleData.TitleCount = (ushort) 0;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.OnValueUpdate();
    }
  }
}
