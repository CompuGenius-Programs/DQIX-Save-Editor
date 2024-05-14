// Decompiled with JetBrains decompiler
// Type: JS_Framework.Controls.ToolStripCheckBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace JS_Framework.Controls
{
  public class ToolStripCheckBox : ToolStripControlHost
  {
    public ToolStripCheckBox()
      : base((Control) new CheckBox())
    {
    }

    public CheckBox CheckBox => (CheckBox) this.Control;

    public bool Checked
    {
      get => this.CheckBox.Checked;
      set => this.CheckBox.Checked = value;
    }

    protected override void OnSubscribeControlEvents(Control control)
    {
      base.OnSubscribeControlEvents(control);
      ((CheckBox) control).CheckedChanged += new EventHandler(this.checkBox_CheckedChanged);
    }

    protected override void OnUnsubscribeControlEvents(Control control)
    {
      base.OnUnsubscribeControlEvents(control);
      ((CheckBox) control).CheckedChanged -= new EventHandler(this.checkBox_CheckedChanged);
    }

    public event EventHandler CheckedChanged;

    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this.CheckedChanged == null)
        return;
      this.CheckedChanged((object) this, e);
    }
  }
}
