// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchBossConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.MapSearch;

public class SearchBossConditioin : SearchConditionBase
{
    public SearchBossConditioin()
    {
        _typeIndex = 8;
    }

    public int BossIndex { get; set; }

    public override string ToString()
    {
        return string.Format("Boss {1} {0}", MonsterDataList.List[282 + BossIndex], ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
        switch (_conditionType)
        {
            case SearchConditionType.Accord:
                return BossIndex == dungeonData.Boss;
            case SearchConditionType.Discord:
                return BossIndex != dungeonData.Boss;
            default:
                return false;
        }
    }
}