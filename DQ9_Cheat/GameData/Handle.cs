// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.Handle
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData;

public class Handle
{
    public Handle(ProfileJob job)
    {
        HandleType = HandleType.HandleJob;
        Job = job;
    }

    public Handle(TitleElement title)
    {
        HandleType = HandleType.HandleTitle;
        Title = title;
    }

    public HandleType HandleType { get; }

    public ProfileJob Job { get; }

    public TitleElement Title { get; }
}