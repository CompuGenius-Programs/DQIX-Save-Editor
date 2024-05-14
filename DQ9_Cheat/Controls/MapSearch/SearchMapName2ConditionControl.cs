// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchMapName2ConditionControl
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
  public class SearchMapName2ConditionControl : SearchConditionControlBase
  {
    private SearchMapName2Conditioin _condition;
    private IContainer components;
    private ComboBox comboBox_SearchCondition;
    private ComboBox comboBox_Name2;

    public SearchMapName2ConditionControl()
    {
      this.InitializeComponent();
      this.comboBox_Name2.SelectedIndex = 0;
      this.comboBox_SearchCondition.SelectedIndex = 0;
    }

    public override SearchConditionBase GetCondition()
    {
      if (this._condition == null)
        this._condition = new SearchMapName2Conditioin();
      this._condition.Name2Index = this.comboBox_Name2.SelectedIndex;
      switch (this.comboBox_SearchCondition.SelectedIndex)
      {
        case 0:
          this._condition.ConditionType = SearchConditionType.Accord;
          break;
        case 1:
          this._condition.ConditionType = SearchConditionType.Discord;
          break;
      }
      return (SearchConditionBase) this._condition;
    }

    public override void SetCondition(SearchConditionBase condition)
    {
      this._condition = condition as SearchMapName2Conditioin;
      if (this._condition == null)
        return;
      this.comboBox_Name2.SelectedIndex = this._condition.Name2Index;
      switch (this._condition.ConditionType)
      {
        case SearchConditionType.Accord:
          this.comboBox_SearchCondition.SelectedIndex = 0;
          break;
        case SearchConditionType.Discord:
          this.comboBox_SearchCondition.SelectedIndex = 1;
          break;
      }
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
      this.comboBox_Name2 = new ComboBox();
      this.SuspendLayout();
      this.comboBox_SearchCondition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_SearchCondition.FormattingEnabled = true;
      this.comboBox_SearchCondition.Items.AddRange(new object[2]
      {
        (object) "Equals",
        (object) "Not equals"
      });
      this.comboBox_SearchCondition.Location = new Point(115, 16);
      this.comboBox_SearchCondition.Name = "comboBox_SearchCondition";
      this.comboBox_SearchCondition.Size = new Size(78, 20);
      this.comboBox_SearchCondition.TabIndex = 5;
      this.comboBox_Name2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Name2.FormattingEnabled = true;
      this.comboBox_Name2.Items.AddRange(new object[16]
      {
        (object) "Joy",
        (object) "Bliss",
        (object) "Glee",
        (object) "Doubt",
        (object) "Woe",
        (object) "Dolour",
        (object) "Regret",
        (object) "Bane",
        (object) "Fear",
        (object) "Dread",
        (object) "Hurt",
        (object) "Gloom",
        (object) "Doom",
        (object) "Evil",
        (object) "Ruin",
        (object) "Death"
      });
      this.comboBox_Name2.Location = new Point(16, 16);
      this.comboBox_Name2.Name = "comboBox_Name2";
      this.comboBox_Name2.Size = new Size(80, 20);
      this.comboBox_Name2.TabIndex = 4;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.comboBox_SearchCondition);
      this.Controls.Add((Control) this.comboBox_Name2);
      this.Name = nameof (SearchMapName2ConditionControl);
      this.Size = new Size(200, 46);
      this.ResumeLayout(false);
    }
  }
}
