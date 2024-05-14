// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.MonsterDataManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.DataManager;

internal class MonsterDataManager
{
    public const int MonsterDataCount = 307;
    private const uint MonsterDataOffset = 13784;
    private readonly DataValue<ushort> _compCount;
    private readonly DataValue<uint>[] _monsterData = new DataValue<uint>[307];

    public MonsterDataManager(SaveData owner)
    {
        for (uint index = 0; index < 307U; ++index)
            _monsterData[(int)index] =
                new DataValue<uint>(owner, (uint)(13784 + (int)index * 4), null, 0U, uint.MaxValue);
        _compCount = new DataValue<ushort>(owner, 16044U, null, 0, ushort.MaxValue);
    }

    public ushort CompCount => (ushort)(_compCount.Value & 511U);

    public void ReviseCompCount()
    {
        ushort num = 0;
        for (var index = 0; index < 307; ++index)
            if (GetVictoryCount(index) != 0)
                ++num;
        _compCount.Value = (ushort)((_compCount.Value & 65024) | (num & 511));
    }

    public ushort GetVictoryCount(int index)
    {
        var num = (ushort)(_monsterData[index].Value & 1023U);
        return num <= 999 ? num : (ushort)999;
    }

    public void SetVictoryCount(int index, ushort value)
    {
        if (value > 999)
            value = 999;
        _monsterData[index].Value = (uint)(((int)_monsterData[index].Value & -1024) | (value & 1023));
    }

    public bool IsFindOut(int index)
    {
        return ((int)_monsterData[index].Value & 1024) != 0;
    }

    public void SetFindOut(int index, bool value)
    {
        _monsterData[index].Value = (uint)(((int)_monsterData[index].Value & -1025) | (value ? 1024 : 0));
    }

    public byte GetItemCount1(int index)
    {
        var num = (byte)((_monsterData[index].Value & 260096U) >> 11);
        return num <= 99 ? num : (byte)99;
    }

    public void SetItemCount1(int index, byte value)
    {
        if (value > 99)
            value = 99;
        _monsterData[index].Value = (uint)(((int)_monsterData[index].Value & -260097) | ((value << 11) & 260096));
    }

    public byte GetItemCount2(int index)
    {
        var num = (byte)((_monsterData[index].Value & 33292288U) >> 18);
        return num <= 99 ? num : (byte)99;
    }

    public void SetItemCount2(int index, byte value)
    {
        if (value > 99)
            value = 99;
        _monsterData[index].Value = (uint)(((int)_monsterData[index].Value & -33292289) | ((value << 18) & 33292288));
    }
}