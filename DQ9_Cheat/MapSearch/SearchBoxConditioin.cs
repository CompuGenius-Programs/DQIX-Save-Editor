// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchBoxConditioin
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public class SearchBoxConditioin : SearchConditionBase
  {
    private int _boxType;
    private int _boxCount;

    public SearchBoxConditioin() => this._typeIndex = 9;

    public int BoxType
    {
      get => this._boxType;
      set => this._boxType = value;
    }

    public int BoxCount
    {
      get => this._boxCount;
      set => this._boxCount = value;
    }

    public override string ToString()
    {
      string[] strArray = new string[10]
      {
        "S",
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "I"
      };
      return this._boxType == 0 ? string.Format("Number of chests {1} {0}", (object) this._boxCount, (object) this.ConditionTypeText) : string.Format("Chest rank {0} {2} {1:D}", (object) strArray[this._boxType - 1], (object) this._boxCount, (object) this.ConditionTypeText);
    }

    public override bool IsHit(SearchDungeonData dungeonData)
    {
      int num = 0;
      switch (this._boxType)
      {
        case 0:
          num = (int) dungeonData.SBoxCount + (int) dungeonData.ABoxCount + (int) dungeonData.BBoxCount + (int) dungeonData.CBoxCount + (int) dungeonData.DBoxCount + (int) dungeonData.EBoxCount + (int) dungeonData.FBoxCount + (int) dungeonData.GBoxCount + (int) dungeonData.HBoxCount + (int) dungeonData.IBoxCount;
          break;
        case 1:
          num = (int) dungeonData.SBoxCount;
          break;
        case 2:
          num = (int) dungeonData.ABoxCount;
          break;
        case 3:
          num = (int) dungeonData.BBoxCount;
          break;
        case 4:
          num = (int) dungeonData.CBoxCount;
          break;
        case 5:
          num = (int) dungeonData.DBoxCount;
          break;
        case 6:
          num = (int) dungeonData.EBoxCount;
          break;
        case 7:
          num = (int) dungeonData.FBoxCount;
          break;
        case 8:
          num = (int) dungeonData.GBoxCount;
          break;
        case 9:
          num = (int) dungeonData.HBoxCount;
          break;
        case 10:
          num = (int) dungeonData.IBoxCount;
          break;
      }
      switch (this._conditionType)
      {
        case SearchConditionType.Accord:
          return this._boxCount == num;
        case SearchConditionType.Discord:
          return this._boxCount != num;
        case SearchConditionType.AndOver:
          return this._boxCount <= num;
        case SearchConditionType.AndLess:
          return this._boxCount >= num;
        default:
          return false;
      }
    }
  }
}
