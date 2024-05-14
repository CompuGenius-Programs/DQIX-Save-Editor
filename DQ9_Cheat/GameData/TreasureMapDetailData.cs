// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.TreasureMapDetailData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DQ9_Cheat.GameData;

internal class TreasureMapDetailData
{
    private const int FloorMapDataOffset = 792;
    private const uint ConstValue1 = 1103515245;
    private const uint ConstValue2 = 12345;
    private static List<byte> _candidateRank;

    [ThreadStatic] private static byte[,] _dungeonInfo;

    private readonly byte[] _details = new byte[20];
    private readonly byte[] _details2 = new byte[20];
    private readonly List<byte> _highRankValidPlaceList = new();
    private readonly List<byte> _lowRankValidPlaceList = new();
    private readonly List<byte> _middleRankValidPlaceList = new();
    private uint _seed;
    private readonly List<byte> _validPlaceList = new();
    private readonly List<byte> _validRankList = new();

    public TreasureMapDetailData()
    {
        if (_dungeonInfo == null)
            _dungeonInfo = new byte[16, 1336];
        for (var index = 0; index < 16; ++index)
            TreasureBoxInfoList[index] = new List<TreasureBoxInfo>();
        if (_candidateRank != null)
            return;
        _candidateRank = new List<byte>();
        for (var index1 = 1; index1 <= 99; ++index1)
        for (var index2 = 0; index2 <= 50; index2 += 5)
        for (var index3 = 1; index3 <= 99; ++index3)
        {
            var num = (byte)(index1 + index2 + index3);
            if (!_candidateRank.Contains(num))
                _candidateRank.Add(num);
        }
    }

    public ushort MapSeed { get; set; }

    public byte MapRank { get; set; }

    public bool IsValidSeed { get; private set; }

    public bool IsValidRank => _validRankList.Contains(MapRank);

    public ReadOnlyCollection<byte> ValidPlaceList => _validPlaceList.AsReadOnly();

    public ReadOnlyCollection<byte> LowRankValidPlaceList => _lowRankValidPlaceList.AsReadOnly();

    public ReadOnlyCollection<byte> MiddleRankValidPlaceList => _middleRankValidPlaceList.AsReadOnly();

    public ReadOnlyCollection<byte> HighRankValidPlaceList => _highRankValidPlaceList.AsReadOnly();

    public string MapName
    {
        get
        {
            if (MapRank < 2 || MapRank > 248)
                return "Unknown";
            return string.Format("{0} {2} of {1} Lv. {3}", TreasureMapDataTable.TreasureMapName1_Table[_details[5] - 1],
                TreasureMapDataTable.TreasureMapName2_Table[_details[6] - 1],
                TreasureMapDataTable.TreasureMapName3_Table[MapName3Index], _details[4]);
        }
    }

    public string MapName1 => MapRank < 2 || MapRank > 248
        ? "Unknown"
        : TreasureMapDataTable.TreasureMapName1_Table[_details[5] - 1];

    public byte MapName1Index => (byte)(_details[5] - 1U);

    public string MapName2 => MapRank < 2 || MapRank > 248
        ? "Unknown"
        : TreasureMapDataTable.TreasureMapName2_Table[_details[6] - 1];

    public byte MapName2Index => (byte)(_details[6] - 1U);

    public string MapName3 => MapRank < 2 || MapRank > 248
        ? "Unknown"
        : TreasureMapDataTable.TreasureMapName3_Table[MapName3Index];

    public byte MapName3Index { get; private set; }

    public int MapLevel => MapRank < 2 || MapRank > 248 ? 0 : _details[4];

    public string BossName => MonsterDataList.List[282 + _details[0] - 1];

    public byte BossIndex => (byte)(_details[0] - 1U);

    public int FloorCount => _details[1];

    public int MonsterRank => _details[2];

    public string MapTypeName => TreasureMapDataTable.TreasureMapMapTypeName_Table[_details[3] - 1];

    public byte MapTypeIndex => (byte)(_details[3] - 1U);

    public List<TreasureBoxInfo>[] TreasureBoxInfoList { get; } = new List<TreasureBoxInfo>[16];

    public bool IsValidPlace(byte place)
    {
        return _validPlaceList.Contains(place);
    }

    private uint GenerateRandom()
    {
        _seed *= 1103515245U;
        _seed += 12345U;
        return (_seed >> 16) & (uint)short.MaxValue;
    }

    private uint GenerateRandom(uint div)
    {
        return GenerateRandom() % div;
    }

    private uint GetItemRank(uint value1, uint value2)
    {
        var num = (int)GenerateRandom() - 1f;
        return (uint)(float)(((int)value2 - (int)value1 + 1) * (double)num / short.MaxValue) + value1;
    }

    private uint Seek1(byte[] table, int tableSize)
    {
        var random = GenerateRandom(100U);
        uint num = 0;
        for (var index = 0; index < tableSize; ++index)
        {
            num += table[index * 4 + 1];
            if (random < num)
                return table[index * 4];
        }

        return 0;
    }

    private uint Seek2(byte[] table, byte value, int tableSize)
    {
        for (var index = 0; index < tableSize; ++index)
            if (value >= table[index * 4] && value <= table[index * 4 + 1])
                return Seek3(table[index * 4 + 2], table[index * 4 + 3]);
        return 0;
    }

    private uint Seek3(byte val1, byte val2)
    {
        var random = GenerateRandom();
        var num = val2 - val1 + 1;
        return num == 0 ? val1 : (uint)(val1 + random % (ulong)num);
    }

    private uint Seek4(byte[] table1, byte[] table2, int roopCount)
    {
        for (var index1 = 0; index1 < roopCount; ++index1)
            if (MapRank >= table1[index1 * 4] && MapRank <= table1[index1 * 4 + 1])
            {
                var num1 = 0;
                for (int index2 = table1[index1 * 4 + 2]; index2 <= table1[index1 * 4 + 3]; ++index2)
                    num1 += table2[(index2 - 1) * 2 + 1];
                var num2 = (int)(GenerateRandom() % num1);
                var num3 = 0;
                for (int index3 = table1[index1 * 4 + 2]; index3 <= table1[index1 * 4 + 3]; ++index3)
                {
                    num3 += table2[(index3 - 1) * 2 + 1];
                    if (num2 < num3)
                        return (uint)index3;
                }

                break;
            }

        return 0;
    }

    private unsafe void GenerateFloorMap(int floor, uint address)
    {
        int index1;
        fixed (byte* numPtr = &_dungeonInfo[(int)(IntPtr)floor, (int)(IntPtr)unchecked(address + 8U)])
        {
            index1 = *(int*)numPtr;
        }

        var index2 = (int)address;
        var num1 = (_dungeonInfo[floor, index1 + 2] - _dungeonInfo[floor, index1] + 1) / 2;
        var num2 = (_dungeonInfo[floor, index1 + 3] - _dungeonInfo[floor, index1 + 1] + 1) / 2;
        var num3 = 0;
        if (_dungeonInfo[floor, 1] == 0 && GenerateRandom(0U, 15U) == 0U)
            num3 = 1;
        int num4;
        int num5;
        int num6;
        int num7;
        if (num3 == 0)
        {
            num4 = _dungeonInfo[floor, index2 + 3] - _dungeonInfo[floor, index1 + 3];
            num5 = _dungeonInfo[floor, index1] - _dungeonInfo[floor, index2];
            num6 = _dungeonInfo[floor, index2 + 2] - _dungeonInfo[floor, index1 + 2];
            num7 = _dungeonInfo[floor, index1 + 1] - _dungeonInfo[floor, index2 + 1];
        }
        else
        {
            num4 = _dungeonInfo[floor, 3] - _dungeonInfo[floor, index1 + 3] - 1;
            num5 = _dungeonInfo[floor, index1] - 1;
            num6 = _dungeonInfo[floor, 2] - _dungeonInfo[floor, index1 + 2] - 1;
            num7 = _dungeonInfo[floor, index1 + 1] - 1;
            _dungeonInfo[floor, 1] = 1;
        }

        for (int index3 = _dungeonInfo[floor, index1]; index3 <= _dungeonInfo[floor, index1 + 2]; ++index3)
        {
            int num8 = _dungeonInfo[floor, index3 + (_dungeonInfo[floor, index1 + 1] << 4) + 792];
            switch (num8)
            {
                case 1:
                case 3:
                    continue;
                default:
                    if (GenerateRandom(0U, 1U) == 0U)
                    {
                        if (num8 != 8)
                            switch (_dungeonInfo[floor, index3 + ((_dungeonInfo[floor, index1 + 1] - 1) << 4) + 792])
                            {
                                case 1:
                                case 8:
                                    continue;
                                default:
                                    var random1 = (int)GenerateRandom(0U, (uint)num2);
                                    var num9 = index3 - 1;
                                    for (var index4 = 0;
                                         index4 < random1 &&
                                         _dungeonInfo[floor,
                                             index3 + ((_dungeonInfo[floor, index1 + 1] + index4) << 4) + 792] != 8 &&
                                         _dungeonInfo[floor,
                                             index3 + ((_dungeonInfo[floor, index1 + 1] + index4 + 1) << 4) + 792] !=
                                         1 &&
                                         (_dungeonInfo[floor,
                                                 ((_dungeonInfo[floor, index1 + 1] + index4) << 4) + index3 + 1 +
                                                 792] ==
                                             1 || _dungeonInfo[floor,
                                                 ((_dungeonInfo[floor, index1 + 1] + index4 + 1) << 4) + index3 + 1 +
                                                 792] != 1) &&
                                         (_dungeonInfo[floor,
                                              ((_dungeonInfo[floor, index1 + 1] + index4) << 4) + num9 + 792] == 1 ||
                                          _dungeonInfo[floor,
                                              num9 + ((_dungeonInfo[floor, index1 + 1] + index4 + 1) << 4) + 792] != 1);
                                         ++index4)
                                        _dungeonInfo[floor,
                                            index3 + ((_dungeonInfo[floor, index1 + 1] + index4) << 4) + 792] = 1;
                                    continue;
                            }

                        continue;
                    }

                    var random2 = (int)GenerateRandom(0U, (uint)num7);
                    for (var index5 = 0; index5 < random2; ++index5)
                    {
                        var index6 = index3 + ((_dungeonInfo[floor, index1 + 1] - 1 - index5) << 4) + 792;
                        if (_dungeonInfo[floor, index6] != 8)
                            _dungeonInfo[floor, index6] = 0;
                    }

                    continue;
            }
        }

        for (int index7 = _dungeonInfo[floor, index1]; index7 <= _dungeonInfo[floor, index1 + 2]; ++index7)
        {
            int num10 = _dungeonInfo[floor, index7 + (_dungeonInfo[floor, index1 + 3] << 4) + 792];
            switch (num10)
            {
                case 1:
                case 3:
                    continue;
                default:
                    if (GenerateRandom(0U, 1U) != 0U)
                    {
                        var random = (int)GenerateRandom(0U, (uint)num4);
                        for (var index8 = 0; index8 < random; ++index8)
                            if (_dungeonInfo[floor,
                                    index7 + ((_dungeonInfo[floor, index1 + 3] + index8 + 1) << 4) + 792] != 8)
                                _dungeonInfo[floor,
                                    index7 + ((_dungeonInfo[floor, index1 + 3] + index8 + 1) << 4) + 792] = 0;
                        continue;
                    }

                    if (num10 != 8)
                        switch (_dungeonInfo[floor, index7 + ((_dungeonInfo[floor, index1 + 3] + 1) << 4) + 792])
                        {
                            case 1:
                            case 8:
                                continue;
                            default:
                                var random3 = (int)GenerateRandom(0U, (uint)num2);
                                var num11 = index7 - 1;
                                for (var index9 = 0;
                                     index9 < random3 &&
                                     _dungeonInfo[floor,
                                         index7 + ((_dungeonInfo[floor, index1 + 3] - index9) << 4) + 792] != 8 &&
                                     _dungeonInfo[floor,
                                         index7 + ((_dungeonInfo[floor, index1 + 3] - index9 - 1) << 4) + 792] != 1 &&
                                     (_dungeonInfo[floor,
                                          ((_dungeonInfo[floor, index1 + 3] - index9) << 4) + index7 + 1 + 792] == 1 ||
                                      _dungeonInfo[floor,
                                          ((_dungeonInfo[floor, index1 + 3] - index9 - 1) << 4) + index7 + 1 + 792] !=
                                      1) && (_dungeonInfo[floor,
                                                 num11 + ((_dungeonInfo[floor, index1 + 3] - index9) << 4) + 792] ==
                                             1 ||
                                             _dungeonInfo[floor,
                                                 num11 + ((_dungeonInfo[floor, index1 + 3] - index9 - 1) << 4) + 792] !=
                                             1);
                                     ++index9)
                                    _dungeonInfo[floor,
                                        index7 + ((_dungeonInfo[floor, index1 + 3] - index9) << 4) + 792] = 1;
                                continue;
                        }

                    continue;
            }
        }

        for (int index10 = _dungeonInfo[floor, index1 + 1]; index10 <= _dungeonInfo[floor, index1 + 3]; ++index10)
        {
            int num12 = _dungeonInfo[floor, (index10 << 4) + 792 + _dungeonInfo[floor, index1]];
            switch (num12)
            {
                case 1:
                case 3:
                    continue;
                default:
                    if (GenerateRandom(0U, 1U) != 0U)
                    {
                        var random = (int)GenerateRandom(0U, (uint)num5);
                        for (var index11 = 0; index11 < random; ++index11)
                            if (_dungeonInfo[floor, (index10 << 4) + 792 + _dungeonInfo[floor, index1] - 1 - index11] !=
                                8)
                                _dungeonInfo[floor, (index10 << 4) + 792 + _dungeonInfo[floor, index1] - 1 - index11] =
                                    0;
                        continue;
                    }

                    if (num12 != 8)
                        switch (_dungeonInfo[floor, (index10 << 4) + 792 + _dungeonInfo[floor, index1] - 1])
                        {
                            case 1:
                            case 8:
                                continue;
                            default:
                                var random4 = (int)GenerateRandom(0U, (uint)num1);
                                var num13 = index10 - 1;
                                for (var index12 = 0;
                                     index12 < random4 &&
                                     _dungeonInfo[floor,
                                         index12 + (index10 << 4) + _dungeonInfo[floor, index1] + 792] != 8 &&
                                     _dungeonInfo[floor,
                                         index12 + (index10 << 4) + _dungeonInfo[floor, index1] + 792 + 1] != 1 &&
                                     (_dungeonInfo[floor,
                                          index12 + ((index10 + 1) << 4) + _dungeonInfo[floor, index1] + 792] == 1 ||
                                      _dungeonInfo[floor,
                                          index12 + ((index10 + 1) << 4) + _dungeonInfo[floor, index1] + 792 + 1] !=
                                      1) && (_dungeonInfo[floor,
                                                 index12 + (num13 << 4) + _dungeonInfo[floor, index1] + 792] == 1 ||
                                             _dungeonInfo[floor,
                                                 index12 + (num13 << 4) + _dungeonInfo[floor, index1] + 792 + 1] != 1);
                                     ++index12)
                                    _dungeonInfo[floor, index12 + (index10 << 4) + _dungeonInfo[floor, index1] + 792] =
                                        1;
                                continue;
                        }

                    continue;
            }
        }

        for (int index13 = _dungeonInfo[floor, index1 + 1]; index13 <= _dungeonInfo[floor, index1 + 3]; ++index13)
        {
            int num14 = _dungeonInfo[floor, (index13 << 4) + 792 + _dungeonInfo[floor, index1 + 2]];
            switch (num14)
            {
                case 1:
                case 3:
                    continue;
                default:
                    if (GenerateRandom(0U, 1U) != 0U)
                    {
                        var random = (int)GenerateRandom(0U, (uint)num6);
                        for (var index14 = 0; index14 < random; ++index14)
                            if (_dungeonInfo[floor,
                                    index14 + (index13 << 4) + _dungeonInfo[floor, index1 + 2] + 792 + 1] != 8)
                                _dungeonInfo[floor,
                                    index14 + (index13 << 4) + _dungeonInfo[floor, index1 + 2] + 792 + 1] = 0;
                        continue;
                    }

                    if (num14 != 8)
                        switch (_dungeonInfo[floor, _dungeonInfo[floor, index1 + 1] + (index13 << 4) + 792 + 1])
                        {
                            case 1:
                            case 8:
                                continue;
                            default:
                                var random5 = (int)GenerateRandom(0U, (uint)num1);
                                var num15 = index13 - 1;
                                for (var index15 = 0;
                                     index15 < random5 &&
                                     _dungeonInfo[floor,
                                         (index13 << 4) + 792 + _dungeonInfo[floor, index1 + 2] - index15] != 8 &&
                                     _dungeonInfo[floor,
                                         (index13 << 4) + 792 + _dungeonInfo[floor, index1 + 2] - index15 - 1] != 1 &&
                                     (_dungeonInfo[floor,
                                          ((index13 + 1) << 4) + 792 + _dungeonInfo[floor, index1 + 2] - index15] ==
                                      1 ||
                                      _dungeonInfo[floor,
                                          ((index13 + 1) << 4) + 792 + _dungeonInfo[floor, index1 + 2] - index15 - 1] !=
                                      1) && (_dungeonInfo[floor,
                                                 (num15 << 4) + 792 + _dungeonInfo[floor, index1 + 2] - index15] == 1 ||
                                             _dungeonInfo[floor,
                                                 (num15 << 4) + 792 + _dungeonInfo[floor, index1 + 2] - index15 - 1] !=
                                             1);
                                     ++index15)
                                    _dungeonInfo[floor,
                                        (index13 << 4) + 792 + _dungeonInfo[floor, index1 + 2] - index15] = 1;
                                continue;
                        }

                    continue;
            }
        }
    }

    private unsafe void routine1(int floor, uint address, uint value1, uint value2)
    {
        if (value2 == 0U)
            return;
        var num1 = value1;
        if (value2 >= 4U)
        {
            var num2 = (value1 << 8) + value1;
            var num3 = num2;
            num1 = (num2 << 16) + num3;
            for (var index = value2 >> 2; index > 0U; --index)
            {
                fixed (byte* numPtr = &_dungeonInfo[(int)(IntPtr)floor, (int)(IntPtr)address])
                {
                    *(int*)numPtr = (int)num1;
                }

                address += 4U;
            }
        }

        if (value2 >= 4U && ((int)value2 & 3) == 0)
            return;
        for (value2 &= 3U; value2 > 0U; --value2)
        {
            _dungeonInfo[floor, address] = (byte)num1;
            ++address;
        }
    }

    private uint GenerateRandom(uint value1, uint value2)
    {
        if ((int)value1 == (int)value2)
            return value1;
        var random = GenerateRandom();
        var num = (int)value2 - (int)value1 + 1;
        return num == 0 ? value1 : (uint)(value1 + random % (ulong)num);
    }

    private void SetValue(
        int floor,
        uint address,
        byte value1,
        byte value2,
        byte value3,
        byte value4)
    {
        _dungeonInfo[floor, address] = value1;
        _dungeonInfo[floor, address + 1U] = value2;
        _dungeonInfo[floor, address + 2U] = value3;
        _dungeonInfo[floor, address + 3U] = value4;
    }

    private unsafe bool routineA(int floor, uint address, uint value1, uint value2)
    {
        var num1 = _dungeonInfo[floor, address + 3U] + 1 - _dungeonInfo[floor, address + 1U];
        if (num1 < 7 || _dungeonInfo[floor, address + 4U] != 0)
            return false;
        var random = (int)GenerateRandom(0U, (uint)(num1 - 7));
        var num2 = _dungeonInfo[floor, address + 1U] + random + 3;
        for (int index = _dungeonInfo[floor, address]; index < _dungeonInfo[floor, address + 2U] + 1; ++index)
            _dungeonInfo[floor, (num2 << 4) + index + 792] = 3;
        SetValue(floor, value2, _dungeonInfo[floor, address], (byte)num2, _dungeonInfo[floor, address + 2U],
            (byte)num2);
        SetValue(floor, value1, _dungeonInfo[floor, address], (byte)(num2 + 1), _dungeonInfo[floor, address + 2U],
            _dungeonInfo[floor, address + 3U]);
        _dungeonInfo[floor, value1 + 4U] = 0;
        _dungeonInfo[floor, value1 + 5U] = 0;
        _dungeonInfo[floor, address + 3U] = (byte)(num2 - 1);
        _dungeonInfo[floor, address + 4U] = 1;
        fixed (byte* numPtr = &_dungeonInfo[(int)(IntPtr)floor, (int)(IntPtr)value2])
        {
            *(int*)(numPtr + 4) = (int)address;
            *(int*)(numPtr + 8) = (int)value1;
        }

        _dungeonInfo[floor, value2 + 12U] = 1;
        return true;
    }

    private void routineB(int floor, uint address)
    {
        int num = _dungeonInfo[floor, 21];
        ++_dungeonInfo[floor, 21];
        ++_dungeonInfo[floor, 22];
        if (((int)GenerateRandom() & 1) != 0)
        {
            routineF(floor, address);
            routineF(floor, (uint)(num * 12 + 24));
        }
        else
        {
            routineF(floor, (uint)(num * 12 + 24));
            routineF(floor, address);
        }
    }

    private unsafe bool routineC(int floor, uint address1, uint address2)
    {
        if (_dungeonInfo[floor, address1 + 2U] + 1 - _dungeonInfo[floor, address1] < 3 ||
            _dungeonInfo[floor, address1 + 3U] + 1 - _dungeonInfo[floor, address1 + 1U] < 3)
            return false;
        int num1 = _dungeonInfo[floor, address1];
        int num2 = _dungeonInfo[floor, address1 + 1U];
        int num3 = _dungeonInfo[floor, address1 + 2U];
        int num4 = _dungeonInfo[floor, address1 + 3U];
        int random1;
        int random2;
        if (GenerateRandom(0U, 1U) != 0U)
        {
            random1 = (int)GenerateRandom((uint)num1, (uint)(num1 + (num3 - num1 + 1) / 3));
            random2 = (int)GenerateRandom((uint)num2, (uint)(num2 + (num4 - num2 + 1) / 3));
        }
        else
        {
            random1 = (int)GenerateRandom((uint)(num1 + 1), (uint)(num1 + (num3 - num1 + 1) / 3));
            random2 = (int)GenerateRandom((uint)(num2 + 1), (uint)(num2 + (num4 - num2 + 1) / 3));
        }

        int random3;
        int random4;
        if (GenerateRandom(0U, 1U) != 0U)
        {
            random3 = (int)GenerateRandom((uint)(num1 + (num3 - num1 + 1) / 3 * 2), (uint)num3);
            random4 = (int)GenerateRandom((uint)(num2 + (num4 - num2 + 1) / 3 * 2), (uint)num4);
        }
        else
        {
            random3 = (int)GenerateRandom((uint)(num1 + (num3 - num1 + 1) / 3 * 2), (uint)(num3 - 1));
            random4 = (int)GenerateRandom((uint)(num2 + (num4 - num2 + 1) / 3 * 2), (uint)(num4 - 1));
        }

        SetValue(floor, address2, (byte)random1, (byte)random2, (byte)random3, (byte)random4);
        for (var index = 4; index < 20; ++index)
            _dungeonInfo[floor, address2 + index] = 0;
        fixed (byte* numPtr = &_dungeonInfo[(int)(IntPtr)floor, (int)(IntPtr)unchecked(address1 + 8U)])
        {
            *(int*)numPtr = (int)address2;
        }

        for (var index1 = random2; index1 <= random4; ++index1)
        for (var index2 = random1; index2 <= random3; ++index2)
            _dungeonInfo[floor, index2 + (index1 << 4) + 792] = 0;
        routineD(floor, address2);
        return true;
    }

    private bool routineD(int floor, uint address)
    {
        int num1 = _dungeonInfo[floor, address];
        if (num1 == 0 || _dungeonInfo[floor, address + 1U] == 0)
            return false;
        int num2 = _dungeonInfo[floor, address + 2U];
        if (num2 == 0 || _dungeonInfo[floor, address + 3U] == 0)
            return false;
        if (num2 - num1 + 1 < 5)
        {
            _dungeonInfo[floor, address + 12U] = (byte)GenerateRandom((uint)num1, (uint)num2);
            _dungeonInfo[floor, address + 13U] = _dungeonInfo[floor, address + 1U];
            _dungeonInfo[floor, address + 16U] =
                (byte)GenerateRandom(_dungeonInfo[floor, address], _dungeonInfo[floor, address + 2U]);
            _dungeonInfo[floor, address + 17U] = _dungeonInfo[floor, address + 3U];
            var index1 = (_dungeonInfo[floor, address + 13U] << 4) + 792 + _dungeonInfo[floor, address + 12U];
            _dungeonInfo[floor, index1] = 8;
            var index2 = (_dungeonInfo[floor, address + 17U] << 4) + 792 + _dungeonInfo[floor, address + 16U];
            _dungeonInfo[floor, index2] = 8;
        }
        else
        {
            var num3 = num1 + (num2 - num1 + 1) / 2 - 1;
            _dungeonInfo[floor, address + 12U] = (byte)GenerateRandom((uint)num1, (uint)num3);
            _dungeonInfo[floor, address + 13U] = _dungeonInfo[floor, address + 1U];
            _dungeonInfo[floor, address + 14U] =
                (byte)GenerateRandom((uint)(num3 + 1), _dungeonInfo[floor, address + 2U]);
            _dungeonInfo[floor, address + 15U] = _dungeonInfo[floor, address + 1U];
            _dungeonInfo[floor, address + 16U] = (byte)GenerateRandom(_dungeonInfo[floor, address], (uint)num3);
            _dungeonInfo[floor, address + 17U] = _dungeonInfo[floor, address + 3U];
            _dungeonInfo[floor, address + 18U] =
                (byte)GenerateRandom((uint)(num3 + 1), _dungeonInfo[floor, address + 2U]);
            _dungeonInfo[floor, address + 19U] = _dungeonInfo[floor, address + 3U];
            var index3 = (_dungeonInfo[floor, address + 13U] << 4) + 792 + _dungeonInfo[floor, address + 12U];
            _dungeonInfo[floor, index3] = 8;
            var index4 = (_dungeonInfo[floor, address + 15U] << 4) + 792 + _dungeonInfo[floor, address + 14U];
            _dungeonInfo[floor, index4] = 8;
            var index5 = (_dungeonInfo[floor, address + 17U] << 4) + 792 + _dungeonInfo[floor, address + 16U];
            _dungeonInfo[floor, index5] = 8;
            var index6 = (_dungeonInfo[floor, address + 19U] << 4) + 792 + _dungeonInfo[floor, address + 18U];
            _dungeonInfo[floor, index6] = 8;
        }

        if (_dungeonInfo[floor, address + 3U] - _dungeonInfo[floor, address + 1U] + 1 < 5)
        {
            _dungeonInfo[floor, address + 4U] = _dungeonInfo[floor, address];
            _dungeonInfo[floor, address + 5U] =
                (byte)GenerateRandom(_dungeonInfo[floor, address + 1U], _dungeonInfo[floor, address + 3U]);
            _dungeonInfo[floor, address + 8U] = _dungeonInfo[floor, address + 2U];
            _dungeonInfo[floor, address + 9U] =
                (byte)GenerateRandom(_dungeonInfo[floor, address + 1U], _dungeonInfo[floor, address + 3U]);
            var index7 = (_dungeonInfo[floor, address + 5U] << 4) + 792 + _dungeonInfo[floor, address + 4U];
            _dungeonInfo[floor, index7] = 8;
            var index8 = (_dungeonInfo[floor, address + 9U] << 4) + 792 + _dungeonInfo[floor, address + 8U];
            _dungeonInfo[floor, index8] = 8;
        }
        else
        {
            int num4 = _dungeonInfo[floor, address + 1U];
            var num5 = num4 + (_dungeonInfo[floor, address + 3U] + 1 - num4) / 2 - 1;
            _dungeonInfo[floor, address + 4U] = _dungeonInfo[floor, address];
            _dungeonInfo[floor, address + 5U] = (byte)GenerateRandom(_dungeonInfo[floor, address + 1U], (uint)num5);
            _dungeonInfo[floor, address + 6U] = _dungeonInfo[floor, address];
            _dungeonInfo[floor, address + 7U] =
                (byte)GenerateRandom((uint)(num5 + 1), _dungeonInfo[floor, address + 3U]);
            _dungeonInfo[floor, address + 8U] = _dungeonInfo[floor, address + 2U];
            _dungeonInfo[floor, address + 9U] = (byte)GenerateRandom(_dungeonInfo[floor, address + 1U], (uint)num5);
            _dungeonInfo[floor, address + 10U] = _dungeonInfo[floor, address + 2U];
            _dungeonInfo[floor, address + 11U] =
                (byte)GenerateRandom((uint)(num5 + 1), _dungeonInfo[floor, address + 3U]);
            var index9 = (_dungeonInfo[floor, address + 5U] << 4) + 792 + _dungeonInfo[floor, address + 4U];
            _dungeonInfo[floor, index9] = 8;
            var index10 = (_dungeonInfo[floor, address + 7U] << 4) + 792 + _dungeonInfo[floor, address + 6U];
            _dungeonInfo[floor, index10] = 8;
            var index11 = (_dungeonInfo[floor, address + 9U] << 4) + 792 + _dungeonInfo[floor, address + 8U];
            _dungeonInfo[floor, index11] = 8;
            var index12 = (_dungeonInfo[floor, address + 11U] << 4) + 792 + _dungeonInfo[floor, address + 10U];
            _dungeonInfo[floor, index12] = 8;
        }

        return true;
    }

    private unsafe bool routineE(int floor, uint address, uint value1, uint value2)
    {
        var num1 = _dungeonInfo[floor, address + 2U] + 1 - _dungeonInfo[floor, address];
        if (num1 < 7 || _dungeonInfo[floor, address + 5U] != 0)
            return false;
        var random = (int)GenerateRandom(0U, (uint)(num1 - 7));
        var num2 = _dungeonInfo[floor, address] + random + 3;
        for (int index = _dungeonInfo[floor, address + 1U]; index < _dungeonInfo[floor, address + 3U] + 1; ++index)
            _dungeonInfo[floor, (index << 4) + num2 + 792] = 3;
        SetValue(floor, value2, (byte)num2, _dungeonInfo[floor, address + 1U], (byte)num2,
            _dungeonInfo[floor, address + 3U]);
        SetValue(floor, value1, (byte)(num2 + 1), _dungeonInfo[floor, address + 1U], _dungeonInfo[floor, address + 2U],
            _dungeonInfo[floor, address + 3U]);
        _dungeonInfo[floor, value1 + 4U] = 0;
        _dungeonInfo[floor, value1 + 5U] = 0;
        _dungeonInfo[floor, address + 2U] = (byte)(num2 - 1);
        _dungeonInfo[floor, address + 5U] = 1;
        fixed (byte* numPtr = &_dungeonInfo[(int)(IntPtr)floor, (int)(IntPtr)value2])
        {
            *(int*)(numPtr + 4) = (int)address;
            *(int*)(numPtr + 8) = (int)value1;
        }

        _dungeonInfo[floor, value2 + 12U] = 2;
        return true;
    }

    private void routineF(int floor, uint address)
    {
        if (_dungeonInfo[floor, 21] >= 15)
            return;
        if (_dungeonInfo[floor, address + 5U] != 0)
        {
            if (!routineA(floor, address, (uint)(_dungeonInfo[floor, 21] * 12 + 24),
                    (uint)((_dungeonInfo[floor, 22] << 4) + 216)))
                return;
            routineB(floor, address);
        }
        else if (_dungeonInfo[floor, address + 4U] != 0)
        {
            if (!routineE(floor, address, (uint)(_dungeonInfo[floor, 21] * 12 + 24),
                    (uint)((_dungeonInfo[floor, 22] << 4) + 216)))
                return;
            routineB(floor, address);
        }
        else if (((int)GenerateRandom() & 1) != 0)
        {
            if (!routineE(floor, address, (uint)(_dungeonInfo[floor, 21] * 12 + 24),
                    (uint)((_dungeonInfo[floor, 22] << 4) + 216)))
                return;
            routineB(floor, address);
        }
        else
        {
            if (!routineA(floor, address, (uint)(_dungeonInfo[floor, 21] * 12 + 24),
                    (uint)((_dungeonInfo[floor, 22] << 4) + 216)))
                return;
            routineB(floor, address);
        }
    }

    private unsafe int routineG(int floor, uint address)
    {
        var address3 = (int)address;
        if (_dungeonInfo[floor, address3 + 12] == 1)
        {
            int address1;
            int address2;
            fixed (byte* numPtr = &_dungeonInfo[floor, 0])
            {
                address1 = (int)*(uint*)(numPtr + (int)*(uint*)(numPtr + address3 + 4) + 8);
                address2 = (int)*(uint*)(numPtr + (int)*(uint*)(numPtr + address3 + 8) + 8);
            }

            var num1 = GenerateRandom(0U, 7U) == 0U ? 1 : 0;
            routineH(floor, (uint)address1, 16U, (uint)address2, 12U, (uint)address3, (uint)num1);
            var num2 = GenerateRandom(0U, 7U) == 0U ? 1 : 0;
            routineH(floor, (uint)address1, 18U, (uint)address2, 12U, (uint)address3, (uint)num2);
            var num3 = GenerateRandom(0U, 7U) == 0U ? 1 : 0;
            routineH(floor, (uint)address1, 16U, (uint)address2, 14U, (uint)address3, (uint)num3);
            var num4 = GenerateRandom(0U, 7U) == 0U ? 1 : 0;
            routineH(floor, (uint)address1, 18U, (uint)address2, 14U, (uint)address3, (uint)num4);
        }
        else if (_dungeonInfo[floor, address3 + 12] == 2)
        {
            int address1;
            int address2;
            fixed (byte* numPtr = &_dungeonInfo[floor, 0])
            {
                address1 = (int)*(uint*)(numPtr + (int)*(uint*)(numPtr + address3 + 4) + 8);
                address2 = (int)*(uint*)(numPtr + (int)*(uint*)(numPtr + address3 + 8) + 8);
            }

            var num5 = GenerateRandom(0U, 7U) == 0U ? 1 : 0;
            routineH(floor, (uint)address1, 8U, (uint)address2, 4U, (uint)address3, (uint)num5);
            var num6 = GenerateRandom(0U, 7U) == 0U ? 1 : 0;
            routineH(floor, (uint)address1, 10U, (uint)address2, 4U, (uint)address3, (uint)num6);
            var num7 = GenerateRandom(0U, 7U) == 0U ? 1 : 0;
            routineH(floor, (uint)address1, 8U, (uint)address2, 6U, (uint)address3, (uint)num7);
            var num8 = GenerateRandom(0U, 7U) == 0U ? 1 : 0;
            routineH(floor, (uint)address1, 10U, (uint)address2, 6U, (uint)address3, (uint)num8);
        }

        return 1;
    }

    private bool routineH(
        int floor,
        uint address1,
        uint value1,
        uint address2,
        uint value2,
        uint address3,
        uint value3)
    {
        var index1 = (int)address3;
        int num1 = _dungeonInfo[floor, address1 + value1];
        int num2 = _dungeonInfo[floor, (uint)((int)address1 + (int)value1 + 1)];
        int num3 = _dungeonInfo[floor, address2 + value2];
        int num4 = _dungeonInfo[floor, (uint)((int)address2 + (int)value2 + 1)];
        if (num1 == 0 || num2 == 0 || num3 == 0 || num4 == 0)
            return false;
        if (_dungeonInfo[floor, address3 + 12U] == 1)
        {
            for (var index2 = num2 + 1; index2 < _dungeonInfo[floor, index1 + 1] + 1; ++index2)
                _dungeonInfo[floor, (index2 << 4) + 792 + num1] = 2;
            for (var index3 = num4 - 1; index3 > _dungeonInfo[floor, index1 + 1]; --index3)
                _dungeonInfo[floor, (index3 << 4) + 792 + num3] = 2;
            if (num1 < num3)
                for (var index4 = num1; index4 < num3 + 1; ++index4)
                    _dungeonInfo[floor, index4 + (_dungeonInfo[floor, index1 + 1] << 4) + 792] = 2;
            else if (num1 > num3)
                for (var index5 = num3; index5 < num1 + 1; ++index5)
                    _dungeonInfo[floor, index5 + (_dungeonInfo[floor, index1 + 1] << 4) + 792] = 2;
            if (value3 == 0U)
                return true;
            if (num1 < num3)
            {
                for (var index6 = num3 + 1; index6 < 16; ++index6)
                    switch (_dungeonInfo[floor, index6 + (_dungeonInfo[floor, index1 + 1] << 4) + 792])
                    {
                        case 1:
                        case 3:
                            continue;
                        default:
                            for (var index7 = num3 + 1; index7 < index6; ++index7)
                                _dungeonInfo[floor, index7 + (_dungeonInfo[floor, index1 + 1] << 4) + 792] = 2;
                            goto label_27;
                    }

                label_27:
                for (var index8 = num1 - 1; index8 >= 0; --index8)
                    switch (_dungeonInfo[floor, index8 + (_dungeonInfo[floor, index1 + 1] << 4) + 792])
                    {
                        case 1:
                        case 3:
                            continue;
                        default:
                            for (var index9 = num1 - 1; index9 > index8; --index9)
                                _dungeonInfo[floor, index9 + (_dungeonInfo[floor, index1 + 1] << 4) + 792] = 2;
                            goto label_95;
                    }
            }
            else if (num1 >= num3)
            {
                for (var index10 = num1 + 1; index10 < 16; ++index10)
                    switch (_dungeonInfo[floor, index10 + (_dungeonInfo[floor, index1 + 1] << 4) + 792])
                    {
                        case 1:
                        case 3:
                            continue;
                        default:
                            for (var index11 = num1 + 1; index11 < index10; ++index11)
                                _dungeonInfo[floor, index11 + (_dungeonInfo[floor, index1 + 1] << 4) + 792] = 2;
                            goto label_42;
                    }

                label_42:
                for (var index12 = num3 - 1; index12 >= 0; --index12)
                    switch (_dungeonInfo[floor, index12 + (_dungeonInfo[floor, index1 + 1] << 4) + 792])
                    {
                        case 1:
                        case 3:
                            continue;
                        default:
                            for (var index13 = num3 - 1; index13 > index12; --index13)
                                _dungeonInfo[floor, index13 + (_dungeonInfo[floor, index1 + 1] << 4) + 792] = 2;
                            goto label_95;
                    }
            }
        }
        else if (_dungeonInfo[floor, address3 + 12U] == 2)
        {
            for (var index14 = num1 + 1; index14 < _dungeonInfo[floor, index1] + 1; ++index14)
                _dungeonInfo[floor, index14 + (num2 << 4) + 792] = 2;
            for (var index15 = num3 - 1; index15 > _dungeonInfo[floor, index1]; --index15)
                _dungeonInfo[floor, index15 + (num4 << 4) + 792] = 2;
            if (num2 < num4)
                for (var index16 = num2; index16 < num4 + 1; ++index16)
                    _dungeonInfo[floor, (index16 << 4) + 792 + _dungeonInfo[floor, index1]] = 2;
            else if (num2 > num4)
                for (var index17 = num4; index17 < num2 + 1; ++index17)
                    _dungeonInfo[floor, (index17 << 4) + 792 + _dungeonInfo[floor, index1]] = 2;
            if (value3 == 0U)
                return true;
            if (num2 < num4)
            {
                for (var index18 = num4 + 1; index18 < 16; ++index18)
                    switch (_dungeonInfo[floor, (index18 << 4) + 792 + _dungeonInfo[floor, index1]])
                    {
                        case 1:
                        case 3:
                            continue;
                        default:
                            for (var index19 = num4 + 1; index19 < index18; ++index19)
                                _dungeonInfo[floor, (index19 << 4) + 792 + _dungeonInfo[floor, index1]] = 2;
                            goto label_74;
                    }

                label_74:
                for (var index20 = num2 - 1; index20 >= 0; --index20)
                    switch (_dungeonInfo[floor, (index20 << 4) + 792 + _dungeonInfo[floor, index1]])
                    {
                        case 1:
                        case 3:
                            continue;
                        default:
                            for (var index21 = num2 - 1; index21 > index20; --index21)
                                _dungeonInfo[floor, (index21 << 4) + 792 + _dungeonInfo[floor, index1]] = 2;
                            continue;
                    }
            }
            else
            {
                for (var index22 = num2 >= num4 ? num2 + 1 : num2; index22 < 16; ++index22)
                    switch (_dungeonInfo[floor, (index22 << 4) + 792 + _dungeonInfo[floor, index1]])
                    {
                        case 1:
                        case 3:
                            continue;
                        default:
                            for (var index23 = num2 + 1; index23 < index22; ++index23)
                                _dungeonInfo[floor, (index23 << 4) + 792 + _dungeonInfo[floor, index1]] = 2;
                            goto label_88;
                    }

                label_88:
                for (var index24 = num4 - 1; index24 >= 0; --index24)
                    switch (_dungeonInfo[floor, (index24 << 4) + 792 + _dungeonInfo[floor, index1]])
                    {
                        case 1:
                        case 3:
                            continue;
                        default:
                            for (var index25 = num4 - 1; index25 > index24; --index25)
                                _dungeonInfo[floor, (index25 << 4) + 792 + _dungeonInfo[floor, index1]] = 2;
                            goto label_95;
                    }
            }
        }

        label_95:
        return true;
    }

    private uint routineI(int floor, uint value1, uint value2, uint value3)
    {
        int num1 = _dungeonInfo[floor, (uint)((int)value1 + ((int)value2 << 4) + 792)];
        switch (num1)
        {
            case 1:
            case 3:
                return byte.MaxValue;
            default:
                int num2 = _dungeonInfo[floor, (uint)((int)value1 + (((int)value2 - 1) << 4) + 792)];
                int num3 = _dungeonInfo[floor, (uint)((int)value1 + (((int)value2 - 1) << 4) + 792 - 1)];
                int num4 = _dungeonInfo[floor, (uint)((int)value1 + (((int)value2 - 1) << 4) + 792 + 1)];
                int num5 = _dungeonInfo[floor, (uint)((int)value1 + ((int)value2 << 4) + 792 + 1)];
                int num6 = _dungeonInfo[floor, (uint)((int)value1 + (((int)value2 + 1) << 4) + 792 + 1)];
                int num7 = _dungeonInfo[floor, (uint)((int)value1 + (((int)value2 + 1) << 4) + 792)];
                int num8 = _dungeonInfo[floor, (uint)((int)value1 + (((int)value2 + 1) << 4) + 792 - 1)];
                int num9 = _dungeonInfo[floor, (uint)((int)value1 + ((int)value2 << 4) + 792 - 1)];
                if (num1 != 0 && num1 != 2 && ((num1 + 252) & byte.MaxValue) > 4)
                    return value3;
                if (num3 == 1 || num3 == 3)
                    value3 |= 128U;
                else
                    value3 &= (uint)sbyte.MaxValue;
                if (num4 == 1 || num4 == 3)
                    value3 |= 32U;
                else
                    value3 &= 223U;
                if (num6 == 1 || num6 == 3)
                    value3 |= 8U;
                else
                    value3 &= 247U;
                if (num8 == 1 || num8 == 3)
                    value3 |= 2U;
                else
                    value3 &= 253U;
                if (num2 == 1 || num2 == 3)
                    value3 |= 224U;
                else
                    value3 &= 191U;
                if (num5 == 1 || num5 == 3)
                    value3 |= 56U;
                else
                    value3 &= 239U;
                if (num7 == 1 || num7 == 3)
                    value3 |= 14U;
                else
                    value3 &= 251U;
                if (num9 == 1 || num9 == 3)
                    value3 |= 131U;
                else
                    value3 &= 254U;
                return value3;
        }
    }

    private void routineJ(int floor)
    {
        var num1 = 0;
        var num2 = 0;
        var random1 = 0;
        var random2 = 0;
        while (true)
        {
            var random3 = (int)GenerateRandom(0U, _dungeonInfo[floor, 23] - 1U);
            var index1 = random3 * 20 + 472;
            var random4 = (int)GenerateRandom(_dungeonInfo[floor, index1], _dungeonInfo[floor, index1 + 2]);
            var random5 = (int)GenerateRandom(_dungeonInfo[floor, index1 + 1], _dungeonInfo[floor, index1 + 3]);
            if (num2 < 100)
            {
                int num3 = _dungeonInfo[floor, ((random5 - 1) << 4) + random4 + 792];
                int num4 = _dungeonInfo[floor, ((random5 + 1) << 4) + random4 + 792];
                int num5 = _dungeonInfo[floor, (random5 << 4) + 792 + random4 - 1];
                int num6 = _dungeonInfo[floor, (random5 << 4) + 792 + random4 + 1];
                var num7 = num3 == 1 || num3 == 3 ? 1 : 0;
                var num8 = num4 == 1 || num4 == 3 ? 1 : 0;
                var num9 = num5 == 1 || num5 == 3 ? 1 : 0;
                var num10 = num6 == 1 || num6 == 3 ? 1 : 0;
                if (num7 != 0 && num8 != 0 && num9 != 0 && num10 != 0)
                {
                    ++num2;
                    continue;
                }

                if (num7 != 0 && num10 != 0)
                {
                    ++num2;
                    continue;
                }

                if (num7 != 0 && num9 != 0)
                {
                    ++num2;
                    continue;
                }

                if (num8 != 0 && num10 != 0)
                {
                    ++num2;
                    continue;
                }

                if (num8 != 0 && num9 != 0)
                {
                    ++num2;
                    continue;
                }

                switch ((int)routineI(floor, (uint)random4, (uint)random5, 0U) & byte.MaxValue)
                {
                    case 46:
                    case 58:
                    case 139:
                    case 142:
                    case 163:
                    case 171:
                    case 174:
                    case 184:
                    case 186:
                    case 226:
                    case 232:
                    case 234:
                        ++num2;
                        continue;
                }
            }

            _dungeonInfo[floor, random4 + (random5 << 4) + 792] = 4;
            _dungeonInfo[floor, 4] = (byte)random4;
            _dungeonInfo[floor, 5] = (byte)random5;
            var num11 = random4;
            var num12 = random5;
            var num13 = 0;
            do
            {
                var random6 = (int)GenerateRandom(0U, _dungeonInfo[floor, 23] - 1U);
                if (random6 == (random3 & byte.MaxValue) && (num1 & byte.MaxValue) < 25)
                {
                    ++num1;
                }
                else
                {
                    var index2 = random6 * 20 + 472;
                    random1 = (int)GenerateRandom(_dungeonInfo[floor, index2], _dungeonInfo[floor, index2 + 2]);
                    num13 = random6;
                    random2 = (int)GenerateRandom(_dungeonInfo[floor, index2 + 1], _dungeonInfo[floor, index2 + 3]);
                }
            } while ((random3 & byte.MaxValue) == num13 && random1 == num11 && random2 == num12);

            int num14 = _dungeonInfo[floor, random1 + ((random2 - 1) << 4) + 792];
            int num15 = _dungeonInfo[floor, random1 + ((random2 + 1) << 4) + 792];
            int num16 = _dungeonInfo[floor, random1 + (random2 << 4) + 792 - 1];
            int num17 = _dungeonInfo[floor, random1 + (random2 << 4) + 792 + 1];
            var num18 = num14 == 1 || num14 == 3 ? 1 : 0;
            var num19 = num15 == 1 || num15 == 3 ? 1 : 0;
            var num20 = num16 == 1 || num16 == 3 ? 1 : 0;
            var num21 = num17 == 1 || num17 == 3 ? 1 : 0;
            if (num18 != 0 && num19 != 0 && num20 != 0 && num21 != 0)
                ++num2;
            else if (num18 != 0 && num21 != 0)
                ++num2;
            else if (num18 != 0 && num20 != 0)
                ++num2;
            else if (num19 != 0 && num21 != 0)
                ++num2;
            else if (num19 != 0 && num20 != 0)
                ++num2;
            else
                break;
        }

        _dungeonInfo[floor, random1 + (random2 << 4) + 792] = 5;
        _dungeonInfo[floor, 6] = (byte)random1;
        _dungeonInfo[floor, 7] = (byte)random2;
    }

    private int routineK(int floor)
    {
        var random1 = (int)GenerateRandom(1U, 3U);
        _dungeonInfo[floor, 8] = (byte)random1;
        var num1 = 0;
        var num2 = 0;
        do
        {
            var index = (int)GenerateRandom(0U, _dungeonInfo[floor, 23] - 1U) * 20 + 472;
            var random2 = (int)GenerateRandom(_dungeonInfo[floor, index], _dungeonInfo[floor, index + 2]);
            var random3 = (int)GenerateRandom(_dungeonInfo[floor, index + 1], _dungeonInfo[floor, index + 3]);
            int num3 = _dungeonInfo[floor, random2 + ((random3 & byte.MaxValue) << 4) + 792];
            if (num1 < 100 && (_dungeonInfo[floor, 0] == 3 || _dungeonInfo[floor, 0] == 1))
            {
                ++num1;
            }
            else if (num3 == 6 || num3 == 4 || num3 == 5)
            {
                ++num1;
            }
            else
            {
                _dungeonInfo[floor, random2 + ((random3 & byte.MaxValue) << 4) + 792] = 6;
                _dungeonInfo[floor, num2 * 2 + 13] = (byte)random2;
                _dungeonInfo[floor, num2 * 2 + 14] = (byte)random3;
                ++num2;
            }
        } while (num2 < (random1 & byte.MaxValue));

        return 1;
    }

    private unsafe void CreateDungeonDetail(bool createSearchData)
    {
        for (var index1 = 1; index1 < _details[1] + 1; ++index1)
        {
            var floor = index1 - 1;
            _dungeonInfo[floor, 0] = (byte)index1;
            _dungeonInfo[floor, 8] = 0;
            _seed = MapSeed + (uint)index1;
            if (!createSearchData || index1 > 2)
            {
                routine1(floor, 792U, 1U, 256U);
                _dungeonInfo[floor, 21] = 1;
                _dungeonInfo[floor, 22] = 0;
                _dungeonInfo[floor, 23] = 0;
                _dungeonInfo[floor, 1] = 0;
                SetValue(floor, 24U, 1, 1, (byte)(_dungeonInfo[floor, 2] - 2U), (byte)(_dungeonInfo[floor, 3] - 2U));
                _dungeonInfo[floor, 28] = 0;
                _dungeonInfo[floor, 29] = 0;
                routineF(floor, 24U);
                for (var index2 = 0; index2 < _dungeonInfo[floor, 21]; ++index2)
                    if (routineC(floor, (uint)(index2 * 12 + 24), (uint)(_dungeonInfo[floor, 23] * 20 + 472)))
                        ++_dungeonInfo[floor, 23];
                for (var index3 = 0; index3 < _dungeonInfo[floor, 21]; ++index3)
                    GenerateFloorMap(floor, (uint)(index3 * 12 + 24));
                for (var index4 = 0; index4 < _dungeonInfo[floor, 22]; ++index4)
                    routineG(floor, (uint)((index4 << 4) + 216));
                for (var index5 = 0; index5 < _dungeonInfo[floor, 2]; ++index5)
                {
                    _dungeonInfo[floor, index5 + 792] = 1;
                    _dungeonInfo[floor, ((_dungeonInfo[floor, 3] - 1) << 4) + index5 + 792] = 1;
                }

                for (var index6 = 0; index6 < _dungeonInfo[floor, 3]; ++index6)
                {
                    _dungeonInfo[floor, (index6 << 4) + 792] = 1;
                    _dungeonInfo[floor, (index6 << 4) + 792 + _dungeonInfo[floor, 2] - 1] = 1;
                }

                routineJ(floor);
                if (_dungeonInfo[floor, 0] <= 2)
                    _dungeonInfo[floor, 8] = 0;
                else
                    routineK(floor);
                if (!createSearchData)
                {
                    _dungeonInfo[floor, 1306] = 0;
                    _dungeonInfo[floor, 1307] = 0;
                    for (var index7 = 1; index7 < 15; ++index7)
                    for (var index8 = 1; index8 < 15; ++index8)
                        switch (_dungeonInfo[floor, index8 + (index7 << 4) + 792])
                        {
                            case 1:
                            case 3:
                                continue;
                            default:
                                ++_dungeonInfo[floor, 1306];
                                switch (_dungeonInfo[floor, index8 + ((index7 - 1) << 4) + 792])
                                {
                                    case 1:
                                    case 3:
                                        switch (_dungeonInfo[floor, (index7 << 4) + 792 + index8 - 1])
                                        {
                                            case 1:
                                            case 3:
                                                continue;
                                            default:
                                                ++_dungeonInfo[floor, 1307];
                                                continue;
                                        }
                                    default:
                                        ++_dungeonInfo[floor, 1307];
                                        goto case 1;
                                }
                        }

                    _dungeonInfo[floor, 1304] = (byte)(_details[2] + (uint)((index1 - 1) / 4));
                    var index9 = (TreasureMapDataTable.TableJ[_details[3] - 1] * 12 + _dungeonInfo[floor, 1304] - 1) *
                                 18;
                    _dungeonInfo[floor, 1305] = TreasureMapDataTable.TableK[index9];
                    _dungeonInfo[floor, 1312] = 0;
                    fixed (byte* numPtr1 = &_dungeonInfo[floor, 0])
                    {
                        *(int*)(numPtr1 + 1308) = (numPtr1[1306] << 4) + 4896;
                        var num1 = 4128 - ((numPtr1[1306] << 4) + numPtr1[1307] * 8);
                        if (num1 < 0)
                        {
                            var numPtr2 = numPtr1 + 1308;
                            *(int*)numPtr2 = (int)*(uint*)numPtr2 + (numPtr1[1307] + (num1 + 7) / 8 - 1) * 8;
                        }
                        else
                        {
                            var numPtr3 = numPtr1 + 1308;
                            *(int*)numPtr3 = (int)*(uint*)numPtr3 + numPtr1[1307] * 8;
                        }

                        var numPtr4 = numPtr1 + 1308;
                        *(int*)numPtr4 = (int)*(uint*)numPtr4 + 4;
                        var numPtr5 = numPtr1 + 1308;
                        *(int*)numPtr5 = (int)*(uint*)numPtr5 + numPtr1[1307] * 8;
                        var numPtr6 = numPtr1 + 1308;
                        *(int*)numPtr6 = (int)*(uint*)numPtr6 + numPtr1[1305] * 20;
                        for (var index10 = 0; index10 < numPtr1[1305]; ++index10)
                            fixed (byte* numPtr7 = &TreasureMapDataTable.TableK[0])
                            {
                                int num2 = *(ushort*)(numPtr7 + (index9 + index10 * 2 + 2));
                                fixed (byte* numPtr8 = &TreasureMapDataTable.TableM[num2 * 2])
                                {
                                    var numPtr9 = numPtr1 + 1308;
                                    *(int*)numPtr9 = (int)*(uint*)numPtr9 +
                                                     TreasureMapDataTable.TableL[*(ushort*)numPtr8] + 8;
                                }
                            }

                        var num3 = 11216;
                        var num4 = num3 < *(uint*)(numPtr1 + 1308) ? 0 : (int)(num3 - *(uint*)(numPtr1 + 1308)) / 20;
                        numPtr1[1313] = 0;
                        var num5 = 0;
                        for (var index11 = 0; index11 < numPtr1[1305]; ++index11)
                            fixed (byte* numPtr10 = &TreasureMapDataTable.TableK[0])
                            {
                                int num6 = *(ushort*)(numPtr10 + (index9 + index11 * 2 + 2));
                                switch (num6)
                                {
                                    case 38:
                                    case 39:
                                    case 40:
                                        continue;
                                    default:
                                        if (index11 >= num4)
                                        {
                                            ++num5;
                                            continue;
                                        }

                                        *(short*)(numPtr1 + (numPtr1[1313] * 2 + 1314)) = (short)(ushort)num6;
                                        var numPtr11 = numPtr1 + 1313;
                                        *numPtr11 = (byte)(*numPtr11 + 1U);
                                        continue;
                                }
                            }

                        if (numPtr1[1313] == 0)
                            numPtr1[1312] = (byte)(numPtr1[1312] | 1U);
                        else if (numPtr1[1313] == 1)
                            numPtr1[1312] = (byte)(numPtr1[1312] | 2U);
                        else if (num5 > 0)
                            numPtr1[1312] = (byte)(numPtr1[1312] | 4U);
                        if (numPtr1[1313] == 1)
                        {
                            _details2[14] = numPtr1[1314];
                            _details2[15] = numPtr1[1315];
                        }
                        else
                        {
                            _details2[12] = (byte)(_details2[12] | (uint)numPtr1[1312]);
                        }
                    }
                }
            }
        }

        for (var index12 = 2; index12 < _details[1]; ++index12)
        {
            _seed = (uint)(MapSeed + index12 + 1);
            for (var index13 = 0; index13 < _dungeonInfo[index12, 8] << 1; ++index13)
            {
                var random = (int)GenerateRandom();
            }

            var num = _details[2] + index12 / 4;
            for (var index14 = 0; index14 < _dungeonInfo[index12, 8]; ++index14)
            {
                _dungeonInfo[index12, index14 + 9] = (byte)GetItemRank(TreasureMapDataTable.TableN[(num - 1) * 4 + 1],
                    TreasureMapDataTable.TableN[(num - 1) * 4 + 2]);
                ++_details2[_dungeonInfo[index12, index14 + 9] - 1];
            }

            if (_dungeonInfo[index12, 8] > 0)
                for (var index15 = 0; index15 < _dungeonInfo[index12, 8]; ++index15)
                {
                    var treasureBoxInfo = new TreasureBoxInfo(index15, _dungeonInfo[index12, 9 + index15],
                        _dungeonInfo[index12, index15 * 2 + 13], _dungeonInfo[index12, index15 * 2 + 14]);
                    var index16 = 0;
                    while (index16 < TreasureBoxInfoList[index12].Count &&
                           treasureBoxInfo.Rank <= TreasureBoxInfoList[index12][index16].Rank)
                        ++index16;
                    TreasureBoxInfoList[index12].Insert(index16, treasureBoxInfo);
                }
        }
    }

    public string GetTreasureBoxItem(int floor, int boxIndex, int second)
    {
        _seed = (uint)(_dungeonInfo[floor, 0] + MapSeed + second);
        for (var index1 = 0; index1 < _dungeonInfo[floor, 8]; ++index1)
        {
            var num1 = (int)routineRandom(100U);
            if (index1 == boxIndex)
            {
                int index2 = _dungeonInfo[floor, index1 + 9];
                int num2 = TreasureMapDataTable.TableO[index2 - 1];
                int num3 = TreasureMapDataTable.TableO[index2];
                var num4 = 0;
                for (var index3 = num2; index3 < num3; ++index3)
                {
                    num4 += TreasureMapDataTable.TableP[index3];
                    if (num1 < num4)
                        return TreasureMapDataTable.TableR[TreasureMapDataTable.TableQ[index3]];
                }
            }
        }

        return null;
    }

    private uint routineRandom(uint value)
    {
        return (uint)(((int)GenerateRandom() - 1f) * (double)value / short.MaxValue);
    }

    public void CalculateDetail()
    {
        CalculateDetail(false, false);
    }

    public void CalculateDetail(bool floorDetail)
    {
        CalculateDetail(floorDetail, false);
    }

    public void CalculateDetail(bool floorDetail, bool createSearchData)
    {
        IsValidSeed = false;
        _validPlaceList.Clear();
        _lowRankValidPlaceList.Clear();
        _middleRankValidPlaceList.Clear();
        _highRankValidPlaceList.Clear();
        _validRankList.Clear();
        for (var index = 0; index < 16; ++index)
            TreasureBoxInfoList[index].Clear();
        Array.Clear(_details, 0, 20);
        Array.Clear(_details2, 0, 20);
        if (MapRank < 2 || MapRank > 248)
            return;
        _seed = MapSeed;
        for (var index = 0; index < 12; ++index)
        {
            var random = (int)GenerateRandom(100U);
        }

        _details[3] = (byte)Seek1(TreasureMapDataTable.TableA, 5);
        _details[1] = (byte)Seek2(TreasureMapDataTable.TableB, MapRank, 9);
        _details[2] = (byte)Seek2(TreasureMapDataTable.TableC, MapRank, 8);
        _details[0] = (byte)Seek4(TreasureMapDataTable.TableD, TreasureMapDataTable.TableE, 9);
        for (var index = 0; index < 12; ++index)
            _details[index + 1 + 7] = (byte)Seek3(TreasureMapDataTable.TableF[index * 4 + 1],
                TreasureMapDataTable.TableF[index * 4 + 2]);
        _details[5] = (byte)Seek2(TreasureMapDataTable.TableH, _details[2], 5);
        _details[6] = (byte)Seek2(TreasureMapDataTable.TableI, _details[0], 4);
        _details[7] = (byte)Seek2(TreasureMapDataTable.TableG, _details[1], 8);
        var num1 = (_details[0] + _details[1] + _details[2] - 4) * 3 + ((int)GenerateRandom(11U) - 5);
        if (num1 < 1)
            num1 = 1;
        if (num1 > 99)
            num1 = 99;
        _details[4] = (byte)num1;
        MapName3Index = TreasureMapDataTable.TreasureMapName3_IndexTable[(_details[7] - 1) * 5 + _details[3] - 1];
        if (!createSearchData)
        {
            var reverseSeedTable = TreasureMapDataTable.GetReverseSeedTable(MapSeed);
            if (reverseSeedTable != null)
            {
                IsValidSeed = true;
                foreach (uint num2 in reverseSeedTable)
                {
                    _seed = num2;
                    var random1 = GenerateRandom();
                    foreach (var num3 in _candidateRank)
                    {
                        var num4 = (int)(num3 + random1 % (num3 / 10 * 2 + 1) - num3 / 10);
                        if (num4 > 248)
                            num4 = 248;
                        if (!_validRankList.Contains((byte)num4))
                            _validRankList.Add((byte)num4);
                    }

                    GenerateRandom();
                    var random2 = GenerateRandom();
                    var num5 = MapRank > 50
                        ? MapRank > 80 ? random2 % 150U + 1U : random2 % 131U + 1U
                        : random2 % 47U + 1U;
                    if (!_validPlaceList.Contains((byte)num5))
                        _validPlaceList.Add((byte)num5);
                    var num6 = random2 % 47U + 1U;
                    if (!_lowRankValidPlaceList.Contains((byte)num6))
                        _lowRankValidPlaceList.Add((byte)num6);
                    var num7 = random2 % 131U + 1U;
                    if (!_middleRankValidPlaceList.Contains((byte)num7))
                        _middleRankValidPlaceList.Add((byte)num7);
                    var num8 = random2 % 150U + 1U;
                    if (!_highRankValidPlaceList.Contains((byte)num8))
                        _highRankValidPlaceList.Add((byte)num8);
                }

                if (MapRank == 2 && MapSeed == 50)
                {
                    _validPlaceList.Add(5);
                    _lowRankValidPlaceList.Add(5);
                }
            }
            else
            {
                IsValidSeed = false;
                _validPlaceList.Clear();
                _validRankList.Clear();
            }
        }

        if (!floorDetail)
            return;
        for (var index = 1; index < _details[1] + 1; ++index)
        {
            var num9 = index > 4
                ? index > 8 ? index > 12 ? 16 : (MapSeed + index) % 3 + 14 : (MapSeed + index) % 4 + 12
                : (MapSeed + index) % 5 + 10;
            _dungeonInfo[index - 1, 2] = (byte)num9;
            _dungeonInfo[index - 1, 3] = (byte)num9;
        }

        CreateDungeonDetail(createSearchData);
    }

    public int GetTreasureBoxCount(int rank)
    {
        if (rank == 0)
        {
            var treasureBoxCount = 0;
            for (var index = 0; index < 10; ++index)
                treasureBoxCount += _details2[index];
            return treasureBoxCount;
        }

        return rank > 0 && rank <= 10 ? _details2[rank - 1] : 0;
    }

    public int GetTreasureBoxRankPerFloor(int floor, int index)
    {
        return floor < FloorCount && index < GetTreasureBoxCountPerFloor(floor) ? _dungeonInfo[floor, 9 + index] : 0;
    }

    public void GetTreasureBoxPosPerFloor(int floor, int index, out int x, out int y)
    {
        x = -1;
        y = -1;
        if (floor >= FloorCount || index >= GetTreasureBoxCountPerFloor(floor))
            return;
        x = _dungeonInfo[floor, index * 2 + 13];
        y = _dungeonInfo[floor, index * 2 + 14];
    }

    public int GetTreasureBoxCountPerFloor(int floor)
    {
        return floor < FloorCount ? _dungeonInfo[floor, 8] : 0;
    }

    public int GetFloorWidth(int floor)
    {
        return floor < FloorCount ? _dungeonInfo[floor, 2] : 0;
    }

    public int GetFloorHeight(int floor)
    {
        return floor < FloorCount ? _dungeonInfo[floor, 3] : 0;
    }

    public byte[,] GetFloorMap(int floor)
    {
        if (floor >= FloorCount)
            return null;
        var floorHeight = GetFloorHeight(floor);
        var floorWidth = GetFloorWidth(floor);
        var destinationArray = new byte[floorWidth, floorHeight];
        var sourceIndex = floor * 1336 + 792;
        var destinationIndex = 0;
        for (var index = 0; index < floorHeight; ++index)
        {
            Array.Copy(_dungeonInfo, sourceIndex, destinationArray, destinationIndex, floorWidth);
            sourceIndex += 16;
            destinationIndex += floorWidth;
        }

        return destinationArray;
    }

    public bool IsUpStep(int floor, int x, int y)
    {
        return floor < FloorCount && x < GetFloorWidth(floor) && y < GetFloorHeight(floor) &&
               _dungeonInfo[floor, 4] == x && _dungeonInfo[floor, 5] == y;
    }

    public int IsTreasureBoxRank(int floor, int x, int y)
    {
        if (floor < FloorCount && x < GetFloorWidth(floor) && y < GetFloorHeight(floor))
            for (var index = 0; index < GetTreasureBoxCountPerFloor(floor); ++index)
                if (_dungeonInfo[floor, index * 2 + 13] == x && _dungeonInfo[floor, index * 2 + 14] == y)
                    return _dungeonInfo[floor, index + 9];
        return 0;
    }

    public int GetTreasureBoxIndex(int floor, int x, int y)
    {
        if (floor < FloorCount && x < GetFloorWidth(floor) && y < GetFloorHeight(floor))
            for (var treasureBoxIndex = 0; treasureBoxIndex < GetTreasureBoxCountPerFloor(floor); ++treasureBoxIndex)
                if (_dungeonInfo[floor, treasureBoxIndex * 2 + 13] == x &&
                    _dungeonInfo[floor, treasureBoxIndex * 2 + 14] == y)
                    return treasureBoxIndex;
        return -1;
    }
}