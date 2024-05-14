// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.ItemDataBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

#nullable disable
namespace DQ9_Cheat.GameData
{
  public class ItemDataBase
  {
    private int _dataIndex;
    private int _alchemyIndex;
    private bool _alchemyRate;
    private ItemType _itemType;
    private WeaponType _weaponType;
    private string _name;
    private ushort _value;

    public ItemDataBase(
      int dataIndex,
      int alchemyIndex,
      bool alchemyRate,
      ItemType itemType,
      ushort itemValue,
      string name)
    {
      this._dataIndex = dataIndex;
      this._alchemyIndex = alchemyIndex;
      this._alchemyRate = alchemyRate;
      this._itemType = itemType;
      this._name = name;
      this._value = itemValue;
    }

    public ItemDataBase(
      int dataIndex,
      int alchemyIndex,
      bool alchemyRate,
      ItemType itemType,
      WeaponType weapongType,
      ushort itemValue,
      string name)
    {
      this._dataIndex = dataIndex;
      this._alchemyIndex = alchemyIndex;
      this._alchemyRate = alchemyRate;
      this._itemType = itemType;
      this._weaponType = weapongType;
      this._name = name;
      this._value = itemValue;
    }

    public int DataIndex => this._dataIndex;

    public int AlchemyIndex => this._alchemyIndex;

    public bool AlchemyRate => this._alchemyRate;

    public ItemType ItemType => this._itemType;

    public WeaponType WeaponType => this._weaponType;

    public string Name => this._name;

    public ushort Value => this._value;

    public override string ToString() => this._name;
  }
}
