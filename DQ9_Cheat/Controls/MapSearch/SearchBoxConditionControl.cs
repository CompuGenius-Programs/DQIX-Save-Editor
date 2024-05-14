// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchBoxConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.MapSearch;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls.MapSearch
{
  public class SearchBoxConditionControl : SearchConditionControlBase
  {
    private SearchBoxConditioin _condition;
    private IContainer components;
    private ComboBox comboBox_SearchCondition;
    private ComboBox comboBox_BoxType;
    private NumericUpDown numericUpDown_BoxCount;

    public SearchBoxConditionControl()
    {
      this.InitializeComponent();
      this.comboBox_BoxType.SelectedIndex = 0;
      this.comboBox_SearchCondition.SelectedIndex = 0;
      this.numericUpDown_BoxCount.Value = 0M;
    }

    public override SearchConditionBase GetCondition()
    {
      if (this._condition == null)
        this._condition = new SearchBoxConditioin();
      this._condition.BoxType = this.comboBox_BoxType.SelectedIndex;
      switch (this.comboBox_SearchCondition.SelectedIndex)
      {
        case 0:
          this._condition.ConditionType = SearchConditionType.Accord;
          break;
        case 1:
          this._condition.ConditionType = SearchConditionType.Discord;
          break;
        case 2:
          this._condition.ConditionType = SearchConditionType.AndOver;
          break;
        case 3:
          this._condition.ConditionType = SearchConditionType.AndLess;
          break;
      }
      this._condition.BoxCount = (int) this.numericUpDown_BoxCount.Value;
      return (SearchConditionBase) this._condition;
    }

    public override void SetCondition(SearchConditionBase condition)
    {
      this._condition = condition as SearchBoxConditioin;
      if (this._condition == null)
        return;
      this.comboBox_BoxType.SelectedIndex = this._condition.BoxType;
      switch (this._condition.ConditionType)
      {
        case SearchConditionType.Accord:
          this.comboBox_SearchCondition.SelectedIndex = 0;
          break;
        case SearchConditionType.Discord:
          this.comboBox_SearchCondition.SelectedIndex = 1;
          break;
        case SearchConditionType.AndOver:
          this.comboBox_SearchCondition.SelectedIndex = 2;
          break;
        case SearchConditionType.AndLess:
          this.comboBox_SearchCondition.SelectedIndex = 3;
          break;
      }
      this.numericUpDown_BoxCount.Value = (Decimal) this._condition.BoxCount;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.comboBox_SearchCondition = new ComboBox();
      this.comboBox_BoxType = new ComboBox();
      this.numericUpDown_BoxCount = new NumericUpDown();
      this.numericUpDown_BoxCount.BeginInit();
      this.SuspendLayout();
      this.comboBox_SearchCondition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_SearchCondition.FormattingEnabled = true;
      this.comboBox_SearchCondition.Items.AddRange(new object[4]
      {
        (object) "Equals",
        (object) "Not equals",
        (object) "At least",
        (object) "Up to"
      });
      this.comboBox_SearchCondition.Location = new Point(175, 17);
      this.comboBox_SearchCondition.Name = "comboBox_SearchCondition";
      this.comboBox_SearchCondition.Size = new Size(78, 20);
      this.comboBox_SearchCondition.TabIndex = 6;
      this.comboBox_BoxType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_BoxType.FormattingEnabled = true;
      this.comboBox_BoxType.Items.AddRange(new object[11]
      {
        (object) "Total",
        (object) "S Rank",
        (object) "A Rank",
        (object) "B Rank",
        (object) "C Rank",
        (object) "D Rank",
        (object) "E Rank",
        (object) "F Rank",
        (object) "G Rank",
        (object) "H Rank",
        (object) "I Rank"
      });
      this.comboBox_BoxType.Location = new Point(16, 16);
      this.comboBox_BoxType.Name = "comboBox_BoxType";
      this.comboBox_BoxType.Size = new Size(73, 20);
      this.comboBox_BoxType.TabIndex = 7;
      this.numericUpDown_BoxCount.Location = new Point(94, 17);
      this.numericUpDown_BoxCount.Maximum = new Decimal(new int[4]
      {
        40,
        0,
        0,
        0
      });
      this.numericUpDown_BoxCount.Name = "numericUpDown_BoxCount";
      this.numericUpDown_BoxCount.Size = new Size(75, 19);
      this.numericUpDown_BoxCount.TabIndex = 8;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.numericUpDown_BoxCount);
      this.Controls.Add((Control) this.comboBox_BoxType);
      this.Controls.Add((Control) this.comboBox_SearchCondition);
      this.Name = nameof (SearchBoxConditionControl);
      this.Size = new Size(261, 51);
      this.numericUpDown_BoxCount.EndInit();
      this.ResumeLayout(false);
    }
  }
}
