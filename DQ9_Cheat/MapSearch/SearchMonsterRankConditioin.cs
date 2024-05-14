// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMonsterRankConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.MapSearch;

public class SearchMonsterRankConditioin : SearchConditionBase
{
    public SearchMonsterRankConditioin()
    {
        _typeIndex = 6;
    }

    public int MonsterRank { get; set; }

    public override string ToString()
    {
        return string.Format("Monster Rank {1} {0}", MonsterRank, ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
        switch (_conditionType)
        {
            case SearchConditionType.Accord:
                return MonsterRank == dungeonData.MonsterRank;
            case SearchConditionType.Discord:
                return MonsterRank != dungeonData.MonsterRank;
            case SearchConditionType.AndOver:
                return MonsterRank <= dungeonData.MonsterRank;
            case SearchConditionType.AndLess:
                return MonsterRank >= dungeonData.MonsterRank;
            default:
                return false;
        }
    }
}