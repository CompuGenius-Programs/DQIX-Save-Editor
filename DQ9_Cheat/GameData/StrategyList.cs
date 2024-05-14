// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.StrategyList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;

namespace DQ9_Cheat.GameData
{
  internal static class StrategyList
  {
    private static List<Strategy> _list = new List<Strategy>();

    static StrategyList()
    {
      _list.Add(new Strategy("Show No Mercy", 0));
      _list.Add(new Strategy("Fight Wisely", 8));
      _list.Add(new Strategy("Mix It Up", 16));
      _list.Add(new Strategy("Focus On Healing", 24));
      _list.Add(new Strategy("Don't Use MP", 32));
      _list.Add(new Strategy("Follow Orders", 40));
    }

    public static List<Strategy> List => _list;

    public static Strategy GetStrategy(byte value)
    {
      foreach (Strategy strategy in _list)
      {
        if (strategy.Value == (byte) (value & 56U))
          return strategy;
      }
      return null;
    }
  }
}
