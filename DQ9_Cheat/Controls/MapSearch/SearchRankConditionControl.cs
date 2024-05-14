// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchRankConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.MapSearch;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls.MapSearch
{
  public class SearchRankConditionControl : SearchConditionControlBase
  {
    private IContainer components;
    private ComboBox comboBox_Rank;
    private ComboBox comboBox_SearchCondition;
    private SearchMapRankCondition _condition;

    public SearchRankConditionControl()
    {
      this.InitializeComponent();
      this.comboBox_Rank.SelectedIndex = 0;
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
      this.comboBox_Rank = new ComboBox();
      this.comboBox_SearchCondition = new ComboBox();
      this.SuspendLayout();
      this.comboBox_Rank.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Rank.FormattingEnabled = true;
      this.comboBox_Rank.Items.AddRange(new object[12]
      {
        (object) "02",
        (object) "38",
        (object) "3D",
        (object) "4C",
        (object) "51",
        (object) "65",
        (object) "79",
        (object) "8D",
        (object) "A1",
        (object) "B5",
        (object) "C9",
        (object) "DD"
      });
      this.comboBox_Rank.Location = new Point(16, 16);
      this.comboBox_Rank.Name = "comboBox_Rank";
      this.comboBox_Rank.Size = new Size(73, 20);
      this.comboBox_Rank.TabIndex = 0;
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
      this.comboBox_SearchCondition.TabIndex = 1;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.comboBox_SearchCondition);
      this.Controls.Add((Control) this.comboBox_Rank);
      this.Name = nameof (SearchRankConditionControl);
      this.Size = new Size(199, 45);
      this.ResumeLayout(false);
    }

    public override SearchConditionBase GetCondition()
    {
      if (this._condition == null)
        this._condition = new SearchMapRankCondition();
      this._condition.RankIndex = this.comboBox_Rank.SelectedIndex;
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
      this._condition = condition as SearchMapRankCondition;
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
      this.comboBox_Rank.SelectedIndex = this._condition.RankIndex;
    }
  }
}
