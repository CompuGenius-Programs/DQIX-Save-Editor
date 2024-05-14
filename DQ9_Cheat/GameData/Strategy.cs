// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.Strategy
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public class Strategy
  {
    private string _name;
    private byte _value;

    public Strategy(string name, byte value)
    {
      this._name = name;
      this._value = value;
    }

    public string Name => this._name;

    public byte Value => this._value;

    public override string ToString() => this._name;
  }
}
