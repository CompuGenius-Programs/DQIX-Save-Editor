// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.ItemDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
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
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      this.ItemCountEveryType = new int[10]
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
      this.panel.MouseWheel += new MouseEventHandler(this.panel_MouseWheel);
      this.panel.MouseMove += new MouseEventHandler(this.panel_MouseMove);
    }

    protected override void OnValueUpdate() => this.SetItemData();

    private void panel_MouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta < 0)
      {
        if (this._vScrollBar.Value >= this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 1)
          return;
        this.textBox_Dummy.Focus();
        ++this._vScrollBar.Value;
        this.SetItemData();
      }
      else
      {
        if (this._vScrollBar.Value <= this._vScrollBar.Minimum)
          return;
        this.textBox_Dummy.Focus();
        --this._vScrollBar.Value;
        this.SetItemData();
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
      this.SuspendLayout();
      this.BeginUpdate();
      int index1 = 0;
      int top = 12;
      for (int index2 = 0; index2 < 16; ++index2)
      {
        int left1 = 8;
        for (int index3 = 0; index3 < 3; ++index3)
        {
          this._textBox_ItemName[index1] = new VisionTextBox(left1, top, 113, 20);
          this._textBox_ItemName[index1].ReadOnly = true;
          this._textBox_ItemName[index1].Tag = (object) index1;
          this.panel.AddVisionControl((VisionControlBase) this._textBox_ItemName[index1]);
          int left2 = left1 + (this._textBox_ItemName[index1].Width + 6);
          this._numericUpDown_ItemCount[index1] = new VisionNumericUpDown(left2, top, 38, 20);
          this._numericUpDown_ItemCount[index1].Minimum = 0M;
          this._numericUpDown_ItemCount[index1].Maximum = 99M;
          this._numericUpDown_ItemCount[index1].Tag = (object) index1;
          this._numericUpDown_ItemCount[index1].ValueChanged += new EventHandler(this.NumericUpDown_ItemCount_ValueChanged);
          this.panel.AddVisionControl((VisionControlBase) this._numericUpDown_ItemCount[index1]);
          int left3 = left2 + (this._numericUpDown_ItemCount[index1].Width + 6);
          this._button_SelectItem[index1] = new VisionButton(left3, top, 39, 20);
          this._button_SelectItem[index1].Text = "Set";
          this._button_SelectItem[index1].Tag = (object) index1;
          this._button_SelectItem[index1].Click += new EventHandler(this.Button_SelectItem_Click);
          this.panel.AddVisionControl((VisionControlBase) this._button_SelectItem[index1]);
          left1 = left3 + (this._button_SelectItem[index1].Width + 5);
          ++index1;
        }
        top += 21;
      }
      this.comboBox_ItemListType.SelectedIndex = 0;
      this.EndUpdate();
      this.ResumeLayout(false);
    }

    private void NumericUpDown_ItemCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is VisionNumericUpDown visionNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.ItemData.GetItemNum(this._itemType, this._vScrollBar.Value * 3 + (int) visionNumericUpDown.Tag).Value = (byte) visionNumericUpDown.Value;
    }

    private void Button_SelectItem_Click(object sender, EventArgs e)
    {
      if (!(sender is VisionButton visionButton))
        return;
      ItemSelectWindow itemSelectWindow = new ItemSelectWindow(this._itemType);
      itemSelectWindow.Location = this.PointToScreen(new Point(this.panel.Left + visionButton.Right, this.panel.Top + visionButton.Bottom));
      if (itemSelectWindow.ShowDialog() != DialogResult.OK)
        return;
      ItemDataBase selectedItem = itemSelectWindow.SelectedItem;
      SaveDataManager.Instance.SaveData.ItemData.SetItemData(this._itemType, this._vScrollBar.Value * 3 + (int) visionButton.Tag, selectedItem);
      this.SetItemData();
    }

    private void comboBox_ItemListType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this._itemType = (ItemType) this.comboBox_ItemListType.SelectedIndex;
      this.RenewalScrollBar(this.ItemCountEveryType[this.comboBox_ItemListType.SelectedIndex]);
      if (this._updateCount != 0)
        return;
      this.SetItemData();
    }

    private void RenewalScrollBar(int maxCount)
    {
      this._vScrollBar.Value = 0;
      this._vScrollBar.Maximum = maxCount / 3;
      if (maxCount % 3 != 0)
        ++this._vScrollBar.Maximum;
      this._vScrollBar.LargeChange = 16;
      if (this._vScrollBar.Maximum <= this._vScrollBar.LargeChange)
        this._vScrollBar.Visible = false;
      else
        this._vScrollBar.Visible = true;
    }

    private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      if (this._vScrollBar.Value > this._vScrollBar.Maximum - this._vScrollBar.LargeChange)
      {
        this.BeginUpdate();
        this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange;
        this.EndUpdate();
      }
      this.textBox_Dummy.Focus();
      this.SetItemData();
    }

    private void SetItemData()
    {
      this.BeginUpdate();
      if (this._vScrollBar.Value > this._vScrollBar.Maximum - this._vScrollBar.LargeChange)
        this._vScrollBar.Value = this._vScrollBar.Maximum - this._vScrollBar.LargeChange;
      int index1 = this._vScrollBar.Value * 3;
      int index2 = 0;
      for (int index3 = 0; index3 < 16; ++index3)
      {
        for (int index4 = 0; index4 < 3; ++index4)
        {
          if (index1 >= this.ItemCountEveryType[(int) this._itemType])
          {
            this._textBox_ItemName[index2].Visible = false;
            this._numericUpDown_ItemCount[index2].Visible = false;
            this._button_SelectItem[index2].Visible = false;
          }
          else
          {
            this._textBox_ItemName[index2].Visible = true;
            this._numericUpDown_ItemCount[index2].Visible = true;
            this._button_SelectItem[index2].Visible = true;
            ItemData itemData1 = SaveDataManager.Instance.SaveData.ItemData;
            ItemDataBase itemData2 = itemData1.GetItemData(this._itemType, index1);
            this._textBox_ItemName[index2].Text = itemData2 != null ? itemData2.Name : "Empty";
            this._numericUpDown_ItemCount[index2].Value = (Decimal) itemData1.GetItemNum(this._itemType, index1).Value;
          }
          ++index1;
          ++index2;
        }
      }
      this.EndUpdate();
    }

    private void panel_Click(object sender, EventArgs e) => this.textBox_Dummy.Focus();

    private void textBox_Dummy_KeyDown(object sender, KeyEventArgs e)
    {
      if (this._vScrollBar.Value != this._vScrollBar.Minimum)
      {
        if (e.KeyCode == Keys.Home)
        {
          this._vScrollBar.Value = this._vScrollBar.Minimum;
          this.SetItemData();
        }
        else if (e.KeyCode == Keys.Prior)
        {
          if (this._vScrollBar.Value - (this._vScrollBar.LargeChange - 1) < this._vScrollBar.Minimum)
            this._vScrollBar.Value = this._vScrollBar.Minimum;
          else
            this._vScrollBar.Value -= this._vScrollBar.LargeChange - 1;
          this.SetItemData();
        }
      }
      if (this._vScrollBar.Value == this._vScrollBar.Maximum - this._vScrollBar.LargeChange + 2)
        return;
      if (e.KeyCode == Keys.End)
      {
        this._vScrollBar.Value = this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1) + 1;
        this.SetItemData();
      }
      else
      {
        if (e.KeyCode != Keys.Next)
          return;
        if (this._vScrollBar.Value + (this._vScrollBar.LargeChange - 1) > this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1))
          this._vScrollBar.Value = this._vScrollBar.Maximum - (this._vScrollBar.LargeChange - 1) + 1;
        else
          this._vScrollBar.Value += this._vScrollBar.LargeChange - 1;
        this.SetItemData();
      }
    }

    private void ItemDataControl_Click(object sender, EventArgs e) => this.textBox_Dummy.Focus();

    private void button_Execute_Click(object sender, EventArgs e)
    {
      byte count = (byte) this.numericUpDown_LumpEditItemCount.Value;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      List<ItemType> itemTypeList = new List<ItemType>();
      if (this.checkBox_LumpEditAccessory.Checked)
        itemTypeList.Add(ItemType.Accessory);
      if (this.checkBox_LumpEditArm.Checked)
        itemTypeList.Add(ItemType.Arm);
      if (this.checkBox_LumpEditHead.Checked)
        itemTypeList.Add(ItemType.Head);
      if (this.checkBox_LumpEditImportant.Checked)
        itemTypeList.Add(ItemType.important);
      if (this.checkBox_LumpEditLowerBody.Checked)
        itemTypeList.Add(ItemType.LowerBody);
      if (this.checkBox_LumpEditShield.Checked)
        itemTypeList.Add(ItemType.Shield);
      if (this.checkBox_LumpEditShoe.Checked)
        itemTypeList.Add(ItemType.Shoe);
      if (this.checkBox_LumpEditBag.Checked)
        itemTypeList.Add(ItemType.Tool);
      if (this.checkBox_LumpEditUpperBody.Checked)
        itemTypeList.Add(ItemType.UpperBody);
      if (this.checkBox_LumpEditWeapon.Checked)
        itemTypeList.Add(ItemType.Weapon);
      if (this.radioButton_PossessAll.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.PossessAll(itemType, count);
      }
      else if (this.radioButton_RemoveAll.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.RemoveAll(itemType);
      }
      else if (this.radioButton_RemoveOverlap.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.RemoveOverlap(itemType);
      }
      else if (this.radioButton_SetCountHaving.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.SetCountHaving(itemType, count);
      }
      else if (this.radioButton_SqueezeGap.Checked)
      {
        foreach (ItemType itemType in itemTypeList)
          SaveDataManager.Instance.SaveData.ItemData.SqueezeGap(itemType);
      }
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.SetItemData();
    }

    private void radioButton_LumpEdit_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radioButton_PossessAll.Checked || this.radioButton_SetCountHaving.Checked)
        this.numericUpDown_LumpEditItemCount.Enabled = true;
      else
        this.numericUpDown_LumpEditItemCount.Enabled = false;
    }

    private void checkBox_LumpEditItemType_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBox_LumpEditAccessory.Checked || this.checkBox_LumpEditArm.Checked || this.checkBox_LumpEditBag.Checked || this.checkBox_LumpEditHead.Checked || this.checkBox_LumpEditImportant.Checked || this.checkBox_LumpEditLowerBody.Checked || this.checkBox_LumpEditShield.Checked || this.checkBox_LumpEditShoe.Checked || this.checkBox_LumpEditUpperBody.Checked || this.checkBox_LumpEditWeapon.Checked)
        this.button_Execute.Enabled = true;
      else
        this.button_Execute.Enabled = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.panel = new JS_Panel();
      this.textBox_Dummy = new TextBox();
      this._vScrollBar = new VScrollBar();
      this.comboBox_ItemListType = new ComboBox();
      this.groupBox1 = new GroupBox();
      this.radioButton_RemoveAll = new RadioButton();
      this.radioButton_SqueezeGap = new RadioButton();
      this.radioButton_RemoveOverlap = new RadioButton();
      this.radioButton_SetCountHaving = new RadioButton();
      this.label4 = new Label();
      this.radioButton_PossessAll = new RadioButton();
      this.numericUpDown_LumpEditItemCount = new NumericUpDown();
      this.button_Execute = new Button();
      this.groupBox2 = new GroupBox();
      this.checkBox_LumpEditAccessory = new CheckBox();
      this.checkBox_LumpEditShoe = new CheckBox();
      this.checkBox_LumpEditLowerBody = new CheckBox();
      this.checkBox_LumpEditArm = new CheckBox();
      this.checkBox_LumpEditUpperBody = new CheckBox();
      this.checkBox_LumpEditHead = new CheckBox();
      this.checkBox_LumpEditShield = new CheckBox();
      this.checkBox_LumpEditWeapon = new CheckBox();
      this.checkBox_LumpEditImportant = new CheckBox();
      this.checkBox_LumpEditBag = new CheckBox();
      this.panel.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.numericUpDown_LumpEditItemCount.BeginInit();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.panel.BorderStyle = BorderStyle.Fixed3D;
      this.panel.Controls.Add((Control) this.textBox_Dummy);
      this.panel.Controls.Add((Control) this._vScrollBar);
      this.panel.Location = new Point(6, 39);
      this.panel.Name = "panel";
      this.panel.Size = new Size(653, 359);
      this.panel.TabIndex = 1;
      this.panel.Click += new EventHandler(this.panel_Click);
      this.textBox_Dummy.Location = new Point(-100, -100);
      this.textBox_Dummy.Name = "textBox_Dummy";
      this.textBox_Dummy.ReadOnly = true;
      this.textBox_Dummy.Size = new Size(100, 19);
      this.textBox_Dummy.TabIndex = 1;
      this.textBox_Dummy.KeyDown += new KeyEventHandler(this.textBox_Dummy_KeyDown);
      this._vScrollBar.Dock = DockStyle.Right;
      this._vScrollBar.Location = new Point(632, 0);
      this._vScrollBar.Name = "_vScrollBar";
      this._vScrollBar.Size = new Size(17, 355);
      this._vScrollBar.TabIndex = 0;
      this._vScrollBar.Value = 100;
      this._vScrollBar.ValueChanged += new EventHandler(this._vScrollBar_ValueChanged);
      this._vScrollBar.Scroll += new ScrollEventHandler(this.vScrollBar_Scroll);
      this.comboBox_ItemListType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_ItemListType.FormattingEnabled = true;
      this.comboBox_ItemListType.Items.AddRange(new object[10]
      {
        (object) "Everyday Items",
        (object) "Important Items",
        (object) "Weapons",
        (object) "Shields",
        (object) "Head",
        (object) "Torso",
        (object) "Arms",
        (object) "Legs",
        (object) "Feet",
        (object) "Accessories"
      });
      this.comboBox_ItemListType.Location = new Point(6, 9);
      this.comboBox_ItemListType.Name = "comboBox_ItemListType";
      this.comboBox_ItemListType.Size = new Size(121, 20);
      this.comboBox_ItemListType.TabIndex = 0;
      this.comboBox_ItemListType.SelectedIndexChanged += new EventHandler(this.comboBox_ItemListType_SelectedIndexChanged);
      this.groupBox1.Controls.Add((Control) this.radioButton_RemoveAll);
      this.groupBox1.Controls.Add((Control) this.radioButton_SqueezeGap);
      this.groupBox1.Controls.Add((Control) this.radioButton_RemoveOverlap);
      this.groupBox1.Controls.Add((Control) this.radioButton_SetCountHaving);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.radioButton_PossessAll);
      this.groupBox1.Controls.Add((Control) this.numericUpDown_LumpEditItemCount);
      this.groupBox1.Controls.Add((Control) this.button_Execute);
      this.groupBox1.Controls.Add((Control) this.groupBox2);
      this.groupBox1.Location = new Point(665, 32);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(164, 366);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Bulk Edit";
      this.radioButton_RemoveAll.AutoSize = true;
      this.radioButton_RemoveAll.Location = new Point(14, 41);
      this.radioButton_RemoveAll.Name = "radioButton_RemoveAll";
      this.radioButton_RemoveAll.Size = new Size(148, 16);
      this.radioButton_RemoveAll.TabIndex = 8;
      this.radioButton_RemoveAll.TabStop = true;
      this.radioButton_RemoveAll.Text = "Remove all";
      this.radioButton_RemoveAll.UseVisualStyleBackColor = true;
      this.radioButton_RemoveAll.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.radioButton_SqueezeGap.AutoSize = true;
      this.radioButton_SqueezeGap.Location = new Point(14, 101);
      this.radioButton_SqueezeGap.Name = "radioButton_SqueezeGap";
      this.radioButton_SqueezeGap.Size = new Size(87, 16);
      this.radioButton_SqueezeGap.TabIndex = 3;
      this.radioButton_SqueezeGap.TabStop = true;
      this.radioButton_SqueezeGap.Text = "Sort";
      this.radioButton_SqueezeGap.UseVisualStyleBackColor = true;
      this.radioButton_SqueezeGap.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.radioButton_RemoveOverlap.AutoSize = true;
      this.radioButton_RemoveOverlap.Location = new Point(14, 81);
      this.radioButton_RemoveOverlap.Name = "radioButton_RemoveOverlap";
      this.radioButton_RemoveOverlap.Size = new Size(118, 16);
      this.radioButton_RemoveOverlap.TabIndex = 2;
      this.radioButton_RemoveOverlap.TabStop = true;
      this.radioButton_RemoveOverlap.Text = "Remove duplicates";
      this.radioButton_RemoveOverlap.UseVisualStyleBackColor = true;
      this.radioButton_RemoveOverlap.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.radioButton_SetCountHaving.AutoSize = true;
      this.radioButton_SetCountHaving.Location = new Point(14, 61);
      this.radioButton_SetCountHaving.Name = "radioButton_SetCountHaving";
      this.radioButton_SetCountHaving.Size = new Size(142, 16);
      this.radioButton_SetCountHaving.TabIndex = 1;
      this.radioButton_SetCountHaving.TabStop = true;
      this.radioButton_SetCountHaving.Text = "Change Amount of All";
      this.radioButton_SetCountHaving.UseVisualStyleBackColor = true;
      this.radioButton_SetCountHaving.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(15, 133);
      this.label4.Name = "label4";
      this.label4.Size = new Size(29, 12);
      this.label4.TabIndex = 7;
      this.label4.Text = "Qty";
      this.radioButton_PossessAll.AutoSize = true;
      this.radioButton_PossessAll.Location = new Point(14, 21);
      this.radioButton_PossessAll.Name = "radioButton_PossessAll";
      this.radioButton_PossessAll.Size = new Size(124, 16);
      this.radioButton_PossessAll.TabIndex = 0;
      this.radioButton_PossessAll.TabStop = true;
      this.radioButton_PossessAll.Text = "Give all";
      this.radioButton_PossessAll.UseVisualStyleBackColor = true;
      this.radioButton_PossessAll.CheckedChanged += new EventHandler(this.radioButton_LumpEdit_CheckedChanged);
      this.numericUpDown_LumpEditItemCount.Enabled = false;
      this.numericUpDown_LumpEditItemCount.Location = new Point(46, 129);
      this.numericUpDown_LumpEditItemCount.Maximum = new Decimal(new int[4]
      {
        99,
        0,
        0,
        0
      });
      this.numericUpDown_LumpEditItemCount.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_LumpEditItemCount.Name = "numericUpDown_LumpEditItemCount";
      this.numericUpDown_LumpEditItemCount.Size = new Size(41, 19);
      this.numericUpDown_LumpEditItemCount.TabIndex = 6;
      this.numericUpDown_LumpEditItemCount.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.button_Execute.Enabled = false;
      this.button_Execute.Location = new Point(93, (int) sbyte.MaxValue);
      this.button_Execute.Name = "button_Execute";
      this.button_Execute.Size = new Size(49, 23);
      this.button_Execute.TabIndex = 4;
      this.button_Execute.Text = "Go";
      this.button_Execute.UseVisualStyleBackColor = true;
      this.button_Execute.Click += new EventHandler(this.button_Execute_Click);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditAccessory);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditShoe);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditLowerBody);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditArm);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditUpperBody);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditHead);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditShield);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditWeapon);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditImportant);
      this.groupBox2.Controls.Add((Control) this.checkBox_LumpEditBag);
      this.groupBox2.Location = new Point(11, 164);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(130, 193);
      this.groupBox2.TabIndex = 0;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Inventories to Edit:";
      this.checkBox_LumpEditAccessory.AutoSize = true;
      this.checkBox_LumpEditAccessory.Location = new Point(22, 172);
      this.checkBox_LumpEditAccessory.Name = "checkBox_LumpEditAccessory";
      this.checkBox_LumpEditAccessory.Size = new Size(78, 16);
      this.checkBox_LumpEditAccessory.TabIndex = 9;
      this.checkBox_LumpEditAccessory.Text = "Accessories";
      this.checkBox_LumpEditAccessory.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditAccessory.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.checkBox_LumpEditShoe.AutoSize = true;
      this.checkBox_LumpEditShoe.Location = new Point(22, 155);
      this.checkBox_LumpEditShoe.Name = "checkBox_LumpEditShoe";
      this.checkBox_LumpEditShoe.Size = new Size(36, 16);
      this.checkBox_LumpEditShoe.TabIndex = 8;
      this.checkBox_LumpEditShoe.Text = "Feet";
      this.checkBox_LumpEditShoe.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditShoe.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.checkBox_LumpEditLowerBody.AutoSize = true;
      this.checkBox_LumpEditLowerBody.Location = new Point(22, 138);
      this.checkBox_LumpEditLowerBody.Name = "checkBox_LumpEditLowerBody";
      this.checkBox_LumpEditLowerBody.Size = new Size(94, 16);
      this.checkBox_LumpEditLowerBody.TabIndex = 7;
      this.checkBox_LumpEditLowerBody.Text = "Legs";
      this.checkBox_LumpEditLowerBody.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditLowerBody.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.checkBox_LumpEditArm.AutoSize = true;
      this.checkBox_LumpEditArm.Location = new Point(22, 121);
      this.checkBox_LumpEditArm.Name = "checkBox_LumpEditArm";
      this.checkBox_LumpEditArm.Size = new Size(70, 16);
      this.checkBox_LumpEditArm.TabIndex = 6;
      this.checkBox_LumpEditArm.Text = "Arms";
      this.checkBox_LumpEditArm.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditArm.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.checkBox_LumpEditUpperBody.AutoSize = true;
      this.checkBox_LumpEditUpperBody.Location = new Point(22, 104);
      this.checkBox_LumpEditUpperBody.Name = "checkBox_LumpEditUpperBody";
      this.checkBox_LumpEditUpperBody.Size = new Size(94, 16);
      this.checkBox_LumpEditUpperBody.TabIndex = 5;
      this.checkBox_LumpEditUpperBody.Text = "Torso";
      this.checkBox_LumpEditUpperBody.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditUpperBody.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.checkBox_LumpEditHead.AutoSize = true;
      this.checkBox_LumpEditHead.Location = new Point(22, 87);
      this.checkBox_LumpEditHead.Name = "checkBox_LumpEditHead";
      this.checkBox_LumpEditHead.Size = new Size(70, 16);
      this.checkBox_LumpEditHead.TabIndex = 4;
      this.checkBox_LumpEditHead.Text = "Head";
      this.checkBox_LumpEditHead.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditHead.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.checkBox_LumpEditShield.AutoSize = true;
      this.checkBox_LumpEditShield.Location = new Point(22, 70);
      this.checkBox_LumpEditShield.Name = "checkBox_LumpEditShield";
      this.checkBox_LumpEditShield.Size = new Size(36, 16);
      this.checkBox_LumpEditShield.TabIndex = 3;
      this.checkBox_LumpEditShield.Text = "Shields";
      this.checkBox_LumpEditShield.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditShield.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.checkBox_LumpEditWeapon.AutoSize = true;
      this.checkBox_LumpEditWeapon.Location = new Point(22, 53);
      this.checkBox_LumpEditWeapon.Name = "checkBox_LumpEditWeapon";
      this.checkBox_LumpEditWeapon.Size = new Size(48, 16);
      this.checkBox_LumpEditWeapon.TabIndex = 2;
      this.checkBox_LumpEditWeapon.Text = "Weapons";
      this.checkBox_LumpEditWeapon.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditWeapon.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.checkBox_LumpEditImportant.AutoSize = true;
      this.checkBox_LumpEditImportant.Location = new Point(22, 36);
      this.checkBox_LumpEditImportant.Name = "checkBox_LumpEditImportant";
      this.checkBox_LumpEditImportant.Size = new Size(77, 16);
      this.checkBox_LumpEditImportant.TabIndex = 1;
      this.checkBox_LumpEditImportant.Text = "Important Items";
      this.checkBox_LumpEditImportant.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditImportant.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.checkBox_LumpEditBag.AutoSize = true;
      this.checkBox_LumpEditBag.Location = new Point(22, 19);
      this.checkBox_LumpEditBag.Name = "checkBox_LumpEditBag";
      this.checkBox_LumpEditBag.Size = new Size(49, 16);
      this.checkBox_LumpEditBag.TabIndex = 0;
      this.checkBox_LumpEditBag.Text = "Everyday Items";
      this.checkBox_LumpEditBag.UseVisualStyleBackColor = true;
      this.checkBox_LumpEditBag.CheckedChanged += new EventHandler(this.checkBox_LumpEditItemType_CheckedChanged);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.comboBox_ItemListType);
      this.Controls.Add((Control) this.panel);
      this.Name = nameof (ItemDataControl);
      this.Size = new Size(840, 405);
      this.Click += new EventHandler(this.ItemDataControl_Click);
      this.panel.ResumeLayout(false);
      this.panel.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.numericUpDown_LumpEditItemCount.EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
