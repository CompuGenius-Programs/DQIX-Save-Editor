// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.CharacterManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class CharacterManager
  {
    public const int CharacterMax = 13;
    private bool _characterEdited;
    private DQ9_Cheat.DataManager.CharacterData[] _characterData = new DQ9_Cheat.DataManager.CharacterData[13];
    private DataValue<byte>[] _partyOrder = new DataValue<byte>[4];
    private DataValue<byte> _partyCharacterCount;
    private DataValue<byte> _characterStandbyCount;

    public CharacterManager(SaveData owner)
    {
      for (int index = 0; index < 4; ++index)
        this._partyOrder[index] = new DataValue<byte>(owner, (uint) (7573 + index), (Control) null, (byte) 0, (byte) 3);
      for (uint index = 0; index < 13U; ++index)
        this._characterData[(int) index] = new DQ9_Cheat.DataManager.CharacterData(owner, index);
      this._partyCharacterCount = new DataValue<byte>(owner, 7577U, (Control) null, (byte) 1, (byte) 4);
      this._characterStandbyCount = new DataValue<byte>(owner, 7572U, (Control) null, (byte) 0, (byte) 12);
    }

    public DQ9_Cheat.DataManager.CharacterData[] CharacterData => this._characterData;

    public byte PartyCharacterCount
    {
      get => (byte) ((uint) this._partyCharacterCount.Value & 7U);
      set
      {
        this._partyCharacterCount.Value = (byte) ((int) this._partyCharacterCount.Value & 248 | (int) value & 7);
      }
    }

    public byte CharacterStandbyCount
    {
      get => (byte) ((uint) this._characterStandbyCount.Value & 15U);
      set
      {
        this._characterStandbyCount.Value = (byte) ((int) this._characterStandbyCount.Value & 240 | (int) value & 15);
      }
    }

    public byte CharacterCount
    {
      get => (byte) ((uint) this.PartyCharacterCount + (uint) this.CharacterStandbyCount);
    }

    public void OnLoaded()
    {
      for (int index = 0; index < (int) this._partyCharacterCount.Value; ++index)
      {
        if (this._partyOrder[index].Value == (byte) 0)
          this.MoveTo((int) this._characterStandbyCount.Value + index, (int) this._characterStandbyCount.Value);
      }
      this._characterEdited = false;
    }

    public void OnSaving()
    {
      if (!this._characterEdited)
        return;
      for (int index = 0; index < (int) this._partyCharacterCount.Value; ++index)
        this._partyOrder[index].Value = (byte) index;
    }

    public void MoveTo(int srcIndex, int toIndex)
    {
      if (srcIndex >= (int) this.CharacterCount || toIndex >= (int) this.CharacterCount || srcIndex == toIndex)
        return;
      byte[] bytesData = this._characterData[srcIndex].GetBytesData();
      if (srcIndex > toIndex)
      {
        for (int index = srcIndex; index > toIndex; --index)
          this._characterData[index].Copy(this._characterData[index - 1].GetBytesData());
      }
      else if (srcIndex < toIndex)
      {
        for (int index = srcIndex; index < toIndex; ++index)
          this._characterData[index].Copy(this._characterData[index + 1].GetBytesData());
      }
      this._characterData[toIndex].Copy(bytesData);
      SaveDataManager.Instance.UndoRedoMgr.Edited((UndoRedoElement) new UndoRedoCharacterIndexChanged(srcIndex, toIndex));
    }

    public void PartyIn(int index)
    {
      if ((int) this._partyCharacterCount.Value >= (int) this._partyCharacterCount.Max || (int) this._characterStandbyCount.Value <= index)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.MoveTo(index, (int) this.CharacterCount - 1);
      --this._characterStandbyCount.Value;
      ++this._partyCharacterCount.Value;
      this._characterEdited = true;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void PartyOut(int index)
    {
      if (this._partyCharacterCount.Value < (byte) 2)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.MoveTo((int) this._characterStandbyCount.Value + index, (int) this._characterStandbyCount.Value);
      ++this._characterStandbyCount.Value;
      --this._partyCharacterCount.Value;
      this._characterEdited = true;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void PartyMemberUp(int index)
    {
      if (index <= 0 || index >= (int) this._partyCharacterCount.Value)
        return;
      this.MoveTo((int) this._characterStandbyCount.Value + index, (int) this._characterStandbyCount.Value + index - 1);
      this._characterEdited = true;
    }

    public void PartyMemberDown(int index)
    {
      if (index < 0 || index >= (int) this._partyCharacterCount.Value - 1)
        return;
      this.MoveTo((int) this._characterStandbyCount.Value + index, (int) this._characterStandbyCount.Value + index + 1);
      this._characterEdited = true;
    }

    public void StandbyMemberUp(int index)
    {
      if (index <= 0 || index >= (int) this._characterStandbyCount.Value)
        return;
      this.MoveTo(index, index - 1);
    }

    public void StandbyMemberDown(int index)
    {
      if (index < 0 || index >= (int) this._characterStandbyCount.Value - 1)
        return;
      this.MoveTo(index, index + 1);
    }

    public void DeleteCharacter(int index)
    {
      if (index < 0 || index >= (int) this._characterStandbyCount.Value)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.MoveTo(index, (int) this.CharacterCount - 1);
      this._characterData[(int) this.CharacterCount - 1].Clear();
      --this._characterStandbyCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public bool CreateCharacter()
    {
      if (this.CharacterCount >= (byte) 13)
        return false;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      ++this._characterStandbyCount.Value;
      this._characterData[(int) this.CharacterCount - 1].Clear();
      this._characterData[(int) this.CharacterCount - 1].InitNewChara();
      this.MoveTo((int) this.CharacterCount - 1, (int) this._characterStandbyCount.Value - 1);
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      return true;
    }
  }
}
