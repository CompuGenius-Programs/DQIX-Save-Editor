// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchBoxConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.MapSearch;

public class SearchBoxConditioin : SearchConditionBase
{
    public SearchBoxConditioin()
    {
        _typeIndex = 9;
    }

    public int BoxType { get; set; }

    public int BoxCount { get; set; }

    public override string ToString()
    {
        var strArray = new string[10]
        {
            "S",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I"
        };
        return BoxType == 0
            ? string.Format("Number of chests {1} {0}", BoxCount, ConditionTypeText)
            : string.Format("Chest rank {0} {2} {1:D}", strArray[BoxType - 1], BoxCount, ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
        var num = 0;
        switch (BoxType)
        {
            case 0:
                num = dungeonData.SBoxCount + dungeonData.ABoxCount + dungeonData.BBoxCount + dungeonData.CBoxCount +
                      dungeonData.DBoxCount + dungeonData.EBoxCount + dungeonData.FBoxCount + dungeonData.GBoxCount +
                      dungeonData.HBoxCount + dungeonData.IBoxCount;
                break;
            case 1:
                num = dungeonData.SBoxCount;
                break;
            case 2:
                num = dungeonData.ABoxCount;
                break;
            case 3:
                num = dungeonData.BBoxCount;
                break;
            case 4:
                num = dungeonData.CBoxCount;
                break;
            case 5:
                num = dungeonData.DBoxCount;
                break;
            case 6:
                num = dungeonData.EBoxCount;
                break;
            case 7:
                num = dungeonData.FBoxCount;
                break;
            case 8:
                num = dungeonData.GBoxCount;
                break;
            case 9:
                num = dungeonData.HBoxCount;
                break;
            case 10:
                num = dungeonData.IBoxCount;
                break;
        }

        switch (_conditionType)
        {
            case SearchConditionType.Accord:
                return BoxCount == num;
            case SearchConditionType.Discord:
                return BoxCount != num;
            case SearchConditionType.AndOver:
                return BoxCount <= num;
            case SearchConditionType.AndLess:
                return BoxCount >= num;
            default:
                return false;
        }
    }
}