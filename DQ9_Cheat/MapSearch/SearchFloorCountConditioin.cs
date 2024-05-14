// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchFloorCountConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchFloorCountConditioin : SearchConditionBase
  {
    private int _floorCount;

    public SearchFloorCountConditioin() => this._typeIndex = 7;

    public int FloorCount
    {
      get => this._floorCount;
      set => this._floorCount = value;
    }

    public override string ToString()
    {
      return string.Format("Number of floors {1} {0}", (object) this._floorCount, (object) this.ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      switch (this._conditionType)
      {
        case SearchConditionType.Accord:
          return this._floorCount == (int) dungeonData.Depth;
        case SearchConditionType.Discord:
          return this._floorCount != (int) dungeonData.Depth;
        case SearchConditionType.AndOver:
          return this._floorCount <= (int) dungeonData.Depth;
        case SearchConditionType.AndLess:
          return this._floorCount >= (int) dungeonData.Depth;
        default:
          return false;
      }
    }
  }
}
