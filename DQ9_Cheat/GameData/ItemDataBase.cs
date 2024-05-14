// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.GameData.ItemDataBase
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.GameData;

public class ItemDataBase
{
    public ItemDataBase(
        int dataIndex,
        int alchemyIndex,
        bool alchemyRate,
        ItemType itemType,
        ushort itemValue,
        string name)
    {
        DataIndex = dataIndex;
        AlchemyIndex = alchemyIndex;
        AlchemyRate = alchemyRate;
        ItemType = itemType;
        Name = name;
        Value = itemValue;
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
        DataIndex = dataIndex;
        AlchemyIndex = alchemyIndex;
        AlchemyRate = alchemyRate;
        ItemType = itemType;
        WeaponType = weapongType;
        Name = name;
        Value = itemValue;
    }

    public int DataIndex { get; }

    public int AlchemyIndex { get; }

    public bool AlchemyRate { get; }

    public ItemType ItemType { get; }

    public WeaponType WeaponType { get; }

    public string Name { get; }

    public ushort Value { get; }

    public override string ToString()
    {
        return Name;
    }
}