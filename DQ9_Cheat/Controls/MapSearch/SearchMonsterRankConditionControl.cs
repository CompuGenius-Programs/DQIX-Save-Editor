// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchMonsterRankConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

namespace DQ9_Cheat.Controls.MapSearch;

public class SearchMonsterRankConditionControl : SearchConditionControlBase
{
    private SearchMonsterRankConditioin _condition;
    private ComboBox comboBox_SearchCondition;
    private IContainer components;
    private NumericUpDown numericUpDown_MonsterRank;

    public SearchMonsterRankConditionControl()
    {
        InitializeComponent();
        numericUpDown_MonsterRank.Value = numericUpDown_MonsterRank.Minimum;
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
        numericUpDown_MonsterRank = new NumericUpDown();
        numericUpDown_MonsterRank.BeginInit();
        SuspendLayout();
        comboBox_SearchCondition.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_SearchCondition.FormattingEnabled = true;
        comboBox_SearchCondition.Items.AddRange([
            "Equals",
            "Not equals",
            "At least",
            "Up to"
        ]);
        comboBox_SearchCondition.Location = new Point(115, 16);
        comboBox_SearchCondition.Name = "comboBox_SearchCondition";
        comboBox_SearchCondition.Size = new Size(78, 20);
        comboBox_SearchCondition.TabIndex = 3;
        numericUpDown_MonsterRank.Location = new Point(16, 16);
        numericUpDown_MonsterRank.Maximum = new decimal([
            9,
            0,
            0,
            0
        ]);
        numericUpDown_MonsterRank.Minimum = new decimal([
            1,
            0,
            0,
            0
        ]);
        numericUpDown_MonsterRank.Name = "numericUpDown_MonsterRank";
        numericUpDown_MonsterRank.Size = new Size(64, 19);
        numericUpDown_MonsterRank.TabIndex = 4;
        numericUpDown_MonsterRank.Value = new decimal([
            1,
            0,
            0,
            0
        ]);
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(numericUpDown_MonsterRank);
        Controls.Add(comboBox_SearchCondition);
        Name = nameof(SearchMonsterRankConditionControl);
        Size = new Size(209, 45);
        numericUpDown_MonsterRank.EndInit();
        ResumeLayout(false);
    }

    public override SearchConditionBase GetCondition()
    {
        if (_condition == null)
            _condition = new SearchMonsterRankConditioin();
        _condition.MonsterRank = (int)numericUpDown_MonsterRank.Value;
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
        _condition = condition as SearchMonsterRankConditioin;
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

        numericUpDown_MonsterRank.Value = _condition.MonsterRank;
    }
}