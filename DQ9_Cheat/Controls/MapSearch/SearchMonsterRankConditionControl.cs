// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchMonsterRankConditionControl
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
  public class SearchMonsterRankConditionControl : SearchConditionControlBase
  {
    private IContainer components;
    private ComboBox comboBox_SearchCondition;
    private NumericUpDown numericUpDown_MonsterRank;
    private SearchMonsterRankConditioin _condition;

    public SearchMonsterRankConditionControl()
    {
      this.InitializeComponent();
      this.numericUpDown_MonsterRank.Value = this.numericUpDown_MonsterRank.Minimum;
      this.comboBox_SearchCondition.SelectedIndex = 0;
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
      this.numericUpDown_MonsterRank = new NumericUpDown();
      this.numericUpDown_MonsterRank.BeginInit();
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
      this.comboBox_SearchCondition.Location = new Point(115, 16);
      this.comboBox_SearchCondition.Name = "comboBox_SearchCondition";
      this.comboBox_SearchCondition.Size = new Size(78, 20);
      this.comboBox_SearchCondition.TabIndex = 3;
      this.numericUpDown_MonsterRank.Location = new Point(16, 16);
      this.numericUpDown_MonsterRank.Maximum = new Decimal(new int[4]
      {
        9,
        0,
        0,
        0
      });
      this.numericUpDown_MonsterRank.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_MonsterRank.Name = "numericUpDown_MonsterRank";
      this.numericUpDown_MonsterRank.Size = new Size(64, 19);
      this.numericUpDown_MonsterRank.TabIndex = 4;
      this.numericUpDown_MonsterRank.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.numericUpDown_MonsterRank);
      this.Controls.Add((Control) this.comboBox_SearchCondition);
      this.Name = nameof (SearchMonsterRankConditionControl);
      this.Size = new Size(209, 45);
      this.numericUpDown_MonsterRank.EndInit();
      this.ResumeLayout(false);
    }

    public override SearchConditionBase GetCondition()
    {
      if (this._condition == null)
        this._condition = new SearchMonsterRankConditioin();
      this._condition.MonsterRank = (int) this.numericUpDown_MonsterRank.Value;
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
      return (SearchConditionBase) this._condition;
    }

    public override void SetCondition(SearchConditionBase condition)
    {
      this._condition = condition as SearchMonsterRankConditioin;
      if (this._condition == null)
        return;
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
      this.numericUpDown_MonsterRank.Value = (Decimal) this._condition.MonsterRank;
    }
  }
}
