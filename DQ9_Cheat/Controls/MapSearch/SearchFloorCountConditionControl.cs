// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchFloorCountConditionControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

namespace DQ9_Cheat.Controls.MapSearch;

public class SearchFloorCountConditionControl : SearchConditionControlBase
{
    private SearchFloorCountConditioin _condition;
    private ComboBox comboBox_SearchCondition;
    private IContainer components;
    private NumericUpDown numericUpDown_FloorCount;

    public SearchFloorCountConditionControl()
    {
        InitializeComponent();
        numericUpDown_FloorCount.Value = numericUpDown_FloorCount.Minimum;
        comboBox_SearchCondition.SelectedIndex = 0;
    }

    public override SearchConditionBase GetCondition()
    {
        if (_condition == null)
            _condition = new SearchFloorCountConditioin();
        _condition.FloorCount = (int)numericUpDown_FloorCount.Value;
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
        _condition = condition as SearchFloorCountConditioin;
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

        numericUpDown_FloorCount.Value = _condition.FloorCount;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        numericUpDown_FloorCount = new NumericUpDown();
        comboBox_SearchCondition = new ComboBox();
        numericUpDown_FloorCount.BeginInit();
        SuspendLayout();
        numericUpDown_FloorCount.Location = new Point(16, 16);
        numericUpDown_FloorCount.Maximum = new decimal(new int[4]
        {
            16,
            0,
            0,
            0
        });
        numericUpDown_FloorCount.Minimum = new decimal(new int[4]
        {
            2,
            0,
            0,
            0
        });
        numericUpDown_FloorCount.Name = "numericUpDown_FloorCount";
        numericUpDown_FloorCount.Size = new Size(64, 19);
        numericUpDown_FloorCount.TabIndex = 6;
        numericUpDown_FloorCount.Value = new decimal(new int[4]
        {
            2,
            0,
            0,
            0
        });
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
        comboBox_SearchCondition.TabIndex = 5;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(numericUpDown_FloorCount);
        Controls.Add(comboBox_SearchCondition);
        Name = nameof(SearchFloorCountConditionControl);
        Size = new Size(195, 42);
        numericUpDown_FloorCount.EndInit();
        ResumeLayout(false);
    }
}