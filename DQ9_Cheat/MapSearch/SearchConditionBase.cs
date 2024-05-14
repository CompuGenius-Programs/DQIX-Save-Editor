// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchConditionBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.MapSearch
{
  public abstract class SearchConditionBase
  {
    protected int _typeIndex;
    protected SearchConditionType _conditionType;

    public int TypeIndex => _typeIndex;

    public SearchConditionType ConditionType
    {
      get => _conditionType;
      set => _conditionType = value;
    }

    protected string ConditionTypeText
    {
      get
      {
        switch (_conditionType)
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
