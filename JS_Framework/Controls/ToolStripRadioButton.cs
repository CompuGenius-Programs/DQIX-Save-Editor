// Decompiled with JetBrains decompiler
// Type: JS_Framework.Controls.ToolStripRadioButton
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace JS_Framework.Controls
{
  public class ToolStripRadioButton : ToolStripControlHost
  {
    public ToolStripRadioButton()
      : base((Control) new RadioButton())
    {
    }

    public RadioButton RadioButton => (RadioButton) this.Control;

    public bool Checked
    {
      get => this.RadioButton.Checked;
      set => this.RadioButton.Checked = value;
    }

    protected override void OnSubscribeControlEvents(Control control)
    {
      base.OnSubscribeControlEvents(control);
      ((RadioButton) control).CheckedChanged += new EventHandler(this.radioButton_CheckedChanged);
    }

    protected override void OnUnsubscribeControlEvents(Control control)
    {
      base.OnUnsubscribeControlEvents(control);
      ((RadioButton) control).CheckedChanged -= new EventHandler(this.radioButton_CheckedChanged);
    }

    public event EventHandler CheckedChanged;

    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
      if (this.CheckedChanged == null)
        return;
      this.CheckedChanged((object) this, e);
    }
  }
}
