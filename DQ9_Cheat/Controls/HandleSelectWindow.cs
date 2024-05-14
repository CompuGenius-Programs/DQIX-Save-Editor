// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.HandleSelectWindow
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
  public class HandleSelectWindow : Form
  {
    private IContainer components;
    private Button button_Cancel;
    private Button button_OK;
    private ListBox listBox_HandleList;
    private Label label_Search;
    private TextBox textBox_SearchString;
    private Label label_TypeName;
    private ComboBox comboBox_SelectType;
    private DQ9_Cheat.GameData.Handle _selectedHandle;
    private int _sex;

    public HandleSelectWindow(int sex)
    {
      this.InitializeComponent();
      this.comboBox_SelectType.SelectedIndex = 0;
      this._sex = sex;
      this.RenewalList();
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
      this.listBox_HandleList = new ListBox();
      this.label_Search = new Label();
      this.textBox_SearchString = new TextBox();
      this.label_TypeName = new Label();
      this.comboBox_SelectType = new ComboBox();
      this.SuspendLayout();
      this.button_Cancel.DialogResult = DialogResult.Cancel;
      this.button_Cancel.Location = new Point(111, 317);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new Size(61, 23);
      this.button_Cancel.TabIndex = 8;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_OK.DialogResult = DialogResult.OK;
      this.button_OK.Enabled = false;
      this.button_OK.Location = new Point(44, 317);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new Size(61, 23);
      this.button_OK.TabIndex = 7;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new EventHandler(this.button_OK_Click);
      this.listBox_HandleList.FormattingEnabled = true;
      this.listBox_HandleList.ItemHeight = 12;
      this.listBox_HandleList.Location = new Point(12, 57);
      this.listBox_HandleList.Name = "listBox_HandleList";
      this.listBox_HandleList.Size = new Size(160, 256);
      this.listBox_HandleList.TabIndex = 6;
      this.listBox_HandleList.MouseDoubleClick += new MouseEventHandler(this.listBox_TitleList_MouseDoubleClick);
      this.listBox_HandleList.SelectedIndexChanged += new EventHandler(this.listBox_TitleList_SelectedIndexChanged);
      this.label_Search.AutoSize = true;
      this.label_Search.Location = new Point(4, 35);
      this.label_Search.Name = "label_Search";
      this.label_Search.Size = new Size(41, 13);
      this.label_Search.TabIndex = 5;
      this.label_Search.Text = "Search";
      this.textBox_SearchString.Location = new Point(45, 32);
      this.textBox_SearchString.Name = "textBox_SearchString";
      this.textBox_SearchString.Size = new Size((int) sbyte.MaxValue, 20);
      this.textBox_SearchString.TabIndex = 4;
      this.textBox_SearchString.TextChanged += new EventHandler(this.textBox_SearchString_TextChanged);
      this.label_TypeName.AutoSize = true;
      this.label_TypeName.Location = new Point(14, 9);
      this.label_TypeName.Name = "label_TypeName";
      this.label_TypeName.Size = new Size(31, 13);
      this.label_TypeName.TabIndex = 10;
      this.label_TypeName.Text = "Type";
      this.comboBox_SelectType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_SelectType.FormattingEnabled = true;
      this.comboBox_SelectType.Items.AddRange(new object[2]
      {
        (object) "Occupations",
        (object) "Accolades"
      });
      this.comboBox_SelectType.Location = new Point(45, 6);
      this.comboBox_SelectType.Name = "comboBox_SelectType";
      this.comboBox_SelectType.Size = new Size((int) sbyte.MaxValue, 21);
      this.comboBox_SelectType.TabIndex = 9;
      this.comboBox_SelectType.SelectedIndexChanged += new EventHandler(this.comboBox_SelectType_SelectedIndexChanged);
      this.AcceptButton = (IButtonControl) this.button_OK;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button_Cancel;
      this.ClientSize = new Size(180, 345);
      this.Controls.Add((Control) this.label_TypeName);
      this.Controls.Add((Control) this.comboBox_SelectType);
      this.Controls.Add((Control) this.button_Cancel);
      this.Controls.Add((Control) this.button_OK);
      this.Controls.Add((Control) this.listBox_HandleList);
      this.Controls.Add((Control) this.label_Search);
      this.Controls.Add((Control) this.textBox_SearchString);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (HandleSelectWindow);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Select Profile Title";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public DQ9_Cheat.GameData.Handle SelectedHandle => this._selectedHandle;

    private void textBox_SearchString_TextChanged(object sender, EventArgs e) => this.RenewalList();

    private void RenewalList()
    {
      this.listBox_HandleList.BeginUpdate();
      Regex regex = (Regex) null;
      if (!string.IsNullOrEmpty(this.textBox_SearchString.Text))
        regex = new Regex(this.textBox_SearchString.Text, RegexOptions.IgnoreCase);
      this.listBox_HandleList.Items.Clear();
      if (this.comboBox_SelectType.SelectedIndex == 0)
      {
        foreach (ProfileJob profileJob in ProfileJobList.List)
        {
          if (regex != null)
          {
            if (regex.IsMatch(profileJob.Name))
              this.listBox_HandleList.Items.Add((object) profileJob);
          }
          else
            this.listBox_HandleList.Items.Add((object) profileJob);
        }
      }
      else
      {
        foreach (TitleElement titleElement in TitleDataList.List)
        {
          if (regex != null)
          {
            if (regex.IsMatch(this._sex == 0 ? titleElement.MaleTitleName : titleElement.LadyTitleName))
              this.listBox_HandleList.Items.Add((object) new HandleSelectWindow.TitleListBoxItem(this._sex, titleElement));
          }
          else if ((this._sex == 0 ? (!string.IsNullOrEmpty(titleElement.MaleTitleName) ? 1 : 0) : (!string.IsNullOrEmpty(titleElement.LadyTitleName) ? 1 : 0)) != 0)
            this.listBox_HandleList.Items.Add((object) new HandleSelectWindow.TitleListBoxItem(this._sex, titleElement));
        }
      }
      this.listBox_HandleList.EndUpdate();
      if (this.listBox_HandleList.Items.Count > 0)
      {
        this.listBox_HandleList.SelectedIndex = 0;
      }
      else
      {
        this.listBox_HandleList.SelectedIndex = -1;
        this.button_OK.Enabled = false;
      }
    }

    private void listBox_TitleList_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.button_OK.Enabled = this.listBox_HandleList.SelectedIndex != -1;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      if (this.listBox_HandleList.SelectedItem != null)
      {
        if (this.listBox_HandleList.SelectedItem is ProfileJob)
        {
          this._selectedHandle = new DQ9_Cheat.GameData.Handle(this.listBox_HandleList.SelectedItem as ProfileJob);
        }
        else
        {
          if (!(this.listBox_HandleList.SelectedItem is HandleSelectWindow.TitleListBoxItem))
            return;
          this._selectedHandle = new DQ9_Cheat.GameData.Handle((this.listBox_HandleList.SelectedItem as HandleSelectWindow.TitleListBoxItem).TitleElement);
        }
      }
      else
        this.DialogResult = DialogResult.None;
    }

    private void listBox_TitleList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.listBox_HandleList.IndexFromPoint(e.Location) == -1)
        return;
      if (this.listBox_HandleList.SelectedItem != null)
      {
        if (this.listBox_HandleList.SelectedItem is ProfileJob)
          this._selectedHandle = new DQ9_Cheat.GameData.Handle(this.listBox_HandleList.SelectedItem as ProfileJob);
        else if (this.listBox_HandleList.SelectedItem is HandleSelectWindow.TitleListBoxItem)
          this._selectedHandle = new DQ9_Cheat.GameData.Handle((this.listBox_HandleList.SelectedItem as HandleSelectWindow.TitleListBoxItem).TitleElement);
        this.DialogResult = DialogResult.OK;
      }
      else
        this.DialogResult = DialogResult.None;
    }

    private void comboBox_SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.textBox_SearchString.Text = string.Empty;
      this.RenewalList();
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
