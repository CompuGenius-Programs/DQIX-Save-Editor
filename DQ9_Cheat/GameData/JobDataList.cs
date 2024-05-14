// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.JobDataList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;

namespace DQ9_Cheat.GameData;

internal static class JobDataList
{
    static JobDataList()
    {
        List.Add(new JobData(0, "Guardian", null));
        List.Add(new JobData(1, "Warrior", [
            0,
            1,
            2,
            12,
            14
        ]));
        List.Add(new JobData(2, "Priest", [
            1,
            3,
            5,
            12,
            15
        ]));
        List.Add(new JobData(3, "Mage", [
            3,
            2,
            4,
            12,
            16
        ]));
        List.Add(new JobData(4, "Martial Artist", [
            6,
            5,
            7,
            13,
            17
        ]));
        List.Add(new JobData(5, "Thief", [
            2,
            0,
            6,
            13,
            18
        ]));
        List.Add(new JobData(6, "Minstrel", [
            0,
            4,
            7,
            12,
            19
        ]));
        List.Add(new JobData(7, "Gladiator", [
            8,
            9,
            0,
            13,
            20
        ]));
        List.Add(new JobData(9, "Paladin", [
            9,
            1,
            3,
            12,
            22
        ]));
        List.Add(new JobData(8, "Armamentalist", [
            11,
            0,
            3,
            12,
            21
        ]));
        List.Add(new JobData(12, "Ranger", [
            10,
            8,
            11,
            13,
            25
        ]));
        List.Add(new JobData(10, "Sage", [
            3,
            11,
            10,
            12,
            23
        ]));
        List.Add(new JobData(11, "Luminary", [
            7,
            4,
            10,
            12,
            24
        ]));
    }

    public static List<JobData> List { get; } = [];

    public static JobData GetJobData(int dataIndex)
    {
        foreach (var job in List)
            if (job.DataIndex == dataIndex)
                return job;
        return null;
    }
}