// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.AddressSelectWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class AddressSelectWindow : Form
  {
    private ProfileAddress _selectedAddress;
    private IContainer components;
    private TextBox textBox_SearchString;
    private Label label_Search;
    private ListBox listBox_AddressList;
    private Button button_OK;
    private Button button_Cancel;
    private ComboBox comboBox_SelectType;
    private Label label_TypeName;

    public AddressSelectWindow()
    {
      this.InitializeComponent();
      this.comboBox_SelectType.SelectedIndex = 0;
      this.RenewalList();
    }

    public ProfileAddress SelectedAddress => this._selectedAddress;

    private void RenewalList()
    {
      ReadOnlyCollection<ProfileAddress> readOnlyCollection = this.comboBox_SelectType.SelectedIndex != 0 ? (this.comboBox_SelectType.SelectedIndex != 1 ? (this.comboBox_SelectType.SelectedIndex != 2 ? ProfileAddressList.UnknownAreaList : ProfileAddressList.DQAreaList) : ProfileAddressList.OtherAreaList) : ProfileAddressList.PrefectureList;
      Regex regex = (Regex) null;
      if (!string.IsNullOrEmpty(this.textBox_SearchString.Text))
        regex = new Regex(this.textBox_SearchString.Text, RegexOptions.IgnoreCase);
      this.listBox_AddressList.BeginUpdate();
      this.listBox_AddressList.Items.Clear();
      foreach (ProfileAddress profileAddress in readOnlyCollection)
      {
        if (regex != null)
        {
          if (regex.IsMatch(profileAddress.Name))
            this.listBox_AddressList.Items.Add((object) profileAddress);
        }
        else
          this.listBox_AddressList.Items.Add((object) profileAddress);
      }
      this.listBox_AddressList.EndUpdate();
      this.button_OK.Enabled = false;
    }

    private void textBox_SearchString_TextChanged(object sender, EventArgs e) => this.RenewalList();

    private void listBox_ItemList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.listBox_AddressList.IndexFromPoint(e.Location) == -1)
        return;
      this._selectedAddress = this.listBox_AddressList.SelectedItem as ProfileAddress;
      this.DialogResult = DialogResult.OK;
    }

    private void listBox_ItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.button_OK.Enabled = this.listBox_AddressList.SelectedIndex != -1;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      this._selectedAddress = this.listBox_AddressList.SelectedItem as ProfileAddress;
    }

    private void comboBox_SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.textBox_SearchString.Text = string.Empty;
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
      this.textBox_SearchString = new TextBox();
      this.label_Search = new Label();
      this.listBox_AddressList = new ListBox();
      this.button_OK = new Button();
      this.button_Cancel = new Button();
      this.comboBox_SelectType = new ComboBox();
      this.label_TypeName = new Label();
      this.SuspendLayout();
      this.textBox_SearchString.Location = new Point(47, 32);
      this.textBox_SearchString.Name = "textBox_SearchString";
      this.textBox_SearchString.Size = new Size((int) sbyte.MaxValue, 20);
      this.textBox_SearchString.TabIndex = 0;
      this.textBox_SearchString.TextChanged += new EventHandler(this.textBox_SearchString_TextChanged);
      this.label_Search.AutoSize = true;
      this.label_Search.Location = new Point(6, 35);
      this.label_Search.Name = "label_Search";
      this.label_Search.Size = new Size(41, 13);
      this.label_Search.TabIndex = 1;
      this.label_Search.Text = "Search";
      this.listBox_AddressList.FormattingEnabled = true;
      this.listBox_AddressList.ItemHeight = 12;
      this.listBox_AddressList.Location = new Point(6, 57);
      this.listBox_AddressList.Name = "listBox_AddressList";
      this.listBox_AddressList.Size = new Size(168, 251);
      this.listBox_AddressList.TabIndex = 1;
      this.listBox_AddressList.MouseDoubleClick += new MouseEventHandler(this.listBox_ItemList_MouseDoubleClick);
      this.listBox_AddressList.SelectedIndexChanged += new EventHandler(this.listBox_ItemList_SelectedIndexChanged);
      this.button_OK.DialogResult = DialogResult.OK;
      this.button_OK.Enabled = false;
      this.button_OK.Location = new Point(47, 317);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new Size(61, 23);
      this.button_OK.TabIndex = 2;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new EventHandler(this.button_OK_Click);
      this.button_Cancel.DialogResult = DialogResult.Cancel;
      this.button_Cancel.Location = new Point(114, 317);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new Size(61, 23);
      this.button_Cancel.TabIndex = 3;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.comboBox_SelectType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_SelectType.FormattingEnabled = true;
      this.comboBox_SelectType.Items.AddRange(new object[4]
      {
        (object) "Countries",
        (object) "Continents",
        (object) "DQ Locations",
        (object) "???"
      });
      this.comboBox_SelectType.Location = new Point(47, 6);
      this.comboBox_SelectType.Name = "comboBox_SelectType";
      this.comboBox_SelectType.Size = new Size((int) sbyte.MaxValue, 21);
      this.comboBox_SelectType.TabIndex = 4;
      this.comboBox_SelectType.SelectedIndexChanged += new EventHandler(this.comboBox_SelectType_SelectedIndexChanged);
      this.label_TypeName.AutoSize = true;
      this.label_TypeName.Location = new Point(16, 9);
      this.label_TypeName.Name = "label_TypeName";
      this.label_TypeName.Size = new Size(31, 13);
      this.label_TypeName.TabIndex = 5;
      this.label_TypeName.Text = "Type";
      this.AcceptButton = (IButtonControl) this.button_OK;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button_Cancel;
      this.ClientSize = new Size(180, 342);
      this.Controls.Add((Control) this.label_TypeName);
      this.Controls.Add((Control) this.comboBox_SelectType);
      this.Controls.Add((Control) this.button_Cancel);
      this.Controls.Add((Control) this.button_OK);
      this.Controls.Add((Control) this.listBox_AddressList);
      this.Controls.Add((Control) this.label_Search);
      this.Controls.Add((Control) this.textBox_SearchString);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AddressSelectWindow);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Location";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
