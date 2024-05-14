// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchMapTypeConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

namespace DQ9_Cheat.Controls.MapSearch;

public class SearchMapTypeConditionControl : SearchConditionControlBase
{
    private SearchMapTypeConditioin _condition;
    private ComboBox comboBox_MapType;
    private ComboBox comboBox_SearchCondition;
    private IContainer components;

    public SearchMapTypeConditionControl()
    {
        InitializeComponent();
        comboBox_MapType.SelectedIndex = 0;
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
        comboBox_MapType = new ComboBox();
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
        comboBox_SearchCondition.TabIndex = 9;
        comboBox_MapType.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_MapType.FormattingEnabled = true;
        comboBox_MapType.Items.AddRange([
            "Caves",
            "Ruins",
            "Ice",
            "Water",
            "Volcano"
        ]);
        comboBox_MapType.Location = new Point(16, 16);
        comboBox_MapType.Name = "comboBox_MapType";
        comboBox_MapType.Size = new Size(74, 20);
        comboBox_MapType.TabIndex = 8;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(comboBox_SearchCondition);
        Controls.Add(comboBox_MapType);
        Name = nameof(SearchMapTypeConditionControl);
        Size = new Size(201, 45);
        ResumeLayout(false);
    }

    public override SearchConditionBase GetCondition()
    {
        if (_condition == null)
            _condition = new SearchMapTypeConditioin();
        _condition.MapType = comboBox_MapType.SelectedIndex;
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
        _condition = condition as SearchMapTypeConditioin;
        if (_condition == null)
            return;
        comboBox_MapType.SelectedIndex = _condition.MapType;
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