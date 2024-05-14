// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.ItemDataBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

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
      _dataIndex = dataIndex;
      _alchemyIndex = alchemyIndex;
      _alchemyRate = alchemyRate;
      _itemType = itemType;
      _name = name;
      _value = itemValue;
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
      _dataIndex = dataIndex;
      _alchemyIndex = alchemyIndex;
      _alchemyRate = alchemyRate;
      _itemType = itemType;
      _weaponType = weapongType;
      _name = name;
      _value = itemValue;
    }

    public int DataIndex => _dataIndex;

    public int AlchemyIndex => _alchemyIndex;

    public bool AlchemyRate => _alchemyRate;

    public ItemType ItemType => _itemType;

    public WeaponType WeaponType => _weaponType;

    public string Name => _name;

    public ushort Value => _value;

    public override string ToString() => _name;
  }
}
