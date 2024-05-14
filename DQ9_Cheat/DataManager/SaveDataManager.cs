// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.SaveDataManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.IO;
using System.Text;

namespace DQ9_Cheat.DataManager;

internal class SaveDataManager
{
    private static SaveDataManager _instance;
    private readonly uint[] _crcTable = new uint[256];
    private byte[] _footerData;
    private byte[] _headerData;
    private readonly SaveData[] _saveData = new SaveData[2];
    private int _selectedDataIndex;

    private SaveDataManager()
    {
        MakeCRCTable();
        _saveData[0] = new SaveData();
        _saveData[1] = new SaveData();
    }

    public UndoRedoManager UndoRedoMgr { get; } = new();

    public static SaveDataManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SaveDataManager();
            return _instance;
        }
    }

    public string DataFilePath { get; set; }

    public int SelectedDataIndex
    {
        get => _selectedDataIndex;
        set
        {
            if (value < 0)
                value = 0;
            if (value > 1)
                value = 1;
            if (value == 1 && _saveData[1].IsIntermission.Value == 0)
                value = 0;
            _selectedDataIndex = value;
        }
    }

    public SaveData SaveData => _saveData[_selectedDataIndex];

    public bool IsThereIntermissionData => _saveData[1].IsIntermission.Value == 1;

    public void ReadData(BinaryReader br)
    {
        UndoRedoMgr.OnLoading();
        for (var index = 0; index < 2; ++index)
            _saveData[index].ReadData(br);
        if (br.BaseStream.Position < br.BaseStream.Length)
            _footerData = br.ReadBytes((int)(br.BaseStream.Length - br.BaseStream.Position));
        UndoRedoMgr.OnLoaded();
    }

    public unsafe int CheckFile(BinaryReader br)
    {
        if (br.BaseStream.Length < 65536L)
            return -1;
        var numArray = br.ReadBytes(1024);
        uint num = 1195463236;
        fixed (byte* numPtr1 = &numArray[0])
        {
            var numPtr2 = numPtr1;
            for (var length = 0; length < 1008; ++length)
            {
                if ((int)*(uint*)numPtr2 == (int)num &&
                    Encoding.GetEncoding("shift-jis").GetString(numArray, length, 15) == "DRAGON QUEST IX")
                {
                    _headerData = new byte[length];
                    Array.Copy(numArray, 0, _headerData, 0, length);
                    return length;
                }

                ++numPtr2;
            }
        }

        return -1;
    }

    public unsafe void WriteData(BinaryWriter bw)
    {
        if (_headerData != null)
            bw.Write(_headerData);
        for (var index = 0; index < 2; ++index)
        {
            _saveData[index].OnSaving();
            var num1 = crc32(_saveData[index].Data, 20, 16);
            var num2 = crc32(_saveData[index].Data, 136, 28508);
            fixed (byte* numPtr = &_saveData[index].Data[16])
            {
                *(int*)numPtr = (int)num1;
            }

            fixed (byte* numPtr = &_saveData[index].Data[132])
            {
                *(int*)numPtr = (int)num2;
            }

            bw.Write(_saveData[index].Data);
        }

        if (_footerData != null)
            bw.Write(_footerData);
        UndoRedoMgr.OnSave();
    }

    public void CopyIntermissionData(int srcIndex)
    {
        if (srcIndex == 1 && _saveData[1].IsIntermission.Value != 1)
            return;
        Instance.UndoRedoMgr.BeginPluralEdit();
        Instance.UndoRedoMgr.Edited(new UndoRedoSaveDataCopy(srcIndex));
        var data = _saveData[srcIndex].GetData();
        _saveData[srcIndex ^ 1].CopyData(data);
        if (srcIndex == 0)
        {
            _saveData[1].IsIntermission.Value = 1;
            _saveData[1].BasisData.IntermissionPlace = _saveData[0].BasisData.SavePlace;
            _saveData[1].BasisData.IntermissionX.Value = 0;
            _saveData[1].BasisData.IntermissionY.Value = 0;
            _saveData[1].BasisData.IntermissionZ.Value = 0;
        }

        Instance.UndoRedoMgr.EndPluralEdit();
    }

    internal SaveData GetSaveData(int index)
    {
        return index == 0 || index == 1 ? _saveData[index] : null;
    }

    public void RemoveIntermissionData()
    {
        if (!IsThereIntermissionData)
            return;
        UndoRedoMgr.BeginPluralEdit();
        _saveData[0].IsIntermission.Value = 0;
        _saveData[1].IsIntermission.Value = 0;
        UndoRedoMgr.EndPluralEdit();
    }

    private void MakeCRCTable()
    {
        for (var index1 = 0; index1 < 256; ++index1)
        {
            var num = (uint)index1;
            for (var index2 = 0; index2 < 8; ++index2)
                if (((int)num & 1) != 0)
                    num = 3988292384U ^ (num >> 1);
                else
                    num >>= 1;
            _crcTable[index1] = num;
        }
    }

    private uint crc32(byte[] data, int offset, int length)
    {
        var num = uint.MaxValue;
        for (uint index = 0; index < length; ++index)
            num = _crcTable[(int)(uint)(((int)num ^ data[offset + index]) & byte.MaxValue)] ^ (num >> 8);
        return num ^ uint.MaxValue;
    }
}