// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionControlBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Drawing;
using System.Windows.Forms;

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
      _mouseEntered = false;
      _left = (int) (left * (double) dpiRateX);
      _top = (int) (top * (double) dpiRateY);
      _width = (int) (width * (double) dpiRateX);
      _height = (int) (height * (double) dpiRateY);
    }

    public VisionControlBase(int left, int top, int width, int height)
    {
      _mouseEntered = false;
      _left = left;
      _top = top;
      _width = width;
      _height = height;
    }

    public bool MouseEntered => _mouseEntered;

    public Control Parent
    {
      get => _parentControl;
      set
      {
        _parentControl = value;
        Regist(_parentControl);
      }
    }

    public object Tag
    {
      get => _tag;
      set => _tag = value;
    }

    public bool TabStop
    {
      get => _innerControl.TabStop;
      set => _innerControl.TabStop = value;
    }

    public int TabIndex
    {
      get => _innerControl.TabIndex;
      set => _innerControl.TabIndex = value;
    }

    public int Left
    {
      get => _left;
      set => _left = value;
    }

    public int Right => _left + _width;

    public int Top
    {
      get => _top;
      set => _top = value;
    }

    public int Bottom => _top + _height;

    public int Width
    {
      get => _width;
      set => _width = value;
    }

    public int Height
    {
      get => _height;
      set => _height = value;
    }

    public bool Visible
    {
      get => _visible;
      set
      {
        _visible = value;
        if (_innerControl != null)
          _innerControl.Visible = value;
        DrawControl();
      }
    }

    public bool Enable
    {
      get => _enable;
      set
      {
        _enable = value;
        if (_innerControl == null)
          return;
        _innerControl.Enabled = value;
      }
    }

    protected virtual void Regist(Control parent)
    {
    }

    protected void BeginUpdate() => ++_updateCount;

    protected void EndUpdate()
    {
      if (_updateCount <= 0)
        return;
      --_updateCount;
    }

    public void Focus()
    {
      if (_innerControl == null)
        return;
      _innerControl.Focus();
    }

    public virtual bool HitTest(int x, int y)
    {
      return x >= _left && x < _left + _width && y >= _top && y < _top + _height;
    }

    internal void MouseMove(int x, int y)
    {
      if (_mouseEntered)
      {
        if (HitTest(x, y))
          return;
        _mouseEntered = false;
        MouseLeave();
      }
      else
      {
        if (!HitTest(x, y))
          return;
        _mouseEntered = true;
        MouseEnter();
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
      if (_parentControl == null)
        return;
      using (Graphics graphic = Graphics.FromHwnd(_parentControl.Handle))
        DrawControl(graphic);
    }

    public abstract void DrawControl(Graphics graphic);
  }
}
