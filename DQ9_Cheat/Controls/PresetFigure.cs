// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.PresetFigure
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.Controls;

public class PresetFigure
{
    public PresetFigure(string name, ushort width, ushort height)
    {
        PresetName = name;
        Width = width;
        Height = height;
    }

    public string PresetName { get; }

    public ushort Width { get; }

    public ushort Height { get; }

    public override string ToString()
    {
        return PresetName;
    }
}