// Decompiled with JetBrains decompiler
// Type: JS_Framework.ProgressEventArgs
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;

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
      _state = state;
      _totalCount = totalCount;
      _processedCount = processedCount;
    }

    public ProgressEventArgs(
      ProgressState state,
      int totalCount,
      int processedCount,
      string title)
      : this(state, totalCount, processedCount)
    {
      _title = title;
    }

    public ProgressEventArgs(
      ProgressState state,
      int totalCount,
      int processedCount,
      string title,
      string comment)
      : this(state, totalCount, processedCount)
    {
      _title = title;
      _comment = comment;
    }

    public ProgressState State => _state;

    public int TotalCount => _totalCount;

    public int ProcessedCount => _processedCount;

    public string Title => _title;

    public string Comment => _comment;

    public bool Skip
    {
      get => _skip;
      set => _skip = value;
    }

    public bool Cancel
    {
      get => _cancel;
      set => _cancel = value;
    }

    public double Percent => _processedCount / (double) _totalCount * 100.0;
  }
}
