// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.ItemCollectionDataControl
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
  public class ItemCollectionDataControl : DataControlBase
  {
    private const int ControlMarginLeft = 30;
    private const int ControlMarginTop = 8;
    private const int ControlMarginWidth = 60;
    private const int ControlMarginHeight = 0;
    private const int Horizontal = 4;
    private const int Vertical = 12;
    private const int ControlCount = 48;
    private const int CheckBox_Width = 130;
    private const int CheckBox_Height = 30;
    private IContainer components;
    private DoubleBufferedPanel panel;
    private VScrollBar _vScrollBar;
    private Label label_TitleCount;
    private System.Windows.Forms.TextBox textBox_Dummy;
    private System.Windows.Forms.Button button_AllCheck;
    private System.Windows.Forms.Button button_AllUncheck;
    private System.Windows.Forms.ComboBox comboBox_SelectType;
    private Label label1;
    private Label label_CompRate;
    private Label label_CollectionCount;
    private bool[] _checkBox_Checked = new bool[48];
    private Bitmap _panelBitmap;
    private Bitmap[] _checkBoxBitmap = new Bitmap[2];
    private int _lastMouseOverIndex;
    private ItemDataBase[] _itemList;

    public ItemCollectionDataControl()
    {
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      this.Disposed += new EventHandler(this.ItemCollectionDataControl_Disposed);
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
      this.button_AllCheck = new System.Windows.Forms.Button();
      this.button_AllUncheck = new System.Windows.Forms.Button();
      this.comboBox_SelectType = new System.Windows.Forms.ComboBox();
      this.label1 = new Label();
      this.label_CompRate = new Label();
      this.label_CollectionCount = new Label();
      this.panel.SuspendLayout();
      this.SuspendLayout();
      this.panel.BorderStyle = BorderStyle.Fixed3D;
      this.panel.Controls.Add((Control) this.textBox_Dummy);
      this.panel.Controls.Add((Control) this._vScrollBar);
      this.panel.Location = new Point(14, 56);
      this.panel.Name = "panel";
      this.panel.Size = new Size(806, 373);
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
      this._vScrollBar.Location = new Point(785, 0);
      this._vScrollBar.Name = "_vScrollBar";
      this._vScrollBar.Size = new Size(17, 369);
      this._vScrollBar.TabIndex = 0;
      this._vScrollBar.ValueChanged += new EventHandler(this._vScrollBar_ValueChanged);
      this._vScrollBar.Scroll += new ScrollEventHandler(this._vScrollBar_Scroll);
      this.label_TitleCount.AutoSize = true;
      this.label_TitleCount.Location = new Point(141, 34);
      this.label_TitleCount.Name = "label_TitleCount";
      this.label_TitleCount.Size = new Size(48, 12);
      this.label_TitleCount.TabIndex = 1;
      this.label_TitleCount.Text = "Amount:";
      this.button_AllCheck.Location = new Point(548, 27);
      this.button_AllCheck.Name = "button_AllCheck";
      this.button_AllCheck.Size = new Size(133, 23);
      this.button_AllCheck.TabIndex = 4;
      this.button_AllCheck.Text = "Check all";
      this.button_AllCheck.UseVisualStyleBackColor = true;
      this.button_AllCheck.Click += new EventHandler(this.button_AllCheck_Click);
      this.button_AllUncheck.Location = new Point(687, 27);
      this.button_AllUncheck.Name = "button_AllUncheck";
      this.button_AllUncheck.Size = new Size(133, 23);
      this.button_AllUncheck.TabIndex = 5;
      this.button_AllUncheck.Text = "Uncheck all";
      this.button_AllUncheck.UseVisualStyleBackColor = true;
      this.button_AllUncheck.Click += new EventHandler(this.button_AllUncheck_Click);
      this.comboBox_SelectType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_SelectType.FormattingEnabled = true;
      this.comboBox_SelectType.Items.AddRange(new object[3]
      {
        (object) "All",
        (object) "Items",
        (object) "Important items"
      });
      this.comboBox_SelectType.Location = new Point(14, 30);
      this.comboBox_SelectType.Name = "comboBox_SelectType";
      this.comboBox_SelectType.Size = new Size(121, 20);
      this.comboBox_SelectType.TabIndex = 6;
      this.comboBox_SelectType.SelectedIndexChanged += new EventHandler(this.comboBox_SelectType_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(13, 11);
      this.label1.Name = "label1";
      this.label1.Size = new Size(128, 12);
      this.label1.TabIndex = 7;
      this.label1.Text = "Completion Rate";
      this.label_CompRate.AutoSize = true;
      this.label_CompRate.Location = new Point(141, 11);
      this.label_CompRate.Name = "label_CompRate";
      this.label_CompRate.Size = new Size(17, 12);
      this.label_CompRate.TabIndex = 8;
      this.label_CompRate.Text = "0%";
      this.label_CollectionCount.AutoSize = true;
      this.label_CollectionCount.Location = new Point(195, 34);
      this.label_CollectionCount.Name = "label_CollectionCount";
      this.label_CollectionCount.Size = new Size(35, 12);
      this.label_CollectionCount.TabIndex = 9;
      this.label_CollectionCount.Text = "0 types";
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.label_CollectionCount);
      this.Controls.Add((Control) this.label_CompRate);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.comboBox_SelectType);
      this.Controls.Add((Control) this.button_AllUncheck);
      this.Controls.Add((Control) this.button_AllCheck);
      this.Controls.Add((Control) this.label_TitleCount);
      this.Controls.Add((Control) this.panel);
      this.Name = nameof (ItemCollectionDataControl);
      this.Size = new Size(887, 500);
      this.Click += new EventHandler(this.ItemCollectionDataControl_Click);
      this.panel.ResumeLayout(false);
      this.panel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void ItemCollectionDataControl_Disposed(object sender, EventArgs e)
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
      this.BeginUpdate();
      this.comboBox_SelectType.SelectedIndex = 0;
      for (int index = 0; index < 48; ++index)
        this._checkBox_Checked[index] = false;
      this._panelBitmap = new Bitmap(this.panel.Width, this.panel.Height);
      this.panel.MouseMove += new MouseEventHandler(this.panel_MouseMove);
      this.panel.MouseWheel += new MouseEventHandler(this.panel_MouseWheel);
      using (Graphics.FromHwnd(this.Handle))
      {
        for (int index = 0; index < 2; ++index)
        {
          int width = 20;
          int height = 20;
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
      this.EndUpdate();
    }

    private void RenewalCollectionCount()
    {
      ItemCollectionData itemCollectionData = SaveDataManager.Instance.SaveData.ItemCollectionData;
      int num1 = 0;
      foreach (ItemDataBase itemDataBase in this._itemList)
      {
        if (itemDataBase.DataIndex != -1 && itemCollectionData.IsItemCollectionHold(itemDataBase.DataIndex))
          ++num1;
      }
      this.label_CollectionCount.Text = string.Format("{0} Types", (object) num1);
      int num2 = (int) ((double) itemCollectionData.CompCount / 232.0 * 100.0);
      if (num2 == 0 && itemCollectionData.CompCount > (ushort) 0)
        num2 = 1;
      this.label_CompRate.Text = string.Format("{0}%", (object) num2);
    }

    private int CheckBoxHitTest(int x, int y)
    {
      if (x < 30)
        return -1;
      x -= 30;
      if (x % 190 > 130 || y % 30 > 30)
        return -1;
      int num1 = x / 190;
      int num2 = y / 30;
      if (num1 >= 4 || num2 >= 12)
        return -1;
      int index = num2 * 4 + num1;
      return index + this._vScrollBar.Value * 4 < this._itemList.Length && this._itemList[index].DataIndex != -1 ? index : -1;
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
      int index2 = this._vScrollBar.Value * 4 + index1;
      if (this._itemList[index2].DataIndex == -1)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this._checkBox_Checked[index1] = !this._checkBox_Checked[index1];
      this.DrawCheckBox((Graphics) null, index1, this._checkBox_Checked[index1] ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot);
      ItemCollectionData itemCollectionData = SaveDataManager.Instance.SaveData.ItemCollectionData;
      itemCollectionData.SetItemCollectionHold(this._itemList[index2].DataIndex, this._checkBox_Checked[index1]);
      itemCollectionData.ReviseCompCount();
      this.RenewalCollectionCount();
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

    protected override void OnDataFileLoad()
    {
    }

    protected override void OnValueUpdate()
    {
      this.BeginUpdate();
      this.SetItemCollectionData();
      this.panelPaint();
      this.RenewalCollectionCount();
      this.EndUpdate();
    }

    private void SetItemCollectionData()
    {
      ItemCollectionData itemCollectionData = SaveDataManager.Instance.SaveData.ItemCollectionData;
      int index1 = 0;
      int index2 = this._vScrollBar.Value * 4;
      for (int index3 = 0; index3 < 12; ++index3)
      {
        for (int index4 = 0; index4 < 4; ++index4)
        {
          if (index2 < this._itemList.Length && this._itemList[index2].DataIndex != -1)
            this._checkBox_Checked[index1] = itemCollectionData.IsItemCollectionHold(this._itemList[index2].DataIndex);
          ++index1;
          ++index2;
        }
      }
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
              g.FillRectangle(brush3, new Rectangle(0, 0, this._panelBitmap.Width, this._panelBitmap.Height));
              int index1 = this._vScrollBar.Value <= this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1 ? this._vScrollBar.Value * 4 : (this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1) * 4;
              if (index1 < 0)
                index1 = 0;
              int index2 = 0;
              int y = 8;
              for (int index3 = 0; index3 < 12; ++index3)
              {
                if ((index3 & 1) == 1)
                  g.FillRectangle(brush2, new Rectangle(0, index3 * 30, this.panel.Width, 30));
                int x = 48;
                for (int index4 = 0; index4 < 4; ++index4)
                {
                  if (index1 < this._itemList.Length && this._itemList[index1].DataIndex != -1)
                  {
                    ItemDataBase itemDataBase = this._itemList[index1];
                    g.DrawString(itemDataBase.Name, this.Font, brush1, (float) x, (float) y);
                    this.DrawCheckBox(g, index2, this._checkBox_Checked[index2] ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
                  }
                  x += 190;
                  ++index1;
                  ++index2;
                }
                y += 30;
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
          if (this._vScrollBar.Value - this._vScrollBar.LargeChange < this._vScrollBar.Minimum)
            this._vScrollBar.Value = this._vScrollBar.Minimum;
          else
            this._vScrollBar.Value -= this._vScrollBar.LargeChange;
          this.OnValueUpdate();
        }
      }
      if (this._vScrollBar.Value != this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1)
      {
        if (e.KeyCode == Keys.End)
        {
          this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1;
          this.OnValueUpdate();
        }
        else if (e.KeyCode == Keys.Next)
        {
          if (this._vScrollBar.Value + this._vScrollBar.LargeChange > this._vScrollBar.Maximum - this._vScrollBar.LargeChange)
            this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1;
          else
            this._vScrollBar.Value += this._vScrollBar.LargeChange;
          this.OnValueUpdate();
        }
      }
      this.EndUpdate();
    }

    public void DrawCheckBox(Graphics g, int index, CheckBoxState state)
    {
      int x = 30 + 190 * (index % 4);
      int y = 8 + 30 * (index / 4);
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
      int length = this._itemList.Length;
      if (this.comboBox_SelectType.SelectedIndex == 1)
        length -= 2;
      this._vScrollBar.Value = 0;
      this._vScrollBar.Maximum = length / 4 - 1;
      if (length % 4 != 0)
        ++this._vScrollBar.Maximum;
      this._vScrollBar.LargeChange = 12;
      if (this._vScrollBar.Maximum < this._vScrollBar.LargeChange)
        this._vScrollBar.Visible = false;
      else
        this._vScrollBar.Visible = true;
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.BeginUpdate();
      if (this._vScrollBar.Value > this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1)
      {
        int num = this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1;
        if (num < 0)
          num = 0;
        this._vScrollBar.Value = num;
      }
      this.textBox_Dummy.Focus();
      this.OnValueUpdate();
      this.EndUpdate();
    }

    private void ItemCollectionDataControl_Click(object sender, EventArgs e)
    {
      this.textBox_Dummy.Focus();
    }

    private void panel_Click(object sender, EventArgs e) => this.textBox_Dummy.Focus();

    private void button_AllCheck_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      for (int index = 0; index < this._itemList.Length; ++index)
      {
        if (this._itemList[index].DataIndex != -1)
          SaveDataManager.Instance.SaveData.ItemCollectionData.SetItemCollectionHold(this._itemList[index].DataIndex, true);
      }
      SaveDataManager.Instance.SaveData.ItemCollectionData.ReviseCompCount();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.OnValueUpdate();
    }

    private void button_AllUncheck_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      for (int index = 0; index < this._itemList.Length; ++index)
      {
        if (this._itemList[index].DataIndex != -1)
          SaveDataManager.Instance.SaveData.ItemCollectionData.SetItemCollectionHold(this._itemList[index].DataIndex, false);
      }
      SaveDataManager.Instance.SaveData.ItemCollectionData.ReviseCompCount();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.OnValueUpdate();
    }

    private void comboBox_SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
      int selectedIndex = this.comboBox_SelectType.SelectedIndex;
      this._itemList = selectedIndex != 0 ? ItemDataList.GetList((ItemType) (selectedIndex - 1), (string) null) : ItemDataList.GetAllCollectionList();
      this.RenewalScrollBar();
      if (this._updateCount != 0)
        return;
      this.SetItemCollectionData();
      this.panelPaint();
      this.RenewalCollectionCount();
    }

    private void _vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
      if (e.Type == ScrollEventType.LargeDecrement)
      {
        if (e.OldValue - e.NewValue < this._vScrollBar.LargeChange)
          return;
        ++e.NewValue;
      }
      else
      {
        if (e.Type != ScrollEventType.LargeIncrement || e.NewValue - e.OldValue < this._vScrollBar.LargeChange)
          return;
        --e.NewValue;
      }
    }
  }
}
