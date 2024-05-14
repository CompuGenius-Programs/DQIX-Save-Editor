// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchMapName2ConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

namespace DQ9_Cheat.Controls.MapSearch;

public class SearchMapName2ConditionControl : SearchConditionControlBase
{
    private SearchMapName2Conditioin _condition;
    private ComboBox comboBox_Name2;
    private ComboBox comboBox_SearchCondition;
    private IContainer components;

    public SearchMapName2ConditionControl()
    {
        InitializeComponent();
        comboBox_Name2.SelectedIndex = 0;
        comboBox_SearchCondition.SelectedIndex = 0;
    }

    public override SearchConditionBase GetCondition()
    {
        if (_condition == null)
            _condition = new SearchMapName2Conditioin();
        _condition.Name2Index = comboBox_Name2.SelectedIndex;
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
        _condition = condition as SearchMapName2Conditioin;
        if (_condition == null)
            return;
        comboBox_Name2.SelectedIndex = _condition.Name2Index;
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

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        comboBox_SearchCondition = new ComboBox();
        comboBox_Name2 = new ComboBox();
        SuspendLayout();
        comboBox_SearchCondition.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_SearchCondition.FormattingEnabled = true;
        comboBox_SearchCondition.Items.AddRange([
            "Equals",
            "Not equals"
        ]);
        comboBox_SearchCondition.Location = new Point(115, 16);
        comboBox_SearchCondition.Name = "comboBox_SearchCondition";
        comboBox_SearchCondition.Size = new Size(78, 20);
        comboBox_SearchCondition.TabIndex = 5;
        comboBox_Name2.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Name2.FormattingEnabled = true;
        comboBox_Name2.Items.AddRange([
            "Joy",
            "Bliss",
            "Glee",
            "Doubt",
            "Woe",
            "Dolour",
            "Regret",
            "Bane",
            "Fear",
            "Dread",
            "Hurt",
            "Gloom",
            "Doom",
            "Evil",
            "Ruin",
            "Death"
        ]);
        comboBox_Name2.Location = new Point(16, 16);
        comboBox_Name2.Name = "comboBox_Name2";
        comboBox_Name2.Size = new Size(80, 20);
        comboBox_Name2.TabIndex = 4;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(comboBox_SearchCondition);
        Controls.Add(comboBox_Name2);
        Name = nameof(SearchMapName2ConditionControl);
        Size = new Size(200, 46);
        ResumeLayout(false);
    }
}