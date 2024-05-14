// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapLvConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchMapLvConditioin : SearchConditionBase
  {
    private int _mapLevel;

    public SearchMapLvConditioin() => this._typeIndex = 4;

    public int MapLevel
    {
      get => this._mapLevel;
      set => this._mapLevel = value;
    }

    public override string ToString()
    {
      return string.Format("Level {1} {0:D}", (object) this._mapLevel, (object) this.ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (this._conditionType)
      {
        case SearchConditionType.Accord:
          return this._mapLevel == (int) dungeonData.MapLevel;
        case SearchConditionType.Discord:
          return this._mapLevel != (int) dungeonData.MapLevel;
        case SearchConditionType.AndOver:
          return this._mapLevel <= (int) dungeonData.MapLevel;
        case SearchConditionType.AndLess:
          return this._mapLevel >= (int) dungeonData.MapLevel;
        default:
          return false;
      }
    }
  }
}
