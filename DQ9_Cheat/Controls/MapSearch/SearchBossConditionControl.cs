// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchBossConditionControl
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
  public class SearchBossConditionControl : SearchConditionControlBase
  {
    private IContainer components;
    private ComboBox comboBox_SearchCondition;
    private ComboBox comboBox_Boss;
    private SearchBossConditioin _condition;

    public SearchBossConditionControl()
    {
      this.InitializeComponent();
      this.comboBox_Boss.SelectedIndex = 0;
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
      this.comboBox_Boss = new ComboBox();
      this.SuspendLayout();
      this.comboBox_SearchCondition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_SearchCondition.FormattingEnabled = true;
      this.comboBox_SearchCondition.Items.AddRange(new object[2]
      {
        (object) "Equals",
        (object) "Not equals"
      });
      this.comboBox_SearchCondition.SetBounds(168, 16, 78, 20);
      this.comboBox_SearchCondition.Name = "comboBox_SearchCondition";
      this.comboBox_SearchCondition.TabIndex = 5;
      this.comboBox_Boss.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Boss.FormattingEnabled = true;
      this.comboBox_Boss.Items.AddRange(new object[12]
      {
        (object) "Equinox",
        (object) "Nemean",
        (object) "Shogum",
        (object) "Trauminator",
        (object) "Elusid",
        (object) "Sir Sanguinus",
        (object) "Atlas",
        (object) "Hammibal",
        (object) "Fowleye",
        (object) "Excalipurr",
        (object) "Tyrannosaurus Wrecks",
        (object) "Greygnarl"
      });
      this.comboBox_Boss.Location = new Point(16, 16);
      this.comboBox_Boss.Name = "comboBox_Boss";
      this.comboBox_Boss.Size = new Size(132, 20);
      this.comboBox_Boss.TabIndex = 4;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.comboBox_SearchCondition);
      this.Controls.Add((Control) this.comboBox_Boss);
      this.Name = nameof (SearchBossConditionControl);
      this.Size = new Size(257, 51);
      this.ResumeLayout(false);
    }

    public override SearchConditionBase GetCondition()
    {
      if (this._condition == null)
        this._condition = new SearchBossConditioin();
      this._condition.BossIndex = this.comboBox_Boss.SelectedIndex;
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
      this._condition = condition as SearchBossConditioin;
      if (this._condition == null)
        return;
      this.comboBox_Boss.SelectedIndex = this._condition.BossIndex;
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
  }
}
