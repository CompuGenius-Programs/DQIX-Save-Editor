// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapName2Conditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.MapSearch
{
  public class SearchMapName2Conditioin : SearchConditionBase
  {
    private int _name2Index;

    public SearchMapName2Conditioin() => _typeIndex = 3;

    public int Name2Index
    {
      get => _name2Index;
      set => _name2Index = value;
    }

    public override string ToString()
    {
      return string.Format("Name 3 {1} {0}", TreasureMapDataTable.TreasureMapName2_Table[_name2Index], ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (_conditionType)
      {
        case SearchConditionType.Accord:
          return _name2Index == dungeonData.MapName2Index;
        case SearchConditionType.Discord:
          return _name2Index != dungeonData.MapName2Index;
        default:
          return false;
      }
    }
  }
}
