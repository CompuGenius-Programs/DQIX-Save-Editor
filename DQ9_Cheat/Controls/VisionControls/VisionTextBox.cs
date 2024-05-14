// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionTextBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DQ9_Cheat.Controls.VisionControls;

public class VisionTextBox : VisionControlBase
{
    private static bool _controlInitialized = false;
    private static TextBox[] _entityButton = new TextBox[2];
    private static bool[] _controlAdded = new bool[2];
    private int _addedIndex;
    private readonly TextBox _innerTextBox;
    private bool _readOnly;
    private string _text;

    public VisionTextBox(
        int left,
        int top,
        int width,
        int height,
        float dpiRateX,
        float dpiRateY)
        : base(left, top, width, height, dpiRateX, dpiRateY)
    {
        _innerTextBox = new TextBox();
        _innerControl = _innerTextBox;
        _innerTextBox.Size = new Size(_width, _height);
        _innerTextBox.Location = new Point(_left, _top);
        _innerTextBox.TextChanged += _innerTextBox_TextChanged;
        _addedIndex = -1;
    }

    public VisionTextBox(int left, int top, int width, int height)
        : base(left, top, width, height)
    {
        _innerTextBox = new TextBox();
        _innerControl = _innerTextBox;
        _innerTextBox.Size = new Size(width, height);
        _innerTextBox.Location = new Point(left, top);
        _innerTextBox.TextChanged += _innerTextBox_TextChanged;
        _addedIndex = -1;
    }

    public string Text
    {
        get => _text;
        set
        {
            if (!(_text != value))
                return;
            _text = value;
            _innerTextBox.Text = value;
        }
    }

    public int SelectionStart
    {
        get => _innerTextBox.SelectionStart;
        set => _innerTextBox.SelectionStart = value;
    }

    public bool ReadOnly
    {
        get => _readOnly;
        set
        {
            _readOnly = value;
            _innerTextBox.ReadOnly = value;
        }
    }

    public event EventHandler TextChanged;

    protected override void Regist(Control parent)
    {
        parent?.Controls.Add(_innerTextBox);
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
        _text = textBox.Text;
        if (TextChanged == null)
            return;
        TextChanged(sender, e);
    }

    private void EntityTextBox_TextChanged(object sender, EventArgs e)
    {
        if (!(sender is TextBox textBox))
            return;
        _text = textBox.Text;
        if (TextChanged == null)
            return;
        TextChanged(sender, e);
    }

    public override void MouseLeave()
    {
    }

    private void EntityTextBox_Leave(object sender, EventArgs e)
    {
    }
}