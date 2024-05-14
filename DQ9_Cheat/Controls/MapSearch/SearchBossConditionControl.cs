// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchBossConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

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
      InitializeComponent();
      comboBox_Boss.SelectedIndex = 0;
      comboBox_SearchCondition.SelectedIndex = 0;
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
      comboBox_Boss = new ComboBox();
      SuspendLayout();
      comboBox_SearchCondition.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_SearchCondition.FormattingEnabled = true;
      comboBox_SearchCondition.Items.AddRange(new object[2]
      {
        "Equals",
        "Not equals"
      });
      comboBox_SearchCondition.SetBounds(168, 16, 78, 20);
      comboBox_SearchCondition.Name = "comboBox_SearchCondition";
      comboBox_SearchCondition.TabIndex = 5;
      comboBox_Boss.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_Boss.FormattingEnabled = true;
      comboBox_Boss.Items.AddRange(new object[12]
      {
        "Equinox",
        "Nemean",
        "Shogum",
        "Trauminator",
        "Elusid",
        "Sir Sanguinus",
        "Atlas",
        "Hammibal",
        "Fowleye",
        "Excalipurr",
        "Tyrannosaurus Wrecks",
        "Greygnarl"
      });
      comboBox_Boss.Location = new Point(16, 16);
      comboBox_Boss.Name = "comboBox_Boss";
      comboBox_Boss.Size = new Size(132, 20);
      comboBox_Boss.TabIndex = 4;
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(comboBox_SearchCondition);
      Controls.Add(comboBox_Boss);
      Name = nameof (SearchBossConditionControl);
      Size = new Size(257, 51);
      ResumeLayout(false);
    }

    public override SearchConditionBase GetCondition()
    {
      if (_condition == null)
        _condition = new SearchBossConditioin();
      _condition.BossIndex = comboBox_Boss.SelectedIndex;
      switch (comboBox_SearchCondition.SelectedIndex)
      {
        case 0:
          _condition.ConditionType = SearchConditionType.Accord;
          break;
        case 1:
          _condition.ConditionType = SearchConditionType.Discord;
          break;
      }
      return _condition;
    }

    public override void SetCondition(SearchConditionBase condition)
    {
      _condition = condition as SearchBossConditioin;
      if (_condition == null)
        return;
      comboBox_Boss.SelectedIndex = _condition.BossIndex;
      switch (_condition.ConditionType)
      {
        case SearchConditionType.Accord:
          comboBox_SearchCondition.SelectedIndex = 0;
          break;
        case SearchConditionType.Discord:
          comboBox_SearchCondition.SelectedIndex = 1;
          break;
      }
    }
  }
}
