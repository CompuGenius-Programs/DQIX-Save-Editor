// Decompiled with JetBrains decompiler
// Type: JS_Framework.ProgressEventArgs
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;

namespace JS_Framework;

public class ProgressEventArgs : EventArgs
{
    public ProgressEventArgs(ProgressState state, int totalCount, int processedCount)
    {
        State = state;
        TotalCount = totalCount;
        ProcessedCount = processedCount;
    }

    public ProgressEventArgs(
        ProgressState state,
        int totalCount,
        int processedCount,
        string title)
        : this(state, totalCount, processedCount)
    {
        Title = title;
    }

    public ProgressEventArgs(
        ProgressState state,
        int totalCount,
        int processedCount,
        string title,
        string comment)
        : this(state, totalCount, processedCount)
    {
        Title = title;
        Comment = comment;
    }

    public ProgressState State { get; }

    public int TotalCount { get; }

    public int ProcessedCount { get; }

    public string Title { get; }

    public string Comment { get; }

    public bool Skip { get; set; }

    public bool Cancel { get; set; }

    public double Percent => ProcessedCount / (double)TotalCount * 100.0;
}