// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.DataControlBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.Controls.VisionControls;

namespace DQ9_Cheat.Controls
{
  public class DataControlBase : UserControl
  {
    private List<VisionControlBase> _visionControls = new List<VisionControlBase>();
    protected int _updateCount;
    private IContainer components;

    public DataControlBase()
    {
      InitializeComponent();
      DoubleBuffered = true;
      Disposed += DataControlBase_Disposed;
    }

    private void DataControlBase_Disposed(object sender, EventArgs e)
    {
    }

    protected override void OnLoad(EventArgs e)
    {
    }

    public void DataFileLoaded()
    {
      BeginUpdate();
      OnDataFileLoad();
      EndUpdate();
    }

    public void ValueUpdated()
    {
      BeginUpdate();
      OnValueUpdate();
      EndUpdate();
    }

    public void Activate()
    {
      BeginUpdate();
      OnActivate();
      EndUpdate();
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

    public void BeginUpdate() => ++_updateCount;

    public void EndUpdate()
    {
      --_updateCount;
      if (_updateCount >= 0)
        return;
      _updateCount = 0;
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

    private void InitializeComponent()
    {
      SuspendLayout();
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      Name = nameof (DataControlBase);
      Size = new Size(406, 357);
      ResumeLayout(false);
    }
  }
}
