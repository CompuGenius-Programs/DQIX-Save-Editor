// Decompiled with JetBrains decompiler
// Type: JS_Framework.Controls.GroupBoxWithCheckBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace JS_Framework.Controls;

[DefaultEvent("CheckedChanged")]
public class GroupBoxWithCheckBox : Panel
{
    private readonly CheckBox _innerCheckBox = new();
    private readonly GroupBox _innerGroupBox = new();
    private IContainer components;

    public GroupBoxWithCheckBox()
    {
        InitializeComponent();
        _innerCheckBox.AutoSize = true;
        _innerCheckBox.Top = -1;
        _innerCheckBox.Left = 10;
        _innerGroupBox.Left = 0;
        _innerGroupBox.Top = 0;
        _innerGroupBox.Width = Width;
        _innerGroupBox.Height = Height;
        _innerGroupBox.Enabled = _innerCheckBox.Checked;
        if (VisualStyleRenderer.IsSupported)
        {
            var normal = VisualStyleElement.Button.GroupBox.Normal;
            _innerCheckBox.ForeColor =
                new VisualStyleRenderer(normal.ClassName, normal.Part, normal.State).GetColor(ColorProperty.TextColor);
        }

        _innerCheckBox.Text = Text;
        _innerCheckBox.CheckedChanged += checkBox_CheckedChanged;
        base.Controls.Add(_innerCheckBox);
        base.Controls.Add(_innerGroupBox);
    }

    public new ControlCollection Controls => _innerGroupBox.Controls;

    public bool AllowEnabledWithCheckBoxState { get; set; } = true;

    [Browsable(true)]
    public override string Text
    {
        get => base.Text;
        set
        {
            base.Text = value;
            _innerCheckBox.Text = value;
        }
    }

    public bool Checked
    {
        get => _innerCheckBox.Checked;
        set => _innerCheckBox.Checked = value;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        Size = new Size(220, 95);
        ResumeLayout(false);
    }

    public event EventHandler CheckedChanged;

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        _innerGroupBox.Size = Size;
    }

    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        if (AllowEnabledWithCheckBoxState)
            _innerGroupBox.Enabled = _innerCheckBox.Checked;
        if (CheckedChanged == null)
            return;
        CheckedChanged(this, e);
    }
}