// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.SkillData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DQ9_Cheat.GameData;

public class SkillData
{
    private readonly List<SkillSpecialtyEffectData> _skillEffectList = [];
    private readonly List<SkillSpecialtyEffectData> _skillSpecialtyList = [];

    public SkillData(string name, int index, SkillSpecialtyEffectData[] specialtyEffects)
    {
        Name = name;
        Index = index;
        foreach (var specialtyEffect in specialtyEffects)
            if (specialtyEffect.Specialty)
                _skillSpecialtyList.Add(specialtyEffect);
            else
                _skillEffectList.Add(specialtyEffect);
    }

    public string Name { get; }

    public int Index { get; }

    public ReadOnlyCollection<SkillSpecialtyEffectData> SkillSpecialtyList => _skillSpecialtyList.AsReadOnly();

    public ReadOnlyCollection<SkillSpecialtyEffectData> SkillEffectList => _skillEffectList.AsReadOnly();

    public override string ToString()
    {
        return Name;
    }
}