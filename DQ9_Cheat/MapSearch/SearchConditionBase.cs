// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchConditionBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public abstract class SearchConditionBase
  {
    protected int _typeIndex;
    protected SearchConditionType _conditionType;

    public int TypeIndex => this._typeIndex;

    public SearchConditionType ConditionType
    {
      get => this._conditionType;
      set => this._conditionType = value;
    }

    protected string ConditionTypeText
    {
      get
      {
        switch (this._conditionType)
        {
          case SearchConditionType.Accord:
            return "==";
          case SearchConditionType.Discord:
            return "!=";
          case SearchConditionType.AndOver:
            return ">=";
          case SearchConditionType.AndLess:
            return "<=";
          default:
            return string.Empty;
        }
      }
    }

    public abstract bool IsHit(SearchDungeonData dungeonData);
  }
}
