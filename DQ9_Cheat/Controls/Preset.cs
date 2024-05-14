// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.Preset
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class Preset
  {
    private string _presetName;
    private byte _index;

    public Preset(string name, byte index)
    {
      this._presetName = name;
      this._index = index;
    }

    public string PresetName => this._presetName;

    public byte Index => this._index;

    public override string ToString() => this._presetName;
  }
}
