// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapRankCondition
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.MapSearch;

public class SearchMapRankCondition : SearchConditionBase
{
    public SearchMapRankCondition()
    {
        _typeIndex = 0;
    }

    public int RankIndex { get; set; }

    public override string ToString()
    {
        return string.Format("Rank {1} {0:X02}", SearchDataFile.RankList[RankIndex], ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
        var rank = SearchDataFile.RankList[RankIndex];
        switch (_conditionType)
        {
            case SearchConditionType.Accord:
                return rank == dungeonData.Rank;
            case SearchConditionType.Discord:
                return rank != dungeonData.Rank;
            case SearchConditionType.AndOver:
                return rank <= dungeonData.Rank;
            case SearchConditionType.AndLess:
                return rank >= dungeonData.Rank;
            default:
                return false;
        }
    }
}