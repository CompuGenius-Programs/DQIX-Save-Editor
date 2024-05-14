// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionNumericUpDown
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#nullable disable
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
      this._innerNumericUpDown = new SafeNumericUpDown();
      this._innerControl = (Control) this._innerNumericUpDown;
      this._innerNumericUpDown.Location = new Point(this._left, this._top);
      this._innerNumericUpDown.Size = new Size(this._width, this._height);
      this._innerNumericUpDown.ValueChanged += new EventHandler(this._innerNumericUpDown_ValueChanged);
      this._innerNumericUpDown.Leave += new EventHandler(this._innerNumericUpDown_Leave);
      this._innerNumericUpDown.Enter += new EventHandler(this._innerNumericUpDown_Enter);
    }

    public VisionNumericUpDown(int left, int top, int width, int height)
      : base(left, top, width, height)
    {
      this._innerNumericUpDown = new SafeNumericUpDown();
      this._innerControl = (Control) this._innerNumericUpDown;
      this._innerNumericUpDown.TextAlign = HorizontalAlignment.Right;
      this._innerNumericUpDown.Location = new Point(left, top);
      this._innerNumericUpDown.Size = new Size(width, height);
      this._innerNumericUpDown.ValueChanged += new EventHandler(this._innerNumericUpDown_ValueChanged);
      this._innerNumericUpDown.Leave += new EventHandler(this._innerNumericUpDown_Leave);
      this._innerNumericUpDown.Enter += new EventHandler(this._innerNumericUpDown_Enter);
    }

    public event EventHandler Leave;

    public event EventHandler Enter;

    public event EventHandler ValueChanged;

    public Decimal Value
    {
      get => this._value;
      set
      {
        if (!(this._value != value))
          return;
        this._value = value;
        this._innerNumericUpDown.Value = value;
      }
    }

    public Decimal Maximum
    {
      get => this._maximum;
      set
      {
        this._maximum = value;
        this._innerNumericUpDown.Maximum = value;
      }
    }

    public Decimal Minimum
    {
      get => this._minimum;
      set
      {
        this._minimum = value;
        this._innerNumericUpDown.Minimum = value;
      }
    }

    public bool Hexadecimal
    {
      get => this._innerNumericUpDown.Hexadecimal;
      set => this._innerNumericUpDown.Hexadecimal = value;
    }

    public bool ReadOnly
    {
      get => this._readOnly;
      set
      {
        this._readOnly = value;
        this._innerNumericUpDown.ReadOnly = value;
      }
    }

    private void _innerNumericUpDown_Leave(object sender, EventArgs e)
    {
      if (this.Leave == null)
        return;
      this.Leave((object) this, e);
    }

    private void _innerNumericUpDown_Enter(object sender, EventArgs e)
    {
      if (this.Enter == null)
        return;
      this.Enter((object) this, e);
    }

    protected override void Regist(Control parent)
    {
      parent?.Controls.Add((Control) this._innerNumericUpDown);
    }

    private void InitializeSpinButton()
    {
      this._spinButtonEnableBitmap = new Bitmap(16, this._height);
      this._spinButtonDisableBitmap = new Bitmap(16, this._height);
      if (VisualStyleRenderer.IsSupported)
      {
        VisualStyleElement normal1 = VisualStyleElement.Spin.Up.Normal;
        VisualStyleRenderer visualStyleRenderer1 = new VisualStyleRenderer(normal1.ClassName, normal1.Part, normal1.State);
        VisualStyleElement normal2 = VisualStyleElement.Spin.Down.Normal;
        VisualStyleRenderer visualStyleRenderer2 = new VisualStyleRenderer(normal2.ClassName, normal2.Part, normal2.State);
        using (Graphics dc = Graphics.FromImage((Image) this._spinButtonEnableBitmap))
        {
          dc.Clear(Color.Transparent);
          visualStyleRenderer1.DrawBackground((IDeviceContext) dc, new Rectangle(0, 1, 16, this._height / 2 - 1));
          visualStyleRenderer2.DrawBackground((IDeviceContext) dc, new Rectangle(0, this._height / 2, 16, this._height / 2 - 1));
        }
        VisualStyleElement disabled1 = VisualStyleElement.Spin.Up.Disabled;
        VisualStyleRenderer visualStyleRenderer3 = new VisualStyleRenderer(disabled1.ClassName, disabled1.Part, disabled1.State);
        VisualStyleElement disabled2 = VisualStyleElement.Spin.Down.Disabled;
        VisualStyleRenderer visualStyleRenderer4 = new VisualStyleRenderer(disabled2.ClassName, disabled2.Part, disabled2.State);
        using (Graphics dc = Graphics.FromImage((Image) this._spinButtonDisableBitmap))
        {
          dc.Clear(Color.Transparent);
          visualStyleRenderer3.DrawBackground((IDeviceContext) dc, new Rectangle(0, 1, 16, this._height / 2 - 1));
          visualStyleRenderer4.DrawBackground((IDeviceContext) dc, new Rectangle(0, this._height / 2, 16, this._height / 2 - 1));
        }
      }
      else
      {
        using (Graphics graphics = Graphics.FromImage((Image) this._spinButtonEnableBitmap))
        {
          graphics.Clear(Color.Transparent);
          ControlPaint.DrawScrollButton(graphics, new Rectangle(0, 2, 16, (this._height - 4) / 2), ScrollButton.Up, ButtonState.Normal);
          ControlPaint.DrawScrollButton(graphics, new Rectangle(0, this._height / 2, 16, (this._height - 4) / 2), ScrollButton.Down, ButtonState.Normal);
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
      if (this._updateCount != 0 || !(sender is SafeNumericUpDown safeNumericUpDown))
        return;
      this._value = safeNumericUpDown.Value;
      if (this.ValueChanged == null)
        return;
      this.ValueChanged((object) this, e);
    }

    private void EntityNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is SafeNumericUpDown safeNumericUpDown))
        return;
      this._value = safeNumericUpDown.Value;
      if (this.ValueChanged == null)
        return;
      this.ValueChanged((object) this, e);
    }

    public override void MouseLeave()
    {
    }

    private void EntityNumericUpDown_Leave(object sender, EventArgs e)
    {
    }
  }
}
