// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapTypeConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.MapSearch;

public class SearchMapTypeConditioin : SearchConditionBase
{
    public SearchMapTypeConditioin()
    {
        _typeIndex = 5;
    }

    public int MapType { get; set; }

    public override string ToString()
    {
        return string.Format("Type {1} {0}", TreasureMapDataTable.TreasureMapMapTypeName_Table[MapType],
            ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
        switch (_conditionType)
        {
            case SearchConditionType.Accord:
                return MapType == dungeonData.MapType;
            case SearchConditionType.Discord:
                return MapType != dungeonData.MapType;
            default:
                return false;
        }
    }
}