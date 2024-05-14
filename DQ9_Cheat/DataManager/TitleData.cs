// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.TitleData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.DataManager;

internal class TitleData
{
    private readonly DataValue<ushort> _titleCount;
    private readonly DataValue<byte>[] _titleFlag = new DataValue<byte>[TitleDataList.MaxDataIndex / 8 + 1];

    public TitleData(SaveData owner)
    {
        for (var index = 0; index < _titleFlag.Length; ++index)
            _titleFlag[index] = new DataValue<byte>(owner, (uint)(15964 + index), null, 0, byte.MaxValue);
        _titleCount = new DataValue<ushort>(owner, 16040U, null, 0, ushort.MaxValue);
    }

    public ushort TitleCount
    {
        get => (ushort)(_titleCount.Value & 511U);
        set => _titleCount.Value = (ushort)((_titleCount.Value & 65024) | (value & 511));
    }

    public bool IsTitleHold(int index)
    {
        var dataIndex = TitleDataList.List[index].DataIndex;
        return (_titleFlag[dataIndex >> 3].Value & (1 << (dataIndex % 8))) != 0;
    }

    public void SetTitleHold(int index, bool value)
    {
        var dataIndex = TitleDataList.List[index].DataIndex;
        var index1 = dataIndex >> 3;
        var num = dataIndex % 8;
        var dataValue = _titleFlag[index1];
        dataValue.Value = (byte)((dataValue.Value & ~(1 << num)) | (value ? 1 << num : 0));
    }

    public void ReviseTitleCount()
    {
        ushort num = 0;
        for (var index = 0; index < TitleDataList.List.Count; ++index)
            if (IsTitleHold(index))
                ++num;
        TitleCount = num;
    }
}