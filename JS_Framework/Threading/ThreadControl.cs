// Decompiled with JetBrains decompiler
// Type: JS_Framework.Threading.ThreadControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Threading;

namespace JS_Framework.Threading
{
  public class ThreadControl
  {
    private Thread _threadHandle;
    private ThreadRunnable _runnable;
    private ThreadParameterizedRunnable _parameterisedRunnable;
    private object[] _params;
    protected string _name;
    private volatile bool _isStop;

    public ThreadControl(string name)
    {
      _name = name;
      _parameterisedRunnable = Runnable;
      Initialize();
    }

    public ThreadControl(string name, ThreadRunnable runnable)
    {
      _name = name;
      _runnable = runnable;
      Initialize();
    }

    public ThreadControl(string name, ThreadParameterizedRunnable parameterisedRunnable)
    {
      _name = name;
      _parameterisedRunnable = parameterisedRunnable;
      Initialize();
    }

    public event ThreadEndingHandler ThreadEnding;

    public bool IsStop => _isStop;

    protected virtual void Runnable(params object[] param)
    {
    }

    private void Initialize()
    {
      _threadHandle = new Thread(ThreadProc);
      _threadHandle.Name = _name;
      _threadHandle.IsBackground = true;
      _threadHandle.SetApartmentState(ApartmentState.STA);
    }

    public void Start() => _threadHandle.Start();

    public void Start(params object[] param)
    {
      _params = param;
      _threadHandle.Start();
    }

    public void Stop() => _isStop = true;

    private void ThreadProc()
    {
      Exception ex1 = null;
      try
      {
        if (_runnable != null)
        {
          _runnable();
        }
        else
        {
          if (_parameterisedRunnable == null)
            throw new ThreadRunnableNotFoundException(_name);
          _parameterisedRunnable(_params);
        }
      }
      catch (ThreadAbortException ex2)
      {
        ex1 = ex2;
      }
      catch (ThreadRunnableNotFoundException ex3)
      {
        ex1 = ex3;
      }
      catch (Exception ex4)
      {
        ex1 = ex4;
      }
      finally
      {
        if (ThreadEnding != null)
          ThreadEnding(ex1);
      }
    }

    public void Abort() => _threadHandle.Abort();

    public void Join()
    {
      if ((_threadHandle.ThreadState & ThreadState.Unstarted) == ThreadState.Unstarted)
        return;
      _threadHandle.Join();
    }

    public bool Join(int timeout)
    {
      return (_threadHandle.ThreadState & ThreadState.Unstarted) != ThreadState.Unstarted && _threadHandle.Join(timeout);
    }

    public bool IsAlive => _threadHandle.IsAlive;
  }
}
