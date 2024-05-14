// Decompiled with JetBrains decompiler
// Type: JS_Framework.Threading.ThreadControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Threading;

#nullable disable
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
      this._name = name;
      this._parameterisedRunnable = new ThreadParameterizedRunnable(this.Runnable);
      this.Initialize();
    }

    public ThreadControl(string name, ThreadRunnable runnable)
    {
      this._name = name;
      this._runnable = runnable;
      this.Initialize();
    }

    public ThreadControl(string name, ThreadParameterizedRunnable parameterisedRunnable)
    {
      this._name = name;
      this._parameterisedRunnable = parameterisedRunnable;
      this.Initialize();
    }

    public event ThreadEndingHandler ThreadEnding;

    public bool IsStop => this._isStop;

    protected virtual void Runnable(params object[] param)
    {
    }

    private void Initialize()
    {
      this._threadHandle = new Thread(new ThreadStart(this.ThreadProc));
      this._threadHandle.Name = this._name;
      this._threadHandle.IsBackground = true;
      this._threadHandle.SetApartmentState(ApartmentState.STA);
    }

    public void Start() => this._threadHandle.Start();

    public void Start(params object[] param)
    {
      this._params = param;
      this._threadHandle.Start();
    }

    public void Stop() => this._isStop = true;

    private void ThreadProc()
    {
      Exception ex1 = (Exception) null;
      try
      {
        if (this._runnable != null)
        {
          this._runnable();
        }
        else
        {
          if (this._parameterisedRunnable == null)
            throw new ThreadRunnableNotFoundException(this._name);
          this._parameterisedRunnable(this._params);
        }
      }
      catch (ThreadAbortException ex2)
      {
        ex1 = (Exception) ex2;
      }
      catch (ThreadRunnableNotFoundException ex3)
      {
        ex1 = (Exception) ex3;
      }
      catch (Exception ex4)
      {
        ex1 = ex4;
      }
      finally
      {
        if (this.ThreadEnding != null)
          this.ThreadEnding(ex1);
      }
    }

    public void Abort() => this._threadHandle.Abort();

    public void Join()
    {
      if ((this._threadHandle.ThreadState & ThreadState.Unstarted) == ThreadState.Unstarted)
        return;
      this._threadHandle.Join();
    }

    public bool Join(int timeout)
    {
      return (this._threadHandle.ThreadState & ThreadState.Unstarted) != ThreadState.Unstarted && this._threadHandle.Join(timeout);
    }

    public bool IsAlive => this._threadHandle.IsAlive;
  }
}
