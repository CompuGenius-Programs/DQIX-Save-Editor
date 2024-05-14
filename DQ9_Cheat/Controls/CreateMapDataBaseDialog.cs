// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.CreateMapDataBaseDialog
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.MapSearch;
using JS_Framework;

namespace DQ9_Cheat.Controls;

public class CreateMapDataBaseDialog : Form
{
    private bool _requestStop;
    private bool _terminate;
    private Button button_Cancel;
    private IContainer components;
    private Label label_ProgressInfo;
    private ProgressBar progressBar;

    public CreateMapDataBaseDialog()
    {
        InitializeComponent();
        SearchDataFile.EventHandler += SearchDataFile_EventHandler;
        SearchDataFile.CreateSearchDataFile();
    }

    private void SearchDataFile_EventHandler(object sender, ProgressEventArgs e)
    {
        if (InvokeRequired)
        {
            if (e.State == ProgressState.Working)
            {
                BeginInvoke(new RenewalInfoDelegate(RenewalInfo), e.ProcessedCount, e.TotalCount);
            }
            else
            {
                if (e.State == ProgressState.Preparing)
                    return;
                _terminate = true;
                Invoke(new MethodInvoker(Close));
            }
        }
        else
        {
            RenewalInfo(e.ProcessedCount, e.TotalCount);
        }
    }

    private void CallBack_RenewalInfoDelegate(IAsyncResult ar)
    {
        ((RenewalInfoDelegate)ar.AsyncState).EndInvoke(ar);
    }

    private void RenewalInfo(int progressCount, int totalCount)
    {
        label_ProgressInfo.Text = string.Format("{0:D}/{1:D}", progressCount, totalCount);
        progressBar.Maximum = totalCount;
        progressBar.Value = progressCount;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        if (!_terminate && !_requestStop)
        {
            SearchDataFile.Cancel();
            _requestStop = true;
            e.Cancel = true;
        }
        else
        {
            if (_terminate)
                return;
            e.Cancel = true;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        button_Cancel = new Button();
        progressBar = new ProgressBar();
        label_ProgressInfo = new Label();
        SuspendLayout();
        button_Cancel.DialogResult = DialogResult.Cancel;
        button_Cancel.Location = new Point(430, 111);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new Size(75, 23);
        button_Cancel.TabIndex = 0;
        button_Cancel.Text = "Cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        progressBar.Location = new Point(12, 32);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(493, 23);
        progressBar.TabIndex = 1;
        label_ProgressInfo.Location = new Point(301, 61);
        label_ProgressInfo.Name = "label_ProgressInfo";
        label_ProgressInfo.Size = new Size(201, 23);
        label_ProgressInfo.TabIndex = 2;
        label_ProgressInfo.TextAlign = ContentAlignment.MiddleRight;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(517, 146);
        Controls.Add(label_ProgressInfo);
        Controls.Add(progressBar);
        Controls.Add(button_Cancel);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = nameof(CreateMapDataBaseDialog);
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Map Data";
        ResumeLayout(false);
    }

    private delegate void RenewalInfoDelegate(int progressCount, int totalCount);
}