// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchRankConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

namespace DQ9_Cheat.Controls.MapSearch;

public class SearchRankConditionControl : SearchConditionControlBase
{
    private SearchMapRankCondition _condition;
    private ComboBox comboBox_Rank;
    private ComboBox comboBox_SearchCondition;
    private IContainer components;

    public SearchRankConditionControl()
    {
        InitializeComponent();
        comboBox_Rank.SelectedIndex = 0;
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
        comboBox_Rank = new ComboBox();
        comboBox_SearchCondition = new ComboBox();
        SuspendLayout();
        comboBox_Rank.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_Rank.FormattingEnabled = true;
        comboBox_Rank.Items.AddRange(new object[12]
        {
            "02",
            "38",
            "3D",
            "4C",
            "51",
            "65",
            "79",
            "8D",
            "A1",
            "B5",
            "C9",
            "DD"
        });
        comboBox_Rank.Location = new Point(16, 16);
        comboBox_Rank.Name = "comboBox_Rank";
        comboBox_Rank.Size = new Size(73, 20);
        comboBox_Rank.TabIndex = 0;
        comboBox_SearchCondition.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_SearchCondition.FormattingEnabled = true;
        comboBox_SearchCondition.Items.AddRange(new object[4]
        {
            "Equals",
            "Not equals",
            "At least",
            "Up to"
        });
        comboBox_SearchCondition.Location = new Point(115, 16);
        comboBox_SearchCondition.Name = "comboBox_SearchCondition";
        comboBox_SearchCondition.Size = new Size(78, 20);
        comboBox_SearchCondition.TabIndex = 1;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(comboBox_SearchCondition);
        Controls.Add(comboBox_Rank);
        Name = nameof(SearchRankConditionControl);
        Size = new Size(199, 45);
        ResumeLayout(false);
    }

    public override SearchConditionBase GetCondition()
    {
        if (_condition == null)
            _condition = new SearchMapRankCondition();
        _condition.RankIndex = comboBox_Rank.SelectedIndex;
        switch (comboBox_SearchCondition.SelectedIndex)
        {
            case 0:
                _condition.ConditionType = SearchConditionType.Accord;
                break;
            case 1:
                _condition.ConditionType = SearchConditionType.Discord;
                break;
            case 2:
                _condition.ConditionType = SearchConditionType.AndOver;
                break;
            case 3:
                _condition.ConditionType = SearchConditionType.AndLess;
                break;
        }

        return _condition;
    }

    public override void SetCondition(SearchConditionBase condition)
    {
        _condition = condition as SearchMapRankCondition;
        if (_condition == null)
            return;
        switch (_condition.ConditionType)
        {
            case SearchConditionType.Accord:
                comboBox_SearchCondition.SelectedIndex = 0;
                break;
            case SearchConditionType.Discord:
                comboBox_SearchCondition.SelectedIndex = 1;
                break;
            case SearchConditionType.AndOver:
                comboBox_SearchCondition.SelectedIndex = 2;
                break;
            case SearchConditionType.AndLess:
                comboBox_SearchCondition.SelectedIndex = 3;
                break;
        }

        comboBox_Rank.SelectedIndex = _condition.RankIndex;
    }
}