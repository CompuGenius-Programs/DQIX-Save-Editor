// Decompiled with JetBrains decompiler
// Type: JS_Framework.Controls.ToolStripNumericUpDown
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace JS_Framework.Controls
{
  public class ToolStripNumericUpDown : ToolStripControlHost
  {
    private int _updateCount;

    public ToolStripNumericUpDown()
      : base((Control) new NumericUpDown())
    {
    }

    public void BeginUpdate() => ++this._updateCount;

    public void EndUpdate()
    {
      --this._updateCount;
      if (this._updateCount >= 0)
        return;
      this._updateCount = 0;
    }

    public NumericUpDown NumericUpDown => (NumericUpDown) this.Control;

    public Decimal Value
    {
      get => this.NumericUpDown.Value;
      set => this.NumericUpDown.Value = value;
    }

    public Decimal Maximum
    {
      get => this.NumericUpDown.Maximum;
      set => this.NumericUpDown.Maximum = value;
    }

    public Decimal Minimum
    {
      get => this.NumericUpDown.Minimum;
      set => this.NumericUpDown.Minimum = value;
    }

    protected override void OnSubscribeControlEvents(Control control)
    {
      base.OnSubscribeControlEvents(control);
      ((NumericUpDown) control).ValueChanged += new EventHandler(this.NumericUpDown_OnValueChanged);
    }

    protected override void OnUnsubscribeControlEvents(Control control)
    {
      base.OnUnsubscribeControlEvents(control);
      ((NumericUpDown) control).ValueChanged -= new EventHandler(this.NumericUpDown_OnValueChanged);
    }

    public event EventHandler ValueChanged;

    private void NumericUpDown_OnValueChanged(object sender, EventArgs e)
    {
      if (this.ValueChanged == null || this._updateCount != 0)
        return;
      this.ValueChanged((object) this, e);
    }
  }
}
