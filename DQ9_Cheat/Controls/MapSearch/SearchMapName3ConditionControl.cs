// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchMapName3ConditionControl
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
  public class SearchMapName3ConditionControl : SearchConditionControlBase
  {
    private SearchMapName3Conditioin _condition;
    private IContainer components;
    private ComboBox comboBox_SearchCondition;
    private ComboBox comboBox_Name3;

    public SearchMapName3ConditionControl()
    {
      this.InitializeComponent();
      this.comboBox_Name3.SelectedIndex = 0;
      this.comboBox_SearchCondition.SelectedIndex = 0;
    }

    public override SearchConditionBase GetCondition()
    {
      if (this._condition == null)
        this._condition = new SearchMapName3Conditioin();
      this._condition.Name3Index = this.comboBox_Name3.SelectedIndex;
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
      this._condition = condition as SearchMapName3Conditioin;
      if (this._condition == null)
        return;
      this.comboBox_Name3.SelectedIndex = this._condition.Name3Index;
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
      this.comboBox_Name3 = new ComboBox();
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
      this.comboBox_SearchCondition.TabIndex = 7;
      this.comboBox_Name3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Name3.FormattingEnabled = true;
      this.comboBox_Name3.Items.AddRange(new object[24]
      {
        (object) "Cave",
        (object) "Mine",
        (object) "Lair",
        (object) "Path",
        (object) "Crypt",
        (object) "Nest",
        (object) "World",
        (object) "Abyss",
        (object) "Tunnel",
        (object) "Ruins",
        (object) "Maze",
        (object) "Crevasse",
        (object) "Icepit",
        (object) "Snowhall",
        (object) "Tundra",
        (object) "Glacier",
        (object) "Marsh",
        (object) "Lake",
        (object) "Moor",
        (object) "Waterway",
        (object) "Chasm",
        (object) "Crater",
        (object) "Dungeon",
        (object) "Void"
      });
      this.comboBox_Name3.Location = new Point(16, 16);
      this.comboBox_Name3.Name = "comboBox_Name3";
      this.comboBox_Name3.Size = new Size(80, 20);
      this.comboBox_Name3.TabIndex = 6;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.comboBox_SearchCondition);
      this.Controls.Add((Control) this.comboBox_Name3);
      this.Name = nameof (SearchMapName3ConditionControl);
      this.Size = new Size(198, 42);
      this.ResumeLayout(false);
    }
  }
}
