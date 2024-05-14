// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.DataValueBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Windows.Forms;

namespace DQ9_Cheat.DataManager;

internal abstract class DataValueBase
{
    protected uint _dataOffset;
    protected SaveData _owner;
    protected Control _relationalControl;

    public uint DataOffset => _dataOffset;

    public abstract void Undo();

    public abstract void Redo();

    public void FocusControl()
    {
    }
}