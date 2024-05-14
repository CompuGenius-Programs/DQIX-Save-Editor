// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.JobData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public class JobData
  {
    private string _name;
    private int _dataIndex;
    private SkillData[] _skillList;

    public JobData(int dataIndex, string name, int[] skillIndexes)
    {
      this._name = name;
      this._dataIndex = dataIndex;
      if (skillIndexes == null)
        return;
      this._skillList = new SkillData[5];
      int num = 0;
      foreach (int skillIndex in skillIndexes)
        this._skillList[num++] = SkillDataList.List[skillIndex];
    }

    public string Name => this._name;

    public int DataIndex => this._dataIndex;

    public SkillData[] SkillList => this._skillList;
  }
}
