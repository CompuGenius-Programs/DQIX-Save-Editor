// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.VisitorManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Security.Cryptography;

namespace DQ9_Cheat.DataManager
{
  internal class VisitorManager
  {
    public const int VisitorMax = 30;
    private VisitorData[] _visitorData = new VisitorData[30];
    private DataValue<byte> _visitorCount;

    public VisitorManager(SaveData owner)
    {
      for (uint index = 0; index < 30U; ++index)
        _visitorData[(int) index] = new VisitorData(owner, index);
      _visitorCount = new DataValue<byte>(owner, 23160U, null, 0, 30);
    }

    public VisitorData[] VisitorData => _visitorData;

    public DataValue<byte> VisitorCount => _visitorCount;

    public void OnLoaded()
    {
      for (uint index = 0; index < 30U; ++index)
        _visitorData[(int) index].OnLoaded();
    }

    public void OnUndo()
    {
      for (uint index = 0; index < 30U; ++index)
        _visitorData[(int) index].OnUndo();
    }

    public void OnRedo()
    {
      for (uint index = 0; index < 30U; ++index)
        _visitorData[(int) index].OnRedo();
    }

    public void MoveTo(int srcIndex, int toIndex)
    {
      if (srcIndex == toIndex)
        return;
      byte[] bytesData = _visitorData[srcIndex].GetBytesData();
      if (srcIndex > toIndex)
      {
        for (int index = srcIndex; index > toIndex; --index)
          _visitorData[index].Copy(_visitorData[index - 1].GetBytesData());
      }
      else if (srcIndex < toIndex)
      {
        for (int index = srcIndex; index < toIndex; ++index)
          _visitorData[index].Copy(_visitorData[index + 1].GetBytesData());
      }
      _visitorData[toIndex].Copy(bytesData);
      SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoVisitorIndexChanged(srcIndex, toIndex));
    }

    public void DeleteVisitor(int index)
    {
      if (index < 0 || index >= _visitorCount.Value)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      MoveTo(index, _visitorCount.Value - 1);
      _visitorData[_visitorCount.Value - 1].Clear();
      --_visitorCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public bool CreateCharacter()
    {
      if (_visitorCount.Value >= 30)
        return false;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      int index = 0;
      while (index < 30 && _visitorData[index].SEQ != 0U)
        ++index;
      ++SaveDataManager.Instance.SaveData.RikkaData.VisitorCount;
      ++_visitorCount.Value;
      _visitorData[index].Clear();
      _visitorData[index].SEQ = SaveDataManager.Instance.SaveData.RikkaData.VisitorCount;
      _visitorData[index].OnCreate();
      _visitorData[index].LodgingDay_Year = (ushort) DateTime.Now.Year;
      _visitorData[index].LodgingDay_Month = (byte) DateTime.Now.Month;
      _visitorData[index].LodgingDay_Day = (byte) DateTime.Now.Day;
      uint uid;
      do
        ;
      while (!IsValidUID(uid = CreateUID()));
      _visitorData[index].UID = uid;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      return true;
    }

    private uint CreateUID()
    {
      byte[] data = new byte[4];
      new RNGCryptoServiceProvider().GetNonZeroBytes(data);
      return (uint) (data[0] | data[1] << 8 | data[2] << 16 | data[3] << 24);
    }

    public bool IsValidUID(uint uid)
    {
      if (uid == 0U)
        return false;
      for (int index = 0; index < 30; ++index)
      {
        if (_visitorData[index].SEQ != 0U && (long) _visitorData[index].UID == uid)
          return false;
      }
      return true;
    }
  }
}
