// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.JS_GroupBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DQ9_Cheat.Controls.VisionControls;

public class JS_GroupBox : GroupBox
{
    private readonly List<VisionControlBase> _visionControls = new();
    private IContainer components;

    public JS_GroupBox()
    {
        InitializeComponent();
        DoubleBuffered = true;
    }

    public void AddVisionControl(VisionControlBase visionControl)
    {
        if (_visionControls.Contains(visionControl))
            return;
        _visionControls.Add(visionControl);
        visionControl.Parent = this;
    }

    public void RenewalVisionControl()
    {
        using (var g = Graphics.FromHwnd(Handle))
        {
            RenewalVisionControl(g);
        }
    }

    public void RenewalVisionControl(Graphics g)
    {
        foreach (var visionControl in _visionControls)
            visionControl.DrawControl(g);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        foreach (var visionControl in _visionControls)
            visionControl.DrawControl(e.Graphics);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        foreach (var visionControl in _visionControls)
            visionControl.MouseMove(e.X, e.Y);
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
    }
}