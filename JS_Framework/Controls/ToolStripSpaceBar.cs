// Decompiled with JetBrains decompiler
// Type: JS_Framework.Controls.ToolStripSpaceBar
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Drawing;
using System.Windows.Forms;

namespace JS_Framework.Controls
{
  public class ToolStripSpaceBar : ToolStripControlHost
  {
    public ToolStripSpaceBar()
      : base(new Label())
    {
      BackColor = Color.Transparent;
      AutoSize = false;
      Width = 20;
      Text = string.Empty;
    }
  }
}
