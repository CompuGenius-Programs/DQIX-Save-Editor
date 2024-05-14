// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapLvConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.MapSearch
{
  public class SearchMapLvConditioin : SearchConditionBase
  {
    private int _mapLevel;

    public SearchMapLvConditioin() => _typeIndex = 4;

    public int MapLevel
    {
      get => _mapLevel;
      set => _mapLevel = value;
    }

    public override string ToString()
    {
      return string.Format("Level {1} {0:D}", _mapLevel, ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (_conditionType)
      {
        case SearchConditionType.Accord:
          return _mapLevel == dungeonData.MapLevel;
        case SearchConditionType.Discord:
          return _mapLevel != dungeonData.MapLevel;
        case SearchConditionType.AndOver:
          return _mapLevel <= dungeonData.MapLevel;
        case SearchConditionType.AndLess:
          return _mapLevel >= dungeonData.MapLevel;
        default:
          return false;
      }
    }
  }
}
