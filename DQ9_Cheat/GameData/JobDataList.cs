// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.JobDataList
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  internal static class JobDataList
  {
    private static System.Collections.Generic.List<JobData> _jobList = new System.Collections.Generic.List<JobData>();

    static JobDataList()
    {
      JobDataList._jobList.Add(new JobData(0, "Guardian", (int[]) null));
      JobDataList._jobList.Add(new JobData(1, "Warrior", new int[5]
      {
        0,
        1,
        2,
        12,
        14
      }));
      JobDataList._jobList.Add(new JobData(2, "Priest", new int[5]
      {
        1,
        3,
        5,
        12,
        15
      }));
      JobDataList._jobList.Add(new JobData(3, "Mage", new int[5]
      {
        3,
        2,
        4,
        12,
        16
      }));
      JobDataList._jobList.Add(new JobData(4, "Martial Artist", new int[5]
      {
        6,
        5,
        7,
        13,
        17
      }));
      JobDataList._jobList.Add(new JobData(5, "Thief", new int[5]
      {
        2,
        0,
        6,
        13,
        18
      }));
      JobDataList._jobList.Add(new JobData(6, "Minstrel", new int[5]
      {
        0,
        4,
        7,
        12,
        19
      }));
      JobDataList._jobList.Add(new JobData(7, "Gladiator", new int[5]
      {
        8,
        9,
        0,
        13,
        20
      }));
      JobDataList._jobList.Add(new JobData(9, "Paladin", new int[5]
      {
        9,
        1,
        3,
        12,
        22
      }));
      JobDataList._jobList.Add(new JobData(8, "Armamentalist", new int[5]
      {
        11,
        0,
        3,
        12,
        21
      }));
      JobDataList._jobList.Add(new JobData(12, "Ranger", new int[5]
      {
        10,
        8,
        11,
        13,
        25
      }));
      JobDataList._jobList.Add(new JobData(10, "Sage", new int[5]
      {
        3,
        11,
        10,
        12,
        23
      }));
      JobDataList._jobList.Add(new JobData(11, "Luminary", new int[5]
      {
        7,
        4,
        10,
        12,
        24
      }));
    }

    public static System.Collections.Generic.List<JobData> List => JobDataList._jobList;

    public static JobData GetJobData(int dataIndex)
    {
      foreach (JobData job in JobDataList._jobList)
      {
        if (job.DataIndex == dataIndex)
          return job;
      }
      return (JobData) null;
    }
  }
}
