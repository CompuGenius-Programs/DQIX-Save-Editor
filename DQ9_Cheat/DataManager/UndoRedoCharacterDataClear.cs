// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoCharacterDataClear
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.DataManager;

internal class UndoRedoCharacterDataClear : UndoRedoElement
{
    private byte[] _characterData;
    private readonly uint _index;

    public UndoRedoCharacterDataClear(uint index)
    {
        _index = index;
        _characterData = GetSaveData().CharacterManager.CharacterData[(int)index].GetBytesData();
    }

    protected override void OnDispose()
    {
        _characterData = null;
    }

    public override void Undo()
    {
        GetSaveData().CharacterManager.CharacterData[(int)_index].Copy(_characterData);
    }

    public override void Redo()
    {
        GetSaveData().CharacterManager.CharacterData[(int)_index].Copy(_characterData);
    }
}