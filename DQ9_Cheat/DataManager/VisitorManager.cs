// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.VisitorManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Security.Cryptography;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class VisitorManager
  {
    public const int VisitorMax = 30;
    private DQ9_Cheat.DataManager.VisitorData[] _visitorData = new DQ9_Cheat.DataManager.VisitorData[30];
    private DataValue<byte> _visitorCount;

    public VisitorManager(SaveData owner)
    {
      for (uint index = 0; index < 30U; ++index)
        this._visitorData[(int) index] = new DQ9_Cheat.DataManager.VisitorData(owner, index);
      this._visitorCount = new DataValue<byte>(owner, 23160U, (Control) null, (byte) 0, (byte) 30);
    }

    public DQ9_Cheat.DataManager.VisitorData[] VisitorData => this._visitorData;

    public DataValue<byte> VisitorCount => this._visitorCount;

    public void OnLoaded()
    {
      for (uint index = 0; index < 30U; ++index)
        this._visitorData[(int) index].OnLoaded();
    }

    public void OnUndo()
    {
      for (uint index = 0; index < 30U; ++index)
        this._visitorData[(int) index].OnUndo();
    }

    public void OnRedo()
    {
      for (uint index = 0; index < 30U; ++index)
        this._visitorData[(int) index].OnRedo();
    }

    public void MoveTo(int srcIndex, int toIndex)
    {
      if (srcIndex == toIndex)
        return;
      byte[] bytesData = this._visitorData[srcIndex].GetBytesData();
      if (srcIndex > toIndex)
      {
        for (int index = srcIndex; index > toIndex; --index)
          this._visitorData[index].Copy(this._visitorData[index - 1].GetBytesData());
      }
      else if (srcIndex < toIndex)
      {
        for (int index = srcIndex; index < toIndex; ++index)
          this._visitorData[index].Copy(this._visitorData[index + 1].GetBytesData());
      }
      this._visitorData[toIndex].Copy(bytesData);
      SaveDataManager.Instance.UndoRedoMgr.Edited((UndoRedoElement) new UndoRedoVisitorIndexChanged(srcIndex, toIndex));
    }

    public void DeleteVisitor(int index)
    {
      if (index < 0 || index >= (int) this._visitorCount.Value)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.MoveTo(index, (int) this._visitorCount.Value - 1);
      this._visitorData[(int) this._visitorCount.Value - 1].Clear();
      --this._visitorCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public bool CreateCharacter()
    {
      if (this._visitorCount.Value >= (byte) 30)
        return false;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      int index = 0;
      while (index < 30 && this._visitorData[index].SEQ != 0U)
        ++index;
      ++SaveDataManager.Instance.SaveData.RikkaData.VisitorCount;
      ++this._visitorCount.Value;
      this._visitorData[index].Clear();
      this._visitorData[index].SEQ = SaveDataManager.Instance.SaveData.RikkaData.VisitorCount;
      this._visitorData[index].OnCreate();
      this._visitorData[index].LodgingDay_Year = (ushort) DateTime.Now.Year;
      this._visitorData[index].LodgingDay_Month = (byte) DateTime.Now.Month;
      this._visitorData[index].LodgingDay_Day = (byte) DateTime.Now.Day;
      uint uid;
      do
        ;
      while (!this.IsValidUID(uid = this.CreateUID()));
      this._visitorData[index].UID = (ulong) uid;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      return true;
    }

    private uint CreateUID()
    {
      byte[] data = new byte[4];
      new RNGCryptoServiceProvider().GetNonZeroBytes(data);
      return (uint) ((int) data[0] | (int) data[1] << 8 | (int) data[2] << 16 | (int) data[3] << 24);
    }

    public bool IsValidUID(uint uid)
    {
      if (uid == 0U)
        return false;
      for (int index = 0; index < 30; ++index)
      {
        if (this._visitorData[index].SEQ != 0U && (long) this._visitorData[index].UID == (long) uid)
          return false;
      }
      return true;
    }
  }
}
