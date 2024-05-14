// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchBoxConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

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
      InitializeComponent();
      comboBox_BoxType.SelectedIndex = 0;
      comboBox_SearchCondition.SelectedIndex = 0;
      numericUpDown_BoxCount.Value = 0M;
    }

    public override SearchConditionBase GetCondition()
    {
      if (_condition == null)
        _condition = new SearchBoxConditioin();
      _condition.BoxType = comboBox_BoxType.SelectedIndex;
      switch (comboBox_SearchCondition.SelectedIndex)
      {
        case 0:
          _condition.ConditionType = SearchConditionType.Accord;
          break;
        case 1:
          _condition.ConditionType = SearchConditionType.Discord;
          break;
        case 2:
          _condition.ConditionType = SearchConditionType.AndOver;
          break;
        case 3:
          _condition.ConditionType = SearchConditionType.AndLess;
          break;
      }
      _condition.BoxCount = (int) numericUpDown_BoxCount.Value;
      return _condition;
    }

    public override void SetCondition(SearchConditionBase condition)
    {
      _condition = condition as SearchBoxConditioin;
      if (_condition == null)
        return;
      comboBox_BoxType.SelectedIndex = _condition.BoxType;
      switch (_condition.ConditionType)
      {
        case SearchConditionType.Accord:
          comboBox_SearchCondition.SelectedIndex = 0;
          break;
        case SearchConditionType.Discord:
          comboBox_SearchCondition.SelectedIndex = 1;
          break;
        case SearchConditionType.AndOver:
          comboBox_SearchCondition.SelectedIndex = 2;
          break;
        case SearchConditionType.AndLess:
          comboBox_SearchCondition.SelectedIndex = 3;
          break;
      }
      numericUpDown_BoxCount.Value = _condition.BoxCount;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      comboBox_SearchCondition = new ComboBox();
      comboBox_BoxType = new ComboBox();
      numericUpDown_BoxCount = new NumericUpDown();
      numericUpDown_BoxCount.BeginInit();
      SuspendLayout();
      comboBox_SearchCondition.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_SearchCondition.FormattingEnabled = true;
      comboBox_SearchCondition.Items.AddRange(new object[4]
      {
        "Equals",
        "Not equals",
        "At least",
        "Up to"
      });
      comboBox_SearchCondition.Location = new Point(175, 17);
      comboBox_SearchCondition.Name = "comboBox_SearchCondition";
      comboBox_SearchCondition.Size = new Size(78, 20);
      comboBox_SearchCondition.TabIndex = 6;
      comboBox_BoxType.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_BoxType.FormattingEnabled = true;
      comboBox_BoxType.Items.AddRange(new object[11]
      {
        "Total",
        "S Rank",
        "A Rank",
        "B Rank",
        "C Rank",
        "D Rank",
        "E Rank",
        "F Rank",
        "G Rank",
        "H Rank",
        "I Rank"
      });
      comboBox_BoxType.Location = new Point(16, 16);
      comboBox_BoxType.Name = "comboBox_BoxType";
      comboBox_BoxType.Size = new Size(73, 20);
      comboBox_BoxType.TabIndex = 7;
      numericUpDown_BoxCount.Location = new Point(94, 17);
      numericUpDown_BoxCount.Maximum = new Decimal(new int[4]
      {
        40,
        0,
        0,
        0
      });
      numericUpDown_BoxCount.Name = "numericUpDown_BoxCount";
      numericUpDown_BoxCount.Size = new Size(75, 19);
      numericUpDown_BoxCount.TabIndex = 8;
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(numericUpDown_BoxCount);
      Controls.Add(comboBox_BoxType);
      Controls.Add(comboBox_SearchCondition);
      Name = nameof (SearchBoxConditionControl);
      Size = new Size(261, 51);
      numericUpDown_BoxCount.EndInit();
      ResumeLayout(false);
    }
  }
}
