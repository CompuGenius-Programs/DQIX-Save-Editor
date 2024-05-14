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

namespace DQ9_Cheat.MapSearch
{
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
    private static int _coreCount;
    private static byte[] _byteData;
    private static SearchDungeonData[] _dungeonData;
    private static string _filePath;
    private static bool _cancel;
    private static bool _error;
    private static int _progress;
    private static int _finishCount;
    private static int _totalCount = TreasureMapDataTable.SeedCount * RankList.Length;
    private static int _notifyCount;

    static SearchDataFile()
    {
      _byteData = new byte[_totalCount * SearchDungeonData.Size];
      _dungeonData = new SearchDungeonData[_totalCount];
      _filePath = Path.Combine(Application.StartupPath, "MapSearch.dat");
      int num1 = 0;
      int index1 = 0;
      for (ushort seed = 0; seed < 32768; ++seed)
      {
        if (TreasureMapDataTable.GetReverseSeedTable(seed) != null)
        {
          for (int index2 = 0; index2 < RankList.Length; ++index2)
          {
            _dungeonData[num1++] = new SearchDungeonData(index1, _byteData, seed, RankList[index2]);
            index1 += SearchDungeonData.Size;
          }
        }
      }
      _coreCount = 0;
      try
      {
        foreach (ManagementBaseObject instance in new ManagementClass("Win32_Processor").GetInstances())
        {
          uint num2 = (uint) instance["NumberOfCores"];
          _coreCount += (int) num2;
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

    public static event ProgressEventHandler EventHandler;

    public static SearchDungeonData[] DungeonData => _dungeonData;

    public static string FilePath => _filePath;

    public static int TotalCount => _totalCount;

    public static void LoadSearchDataFile()
    {
      if (!File.Exists(_filePath))
        return;
      using (FileStream input = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
      {
        using (BinaryReader binaryReader = new BinaryReader(input))
          binaryReader.Read(_byteData, 0, TreasureMapDataTable.SeedCount * RankList.Length * SearchDungeonData.Size);
      }
    }

    private static void CreateSearchDataFileThread(object[] param)
    {
      int threadIndex = (int) param[0];
      int num1 = _totalCount / _coreCount * threadIndex;
      int num2 = threadIndex != _coreCount - 1 ? _totalCount / _coreCount * (threadIndex + 1) : _totalCount;
      TreasureMapDetailData treasureMapDetailData = new TreasureMapDetailData();
      int num3 = 0;
      for (int index = num1; index < num2; ++index)
      {
        SearchDungeonData searchDungeonData = _dungeonData[index];
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
          using (FileStream output = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
          {
            using (BinaryWriter binaryWriter = new BinaryWriter(output))
              binaryWriter.Write(_byteData, 0, TreasureMapDataTable.SeedCount * RankList.Length * SearchDungeonData.Size);
          }
          if (EventHandler == null)
            return;
          EventHandler(null, new ProgressEventArgs(ProgressState.Complete, _totalCount, _progress));
        }
        else if (_error)
        {
          if (EventHandler == null)
            return;
          EventHandler(null, new ProgressEventArgs(ProgressState.InterruptByError, _totalCount, _progress));
        }
        else
        {
          if (EventHandler == null)
            return;
          EventHandler(null, new ProgressEventArgs(ProgressState.InterruptByUser, _totalCount, _progress));
        }
      }
      else
      {
        if (_notifyCount <= 4)
          return;
        if (EventHandler != null)
          EventHandler(null, new ProgressEventArgs(ProgressState.Working, _totalCount, _progress));
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
        _threadControl[(int) index] = new ThreadControl("CreateSearchDataFileThread", CreateSearchDataFileThread);
        _threadControl[(int) index].Start((int) index);
        _threadControl[(int) index].ThreadEnding += SearchDataFile_ThreadEnding;
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
        _threadControl[(int) index].Stop();
      _cancel = true;
    }
  }
}
