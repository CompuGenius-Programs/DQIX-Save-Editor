// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.VisitorManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Security.Cryptography;

namespace DQ9_Cheat.DataManager;

internal class VisitorManager
{
    public const int VisitorMax = 30;

    public VisitorManager(SaveData owner)
    {
        for (uint index = 0; index < 30U; ++index)
            VisitorData[(int)index] = new VisitorData(owner, index);
        VisitorCount = new DataValue<byte>(owner, 23160U, null, 0, 30);
    }

    public VisitorData[] VisitorData { get; } = new VisitorData[30];

    public DataValue<byte> VisitorCount { get; }

    public void OnLoaded()
    {
        for (uint index = 0; index < 30U; ++index)
            VisitorData[(int)index].OnLoaded();
    }

    public void OnUndo()
    {
        for (uint index = 0; index < 30U; ++index)
            VisitorData[(int)index].OnUndo();
    }

    public void OnRedo()
    {
        for (uint index = 0; index < 30U; ++index)
            VisitorData[(int)index].OnRedo();
    }

    public void MoveTo(int srcIndex, int toIndex)
    {
        if (srcIndex == toIndex)
            return;
        var bytesData = VisitorData[srcIndex].GetBytesData();
        if (srcIndex > toIndex)
            for (var index = srcIndex; index > toIndex; --index)
                VisitorData[index].Copy(VisitorData[index - 1].GetBytesData());
        else if (srcIndex < toIndex)
            for (var index = srcIndex; index < toIndex; ++index)
                VisitorData[index].Copy(VisitorData[index + 1].GetBytesData());
        VisitorData[toIndex].Copy(bytesData);
        SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoVisitorIndexChanged(srcIndex, toIndex));
    }

    public void DeleteVisitor(int index)
    {
        if (index < 0 || index >= VisitorCount.Value)
            return;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        MoveTo(index, VisitorCount.Value - 1);
        VisitorData[VisitorCount.Value - 1].Clear();
        --VisitorCount.Value;
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public bool CreateCharacter()
    {
        if (VisitorCount.Value >= 30)
            return false;
        SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
        var index = 0;
        while (index < 30 && VisitorData[index].SEQ != 0U)
            ++index;
        ++SaveDataManager.Instance.SaveData.RikkaData.VisitorCount;
        ++VisitorCount.Value;
        VisitorData[index].Clear();
        VisitorData[index].SEQ = SaveDataManager.Instance.SaveData.RikkaData.VisitorCount;
        VisitorData[index].OnCreate();
        VisitorData[index].LodgingDay_Year = (ushort)DateTime.Now.Year;
        VisitorData[index].LodgingDay_Month = (byte)DateTime.Now.Month;
        VisitorData[index].LodgingDay_Day = (byte)DateTime.Now.Day;
        uint uid;
        do
        {
            ;
        } while (!IsValidUID(uid = CreateUID()));

        VisitorData[index].UID = uid;
        SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
        return true;
    }

    private uint CreateUID()
    {
        var data = new byte[4];
        new RNGCryptoServiceProvider().GetNonZeroBytes(data);
        return (uint)(data[0] | (data[1] << 8) | (data[2] << 16) | (data[3] << 24));
    }

    public bool IsValidUID(uint uid)
    {
        if (uid == 0U)
            return false;
        for (var index = 0; index < 30; ++index)
            if (VisitorData[index].SEQ != 0U && (long)VisitorData[index].UID == uid)
                return false;
        return true;
    }
}