// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.Handle
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public class Handle
  {
    private HandleType _handleType;
    private ProfileJob _job;
    private TitleElement _title;

    public Handle(ProfileJob job)
    {
      this._handleType = HandleType.HandleJob;
      this._job = job;
    }

    public Handle(TitleElement title)
    {
      this._handleType = HandleType.HandleTitle;
      this._title = title;
    }

    public HandleType HandleType => this._handleType;

    public ProfileJob Job => this._job;

    public TitleElement Title => this._title;
  }
}
