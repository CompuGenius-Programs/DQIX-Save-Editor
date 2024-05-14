// Decompiled with JetBrains decompiler
// Type: JS_Framework.Controls.GroupBoxWithCheckBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#nullable disable
namespace JS_Framework.Controls
{
  [DefaultEvent("CheckedChanged")]
  public class GroupBoxWithCheckBox : Panel
  {
    private IContainer components;
    private System.Windows.Forms.GroupBox _innerGroupBox = new System.Windows.Forms.GroupBox();
    private System.Windows.Forms.CheckBox _innerCheckBox = new System.Windows.Forms.CheckBox();
    private bool _allowEnabledWithCheckBoxState = true;

    public GroupBoxWithCheckBox()
    {
      this.InitializeComponent();
      this._innerCheckBox.AutoSize = true;
      this._innerCheckBox.Top = -1;
      this._innerCheckBox.Left = 10;
      this._innerGroupBox.Left = 0;
      this._innerGroupBox.Top = 0;
      this._innerGroupBox.Width = this.Width;
      this._innerGroupBox.Height = this.Height;
      this._innerGroupBox.Enabled = this._innerCheckBox.Checked;
      if (VisualStyleRenderer.IsSupported)
      {
        VisualStyleElement normal = VisualStyleElement.Button.GroupBox.Normal;
        this._innerCheckBox.ForeColor = new VisualStyleRenderer(normal.ClassName, normal.Part, normal.State).GetColor(ColorProperty.TextColor);
      }
      this._innerCheckBox.Text = this.Text;
      this._innerCheckBox.CheckedChanged += new EventHandler(this.checkBox_CheckedChanged);
      base.Controls.Add((Control) this._innerCheckBox);
      base.Controls.Add((Control) this._innerGroupBox);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.Size = new Size(220, 95);
      this.ResumeLayout(false);
    }

    public event EventHandler CheckedChanged;

    public new Control.ControlCollection Controls => this._innerGroupBox.Controls;

    public bool AllowEnabledWithCheckBoxState
    {
      get => this._allowEnabledWithCheckBoxState;
      set => this._allowEnabledWithCheckBoxState = value;
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      this._innerGroupBox.Size = this.Size;
    }

    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
      if (this._allowEnabledWithCheckBoxState)
        this._innerGroupBox.Enabled = this._innerCheckBox.Checked;
      if (this.CheckedChanged == null)
        return;
      this.CheckedChanged((object) this, e);
    }

    [Browsable(true)]
    public override string Text
    {
      get => base.Text;
      set
      {
        base.Text = value;
        this._innerCheckBox.Text = value;
      }
    }

    public bool Checked
    {
      get => this._innerCheckBox.Checked;
      set => this._innerCheckBox.Checked = value;
    }
  }
}
