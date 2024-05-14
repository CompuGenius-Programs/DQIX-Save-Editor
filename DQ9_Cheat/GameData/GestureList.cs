// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.GestureList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public static class GestureList
  {
    private static System.Collections.Generic.List<Gesture> _list = new System.Collections.Generic.List<Gesture>();

    static GestureList()
    {
      string[] strArray = new string[32]
      {
        "---",
        "Bow",
        "Clap",
        "Air Punch",
        "Bye Bye",
        "Weep",
        "Despair",
        "Tantrum",
        "Surprised",
        "Jump",
        "Sit",
        "Recline",
        "Hello!",
        "Thanks!",
        "Goodbye!",
        "Eek!",
        "Hmm...",
        "Pray",
        "Dive",
        "Pirouette",
        "Belly Dance",
        "Royal Regards",
        "Swinedimples Salute",
        "Cap'n's Curtsy",
        "Sultry Dance",
        "Weird Dance",
        "Wallop",
        "Cheer",
        "Provoke",
        "Salute",
        "Inspiration",
        "Professor's Pose"
      };
      int num = 0;
      foreach (string name in strArray)
        GestureList._list.Add(new Gesture(name, num++));
    }

    public static System.Collections.Generic.List<Gesture> List => GestureList._list;
  }
}
