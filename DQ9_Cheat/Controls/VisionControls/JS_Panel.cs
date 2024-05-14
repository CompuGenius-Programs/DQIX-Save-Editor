// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.JS_Panel
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DQ9_Cheat.Controls.VisionControls
{
  public class JS_Panel : Panel
  {
    private List<VisionControlBase> _visionControls = new List<VisionControlBase>();
    private IContainer components;

    public JS_Panel()
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
      using (Graphics g = Graphics.FromHwnd(Handle))
        RenewalVisionControl(g);
    }

    public void RenewalVisionControl(Graphics g)
    {
      foreach (VisionControlBase visionControl in _visionControls)
        visionControl.DrawControl(g);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      foreach (VisionControlBase visionControl in _visionControls)
        visionControl.DrawControl(e.Graphics);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      foreach (VisionControlBase visionControl in _visionControls)
        visionControl.MouseMove(e.X, e.Y);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent() => components = new Container();
  }
}
