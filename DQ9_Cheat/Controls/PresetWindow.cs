// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.PresetWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class PresetWindow : Form
  {
    private IContainer components;
    private ListBox listBox;
    private Button button_OK;
    private Button button_Cancel;
    private object _selectedPreset;

    public PresetWindow(ListType listType)
    {
      this.InitializeComponent();
      switch (listType)
      {
        case ListType.Figure:
          this.InitializeListFigure();
          break;
        case ListType.HairType:
          this.InitializeListHairType();
          break;
        case ListType.HairColor:
          this.InitializeListHairColor();
          break;
        case ListType.FaceType:
          this.InitializeListFaceType();
          break;
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
      this.listBox = new ListBox();
      this.button_OK = new Button();
      this.button_Cancel = new Button();
      this.SuspendLayout();
      this.listBox.ColumnWidth = 100;
      this.listBox.FormattingEnabled = true;
      this.listBox.ItemHeight = 12;
      this.listBox.Location = new Point(5, 5);
      this.listBox.MultiColumn = true;
      this.listBox.Name = "listBox";
      this.listBox.Size = new Size(205, 124);
      this.listBox.TabIndex = 0;
      this.listBox.MouseDoubleClick += new MouseEventHandler(this.listBox_MouseDoubleClick);
      this.button_OK.DialogResult = DialogResult.OK;
      this.button_OK.Location = new Point(54, 136);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new Size(75, 23);
      this.button_OK.TabIndex = 1;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new EventHandler(this.button_OK_Click);
      this.button_Cancel.DialogResult = DialogResult.Cancel;
      this.button_Cancel.Location = new Point(135, 136);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new Size(75, 23);
      this.button_Cancel.TabIndex = 2;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new EventHandler(this.button_Cancel_Click);
      this.AcceptButton = (IButtonControl) this.button_OK;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button_Cancel;
      this.ClientSize = new Size(216, 163);
      this.Controls.Add((Control) this.button_Cancel);
      this.Controls.Add((Control) this.button_OK);
      this.Controls.Add((Control) this.listBox);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (PresetWindow);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Preset";
      this.ResumeLayout(false);
    }

    public object SelectedPreset => this._selectedPreset;

    private void InitializeListFigure()
    {
      this.Text = "Body - Preset";
      this.listBox.Items.Clear();
      this.listBox.Items.Add((object) new PresetFigure("Male Type １", (ushort) 3768, (ushort) 4255));
      this.listBox.Items.Add((object) new PresetFigure("Male Type ２", (ushort) 3637, (ushort) 4136));
      this.listBox.Items.Add((object) new PresetFigure("Male Type ３", (ushort) 3850, (ushort) 4014));
      this.listBox.Items.Add((object) new PresetFigure("Male Type ４", (ushort) 4132, (ushort) 3891));
      this.listBox.Items.Add((object) new PresetFigure("Male Type ５", (ushort) 3870, (ushort) 3764));
      this.listBox.Items.Add((object) new PresetFigure("Female Type １", (ushort) 3768, (ushort) 4177));
      this.listBox.Items.Add((object) new PresetFigure("Female Type ２", (ushort) 3641, (ushort) 4091));
      this.listBox.Items.Add((object) new PresetFigure("Female Type ３", (ushort) 3809, (ushort) 3973));
      this.listBox.Items.Add((object) new PresetFigure("Female Type ４", (ushort) 4132, (ushort) 3891));
      this.listBox.Items.Add((object) new PresetFigure("Female Type ５", (ushort) 3768, (ushort) 3764));
      this.listBox.SelectedIndex = 0;
    }

    private void InitializeListHairType()
    {
      this.Text = "Hair Style - Preset";
      this.listBox.Items.Clear();
      this.listBox.Items.Add((object) new Preset("Male Type １", (byte) 40));
      this.listBox.Items.Add((object) new Preset("Male Type ２", (byte) 41));
      this.listBox.Items.Add((object) new Preset("Male Type ３", (byte) 42));
      this.listBox.Items.Add((object) new Preset("Male Type ４", (byte) 43));
      this.listBox.Items.Add((object) new Preset("Male Type ５", (byte) 44));
      this.listBox.Items.Add((object) new Preset("Male Type ６", (byte) 45));
      this.listBox.Items.Add((object) new Preset("Male Type ７", (byte) 46));
      this.listBox.Items.Add((object) new Preset("Male Type ８", (byte) 47));
      this.listBox.Items.Add((object) new Preset("Male Type ９", (byte) 48));
      this.listBox.Items.Add((object) new Preset("Male Type 10", (byte) 49));
      this.listBox.Items.Add((object) new Preset("Female Type １", (byte) 46));
      this.listBox.Items.Add((object) new Preset("Female Type ２", (byte) 40));
      this.listBox.Items.Add((object) new Preset("Female Type ３", (byte) 41));
      this.listBox.Items.Add((object) new Preset("Female Type ４", (byte) 42));
      this.listBox.Items.Add((object) new Preset("Female Type ５", (byte) 43));
      this.listBox.Items.Add((object) new Preset("Female Type ６", (byte) 44));
      this.listBox.Items.Add((object) new Preset("Female Type ７", (byte) 45));
      this.listBox.Items.Add((object) new Preset("Female Type ８", (byte) 47));
      this.listBox.Items.Add((object) new Preset("Female Type ９", (byte) 48));
      this.listBox.Items.Add((object) new Preset("Female Type 10", (byte) 49));
      this.listBox.SelectedIndex = 0;
    }

    private void InitializeListHairColor()
    {
      this.Text = "Hair Color - Preset";
      this.listBox.Items.Clear();
      this.listBox.Items.Add((object) new Preset("Male Type １", (byte) 160));
      this.listBox.Items.Add((object) new Preset("Male Type ２", (byte) 161));
      this.listBox.Items.Add((object) new Preset("Male Type ３", (byte) 162));
      this.listBox.Items.Add((object) new Preset("Male Type ４", (byte) 163));
      this.listBox.Items.Add((object) new Preset("Male Type ５", (byte) 164));
      this.listBox.Items.Add((object) new Preset("Male Type ６", (byte) 165));
      this.listBox.Items.Add((object) new Preset("Male Type ７", (byte) 166));
      this.listBox.Items.Add((object) new Preset("Male Type ８", (byte) 167));
      this.listBox.Items.Add((object) new Preset("Male Type ９", (byte) 168));
      this.listBox.Items.Add((object) new Preset("Male Type 10", (byte) 169));
      this.listBox.Items.Add((object) new Preset("Female Type １", (byte) 160));
      this.listBox.Items.Add((object) new Preset("Female Type ２", (byte) 161));
      this.listBox.Items.Add((object) new Preset("Female Type ３", (byte) 162));
      this.listBox.Items.Add((object) new Preset("Female Type ４", (byte) 163));
      this.listBox.Items.Add((object) new Preset("Female Type ５", (byte) 164));
      this.listBox.Items.Add((object) new Preset("Female Type ６", (byte) 165));
      this.listBox.Items.Add((object) new Preset("Female Type ７", (byte) 166));
      this.listBox.Items.Add((object) new Preset("Female Type ８", (byte) 167));
      this.listBox.Items.Add((object) new Preset("Female Type ９", (byte) 168));
      this.listBox.Items.Add((object) new Preset("Female Type 10", (byte) 169));
      this.listBox.SelectedIndex = 0;
    }

    private void InitializeListFaceType()
    {
      this.Text = "Face - Preset";
      this.listBox.Items.Clear();
      this.listBox.Items.Add((object) new Preset("Male Type１", (byte) 64));
      this.listBox.Items.Add((object) new Preset("Male Type ２", (byte) 60));
      this.listBox.Items.Add((object) new Preset("Male Type ３", (byte) 61));
      this.listBox.Items.Add((object) new Preset("Male Type ４", (byte) 62));
      this.listBox.Items.Add((object) new Preset("Male Type ５", (byte) 63));
      this.listBox.Items.Add((object) new Preset("Male Type ６", (byte) 65));
      this.listBox.Items.Add((object) new Preset("Male Type ７", (byte) 66));
      this.listBox.Items.Add((object) new Preset("Male Type ８", (byte) 67));
      this.listBox.Items.Add((object) new Preset("Male Type ９", (byte) 68));
      this.listBox.Items.Add((object) new Preset("Male Type 10", (byte) 69));
      this.listBox.Items.Add((object) new Preset("Female Type １", (byte) 61));
      this.listBox.Items.Add((object) new Preset("Female Type ２", (byte) 60));
      this.listBox.Items.Add((object) new Preset("Female Type ３", (byte) 62));
      this.listBox.Items.Add((object) new Preset("Female Type ４", (byte) 63));
      this.listBox.Items.Add((object) new Preset("Female Type ５", (byte) 64));
      this.listBox.Items.Add((object) new Preset("Female Type ６", (byte) 65));
      this.listBox.Items.Add((object) new Preset("Female Type ７", (byte) 66));
      this.listBox.Items.Add((object) new Preset("Female Type ８", (byte) 67));
      this.listBox.Items.Add((object) new Preset("Female Type ９", (byte) 68));
      this.listBox.Items.Add((object) new Preset("Female Type 10", (byte) 69));
      this.listBox.SelectedIndex = 0;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      this._selectedPreset = this.listBox.SelectedItem;
    }

    private void button_Cancel_Click(object sender, EventArgs e)
    {
    }

    private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      int index = this.listBox.IndexFromPoint(e.Location);
      if (index == -1)
        return;
      this._selectedPreset = this.listBox.Items[index];
      this.DialogResult = DialogResult.OK;
    }
  }
}
