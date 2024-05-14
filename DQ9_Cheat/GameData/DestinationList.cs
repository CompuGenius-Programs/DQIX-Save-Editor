// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.DestinationList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;

namespace DQ9_Cheat.GameData;

public static class DestinationList
{
    static DestinationList()
    {
        var strArray = new string[18]
        {
            "Angel Falls",
            "Zere",
            "Stornway",
            "Coffinwell",
            "Alltrades Abbey",
            "Porth Llaffan",
            "Slurry Quay",
            "Dourbridge",
            "Zere Rocks",
            "Bloomingdale",
            "Gleeba",
            "Batsureg",
            "Swinedimples Academy",
            "Wormwood Creek",
            "Upover",
            "The Magmaroo",
            "The Gortress",
            "Gittingham Palace"
        };
        var num = 0;
        foreach (var name in strArray)
            List.Add(new Destination(name, num++));
    }

    public static List<Destination> List { get; } = new();
}