// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.JobData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData
{
  public class JobData
  {
    private string _name;
    private int _dataIndex;
    private SkillData[] _skillList;

    public JobData(int dataIndex, string name, int[] skillIndexes)
    {
      _name = name;
      _dataIndex = dataIndex;
      if (skillIndexes == null)
        return;
      _skillList = new SkillData[5];
      int num = 0;
      foreach (int skillIndex in skillIndexes)
        _skillList[num++] = SkillDataList.List[skillIndex];
    }

    public string Name => _name;

    public int DataIndex => _dataIndex;

    public SkillData[] SkillList => _skillList;
  }
}
