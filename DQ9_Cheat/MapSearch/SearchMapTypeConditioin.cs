// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchMapTypeConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchMapTypeConditioin : SearchConditionBase
  {
    private int _mapType;

    public SearchMapTypeConditioin() => this._typeIndex = 5;

    public int MapType
    {
      get => this._mapType;
      set => this._mapType = value;
    }

    public override string ToString()
    {
      return string.Format("Type {1} {0}", (object) TreasureMapDataTable.TreasureMapMapTypeName_Table[this._mapType], (object) this.ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (this._conditionType)
      {
        case SearchConditionType.Accord:
          return this._mapType == (int) dungeonData.MapType;
        case SearchConditionType.Discord:
          return this._mapType != (int) dungeonData.MapType;
        default:
          return false;
      }
    }
  }
}
