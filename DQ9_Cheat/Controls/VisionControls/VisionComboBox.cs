// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.VisionControls.VisionComboBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls.VisionControls
{
  public class VisionComboBox : VisionControlBase
  {
    private ComboBox _innerComboBox;
    private static bool _controlInitialized = false;
    private static ComboBox[] _entityComboBox = new ComboBox[3];
    private static bool[] _controlAdded = new bool[3];
    private int _addedIndex;
    private int _selectedIndex = -1;
    private string _text;

    public VisionComboBox(
      int left,
      int top,
      int width,
      int height,
      float dpiRateX,
      float dpiRateY)
      : base(left, top, width, height, dpiRateX, dpiRateY)
    {
      this._innerComboBox = new ComboBox();
      this._innerControl = (Control) this._innerComboBox;
      this._innerComboBox.Size = new Size(this._width, this._height);
      this._innerComboBox.Location = new Point(this._left, this._top);
      this._innerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this._innerComboBox.SelectedIndexChanged += new EventHandler(this._innerComboBox_SelectedIndexChanged);
    }

    public VisionComboBox(int left, int top, int width, int height)
      : base(left, top, width, height)
    {
      this._innerComboBox = new ComboBox();
      this._innerControl = (Control) this._innerComboBox;
      this._innerComboBox.Size = new Size(width, height);
      this._innerComboBox.Location = new Point(left, top);
      this._innerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this._innerComboBox.SelectedIndexChanged += new EventHandler(this._innerComboBox_SelectedIndexChanged);
    }

    public event EventHandler SelectedIndexChanged;

    public int SelectedIndex
    {
      get => this._selectedIndex;
      set
      {
        this._selectedIndex = value;
        this._innerComboBox.SelectedIndex = value;
      }
    }

    public ComboBox.ObjectCollection Items => this._innerComboBox.Items;

    public string Text => this._text;

    protected override void Regist(Control parent)
    {
      parent?.Controls.Add((Control) this._innerComboBox);
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
      this._selectedIndex = comboBox.SelectedIndex;
      if (this.SelectedIndexChanged == null)
        return;
      this.SelectedIndexChanged((object) this, e);
    }

    private void EntityComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(sender is ComboBox comboBox))
        return;
      this._selectedIndex = comboBox.SelectedIndex;
      if (this.SelectedIndexChanged == null)
        return;
      this.SelectedIndexChanged((object) this, e);
    }

    public override void MouseLeave()
    {
    }

    private void EntityComboBox_Leave(object sender, EventArgs e)
    {
    }
  }
}
