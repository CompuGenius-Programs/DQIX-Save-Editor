// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Program
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      MainWindow.Instance.Initialize();
      Application.Run((Form) MainWindow.Instance);
    }
  }
}
