// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.CharacterManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.DataManager
{
  internal class CharacterManager
  {
    public const int CharacterMax = 13;
    private bool _characterEdited;
    private CharacterData[] _characterData = new CharacterData[13];
    private DataValue<byte>[] _partyOrder = new DataValue<byte>[4];
    private DataValue<byte> _partyCharacterCount;
    private DataValue<byte> _characterStandbyCount;

    public CharacterManager(SaveData owner)
    {
      for (int index = 0; index < 4; ++index)
        _partyOrder[index] = new DataValue<byte>(owner, (uint) (7573 + index), null, 0, 3);
      for (uint index = 0; index < 13U; ++index)
        _characterData[(int) index] = new CharacterData(owner, index);
      _partyCharacterCount = new DataValue<byte>(owner, 7577U, null, 1, 4);
      _characterStandbyCount = new DataValue<byte>(owner, 7572U, null, 0, 12);
    }

    public CharacterData[] CharacterData => _characterData;

    public byte PartyCharacterCount
    {
      get => (byte) (_partyCharacterCount.Value & 7U);
      set
      {
        _partyCharacterCount.Value = (byte) (_partyCharacterCount.Value & 248 | value & 7);
      }
    }

    public byte CharacterStandbyCount
    {
      get => (byte) (_characterStandbyCount.Value & 15U);
      set
      {
        _characterStandbyCount.Value = (byte) (_characterStandbyCount.Value & 240 | value & 15);
      }
    }

    public byte CharacterCount
    {
      get => (byte) (PartyCharacterCount + (uint) CharacterStandbyCount);
    }

    public void OnLoaded()
    {
      for (int index = 0; index < _partyCharacterCount.Value; ++index)
      {
        if (_partyOrder[index].Value == 0)
          MoveTo(_characterStandbyCount.Value + index, _characterStandbyCount.Value);
      }
      _characterEdited = false;
    }

    public void OnSaving()
    {
      if (!_characterEdited)
        return;
      for (int index = 0; index < _partyCharacterCount.Value; ++index)
        _partyOrder[index].Value = (byte) index;
    }

    public void MoveTo(int srcIndex, int toIndex)
    {
      if (srcIndex >= CharacterCount || toIndex >= CharacterCount || srcIndex == toIndex)
        return;
      byte[] bytesData = _characterData[srcIndex].GetBytesData();
      if (srcIndex > toIndex)
      {
        for (int index = srcIndex; index > toIndex; --index)
          _characterData[index].Copy(_characterData[index - 1].GetBytesData());
      }
      else if (srcIndex < toIndex)
      {
        for (int index = srcIndex; index < toIndex; ++index)
          _characterData[index].Copy(_characterData[index + 1].GetBytesData());
      }
      _characterData[toIndex].Copy(bytesData);
      SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoCharacterIndexChanged(srcIndex, toIndex));
    }

    public void PartyIn(int index)
    {
      if (_partyCharacterCount.Value >= _partyCharacterCount.Max || _characterStandbyCount.Value <= index)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      MoveTo(index, CharacterCount - 1);
      --_characterStandbyCount.Value;
      ++_partyCharacterCount.Value;
      _characterEdited = true;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void PartyOut(int index)
    {
      if (_partyCharacterCount.Value < 2)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      MoveTo(_characterStandbyCount.Value + index, _characterStandbyCount.Value);
      ++_characterStandbyCount.Value;
      --_partyCharacterCount.Value;
      _characterEdited = true;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void PartyMemberUp(int index)
    {
      if (index <= 0 || index >= _partyCharacterCount.Value)
        return;
      MoveTo(_characterStandbyCount.Value + index, _characterStandbyCount.Value + index - 1);
      _characterEdited = true;
    }

    public void PartyMemberDown(int index)
    {
      if (index < 0 || index >= _partyCharacterCount.Value - 1)
        return;
      MoveTo(_characterStandbyCount.Value + index, _characterStandbyCount.Value + index + 1);
      _characterEdited = true;
    }

    public void StandbyMemberUp(int index)
    {
      if (index <= 0 || index >= _characterStandbyCount.Value)
        return;
      MoveTo(index, index - 1);
    }

    public void StandbyMemberDown(int index)
    {
      if (index < 0 || index >= _characterStandbyCount.Value - 1)
        return;
      MoveTo(index, index + 1);
    }

    public void DeleteCharacter(int index)
    {
      if (index < 0 || index >= _characterStandbyCount.Value)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      MoveTo(index, CharacterCount - 1);
      _characterData[CharacterCount - 1].Clear();
      --_characterStandbyCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public bool CreateCharacter()
    {
      if (CharacterCount >= 13)
        return false;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      ++_characterStandbyCount.Value;
      _characterData[CharacterCount - 1].Clear();
      _characterData[CharacterCount - 1].InitNewChara();
      MoveTo(CharacterCount - 1, _characterStandbyCount.Value - 1);
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      return true;
    }
  }
}
