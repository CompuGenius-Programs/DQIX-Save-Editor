// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.SearchConditionControlBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.ComponentModel;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;

namespace DQ9_Cheat.Controls.MapSearch
{
  public class SearchConditionControlBase : UserControl
  {
    private IContainer components;

    public SearchConditionControlBase() => InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      components = new Container();
      AutoScaleMode = AutoScaleMode.Font;
    }

    public virtual SearchConditionBase GetCondition() => null;

    public virtual void SetCondition(SearchConditionBase condition)
    {
    }
  }
}
