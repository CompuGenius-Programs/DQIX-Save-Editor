// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.VisitorData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class VisitorData
  {
    public const int DataSize = 232;
    private const uint VisitorDataOffset = 16200;
    private uint _index;
    private DataValueString _name;
    private DataValue<ushort> _handle;
    private DataValue<ushort> _handle2;
    private DataValue<ushort> _address;
    private DataValue<byte> _sex;
    private DataValue<byte> _haveTreasureMap;
    private DataValue<byte> _lodgingDayYear;
    private DataValue<ushort> _lodgingDayMonthDay;
    private DataValue<byte> _level;
    private DataValue<byte> _transmigration;
    private DataValue<byte> _color;
    private DataValue<byte> _profileSetting_Sex;
    private DataValue<ushort> _profileTone;
    private DataValue<ushort> _profileBirthYearMonth;
    private DataValue<byte> _profileBirthDay;
    private DataValue<byte> _profileSecretAge;
    private DataValueString _profileMessage;
    private DataValue<uint> _victoryCount;
    private DataValue<ushort> _monsterCompRate;
    private DataValue<ushort> _itemCompRate;
    private DataValue<byte> _fashionCompRate;
    private DataValue<uint> _questVisitorAlchemy;
    private DataValue<ushort> _titleCount;
    private DataValue<ushort> _treasureMapCount;
    private DataValue<uint> _alchemyCount;
    private DataValue<byte> _jobAndPlace;
    private DataValue<ushort> _playTimeHour;
    private DataValue<ushort> _playTimeMinute;
    private DataValue<ushort> _multiPlayTimeHour;
    private DataValue<ushort> _figureWidth;
    private DataValue<ushort> _figureHeight;
    private DataValue<byte> _hairType;
    private DataValue<byte> _hairColor;
    private DataValue<byte> _faceType;
    private DataValue<byte> _skinEyeColorSex;
    private DataValue<ushort> _equipmentWeapon;
    private DataValue<ushort> _equipmentShield;
    private DataValue<ushort> _equipmentHead;
    private DataValue<ushort> _equipmentUpperBody;
    private DataValue<ushort> _equipmentArm;
    private DataValue<ushort> _equipmentLowerBody;
    private DataValue<ushort> _equipmentShoe;
    private DataValue<ushort> _equipmentAccessory;
    private TreasureMapData _treasureMapData;
    private DataValue<uint> _seq;
    private DataValue<ulong> _uid;
    private DataValue<ushort> _visible;

    public VisitorData(SaveData owner, uint index)
    {
      this._index = index;
      uint offset = (uint) (16200 + 232 * (int) index);
      this._visible = new DataValue<ushort>(owner, 15U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._seq = new DataValue<uint>(owner, 16U + offset, (Control) null, 0U, uint.MaxValue);
      this._uid = new DataValue<ulong>(owner, 20U + offset, (Control) null, 0UL, ulong.MaxValue);
      this._name = new DataValueString(owner, offset, (Control) null, 10, true);
      this._address = new DataValue<ushort>(owner, 113U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._handle = new DataValue<ushort>(owner, 114U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._handle2 = new DataValue<ushort>(owner, 76U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._sex = new DataValue<byte>(owner, 78U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._haveTreasureMap = new DataValue<byte>(owner, 11U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._lodgingDayYear = new DataValue<byte>(owner, 11U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._lodgingDayMonthDay = new DataValue<ushort>(owner, 13U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._level = new DataValue<byte>(owner, 13U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._transmigration = new DataValue<byte>(owner, 78U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._color = new DataValue<byte>(owner, 79U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._jobAndPlace = new DataValue<byte>(owner, 12U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._profileBirthYearMonth = new DataValue<ushort>(owner, 108U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._profileBirthDay = new DataValue<byte>(owner, 110U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._profileSetting_Sex = new DataValue<byte>(owner, 111U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._profileTone = new DataValue<ushort>(owner, 110U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      byte[] fillData = new byte[2]{ (byte) 129, (byte) 69 };
      this._profileMessage = new DataValueString(owner, 116U + offset, (Control) null, 114, false, fillData);
      this._profileSecretAge = new DataValue<byte>(owner, 111U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._playTimeHour = new DataValue<ushort>(owner, 56U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._playTimeMinute = new DataValue<ushort>(owner, 64U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._multiPlayTimeHour = new DataValue<ushort>(owner, 60U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._victoryCount = new DataValue<uint>(owner, 61U + offset, (Control) null, 0U, uint.MaxValue);
      this._monsterCompRate = new DataValue<ushort>(owner, 65U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._itemCompRate = new DataValue<ushort>(owner, 66U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._fashionCompRate = new DataValue<byte>(owner, 71U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._questVisitorAlchemy = new DataValue<uint>(owner, 72U + offset, (Control) null, 0U, uint.MaxValue);
      this._titleCount = new DataValue<ushort>(owner, 68U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._treasureMapCount = new DataValue<ushort>(owner, 69U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._alchemyCount = new DataValue<uint>(owner, 57U + offset, (Control) null, 0U, uint.MaxValue);
      this._figureWidth = new DataValue<ushort>(owner, 50U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._figureHeight = new DataValue<ushort>(owner, 52U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._hairType = new DataValue<byte>(owner, 32U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._hairColor = new DataValue<byte>(owner, 47U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._faceType = new DataValue<byte>(owner, 30U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._skinEyeColorSex = new DataValue<byte>(owner, 46U + offset, (Control) null, (byte) 0, byte.MaxValue);
      this._equipmentWeapon = new DataValue<ushort>(owner, 40U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentShield = new DataValue<ushort>(owner, 42U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentHead = new DataValue<ushort>(owner, 38U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentUpperBody = new DataValue<ushort>(owner, 26U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentArm = new DataValue<ushort>(owner, 34U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentLowerBody = new DataValue<ushort>(owner, 28U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentShoe = new DataValue<ushort>(owner, 36U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentAccessory = new DataValue<ushort>(owner, 44U + offset, (Control) null, (ushort) 0, ushort.MaxValue);
      this._treasureMapData = new TreasureMapData(owner, 80U + offset);
    }

    internal DataValueString Name => this._name;

    public Handle Handle
    {
      get
      {
        ushort num = (ushort) (((int) this._handle.Value & 16376) >> 3);
        ProfileJob jobFromIndex = ProfileJobList.GetJobFromIndex((int) num);
        if (jobFromIndex != null)
          return new Handle(jobFromIndex);
        TitleElement titleElement = TitleDataList.GetTitleElement((int) num);
        return titleElement != null ? new Handle(titleElement) : (Handle) null;
      }
      set
      {
        if (value == null)
          return;
        ushort num;
        if (value.HandleType == HandleType.HandleJob && value.Job != null)
        {
          num = (ushort) value.Job.Index;
        }
        else
        {
          if (value.HandleType != HandleType.HandleTitle || value.Title == null)
            return;
          num = (ushort) value.Title.DataIndex;
        }
        this._handle.Value = (ushort) ((int) this._handle.Value & 49159 | (int) num << 3 & 16376);
        this._handle2.Value = (ushort) ((int) this._handle2.Value & 63488 | (int) num & 2047);
      }
    }

    public ProfileAddress Address
    {
      get
      {
        return ProfileAddressList.GetAddressFromIndex((ushort) (((int) this._address.Value & 2046) >> 1));
      }
      set
      {
        this._address.Value = (ushort) ((int) this._address.Value & 63489 | value.Index << 1 & 2046);
      }
    }

    public byte Sex
    {
      get => (byte) ((uint) this._sex.Value & 1U);
      set => this._sex.Value = (byte) ((int) this._sex.Value & 254 | (int) value & 1);
    }

    public bool HaveTreasureMap
    {
      get => ((int) this._haveTreasureMap.Value & 128) != 0;
      set
      {
        this._haveTreasureMap.Value = (byte) ((int) this._haveTreasureMap.Value & (int) sbyte.MaxValue | (value ? 128 : 0));
      }
    }

    public ushort LodgingDay_Year
    {
      get => (ushort) (2000 + ((int) this._lodgingDayYear.Value & (int) sbyte.MaxValue));
      set
      {
        this._lodgingDayYear.Value = (byte) ((int) this._lodgingDayYear.Value & 128 | (int) value - 2000 & (int) sbyte.MaxValue);
      }
    }

    public byte LodgingDay_Month
    {
      get => (byte) (((int) this._lodgingDayMonthDay.Value & 1920) >> 7);
      set
      {
        this._lodgingDayMonthDay.Value = (ushort) ((int) this._lodgingDayMonthDay.Value & 63615 | (int) value << 7 & 1920);
      }
    }

    public byte LodgingDay_Day
    {
      get => (byte) (((int) this._lodgingDayMonthDay.Value & 63488) >> 11);
      set
      {
        this._lodgingDayMonthDay.Value = (ushort) ((int) this._lodgingDayMonthDay.Value & 2047 | (int) value << 11 & 63488);
      }
    }

    public byte Level
    {
      get => (byte) ((uint) this._level.Value & (uint) sbyte.MaxValue);
      set
      {
        this._level.Value = (byte) ((int) this._level.Value & 128 | (int) value & (int) sbyte.MaxValue);
      }
    }

    public byte Transmigration
    {
      get => (byte) (((int) this._transmigration.Value & 30) >> 1);
      set
      {
        this._transmigration.Value = (byte) ((int) this._transmigration.Value & 225 | (int) value << 1 & 30);
      }
    }

    public byte Color
    {
      get => (byte) ((uint) this._color.Value & 15U);
      set => this._color.Value = (byte) ((int) this._color.Value & 240 | (int) value & 15);
    }

    public byte ProfileSex
    {
      get => (byte) (((int) this._profileSetting_Sex.Value & 2) >> 1);
      set
      {
        this._profileSetting_Sex.Value = (byte) ((int) this._profileSetting_Sex.Value & 253 | (value != (byte) 0 ? 2 : 0));
      }
    }

    public bool ProfileSetting
    {
      get => ((int) this._profileSetting_Sex.Value & 4) != 0;
      set
      {
        this._profileSetting_Sex.Value = (byte) ((int) this._profileSetting_Sex.Value & 251 | (value ? 4 : 0));
      }
    }

    public byte ProfileTone
    {
      get => (byte) (((int) this._profileTone.Value & 480) >> 5);
      set
      {
        this._profileTone.Value = (ushort) ((int) this._profileTone.Value & 65055 | (int) value << 5 & 480);
      }
    }

    public ushort ProfileBirthYear
    {
      get => (ushort) ((uint) this._profileBirthYearMonth.Value & 4095U);
      set
      {
        this._profileBirthYearMonth.Value = (ushort) ((int) this._profileBirthYearMonth.Value & 61440 | (int) value & 4095);
      }
    }

    public byte ProfileBirthMonth
    {
      get => (byte) ((uint) this._profileBirthYearMonth.Value >> 12);
      set
      {
        this._profileBirthYearMonth.Value = (ushort) ((int) this._profileBirthYearMonth.Value & 4095 | (int) value << 12);
      }
    }

    public byte ProfileBirthDay
    {
      get => (byte) ((uint) this._profileBirthDay.Value & 31U);
      set
      {
        this._profileBirthDay.Value = (byte) ((int) this._profileBirthDay.Value & 224 | (int) value & 31);
      }
    }

    public bool ProfileSecretAge
    {
      get => ((int) this._profileSecretAge.Value & 128) == 0;
      set
      {
        this._profileSecretAge.Value = (byte) ((int) (byte) ((uint) this._profileSecretAge.Value & (uint) sbyte.MaxValue) | (value ? 0 : 128));
      }
    }

    public DataValueString ProfileMessage => this._profileMessage;

    public uint VictoryCount
    {
      get => (this._victoryCount.Value & 8388544U) >> 6;
      set
      {
        this._victoryCount.Value = (uint) ((int) this._victoryCount.Value & -8388545 | (int) value << 6 & 8388544);
      }
    }

    public byte MonsterCompRate
    {
      get => (byte) (((int) this._monsterCompRate.Value & 8128) >> 6);
      set
      {
        this._monsterCompRate.Value = (ushort) ((int) this._monsterCompRate.Value & 57407 | (int) value << 6 & 8128);
      }
    }

    public byte ItemCompRate
    {
      get => (byte) (((int) this._itemCompRate.Value & 4064) >> 5);
      set
      {
        this._itemCompRate.Value = (ushort) ((int) this._itemCompRate.Value & 61471 | (int) value << 5 & 4064);
      }
    }

    public byte FashionCompRate
    {
      get => (byte) ((uint) this._fashionCompRate.Value & (uint) sbyte.MaxValue);
      set
      {
        this._fashionCompRate.Value = (byte) ((int) this._itemCompRate.Value & 128 | (int) value & (int) sbyte.MaxValue);
      }
    }

    public ushort QuestClearCount
    {
      get => (ushort) (this._questVisitorAlchemy.Value & 511U);
      set
      {
        this._questVisitorAlchemy.Value = (uint) ((int) this._questVisitorAlchemy.Value & -512 | (int) value & 511);
      }
    }

    public ushort VisitorCount
    {
      get => (ushort) ((this._questVisitorAlchemy.Value & 8388096U) >> 9);
      set
      {
        this._questVisitorAlchemy.Value = (uint) ((int) this._questVisitorAlchemy.Value & -8388097 | (int) value << 9 & 8388096);
      }
    }

    public byte AlchemyCompRate
    {
      get => (byte) ((this._questVisitorAlchemy.Value & 1065353216U) >> 23);
      set
      {
        this._questVisitorAlchemy.Value = (uint) ((int) this._questVisitorAlchemy.Value & -1065353217 | (int) value << 23 & 1065353216);
      }
    }

    public ushort TitleCount
    {
      get => (ushort) ((uint) this._titleCount.Value & 1023U);
      set
      {
        this._titleCount.Value = (ushort) ((int) this._titleCount.Value & 64512 | (int) value & 1023);
      }
    }

    public ushort TreasureMapCount
    {
      get => (ushort) (((int) this._treasureMapCount.Value & 65532) >> 2);
      set
      {
        this._treasureMapCount.Value = (ushort) ((int) this._treasureMapCount.Value & 3 | (int) value << 2);
      }
    }

    public ushort AlchemyCount
    {
      get => (ushort) ((this._alchemyCount.Value & 4194240U) >> 6);
      set
      {
        this._alchemyCount.Value = (uint) ((int) this._alchemyCount.Value & -4194241 | (int) value << 6 & 4194240);
      }
    }

    public byte Job
    {
      get => (byte) ((uint) this._jobAndPlace.Value & 15U);
      set
      {
        this._jobAndPlace.Value = (byte) ((int) this._jobAndPlace.Value & 240 | (int) value & 15);
      }
    }

    public byte Place
    {
      get
      {
        byte num = (byte) (((int) this._jobAndPlace.Value & 240) >> 4);
        return num <= (byte) 0 || num >= (byte) 7 ? (num == (byte) 9 || num == (byte) 10 ? (byte) ((uint) num - 3U) : (byte) 0) : (byte) ((uint) num - 1U);
      }
      set
      {
        if (value > (byte) 0 && value <= (byte) 5)
          ++value;
        else
          value += (byte) 3;
        this._jobAndPlace.Value = (byte) ((int) this._jobAndPlace.Value & 15 | (int) value << 4 & 240);
      }
    }

    public ushort PlayTimeHour
    {
      get => (ushort) ((uint) this._playTimeHour.Value & 16383U);
      set
      {
        this._playTimeHour.Value = (ushort) ((int) this._playTimeHour.Value & 49152 | (int) value & 16383);
      }
    }

    public byte PlayTimeMinute
    {
      get => (byte) ((uint) this._playTimeMinute.Value & (uint) sbyte.MaxValue);
      set
      {
        this._playTimeMinute.Value = (ushort) ((int) this._playTimeMinute.Value & 65408 | (int) value & (int) sbyte.MaxValue);
      }
    }

    public byte MultiPlayTimeMinute
    {
      get => (byte) (((int) this._playTimeMinute.Value & 16256) >> 7);
      set
      {
        this._playTimeMinute.Value = (ushort) ((int) this._playTimeMinute.Value & 49279 | (int) value << 7 & 16256);
      }
    }

    public ushort MultiPlayTimeHour
    {
      get => (ushort) ((uint) this._multiPlayTimeHour.Value & 16383U);
      set
      {
        this._multiPlayTimeHour.Value = (ushort) ((int) this._multiPlayTimeHour.Value & 49152 | (int) value & 16383);
      }
    }

    public DataValue<ushort> FigureWidth => this._figureWidth;

    public DataValue<ushort> FigureHeight => this._figureHeight;

    public DataValue<byte> HairType => this._hairType;

    public DataValue<byte> HairColor => this._hairColor;

    public DataValue<byte> FaceType => this._faceType;

    public byte CharaSex
    {
      get => (byte) ((uint) this._skinEyeColorSex.Value & 1U);
      set
      {
        this._skinEyeColorSex.Value = (byte) ((int) this._skinEyeColorSex.Value & 254 | (int) value & 1);
      }
    }

    public byte SkinColor
    {
      get => (byte) (((int) this._skinEyeColorSex.Value & 14) >> 1);
      set
      {
        this._skinEyeColorSex.Value = (byte) ((int) this._skinEyeColorSex.Value & 241 | (int) value << 1);
      }
    }

    public byte EyeColor
    {
      get => (byte) (((int) this._skinEyeColorSex.Value & 240) >> 4);
      set
      {
        this._skinEyeColorSex.Value = (byte) ((int) this._skinEyeColorSex.Value & 15 | (int) value << 4);
      }
    }

    public ItemDataBase EquipmentWeapon
    {
      get => ItemDataList.GetItem(ItemType.Weapon, this._equipmentWeapon.Value);
      set => this._equipmentWeapon.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentShield
    {
      get => ItemDataList.GetItem(ItemType.Shield, this._equipmentShield.Value);
      set => this._equipmentShield.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentHead
    {
      get => ItemDataList.GetItem(ItemType.Head, this._equipmentHead.Value);
      set => this._equipmentHead.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentUpperBody
    {
      get => ItemDataList.GetItem(ItemType.UpperBody, this._equipmentUpperBody.Value);
      set => this._equipmentUpperBody.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentArm
    {
      get => ItemDataList.GetItem(ItemType.Arm, this._equipmentArm.Value);
      set => this._equipmentArm.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentLowerBody
    {
      get => ItemDataList.GetItem(ItemType.LowerBody, this._equipmentLowerBody.Value);
      set => this._equipmentLowerBody.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentShoe
    {
      get => ItemDataList.GetItem(ItemType.Shoe, this._equipmentShoe.Value);
      set => this._equipmentShoe.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentAccessory
    {
      get => ItemDataList.GetItem(ItemType.Accessory, this._equipmentAccessory.Value);
      set => this._equipmentAccessory.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public TreasureMapData TreasureMapData => this._treasureMapData;

    public uint SEQ
    {
      get => (this._seq.Value & 4294967292U) >> 2;
      set
      {
        if (value == 0U)
          value = 1U;
        this._seq.Value = (uint) ((int) this._seq.Value & 3 | (int) value << 2);
      }
    }

    public ulong UID
    {
      get => this._uid.Value & 281474976710655UL;
      set
      {
        this._uid.Value = (ulong) ((long) this._uid.Value & -281474976710656L | (long) value & 281474976710655L);
      }
    }

    public void SetEquipment(ItemType itemType, ItemDataBase item)
    {
      switch (itemType)
      {
        case ItemType.Weapon:
          this.EquipmentWeapon = item;
          break;
        case ItemType.Shield:
          this.EquipmentShield = item;
          break;
        case ItemType.Head:
          this.EquipmentHead = item;
          break;
        case ItemType.UpperBody:
          this.EquipmentUpperBody = item;
          break;
        case ItemType.Arm:
          this.EquipmentArm = item;
          break;
        case ItemType.LowerBody:
          this.EquipmentLowerBody = item;
          break;
        case ItemType.Shoe:
          this.EquipmentShoe = item;
          break;
        case ItemType.Accessory:
          this.EquipmentAccessory = item;
          break;
      }
    }

    public void OnLoaded() => this._treasureMapData.CalculateDetail();

    public void OnUndo() => this._treasureMapData.CalculateDetail();

    public void OnRedo() => this._treasureMapData.CalculateDetail();

    public byte[] GetBytesData()
    {
      byte[] destinationArray = new byte[232];
      Array.Copy((Array) SaveDataManager.Instance.SaveData.Data, (long) (uint) (16200 + 232 * (int) this._index), (Array) destinationArray, 0L, 232L);
      return destinationArray;
    }

    public void Copy(byte[] srcData)
    {
      srcData.CopyTo((Array) SaveDataManager.Instance.SaveData.Data, (long) (uint) (16200 + 232 * (int) this._index));
      this._treasureMapData.CalculateDetail();
    }

    public void Clear()
    {
      SaveDataManager.Instance.UndoRedoMgr.Edited((UndoRedoElement) new UndoRedoVisitorDataClear(this._index));
      byte[] sourceArray1 = new byte[28]
      {
        (byte) 207,
        (byte) 50,
        (byte) 87,
        (byte) 63,
        (byte) 60,
        (byte) 35,
        (byte) 40,
        (byte) 35,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 224,
        (byte) 66,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 36,
        (byte) 78,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 4,
        (byte) 0,
        (byte) 183,
        (byte) 54,
        (byte) 0,
        (byte) 16,
        (byte) 0,
        (byte) 16
      };
      byte[] sourceArray2 = new byte[8]
      {
        (byte) 208,
        (byte) 23,
        (byte) 1,
        (byte) 64,
        byte.MaxValue,
        (byte) 89,
        (byte) 18,
        (byte) 22
      };
      Array.Clear((Array) SaveDataManager.Instance.SaveData.Data, 16200 + 232 * (int) this._index, 232);
      SaveDataManager.Instance.SaveData.Data[16200 + 232 * (int) this._index + 12] = (byte) ((int) (this._index / 6U) + 2 << 4);
      Array.Copy((Array) sourceArray1, 0, (Array) SaveDataManager.Instance.SaveData.Data, 16200 + 232 * (int) this._index + 26, 28);
      Array.Copy((Array) sourceArray2, 0, (Array) SaveDataManager.Instance.SaveData.Data, 16200 + 232 * (int) this._index + 108, 8);
    }

    public void OnCreate()
    {
      this._visible.Value = (ushort) ((int) this._visible.Value & 64512 | 576);
      this.ProfileSetting = true;
    }
  }
}
