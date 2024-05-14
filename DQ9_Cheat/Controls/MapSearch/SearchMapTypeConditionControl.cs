// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchMapTypeConditionControl
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
  public class SearchMapTypeConditionControl : SearchConditionControlBase
  {
    private IContainer components;
    private ComboBox comboBox_SearchCondition;
    private ComboBox comboBox_MapType;
    private SearchMapTypeConditioin _condition;

    public SearchMapTypeConditionControl()
    {
      this.InitializeComponent();
      this.comboBox_MapType.SelectedIndex = 0;
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
      this.comboBox_MapType = new ComboBox();
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
      this.comboBox_SearchCondition.TabIndex = 9;
      this.comboBox_MapType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_MapType.FormattingEnabled = true;
      this.comboBox_MapType.Items.AddRange(new object[5]
      {
        (object) "Caves",
        (object) "Ruins",
        (object) "Ice",
        (object) "Water",
        (object) "Volcano"
      });
      this.comboBox_MapType.Location = new Point(16, 16);
      this.comboBox_MapType.Name = "comboBox_MapType";
      this.comboBox_MapType.Size = new Size(74, 20);
      this.comboBox_MapType.TabIndex = 8;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.comboBox_SearchCondition);
      this.Controls.Add((Control) this.comboBox_MapType);
      this.Name = nameof (SearchMapTypeConditionControl);
      this.Size = new Size(201, 45);
      this.ResumeLayout(false);
    }

    public override SearchConditionBase GetCondition()
    {
      if (this._condition == null)
        this._condition = new SearchMapTypeConditioin();
      this._condition.MapType = this.comboBox_MapType.SelectedIndex;
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
      this._condition = condition as SearchMapTypeConditioin;
      if (this._condition == null)
        return;
      this.comboBox_MapType.SelectedIndex = this._condition.MapType;
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
