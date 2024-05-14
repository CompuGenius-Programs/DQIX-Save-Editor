// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.WifiShoppingDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls
{
  public class WifiShoppingDataControl : DataControlBase
  {
    private TextBox[] _textBoxItemNames = new TextBox[6];
    private Button[] _buttonItemSelects = new Button[6];
    private SafeNumericUpDown[] _numericUpDownItemCounts = new SafeNumericUpDown[6];
    private SafeNumericUpDown[] _numericUpDownItemPrices = new SafeNumericUpDown[6];
    private IContainer components;
    private Label label1;
    private SafeNumericUpDown numericUpDown_AllowNextConnectHour;
    private Label label2;
    private SafeNumericUpDown numericUpDown_AllowNextConnectDay;
    private Label label3;
    private SafeNumericUpDown numericUpDown_AllowNextConnectMonth;
    private Label label4;
    private SafeNumericUpDown numericUpDown_AllowNextConnectYear;
    private Label label5;
    private Label label6;
    private SafeNumericUpDown numericUpDown_ExpiresHour;
    private Label label7;
    private SafeNumericUpDown numericUpDown_ExpiresDay;
    private Label label8;
    private SafeNumericUpDown numericUpDown_ExpiresMonth;
    private Label label9;
    private SafeNumericUpDown numericUpDown_ExpiresYear;
    private Label label10;
    private Label label16;
    private SafeNumericUpDown numericUpDown_MessageExpiresHour;
    private Label label17;
    private SafeNumericUpDown numericUpDown_MessageExpiresDay;
    private Label label18;
    private SafeNumericUpDown numericUpDown_MessageExpiresMonth;
    private Label label19;
    private SafeNumericUpDown numericUpDown_MessageExpiresYear;
    private Label label20;
    private TextBox textBox_Message;

    public WifiShoppingDataControl()
    {
      AutoScaleMode = AutoScaleMode.None;
      InitializeComponent();
      for (int index = 0; index < 6; ++index)
      {
        _textBoxItemNames[index] = new TextBox();
        _textBoxItemNames[index].ReadOnly = true;
        _textBoxItemNames[index].Location = new Point(31, 99 + 25 * index);
        _textBoxItemNames[index].Size = new Size(113, 20);
        _textBoxItemNames[index].Tag = index;
        Controls.Add(_textBoxItemNames[index]);
        _buttonItemSelects[index] = new Button();
        _buttonItemSelects[index].Text = "Set";
        _buttonItemSelects[index].Location = new Point(150, 99 + 25 * index);
        _buttonItemSelects[index].Size = new Size(37, 20);
        _buttonItemSelects[index].UseVisualStyleBackColor = true;
        _buttonItemSelects[index].Tag = index;
        _buttonItemSelects[index].Click += ButtonItemSelects_Click;
        Controls.Add(_buttonItemSelects[index]);
        _numericUpDownItemCounts[index] = new SafeNumericUpDown();
        _numericUpDownItemCounts[index].Location = new Point(223, 99 + 25 * index);
        _numericUpDownItemCounts[index].Size = new Size(40, 20);
        _numericUpDownItemCounts[index].Tag = index;
        _numericUpDownItemCounts[index].Maximum = 127M;
        _numericUpDownItemCounts[index].Minimum = 0M;
        _numericUpDownItemCounts[index].ValueChanged += NumericUpDownItemCounts_ValueChanged;
        Controls.Add(_numericUpDownItemCounts[index]);
        _numericUpDownItemPrices[index] = new SafeNumericUpDown();
        _numericUpDownItemPrices[index].Location = new Point(303, 99 + 25 * index);
        _numericUpDownItemPrices[index].Size = new Size(71, 20);
        _numericUpDownItemPrices[index].Maximum = 33554431M;
        _numericUpDownItemPrices[index].Minimum = 0M;
        _numericUpDownItemPrices[index].Tag = index;
        _numericUpDownItemPrices[index].ValueChanged += NumericUpDownItemPrices_ValueChanged;
        Controls.Add(_numericUpDownItemPrices[index]);
      }
    }

    private void NumericUpDownItemPrices_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is SafeNumericUpDown safeNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.WifiShopGoods[(int) safeNumericUpDown.Tag].ItemPrice = (uint) safeNumericUpDown.Value;
    }

    private void NumericUpDownItemCounts_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is SafeNumericUpDown safeNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.WifiShopGoods[(int) safeNumericUpDown.Tag].ItemCount = (byte) safeNumericUpDown.Value;
    }

    private void ButtonItemSelects_Click(object sender, EventArgs e)
    {
      if (!(sender is Button button))
        return;
      ItemSelectWindow itemSelectWindow = new ItemSelectWindow(new ItemType[9]
      {
        ItemType.Tool,
        ItemType.Weapon,
        ItemType.Shield,
        ItemType.Head,
        ItemType.UpperBody,
        ItemType.Arm,
        ItemType.LowerBody,
        ItemType.Shoe,
        ItemType.Accessory
      });
      itemSelectWindow.Location = PointToScreen(new Point(Left + button.Right, Top + button.Bottom));
      if (itemSelectWindow.ShowDialog() != DialogResult.OK)
        return;
      ItemDataBase selectedItem = itemSelectWindow.SelectedItem;
      SaveDataManager.Instance.SaveData.WifiShopData.WifiShopGoods[(int) button.Tag].Item = selectedItem;
      OnValueUpdate();
    }

    protected override void OnValueUpdate()
    {
      BeginUpdate();
      WifiShopping wifiShopData = SaveDataManager.Instance.SaveData.WifiShopData;
      numericUpDown_ExpiresYear.Value = wifiShopData.ExpiresYear;
      numericUpDown_ExpiresMonth.Value = wifiShopData.ExpiresMonth;
      numericUpDown_ExpiresDay.Value = wifiShopData.ExpiresDay;
      numericUpDown_ExpiresHour.Value = wifiShopData.ExpiresHour;
      numericUpDown_AllowNextConnectYear.Value = wifiShopData.AllowNextConnectYear;
      numericUpDown_AllowNextConnectMonth.Value = wifiShopData.AllowNextConnectMonth;
      numericUpDown_AllowNextConnectDay.Value = wifiShopData.AllowNextConnectDay;
      numericUpDown_AllowNextConnectHour.Value = wifiShopData.AllowNextConnectHour;
      numericUpDown_MessageExpiresYear.Value = wifiShopData.MessageExpiresYear;
      numericUpDown_MessageExpiresMonth.Value = wifiShopData.MessageExpiresMonth;
      numericUpDown_MessageExpiresDay.Value = wifiShopData.MessageExpiresDay;
      numericUpDown_MessageExpiresHour.Value = wifiShopData.MessageExpiresHour;
      textBox_Message.Text = wifiShopData.Message;
      for (int index = 0; index < 6; ++index)
      {
        ItemDataBase itemDataBase = wifiShopData.WifiShopGoods[index].Item;
        if (itemDataBase != null)
          _textBoxItemNames[index].Text = itemDataBase.Name;
        else
          _textBoxItemNames[index].Text = "Empty";
        _numericUpDownItemCounts[index].Value = wifiShopData.WifiShopGoods[index].ItemCount;
        _numericUpDownItemPrices[index].Value = wifiShopData.WifiShopGoods[index].ItemPrice;
      }
      EndUpdate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      using (Brush brush = new SolidBrush(SystemColors.ControlText))
      {
        for (int index = 0; index < 6; ++index)
        {
          e.Graphics.DrawString("Qty", Font, brush, 198f, 101 + 25 * index);
          e.Graphics.DrawString("Price", Font, brush, 271f, 101 + 25 * index);
        }
        e.Graphics.DrawString("Message", Font, brush, 413f, 79f);
        e.Graphics.DrawString("<PAGE>: New page", Font, brush, 413f, 254f);
        e.Graphics.DrawString("<PAD_WAIT>: Wait for button press", Font, brush, 413f, 270f);
        e.Graphics.DrawString("<END>: End message", Font, brush, 413f, 286f);
      }
    }

    private void numericUpDown_ExpiresYear_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.ExpiresYear = (ushort) numericUpDown_ExpiresYear.Value;
    }

    private void numericUpDown_ExpiresMonth_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.ExpiresMonth = (byte) numericUpDown_ExpiresMonth.Value;
    }

    private void numericUpDown_ExpiresDay_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.ExpiresDay = (byte) numericUpDown_ExpiresDay.Value;
    }

    private void numericUpDown_ExpiresHour_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.ExpiresHour = (byte) numericUpDown_ExpiresHour.Value;
    }

    private void numericUpDown_AllowNextConnectYear_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.AllowNextConnectYear = (ushort) numericUpDown_AllowNextConnectYear.Value;
    }

    private void numericUpDown_AllowNextConnectMonth_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.AllowNextConnectMonth = (byte) numericUpDown_AllowNextConnectMonth.Value;
    }

    private void numericUpDown_AllowNextConnectDay_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.AllowNextConnectDay = (byte) numericUpDown_AllowNextConnectDay.Value;
    }

    private void numericUpDown_AllowNextConnectHour_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.AllowNextConnectHour = (byte) numericUpDown_AllowNextConnectHour.Value;
    }

    private void textBox_Message_TextChanged(object sender, EventArgs e)
    {
      Encoding encoding = Encoding.GetEncoding("utf-8");
      byte[] bytes = encoding.GetBytes(textBox_Message.Text);
      if (bytes.Length > SaveDataManager.Instance.SaveData.WifiShopData.MessageMaxLength)
      {
        textBox_Message.Text = encoding.GetString(bytes, 0, SaveDataManager.Instance.SaveData.WifiShopData.MessageMaxLength);
        textBox_Message.SelectionStart = textBox_Message.TextLength;
        textBox_Message.ScrollToCaret();
      }
      else
        textBox_Message.Text = encoding.GetString(bytes, 0, bytes.Length);
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.Message = textBox_Message.Text;
    }

    private void numericUpDown_MessageExpiresYear_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.MessageExpiresYear = (ushort) numericUpDown_MessageExpiresYear.Value;
    }

    private void numericUpDown_MessageExpiresMonth_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.MessageExpiresMonth = (byte) numericUpDown_MessageExpiresMonth.Value;
    }

    private void numericUpDown_MessageExpiresDay_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.MessageExpiresDay = (byte) numericUpDown_MessageExpiresDay.Value;
    }

    private void numericUpDown_MessageExpiresHour_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.MessageExpiresHour = (byte) numericUpDown_MessageExpiresHour.Value;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      label1 = new Label();
      numericUpDown_AllowNextConnectHour = new SafeNumericUpDown();
      label2 = new Label();
      numericUpDown_AllowNextConnectDay = new SafeNumericUpDown();
      label3 = new Label();
      numericUpDown_AllowNextConnectMonth = new SafeNumericUpDown();
      label4 = new Label();
      numericUpDown_AllowNextConnectYear = new SafeNumericUpDown();
      label5 = new Label();
      label6 = new Label();
      numericUpDown_ExpiresHour = new SafeNumericUpDown();
      label7 = new Label();
      numericUpDown_ExpiresDay = new SafeNumericUpDown();
      label8 = new Label();
      numericUpDown_ExpiresMonth = new SafeNumericUpDown();
      label9 = new Label();
      numericUpDown_ExpiresYear = new SafeNumericUpDown();
      label10 = new Label();
      label16 = new Label();
      numericUpDown_MessageExpiresHour = new SafeNumericUpDown();
      label17 = new Label();
      numericUpDown_MessageExpiresDay = new SafeNumericUpDown();
      label18 = new Label();
      numericUpDown_MessageExpiresMonth = new SafeNumericUpDown();
      label19 = new Label();
      numericUpDown_MessageExpiresYear = new SafeNumericUpDown();
      label20 = new Label();
      textBox_Message = new TextBox();
      numericUpDown_AllowNextConnectHour.BeginInit();
      numericUpDown_AllowNextConnectDay.BeginInit();
      numericUpDown_AllowNextConnectMonth.BeginInit();
      numericUpDown_AllowNextConnectYear.BeginInit();
      numericUpDown_ExpiresHour.BeginInit();
      numericUpDown_ExpiresDay.BeginInit();
      numericUpDown_ExpiresMonth.BeginInit();
      numericUpDown_ExpiresYear.BeginInit();
      numericUpDown_MessageExpiresHour.BeginInit();
      numericUpDown_MessageExpiresDay.BeginInit();
      numericUpDown_MessageExpiresMonth.BeginInit();
      numericUpDown_MessageExpiresYear.BeginInit();
      SuspendLayout();
      label1.AutoSize = true;
      label1.Location = new Point(365, 54);
      label1.Name = "label1";
      label1.Size = new Size(15, 13);
      label1.TabIndex = 92;
      label1.Text = "H";
      numericUpDown_AllowNextConnectHour.Location = new Point(325, 52);
      numericUpDown_AllowNextConnectHour.Maximum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        0
      });
      numericUpDown_AllowNextConnectHour.Name = "numericUpDown_AllowNextConnectHour";
      numericUpDown_AllowNextConnectHour.Size = new Size(39, 20);
      numericUpDown_AllowNextConnectHour.TabIndex = 91;
      numericUpDown_AllowNextConnectHour.Value = new Decimal(new int[4]);
      numericUpDown_AllowNextConnectHour.ValueChanged += numericUpDown_AllowNextConnectHour_ValueChanged;
      label2.AutoSize = true;
      label2.Location = new Point(304, 54);
      label2.Name = "label2";
      label2.Size = new Size(15, 13);
      label2.TabIndex = 90;
      label2.Text = "D";
      numericUpDown_AllowNextConnectDay.Location = new Point(264, 52);
      numericUpDown_AllowNextConnectDay.Maximum = new Decimal(new int[4]
      {
        31,
        0,
        0,
        0
      });
      numericUpDown_AllowNextConnectDay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_AllowNextConnectDay.Name = "numericUpDown_AllowNextConnectDay";
      numericUpDown_AllowNextConnectDay.Size = new Size(39, 20);
      numericUpDown_AllowNextConnectDay.TabIndex = 89;
      numericUpDown_AllowNextConnectDay.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_AllowNextConnectDay.ValueChanged += numericUpDown_AllowNextConnectDay_ValueChanged;
      label3.AutoSize = true;
      label3.Location = new Point(242, 54);
      label3.Name = "label3";
      label3.Size = new Size(16, 13);
      label3.TabIndex = 88;
      label3.Text = "M";
      numericUpDown_AllowNextConnectMonth.Location = new Point(202, 52);
      numericUpDown_AllowNextConnectMonth.Maximum = new Decimal(new int[4]
      {
        12,
        0,
        0,
        0
      });
      numericUpDown_AllowNextConnectMonth.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_AllowNextConnectMonth.Name = "numericUpDown_AllowNextConnectMonth";
      numericUpDown_AllowNextConnectMonth.Size = new Size(39, 20);
      numericUpDown_AllowNextConnectMonth.TabIndex = 87;
      numericUpDown_AllowNextConnectMonth.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_AllowNextConnectMonth.ValueChanged += numericUpDown_AllowNextConnectMonth_ValueChanged;
      label4.AutoSize = true;
      label4.Location = new Point(181, 54);
      label4.Name = "label4";
      label4.Size = new Size(14, 13);
      label4.TabIndex = 86;
      label4.Text = "Y";
      numericUpDown_AllowNextConnectYear.Location = new Point(128, 52);
      numericUpDown_AllowNextConnectYear.Maximum = new Decimal(new int[4]
      {
        4095,
        0,
        0,
        0
      });
      numericUpDown_AllowNextConnectYear.Name = "numericUpDown_AllowNextConnectYear";
      numericUpDown_AllowNextConnectYear.Size = new Size(52, 20);
      numericUpDown_AllowNextConnectYear.TabIndex = 85;
      numericUpDown_AllowNextConnectYear.Value = new Decimal(new int[4]);
      numericUpDown_AllowNextConnectYear.ValueChanged += numericUpDown_AllowNextConnectYear_ValueChanged;
      label5.AutoSize = true;
      label5.Location = new Point(30, 54);
      label5.Name = "label5";
      label5.Size = new Size(98, 13);
      label5.TabIndex = 84;
      label5.Text = "Next available date";
      label6.AutoSize = true;
      label6.Location = new Point(365, 28);
      label6.Name = "label6";
      label6.Size = new Size(15, 13);
      label6.TabIndex = 83;
      label6.Text = "H";
      numericUpDown_ExpiresHour.Location = new Point(325, 26);
      numericUpDown_ExpiresHour.Maximum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        0
      });
      numericUpDown_ExpiresHour.Name = "numericUpDown_ExpiresHour";
      numericUpDown_ExpiresHour.Size = new Size(39, 20);
      numericUpDown_ExpiresHour.TabIndex = 82;
      numericUpDown_ExpiresHour.Value = new Decimal(new int[4]);
      numericUpDown_ExpiresHour.ValueChanged += numericUpDown_ExpiresHour_ValueChanged;
      label7.AutoSize = true;
      label7.Location = new Point(304, 28);
      label7.Name = "label7";
      label7.Size = new Size(15, 13);
      label7.TabIndex = 81;
      label7.Text = "D";
      numericUpDown_ExpiresDay.Location = new Point(264, 26);
      numericUpDown_ExpiresDay.Maximum = new Decimal(new int[4]
      {
        31,
        0,
        0,
        0
      });
      numericUpDown_ExpiresDay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_ExpiresDay.Name = "numericUpDown_ExpiresDay";
      numericUpDown_ExpiresDay.Size = new Size(39, 20);
      numericUpDown_ExpiresDay.TabIndex = 80;
      numericUpDown_ExpiresDay.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_ExpiresDay.ValueChanged += numericUpDown_ExpiresDay_ValueChanged;
      label8.AutoSize = true;
      label8.Location = new Point(242, 28);
      label8.Name = "label8";
      label8.Size = new Size(16, 13);
      label8.TabIndex = 79;
      label8.Text = "M";
      numericUpDown_ExpiresMonth.Location = new Point(202, 26);
      numericUpDown_ExpiresMonth.Maximum = new Decimal(new int[4]
      {
        12,
        0,
        0,
        0
      });
      numericUpDown_ExpiresMonth.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_ExpiresMonth.Name = "numericUpDown_ExpiresMonth";
      numericUpDown_ExpiresMonth.Size = new Size(39, 20);
      numericUpDown_ExpiresMonth.TabIndex = 78;
      numericUpDown_ExpiresMonth.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_ExpiresMonth.ValueChanged += numericUpDown_ExpiresMonth_ValueChanged;
      label9.AutoSize = true;
      label9.Location = new Point(181, 28);
      label9.Name = "label9";
      label9.Size = new Size(14, 13);
      label9.TabIndex = 77;
      label9.Text = "Y";
      numericUpDown_ExpiresYear.Location = new Point(128, 26);
      numericUpDown_ExpiresYear.Maximum = new Decimal(new int[4]
      {
        4095,
        0,
        0,
        0
      });
      numericUpDown_ExpiresYear.Name = "numericUpDown_ExpiresYear";
      numericUpDown_ExpiresYear.Size = new Size(52, 20);
      numericUpDown_ExpiresYear.TabIndex = 76;
      numericUpDown_ExpiresYear.Value = new Decimal(new int[4]);
      numericUpDown_ExpiresYear.ValueChanged += numericUpDown_ExpiresYear_ValueChanged;
      label10.AutoSize = true;
      label10.Location = new Point(87, 28);
      label10.Name = "label10";
      label10.Size = new Size(41, 13);
      label10.TabIndex = 75;
      label10.Text = "Expires";
      label16.AutoSize = true;
      label16.Location = new Point(754, 54);
      label16.Name = "label16";
      label16.Size = new Size(15, 13);
      label16.TabIndex = 101;
      label16.Text = "H";
      numericUpDown_MessageExpiresHour.Location = new Point(714, 52);
      numericUpDown_MessageExpiresHour.Maximum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        0
      });
      numericUpDown_MessageExpiresHour.Name = "numericUpDown_MessageExpiresHour";
      numericUpDown_MessageExpiresHour.Size = new Size(39, 20);
      numericUpDown_MessageExpiresHour.TabIndex = 100;
      numericUpDown_MessageExpiresHour.Value = new Decimal(new int[4]);
      numericUpDown_MessageExpiresHour.ValueChanged += numericUpDown_MessageExpiresHour_ValueChanged;
      label17.AutoSize = true;
      label17.Location = new Point(691, 54);
      label17.Name = "label17";
      label17.Size = new Size(15, 13);
      label17.TabIndex = 99;
      label17.Text = "D";
      numericUpDown_MessageExpiresDay.Location = new Point(651, 52);
      numericUpDown_MessageExpiresDay.Maximum = new Decimal(new int[4]
      {
        31,
        0,
        0,
        0
      });
      numericUpDown_MessageExpiresDay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_MessageExpiresDay.Name = "numericUpDown_MessageExpiresDay";
      numericUpDown_MessageExpiresDay.Size = new Size(39, 20);
      numericUpDown_MessageExpiresDay.TabIndex = 98;
      numericUpDown_MessageExpiresDay.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_MessageExpiresDay.ValueChanged += numericUpDown_MessageExpiresDay_ValueChanged;
      label18.AutoSize = true;
      label18.Location = new Point(629, 54);
      label18.Name = "label18";
      label18.Size = new Size(16, 13);
      label18.TabIndex = 97;
      label18.Text = "M";
      numericUpDown_MessageExpiresMonth.Location = new Point(589, 52);
      numericUpDown_MessageExpiresMonth.Maximum = new Decimal(new int[4]
      {
        12,
        0,
        0,
        0
      });
      numericUpDown_MessageExpiresMonth.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_MessageExpiresMonth.Name = "numericUpDown_MessageExpiresMonth";
      numericUpDown_MessageExpiresMonth.Size = new Size(39, 20);
      numericUpDown_MessageExpiresMonth.TabIndex = 96;
      numericUpDown_MessageExpiresMonth.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_MessageExpiresMonth.ValueChanged += numericUpDown_MessageExpiresMonth_ValueChanged;
      label19.AutoSize = true;
      label19.Location = new Point(567, 54);
      label19.Name = "label19";
      label19.Size = new Size(14, 13);
      label19.TabIndex = 95;
      label19.Text = "Y";
      numericUpDown_MessageExpiresYear.Location = new Point(514, 52);
      numericUpDown_MessageExpiresYear.Maximum = new Decimal(new int[4]
      {
        4095,
        0,
        0,
        0
      });
      numericUpDown_MessageExpiresYear.Name = "numericUpDown_MessageExpiresYear";
      numericUpDown_MessageExpiresYear.Size = new Size(52, 20);
      numericUpDown_MessageExpiresYear.TabIndex = 94;
      numericUpDown_MessageExpiresYear.Value = new Decimal(new int[4]);
      numericUpDown_MessageExpiresYear.ValueChanged += numericUpDown_MessageExpiresYear_ValueChanged;
      label20.AutoSize = true;
      label20.Location = new Point(427, 54);
      label20.Name = "label20";
      label20.Size = new Size(87, 13);
      label20.TabIndex = 93;
      label20.Text = "Message Expires";
      textBox_Message.Location = new Point(415, 94);
      textBox_Message.MaxLength = 500;
      textBox_Message.Multiline = true;
      textBox_Message.Name = "textBox_Message";
      textBox_Message.ScrollBars = ScrollBars.Vertical;
      textBox_Message.Size = new Size(361, 157);
      textBox_Message.TabIndex = 102;
      textBox_Message.TextChanged += textBox_Message_TextChanged;
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(textBox_Message);
      Controls.Add(label16);
      Controls.Add(numericUpDown_MessageExpiresHour);
      Controls.Add(label17);
      Controls.Add(numericUpDown_MessageExpiresDay);
      Controls.Add(label18);
      Controls.Add(numericUpDown_MessageExpiresMonth);
      Controls.Add(label19);
      Controls.Add(numericUpDown_MessageExpiresYear);
      Controls.Add(label1);
      Controls.Add(numericUpDown_AllowNextConnectHour);
      Controls.Add(label2);
      Controls.Add(numericUpDown_AllowNextConnectDay);
      Controls.Add(label3);
      Controls.Add(numericUpDown_AllowNextConnectMonth);
      Controls.Add(label4);
      Controls.Add(numericUpDown_AllowNextConnectYear);
      Controls.Add(label5);
      Controls.Add(label6);
      Controls.Add(numericUpDown_ExpiresHour);
      Controls.Add(label7);
      Controls.Add(numericUpDown_ExpiresDay);
      Controls.Add(label8);
      Controls.Add(numericUpDown_ExpiresMonth);
      Controls.Add(label9);
      Controls.Add(numericUpDown_ExpiresYear);
      Controls.Add(label10);
      Controls.Add(label20);
      Name = nameof (WifiShoppingDataControl);
      Size = new Size(807, 507);
      numericUpDown_AllowNextConnectHour.EndInit();
      numericUpDown_AllowNextConnectDay.EndInit();
      numericUpDown_AllowNextConnectMonth.EndInit();
      numericUpDown_AllowNextConnectYear.EndInit();
      numericUpDown_ExpiresHour.EndInit();
      numericUpDown_ExpiresDay.EndInit();
      numericUpDown_ExpiresMonth.EndInit();
      numericUpDown_ExpiresYear.EndInit();
      numericUpDown_MessageExpiresHour.EndInit();
      numericUpDown_MessageExpiresDay.EndInit();
      numericUpDown_MessageExpiresMonth.EndInit();
      numericUpDown_MessageExpiresYear.EndInit();
      ResumeLayout(false);
      PerformLayout();
    }
  }
}
