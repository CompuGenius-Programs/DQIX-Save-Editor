// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.SaveData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.IO;

namespace DQ9_Cheat.DataManager;

internal class SaveData
{
    private const int DataSize = 32768;
    private const int HeaderSize = 16;

    public SaveData()
    {
        IsIntermission = new DataValue<byte>(this, 20U, null, 0, 1);
        BasisData = new BasisData(this);
        FirstClearData = new FirstClearData(this);
        CharacterManager = new CharacterManager(this);
        RikkaData = new RikkaData(this);
        ItemData = new ItemData(this);
        ProcessFlag = new ProcessFlag(this);
        QuestDataManager = new QuestDataManager(this);
        TitleData = new TitleData(this);
        TreasureMapManager = new TreasureMapManager(this);
        MonsterDataManager = new MonsterDataManager(this);
        SmartItemData = new SmartItemData(this);
        ItemCollectionData = new ItemCollectionData(this);
        AlchemyData = new AlchemyData(this);
        WifiShopData = new WifiShopping(this);
    }

    public byte[] Data { get; private set; }

    public DataValue<byte> IsIntermission { get; }

    public BasisData BasisData { get; }

    public FirstClearData FirstClearData { get; }

    public CharacterManager CharacterManager { get; }

    public RikkaData RikkaData { get; }

    public ItemData ItemData { get; }

    public ProcessFlag ProcessFlag { get; }

    public QuestDataManager QuestDataManager { get; }

    public TitleData TitleData { get; }

    public TreasureMapManager TreasureMapManager { get; }

    public MonsterDataManager MonsterDataManager { get; }

    public SmartItemData SmartItemData { get; }

    public ItemCollectionData ItemCollectionData { get; }

    public AlchemyData AlchemyData { get; }

    public WifiShopping WifiShopData { get; }

    internal void ReadData(BinaryReader br)
    {
        Data = br.ReadBytes(32768);
        CharacterManager.OnLoaded();
        AlchemyData.OnLoaded();
        RikkaData.VisitorManager.OnLoaded();
        TreasureMapManager.OnLoaded();
    }

    internal void Create()
    {
        Data = new byte[32768];
    }

    internal void OnSaving()
    {
        CharacterManager.OnSaving();
        AlchemyData.OnSaving();
    }

    internal void OnUndo()
    {
        RikkaData.VisitorManager.OnUndo();
        TreasureMapManager.OnUndo();
    }

    internal void OnRedo()
    {
        RikkaData.VisitorManager.OnRedo();
        TreasureMapManager.OnRedo();
    }

    public byte[] GetData()
    {
        var destinationArray = new byte[32752];
        Array.Copy(Data, 16, destinationArray, 0, destinationArray.Length);
        return destinationArray;
    }

    public void CopyData(byte[] src)
    {
        if (src.Length != 32752)
            return;
        Array.Copy(src, 0, Data, 16, 32752);
    }
}