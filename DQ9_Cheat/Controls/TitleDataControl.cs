// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.TitleDataControl
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

public class TitleDataControl : DataControlBase
{
    private const int ControlMarginLeft = 40;
    private const int ControlMarginTop = 32;
    private const int ControlMarginWidth = 40;
    private const int ControlMarginHeight = 5;
    private const int Horizontal = 3;
    private const int Vertical = 10;
    private const int ControlCount = 30;
    private const int CheckBox_Width = 160;
    private const int CheckBox_Height = 30;
    private readonly bool[] _checkBox_Checked = new bool[30];
    private Bitmap[] _checkBoxBitmap = new Bitmap[2];
    private int _lastMouseOverIndex;
    private Bitmap _panelBitmap;
    private bool _reviseCount;
    private VScrollBar _vScrollBar;
    private Button button_AllCheck;
    private Button button_AllUncheck;
    private IContainer components;
    private Label label_TitleCount;
    private Label label1;
    private DoubleBufferedPanel panel;
    private TextBox textBox_Dummy;
    private TextBox textBox_TitleCount;

    public TitleDataControl()
    {
        AutoScaleMode = AutoScaleMode.None;
        InitializeComponent();
        Disposed += TitleDataControl_Disposed;
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
        textBox_TitleCount = new TextBox();
        label1 = new Label();
        button_AllCheck = new Button();
        button_AllUncheck = new Button();
        panel.SuspendLayout();
        SuspendLayout();
        panel.BorderStyle = BorderStyle.Fixed3D;
        panel.Controls.Add(textBox_Dummy);
        panel.Controls.Add(_vScrollBar);
        panel.Location = new Point(42, 38);
        panel.Name = "panel";
        panel.Size = new Size(619, 386);
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
        _vScrollBar.Location = new Point(598, 0);
        _vScrollBar.Name = "_vScrollBar";
        _vScrollBar.Size = new Size(17, 382);
        _vScrollBar.TabIndex = 0;
        _vScrollBar.ValueChanged += _vScrollBar_ValueChanged;
        label_TitleCount.AutoSize = true;
        label_TitleCount.Location = new Point(40, 16);
        label_TitleCount.Name = "label_TitleCount";
        label_TitleCount.Size = new Size(65, 12);
        label_TitleCount.TabIndex = 1;
        label_TitleCount.Text = "Accolades";
        textBox_TitleCount.Location = new Point(111, 12);
        textBox_TitleCount.Name = "textBox_TitleCount";
        textBox_TitleCount.ReadOnly = true;
        textBox_TitleCount.Size = new Size(100, 19);
        textBox_TitleCount.TabIndex = 2;
        label1.AutoSize = true;
        label1.Location = new Point(40, 421);
        label1.Name = "label1";
        label1.Size = new Size(364, 12);
        label1.TabIndex = 3;
        label1.Text = "The top name is for male characters, the bottom is for females.";
        button_AllCheck.Location = new Point(234, 10);
        button_AllCheck.Name = "button_AllCheck";
        button_AllCheck.Size = new Size(133, 23);
        button_AllCheck.TabIndex = 4;
        button_AllCheck.Text = "Check all";
        button_AllCheck.UseVisualStyleBackColor = true;
        button_AllCheck.Click += button_AllCheck_Click;
        button_AllUncheck.Location = new Point(373, 10);
        button_AllUncheck.Name = "button_AllUncheck";
        button_AllUncheck.Size = new Size(133, 23);
        button_AllUncheck.TabIndex = 5;
        button_AllUncheck.Text = "Uncheck all";
        button_AllUncheck.UseVisualStyleBackColor = true;
        button_AllUncheck.Click += button_AllUncheck_Click;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(button_AllUncheck);
        Controls.Add(button_AllCheck);
        Controls.Add(label1);
        Controls.Add(textBox_TitleCount);
        Controls.Add(label_TitleCount);
        Controls.Add(panel);
        DoubleBuffered = true;
        Name = nameof(TitleDataControl);
        Size = new Size(698, 500);
        Click += TitleDataControl_Click;
        panel.ResumeLayout(false);
        panel.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private void TitleDataControl_Disposed(object sender, EventArgs e)
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
        for (var index = 0; index < 30; ++index)
            _checkBox_Checked[index] = false;
        RenewalScrollBar();
        _panelBitmap = new Bitmap(panel.Width, panel.Height);
        panel.MouseMove += panel_MouseMove;
        panel.MouseWheel += panel_MouseWheel;
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

    private void RenewalTitleCount()
    {
        textBox_TitleCount.Text = SaveDataManager.Instance.SaveData.TitleData.TitleCount.ToString();
    }

    private int CheckBoxHitTest(int x, int y)
    {
        if (x < 40 || y < 20)
            return -1;
        x -= 40;
        y -= 20;
        if (x % 200 > 160 || y % 35 > 30)
            return -1;
        var num1 = x / 200;
        var num2 = y / 35;
        return num1 >= 3 || num2 >= 10 ? -1 : num2 * 3 + num1;
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
        var index2 = _vScrollBar.Value * 3 + index1;
        _checkBox_Checked[index1] = !_checkBox_Checked[index1];
        DrawCheckBox(null, index1, _checkBox_Checked[index1] ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot);
        SaveDataManager.Instance.SaveData.TitleData.SetTitleHold(index2, _checkBox_Checked[index1]);
        if (_reviseCount)
        {
            if (_checkBox_Checked[index1])
                ++SaveDataManager.Instance.SaveData.TitleData.TitleCount;
            else
                --SaveDataManager.Instance.SaveData.TitleData.TitleCount;
        }
        else
        {
            SaveDataManager.Instance.SaveData.TitleData.ReviseTitleCount();
        }

        RenewalTitleCount();
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
        _reviseCount = false;
    }

    protected override void OnValueUpdate()
    {
        BeginUpdate();
        var titleData = SaveDataManager.Instance.SaveData.TitleData;
        var index1 = 0;
        var index2 = _vScrollBar.Value * 3;
        for (var index3 = 0; index3 < 10; ++index3)
        for (var index4 = 0; index4 < 3; ++index4)
        {
            if (index2 < TitleDataList.List.Count)
                _checkBox_Checked[index1] = titleData.IsTitleHold(index2);
            ++index1;
            ++index2;
        }

        panelPaint();
        RenewalTitleCount();
        EndUpdate();
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
                        g.FillRectangle(brush3, new Rectangle(0, 0, panel.Width, 20));
                        g.FillRectangle(brush2, new Rectangle(0, panel.Height - 20, panel.Width, panel.Height));
                        var index1 = _vScrollBar.Value < _vScrollBar.Maximum - _vScrollBar.LargeChange
                            ? _vScrollBar.Value * 3
                            : (_vScrollBar.Maximum - _vScrollBar.LargeChange - 1) * 3;
                        var index2 = 0;
                        var y = 25;
                        for (var index3 = 0; index3 < 10; ++index3)
                        {
                            g.FillRectangle((index3 & 1) == 0 ? brush2 : brush3,
                                new Rectangle(0, 20 + index3 * 35, panel.Width, 35));
                            var x = 58;
                            for (var index4 = 0; index4 < 3; ++index4)
                            {
                                if (index1 < TitleDataList.List.Count)
                                {
                                    var titleElement = TitleDataList.List[index1];
                                    g.DrawString(titleElement.MaleTitleName, Font, brush1, x, y);
                                    g.DrawString(titleElement.LadyTitleName, Font, brush1, x, y + 14);
                                    DrawCheckBox(g, index2,
                                        _checkBox_Checked[index2]
                                            ? CheckBoxState.CheckedNormal
                                            : CheckBoxState.UncheckedNormal);
                                }

                                x += 200;
                                ++index1;
                                ++index2;
                            }

                            y += 35;
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
                if (_vScrollBar.Value - (_vScrollBar.LargeChange - 1) < _vScrollBar.Minimum)
                    _vScrollBar.Value = _vScrollBar.Minimum;
                else
                    _vScrollBar.Value -= _vScrollBar.LargeChange - 1;
                OnValueUpdate();
            }
        }

        if (_vScrollBar.Value != _vScrollBar.Maximum - _vScrollBar.LargeChange + 2)
        {
            if (e.KeyCode == Keys.End)
            {
                _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange - 1;
                OnValueUpdate();
            }
            else if (e.KeyCode == Keys.Next)
            {
                if (_vScrollBar.Value + (_vScrollBar.LargeChange - 1) >
                    _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1))
                    _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange - 1;
                else
                    _vScrollBar.Value += _vScrollBar.LargeChange - 1;
                OnValueUpdate();
            }
        }

        EndUpdate();
    }

    public void DrawCheckBox(Graphics g, int index, CheckBoxState state)
    {
        var x = 40 + 200 * (index % 3);
        var y = 32 + 35 * (index / 3);
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
        _vScrollBar.Maximum = TitleDataList.List.Count / 3;
        if (TitleDataList.List.Count % 3 != 0)
            ++_vScrollBar.Maximum;
        _vScrollBar.LargeChange = 9;
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
        if (_updateCount != 0)
            return;
        if (_vScrollBar.Value > _vScrollBar.Maximum - _vScrollBar.LargeChange - 1)
            _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange - 1;
        textBox_Dummy.Focus();
        OnValueUpdate();
    }

    private void TitleDataControl_Click(object sender, EventArgs e)
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
        for (var index = 0; index < TitleDataList.List.Count; ++index)
            SaveDataManager.Instance.SaveData.TitleData.SetTitleHold(index, true);
        SaveDataManager.Instance.SaveData.TitleData.TitleCount = (ushort)TitleDataList.List.Count;
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        OnValueUpdate();
    }

    private void button_AllUncheck_Click(object sender, EventArgs e)
    {
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        for (var index = 0; index < TitleDataList.List.Count; ++index)
            SaveDataManager.Instance.SaveData.TitleData.SetTitleHold(index, false);
        SaveDataManager.Instance.SaveData.TitleData.TitleCount = 0;
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        OnValueUpdate();
    }
}