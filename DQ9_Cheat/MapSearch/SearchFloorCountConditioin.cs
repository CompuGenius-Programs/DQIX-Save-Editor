// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchFloorCountConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.MapSearch;

public class SearchFloorCountConditioin : SearchConditionBase
{
    public SearchFloorCountConditioin()
    {
        _typeIndex = 7;
    }

    public int FloorCount { get; set; }

    public override string ToString()
    {
        return string.Format("Number of floors {1} {0}", FloorCount, ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
        switch (_conditionType)
        {
            case SearchConditionType.Accord:
                return FloorCount == dungeonData.Depth;
            case SearchConditionType.Discord:
                return FloorCount != dungeonData.Depth;
            case SearchConditionType.AndOver:
                return FloorCount <= dungeonData.Depth;
            case SearchConditionType.AndLess:
                return FloorCount >= dungeonData.Depth;
            default:
                return false;
        }
    }
}