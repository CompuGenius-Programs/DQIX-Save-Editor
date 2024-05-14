// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionControlBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls.VisionControls
{
  public abstract class VisionControlBase
  {
    protected int _updateCount;
    private bool _mouseEntered;
    protected Control _innerControl;
    protected Control _parentControl;
    protected object _tag;
    protected int _left;
    protected int _top;
    protected int _width;
    protected int _height;
    protected bool _visible = true;
    protected bool _enable = true;

    public VisionControlBase(
      int left,
      int top,
      int width,
      int height,
      float dpiRateX,
      float dpiRateY)
    {
      this._mouseEntered = false;
      this._left = (int) ((double) left * (double) dpiRateX);
      this._top = (int) ((double) top * (double) dpiRateY);
      this._width = (int) ((double) width * (double) dpiRateX);
      this._height = (int) ((double) height * (double) dpiRateY);
    }

    public VisionControlBase(int left, int top, int width, int height)
    {
      this._mouseEntered = false;
      this._left = left;
      this._top = top;
      this._width = width;
      this._height = height;
    }

    public bool MouseEntered => this._mouseEntered;

    public Control Parent
    {
      get => this._parentControl;
      set
      {
        this._parentControl = value;
        this.Regist(this._parentControl);
      }
    }

    public object Tag
    {
      get => this._tag;
      set => this._tag = value;
    }

    public bool TabStop
    {
      get => this._innerControl.TabStop;
      set => this._innerControl.TabStop = value;
    }

    public int TabIndex
    {
      get => this._innerControl.TabIndex;
      set => this._innerControl.TabIndex = value;
    }

    public int Left
    {
      get => this._left;
      set => this._left = value;
    }

    public int Right => this._left + this._width;

    public int Top
    {
      get => this._top;
      set => this._top = value;
    }

    public int Bottom => this._top + this._height;

    public int Width
    {
      get => this._width;
      set => this._width = value;
    }

    public int Height
    {
      get => this._height;
      set => this._height = value;
    }

    public bool Visible
    {
      get => this._visible;
      set
      {
        this._visible = value;
        if (this._innerControl != null)
          this._innerControl.Visible = value;
        this.DrawControl();
      }
    }

    public bool Enable
    {
      get => this._enable;
      set
      {
        this._enable = value;
        if (this._innerControl == null)
          return;
        this._innerControl.Enabled = value;
      }
    }

    protected virtual void Regist(Control parent)
    {
    }

    protected void BeginUpdate() => ++this._updateCount;

    protected void EndUpdate()
    {
      if (this._updateCount <= 0)
        return;
      --this._updateCount;
    }

    public void Focus()
    {
      if (this._innerControl == null)
        return;
      this._innerControl.Focus();
    }

    public virtual bool HitTest(int x, int y)
    {
      return x >= this._left && x < this._left + this._width && y >= this._top && y < this._top + this._height;
    }

    internal void MouseMove(int x, int y)
    {
      if (this._mouseEntered)
      {
        if (this.HitTest(x, y))
          return;
        this._mouseEntered = false;
        this.MouseLeave();
      }
      else
      {
        if (!this.HitTest(x, y))
          return;
        this._mouseEntered = true;
        this.MouseEnter();
      }
    }

    public virtual void MouseEnter()
    {
    }

    public virtual void MouseLeave()
    {
    }

    public virtual void DrawControl()
    {
      if (this._parentControl == null)
        return;
      using (Graphics graphic = Graphics.FromHwnd(this._parentControl.Handle))
        this.DrawControl(graphic);
    }

    public abstract void DrawControl(Graphics graphic);
  }
}
