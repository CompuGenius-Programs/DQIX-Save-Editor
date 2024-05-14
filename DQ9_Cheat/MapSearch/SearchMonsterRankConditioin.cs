// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMonsterRankConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchMonsterRankConditioin : SearchConditionBase
  {
    private int _monsterRank;

    public SearchMonsterRankConditioin() => this._typeIndex = 6;

    public int MonsterRank
    {
      get => this._monsterRank;
      set => this._monsterRank = value;
    }

    public override string ToString()
    {
      return string.Format("Monster Rank {1} {0}", (object) this._monsterRank, (object) this.ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (this._conditionType)
      {
        case SearchConditionType.Accord:
          return this._monsterRank == (int) dungeonData.MonsterRank;
        case SearchConditionType.Discord:
          return this._monsterRank != (int) dungeonData.MonsterRank;
        case SearchConditionType.AndOver:
          return this._monsterRank <= (int) dungeonData.MonsterRank;
        case SearchConditionType.AndLess:
          return this._monsterRank >= (int) dungeonData.MonsterRank;
        default:
          return false;
      }
    }
  }
}
