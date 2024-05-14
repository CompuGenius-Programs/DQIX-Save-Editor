// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.StrategyList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;

namespace DQ9_Cheat.GameData;

internal static class StrategyList
{
    static StrategyList()
    {
        List.Add(new Strategy("Show No Mercy", 0));
        List.Add(new Strategy("Fight Wisely", 8));
        List.Add(new Strategy("Mix It Up", 16));
        List.Add(new Strategy("Focus On Healing", 24));
        List.Add(new Strategy("Don't Use MP", 32));
        List.Add(new Strategy("Follow Orders", 40));
    }

    public static List<Strategy> List { get; } = [];

    public static Strategy GetStrategy(byte value)
    {
        foreach (var strategy in List)
            if (strategy.Value == (byte)(value & 56U))
                return strategy;
        return null;
    }
}