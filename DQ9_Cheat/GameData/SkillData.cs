// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.SkillData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace DQ9_Cheat.GameData
{
  public class SkillData
  {
    private string _name;
    private int _index;
    private List<SkillSpecialtyEffectData> _skillSpecialtyList = new List<SkillSpecialtyEffectData>();
    private List<SkillSpecialtyEffectData> _skillEffectList = new List<SkillSpecialtyEffectData>();

    public SkillData(string name, int index, SkillSpecialtyEffectData[] specialtyEffects)
    {
      this._name = name;
      this._index = index;
      foreach (SkillSpecialtyEffectData specialtyEffect in specialtyEffects)
      {
        if (specialtyEffect.Specialty)
          this._skillSpecialtyList.Add(specialtyEffect);
        else
          this._skillEffectList.Add(specialtyEffect);
      }
    }

    public string Name => this._name;

    public int Index => this._index;

    public ReadOnlyCollection<SkillSpecialtyEffectData> SkillSpecialtyList
    {
      get => this._skillSpecialtyList.AsReadOnly();
    }

    public ReadOnlyCollection<SkillSpecialtyEffectData> SkillEffectList
    {
      get => this._skillEffectList.AsReadOnly();
    }

    public override string ToString() => this._name;
  }
}
