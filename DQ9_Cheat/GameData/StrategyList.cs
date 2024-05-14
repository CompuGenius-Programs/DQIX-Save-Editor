// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.StrategyList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  internal static class StrategyList
  {
    private static System.Collections.Generic.List<Strategy> _list = new System.Collections.Generic.List<Strategy>();

    static StrategyList()
    {
      StrategyList._list.Add(new Strategy("Show No Mercy", (byte) 0));
      StrategyList._list.Add(new Strategy("Fight Wisely", (byte) 8));
      StrategyList._list.Add(new Strategy("Mix It Up", (byte) 16));
      StrategyList._list.Add(new Strategy("Focus On Healing", (byte) 24));
      StrategyList._list.Add(new Strategy("Don't Use MP", (byte) 32));
      StrategyList._list.Add(new Strategy("Follow Orders", (byte) 40));
    }

    public static System.Collections.Generic.List<Strategy> List => StrategyList._list;

    public static Strategy GetStrategy(byte value)
    {
      foreach (Strategy strategy in StrategyList._list)
      {
        if ((int) strategy.Value == (int) (byte) ((uint) value & 56U))
          return strategy;
      }
      return (Strategy) null;
    }
  }
}
