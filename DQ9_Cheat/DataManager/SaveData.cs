// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.SaveData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.IO;

namespace DQ9_Cheat.DataManager
{
  internal class SaveData
  {
    private const int DataSize = 32768;
    private const int HeaderSize = 16;
    private byte[] _data;
    private DataValue<byte> _isIntermission;
    private BasisData _basisData;
    private FirstClearData _firstClearData;
    private CharacterManager _characterManager;
    private RikkaData _rikkaData;
    private ItemData _itemData;
    private ProcessFlag _processFlag;
    private QuestDataManager _questDataManager;
    private TitleData _titleData;
    private TreasureMapManager _treasureMapManager;
    private MonsterDataManager _monsterDataManager;
    private SmartItemData _smartItemData;
    private ItemCollectionData _itemCollectionData;
    private AlchemyData _alchemyData;
    private WifiShopping _wifiShopData;

    public SaveData()
    {
      _isIntermission = new DataValue<byte>(this, 20U, null, 0, 1);
      _basisData = new BasisData(this);
      _firstClearData = new FirstClearData(this);
      _characterManager = new CharacterManager(this);
      _rikkaData = new RikkaData(this);
      _itemData = new ItemData(this);
      _processFlag = new ProcessFlag(this);
      _questDataManager = new QuestDataManager(this);
      _titleData = new TitleData(this);
      _treasureMapManager = new TreasureMapManager(this);
      _monsterDataManager = new MonsterDataManager(this);
      _smartItemData = new SmartItemData(this);
      _itemCollectionData = new ItemCollectionData(this);
      _alchemyData = new AlchemyData(this);
      _wifiShopData = new WifiShopping(this);
    }

    public byte[] Data => _data;

    internal void ReadData(BinaryReader br)
    {
      _data = br.ReadBytes(32768);
      _characterManager.OnLoaded();
      _alchemyData.OnLoaded();
      _rikkaData.VisitorManager.OnLoaded();
      _treasureMapManager.OnLoaded();
    }

    internal void Create() => _data = new byte[32768];

    internal void OnSaving()
    {
      _characterManager.OnSaving();
      _alchemyData.OnSaving();
    }

    internal void OnUndo()
    {
      _rikkaData.VisitorManager.OnUndo();
      _treasureMapManager.OnUndo();
    }

    internal void OnRedo()
    {
      _rikkaData.VisitorManager.OnRedo();
      _treasureMapManager.OnRedo();
    }

    public DataValue<byte> IsIntermission => _isIntermission;

    public BasisData BasisData => _basisData;

    public FirstClearData FirstClearData => _firstClearData;

    public CharacterManager CharacterManager => _characterManager;

    public RikkaData RikkaData => _rikkaData;

    public ItemData ItemData => _itemData;

    public ProcessFlag ProcessFlag => _processFlag;

    public QuestDataManager QuestDataManager => _questDataManager;

    public TitleData TitleData => _titleData;

    public TreasureMapManager TreasureMapManager => _treasureMapManager;

    public MonsterDataManager MonsterDataManager => _monsterDataManager;

    public SmartItemData SmartItemData => _smartItemData;

    public ItemCollectionData ItemCollectionData => _itemCollectionData;

    public AlchemyData AlchemyData => _alchemyData;

    public WifiShopping WifiShopData => _wifiShopData;

    public byte[] GetData()
    {
      byte[] destinationArray = new byte[32752];
      Array.Copy(_data, 16, destinationArray, 0, destinationArray.Length);
      return destinationArray;
    }

    public void CopyData(byte[] src)
    {
      if (src.Length != 32752)
        return;
      Array.Copy(src, 0, _data, 16, 32752);
    }
  }
}
