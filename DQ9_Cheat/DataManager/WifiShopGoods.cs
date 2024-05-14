// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.WifiShopGoods
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class WifiShopGoods
  {
    private const int WifiShopGoodsOffset = 27844;
    private const int DataSize = 40;
    private int _index;
    private DataValue<ushort> _itemValue;
    private DataValue<uint> _itemCountPrice;

    public WifiShopGoods(SaveData owner, int index)
    {
      this._index = index;
      uint offset = (uint) (27844 + 40 * this._index);
      this._itemValue = new DataValue<ushort>(owner, offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._itemCountPrice = new DataValue<uint>(owner, 4U + offset, (Control) null, 0U, uint.MaxValue);
    }

    public ItemDataBase Item
    {
      get => ItemDataList.GetItem(this._itemValue.Value);
      set => this._itemValue.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public byte ItemCount
    {
      get => (byte) (this._itemCountPrice.Value & (uint) sbyte.MaxValue);
      set
      {
        this._itemCountPrice.Value = (uint) ((int) this._itemCountPrice.Value & (int) sbyte.MinValue | (int) value & (int) sbyte.MaxValue);
      }
    }

    public uint ItemPrice
    {
      get => (this._itemCountPrice.Value & 4294967168U) >> 7;
      set
      {
        this._itemCountPrice.Value = (uint) ((int) this._itemCountPrice.Value & (int) sbyte.MaxValue | (int) value << 7 & (int) sbyte.MinValue);
      }
    }
  }
}
