﻿// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.DestinationList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public static class DestinationList
  {
    private static System.Collections.Generic.List<Destination> _list = new System.Collections.Generic.List<Destination>();

    static DestinationList()
    {
      string[] strArray = new string[18]
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
      int num = 0;
      foreach (string name in strArray)
        DestinationList._list.Add(new Destination(name, num++));
    }

    public static System.Collections.Generic.List<Destination> List => DestinationList._list;
  }
}