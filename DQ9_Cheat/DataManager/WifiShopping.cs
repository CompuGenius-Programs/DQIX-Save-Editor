// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.WifiShopping
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class WifiShopping
  {
    public const int WifiShopGoodsCount = 6;
    private DataValue<uint> _expiresDateTime;
    private DataValue<uint> _allowNextConnectDateTime;
    private DQ9_Cheat.DataManager.WifiShopGoods[] _wifiShopGoods = new DQ9_Cheat.DataManager.WifiShopGoods[6];
    private DataValue<uint> _messageExpiresDateTime;
    private DataValueString _message;

    public WifiShopping(SaveData owner)
    {
      this._expiresDateTime = new DataValue<uint>(owner, 28084U, (Control) null, 0U, uint.MaxValue);
      this._allowNextConnectDateTime = new DataValue<uint>(owner, 28100U, (Control) null, 0U, uint.MaxValue);
      this._messageExpiresDateTime = new DataValue<uint>(owner, 28096U, (Control) null, 0U, uint.MaxValue);
      this._message = new DataValueString(owner, 23176U, (Control) null, 510, false, new byte[1]);
      for (int index = 0; index < 6; ++index)
        this._wifiShopGoods[index] = new DQ9_Cheat.DataManager.WifiShopGoods(owner, index);
    }

    public ushort ExpiresYear
    {
      get => (ushort) (this._expiresDateTime.Value & 4095U);
      set
      {
        this._expiresDateTime.Value = (uint) ((int) this._expiresDateTime.Value & -4096 | (int) value & 4095);
      }
    }

    public byte ExpiresMonth
    {
      get => (byte) ((this._expiresDateTime.Value & 61440U) >> 12);
      set
      {
        this._expiresDateTime.Value = (uint) ((int) this._expiresDateTime.Value & -61441 | (int) value << 12 & 61440);
      }
    }

    public byte ExpiresDay
    {
      get => (byte) ((this._expiresDateTime.Value & 2031616U) >> 16);
      set
      {
        this._expiresDateTime.Value = (uint) ((int) this._expiresDateTime.Value & -2031617 | (int) value << 16 & 2031616);
      }
    }

    public byte ExpiresHour
    {
      get => (byte) ((this._expiresDateTime.Value & 65011712U) >> 21);
      set
      {
        this._expiresDateTime.Value = (uint) ((int) this._expiresDateTime.Value & -65011713 | (int) value << 21 & 65011712);
      }
    }

    public ushort AllowNextConnectYear
    {
      get => (ushort) (this._allowNextConnectDateTime.Value & 4095U);
      set
      {
        this._allowNextConnectDateTime.Value = (uint) ((int) this._allowNextConnectDateTime.Value & -4096 | (int) value & 4095);
      }
    }

    public byte AllowNextConnectMonth
    {
      get => (byte) ((this._allowNextConnectDateTime.Value & 61440U) >> 12);
      set
      {
        this._allowNextConnectDateTime.Value = (uint) ((int) this._allowNextConnectDateTime.Value & -61441 | (int) value << 12 & 61440);
      }
    }

    public byte AllowNextConnectDay
    {
      get => (byte) ((this._allowNextConnectDateTime.Value & 2031616U) >> 16);
      set
      {
        this._allowNextConnectDateTime.Value = (uint) ((int) this._allowNextConnectDateTime.Value & -2031617 | (int) value << 16 & 2031616);
      }
    }

    public byte AllowNextConnectHour
    {
      get => (byte) ((this._allowNextConnectDateTime.Value & 65011712U) >> 21);
      set
      {
        this._allowNextConnectDateTime.Value = (uint) ((int) this._allowNextConnectDateTime.Value & -65011713 | (int) value << 21 & 65011712);
      }
    }

    public DQ9_Cheat.DataManager.WifiShopGoods[] WifiShopGoods => this._wifiShopGoods;

    public ushort MessageExpiresYear
    {
      get => (ushort) (this._messageExpiresDateTime.Value & 4095U);
      set
      {
        this._messageExpiresDateTime.Value = (uint) ((int) this._messageExpiresDateTime.Value & -4096 | (int) value & 4095);
      }
    }

    public byte MessageExpiresMonth
    {
      get => (byte) ((this._messageExpiresDateTime.Value & 61440U) >> 12);
      set
      {
        this._messageExpiresDateTime.Value = (uint) ((int) this._messageExpiresDateTime.Value & -61441 | (int) value << 12 & 61440);
      }
    }

    public byte MessageExpiresDay
    {
      get => (byte) ((this._messageExpiresDateTime.Value & 2031616U) >> 16);
      set
      {
        this._messageExpiresDateTime.Value = (uint) ((int) this._messageExpiresDateTime.Value & -2031617 | (int) value << 16 & 2031616);
      }
    }

    public byte MessageExpiresHour
    {
      get => (byte) ((this._messageExpiresDateTime.Value & 65011712U) >> 21);
      set
      {
        this._messageExpiresDateTime.Value = (uint) ((int) this._messageExpiresDateTime.Value & -65011713 | (int) value << 21 & 65011712);
      }
    }

    public string Message
    {
      get => this._message.Value.Replace("\\n", "\r\n");
      set => this._message.Value = value.Replace("\r\n", "\\n");
    }

    public int MessageMaxLength => this._message.MaxLength;
  }
}
