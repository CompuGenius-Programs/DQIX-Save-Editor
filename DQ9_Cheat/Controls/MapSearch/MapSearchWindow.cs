// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.MapSearchWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DQ9_Cheat.GameData;
using DQ9_Cheat.MapSearch;
using JS_Framework.Controls;

namespace DQ9_Cheat.Controls.MapSearch;

public class MapSearchWindow : Form
{
    private static readonly string[,] _treasureBoxRankSymbol = new string[2, 10]
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

    private readonly ComparerBase[] _comparer = new ComparerBase[22]
    {
        new SeedComparer(),
        new RankComparer(),
        new MapNameComparer(),
        new MapName1Comparer(),
        new MapName3Comparer(),
        new MapName2Comparer(),
        new MapLVComparer(),
        new MapTypeComparer(),
        new DepthComparer(),
        new MonsterRankComparer(),
        new BossComparer(),
        new SBoxComparer(),
        new ABoxComparer(),
        new BBoxComparer(),
        new CBoxComparer(),
        new DBoxComparer(),
        new EBoxComparer(),
        new FBoxComparer(),
        new GBoxComparer(),
        new HBoxComparer(),
        new IBoxComparer(),
        new TotalBoxComparer()
    };

    private ListViewItem[] _dispItems;
    private bool _dispRenewal = true;
    private int _dispStartIndex;
    private readonly ListView.SelectedIndexCollection _listViewItemSelection;
    private readonly MapSearchConditionEdit _mapSearchConditionEdit;
    private readonly SearchDungeonData[] _resultDatas;
    private int _resultsCount;
    private readonly int[] _treasureBoxCount = new int[16];
    private readonly int[,] _treasureBoxIndexes = new int[16, 3];
    private readonly TreasureMapDetailData _treasureMapDetailData = new();
    private Button button_AddCondition;
    private Button button_DeleteCondition;
    private Button button_EditCondition;
    private Button button_Search;
    private ColumnHeader columnHeader_ARank;
    private ColumnHeader columnHeader_Boss;
    private ColumnHeader columnHeader_BRank;
    private ColumnHeader columnHeader_CRank;
    private ColumnHeader columnHeader_DRank;
    private ColumnHeader columnHeader_ERank;
    private ColumnHeader columnHeader_FloorCount;
    private ColumnHeader columnHeader_FRank;
    private ColumnHeader columnHeader_GRank;
    private ColumnHeader columnHeader_HRank;
    private ColumnHeader columnHeader_IRank;
    private ColumnHeader columnHeader_MapLevel;
    private ColumnHeader columnHeader_MapName;
    private ColumnHeader columnHeader_MapName1;
    private ColumnHeader columnHeader_MapName2;
    private ColumnHeader columnHeader_MapName3;
    private ColumnHeader columnHeader_MapType;
    private ColumnHeader columnHeader_MonsterRank;
    private ColumnHeader columnHeader_Rank;
    private ColumnHeader columnHeader_Seed;
    private ColumnHeader columnHeader_SRank;
    private ColumnHeader columnHeader_Total;
    private IContainer components;
    private GroupBox groupBox1;
    private Label label_ResultCount;
    private ListBox listBox_SearchCondition;
    private DoubleBufferedListView listView_Result;
    private RichTextBox richTextBox_dummy;
    private SplitContainer splitContainer_Horizontal;
    private SplitContainer splitContainer1;
    private Splitter splitter1;
    private RichTextBox textBox_DungeonDetail;

    public MapSearchWindow()
    {
        InitializeComponent();
        textBox_DungeonDetail.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
        _mapSearchConditionEdit = new MapSearchConditionEdit();
        SearchDataFile.LoadSearchDataFile();
        _resultDatas = new SearchDungeonData[SearchDataFile.TotalCount];
        _listViewItemSelection = new ListView.SelectedIndexCollection(listView_Result);
        Disposed += MapSearchWindow_Disposed;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        var componentResourceManager = new ComponentResourceManager(typeof(MapSearchWindow));
        groupBox1 = new GroupBox();
        button_Search = new Button();
        button_EditCondition = new Button();
        button_DeleteCondition = new Button();
        button_AddCondition = new Button();
        listBox_SearchCondition = new ListBox();
        label_ResultCount = new Label();
        richTextBox_dummy = new RichTextBox();
        splitter1 = new Splitter();
        splitContainer_Horizontal = new SplitContainer();
        splitContainer1 = new SplitContainer();
        textBox_DungeonDetail = new RichTextBox();
        listView_Result = new DoubleBufferedListView();
        columnHeader_Seed = new ColumnHeader();
        columnHeader_Rank = new ColumnHeader();
        columnHeader_MapName = new ColumnHeader();
        columnHeader_MapName1 = new ColumnHeader();
        columnHeader_MapName2 = new ColumnHeader();
        columnHeader_MapName3 = new ColumnHeader();
        columnHeader_MapLevel = new ColumnHeader();
        columnHeader_MapType = new ColumnHeader();
        columnHeader_FloorCount = new ColumnHeader();
        columnHeader_MonsterRank = new ColumnHeader();
        columnHeader_Boss = new ColumnHeader();
        columnHeader_SRank = new ColumnHeader();
        columnHeader_ARank = new ColumnHeader();
        columnHeader_BRank = new ColumnHeader();
        columnHeader_CRank = new ColumnHeader();
        columnHeader_DRank = new ColumnHeader();
        columnHeader_ERank = new ColumnHeader();
        columnHeader_FRank = new ColumnHeader();
        columnHeader_GRank = new ColumnHeader();
        columnHeader_HRank = new ColumnHeader();
        columnHeader_IRank = new ColumnHeader();
        columnHeader_Total = new ColumnHeader();
        groupBox1.SuspendLayout();
        splitContainer_Horizontal.Panel1.SuspendLayout();
        splitContainer_Horizontal.Panel2.SuspendLayout();
        splitContainer_Horizontal.SuspendLayout();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        SuspendLayout();
        groupBox1.Controls.Add(button_Search);
        groupBox1.Controls.Add(button_EditCondition);
        groupBox1.Controls.Add(button_DeleteCondition);
        groupBox1.Controls.Add(button_AddCondition);
        groupBox1.Controls.Add(listBox_SearchCondition);
        groupBox1.Location = new Point(9, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(370, 213);
        groupBox1.TabIndex = 3;
        groupBox1.TabStop = false;
        groupBox1.Text = "Search criteria";
        button_Search.Location = new Point(280, 179);
        button_Search.Name = "button_Search";
        button_Search.Size = new Size(75, 23);
        button_Search.TabIndex = 5;
        button_Search.Text = "Search";
        button_Search.UseVisualStyleBackColor = true;
        button_Search.Click += button_Search_Click;
        button_EditCondition.Location = new Point(280, 76);
        button_EditCondition.Name = "button_EditCondition";
        button_EditCondition.Size = new Size(75, 23);
        button_EditCondition.TabIndex = 4;
        button_EditCondition.Text = "Edit";
        button_EditCondition.UseVisualStyleBackColor = true;
        button_EditCondition.Click += button_EditCondition_Click;
        button_DeleteCondition.Location = new Point(280, 47);
        button_DeleteCondition.Name = "button_DeleteCondition";
        button_DeleteCondition.Size = new Size(75, 23);
        button_DeleteCondition.TabIndex = 3;
        button_DeleteCondition.Text = "Delete";
        button_DeleteCondition.UseVisualStyleBackColor = true;
        button_DeleteCondition.Click += button_DeleteCondition_Click;
        button_AddCondition.Location = new Point(280, 18);
        button_AddCondition.Name = "button_AddCondition";
        button_AddCondition.Size = new Size(75, 23);
        button_AddCondition.TabIndex = 2;
        button_AddCondition.Text = "Add";
        button_AddCondition.UseVisualStyleBackColor = true;
        button_AddCondition.Click += button_AddCondition_Click;
        listBox_SearchCondition.FormattingEnabled = true;
        listBox_SearchCondition.ItemHeight = 12;
        listBox_SearchCondition.Location = new Point(18, 18);
        listBox_SearchCondition.Name = "listBox_SearchCondition";
        listBox_SearchCondition.Size = new Size(256, 184);
        listBox_SearchCondition.TabIndex = 1;
        listBox_SearchCondition.MouseDoubleClick += listBox_SearchCondition_MouseDoubleClick;
        listBox_SearchCondition.KeyDown += listBox_SearchCondition_KeyDown;
        label_ResultCount.Location = new Point(814, 7);
        label_ResultCount.Name = "label_ResultCount";
        label_ResultCount.Size = new Size(176, 23);
        label_ResultCount.TabIndex = 5;
        label_ResultCount.TextAlign = ContentAlignment.MiddleRight;
        richTextBox_dummy.BackColor = SystemColors.Control;
        richTextBox_dummy.Font = new Font("MS Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
        richTextBox_dummy.Location = new Point(8, 8);
        richTextBox_dummy.Name = "richTextBox_dummy";
        richTextBox_dummy.ReadOnly = true;
        richTextBox_dummy.ScrollBars = RichTextBoxScrollBars.Vertical;
        richTextBox_dummy.Size = new Size(592, 235);
        richTextBox_dummy.TabIndex = 20;
        richTextBox_dummy.Text = "";
        richTextBox_dummy.Visible = false;
        splitter1.Location = new Point(0, 0);
        splitter1.Name = "splitter1";
        splitter1.Size = new Size(3, 548);
        splitter1.TabIndex = 21;
        splitter1.TabStop = false;
        splitContainer_Horizontal.BorderStyle = BorderStyle.Fixed3D;
        splitContainer_Horizontal.Dock = DockStyle.Fill;
        splitContainer_Horizontal.Location = new Point(3, 0);
        splitContainer_Horizontal.Name = "splitContainer_Horizontal";
        splitContainer_Horizontal.Orientation = Orientation.Horizontal;
        splitContainer_Horizontal.Panel1.Controls.Add(splitContainer1);
        splitContainer_Horizontal.Panel1MinSize = 250;
        splitContainer_Horizontal.Panel2.Controls.Add(label_ResultCount);
        splitContainer_Horizontal.Panel2.Controls.Add(listView_Result);
        splitContainer_Horizontal.Panel2.Resize += splitContainer_Horizontal_Panel2_Resize;
        splitContainer_Horizontal.Size = new Size(1005, 548);
        splitContainer_Horizontal.SplitterDistance = 250;
        splitContainer_Horizontal.TabIndex = 22;
        splitContainer1.BorderStyle = BorderStyle.Fixed3D;
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Panel1.AutoScroll = true;
        splitContainer1.Panel1.Controls.Add(groupBox1);
        splitContainer1.Panel1.Resize += splitContainer1_Panel1_Resize;
        splitContainer1.Panel1MinSize = 390;
        splitContainer1.Panel2.Controls.Add(richTextBox_dummy);
        splitContainer1.Panel2.Controls.Add(textBox_DungeonDetail);
        splitContainer1.Panel2.Resize += splitContainer1_Panel2_Resize;
        splitContainer1.Size = new Size(1005, 250);
        splitContainer1.SplitterDistance = 390;
        splitContainer1.TabIndex = 0;
        textBox_DungeonDetail.BackColor = SystemColors.Control;
        textBox_DungeonDetail.Font = new Font("MS Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
        textBox_DungeonDetail.Location = new Point(8, 8);
        textBox_DungeonDetail.Name = "textBox_DungeonDetail";
        textBox_DungeonDetail.ReadOnly = true;
        textBox_DungeonDetail.ScrollBars = RichTextBoxScrollBars.Vertical;
        textBox_DungeonDetail.Size = new Size(592, 235);
        textBox_DungeonDetail.TabIndex = 21;
        textBox_DungeonDetail.Text = "";
        textBox_DungeonDetail.MouseMove += textBox_DungeonDetail_MouseMove;
        textBox_DungeonDetail.MouseDown += textBox_DungeonDetail_MouseDown;
        listView_Result.Columns.AddRange(new ColumnHeader[22]
        {
            columnHeader_Seed,
            columnHeader_Rank,
            columnHeader_MapName,
            columnHeader_MapName1,
            columnHeader_MapName2,
            columnHeader_MapName3,
            columnHeader_MapLevel,
            columnHeader_MapType,
            columnHeader_FloorCount,
            columnHeader_MonsterRank,
            columnHeader_Boss,
            columnHeader_SRank,
            columnHeader_ARank,
            columnHeader_BRank,
            columnHeader_CRank,
            columnHeader_DRank,
            columnHeader_ERank,
            columnHeader_FRank,
            columnHeader_GRank,
            columnHeader_HRank,
            columnHeader_IRank,
            columnHeader_Total
        });
        listView_Result.FullRowSelect = true;
        listView_Result.GridLines = true;
        listView_Result.Location = new Point(6, 36);
        listView_Result.MultiSelect = false;
        listView_Result.Name = "listView_Result";
        listView_Result.Size = new Size(988, 251);
        listView_Result.TabIndex = 4;
        listView_Result.UseCompatibleStateImageBehavior = false;
        listView_Result.View = View.Details;
        listView_Result.VirtualMode = true;
        listView_Result.SelectedIndexChanged += listView_Result_SelectedIndexChanged;
        listView_Result.ColumnClick += listView_Result_ColumnClick;
        listView_Result.RetrieveVirtualItem += listView_Result_RetrieveVirtualItem;
        listView_Result.CacheVirtualItems += listView_Result_CacheVirtualItems;
        columnHeader_Seed.Text = "Seed";
        columnHeader_Seed.Width = 40;
        columnHeader_Rank.Text = "Rank";
        columnHeader_Rank.Width = 40;
        columnHeader_MapName.Text = "Map Name";
        columnHeader_MapName.Width = 153;
        columnHeader_MapName1.Text = "Name 1";
        columnHeader_MapName2.Text = "Name 2";
        columnHeader_MapName3.Text = "Name 3";
        columnHeader_MapLevel.Text = "LV";
        columnHeader_MapLevel.Width = 34;
        columnHeader_MapType.Text = "Type";
        columnHeader_MapType.Width = 65;
        columnHeader_FloorCount.DisplayIndex = 10;
        columnHeader_FloorCount.Text = "Floors";
        columnHeader_FloorCount.Width = 36;
        columnHeader_MonsterRank.DisplayIndex = 8;
        columnHeader_MonsterRank.Text = "M.Rank";
        columnHeader_MonsterRank.Width = 54;
        columnHeader_Boss.DisplayIndex = 9;
        columnHeader_Boss.Text = "Boss";
        columnHeader_Boss.Width = 114;
        columnHeader_SRank.Text = "S";
        columnHeader_SRank.Width = 20;
        columnHeader_ARank.Text = "A";
        columnHeader_ARank.Width = 20;
        columnHeader_BRank.Text = "B";
        columnHeader_BRank.Width = 20;
        columnHeader_CRank.Text = "C";
        columnHeader_CRank.Width = 20;
        columnHeader_DRank.Text = "D";
        columnHeader_DRank.Width = 20;
        columnHeader_ERank.Text = "E";
        columnHeader_ERank.Width = 20;
        columnHeader_FRank.Text = "F";
        columnHeader_FRank.Width = 20;
        columnHeader_GRank.Text = "G";
        columnHeader_GRank.Width = 20;
        columnHeader_HRank.Text = "H";
        columnHeader_HRank.Width = 20;
        columnHeader_IRank.Text = "I";
        columnHeader_IRank.Width = 20;
        columnHeader_Total.Text = "# treasures";
        columnHeader_Total.Width = 49;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1008, 548);
        Controls.Add(splitContainer_Horizontal);
        Controls.Add(splitter1);
        Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
        Name = nameof(MapSearchWindow);
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Treasure Map Search";
        Shown += MapSearchWindow_Shown;
        groupBox1.ResumeLayout(false);
        splitContainer_Horizontal.Panel1.ResumeLayout(false);
        splitContainer_Horizontal.Panel2.ResumeLayout(false);
        splitContainer_Horizontal.ResumeLayout(false);
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        e.Cancel = true;
        Visible = false;
    }

    private void MapSearchWindow_Disposed(object sender, EventArgs e)
    {
        _mapSearchConditionEdit.Dispose();
    }

    private void button_AddCondition_Click(object sender, EventArgs e)
    {
        _mapSearchConditionEdit.Condition = null;
        if (_mapSearchConditionEdit.ShowDialog() != DialogResult.OK)
            return;
        listBox_SearchCondition.Items.Add(_mapSearchConditionEdit.Condition);
    }

    private void EditCondition(int index)
    {
        if (index < 0 || index >= listBox_SearchCondition.Items.Count)
            return;
        _mapSearchConditionEdit.Condition = listBox_SearchCondition.SelectedItem as SearchConditionBase;
        if (_mapSearchConditionEdit.ShowDialog() != DialogResult.OK)
            return;
        listBox_SearchCondition.BeginUpdate();
        listBox_SearchCondition.Items.RemoveAt(index);
        listBox_SearchCondition.Items.Insert(index, _mapSearchConditionEdit.Condition);
        listBox_SearchCondition.EndUpdate();
    }

    private void RemoveCondition(int index)
    {
        if (index < 0 || index >= listBox_SearchCondition.Items.Count)
            return;
        listBox_SearchCondition.Items.RemoveAt(index);
    }

    private void listBox_SearchCondition_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        EditCondition(listBox_SearchCondition.IndexFromPoint(e.Location));
    }

    private void listBox_SearchCondition_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Delete)
            return;
        RemoveCondition(listBox_SearchCondition.SelectedIndex);
    }

    private void button_DeleteCondition_Click(object sender, EventArgs e)
    {
        RemoveCondition(listBox_SearchCondition.SelectedIndex);
    }

    private void button_EditCondition_Click(object sender, EventArgs e)
    {
        EditCondition(listBox_SearchCondition.SelectedIndex);
    }

    private void button_Search_Click(object sender, EventArgs e)
    {
        _dispRenewal = true;
        RenewalDungeonDetail(false);
        listView_Result.BeginUpdate();
        listView_Result.Items.Clear();
        _resultsCount = 0;
        var index1 = 0;
        for (ushort seed = 0; seed < 32768; ++seed)
            if (TreasureMapDataTable.GetReverseSeedTable(seed) != null)
                for (byte index2 = 0; index2 < 12; ++index2)
                {
                    var flag = true;
                    var dungeonData = SearchDataFile.DungeonData[index1];
                    foreach (SearchConditionBase searchConditionBase in listBox_SearchCondition.Items)
                        if (!searchConditionBase.IsHit(dungeonData))
                        {
                            flag = false;
                            break;
                        }

                    if (flag)
                    {
                        _resultDatas[_resultsCount] = dungeonData;
                        ++_resultsCount;
                    }

                    ++index1;
                }

        listView_Result.VirtualListSize = _resultsCount;
        listView_Result.EndUpdate();
        RenewalResultInfo();
    }

    private void listView_Result_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
    {
        var index = e.ItemIndex - _dispStartIndex;
        if (index < 0)
            index = 0;
        if (index >= _dispItems.Length)
            index = _dispItems.Length - 1;
        e.Item = _dispItems[index];
    }

    private void MapSearchWindow_Shown(object sender, EventArgs e)
    {
        _resultsCount = 0;
        listView_Result.VirtualListSize = 0;
        _dispRenewal = true;
        RenewalResultInfo();
    }

    private void RenewalResultInfo()
    {
        label_ResultCount.Text = string.Format("{0} / {1}", _resultsCount, SearchDataFile.TotalCount);
    }

    private void listView_Result_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
    {
        var length = e.EndIndex - e.StartIndex + 1;
        if ((!_dispRenewal && _dispItems != null && _dispStartIndex <= e.StartIndex &&
             _dispStartIndex + _dispItems.Length > e.EndIndex) || length <= 0)
            return;
        _dispRenewal = false;
        _dispItems = new ListViewItem[length];
        var startIndex = e.StartIndex;
        _dispStartIndex = e.StartIndex;
        for (var index = 0; index < length; ++index)
        {
            var resultData = _resultDatas[startIndex];
            _dispItems[index] = new ListViewItem();
            _dispItems[index].Text = string.Format("{0:X04}", resultData.Seed);
            _dispItems[index].SubItems.Add(string.Format("{0:X02}", resultData.Rank));
            _dispItems[index].SubItems.Add(resultData.MapName);
            _dispItems[index].SubItems.Add(resultData.MapName1);
            _dispItems[index].SubItems.Add(resultData.MapName3);
            _dispItems[index].SubItems.Add(resultData.MapName2);
            _dispItems[index].SubItems.Add(resultData.MapLevel.ToString());
            _dispItems[index].SubItems.Add(TreasureMapDataTable.TreasureMapMapTypeName_Table[resultData.MapType]);
            _dispItems[index].SubItems.Add(resultData.Depth.ToString());
            _dispItems[index].SubItems.Add(resultData.MonsterRank.ToString());
            _dispItems[index].SubItems.Add(MonsterDataList.List[282 + resultData.Boss]);
            _dispItems[index].SubItems.Add(resultData.SBoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.ABoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.BBoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.CBoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.DBoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.EBoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.FBoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.GBoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.HBoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.IBoxCount.ToString());
            _dispItems[index].SubItems.Add(resultData.TotalBoxCount.ToString());
            ++startIndex;
        }
    }

    private void listView_Result_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        if (_resultsCount <= 0)
            return;
        _comparer[e.Column].Up = !_comparer[e.Column].Up;
        Array.Sort(_resultDatas, 0, _resultsCount, _comparer[e.Column]);
        _dispRenewal = true;
        listView_Result.Invalidate();
    }

    private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
    {
    }

    private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
    {
        richTextBox_dummy.Height = splitContainer1.Panel2.Height - 16;
        richTextBox_dummy.Width = splitContainer1.Panel2.Width - 16;
        textBox_DungeonDetail.Height = splitContainer1.Panel2.Height - 16;
        textBox_DungeonDetail.Width = splitContainer1.Panel2.Width - 16;
    }

    private void splitContainer_Horizontal_Panel2_Resize(object sender, EventArgs e)
    {
        label_ResultCount.Left = splitContainer_Horizontal.Panel2.Width - label_ResultCount.Width - 8;
        listView_Result.Width = splitContainer_Horizontal.Panel2.Width - 16;
        listView_Result.Height = splitContainer_Horizontal.Panel2.Height - listView_Result.Top - 8;
    }

    private void listView_Result_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_listViewItemSelection.Count > 0)
        {
            var index = _listViewItemSelection[0];
            _treasureMapDetailData.MapSeed = _resultDatas[index].Seed;
            _treasureMapDetailData.MapRank = _resultDatas[index].Rank;
            _treasureMapDetailData.CalculateDetail(true);
            RenewalDungeonDetail(true);
        }
        else
        {
            RenewalDungeonDetail(false);
        }
    }

    private void RenewalDungeonDetail(bool disp)
    {
        if (disp)
        {
            richTextBox_dummy.Visible = true;
            textBox_DungeonDetail.Text = string.Empty;
            var stringBuilder = new StringBuilder();
            byte num1 = 0;
            for (var index = 0; index < SearchDataFile.RankList.Length; ++index)
                if (SearchDataFile.RankList[index] == _treasureMapDetailData.MapRank)
                {
                    num1 = index != SearchDataFile.RankList.Length - 1
                        ? (byte)(SearchDataFile.RankList[index + 1] - 1U)
                        : (byte)248;
                    break;
                }

            stringBuilder.AppendFormat("Rank: 0x{0:X2} - 0x{1:X2}, Seed: 0x{2:X4}\n", _treasureMapDetailData.MapRank,
                num1, _treasureMapDetailData.MapSeed);
            stringBuilder.AppendFormat("{0}\n", _treasureMapDetailData.MapName);
            if (_treasureMapDetailData.MapRank <= 50 && num1 > 50)
            {
                stringBuilder.Append("Locations up to Rank 0x32:");
                foreach (var lowRankValidPlace in _treasureMapDetailData.LowRankValidPlaceList)
                    stringBuilder.AppendFormat(" 0x{0:X2}({1})", lowRankValidPlace,
                        TreasureMapDataTable.TreasureMapPlaceName_Table[
                            TreasureMapDataTable.TreasureMapPlace_Table[lowRankValidPlace]]);
                stringBuilder.Append("\n");
                stringBuilder.Append("Locations up to Rank 0x37:");
                foreach (var middleRankValidPlace in _treasureMapDetailData.MiddleRankValidPlaceList)
                    stringBuilder.AppendFormat(" 0x{0:X2}({1})", middleRankValidPlace,
                        TreasureMapDataTable.TreasureMapPlaceName_Table[
                            TreasureMapDataTable.TreasureMapPlace_Table[middleRankValidPlace]]);
            }
            else
            {
                stringBuilder.Append("Locations:");
                foreach (var validPlace in _treasureMapDetailData.ValidPlaceList)
                    stringBuilder.AppendFormat(" 0x{0:X2}({1})", validPlace,
                        TreasureMapDataTable.TreasureMapPlaceName_Table[
                            TreasureMapDataTable.TreasureMapPlace_Table[validPlace]]);
            }

            stringBuilder.Append("\n");
            stringBuilder.AppendFormat("Type: {0}\n", _treasureMapDetailData.MapTypeName);
            stringBuilder.AppendFormat("Floors: {0}\n", _treasureMapDetailData.FloorCount);
            stringBuilder.AppendFormat("Monster rank: {0}\n", _treasureMapDetailData.MonsterRank);
            stringBuilder.AppendFormat("Boss: {0}\n", _treasureMapDetailData.BossName);
            var treasureBoxCount = _treasureMapDetailData.GetTreasureBoxCount(0);
            stringBuilder.AppendFormat("Number of chests: {0}\n", treasureBoxCount);
            if (treasureBoxCount > 0)
            {
                stringBuilder.Append(" By rank:\n  ");
                for (var rank = 10; rank > 0; --rank)
                    stringBuilder.AppendFormat(" {0}:{1}", _treasureBoxRankSymbol[0, rank - 1],
                        _treasureMapDetailData.GetTreasureBoxCount(rank));
                stringBuilder.Append("\n");
                stringBuilder.Append(" By floor:\n");
                for (var floor = 0; floor < _treasureMapDetailData.FloorCount; ++floor)
                    if (_treasureMapDetailData.GetTreasureBoxCountPerFloor(floor) > 0)
                    {
                        stringBuilder.AppendFormat("   B{0:D2}:", floor + 1);
                        foreach (var treasureBoxInfo in _treasureMapDetailData.TreasureBoxInfoList[floor])
                            stringBuilder.AppendFormat(" {0}", _treasureBoxRankSymbol[0, treasureBoxInfo.Rank - 1]);
                        stringBuilder.Append("\n");
                    }
            }

            for (var floor = 0; floor < _treasureMapDetailData.FloorCount; ++floor)
            {
                _treasureBoxCount[floor] = 0;
                var floorMap = _treasureMapDetailData.GetFloorMap(floor);
                if (floorMap != null)
                {
                    stringBuilder.Append("\n");
                    stringBuilder.AppendFormat("B{0:D2}\n", floor + 1);
                    for (var y = 0; y < _treasureMapDetailData.GetFloorHeight(floor); ++y)
                    {
                        for (var x = 0; x < _treasureMapDetailData.GetFloorWidth(floor); ++x)
                            if (floorMap[y, x] == 1 || floorMap[y, x] == 3)
                            {
                                stringBuilder.Append("■");
                            }
                            else if (floorMap[y, x] == 4)
                            {
                                if (_treasureMapDetailData.IsUpStep(floor, x, y))
                                    stringBuilder.Append("△");
                                else
                                    stringBuilder.Append("　");
                            }
                            else if (floorMap[y, x] == 5)
                            {
                                stringBuilder.Append("▽");
                            }
                            else if (floorMap[y, x] == 6)
                            {
                                var num2 = _treasureMapDetailData.IsTreasureBoxRank(floor, x, y);
                                if (num2 > 0)
                                {
                                    var treasureBoxIndex = _treasureMapDetailData.GetTreasureBoxIndex(floor, x, y);
                                    _treasureBoxIndexes[floor, treasureBoxIndex] = stringBuilder.Length;
                                    stringBuilder.AppendFormat("{0}", _treasureBoxRankSymbol[1, num2 - 1]);
                                    ++_treasureBoxCount[floor];
                                }
                                else
                                {
                                    stringBuilder.Append("　");
                                }
                            }
                            else
                            {
                                stringBuilder.Append("　");
                            }

                        stringBuilder.Append("\n");
                    }

                    for (var index1 = 0; index1 < _treasureBoxCount[floor]; ++index1)
                    {
                        var rank = _treasureMapDetailData.TreasureBoxInfoList[floor][index1].Rank;
                        var index2 = _treasureMapDetailData.TreasureBoxInfoList[floor][index1].Index;
                        var treasureBoxItem = _treasureMapDetailData.GetTreasureBoxItem(floor, index2, 2);
                        stringBuilder.AppendFormat("({0:D2}, {1:D2}) {2} {3}\n",
                            _treasureMapDetailData.TreasureBoxInfoList[floor][index1].X,
                            _treasureMapDetailData.TreasureBoxInfoList[floor][index1].Y,
                            _treasureBoxRankSymbol[1, rank - 1], treasureBoxItem);
                    }
                }
            }

            textBox_DungeonDetail.Text = stringBuilder.ToString();
            using (var font = new Font("ＭＳ ゴシック", 9f, FontStyle.Underline, GraphicsUnit.Point, 128))
            {
                for (var index3 = 0; index3 < _treasureMapDetailData.FloorCount; ++index3)
                for (var index4 = 0; index4 < _treasureBoxCount[index3]; ++index4)
                {
                    textBox_DungeonDetail.SelectionStart = _treasureBoxIndexes[index3, index4];
                    textBox_DungeonDetail.SelectionLength = 1;
                    textBox_DungeonDetail.SelectionFont = font;
                    textBox_DungeonDetail.SelectionColor = Color.Blue;
                }
            }

            textBox_DungeonDetail.SelectionStart = 0;
            textBox_DungeonDetail.SelectionLength = 0;
            textBox_DungeonDetail.ScrollToCaret();
            textBox_DungeonDetail.Enabled = true;
            richTextBox_dummy.Visible = false;
        }
        else
        {
            textBox_DungeonDetail.Enabled = false;
            textBox_DungeonDetail.Text = string.Empty;
        }
    }

    private void textBox_DungeonDetail_MouseMove(object sender, MouseEventArgs e)
    {
        if (_listViewItemSelection.Count <= 0)
            return;
        var indexFromPosition = textBox_DungeonDetail.GetCharIndexFromPosition(new Point(e.X - 5, e.Y));
        for (var index1 = 0; index1 < _treasureMapDetailData.FloorCount; ++index1)
        for (var index2 = 0; index2 < _treasureBoxCount[index1]; ++index2)
            if (_treasureBoxIndexes[index1, index2] == indexFromPosition)
            {
                textBox_DungeonDetail.Cursor = Cursors.Arrow;
                return;
            }

        textBox_DungeonDetail.Cursor = Cursors.IBeam;
    }

    private void textBox_DungeonDetail_MouseDown(object sender, MouseEventArgs e)
    {
        if (_listViewItemSelection.Count <= 0)
            return;
        var indexFromPosition = textBox_DungeonDetail.GetCharIndexFromPosition(new Point(e.X - 5, e.Y));
        for (var floor = 0; floor < _treasureMapDetailData.FloorCount; ++floor)
        for (var boxIndex = 0; boxIndex < _treasureBoxCount[floor]; ++boxIndex)
            if (_treasureBoxIndexes[floor, boxIndex] == indexFromPosition)
            {
                textBox_DungeonDetail.Cursor = Cursors.Arrow;
                using (var boxItemTableList = new TreasureBoxItemTableList(_treasureMapDetailData, floor, boxIndex))
                {
                    foreach (var treasureBoxInfo in _treasureMapDetailData.TreasureBoxInfoList[floor])
                        if (treasureBoxInfo.Index == boxIndex)
                            boxItemTableList.Text = string.Format("Item Table B{0} ({1}, {2}) {3}", floor + 1,
                                treasureBoxInfo.X, treasureBoxInfo.Y,
                                _treasureBoxRankSymbol[0, treasureBoxInfo.Rank - 1]);
                    var num = (int)boxItemTableList.ShowDialog();
                    return;
                }
            }

        textBox_DungeonDetail.Cursor = Cursors.IBeam;
    }

    private class ABoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.ABoxCount - searchDungeonData2.ABoxCount
                : searchDungeonData2.ABoxCount - searchDungeonData1.ABoxCount;
        }
    }

    private class BBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.BBoxCount - searchDungeonData2.BBoxCount
                : searchDungeonData2.BBoxCount - searchDungeonData1.BBoxCount;
        }
    }

    private class BossComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.Boss - searchDungeonData2.Boss
                : searchDungeonData2.Boss - searchDungeonData1.Boss;
        }
    }

    private class CBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.CBoxCount - searchDungeonData2.CBoxCount
                : searchDungeonData2.CBoxCount - searchDungeonData1.CBoxCount;
        }
    }

    private abstract class ComparerBase : IComparer
    {
        protected bool _up;

        public bool Up
        {
            get => _up;
            set => _up = value;
        }

        public abstract int Compare(object x, object y);
    }

    private class DBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.DBoxCount - searchDungeonData2.DBoxCount
                : searchDungeonData2.DBoxCount - searchDungeonData1.DBoxCount;
        }
    }

    private class DepthComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.Depth - searchDungeonData2.Depth
                : searchDungeonData2.Depth - searchDungeonData1.Depth;
        }
    }

    private class EBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.EBoxCount - searchDungeonData2.EBoxCount
                : searchDungeonData2.EBoxCount - searchDungeonData1.EBoxCount;
        }
    }

    private class FBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.FBoxCount - searchDungeonData2.FBoxCount
                : searchDungeonData2.FBoxCount - searchDungeonData1.FBoxCount;
        }
    }

    private class GBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.GBoxCount - searchDungeonData2.GBoxCount
                : searchDungeonData2.GBoxCount - searchDungeonData1.GBoxCount;
        }
    }

    private class HBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.HBoxCount - searchDungeonData2.HBoxCount
                : searchDungeonData2.HBoxCount - searchDungeonData1.HBoxCount;
        }
    }

    private class IBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.IBoxCount - searchDungeonData2.IBoxCount
                : searchDungeonData2.IBoxCount - searchDungeonData1.IBoxCount;
        }
    }

    private class MapLVComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.MapLevel - searchDungeonData2.MapLevel
                : searchDungeonData2.MapLevel - searchDungeonData1.MapLevel;
        }
    }

    private class MapName1Comparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.MapName1Index - searchDungeonData2.MapName1Index
                : searchDungeonData2.MapName1Index - searchDungeonData1.MapName1Index;
        }
    }

    private class MapName2Comparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.MapName2Index - searchDungeonData2.MapName2Index
                : searchDungeonData2.MapName2Index - searchDungeonData1.MapName2Index;
        }
    }

    private class MapName3Comparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.MapName3Index - searchDungeonData2.MapName3Index
                : searchDungeonData2.MapName3Index - searchDungeonData1.MapName3Index;
        }
    }

    private class MapNameComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            var num1 = searchDungeonData1.MapName1Index + (searchDungeonData1.MapName2Index << 5) +
                       (searchDungeonData1.MapName3Index << 10) + (searchDungeonData1.MapLevel << 15);
            var num2 = searchDungeonData2.MapName1Index + (searchDungeonData2.MapName2Index << 5) +
                       (searchDungeonData2.MapName3Index << 10) + (searchDungeonData2.MapLevel << 15);
            return _up ? num1 - num2 : num2 - num1;
        }
    }

    private class MapTypeComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.MapType - searchDungeonData2.MapType
                : searchDungeonData2.MapType - searchDungeonData1.MapType;
        }
    }

    private class MonsterRankComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.MonsterRank - searchDungeonData2.MonsterRank
                : searchDungeonData2.MonsterRank - searchDungeonData1.MonsterRank;
        }
    }

    private class RankComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.Rank - searchDungeonData2.Rank
                : searchDungeonData2.Rank - searchDungeonData1.Rank;
        }
    }

    private class SBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.SBoxCount - searchDungeonData2.SBoxCount
                : searchDungeonData2.SBoxCount - searchDungeonData1.SBoxCount;
        }
    }

    private class SeedComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.Seed - searchDungeonData2.Seed
                : searchDungeonData2.Seed - searchDungeonData1.Seed;
        }
    }

    private class TotalBoxComparer : ComparerBase, IComparer
    {
        public override int Compare(object x, object y)
        {
            var searchDungeonData1 = (SearchDungeonData)x;
            var searchDungeonData2 = (SearchDungeonData)y;
            return _up
                ? searchDungeonData1.TotalBoxCount - searchDungeonData2.TotalBoxCount
                : searchDungeonData2.TotalBoxCount - searchDungeonData1.TotalBoxCount;
        }
    }
}