// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapName1Conditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchMapName1Conditioin : SearchConditionBase
  {
    private int _name1Index;

    public SearchMapName1Conditioin() => this._typeIndex = 1;

    public int Name1Index
    {
      get => this._name1Index;
      set => this._name1Index = value;
    }

    public override string ToString()
    {
      return string.Format("Name 1 {1} {0}", (object) TreasureMapDataTable.TreasureMapName1_Table[this._name1Index], (object) this.ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (this._conditionType)
      {
        case SearchConditionType.Accord:
          return this._name1Index == (int) dungeonData.MapName1Index;
        case SearchConditionType.Discord:
          return this._name1Index != (int) dungeonData.MapName1Index;
        default:
          return false;
      }
    }
  }
}
