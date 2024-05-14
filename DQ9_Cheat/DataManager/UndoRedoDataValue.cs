// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.DataManager.UndoRedoDataValue
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System.Collections.Generic;

#nullable disable
namespace DQ9_Cheat.DataManager
{
  internal class UndoRedoDataValue : UndoRedoElement
  {
    private List<DataValueBase> _dataValueList = new List<DataValueBase>();

    public UndoRedoDataValue()
    {
    }

    public UndoRedoDataValue(DataValueBase dataValue) => this._dataValueList.Add(dataValue);

    public void AddDataValue(DataValueBase dataValue) => this._dataValueList.Add(dataValue);

    public override void Undo()
    {
      foreach (DataValueBase dataValue in this._dataValueList)
        dataValue.Undo();
    }

    public override void Redo()
    {
      foreach (DataValueBase dataValue in this._dataValueList)
        dataValue.Redo();
    }
  }
}
