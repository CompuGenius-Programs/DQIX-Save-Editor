// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.SafeNumericUpDown
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace DQ9_Cheat.Controls;

public class SafeNumericUpDown : NumericUpDown
{
    private IContainer components;

    public SafeNumericUpDown()
    {
        InitializeComponent();
    }

    public new decimal Value
    {
        get => base.Value;
        set
        {
            if (value > Maximum)
                value = Maximum;
            if (value < Minimum)
                value = Minimum;
            base.Value = value;
        }
    }

    private decimal Constrain(decimal value)
    {
        if (value < Minimum)
            value = Minimum;
        if (value > Maximum)
            value = Maximum;
        return value;
    }

    protected override void ValidateEditText()
    {
        ParseEditText();
        UpdateEditText();
    }

    protected override void UpdateEditText()
    {
        if (UserEdit)
            ParseEditText();
        base.UpdateEditText();
    }

    protected new void ParseEditText()
    {
        try
        {
            if (string.IsNullOrEmpty(Text) || (Text.Length == 1 && !(Text != "-")))
                return;
            if (Hexadecimal)
                Value = Constrain(Convert.ToDecimal(Convert.ToUInt64(Text, 16)));
            else
                Value = Constrain(decimal.Parse(Text, CultureInfo.CurrentCulture));
        }
        catch
        {
        }
        finally
        {
            UserEdit = false;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new Container();
        AutoScaleMode = AutoScaleMode.Font;
    }
}