// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.SaveData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.IO;
using System.Windows.Forms;

#nullable disable
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
      this._isIntermission = new DataValue<byte>(this, 20U, (Control) null, (byte) 0, (byte) 1);
      this._basisData = new BasisData(this);
      this._firstClearData = new FirstClearData(this);
      this._characterManager = new CharacterManager(this);
      this._rikkaData = new RikkaData(this);
      this._itemData = new ItemData(this);
      this._processFlag = new ProcessFlag(this);
      this._questDataManager = new QuestDataManager(this);
      this._titleData = new TitleData(this);
      this._treasureMapManager = new TreasureMapManager(this);
      this._monsterDataManager = new MonsterDataManager(this);
      this._smartItemData = new SmartItemData(this);
      this._itemCollectionData = new ItemCollectionData(this);
      this._alchemyData = new AlchemyData(this);
      this._wifiShopData = new WifiShopping(this);
    }

    public byte[] Data => this._data;

    internal void ReadData(BinaryReader br)
    {
      this._data = br.ReadBytes(32768);
      this._characterManager.OnLoaded();
      this._alchemyData.OnLoaded();
      this._rikkaData.VisitorManager.OnLoaded();
      this._treasureMapManager.OnLoaded();
    }

    internal void Create() => this._data = new byte[32768];

    internal void OnSaving()
    {
      this._characterManager.OnSaving();
      this._alchemyData.OnSaving();
    }

    internal void OnUndo()
    {
      this._rikkaData.VisitorManager.OnUndo();
      this._treasureMapManager.OnUndo();
    }

    internal void OnRedo()
    {
      this._rikkaData.VisitorManager.OnRedo();
      this._treasureMapManager.OnRedo();
    }

    public DataValue<byte> IsIntermission => this._isIntermission;

    public BasisData BasisData => this._basisData;

    public FirstClearData FirstClearData => this._firstClearData;

    public CharacterManager CharacterManager => this._characterManager;

    public RikkaData RikkaData => this._rikkaData;

    public ItemData ItemData => this._itemData;

    public ProcessFlag ProcessFlag => this._processFlag;

    public QuestDataManager QuestDataManager => this._questDataManager;

    public TitleData TitleData => this._titleData;

    public TreasureMapManager TreasureMapManager => this._treasureMapManager;

    public MonsterDataManager MonsterDataManager => this._monsterDataManager;

    public SmartItemData SmartItemData => this._smartItemData;

    public ItemCollectionData ItemCollectionData => this._itemCollectionData;

    public AlchemyData AlchemyData => this._alchemyData;

    public WifiShopping WifiShopData => this._wifiShopData;

    public byte[] GetData()
    {
      byte[] destinationArray = new byte[32752];
      Array.Copy((Array) this._data, 16, (Array) destinationArray, 0, destinationArray.Length);
      return destinationArray;
    }

    public void CopyData(byte[] src)
    {
      if (src.Length != 32752)
        return;
      Array.Copy((Array) src, 0, (Array) this._data, 16, 32752);
    }
  }
}
