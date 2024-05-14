// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.TitleSelectWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DQ9_Cheat.GameData;

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
      InitializeComponent();
      _sex = sex;
      _clearTitle = clearTitle;
      RenewalList();
    }

    public TitleElement SelectedTitle => _selectedTitle;

    private void textBox_SearchString_TextChanged(object sender, EventArgs e) => RenewalList();

    private void RenewalList()
    {
      listBox_TitleList.BeginUpdate();
      int num = _clearTitle ? 425 : 2;
      Regex regex = null;
      if (!string.IsNullOrEmpty(textBox_SearchString.Text))
        regex = new Regex(textBox_SearchString.Text, RegexOptions.IgnoreCase);
      listBox_TitleList.Items.Clear();
      foreach (TitleElement titleElement in TitleDataList.List)
      {
        if (titleElement.DataIndex >= num)
        {
          if (regex != null)
          {
            if (regex.IsMatch(_sex == 0 ? titleElement.MaleTitleName : titleElement.LadyTitleName))
              listBox_TitleList.Items.Add(new TitleListBoxItem(_sex, titleElement));
          }
          else if ((_sex == 0 ? (!string.IsNullOrEmpty(titleElement.MaleTitleName) ? 1 : 0) : (!string.IsNullOrEmpty(titleElement.LadyTitleName) ? 1 : 0)) != 0)
            listBox_TitleList.Items.Add(new TitleListBoxItem(_sex, titleElement));
        }
      }
      listBox_TitleList.EndUpdate();
      if (listBox_TitleList.Items.Count > 0)
      {
        listBox_TitleList.SelectedIndex = 0;
      }
      else
      {
        listBox_TitleList.SelectedIndex = -1;
        button_OK.Enabled = false;
      }
    }

    private void listBox_TitleList_SelectedIndexChanged(object sender, EventArgs e)
    {
      button_OK.Enabled = listBox_TitleList.SelectedIndex != -1;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      if (listBox_TitleList.SelectedItem is TitleListBoxItem selectedItem)
        _selectedTitle = selectedItem.TitleElement;
      else
        DialogResult = DialogResult.None;
    }

    private void listBox_TitleList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (listBox_TitleList.IndexFromPoint(e.Location) == -1)
        return;
      if (listBox_TitleList.SelectedItem is TitleListBoxItem selectedItem)
      {
        _selectedTitle = selectedItem.TitleElement;
        DialogResult = DialogResult.OK;
      }
      else
        DialogResult = DialogResult.None;
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
      button_OK = new Button();
      listBox_TitleList = new ListBox();
      label_Search = new Label();
      textBox_SearchString = new TextBox();
      SuspendLayout();
      button_Cancel.DialogResult = DialogResult.Cancel;
      button_Cancel.Location = new Point(111, 291);
      button_Cancel.Name = "button_Cancel";
      button_Cancel.Size = new Size(61, 23);
      button_Cancel.TabIndex = 8;
      button_Cancel.Text = "Cancel";
      button_Cancel.UseVisualStyleBackColor = true;
      button_OK.DialogResult = DialogResult.OK;
      button_OK.Enabled = false;
      button_OK.Location = new Point(44, 291);
      button_OK.Name = "button_OK";
      button_OK.Size = new Size(61, 23);
      button_OK.TabIndex = 7;
      button_OK.Text = "OK";
      button_OK.UseVisualStyleBackColor = true;
      button_OK.Click += button_OK_Click;
      listBox_TitleList.FormattingEnabled = true;
      listBox_TitleList.ItemHeight = 12;
      listBox_TitleList.Location = new Point(12, 31);
      listBox_TitleList.Name = "listBox_TitleList";
      listBox_TitleList.Size = new Size(160, 256);
      listBox_TitleList.TabIndex = 6;
      listBox_TitleList.MouseDoubleClick += listBox_TitleList_MouseDoubleClick;
      listBox_TitleList.SelectedIndexChanged += listBox_TitleList_SelectedIndexChanged;
      label_Search.AutoSize = true;
      label_Search.Location = new Point(4, 9);
      label_Search.Name = "label_Search";
      label_Search.Size = new Size(41, 13);
      label_Search.TabIndex = 5;
      label_Search.Text = "Search";
      textBox_SearchString.Location = new Point(45, 6);
      textBox_SearchString.Name = "textBox_SearchString";
      textBox_SearchString.Size = new Size(sbyte.MaxValue, 20);
      textBox_SearchString.TabIndex = 4;
      textBox_SearchString.TextChanged += textBox_SearchString_TextChanged;
      AcceptButton = button_OK;
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = button_Cancel;
      ClientSize = new Size(180, 315);
      Controls.Add(button_Cancel);
      Controls.Add(button_OK);
      Controls.Add(listBox_TitleList);
      Controls.Add(label_Search);
      Controls.Add(textBox_SearchString);
      FormBorderStyle = FormBorderStyle.Fixed3D;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = nameof (TitleSelectWindow);
      ShowIcon = false;
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.Manual;
      Text = "Select Accolade";
      ResumeLayout(false);
      PerformLayout();
    }

    private class TitleListBoxItem
    {
      private TitleElement _titleElement;
      private int _sex;

      public TitleListBoxItem(int sex, TitleElement titleElement)
      {
        _titleElement = titleElement;
        _sex = sex;
      }

      public TitleElement TitleElement => _titleElement;

      public override string ToString()
      {
        return _sex != 0 ? _titleElement.LadyTitleName : _titleElement.MaleTitleName;
      }
    }
  }
}
