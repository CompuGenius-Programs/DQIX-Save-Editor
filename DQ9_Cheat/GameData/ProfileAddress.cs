// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.ProfileAddress
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData
{
  public class ProfileAddress
  {
    private string _name;
    private int _index;

    public ProfileAddress(string name, int index)
    {
      _name = name;
      _index = index;
    }

    public string Name => _name;

    public int Index => _index;

    public override string ToString() => _name;
  }
}
