// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.MapSearchConditionEdit
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

namespace DQ9_Cheat.Controls.MapSearch;

public class MapSearchConditionEdit : Form
{
    private SearchConditionControlBase _activeControl;
    private SearchConditionBase _condition;
    private readonly SearchConditionControlBase[] _searchConditions = new SearchConditionControlBase[10];
    private int _updateCount;
    private Button button_Cancel;
    private Button button_OK;
    private ComboBox comboBox_SearchType;
    private IContainer components;
    private GroupBox groupBox_Condition;
    private Label label1;

    public MapSearchConditionEdit()
    {
        InitializeComponent();
        BeginUpdate();
        _searchConditions[0] = new SearchRankConditionControl();
        _searchConditions[1] = new SearchMapName1ConditionControl();
        _searchConditions[2] = new SearchMapName3ConditionControl();
        _searchConditions[3] = new SearchMapName2ConditionControl();
        _searchConditions[4] = new SearchMapLvConditionControl();
        _searchConditions[5] = new SearchMapTypeConditionControl();
        _searchConditions[6] = new SearchMonsterRankConditionControl();
        _searchConditions[7] = new SearchFloorCountConditionControl();
        _searchConditions[8] = new SearchBossConditionControl();
        _searchConditions[9] = new SearchBoxConditionControl();
        comboBox_SearchType.SelectedIndex = 0;
        _activeControl = _searchConditions[0];
        for (var index = 0; index < 10; ++index)
        {
            _searchConditions[index].Location = new Point(8, 12);
            groupBox_Condition.Controls.Add(_searchConditions[index]);
            _searchConditions[index].Visible = false;
        }

        _activeControl.Visible = true;
        EndUpdate();
    }

    public SearchConditionBase Condition
    {
        get => _condition;
        set
        {
            _condition = value;
            if (_activeControl != null)
            {
                _activeControl.Visible = false;
                _activeControl = null;
            }

            if (_condition != null)
            {
                _activeControl = _searchConditions[_condition.TypeIndex];
                _activeControl.Visible = true;
                _activeControl.SetCondition(_condition);
                comboBox_SearchType.SelectedIndex = _condition.TypeIndex;
            }
            else
            {
                _activeControl = _searchConditions[0];
                _activeControl.Visible = true;
                _activeControl.SetCondition(_condition);
                comboBox_SearchType.SelectedIndex = 0;
            }
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
        comboBox_SearchType = new ComboBox();
        label1 = new Label();
        button_OK = new Button();
        button_Cancel = new Button();
        groupBox_Condition = new GroupBox();
        SuspendLayout();
        comboBox_SearchType.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_SearchType.FormattingEnabled = true;
        comboBox_SearchType.Items.AddRange(new object[10]
        {
            "Rank",
            "Map Name 1",
            "Map Name 2",
            "Map Name 3",
            "Level",
            "Type",
            "Monster Rank",
            "Floors",
            "Boss",
            "# of Chests"
        });
        comboBox_SearchType.Location = new Point(68, 9);
        comboBox_SearchType.Name = "comboBox_SearchType";
        comboBox_SearchType.Size = new Size(121, 21);
        comboBox_SearchType.TabIndex = 0;
        comboBox_SearchType.SelectedIndexChanged += comboBox_SearchType_SelectedIndexChanged;
        label1.AutoSize = true;
        label1.Location = new Point(28, 12);
        label1.Name = "label1";
        label1.Size = new Size(38, 13);
        label1.TabIndex = 1;
        label1.Text = "Target";
        button_OK.DialogResult = DialogResult.OK;
        button_OK.Location = new Point(136, 124);
        button_OK.Name = "button_OK";
        button_OK.Size = new Size(75, 23);
        button_OK.TabIndex = 2;
        button_OK.Text = "OK";
        button_OK.UseVisualStyleBackColor = true;
        button_OK.Click += button_OK_Click;
        button_Cancel.DialogResult = DialogResult.Cancel;
        button_Cancel.Location = new Point(217, 124);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new Size(75, 23);
        button_Cancel.TabIndex = 3;
        button_Cancel.Text = "Cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        groupBox_Condition.Location = new Point(12, 34);
        groupBox_Condition.Name = "groupBox_Condition";
        groupBox_Condition.Size = new Size(280, 84);
        groupBox_Condition.TabIndex = 4;
        groupBox_Condition.TabStop = false;
        groupBox_Condition.Text = "Condition";
        AcceptButton = button_OK;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = button_Cancel;
        ClientSize = new Size(304, 154);
        Controls.Add(groupBox_Condition);
        Controls.Add(button_Cancel);
        Controls.Add(button_OK);
        Controls.Add(label1);
        Controls.Add(comboBox_SearchType);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = nameof(MapSearchConditionEdit);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Search criteria";
        ResumeLayout(false);
        PerformLayout();
    }

    private void BeginUpdate()
    {
        ++_updateCount;
    }

    private void EndUpdate()
    {
        --_updateCount;
        if (_updateCount >= 0)
            return;
        _updateCount = 0;
    }

    private void comboBox_SearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        if (_activeControl != null)
        {
            _activeControl.Visible = false;
            _activeControl = null;
        }

        if (comboBox_SearchType.SelectedIndex == -1)
            return;
        _activeControl = _searchConditions[comboBox_SearchType.SelectedIndex];
        _activeControl.Visible = true;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
        if (_activeControl == null)
            return;
        _condition = _activeControl.GetCondition();
    }
}