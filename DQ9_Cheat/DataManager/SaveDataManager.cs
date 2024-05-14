// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.SaveDataManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.IO;
using System.Text;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class SaveDataManager
  {
    private UndoRedoManager _undoRedoManger = new UndoRedoManager();
    private static SaveDataManager _instance;
    private string _dataFilePath;
    private int _selectedDataIndex;
    private SaveData[] _saveData = new SaveData[2];
    private byte[] _headerData;
    private byte[] _footerData;
    private uint[] _crcTable = new uint[256];

    private SaveDataManager()
    {
      this.MakeCRCTable();
      this._saveData[0] = new SaveData();
      this._saveData[1] = new SaveData();
    }

    public UndoRedoManager UndoRedoMgr => this._undoRedoManger;

    public static SaveDataManager Instance
    {
      get
      {
        if (SaveDataManager._instance == null)
          SaveDataManager._instance = new SaveDataManager();
        return SaveDataManager._instance;
      }
    }

    public void ReadData(BinaryReader br)
    {
      this._undoRedoManger.OnLoading();
      for (int index = 0; index < 2; ++index)
        this._saveData[index].ReadData(br);
      if (br.BaseStream.Position < br.BaseStream.Length)
        this._footerData = br.ReadBytes((int) (br.BaseStream.Length - br.BaseStream.Position));
      this._undoRedoManger.OnLoaded();
    }

    public unsafe int CheckFile(BinaryReader br)
    {
      if (br.BaseStream.Length < 65536L)
        return -1;
      byte[] numArray = br.ReadBytes(1024);
      uint num = 1195463236;
      fixed (byte* numPtr1 = &numArray[0])
      {
        byte* numPtr2 = numPtr1;
        for (int length = 0; length < 1008; ++length)
        {
          if ((int) *(uint*) numPtr2 == (int) num && Encoding.GetEncoding("shift-jis").GetString(numArray, length, 15) == "DRAGON QUEST IX")
          {
            this._headerData = new byte[length];
            Array.Copy((Array) numArray, 0, (Array) this._headerData, 0, length);
            return length;
          }
          ++numPtr2;
        }
      }
      return -1;
    }

    public unsafe void WriteData(BinaryWriter bw)
    {
      if (this._headerData != null)
        bw.Write(this._headerData);
      for (int index = 0; index < 2; ++index)
      {
        this._saveData[index].OnSaving();
        uint num1 = this.crc32(this._saveData[index].Data, 20, 16);
        uint num2 = this.crc32(this._saveData[index].Data, 136, 28508);
        fixed (byte* numPtr = &this._saveData[index].Data[16])
          *(int*) numPtr = (int) num1;
        fixed (byte* numPtr = &this._saveData[index].Data[132])
          *(int*) numPtr = (int) num2;
        bw.Write(this._saveData[index].Data);
      }
      if (this._footerData != null)
        bw.Write(this._footerData);
      this._undoRedoManger.OnSave();
    }

    public void CopyIntermissionData(int srcIndex)
    {
      if (srcIndex == 1 && this._saveData[1].IsIntermission.Value != (byte) 1)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      SaveDataManager.Instance.UndoRedoMgr.Edited((UndoRedoElement) new UndoRedoSaveDataCopy(srcIndex));
      byte[] data = this._saveData[srcIndex].GetData();
      this._saveData[srcIndex ^ 1].CopyData(data);
      if (srcIndex == 0)
      {
        this._saveData[1].IsIntermission.Value = (byte) 1;
        this._saveData[1].BasisData.IntermissionPlace = this._saveData[0].BasisData.SavePlace;
        this._saveData[1].BasisData.IntermissionX.Value = 0;
        this._saveData[1].BasisData.IntermissionY.Value = 0;
        this._saveData[1].BasisData.IntermissionZ.Value = 0;
      }
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public string DataFilePath
    {
      get => this._dataFilePath;
      set => this._dataFilePath = value;
    }

    public int SelectedDataIndex
    {
      get => this._selectedDataIndex;
      set
      {
        if (value < 0)
          value = 0;
        if (value > 1)
          value = 1;
        if (value == 1 && this._saveData[1].IsIntermission.Value == (byte) 0)
          value = 0;
        this._selectedDataIndex = value;
      }
    }

    public SaveData SaveData => this._saveData[this._selectedDataIndex];

    internal SaveData GetSaveData(int index)
    {
      return index == 0 || index == 1 ? this._saveData[index] : (SaveData) null;
    }

    public bool IsThereIntermissionData => this._saveData[1].IsIntermission.Value == (byte) 1;

    public void RemoveIntermissionData()
    {
      if (!this.IsThereIntermissionData)
        return;
      this._undoRedoManger.BeginPluralEdit();
      this._saveData[0].IsIntermission.Value = (byte) 0;
      this._saveData[1].IsIntermission.Value = (byte) 0;
      this._undoRedoManger.EndPluralEdit();
    }

    private void MakeCRCTable()
    {
      for (int index1 = 0; index1 < 256; ++index1)
      {
        uint num = (uint) index1;
        for (int index2 = 0; index2 < 8; ++index2)
        {
          if (((int) num & 1) != 0)
            num = 3988292384U ^ num >> 1;
          else
            num >>= 1;
        }
        this._crcTable[index1] = num;
      }
    }

    private uint crc32(byte[] data, int offset, int length)
    {
      uint num = uint.MaxValue;
      for (uint index = 0; (long) index < (long) length; ++index)
        num = this._crcTable[(int) (uint) (((int) num ^ (int) data[(long) offset + (long) index]) & (int) byte.MaxValue)] ^ num >> 8;
      return num ^ uint.MaxValue;
    }
  }
}
