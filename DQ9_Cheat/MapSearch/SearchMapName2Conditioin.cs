// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapName2Conditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchMapName2Conditioin : SearchConditionBase
  {
    private int _name2Index;

    public SearchMapName2Conditioin() => this._typeIndex = 3;

    public int Name2Index
    {
      get => this._name2Index;
      set => this._name2Index = value;
    }

    public override string ToString()
    {
      return string.Format("Name 3 {1} {0}", (object) TreasureMapDataTable.TreasureMapName2_Table[this._name2Index], (object) this.ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (this._conditionType)
      {
        case SearchConditionType.Accord:
          return this._name2Index == (int) dungeonData.MapName2Index;
        case SearchConditionType.Discord:
          return this._name2Index != (int) dungeonData.MapName2Index;
        default:
          return false;
      }
    }
  }
}
