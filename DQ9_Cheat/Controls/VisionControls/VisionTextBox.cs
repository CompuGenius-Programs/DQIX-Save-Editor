// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionTextBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls.VisionControls
{
  public class VisionTextBox : VisionControlBase
  {
    private TextBox _innerTextBox;
    private static bool _controlInitialized = false;
    private static TextBox[] _entityButton = new TextBox[2];
    private static bool[] _controlAdded = new bool[2];
    private int _addedIndex;
    private string _text;
    private bool _readOnly;

    public VisionTextBox(
      int left,
      int top,
      int width,
      int height,
      float dpiRateX,
      float dpiRateY)
      : base(left, top, width, height, dpiRateX, dpiRateY)
    {
      this._innerTextBox = new TextBox();
      this._innerControl = (Control) this._innerTextBox;
      this._innerTextBox.Size = new Size(this._width, this._height);
      this._innerTextBox.Location = new Point(this._left, this._top);
      this._innerTextBox.TextChanged += new EventHandler(this._innerTextBox_TextChanged);
      this._addedIndex = -1;
    }

    public VisionTextBox(int left, int top, int width, int height)
      : base(left, top, width, height)
    {
      this._innerTextBox = new TextBox();
      this._innerControl = (Control) this._innerTextBox;
      this._innerTextBox.Size = new Size(width, height);
      this._innerTextBox.Location = new Point(left, top);
      this._innerTextBox.TextChanged += new EventHandler(this._innerTextBox_TextChanged);
      this._addedIndex = -1;
    }

    public event EventHandler TextChanged;

    public string Text
    {
      get => this._text;
      set
      {
        if (!(this._text != value))
          return;
        this._text = value;
        this._innerTextBox.Text = value;
      }
    }

    public int SelectionStart
    {
      get => this._innerTextBox.SelectionStart;
      set => this._innerTextBox.SelectionStart = value;
    }

    public bool ReadOnly
    {
      get => this._readOnly;
      set
      {
        this._readOnly = value;
        this._innerTextBox.ReadOnly = value;
      }
    }

    protected override void Regist(Control parent)
    {
      parent?.Controls.Add((Control) this._innerTextBox);
    }

    public override void DrawControl(Graphics graphic)
    {
    }

    public override void MouseEnter()
    {
    }

    private void _innerTextBox_TextChanged(object sender, EventArgs e)
    {
      if (!(sender is TextBox textBox))
        return;
      this._text = textBox.Text;
      if (this.TextChanged == null)
        return;
      this.TextChanged(sender, e);
    }

    private void EntityTextBox_TextChanged(object sender, EventArgs e)
    {
      if (!(sender is TextBox textBox))
        return;
      this._text = textBox.Text;
      if (this.TextChanged == null)
        return;
      this.TextChanged(sender, e);
    }

    public override void MouseLeave()
    {
    }

    private void EntityTextBox_Leave(object sender, EventArgs e)
    {
    }
  }
}
