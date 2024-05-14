// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.TreasureMapManager
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class TreasureMapManager
  {
    public const int MapCountMax = 99;
    private DataValue<uint> _clearCount;
    private DataValue<byte> _mapCount;
    private TreasureMapData[] _mapData = new TreasureMapData[99];

    public TreasureMapManager(SaveData owner)
    {
      this._clearCount = new DataValue<uint>(owner, 16037U, (Control) null, 0U, uint.MaxValue);
      this._mapCount = new DataValue<byte>(owner, 24204U, (Control) null, (byte) 0, (byte) 99);
      for (int index = 0; index < 99; ++index)
        this._mapData[index] = new TreasureMapData(owner, (uint) (24206 + 28 * index));
    }

    public ushort ClearCount
    {
      get => (ushort) ((this._clearCount.Value & 1048512U) >> 6);
      set
      {
        this._clearCount.Value = (uint) ((int) this._clearCount.Value & -1048513 | (int) value << 6 & 1048512);
      }
    }

    public byte MapCount => this._mapCount.Value;

    public TreasureMapData GetMapData(int index)
    {
      return index >= 0 && index < (int) this._mapCount.Value ? this._mapData[index] : (TreasureMapData) null;
    }

    public bool CreateMapData()
    {
      if (this._mapCount.Value >= (byte) 99)
        return false;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      ++this._mapCount.Value;
      this._mapData[(int) this._mapCount.Value - 1].InitNewMap();
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      return true;
    }

    public void DeleteMapData(int index)
    {
      if (index < 0 || index >= (int) this._mapCount.Value)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this.MoveTo(index, (int) this._mapCount.Value - 1);
      this._mapData[(int) this._mapCount.Value - 1].Clear();
      --this._mapCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
    }

    public void MoveTo(int srcIndex, int toIndex)
    {
      if (srcIndex >= (int) this._mapCount.Value || toIndex >= (int) this._mapCount.Value || srcIndex == toIndex)
        return;
      byte[] bytesData = this._mapData[srcIndex].GetBytesData();
      if (srcIndex > toIndex)
      {
        for (int index = srcIndex; index > toIndex; --index)
          this._mapData[index].Copy(this._mapData[index - 1].GetBytesData());
      }
      else if (srcIndex < toIndex)
      {
        for (int index = srcIndex; index < toIndex; ++index)
          this._mapData[index].Copy(this._mapData[index + 1].GetBytesData());
      }
      this._mapData[toIndex].Copy(bytesData);
      SaveDataManager.Instance.UndoRedoMgr.Edited((UndoRedoElement) new UndoRedoTreasureMapIndexChanged(srcIndex, toIndex));
    }

    public void OnLoaded()
    {
      for (int index = 0; index < 99; ++index)
        this._mapData[index].CalculateDetail();
    }

    public void OnUndo()
    {
      for (int index = 0; index < 99; ++index)
        this._mapData[index].CalculateDetail();
    }

    public void OnRedo()
    {
      for (int index = 0; index < 99; ++index)
        this._mapData[index].CalculateDetail();
    }
  }
}
