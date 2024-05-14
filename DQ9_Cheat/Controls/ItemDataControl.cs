// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.ItemDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls
{
  public class ItemDataControl : DataControlBase
  {
    private const int ControlMarginWidth = 16;
    private const int ControlMarginHeight = 12;
    private const int Horizontal = 3;
    private const int Vertical = 16;
    private VisionTextBox[] _textBox_ItemName = new VisionTextBox[48];
    private VisionButton[] _button_SelectItem = new VisionButton[48];
    private VisionNumericUpDown[] _numericUpDown_ItemCount = new VisionNumericUpDown[48];
    private ItemType _itemType;
    private int[] ItemCountEveryType;
    private IContainer components;
    private JS_Panel panel;
    private ComboBox comboBox_ItemListType;
    private VScrollBar _vScrollBar;
    private TextBox textBox_Dummy;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private CheckBox checkBox_LumpEditImportant;
    private CheckBox checkBox_LumpEditBag;
    private CheckBox checkBox_LumpEditShield;
    private CheckBox checkBox_LumpEditWeapon;
    private CheckBox checkBox_LumpEditAccessory;
    private CheckBox checkBox_LumpEditShoe;
    private CheckBox checkBox_LumpEditLowerBody;
    private CheckBox checkBox_LumpEditArm;
    private CheckBox checkBox_LumpEditUpperBody;
    private CheckBox checkBox_LumpEditHead;
    private Label label4;
    private NumericUpDown numericUpDown_LumpEditItemCount;
    private RadioButton radioButton_SqueezeGap;
    private RadioButton radioButton_RemoveOverlap;
    private RadioButton radioButton_SetCountHaving;
    private RadioButton radioButton_PossessAll;
    private RadioButton radioButton_RemoveAll;
    private Button button_Execute;

    public ItemDataControl()
    {
      AutoScaleMode = AutoScaleMode.None;
      InitializeComponent();
      ItemCountEveryType = new int[10]
      {
        152,
        94,
        272,
        48,
        144,
        192,
        80,
        96,
        112,
        64
      };
      panel.MouseWheel += panel_MouseWheel;
      panel.MouseMove += panel_MouseMove;
    }

    protected override void OnValueUpdate() => SetItemData();

    private void panel_MouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta < 0)
      {
        if (_vScrollBar.Value >= _vScrollBar.Maximum - _vScrollBar.LargeChange + 1)
          return;
        textBox_Dummy.Focus();
        ++_vScrollBar.Value;
        SetItemData();
      }
      else
      {
        if (_vScrollBar.Value <= _vScrollBar.Minimum)
          return;
        textBox_Dummy.Focus();
        --_vScrollBar.Value;
        SetItemData();
      }
    }

    private void panel_MouseMove(object sender, MouseEventArgs e)
    {
    }

    private void panelPaint()
    {
    }

    public void Initialize()
    {
      SuspendLayout();
      BeginUpdate();
      int index1 = 0;
      int top = 12;
      for (int index2 = 0; index2 < 16; ++index2)
      {
        int left1 = 8;
        for (int index3 = 0; index3 < 3; ++index3)
        {
          _textBox_ItemName[index1] = new VisionTextBox(left1, top, 113, 20);
          _textBox_ItemName[index1].ReadOnly = true;
          _textBox_ItemName[index1].Tag = index1;
          panel.AddVisionControl(_textBox_ItemName[index1]);
          int left2 = left1 + (_textBox_ItemName[index1].Width + 6);
          _numericUpDown_ItemCount[index1] = new VisionNumericUpDown(left2, top, 38, 20);
          _numericUpDown_ItemCount[index1].Minimum = 0M;
          _numericUpDown_ItemCount[index1].Maximum = 99M;
          _numericUpDown_ItemCount[index1].Tag = index1;
          _numericUpDown_ItemCount[index1].ValueChanged += NumericUpDown_ItemCount_ValueChanged;
          panel.AddVisionControl(_numericUpDown_ItemCount[index1]);
          int left3 = left2 + (_numericUpDown_ItemCount[index1].Width + 6);
          _button_SelectItem[index1] = new VisionButton(left3, top, 39, 20);
          _button_SelectItem[index1].Text = "Set";
          _button_SelectItem[index1].Tag = index1;
          _button_SelectItem[index1].Click += Button_SelectItem_Click;
          panel.AddVisionControl(_button_SelectItem[index1]);
          left1 = left3 + (_button_SelectItem[index1].Width + 5);
          ++index1;
        }
        top += 21;
      }
      comboBox_ItemListType.SelectedIndex = 0;
      EndUpdate();
      ResumeLayout(false);
    }

    private void NumericUpDown_ItemCount_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.ItemData.GetItemNum(_itemType, _vScrollBar.Value * 3 + (int) visionNumericUpDown.Tag).Value = (byte) visionNumericUpDown.Value;
    }

    private void Button_SelectItem_Click(object sender, EventArgs e)
    {
      if (!(sender is VisionButton visionButton))
        return;
      ItemSelectWindow itemSelectWindow = new ItemSelectWindow(_itemType);
      itemSelectWindow.Location = PointToScreen(new Point(panel.Left + visionButton.Right, panel.Top + visionButton.Bottom));
      if (itemSelectWindow.ShowDialog() != DialogResult.OK)
        return;
      ItemDataBase selectedItem = itemSelectWindow.SelectedItem;
      SaveDataManager.Instance.SaveData.ItemData.SetItemData(_itemType, _vScrollBar.Value * 3 + (int) visionButton.Tag, selectedItem);
      SetItemData();
    }

    private void comboBox_ItemListType_SelectedIndexChanged(object sender, EventArgs e)
    {
      _itemType = (ItemType) comboBox_ItemListType.SelectedIndex;
      RenewalScrollBar(ItemCountEveryType[comboBox_ItemListType.SelectedIndex]);
      if (_updateCount != 0)
        return;
      SetItemData();
    }

    private void RenewalScrollBar(int maxCount)
    {
      _vScrollBar.Value = 0;
      _vScrollBar.Maximum = maxCount / 3;
      if (maxCount % 3 != 0)
        ++_vScrollBar.Maximum;
      _vScrollBar.LargeChange = 16;
      if (_vScrollBar.Maximum <= _vScrollBar.LargeChange)
        _vScrollBar.Visible = false;
      else
        _vScrollBar.Visible = true;
    }

    private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      if (_vScrollBar.Value > _vScrollBar.Maximum - _vScrollBar.LargeChange)
      {
        BeginUpdate();
        _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange;
        EndUpdate();
      }
      textBox_Dummy.Focus();
      SetItemData();
    }

    private void SetItemData()
    {
      BeginUpdate();
      if (_vScrollBar.Value > _vScrollBar.Maximum - _vScrollBar.LargeChange)
        _vScrollBar.Value = _vScrollBar.Maximum - _vScrollBar.LargeChange;
      int index1 = _vScrollBar.Value * 3;
      int index2 = 0;
      for (int index3 = 0; index3 < 16; ++index3)
      {
        for (int index4 = 0; index4 < 3; ++index4)
        {
          if (index1 >= ItemCountEveryType[(int) _itemType])
          {
            _textBox_ItemName[index2].Visible = false;
            _numericUpDown_ItemCount[index2].Visible = false;
            _button_SelectItem[index2].Visible = false;
          }
          else
          {
            _textBox_ItemName[index2].Visible = true;
            _numericUpDown_ItemCount[index2].Visible = true;
            _button_SelectItem[index2].Visible = true;
            ItemData itemData1 = SaveDataManager.Instance.SaveData.ItemData;
            ItemDataBase itemData2 = itemData1.GetItemData(_itemType, index1);
            _textBox_ItemName[index2].Text = itemData2 != null ? itemData2.Name : "Empty";
            _numericUpDown_ItemCount[index2].Value = itemData1.GetItemNum(_itemType, index1).Value;
          }
          ++index1;
          ++index2;
        }
      }
      EndUpdate();
    }

    private void panel_Click(object sender, EventArgs e) => textBox_Dummy.Focus();

    private void textBox_Dummy_KeyDown(object sender, KeyEventArgs e)
    {
      if (_vScrollBar.Value != _vScrollBar.Minimum)
      {
        if (e.KeyCode == Keys.Home)
        {
          _vScrollBar.Value = _vScrollBar.Minimum;
          SetItemData();
        }
        else if (e.KeyCode == Keys.Prior)
        {
          if (_vScrollBar.Value - (_vScrollBar.LargeChange - 1) < _vScrollBar.Minimum)
            _vScrollBar.Value = _vScrollBar.Minimum;
          else
            _vScrollBar.Value -= _vScrollBar.LargeChange - 1;
          SetItemData();
        }
      }
      if (_vScrollBar.Value == _vScrollBar.Maximum - _vScrollBar.LargeChange + 2)
        return;
      if (e.KeyCode == Keys.End)
      {
        _vScrollBar.Value = _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1) + 1;
        SetItemData();
      }
      else
      {
        if (e.KeyCode != Keys.Next)
          return;
        if (_vScrollBar.Value + (_vScrollBar.LargeChange - 1) > _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1))
          _vScrollBar.Value = _vScrollBar.Maximum - (_vScrollBar.LargeChange - 1) + 1;
        else
          _vScrollBar.Value += _vScrollBar.LargeChange - 1;
        SetItemData();
      }
    }

    private void ItemDataControl_Click(object sender, EventArgs e) => textBox_Dummy.Focus();

    private void button_Execute_Click(object sender, EventArgs e)
    {
      byte count = (byte) numericUpDown_LumpEditItemCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      List<ItemType> itemTypeList = new List<ItemType>();
      if (checkBox_LumpEditAccessory.Checked)
        itemTypeList.Add(ItemType.Accessory);
      if (checkBox_LumpEditArm.Checked)
        itemTypeList.Add(ItemType.Arm);
      if (checkBox_LumpEditHead.Checked)
        itemTypeList.Add(ItemType.Head);
      if (checkBox_LumpEditImportant.Checked)
        itemTypeList.Add(ItemType.important);
      if (checkBox_LumpEditLowerBody.Checked)
        itemTypeList.Add(ItemType.LowerBody);
      if (checkBox_LumpEditShield.Checked)
        itemTypeList.Add(ItemType.Shield);
      if (checkBox_LumpEditShoe.Checked)
        itemTypeList.Add(ItemType.Shoe);
      if (checkBox_LumpEditBag.Checked)
        itemTypeList.Add(ItemType.Tool);
      if (checkBox_LumpEditUpperBody.Checked)
        itemTypeList.Add(ItemType.UpperBody);
      if (checkBox_LumpEditWeapon.Checked)
        itemTypeList.Add(ItemType.Weapon);
      if (radioButton_PossessAll.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.PossessAll(itemType, count);
      }
      else if (radioButton_RemoveAll.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.RemoveAll(itemType);
      }
      else if (radioButton_RemoveOverlap.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.RemoveOverlap(itemType);
      }
      else if (radioButton_SetCountHaving.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.SetCountHaving(itemType, count);
      }
      else if (radioButton_SqueezeGap.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.SqueezeGap(itemType);
      }
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      SetItemData();
    }

    private void radioButton_LumpEdit_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButton_PossessAll.Checked || radioButton_SetCountHaving.Checked)
        numericUpDown_LumpEditItemCount.Enabled = true;
      else
        numericUpDown_LumpEditItemCount.Enabled = false;
    }

    private void checkBox_LumpEditItemType_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBox_LumpEditAccessory.Checked || checkBox_LumpEditArm.Checked || checkBox_LumpEditBag.Checked || checkBox_LumpEditHead.Checked || checkBox_LumpEditImportant.Checked || checkBox_LumpEditLowerBody.Checked || checkBox_LumpEditShield.Checked || checkBox_LumpEditShoe.Checked || checkBox_LumpEditUpperBody.Checked || checkBox_LumpEditWeapon.Checked)
        button_Execute.Enabled = true;
      else
        button_Execute.Enabled = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      panel = new JS_Panel();
      textBox_Dummy = new TextBox();
      _vScrollBar = new VScrollBar();
      comboBox_ItemListType = new ComboBox();
      groupBox1 = new GroupBox();
      radioButton_RemoveAll = new RadioButton();
      radioButton_SqueezeGap = new RadioButton();
      radioButton_RemoveOverlap = new RadioButton();
      radioButton_SetCountHaving = new RadioButton();
      label4 = new Label();
      radioButton_PossessAll = new RadioButton();
      numericUpDown_LumpEditItemCount = new NumericUpDown();
      button_Execute = new Button();
      groupBox2 = new GroupBox();
      checkBox_LumpEditAccessory = new CheckBox();
      checkBox_LumpEditShoe = new CheckBox();
      checkBox_LumpEditLowerBody = new CheckBox();
      checkBox_LumpEditArm = new CheckBox();
      checkBox_LumpEditUpperBody = new CheckBox();
      checkBox_LumpEditHead = new CheckBox();
      checkBox_LumpEditShield = new CheckBox();
      checkBox_LumpEditWeapon = new CheckBox();
      checkBox_LumpEditImportant = new CheckBox();
      checkBox_LumpEditBag = new CheckBox();
      panel.SuspendLayout();
      groupBox1.SuspendLayout();
      numericUpDown_LumpEditItemCount.BeginInit();
      groupBox2.SuspendLayout();
      SuspendLayout();
      panel.BorderStyle = BorderStyle.Fixed3D;
      panel.Controls.Add(textBox_Dummy);
      panel.Controls.Add(_vScrollBar);
      panel.Location = new Point(6, 39);
      panel.Name = "panel";
      panel.Size = new Size(653, 359);
      panel.TabIndex = 1;
      panel.Click += panel_Click;
      textBox_Dummy.Location = new Point(-100, -100);
      textBox_Dummy.Name = "textBox_Dummy";
      textBox_Dummy.ReadOnly = true;
      textBox_Dummy.Size = new Size(100, 19);
      textBox_Dummy.TabIndex = 1;
      textBox_Dummy.KeyDown += textBox_Dummy_KeyDown;
      _vScrollBar.Dock = DockStyle.Right;
      _vScrollBar.Location = new Point(632, 0);
      _vScrollBar.Name = "_vScrollBar";
      _vScrollBar.Size = new Size(17, 355);
      _vScrollBar.TabIndex = 0;
      _vScrollBar.Value = 100;
      _vScrollBar.ValueChanged += _vScrollBar_ValueChanged;
      _vScrollBar.Scroll += vScrollBar_Scroll;
      comboBox_ItemListType.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_ItemListType.FormattingEnabled = true;
      comboBox_ItemListType.Items.AddRange(new object[10]
      {
        "Everyday Items",
        "Important Items",
        "Weapons",
        "Shields",
        "Head",
        "Torso",
        "Arms",
        "Legs",
        "Feet",
        "Accessories"
      });
      comboBox_ItemListType.Location = new Point(6, 9);
      comboBox_ItemListType.Name = "comboBox_ItemListType";
      comboBox_ItemListType.Size = new Size(121, 20);
      comboBox_ItemListType.TabIndex = 0;
      comboBox_ItemListType.SelectedIndexChanged += comboBox_ItemListType_SelectedIndexChanged;
      groupBox1.Controls.Add(radioButton_RemoveAll);
      groupBox1.Controls.Add(radioButton_SqueezeGap);
      groupBox1.Controls.Add(radioButton_RemoveOverlap);
      groupBox1.Controls.Add(radioButton_SetCountHaving);
      groupBox1.Controls.Add(label4);
      groupBox1.Controls.Add(radioButton_PossessAll);
      groupBox1.Controls.Add(numericUpDown_LumpEditItemCount);
      groupBox1.Controls.Add(button_Execute);
      groupBox1.Controls.Add(groupBox2);
      groupBox1.Location = new Point(665, 32);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new Size(164, 366);
      groupBox1.TabIndex = 2;
      groupBox1.TabStop = false;
      groupBox1.Text = "Bulk Edit";
      radioButton_RemoveAll.AutoSize = true;
      radioButton_RemoveAll.Location = new Point(14, 41);
      radioButton_RemoveAll.Name = "radioButton_RemoveAll";
      radioButton_RemoveAll.Size = new Size(148, 16);
      radioButton_RemoveAll.TabIndex = 8;
      radioButton_RemoveAll.TabStop = true;
      radioButton_RemoveAll.Text = "Remove all";
      radioButton_RemoveAll.UseVisualStyleBackColor = true;
      radioButton_RemoveAll.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      radioButton_SqueezeGap.AutoSize = true;
      radioButton_SqueezeGap.Location = new Point(14, 101);
      radioButton_SqueezeGap.Name = "radioButton_SqueezeGap";
      radioButton_SqueezeGap.Size = new Size(87, 16);
      radioButton_SqueezeGap.TabIndex = 3;
      radioButton_SqueezeGap.TabStop = true;
      radioButton_SqueezeGap.Text = "Sort";
      radioButton_SqueezeGap.UseVisualStyleBackColor = true;
      radioButton_SqueezeGap.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      radioButton_RemoveOverlap.AutoSize = true;
      radioButton_RemoveOverlap.Location = new Point(14, 81);
      radioButton_RemoveOverlap.Name = "radioButton_RemoveOverlap";
      radioButton_RemoveOverlap.Size = new Size(118, 16);
      radioButton_RemoveOverlap.TabIndex = 2;
      radioButton_RemoveOverlap.TabStop = true;
      radioButton_RemoveOverlap.Text = "Remove duplicates";
      radioButton_RemoveOverlap.UseVisualStyleBackColor = true;
      radioButton_RemoveOverlap.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      radioButton_SetCountHaving.AutoSize = true;
      radioButton_SetCountHaving.Location = new Point(14, 61);
      radioButton_SetCountHaving.Name = "radioButton_SetCountHaving";
      radioButton_SetCountHaving.Size = new Size(142, 16);
      radioButton_SetCountHaving.TabIndex = 1;
      radioButton_SetCountHaving.TabStop = true;
      radioButton_SetCountHaving.Text = "Change Amount of All";
      radioButton_SetCountHaving.UseVisualStyleBackColor = true;
      radioButton_SetCountHaving.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      label4.AutoSize = true;
      label4.Location = new Point(15, 133);
      label4.Name = "label4";
      label4.Size = new Size(29, 12);
      label4.TabIndex = 7;
      label4.Text = "Qty";
      radioButton_PossessAll.AutoSize = true;
      radioButton_PossessAll.Location = new Point(14, 21);
      radioButton_PossessAll.Name = "radioButton_PossessAll";
      radioButton_PossessAll.Size = new Size(124, 16);
      radioButton_PossessAll.TabIndex = 0;
      radioButton_PossessAll.TabStop = true;
      radioButton_PossessAll.Text = "Give all";
      radioButton_PossessAll.UseVisualStyleBackColor = true;
      radioButton_PossessAll.CheckedChanged += radioButton_LumpEdit_CheckedChanged;
      numericUpDown_LumpEditItemCount.Enabled = false;
      numericUpDown_LumpEditItemCount.Location = new Point(46, 129);
      numericUpDown_LumpEditItemCount.Maximum = new Decimal(new int[4]
      {
        99,
        0,
        0,
        0
      });
      numericUpDown_LumpEditItemCount.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_LumpEditItemCount.Name = "numericUpDown_LumpEditItemCount";
      numericUpDown_LumpEditItemCount.Size = new Size(41, 19);
      numericUpDown_LumpEditItemCount.TabIndex = 6;
      numericUpDown_LumpEditItemCount.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      button_Execute.Enabled = false;
      button_Execute.Location = new Point(93, sbyte.MaxValue);
      button_Execute.Name = "button_Execute";
      button_Execute.Size = new Size(49, 23);
      button_Execute.TabIndex = 4;
      button_Execute.Text = "Go";
      button_Execute.UseVisualStyleBackColor = true;
      button_Execute.Click += button_Execute_Click;
      groupBox2.Controls.Add(checkBox_LumpEditAccessory);
      groupBox2.Controls.Add(checkBox_LumpEditShoe);
      groupBox2.Controls.Add(checkBox_LumpEditLowerBody);
      groupBox2.Controls.Add(checkBox_LumpEditArm);
      groupBox2.Controls.Add(checkBox_LumpEditUpperBody);
      groupBox2.Controls.Add(checkBox_LumpEditHead);
      groupBox2.Controls.Add(checkBox_LumpEditShield);
      groupBox2.Controls.Add(checkBox_LumpEditWeapon);
      groupBox2.Controls.Add(checkBox_LumpEditImportant);
      groupBox2.Controls.Add(checkBox_LumpEditBag);
      groupBox2.Location = new Point(11, 164);
      groupBox2.Name = "groupBox2";
      groupBox2.Size = new Size(130, 193);
      groupBox2.TabIndex = 0;
      groupBox2.TabStop = false;
      groupBox2.Text = "Inventories to Edit:";
      checkBox_LumpEditAccessory.AutoSize = true;
      checkBox_LumpEditAccessory.Location = new Point(22, 172);
      checkBox_LumpEditAccessory.Name = "checkBox_LumpEditAccessory";
      checkBox_LumpEditAccessory.Size = new Size(78, 16);
      checkBox_LumpEditAccessory.TabIndex = 9;
      checkBox_LumpEditAccessory.Text = "Accessories";
      checkBox_LumpEditAccessory.UseVisualStyleBackColor = true;
      checkBox_LumpEditAccessory.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      checkBox_LumpEditShoe.AutoSize = true;
      checkBox_LumpEditShoe.Location = new Point(22, 155);
      checkBox_LumpEditShoe.Name = "checkBox_LumpEditShoe";
      checkBox_LumpEditShoe.Size = new Size(36, 16);
      checkBox_LumpEditShoe.TabIndex = 8;
      checkBox_LumpEditShoe.Text = "Feet";
      checkBox_LumpEditShoe.UseVisualStyleBackColor = true;
      checkBox_LumpEditShoe.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      checkBox_LumpEditLowerBody.AutoSize = true;
      checkBox_LumpEditLowerBody.Location = new Point(22, 138);
      checkBox_LumpEditLowerBody.Name = "checkBox_LumpEditLowerBody";
      checkBox_LumpEditLowerBody.Size = new Size(94, 16);
      checkBox_LumpEditLowerBody.TabIndex = 7;
      checkBox_LumpEditLowerBody.Text = "Legs";
      checkBox_LumpEditLowerBody.UseVisualStyleBackColor = true;
      checkBox_LumpEditLowerBody.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      checkBox_LumpEditArm.AutoSize = true;
      checkBox_LumpEditArm.Location = new Point(22, 121);
      checkBox_LumpEditArm.Name = "checkBox_LumpEditArm";
      checkBox_LumpEditArm.Size = new Size(70, 16);
      checkBox_LumpEditArm.TabIndex = 6;
      checkBox_LumpEditArm.Text = "Arms";
      checkBox_LumpEditArm.UseVisualStyleBackColor = true;
      checkBox_LumpEditArm.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      checkBox_LumpEditUpperBody.AutoSize = true;
      checkBox_LumpEditUpperBody.Location = new Point(22, 104);
      checkBox_LumpEditUpperBody.Name = "checkBox_LumpEditUpperBody";
      checkBox_LumpEditUpperBody.Size = new Size(94, 16);
      checkBox_LumpEditUpperBody.TabIndex = 5;
      checkBox_LumpEditUpperBody.Text = "Torso";
      checkBox_LumpEditUpperBody.UseVisualStyleBackColor = true;
      checkBox_LumpEditUpperBody.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      checkBox_LumpEditHead.AutoSize = true;
      checkBox_LumpEditHead.Location = new Point(22, 87);
      checkBox_LumpEditHead.Name = "checkBox_LumpEditHead";
      checkBox_LumpEditHead.Size = new Size(70, 16);
      checkBox_LumpEditHead.TabIndex = 4;
      checkBox_LumpEditHead.Text = "Head";
      checkBox_LumpEditHead.UseVisualStyleBackColor = true;
      checkBox_LumpEditHead.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      checkBox_LumpEditShield.AutoSize = true;
      checkBox_LumpEditShield.Location = new Point(22, 70);
      checkBox_LumpEditShield.Name = "checkBox_LumpEditShield";
      checkBox_LumpEditShield.Size = new Size(36, 16);
      checkBox_LumpEditShield.TabIndex = 3;
      checkBox_LumpEditShield.Text = "Shields";
      checkBox_LumpEditShield.UseVisualStyleBackColor = true;
      checkBox_LumpEditShield.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      checkBox_LumpEditWeapon.AutoSize = true;
      checkBox_LumpEditWeapon.Location = new Point(22, 53);
      checkBox_LumpEditWeapon.Name = "checkBox_LumpEditWeapon";
      checkBox_LumpEditWeapon.Size = new Size(48, 16);
      checkBox_LumpEditWeapon.TabIndex = 2;
      checkBox_LumpEditWeapon.Text = "Weapons";
      checkBox_LumpEditWeapon.UseVisualStyleBackColor = true;
      checkBox_LumpEditWeapon.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      checkBox_LumpEditImportant.AutoSize = true;
      checkBox_LumpEditImportant.Location = new Point(22, 36);
      checkBox_LumpEditImportant.Name = "checkBox_LumpEditImportant";
      checkBox_LumpEditImportant.Size = new Size(77, 16);
      checkBox_LumpEditImportant.TabIndex = 1;
      checkBox_LumpEditImportant.Text = "Important Items";
      checkBox_LumpEditImportant.UseVisualStyleBackColor = true;
      checkBox_LumpEditImportant.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      checkBox_LumpEditBag.AutoSize = true;
      checkBox_LumpEditBag.Location = new Point(22, 19);
      checkBox_LumpEditBag.Name = "checkBox_LumpEditBag";
      checkBox_LumpEditBag.Size = new Size(49, 16);
      checkBox_LumpEditBag.TabIndex = 0;
      checkBox_LumpEditBag.Text = "Everyday Items";
      checkBox_LumpEditBag.UseVisualStyleBackColor = true;
      checkBox_LumpEditBag.CheckedChanged += checkBox_LumpEditItemType_CheckedChanged;
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(groupBox1);
      Controls.Add(comboBox_ItemListType);
      Controls.Add(panel);
      Name = nameof (ItemDataControl);
      Size = new Size(840, 405);
      Click += ItemDataControl_Click;
      panel.ResumeLayout(false);
      panel.PerformLayout();
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      numericUpDown_LumpEditItemCount.EndInit();
      groupBox2.ResumeLayout(false);
      groupBox2.PerformLayout();
      ResumeLayout(false);
    }
  }
}
