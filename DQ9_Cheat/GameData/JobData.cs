// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.JobData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData;

public class JobData
{
    public JobData(int dataIndex, string name, int[] skillIndexes)
    {
        Name = name;
        DataIndex = dataIndex;
        if (skillIndexes == null)
            return;
        SkillList = new SkillData[5];
        var num = 0;
        foreach (var skillIndex in skillIndexes)
            SkillList[num++] = SkillDataList.List[skillIndex];
    }

    public string Name { get; }

    public int DataIndex { get; }

    public SkillData[] SkillList { get; }
}