// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.DataControlBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls.VisionControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class DataControlBase : UserControl
  {
    private List<VisionControlBase> _visionControls = new List<VisionControlBase>();
    protected int _updateCount;
    private IContainer components;

    public DataControlBase()
    {
      this.InitializeComponent();
      this.DoubleBuffered = true;
      this.Disposed += new EventHandler(this.DataControlBase_Disposed);
    }

    private void DataControlBase_Disposed(object sender, EventArgs e)
    {
    }

    protected override void OnLoad(EventArgs e)
    {
    }

    public void DataFileLoaded()
    {
      this.BeginUpdate();
      this.OnDataFileLoad();
      this.EndUpdate();
    }

    public void ValueUpdated()
    {
      this.BeginUpdate();
      this.OnValueUpdate();
      this.EndUpdate();
    }

    public void Activate()
    {
      this.BeginUpdate();
      this.OnActivate();
      this.EndUpdate();
    }

    protected virtual void OnDataFileLoad()
    {
    }

    protected virtual void OnValueUpdate()
    {
    }

    protected virtual void RenewalControl()
    {
    }

    protected virtual void OnActivate()
    {
    }

    public void BeginUpdate() => ++this._updateCount;

    public void EndUpdate()
    {
      --this._updateCount;
      if (this._updateCount >= 0)
        return;
      this._updateCount = 0;
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

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Name = nameof (DataControlBase);
      this.Size = new Size(406, 357);
      this.ResumeLayout(false);
    }
  }
}
