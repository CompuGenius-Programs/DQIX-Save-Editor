// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.SavePlace
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public class SavePlace
  {
    private SavePlaceType _type;
    private string _name;
    private ushort _index;

    public SavePlace(ushort index, string name, SavePlaceType type)
    {
      this._type = type;
      this._name = name;
      this._index = index;
    }

    public SavePlaceType Type => this._type;

    public string Name => this._name;

    public ushort Index => this._index;

    public override string ToString() => this._name;
  }
}
