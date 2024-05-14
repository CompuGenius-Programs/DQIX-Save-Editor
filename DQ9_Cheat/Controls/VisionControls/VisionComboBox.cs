// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionComboBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DQ9_Cheat.Controls.VisionControls;

public class VisionComboBox : VisionControlBase
{
    private static bool _controlInitialized = false;
    private static ComboBox[] _entityComboBox = new ComboBox[3];
    private static bool[] _controlAdded = new bool[3];
    private int _addedIndex;
    private readonly ComboBox _innerComboBox;
    private int _selectedIndex = -1;

    public VisionComboBox(
        int left,
        int top,
        int width,
        int height,
        float dpiRateX,
        float dpiRateY)
        : base(left, top, width, height, dpiRateX, dpiRateY)
    {
        _innerComboBox = new ComboBox();
        _innerControl = _innerComboBox;
        _innerComboBox.Size = new Size(_width, _height);
        _innerComboBox.Location = new Point(_left, _top);
        _innerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        _innerComboBox.SelectedIndexChanged += _innerComboBox_SelectedIndexChanged;
    }

    public VisionComboBox(int left, int top, int width, int height)
        : base(left, top, width, height)
    {
        _innerComboBox = new ComboBox();
        _innerControl = _innerComboBox;
        _innerComboBox.Size = new Size(width, height);
        _innerComboBox.Location = new Point(left, top);
        _innerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        _innerComboBox.SelectedIndexChanged += _innerComboBox_SelectedIndexChanged;
    }

    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            _selectedIndex = value;
            _innerComboBox.SelectedIndex = value;
        }
    }

    public ComboBox.ObjectCollection Items => _innerComboBox.Items;

    public string Text { get; }

    public event EventHandler SelectedIndexChanged;

    protected override void Regist(Control parent)
    {
        parent?.Controls.Add(_innerComboBox);
    }

    public override void DrawControl(Graphics graphic)
    {
    }

    public override void MouseEnter()
    {
    }

    private void _innerComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(sender is ComboBox comboBox))
            return;
        _selectedIndex = comboBox.SelectedIndex;
        if (SelectedIndexChanged == null)
            return;
        SelectedIndexChanged(this, e);
    }

    private void EntityComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!(sender is ComboBox comboBox))
            return;
        _selectedIndex = comboBox.SelectedIndex;
        if (SelectedIndexChanged == null)
            return;
        SelectedIndexChanged(this, e);
    }

    public override void MouseLeave()
    {
    }

    private void EntityComboBox_Leave(object sender, EventArgs e)
    {
    }
}