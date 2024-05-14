// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.SavePlace
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData
{
  public class SavePlace
  {
    private SavePlaceType _type;
    private string _name;
    private ushort _index;

    public SavePlace(ushort index, string name, SavePlaceType type)
    {
      _type = type;
      _name = name;
      _index = index;
    }

    public SavePlaceType Type => _type;

    public string Name => _name;

    public ushort Index => _index;

    public override string ToString() => _name;
  }
}
