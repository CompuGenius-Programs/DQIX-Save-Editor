// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionButton
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DQ9_Cheat.Controls.VisionControls
{
  public class VisionButton : VisionControlBase
  {
    private Button _innerButton;
    private static bool _controlInitialized = false;
    private static Button[] _entityButton = new Button[3];
    private static bool[] _controlAdded = new bool[3];
    private int _addedIndex;
    private string _text;

    public VisionButton(
      int left,
      int top,
      int width,
      int height,
      float dpiRateX,
      float dpiRateY)
      : base(left, top, width, height, dpiRateX, dpiRateY)
    {
      _addedIndex = -1;
      _innerButton = new Button();
      _innerControl = _innerButton;
      _innerButton.Size = new Size(_width, _height);
      _innerButton.Location = new Point(_left, _top);
      _innerButton.Click += _innerButton_Click;
    }

    public VisionButton(int left, int top, int width, int height)
      : base(left, top, width, height)
    {
      _addedIndex = -1;
      _innerButton = new Button();
      _innerControl = _innerButton;
      _innerButton.Size = new Size(width, height);
      _innerButton.Location = new Point(left, top);
      _innerButton.Click += _innerButton_Click;
    }

    public event EventHandler Click;

    public string Text
    {
      get => _text;
      set
      {
        if (!(_text != value))
          return;
        _text = value;
        _innerButton.Text = _text;
      }
    }

    protected override void Regist(Control parent)
    {
      parent?.Controls.Add(_innerButton);
    }

    public override void DrawControl(Graphics graphic)
    {
    }

    public override void MouseEnter()
    {
    }

    private void _innerButton_Click(object sender, EventArgs e)
    {
      if (!(sender is Button) || Click == null)
        return;
      Click(this, e);
    }

    private void EntityButton_Click(object sender, EventArgs e)
    {
      if (!(sender is Button) || Click == null)
        return;
      Click(this, e);
    }

    public override void MouseLeave()
    {
    }

    private void EntityButton_Leave(object sender, EventArgs e)
    {
    }
  }
}
