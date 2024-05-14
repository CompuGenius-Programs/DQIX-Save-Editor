// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapRankCondition
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchMapRankCondition : SearchConditionBase
  {
    private int _rankIndex;

    public SearchMapRankCondition() => this._typeIndex = 0;

    public int RankIndex
    {
      get => this._rankIndex;
      set => this._rankIndex = value;
    }

    public override string ToString()
    {
      return string.Format("Rank {1} {0:X02}", (object) SearchDataFile.RankList[this._rankIndex], (object) this.ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      byte rank = SearchDataFile.RankList[this._rankIndex];
      switch (this._conditionType)
      {
        case SearchConditionType.Accord:
          return (int) rank == (int) dungeonData.Rank;
        case SearchConditionType.Discord:
          return (int) rank != (int) dungeonData.Rank;
        case SearchConditionType.AndOver:
          return (int) rank <= (int) dungeonData.Rank;
        case SearchConditionType.AndLess:
          return (int) rank >= (int) dungeonData.Rank;
        default:
          return false;
      }
    }
  }
}
