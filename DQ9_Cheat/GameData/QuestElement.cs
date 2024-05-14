// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.QuestElement
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData
{
  public class QuestElement
  {
    private int _questNo;
    private string _questTitle;
    private byte _dataIndex;
    private bool _additionalQuest;

    public QuestElement(byte dataIndex, byte questNo, bool additional, string questTitle)
    {
      _dataIndex = dataIndex;
      _questNo = questNo;
      _additionalQuest = additional;
      _questTitle = questTitle;
    }

    public int QuestNo => _questNo;

    public string QuestTitle => _questTitle;

    public byte DataIndex => _dataIndex;

    public bool AdditionalQuest => _additionalQuest;
  }
}
