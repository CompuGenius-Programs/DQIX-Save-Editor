// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.RikkaInnDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls;

public class RikkaInnDataControl : DataControlBase
{
    private CheckedListBox checkedListBox_VipNPC;
    private IContainer components;
    private StayingListGroupBox groupBox_StayingList;
    private ListBox listBox_StayingMember;
    private Panel panel1;
    private ToolStripButton toolButton_AddMember;
    private ToolStripButton toolButton_Remove;
    private ToolStrip toolStrip1;

    public RikkaInnDataControl()
    {
        AutoScaleMode = AutoScaleMode.None;
        InitializeComponent();
        NumericUpDown_OwnUID = new SafeNumericUpDown();
        NumericUpDown_OwnUID.Minimum = 1M;
        NumericUpDown_OwnUID.Maximum = 281474976710655M;
        NumericUpDown_OwnUID.Hexadecimal = true;
        NumericUpDown_OwnUID.Location = new Point(13, 32);
        NumericUpDown_OwnUID.Size = new Size(120, 19);
        NumericUpDown_OwnUID.ValueChanged += _numericUpDown_OwnUID_ValueChanged;
        Controls.Add(NumericUpDown_OwnUID);
        NumericUpDownVisitorCount = new VisionNumericUpDown(43, 75, 90, 19);
        NumericUpDownVisitorCount.ValueChanged += _numericUpDownVisitorCount_ValueChanged;
        AddVisionControl(NumericUpDownVisitorCount);
        NumericUpDownGrade = new VisionNumericUpDown(80, 100, 53, 19);
        NumericUpDownGrade.ValueChanged += _numericUpDownGrade_ValueChanged;
        AddVisionControl(NumericUpDownGrade);
    }

    public SafeNumericUpDown NumericUpDown_OwnUID { get; }

    public VisionNumericUpDown NumericUpDownVisitorCount { get; }

    public VisionNumericUpDown NumericUpDownGrade { get; }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        var componentResourceManager = new ComponentResourceManager(typeof(RikkaInnDataControl));
        listBox_StayingMember = new ListBox();
        groupBox_StayingList = new StayingListGroupBox();
        panel1 = new Panel();
        toolStrip1 = new ToolStrip();
        toolButton_AddMember = new ToolStripButton();
        toolButton_Remove = new ToolStripButton();
        checkedListBox_VipNPC = new CheckedListBox();
        groupBox_StayingList.SuspendLayout();
        panel1.SuspendLayout();
        toolStrip1.SuspendLayout();
        SuspendLayout();
        listBox_StayingMember.Dock = DockStyle.Fill;
        listBox_StayingMember.FormattingEnabled = true;
        listBox_StayingMember.ItemHeight = 12;
        listBox_StayingMember.Location = new Point(0, 0);
        listBox_StayingMember.Name = "listBox_StayingMember";
        listBox_StayingMember.Size = new Size(90, 220);
        listBox_StayingMember.TabIndex = 0;
        listBox_StayingMember.SelectedIndexChanged += listBox_StayingMember_SelectedIndexChanged;
        groupBox_StayingList.Controls.Add(panel1);
        groupBox_StayingList.Location = new Point(142, 8);
        groupBox_StayingList.Name = "groupBox_StayingList";
        groupBox_StayingList.Size = new Size(859, 499);
        groupBox_StayingList.TabIndex = 1;
        groupBox_StayingList.TabStop = false;
        groupBox_StayingList.Text = "Guest List";
        panel1.BorderStyle = BorderStyle.Fixed3D;
        panel1.Controls.Add(toolStrip1);
        panel1.Controls.Add(listBox_StayingMember);
        panel1.Location = new Point(12, 18);
        panel1.Name = "panel1";
        panel1.Size = new Size(94, 249);
        panel1.TabIndex = 1;
        toolStrip1.Dock = DockStyle.Bottom;
        toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
        toolStrip1.Items.AddRange(new ToolStripItem[2]
        {
            toolButton_AddMember,
            toolButton_Remove
        });
        toolStrip1.Location = new Point(0, 220);
        toolStrip1.Name = "toolStrip1";
        toolStrip1.Size = new Size(90, 25);
        toolStrip1.TabIndex = 1;
        toolStrip1.Text = "toolStrip1";
        toolButton_AddMember.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_AddMember.Image = (Image)componentResourceManager.GetObject("toolButton_AddMember.Image");
        toolButton_AddMember.ImageTransparentColor = Color.Magenta;
        toolButton_AddMember.Name = "toolButton_AddMember";
        toolButton_AddMember.Size = new Size(23, 22);
        toolButton_AddMember.Text = "Add";
        toolButton_AddMember.Click += toolButton_AddMember_Click;
        toolButton_Remove.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_Remove.Image = (Image)componentResourceManager.GetObject("toolButton_Remove.Image");
        toolButton_Remove.ImageTransparentColor = Color.Magenta;
        toolButton_Remove.Name = "toolButton_Remove";
        toolButton_Remove.Size = new Size(23, 22);
        toolButton_Remove.Text = "Remove";
        toolButton_Remove.Click += toolButton_Remove_Click;
        checkedListBox_VipNPC.FormattingEnabled = true;
        checkedListBox_VipNPC.Items.AddRange(new object[23]
        {
            "Princeton",
            "Princessa",
            "Alena",
            "Kiryl",
            "Borya",
            "Meena",
            "Maya",
            "Torneko",
            "Ragnar",
            "Bianca",
            "Nera",
            "Debora",
            "Milly",
            "Carver",
            "Ashlynn",
            "Kiefer",
            "Maribel",
            "Jessica",
            "Angelo",
            "Yangus",
            "Trode",
            "Morrie",
            "Fleurette"
        });
        checkedListBox_VipNPC.Location = new Point(24, 150);
        checkedListBox_VipNPC.Name = "checkedListBox_VipNPC";
        checkedListBox_VipNPC.Size = new Size(109, 350);
        checkedListBox_VipNPC.TabIndex = 3;
        checkedListBox_VipNPC.ItemCheck += checkedListBox_VipNPC_ItemCheck;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(checkedListBox_VipNPC);
        Controls.Add(groupBox_StayingList);
        Name = nameof(RikkaInnDataControl);
        Size = new Size(1015, 516);
        groupBox_StayingList.ResumeLayout(false);
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        toolStrip1.ResumeLayout(false);
        toolStrip1.PerformLayout();
        ResumeLayout(false);
    }

    protected override void OnValueUpdate()
    {
        var rikkaData = SaveDataManager.Instance.SaveData.RikkaData;
        BeginUpdate();
        NumericUpDown_OwnUID.Value = rikkaData.UID;
        NumericUpDownVisitorCount.Value = rikkaData.VisitorCount;
        NumericUpDownGrade.Value = rikkaData.Grade;
        RenewalListBox();
        RenewalListBoxToolBar();
        RenewalGroupBoxStaying();
        for (var index = 0; index < HistoryCharacterList.List.Count; ++index)
            checkedListBox_VipNPC.SetItemChecked(index, rikkaData.IsHistoryCharacter(index));
        EndUpdate();
    }

    private void RenewalListBoxToolBar()
    {
        var rikkaData = SaveDataManager.Instance.SaveData.RikkaData;
        toolButton_Remove.Enabled = listBox_StayingMember.SelectedIndex != -1;
        toolButton_AddMember.Enabled = rikkaData.VisitorManager.VisitorCount.Value < 30;
    }

    public void RenewalListBox()
    {
        var rikkaData = SaveDataManager.Instance.SaveData.RikkaData;
        listBox_StayingMember.BeginUpdate();
        var selectedIndex = listBox_StayingMember.SelectedIndex;
        listBox_StayingMember.Items.Clear();
        var index1 = 0;
        for (var index2 = 0; index2 < rikkaData.VisitorManager.VisitorCount.Value && index1 < 30; ++index1)
            if (rikkaData.VisitorManager.VisitorData[index1].SEQ != 0U)
            {
                listBox_StayingMember.Items.Add(
                    new listBox_StayingMemberItem(rikkaData.VisitorManager.VisitorData[index1].Name.Value, index1));
                ++index2;
            }

        if (listBox_StayingMember.Items.Count > selectedIndex)
            listBox_StayingMember.SelectedIndex = selectedIndex;
        else if (listBox_StayingMember.Items.Count > 0)
            listBox_StayingMember.SelectedIndex = 0;
        listBox_StayingMember.EndUpdate();
    }

    private void _numericUpDown_OwnUID_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.UID = (ulong)NumericUpDown_OwnUID.Value;
    }

    private void _numericUpDownVisitorCount_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.VisitorCount = (uint)NumericUpDownVisitorCount.Value;
    }

    private void _numericUpDownGrade_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.Grade = (byte)NumericUpDownGrade.Value;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using (Brush brush = new SolidBrush(SystemColors.ControlText))
        {
            e.Graphics.DrawString("UID", Font, brush, new PointF(8f, 18f));
            e.Graphics.DrawString("Visitors", Font, brush, new PointF(8f, 56f));
            e.Graphics.DrawString("Inn Grade", Font, brush, new PointF(13f, 103f));
            e.Graphics.DrawString("Historical Characters", Font, brush, new PointF(15f, 130f));
        }
    }

    private void listBox_StayingMember_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_updateCount == 0)
            RenewalGroupBoxStaying();
        RenewalListBoxToolBar();
    }

    private void toolButton_AddMember_Click(object sender, EventArgs e)
    {
        var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        if (visitorManager.VisitorCount.Value >= 30)
            return;
        BeginUpdate();
        visitorManager.CreateCharacter();
        NumericUpDownVisitorCount.Value = SaveDataManager.Instance.SaveData.RikkaData.VisitorCount;
        EndUpdate();
        RenewalListBox();
        listBox_StayingMember.SelectedIndex = visitorManager.VisitorCount.Value - 1;
    }

    private void toolButton_Remove_Click(object sender, EventArgs e)
    {
        if (!(listBox_StayingMember.SelectedItem is listBox_StayingMemberItem selectedItem))
            return;
        var selectedIndex = listBox_StayingMember.SelectedIndex;
        var index = selectedItem.Index;
        var visitorManager = SaveDataManager.Instance.SaveData.RikkaData.VisitorManager;
        visitorManager.DeleteVisitor(index);
        RenewalListBox();
        if (visitorManager.VisitorCount.Value > 0)
        {
            listBox_StayingMember.SelectedIndex = selectedIndex == 0 ? 0 : selectedIndex - 1;
        }
        else
        {
            listBox_StayingMember.SelectedIndex = -1;
            RenewalGroupBoxStaying();
            RenewalListBoxToolBar();
        }
    }

    private void checkedListBox_VipNPC_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.RikkaData.SetHistoryCharacter(e.Index, e.NewValue == CheckState.Checked);
    }

    private void RenewalGroupBoxStaying()
    {
        groupBox_StayingList.OnValueUpdate(
            !(listBox_StayingMember.SelectedItem is listBox_StayingMemberItem selectedItem) ? -1 : selectedItem.Index);
    }

    private class listBox_StayingMemberItem
    {
        private readonly string _name;

        public listBox_StayingMemberItem(string name, int index)
        {
            _name = name;
            Index = index;
        }

        public int Index { get; }

        public override string ToString()
        {
            return _name;
        }
    }
}