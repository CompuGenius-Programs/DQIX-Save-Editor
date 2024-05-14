// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionNumericUpDown
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DQ9_Cheat.Controls.VisionControls
{
  public class VisionNumericUpDown : VisionControlBase
  {
    private SafeNumericUpDown _innerNumericUpDown;
    private static bool _controlInitialized = false;
    private static SafeNumericUpDown[] _entityNumericUpDown = new SafeNumericUpDown[3];
    private static bool[] _controlAdded = new bool[3];
    private Bitmap _spinButtonEnableBitmap;
    private Bitmap _spinButtonDisableBitmap;
    private int _addedIndex;
    private Decimal _value;
    private Decimal _maximum;
    private Decimal _minimum;
    private bool _readOnly;

    public VisionNumericUpDown(
      int left,
      int top,
      int width,
      int height,
      float dpiRateX,
      float dpiRateY)
      : base(left, top, width, height, dpiRateX, dpiRateY)
    {
      _innerNumericUpDown = new SafeNumericUpDown();
      _innerControl = _innerNumericUpDown;
      _innerNumericUpDown.Location = new Point(_left, _top);
      _innerNumericUpDown.Size = new Size(_width, _height);
      _innerNumericUpDown.ValueChanged += _innerNumericUpDown_ValueChanged;
      _innerNumericUpDown.Leave += _innerNumericUpDown_Leave;
      _innerNumericUpDown.Enter += _innerNumericUpDown_Enter;
    }

    public VisionNumericUpDown(int left, int top, int width, int height)
      : base(left, top, width, height)
    {
      _innerNumericUpDown = new SafeNumericUpDown();
      _innerControl = _innerNumericUpDown;
      _innerNumericUpDown.TextAlign = HorizontalAlignment.Right;
      _innerNumericUpDown.Location = new Point(left, top);
      _innerNumericUpDown.Size = new Size(width, height);
      _innerNumericUpDown.ValueChanged += _innerNumericUpDown_ValueChanged;
      _innerNumericUpDown.Leave += _innerNumericUpDown_Leave;
      _innerNumericUpDown.Enter += _innerNumericUpDown_Enter;
    }

    public event EventHandler Leave;

    public event EventHandler Enter;

    public event EventHandler ValueChanged;

    public Decimal Value
    {
      get => _value;
      set
      {
        if (!(_value != value))
          return;
        _value = value;
        _innerNumericUpDown.Value = value;
      }
    }

    public Decimal Maximum
    {
      get => _maximum;
      set
      {
        _maximum = value;
        _innerNumericUpDown.Maximum = value;
      }
    }

    public Decimal Minimum
    {
      get => _minimum;
      set
      {
        _minimum = value;
        _innerNumericUpDown.Minimum = value;
      }
    }

    public bool Hexadecimal
    {
      get => _innerNumericUpDown.Hexadecimal;
      set => _innerNumericUpDown.Hexadecimal = value;
    }

    public bool ReadOnly
    {
      get => _readOnly;
      set
      {
        _readOnly = value;
        _innerNumericUpDown.ReadOnly = value;
      }
    }

    private void _innerNumericUpDown_Leave(object sender, EventArgs e)
    {
      if (Leave == null)
        return;
      Leave(this, e);
    }

    private void _innerNumericUpDown_Enter(object sender, EventArgs e)
    {
      if (Enter == null)
        return;
      Enter(this, e);
    }

    protected override void Regist(Control parent)
    {
      parent?.Controls.Add(_innerNumericUpDown);
    }

    private void InitializeSpinButton()
    {
      _spinButtonEnableBitmap = new Bitmap(16, _height);
      _spinButtonDisableBitmap = new Bitmap(16, _height);
      if (VisualStyleRenderer.IsSupported)
      {
        VisualStyleElement normal1 = VisualStyleElement.Spin.Up.Normal;
        VisualStyleRenderer visualStyleRenderer1 = new VisualStyleRenderer(normal1.ClassName, normal1.Part, normal1.State);
        VisualStyleElement normal2 = VisualStyleElement.Spin.Down.Normal;
        VisualStyleRenderer visualStyleRenderer2 = new VisualStyleRenderer(normal2.ClassName, normal2.Part, normal2.State);
        using (Graphics dc = Graphics.FromImage(_spinButtonEnableBitmap))
        {
          dc.Clear(Color.Transparent);
          visualStyleRenderer1.DrawBackground(dc, new Rectangle(0, 1, 16, _height / 2 - 1));
          visualStyleRenderer2.DrawBackground(dc, new Rectangle(0, _height / 2, 16, _height / 2 - 1));
        }
        VisualStyleElement disabled1 = VisualStyleElement.Spin.Up.Disabled;
        VisualStyleRenderer visualStyleRenderer3 = new VisualStyleRenderer(disabled1.ClassName, disabled1.Part, disabled1.State);
        VisualStyleElement disabled2 = VisualStyleElement.Spin.Down.Disabled;
        VisualStyleRenderer visualStyleRenderer4 = new VisualStyleRenderer(disabled2.ClassName, disabled2.Part, disabled2.State);
        using (Graphics dc = Graphics.FromImage(_spinButtonDisableBitmap))
        {
          dc.Clear(Color.Transparent);
          visualStyleRenderer3.DrawBackground(dc, new Rectangle(0, 1, 16, _height / 2 - 1));
          visualStyleRenderer4.DrawBackground(dc, new Rectangle(0, _height / 2, 16, _height / 2 - 1));
        }
      }
      else
      {
        using (Graphics graphics = Graphics.FromImage(_spinButtonEnableBitmap))
        {
          graphics.Clear(Color.Transparent);
          ControlPaint.DrawScrollButton(graphics, new Rectangle(0, 2, 16, (_height - 4) / 2), ScrollButton.Up, ButtonState.Normal);
          ControlPaint.DrawScrollButton(graphics, new Rectangle(0, _height / 2, 16, (_height - 4) / 2), ScrollButton.Down, ButtonState.Normal);
        }
      }
    }

    public override void DrawControl(Graphics graphic)
    {
    }

    public override void MouseEnter()
    {
    }

    private void _innerNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is SafeNumericUpDown safeNumericUpDown))
        return;
      _value = safeNumericUpDown.Value;
      if (ValueChanged == null)
        return;
      ValueChanged(this, e);
    }

    private void EntityNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is SafeNumericUpDown safeNumericUpDown))
        return;
      _value = safeNumericUpDown.Value;
      if (ValueChanged == null)
        return;
      ValueChanged(this, e);
    }

    public override void MouseLeave()
    {
    }

    private void EntityNumericUpDown_Leave(object sender, EventArgs e)
    {
    }
  }
}
