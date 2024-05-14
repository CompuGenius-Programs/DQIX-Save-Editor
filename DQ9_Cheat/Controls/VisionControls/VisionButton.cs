// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionButton
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
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
      this._addedIndex = -1;
      this._innerButton = new Button();
      this._innerControl = (Control) this._innerButton;
      this._innerButton.Size = new Size(this._width, this._height);
      this._innerButton.Location = new Point(this._left, this._top);
      this._innerButton.Click += new EventHandler(this._innerButton_Click);
    }

    public VisionButton(int left, int top, int width, int height)
      : base(left, top, width, height)
    {
      this._addedIndex = -1;
      this._innerButton = new Button();
      this._innerControl = (Control) this._innerButton;
      this._innerButton.Size = new Size(width, height);
      this._innerButton.Location = new Point(left, top);
      this._innerButton.Click += new EventHandler(this._innerButton_Click);
    }

    public event EventHandler Click;

    public string Text
    {
      get => this._text;
      set
      {
        if (!(this._text != value))
          return;
        this._text = value;
        this._innerButton.Text = this._text;
      }
    }

    protected override void Regist(Control parent)
    {
      parent?.Controls.Add((Control) this._innerButton);
    }

    public override void DrawControl(Graphics graphic)
    {
    }

    public override void MouseEnter()
    {
    }

    private void _innerButton_Click(object sender, EventArgs e)
    {
      if (!(sender is Button) || this.Click == null)
        return;
      this.Click((object) this, e);
    }

    private void EntityButton_Click(object sender, EventArgs e)
    {
      if (!(sender is Button) || this.Click == null)
        return;
      this.Click((object) this, e);
    }

    public override void MouseLeave()
    {
    }

    private void EntityButton_Leave(object sender, EventArgs e)
    {
    }
  }
}
