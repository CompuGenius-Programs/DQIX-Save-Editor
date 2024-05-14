// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.ItemSelectWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls
{
  public class ItemSelectWindow : Form
  {
    private IContainer components;
    private TextBox textBox_SearchString;
    private Label label_Search;
    private ListBox listBox_ItemList;
    private Button button_OK;
    private Button button_Cancel;
    private ComboBox comboBox_SelectType;
    private Label label_TypeName;
    private ItemType _itemType;
    private ItemDataBase _selectedItem;
    private List<ItemType> _itemTypes = new List<ItemType>();

    public ItemSelectWindow(ItemType[] itemTypes)
    {
      InitializeComponent();
      if (itemTypes.Length == 0)
        return;
      _itemTypes.AddRange(itemTypes);
      foreach (ItemType itemType in itemTypes)
      {
        string str = null;
        switch (itemType)
        {
          case ItemType.Tool:
            str = "Items";
            break;
          case ItemType.important:
            str = "Important Items";
            break;
          case ItemType.Weapon:
            str = "Weapons";
            break;
          case ItemType.Shield:
            str = "Shields";
            break;
          case ItemType.Head:
            str = "Head";
            break;
          case ItemType.UpperBody:
            str = "Torso";
            break;
          case ItemType.Arm:
            str = "Arms";
            break;
          case ItemType.LowerBody:
            str = "Legs";
            break;
          case ItemType.Shoe:
            str = "Feet";
            break;
          case ItemType.Accessory:
            str = "Accessories";
            break;
        }
        if (str != null)
          comboBox_SelectType.Items.Add(str);
      }
      comboBox_SelectType.SelectedIndex = 0;
      _itemType = itemTypes[0];
      RenewalCaption();
      RenewalList();
    }

    public ItemSelectWindow(ItemType itemType)
    {
      InitializeComponent();
      comboBox_SelectType.Enabled = false;
      comboBox_SelectType.Visible = false;
      label_TypeName.Visible = false;
      label_Search.Top -= 26;
      textBox_SearchString.Top -= 26;
      listBox_ItemList.Top -= 26;
      button_OK.Top -= 26;
      button_Cancel.Top -= 26;
      Height -= 26;
      _itemType = itemType;
      RenewalCaption();
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
      listBox_ItemList = new ListBox();
      button_OK = new Button();
      button_Cancel = new Button();
      comboBox_SelectType = new ComboBox();
      label_TypeName = new Label();
      SuspendLayout();
      textBox_SearchString.Location = new Point(47, 32);
      textBox_SearchString.Name = "textBox_SearchString";
      textBox_SearchString.Size = new Size(sbyte.MaxValue, 19);
      textBox_SearchString.TabIndex = 0;
      textBox_SearchString.TextChanged += textBox_SearchString_TextChanged;
      label_Search.AutoSize = true;
      label_Search.Location = new Point(5, 35);
      label_Search.Name = "label_Search";
      label_Search.Size = new Size(29, 12);
      label_Search.TabIndex = 1;
      label_Search.Text = "Search";
      label_Search.TextAlign = ContentAlignment.MiddleRight;
      listBox_ItemList.FormattingEnabled = true;
      listBox_ItemList.ItemHeight = 12;
      listBox_ItemList.Location = new Point(14, 57);
      listBox_ItemList.Name = "listBox_ItemList";
      listBox_ItemList.Size = new Size(160, 256);
      listBox_ItemList.TabIndex = 1;
      listBox_ItemList.MouseDoubleClick += listBox_ItemList_MouseDoubleClick;
      listBox_ItemList.SelectedIndexChanged += listBox_ItemList_SelectedIndexChanged;
      button_OK.DialogResult = DialogResult.OK;
      button_OK.Enabled = false;
      button_OK.Location = new Point(46, 317);
      button_OK.Name = "button_OK";
      button_OK.Size = new Size(61, 23);
      button_OK.TabIndex = 2;
      button_OK.Text = "OK";
      button_OK.UseVisualStyleBackColor = true;
      button_OK.Click += button_OK_Click;
      button_Cancel.DialogResult = DialogResult.Cancel;
      button_Cancel.Location = new Point(113, 317);
      button_Cancel.Name = "button_Cancel";
      button_Cancel.Size = new Size(61, 23);
      button_Cancel.TabIndex = 3;
      button_Cancel.Text = "Cancel";
      button_Cancel.UseVisualStyleBackColor = true;
      comboBox_SelectType.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_SelectType.FormattingEnabled = true;
      comboBox_SelectType.Location = new Point(47, 6);
      comboBox_SelectType.Name = "comboBox_SelectType";
      comboBox_SelectType.Size = new Size(sbyte.MaxValue, 20);
      comboBox_SelectType.TabIndex = 4;
      comboBox_SelectType.SelectedIndexChanged += comboBox_SelectType_SelectedIndexChanged;
      label_TypeName.AutoSize = true;
      label_TypeName.Location = new Point(12, 10);
      label_TypeName.Name = "label_TypeName";
      label_TypeName.Size = new Size(29, 12);
      label_TypeName.TabIndex = 5;
      label_TypeName.Text = "Type";
      AcceptButton = button_OK;
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = button_Cancel;
      ClientSize = new Size(186, 342);
      Controls.Add(label_TypeName);
      Controls.Add(comboBox_SelectType);
      Controls.Add(button_Cancel);
      Controls.Add(button_OK);
      Controls.Add(listBox_ItemList);
      Controls.Add(label_Search);
      Controls.Add(textBox_SearchString);
      FormBorderStyle = FormBorderStyle.Fixed3D;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = nameof (ItemSelectWindow);
      ShowIcon = false;
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.Manual;
      Text = "Item Options";
      ResumeLayout(false);
      PerformLayout();
    }

    public ItemDataBase SelectedItem => _selectedItem;

    private void RenewalList()
    {
      ItemDataBase[] itemDataBaseArray = textBox_SearchString.Text.Length <= 0 ? ItemDataList.GetList(_itemType, null) : ItemDataList.GetList(_itemType, textBox_SearchString.Text);
      listBox_ItemList.BeginUpdate();
      listBox_ItemList.Items.Clear();
      listBox_ItemList.Items.Add("Empty");
      foreach (object obj in itemDataBaseArray)
        listBox_ItemList.Items.Add(obj);
      listBox_ItemList.EndUpdate();
      button_OK.Enabled = false;
    }

    private void textBox_SearchString_TextChanged(object sender, EventArgs e) => RenewalList();

    private void listBox_ItemList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (listBox_ItemList.IndexFromPoint(e.Location) == -1)
        return;
      _selectedItem = listBox_ItemList.SelectedItem as ItemDataBase;
      DialogResult = DialogResult.OK;
    }

    private void listBox_ItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
      button_OK.Enabled = listBox_ItemList.SelectedIndex != -1;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      _selectedItem = listBox_ItemList.SelectedItem as ItemDataBase;
    }

    private void RenewalCaption()
    {
      switch (_itemType)
      {
        case ItemType.Tool:
          Text = "Set Item";
          break;
        case ItemType.important:
          Text = "Set Important Items";
          break;
        case ItemType.Weapon:
          Text = "Set Weapon";
          break;
        case ItemType.Shield:
          Text = "Set Shield";
          break;
        case ItemType.Head:
          Text = "Set Head";
          break;
        case ItemType.UpperBody:
          Text = "Set Torso";
          break;
        case ItemType.Arm:
          Text = "Set Arms";
          break;
        case ItemType.LowerBody:
          Text = "Set Legs";
          break;
        case ItemType.Shoe:
          Text = "Set Feet";
          break;
        case ItemType.Accessory:
          Text = "Set Accessory";
          break;
      }
    }

    private void comboBox_SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
      _itemType = _itemTypes[comboBox_SelectType.SelectedIndex];
      textBox_SearchString.Text = string.Empty;
      RenewalCaption();
      RenewalList();
    }
  }
}
