// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.TreasureBoxInfo
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public class TreasureBoxInfo
  {
    private int _index;
    private int _rank;
    private int _x;
    private int _y;

    public TreasureBoxInfo(int index, int rank, int x, int y)
    {
      this._index = index;
      this._rank = rank;
      this._x = x;
      this._y = y;
    }

    public int Index => this._index;

    public int Rank => this._rank;

    public int X => this._x;

    public int Y => this._y;
  }
}
