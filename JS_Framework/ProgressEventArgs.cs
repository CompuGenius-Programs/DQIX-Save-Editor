// Decompiled with JetBrains decompiler
// Type: JS_Framework.ProgressEventArgs
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;

#nullable disable
namespace JS_Framework
{
  public class ProgressEventArgs : EventArgs
  {
    private ProgressState _state;
    private int _totalCount;
    private int _processedCount;
    private string _title;
    private string _comment;
    private bool _skip;
    private bool _cancel;

    public ProgressEventArgs(ProgressState state, int totalCount, int processedCount)
    {
      this._state = state;
      this._totalCount = totalCount;
      this._processedCount = processedCount;
    }

    public ProgressEventArgs(
      ProgressState state,
      int totalCount,
      int processedCount,
      string title)
      : this(state, totalCount, processedCount)
    {
      this._title = title;
    }

    public ProgressEventArgs(
      ProgressState state,
      int totalCount,
      int processedCount,
      string title,
      string comment)
      : this(state, totalCount, processedCount)
    {
      this._title = title;
      this._comment = comment;
    }

    public ProgressState State => this._state;

    public int TotalCount => this._totalCount;

    public int ProcessedCount => this._processedCount;

    public string Title => this._title;

    public string Comment => this._comment;

    public bool Skip
    {
      get => this._skip;
      set => this._skip = value;
    }

    public bool Cancel
    {
      get => this._cancel;
      set => this._cancel = value;
    }

    public double Percent => (double) this._processedCount / (double) this._totalCount * 100.0;
  }
}
