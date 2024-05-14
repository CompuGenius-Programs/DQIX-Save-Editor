// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.CharacterData
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls;
using DQ9_Cheat.GameData;
using System;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class CharacterData
  {
    public const int DataSize = 572;
    private const uint CharacterDataOffset = 136;
    private DataValue<byte> _state;
    private DataValueString _name;
    private DataValue<byte> _sex;
    private DataValue<byte> _job;
    private DataValue<byte>[] _jobLevel = new DataValue<byte>[13];
    private DataValue<uint>[] _jobExperience = new DataValue<uint>[13];
    private DataValue<byte>[] _transmigration = new DataValue<byte>[13];
    private DataValue<byte>[] _jobSkillLevel = new DataValue<byte>[SkillDataList.List.Count];
    private DataValue<byte> _specialtyRuler;
    private DataValue<byte> _specialtyCheer;
    private DataValue<byte>[] _skillSpecialtyEffect = new DataValue<byte>[SkillDataList.SpecialtyEffectMaxIndex / 8 + 1];
    private DataValue<ushort> _nowHP;
    private DataValue<ushort> _maxHP;
    private DataValue<ushort> _nowMP;
    private DataValue<ushort> _maxMP;
    private DataValue<uint>[] _revisePowQuickDef = new DataValue<uint>[13];
    private DataValue<uint>[] _reviseFacSmartRev = new DataValue<uint>[13];
    private DataValue<uint>[] _reviseAtmgcHPMP = new DataValue<uint>[13];
    private DataValue<ushort> _figureWidth;
    private DataValue<ushort> _figureHeight;
    private DataValue<byte> _hairType;
    private DataValue<byte> _hairColor;
    private DataValue<byte> _faceType;
    private DataValue<byte> _skinColor;
    private DataValue<byte> _eyeColor;
    private DataValue<ushort> _equipmentWeapon;
    private DataValue<ushort> _equipmentShield;
    private DataValue<ushort> _equipmentHead;
    private DataValue<ushort> _equipmentUpperBody;
    private DataValue<ushort> _equipmentArm;
    private DataValue<ushort> _equipmentLowerBody;
    private DataValue<ushort> _equipmentShoe;
    private DataValue<ushort> _equipmentAccessory;
    private DataValue<ushort> _skillPoint;
    private DataValue<byte> _strategy;
    private DataValue<byte> _rank;
    private DataValue<byte> _color;
    private uint _index;

    public CharacterData(SaveData owner, uint index)
    {
      CharacterDataControl characterDataControl = MainWindow.Instance.CharacterDataControl;
      this._index = index;
      uint num = 572U * index;
      this._state = new DataValue<byte>(owner, 454U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._name = new DataValueString(owner, 456U + num, (Control) null, 10, true);
      this._sex = new DataValue<byte>(owner, 508U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._job = new DataValue<byte>(owner, 216U + num, (Control) null, (byte) 0, (byte) (JobDataList.List.Count - 1));
      for (int index1 = 0; index1 < 13; ++index1)
      {
        this._jobLevel[index1] = new DataValue<byte>(owner, (uint) ((ulong) (138 + index1) + (ulong) num), (Control) null, (byte) 0, (byte) 99);
        this._jobExperience[index1] = new DataValue<uint>(owner, (uint) ((ulong) (164 + 4 * index1) + (ulong) num), (Control) null, 0U, 999999999U);
        this._transmigration[index1] = new DataValue<byte>(owner, (uint) ((ulong) (151 + index1) + (ulong) num), (Control) null, (byte) 0, byte.MaxValue);
        this._revisePowQuickDef[index1] = new DataValue<uint>(owner, (uint) ((ulong) (224U + num) + (ulong) (12 * index1)), (Control) null, 0U, uint.MaxValue);
        this._reviseFacSmartRev[index1] = new DataValue<uint>(owner, (uint) ((ulong) (228U + num) + (ulong) (12 * index1)), (Control) null, 0U, uint.MaxValue);
        this._reviseAtmgcHPMP[index1] = new DataValue<uint>(owner, (uint) ((ulong) (232U + num) + (ulong) (12 * index1)), (Control) null, 0U, uint.MaxValue);
      }
      for (int index2 = 0; index2 < SkillDataList.List.Count; ++index2)
        this._jobSkillLevel[index2] = new DataValue<byte>(owner, (uint) ((ulong) (383U + num) + (ulong) index2), (Control) null, (byte) 0, (byte) 100);
      this._specialtyRuler = new DataValue<byte>(owner, 416U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._specialtyCheer = new DataValue<byte>(owner, 453U + num, (Control) null, (byte) 0, byte.MaxValue);
      for (int index3 = 0; index3 < SkillDataList.SpecialtyEffectMaxIndex / 8 + 1; ++index3)
        this._skillSpecialtyEffect[index3] = new DataValue<byte>(owner, (uint) ((ulong) (418 + index3) + (ulong) num), (Control) null, (byte) 0, byte.MaxValue);
      this._nowHP = new DataValue<ushort>(owner, 477U + num, (Control) characterDataControl.NumericUpDown_NowHP, (ushort) 0, ushort.MaxValue);
      this._maxHP = new DataValue<ushort>(owner, 480U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._nowMP = new DataValue<ushort>(owner, 478U + num, (Control) characterDataControl.NumericUpDown_NowMP, (ushort) 0, ushort.MaxValue);
      this._maxMP = new DataValue<ushort>(owner, 481U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._figureWidth = new DataValue<ushort>(owner, 512U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._figureHeight = new DataValue<ushort>(owner, 514U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._hairType = new DataValue<byte>(owner, 494U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._hairColor = new DataValue<byte>(owner, 509U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._faceType = new DataValue<byte>(owner, 492U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._skinColor = new DataValue<byte>(owner, 508U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._eyeColor = new DataValue<byte>(owner, 508U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._equipmentWeapon = new DataValue<ushort>(owner, 502U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentShield = new DataValue<ushort>(owner, 504U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentHead = new DataValue<ushort>(owner, 500U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentUpperBody = new DataValue<ushort>(owner, 488U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentArm = new DataValue<ushort>(owner, 496U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentLowerBody = new DataValue<ushort>(owner, 490U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentShoe = new DataValue<ushort>(owner, 498U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentAccessory = new DataValue<ushort>(owner, 506U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._equipmentWeapon = new DataValue<ushort>(owner, 502U + num, (Control) null, (ushort) 0, ushort.MaxValue);
      this._skillPoint = new DataValue<ushort>(owner, 380U + num, (Control) null, (ushort) 0, (ushort) 9999);
      this._strategy = new DataValue<byte>(owner, 455U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._rank = new DataValue<byte>(owner, 137U + num, (Control) null, (byte) 0, byte.MaxValue);
      this._color = new DataValue<byte>(owner, 137U + num, (Control) null, (byte) 0, byte.MaxValue);
      if (index != 0U)
        return;
      characterDataControl.BeginUpdate();
      characterDataControl.NumericUpDown_Level.Minimum = (Decimal) this._jobLevel[0].Min;
      characterDataControl.NumericUpDown_Level.Maximum = (Decimal) this._jobLevel[0].Max;
      characterDataControl.NumericUpDown_Experience.Minimum = (Decimal) this._jobExperience[0].Min;
      characterDataControl.NumericUpDown_Experience.Maximum = (Decimal) this._jobExperience[0].Max;
      characterDataControl.NumericUpDown_NowHP.Maximum = 999M;
      characterDataControl.NumericUpDown_NowHP.Minimum = (Decimal) this._nowHP.Min;
      characterDataControl.NumericUpDown_NowMP.Maximum = 999M;
      characterDataControl.NumericUpDown_NowMP.Minimum = (Decimal) this._nowHP.Min;
      characterDataControl.NumericUpDown_FigureWidth.Maximum = (Decimal) this._figureWidth.Max;
      characterDataControl.NumericUpDown_FigureWidth.Minimum = (Decimal) this._figureWidth.Min;
      characterDataControl.NumericUpDown_FigureHeight.Maximum = (Decimal) this._figureHeight.Max;
      characterDataControl.NumericUpDown_FigureHeight.Minimum = (Decimal) this._figureHeight.Min;
      characterDataControl.NumericUpDown_Hair.Maximum = (Decimal) this._hairType.Max;
      characterDataControl.NumericUpDown_Hair.Minimum = (Decimal) this._hairType.Min;
      characterDataControl.NumericUpDown_HairColor.Maximum = (Decimal) this._hairColor.Max;
      characterDataControl.NumericUpDown_HairColor.Minimum = (Decimal) this._hairColor.Min;
      characterDataControl.NumericUpDown_Face.Maximum = (Decimal) this._faceType.Max;
      characterDataControl.NumericUpDown_Face.Minimum = (Decimal) this._faceType.Min;
      characterDataControl.NumericUpDown_SkinColor.Maximum = 7M;
      characterDataControl.NumericUpDown_SkinColor.Minimum = 0M;
      characterDataControl.NumericUpDown_EyeColor.Maximum = 15M;
      characterDataControl.NumericUpDown_EyeColor.Minimum = 0M;
      characterDataControl.NumericUpDown_SkillPoint.Maximum = (Decimal) this._skillPoint.Max;
      characterDataControl.NumericUpDown_SkillPoint.Minimum = (Decimal) this._skillPoint.Min;
      characterDataControl.EndUpdate();
    }

    public bool Die
    {
      get => ((int) this._state.Value & 1) != 0;
      set => this._state.Value = (byte) ((int) this._state.Value & 254 | (value ? 1 : 0));
    }

    public bool Poison
    {
      get => ((int) this._state.Value & 2) != 0;
      set => this._state.Value = (byte) ((int) this._state.Value & 253 | (value ? 2 : 0));
    }

    public bool Curse
    {
      get => ((int) this._state.Value & 4) != 0;
      set => this._state.Value = (byte) ((int) this._state.Value & 251 | (value ? 4 : 0));
    }

    public DataValueString Name => this._name;

    public byte Sex
    {
      get => (byte) ((uint) this._sex.Value & 1U);
      set => this._sex.Value = (byte) ((int) this._sex.Value & 254 | (value == (byte) 0 ? 0 : 1));
    }

    public DataValue<byte> Job => this._job;

    public DataValue<byte>[] JobLevel => this._jobLevel;

    public DataValue<uint>[] JobExperience => this._jobExperience;

    public byte GetTransmigration(int index)
    {
      return this._transmigration[index].Value <= (byte) 10 ? this._transmigration[index].Value : (byte) 10;
    }

    public void SetTransmigration(int index, byte value)
    {
      this._transmigration[index].Value = (byte) ((int) this._transmigration[index].Value & 240 | (value > (byte) 10 ? 10 : (int) value));
    }

    public DataValue<byte>[] JobSkillLevel => this._jobSkillLevel;

    public bool IsLearnRular() => ((int) this._specialtyRuler.Value & 16) != 0;

    public void SetLearnRular(bool value)
    {
      this._specialtyRuler.Value = (byte) ((int) this._specialtyRuler.Value & 239 | (value ? 16 : 0));
    }

    public bool IsLearnCheer() => ((int) this._specialtyCheer.Value & 64) != 0;

    public void SetLearnCheer(bool value)
    {
      this._specialtyCheer.Value = (byte) ((int) this._specialtyCheer.Value & 191 | (value ? 64 : 0));
    }

    public bool IsLearnSkillSpecialtyEffect(int index)
    {
      return ((int) this._skillSpecialtyEffect[index / 8].Value & 1 << index % 8) != 0;
    }

    public void SetLearnSkillSpecialtyEffect(int index, bool value)
    {
      byte num = (byte) ~(1 << index % 8);
      this._skillSpecialtyEffect[index / 8].Value = (byte) ((int) this._skillSpecialtyEffect[index / 8].Value & (int) num | (value ? (int) ~num : 0));
    }

    public ushort NowHP
    {
      get => (ushort) (((int) this._nowHP.Value & 4092) >> 2);
      set => this._nowHP.Value = (ushort) ((int) this._nowHP.Value & 61443 | (int) value << 2);
    }

    public ushort MaxHP
    {
      get => (ushort) ((uint) this._maxHP.Value & 1023U);
      set => this._maxHP.Value = (ushort) ((uint) this._maxHP.Value & 64512U | (uint) value);
    }

    public ushort NowMP
    {
      get => (ushort) (((int) this._nowMP.Value & 65520) >> 4);
      set => this._nowMP.Value = (ushort) ((int) this._nowMP.Value & 15 | (int) value << 4);
    }

    public ushort MaxMP
    {
      get => (ushort) (((int) this._maxMP.Value & 4092) >> 2);
      set => this._maxMP.Value = (ushort) ((int) this._maxMP.Value & 61443 | (int) value << 2);
    }

    public ushort GetRevisePower(int index)
    {
      return index >= 0 && index < 13 ? (ushort) (this._revisePowQuickDef[index].Value & 1023U) : (ushort) 0;
    }

    public void SetRevisePower(int index, ushort value)
    {
      if (index < 0 || index >= 13)
        return;
      this._revisePowQuickDef[index].Value = this._revisePowQuickDef[index].Value & 4294966272U | (uint) value;
    }

    public ushort GetReviseQuick(int index)
    {
      return index >= 0 && index < 13 ? (ushort) ((this._revisePowQuickDef[index].Value & 1047552U) >> 10) : (ushort) 0;
    }

    public void SetReviseQuick(int index, ushort value)
    {
      if (index < 0 || index >= 13)
        return;
      this._revisePowQuickDef[index].Value = (uint) ((int) this._revisePowQuickDef[index].Value & -1047553 | (int) value << 10);
    }

    public ushort GetReviseDefense(int index)
    {
      return index >= 0 && index < 13 ? (ushort) ((this._revisePowQuickDef[index].Value & 1072693248U) >> 20) : (ushort) 0;
    }

    public void SetReviseDefense(int index, ushort value)
    {
      if (index < 0 || index >= 13)
        return;
      this._revisePowQuickDef[index].Value = (uint) ((int) this._revisePowQuickDef[index].Value & -1072693249 | (int) value << 20);
    }

    public ushort GetReviseFacility(int index)
    {
      return index >= 0 && index < 13 ? (ushort) (this._reviseFacSmartRev[index].Value & 1023U) : (ushort) 0;
    }

    public void SetReviseFacility(int index, ushort value)
    {
      if (index < 0 || index >= 13)
        return;
      this._reviseFacSmartRev[index].Value = this._reviseFacSmartRev[index].Value & 4294966272U | (uint) value;
    }

    public ushort GetReviseSmart(int index)
    {
      return index >= 0 && index < 13 ? (ushort) ((this._reviseFacSmartRev[index].Value & 1047552U) >> 10) : (ushort) 0;
    }

    public void SetReviseSmart(int index, ushort value)
    {
      if (index < 0 || index >= 13)
        return;
      this._reviseFacSmartRev[index].Value = (uint) ((int) this._reviseFacSmartRev[index].Value & -1047553 | (int) value << 10);
    }

    public ushort GetReviseRevivalMagic(int index)
    {
      return index >= 0 && index < 13 ? (ushort) ((this._reviseFacSmartRev[index].Value & 1072693248U) >> 20) : (ushort) 0;
    }

    public void SetReviseRevivalMagic(int index, ushort value)
    {
      if (index < 0 || index >= 13)
        return;
      this._reviseFacSmartRev[index].Value = (uint) ((int) this._reviseFacSmartRev[index].Value & -1072693249 | (int) value << 20);
    }

    public ushort GetReviseAttackMagic(int index)
    {
      return index >= 0 && index < 13 ? (ushort) (this._reviseAtmgcHPMP[index].Value & 1023U) : (ushort) 0;
    }

    public void SetReviseAttackMagic(int index, ushort value)
    {
      if (index < 0 || index >= 13)
        return;
      this._reviseAtmgcHPMP[index].Value = this._reviseAtmgcHPMP[index].Value & 4294966272U | (uint) value;
    }

    public ushort GetReviseMaxHP(int index)
    {
      return index >= 0 && index < 13 ? (ushort) ((this._reviseAtmgcHPMP[index].Value & 1047552U) >> 10) : (ushort) 0;
    }

    public void SetReviseMaxHP(int index, ushort value)
    {
      if (index < 0 || index >= 13)
        return;
      this._reviseAtmgcHPMP[index].Value = (uint) ((int) this._reviseAtmgcHPMP[index].Value & -1047553 | (int) value << 10);
    }

    public ushort GetReviseMaxMP(int index)
    {
      return index >= 0 && index < 13 ? (ushort) ((this._reviseAtmgcHPMP[index].Value & 1072693248U) >> 20) : (ushort) 0;
    }

    public void SetReviseMaxMP(int index, ushort value)
    {
      if (index < 0 || index >= 13)
        return;
      this._reviseAtmgcHPMP[index].Value = (uint) ((int) this._reviseAtmgcHPMP[index].Value & -1072693249 | (int) value << 20);
    }

    public DataValue<ushort> FigureWidth => this._figureWidth;

    public DataValue<ushort> FigureHeight => this._figureHeight;

    public DataValue<byte> HairType => this._hairType;

    public DataValue<byte> HairColor => this._hairColor;

    public DataValue<byte> FaceType => this._faceType;

    public byte SkinColor
    {
      get => (byte) (((int) this._skinColor.Value & 14) >> 1);
      set => this._skinColor.Value = (byte) ((int) this._skinColor.Value & 241 | (int) value << 1);
    }

    public byte EyeColor
    {
      get => (byte) (((int) this._eyeColor.Value & 240) >> 4);
      set => this._eyeColor.Value = (byte) ((int) this._eyeColor.Value & 15 | (int) value << 4);
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

    public DataValue<ushort> SkillPoint => this._skillPoint;

    public Strategy Strategy
    {
      get => StrategyList.GetStrategy(this._strategy.Value);
      set
      {
        this._strategy.Value = (byte) ((uint) this._strategy.Value & 199U | (uint) value.Value);
      }
    }

    public byte Rank
    {
      get => (byte) ((int) this._rank.Value >> 4 & 1);
      set => this._rank.Value = (byte) ((int) this._rank.Value & 15 | (value == (byte) 0 ? 0 : 16));
    }

    public byte Color
    {
      get => (byte) ((uint) this._color.Value & 15U);
      set => this._color.Value = (byte) ((int) this._color.Value & 240 | (int) value & 15);
    }

    public uint Index => this._index;

    public byte[] GetBytesData()
    {
      byte[] destinationArray = new byte[572];
      Array.Copy((Array) SaveDataManager.Instance.SaveData.Data, (long) (uint) (136 + 572 * (int) this._index), (Array) destinationArray, 0L, 572L);
      return destinationArray;
    }

    public void Copy(byte[] srcData)
    {
      srcData.CopyTo((Array) SaveDataManager.Instance.SaveData.Data, (long) (uint) (136 + 572 * (int) this._index));
    }

    public void Clear()
    {
      SaveDataManager.Instance.UndoRedoMgr.Edited((UndoRedoElement) new UndoRedoCharacterDataClear(this._index));
      Array.Clear((Array) SaveDataManager.Instance.SaveData.Data, 136 + 572 * (int) this._index, 572);
    }

    public void InitNewChara()
    {
      byte[] data = SaveDataManager.Instance.SaveData.Data;
      uint num = (uint) (136 + 572 * (int) this._index);
      data[(int) (num + 1U)] = (byte) 12;
      data[(int) (num + 80U)] = (byte) 1;
      data[(int) (num + 84U)] = (byte) 2;
      for (int index = 7; index < 46; ++index)
        data[(int) ((long) (num + 91U) + (long) ((index - 7) * 4))] = index % 4 != 0 ? (byte) 192 : (index % 8 != 0 ? (byte) 128 : (byte) 0);
      for (int index = 0; index < 13; ++index)
        data[(long) (num + 2U) + (long) index] = (byte) 1;
      data[(int) (num + 319U)] = (byte) 40;
      byte[] sourceArray = new byte[48]
      {
        (byte) 18,
        (byte) 16,
        (byte) 32,
        (byte) 1,
        (byte) 5,
        (byte) 16,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 104,
        (byte) 64,
        (byte) 0,
        (byte) 26,
        (byte) 16,
        (byte) 144,
        (byte) 1,
        (byte) 22,
        (byte) 72,
        (byte) 0,
        (byte) 2,
        (byte) 205,
        (byte) 50,
        (byte) 85,
        (byte) 63,
        (byte) 60,
        (byte) 35,
        (byte) 40,
        (byte) 35,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 254,
        (byte) 67,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 36,
        (byte) 78,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 6,
        (byte) 240,
        (byte) 181,
        (byte) 54,
        (byte) 10,
        (byte) 15,
        (byte) 174,
        (byte) 15
      };
      Array.Copy((Array) sourceArray, 0L, (Array) data, (long) (num + 332U), (long) sourceArray.Length);
      for (int index = 0; index < 192; ++index)
        data[(long) num + (long) index + 380L] = byte.MaxValue;
    }
  }
}
