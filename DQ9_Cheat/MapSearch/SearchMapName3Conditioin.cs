// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapName3Conditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.MapSearch
{
  public class SearchMapName3Conditioin : SearchConditionBase
  {
    private int _name3Index;

    public SearchMapName3Conditioin() => _typeIndex = 2;

    public int Name3Index
    {
      get => _name3Index;
      set => _name3Index = value;
    }

    public override string ToString()
    {
      return string.Format("Name 2 {1} {0}", TreasureMapDataTable.TreasureMapName3_Table[_name3Index], ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (_conditionType)
      {
        case SearchConditionType.Accord:
          return _name3Index == dungeonData.MapName3Index;
        case SearchConditionType.Discord:
          return _name3Index != dungeonData.MapName3Index;
        default:
          return false;
      }
    }
  }
}
