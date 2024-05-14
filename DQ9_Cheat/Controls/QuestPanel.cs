// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.QuestPanel
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.GameData;
using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class QuestPanel : JS_Panel
  {
    private const int ControlCount = 12;
    private Bitmap _panelBitmap;
    private int _questIndex;

    public QuestPanel() => this.Disposed += new EventHandler(this.QuestPanel_Disposed);

    private void QuestPanel_Disposed(object sender, EventArgs e)
    {
      if (this._panelBitmap == null)
        return;
      this._panelBitmap.Dispose();
      this._panelBitmap = (Bitmap) null;
    }

    public int QuestIndex
    {
      get => this._questIndex;
      set => this._questIndex = value;
    }

    protected override void OnPaint(PaintEventArgs e) => this.panel_Paint(e.Graphics);

    public void panel_Paint()
    {
      using (Graphics panelGraphics = Graphics.FromHwnd(this.Handle))
        this.panel_Paint(panelGraphics);
    }

    protected override void OnResize(EventArgs eventargs)
    {
      base.OnResize(eventargs);
      if (this.Width <= 0 || this.Height <= 0)
        return;
      if (this._panelBitmap != null)
      {
        this._panelBitmap.Dispose();
        this._panelBitmap = (Bitmap) null;
      }
      this._panelBitmap = new Bitmap(this.Width, this.Height);
    }

    public void panel_Paint(Graphics panelGraphics)
    {
      if (this._panelBitmap == null)
        return;
      using (Graphics g = Graphics.FromImage((Image) this._panelBitmap))
      {
        using (Brush brush1 = (Brush) new SolidBrush(this.ForeColor))
        {
          using (Brush brush2 = (Brush) new SolidBrush(SystemColors.ControlLight))
          {
            using (Brush brush3 = (Brush) new SolidBrush(SystemColors.Control))
            {
              g.FillRectangle(brush3, new Rectangle(0, 0, this.Width, 20));
              g.FillRectangle(brush2, new Rectangle(0, this.Height - 20, this.Width, this.Height));
              using (Brush brush4 = (Brush) new SolidBrush(this.ForeColor))
              {
                g.DrawString("Y.", this.Font, brush4, (PointF) new Point(310, 6));
                g.DrawString("M.", this.Font, brush4, (PointF) new Point(370, 6));
                g.DrawString("D.", this.Font, brush4, (PointF) new Point(420, 6));
                g.DrawString("H.", this.Font, brush4, (PointF) new Point(470, 6));
                g.DrawString("M.", this.Font, brush4, (PointF) new Point(520, 6));
              }
              int questIndex = this._questIndex;
              int num = 0;
              while (num < 12)
              {
                g.FillRectangle((num & 1) == 0 ? brush2 : brush3, new Rectangle(0, 20 + num * 28, this.Width, 28));
                if (questIndex < QuestDataList.List.Count)
                {
                  QuestElement questElement = QuestDataList.List[questIndex];
                  g.DrawString(string.Format("{0:D3}", (object) questElement.QuestNo), this.Font, brush1, 6f, (float) (28 + num * 28));
                  g.DrawString(questElement.QuestTitle, this.Font, brush1, 40f, (float) (28 + num * 28));
                }
                ++num;
                ++questIndex;
              }
              this.RenewalVisionControl(g);
            }
          }
        }
      }
      panelGraphics.DrawImage((Image) this._panelBitmap, Point.Empty);
    }
  }
}
