// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.SmartItemDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using JS_Framework.Controls;

namespace DQ9_Cheat.Controls;

public class SmartItemDataControl : DataControlBase
{
    private const int ControlMarginLeft = 30;
    private const int ControlMarginTop = 8;
    private const int ControlMarginWidth = 60;
    private const int ControlMarginHeight = 0;
    private const int Horizontal = 4;
    private const int Vertical = 12;
    private const int ControlCount = 48;
    private const int CheckBox_Width = 130;
    private const int CheckBox_Height = 30;
    private readonly bool[] _checkBox_Checked = new bool[48];
    private Bitmap[] _checkBoxBitmap = new Bitmap[2];
    private ItemDataBase[] _itemList;
    private int _lastMouseOverIndex = -1;
    private Bitmap _panelBitmap;
    private VScrollBar _vScrollBar;
    private Button button_AllCheck;
    private Button button_AllUncheck;
    private ComboBox comboBox_SelectType;
    private IContainer components;
    private Label label_CollectionCount;
    private Label label_CompRate;
    private Label label_TitleCount;
    private Label label1;
    private DoubleBufferedPanel panel;
    private TextBox textBox_Dummy;

    public SmartItemDataControl()
    {
        AutoScaleMode = AutoScaleMode.None;
        InitializeComponent();
        Disposed += SmartItemDataControl_Disposed;
    }

    private void SmartItemDataControl_Disposed(object sender, EventArgs e)
    {
        for (var index = 0; index < 2; ++index)
            if (_checkBoxBitmap[index] != null)
            {
                _checkBoxBitmap[index].Dispose();
                _checkBoxBitmap[index] = null;
            }

        _checkBoxBitmap = null;
        if (_panelBitmap == null)
            return;
        _panelBitmap.Dispose();
        _panelBitmap = null;
    }

    public void Initialize()
    {
        BeginUpdate();
        comboBox_SelectType.SelectedIndex = 0;
        for (var index = 0; index < 48; ++index)
            _checkBox_Checked[index] = false;
        _panelBitmap = new Bitmap(panel.Width, panel.Height);
        panel.MouseMove += panel_MouseMove;
        panel.MouseWheel += panel_MouseWheel;
        using (Graphics.FromHwnd(Handle))
        {
            var width = 20;
            var height = 20;
            for (var index = 0; index < 2; ++index)
            {
                _checkBoxBitmap[index] = new Bitmap(width, height);
                using (var graphics = Graphics.FromImage(_checkBoxBitmap[index]))
                {
                    graphics.Clear(Color.Transparent);
                    if (VisualStyleRenderer.IsSupported)
                        CheckBoxRenderer.DrawCheckBox(graphics, new Point(0, 0),
                            index == 0 ? CheckBoxState.UncheckedNormal : CheckBoxState.CheckedNormal);
                    else if (index == 0)
                        ControlPaint.DrawCheckBox(graphics, 0, 0, width, height, ButtonState.Normal);
                    else
                        ControlPaint.DrawCheckBox(graphics, 0, 0, width, height, ButtonState.Checked);
                }
            }
        }

        EndUpdate();
    }

    private void RenewalCollectionCount()
    {
        var smartItemData = SaveDataManager.Instance.SaveData.SmartItemData;
        var num1 = 0;
        foreach (var itemDataBase in _itemList)
            if (smartItemData.IsSmartItemHold(itemDataBase.DataIndex))
                ++num1;
        label_CollectionCount.Text = string.Format("{0} Types", num1);
        var num2 = (int)(smartItemData.CompCount / 944.0 * 100.0);
        if (num2 == 0 && smartItemData.CompCount > 0)
            num2 = 1;
        label_CompRate.Text = string.Format("{0}%", num2);
    }

    private int CheckBoxHitTest(int x, int y)
    {
        if (x < 30)
            return -1;
        x -= 30;
        if (x % 190 > 130 || y % 30 > 30)
            return -1;
        var num1 = x / 190;
        var num2 = y / 30;
        if (num1 >= 4 || num2 >= 12)
            return -1;
        var num3 = num2 * 4 + num1;
        return num3 + _vScrollBar.Value * 4 < _itemList.Length ? num3 : -1;
    }

    private void panel_MouseMove(object sender, MouseEventArgs e)
    {
        var index = CheckBoxHitTest(e.X, e.Y);
        if (_lastMouseOverIndex == index)
            return;
        if (_lastMouseOverIndex != -1)
            DrawCheckBox(null, _lastMouseOverIndex,
                _checkBox_Checked[_lastMouseOverIndex] ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal);
        _lastMouseOverIndex = index;
        if (index == -1)
            return;
        DrawCheckBox(null, index, _checkBox_Checked[index] ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot);
    }

    private void panel_MouseDown(object sender, MouseEventArgs e)
    {
        var index1 = CheckBoxHitTest(e.X, e.Y);
        if (index1 == -1)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        var index2 = _vScrollBar.Value * 4 + index1;
        _checkBox_Checked[index1] = !_checkBox_Checked[index1];
        DrawCheckBox(null, index1, _checkBox_Checked[index1] ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot);
        SaveDataManager.Instance.SaveData.SmartItemData.SetSmartItemHold(_itemList[index2].DataIndex,
            _checkBox_Checked[index1]);
        SaveDataManager.Instance.SaveData.SmartItemData.ReviseCompCount();
        RenewalCollectionCount();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    private void panel_MouseWheel(object sender, MouseEventArgs e)
    {
        if (e.Delta < 0)
        {
            if (_vScrollBar.Value >= _vScrollBar.Maximum - _vScrollBar.LargeChange + 1)
                return;
            textBox_Dummy.Focus();
            ++_vScrollBar.Value;
            OnValueUpdate();
        }
        else
        {
            if (_vScrollBar.Value <= _vScrollBar.Minimum)
                return;
            textBox_Dummy.Focus();
            --_vScrollBar.Value;
            OnValueUpdate();
        }
    }

    private void CheckBox_TitleHold_CheckedChanged(object sender, EventArgs e)
    {
    }

    protected override void OnDataFileLoad()
    {
    }

    protected override void OnValueUpdate()
    {
        BeginUpdate();
        SetSmartItemData();
        panelPaint();
        RenewalCollectionCount();
        _lastMouseOverIndex = -1;
        EndUpdate();
    }

    private void SetSmartItemData()
    {
        var smartItemData = SaveDataManager.Instance.SaveData.SmartItemData;
        var index1 = 0;
        var index2 = _vScrollBar.Value * 4;
        for (var index3 = 0; index3 < 12; ++index3)
        for (var index4 = 0; index4 < 4; ++index4)
        {
            if (index2 < _itemList.Length)
                _checkBox_Checked[index1] = smartItemData.IsSmartItemHold(_itemList[index2].DataIndex);
            ++index1;
            ++index2;
        }
    }

    private void panel_Paint(object sender, PaintEventArgs e)
    {
        panelPaint(e.Graphics);
    }

    private void panelPaint()
    {
        using (var panelGraphics = Graphics.FromHwnd(panel.Handle))
        {
            panelPaint(panelGraphics);
        }
    }

    private void panelPaint(Graphics panelGraphics)
    {
        using (var g = Graphics.FromImage(_panelBitmap))
        {
            using (Brush brush1 = new SolidBrush(ForeColor))
            {
                using (Brush brush2 = new SolidBrush(SystemColors.ControlLight))
                {
                    using (Brush brush3 = new SolidBrush(SystemColors.Control))
                    {
                        g.FillRectangle(brush3, new Rectangle(0, 0, _panelBitmap.Width, _panelBitmap.Height));
                        var index1 = _vScrollBar.Value <= _vScrollBar.Maximum - _vScrollBar.LargeChange + 1
                            ? _vScrollBar.Value * 4
                            : (_vScrollBar.Maximum - _vScrollBar.LargeChange + 1) * 4;
                        if (index1 < 0)
                            index1 = 0;
                        var index2 = 0;
                        var y = 8;
                        for (var index3 = 0; index3 < 12; ++index3)
                        {
                            if ((index3 & 1) == 1)
                                g.FillRectangle(brush2, new Rectangle(0, index3 * 30, panel.Width, 30));
                            var x = 48;
                            for (var index4 = 0; index4 < 4; ++index4)
                            {
                                if (index1 < _itemList.Length)
                                {
                                    var itemDataBase = _itemList[index1];
                                    g.DrawString(itemDataBase.Name, Font, brush1, x, y);
                                    DrawCheckBox(g, index2,
                                        _checkBox_Checked[index2]
                                            ? CheckBoxState.CheckedNormal
                                            : CheckBoxState.UncheckedNormal);
                                }

                                x += 190;
                                ++index1;
                                ++index2;
                            }

                            y += 30;
                        }
                    }
                }
            }
        }

        panelGraphics.DrawImage(_panelBitmap, Point.Empty);
    }

    private void textBox_Dummy_KeyDown(object sender, KeyEventArgs e)
    {
        BeginUpdate();
        if (_vScrollBar.Value != _vScrollBar.Minimum)
        {
            if (e.KeyCode == Keys.Home)
            {
                _vScrollBar.Value = _vScrollBar.Minimum;
                OnValueUpdate();
            }
            else if (e.KeyCode == Keys.Prior)
            {
                if (_vScrollBar.Value - _vScrollBar.LargeChange < _vScrollBar.Minimum)
                    _vScrollBar.Value = _vScrollBar.Minimum;
                else
                    _vScrollBar.Value -= _vScrollBar.LargeChange;
                OnValueUpdate();
            }
        }

        if (_vScrollBar.Value != _vScrollBar.Maximum - _vScrollBar.LargeChange + 1)
        {
            if (e.KeyCode == Keys.End)
            {
                _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange + 1;
                OnValueUpdate();
            }
            else if (e.KeyCode == Keys.Next)
            {
                if (_vScrollBar.Value + _vScrollBar.LargeChange > _vScrollBar.Maximum - _vScrollBar.LargeChange)
                    _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange + 1;
                else
                    _vScrollBar.Value += _vScrollBar.LargeChange;
                OnValueUpdate();
            }
        }

        EndUpdate();
    }

    public void DrawCheckBox(Graphics g, int index, CheckBoxState state)
    {
        var x = 30 + 190 * (index % 4);
        var y = 8 + 30 * (index / 4);
        if (g != null)
        {
            if (VisualStyleRenderer.IsSupported)
            {
                if (state == CheckBoxState.CheckedNormal)
                    g.DrawImage(_checkBoxBitmap[1], new Point(x, y));
                else if (state == CheckBoxState.UncheckedNormal)
                    g.DrawImage(_checkBoxBitmap[0], new Point(x, y));
                else
                    CheckBoxRenderer.DrawCheckBox(g, new Point(x, y), state);
            }
            else if (state == CheckBoxState.CheckedHot || state == CheckBoxState.CheckedNormal)
            {
                g.DrawImage(_checkBoxBitmap[1], new Point(x, y));
            }
            else
            {
                g.DrawImage(_checkBoxBitmap[0], new Point(x, y));
            }
        }
        else
        {
            using (g = Graphics.FromHwnd(panel.Handle))
            {
                if (VisualStyleRenderer.IsSupported)
                {
                    if (state == CheckBoxState.CheckedNormal)
                        g.DrawImage(_checkBoxBitmap[1], new Point(x, y));
                    else if (state == CheckBoxState.UncheckedNormal)
                        g.DrawImage(_checkBoxBitmap[0], new Point(x, y));
                    else
                        CheckBoxRenderer.DrawCheckBox(g, new Point(x, y), state);
                }
                else if (state == CheckBoxState.CheckedHot || state == CheckBoxState.CheckedNormal)
                {
                    g.DrawImage(_checkBoxBitmap[1], new Point(x, y));
                }
                else
                {
                    g.DrawImage(_checkBoxBitmap[0], new Point(x, y));
                }
            }
        }
    }

    private void RenewalScrollBar()
    {
        _vScrollBar.Value = 0;
        _vScrollBar.Maximum = _itemList.Length / 4 - 1;
        if (_itemList.Length % 4 != 0)
            ++_vScrollBar.Maximum;
        _vScrollBar.LargeChange = 12;
        if (_vScrollBar.Maximum < _vScrollBar.LargeChange)
            _vScrollBar.Visible = false;
        else
            _vScrollBar.Visible = true;
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        BeginUpdate();
        if (_vScrollBar.Value > _vScrollBar.Maximum - _vScrollBar.LargeChange + 1)
        {
            var num = _vScrollBar.Maximum - _vScrollBar.LargeChange + 1;
            if (num < 0)
                num = 0;
            _vScrollBar.Value = num;
        }

        textBox_Dummy.Focus();
        OnValueUpdate();
        EndUpdate();
    }

    private void SmartItemDataControl_Click(object sender, EventArgs e)
    {
        textBox_Dummy.Focus();
    }

    private void panel_Click(object sender, EventArgs e)
    {
        textBox_Dummy.Focus();
    }

    private void button_AllCheck_Click(object sender, EventArgs e)
    {
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        for (var index = 0; index < _itemList.Length; ++index)
            SaveDataManager.Instance.SaveData.SmartItemData.SetSmartItemHold(_itemList[index].DataIndex, true);
        SaveDataManager.Instance.SaveData.SmartItemData.ReviseCompCount();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        OnValueUpdate();
    }

    private void button_AllUncheck_Click(object sender, EventArgs e)
    {
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        for (var index = 0; index < _itemList.Length; ++index)
            SaveDataManager.Instance.SaveData.SmartItemData.SetSmartItemHold(_itemList[index].DataIndex, false);
        SaveDataManager.Instance.SaveData.SmartItemData.ReviseCompCount();
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        OnValueUpdate();
    }

    private void comboBox_SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedIndex = comboBox_SelectType.SelectedIndex;
        _itemList = selectedIndex != 0
            ? selectedIndex >= 13
                ? ItemDataList.GetList((ItemType)(selectedIndex - 10), null)
                : ItemDataList.GetWeaponList((WeaponType)(selectedIndex - 1))
            : ItemDataList.GetAllSmartList();
        RenewalScrollBar();
        if (_updateCount != 0)
            return;
        SetSmartItemData();
        panelPaint();
        RenewalCollectionCount();
    }

    private void _vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
        if (e.Type == ScrollEventType.LargeDecrement)
        {
            if (e.OldValue - e.NewValue < _vScrollBar.LargeChange)
                return;
            ++e.NewValue;
        }
        else
        {
            if (e.Type != ScrollEventType.LargeIncrement || e.NewValue - e.OldValue < _vScrollBar.LargeChange)
                return;
            --e.NewValue;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panel = new DoubleBufferedPanel();
        textBox_Dummy = new TextBox();
        _vScrollBar = new VScrollBar();
        label_TitleCount = new Label();
        button_AllCheck = new Button();
        button_AllUncheck = new Button();
        comboBox_SelectType = new ComboBox();
        label1 = new Label();
        label_CompRate = new Label();
        label_CollectionCount = new Label();
        panel.SuspendLayout();
        SuspendLayout();
        panel.BorderStyle = BorderStyle.Fixed3D;
        panel.Controls.Add(textBox_Dummy);
        panel.Controls.Add(_vScrollBar);
        panel.Location = new Point(14, 56);
        panel.Name = "panel";
        panel.Size = new Size(806, 373);
        panel.TabIndex = 0;
        panel.Paint += panel_Paint;
        panel.Click += panel_Click;
        panel.MouseDown += panel_MouseDown;
        textBox_Dummy.Location = new Point(-100, -100);
        textBox_Dummy.Name = "textBox_Dummy";
        textBox_Dummy.ReadOnly = true;
        textBox_Dummy.Size = new Size(100, 19);
        textBox_Dummy.TabIndex = 1;
        textBox_Dummy.KeyDown += textBox_Dummy_KeyDown;
        _vScrollBar.Dock = DockStyle.Right;
        _vScrollBar.Location = new Point(785, 0);
        _vScrollBar.Name = "_vScrollBar";
        _vScrollBar.Size = new Size(17, 369);
        _vScrollBar.TabIndex = 0;
        _vScrollBar.ValueChanged += _vScrollBar_ValueChanged;
        _vScrollBar.Scroll += _vScrollBar_Scroll;
        label_TitleCount.AutoSize = true;
        label_TitleCount.Location = new Point(141, 34);
        label_TitleCount.Name = "label_TitleCount";
        label_TitleCount.Size = new Size(48, 12);
        label_TitleCount.TabIndex = 1;
        label_TitleCount.Text = "Amount:";
        button_AllCheck.Location = new Point(548, 27);
        button_AllCheck.Name = "button_AllCheck";
        button_AllCheck.Size = new Size(133, 23);
        button_AllCheck.TabIndex = 4;
        button_AllCheck.Text = "Check All";
        button_AllCheck.UseVisualStyleBackColor = true;
        button_AllCheck.Click += button_AllCheck_Click;
        button_AllUncheck.Location = new Point(687, 27);
        button_AllUncheck.Name = "button_AllUncheck";
        button_AllUncheck.Size = new Size(133, 23);
        button_AllUncheck.TabIndex = 5;
        button_AllUncheck.Text = "Uncheck All";
        button_AllUncheck.UseVisualStyleBackColor = true;
        button_AllUncheck.Click += button_AllUncheck_Click;
        comboBox_SelectType.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_SelectType.FormattingEnabled = true;
        comboBox_SelectType.Items.AddRange(new object[20]
        {
            "All",
            "Swords",
            "Spears",
            "Knives",
            "Wands",
            "Whips",
            "Staves",
            "Claws",
            "Fans",
            "Axes",
            "Hammers",
            "Boomerangs",
            "Bows",
            "Shields",
            "Head",
            "Torso",
            "Arms",
            "Legs",
            "Feet",
            "Accessories"
        });
        comboBox_SelectType.Location = new Point(14, 30);
        comboBox_SelectType.Name = "comboBox_SelectType";
        comboBox_SelectType.Size = new Size(121, 20);
        comboBox_SelectType.TabIndex = 6;
        comboBox_SelectType.SelectedIndexChanged += comboBox_SelectType_SelectedIndexChanged;
        label1.AutoSize = true;
        label1.Location = new Point(13, 11);
        label1.Name = "label1";
        label1.Size = new Size(116, 12);
        label1.TabIndex = 7;
        label1.Text = "Completion Rate";
        label_CompRate.AutoSize = true;
        label_CompRate.Location = new Point(135, 11);
        label_CompRate.Name = "label_CompRate";
        label_CompRate.Size = new Size(17, 12);
        label_CompRate.TabIndex = 8;
        label_CompRate.Text = "0%";
        label_CollectionCount.AutoSize = true;
        label_CollectionCount.Location = new Point(195, 34);
        label_CollectionCount.Name = "label_CollectionCount";
        label_CollectionCount.Size = new Size(35, 12);
        label_CollectionCount.TabIndex = 9;
        label_CollectionCount.Text = "0 types";
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(label_CollectionCount);
        Controls.Add(label_CompRate);
        Controls.Add(label1);
        Controls.Add(comboBox_SelectType);
        Controls.Add(button_AllUncheck);
        Controls.Add(button_AllCheck);
        Controls.Add(label_TitleCount);
        Controls.Add(panel);
        Name = nameof(SmartItemDataControl);
        Size = new Size(887, 500);
        Click += SmartItemDataControl_Click;
        panel.ResumeLayout(false);
        panel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}