// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.RikkaInnDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class RikkaInnDataControl : DataControlBase
  {
    private IContainer components;
    private ListBox listBox_StayingMember;
    private StayingListGroupBox groupBox_StayingList;
    private Panel panel1;
    private ToolStrip toolStrip1;
    private ToolStripButton toolButton_AddMember;
    private ToolStripButton toolButton_Remove;
    private CheckedListBox checkedListBox_VipNPC;
    private SafeNumericUpDown _numericUpDown_OwnUID;
    private VisionNumericUpDown _numericUpDownVisitorCount;
    private VisionNumericUpDown _numericUpDownGrade;

    public RikkaInnDataControl()
    {
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      this._numericUpDown_OwnUID = new SafeNumericUpDown();
      this._numericUpDown_OwnUID.Minimum = 1M;
      this._numericUpDown_OwnUID.Maximum = 281474976710655M;
      this._numericUpDown_OwnUID.Hexadecimal = true;
      this._numericUpDown_OwnUID.Location = new Point(13, 32);
      this._numericUpDown_OwnUID.Size = new Size(120, 19);
      this._numericUpDown_OwnUID.ValueChanged += new EventHandler(this._numericUpDown_OwnUID_ValueChanged);
      this.Controls.Add((Control) this._numericUpDown_OwnUID);
      this._numericUpDownVisitorCount = new VisionNumericUpDown(43, 75, 90, 19);
      this._numericUpDownVisitorCount.ValueChanged += new EventHandler(this._numericUpDownVisitorCount_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDownVisitorCount);
      this._numericUpDownGrade = new VisionNumericUpDown(80, 100, 53, 19);
      this._numericUpDownGrade.ValueChanged += new EventHandler(this._numericUpDownGrade_ValueChanged);
      this.AddVisionControl((VisionControlBase) this._numericUpDownGrade);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (RikkaInnDataControl));
      this.listBox_StayingMember = new ListBox();
      this.groupBox_StayingList = new StayingListGroupBox();
      this.panel1 = new Panel();
      this.toolStrip1 = new ToolStrip();
      this.toolButton_AddMember = new ToolStripButton();
      this.toolButton_Remove = new ToolStripButton();
      this.checkedListBox_VipNPC = new CheckedListBox();
      this.groupBox_StayingList.SuspendLayout();
      this.panel1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      this.listBox_StayingMember.Dock = DockStyle.Fill;
      this.listBox_StayingMember.FormattingEnabled = true;
      this.listBox_StayingMember.ItemHeight = 12;
      this.listBox_StayingMember.Location = new Point(0, 0);
      this.listBox_StayingMember.Name = "listBox_StayingMember";
      this.listBox_StayingMember.Size = new Size(90, 220);
      this.listBox_StayingMember.TabIndex = 0;
      this.listBox_StayingMember.SelectedIndexChanged += new EventHandler(this.listBox_StayingMember_SelectedIndexChanged);
      this.groupBox_StayingList.Controls.Add((Control) this.panel1);
      this.groupBox_StayingList.Location = new Point(142, 8);
      this.groupBox_StayingList.Name = "groupBox_StayingList";
      this.groupBox_StayingList.Size = new Size(859, 499);
      this.groupBox_StayingList.TabIndex = 1;
      this.groupBox_StayingList.TabStop = false;
      this.groupBox_StayingList.Text = "Guest List";
      this.panel1.BorderStyle = BorderStyle.Fixed3D;
      this.panel1.Controls.Add((Control) this.toolStrip1);
      this.panel1.Controls.Add((Control) this.listBox_StayingMember);
      this.panel1.Location = new Point(12, 18);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(94, 249);
      this.panel1.TabIndex = 1;
      this.toolStrip1.Dock = DockStyle.Bottom;
      this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.toolButton_AddMember,
        (ToolStripItem) this.toolButton_Remove
      });
      this.toolStrip1.Location = new Point(0, 220);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(90, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      this.toolButton_AddMember.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_AddMember.Image = (Image) componentResourceManager.GetObject("toolButton_AddMember.Image");
      this.toolButton_AddMember.ImageTransparentColor = Color.Magenta;
      this.toolButton_AddMember.Name = "toolButton_AddMember";
      this.toolButton_AddMember.Size = new Size(23, 22);
      this.toolButton_AddMember.Text = "Add";
      this.toolButton_AddMember.Click += new EventHandler(this.toolButton_AddMember_Click);
      this.toolButton_Remove.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_Remove.Image = (Image) componentResourceManager.GetObject("toolButton_Remove.Image");
      this.toolButton_Remove.ImageTransparentColor = Color.Magenta;
      this.toolButton_Remove.Name = "toolButton_Remove";
      this.toolButton_Remove.Size = new Size(23, 22);
      this.toolButton_Remove.Text = "Remove";
      this.toolButton_Remove.Click += new EventHandler(this.toolButton_Remove_Click);
      this.checkedListBox_VipNPC.FormattingEnabled = true;
      this.checkedListBox_VipNPC.Items.AddRange(new object[23]
      {
        (object) "Princeton",
        (object) "Princessa",
        (object) "Alena",
        (object) "Kiryl",
        (object) "Borya",
        (object) "Meena",
        (object) "Maya",
        (object) "Torneko",
        (object) "Ragnar",
        (object) "Bianca",
        (object) "Nera",
        (object) "Debora",
        (object) "Milly",
        (object) "Carver",
        (object) "Ashlynn",
        (object) "Kiefer",
        (object) "Maribel",
        (object) "Jessica",
        (object) "Angelo",
        (object) "Yangus",
        (object) "Trode",
        (object) "Morrie",
        (object) "Fleurette"
      });
      this.checkedListBox_VipNPC.Location = new Point(24, 150);
      this.checkedListBox_VipNPC.Name = "checkedListBox_VipNPC";
      this.checkedListBox_VipNPC.Size = new Size(109, 350);
      this.checkedListBox_VipNPC.TabIndex = 3;
      this.checkedListBox_VipNPC.ItemCheck += new ItemCheckEventHandler(this.checkedListBox_VipNPC_ItemCheck);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.checkedListBox_VipNPC);
      this.Controls.Add((Control) this.groupBox_StayingList);
      this.Name = nameof (RikkaInnDataControl);
      this.Size = new Size(1015, 516);
      this.groupBox_StayingList.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
    }

    public SafeNumericUpDown NumericUpDown_OwnUID => this._numericUpDown_OwnUID;

    public VisionNumericUpDown NumericUpDownVisitorCount => this._numericUpDownVisitorCount;

    public VisionNumericUpDown NumericUpDownGrade => this._numericUpDownGrade;

    protected override void OnValueUpdate()
    {
      RikkaData rikkaData = SaveDataManager.Instance.SaveData.RikkaData;
      this.BeginUpdate();
      this._numericUpDown_OwnUID.Value = (Decimal) rikkaData.UID;
      this._numericUpDownVisitorCount.Value = (Decimal) rikkaData.VisitorCount;
      this._numericUpDownGrade.Value = (Decimal) rikkaData.Grade;
      this.RenewalListBox();
      this.RenewalListBoxToolBar();
      this.RenewalGroupBoxStaying();
      for (int index = 0; index < HistoryCharacterList.List.Count; ++index)
        this.checkedListBox_VipNPC.SetItemChecked(index, rikkaData.IsHistoryCharacter(index));
      this.EndUpdate();
    }

    private void RenewalListBoxToolBar()
    {
      RikkaData rikkaData = SaveDataManager.Instance.SaveData.RikkaData;
      this.toolButton_Remove.Enabled = this.listBox_StayingMember.SelectedIndex != -1;
      this.toolButton_AddMember.Enabled = rikkaData.VisitorManager.VisitorCount.Value < (byte) 30;
    }

    public void RenewalListBox()
    {
      RikkaData rikkaData = SaveDataManager.Instance.SaveData.RikkaData;
      this.listBox_StayingMember.BeginUpdate();
      int selectedIndex = this.listBox_StayingMember.SelectedIndex;
      this.listBox_StayingMember.Items.Clear();
      int index1 = 0;
      for (int index2 = 0; index2 < (int) rikkaData.VisitorManager.VisitorCount.Value && index1 < 30; ++index1)
      {
        if (rikkaData.VisitorManager.VisitorData[index1].SEQ != 0U)
        {
          this.listBox_StayingMember.Items.Add((object) new RikkaInnDataControl.listBox_StayingMemberItem(rikkaData.VisitorManager.VisitorData[index1].Name.Value, index1));
          ++index2;
        }
      }
      if (this.listBox_StayingMember.Items.Count > selectedIndex)
        this.listBox_StayingMember.SelectedIndex = selectedIndex;
      else if (this.listBox_StayingMember.Items.Count > 0)
        this.listBox_StayingMember.SelectedIndex = 0;
      this.listBox_StayingMember.EndUpdate();
    }

    private void _numericUpDown_OwnUID_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.UID = (ulong) this._numericUpDown_OwnUID.Value;
    }

    private void _numericUpDownVisitorCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.VisitorCount = (uint) this._numericUpDownVisitorCount.Value;
    }

    private void _numericUpDownGrade_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.Grade = (byte) this._numericUpDownGrade.Value;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        e.Graphics.DrawString("UID", this.Font, brush, new PointF(8f, 18f));
        e.Graphics.DrawString("Visitors", this.Font, brush, new PointF(8f, 56f));
        e.Graphics.DrawString("Inn Grade", this.Font, brush, new PointF(13f, 103f));
        e.Graphics.DrawString("Historical Characters", this.Font, brush, new PointF(15f, 130f));
      }
    }

    private void listBox_StayingMember_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount == 0)
        this.RenewalGroupBoxStaying();
      this.RenewalListBoxToolBar();
    }

    private void toolButton_AddMember_Click(object sender, EventArgs e)
    {
      VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
      if (visitorManager.VisitorCount.Value >= (byte) 30)
        return;
      this.BeginUpdate();
      visitorManager.CreateCharacter();
      this._numericUpDownVisitorCount.Value = (Decimal) SaveDataManager.Instance.SaveData.RikkaData.VisitorCount;
      this.EndUpdate();
      this.RenewalListBox();
      this.listBox_StayingMember.SelectedIndex = (int) visitorManager.VisitorCount.Value - 1;
    }

    private void toolButton_Remove_Click(object sender, EventArgs e)
    {
      if (!(this.listBox_StayingMember.SelectedItem is RikkaInnDataControl.listBox_StayingMemberItem selectedItem))
        return;
      int selectedIndex = this.listBox_StayingMember.SelectedIndex;
      int index = selectedItem.Index;
      VisitorManager visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
      visitorManager.DeleteVisitor(index);
      this.RenewalListBox();
      if (visitorManager.VisitorCount.Value > (byte) 0)
      {
        this.listBox_StayingMember.SelectedIndex = selectedIndex == 0 ? 0 : selectedIndex - 1;
      }
      else
      {
        this.listBox_StayingMember.SelectedIndex = -1;
        this.RenewalGroupBoxStaying();
        this.RenewalListBoxToolBar();
      }
    }

    private void checkedListBox_VipNPC_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.RikkaData.SetHistoryCharacter(e.Index, e.NewValue == CheckState.Checked);
    }

    private void RenewalGroupBoxStaying()
    {
      this.groupBox_StayingList.OnValueUpdate(!(this.listBox_StayingMember.SelectedItem is RikkaInnDataControl.listBox_StayingMemberItem selectedItem) ? -1 : selectedItem.Index);
    }

    private class listBox_StayingMemberItem
    {
      private string _name;
      private int _index;

      public listBox_StayingMemberItem(string name, int index)
      {
        this._name = name;
        this._index = index;
      }

      public int Index => this._index;

      public override string ToString() => this._name;
    }
  }
}
