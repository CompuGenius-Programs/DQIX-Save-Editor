// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.MapSearchConditionEdit
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.MapSearch;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls.MapSearch
{
  public class MapSearchConditionEdit : Form
  {
    private IContainer components;
    private Button button_Cancel;
    private Button button_OK;
    private Label label1;
    private ComboBox comboBox_SearchType;
    private GroupBox groupBox_Condition;
    private SearchConditionControlBase[] _searchConditions = new SearchConditionControlBase[10];
    private SearchConditionControlBase _activeControl;
    private int _updateCount;
    private SearchConditionBase _condition;

    public MapSearchConditionEdit()
    {
      this.InitializeComponent();
      this.BeginUpdate();
      this._searchConditions[0] = (SearchConditionControlBase) new SearchRankConditionControl();
      this._searchConditions[1] = (SearchConditionControlBase) new SearchMapName1ConditionControl();
      this._searchConditions[2] = (SearchConditionControlBase) new SearchMapName3ConditionControl();
      this._searchConditions[3] = (SearchConditionControlBase) new SearchMapName2ConditionControl();
      this._searchConditions[4] = (SearchConditionControlBase) new SearchMapLvConditionControl();
      this._searchConditions[5] = (SearchConditionControlBase) new SearchMapTypeConditionControl();
      this._searchConditions[6] = (SearchConditionControlBase) new SearchMonsterRankConditionControl();
      this._searchConditions[7] = (SearchConditionControlBase) new SearchFloorCountConditionControl();
      this._searchConditions[8] = (SearchConditionControlBase) new SearchBossConditionControl();
      this._searchConditions[9] = (SearchConditionControlBase) new SearchBoxConditionControl();
      this.comboBox_SearchType.SelectedIndex = 0;
      this._activeControl = this._searchConditions[0];
      for (int index = 0; index < 10; ++index)
      {
        this._searchConditions[index].Location = new Point(8, 12);
        this.groupBox_Condition.Controls.Add((Control) this._searchConditions[index]);
        this._searchConditions[index].Visible = false;
      }
      this._activeControl.Visible = true;
      this.EndUpdate();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.comboBox_SearchType = new ComboBox();
      this.label1 = new Label();
      this.button_OK = new Button();
      this.button_Cancel = new Button();
      this.groupBox_Condition = new GroupBox();
      this.SuspendLayout();
      this.comboBox_SearchType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_SearchType.FormattingEnabled = true;
      this.comboBox_SearchType.Items.AddRange(new object[10]
      {
        (object) "Rank",
        (object) "Map Name 1",
        (object) "Map Name 2",
        (object) "Map Name 3",
        (object) "Level",
        (object) "Type",
        (object) "Monster Rank",
        (object) "Floors",
        (object) "Boss",
        (object) "# of Chests"
      });
      this.comboBox_SearchType.Location = new Point(68, 9);
      this.comboBox_SearchType.Name = "comboBox_SearchType";
      this.comboBox_SearchType.Size = new Size(121, 21);
      this.comboBox_SearchType.TabIndex = 0;
      this.comboBox_SearchType.SelectedIndexChanged += new EventHandler(this.comboBox_SearchType_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(28, 12);
      this.label1.Name = "label1";
      this.label1.Size = new Size(38, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Target";
      this.button_OK.DialogResult = DialogResult.OK;
      this.button_OK.Location = new Point(136, 124);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new Size(75, 23);
      this.button_OK.TabIndex = 2;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new EventHandler(this.button_OK_Click);
      this.button_Cancel.DialogResult = DialogResult.Cancel;
      this.button_Cancel.Location = new Point(217, 124);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new Size(75, 23);
      this.button_Cancel.TabIndex = 3;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.groupBox_Condition.Location = new Point(12, 34);
      this.groupBox_Condition.Name = "groupBox_Condition";
      this.groupBox_Condition.Size = new Size(280, 84);
      this.groupBox_Condition.TabIndex = 4;
      this.groupBox_Condition.TabStop = false;
      this.groupBox_Condition.Text = "Condition";
      this.AcceptButton = (IButtonControl) this.button_OK;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button_Cancel;
      this.ClientSize = new Size(304, 154);
      this.Controls.Add((Control) this.groupBox_Condition);
      this.Controls.Add((Control) this.button_Cancel);
      this.Controls.Add((Control) this.button_OK);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.comboBox_SearchType);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (MapSearchConditionEdit);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Search criteria";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public SearchConditionBase Condition
    {
      get => this._condition;
      set
      {
        this._condition = value;
        if (this._activeControl != null)
        {
          this._activeControl.Visible = false;
          this._activeControl = (SearchConditionControlBase) null;
        }
        if (this._condition != null)
        {
          this._activeControl = this._searchConditions[this._condition.TypeIndex];
          this._activeControl.Visible = true;
          this._activeControl.SetCondition(this._condition);
          this.comboBox_SearchType.SelectedIndex = this._condition.TypeIndex;
        }
        else
        {
          this._activeControl = this._searchConditions[0];
          this._activeControl.Visible = true;
          this._activeControl.SetCondition(this._condition);
          this.comboBox_SearchType.SelectedIndex = 0;
        }
      }
    }

    private void BeginUpdate() => ++this._updateCount;

    private void EndUpdate()
    {
      --this._updateCount;
      if (this._updateCount >= 0)
        return;
      this._updateCount = 0;
    }

    private void comboBox_SearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      if (this._activeControl != null)
      {
        this._activeControl.Visible = false;
        this._activeControl = (SearchConditionControlBase) null;
      }
      if (this.comboBox_SearchType.SelectedIndex == -1)
        return;
      this._activeControl = this._searchConditions[this.comboBox_SearchType.SelectedIndex];
      this._activeControl.Visible = true;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      if (this._activeControl == null)
        return;
      this._condition = this._activeControl.GetCondition();
    }
  }
}
