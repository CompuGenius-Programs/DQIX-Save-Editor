// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchBossConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchBossConditioin : SearchConditionBase
  {
    private int _bossIndex;

    public SearchBossConditioin() => this._typeIndex = 8;

    public int BossIndex
    {
      get => this._bossIndex;
      set => this._bossIndex = value;
    }

    public override string ToString()
    {
      return string.Format("Boss {1} {0}", (object) MonsterDataList.List[282 + this._bossIndex], (object) this.ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (this._conditionType)
      {
        case SearchConditionType.Accord:
          return this._bossIndex == (int) dungeonData.Boss;
        case SearchConditionType.Discord:
          return this._bossIndex != (int) dungeonData.Boss;
        default:
          return false;
      }
    }
  }
}
