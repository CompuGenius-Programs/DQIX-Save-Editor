// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MapSearch.SearchDataFile
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using JS_Framework;
using JS_Framework.Threading;
using System;
using System.IO;
using System.Management;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.MapSearch
{
  public static class SearchDataFile
  {
    private static ThreadControl[] _threadControl;
    public static byte[] RankList = new byte[12]
    {
      (byte) 2,
      (byte) 56,
      (byte) 61,
      (byte) 76,
      (byte) 81,
      (byte) 101,
      (byte) 121,
      (byte) 141,
      (byte) 161,
      (byte) 181,
      (byte) 201,
      (byte) 221
    };
    private static int _coreCount;
    private static byte[] _byteData = (byte[]) null;
    private static SearchDungeonData[] _dungeonData = (SearchDungeonData[]) null;
    private static string _filePath;
    private static bool _cancel;
    private static bool _error;
    private static int _progress;
    private static int _finishCount;
    private static int _totalCount = TreasureMapDataTable.SeedCount * SearchDataFile.RankList.Length;
    private static int _notifyCount;

    static SearchDataFile()
    {
      SearchDataFile._byteData = new byte[SearchDataFile._totalCount * SearchDungeonData.Size];
      SearchDataFile._dungeonData = new SearchDungeonData[SearchDataFile._totalCount];
      SearchDataFile._filePath = Path.Combine(Application.StartupPath, "MapSearch.dat");
      int num1 = 0;
      int index1 = 0;
      for (ushort seed = 0; seed < (ushort) 32768; ++seed)
      {
        if (TreasureMapDataTable.GetReverseSeedTable(seed) != null)
        {
          for (int index2 = 0; index2 < SearchDataFile.RankList.Length; ++index2)
          {
            SearchDataFile._dungeonData[num1++] = new SearchDungeonData(index1, SearchDataFile._byteData, seed, SearchDataFile.RankList[index2]);
            index1 += SearchDungeonData.Size;
          }
        }
      }
      SearchDataFile._coreCount = 0;
      try
      {
        foreach (ManagementBaseObject instance in new ManagementClass("Win32_Processor").GetInstances())
        {
          uint num2 = (uint) instance["NumberOfCores"];
          SearchDataFile._coreCount += (int) num2;
        }
      }
      catch
      {
        SearchDataFile._coreCount = 1;
      }
      if (SearchDataFile._coreCount >= 1)
        return;
      SearchDataFile._coreCount = 1;
    }

    public static event JS_Framework.ProgressEventHandler EventHandler;

    public static SearchDungeonData[] DungeonData => SearchDataFile._dungeonData;

    public static string FilePath => SearchDataFile._filePath;

    public static int TotalCount => SearchDataFile._totalCount;

    public static void LoadSearchDataFile()
    {
      if (!File.Exists(SearchDataFile._filePath))
        return;
      using (FileStream input = new FileStream(SearchDataFile._filePath, FileMode.Open, FileAccess.Read))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) input))
          binaryReader.Read(SearchDataFile._byteData, 0, TreasureMapDataTable.SeedCount * SearchDataFile.RankList.Length * SearchDungeonData.Size);
      }
    }

    private static void CreateSearchDataFileThread(object[] param)
    {
      int threadIndex = (int) param[0];
      int num1 = SearchDataFile._totalCount / SearchDataFile._coreCount * threadIndex;
      int num2 = threadIndex != SearchDataFile._coreCount - 1 ? SearchDataFile._totalCount / SearchDataFile._coreCount * (threadIndex + 1) : SearchDataFile._totalCount;
      TreasureMapDetailData treasureMapDetailData = new TreasureMapDetailData();
      int num3 = 0;
      for (int index = num1; index < num2; ++index)
      {
        SearchDungeonData searchDungeonData = SearchDataFile._dungeonData[index];
        ++SearchDataFile._progress;
        searchDungeonData.Calculate(treasureMapDetailData);
        ++num3;
        if (num3 > 512)
        {
          SearchDataFile.InnerNotify(threadIndex, ProgressState.Working);
          num3 = 0;
        }
        if (SearchDataFile._threadControl[threadIndex].IsStop)
          break;
      }
      SearchDataFile.InnerNotify(threadIndex, ProgressState.Complete);
    }

    private static void InnerNotify(int threadIndex, ProgressState state)
    {
      ++SearchDataFile._notifyCount;
      if (SearchDataFile._finishCount >= SearchDataFile._coreCount)
      {
        if (!SearchDataFile._cancel && !SearchDataFile._error)
        {
          using (FileStream output = new FileStream(SearchDataFile._filePath, FileMode.Create, FileAccess.Write))
          {
            using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
              binaryWriter.Write(SearchDataFile._byteData, 0, TreasureMapDataTable.SeedCount * SearchDataFile.RankList.Length * SearchDungeonData.Size);
          }
          if (SearchDataFile.EventHandler == null)
            return;
          SearchDataFile.EventHandler((object) null, new JS_Framework.ProgressEventArgs(ProgressState.Complete, SearchDataFile._totalCount, SearchDataFile._progress));
        }
        else if (SearchDataFile._error)
        {
          if (SearchDataFile.EventHandler == null)
            return;
          SearchDataFile.EventHandler((object) null, new JS_Framework.ProgressEventArgs(ProgressState.InterruptByError, SearchDataFile._totalCount, SearchDataFile._progress));
        }
        else
        {
          if (SearchDataFile.EventHandler == null)
            return;
          SearchDataFile.EventHandler((object) null, new JS_Framework.ProgressEventArgs(ProgressState.InterruptByUser, SearchDataFile._totalCount, SearchDataFile._progress));
        }
      }
      else
      {
        if (SearchDataFile._notifyCount <= 4)
          return;
        if (SearchDataFile.EventHandler != null)
          SearchDataFile.EventHandler((object) null, new JS_Framework.ProgressEventArgs(ProgressState.Working, SearchDataFile._totalCount, SearchDataFile._progress));
        SearchDataFile._notifyCount = 0;
      }
    }

    public static void CreateSearchDataFile()
    {
      SearchDataFile._notifyCount = 0;
      SearchDataFile._progress = 0;
      SearchDataFile._finishCount = 0;
      SearchDataFile._cancel = false;
      SearchDataFile._error = false;
      SearchDataFile._threadControl = new ThreadControl[SearchDataFile._coreCount];
      for (uint index = 0; (long) index < (long) SearchDataFile._coreCount; ++index)
      {
        SearchDataFile._threadControl[(int) index] = new ThreadControl("CreateSearchDataFileThread", new ThreadParameterizedRunnable(SearchDataFile.CreateSearchDataFileThread));
        SearchDataFile._threadControl[(int) index].Start((object) (int) index);
        SearchDataFile._threadControl[(int) index].ThreadEnding += new ThreadEndingHandler(SearchDataFile.SearchDataFile_ThreadEnding);
      }
    }

    private static void SearchDataFile_ThreadEnding(Exception ex)
    {
      ++SearchDataFile._finishCount;
      if (ex != null)
      {
        SearchDataFile._error = true;
        if (SearchDataFile._finishCount >= SearchDataFile._coreCount)
          SearchDataFile.InnerNotify(0, ProgressState.InterruptByError);
        else
          SearchDataFile.Cancel();
      }
      else
      {
        if (SearchDataFile._finishCount < SearchDataFile._coreCount)
          return;
        SearchDataFile.InnerNotify(0, ProgressState.Complete);
      }
    }

    public static void Cancel()
    {
      for (uint index = 0; (long) index < (long) SearchDataFile._coreCount; ++index)
        SearchDataFile._threadControl[(int) index].Stop();
      SearchDataFile._cancel = true;
    }
  }
}
