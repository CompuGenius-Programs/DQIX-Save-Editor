// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.ProfileJobList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DQ9_Cheat.GameData;

public static class ProfileJobList
{
    private static readonly List<ProfileJob> _list = new();

    static ProfileJobList()
    {
        var strArray = new string[59]
        {
            "Pre-schooler",
            "Primary school student",
            "Middle school student",
            "High school student",
            "Dropout",
            "University student",
            "Company drone",
            "Freelancer",
            "Free agent",
            "Artist",
            "Sportsperson",
            "Poet",
            "Musician",
            "Cameraperson",
            "Nurse",
            "Maid",
            "Butler",
            "Researcher",
            "Explorer",
            "King",
            "Queen",
            "Prince",
            "Princess",
            "Don",
            "Capo",
            "Idol",
            "Hunk",
            "Nerd",
            "Dreamer",
            "Father",
            "Mother",
            "Daddy's girl",
            "Mummy's boy",
            "Big brother",
            "Big sister",
            "Little brother",
            "Little sister",
            "Grandad",
            "Grandma",
            "Bodybuilder",
            "Home help",
            "Glitter girl",
            "Glitter guy",
            "Charmer",
            "Goodie",
            "Baddie",
            "Faerie",
            "Angel",
            "Demon",
            "Game designer",
            "Cartoonist",
            "Composer",
            "Producer",
            "Director",
            "Foreman",
            "Chief executive",
            "Department head",
            "President",
            "Demon king"
        };
        _list.Add(new ProfileJob("Current Vocation", 712));
        for (var index = 0; index < strArray.Length; ++index)
            _list.Add(new ProfileJob(strArray[index], 800 + index));
    }

    public static ReadOnlyCollection<ProfileJob> List => _list.AsReadOnly();

    public static ProfileJob GetJobFromIndex(int index)
    {
        if (index >= 700 && index < 800)
            return _list[0];
        if (index >= 900 && index < 1000)
            index -= 100;
        foreach (var jobFromIndex in _list)
            if (jobFromIndex.Index == index)
                return jobFromIndex;
        return null;
    }
}