// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.QuestElement
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData;

public class QuestElement
{
    public QuestElement(byte dataIndex, byte questNo, bool additional, string questTitle)
    {
        DataIndex = dataIndex;
        QuestNo = questNo;
        AdditionalQuest = additional;
        QuestTitle = questTitle;
    }

    public int QuestNo { get; }

    public string QuestTitle { get; }

    public byte DataIndex { get; }

    public bool AdditionalQuest { get; }
}