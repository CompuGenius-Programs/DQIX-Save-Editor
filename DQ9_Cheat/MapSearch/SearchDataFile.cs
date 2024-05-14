// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchDataFile
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.IO;
using System.Management;
using System.Windows.Forms;
using DQ9_Cheat.GameData;
using JS_Framework;
using JS_Framework.Threading;
using ProgressEventArgs = JS_Framework.ProgressEventArgs;
using ProgressEventHandler = JS_Framework.ProgressEventHandler;

namespace DQ9_Cheat.MapSearch;

public static class SearchDataFile
{
    private static ThreadControl[] _threadControl;

    public static byte[] RankList = new byte[12]
    {
        2,
        56,
        61,
        76,
        81,
        101,
        121,
        141,
        161,
        181,
        201,
        221
    };

    private static readonly int _coreCount;
    private static readonly byte[] _byteData;
    private static bool _cancel;
    private static bool _error;
    private static int _progress;
    private static int _finishCount;
    private static int _notifyCount;

    static SearchDataFile()
    {
        _byteData = new byte[TotalCount * SearchDungeonData.Size];
        DungeonData = new SearchDungeonData[TotalCount];
        FilePath = Path.Combine(Application.StartupPath, "MapSearch.dat");
        var num1 = 0;
        var index1 = 0;
        for (ushort seed = 0; seed < 32768; ++seed)
            if (TreasureMapDataTable.GetReverseSeedTable(seed) != null)
                for (var index2 = 0; index2 < RankList.Length; ++index2)
                {
                    DungeonData[num1++] = new SearchDungeonData(index1, _byteData, seed, RankList[index2]);
                    index1 += SearchDungeonData.Size;
                }

        _coreCount = 0;
        try
        {
            foreach (var instance in new ManagementClass("Win32_Processor").GetInstances())
            {
                var num2 = (uint)instance["NumberOfCores"];
                _coreCount += (int)num2;
            }
        }
        catch
        {
            _coreCount = 1;
        }

        if (_coreCount >= 1)
            return;
        _coreCount = 1;
    }

    public static SearchDungeonData[] DungeonData { get; }

    public static string FilePath { get; }

    public static int TotalCount { get; } = TreasureMapDataTable.SeedCount * RankList.Length;

    public static event ProgressEventHandler EventHandler;

    public static void LoadSearchDataFile()
    {
        if (!File.Exists(FilePath))
            return;
        using (var input = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
        {
            using (var binaryReader = new BinaryReader(input))
            {
                binaryReader.Read(_byteData, 0,
                    TreasureMapDataTable.SeedCount * RankList.Length * SearchDungeonData.Size);
            }
        }
    }

    private static void CreateSearchDataFileThread(object[] param)
    {
        var threadIndex = (int)param[0];
        var num1 = TotalCount / _coreCount * threadIndex;
        var num2 = threadIndex != _coreCount - 1 ? TotalCount / _coreCount * (threadIndex + 1) : TotalCount;
        var treasureMapDetailData = new TreasureMapDetailData();
        var num3 = 0;
        for (var index = num1; index < num2; ++index)
        {
            var searchDungeonData = DungeonData[index];
            ++_progress;
            searchDungeonData.Calculate(treasureMapDetailData);
            ++num3;
            if (num3 > 512)
            {
                InnerNotify(threadIndex, ProgressState.Working);
                num3 = 0;
            }

            if (_threadControl[threadIndex].IsStop)
                break;
        }

        InnerNotify(threadIndex, ProgressState.Complete);
    }

    private static void InnerNotify(int threadIndex, ProgressState state)
    {
        ++_notifyCount;
        if (_finishCount >= _coreCount)
        {
            if (!_cancel && !_error)
            {
                using (var output = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
                {
                    using (var binaryWriter = new BinaryWriter(output))
                    {
                        binaryWriter.Write(_byteData, 0,
                            TreasureMapDataTable.SeedCount * RankList.Length * SearchDungeonData.Size);
                    }
                }

                if (EventHandler == null)
                    return;
                EventHandler(null, new ProgressEventArgs(ProgressState.Complete, TotalCount, _progress));
            }
            else if (_error)
            {
                if (EventHandler == null)
                    return;
                EventHandler(null, new ProgressEventArgs(ProgressState.InterruptByError, TotalCount, _progress));
            }
            else
            {
                if (EventHandler == null)
                    return;
                EventHandler(null, new ProgressEventArgs(ProgressState.InterruptByUser, TotalCount, _progress));
            }
        }
        else
        {
            if (_notifyCount <= 4)
                return;
            if (EventHandler != null)
                EventHandler(null, new ProgressEventArgs(ProgressState.Working, TotalCount, _progress));
            _notifyCount = 0;
        }
    }

    public static void CreateSearchDataFile()
    {
        _notifyCount = 0;
        _progress = 0;
        _finishCount = 0;
        _cancel = false;
        _error = false;
        _threadControl = new ThreadControl[_coreCount];
        for (uint index = 0; index < _coreCount; ++index)
        {
            _threadControl[(int)index] = new ThreadControl("CreateSearchDataFileThread", CreateSearchDataFileThread);
            _threadControl[(int)index].Start((int)index);
            _threadControl[(int)index].ThreadEnding += SearchDataFile_ThreadEnding;
        }
    }

    private static void SearchDataFile_ThreadEnding(Exception ex)
    {
        ++_finishCount;
        if (ex != null)
        {
            _error = true;
            if (_finishCount >= _coreCount)
                InnerNotify(0, ProgressState.InterruptByError);
            else
                Cancel();
        }
        else
        {
            if (_finishCount < _coreCount)
                return;
            InnerNotify(0, ProgressState.Complete);
        }
    }

    public static void Cancel()
    {
        for (uint index = 0; index < _coreCount; ++index)
            _threadControl[(int)index].Stop();
        _cancel = true;
    }
}