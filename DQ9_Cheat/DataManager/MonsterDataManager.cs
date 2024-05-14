// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.MonsterDataManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class MonsterDataManager
  {
    public const int MonsterDataCount = 307;
    private const uint MonsterDataOffset = 13784;
    private DataValue<ushort> _compCount;
    private DataValue<uint>[] _monsterData = new DataValue<uint>[307];

    public MonsterDataManager(SaveData owner)
    {
      for (uint index = 0; index < 307U; ++index)
        this._monsterData[(int) index] = new DataValue<uint>(owner, (uint) (13784 + (int) index * 4), (Control) null, 0U, uint.MaxValue);
      this._compCount = new DataValue<ushort>(owner, 16044U, (Control) null, (ushort) 0, ushort.MaxValue);
    }

    public ushort CompCount => (ushort) ((uint) this._compCount.Value & 511U);

    public void ReviseCompCount()
    {
      ushort num = 0;
      for (int index = 0; index < 307; ++index)
      {
        if (this.GetVictoryCount(index) != (ushort) 0)
          ++num;
      }
      this._compCount.Value = (ushort) ((int) this._compCount.Value & 65024 | (int) num & 511);
    }

    public ushort GetVictoryCount(int index)
    {
      ushort num = (ushort) (this._monsterData[index].Value & 1023U);
      return num <= (ushort) 999 ? num : (ushort) 999;
    }

    public void SetVictoryCount(int index, ushort value)
    {
      if (value > (ushort) 999)
        value = (ushort) 999;
      this._monsterData[index].Value = (uint) ((int) this._monsterData[index].Value & -1024 | (int) value & 1023);
    }

    public bool IsFindOut(int index) => ((int) this._monsterData[index].Value & 1024) != 0;

    public void SetFindOut(int index, bool value)
    {
      this._monsterData[index].Value = (uint) ((int) this._monsterData[index].Value & -1025 | (value ? 1024 : 0));
    }

    public byte GetItemCount1(int index)
    {
      byte num = (byte) ((this._monsterData[index].Value & 260096U) >> 11);
      return num <= (byte) 99 ? num : (byte) 99;
    }

    public void SetItemCount1(int index, byte value)
    {
      if (value > (byte) 99)
        value = (byte) 99;
      this._monsterData[index].Value = (uint) ((int) this._monsterData[index].Value & -260097 | (int) value << 11 & 260096);
    }

    public byte GetItemCount2(int index)
    {
      byte num = (byte) ((this._monsterData[index].Value & 33292288U) >> 18);
      return num <= (byte) 99 ? num : (byte) 99;
    }

    public void SetItemCount2(int index, byte value)
    {
      if (value > (byte) 99)
        value = (byte) 99;
      this._monsterData[index].Value = (uint) ((int) this._monsterData[index].Value & -33292289 | (int) value << 18 & 33292288);
    }
  }
}
