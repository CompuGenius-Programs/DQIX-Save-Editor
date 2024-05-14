// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchMapName3ConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

namespace DQ9_Cheat.Controls.MapSearch;

public class SearchMapName3ConditionControl : SearchConditionControlBase
{
    private SearchMapName3Conditioin _condition;
    private ComboBox comboBox_Name3;
    private ComboBox comboBox_SearchCondition;
    private IContainer components;

    public SearchMapName3ConditionControl()
    {
        InitializeComponent();
        comboBox_Name3.SelectedIndex = 0;
        comboBox_SearchCondition.SelectedIndex = 0;
    }

    public override SearchConditionBase GetCondition()
    {
        if (_condition == null)
            _condition = new SearchMapName3Conditioin();
        _condition.Name3Index = comboBox_Name3.SelectedIndex;
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
        _condition = condition as SearchMapName3Conditioin;
        if (_condition == null)
            return;
        comboBox_Name3.SelectedIndex = _condition.Name3Index;
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
        comboBox_Name3 = new ComboBox();
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
        comboBox_SearchCondition.TabIndex = 7;
        comboBox_Name3.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Name3.FormattingEnabled = true;
        comboBox_Name3.Items.AddRange(new object[24]
        {
            "Cave",
            "Mine",
            "Lair",
            "Path",
            "Crypt",
            "Nest",
            "World",
            "Abyss",
            "Tunnel",
            "Ruins",
            "Maze",
            "Crevasse",
            "Icepit",
            "Snowhall",
            "Tundra",
            "Glacier",
            "Marsh",
            "Lake",
            "Moor",
            "Waterway",
            "Chasm",
            "Crater",
            "Dungeon",
            "Void"
        });
        comboBox_Name3.Location = new Point(16, 16);
        comboBox_Name3.Name = "comboBox_Name3";
        comboBox_Name3.Size = new Size(80, 20);
        comboBox_Name3.TabIndex = 6;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(comboBox_SearchCondition);
        Controls.Add(comboBox_Name3);
        Name = nameof(SearchMapName3ConditionControl);
        Size = new Size(198, 42);
        ResumeLayout(false);
    }
}