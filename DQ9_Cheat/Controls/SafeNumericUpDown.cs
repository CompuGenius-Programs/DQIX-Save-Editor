// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.SafeNumericUpDown
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class SafeNumericUpDown : NumericUpDown
  {
    private IContainer components;

    public SafeNumericUpDown() => this.InitializeComponent();

    public new Decimal Value
    {
      get => base.Value;
      set
      {
        if (value > this.Maximum)
          value = this.Maximum;
        if (value < this.Minimum)
          value = this.Minimum;
        base.Value = value;
      }
    }

    private Decimal Constrain(Decimal value)
    {
      if (value < this.Minimum)
        value = this.Minimum;
      if (value > this.Maximum)
        value = this.Maximum;
      return value;
    }

    protected override void ValidateEditText()
    {
      this.ParseEditText();
      this.UpdateEditText();
    }

    protected override void UpdateEditText()
    {
      if (this.UserEdit)
        this.ParseEditText();
      base.UpdateEditText();
    }

    protected new void ParseEditText()
    {
      try
      {
        if (string.IsNullOrEmpty(this.Text) || this.Text.Length == 1 && !(this.Text != "-"))
          return;
        if (this.Hexadecimal)
          this.Value = this.Constrain(Convert.ToDecimal(Convert.ToUInt64(this.Text, 16)));
        else
          this.Value = this.Constrain(Decimal.Parse(this.Text, (IFormatProvider) CultureInfo.CurrentCulture));
      }
      catch
      {
      }
      finally
      {
        this.UserEdit = false;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.AutoScaleMode = AutoScaleMode.Font;
    }
  }
}
