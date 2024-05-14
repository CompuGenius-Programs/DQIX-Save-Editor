// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.PresetWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DQ9_Cheat.Controls;

public class PresetWindow : Form
{
    private Button button_Cancel;
    private Button button_OK;
    private IContainer components;
    private ListBox listBox;

    public PresetWindow(ListType listType)
    {
        InitializeComponent();
        switch (listType)
        {
            case ListType.Figure:
                InitializeListFigure();
                break;
            case ListType.HairType:
                InitializeListHairType();
                break;
            case ListType.HairColor:
                InitializeListHairColor();
                break;
            case ListType.FaceType:
                InitializeListFaceType();
                break;
        }
    }

    public object SelectedPreset { get; private set; }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        listBox = new ListBox();
        button_OK = new Button();
        button_Cancel = new Button();
        SuspendLayout();
        listBox.ColumnWidth = 100;
        listBox.FormattingEnabled = true;
        listBox.ItemHeight = 12;
        listBox.Location = new Point(5, 5);
        listBox.MultiColumn = true;
        listBox.Name = "listBox";
        listBox.Size = new Size(205, 124);
        listBox.TabIndex = 0;
        listBox.MouseDoubleClick += listBox_MouseDoubleClick;
        button_OK.DialogResult = DialogResult.OK;
        button_OK.Location = new Point(54, 136);
        button_OK.Name = "button_OK";
        button_OK.Size = new Size(75, 23);
        button_OK.TabIndex = 1;
        button_OK.Text = "OK";
        button_OK.UseVisualStyleBackColor = true;
        button_OK.Click += button_OK_Click;
        button_Cancel.DialogResult = DialogResult.Cancel;
        button_Cancel.Location = new Point(135, 136);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new Size(75, 23);
        button_Cancel.TabIndex = 2;
        button_Cancel.Text = "Cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        button_Cancel.Click += button_Cancel_Click;
        AcceptButton = button_OK;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = button_Cancel;
        ClientSize = new Size(216, 163);
        Controls.Add(button_Cancel);
        Controls.Add(button_OK);
        Controls.Add(listBox);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = nameof(PresetWindow);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        Text = "Preset";
        ResumeLayout(false);
    }

    private void InitializeListFigure()
    {
        Text = "Body - Preset";
        listBox.Items.Clear();
        listBox.Items.Add(new PresetFigure("Male Type １", 3768, 4255));
        listBox.Items.Add(new PresetFigure("Male Type ２", 3637, 4136));
        listBox.Items.Add(new PresetFigure("Male Type ３", 3850, 4014));
        listBox.Items.Add(new PresetFigure("Male Type ４", 4132, 3891));
        listBox.Items.Add(new PresetFigure("Male Type ５", 3870, 3764));
        listBox.Items.Add(new PresetFigure("Female Type １", 3768, 4177));
        listBox.Items.Add(new PresetFigure("Female Type ２", 3641, 4091));
        listBox.Items.Add(new PresetFigure("Female Type ３", 3809, 3973));
        listBox.Items.Add(new PresetFigure("Female Type ４", 4132, 3891));
        listBox.Items.Add(new PresetFigure("Female Type ５", 3768, 3764));
        listBox.SelectedIndex = 0;
    }

    private void InitializeListHairType()
    {
        Text = "Hair Style - Preset";
        listBox.Items.Clear();
        listBox.Items.Add(new Preset("Male Type １", 40));
        listBox.Items.Add(new Preset("Male Type ２", 41));
        listBox.Items.Add(new Preset("Male Type ３", 42));
        listBox.Items.Add(new Preset("Male Type ４", 43));
        listBox.Items.Add(new Preset("Male Type ５", 44));
        listBox.Items.Add(new Preset("Male Type ６", 45));
        listBox.Items.Add(new Preset("Male Type ７", 46));
        listBox.Items.Add(new Preset("Male Type ８", 47));
        listBox.Items.Add(new Preset("Male Type ９", 48));
        listBox.Items.Add(new Preset("Male Type 10", 49));
        listBox.Items.Add(new Preset("Female Type １", 46));
        listBox.Items.Add(new Preset("Female Type ２", 40));
        listBox.Items.Add(new Preset("Female Type ３", 41));
        listBox.Items.Add(new Preset("Female Type ４", 42));
        listBox.Items.Add(new Preset("Female Type ５", 43));
        listBox.Items.Add(new Preset("Female Type ６", 44));
        listBox.Items.Add(new Preset("Female Type ７", 45));
        listBox.Items.Add(new Preset("Female Type ８", 47));
        listBox.Items.Add(new Preset("Female Type ９", 48));
        listBox.Items.Add(new Preset("Female Type 10", 49));
        listBox.SelectedIndex = 0;
    }

    private void InitializeListHairColor()
    {
        Text = "Hair Color - Preset";
        listBox.Items.Clear();
        listBox.Items.Add(new Preset("Male Type １", 160));
        listBox.Items.Add(new Preset("Male Type ２", 161));
        listBox.Items.Add(new Preset("Male Type ３", 162));
        listBox.Items.Add(new Preset("Male Type ４", 163));
        listBox.Items.Add(new Preset("Male Type ５", 164));
        listBox.Items.Add(new Preset("Male Type ６", 165));
        listBox.Items.Add(new Preset("Male Type ７", 166));
        listBox.Items.Add(new Preset("Male Type ８", 167));
        listBox.Items.Add(new Preset("Male Type ９", 168));
        listBox.Items.Add(new Preset("Male Type 10", 169));
        listBox.Items.Add(new Preset("Female Type １", 160));
        listBox.Items.Add(new Preset("Female Type ２", 161));
        listBox.Items.Add(new Preset("Female Type ３", 162));
        listBox.Items.Add(new Preset("Female Type ４", 163));
        listBox.Items.Add(new Preset("Female Type ５", 164));
        listBox.Items.Add(new Preset("Female Type ６", 165));
        listBox.Items.Add(new Preset("Female Type ７", 166));
        listBox.Items.Add(new Preset("Female Type ８", 167));
        listBox.Items.Add(new Preset("Female Type ９", 168));
        listBox.Items.Add(new Preset("Female Type 10", 169));
        listBox.SelectedIndex = 0;
    }

    private void InitializeListFaceType()
    {
        Text = "Face - Preset";
        listBox.Items.Clear();
        listBox.Items.Add(new Preset("Male Type１", 64));
        listBox.Items.Add(new Preset("Male Type ２", 60));
        listBox.Items.Add(new Preset("Male Type ３", 61));
        listBox.Items.Add(new Preset("Male Type ４", 62));
        listBox.Items.Add(new Preset("Male Type ５", 63));
        listBox.Items.Add(new Preset("Male Type ６", 65));
        listBox.Items.Add(new Preset("Male Type ７", 66));
        listBox.Items.Add(new Preset("Male Type ８", 67));
        listBox.Items.Add(new Preset("Male Type ９", 68));
        listBox.Items.Add(new Preset("Male Type 10", 69));
        listBox.Items.Add(new Preset("Female Type １", 61));
        listBox.Items.Add(new Preset("Female Type ２", 60));
        listBox.Items.Add(new Preset("Female Type ３", 62));
        listBox.Items.Add(new Preset("Female Type ４", 63));
        listBox.Items.Add(new Preset("Female Type ５", 64));
        listBox.Items.Add(new Preset("Female Type ６", 65));
        listBox.Items.Add(new Preset("Female Type ７", 66));
        listBox.Items.Add(new Preset("Female Type ８", 67));
        listBox.Items.Add(new Preset("Female Type ９", 68));
        listBox.Items.Add(new Preset("Female Type 10", 69));
        listBox.SelectedIndex = 0;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
        SelectedPreset = listBox.SelectedItem;
    }

    private void button_Cancel_Click(object sender, EventArgs e)
    {
    }

    private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var index = listBox.IndexFromPoint(e.Location);
        if (index == -1)
            return;
        SelectedPreset = listBox.Items[index];
        DialogResult = DialogResult.OK;
    }
}