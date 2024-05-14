// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.VisitorData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using DQ9_Cheat.GameData;

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
      _index = index;
      uint offset = (uint) (16200 + 232 * (int) index);
      _visible = new DataValue<ushort>(owner, 15U + offset, null, 0, ushort.MaxValue);
      _seq = new DataValue<uint>(owner, 16U + offset, null, 0U, uint.MaxValue);
      _uid = new DataValue<ulong>(owner, 20U + offset, null, 0UL, ulong.MaxValue);
      _name = new DataValueString(owner, offset, null, 10, true);
      _address = new DataValue<ushort>(owner, 113U + offset, null, 0, ushort.MaxValue);
      _handle = new DataValue<ushort>(owner, 114U + offset, null, 0, ushort.MaxValue);
      _handle2 = new DataValue<ushort>(owner, 76U + offset, null, 0, ushort.MaxValue);
      _sex = new DataValue<byte>(owner, 78U + offset, null, 0, byte.MaxValue);
      _haveTreasureMap = new DataValue<byte>(owner, 11U + offset, null, 0, byte.MaxValue);
      _lodgingDayYear = new DataValue<byte>(owner, 11U + offset, null, 0, byte.MaxValue);
      _lodgingDayMonthDay = new DataValue<ushort>(owner, 13U + offset, null, 0, ushort.MaxValue);
      _level = new DataValue<byte>(owner, 13U + offset, null, 0, byte.MaxValue);
      _transmigration = new DataValue<byte>(owner, 78U + offset, null, 0, byte.MaxValue);
      _color = new DataValue<byte>(owner, 79U + offset, null, 0, byte.MaxValue);
      _jobAndPlace = new DataValue<byte>(owner, 12U + offset, null, 0, byte.MaxValue);
      _profileBirthYearMonth = new DataValue<ushort>(owner, 108U + offset, null, 0, ushort.MaxValue);
      _profileBirthDay = new DataValue<byte>(owner, 110U + offset, null, 0, byte.MaxValue);
      _profileSetting_Sex = new DataValue<byte>(owner, 111U + offset, null, 0, byte.MaxValue);
      _profileTone = new DataValue<ushort>(owner, 110U + offset, null, 0, ushort.MaxValue);
      byte[] fillData = new byte[2]{ 129, 69 };
      _profileMessage = new DataValueString(owner, 116U + offset, null, 114, false, fillData);
      _profileSecretAge = new DataValue<byte>(owner, 111U + offset, null, 0, byte.MaxValue);
      _playTimeHour = new DataValue<ushort>(owner, 56U + offset, null, 0, ushort.MaxValue);
      _playTimeMinute = new DataValue<ushort>(owner, 64U + offset, null, 0, ushort.MaxValue);
      _multiPlayTimeHour = new DataValue<ushort>(owner, 60U + offset, null, 0, ushort.MaxValue);
      _victoryCount = new DataValue<uint>(owner, 61U + offset, null, 0U, uint.MaxValue);
      _monsterCompRate = new DataValue<ushort>(owner, 65U + offset, null, 0, ushort.MaxValue);
      _itemCompRate = new DataValue<ushort>(owner, 66U + offset, null, 0, ushort.MaxValue);
      _fashionCompRate = new DataValue<byte>(owner, 71U + offset, null, 0, byte.MaxValue);
      _questVisitorAlchemy = new DataValue<uint>(owner, 72U + offset, null, 0U, uint.MaxValue);
      _titleCount = new DataValue<ushort>(owner, 68U + offset, null, 0, ushort.MaxValue);
      _treasureMapCount = new DataValue<ushort>(owner, 69U + offset, null, 0, ushort.MaxValue);
      _alchemyCount = new DataValue<uint>(owner, 57U + offset, null, 0U, uint.MaxValue);
      _figureWidth = new DataValue<ushort>(owner, 50U + offset, null, 0, ushort.MaxValue);
      _figureHeight = new DataValue<ushort>(owner, 52U + offset, null, 0, ushort.MaxValue);
      _hairType = new DataValue<byte>(owner, 32U + offset, null, 0, byte.MaxValue);
      _hairColor = new DataValue<byte>(owner, 47U + offset, null, 0, byte.MaxValue);
      _faceType = new DataValue<byte>(owner, 30U + offset, null, 0, byte.MaxValue);
      _skinEyeColorSex = new DataValue<byte>(owner, 46U + offset, null, 0, byte.MaxValue);
      _equipmentWeapon = new DataValue<ushort>(owner, 40U + offset, null, 0, ushort.MaxValue);
      _equipmentShield = new DataValue<ushort>(owner, 42U + offset, null, 0, ushort.MaxValue);
      _equipmentHead = new DataValue<ushort>(owner, 38U + offset, null, 0, ushort.MaxValue);
      _equipmentUpperBody = new DataValue<ushort>(owner, 26U + offset, null, 0, ushort.MaxValue);
      _equipmentArm = new DataValue<ushort>(owner, 34U + offset, null, 0, ushort.MaxValue);
      _equipmentLowerBody = new DataValue<ushort>(owner, 28U + offset, null, 0, ushort.MaxValue);
      _equipmentShoe = new DataValue<ushort>(owner, 36U + offset, null, 0, ushort.MaxValue);
      _equipmentAccessory = new DataValue<ushort>(owner, 44U + offset, null, 0, ushort.MaxValue);
      _treasureMapData = new TreasureMapData(owner, 80U + offset);
    }

    internal DataValueString Name => _name;

    public Handle Handle
    {
      get
      {
        ushort num = (ushort) ((_handle.Value & 16376) >> 3);
        ProfileJob jobFromIndex = ProfileJobList.GetJobFromIndex(num);
        if (jobFromIndex != null)
          return new Handle(jobFromIndex);
        TitleElement titleElement = TitleDataList.GetTitleElement(num);
        return titleElement != null ? new Handle(titleElement) : null;
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
        _handle.Value = (ushort) (_handle.Value & 49159 | num << 3 & 16376);
        _handle2.Value = (ushort) (_handle2.Value & 63488 | num & 2047);
      }
    }

    public ProfileAddress Address
    {
      get
      {
        return ProfileAddressList.GetAddressFromIndex((ushort) ((_address.Value & 2046) >> 1));
      }
      set
      {
        _address.Value = (ushort) (_address.Value & 63489 | value.Index << 1 & 2046);
      }
    }

    public byte Sex
    {
      get => (byte) (_sex.Value & 1U);
      set => _sex.Value = (byte) (_sex.Value & 254 | value & 1);
    }

    public bool HaveTreasureMap
    {
      get => (_haveTreasureMap.Value & 128) != 0;
      set
      {
        _haveTreasureMap.Value = (byte) (_haveTreasureMap.Value & sbyte.MaxValue | (value ? 128 : 0));
      }
    }

    public ushort LodgingDay_Year
    {
      get => (ushort) (2000 + (_lodgingDayYear.Value & sbyte.MaxValue));
      set
      {
        _lodgingDayYear.Value = (byte) (_lodgingDayYear.Value & 128 | value - 2000 & sbyte.MaxValue);
      }
    }

    public byte LodgingDay_Month
    {
      get => (byte) ((_lodgingDayMonthDay.Value & 1920) >> 7);
      set
      {
        _lodgingDayMonthDay.Value = (ushort) (_lodgingDayMonthDay.Value & 63615 | value << 7 & 1920);
      }
    }

    public byte LodgingDay_Day
    {
      get => (byte) ((_lodgingDayMonthDay.Value & 63488) >> 11);
      set
      {
        _lodgingDayMonthDay.Value = (ushort) (_lodgingDayMonthDay.Value & 2047 | value << 11 & 63488);
      }
    }

    public byte Level
    {
      get => (byte) (_level.Value & (uint) sbyte.MaxValue);
      set
      {
        _level.Value = (byte) (_level.Value & 128 | value & sbyte.MaxValue);
      }
    }

    public byte Transmigration
    {
      get => (byte) ((_transmigration.Value & 30) >> 1);
      set
      {
        _transmigration.Value = (byte) (_transmigration.Value & 225 | value << 1 & 30);
      }
    }

    public byte Color
    {
      get => (byte) (_color.Value & 15U);
      set => _color.Value = (byte) (_color.Value & 240 | value & 15);
    }

    public byte ProfileSex
    {
      get => (byte) ((_profileSetting_Sex.Value & 2) >> 1);
      set
      {
        _profileSetting_Sex.Value = (byte) (_profileSetting_Sex.Value & 253 | (value != 0 ? 2 : 0));
      }
    }

    public bool ProfileSetting
    {
      get => (_profileSetting_Sex.Value & 4) != 0;
      set
      {
        _profileSetting_Sex.Value = (byte) (_profileSetting_Sex.Value & 251 | (value ? 4 : 0));
      }
    }

    public byte ProfileTone
    {
      get => (byte) ((_profileTone.Value & 480) >> 5);
      set
      {
        _profileTone.Value = (ushort) (_profileTone.Value & 65055 | value << 5 & 480);
      }
    }

    public ushort ProfileBirthYear
    {
      get => (ushort) (_profileBirthYearMonth.Value & 4095U);
      set
      {
        _profileBirthYearMonth.Value = (ushort) (_profileBirthYearMonth.Value & 61440 | value & 4095);
      }
    }

    public byte ProfileBirthMonth
    {
      get => (byte) ((uint) _profileBirthYearMonth.Value >> 12);
      set
      {
        _profileBirthYearMonth.Value = (ushort) (_profileBirthYearMonth.Value & 4095 | value << 12);
      }
    }

    public byte ProfileBirthDay
    {
      get => (byte) (_profileBirthDay.Value & 31U);
      set
      {
        _profileBirthDay.Value = (byte) (_profileBirthDay.Value & 224 | value & 31);
      }
    }

    public bool ProfileSecretAge
    {
      get => (_profileSecretAge.Value & 128) == 0;
      set
      {
        _profileSecretAge.Value = (byte) ((byte) (_profileSecretAge.Value & (uint) sbyte.MaxValue) | (value ? 0 : 128));
      }
    }

    public DataValueString ProfileMessage => _profileMessage;

    public uint VictoryCount
    {
      get => (_victoryCount.Value & 8388544U) >> 6;
      set
      {
        _victoryCount.Value = (uint) ((int) _victoryCount.Value & -8388545 | (int) value << 6 & 8388544);
      }
    }

    public byte MonsterCompRate
    {
      get => (byte) ((_monsterCompRate.Value & 8128) >> 6);
      set
      {
        _monsterCompRate.Value = (ushort) (_monsterCompRate.Value & 57407 | value << 6 & 8128);
      }
    }

    public byte ItemCompRate
    {
      get => (byte) ((_itemCompRate.Value & 4064) >> 5);
      set
      {
        _itemCompRate.Value = (ushort) (_itemCompRate.Value & 61471 | value << 5 & 4064);
      }
    }

    public byte FashionCompRate
    {
      get => (byte) (_fashionCompRate.Value & (uint) sbyte.MaxValue);
      set
      {
        _fashionCompRate.Value = (byte) (_itemCompRate.Value & 128 | value & sbyte.MaxValue);
      }
    }

    public ushort QuestClearCount
    {
      get => (ushort) (_questVisitorAlchemy.Value & 511U);
      set
      {
        _questVisitorAlchemy.Value = (uint) ((int) _questVisitorAlchemy.Value & -512 | value & 511);
      }
    }

    public ushort VisitorCount
    {
      get => (ushort) ((_questVisitorAlchemy.Value & 8388096U) >> 9);
      set
      {
        _questVisitorAlchemy.Value = (uint) ((int) _questVisitorAlchemy.Value & -8388097 | value << 9 & 8388096);
      }
    }

    public byte AlchemyCompRate
    {
      get => (byte) ((_questVisitorAlchemy.Value & 1065353216U) >> 23);
      set
      {
        _questVisitorAlchemy.Value = (uint) ((int) _questVisitorAlchemy.Value & -1065353217 | value << 23 & 1065353216);
      }
    }

    public ushort TitleCount
    {
      get => (ushort) (_titleCount.Value & 1023U);
      set
      {
        _titleCount.Value = (ushort) (_titleCount.Value & 64512 | value & 1023);
      }
    }

    public ushort TreasureMapCount
    {
      get => (ushort) ((_treasureMapCount.Value & 65532) >> 2);
      set
      {
        _treasureMapCount.Value = (ushort) (_treasureMapCount.Value & 3 | value << 2);
      }
    }

    public ushort AlchemyCount
    {
      get => (ushort) ((_alchemyCount.Value & 4194240U) >> 6);
      set
      {
        _alchemyCount.Value = (uint) ((int) _alchemyCount.Value & -4194241 | value << 6 & 4194240);
      }
    }

    public byte Job
    {
      get => (byte) (_jobAndPlace.Value & 15U);
      set
      {
        _jobAndPlace.Value = (byte) (_jobAndPlace.Value & 240 | value & 15);
      }
    }

    public byte Place
    {
      get
      {
        byte num = (byte) ((_jobAndPlace.Value & 240) >> 4);
        return num <= 0 || num >= 7 ? (num == 9 || num == 10 ? (byte) (num - 3U) : (byte) 0) : (byte) (num - 1U);
      }
      set
      {
        if (value > 0 && value <= 5)
          ++value;
        else
          value += 3;
        _jobAndPlace.Value = (byte) (_jobAndPlace.Value & 15 | value << 4 & 240);
      }
    }

    public ushort PlayTimeHour
    {
      get => (ushort) (_playTimeHour.Value & 16383U);
      set
      {
        _playTimeHour.Value = (ushort) (_playTimeHour.Value & 49152 | value & 16383);
      }
    }

    public byte PlayTimeMinute
    {
      get => (byte) (_playTimeMinute.Value & (uint) sbyte.MaxValue);
      set
      {
        _playTimeMinute.Value = (ushort) (_playTimeMinute.Value & 65408 | value & sbyte.MaxValue);
      }
    }

    public byte MultiPlayTimeMinute
    {
      get => (byte) ((_playTimeMinute.Value & 16256) >> 7);
      set
      {
        _playTimeMinute.Value = (ushort) (_playTimeMinute.Value & 49279 | value << 7 & 16256);
      }
    }

    public ushort MultiPlayTimeHour
    {
      get => (ushort) (_multiPlayTimeHour.Value & 16383U);
      set
      {
        _multiPlayTimeHour.Value = (ushort) (_multiPlayTimeHour.Value & 49152 | value & 16383);
      }
    }

    public DataValue<ushort> FigureWidth => _figureWidth;

    public DataValue<ushort> FigureHeight => _figureHeight;

    public DataValue<byte> HairType => _hairType;

    public DataValue<byte> HairColor => _hairColor;

    public DataValue<byte> FaceType => _faceType;

    public byte CharaSex
    {
      get => (byte) (_skinEyeColorSex.Value & 1U);
      set
      {
        _skinEyeColorSex.Value = (byte) (_skinEyeColorSex.Value & 254 | value & 1);
      }
    }

    public byte SkinColor
    {
      get => (byte) ((_skinEyeColorSex.Value & 14) >> 1);
      set
      {
        _skinEyeColorSex.Value = (byte) (_skinEyeColorSex.Value & 241 | value << 1);
      }
    }

    public byte EyeColor
    {
      get => (byte) ((_skinEyeColorSex.Value & 240) >> 4);
      set
      {
        _skinEyeColorSex.Value = (byte) (_skinEyeColorSex.Value & 15 | value << 4);
      }
    }

    public ItemDataBase EquipmentWeapon
    {
      get => ItemDataList.GetItem(ItemType.Weapon, _equipmentWeapon.Value);
      set => _equipmentWeapon.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentShield
    {
      get => ItemDataList.GetItem(ItemType.Shield, _equipmentShield.Value);
      set => _equipmentShield.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentHead
    {
      get => ItemDataList.GetItem(ItemType.Head, _equipmentHead.Value);
      set => _equipmentHead.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentUpperBody
    {
      get => ItemDataList.GetItem(ItemType.UpperBody, _equipmentUpperBody.Value);
      set => _equipmentUpperBody.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentArm
    {
      get => ItemDataList.GetItem(ItemType.Arm, _equipmentArm.Value);
      set => _equipmentArm.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentLowerBody
    {
      get => ItemDataList.GetItem(ItemType.LowerBody, _equipmentLowerBody.Value);
      set => _equipmentLowerBody.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentShoe
    {
      get => ItemDataList.GetItem(ItemType.Shoe, _equipmentShoe.Value);
      set => _equipmentShoe.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public ItemDataBase EquipmentAccessory
    {
      get => ItemDataList.GetItem(ItemType.Accessory, _equipmentAccessory.Value);
      set => _equipmentAccessory.Value = value != null ? value.Value : ushort.MaxValue;
    }

    public TreasureMapData TreasureMapData => _treasureMapData;

    public uint SEQ
    {
      get => (_seq.Value & 4294967292U) >> 2;
      set
      {
        if (value == 0U)
          value = 1U;
        _seq.Value = (uint) ((int) _seq.Value & 3 | (int) value << 2);
      }
    }

    public ulong UID
    {
      get => _uid.Value & 281474976710655UL;
      set
      {
        _uid.Value = (ulong) ((long) _uid.Value & -281474976710656L | (long) value & 281474976710655L);
      }
    }

    public void SetEquipment(ItemType itemType, ItemDataBase item)
    {
      switch (itemType)
      {
        case ItemType.Weapon:
          EquipmentWeapon = item;
          break;
        case ItemType.Shield:
          EquipmentShield = item;
          break;
        case ItemType.Head:
          EquipmentHead = item;
          break;
        case ItemType.UpperBody:
          EquipmentUpperBody = item;
          break;
        case ItemType.Arm:
          EquipmentArm = item;
          break;
        case ItemType.LowerBody:
          EquipmentLowerBody = item;
          break;
        case ItemType.Shoe:
          EquipmentShoe = item;
          break;
        case ItemType.Accessory:
          EquipmentAccessory = item;
          break;
      }
    }

    public void OnLoaded() => _treasureMapData.CalculateDetail();

    public void OnUndo() => _treasureMapData.CalculateDetail();

    public void OnRedo() => _treasureMapData.CalculateDetail();

    public byte[] GetBytesData()
    {
      byte[] destinationArray = new byte[232];
      Array.Copy(SaveDataManager.Instance.SaveData.Data, (uint) (16200 + 232 * (int) _index), destinationArray, 0L, 232L);
      return destinationArray;
    }

    public void Copy(byte[] srcData)
    {
      srcData.CopyTo(SaveDataManager.Instance.SaveData.Data, (uint) (16200 + 232 * (int) _index));
      _treasureMapData.CalculateDetail();
    }

    public void Clear()
    {
      SaveDataManager.Instance.UndoRedoMgr.Edited(new UndoRedoVisitorDataClear(_index));
      byte[] sourceArray1 = new byte[28]
      {
        207,
        50,
        87,
        63,
        60,
        35,
        40,
        35,
        byte.MaxValue,
        byte.MaxValue,
        224,
        66,
        byte.MaxValue,
        byte.MaxValue,
        36,
        78,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        4,
        0,
        183,
        54,
        0,
        16,
        0,
        16
      };
      byte[] sourceArray2 = new byte[8]
      {
        208,
        23,
        1,
        64,
        byte.MaxValue,
        89,
        18,
        22
      };
      Array.Clear(SaveDataManager.Instance.SaveData.Data, 16200 + 232 * (int) _index, 232);
      SaveDataManager.Instance.SaveData.Data[16200 + 232 * (int) _index + 12] = (byte) ((int) (_index / 6U) + 2 << 4);
      Array.Copy(sourceArray1, 0, SaveDataManager.Instance.SaveData.Data, 16200 + 232 * (int) _index + 26, 28);
      Array.Copy(sourceArray2, 0, SaveDataManager.Instance.SaveData.Data, 16200 + 232 * (int) _index + 108, 8);
    }

    public void OnCreate()
    {
      _visible.Value = (ushort) (_visible.Value & 64512 | 576);
      ProfileSetting = true;
    }
  }
}
