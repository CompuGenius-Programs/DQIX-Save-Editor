// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.QuestElement
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
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
      this._dataIndex = dataIndex;
      this._questNo = (int) questNo;
      this._additionalQuest = additional;
      this._questTitle = questTitle;
    }

    public int QuestNo => this._questNo;

    public string QuestTitle => this._questTitle;

    public byte DataIndex => this._dataIndex;

    public bool AdditionalQuest => this._additionalQuest;
  }
}
