// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.TreasureMapDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using JS_Framework.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls
{
  public class TreasureMapDataControl : DataControlBase
  {
    private Point _panelLocation;
    private TreasureMapData _selectedMapData;
    private int[] _treasureBoxCount = new int[16];
    private int[,] _treasureBoxIndexes = new int[16, 3];
    private static string[,] _treasureBoxRankSymbol = new string[2, 10]
    {
      {
        "I",
        "H",
        "G",
        "F",
        "E",
        "D",
        "C",
        "B",
        "A",
        "S"
      },
      {
        "Ｉ",
        "Ｈ",
        "Ｇ",
        "Ｆ",
        "Ｅ",
        "Ｄ",
        "Ｃ",
        "Ｂ",
        "Ａ",
        "Ｓ"
      }
    };
    private IContainer components;
    private ListBox listBox_TreasureMap;
    private RadioButton radioButton_NormalMap;
    private RadioButton radioButton_DevilMap;
    private JS_GroupBox GroupBox_MapType;
    private Label label1;
    private TextBox textBox_Detector;
    private TextBox textBox_Renewer;
    private Label label2;
    private JS_Panel Panel_NormalMap;
    private SafeNumericUpDown numericUpDown_MapNo2;
    private SafeNumericUpDown numericUpDown_MapNo1;
    private Label label3;
    private JS_GroupBox GroupBox_Probability;
    private CheckBox checkBox_OpenProbability3;
    private CheckBox checkBox_OpenProbability2;
    private CheckBox checkBox_OpenProbability1;
    private JS_Panel Panel_Devil;
    private SafeNumericUpDown numericUpDown_DevilVictoryTurn;
    private Label label6;
    private SafeNumericUpDown numericUpDown_DevilLevel;
    private Label label5;
    private Label label4;
    private ComboBox comboBox_Devil;
    private JS_Panel Panel_TreasureMapEditArea;
    private Panel panel2;
    private ToolStrip toolStrip2;
    private ToolStripButton toolButton_CreateMap;
    private ToolStripButton toolButton_DeleteMap;
    private Label label7;
    private ComboBox comboBox_State;
    private SafeNumericUpDown numericUpDown_Place;
    private Label label8;
    private SafeNumericUpDown numericUpDown_ClearCount;
    private Label label9;
    private CheckBox checkBox_Hex;
    private Label label_DungeonDetail;
    private RichTextBox textBox_DungeonDetail;
    private RichTextBox richTextBox_dummy;
    private Label label_PlaceName;
    private CheckBox checkBox_PlaceHex;
    private ToolStripLabel label_MapCount;
    private GroupBoxWithCheckBox groupBoxWithCheckBox_Narrowing;
    private CheckBox checkBox_NarrowingLevel;
    private CheckBox CheckBox_NarrowingNormal;
    private CheckBox CheckBox_NarrowingDevil;
    private NumericUpDown numericUpDown_NarrowingLevel;
    private ComboBox comboBox_NarrowingLevel;
    private ComboBox comboBox_NarrowingName1;
    private ComboBox comboBox_NarrowingName2;
    private ComboBox comboBox_NarrowingName3;
    private Label labelCandidatePlace;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolButton_SortLVUp;
    private ToolStripButton toolButton_SortLVDown;

    public TreasureMapDataControl()
    {
      this.InitializeComponent();
      this.BeginUpdate();
      foreach (object obj in DevilList.List)
        this.comboBox_Devil.Items.Add(obj);
      this.Panel_Devil.Visible = false;
      this._panelLocation = this.Panel_NormalMap.Location;
      this.textBox_DungeonDetail.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
      this.comboBox_NarrowingName1.Items.Add((object) string.Empty);
      foreach (object obj in TreasureMapDataTable.TreasureMapName1_Table)
        this.comboBox_NarrowingName1.Items.Add(obj);
      this.comboBox_NarrowingName1.SelectedIndex = 0;
      this.comboBox_NarrowingName2.Items.Add((object) string.Empty);
      foreach (object obj in TreasureMapDataTable.TreasureMapName2_Table)
        this.comboBox_NarrowingName2.Items.Add(obj);
      this.comboBox_NarrowingName2.SelectedIndex = 0;
      this.comboBox_NarrowingName3.Items.Add((object) string.Empty);
      foreach (object obj in TreasureMapDataTable.TreasureMapName3_Table)
        this.comboBox_NarrowingName3.Items.Add(obj);
      this.comboBox_NarrowingName3.SelectedIndex = 0;
      this.comboBox_NarrowingLevel.SelectedIndex = 0;
      this.EndUpdate();
    }

    protected override void OnValueUpdate()
    {
      this.BeginUpdate();
      this.numericUpDown_ClearCount.Value = (Decimal) SaveDataManager.Instance.SaveData.TreasureMapManager.ClearCount;
      this.RenewalListBox();
      this.RenewalToolButton();
      this.RenewalMapCountLabel();
      this.RenewalEditArea(true);
      this.EndUpdate();
    }

    private void RenewalListBox()
    {
      int selectedIndex = this.listBox_TreasureMap.SelectedIndex;
      this.listBox_TreasureMap.BeginUpdate();
      this.listBox_TreasureMap.Items.Clear();
      TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
      for (int index = 0; index < (int) treasureMapManager.MapCount; ++index)
      {
        TreasureMapData mapData = treasureMapManager.GetMapData(index);
        this.AddListBox(index, mapData);
      }
      this.RenewalMapCountLabel();
      if (this.listBox_TreasureMap.Items.Count > selectedIndex)
        this.listBox_TreasureMap.SelectedIndex = selectedIndex;
      else
        this.listBox_TreasureMap.SelectedIndex = this.listBox_TreasureMap.Items.Count - 1;
      this.listBox_TreasureMap.EndUpdate();
    }

    private bool AddListBox(int index, TreasureMapData mapData)
    {
      if (this.groupBoxWithCheckBox_Narrowing.Checked && this.checkBox_NarrowingLevel.Checked)
      {
        int num = (int) this.numericUpDown_NarrowingLevel.Value;
        if (this.comboBox_NarrowingLevel.SelectedIndex == 0)
        {
          if (mapData.MapLevel < num)
            return false;
        }
        else if (this.comboBox_NarrowingLevel.SelectedIndex == 1 && mapData.MapLevel > num)
          return false;
      }
      string name;
      if (mapData.MapType == MapType.Normal)
      {
        if (this.groupBoxWithCheckBox_Narrowing.Checked && (!this.CheckBox_NarrowingNormal.Checked || !string.IsNullOrEmpty(this.comboBox_NarrowingName1.SelectedItem.ToString()) && this.comboBox_NarrowingName1.SelectedItem.ToString() != mapData.MapName1 || !string.IsNullOrEmpty(this.comboBox_NarrowingName2.SelectedItem.ToString()) && this.comboBox_NarrowingName2.SelectedItem.ToString() != mapData.MapName2 || !string.IsNullOrEmpty(this.comboBox_NarrowingName3.SelectedItem.ToString()) && this.comboBox_NarrowingName3.SelectedItem.ToString() != mapData.MapName3))
          return false;
        name = !mapData.IsValid ? string.Format("!{0}", (object) mapData.MapName) : mapData.MapName;
      }
      else if (mapData.MapType == MapType.devil)
      {
        if (this.groupBoxWithCheckBox_Narrowing.Checked && !this.CheckBox_NarrowingDevil.Checked)
          return false;
        name = mapData.DevilType == null ? "Devil" : string.Format("{0}'s Map Lv. {1}", (object) mapData.DevilType.Name, (object) mapData.DevilLevel.Value);
      }
      else
        name = "Unknown";
      TreasureMapDataControl.TreasureMapListBoxItem treasureMapListBoxItem1 = new TreasureMapDataControl.TreasureMapListBoxItem(index, name);
      if (this.toolButton_SortLVUp.Checked || this.toolButton_SortLVDown.Checked)
      {
        TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
        for (int index1 = 0; index1 < this.listBox_TreasureMap.Items.Count; ++index1)
        {
          if (this.listBox_TreasureMap.Items[index1] is TreasureMapDataControl.TreasureMapListBoxItem treasureMapListBoxItem2)
          {
            TreasureMapData mapData1 = treasureMapManager.GetMapData(treasureMapListBoxItem2.Index);
            TreasureMapData mapData2 = treasureMapManager.GetMapData(index);
            if (this.toolButton_SortLVUp.Checked)
            {
              if (mapData1.MapType == MapType.devil && mapData2.MapType == MapType.Normal && mapData1.MapLevel >= mapData2.MapLevel)
              {
                this.listBox_TreasureMap.Items.Insert(index1, (object) treasureMapListBoxItem1);
                return true;
              }
              if (mapData1.MapLevel > mapData2.MapLevel)
              {
                this.listBox_TreasureMap.Items.Insert(index1, (object) treasureMapListBoxItem1);
                return true;
              }
            }
            else
            {
              if (mapData1.MapType == MapType.devil && mapData2.MapType == MapType.Normal && mapData1.MapLevel <= mapData2.MapLevel)
              {
                this.listBox_TreasureMap.Items.Insert(index1, (object) treasureMapListBoxItem1);
                return true;
              }
              if (mapData1.MapLevel < mapData2.MapLevel)
              {
                this.listBox_TreasureMap.Items.Insert(index1, (object) treasureMapListBoxItem1);
                return true;
              }
            }
          }
        }
      }
      this.listBox_TreasureMap.Items.Add((object) treasureMapListBoxItem1);
      return true;
    }

    private void RenewalMapCountLabel()
    {
      int mapCount = (int) SaveDataManager.Instance.SaveData.TreasureMapManager.MapCount;
      if (this.groupBoxWithCheckBox_Narrowing.Checked)
        this.label_MapCount.Text = string.Format("({0:D2}/{1:D2})", (object) this.listBox_TreasureMap.Items.Count, (object) mapCount);
      else
        this.label_MapCount.Text = string.Format("({0:D2}/{1:D2})", (object) mapCount, (object) 99);
    }

    private void RenewalToolButton()
    {
      this.toolButton_DeleteMap.Enabled = this.listBox_TreasureMap.SelectedIndex != -1;
      this.toolButton_CreateMap.Enabled = SaveDataManager.Instance.SaveData.TreasureMapManager.MapCount < (byte) 99;
    }

    private void RenewalPlaceName()
    {
      if (this._selectedMapData == null)
        return;
      if (this._selectedMapData.Place.Value >= (byte) 1 && this._selectedMapData.Place.Value <= (byte) 150)
      {
        int index = (int) TreasureMapDataTable.TreasureMapPlace_Table[(int) this._selectedMapData.Place.Value];
        this.label_PlaceName.Text = TreasureMapDataTable.TreasureMapPlaceName_Table[index];
      }
      else
        this.label_PlaceName.Text = string.Empty;
    }

    private void RenewalCandidatePlace()
    {
      if (this._selectedMapData != null)
      {
        if (this._selectedMapData.MapType == MapType.Normal)
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append("Valid: ");
          ReadOnlyCollection<byte> validPlaceList = this._selectedMapData.ValidPlaceList;
          if (validPlaceList.Count > 0)
          {
            bool flag = true;
            foreach (byte num in validPlaceList)
            {
              if (!flag)
                stringBuilder.Append(", ");
              if (this.checkBox_PlaceHex.Checked)
                stringBuilder.AppendFormat("{0:X02}", (object) num);
              else
                stringBuilder.AppendFormat("{0:D}", (object) num);
              flag = false;
            }
          }
          else
            stringBuilder.Append("None");
          this.labelCandidatePlace.Text = stringBuilder.ToString();
        }
        else
          this.labelCandidatePlace.Text = string.Empty;
      }
      else
        this.labelCandidatePlace.Text = string.Empty;
    }

    private void RenewalEditArea(bool floorDetail)
    {
      this.BeginUpdate();
      if (this.listBox_TreasureMap.SelectedIndex == -1)
      {
        this.Panel_TreasureMapEditArea.Enabled = false;
        this.textBox_Detector.Text = string.Empty;
        this.textBox_Renewer.Text = string.Empty;
        this.label_PlaceName.Text = string.Empty;
        this.labelCandidatePlace.Text = string.Empty;
        this.RenewalDungeonDetail((TreasureMapData) null);
      }
      else if (this._selectedMapData != null)
      {
        this.Panel_TreasureMapEditArea.Enabled = true;
        this.RenewalPlaceName();
        this.RenewalCandidatePlace();
        this.SetVisibleControl(this._selectedMapData.MapType);
        this.textBox_Detector.Text = this._selectedMapData.Detector.Value;
        this.textBox_Renewer.Text = this._selectedMapData.Renewer.Value;
        this.numericUpDown_Place.Value = (Decimal) this._selectedMapData.Place.Value;
        this.checkBox_OpenProbability1.Checked = this._selectedMapData.IsOpenProbability(0);
        this.checkBox_OpenProbability2.Checked = this._selectedMapData.IsOpenProbability(1);
        this.checkBox_OpenProbability3.Checked = this._selectedMapData.IsOpenProbability(2);
        switch (this._selectedMapData.MapType)
        {
          case MapType.Normal:
            if (floorDetail)
              this._selectedMapData.CalculateDetail(true);
            this.radioButton_NormalMap.Checked = true;
            this.numericUpDown_MapNo1.Value = (Decimal) this._selectedMapData.Rank;
            this.numericUpDown_MapNo2.Value = (Decimal) this._selectedMapData.Seed;
            if (this._selectedMapData.IsValidSeed)
              this.numericUpDown_MapNo2.ForeColor = Color.Black;
            else
              this.numericUpDown_MapNo2.ForeColor = Color.Red;
            if (this._selectedMapData.IsValidRank)
              this.numericUpDown_MapNo1.ForeColor = Color.Black;
            else
              this.numericUpDown_MapNo1.ForeColor = Color.Red;
            if (this._selectedMapData.IsValidPlace)
            {
              this.numericUpDown_Place.ForeColor = Color.Black;
              break;
            }
            this.numericUpDown_Place.ForeColor = Color.Red;
            break;
          case MapType.devil:
            this.radioButton_DevilMap.Checked = true;
            this.comboBox_Devil.SelectedItem = (object) this._selectedMapData.DevilType;
            this.numericUpDown_DevilLevel.Value = (Decimal) this._selectedMapData.DevilLevel.Value;
            this.numericUpDown_DevilVictoryTurn.Value = (Decimal) this._selectedMapData.DevilVictoryTurn;
            this.numericUpDown_MapNo2.ForeColor = Color.Black;
            break;
        }
        if (this._selectedMapData.MapState == MapState.NotDiscover)
          this.comboBox_State.SelectedIndex = 0;
        else if (this._selectedMapData.MapState == MapState.Discover)
          this.comboBox_State.SelectedIndex = 1;
        else if (this._selectedMapData.MapState == MapState.Clear)
          this.comboBox_State.SelectedIndex = 2;
        else
          this.comboBox_State.SelectedIndex = -1;
        this.RenewalDungeonDetail(this._selectedMapData);
      }
      this.Panel_NormalMap.Invalidate();
      this.EndUpdate();
    }

    private void RenewalDungeonDetail(TreasureMapData mapData)
    {
      if (mapData != null && mapData.MapType == MapType.Normal && mapData.Rank >= (byte) 2 && mapData.Rank <= (byte) 248)
      {
        this.richTextBox_dummy.Visible = true;
        this.textBox_DungeonDetail.Text = string.Empty;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("Rank: {0:X2}, Seed: {1:X4}\n", (object) mapData.Rank, (object) mapData.Seed);
        stringBuilder.AppendFormat("{0}\n", (object) mapData.MapName);
        stringBuilder.AppendFormat("Type: {0}\n", (object) mapData.MapTypeName);
        stringBuilder.AppendFormat("Floors: {0}\n", (object) mapData.FloorCount);
        stringBuilder.AppendFormat("Monster rank: {0}\n", (object) mapData.MonsterRank);
        stringBuilder.AppendFormat("Boss: {0}\n", (object) mapData.BossName);
        int treasureBoxCount = mapData.GetTreasureBoxCount(0);
        stringBuilder.AppendFormat("Number of chests: {0}\n", (object) treasureBoxCount);
        if (treasureBoxCount > 0)
        {
          stringBuilder.Append(" By rank:\n  ");
          for (int rank = 10; rank > 0; --rank)
            stringBuilder.AppendFormat(" {0}:{1}", (object) TreasureMapDataControl._treasureBoxRankSymbol[0, rank - 1], (object) mapData.GetTreasureBoxCount(rank));
          stringBuilder.Append("\n");
          stringBuilder.Append(" By floor:\n");
          for (int floor = 0; floor < mapData.FloorCount; ++floor)
          {
            if (mapData.GetTreasureBoxCountPerFloor(floor) > 0)
            {
              stringBuilder.AppendFormat("   B{0:D2}:", (object) (floor + 1));
              foreach (TreasureBoxInfo treasureBoxInfo in mapData.TreasureBoxInfoList[floor])
                stringBuilder.AppendFormat(" {0}", (object) TreasureMapDataControl._treasureBoxRankSymbol[0, treasureBoxInfo.Rank - 1]);
              stringBuilder.Append("\n");
            }
          }
        }
        for (int floor = 0; floor < mapData.FloorCount; ++floor)
        {
          this._treasureBoxCount[floor] = 0;
          byte[,] floorMap = mapData.GetFloorMap(floor);
          if (floorMap != null)
          {
            stringBuilder.Append("\n");
            stringBuilder.AppendFormat("B{0:D2}\n", (object) (floor + 1));
            for (int y = 0; y < mapData.GetFloorHeight(floor); ++y)
            {
              for (int x = 0; x < mapData.GetFloorWidth(floor); ++x)
              {
                if (floorMap[y, x] == (byte) 1 || floorMap[y, x] == (byte) 3)
                  stringBuilder.Append("■");
                else if (floorMap[y, x] == (byte) 4)
                {
                  if (mapData.IsUpStep(floor, x, y))
                    stringBuilder.Append("△");
                  else
                    stringBuilder.Append("　");
                }
                else if (floorMap[y, x] == (byte) 5)
                  stringBuilder.Append("▽");
                else if (floorMap[y, x] == (byte) 6)
                {
                  int num = mapData.IsTreasureBoxRank(floor, x, y);
                  if (num > 0)
                  {
                    int treasureBoxIndex = mapData.GetTreasureBoxIndex(floor, x, y);
                    this._treasureBoxIndexes[floor, treasureBoxIndex] = stringBuilder.Length;
                    stringBuilder.AppendFormat("{0}", (object) TreasureMapDataControl._treasureBoxRankSymbol[1, num - 1]);
                    ++this._treasureBoxCount[floor];
                  }
                  else
                    stringBuilder.Append("　");
                }
                else
                  stringBuilder.Append("　");
              }
              stringBuilder.Append("\n");
            }
            for (int index1 = 0; index1 < this._treasureBoxCount[floor]; ++index1)
            {
              int rank = mapData.TreasureBoxInfoList[floor][index1].Rank;
              int index2 = mapData.TreasureBoxInfoList[floor][index1].Index;
              string treasureBoxItem = mapData.GetTreasureBoxItem(floor, index2, 2);
              stringBuilder.AppendFormat("({0:D2}, {1:D2}) {2} {3}\n", (object) mapData.TreasureBoxInfoList[floor][index1].X, (object) mapData.TreasureBoxInfoList[floor][index1].Y, (object) TreasureMapDataControl._treasureBoxRankSymbol[1, rank - 1], (object) treasureBoxItem);
            }
          }
        }
        this.textBox_DungeonDetail.Text = stringBuilder.ToString();
        using (Font font = new Font("MS Gothic", 9f, FontStyle.Underline, GraphicsUnit.Point, (byte) 128))
        {
          for (int index3 = 0; index3 < mapData.FloorCount; ++index3)
          {
            for (int index4 = 0; index4 < this._treasureBoxCount[index3]; ++index4)
            {
              this.textBox_DungeonDetail.SelectionStart = this._treasureBoxIndexes[index3, index4];
              this.textBox_DungeonDetail.SelectionLength = 1;
              this.textBox_DungeonDetail.SelectionFont = font;
              this.textBox_DungeonDetail.SelectionColor = Color.Blue;
            }
          }
        }
        this.textBox_DungeonDetail.SelectionStart = 0;
        this.textBox_DungeonDetail.SelectionLength = 0;
        this.textBox_DungeonDetail.ScrollToCaret();
        this.label_DungeonDetail.Enabled = true;
        this.textBox_DungeonDetail.Enabled = true;
        this.richTextBox_dummy.Visible = false;
      }
      else
      {
        this.label_DungeonDetail.Enabled = false;
        this.textBox_DungeonDetail.Enabled = false;
        this.textBox_DungeonDetail.Text = string.Empty;
      }
    }

    private void listBox_TreasureMap_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount == 0 && this.listBox_TreasureMap.SelectedIndex != -1)
      {
        TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
        if (this.listBox_TreasureMap.SelectedItem is TreasureMapDataControl.TreasureMapListBoxItem selectedItem)
        {
          this._selectedMapData = treasureMapManager.GetMapData(selectedItem.Index);
          this.RenewalEditArea(true);
        }
      }
      this.RenewalToolButton();
    }

    private void SetVisibleControl(MapType mapType)
    {
      if (mapType == MapType.Normal)
      {
        this.Panel_Devil.Visible = false;
        this.Panel_NormalMap.Visible = true;
        this.Panel_NormalMap.Location = this._panelLocation;
      }
      else
      {
        if (mapType != MapType.devil)
          return;
        this.Panel_Devil.Visible = true;
        this.Panel_NormalMap.Visible = false;
        this.Panel_Devil.Location = this._panelLocation;
      }
    }

    private void toolButton_CreateMap_Click(object sender, EventArgs e)
    {
      TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
      if (!treasureMapManager.CreateMapData())
        return;
      this.BeginUpdate();
      this.groupBoxWithCheckBox_Narrowing.Checked = false;
      this.EndUpdate();
      this.listBox_TreasureMap.BeginUpdate();
      TreasureMapData mapData = treasureMapManager.GetMapData((int) treasureMapManager.MapCount - 1);
      this.RenewalListBox();
      this.listBox_TreasureMap.SelectedIndex = (int) treasureMapManager.MapCount - 1;
      this._selectedMapData = mapData;
      this.RenewalEditArea(true);
      this.listBox_TreasureMap.EndUpdate();
    }

    private void toolButton_DeleteMap_Click(object sender, EventArgs e)
    {
      if (this.listBox_TreasureMap.SelectedIndex == -1 || !(this.listBox_TreasureMap.SelectedItem is TreasureMapDataControl.TreasureMapListBoxItem selectedItem1))
        return;
      SaveDataManager.Instance.SaveData.TreasureMapManager.DeleteMapData(selectedItem1.Index);
      int selectedIndex = this.listBox_TreasureMap.SelectedIndex;
      this.listBox_TreasureMap.Items.RemoveAt(selectedIndex);
      this.RenewalListBox();
      if (this.listBox_TreasureMap.Items.Count > selectedIndex)
      {
        this.listBox_TreasureMap.SelectedIndex = selectedIndex;
        TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
        this._selectedMapData = !(this.listBox_TreasureMap.SelectedItem is TreasureMapDataControl.TreasureMapListBoxItem selectedItem2) ? (TreasureMapData) null : treasureMapManager.GetMapData(selectedItem2.Index);
      }
      else
      {
        this.listBox_TreasureMap.SelectedIndex = selectedIndex - 1;
        this._selectedMapData = (TreasureMapData) null;
      }
      this.RenewalMapCountLabel();
      this.RenewalEditArea(true);
    }

    private void radioButton_MapType_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is RadioButton radioButton))
        return;
      MapType tag = (MapType) radioButton.Tag;
      if (this._selectedMapData == null)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      this._selectedMapData.MapType = tag;
      this._selectedMapData.Rank = tag != MapType.Normal ? (byte) 1 : (byte) 2;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      this.RenewalListBox();
      this.RenewalEditArea(true);
    }

    private void textBox_Detector_TextChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedMapData == null)
        return;
      this._selectedMapData.Detector.Value = this.textBox_Detector.Text;
      this.textBox_Detector.Text = this._selectedMapData.Detector.Value;
    }

    private void textBox_Renewer_TextChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedMapData == null)
        return;
      this._selectedMapData.Renewer.Value = this.textBox_Renewer.Text;
      this.textBox_Renewer.Text = this._selectedMapData.Renewer.Value;
    }

    private void numericUpDown_Place_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedMapData == null)
        return;
      this._selectedMapData.Place.Value = (byte) this.numericUpDown_Place.Value;
      this.RenewalListBox();
      this.RenewalPlaceName();
      if (this._selectedMapData.MapType == MapType.devil || this._selectedMapData.IsValidPlace)
        this.numericUpDown_Place.ForeColor = Color.Black;
      else
        this.numericUpDown_Place.ForeColor = Color.Red;
    }

    private void comboBox_State_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this.comboBox_State.SelectedIndex == -1 || this._selectedMapData == null)
        return;
      this._selectedMapData.MapState = (MapState) (1 << this.comboBox_State.SelectedIndex);
    }

    private void checkBox_OpenProbability_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || !(sender is CheckBox checkBox) || this._selectedMapData == null)
        return;
      this._selectedMapData.SetOpenProbability((int) checkBox.Tag, checkBox.Checked);
    }

    private void comboBox_Devil_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this.comboBox_Devil.SelectedIndex == -1 || !(this.comboBox_Devil.SelectedItem is Devil selectedItem) || this._selectedMapData == null)
        return;
      this._selectedMapData.DevilType = selectedItem;
      this.RenewalListBox();
    }

    private void numericUpDown_DevilLevel_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedMapData == null)
        return;
      this._selectedMapData.DevilLevel.Value = (byte) this.numericUpDown_DevilLevel.Value;
      this.RenewalListBox();
    }

    private void numericUpDown_DevilVictoryTurn_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedMapData == null)
        return;
      this._selectedMapData.DevilVictoryTurn = (ushort) this.numericUpDown_DevilVictoryTurn.Value;
    }

    private void numericUpDown_MapNo1_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedMapData == null)
        return;
      this._selectedMapData.Rank = (byte) this.numericUpDown_MapNo1.Value;
      this._selectedMapData.CalculateDetail(true);
      this.RenewalListBox();
      this.RenewalEditArea(true);
      if (this._selectedMapData.IsValidRank)
        this.numericUpDown_MapNo1.ForeColor = Color.Black;
      else
        this.numericUpDown_MapNo1.ForeColor = Color.Red;
    }

    private void numericUpDown_MapNo2_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0 || this._selectedMapData == null)
        return;
      this._selectedMapData.Seed = (ushort) this.numericUpDown_MapNo2.Value;
      this._selectedMapData.CalculateDetail(true);
      this.RenewalListBox();
      this.RenewalEditArea(true);
      if (this._selectedMapData.IsValidSeed)
        this.numericUpDown_MapNo2.ForeColor = Color.Black;
      else
        this.numericUpDown_MapNo2.ForeColor = Color.Red;
    }

    private void numericUpDown_ClearCount_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.TreasureMapManager.ClearCount = (ushort) this.numericUpDown_ClearCount.Value;
    }

    private void Panel_NormalMap_Paint(object sender, PaintEventArgs e)
    {
      if (this.listBox_TreasureMap.SelectedIndex == -1)
        return;
      e.Graphics.ScaleTransform(this.AutoScaleFactor.Width, this.AutoScaleFactor.Height);
      if (this._selectedMapData == null || this._selectedMapData.MapType != MapType.Normal)
        return;
      using (Brush brush = (Brush) new SolidBrush(SystemColors.ControlText))
        e.Graphics.DrawString(this._selectedMapData.MapName, this.Font, brush, new PointF(6f, 35f));
    }

    private void checkBox_Hex_CheckedChanged(object sender, EventArgs e)
    {
      this.numericUpDown_MapNo1.Hexadecimal = this.checkBox_Hex.Checked;
      this.numericUpDown_MapNo2.Hexadecimal = this.checkBox_Hex.Checked;
    }

    private void checkBox_PlaceHex_CheckedChanged(object sender, EventArgs e)
    {
      this.numericUpDown_Place.Hexadecimal = this.checkBox_PlaceHex.Checked;
      this.RenewalCandidatePlace();
    }

    private void textBox_DungeonDetail_MouseMove(object sender, MouseEventArgs e)
    {
      if (this._selectedMapData == null || this._selectedMapData.MapType != MapType.Normal)
        return;
      int indexFromPosition = this.textBox_DungeonDetail.GetCharIndexFromPosition(new Point(e.X - 5, e.Y));
      for (int index1 = 0; index1 < this._selectedMapData.FloorCount; ++index1)
      {
        for (int index2 = 0; index2 < this._treasureBoxCount[index1]; ++index2)
        {
          if (this._treasureBoxIndexes[index1, index2] == indexFromPosition)
          {
            this.textBox_DungeonDetail.Cursor = Cursors.Arrow;
            return;
          }
        }
      }
      this.textBox_DungeonDetail.Cursor = Cursors.IBeam;
    }

    private void textBox_DungeonDetail_MouseDown(object sender, MouseEventArgs e)
    {
      if (this._selectedMapData == null || this._selectedMapData.MapType != MapType.Normal)
        return;
      int indexFromPosition = this.textBox_DungeonDetail.GetCharIndexFromPosition(new Point(e.X - 5, e.Y));
      for (int floor = 0; floor < this._selectedMapData.FloorCount; ++floor)
      {
        for (int boxIndex = 0; boxIndex < this._treasureBoxCount[floor]; ++boxIndex)
        {
          if (this._treasureBoxIndexes[floor, boxIndex] == indexFromPosition)
          {
            this.textBox_DungeonDetail.Cursor = Cursors.Arrow;
            using (TreasureBoxItemTableList boxItemTableList = new TreasureBoxItemTableList(this._selectedMapData, floor, boxIndex))
            {
              foreach (TreasureBoxInfo treasureBoxInfo in this._selectedMapData.TreasureBoxInfoList[floor])
              {
                if (treasureBoxInfo.Index == boxIndex)
                  boxItemTableList.Text = string.Format("Item Table B{0} ({1}, {2}) {3}", (object) (floor + 1), (object) treasureBoxInfo.X, (object) treasureBoxInfo.Y, (object) TreasureMapDataControl._treasureBoxRankSymbol[0, treasureBoxInfo.Rank - 1]);
              }
              int num = (int) boxItemTableList.ShowDialog();
              return;
            }
          }
        }
      }
      this.textBox_DungeonDetail.Cursor = Cursors.IBeam;
    }

    private void checkBox_NarrowingLevel_CheckedChanged(object sender, EventArgs e)
    {
      this.numericUpDown_NarrowingLevel.Enabled = this.checkBox_NarrowingLevel.Checked;
      this.comboBox_NarrowingLevel.Enabled = this.checkBox_NarrowingLevel.Checked;
      if (this._updateCount != 0)
        return;
      this.RenewalListBox();
    }

    private void CheckBox_NarrowingDevil_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.RenewalListBox();
    }

    private void CheckBox_NarrowingNormal_CheckedChanged(object sender, EventArgs e)
    {
      this.comboBox_NarrowingName1.Enabled = this.CheckBox_NarrowingNormal.Checked;
      this.comboBox_NarrowingName2.Enabled = this.CheckBox_NarrowingNormal.Checked;
      this.comboBox_NarrowingName3.Enabled = this.CheckBox_NarrowingNormal.Checked;
      if (this._updateCount != 0)
        return;
      this.RenewalListBox();
    }

    private void comboBox_NarrowingName1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.RenewalListBox();
    }

    private void comboBox_NarrowingName2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.RenewalListBox();
    }

    private void comboBox_NarrowingName3_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.RenewalListBox();
    }

    private void numericUpDown_NarrowingLevel_ValueChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.RenewalListBox();
    }

    private void comboBox_NarrowingLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.RenewalListBox();
    }

    private void groupBoxWithCheckBox_Narrowing_CheckedChanged(object sender, EventArgs e)
    {
      if (this._updateCount != 0)
        return;
      this.RenewalListBox();
    }

    private void toolButton_SortLVUp_Click(object sender, EventArgs e)
    {
      this.toolButton_SortLVUp.Checked = !this.toolButton_SortLVUp.Checked;
      this.toolButton_SortLVDown.Checked = false;
      this.listBox_TreasureMap.SelectedIndex = -1;
      this._selectedMapData = (TreasureMapData) null;
      this.RenewalListBox();
    }

    private void toolButton_SortLVDown_Click(object sender, EventArgs e)
    {
      this.toolButton_SortLVDown.Checked = !this.toolButton_SortLVDown.Checked;
      this.toolButton_SortLVUp.Checked = false;
      this.listBox_TreasureMap.SelectedIndex = -1;
      this._selectedMapData = (TreasureMapData) null;
      this.RenewalListBox();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TreasureMapDataControl));
      this.listBox_TreasureMap = new ListBox();
      this.radioButton_NormalMap = new RadioButton();
      this.radioButton_DevilMap = new RadioButton();
      this.GroupBox_MapType = new JS_GroupBox();
      this.label1 = new Label();
      this.textBox_Detector = new TextBox();
      this.textBox_Renewer = new TextBox();
      this.label2 = new Label();
      this.Panel_NormalMap = new JS_Panel();
      this.checkBox_Hex = new CheckBox();
      this.numericUpDown_MapNo2 = new SafeNumericUpDown();
      this.numericUpDown_MapNo1 = new SafeNumericUpDown();
      this.label3 = new Label();
      this.GroupBox_Probability = new JS_GroupBox();
      this.checkBox_OpenProbability3 = new CheckBox();
      this.checkBox_OpenProbability2 = new CheckBox();
      this.checkBox_OpenProbability1 = new CheckBox();
      this.Panel_Devil = new JS_Panel();
      this.numericUpDown_DevilVictoryTurn = new SafeNumericUpDown();
      this.label6 = new Label();
      this.numericUpDown_DevilLevel = new SafeNumericUpDown();
      this.label5 = new Label();
      this.label4 = new Label();
      this.comboBox_Devil = new ComboBox();
      this.Panel_TreasureMapEditArea = new JS_Panel();
      this.labelCandidatePlace = new Label();
      this.label_PlaceName = new Label();
      this.checkBox_PlaceHex = new CheckBox();
      this.richTextBox_dummy = new RichTextBox();
      this.textBox_DungeonDetail = new RichTextBox();
      this.label_DungeonDetail = new Label();
      this.numericUpDown_Place = new SafeNumericUpDown();
      this.label8 = new Label();
      this.comboBox_State = new ComboBox();
      this.label7 = new Label();
      this.panel2 = new Panel();
      this.toolStrip2 = new ToolStrip();
      this.toolButton_CreateMap = new ToolStripButton();
      this.toolButton_DeleteMap = new ToolStripButton();
      this.label_MapCount = new ToolStripLabel();
      this.numericUpDown_ClearCount = new SafeNumericUpDown();
      this.label9 = new Label();
      this.groupBoxWithCheckBox_Narrowing = new GroupBoxWithCheckBox();
      this.comboBox_NarrowingName3 = new ComboBox();
      this.comboBox_NarrowingName2 = new ComboBox();
      this.comboBox_NarrowingName1 = new ComboBox();
      this.CheckBox_NarrowingNormal = new CheckBox();
      this.CheckBox_NarrowingDevil = new CheckBox();
      this.checkBox_NarrowingLevel = new CheckBox();
      this.numericUpDown_NarrowingLevel = new NumericUpDown();
      this.comboBox_NarrowingLevel = new ComboBox();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolButton_SortLVUp = new ToolStripButton();
      this.toolButton_SortLVDown = new ToolStripButton();
      this.GroupBox_MapType.SuspendLayout();
      this.Panel_NormalMap.SuspendLayout();
      this.numericUpDown_MapNo2.BeginInit();
      this.numericUpDown_MapNo1.BeginInit();
      this.GroupBox_Probability.SuspendLayout();
      this.Panel_Devil.SuspendLayout();
      this.numericUpDown_DevilVictoryTurn.BeginInit();
      this.numericUpDown_DevilLevel.BeginInit();
      this.Panel_TreasureMapEditArea.SuspendLayout();
      this.numericUpDown_Place.BeginInit();
      this.panel2.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.numericUpDown_ClearCount.BeginInit();
      this.groupBoxWithCheckBox_Narrowing.SuspendLayout();
      this.numericUpDown_NarrowingLevel.BeginInit();
      this.SuspendLayout();
      this.listBox_TreasureMap.Dock = DockStyle.Fill;
      this.listBox_TreasureMap.FormattingEnabled = true;
      this.listBox_TreasureMap.ItemHeight = 12;
      this.listBox_TreasureMap.Location = new Point(0, 0);
      this.listBox_TreasureMap.Name = "listBox_TreasureMap";
      this.listBox_TreasureMap.Size = new Size(225, 280);
      this.listBox_TreasureMap.TabIndex = 0;
      this.listBox_TreasureMap.SelectedIndexChanged += new EventHandler(this.listBox_TreasureMap_SelectedIndexChanged);
      this.radioButton_NormalMap.AutoSize = true;
      this.radioButton_NormalMap.Location = new Point(12, 22);
      this.radioButton_NormalMap.Name = "radioButton_NormalMap";
      this.radioButton_NormalMap.Size = new Size(58, 17);
      this.radioButton_NormalMap.TabIndex = 2;
      this.radioButton_NormalMap.TabStop = true;
      this.radioButton_NormalMap.Tag = (object) MapType.Normal;
      this.radioButton_NormalMap.Text = "Normal";
      this.radioButton_NormalMap.UseVisualStyleBackColor = true;
      this.radioButton_NormalMap.CheckedChanged += new EventHandler(this.radioButton_MapType_CheckedChanged);
      this.radioButton_DevilMap.AutoSize = true;
      this.radioButton_DevilMap.Location = new Point(77, 22);
      this.radioButton_DevilMap.Name = "radioButton_DevilMap";
      this.radioButton_DevilMap.Size = new Size(86, 17);
      this.radioButton_DevilMap.TabIndex = 3;
      this.radioButton_DevilMap.TabStop = true;
      this.radioButton_DevilMap.Tag = (object) MapType.devil;
      this.radioButton_DevilMap.Text = "Legacy Boss";
      this.radioButton_DevilMap.UseVisualStyleBackColor = true;
      this.radioButton_DevilMap.CheckedChanged += new EventHandler(this.radioButton_MapType_CheckedChanged);
      this.GroupBox_MapType.Controls.Add((Control) this.radioButton_DevilMap);
      this.GroupBox_MapType.Controls.Add((Control) this.radioButton_NormalMap);
      this.GroupBox_MapType.Location = new Point(3, 3);
      this.GroupBox_MapType.Name = "GroupBox_MapType";
      this.GroupBox_MapType.Size = new Size(202, 51);
      this.GroupBox_MapType.TabIndex = 4;
      this.GroupBox_MapType.TabStop = false;
      this.GroupBox_MapType.Text = "Map Type";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(36, 64);
      this.label1.Name = "label1";
      this.label1.Size = new Size(75, 13);
      this.label1.TabIndex = 5;
      this.label1.Text = "Discovered by";
      this.textBox_Detector.Location = new Point(111, 61);
      this.textBox_Detector.Name = "textBox_Detector";
      this.textBox_Detector.Size = new Size(87, 20);
      this.textBox_Detector.TabIndex = 6;
      this.textBox_Detector.TextChanged += new EventHandler(this.textBox_Detector_TextChanged);
      this.textBox_Renewer.Location = new Point(111, 85);
      this.textBox_Renewer.Name = "textBox_Renewer";
      this.textBox_Renewer.Size = new Size(87, 20);
      this.textBox_Renewer.TabIndex = 8;
      this.textBox_Renewer.TextChanged += new EventHandler(this.textBox_Renewer_TextChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(38, 88);
      this.label2.Name = "label2";
      this.label2.Size = new Size(73, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Conquered by";
      this.Panel_NormalMap.Controls.Add((Control) this.checkBox_Hex);
      this.Panel_NormalMap.Controls.Add((Control) this.numericUpDown_MapNo2);
      this.Panel_NormalMap.Controls.Add((Control) this.numericUpDown_MapNo1);
      this.Panel_NormalMap.Controls.Add((Control) this.label3);
      this.Panel_NormalMap.Location = new Point(0, 219);
      this.Panel_NormalMap.Name = "Panel_NormalMap";
      this.Panel_NormalMap.Size = new Size(273, 82);
      this.Panel_NormalMap.TabIndex = 9;
      this.Panel_NormalMap.Paint += new PaintEventHandler(this.Panel_NormalMap_Paint);
      this.checkBox_Hex.AutoSize = true;
      this.checkBox_Hex.Location = new Point(191, 12);
      this.checkBox_Hex.Name = "checkBox_Hex";
      this.checkBox_Hex.Size = new Size(45, 17);
      this.checkBox_Hex.TabIndex = 3;
      this.checkBox_Hex.Text = "Hex";
      this.checkBox_Hex.UseVisualStyleBackColor = true;
      this.checkBox_Hex.CheckedChanged += new EventHandler(this.checkBox_Hex_CheckedChanged);
      this.numericUpDown_MapNo2.Location = new Point(111, 10);
      this.numericUpDown_MapNo2.Maximum = new Decimal(new int[4]
      {
        (int) ushort.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_MapNo2.Name = "numericUpDown_MapNo2";
      this.numericUpDown_MapNo2.Size = new Size(74, 20);
      this.numericUpDown_MapNo2.TabIndex = 2;
      this.numericUpDown_MapNo2.Value = new Decimal(new int[4]);
      this.numericUpDown_MapNo2.ValueChanged += new EventHandler(this.numericUpDown_MapNo2_ValueChanged);
      this.numericUpDown_MapNo1.Location = new Point(54, 10);
      this.numericUpDown_MapNo1.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_MapNo1.Name = "numericUpDown_MapNo1";
      this.numericUpDown_MapNo1.Size = new Size(51, 20);
      this.numericUpDown_MapNo1.TabIndex = 1;
      this.numericUpDown_MapNo1.Value = new Decimal(new int[4]);
      this.numericUpDown_MapNo1.ValueChanged += new EventHandler(this.numericUpDown_MapNo1_ValueChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(6, 12);
      this.label3.Name = "label3";
      this.label3.Size = new Size(45, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "Map No.";
      this.GroupBox_Probability.Controls.Add((Control) this.checkBox_OpenProbability3);
      this.GroupBox_Probability.Controls.Add((Control) this.checkBox_OpenProbability2);
      this.GroupBox_Probability.Controls.Add((Control) this.checkBox_OpenProbability1);
      this.GroupBox_Probability.Location = new Point(0, 186);
      this.GroupBox_Probability.Name = "GroupBox_Probability";
      this.GroupBox_Probability.Size = new Size(204, 37);
      this.GroupBox_Probability.TabIndex = 10;
      this.GroupBox_Probability.TabStop = false;
      this.GroupBox_Probability.Text = "Treasures Plundered";
      this.checkBox_OpenProbability3.AutoSize = true;
      this.checkBox_OpenProbability3.Location = new Point(147, 15);
      this.checkBox_OpenProbability3.Name = "checkBox_OpenProbability3";
      this.checkBox_OpenProbability3.Size = new Size(50, 17);
      this.checkBox_OpenProbability3.TabIndex = 2;
      this.checkBox_OpenProbability3.Tag = (object) 2;
      this.checkBox_OpenProbability3.Text = "Third";
      this.checkBox_OpenProbability3.UseVisualStyleBackColor = true;
      this.checkBox_OpenProbability3.CheckedChanged += new EventHandler(this.checkBox_OpenProbability_CheckedChanged);
      this.checkBox_OpenProbability2.AutoSize = true;
      this.checkBox_OpenProbability2.Location = new Point(78, 15);
      this.checkBox_OpenProbability2.Name = "checkBox_OpenProbability2";
      this.checkBox_OpenProbability2.Size = new Size(63, 17);
      this.checkBox_OpenProbability2.TabIndex = 1;
      this.checkBox_OpenProbability2.Tag = (object) 1;
      this.checkBox_OpenProbability2.Text = "Second";
      this.checkBox_OpenProbability2.UseVisualStyleBackColor = true;
      this.checkBox_OpenProbability2.CheckedChanged += new EventHandler(this.checkBox_OpenProbability_CheckedChanged);
      this.checkBox_OpenProbability1.AutoSize = true;
      this.checkBox_OpenProbability1.Location = new Point(22, 15);
      this.checkBox_OpenProbability1.Name = "checkBox_OpenProbability1";
      this.checkBox_OpenProbability1.Size = new Size(45, 17);
      this.checkBox_OpenProbability1.TabIndex = 0;
      this.checkBox_OpenProbability1.Tag = (object) 0;
      this.checkBox_OpenProbability1.Text = "First";
      this.checkBox_OpenProbability1.UseVisualStyleBackColor = true;
      this.checkBox_OpenProbability1.CheckedChanged += new EventHandler(this.checkBox_OpenProbability_CheckedChanged);
      this.Panel_Devil.Controls.Add((Control) this.numericUpDown_DevilVictoryTurn);
      this.Panel_Devil.Controls.Add((Control) this.label6);
      this.Panel_Devil.Controls.Add((Control) this.numericUpDown_DevilLevel);
      this.Panel_Devil.Controls.Add((Control) this.label5);
      this.Panel_Devil.Controls.Add((Control) this.label4);
      this.Panel_Devil.Controls.Add((Control) this.comboBox_Devil);
      this.Panel_Devil.Location = new Point(0, 261);
      this.Panel_Devil.Name = "Panel_Devil";
      this.Panel_Devil.Size = new Size(233, 54);
      this.Panel_Devil.TabIndex = 11;
      this.numericUpDown_DevilVictoryTurn.Location = new Point(173, 32);
      this.numericUpDown_DevilVictoryTurn.Maximum = new Decimal(new int[4]
      {
        999,
        0,
        0,
        0
      });
      this.numericUpDown_DevilVictoryTurn.Name = "numericUpDown_DevilVictoryTurn";
      this.numericUpDown_DevilVictoryTurn.Size = new Size(49, 20);
      this.numericUpDown_DevilVictoryTurn.TabIndex = 5;
      this.numericUpDown_DevilVictoryTurn.Value = new Decimal(new int[4]);
      this.numericUpDown_DevilVictoryTurn.ValueChanged += new EventHandler(this.numericUpDown_DevilVictoryTurn_ValueChanged);
      this.label6.AutoSize = true;
      this.label6.Location = new Point(105, 34);
      this.label6.Name = "label6";
      this.label6.Size = new Size(66, 13);
      this.label6.TabIndex = 4;
      this.label6.Text = "No. of Turns";
      this.numericUpDown_DevilLevel.Location = new Point(53, 32);
      this.numericUpDown_DevilLevel.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_DevilLevel.Name = "numericUpDown_DevilLevel";
      this.numericUpDown_DevilLevel.Size = new Size(49, 20);
      this.numericUpDown_DevilLevel.TabIndex = 3;
      this.numericUpDown_DevilLevel.Value = new Decimal(new int[4]);
      this.numericUpDown_DevilLevel.ValueChanged += new EventHandler(this.numericUpDown_DevilLevel_ValueChanged);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(18, 34);
      this.label5.Name = "label5";
      this.label5.Size = new Size(33, 13);
      this.label5.TabIndex = 2;
      this.label5.Text = "Level";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(21, 13);
      this.label4.Name = "label4";
      this.label4.Size = new Size(30, 13);
      this.label4.TabIndex = 1;
      this.label4.Text = "Boss";
      this.comboBox_Devil.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_Devil.FormattingEnabled = true;
      this.comboBox_Devil.Location = new Point(53, 9);
      this.comboBox_Devil.Name = "comboBox_Devil";
      this.comboBox_Devil.Size = new Size(121, 21);
      this.comboBox_Devil.TabIndex = 0;
      this.comboBox_Devil.SelectedIndexChanged += new EventHandler(this.comboBox_Devil_SelectedIndexChanged);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.labelCandidatePlace);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.label_PlaceName);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.checkBox_PlaceHex);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.richTextBox_dummy);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.textBox_DungeonDetail);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.label_DungeonDetail);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.numericUpDown_Place);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.label8);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.comboBox_State);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.label7);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.GroupBox_MapType);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.Panel_Devil);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.label1);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.GroupBox_Probability);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.textBox_Detector);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.Panel_NormalMap);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.label2);
      this.Panel_TreasureMapEditArea.Controls.Add((Control) this.textBox_Renewer);
      this.Panel_TreasureMapEditArea.Enabled = false;
      this.Panel_TreasureMapEditArea.Location = new Point(249, 28);
      this.Panel_TreasureMapEditArea.Name = "Panel_TreasureMapEditArea";
      this.Panel_TreasureMapEditArea.Size = new Size(611, 373);
      this.Panel_TreasureMapEditArea.TabIndex = 12;
      this.labelCandidatePlace.AutoSize = true;
      this.labelCandidatePlace.Location = new Point(111, 173);
      this.labelCandidatePlace.Name = "labelCandidatePlace";
      this.labelCandidatePlace.Size = new Size(0, 13);
      this.labelCandidatePlace.TabIndex = 22;
      this.label_PlaceName.AutoSize = true;
      this.label_PlaceName.Location = new Point(111, 156);
      this.label_PlaceName.Name = "label_PlaceName";
      this.label_PlaceName.Size = new Size(0, 13);
      this.label_PlaceName.TabIndex = 21;
      this.label_PlaceName.TextAlign = ContentAlignment.MiddleLeft;
      this.checkBox_PlaceHex.AutoSize = true;
      this.checkBox_PlaceHex.Location = new Point(204, 134);
      this.checkBox_PlaceHex.Name = "checkBox_PlaceHex";
      this.checkBox_PlaceHex.Size = new Size(45, 17);
      this.checkBox_PlaceHex.TabIndex = 20;
      this.checkBox_PlaceHex.Text = "Hex";
      this.checkBox_PlaceHex.UseVisualStyleBackColor = true;
      this.checkBox_PlaceHex.CheckedChanged += new EventHandler(this.checkBox_PlaceHex_CheckedChanged);
      this.richTextBox_dummy.BackColor = SystemColors.Control;
      this.richTextBox_dummy.Font = new Font("Consolas", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.richTextBox_dummy.Location = new Point(277, 18);
      this.richTextBox_dummy.Name = "richTextBox_dummy";
      this.richTextBox_dummy.ReadOnly = true;
      this.richTextBox_dummy.ScrollBars = RichTextBoxScrollBars.Vertical;
      this.richTextBox_dummy.Size = new Size(301, 352);
      this.richTextBox_dummy.TabIndex = 19;
      this.richTextBox_dummy.Text = "";
      this.richTextBox_dummy.Visible = false;
      this.textBox_DungeonDetail.BackColor = SystemColors.Control;
      this.textBox_DungeonDetail.Font = new Font("MS Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.textBox_DungeonDetail.Location = new Point(277, 18);
      this.textBox_DungeonDetail.Name = "textBox_DungeonDetail";
      this.textBox_DungeonDetail.ReadOnly = true;
      this.textBox_DungeonDetail.ScrollBars = RichTextBoxScrollBars.Vertical;
      this.textBox_DungeonDetail.Size = new Size(301, 352);
      this.textBox_DungeonDetail.TabIndex = 18;
      this.textBox_DungeonDetail.Text = "";
      this.textBox_DungeonDetail.MouseMove += new MouseEventHandler(this.textBox_DungeonDetail_MouseMove);
      this.textBox_DungeonDetail.MouseDown += new MouseEventHandler(this.textBox_DungeonDetail_MouseDown);
      this.label_DungeonDetail.AutoSize = true;
      this.label_DungeonDetail.Enabled = false;
      this.label_DungeonDetail.Location = new Point(275, 3);
      this.label_DungeonDetail.Name = "label_DungeonDetail";
      this.label_DungeonDetail.Size = new Size(63, 12);
      this.label_DungeonDetail.TabIndex = 17;
      this.label_DungeonDetail.Text = "Map Details";
      this.numericUpDown_Place.Location = new Point(111, 132);
      this.numericUpDown_Place.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown_Place.Name = "numericUpDown_Place";
      this.numericUpDown_Place.Size = new Size(87, 20);
      this.numericUpDown_Place.TabIndex = 15;
      this.numericUpDown_Place.Value = new Decimal(new int[4]);
      this.numericUpDown_Place.ValueChanged += new EventHandler(this.numericUpDown_Place_ValueChanged);
      this.label8.AutoSize = true;
      this.label8.Location = new Point(63, 134);
      this.label8.Name = "label8";
      this.label8.Size = new Size(48, 13);
      this.label8.TabIndex = 14;
      this.label8.Text = "Location";
      this.comboBox_State.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_State.FormattingEnabled = true;
      this.comboBox_State.Items.AddRange(new object[3]
      {
        (object) "Not Found",
        (object) "Discovered",
        (object) "Cleared"
      });
      this.comboBox_State.Location = new Point(111, 109);
      this.comboBox_State.Name = "comboBox_State";
      this.comboBox_State.Size = new Size(87, 21);
      this.comboBox_State.TabIndex = 13;
      this.comboBox_State.SelectedIndexChanged += new EventHandler(this.comboBox_State_SelectedIndexChanged);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(74, 112);
      this.label7.Name = "label7";
      this.label7.Size = new Size(37, 13);
      this.label7.TabIndex = 12;
      this.label7.Text = "Status";
      this.panel2.BorderStyle = BorderStyle.Fixed3D;
      this.panel2.Controls.Add((Control) this.listBox_TreasureMap);
      this.panel2.Controls.Add((Control) this.toolStrip2);
      this.panel2.Location = new Point(14, 28);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(229, 309);
      this.panel2.TabIndex = 13;
      this.toolStrip2.Dock = DockStyle.Bottom;
      this.toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
      this.toolStrip2.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.toolButton_CreateMap,
        (ToolStripItem) this.toolButton_DeleteMap,
        (ToolStripItem) this.label_MapCount,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolButton_SortLVUp,
        (ToolStripItem) this.toolButton_SortLVDown
      });
      this.toolStrip2.Location = new Point(0, 280);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.Size = new Size(225, 25);
      this.toolStrip2.TabIndex = 1;
      this.toolStrip2.Text = "toolStrip2";
      this.toolButton_CreateMap.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_CreateMap.Enabled = false;
      this.toolButton_CreateMap.Image = (Image) componentResourceManager.GetObject("toolButton_CreateMap.Image");
      this.toolButton_CreateMap.ImageTransparentColor = Color.Magenta;
      this.toolButton_CreateMap.Name = "toolButton_CreateMap";
      this.toolButton_CreateMap.Size = new Size(23, 22);
      this.toolButton_CreateMap.Text = "toolStripButton7";
      this.toolButton_CreateMap.ToolTipText = "Create New Map";
      this.toolButton_CreateMap.Click += new EventHandler(this.toolButton_CreateMap_Click);
      this.toolButton_DeleteMap.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_DeleteMap.Enabled = false;
      this.toolButton_DeleteMap.Image = (Image) componentResourceManager.GetObject("toolButton_DeleteMap.Image");
      this.toolButton_DeleteMap.ImageTransparentColor = Color.Magenta;
      this.toolButton_DeleteMap.Name = "toolButton_DeleteMap";
      this.toolButton_DeleteMap.Size = new Size(23, 22);
      this.toolButton_DeleteMap.Text = "toolStripButton8";
      this.toolButton_DeleteMap.ToolTipText = "Remove Map";
      this.toolButton_DeleteMap.Click += new EventHandler(this.toolButton_DeleteMap_Click);
      this.label_MapCount.Alignment = ToolStripItemAlignment.Right;
      this.label_MapCount.Name = "label_MapCount";
      this.label_MapCount.Size = new Size(51, 22);
      this.label_MapCount.Text = "(00/99)";
      this.numericUpDown_ClearCount.Location = new Point(92, 6);
      this.numericUpDown_ClearCount.Maximum = new Decimal(new int[4]
      {
        16383,
        0,
        0,
        0
      });
      this.numericUpDown_ClearCount.Name = "numericUpDown_ClearCount";
      this.numericUpDown_ClearCount.Size = new Size(76, 20);
      this.numericUpDown_ClearCount.TabIndex = 16;
      this.numericUpDown_ClearCount.Value = new Decimal(new int[4]);
      this.numericUpDown_ClearCount.ValueChanged += new EventHandler(this.numericUpDown_ClearCount_ValueChanged);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(14, 7);
      this.label9.Name = "label9";
      this.label9.Size = new Size(72, 13);
      this.label9.TabIndex = 15;
      this.label9.Text = "Cleared Maps";
      this.groupBoxWithCheckBox_Narrowing.AllowEnabledWithCheckBoxState = true;
      this.groupBoxWithCheckBox_Narrowing.Checked = false;
      this.groupBoxWithCheckBox_Narrowing.Controls.Add((Control) this.comboBox_NarrowingName3);
      this.groupBoxWithCheckBox_Narrowing.Controls.Add((Control) this.comboBox_NarrowingName2);
      this.groupBoxWithCheckBox_Narrowing.Controls.Add((Control) this.comboBox_NarrowingName1);
      this.groupBoxWithCheckBox_Narrowing.Controls.Add((Control) this.CheckBox_NarrowingNormal);
      this.groupBoxWithCheckBox_Narrowing.Controls.Add((Control) this.CheckBox_NarrowingDevil);
      this.groupBoxWithCheckBox_Narrowing.Controls.Add((Control) this.checkBox_NarrowingLevel);
      this.groupBoxWithCheckBox_Narrowing.Controls.Add((Control) this.numericUpDown_NarrowingLevel);
      this.groupBoxWithCheckBox_Narrowing.Controls.Add((Control) this.comboBox_NarrowingLevel);
      this.groupBoxWithCheckBox_Narrowing.Location = new Point(16, 343);
      this.groupBoxWithCheckBox_Narrowing.Name = "groupBoxWithCheckBox_Narrowing";
      this.groupBoxWithCheckBox_Narrowing.Size = new Size(374, 58);
      this.groupBoxWithCheckBox_Narrowing.TabIndex = 17;
      this.groupBoxWithCheckBox_Narrowing.Text = "Filter";
      this.groupBoxWithCheckBox_Narrowing.CheckedChanged += new EventHandler(this.groupBoxWithCheckBox_Narrowing_CheckedChanged);
      this.comboBox_NarrowingName3.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_NarrowingName3.FormattingEnabled = true;
      this.comboBox_NarrowingName3.Location = new Point(132, 37);
      this.comboBox_NarrowingName3.Name = "comboBox_NarrowingName3";
      this.comboBox_NarrowingName3.Size = new Size(62, 21);
      this.comboBox_NarrowingName3.TabIndex = 8;
      this.comboBox_NarrowingName3.SelectedIndexChanged += new EventHandler(this.comboBox_NarrowingName3_SelectedIndexChanged);
      this.comboBox_NarrowingName2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_NarrowingName2.FormattingEnabled = true;
      this.comboBox_NarrowingName2.Location = new Point(200, 37);
      this.comboBox_NarrowingName2.Name = "comboBox_NarrowingName2";
      this.comboBox_NarrowingName2.Size = new Size(58, 21);
      this.comboBox_NarrowingName2.TabIndex = 9;
      this.comboBox_NarrowingName2.SelectedIndexChanged += new EventHandler(this.comboBox_NarrowingName2_SelectedIndexChanged);
      this.comboBox_NarrowingName1.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_NarrowingName1.FormattingEnabled = true;
      this.comboBox_NarrowingName1.Location = new Point(61, 37);
      this.comboBox_NarrowingName1.Name = "comboBox_NarrowingName1";
      this.comboBox_NarrowingName1.Size = new Size(65, 21);
      this.comboBox_NarrowingName1.TabIndex = 7;
      this.comboBox_NarrowingName1.SelectedIndexChanged += new EventHandler(this.comboBox_NarrowingName1_SelectedIndexChanged);
      this.CheckBox_NarrowingNormal.AutoSize = true;
      this.CheckBox_NarrowingNormal.Checked = true;
      this.CheckBox_NarrowingNormal.CheckState = CheckState.Checked;
      this.CheckBox_NarrowingNormal.Location = new Point(6, 39);
      this.CheckBox_NarrowingNormal.Name = "CheckBox_NarrowingNormal";
      this.CheckBox_NarrowingNormal.Size = new Size(59, 17);
      this.CheckBox_NarrowingNormal.TabIndex = 6;
      this.CheckBox_NarrowingNormal.Text = "Normal";
      this.CheckBox_NarrowingNormal.UseVisualStyleBackColor = true;
      this.CheckBox_NarrowingNormal.CheckedChanged += new EventHandler(this.CheckBox_NarrowingNormal_CheckedChanged);
      this.CheckBox_NarrowingDevil.AutoSize = true;
      this.CheckBox_NarrowingDevil.Checked = true;
      this.CheckBox_NarrowingDevil.CheckState = CheckState.Checked;
      this.CheckBox_NarrowingDevil.Location = new Point(274, 14);
      this.CheckBox_NarrowingDevil.Name = "CheckBox_NarrowingDevil";
      this.CheckBox_NarrowingDevil.Size = new Size(49, 17);
      this.CheckBox_NarrowingDevil.TabIndex = 5;
      this.CheckBox_NarrowingDevil.Text = "Legacy Boss";
      this.CheckBox_NarrowingDevil.UseVisualStyleBackColor = true;
      this.CheckBox_NarrowingDevil.CheckedChanged += new EventHandler(this.CheckBox_NarrowingDevil_CheckedChanged);
      this.checkBox_NarrowingLevel.AutoSize = true;
      this.checkBox_NarrowingLevel.Checked = true;
      this.checkBox_NarrowingLevel.CheckState = CheckState.Checked;
      this.checkBox_NarrowingLevel.Location = new Point(6, 16);
      this.checkBox_NarrowingLevel.Name = "checkBox_NarrowingLevel";
      this.checkBox_NarrowingLevel.Size = new Size(52, 17);
      this.checkBox_NarrowingLevel.TabIndex = 2;
      this.checkBox_NarrowingLevel.Text = "Level";
      this.checkBox_NarrowingLevel.UseVisualStyleBackColor = true;
      this.checkBox_NarrowingLevel.CheckedChanged += new EventHandler(this.checkBox_NarrowingLevel_CheckedChanged);
      this.numericUpDown_NarrowingLevel.Location = new Point(61, 15);
      this.numericUpDown_NarrowingLevel.Maximum = new Decimal(new int[4]
      {
        99,
        0,
        0,
        0
      });
      this.numericUpDown_NarrowingLevel.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_NarrowingLevel.Name = "numericUpDown_NarrowingLevel";
      this.numericUpDown_NarrowingLevel.Size = new Size(57, 20);
      this.numericUpDown_NarrowingLevel.TabIndex = 3;
      this.numericUpDown_NarrowingLevel.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDown_NarrowingLevel.ValueChanged += new EventHandler(this.numericUpDown_NarrowingLevel_ValueChanged);
      this.comboBox_NarrowingLevel.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBox_NarrowingLevel.FormattingEnabled = true;
      this.comboBox_NarrowingLevel.Items.AddRange(new object[2]
      {
        (object) "At least",
        (object) "Up to"
      });
      this.comboBox_NarrowingLevel.Location = new Point(123, 14);
      this.comboBox_NarrowingLevel.Name = "comboBox_NarrowingLevel";
      this.comboBox_NarrowingLevel.Size = new Size(67, 21);
      this.comboBox_NarrowingLevel.TabIndex = 4;
      this.comboBox_NarrowingLevel.SelectedIndexChanged += new EventHandler(this.comboBox_NarrowingLevel_SelectedIndexChanged);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.toolButton_SortLVUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_SortLVUp.Image = (Image) componentResourceManager.GetObject("toolButton_SortLVUp.Image");
      this.toolButton_SortLVUp.ImageTransparentColor = Color.Magenta;
      this.toolButton_SortLVUp.Name = "toolButton_SortLVUp";
      this.toolButton_SortLVUp.Size = new Size(23, 22);
      this.toolButton_SortLVUp.Text = "Sort Ascending by Level";
      this.toolButton_SortLVUp.Click += new EventHandler(this.toolButton_SortLVUp_Click);
      this.toolButton_SortLVDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_SortLVDown.Image = (Image) componentResourceManager.GetObject("toolButton_SortLVDown.Image");
      this.toolButton_SortLVDown.ImageTransparentColor = Color.Magenta;
      this.toolButton_SortLVDown.Name = "toolButton_SortLVDown";
      this.toolButton_SortLVDown.Size = new Size(23, 22);
      this.toolButton_SortLVDown.Text = "Sort Descending by Level";
      this.toolButton_SortLVDown.Click += new EventHandler(this.toolButton_SortLVDown_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.groupBoxWithCheckBox_Narrowing);
      this.Controls.Add((Control) this.numericUpDown_ClearCount);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.panel2);
      this.Controls.Add((Control) this.Panel_TreasureMapEditArea);
      this.Name = nameof (TreasureMapDataControl);
      this.Size = new Size(882, 511);
      this.GroupBox_MapType.ResumeLayout(false);
      this.GroupBox_MapType.PerformLayout();
      this.Panel_NormalMap.ResumeLayout(false);
      this.Panel_NormalMap.PerformLayout();
      this.numericUpDown_MapNo2.EndInit();
      this.numericUpDown_MapNo1.EndInit();
      this.GroupBox_Probability.ResumeLayout(false);
      this.GroupBox_Probability.PerformLayout();
      this.Panel_Devil.ResumeLayout(false);
      this.Panel_Devil.PerformLayout();
      this.numericUpDown_DevilVictoryTurn.EndInit();
      this.numericUpDown_DevilLevel.EndInit();
      this.Panel_TreasureMapEditArea.ResumeLayout(false);
      this.Panel_TreasureMapEditArea.PerformLayout();
      this.numericUpDown_Place.EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.numericUpDown_ClearCount.EndInit();
      this.groupBoxWithCheckBox_Narrowing.ResumeLayout(false);
      this.groupBoxWithCheckBox_Narrowing.PerformLayout();
      this.numericUpDown_NarrowingLevel.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private class TreasureMapListBoxItem
    {
      private string _name;
      private int _index;

      public TreasureMapListBoxItem(int index, string name)
      {
        this._index = index;
        this._name = name;
      }

      public int Index
      {
        get => this._index;
        set => this._index = value;
      }

      public override string ToString() => this._name;
    }
  }
}
