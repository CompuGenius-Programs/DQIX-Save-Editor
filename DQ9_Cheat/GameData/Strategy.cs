// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.Strategy
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData
{
  public class Strategy
  {
    private string _name;
    private byte _value;

    public Strategy(string name, byte value)
    {
      _name = name;
      _value = value;
    }

    public string Name => _name;

    public byte Value => _value;

    public override string ToString() => _name;
  }
}
