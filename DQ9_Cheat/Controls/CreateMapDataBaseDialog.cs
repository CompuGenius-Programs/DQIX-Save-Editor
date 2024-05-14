// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.CreateMapDataBaseDialog
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.MapSearch;
using JS_Framework;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class CreateMapDataBaseDialog : Form
  {
    private bool _requestStop;
    private bool _terminate;
    private IContainer components;
    private Button button_Cancel;
    private ProgressBar progressBar;
    private Label label_ProgressInfo;

    public CreateMapDataBaseDialog()
    {
      this.InitializeComponent();
      SearchDataFile.EventHandler += new ProgressEventHandler(this.SearchDataFile_EventHandler);
      SearchDataFile.CreateSearchDataFile();
    }

    private void SearchDataFile_EventHandler(object sender, ProgressEventArgs e)
    {
      if (this.InvokeRequired)
      {
        if (e.State == ProgressState.Working)
        {
          this.BeginInvoke((Delegate) new CreateMapDataBaseDialog.RenewalInfoDelegate(this.RenewalInfo), (object) e.ProcessedCount, (object) e.TotalCount);
        }
        else
        {
          if (e.State == ProgressState.Preparing)
            return;
          this._terminate = true;
          this.Invoke((Delegate) new MethodInvoker(((Form) this).Close));
        }
      }
      else
        this.RenewalInfo(e.ProcessedCount, e.TotalCount);
    }

    private void CallBack_RenewalInfoDelegate(IAsyncResult ar)
    {
      ((CreateMapDataBaseDialog.RenewalInfoDelegate) ar.AsyncState).EndInvoke(ar);
    }

    private void RenewalInfo(int progressCount, int totalCount)
    {
      this.label_ProgressInfo.Text = string.Format("{0:D}/{1:D}", (object) progressCount, (object) totalCount);
      this.progressBar.Maximum = totalCount;
      this.progressBar.Value = progressCount;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      if (!this._terminate && !this._requestStop)
      {
        SearchDataFile.Cancel();
        this._requestStop = true;
        e.Cancel = true;
      }
      else
      {
        if (this._terminate)
          return;
        e.Cancel = true;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button_Cancel = new Button();
      this.progressBar = new ProgressBar();
      this.label_ProgressInfo = new Label();
      this.SuspendLayout();
      this.button_Cancel.DialogResult = DialogResult.Cancel;
      this.button_Cancel.Location = new Point(430, 111);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new Size(75, 23);
      this.button_Cancel.TabIndex = 0;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.progressBar.Location = new Point(12, 32);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new Size(493, 23);
      this.progressBar.TabIndex = 1;
      this.label_ProgressInfo.Location = new Point(301, 61);
      this.label_ProgressInfo.Name = "label_ProgressInfo";
      this.label_ProgressInfo.Size = new Size(201, 23);
      this.label_ProgressInfo.TabIndex = 2;
      this.label_ProgressInfo.TextAlign = ContentAlignment.MiddleRight;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(517, 146);
      this.Controls.Add((Control) this.label_ProgressInfo);
      this.Controls.Add((Control) this.progressBar);
      this.Controls.Add((Control) this.button_Cancel);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (CreateMapDataBaseDialog);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Map Data";
      this.ResumeLayout(false);
    }

    private delegate void RenewalInfoDelegate(int progressCount, int totalCount);
  }
}
