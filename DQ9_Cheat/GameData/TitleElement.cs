// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.TitleElement
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public class TitleElement
  {
    private string _maleTitleName;
    private string _ladyTitleName;
    private int _dataIndex;

    public TitleElement(string maleTitleName, string ladyTitleName, int index)
    {
      this._maleTitleName = maleTitleName;
      this._ladyTitleName = ladyTitleName;
      this._dataIndex = index;
    }

    public string MaleTitleName => this._maleTitleName;

    public string LadyTitleName => this._ladyTitleName;

    public int DataIndex => this._dataIndex;
  }
}
