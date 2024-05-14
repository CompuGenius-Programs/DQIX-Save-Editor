// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.ItemSelectWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
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
      this.InitializeComponent();
      if (itemTypes.Length == 0)
        return;
      this._itemTypes.AddRange((IEnumerable<ItemType>) itemTypes);
      foreach (ItemType itemType in itemTypes)
      {
        string str = (string) null;
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
          this.comboBox_SelectType.Items.Add((object) str);
      }
      this.comboBox_SelectType.SelectedIndex = 0;
      this._itemType = itemTypes[0];
      this.RenewalCaption();
      this.RenewalList();
    }

    public ItemSelectWindow(ItemType itemType)
    {
      this.InitializeComponent();
      this.comboBox_SelectType.Enabled = false;
      this.comboBox_SelectType.Visible = false;
      this.label_TypeName.Visible = false;
      this.label_Search.Top -= 26;
      this.textBox_SearchString.Top -= 26;
      this.listBox_ItemList.Top -= 26;
      this.button_OK.Top -= 26;
      this.button_Cancel.Top -= 26;
      this.Height -= 26;
      this._itemType = itemType;
      this.RenewalCaption();
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
      this.listBox_ItemList = new ListBox();
      this.button_OK = new Button();
      this.button_Cancel = new Button();
      this.comboBox_SelectType = new ComboBox();
      this.label_TypeName = new Label();
      this.SuspendLayout();
      this.textBox_SearchString.Location = new Point(47, 32);
      this.textBox_SearchString.Name = "textBox_SearchString";
      this.textBox_SearchString.Size = new Size((int) sbyte.MaxValue, 19);
      this.textBox_SearchString.TabIndex = 0;
      this.textBox_SearchString.TextChanged += new EventHandler(this.textBox_SearchString_TextChanged);
      this.label_Search.AutoSize = true;
      this.label_Search.Location = new Point(5, 35);
      this.label_Search.Name = "label_Search";
      this.label_Search.Size = new Size(29, 12);
      this.label_Search.TabIndex = 1;
      this.label_Search.Text = "Search";
      this.label_Search.TextAlign = ContentAlignment.MiddleRight;
      this.listBox_ItemList.FormattingEnabled = true;
      this.listBox_ItemList.ItemHeight = 12;
      this.listBox_ItemList.Location = new Point(14, 57);
      this.listBox_ItemList.Name = "listBox_ItemList";
      this.listBox_ItemList.Size = new Size(160, 256);
      this.listBox_ItemList.TabIndex = 1;
      this.listBox_ItemList.MouseDoubleClick += new MouseEventHandler(this.listBox_ItemList_MouseDoubleClick);
      this.listBox_ItemList.SelectedIndexChanged += new EventHandler(this.listBox_ItemList_SelectedIndexChanged);
      this.button_OK.DialogResult = DialogResult.OK;
      this.button_OK.Enabled = false;
      this.button_OK.Location = new Point(46, 317);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new Size(61, 23);
      this.button_OK.TabIndex = 2;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new EventHandler(this.button_OK_Click);
      this.button_Cancel.DialogResult = DialogResult.Cancel;
      this.button_Cancel.Location = new Point(113, 317);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new Size(61, 23);
      this.button_Cancel.TabIndex = 3;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.comboBox_SelectType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_SelectType.FormattingEnabled = true;
      this.comboBox_SelectType.Location = new Point(47, 6);
      this.comboBox_SelectType.Name = "comboBox_SelectType";
      this.comboBox_SelectType.Size = new Size((int) sbyte.MaxValue, 20);
      this.comboBox_SelectType.TabIndex = 4;
      this.comboBox_SelectType.SelectedIndexChanged += new EventHandler(this.comboBox_SelectType_SelectedIndexChanged);
      this.label_TypeName.AutoSize = true;
      this.label_TypeName.Location = new Point(12, 10);
      this.label_TypeName.Name = "label_TypeName";
      this.label_TypeName.Size = new Size(29, 12);
      this.label_TypeName.TabIndex = 5;
      this.label_TypeName.Text = "Type";
      this.AcceptButton = (IButtonControl) this.button_OK;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button_Cancel;
      this.ClientSize = new Size(186, 342);
      this.Controls.Add((Control) this.label_TypeName);
      this.Controls.Add((Control) this.comboBox_SelectType);
      this.Controls.Add((Control) this.button_Cancel);
      this.Controls.Add((Control) this.button_OK);
      this.Controls.Add((Control) this.listBox_ItemList);
      this.Controls.Add((Control) this.label_Search);
      this.Controls.Add((Control) this.textBox_SearchString);
      this.FormBorderStyle = FormBorderStyle.Fixed3D;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ItemSelectWindow);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Item Options";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public ItemDataBase SelectedItem => this._selectedItem;

    private void RenewalList()
    {
      ItemDataBase[] itemDataBaseArray = this.textBox_SearchString.Text.Length <= 0 ? ItemDataList.GetList(this._itemType, (string) null) : ItemDataList.GetList(this._itemType, this.textBox_SearchString.Text);
      this.listBox_ItemList.BeginUpdate();
      this.listBox_ItemList.Items.Clear();
      this.listBox_ItemList.Items.Add((object) "Empty");
      foreach (object obj in itemDataBaseArray)
        this.listBox_ItemList.Items.Add(obj);
      this.listBox_ItemList.EndUpdate();
      this.button_OK.Enabled = false;
    }

    private void textBox_SearchString_TextChanged(object sender, EventArgs e) => this.RenewalList();

    private void listBox_ItemList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (this.listBox_ItemList.IndexFromPoint(e.Location) == -1)
        return;
      this._selectedItem = this.listBox_ItemList.SelectedItem as ItemDataBase;
      this.DialogResult = DialogResult.OK;
    }

    private void listBox_ItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.button_OK.Enabled = this.listBox_ItemList.SelectedIndex != -1;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
      this._selectedItem = this.listBox_ItemList.SelectedItem as ItemDataBase;
    }

    private void RenewalCaption()
    {
      switch (this._itemType)
      {
        case ItemType.Tool:
          this.Text = "Set Item";
          break;
        case ItemType.important:
          this.Text = "Set Important Items";
          break;
        case ItemType.Weapon:
          this.Text = "Set Weapon";
          break;
        case ItemType.Shield:
          this.Text = "Set Shield";
          break;
        case ItemType.Head:
          this.Text = "Set Head";
          break;
        case ItemType.UpperBody:
          this.Text = "Set Torso";
          break;
        case ItemType.Arm:
          this.Text = "Set Arms";
          break;
        case ItemType.LowerBody:
          this.Text = "Set Legs";
          break;
        case ItemType.Shoe:
          this.Text = "Set Feet";
          break;
        case ItemType.Accessory:
          this.Text = "Set Accessory";
          break;
      }
    }

    private void comboBox_SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this._itemType = this._itemTypes[this.comboBox_SelectType.SelectedIndex];
      this.textBox_SearchString.Text = string.Empty;
      this.RenewalCaption();
      this.RenewalList();
    }
  }
}
