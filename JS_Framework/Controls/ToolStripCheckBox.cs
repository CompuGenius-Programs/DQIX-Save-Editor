// Decompiled with JetBrains decompiler
// Type: JS_Framework.Controls.ToolStripCheckBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Windows.Forms;

namespace JS_Framework.Controls
{
  public class ToolStripCheckBox : ToolStripControlHost
  {
    public ToolStripCheckBox()
      : base(new CheckBox())
    {
    }

    public CheckBox CheckBox => (CheckBox) Control;

    public bool Checked
    {
      get => CheckBox.Checked;
      set => CheckBox.Checked = value;
    }

    protected override void OnSubscribeControlEvents(Control control)
    {
      base.OnSubscribeControlEvents(control);
      ((CheckBox) control).CheckedChanged += checkBox_CheckedChanged;
    }

    protected override void OnUnsubscribeControlEvents(Control control)
    {
      base.OnUnsubscribeControlEvents(control);
      ((CheckBox) control).CheckedChanged -= checkBox_CheckedChanged;
    }

    public event EventHandler CheckedChanged;

    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
      if (CheckedChanged == null)
        return;
      CheckedChanged(this, e);
    }
  }
}
