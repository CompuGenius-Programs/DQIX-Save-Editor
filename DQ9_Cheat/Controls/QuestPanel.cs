// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.QuestPanel
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls;

public class QuestPanel : JS_Panel
{
    private const int ControlCount = 12;
    private Bitmap _panelBitmap;

    public QuestPanel()
    {
        Disposed += QuestPanel_Disposed;
    }

    public int QuestIndex { get; set; }

    private void QuestPanel_Disposed(object sender, EventArgs e)
    {
        if (_panelBitmap == null)
            return;
        _panelBitmap.Dispose();
        _panelBitmap = null;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        panel_Paint(e.Graphics);
    }

    public void panel_Paint()
    {
        using (var panelGraphics = Graphics.FromHwnd(Handle))
        {
            panel_Paint(panelGraphics);
        }
    }

    protected override void OnResize(EventArgs eventargs)
    {
        base.OnResize(eventargs);
        if (Width <= 0 || Height <= 0)
            return;
        if (_panelBitmap != null)
        {
            _panelBitmap.Dispose();
            _panelBitmap = null;
        }

        _panelBitmap = new Bitmap(Width, Height);
    }

    public void panel_Paint(Graphics panelGraphics)
    {
        if (_panelBitmap == null)
            return;
        using (var g = Graphics.FromImage(_panelBitmap))
        {
            using (Brush brush1 = new SolidBrush(ForeColor))
            {
                using (Brush brush2 = new SolidBrush(SystemColors.ControlLight))
                {
                    using (Brush brush3 = new SolidBrush(SystemColors.Control))
                    {
                        g.FillRectangle(brush3, new Rectangle(0, 0, Width, 20));
                        g.FillRectangle(brush2, new Rectangle(0, Height - 20, Width, Height));
                        using (Brush brush4 = new SolidBrush(ForeColor))
                        {
                            g.DrawString("Y.", Font, brush4, new Point(310, 6));
                            g.DrawString("M.", Font, brush4, new Point(370, 6));
                            g.DrawString("D.", Font, brush4, new Point(420, 6));
                            g.DrawString("H.", Font, brush4, new Point(470, 6));
                            g.DrawString("M.", Font, brush4, new Point(520, 6));
                        }

                        var questIndex = QuestIndex;
                        var num = 0;
                        while (num < 12)
                        {
                            g.FillRectangle((num & 1) == 0 ? brush2 : brush3,
                                new Rectangle(0, 20 + num * 28, Width, 28));
                            if (questIndex < QuestDataList.List.Count)
                            {
                                var questElement = QuestDataList.List[questIndex];
                                g.DrawString(string.Format("{0:D3}", questElement.QuestNo), Font, brush1, 6f,
                                    28 + num * 28);
                                g.DrawString(questElement.QuestTitle, Font, brush1, 40f, 28 + num * 28);
                            }

                            ++num;
                            ++questIndex;
                        }

                        RenewalVisionControl(g);
                    }
                }
            }
        }

        panelGraphics.DrawImage(_panelBitmap, Point.Empty);
    }
}