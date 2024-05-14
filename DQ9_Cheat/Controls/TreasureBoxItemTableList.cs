// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.TreasureBoxItemTableList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  internal class TreasureBoxItemTableList : Form
  {
    private IContainer components;
    private NumericUpDown numericUpDown_Second;
    private Label label1;
    private Button button_Close;
    private TextBox textBox_ItemList;
    private TreasureMapDetailData _mapDetailData;
    private int _floor;
    private int _boxIndex;

    public TreasureBoxItemTableList(TreasureMapData mapData, int floor, int boxIndex)
    {
      this.InitializeComponent();
      this._mapDetailData = mapData.TreasureMapDetailData;
      this._floor = floor;
      this._boxIndex = boxIndex;
      this.RenewalList();
    }

    public TreasureBoxItemTableList(TreasureMapDetailData detailData, int floor, int boxIndex)
    {
      this.InitializeComponent();
      this._mapDetailData = detailData;
      this._floor = floor;
      this._boxIndex = boxIndex;
      this.RenewalList();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.numericUpDown_Second = new NumericUpDown();
      this.label1 = new Label();
      this.button_Close = new Button();
      this.textBox_ItemList = new TextBox();
      this.numericUpDown_Second.BeginInit();
      this.SuspendLayout();
      this.numericUpDown_Second.Location = new Point(12, 5);
      this.numericUpDown_Second.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown_Second.Minimum = new Decimal(new int[4]
      {
        7,
        0,
        0,
        0
      });
      this.numericUpDown_Second.Name = "numericUpDown_Second";
      this.numericUpDown_Second.Size = new Size(81, 19);
      this.numericUpDown_Second.TabIndex = 0;
      this.numericUpDown_Second.Value = new Decimal(new int[4]
      {
        260,
        0,
        0,
        0
      });
      this.numericUpDown_Second.ValueChanged += new EventHandler(this.numericUpDown_Second_ValueChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(99, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(36, 12);
      this.label1.TabIndex = 1;
      this.label1.Text = "Probable Items";
      this.button_Close.DialogResult = DialogResult.Cancel;
      this.button_Close.Location = new Point(167, 351);
      this.button_Close.Name = "button_Close";
      this.button_Close.Size = new Size(75, 23);
      this.button_Close.TabIndex = 3;
      this.button_Close.Text = "Close";
      this.button_Close.UseVisualStyleBackColor = true;
      this.textBox_ItemList.BackColor = SystemColors.Window;
      this.textBox_ItemList.Font = new Font("Consolas", 9f, GraphicsUnit.Point);
      this.textBox_ItemList.Location = new Point(12, 30);
      this.textBox_ItemList.Multiline = true;
      this.textBox_ItemList.Name = "textBox_ItemList";
      this.textBox_ItemList.ReadOnly = true;
      this.textBox_ItemList.ScrollBars = ScrollBars.Vertical;
      this.textBox_ItemList.Size = new Size(230, 315);
      this.textBox_ItemList.TabIndex = 4;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button_Close;
      this.ClientSize = new Size(246, 380);
      this.Controls.Add((Control) this.textBox_ItemList);
      this.Controls.Add((Control) this.button_Close);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.numericUpDown_Second);
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.MaximizeBox = false;
      this.MaximumSize = new Size(262, 1000);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(262, 406);
      this.Name = nameof (TreasureBoxItemTableList);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Items";
      this.Resize += new EventHandler(this.TreasureBoxItemTableList_Resize);
      this.numericUpDown_Second.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void RenewalList()
    {
      if (this._mapDetailData == null)
        return;
      StringBuilder stringBuilder = new StringBuilder();
      this.textBox_ItemList.Text = string.Empty;
      int num1 = (int) this.numericUpDown_Second.Value;
      int length1 = num1.ToString().Length;
      int num2 = num1 - 5;
      string strB = (string) null;
      for (int second = 2; second <= num2; ++second)
      {
        string treasureBoxItem = this._mapDetailData.GetTreasureBoxItem(this._floor, this._boxIndex, second);
        if (strB == null || treasureBoxItem.CompareTo(strB) != 0)
        {
          int length2 = (second + 5).ToString().Length;
          for (int index = 0; index < length1 - length2; ++index)
            stringBuilder.Append(" ");
          if (second == 2)
            stringBuilder.AppendFormat("    {0}", (object) treasureBoxItem);
          else
            stringBuilder.AppendFormat("{0}s: {1}", (object) (second + 5), (object) treasureBoxItem);
          stringBuilder.AppendLine();
        }
        strB = treasureBoxItem;
      }
      this.textBox_ItemList.Text = stringBuilder.ToString();
    }

    private void TreasureBoxItemTableList_Resize(object sender, EventArgs e)
    {
      this.button_Close.Top = this.ClientRectangle.Height - this.button_Close.Height - 4;
      this.textBox_ItemList.Height = this.ClientRectangle.Height - this.textBox_ItemList.Top - (this.ClientRectangle.Height - this.button_Close.Top) - 8;
    }

    private void numericUpDown_Second_ValueChanged(object sender, EventArgs e)
    {
      this.RenewalList();
    }
  }
}
