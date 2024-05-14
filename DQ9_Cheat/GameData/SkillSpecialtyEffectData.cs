// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.SkillSpecialtyEffectData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public class SkillSpecialtyEffectData
  {
    private string _name;
    private int _index;
    private bool _specialty;

    public SkillSpecialtyEffectData(string name, int index, bool specialty)
    {
      this._name = name;
      this._index = index;
      this._specialty = specialty;
    }

    public string Name => this._name;

    public int Index => this._index;

    public bool Specialty => this._specialty;

    public override string ToString() => this._name;
  }
}
