// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.WifiShopping
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

namespace DQ9_Cheat.DataManager;

internal class WifiShopping
{
    public const int WifiShopGoodsCount = 6;
    private readonly DataValue<uint> _allowNextConnectDateTime;
    private readonly DataValue<uint> _expiresDateTime;
    private readonly DataValueString _message;
    private readonly DataValue<uint> _messageExpiresDateTime;

    public WifiShopping(SaveData owner)
    {
        _expiresDateTime = new DataValue<uint>(owner, 28084U, null, 0U, uint.MaxValue);
        _allowNextConnectDateTime = new DataValue<uint>(owner, 28100U, null, 0U, uint.MaxValue);
        _messageExpiresDateTime = new DataValue<uint>(owner, 28096U, null, 0U, uint.MaxValue);
        _message = new DataValueString(owner, 23176U, null, 510, false, new byte[1]);
        for (var index = 0; index < 6; ++index)
            WifiShopGoods[index] = new WifiShopGoods(owner, index);
    }

    public ushort ExpiresYear
    {
        get => (ushort)(_expiresDateTime.Value & 4095U);
        set => _expiresDateTime.Value = (uint)(((int)_expiresDateTime.Value & -4096) | (value & 4095));
    }

    public byte ExpiresMonth
    {
        get => (byte)((_expiresDateTime.Value & 61440U) >> 12);
        set => _expiresDateTime.Value = (uint)(((int)_expiresDateTime.Value & -61441) | ((value << 12) & 61440));
    }

    public byte ExpiresDay
    {
        get => (byte)((_expiresDateTime.Value & 2031616U) >> 16);
        set => _expiresDateTime.Value = (uint)(((int)_expiresDateTime.Value & -2031617) | ((value << 16) & 2031616));
    }

    public byte ExpiresHour
    {
        get => (byte)((_expiresDateTime.Value & 65011712U) >> 21);
        set => _expiresDateTime.Value = (uint)(((int)_expiresDateTime.Value & -65011713) | ((value << 21) & 65011712));
    }

    public ushort AllowNextConnectYear
    {
        get => (ushort)(_allowNextConnectDateTime.Value & 4095U);
        set => _allowNextConnectDateTime.Value =
            (uint)(((int)_allowNextConnectDateTime.Value & -4096) | (value & 4095));
    }

    public byte AllowNextConnectMonth
    {
        get => (byte)((_allowNextConnectDateTime.Value & 61440U) >> 12);
        set => _allowNextConnectDateTime.Value =
            (uint)(((int)_allowNextConnectDateTime.Value & -61441) | ((value << 12) & 61440));
    }

    public byte AllowNextConnectDay
    {
        get => (byte)((_allowNextConnectDateTime.Value & 2031616U) >> 16);
        set => _allowNextConnectDateTime.Value =
            (uint)(((int)_allowNextConnectDateTime.Value & -2031617) | ((value << 16) & 2031616));
    }

    public byte AllowNextConnectHour
    {
        get => (byte)((_allowNextConnectDateTime.Value & 65011712U) >> 21);
        set => _allowNextConnectDateTime.Value =
            (uint)(((int)_allowNextConnectDateTime.Value & -65011713) | ((value << 21) & 65011712));
    }

    public WifiShopGoods[] WifiShopGoods { get; } = new WifiShopGoods[6];

    public ushort MessageExpiresYear
    {
        get => (ushort)(_messageExpiresDateTime.Value & 4095U);
        set => _messageExpiresDateTime.Value = (uint)(((int)_messageExpiresDateTime.Value & -4096) | (value & 4095));
    }

    public byte MessageExpiresMonth
    {
        get => (byte)((_messageExpiresDateTime.Value & 61440U) >> 12);
        set => _messageExpiresDateTime.Value =
            (uint)(((int)_messageExpiresDateTime.Value & -61441) | ((value << 12) & 61440));
    }

    public byte MessageExpiresDay
    {
        get => (byte)((_messageExpiresDateTime.Value & 2031616U) >> 16);
        set => _messageExpiresDateTime.Value =
            (uint)(((int)_messageExpiresDateTime.Value & -2031617) | ((value << 16) & 2031616));
    }

    public byte MessageExpiresHour
    {
        get => (byte)((_messageExpiresDateTime.Value & 65011712U) >> 21);
        set => _messageExpiresDateTime.Value =
            (uint)(((int)_messageExpiresDateTime.Value & -65011713) | ((value << 21) & 65011712));
    }

    public string Message
    {
        get => _message.Value.Replace("\\n", "\r\n");
        set => _message.Value = value.Replace("\r\n", "\\n");
    }

    public int MessageMaxLength => _message.MaxLength;
}