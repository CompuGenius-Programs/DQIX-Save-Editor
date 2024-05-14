// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.WifiShopGoods
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;

namespace DQ9_Cheat.DataManager;

internal class WifiShopGoods
{
    private const int WifiShopGoodsOffset = 27844;
    private const int DataSize = 40;
    private readonly int _index;
    private readonly DataValue<uint> _itemCountPrice;
    private readonly DataValue<ushort> _itemValue;

    public WifiShopGoods(SaveData owner, int index)
    {
        _index = index;
        var offset = (uint)(27844 + 40 * _index);
        _itemValue = new DataValue<ushort>(owner, offset, null, 0, ushort.MaxValue);
        _itemCountPrice = new DataValue<uint>(owner, 4U + offset, null, 0U, uint.MaxValue);
    }

    public ItemDataBase Item
    {
        get => ItemDataList.GetItem(_itemValue.Value);
        set => _itemValue.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public byte ItemCount
    {
        get => (byte)(_itemCountPrice.Value & (uint)sbyte.MaxValue);
        set => _itemCountPrice.Value = (uint)(((int)_itemCountPrice.Value & sbyte.MinValue) | (value & sbyte.MaxValue));
    }

    public uint ItemPrice
    {
        get => (_itemCountPrice.Value & 4294967168U) >> 7;
        set => _itemCountPrice.Value =
            (uint)(((int)_itemCountPrice.Value & sbyte.MaxValue) | (((int)value << 7) & sbyte.MinValue));
    }
}