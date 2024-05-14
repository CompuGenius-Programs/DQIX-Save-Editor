// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.SavePlaceList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using FriedGinger.DQCheat;

namespace DQ9_Cheat.GameData;

internal static class SavePlaceList
{
    private static readonly List<SavePlace> _list = new();

    static SavePlaceList()
    {
        SavePlaceListFixer.AddSavePlaces(_list);
    }

    public static ReadOnlyCollection<SavePlace> GetList(SavePlaceType type, string search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            var regex = new Regex(search.Trim(), RegexOptions.IgnoreCase);
            var savePlaceList = new List<SavePlace>();
            foreach (var savePlace in _list)
                if ((type == SavePlaceType.All || type == savePlace.Type) && regex.IsMatch(savePlace.Name))
                    savePlaceList.Add(savePlace);
            return savePlaceList.AsReadOnly();
        }

        var savePlaceList1 = new List<SavePlace>();
        foreach (var savePlace in _list)
            if (type == SavePlaceType.All || type == savePlace.Type)
                savePlaceList1.Add(savePlace);
        return savePlaceList1.AsReadOnly();
    }

    public static SavePlace GetSavePlace(ushort index)
    {
        foreach (var savePlace in _list)
            if (savePlace.Index == index)
                return savePlace;
        return null;
    }
}