// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.TitleSelectWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class TitleSelectWindow : Form
  {
    private TitleElement _selectedTitle;
    private int _sex;
    private bool _clearTitle;
    private IContainer components;
    private Button button_Cancel;
    private Button button_OK;
    private ListBox listBox_TitleList;
    private Label label_Search;
    private TextBox textBox_SearchString;

    public TitleSelectWindow(int sex, bool clearTitle)
    {
      this.InitializeComponent();
      this._sex = sex;
      this._clearTitle = clearTitle;
      this.RenewalList();
    }

    public TitleElement SelectedTitle => this._selectedTitle;

    private void textBox_SearchString_TextChanged(object sender, EventArgs e) => this.RenewalList();

    private void RenewalList()
    {
      this.listBox_TitleList.BeginUpdate();
      int num = this._clearTitle ? 425 : 2;
      Regex regex = (Regex) null;
      if (!string.IsNullOrEmpty(this.textBox_SearchString.Text))
        regex = new Regex(this.textBox_SearchString.Text, RegexOptions.IgnoreCase);
      this.listBox_TitleList.Items.Clear();
      foreach (TitleElement titleElement in TitleDataList.List)
      {
        if (titleElement.DataIndex >= num)
        {
          if (regex != null)
          {
            if (regex.IsMatch(this._sex == 0 ? titleElement.MaleTitleName : titleElement.LadyTitleName))
              this.listBox_TitleList.Items.Add((object) new TitleSelectWindow.TitleListBoxItem(this._sex, titleElement));
          }
          else if ((this._sex == 0 ? (!string.IsNullOrEmpty(titleElement.MaleTitleName) ? 1 : 0) : (!string.IsNullOrEmpty(titleElement.LadyTitleName) ? 1 : 0)) != 0)
            this.listBox_TitleList.Items.Add((object) new TitleSelectWindow.TitleListBoxItem(this._sex, titleElement));
        }
      }
      this.listBox_TitleList.EndUpdate();
      if (this.listBox_TitleList.Items.Count > 0)
      {
        this.listBox_TitleList.SelectedIndex = 0;
      }
      else
      {
        this.listBox_TitleList.SelectedIndex = -1;
        this.button_OK.Enabled = false;
      }
    }

    private void listBox_TitleList_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.button_OK.Enabled = this.listBox_TitleList.SelectedIndex != -1;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      if (this.listBox_TitleList.SelectedItem is TitleSelectWindow.TitleListBoxItem selectedItem)
        this._selectedTitle = selectedItem.TitleElement;
      else
        this.DialogResult = DialogResult.None;
    }

    private void listBox_TitleList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.listBox_TitleList.IndexFromPoint(e.Location) == -1)
        return;
      if (this.listBox_TitleList.SelectedItem is TitleSelectWindow.TitleListBoxItem selectedItem)
      {
        this._selectedTitle = selectedItem.TitleElement;
        this.DialogResult = DialogResult.OK;
      }
      else
        this.DialogResult = DialogResult.None;
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
      this.button_OK = new Button();
      this.listBox_TitleList = new ListBox();
      this.label_Search = new Label();
      this.textBox_SearchString = new TextBox();
      this.SuspendLayout();
      this.button_Cancel.DialogResult = DialogResult.Cancel;
      this.button_Cancel.Location = new Point(111, 291);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new Size(61, 23);
      this.button_Cancel.TabIndex = 8;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_OK.DialogResult = DialogResult.OK;
      this.button_OK.Enabled = false;
      this.button_OK.Location = new Point(44, 291);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new Size(61, 23);
      this.button_OK.TabIndex = 7;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new EventHandler(this.button_OK_Click);
      this.listBox_TitleList.FormattingEnabled = true;
      this.listBox_TitleList.ItemHeight = 12;
      this.listBox_TitleList.Location = new Point(12, 31);
      this.listBox_TitleList.Name = "listBox_TitleList";
      this.listBox_TitleList.Size = new Size(160, 256);
      this.listBox_TitleList.TabIndex = 6;
      this.listBox_TitleList.MouseDoubleClick += new MouseEventHandler(this.listBox_TitleList_MouseDoubleClick);
      this.listBox_TitleList.SelectedIndexChanged += new EventHandler(this.listBox_TitleList_SelectedIndexChanged);
      this.label_Search.AutoSize = true;
      this.label_Search.Location = new Point(4, 9);
      this.label_Search.Name = "label_Search";
      this.label_Search.Size = new Size(41, 13);
      this.label_Search.TabIndex = 5;
      this.label_Search.Text = "Search";
      this.textBox_SearchString.Location = new Point(45, 6);
      this.textBox_SearchString.Name = "textBox_SearchString";
      this.textBox_SearchString.Size = new Size((int) sbyte.MaxValue, 20);
      this.textBox_SearchString.TabIndex = 4;
      this.textBox_SearchString.TextChanged += new EventHandler(this.textBox_SearchString_TextChanged);
      this.AcceptButton = (IButtonControl) this.button_OK;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button_Cancel;
      this.ClientSize = new Size(180, 315);
      this.Controls.Add((Control) this.button_Cancel);
      this.Controls.Add((Control) this.button_OK);
      this.Controls.Add((Control) this.listBox_TitleList);
      this.Controls.Add((Control) this.label_Search);
      this.Controls.Add((Control) this.textBox_SearchString);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (TitleSelectWindow);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Select Accolade";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private class TitleListBoxItem
    {
      private TitleElement _titleElement;
      private int _sex;

      public TitleListBoxItem(int sex, TitleElement titleElement)
      {
        this._titleElement = titleElement;
        this._sex = sex;
      }

      public TitleElement TitleElement => this._titleElement;

      public override string ToString()
      {
        return this._sex != 0 ? this._titleElement.LadyTitleName : this._titleElement.MaleTitleName;
      }
    }
  }
}
