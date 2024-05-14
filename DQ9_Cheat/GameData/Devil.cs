// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.Devil
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData;

public class Devil
{
    public Devil(string name, int index)
    {
        Name = name;
        Index = index;
    }

    public string Name { get; }

    public int Index { get; }

    public override string ToString()
    {
        return Name;
    }
}