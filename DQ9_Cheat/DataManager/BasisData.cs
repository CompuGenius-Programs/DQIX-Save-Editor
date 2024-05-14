// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.BasisData
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
  internal class BasisData
  {
    private DataValue<byte> _afterEnding;
    private DataValue<ushort> _savePlace;
    private DataValue<byte> _profileExplanation;
    private DataValue<byte> _profileSetting_Sex;
    private DataValue<ushort> _profileTone;
    private DataValue<ushort> _profileBirthYearMonth;
    private DataValue<byte> _profileBirthDay;
    private DataValue<byte> _profileSecretAge;
    private DataValue<ushort> _handle;
    private DataValue<ushort> _address;
    private DataValueString _profileMessage;
    private DataValue<ushort> _playTimeHour;
    private DataValue<byte> _playTimeMinute;
    private DataValue<byte> _playTimeSecond;
    private DataValue<ushort> _multiPlayTimeHour;
    private DataValue<byte> _multiPlayTimeMinute;
    private DataValue<byte> _multiPlayTimeSecond;
    private DataValue<uint> _money;
    private DataValue<uint> _bankMoney;
    private DataValue<uint> _medal;
    private DataValue<uint> _battleCount;
    private DataValue<uint> _loseCount;
    private DataValue<uint> _escapeCount;
    private DataValue<uint> _escapeSuccessCount;
    private DataValue<uint> _victoryCount;
    private DataValue<int> _alchemyCount;
    private DataValue<byte> _gestureLearn1;
    private DataValue<byte> _gestureLearn2;
    private DataValue<byte> _gestureLearn3;
    private DataValue<byte> _gestureUp;
    private DataValue<byte> _gestureLeft;
    private DataValue<byte> _gestureRight;
    private DataValue<byte> _gestureDown1;
    private DataValue<byte> _gestureDown2;
    private DataValue<byte> _gestureDown3;
    private DataValue<byte> _gestureDown4;
    private DataValue<ushort> _intermissionPlace;
    private DataValue<int> _intermissionX;
    private DataValue<int> _intermissionY;
    private DataValue<int> _intermissionZ;

    public BasisData(SaveData owner)
    {
      BasisDataControl basisDataControl = MainWindow.Instance.BasisDataControl;
      basisDataControl.BeginUpdate();
      this._intermissionPlace = new DataValue<ushort>(owner, 27104U, (Control) null, (ushort) 0, ushort.MaxValue);
      this._intermissionX = new DataValue<int>(owner, 27108U, (Control) null, int.MinValue, int.MaxValue);
      this._intermissionY = new DataValue<int>(owner, 27112U, (Control) null, int.MinValue, int.MaxValue);
      this._intermissionZ = new DataValue<int>(owner, 27116U, (Control) null, int.MinValue, int.MaxValue);
      this._afterEnding = new DataValue<byte>(owner, 12276U, (Control) null, (byte) 0, byte.MaxValue);
      this._savePlace = new DataValue<ushort>(owner, 11476U, (Control) null, (ushort) 0, ushort.MaxValue);
      this._profileExplanation = new DataValue<byte>(owner, 26987U, (Control) null, (byte) 0, byte.MaxValue);
      this._profileSetting_Sex = new DataValue<byte>(owner, 26983U, (Control) null, (byte) 0, byte.MaxValue);
      this._profileTone = new DataValue<ushort>(owner, 26982U, (Control) null, (ushort) 0, ushort.MaxValue);
      this._profileBirthYearMonth = new DataValue<ushort>(owner, 26980U, (Control) null, (ushort) 0, ushort.MaxValue);
      basisDataControl.NumericUpDown_ProfileBirthYear.Maximum = 4096M;
      basisDataControl.NumericUpDown_ProfileBirthYear.Minimum = 0M;
      basisDataControl.NumericUpDown_ProfileBirthMonth.Maximum = 12M;
      basisDataControl.NumericUpDown_ProfileBirthMonth.Minimum = 1M;
      this._profileBirthDay = new DataValue<byte>(owner, 26982U, (Control) null, (byte) 0, byte.MaxValue);
      basisDataControl.NumericUpDown_ProfileBirthDay.Maximum = 31M;
      basisDataControl.NumericUpDown_ProfileBirthDay.Minimum = 1M;
      this._address = new DataValue<ushort>(owner, 26985U, (Control) null, (ushort) 0, ushort.MaxValue);
      this._handle = new DataValue<ushort>(owner, 26986U, (Control) null, (ushort) 0, ushort.MaxValue);
      byte[] fillData = new byte[2]{ (byte) 129, (byte) 69 };
      this._profileMessage = new DataValueString(owner, 26988U, (Control) null, 114, false, fillData);
      this._profileSecretAge = new DataValue<byte>(owner, 26983U, (Control) basisDataControl.CheckBox_SecretAge, (byte) 0, byte.MaxValue);
      this._playTimeHour = new DataValue<ushort>(owner, 16024U, (Control) null, (ushort) 0, ushort.MaxValue);
      basisDataControl.NumericUpDown_Hour.Maximum = (Decimal) this._playTimeHour.Max;
      basisDataControl.NumericUpDown_Hour.Minimum = (Decimal) this._playTimeHour.Min;
      this._playTimeMinute = new DataValue<byte>(owner, 16026U, (Control) null, (byte) 0, (byte) 59);
      basisDataControl.NumericUpDown_Minute.Maximum = (Decimal) this._playTimeMinute.Max;
      basisDataControl.NumericUpDown_Minute.Minimum = (Decimal) this._playTimeMinute.Min;
      this._playTimeSecond = new DataValue<byte>(owner, 16027U, (Control) null, (byte) 0, (byte) 59);
      basisDataControl.NumericUpDown_Second.Maximum = (Decimal) this._playTimeSecond.Max;
      basisDataControl.NumericUpDown_Second.Minimum = (Decimal) this._playTimeSecond.Min;
      this._multiPlayTimeHour = new DataValue<ushort>(owner, 16028U, (Control) null, (ushort) 0, ushort.MaxValue);
      basisDataControl.NumericUpDown_MultiPlayTimeHour.Maximum = (Decimal) this._multiPlayTimeHour.Max;
      basisDataControl.NumericUpDown_MultiPlayTimeHour.Minimum = (Decimal) this._multiPlayTimeHour.Min;
      this._multiPlayTimeMinute = new DataValue<byte>(owner, 16030U, (Control) null, (byte) 0, (byte) 59);
      basisDataControl.NumericUpDown_MultiPlayTimeMinute.Maximum = (Decimal) this._multiPlayTimeMinute.Max;
      basisDataControl.NumericUpDown_MultiPlayTimeMinute.Minimum = (Decimal) this._multiPlayTimeMinute.Min;
      this._multiPlayTimeSecond = new DataValue<byte>(owner, 16031U, (Control) null, (byte) 0, (byte) 59);
      basisDataControl.NumericUpDown_MultiPlayTimeSecond.Maximum = (Decimal) this._multiPlayTimeSecond.Max;
      basisDataControl.NumericUpDown_MultiPlayTimeSecond.Minimum = (Decimal) this._multiPlayTimeSecond.Min;
      this._money = new DataValue<uint>(owner, 11448U, (Control) null, 0U, 9999999U);
      basisDataControl.NumericUpDown_Money.Maximum = (Decimal) this._money.Max;
      basisDataControl.NumericUpDown_Money.Minimum = (Decimal) this._money.Min;
      this._bankMoney = new DataValue<uint>(owner, 11452U, (Control) null, 0U, 1000000000U);
      basisDataControl.NumericUpDown_BankMoney.Maximum = (Decimal) this._bankMoney.Max;
      basisDataControl.NumericUpDown_BankMoney.Minimum = (Decimal) this._bankMoney.Min;
      this._medal = new DataValue<uint>(owner, 11460U, (Control) null, 0U, 500U);
      basisDataControl.NumericUpDown_Medal.Maximum = (Decimal) this._medal.Max;
      basisDataControl.NumericUpDown_Medal.Minimum = (Decimal) this._medal.Min;
      this._battleCount = new DataValue<uint>(owner, 16084U, (Control) null, 0U, uint.MaxValue);
      basisDataControl.NumericUpDown_BattleCount.Minimum = (Decimal) this._battleCount.Min;
      basisDataControl.NumericUpDown_BattleCount.Maximum = 16777215M;
      this._loseCount = new DataValue<uint>(owner, 16088U, (Control) null, 0U, uint.MaxValue);
      basisDataControl.NumericUpDown_LoseCount.Minimum = (Decimal) this._loseCount.Min;
      basisDataControl.NumericUpDown_LoseCount.Maximum = 16777215M;
      this._escapeCount = new DataValue<uint>(owner, 16076U, (Control) null, 0U, uint.MaxValue);
      basisDataControl.NumericUpDown_EscapeCount.Minimum = (Decimal) this._escapeCount.Min;
      basisDataControl.NumericUpDown_EscapeCount.Maximum = 16777215M;
      this._escapeSuccessCount = new DataValue<uint>(owner, 16080U, (Control) null, 0U, uint.MaxValue);
      basisDataControl.NumericUpDown_EscapeSuccessCount.Minimum = (Decimal) this._escapeSuccessCount.Min;
      basisDataControl.NumericUpDown_EscapeSuccessCount.Maximum = 16777215M;
      this._victoryCount = new DataValue<uint>(owner, 16032U, (Control) null, 0U, uint.MaxValue);
      basisDataControl.NumericUpDown_VictoryCount.Minimum = 0M;
      basisDataControl.NumericUpDown_VictoryCount.Maximum = 16777215M;
      this._alchemyCount = new DataValue<int>(owner, 15016U, (Control) null, 0, int.MaxValue);
      basisDataControl.NumericUpDown_AlchemyCount.Minimum = (Decimal) this._alchemyCount.Min;
      basisDataControl.NumericUpDown_AlchemyCount.Maximum = (Decimal) this._alchemyCount.Max;
      this._gestureLearn1 = new DataValue<byte>(owner, 12108U, (Control) null, (byte) 0, byte.MaxValue);
      this._gestureLearn2 = new DataValue<byte>(owner, 12109U, (Control) null, (byte) 0, byte.MaxValue);
      this._gestureLearn3 = new DataValue<byte>(owner, 12110U, (Control) null, (byte) 0, byte.MaxValue);
      this._gestureUp = new DataValue<byte>(owner, 11468U, (Control) null, (byte) 0, byte.MaxValue);
      this._gestureLeft = new DataValue<byte>(owner, 11469U, (Control) null, (byte) 0, byte.MaxValue);
      this._gestureRight = new DataValue<byte>(owner, 11470U, (Control) null, (byte) 0, byte.MaxValue);
      this._gestureDown1 = new DataValue<byte>(owner, 11471U, (Control) null, (byte) 0, byte.MaxValue);
      this._gestureDown2 = new DataValue<byte>(owner, 11472U, (Control) null, (byte) 0, byte.MaxValue);
      this._gestureDown3 = new DataValue<byte>(owner, 11473U, (Control) null, (byte) 0, byte.MaxValue);
      this._gestureDown4 = new DataValue<byte>(owner, 11474U, (Control) null, (byte) 0, byte.MaxValue);
      basisDataControl.EndUpdate();
    }

    public SavePlace SavePlace
    {
      get
      {
        return ((int) this._afterEnding.Value & 4) == 0 ? SavePlaceList.GetSavePlace(this._savePlace.Value) : SavePlaceList.GetSavePlace(ushort.MaxValue);
      }
      set
      {
        if (value.Index == ushort.MaxValue)
        {
          this._afterEnding.Value = (byte) ((int) this._afterEnding.Value & 251 | 4);
          this._savePlace.Value = (ushort) 109;
        }
        else
        {
          this._afterEnding.Value &= (byte) 251;
          this._savePlace.Value = value.Index;
        }
      }
    }

    public bool ProfileExplanation
    {
      get => ((int) this._profileExplanation.Value & 64) != 0;
      set
      {
        this._profileExplanation.Value = (byte) ((int) this._profileExplanation.Value & 191 | (value ? 64 : 0));
      }
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

    public bool ProfileToneSetting
    {
      get => ((int) this._profileTone.Value & 2048) != 0;
      set
      {
        this._profileTone.Value = (ushort) ((int) this._profileTone.Value & 63487 | (value ? 2048 : 0));
      }
    }

    public ushort ProfileBirthYear
    {
      get => (ushort) ((uint) this._profileBirthYearMonth.Value & 4095U);
      set
      {
        this._profileBirthYearMonth.Value = (ushort) ((int) value & 4095 | (int) this.ProfileBirthMonth << 12);
      }
    }

    public byte ProfileBirthMonth
    {
      get => (byte) ((uint) this._profileBirthYearMonth.Value >> 12);
      set
      {
        this._profileBirthYearMonth.Value = (ushort) ((int) this.ProfileBirthYear & 4095 | (int) value << 12);
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
          num = (ushort) (value.Job.Index << 3 & 16376);
        }
        else
        {
          if (value.HandleType != HandleType.HandleTitle || value.Title == null)
            return;
          num = (ushort) (value.Title.DataIndex << 3 & 16376);
        }
        this._handle.Value = (ushort) ((uint) this._handle.Value & 49159U | (uint) num);
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

    public DataValueString ProfileMessage => this._profileMessage;

    public DataValue<ushort> PlayTimeHour => this._playTimeHour;

    public DataValue<byte> PlayTimeMinute => this._playTimeMinute;

    public DataValue<byte> PlayTimeSecond => this._playTimeSecond;

    public DataValue<ushort> MultiPlayTimeHour => this._multiPlayTimeHour;

    public DataValue<byte> MultiPlayTimeMinute => this._multiPlayTimeMinute;

    public DataValue<byte> MultiPlayTimeSecond => this._multiPlayTimeSecond;

    public DataValue<uint> Money => this._money;

    public DataValue<uint> BankMoney => this._bankMoney;

    public DataValue<uint> Medal => this._medal;

    public uint BattleCount
    {
      get => this._battleCount.Value & 16777215U;
      set
      {
        this._battleCount.Value = (uint) ((int) this._battleCount.Value & -16777216 | (int) value & 16777215);
      }
    }

    public uint LoseCount
    {
      get => this._loseCount.Value & 16777215U;
      set
      {
        this._loseCount.Value = (uint) ((int) this._loseCount.Value & -16777216 | (int) value & 16777215);
      }
    }

    public uint EscapeCount
    {
      get => this._escapeCount.Value & 16777215U;
      set
      {
        this._escapeCount.Value = (uint) ((int) this._escapeCount.Value & -16777216 | (int) value & 16777215);
      }
    }

    public uint EscapeSuccessCount
    {
      get => this._escapeSuccessCount.Value & 16777215U;
      set
      {
        this._escapeSuccessCount.Value = (uint) ((int) this._escapeSuccessCount.Value & -16777216 | (int) value & 16777215);
      }
    }

    public uint VictoryCount
    {
      get => this._victoryCount.Value & 16777215U;
      set
      {
        this._victoryCount.Value = (uint) ((int) this._victoryCount.Value & -16777216 | (int) value & 16777215);
      }
    }

    public DataValue<int> AlchemyCount => this._alchemyCount;

    public bool IsGestureLearn(int index)
    {
      if (index < 6)
        return ((int) this._gestureLearn1.Value & 1 << index + 2) != 0;
      return index < 14 ? ((int) this._gestureLearn2.Value & 1 << index - 6) != 0 : ((int) this._gestureLearn3.Value & 1) != 0;
    }

    public void SetGestureLearn(int index, bool value)
    {
      if (index < 6)
        this._gestureLearn1.Value = (byte) ((int) this._gestureLearn1.Value & ~(1 << index + 2) | (value ? 1 << index + 2 : 0));
      else if (index < 14)
        this._gestureLearn2.Value = (byte) ((int) this._gestureLearn2.Value & ~(1 << index - 6) | (value ? 1 << index - 6 : 0));
      else
        this._gestureLearn3.Value = (byte) ((int) this._gestureLearn3.Value & 254 | (value ? 1 : 0));
    }

    public byte GestureUp
    {
      get => this._gestureUp.Value != byte.MaxValue ? this._gestureUp.Value : (byte) 0;
      set => this._gestureUp.Value = (int) value >= GestureList.List.Count ? byte.MaxValue : value;
    }

    public byte GestureLeft
    {
      get => this._gestureLeft.Value != byte.MaxValue ? this._gestureLeft.Value : (byte) 0;
      set
      {
        this._gestureLeft.Value = (int) value >= GestureList.List.Count ? byte.MaxValue : value;
      }
    }

    public byte GestureRight
    {
      get => this._gestureRight.Value != byte.MaxValue ? this._gestureRight.Value : (byte) 0;
      set
      {
        this._gestureRight.Value = (int) value >= GestureList.List.Count ? byte.MaxValue : value;
      }
    }

    public byte GestureDown1
    {
      get => this._gestureDown1.Value != byte.MaxValue ? this._gestureDown1.Value : (byte) 0;
      set
      {
        this._gestureDown1.Value = (int) value >= GestureList.List.Count ? byte.MaxValue : value;
      }
    }

    public byte GestureDown2
    {
      get => this._gestureDown2.Value != byte.MaxValue ? this._gestureDown2.Value : (byte) 0;
      set
      {
        this._gestureDown2.Value = (int) value >= GestureList.List.Count ? byte.MaxValue : value;
      }
    }

    public byte GestureDown3
    {
      get => this._gestureDown3.Value != byte.MaxValue ? this._gestureDown3.Value : (byte) 0;
      set
      {
        this._gestureDown3.Value = (int) value >= GestureList.List.Count ? byte.MaxValue : value;
      }
    }

    public byte GestureDown4
    {
      get => this._gestureDown4.Value != byte.MaxValue ? this._gestureDown4.Value : (byte) 0;
      set
      {
        this._gestureDown4.Value = (int) value >= GestureList.List.Count ? byte.MaxValue : value;
      }
    }

    public SavePlace IntermissionPlace
    {
      get => SavePlaceList.GetSavePlace(this._intermissionPlace.Value);
      set
      {
        if (value.Index == ushort.MaxValue)
          this._intermissionPlace.Value = (ushort) 100;
        else
          this._intermissionPlace.Value = value.Index;
      }
    }

    public DataValue<int> IntermissionX => this._intermissionX;

    public DataValue<int> IntermissionY => this._intermissionY;

    public DataValue<int> IntermissionZ => this._intermissionZ;
  }
}
