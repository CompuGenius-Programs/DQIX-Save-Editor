// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.AddressSelectWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DQ9_Cheat.GameData;

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
      InitializeComponent();
      comboBox_SelectType.SelectedIndex = 0;
      RenewalList();
    }

    public ProfileAddress SelectedAddress => _selectedAddress;

    private void RenewalList()
    {
      ReadOnlyCollection<ProfileAddress> readOnlyCollection = comboBox_SelectType.SelectedIndex != 0 ? (comboBox_SelectType.SelectedIndex != 1 ? (comboBox_SelectType.SelectedIndex != 2 ? ProfileAddressList.UnknownAreaList : ProfileAddressList.DQAreaList) : ProfileAddressList.OtherAreaList) : ProfileAddressList.PrefectureList;
      Regex regex = null;
      if (!string.IsNullOrEmpty(textBox_SearchString.Text))
        regex = new Regex(textBox_SearchString.Text, RegexOptions.IgnoreCase);
      listBox_AddressList.BeginUpdate();
      listBox_AddressList.Items.Clear();
      foreach (ProfileAddress profileAddress in readOnlyCollection)
      {
        if (regex != null)
        {
          if (regex.IsMatch(profileAddress.Name))
            listBox_AddressList.Items.Add(profileAddress);
        }
        else
          listBox_AddressList.Items.Add(profileAddress);
      }
      listBox_AddressList.EndUpdate();
      button_OK.Enabled = false;
    }

    private void textBox_SearchString_TextChanged(object sender, EventArgs e) => RenewalList();

    private void listBox_ItemList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (listBox_AddressList.IndexFromPoint(e.Location) == -1)
        return;
      _selectedAddress = listBox_AddressList.SelectedItem as ProfileAddress;
      DialogResult = DialogResult.OK;
    }

    private void listBox_ItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
      button_OK.Enabled = listBox_AddressList.SelectedIndex != -1;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      _selectedAddress = listBox_AddressList.SelectedItem as ProfileAddress;
    }

    private void comboBox_SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
      textBox_SearchString.Text = string.Empty;
      RenewalList();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      textBox_SearchString = new TextBox();
      label_Search = new Label();
      listBox_AddressList = new ListBox();
      button_OK = new Button();
      button_Cancel = new Button();
      comboBox_SelectType = new ComboBox();
      label_TypeName = new Label();
      SuspendLayout();
      textBox_SearchString.Location = new Point(47, 32);
      textBox_SearchString.Name = "textBox_SearchString";
      textBox_SearchString.Size = new Size(sbyte.MaxValue, 20);
      textBox_SearchString.TabIndex = 0;
      textBox_SearchString.TextChanged += textBox_SearchString_TextChanged;
      label_Search.AutoSize = true;
      label_Search.Location = new Point(6, 35);
      label_Search.Name = "label_Search";
      label_Search.Size = new Size(41, 13);
      label_Search.TabIndex = 1;
      label_Search.Text = "Search";
      listBox_AddressList.FormattingEnabled = true;
      listBox_AddressList.ItemHeight = 12;
      listBox_AddressList.Location = new Point(6, 57);
      listBox_AddressList.Name = "listBox_AddressList";
      listBox_AddressList.Size = new Size(168, 251);
      listBox_AddressList.TabIndex = 1;
      listBox_AddressList.MouseDoubleClick += listBox_ItemList_MouseDoubleClick;
      listBox_AddressList.SelectedIndexChanged += listBox_ItemList_SelectedIndexChanged;
      button_OK.DialogResult = DialogResult.OK;
      button_OK.Enabled = false;
      button_OK.Location = new Point(47, 317);
      button_OK.Name = "button_OK";
      button_OK.Size = new Size(61, 23);
      button_OK.TabIndex = 2;
      button_OK.Text = "OK";
      button_OK.UseVisualStyleBackColor = true;
      button_OK.Click += button_OK_Click;
      button_Cancel.DialogResult = DialogResult.Cancel;
      button_Cancel.Location = new Point(114, 317);
      button_Cancel.Name = "button_Cancel";
      button_Cancel.Size = new Size(61, 23);
      button_Cancel.TabIndex = 3;
      button_Cancel.Text = "Cancel";
      button_Cancel.UseVisualStyleBackColor = true;
      comboBox_SelectType.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_SelectType.FormattingEnabled = true;
      comboBox_SelectType.Items.AddRange(new object[4]
      {
        "Countries",
        "Continents",
        "DQ Locations",
        "???"
      });
      comboBox_SelectType.Location = new Point(47, 6);
      comboBox_SelectType.Name = "comboBox_SelectType";
      comboBox_SelectType.Size = new Size(sbyte.MaxValue, 21);
      comboBox_SelectType.TabIndex = 4;
      comboBox_SelectType.SelectedIndexChanged += comboBox_SelectType_SelectedIndexChanged;
      label_TypeName.AutoSize = true;
      label_TypeName.Location = new Point(16, 9);
      label_TypeName.Name = "label_TypeName";
      label_TypeName.Size = new Size(31, 13);
      label_TypeName.TabIndex = 5;
      label_TypeName.Text = "Type";
      AcceptButton = button_OK;
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = button_Cancel;
      ClientSize = new Size(180, 342);
      Controls.Add(label_TypeName);
      Controls.Add(comboBox_SelectType);
      Controls.Add(button_Cancel);
      Controls.Add(button_OK);
      Controls.Add(listBox_AddressList);
      Controls.Add(label_Search);
      Controls.Add(textBox_SearchString);
      FormBorderStyle = FormBorderStyle.Fixed3D;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = nameof (AddressSelectWindow);
      ShowIcon = false;
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.Manual;
      Text = "Location";
      ResumeLayout(false);
      PerformLayout();
    }
  }
}
