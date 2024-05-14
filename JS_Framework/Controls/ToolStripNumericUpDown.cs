// Decompiled with JetBrains decompiler
// Type: JS_Framework.Controls.ToolStripNumericUpDown
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Windows.Forms;

namespace JS_Framework.Controls
{
  public class ToolStripNumericUpDown : ToolStripControlHost
  {
    private int _updateCount;

    public ToolStripNumericUpDown()
      : base(new NumericUpDown())
    {
    }

    public void BeginUpdate() => ++_updateCount;

    public void EndUpdate()
    {
      --_updateCount;
      if (_updateCount >= 0)
        return;
      _updateCount = 0;
    }

    public NumericUpDown NumericUpDown => (NumericUpDown) Control;

    public Decimal Value
    {
      get => NumericUpDown.Value;
      set => NumericUpDown.Value = value;
    }

    public Decimal Maximum
    {
      get => NumericUpDown.Maximum;
      set => NumericUpDown.Maximum = value;
    }

    public Decimal Minimum
    {
      get => NumericUpDown.Minimum;
      set => NumericUpDown.Minimum = value;
    }

    protected override void OnSubscribeControlEvents(Control control)
    {
      base.OnSubscribeControlEvents(control);
      ((NumericUpDown) control).ValueChanged += NumericUpDown_OnValueChanged;
    }

    protected override void OnUnsubscribeControlEvents(Control control)
    {
      base.OnUnsubscribeControlEvents(control);
      ((NumericUpDown) control).ValueChanged -= NumericUpDown_OnValueChanged;
    }

    public event EventHandler ValueChanged;

    private void NumericUpDown_OnValueChanged(object sender, EventArgs e)
    {
      if (ValueChanged == null || _updateCount != 0)
        return;
      ValueChanged(this, e);
    }
  }
}
