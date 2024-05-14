// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.HistoryCharacterList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public static class HistoryCharacterList
  {
    private static System.Collections.Generic.List<HistoryCharacter> _list = new System.Collections.Generic.List<HistoryCharacter>();

    static HistoryCharacterList()
    {
      string[] strArray = new string[23]
      {
        "Princeton",
        "Princessa",
        "Alena",
        "Kiryl",
        "Borya",
        "Meena",
        "Maya",
        "Torneko",
        "Ragnar",
        "Bianca",
        "Nera",
        "Debora",
        "Milly",
        "Carver",
        "Ashlynn",
        "Kiefer",
        "Maribel",
        "Jessica",
        "Angelo",
        "Yangus",
        "Trode",
        "Morrie",
        "Fleurette"
      };
      int num = 1;
      foreach (string name in strArray)
        HistoryCharacterList._list.Add(new HistoryCharacter(name, num++));
    }

    public static System.Collections.Generic.List<HistoryCharacter> List
    {
      get => HistoryCharacterList._list;
    }
  }
}
