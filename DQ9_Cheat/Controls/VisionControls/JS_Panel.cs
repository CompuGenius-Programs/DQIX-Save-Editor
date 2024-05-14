// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.JS_Panel
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls.VisionControls
{
  public class JS_Panel : Panel
  {
    private List<VisionControlBase> _visionControls = new List<VisionControlBase>();
    private IContainer components;

    public JS_Panel()
    {
      this.InitializeComponent();
      this.DoubleBuffered = true;
    }

    public void AddVisionControl(VisionControlBase visionControl)
    {
      if (this._visionControls.Contains(visionControl))
        return;
      this._visionControls.Add(visionControl);
      visionControl.Parent = (Control) this;
    }

    public void RenewalVisionControl()
    {
      using (Graphics g = Graphics.FromHwnd(this.Handle))
        this.RenewalVisionControl(g);
    }

    public void RenewalVisionControl(Graphics g)
    {
      foreach (VisionControlBase visionControl in this._visionControls)
        visionControl.DrawControl(g);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      foreach (VisionControlBase visionControl in this._visionControls)
        visionControl.DrawControl(e.Graphics);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      foreach (VisionControlBase visionControl in this._visionControls)
        visionControl.MouseMove(e.X, e.Y);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent() => this.components = (IContainer) new System.ComponentModel.Container();
  }
}
