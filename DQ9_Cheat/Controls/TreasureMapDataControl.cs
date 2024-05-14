// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.TreasureMapDataControl
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DQ9_Cheat.Controls.VisionControls;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.GameData;
using JS_Framework.Controls;

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
      InitializeComponent();
      BeginUpdate();
      foreach (object obj in DevilList.List)
        comboBox_Devil.Items.Add(obj);
      Panel_Devil.Visible = false;
      _panelLocation = Panel_NormalMap.Location;
      textBox_DungeonDetail.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
      comboBox_NarrowingName1.Items.Add(string.Empty);
      foreach (object obj in TreasureMapDataTable.TreasureMapName1_Table)
        comboBox_NarrowingName1.Items.Add(obj);
      comboBox_NarrowingName1.SelectedIndex = 0;
      comboBox_NarrowingName2.Items.Add(string.Empty);
      foreach (object obj in TreasureMapDataTable.TreasureMapName2_Table)
        comboBox_NarrowingName2.Items.Add(obj);
      comboBox_NarrowingName2.SelectedIndex = 0;
      comboBox_NarrowingName3.Items.Add(string.Empty);
      foreach (object obj in TreasureMapDataTable.TreasureMapName3_Table)
        comboBox_NarrowingName3.Items.Add(obj);
      comboBox_NarrowingName3.SelectedIndex = 0;
      comboBox_NarrowingLevel.SelectedIndex = 0;
      EndUpdate();
    }

    protected override void OnValueUpdate()
    {
      BeginUpdate();
      numericUpDown_ClearCount.Value = SaveDataManager.Instance.SaveData.TreasureMapManager.ClearCount;
      RenewalListBox();
      RenewalToolButton();
      RenewalMapCountLabel();
      RenewalEditArea(true);
      EndUpdate();
    }

    private void RenewalListBox()
    {
      int selectedIndex = listBox_TreasureMap.SelectedIndex;
      listBox_TreasureMap.BeginUpdate();
      listBox_TreasureMap.Items.Clear();
      TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
      for (int index = 0; index < treasureMapManager.MapCount; ++index)
      {
        TreasureMapData mapData = treasureMapManager.GetMapData(index);
        AddListBox(index, mapData);
      }
      RenewalMapCountLabel();
      if (listBox_TreasureMap.Items.Count > selectedIndex)
        listBox_TreasureMap.SelectedIndex = selectedIndex;
      else
        listBox_TreasureMap.SelectedIndex = listBox_TreasureMap.Items.Count - 1;
      listBox_TreasureMap.EndUpdate();
    }

    private bool AddListBox(int index, TreasureMapData mapData)
    {
      if (groupBoxWithCheckBox_Narrowing.Checked && checkBox_NarrowingLevel.Checked)
      {
        int num = (int) numericUpDown_NarrowingLevel.Value;
        if (comboBox_NarrowingLevel.SelectedIndex == 0)
        {
          if (mapData.MapLevel < num)
            return false;
        }
        else if (comboBox_NarrowingLevel.SelectedIndex == 1 && mapData.MapLevel > num)
          return false;
      }
      string name;
      if (mapData.MapType == MapType.Normal)
      {
        if (groupBoxWithCheckBox_Narrowing.Checked && (!CheckBox_NarrowingNormal.Checked || !string.IsNullOrEmpty(comboBox_NarrowingName1.SelectedItem.ToString()) && comboBox_NarrowingName1.SelectedItem.ToString() != mapData.MapName1 || !string.IsNullOrEmpty(comboBox_NarrowingName2.SelectedItem.ToString()) && comboBox_NarrowingName2.SelectedItem.ToString() != mapData.MapName2 || !string.IsNullOrEmpty(comboBox_NarrowingName3.SelectedItem.ToString()) && comboBox_NarrowingName3.SelectedItem.ToString() != mapData.MapName3))
          return false;
        name = !mapData.IsValid ? string.Format("!{0}", mapData.MapName) : mapData.MapName;
      }
      else if (mapData.MapType == MapType.devil)
      {
        if (groupBoxWithCheckBox_Narrowing.Checked && !CheckBox_NarrowingDevil.Checked)
          return false;
        name = mapData.DevilType == null ? "Devil" : string.Format("{0}'s Map Lv. {1}", mapData.DevilType.Name, mapData.DevilLevel.Value);
      }
      else
        name = "Unknown";
      TreasureMapListBoxItem treasureMapListBoxItem1 = new TreasureMapListBoxItem(index, name);
      if (toolButton_SortLVUp.Checked || toolButton_SortLVDown.Checked)
      {
        TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
        for (int index1 = 0; index1 < listBox_TreasureMap.Items.Count; ++index1)
        {
          if (listBox_TreasureMap.Items[index1] is TreasureMapListBoxItem treasureMapListBoxItem2)
          {
            TreasureMapData mapData1 = treasureMapManager.GetMapData(treasureMapListBoxItem2.Index);
            TreasureMapData mapData2 = treasureMapManager.GetMapData(index);
            if (toolButton_SortLVUp.Checked)
            {
              if (mapData1.MapType == MapType.devil && mapData2.MapType == MapType.Normal && mapData1.MapLevel >= mapData2.MapLevel)
              {
                listBox_TreasureMap.Items.Insert(index1, treasureMapListBoxItem1);
                return true;
              }
              if (mapData1.MapLevel > mapData2.MapLevel)
              {
                listBox_TreasureMap.Items.Insert(index1, treasureMapListBoxItem1);
                return true;
              }
            }
            else
            {
              if (mapData1.MapType == MapType.devil && mapData2.MapType == MapType.Normal && mapData1.MapLevel <= mapData2.MapLevel)
              {
                listBox_TreasureMap.Items.Insert(index1, treasureMapListBoxItem1);
                return true;
              }
              if (mapData1.MapLevel < mapData2.MapLevel)
              {
                listBox_TreasureMap.Items.Insert(index1, treasureMapListBoxItem1);
                return true;
              }
            }
          }
        }
      }
      listBox_TreasureMap.Items.Add(treasureMapListBoxItem1);
      return true;
    }

    private void RenewalMapCountLabel()
    {
      int mapCount = SaveDataManager.Instance.SaveData.TreasureMapManager.MapCount;
      if (groupBoxWithCheckBox_Narrowing.Checked)
        label_MapCount.Text = string.Format("({0:D2}/{1:D2})", listBox_TreasureMap.Items.Count, mapCount);
      else
        label_MapCount.Text = string.Format("({0:D2}/{1:D2})", mapCount, 99);
    }

    private void RenewalToolButton()
    {
      toolButton_DeleteMap.Enabled = listBox_TreasureMap.SelectedIndex != -1;
      toolButton_CreateMap.Enabled = SaveDataManager.Instance.SaveData.TreasureMapManager.MapCount < 99;
    }

    private void RenewalPlaceName()
    {
      if (_selectedMapData == null)
        return;
      if (_selectedMapData.Place.Value >= 1 && _selectedMapData.Place.Value <= 150)
      {
        int index = TreasureMapDataTable.TreasureMapPlace_Table[_selectedMapData.Place.Value];
        label_PlaceName.Text = TreasureMapDataTable.TreasureMapPlaceName_Table[index];
      }
      else
        label_PlaceName.Text = string.Empty;
    }

    private void RenewalCandidatePlace()
    {
      if (_selectedMapData != null)
      {
        if (_selectedMapData.MapType == MapType.Normal)
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append("Valid: ");
          ReadOnlyCollection<byte> validPlaceList = _selectedMapData.ValidPlaceList;
          if (validPlaceList.Count > 0)
          {
            bool flag = true;
            foreach (byte num in validPlaceList)
            {
              if (!flag)
                stringBuilder.Append(", ");
              if (checkBox_PlaceHex.Checked)
                stringBuilder.AppendFormat("{0:X02}", num);
              else
                stringBuilder.AppendFormat("{0:D}", num);
              flag = false;
            }
          }
          else
            stringBuilder.Append("None");
          labelCandidatePlace.Text = stringBuilder.ToString();
        }
        else
          labelCandidatePlace.Text = string.Empty;
      }
      else
        labelCandidatePlace.Text = string.Empty;
    }

    private void RenewalEditArea(bool floorDetail)
    {
      BeginUpdate();
      if (listBox_TreasureMap.SelectedIndex == -1)
      {
        Panel_TreasureMapEditArea.Enabled = false;
        textBox_Detector.Text = string.Empty;
        textBox_Renewer.Text = string.Empty;
        label_PlaceName.Text = string.Empty;
        labelCandidatePlace.Text = string.Empty;
        RenewalDungeonDetail(null);
      }
      else if (_selectedMapData != null)
      {
        Panel_TreasureMapEditArea.Enabled = true;
        RenewalPlaceName();
        RenewalCandidatePlace();
        SetVisibleControl(_selectedMapData.MapType);
        textBox_Detector.Text = _selectedMapData.Detector.Value;
        textBox_Renewer.Text = _selectedMapData.Renewer.Value;
        numericUpDown_Place.Value = _selectedMapData.Place.Value;
        checkBox_OpenProbability1.Checked = _selectedMapData.IsOpenProbability(0);
        checkBox_OpenProbability2.Checked = _selectedMapData.IsOpenProbability(1);
        checkBox_OpenProbability3.Checked = _selectedMapData.IsOpenProbability(2);
        switch (_selectedMapData.MapType)
        {
          case MapType.Normal:
            if (floorDetail)
              _selectedMapData.CalculateDetail(true);
            radioButton_NormalMap.Checked = true;
            numericUpDown_MapNo1.Value = _selectedMapData.Rank;
            numericUpDown_MapNo2.Value = _selectedMapData.Seed;
            if (_selectedMapData.IsValidSeed)
              numericUpDown_MapNo2.ForeColor = Color.Black;
            else
              numericUpDown_MapNo2.ForeColor = Color.Red;
            if (_selectedMapData.IsValidRank)
              numericUpDown_MapNo1.ForeColor = Color.Black;
            else
              numericUpDown_MapNo1.ForeColor = Color.Red;
            if (_selectedMapData.IsValidPlace)
            {
              numericUpDown_Place.ForeColor = Color.Black;
              break;
            }
            numericUpDown_Place.ForeColor = Color.Red;
            break;
          case MapType.devil:
            radioButton_DevilMap.Checked = true;
            comboBox_Devil.SelectedItem = _selectedMapData.DevilType;
            numericUpDown_DevilLevel.Value = _selectedMapData.DevilLevel.Value;
            numericUpDown_DevilVictoryTurn.Value = _selectedMapData.DevilVictoryTurn;
            numericUpDown_MapNo2.ForeColor = Color.Black;
            break;
        }
        if (_selectedMapData.MapState == MapState.NotDiscover)
          comboBox_State.SelectedIndex = 0;
        else if (_selectedMapData.MapState == MapState.Discover)
          comboBox_State.SelectedIndex = 1;
        else if (_selectedMapData.MapState == MapState.Clear)
          comboBox_State.SelectedIndex = 2;
        else
          comboBox_State.SelectedIndex = -1;
        RenewalDungeonDetail(_selectedMapData);
      }
      Panel_NormalMap.Invalidate();
      EndUpdate();
    }

    private void RenewalDungeonDetail(TreasureMapData mapData)
    {
      if (mapData != null && mapData.MapType == MapType.Normal && mapData.Rank >= 2 && mapData.Rank <= 248)
      {
        richTextBox_dummy.Visible = true;
        textBox_DungeonDetail.Text = string.Empty;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("Rank: {0:X2}, Seed: {1:X4}\n", mapData.Rank, mapData.Seed);
        stringBuilder.AppendFormat("{0}\n", mapData.MapName);
        stringBuilder.AppendFormat("Type: {0}\n", mapData.MapTypeName);
        stringBuilder.AppendFormat("Floors: {0}\n", mapData.FloorCount);
        stringBuilder.AppendFormat("Monster rank: {0}\n", mapData.MonsterRank);
        stringBuilder.AppendFormat("Boss: {0}\n", mapData.BossName);
        int treasureBoxCount = mapData.GetTreasureBoxCount(0);
        stringBuilder.AppendFormat("Number of chests: {0}\n", treasureBoxCount);
        if (treasureBoxCount > 0)
        {
          stringBuilder.Append(" By rank:\n  ");
          for (int rank = 10; rank > 0; --rank)
            stringBuilder.AppendFormat(" {0}:{1}", _treasureBoxRankSymbol[0, rank - 1], mapData.GetTreasureBoxCount(rank));
          stringBuilder.Append("\n");
          stringBuilder.Append(" By floor:\n");
          for (int floor = 0; floor < mapData.FloorCount; ++floor)
          {
            if (mapData.GetTreasureBoxCountPerFloor(floor) > 0)
            {
              stringBuilder.AppendFormat("   B{0:D2}:", floor + 1);
              foreach (TreasureBoxInfo treasureBoxInfo in mapData.TreasureBoxInfoList[floor])
                stringBuilder.AppendFormat(" {0}", _treasureBoxRankSymbol[0, treasureBoxInfo.Rank - 1]);
              stringBuilder.Append("\n");
            }
          }
        }
        for (int floor = 0; floor < mapData.FloorCount; ++floor)
        {
          _treasureBoxCount[floor] = 0;
          byte[,] floorMap = mapData.GetFloorMap(floor);
          if (floorMap != null)
          {
            stringBuilder.Append("\n");
            stringBuilder.AppendFormat("B{0:D2}\n", floor + 1);
            for (int y = 0; y < mapData.GetFloorHeight(floor); ++y)
            {
              for (int x = 0; x < mapData.GetFloorWidth(floor); ++x)
              {
                if (floorMap[y, x] == 1 || floorMap[y, x] == 3)
                  stringBuilder.Append("■");
                else if (floorMap[y, x] == 4)
                {
                  if (mapData.IsUpStep(floor, x, y))
                    stringBuilder.Append("△");
                  else
                    stringBuilder.Append("　");
                }
                else if (floorMap[y, x] == 5)
                  stringBuilder.Append("▽");
                else if (floorMap[y, x] == 6)
                {
                  int num = mapData.IsTreasureBoxRank(floor, x, y);
                  if (num > 0)
                  {
                    int treasureBoxIndex = mapData.GetTreasureBoxIndex(floor, x, y);
                    _treasureBoxIndexes[floor, treasureBoxIndex] = stringBuilder.Length;
                    stringBuilder.AppendFormat("{0}", _treasureBoxRankSymbol[1, num - 1]);
                    ++_treasureBoxCount[floor];
                  }
                  else
                    stringBuilder.Append("　");
                }
                else
                  stringBuilder.Append("　");
              }
              stringBuilder.Append("\n");
            }
            for (int index1 = 0; index1 < _treasureBoxCount[floor]; ++index1)
            {
              int rank = mapData.TreasureBoxInfoList[floor][index1].Rank;
              int index2 = mapData.TreasureBoxInfoList[floor][index1].Index;
              string treasureBoxItem = mapData.GetTreasureBoxItem(floor, index2, 2);
              stringBuilder.AppendFormat("({0:D2}, {1:D2}) {2} {3}\n", mapData.TreasureBoxInfoList[floor][index1].X, mapData.TreasureBoxInfoList[floor][index1].Y, _treasureBoxRankSymbol[1, rank - 1], treasureBoxItem);
            }
          }
        }
        textBox_DungeonDetail.Text = stringBuilder.ToString();
        using (Font font = new Font("MS Gothic", 9f, FontStyle.Underline, GraphicsUnit.Point, 128))
        {
          for (int index3 = 0; index3 < mapData.FloorCount; ++index3)
          {
            for (int index4 = 0; index4 < _treasureBoxCount[index3]; ++index4)
            {
              textBox_DungeonDetail.SelectionStart = _treasureBoxIndexes[index3, index4];
              textBox_DungeonDetail.SelectionLength = 1;
              textBox_DungeonDetail.SelectionFont = font;
              textBox_DungeonDetail.SelectionColor = Color.Blue;
            }
          }
        }
        textBox_DungeonDetail.SelectionStart = 0;
        textBox_DungeonDetail.SelectionLength = 0;
        textBox_DungeonDetail.ScrollToCaret();
        label_DungeonDetail.Enabled = true;
        textBox_DungeonDetail.Enabled = true;
        richTextBox_dummy.Visible = false;
      }
      else
      {
        label_DungeonDetail.Enabled = false;
        textBox_DungeonDetail.Enabled = false;
        textBox_DungeonDetail.Text = string.Empty;
      }
    }

    private void listBox_TreasureMap_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_updateCount == 0 && listBox_TreasureMap.SelectedIndex != -1)
      {
        TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
        if (listBox_TreasureMap.SelectedItem is TreasureMapListBoxItem selectedItem)
        {
          _selectedMapData = treasureMapManager.GetMapData(selectedItem.Index);
          RenewalEditArea(true);
        }
      }
      RenewalToolButton();
    }

    private void SetVisibleControl(MapType mapType)
    {
      if (mapType == MapType.Normal)
      {
        Panel_Devil.Visible = false;
        Panel_NormalMap.Visible = true;
        Panel_NormalMap.Location = _panelLocation;
      }
      else
      {
        if (mapType != MapType.devil)
          return;
        Panel_Devil.Visible = true;
        Panel_NormalMap.Visible = false;
        Panel_Devil.Location = _panelLocation;
      }
    }

    private void toolButton_CreateMap_Click(object sender, EventArgs e)
    {
      TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
      if (!treasureMapManager.CreateMapData())
        return;
      BeginUpdate();
      groupBoxWithCheckBox_Narrowing.Checked = false;
      EndUpdate();
      listBox_TreasureMap.BeginUpdate();
      TreasureMapData mapData = treasureMapManager.GetMapData(treasureMapManager.MapCount - 1);
      RenewalListBox();
      listBox_TreasureMap.SelectedIndex = treasureMapManager.MapCount - 1;
      _selectedMapData = mapData;
      RenewalEditArea(true);
      listBox_TreasureMap.EndUpdate();
    }

    private void toolButton_DeleteMap_Click(object sender, EventArgs e)
    {
      if (listBox_TreasureMap.SelectedIndex == -1 || !(listBox_TreasureMap.SelectedItem is TreasureMapListBoxItem selectedItem1))
        return;
      SaveDataManager.Instance.SaveData.TreasureMapManager.DeleteMapData(selectedItem1.Index);
      int selectedIndex = listBox_TreasureMap.SelectedIndex;
      listBox_TreasureMap.Items.RemoveAt(selectedIndex);
      RenewalListBox();
      if (listBox_TreasureMap.Items.Count > selectedIndex)
      {
        listBox_TreasureMap.SelectedIndex = selectedIndex;
        TreasureMapManager treasureMapManager = SaveDataManager.Instance.SaveData.TreasureMapManager;
        _selectedMapData = !(listBox_TreasureMap.SelectedItem is TreasureMapListBoxItem selectedItem2) ? null : treasureMapManager.GetMapData(selectedItem2.Index);
      }
      else
      {
        listBox_TreasureMap.SelectedIndex = selectedIndex - 1;
        _selectedMapData = null;
      }
      RenewalMapCountLabel();
      RenewalEditArea(true);
    }

    private void radioButton_MapType_CheckedChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is RadioButton radioButton))
        return;
      MapType tag = (MapType) radioButton.Tag;
      if (_selectedMapData == null)
        return;
      SaveDataManager.Instance.UndoRedoMgr.BeginPluralEdit();
      _selectedMapData.MapType = tag;
      _selectedMapData.Rank = tag != MapType.Normal ? (byte) 1 : (byte) 2;
      SaveDataManager.Instance.UndoRedoMgr.EndPluralEdit();
      RenewalListBox();
      RenewalEditArea(true);
    }

    private void textBox_Detector_TextChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || _selectedMapData == null)
        return;
      _selectedMapData.Detector.Value = textBox_Detector.Text;
      textBox_Detector.Text = _selectedMapData.Detector.Value;
    }

    private void textBox_Renewer_TextChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || _selectedMapData == null)
        return;
      _selectedMapData.Renewer.Value = textBox_Renewer.Text;
      textBox_Renewer.Text = _selectedMapData.Renewer.Value;
    }

    private void numericUpDown_Place_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || _selectedMapData == null)
        return;
      _selectedMapData.Place.Value = (byte) numericUpDown_Place.Value;
      RenewalListBox();
      RenewalPlaceName();
      if (_selectedMapData.MapType == MapType.devil || _selectedMapData.IsValidPlace)
        numericUpDown_Place.ForeColor = Color.Black;
      else
        numericUpDown_Place.ForeColor = Color.Red;
    }

    private void comboBox_State_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || comboBox_State.SelectedIndex == -1 || _selectedMapData == null)
        return;
      _selectedMapData.MapState = (MapState) (1 << comboBox_State.SelectedIndex);
    }

    private void checkBox_OpenProbability_CheckedChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || !(sender is CheckBox checkBox) || _selectedMapData == null)
        return;
      _selectedMapData.SetOpenProbability((int) checkBox.Tag, checkBox.Checked);
    }

    private void comboBox_Devil_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || comboBox_Devil.SelectedIndex == -1 || !(comboBox_Devil.SelectedItem is Devil selectedItem) || _selectedMapData == null)
        return;
      _selectedMapData.DevilType = selectedItem;
      RenewalListBox();
    }

    private void numericUpDown_DevilLevel_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || _selectedMapData == null)
        return;
      _selectedMapData.DevilLevel.Value = (byte) numericUpDown_DevilLevel.Value;
      RenewalListBox();
    }

    private void numericUpDown_DevilVictoryTurn_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || _selectedMapData == null)
        return;
      _selectedMapData.DevilVictoryTurn = (ushort) numericUpDown_DevilVictoryTurn.Value;
    }

    private void numericUpDown_MapNo1_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || _selectedMapData == null)
        return;
      _selectedMapData.Rank = (byte) numericUpDown_MapNo1.Value;
      _selectedMapData.CalculateDetail(true);
      RenewalListBox();
      RenewalEditArea(true);
      if (_selectedMapData.IsValidRank)
        numericUpDown_MapNo1.ForeColor = Color.Black;
      else
        numericUpDown_MapNo1.ForeColor = Color.Red;
    }

    private void numericUpDown_MapNo2_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0 || _selectedMapData == null)
        return;
      _selectedMapData.Seed = (ushort) numericUpDown_MapNo2.Value;
      _selectedMapData.CalculateDetail(true);
      RenewalListBox();
      RenewalEditArea(true);
      if (_selectedMapData.IsValidSeed)
        numericUpDown_MapNo2.ForeColor = Color.Black;
      else
        numericUpDown_MapNo2.ForeColor = Color.Red;
    }

    private void numericUpDown_ClearCount_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      SaveDataManager.Instance.SaveData.TreasureMapManager.ClearCount = (ushort) numericUpDown_ClearCount.Value;
    }

    private void Panel_NormalMap_Paint(object sender, PaintEventArgs e)
    {
      if (listBox_TreasureMap.SelectedIndex == -1)
        return;
      e.Graphics.ScaleTransform(AutoScaleFactor.Width, AutoScaleFactor.Height);
      if (_selectedMapData == null || _selectedMapData.MapType != MapType.Normal)
        return;
      using (Brush brush = new SolidBrush(SystemColors.ControlText))
        e.Graphics.DrawString(_selectedMapData.MapName, Font, brush, new PointF(6f, 35f));
    }

    private void checkBox_Hex_CheckedChanged(object sender, EventArgs e)
    {
      numericUpDown_MapNo1.Hexadecimal = checkBox_Hex.Checked;
      numericUpDown_MapNo2.Hexadecimal = checkBox_Hex.Checked;
    }

    private void checkBox_PlaceHex_CheckedChanged(object sender, EventArgs e)
    {
      numericUpDown_Place.Hexadecimal = checkBox_PlaceHex.Checked;
      RenewalCandidatePlace();
    }

    private void textBox_DungeonDetail_MouseMove(object sender, MouseEventArgs e)
    {
      if (_selectedMapData == null || _selectedMapData.MapType != MapType.Normal)
        return;
      int indexFromPosition = textBox_DungeonDetail.GetCharIndexFromPosition(new Point(e.X - 5, e.Y));
      for (int index1 = 0; index1 < _selectedMapData.FloorCount; ++index1)
      {
        for (int index2 = 0; index2 < _treasureBoxCount[index1]; ++index2)
        {
          if (_treasureBoxIndexes[index1, index2] == indexFromPosition)
          {
            textBox_DungeonDetail.Cursor = Cursors.Arrow;
            return;
          }
        }
      }
      textBox_DungeonDetail.Cursor = Cursors.IBeam;
    }

    private void textBox_DungeonDetail_MouseDown(object sender, MouseEventArgs e)
    {
      if (_selectedMapData == null || _selectedMapData.MapType != MapType.Normal)
        return;
      int indexFromPosition = textBox_DungeonDetail.GetCharIndexFromPosition(new Point(e.X - 5, e.Y));
      for (int floor = 0; floor < _selectedMapData.FloorCount; ++floor)
      {
        for (int boxIndex = 0; boxIndex < _treasureBoxCount[floor]; ++boxIndex)
        {
          if (_treasureBoxIndexes[floor, boxIndex] == indexFromPosition)
          {
            textBox_DungeonDetail.Cursor = Cursors.Arrow;
            using (TreasureBoxItemTableList boxItemTableList = new TreasureBoxItemTableList(_selectedMapData, floor, boxIndex))
            {
              foreach (TreasureBoxInfo treasureBoxInfo in _selectedMapData.TreasureBoxInfoList[floor])
              {
                if (treasureBoxInfo.Index == boxIndex)
                  boxItemTableList.Text = string.Format("Item Table B{0} ({1}, {2}) {3}", floor + 1, treasureBoxInfo.X, treasureBoxInfo.Y, _treasureBoxRankSymbol[0, treasureBoxInfo.Rank - 1]);
              }
              int num = (int) boxItemTableList.ShowDialog();
              return;
            }
          }
        }
      }
      textBox_DungeonDetail.Cursor = Cursors.IBeam;
    }

    private void checkBox_NarrowingLevel_CheckedChanged(object sender, EventArgs e)
    {
      numericUpDown_NarrowingLevel.Enabled = checkBox_NarrowingLevel.Checked;
      comboBox_NarrowingLevel.Enabled = checkBox_NarrowingLevel.Checked;
      if (_updateCount != 0)
        return;
      RenewalListBox();
    }

    private void CheckBox_NarrowingDevil_CheckedChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      RenewalListBox();
    }

    private void CheckBox_NarrowingNormal_CheckedChanged(object sender, EventArgs e)
    {
      comboBox_NarrowingName1.Enabled = CheckBox_NarrowingNormal.Checked;
      comboBox_NarrowingName2.Enabled = CheckBox_NarrowingNormal.Checked;
      comboBox_NarrowingName3.Enabled = CheckBox_NarrowingNormal.Checked;
      if (_updateCount != 0)
        return;
      RenewalListBox();
    }

    private void comboBox_NarrowingName1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      RenewalListBox();
    }

    private void comboBox_NarrowingName2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      RenewalListBox();
    }

    private void comboBox_NarrowingName3_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      RenewalListBox();
    }

    private void numericUpDown_NarrowingLevel_ValueChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      RenewalListBox();
    }

    private void comboBox_NarrowingLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      RenewalListBox();
    }

    private void groupBoxWithCheckBox_Narrowing_CheckedChanged(object sender, EventArgs e)
    {
      if (_updateCount != 0)
        return;
      RenewalListBox();
    }

    private void toolButton_SortLVUp_Click(object sender, EventArgs e)
    {
      toolButton_SortLVUp.Checked = !toolButton_SortLVUp.Checked;
      toolButton_SortLVDown.Checked = false;
      listBox_TreasureMap.SelectedIndex = -1;
      _selectedMapData = null;
      RenewalListBox();
    }

    private void toolButton_SortLVDown_Click(object sender, EventArgs e)
    {
      toolButton_SortLVDown.Checked = !toolButton_SortLVDown.Checked;
      toolButton_SortLVUp.Checked = false;
      listBox_TreasureMap.SelectedIndex = -1;
      _selectedMapData = null;
      RenewalListBox();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
        components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (TreasureMapDataControl));
      listBox_TreasureMap = new ListBox();
      radioButton_NormalMap = new RadioButton();
      radioButton_DevilMap = new RadioButton();
      GroupBox_MapType = new JS_GroupBox();
      label1 = new Label();
      textBox_Detector = new TextBox();
      textBox_Renewer = new TextBox();
      label2 = new Label();
      Panel_NormalMap = new JS_Panel();
      checkBox_Hex = new CheckBox();
      numericUpDown_MapNo2 = new SafeNumericUpDown();
      numericUpDown_MapNo1 = new SafeNumericUpDown();
      label3 = new Label();
      GroupBox_Probability = new JS_GroupBox();
      checkBox_OpenProbability3 = new CheckBox();
      checkBox_OpenProbability2 = new CheckBox();
      checkBox_OpenProbability1 = new CheckBox();
      Panel_Devil = new JS_Panel();
      numericUpDown_DevilVictoryTurn = new SafeNumericUpDown();
      label6 = new Label();
      numericUpDown_DevilLevel = new SafeNumericUpDown();
      label5 = new Label();
      label4 = new Label();
      comboBox_Devil = new ComboBox();
      Panel_TreasureMapEditArea = new JS_Panel();
      labelCandidatePlace = new Label();
      label_PlaceName = new Label();
      checkBox_PlaceHex = new CheckBox();
      richTextBox_dummy = new RichTextBox();
      textBox_DungeonDetail = new RichTextBox();
      label_DungeonDetail = new Label();
      numericUpDown_Place = new SafeNumericUpDown();
      label8 = new Label();
      comboBox_State = new ComboBox();
      label7 = new Label();
      panel2 = new Panel();
      toolStrip2 = new ToolStrip();
      toolButton_CreateMap = new ToolStripButton();
      toolButton_DeleteMap = new ToolStripButton();
      label_MapCount = new ToolStripLabel();
      numericUpDown_ClearCount = new SafeNumericUpDown();
      label9 = new Label();
      groupBoxWithCheckBox_Narrowing = new GroupBoxWithCheckBox();
      comboBox_NarrowingName3 = new ComboBox();
      comboBox_NarrowingName2 = new ComboBox();
      comboBox_NarrowingName1 = new ComboBox();
      CheckBox_NarrowingNormal = new CheckBox();
      CheckBox_NarrowingDevil = new CheckBox();
      checkBox_NarrowingLevel = new CheckBox();
      numericUpDown_NarrowingLevel = new NumericUpDown();
      comboBox_NarrowingLevel = new ComboBox();
      toolStripSeparator1 = new ToolStripSeparator();
      toolButton_SortLVUp = new ToolStripButton();
      toolButton_SortLVDown = new ToolStripButton();
      GroupBox_MapType.SuspendLayout();
      Panel_NormalMap.SuspendLayout();
      numericUpDown_MapNo2.BeginInit();
      numericUpDown_MapNo1.BeginInit();
      GroupBox_Probability.SuspendLayout();
      Panel_Devil.SuspendLayout();
      numericUpDown_DevilVictoryTurn.BeginInit();
      numericUpDown_DevilLevel.BeginInit();
      Panel_TreasureMapEditArea.SuspendLayout();
      numericUpDown_Place.BeginInit();
      panel2.SuspendLayout();
      toolStrip2.SuspendLayout();
      numericUpDown_ClearCount.BeginInit();
      groupBoxWithCheckBox_Narrowing.SuspendLayout();
      numericUpDown_NarrowingLevel.BeginInit();
      SuspendLayout();
      listBox_TreasureMap.Dock = DockStyle.Fill;
      listBox_TreasureMap.FormattingEnabled = true;
      listBox_TreasureMap.ItemHeight = 12;
      listBox_TreasureMap.Location = new Point(0, 0);
      listBox_TreasureMap.Name = "listBox_TreasureMap";
      listBox_TreasureMap.Size = new Size(225, 280);
      listBox_TreasureMap.TabIndex = 0;
      listBox_TreasureMap.SelectedIndexChanged += listBox_TreasureMap_SelectedIndexChanged;
      radioButton_NormalMap.AutoSize = true;
      radioButton_NormalMap.Location = new Point(12, 22);
      radioButton_NormalMap.Name = "radioButton_NormalMap";
      radioButton_NormalMap.Size = new Size(58, 17);
      radioButton_NormalMap.TabIndex = 2;
      radioButton_NormalMap.TabStop = true;
      radioButton_NormalMap.Tag = MapType.Normal;
      radioButton_NormalMap.Text = "Normal";
      radioButton_NormalMap.UseVisualStyleBackColor = true;
      radioButton_NormalMap.CheckedChanged += radioButton_MapType_CheckedChanged;
      radioButton_DevilMap.AutoSize = true;
      radioButton_DevilMap.Location = new Point(77, 22);
      radioButton_DevilMap.Name = "radioButton_DevilMap";
      radioButton_DevilMap.Size = new Size(86, 17);
      radioButton_DevilMap.TabIndex = 3;
      radioButton_DevilMap.TabStop = true;
      radioButton_DevilMap.Tag = MapType.devil;
      radioButton_DevilMap.Text = "Legacy Boss";
      radioButton_DevilMap.UseVisualStyleBackColor = true;
      radioButton_DevilMap.CheckedChanged += radioButton_MapType_CheckedChanged;
      GroupBox_MapType.Controls.Add(radioButton_DevilMap);
      GroupBox_MapType.Controls.Add(radioButton_NormalMap);
      GroupBox_MapType.Location = new Point(3, 3);
      GroupBox_MapType.Name = "GroupBox_MapType";
      GroupBox_MapType.Size = new Size(202, 51);
      GroupBox_MapType.TabIndex = 4;
      GroupBox_MapType.TabStop = false;
      GroupBox_MapType.Text = "Map Type";
      label1.AutoSize = true;
      label1.Location = new Point(36, 64);
      label1.Name = "label1";
      label1.Size = new Size(75, 13);
      label1.TabIndex = 5;
      label1.Text = "Discovered by";
      textBox_Detector.Location = new Point(111, 61);
      textBox_Detector.Name = "textBox_Detector";
      textBox_Detector.Size = new Size(87, 20);
      textBox_Detector.TabIndex = 6;
      textBox_Detector.TextChanged += textBox_Detector_TextChanged;
      textBox_Renewer.Location = new Point(111, 85);
      textBox_Renewer.Name = "textBox_Renewer";
      textBox_Renewer.Size = new Size(87, 20);
      textBox_Renewer.TabIndex = 8;
      textBox_Renewer.TextChanged += textBox_Renewer_TextChanged;
      label2.AutoSize = true;
      label2.Location = new Point(38, 88);
      label2.Name = "label2";
      label2.Size = new Size(73, 13);
      label2.TabIndex = 7;
      label2.Text = "Conquered by";
      Panel_NormalMap.Controls.Add(checkBox_Hex);
      Panel_NormalMap.Controls.Add(numericUpDown_MapNo2);
      Panel_NormalMap.Controls.Add(numericUpDown_MapNo1);
      Panel_NormalMap.Controls.Add(label3);
      Panel_NormalMap.Location = new Point(0, 219);
      Panel_NormalMap.Name = "Panel_NormalMap";
      Panel_NormalMap.Size = new Size(273, 82);
      Panel_NormalMap.TabIndex = 9;
      Panel_NormalMap.Paint += Panel_NormalMap_Paint;
      checkBox_Hex.AutoSize = true;
      checkBox_Hex.Location = new Point(191, 12);
      checkBox_Hex.Name = "checkBox_Hex";
      checkBox_Hex.Size = new Size(45, 17);
      checkBox_Hex.TabIndex = 3;
      checkBox_Hex.Text = "Hex";
      checkBox_Hex.UseVisualStyleBackColor = true;
      checkBox_Hex.CheckedChanged += checkBox_Hex_CheckedChanged;
      numericUpDown_MapNo2.Location = new Point(111, 10);
      numericUpDown_MapNo2.Maximum = new Decimal(new int[4]
      {
        ushort.MaxValue,
        0,
        0,
        0
      });
      numericUpDown_MapNo2.Name = "numericUpDown_MapNo2";
      numericUpDown_MapNo2.Size = new Size(74, 20);
      numericUpDown_MapNo2.TabIndex = 2;
      numericUpDown_MapNo2.Value = new Decimal(new int[4]);
      numericUpDown_MapNo2.ValueChanged += numericUpDown_MapNo2_ValueChanged;
      numericUpDown_MapNo1.Location = new Point(54, 10);
      numericUpDown_MapNo1.Maximum = new Decimal(new int[4]
      {
        byte.MaxValue,
        0,
        0,
        0
      });
      numericUpDown_MapNo1.Name = "numericUpDown_MapNo1";
      numericUpDown_MapNo1.Size = new Size(51, 20);
      numericUpDown_MapNo1.TabIndex = 1;
      numericUpDown_MapNo1.Value = new Decimal(new int[4]);
      numericUpDown_MapNo1.ValueChanged += numericUpDown_MapNo1_ValueChanged;
      label3.AutoSize = true;
      label3.Location = new Point(6, 12);
      label3.Name = "label3";
      label3.Size = new Size(45, 13);
      label3.TabIndex = 0;
      label3.Text = "Map No.";
      GroupBox_Probability.Controls.Add(checkBox_OpenProbability3);
      GroupBox_Probability.Controls.Add(checkBox_OpenProbability2);
      GroupBox_Probability.Controls.Add(checkBox_OpenProbability1);
      GroupBox_Probability.Location = new Point(0, 186);
      GroupBox_Probability.Name = "GroupBox_Probability";
      GroupBox_Probability.Size = new Size(204, 37);
      GroupBox_Probability.TabIndex = 10;
      GroupBox_Probability.TabStop = false;
      GroupBox_Probability.Text = "Treasures Plundered";
      checkBox_OpenProbability3.AutoSize = true;
      checkBox_OpenProbability3.Location = new Point(147, 15);
      checkBox_OpenProbability3.Name = "checkBox_OpenProbability3";
      checkBox_OpenProbability3.Size = new Size(50, 17);
      checkBox_OpenProbability3.TabIndex = 2;
      checkBox_OpenProbability3.Tag = 2;
      checkBox_OpenProbability3.Text = "Third";
      checkBox_OpenProbability3.UseVisualStyleBackColor = true;
      checkBox_OpenProbability3.CheckedChanged += checkBox_OpenProbability_CheckedChanged;
      checkBox_OpenProbability2.AutoSize = true;
      checkBox_OpenProbability2.Location = new Point(78, 15);
      checkBox_OpenProbability2.Name = "checkBox_OpenProbability2";
      checkBox_OpenProbability2.Size = new Size(63, 17);
      checkBox_OpenProbability2.TabIndex = 1;
      checkBox_OpenProbability2.Tag = 1;
      checkBox_OpenProbability2.Text = "Second";
      checkBox_OpenProbability2.UseVisualStyleBackColor = true;
      checkBox_OpenProbability2.CheckedChanged += checkBox_OpenProbability_CheckedChanged;
      checkBox_OpenProbability1.AutoSize = true;
      checkBox_OpenProbability1.Location = new Point(22, 15);
      checkBox_OpenProbability1.Name = "checkBox_OpenProbability1";
      checkBox_OpenProbability1.Size = new Size(45, 17);
      checkBox_OpenProbability1.TabIndex = 0;
      checkBox_OpenProbability1.Tag = 0;
      checkBox_OpenProbability1.Text = "First";
      checkBox_OpenProbability1.UseVisualStyleBackColor = true;
      checkBox_OpenProbability1.CheckedChanged += checkBox_OpenProbability_CheckedChanged;
      Panel_Devil.Controls.Add(numericUpDown_DevilVictoryTurn);
      Panel_Devil.Controls.Add(label6);
      Panel_Devil.Controls.Add(numericUpDown_DevilLevel);
      Panel_Devil.Controls.Add(label5);
      Panel_Devil.Controls.Add(label4);
      Panel_Devil.Controls.Add(comboBox_Devil);
      Panel_Devil.Location = new Point(0, 261);
      Panel_Devil.Name = "Panel_Devil";
      Panel_Devil.Size = new Size(233, 54);
      Panel_Devil.TabIndex = 11;
      numericUpDown_DevilVictoryTurn.Location = new Point(173, 32);
      numericUpDown_DevilVictoryTurn.Maximum = new Decimal(new int[4]
      {
        999,
        0,
        0,
        0
      });
      numericUpDown_DevilVictoryTurn.Name = "numericUpDown_DevilVictoryTurn";
      numericUpDown_DevilVictoryTurn.Size = new Size(49, 20);
      numericUpDown_DevilVictoryTurn.TabIndex = 5;
      numericUpDown_DevilVictoryTurn.Value = new Decimal(new int[4]);
      numericUpDown_DevilVictoryTurn.ValueChanged += numericUpDown_DevilVictoryTurn_ValueChanged;
      label6.AutoSize = true;
      label6.Location = new Point(105, 34);
      label6.Name = "label6";
      label6.Size = new Size(66, 13);
      label6.TabIndex = 4;
      label6.Text = "No. of Turns";
      numericUpDown_DevilLevel.Location = new Point(53, 32);
      numericUpDown_DevilLevel.Maximum = new Decimal(new int[4]
      {
        byte.MaxValue,
        0,
        0,
        0
      });
      numericUpDown_DevilLevel.Name = "numericUpDown_DevilLevel";
      numericUpDown_DevilLevel.Size = new Size(49, 20);
      numericUpDown_DevilLevel.TabIndex = 3;
      numericUpDown_DevilLevel.Value = new Decimal(new int[4]);
      numericUpDown_DevilLevel.ValueChanged += numericUpDown_DevilLevel_ValueChanged;
      label5.AutoSize = true;
      label5.Location = new Point(18, 34);
      label5.Name = "label5";
      label5.Size = new Size(33, 13);
      label5.TabIndex = 2;
      label5.Text = "Level";
      label4.AutoSize = true;
      label4.Location = new Point(21, 13);
      label4.Name = "label4";
      label4.Size = new Size(30, 13);
      label4.TabIndex = 1;
      label4.Text = "Boss";
      comboBox_Devil.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_Devil.FormattingEnabled = true;
      comboBox_Devil.Location = new Point(53, 9);
      comboBox_Devil.Name = "comboBox_Devil";
      comboBox_Devil.Size = new Size(121, 21);
      comboBox_Devil.TabIndex = 0;
      comboBox_Devil.SelectedIndexChanged += comboBox_Devil_SelectedIndexChanged;
      Panel_TreasureMapEditArea.Controls.Add(labelCandidatePlace);
      Panel_TreasureMapEditArea.Controls.Add(label_PlaceName);
      Panel_TreasureMapEditArea.Controls.Add(checkBox_PlaceHex);
      Panel_TreasureMapEditArea.Controls.Add(richTextBox_dummy);
      Panel_TreasureMapEditArea.Controls.Add(textBox_DungeonDetail);
      Panel_TreasureMapEditArea.Controls.Add(label_DungeonDetail);
      Panel_TreasureMapEditArea.Controls.Add(numericUpDown_Place);
      Panel_TreasureMapEditArea.Controls.Add(label8);
      Panel_TreasureMapEditArea.Controls.Add(comboBox_State);
      Panel_TreasureMapEditArea.Controls.Add(label7);
      Panel_TreasureMapEditArea.Controls.Add(GroupBox_MapType);
      Panel_TreasureMapEditArea.Controls.Add(Panel_Devil);
      Panel_TreasureMapEditArea.Controls.Add(label1);
      Panel_TreasureMapEditArea.Controls.Add(GroupBox_Probability);
      Panel_TreasureMapEditArea.Controls.Add(textBox_Detector);
      Panel_TreasureMapEditArea.Controls.Add(Panel_NormalMap);
      Panel_TreasureMapEditArea.Controls.Add(label2);
      Panel_TreasureMapEditArea.Controls.Add(textBox_Renewer);
      Panel_TreasureMapEditArea.Enabled = false;
      Panel_TreasureMapEditArea.Location = new Point(249, 28);
      Panel_TreasureMapEditArea.Name = "Panel_TreasureMapEditArea";
      Panel_TreasureMapEditArea.Size = new Size(611, 373);
      Panel_TreasureMapEditArea.TabIndex = 12;
      labelCandidatePlace.AutoSize = true;
      labelCandidatePlace.Location = new Point(111, 173);
      labelCandidatePlace.Name = "labelCandidatePlace";
      labelCandidatePlace.Size = new Size(0, 13);
      labelCandidatePlace.TabIndex = 22;
      label_PlaceName.AutoSize = true;
      label_PlaceName.Location = new Point(111, 156);
      label_PlaceName.Name = "label_PlaceName";
      label_PlaceName.Size = new Size(0, 13);
      label_PlaceName.TabIndex = 21;
      label_PlaceName.TextAlign = ContentAlignment.MiddleLeft;
      checkBox_PlaceHex.AutoSize = true;
      checkBox_PlaceHex.Location = new Point(204, 134);
      checkBox_PlaceHex.Name = "checkBox_PlaceHex";
      checkBox_PlaceHex.Size = new Size(45, 17);
      checkBox_PlaceHex.TabIndex = 20;
      checkBox_PlaceHex.Text = "Hex";
      checkBox_PlaceHex.UseVisualStyleBackColor = true;
      checkBox_PlaceHex.CheckedChanged += checkBox_PlaceHex_CheckedChanged;
      richTextBox_dummy.BackColor = SystemColors.Control;
      richTextBox_dummy.Font = new Font("Consolas", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
      richTextBox_dummy.Location = new Point(277, 18);
      richTextBox_dummy.Name = "richTextBox_dummy";
      richTextBox_dummy.ReadOnly = true;
      richTextBox_dummy.ScrollBars = RichTextBoxScrollBars.Vertical;
      richTextBox_dummy.Size = new Size(301, 352);
      richTextBox_dummy.TabIndex = 19;
      richTextBox_dummy.Text = "";
      richTextBox_dummy.Visible = false;
      textBox_DungeonDetail.BackColor = SystemColors.Control;
      textBox_DungeonDetail.Font = new Font("MS Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
      textBox_DungeonDetail.Location = new Point(277, 18);
      textBox_DungeonDetail.Name = "textBox_DungeonDetail";
      textBox_DungeonDetail.ReadOnly = true;
      textBox_DungeonDetail.ScrollBars = RichTextBoxScrollBars.Vertical;
      textBox_DungeonDetail.Size = new Size(301, 352);
      textBox_DungeonDetail.TabIndex = 18;
      textBox_DungeonDetail.Text = "";
      textBox_DungeonDetail.MouseMove += textBox_DungeonDetail_MouseMove;
      textBox_DungeonDetail.MouseDown += textBox_DungeonDetail_MouseDown;
      label_DungeonDetail.AutoSize = true;
      label_DungeonDetail.Enabled = false;
      label_DungeonDetail.Location = new Point(275, 3);
      label_DungeonDetail.Name = "label_DungeonDetail";
      label_DungeonDetail.Size = new Size(63, 12);
      label_DungeonDetail.TabIndex = 17;
      label_DungeonDetail.Text = "Map Details";
      numericUpDown_Place.Location = new Point(111, 132);
      numericUpDown_Place.Maximum = new Decimal(new int[4]
      {
        byte.MaxValue,
        0,
        0,
        0
      });
      numericUpDown_Place.Name = "numericUpDown_Place";
      numericUpDown_Place.Size = new Size(87, 20);
      numericUpDown_Place.TabIndex = 15;
      numericUpDown_Place.Value = new Decimal(new int[4]);
      numericUpDown_Place.ValueChanged += numericUpDown_Place_ValueChanged;
      label8.AutoSize = true;
      label8.Location = new Point(63, 134);
      label8.Name = "label8";
      label8.Size = new Size(48, 13);
      label8.TabIndex = 14;
      label8.Text = "Location";
      comboBox_State.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_State.FormattingEnabled = true;
      comboBox_State.Items.AddRange(new object[3]
      {
        "Not Found",
        "Discovered",
        "Cleared"
      });
      comboBox_State.Location = new Point(111, 109);
      comboBox_State.Name = "comboBox_State";
      comboBox_State.Size = new Size(87, 21);
      comboBox_State.TabIndex = 13;
      comboBox_State.SelectedIndexChanged += comboBox_State_SelectedIndexChanged;
      label7.AutoSize = true;
      label7.Location = new Point(74, 112);
      label7.Name = "label7";
      label7.Size = new Size(37, 13);
      label7.TabIndex = 12;
      label7.Text = "Status";
      panel2.BorderStyle = BorderStyle.Fixed3D;
      panel2.Controls.Add(listBox_TreasureMap);
      panel2.Controls.Add(toolStrip2);
      panel2.Location = new Point(14, 28);
      panel2.Name = "panel2";
      panel2.Size = new Size(229, 309);
      panel2.TabIndex = 13;
      toolStrip2.Dock = DockStyle.Bottom;
      toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
      toolStrip2.Items.AddRange(new ToolStripItem[6]
      {
        toolButton_CreateMap,
        toolButton_DeleteMap,
        label_MapCount,
        toolStripSeparator1,
        toolButton_SortLVUp,
        toolButton_SortLVDown
      });
      toolStrip2.Location = new Point(0, 280);
      toolStrip2.Name = "toolStrip2";
      toolStrip2.Size = new Size(225, 25);
      toolStrip2.TabIndex = 1;
      toolStrip2.Text = "toolStrip2";
      toolButton_CreateMap.DisplayStyle = ToolStripItemDisplayStyle.Image;
      toolButton_CreateMap.Enabled = false;
      toolButton_CreateMap.Image = (Image) componentResourceManager.GetObject("toolButton_CreateMap.Image");
      toolButton_CreateMap.ImageTransparentColor = Color.Magenta;
      toolButton_CreateMap.Name = "toolButton_CreateMap";
      toolButton_CreateMap.Size = new Size(23, 22);
      toolButton_CreateMap.Text = "toolStripButton7";
      toolButton_CreateMap.ToolTipText = "Create New Map";
      toolButton_CreateMap.Click += toolButton_CreateMap_Click;
      toolButton_DeleteMap.DisplayStyle = ToolStripItemDisplayStyle.Image;
      toolButton_DeleteMap.Enabled = false;
      toolButton_DeleteMap.Image = (Image) componentResourceManager.GetObject("toolButton_DeleteMap.Image");
      toolButton_DeleteMap.ImageTransparentColor = Color.Magenta;
      toolButton_DeleteMap.Name = "toolButton_DeleteMap";
      toolButton_DeleteMap.Size = new Size(23, 22);
      toolButton_DeleteMap.Text = "toolStripButton8";
      toolButton_DeleteMap.ToolTipText = "Remove Map";
      toolButton_DeleteMap.Click += toolButton_DeleteMap_Click;
      label_MapCount.Alignment = ToolStripItemAlignment.Right;
      label_MapCount.Name = "label_MapCount";
      label_MapCount.Size = new Size(51, 22);
      label_MapCount.Text = "(00/99)";
      numericUpDown_ClearCount.Location = new Point(92, 6);
      numericUpDown_ClearCount.Maximum = new Decimal(new int[4]
      {
        16383,
        0,
        0,
        0
      });
      numericUpDown_ClearCount.Name = "numericUpDown_ClearCount";
      numericUpDown_ClearCount.Size = new Size(76, 20);
      numericUpDown_ClearCount.TabIndex = 16;
      numericUpDown_ClearCount.Value = new Decimal(new int[4]);
      numericUpDown_ClearCount.ValueChanged += numericUpDown_ClearCount_ValueChanged;
      label9.AutoSize = true;
      label9.Location = new Point(14, 7);
      label9.Name = "label9";
      label9.Size = new Size(72, 13);
      label9.TabIndex = 15;
      label9.Text = "Cleared Maps";
      groupBoxWithCheckBox_Narrowing.AllowEnabledWithCheckBoxState = true;
      groupBoxWithCheckBox_Narrowing.Checked = false;
      groupBoxWithCheckBox_Narrowing.Controls.Add(comboBox_NarrowingName3);
      groupBoxWithCheckBox_Narrowing.Controls.Add(comboBox_NarrowingName2);
      groupBoxWithCheckBox_Narrowing.Controls.Add(comboBox_NarrowingName1);
      groupBoxWithCheckBox_Narrowing.Controls.Add(CheckBox_NarrowingNormal);
      groupBoxWithCheckBox_Narrowing.Controls.Add(CheckBox_NarrowingDevil);
      groupBoxWithCheckBox_Narrowing.Controls.Add(checkBox_NarrowingLevel);
      groupBoxWithCheckBox_Narrowing.Controls.Add(numericUpDown_NarrowingLevel);
      groupBoxWithCheckBox_Narrowing.Controls.Add(comboBox_NarrowingLevel);
      groupBoxWithCheckBox_Narrowing.Location = new Point(16, 343);
      groupBoxWithCheckBox_Narrowing.Name = "groupBoxWithCheckBox_Narrowing";
      groupBoxWithCheckBox_Narrowing.Size = new Size(374, 58);
      groupBoxWithCheckBox_Narrowing.TabIndex = 17;
      groupBoxWithCheckBox_Narrowing.Text = "Filter";
      groupBoxWithCheckBox_Narrowing.CheckedChanged += groupBoxWithCheckBox_Narrowing_CheckedChanged;
      comboBox_NarrowingName3.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_NarrowingName3.FormattingEnabled = true;
      comboBox_NarrowingName3.Location = new Point(132, 37);
      comboBox_NarrowingName3.Name = "comboBox_NarrowingName3";
      comboBox_NarrowingName3.Size = new Size(62, 21);
      comboBox_NarrowingName3.TabIndex = 8;
      comboBox_NarrowingName3.SelectedIndexChanged += comboBox_NarrowingName3_SelectedIndexChanged;
      comboBox_NarrowingName2.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_NarrowingName2.FormattingEnabled = true;
      comboBox_NarrowingName2.Location = new Point(200, 37);
      comboBox_NarrowingName2.Name = "comboBox_NarrowingName2";
      comboBox_NarrowingName2.Size = new Size(58, 21);
      comboBox_NarrowingName2.TabIndex = 9;
      comboBox_NarrowingName2.SelectedIndexChanged += comboBox_NarrowingName2_SelectedIndexChanged;
      comboBox_NarrowingName1.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_NarrowingName1.FormattingEnabled = true;
      comboBox_NarrowingName1.Location = new Point(61, 37);
      comboBox_NarrowingName1.Name = "comboBox_NarrowingName1";
      comboBox_NarrowingName1.Size = new Size(65, 21);
      comboBox_NarrowingName1.TabIndex = 7;
      comboBox_NarrowingName1.SelectedIndexChanged += comboBox_NarrowingName1_SelectedIndexChanged;
      CheckBox_NarrowingNormal.AutoSize = true;
      CheckBox_NarrowingNormal.Checked = true;
      CheckBox_NarrowingNormal.CheckState = CheckState.Checked;
      CheckBox_NarrowingNormal.Location = new Point(6, 39);
      CheckBox_NarrowingNormal.Name = "CheckBox_NarrowingNormal";
      CheckBox_NarrowingNormal.Size = new Size(59, 17);
      CheckBox_NarrowingNormal.TabIndex = 6;
      CheckBox_NarrowingNormal.Text = "Normal";
      CheckBox_NarrowingNormal.UseVisualStyleBackColor = true;
      CheckBox_NarrowingNormal.CheckedChanged += CheckBox_NarrowingNormal_CheckedChanged;
      CheckBox_NarrowingDevil.AutoSize = true;
      CheckBox_NarrowingDevil.Checked = true;
      CheckBox_NarrowingDevil.CheckState = CheckState.Checked;
      CheckBox_NarrowingDevil.Location = new Point(274, 14);
      CheckBox_NarrowingDevil.Name = "CheckBox_NarrowingDevil";
      CheckBox_NarrowingDevil.Size = new Size(49, 17);
      CheckBox_NarrowingDevil.TabIndex = 5;
      CheckBox_NarrowingDevil.Text = "Legacy Boss";
      CheckBox_NarrowingDevil.UseVisualStyleBackColor = true;
      CheckBox_NarrowingDevil.CheckedChanged += CheckBox_NarrowingDevil_CheckedChanged;
      checkBox_NarrowingLevel.AutoSize = true;
      checkBox_NarrowingLevel.Checked = true;
      checkBox_NarrowingLevel.CheckState = CheckState.Checked;
      checkBox_NarrowingLevel.Location = new Point(6, 16);
      checkBox_NarrowingLevel.Name = "checkBox_NarrowingLevel";
      checkBox_NarrowingLevel.Size = new Size(52, 17);
      checkBox_NarrowingLevel.TabIndex = 2;
      checkBox_NarrowingLevel.Text = "Level";
      checkBox_NarrowingLevel.UseVisualStyleBackColor = true;
      checkBox_NarrowingLevel.CheckedChanged += checkBox_NarrowingLevel_CheckedChanged;
      numericUpDown_NarrowingLevel.Location = new Point(61, 15);
      numericUpDown_NarrowingLevel.Maximum = new Decimal(new int[4]
      {
        99,
        0,
        0,
        0
      });
      numericUpDown_NarrowingLevel.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_NarrowingLevel.Name = "numericUpDown_NarrowingLevel";
      numericUpDown_NarrowingLevel.Size = new Size(57, 20);
      numericUpDown_NarrowingLevel.TabIndex = 3;
      numericUpDown_NarrowingLevel.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      numericUpDown_NarrowingLevel.ValueChanged += numericUpDown_NarrowingLevel_ValueChanged;
      comboBox_NarrowingLevel.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox_NarrowingLevel.FormattingEnabled = true;
      comboBox_NarrowingLevel.Items.AddRange(new object[2]
      {
        "At least",
        "Up to"
      });
      comboBox_NarrowingLevel.Location = new Point(123, 14);
      comboBox_NarrowingLevel.Name = "comboBox_NarrowingLevel";
      comboBox_NarrowingLevel.Size = new Size(67, 21);
      comboBox_NarrowingLevel.TabIndex = 4;
      comboBox_NarrowingLevel.SelectedIndexChanged += comboBox_NarrowingLevel_SelectedIndexChanged;
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new Size(6, 25);
      toolButton_SortLVUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
      toolButton_SortLVUp.Image = (Image) componentResourceManager.GetObject("toolButton_SortLVUp.Image");
      toolButton_SortLVUp.ImageTransparentColor = Color.Magenta;
      toolButton_SortLVUp.Name = "toolButton_SortLVUp";
      toolButton_SortLVUp.Size = new Size(23, 22);
      toolButton_SortLVUp.Text = "Sort Ascending by Level";
      toolButton_SortLVUp.Click += toolButton_SortLVUp_Click;
      toolButton_SortLVDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
      toolButton_SortLVDown.Image = (Image) componentResourceManager.GetObject("toolButton_SortLVDown.Image");
      toolButton_SortLVDown.ImageTransparentColor = Color.Magenta;
      toolButton_SortLVDown.Name = "toolButton_SortLVDown";
      toolButton_SortLVDown.Size = new Size(23, 22);
      toolButton_SortLVDown.Text = "Sort Descending by Level";
      toolButton_SortLVDown.Click += toolButton_SortLVDown_Click;
      AutoScaleDimensions = new SizeF(6f, 12f);
      AutoScaleMode = AutoScaleMode.Font;
      Controls.Add(groupBoxWithCheckBox_Narrowing);
      Controls.Add(numericUpDown_ClearCount);
      Controls.Add(label9);
      Controls.Add(panel2);
      Controls.Add(Panel_TreasureMapEditArea);
      Name = nameof (TreasureMapDataControl);
      Size = new Size(882, 511);
      GroupBox_MapType.ResumeLayout(false);
      GroupBox_MapType.PerformLayout();
      Panel_NormalMap.ResumeLayout(false);
      Panel_NormalMap.PerformLayout();
      numericUpDown_MapNo2.EndInit();
      numericUpDown_MapNo1.EndInit();
      GroupBox_Probability.ResumeLayout(false);
      GroupBox_Probability.PerformLayout();
      Panel_Devil.ResumeLayout(false);
      Panel_Devil.PerformLayout();
      numericUpDown_DevilVictoryTurn.EndInit();
      numericUpDown_DevilLevel.EndInit();
      Panel_TreasureMapEditArea.ResumeLayout(false);
      Panel_TreasureMapEditArea.PerformLayout();
      numericUpDown_Place.EndInit();
      panel2.ResumeLayout(false);
      panel2.PerformLayout();
      toolStrip2.ResumeLayout(false);
      toolStrip2.PerformLayout();
      numericUpDown_ClearCount.EndInit();
      groupBoxWithCheckBox_Narrowing.ResumeLayout(false);
      groupBoxWithCheckBox_Narrowing.PerformLayout();
      numericUpDown_NarrowingLevel.EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    private class TreasureMapListBoxItem
    {
      private string _name;
      private int _index;

      public TreasureMapListBoxItem(int index, string name)
      {
        _index = index;
        _name = name;
      }

      public int Index
      {
        get => _index;
        set => _index = value;
      }

      public override string ToString() => _name;
    }
  }
}
