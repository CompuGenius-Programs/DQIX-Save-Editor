// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchMapName1ConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

namespace DQ9_Cheat.Controls.MapSearch;

public class SearchMapName1ConditionControl : SearchConditionControlBase
{
    private SearchMapName1Conditioin _condition;
    private ComboBox comboBox_Name1;
    private ComboBox comboBox_SearchCondition;
    private IContainer components;

    public SearchMapName1ConditionControl()
    {
        InitializeComponent();
        comboBox_Name1.SelectedIndex = 0;
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
        comboBox_Name1 = new ComboBox();
        SuspendLayout();
        comboBox_SearchCondition.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_SearchCondition.FormattingEnabled = true;
        comboBox_SearchCondition.Items.AddRange(new object[2]
        {
            "Equals",
            "Not equals"
        });
        comboBox_SearchCondition.Location = new Point(115, 16);
        comboBox_SearchCondition.Name = "comboBox_SearchCondition";
        comboBox_SearchCondition.Size = new Size(78, 20);
        comboBox_SearchCondition.TabIndex = 3;
        comboBox_Name1.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Name1.FormattingEnabled = true;
        comboBox_Name1.Items.AddRange(new object[16]
        {
            "Clay",
            "Rock",
            "Granite",
            "Basalt",
            "Graphite",
            "Iron",
            "Copper",
            "Bronze",
            "Steel",
            "Silver",
            "Gold",
            "Platinum",
            "Ruby",
            "Emerald",
            "Sapphire",
            "Diamond"
        });
        comboBox_Name1.Location = new Point(16, 16);
        comboBox_Name1.Name = "comboBox_Name1";
        comboBox_Name1.Size = new Size(80, 20);
        comboBox_Name1.TabIndex = 2;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(comboBox_SearchCondition);
        Controls.Add(comboBox_Name1);
        Name = nameof(SearchMapName1ConditionControl);
        Size = new Size(239, 48);
        ResumeLayout(false);
    }

    public override SearchConditionBase GetCondition()
    {
        if (_condition == null)
            _condition = new SearchMapName1Conditioin();
        _condition.Name1Index = comboBox_Name1.SelectedIndex;
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
        _condition = condition as SearchMapName1Conditioin;
        if (_condition == null)
            return;
        comboBox_Name1.SelectedIndex = _condition.Name1Index;
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