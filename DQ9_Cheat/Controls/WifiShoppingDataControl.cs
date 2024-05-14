// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.WifiShoppingDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#nullable disable
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
      this.AutoScaleMode = AutoScaleMode.None;
      this.InitializeComponent();
      for (int index = 0; index < 6; ++index)
      {
        this._textBoxItemNames[index] = new TextBox();
        this._textBoxItemNames[index].ReadOnly = true;
        this._textBoxItemNames[index].Location = new Point(31, 99 + 25 * index);
        this._textBoxItemNames[index].Size = new Size(113, 20);
        this._textBoxItemNames[index].Tag = (object) index;
        this.Controls.Add((Control) this._textBoxItemNames[index]);
        this._buttonItemSelects[index] = new Button();
        this._buttonItemSelects[index].Text = "Set";
        this._buttonItemSelects[index].Location = new Point(150, 99 + 25 * index);
        this._buttonItemSelects[index].Size = new Size(37, 20);
        this._buttonItemSelects[index].UseVisualStyleBackColor = true;
        this._buttonItemSelects[index].Tag = (object) index;
        this._buttonItemSelects[index].Click += new EventHandler(this.ButtonItemSelects_Click);
        this.Controls.Add((Control) this._buttonItemSelects[index]);
        this._numericUpDownItemCounts[index] = new SafeNumericUpDown();
        this._numericUpDownItemCounts[index].Location = new Point(223, 99 + 25 * index);
        this._numericUpDownItemCounts[index].Size = new Size(40, 20);
        this._numericUpDownItemCounts[index].Tag = (object) index;
        this._numericUpDownItemCounts[index].Maximum = 127M;
        this._numericUpDownItemCounts[index].Minimum = 0M;
        this._numericUpDownItemCounts[index].ValueChanged += new EventHandler(this.NumericUpDownItemCounts_ValueChanged);
        this.Controls.Add((Control) this._numericUpDownItemCounts[index]);
        this._numericUpDownItemPrices[index] = new SafeNumericUpDown();
        this._numericUpDownItemPrices[index].Location = new Point(303, 99 + 25 * index);
        this._numericUpDownItemPrices[index].Size = new Size(71, 20);
        this._numericUpDownItemPrices[index].Maximum = 33554431M;
        this._numericUpDownItemPrices[index].Minimum = 0M;
        this._numericUpDownItemPrices[index].Tag = (object) index;
        this._numericUpDownItemPrices[index].ValueChanged += new EventHandler(this.NumericUpDownItemPrices_ValueChanged);
        this.Controls.Add((Control) this._numericUpDownItemPrices[index]);
      }
    }

    private void NumericUpDownItemPrices_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is SafeNumericUpDown safeNumericUpDown))
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.WifiShopGoods[(int) safeNumericUpDown.Tag].ItemPrice = (uint) safeNumericUpDown.Value;
    }

    private void NumericUpDownItemCounts_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is SafeNumericUpDown safeNumericUpDown))
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
      itemSelectWindow.Location = this.PointToScreen(new Point(this.Left + button.Right, this.Top + button.Bottom));
      if (itemSelectWindow.ShowDialog() != DialogResult.OK)
        return;
      ItemDataBase selectedItem = itemSelectWindow.SelectedItem;
      SaveDataManager.Instance.SaveData.WifiShopData.WifiShopGoods[(int) button.Tag].Item = selectedItem;
      this.OnValueUpdate();
    }

    protected override void OnValueUpdate()
    {
      this.BeginUpdate();
      WifiShopping wifiShopData = SaveDataManager.Instance.SaveData.WifiShopData;
      this.numericUpDown_ExpiresYear.Value = (Decimal) wifiShopData.ExpiresYear;
      this.numericUpDown_ExpiresMonth.Value = (Decimal) wifiShopData.ExpiresMonth;
      this.numericUpDown_ExpiresDay.Value = (Decimal) wifiShopData.ExpiresDay;
      this.numericUpDown_ExpiresHour.Value = (Decimal) wifiShopData.ExpiresHour;
      this.numericUpDown_AllowNextConnectYear.Value = (Decimal) wifiShopData.AllowNextConnectYear;
      this.numericUpDown_AllowNextConnectMonth.Value = (Decimal) wifiShopData.AllowNextConnectMonth;
      this.numericUpDown_AllowNextConnectDay.Value = (Decimal) wifiShopData.AllowNextConnectDay;
      this.numericUpDown_AllowNextConnectHour.Value = (Decimal) wifiShopData.AllowNextConnectHour;
      this.numericUpDown_MessageExpiresYear.Value = (Decimal) wifiShopData.MessageExpiresYear;
      this.numericUpDown_MessageExpiresMonth.Value = (Decimal) wifiShopData.MessageExpiresMonth;
      this.numericUpDown_MessageExpiresDay.Value = (Decimal) wifiShopData.MessageExpiresDay;
      this.numericUpDown_MessageExpiresHour.Value = (Decimal) wifiShopData.MessageExpiresHour;
      this.textBox_Message.Text = wifiShopData.Message;
      for (int index = 0; index < 6; ++index)
      {
        ItemDataBase itemDataBase = wifiShopData.WifiShopGoods[index].Item;
        if (itemDataBase != null)
          this._textBoxItemNames[index].Text = itemDataBase.Name;
        else
          this._textBoxItemNames[index].Text = "Empty";
        this._numericUpDownItemCounts[index].Value = (Decimal) wifiShopData.WifiShopGoods[index].ItemCount;
        this._numericUpDownItemPrices[index].Value = (Decimal) wifiShopData.WifiShopGoods[index].ItemPrice;
      }
      this.EndUpdate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
      {
        for (int index = 0; index < 6; ++index)
        {
          e.Graphics.DrawString("Qty", this.Font, brush, 198f, (float) (101 + 25 * index));
          e.Graphics.DrawString("Price", this.Font, brush, 271f, (float) (101 + 25 * index));
        }
        e.Graphics.DrawString("Message", this.Font, brush, 413f, 79f);
        e.Graphics.DrawString("<PAGE>: New page", this.Font, brush, 413f, 254f);
        e.Graphics.DrawString("<PAD_WAIT>: Wait for button press", this.Font, brush, 413f, 270f);
        e.Graphics.DrawString("<END>: End message", this.Font, brush, 413f, 286f);
      }
    }

    private void numericUpDown_ExpiresYear_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.ExpiresYear = (ushort) this.numericUpDown_ExpiresYear.Value;
    }

    private void numericUpDown_ExpiresMonth_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.ExpiresMonth = (byte) this.numericUpDown_ExpiresMonth.Value;
    }

    private void numericUpDown_ExpiresDay_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.ExpiresDay = (byte) this.numericUpDown_ExpiresDay.Value;
    }

    private void numericUpDown_ExpiresHour_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.ExpiresHour = (byte) this.numericUpDown_ExpiresHour.Value;
    }

    private void numericUpDown_AllowNextConnectYear_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.AllowNextConnectYear = (ushort) this.numericUpDown_AllowNextConnectYear.Value;
    }

    private void numericUpDown_AllowNextConnectMonth_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.AllowNextConnectMonth = (byte) this.numericUpDown_AllowNextConnectMonth.Value;
    }

    private void numericUpDown_AllowNextConnectDay_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.AllowNextConnectDay = (byte) this.numericUpDown_AllowNextConnectDay.Value;
    }

    private void numericUpDown_AllowNextConnectHour_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.AllowNextConnectHour = (byte) this.numericUpDown_AllowNextConnectHour.Value;
    }

    private void textBox_Message_TextChanged(object sender, EventArgs e)
    {
      Encoding encoding = Encoding.GetEncoding("utf-8");
      byte[] bytes = encoding.GetBytes(this.textBox_Message.Text);
      if (bytes.Length > SaveDataManager.Instance.SaveData.WifiShopData.MessageMaxLength)
      {
        this.textBox_Message.Text = encoding.GetString(bytes, 0, SaveDataManager.Instance.SaveData.WifiShopData.MessageMaxLength);
        this.textBox_Message.SelectionStart = this.textBox_Message.TextLength;
        this.textBox_Message.ScrollToCaret();
      }
      else
        this.textBox_Message.Text = encoding.GetString(bytes, 0, bytes.Length);
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.Message = this.textBox_Message.Text;
    }

    private void numericUpDown_MessageExpiresYear_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.MessageExpiresYear = (ushort) this.numericUpDown_MessageExpiresYear.Value;
    }

    private void numericUpDown_MessageExpiresMonth_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.MessageExpiresMonth = (byte) this.numericUpDown_MessageExpiresMonth.Value;
    }

    private void numericUpDown_MessageExpiresDay_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.MessageExpiresDay = (byte) this.numericUpDown_MessageExpiresDay.Value;
    }

    private void numericUpDown_MessageExpiresHour_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.WifiShopData.MessageExpiresHour = (byte) this.numericUpDown_MessageExpiresHour.Value;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.numericUpDown_AllowNextConnectHour = new SafeNumericUpDown();
      this.label2 = new Label();
      this.numericUpDown_AllowNextConnectDay = new SafeNumericUpDown();
      this.label3 = new Label();
      this.numericUpDown_AllowNextConnectMonth = new SafeNumericUpDown();
      this.label4 = new Label();
      this.numericUpDown_AllowNextConnectYear = new SafeNumericUpDown();
      this.label5 = new Label();
      this.label6 = new Label();
      this.numericUpDown_ExpiresHour = new SafeNumericUpDown();
      this.label7 = new Label();
      this.numericUpDown_ExpiresDay = new SafeNumericUpDown();
      this.label8 = new Label();
      this.numericUpDown_ExpiresMonth = new SafeNumericUpDown();
      this.label9 = new Label();
      this.numericUpDown_ExpiresYear = new SafeNumericUpDown();
      this.label10 = new Label();
      this.label16 = new Label();
      this.numericUpDown_MessageExpiresHour = new SafeNumericUpDown();
      this.label17 = new Label();
      this.numericUpDown_MessageExpiresDay = new SafeNumericUpDown();
      this.label18 = new Label();
      this.numericUpDown_MessageExpiresMonth = new SafeNumericUpDown();
      this.label19 = new Label();
      this.numericUpDown_MessageExpiresYear = new SafeNumericUpDown();
      this.label20 = new Label();
      this.textBox_Message = new TextBox();
      this.numericUpDown_AllowNextConnectHour.BeginInit();
      this.numericUpDown_AllowNextConnectDay.BeginInit();
      this.numericUpDown_AllowNextConnectMonth.BeginInit();
      this.numericUpDown_AllowNextConnectYear.BeginInit();
      this.numericUpDown_ExpiresHour.BeginInit();
      this.numericUpDown_ExpiresDay.BeginInit();
      this.numericUpDown_ExpiresMonth.BeginInit();
      this.numericUpDown_ExpiresYear.BeginInit();
      this.numericUpDown_MessageExpiresHour.BeginInit();
      this.numericUpDown_MessageExpiresDay.BeginInit();
      this.numericUpDown_MessageExpiresMonth.BeginInit();
      this.numericUpDown_MessageExpiresYear.BeginInit();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(365, 54);
      this.label1.Name = "label1";
      this.label1.Size = new Size(15, 13);
      this.label1.TabIndex = 92;
      this.label1.Text = "H";
      this.numericUpDown_AllowNextConnectHour.Location = new Point(325, 52);
      this.numericUpDown_AllowNextConnectHour.Maximum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        0
      });
      this.numericUpDown_AllowNextConnectHour.Name = "numericUpDown_AllowNextConnectHour";
      this.numericUpDown_AllowNextConnectHour.Size = new Size(39, 20);
      this.numericUpDown_AllowNextConnectHour.TabIndex = 91;
      this.numericUpDown_AllowNextConnectHour.Value = new Decimal(new int[4]);
      this.numericUpDown_AllowNextConnectHour.ValueChanged += new EventHandler(this.numericUpDown_AllowNextConnectHour_ValueChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(304, 54);
      this.label2.Name = "label2";
      this.label2.Size = new Size(15, 13);
      this.label2.TabIndex = 90;
      this.label2.Text = "D";
      this.numericUpDown_AllowNextConnectDay.Location = new Point(264, 52);
      this.numericUpDown_AllowNextConnectDay.Maximum = new Decimal(new int[4]
      {
        31,
        0,
        0,
        0
      });
      this.numericUpDown_AllowNextConnectDay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_AllowNextConnectDay.Name = "numericUpDown_AllowNextConnectDay";
      this.numericUpDown_AllowNextConnectDay.Size = new Size(39, 20);
      this.numericUpDown_AllowNextConnectDay.TabIndex = 89;
      this.numericUpDown_AllowNextConnectDay.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_AllowNextConnectDay.ValueChanged += new EventHandler(this.numericUpDown_AllowNextConnectDay_ValueChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(242, 54);
      this.label3.Name = "label3";
      this.label3.Size = new Size(16, 13);
      this.label3.TabIndex = 88;
      this.label3.Text = "M";
      this.numericUpDown_AllowNextConnectMonth.Location = new Point(202, 52);
      this.numericUpDown_AllowNextConnectMonth.Maximum = new Decimal(new int[4]
      {
        12,
        0,
        0,
        0
      });
      this.numericUpDown_AllowNextConnectMonth.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_AllowNextConnectMonth.Name = "numericUpDown_AllowNextConnectMonth";
      this.numericUpDown_AllowNextConnectMonth.Size = new Size(39, 20);
      this.numericUpDown_AllowNextConnectMonth.TabIndex = 87;
      this.numericUpDown_AllowNextConnectMonth.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_AllowNextConnectMonth.ValueChanged += new EventHandler(this.numericUpDown_AllowNextConnectMonth_ValueChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(181, 54);
      this.label4.Name = "label4";
      this.label4.Size = new Size(14, 13);
      this.label4.TabIndex = 86;
      this.label4.Text = "Y";
      this.numericUpDown_AllowNextConnectYear.Location = new Point(128, 52);
      this.numericUpDown_AllowNextConnectYear.Maximum = new Decimal(new int[4]
      {
        4095,
        0,
        0,
        0
      });
      this.numericUpDown_AllowNextConnectYear.Name = "numericUpDown_AllowNextConnectYear";
      this.numericUpDown_AllowNextConnectYear.Size = new Size(52, 20);
      this.numericUpDown_AllowNextConnectYear.TabIndex = 85;
      this.numericUpDown_AllowNextConnectYear.Value = new Decimal(new int[4]);
      this.numericUpDown_AllowNextConnectYear.ValueChanged += new EventHandler(this.numericUpDown_AllowNextConnectYear_ValueChanged);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(30, 54);
      this.label5.Name = "label5";
      this.label5.Size = new Size(98, 13);
      this.label5.TabIndex = 84;
      this.label5.Text = "Next available date";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(365, 28);
      this.label6.Name = "label6";
      this.label6.Size = new Size(15, 13);
      this.label6.TabIndex = 83;
      this.label6.Text = "H";
      this.numericUpDown_ExpiresHour.Location = new Point(325, 26);
      this.numericUpDown_ExpiresHour.Maximum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        0
      });
      this.numericUpDown_ExpiresHour.Name = "numericUpDown_ExpiresHour";
      this.numericUpDown_ExpiresHour.Size = new Size(39, 20);
      this.numericUpDown_ExpiresHour.TabIndex = 82;
      this.numericUpDown_ExpiresHour.Value = new Decimal(new int[4]);
      this.numericUpDown_ExpiresHour.ValueChanged += new EventHandler(this.numericUpDown_ExpiresHour_ValueChanged);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(304, 28);
      this.label7.Name = "label7";
      this.label7.Size = new Size(15, 13);
      this.label7.TabIndex = 81;
      this.label7.Text = "D";
      this.numericUpDown_ExpiresDay.Location = new Point(264, 26);
      this.numericUpDown_ExpiresDay.Maximum = new Decimal(new int[4]
      {
        31,
        0,
        0,
        0
      });
      this.numericUpDown_ExpiresDay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_ExpiresDay.Name = "numericUpDown_ExpiresDay";
      this.numericUpDown_ExpiresDay.Size = new Size(39, 20);
      this.numericUpDown_ExpiresDay.TabIndex = 80;
      this.numericUpDown_ExpiresDay.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_ExpiresDay.ValueChanged += new EventHandler(this.numericUpDown_ExpiresDay_ValueChanged);
      this.label8.AutoSize = true;
      this.label8.Location = new Point(242, 28);
      this.label8.Name = "label8";
      this.label8.Size = new Size(16, 13);
      this.label8.TabIndex = 79;
      this.label8.Text = "M";
      this.numericUpDown_ExpiresMonth.Location = new Point(202, 26);
      this.numericUpDown_ExpiresMonth.Maximum = new Decimal(new int[4]
      {
        12,
        0,
        0,
        0
      });
      this.numericUpDown_ExpiresMonth.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_ExpiresMonth.Name = "numericUpDown_ExpiresMonth";
      this.numericUpDown_ExpiresMonth.Size = new Size(39, 20);
      this.numericUpDown_ExpiresMonth.TabIndex = 78;
      this.numericUpDown_ExpiresMonth.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_ExpiresMonth.ValueChanged += new EventHandler(this.numericUpDown_ExpiresMonth_ValueChanged);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(181, 28);
      this.label9.Name = "label9";
      this.label9.Size = new Size(14, 13);
      this.label9.TabIndex = 77;
      this.label9.Text = "Y";
      this.numericUpDown_ExpiresYear.Location = new Point(128, 26);
      this.numericUpDown_ExpiresYear.Maximum = new Decimal(new int[4]
      {
        4095,
        0,
        0,
        0
      });
      this.numericUpDown_ExpiresYear.Name = "numericUpDown_ExpiresYear";
      this.numericUpDown_ExpiresYear.Size = new Size(52, 20);
      this.numericUpDown_ExpiresYear.TabIndex = 76;
      this.numericUpDown_ExpiresYear.Value = new Decimal(new int[4]);
      this.numericUpDown_ExpiresYear.ValueChanged += new EventHandler(this.numericUpDown_ExpiresYear_ValueChanged);
      this.label10.AutoSize = true;
      this.label10.Location = new Point(87, 28);
      this.label10.Name = "label10";
      this.label10.Size = new Size(41, 13);
      this.label10.TabIndex = 75;
      this.label10.Text = "Expires";
      this.label16.AutoSize = true;
      this.label16.Location = new Point(754, 54);
      this.label16.Name = "label16";
      this.label16.Size = new Size(15, 13);
      this.label16.TabIndex = 101;
      this.label16.Text = "H";
      this.numericUpDown_MessageExpiresHour.Location = new Point(714, 52);
      this.numericUpDown_MessageExpiresHour.Maximum = new Decimal(new int[4]
      {
        23,
        0,
        0,
        0
      });
      this.numericUpDown_MessageExpiresHour.Name = "numericUpDown_MessageExpiresHour";
      this.numericUpDown_MessageExpiresHour.Size = new Size(39, 20);
      this.numericUpDown_MessageExpiresHour.TabIndex = 100;
      this.numericUpDown_MessageExpiresHour.Value = new Decimal(new int[4]);
      this.numericUpDown_MessageExpiresHour.ValueChanged += new EventHandler(this.numericUpDown_MessageExpiresHour_ValueChanged);
      this.label17.AutoSize = true;
      this.label17.Location = new Point(691, 54);
      this.label17.Name = "label17";
      this.label17.Size = new Size(15, 13);
      this.label17.TabIndex = 99;
      this.label17.Text = "D";
      this.numericUpDown_MessageExpiresDay.Location = new Point(651, 52);
      this.numericUpDown_MessageExpiresDay.Maximum = new Decimal(new int[4]
      {
        31,
        0,
        0,
        0
      });
      this.numericUpDown_MessageExpiresDay.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_MessageExpiresDay.Name = "numericUpDown_MessageExpiresDay";
      this.numericUpDown_MessageExpiresDay.Size = new Size(39, 20);
      this.numericUpDown_MessageExpiresDay.TabIndex = 98;
      this.numericUpDown_MessageExpiresDay.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_MessageExpiresDay.ValueChanged += new EventHandler(this.numericUpDown_MessageExpiresDay_ValueChanged);
      this.label18.AutoSize = true;
      this.label18.Location = new Point(629, 54);
      this.label18.Name = "label18";
      this.label18.Size = new Size(16, 13);
      this.label18.TabIndex = 97;
      this.label18.Text = "M";
      this.numericUpDown_MessageExpiresMonth.Location = new Point(589, 52);
      this.numericUpDown_MessageExpiresMonth.Maximum = new Decimal(new int[4]
      {
        12,
        0,
        0,
        0
      });
      this.numericUpDown_MessageExpiresMonth.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_MessageExpiresMonth.Name = "numericUpDown_MessageExpiresMonth";
      this.numericUpDown_MessageExpiresMonth.Size = new Size(39, 20);
      this.numericUpDown_MessageExpiresMonth.TabIndex = 96;
      this.numericUpDown_MessageExpiresMonth.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_MessageExpiresMonth.ValueChanged += new EventHandler(this.numericUpDown_MessageExpiresMonth_ValueChanged);
      this.label19.AutoSize = true;
      this.label19.Location = new Point(567, 54);
      this.label19.Name = "label19";
      this.label19.Size = new Size(14, 13);
      this.label19.TabIndex = 95;
      this.label19.Text = "Y";
      this.numericUpDown_MessageExpiresYear.Location = new Point(514, 52);
      this.numericUpDown_MessageExpiresYear.Maximum = new Decimal(new int[4]
      {
        4095,
        0,
        0,
        0
      });
      this.numericUpDown_MessageExpiresYear.Name = "numericUpDown_MessageExpiresYear";
      this.numericUpDown_MessageExpiresYear.Size = new Size(52, 20);
      this.numericUpDown_MessageExpiresYear.TabIndex = 94;
      this.numericUpDown_MessageExpiresYear.Value = new Decimal(new int[4]);
      this.numericUpDown_MessageExpiresYear.ValueChanged += new EventHandler(this.numericUpDown_MessageExpiresYear_ValueChanged);
      this.label20.AutoSize = true;
      this.label20.Location = new Point(427, 54);
      this.label20.Name = "label20";
      this.label20.Size = new Size(87, 13);
      this.label20.TabIndex = 93;
      this.label20.Text = "Message Expires";
      this.textBox_Message.Location = new Point(415, 94);
      this.textBox_Message.MaxLength = 500;
      this.textBox_Message.Multiline = true;
      this.textBox_Message.Name = "textBox_Message";
      this.textBox_Message.ScrollBars = ScrollBars.Vertical;
      this.textBox_Message.Size = new Size(361, 157);
      this.textBox_Message.TabIndex = 102;
      this.textBox_Message.TextChanged += new EventHandler(this.textBox_Message_TextChanged);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.textBox_Message);
      this.Controls.Add((Control) this.label16);
      this.Controls.Add((Control) this.numericUpDown_MessageExpiresHour);
      this.Controls.Add((Control) this.label17);
      this.Controls.Add((Control) this.numericUpDown_MessageExpiresDay);
      this.Controls.Add((Control) this.label18);
      this.Controls.Add((Control) this.numericUpDown_MessageExpiresMonth);
      this.Controls.Add((Control) this.label19);
      this.Controls.Add((Control) this.numericUpDown_MessageExpiresYear);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.numericUpDown_AllowNextConnectHour);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.numericUpDown_AllowNextConnectDay);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.numericUpDown_AllowNextConnectMonth);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.numericUpDown_AllowNextConnectYear);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.numericUpDown_ExpiresHour);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.numericUpDown_ExpiresDay);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.numericUpDown_ExpiresMonth);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.numericUpDown_ExpiresYear);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label20);
      this.Name = nameof (WifiShoppingDataControl);
      this.Size = new Size(807, 507);
      this.numericUpDown_AllowNextConnectHour.EndInit();
      this.numericUpDown_AllowNextConnectDay.EndInit();
      this.numericUpDown_AllowNextConnectMonth.EndInit();
      this.numericUpDown_AllowNextConnectYear.EndInit();
      this.numericUpDown_ExpiresHour.EndInit();
      this.numericUpDown_ExpiresDay.EndInit();
      this.numericUpDown_ExpiresMonth.EndInit();
      this.numericUpDown_ExpiresYear.EndInit();
      this.numericUpDown_MessageExpiresHour.EndInit();
      this.numericUpDown_MessageExpiresDay.EndInit();
      this.numericUpDown_MessageExpiresMonth.EndInit();
      this.numericUpDown_MessageExpiresYear.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
