// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.ProcessFlagControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls;

public class ProcessFlagControl : DataControlBase
{
    private CheckBox checkBox_DisableRuler;
    private CheckedListBox checkedListBox_AllowChangeJob;
    private CheckedListBox checkedListBox_Destination;
    private IContainer components;
    private Label label1;
    private Label label12;

    public ProcessFlagControl()
    {
        AutoScaleMode = AutoScaleMode.None;
        InitializeComponent();
        foreach (object obj in DestinationList.List)
            checkedListBox_Destination.Items.Add(obj);
    }

    protected override void OnValueUpdate()
    {
        var processFlag = SaveDataManager.Instance.SaveData.ProcessFlag;
        for (var index = 0; index < 6; ++index)
            checkedListBox_AllowChangeJob.SetItemChecked(index, processFlag.IsAllowChangeJob(index));
        foreach (var destination in DestinationList.List)
            checkedListBox_Destination.SetItemChecked(destination.Index,
                processFlag.IsAllowDestination(destination.Index));
        checkBox_DisableRuler.Checked = SaveDataManager.Instance.SaveData.ProcessFlag.DisableRuler;
    }

    private void checkedListBox_AllowChangeJob_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.ProcessFlag.SetAllowChangeJob(e.Index, e.NewValue == CheckState.Checked);
    }

    private void checkedListBox_Destination_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.ProcessFlag.SetAllowDestination(e.Index, e.NewValue == CheckState.Checked);
    }

    private void checkBox_DisableRuler_CheckedChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        SaveDataManager.Instance.SaveData.ProcessFlag.DisableRuler = checkBox_DisableRuler.Checked;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        label12 = new Label();
        checkedListBox_AllowChangeJob = new CheckedListBox();
        checkedListBox_Destination = new CheckedListBox();
        label1 = new Label();
        checkBox_DisableRuler = new CheckBox();
        SuspendLayout();
        label12.AutoSize = true;
        label12.Location = new Point(19, 25);
        label12.Name = "label12";
        label12.Size = new Size(77, 12);
        label12.TabIndex = 61;
        label12.Text = "Possible Job Changes";
        checkedListBox_AllowChangeJob.FormattingEnabled = true;
        checkedListBox_AllowChangeJob.Items.AddRange(new object[6]
        {
            "Gladiator",
            "Paladin",
            "Armamentalist",
            "Ranger",
            "Sage",
            "Luminary"
        });
        checkedListBox_AllowChangeJob.Location = new Point(35, 40);
        checkedListBox_AllowChangeJob.MultiColumn = true;
        checkedListBox_AllowChangeJob.Name = "checkedListBox_AllowChangeJob";
        checkedListBox_AllowChangeJob.Size = new Size(400, 46);
        checkedListBox_AllowChangeJob.TabIndex = 0;
        checkedListBox_AllowChangeJob.ItemCheck += checkedListBox_AllowChangeJob_ItemCheck;
        checkedListBox_Destination.ColumnWidth = 150;
        checkedListBox_Destination.FormattingEnabled = true;
        checkedListBox_Destination.Location = new Point(35, 150);
        checkedListBox_Destination.MultiColumn = true;
        checkedListBox_Destination.Name = "checkedListBox_Destination";
        checkedListBox_Destination.Size = new Size(400, 146);
        checkedListBox_Destination.TabIndex = 2;
        checkedListBox_Destination.ItemCheck += checkedListBox_Destination_ItemCheck;
        label1.AutoSize = true;
        label1.Location = new Point(19, 135);
        label1.Name = "label1";
        label1.Size = new Size(76, 12);
        label1.TabIndex = 63;
        label1.Text = "Zoom Destinations";
        checkBox_DisableRuler.AutoSize = true;
        checkBox_DisableRuler.Location = new Point(21, 105);
        checkBox_DisableRuler.Name = "checkBox_DisableRuler";
        checkBox_DisableRuler.Size = new Size(76, 16);
        checkBox_DisableRuler.TabIndex = 1;
        checkBox_DisableRuler.Tag = "Where do I get Zoom?";
        checkBox_DisableRuler.Text = "Disable Zoom";
        checkBox_DisableRuler.UseVisualStyleBackColor = true;
        checkBox_DisableRuler.CheckedChanged += checkBox_DisableRuler_CheckedChanged;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(checkBox_DisableRuler);
        Controls.Add(label1);
        Controls.Add(checkedListBox_Destination);
        Controls.Add(label12);
        Controls.Add(checkedListBox_AllowChangeJob);
        Name = nameof(ProcessFlagControl);
        Size = new Size(556, 342);
        ResumeLayout(false);
        PerformLayout();
    }
}