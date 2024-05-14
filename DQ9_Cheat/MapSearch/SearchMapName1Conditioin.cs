// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapName1Conditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.MapSearch
{
  public class SearchMapName1Conditioin : SearchConditionBase
  {
    private int _name1Index;

    public SearchMapName1Conditioin() => _typeIndex = 1;

    public int Name1Index
    {
      get => _name1Index;
      set => _name1Index = value;
    }

    public override string ToString()
    {
      return string.Format("Name 1 {1} {0}", TreasureMapDataTable.TreasureMapName1_Table[_name1Index], ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (_conditionType)
      {
        case SearchConditionType.Accord:
          return _name1Index == dungeonData.MapName1Index;
        case SearchConditionType.Discord:
          return _name1Index != dungeonData.MapName1Index;
        default:
          return false;
      }
    }
  }
}
