// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.TreasureBoxItemTableList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls;

internal class TreasureBoxItemTableList : Form
{
    private readonly int _boxIndex;
    private readonly int _floor;
    private readonly TreasureMapDetailData _mapDetailData;
    private Button button_Close;
    private IContainer components;
    private Label label1;
    private NumericUpDown numericUpDown_Second;
    private TextBox textBox_ItemList;

    public TreasureBoxItemTableList(TreasureMapData mapData, int floor, int boxIndex)
    {
        InitializeComponent();
        _mapDetailData = mapData.TreasureMapDetailData;
        _floor = floor;
        _boxIndex = boxIndex;
        RenewalList();
    }

    public TreasureBoxItemTableList(TreasureMapDetailData detailData, int floor, int boxIndex)
    {
        InitializeComponent();
        _mapDetailData = detailData;
        _floor = floor;
        _boxIndex = boxIndex;
        RenewalList();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        numericUpDown_Second = new NumericUpDown();
        label1 = new Label();
        button_Close = new Button();
        textBox_ItemList = new TextBox();
        numericUpDown_Second.BeginInit();
        SuspendLayout();
        numericUpDown_Second.Location = new Point(12, 5);
        numericUpDown_Second.Maximum = new decimal(new int[4]
        {
            10000,
            0,
            0,
            0
        });
        numericUpDown_Second.Minimum = new decimal(new int[4]
        {
            7,
            0,
            0,
            0
        });
        numericUpDown_Second.Name = "numericUpDown_Second";
        numericUpDown_Second.Size = new Size(81, 19);
        numericUpDown_Second.TabIndex = 0;
        numericUpDown_Second.Value = new decimal(new int[4]
        {
            260,
            0,
            0,
            0
        });
        numericUpDown_Second.ValueChanged += numericUpDown_Second_ValueChanged;
        label1.AutoSize = true;
        label1.Location = new Point(99, 9);
        label1.Name = "label1";
        label1.Size = new Size(36, 12);
        label1.TabIndex = 1;
        label1.Text = "Probable Items";
        button_Close.DialogResult = DialogResult.Cancel;
        button_Close.Location = new Point(167, 351);
        button_Close.Name = "button_Close";
        button_Close.Size = new Size(75, 23);
        button_Close.TabIndex = 3;
        button_Close.Text = "Close";
        button_Close.UseVisualStyleBackColor = true;
        textBox_ItemList.BackColor = SystemColors.Window;
        textBox_ItemList.Font = new Font("Consolas", 9f, GraphicsUnit.Point);
        textBox_ItemList.Location = new Point(12, 30);
        textBox_ItemList.Multiline = true;
        textBox_ItemList.Name = "textBox_ItemList";
        textBox_ItemList.ReadOnly = true;
        textBox_ItemList.ScrollBars = ScrollBars.Vertical;
        textBox_ItemList.Size = new Size(230, 315);
        textBox_ItemList.TabIndex = 4;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = button_Close;
        ClientSize = new Size(246, 380);
        Controls.Add(textBox_ItemList);
        Controls.Add(button_Close);
        Controls.Add(label1);
        Controls.Add(numericUpDown_Second);
        FormBorderStyle = FormBorderStyle.SizableToolWindow;
        MaximizeBox = false;
        MaximumSize = new Size(262, 1000);
        MinimizeBox = false;
        MinimumSize = new Size(262, 406);
        Name = nameof(TreasureBoxItemTableList);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Items";
        Resize += TreasureBoxItemTableList_Resize;
        numericUpDown_Second.EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private void RenewalList()
    {
        if (_mapDetailData == null)
            return;
        var stringBuilder = new StringBuilder();
        textBox_ItemList.Text = string.Empty;
        var num1 = (int)numericUpDown_Second.Value;
        var length1 = num1.ToString().Length;
        var num2 = num1 - 5;
        string strB = null;
        for (var second = 2; second <= num2; ++second)
        {
            var treasureBoxItem = _mapDetailData.GetTreasureBoxItem(_floor, _boxIndex, second);
            if (strB == null || treasureBoxItem.CompareTo(strB) != 0)
            {
                var length2 = (second + 5).ToString().Length;
                for (var index = 0; index < length1 - length2; ++index)
                    stringBuilder.Append(" ");
                if (second == 2)
                    stringBuilder.AppendFormat("    {0}", treasureBoxItem);
                else
                    stringBuilder.AppendFormat("{0}s: {1}", second + 5, treasureBoxItem);
                stringBuilder.AppendLine();
            }

            strB = treasureBoxItem;
        }

        textBox_ItemList.Text = stringBuilder.ToString();
    }

    private void TreasureBoxItemTableList_Resize(object sender, EventArgs e)
    {
        button_Close.Top = ClientRectangle.Height - button_Close.Height - 4;
        textBox_ItemList.Height = ClientRectangle.Height - textBox_ItemList.Top -
                                  (ClientRectangle.Height - button_Close.Top) - 8;
    }

    private void numericUpDown_Second_ValueChanged(object sender, EventArgs e)
    {
        RenewalList();
    }
}