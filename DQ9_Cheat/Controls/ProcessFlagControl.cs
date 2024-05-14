// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.ProcessFlagControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class ProcessFlagControl : DataControlBase
  {
    private IContainer components;
    private Label label12;
    private CheckedListBox checkedListBox_AllowChangeJob;
    private CheckedListBox checkedListBox_Destination;
    private Label label1;
    private CheckBox checkBox_DisableRuler;

    public ProcessFlagControl()
    {
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      foreach (object obj in DestinationList.List)
        this.checkedListBox_Destination.Items.Add(obj);
    }

    protected override void OnValueUpdate()
    {
      ProcessFlag processFlag = SaveDataManager.Instance.SaveData.ProcessFlag;
      for (int index = 0; index < 6; ++index)
        this.checkedListBox_AllowChangeJob.SetItemChecked(index, processFlag.IsAllowChangeJob(index));
      foreach (Destination destination in DestinationList.List)
        this.checkedListBox_Destination.SetItemChecked(destination.Index, processFlag.IsAllowDestination(destination.Index));
      this.checkBox_DisableRuler.Checked = SaveDataManager.Instance.SaveData.ProcessFlag.DisableRuler;
    }

    private void checkedListBox_AllowChangeJob_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.ProcessFlag.SetAllowChangeJob(e.Index, e.NewValue == CheckState.Checked);
    }

    private void checkedListBox_Destination_ItemCheck(object sender, ItemCheckEventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.ProcessFlag.SetAllowDestination(e.Index, e.NewValue == CheckState.Checked);
    }

    private void checkBox_DisableRuler_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.ProcessFlag.DisableRuler = this.checkBox_DisableRuler.Checked;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label12 = new Label();
      this.checkedListBox_AllowChangeJob = new CheckedListBox();
      this.checkedListBox_Destination = new CheckedListBox();
      this.label1 = new Label();
      this.checkBox_DisableRuler = new CheckBox();
      this.SuspendLayout();
      this.label12.AutoSize = true;
      this.label12.Location = new Point(19, 25);
      this.label12.Name = "label12";
      this.label12.Size = new Size(77, 12);
      this.label12.TabIndex = 61;
      this.label12.Text = "Possible Job Changes";
      this.checkedListBox_AllowChangeJob.FormattingEnabled = true;
      this.checkedListBox_AllowChangeJob.Items.AddRange(new object[6]
      {
        (object) "Gladiator",
        (object) "Paladin",
        (object) "Armamentalist",
        (object) "Ranger",
        (object) "Sage",
        (object) "Luminary"
      });
      this.checkedListBox_AllowChangeJob.Location = new Point(35, 40);
      this.checkedListBox_AllowChangeJob.MultiColumn = true;
      this.checkedListBox_AllowChangeJob.Name = "checkedListBox_AllowChangeJob";
      this.checkedListBox_AllowChangeJob.Size = new Size(400, 46);
      this.checkedListBox_AllowChangeJob.TabIndex = 0;
      this.checkedListBox_AllowChangeJob.ItemCheck += new ItemCheckEventHandler(this.checkedListBox_AllowChangeJob_ItemCheck);
      this.checkedListBox_Destination.ColumnWidth = 150;
      this.checkedListBox_Destination.FormattingEnabled = true;
      this.checkedListBox_Destination.Location = new Point(35, 150);
      this.checkedListBox_Destination.MultiColumn = true;
      this.checkedListBox_Destination.Name = "checkedListBox_Destination";
      this.checkedListBox_Destination.Size = new Size(400, 146);
      this.checkedListBox_Destination.TabIndex = 2;
      this.checkedListBox_Destination.ItemCheck += new ItemCheckEventHandler(this.checkedListBox_Destination_ItemCheck);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(19, 135);
      this.label1.Name = "label1";
      this.label1.Size = new Size(76, 12);
      this.label1.TabIndex = 63;
      this.label1.Text = "Zoom Destinations";
      this.checkBox_DisableRuler.AutoSize = true;
      this.checkBox_DisableRuler.Location = new Point(21, 105);
      this.checkBox_DisableRuler.Name = "checkBox_DisableRuler";
      this.checkBox_DisableRuler.Size = new Size(76, 16);
      this.checkBox_DisableRuler.TabIndex = 1;
      this.checkBox_DisableRuler.Tag = (object) "Where do I get Zoom?";
      this.checkBox_DisableRuler.Text = "Disable Zoom";
      this.checkBox_DisableRuler.UseVisualStyleBackColor = true;
      this.checkBox_DisableRuler.CheckedChanged += new EventHandler(this.checkBox_DisableRuler_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.checkBox_DisableRuler);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.checkedListBox_Destination);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.checkedListBox_AllowChangeJob);
      this.Name = nameof (ProcessFlagControl);
      this.Size = new Size(556, 342);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
