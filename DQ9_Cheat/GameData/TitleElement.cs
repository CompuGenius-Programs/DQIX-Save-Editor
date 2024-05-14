// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.TitleElement
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData
{
  public class TitleElement
  {
    private string _maleTitleName;
    private string _ladyTitleName;
    private int _dataIndex;

    public TitleElement(string maleTitleName, string ladyTitleName, int index)
    {
      _maleTitleName = maleTitleName;
      _ladyTitleName = ladyTitleName;
      _dataIndex = index;
    }

    public string MaleTitleName => _maleTitleName;

    public string LadyTitleName => _ladyTitleName;

    public int DataIndex => _dataIndex;
  }
}
