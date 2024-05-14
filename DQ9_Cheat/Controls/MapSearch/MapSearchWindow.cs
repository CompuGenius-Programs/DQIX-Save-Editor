// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.MapSearch.MapSearchWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.GameData;
using DQ9_Cheat.MapSearch;
using JS_Framework.Controls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat.Controls.MapSearch
{
  public class MapSearchWindow : Form
  {
    private IContainer components;
    private GroupBox groupBox1;
    private Button button_Search;
    private Button button_EditCondition;
    private Button button_DeleteCondition;
    private Button button_AddCondition;
    private ListBox listBox_SearchCondition;
    private DoubleBufferedListView listView_Result;
    private ColumnHeader columnHeader_Rank;
    private ColumnHeader columnHeader_Seed;
    private ColumnHeader columnHeader_MapName;
    private ColumnHeader columnHeader_MapName1;
    private ColumnHeader columnHeader_MapName2;
    private ColumnHeader columnHeader_MapName3;
    private ColumnHeader columnHeader_MapLevel;
    private ColumnHeader columnHeader_MapType;
    private ColumnHeader columnHeader_MonsterRank;
    private ColumnHeader columnHeader_FloorCount;
    private ColumnHeader columnHeader_Boss;
    private ColumnHeader columnHeader_SRank;
    private ColumnHeader columnHeader_ARank;
    private ColumnHeader columnHeader_BRank;
    private ColumnHeader columnHeader_CRank;
    private ColumnHeader columnHeader_DRank;
    private ColumnHeader columnHeader_ERank;
    private ColumnHeader columnHeader_FRank;
    private ColumnHeader columnHeader_GRank;
    private ColumnHeader columnHeader_HRank;
    private ColumnHeader columnHeader_IRank;
    private ColumnHeader columnHeader_Total;
    private Label label_ResultCount;
    private RichTextBox richTextBox_dummy;
    private Splitter splitter1;
    private SplitContainer splitContainer_Horizontal;
    private SplitContainer splitContainer1;
    private RichTextBox textBox_DungeonDetail;
    private MapSearchConditionEdit _mapSearchConditionEdit;
    private SearchDungeonData[] _resultDatas;
    private int _resultsCount;
    private ListViewItem[] _dispItems;
    private int _dispStartIndex;
    private bool _dispRenewal = true;
    private ListView.SelectedIndexCollection _listViewItemSelection;
    private MapSearchWindow.ComparerBase[] _comparer = new MapSearchWindow.ComparerBase[22]
    {
      (MapSearchWindow.ComparerBase) new MapSearchWindow.SeedComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.RankComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.MapNameComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.MapName1Comparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.MapName3Comparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.MapName2Comparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.MapLVComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.MapTypeComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.DepthComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.MonsterRankComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.BossComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.SBoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.ABoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.BBoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.CBoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.DBoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.EBoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.FBoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.GBoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.HBoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.IBoxComparer(),
      (MapSearchWindow.ComparerBase) new MapSearchWindow.TotalBoxComparer()
    };
    private TreasureMapDetailData _treasureMapDetailData = new TreasureMapDetailData();
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

    public MapSearchWindow()
    {
      this.InitializeComponent();
      this.textBox_DungeonDetail.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
      this._mapSearchConditionEdit = new MapSearchConditionEdit();
      SearchDataFile.LoadSearchDataFile();
      this._resultDatas = new SearchDungeonData[SearchDataFile.TotalCount];
      this._listViewItemSelection = new ListView.SelectedIndexCollection((ListView) this.listView_Result);
      this.Disposed += new EventHandler(this.MapSearchWindow_Disposed);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MapSearchWindow));
      this.groupBox1 = new GroupBox();
      this.button_Search = new Button();
      this.button_EditCondition = new Button();
      this.button_DeleteCondition = new Button();
      this.button_AddCondition = new Button();
      this.listBox_SearchCondition = new ListBox();
      this.label_ResultCount = new Label();
      this.richTextBox_dummy = new RichTextBox();
      this.splitter1 = new Splitter();
      this.splitContainer_Horizontal = new SplitContainer();
      this.splitContainer1 = new SplitContainer();
      this.textBox_DungeonDetail = new RichTextBox();
      this.listView_Result = new DoubleBufferedListView();
      this.columnHeader_Seed = new ColumnHeader();
      this.columnHeader_Rank = new ColumnHeader();
      this.columnHeader_MapName = new ColumnHeader();
      this.columnHeader_MapName1 = new ColumnHeader();
      this.columnHeader_MapName2 = new ColumnHeader();
      this.columnHeader_MapName3 = new ColumnHeader();
      this.columnHeader_MapLevel = new ColumnHeader();
      this.columnHeader_MapType = new ColumnHeader();
      this.columnHeader_FloorCount = new ColumnHeader();
      this.columnHeader_MonsterRank = new ColumnHeader();
      this.columnHeader_Boss = new ColumnHeader();
      this.columnHeader_SRank = new ColumnHeader();
      this.columnHeader_ARank = new ColumnHeader();
      this.columnHeader_BRank = new ColumnHeader();
      this.columnHeader_CRank = new ColumnHeader();
      this.columnHeader_DRank = new ColumnHeader();
      this.columnHeader_ERank = new ColumnHeader();
      this.columnHeader_FRank = new ColumnHeader();
      this.columnHeader_GRank = new ColumnHeader();
      this.columnHeader_HRank = new ColumnHeader();
      this.columnHeader_IRank = new ColumnHeader();
      this.columnHeader_Total = new ColumnHeader();
      this.groupBox1.SuspendLayout();
      this.splitContainer_Horizontal.Panel1.SuspendLayout();
      this.splitContainer_Horizontal.Panel2.SuspendLayout();
      this.splitContainer_Horizontal.SuspendLayout();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.button_Search);
      this.groupBox1.Controls.Add((Control) this.button_EditCondition);
      this.groupBox1.Controls.Add((Control) this.button_DeleteCondition);
      this.groupBox1.Controls.Add((Control) this.button_AddCondition);
      this.groupBox1.Controls.Add((Control) this.listBox_SearchCondition);
      this.groupBox1.Location = new Point(9, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(370, 213);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Search criteria";
      this.button_Search.Location = new Point(280, 179);
      this.button_Search.Name = "button_Search";
      this.button_Search.Size = new Size(75, 23);
      this.button_Search.TabIndex = 5;
      this.button_Search.Text = "Search";
      this.button_Search.UseVisualStyleBackColor = true;
      this.button_Search.Click += new EventHandler(this.button_Search_Click);
      this.button_EditCondition.Location = new Point(280, 76);
      this.button_EditCondition.Name = "button_EditCondition";
      this.button_EditCondition.Size = new Size(75, 23);
      this.button_EditCondition.TabIndex = 4;
      this.button_EditCondition.Text = "Edit";
      this.button_EditCondition.UseVisualStyleBackColor = true;
      this.button_EditCondition.Click += new EventHandler(this.button_EditCondition_Click);
      this.button_DeleteCondition.Location = new Point(280, 47);
      this.button_DeleteCondition.Name = "button_DeleteCondition";
      this.button_DeleteCondition.Size = new Size(75, 23);
      this.button_DeleteCondition.TabIndex = 3;
      this.button_DeleteCondition.Text = "Delete";
      this.button_DeleteCondition.UseVisualStyleBackColor = true;
      this.button_DeleteCondition.Click += new EventHandler(this.button_DeleteCondition_Click);
      this.button_AddCondition.Location = new Point(280, 18);
      this.button_AddCondition.Name = "button_AddCondition";
      this.button_AddCondition.Size = new Size(75, 23);
      this.button_AddCondition.TabIndex = 2;
      this.button_AddCondition.Text = "Add";
      this.button_AddCondition.UseVisualStyleBackColor = true;
      this.button_AddCondition.Click += new EventHandler(this.button_AddCondition_Click);
      this.listBox_SearchCondition.FormattingEnabled = true;
      this.listBox_SearchCondition.ItemHeight = 12;
      this.listBox_SearchCondition.Location = new Point(18, 18);
      this.listBox_SearchCondition.Name = "listBox_SearchCondition";
      this.listBox_SearchCondition.Size = new Size(256, 184);
      this.listBox_SearchCondition.TabIndex = 1;
      this.listBox_SearchCondition.MouseDoubleClick += new MouseEventHandler(this.listBox_SearchCondition_MouseDoubleClick);
      this.listBox_SearchCondition.KeyDown += new KeyEventHandler(this.listBox_SearchCondition_KeyDown);
      this.label_ResultCount.Location = new Point(814, 7);
      this.label_ResultCount.Name = "label_ResultCount";
      this.label_ResultCount.Size = new Size(176, 23);
      this.label_ResultCount.TabIndex = 5;
      this.label_ResultCount.TextAlign = ContentAlignment.MiddleRight;
      this.richTextBox_dummy.BackColor = SystemColors.Control;
      this.richTextBox_dummy.Font = new Font("MS Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.richTextBox_dummy.Location = new Point(8, 8);
      this.richTextBox_dummy.Name = "richTextBox_dummy";
      this.richTextBox_dummy.ReadOnly = true;
      this.richTextBox_dummy.ScrollBars = RichTextBoxScrollBars.Vertical;
      this.richTextBox_dummy.Size = new Size(592, 235);
      this.richTextBox_dummy.TabIndex = 20;
      this.richTextBox_dummy.Text = "";
      this.richTextBox_dummy.Visible = false;
      this.splitter1.Location = new Point(0, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new Size(3, 548);
      this.splitter1.TabIndex = 21;
      this.splitter1.TabStop = false;
      this.splitContainer_Horizontal.BorderStyle = BorderStyle.Fixed3D;
      this.splitContainer_Horizontal.Dock = DockStyle.Fill;
      this.splitContainer_Horizontal.Location = new Point(3, 0);
      this.splitContainer_Horizontal.Name = "splitContainer_Horizontal";
      this.splitContainer_Horizontal.Orientation = Orientation.Horizontal;
      this.splitContainer_Horizontal.Panel1.Controls.Add((Control) this.splitContainer1);
      this.splitContainer_Horizontal.Panel1MinSize = 250;
      this.splitContainer_Horizontal.Panel2.Controls.Add((Control) this.label_ResultCount);
      this.splitContainer_Horizontal.Panel2.Controls.Add((Control) this.listView_Result);
      this.splitContainer_Horizontal.Panel2.Resize += new EventHandler(this.splitContainer_Horizontal_Panel2_Resize);
      this.splitContainer_Horizontal.Size = new Size(1005, 548);
      this.splitContainer_Horizontal.SplitterDistance = 250;
      this.splitContainer_Horizontal.TabIndex = 22;
      this.splitContainer1.BorderStyle = BorderStyle.Fixed3D;
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Panel1.AutoScroll = true;
      this.splitContainer1.Panel1.Controls.Add((Control) this.groupBox1);
      this.splitContainer1.Panel1.Resize += new EventHandler(this.splitContainer1_Panel1_Resize);
      this.splitContainer1.Panel1MinSize = 390;
      this.splitContainer1.Panel2.Controls.Add((Control) this.richTextBox_dummy);
      this.splitContainer1.Panel2.Controls.Add((Control) this.textBox_DungeonDetail);
      this.splitContainer1.Panel2.Resize += new EventHandler(this.splitContainer1_Panel2_Resize);
      this.splitContainer1.Size = new Size(1005, 250);
      this.splitContainer1.SplitterDistance = 390;
      this.splitContainer1.TabIndex = 0;
      this.textBox_DungeonDetail.BackColor = SystemColors.Control;
      this.textBox_DungeonDetail.Font = new Font("MS Gothic", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 128);
      this.textBox_DungeonDetail.Location = new Point(8, 8);
      this.textBox_DungeonDetail.Name = "textBox_DungeonDetail";
      this.textBox_DungeonDetail.ReadOnly = true;
      this.textBox_DungeonDetail.ScrollBars = RichTextBoxScrollBars.Vertical;
      this.textBox_DungeonDetail.Size = new Size(592, 235);
      this.textBox_DungeonDetail.TabIndex = 21;
      this.textBox_DungeonDetail.Text = "";
      this.textBox_DungeonDetail.MouseMove += new MouseEventHandler(this.textBox_DungeonDetail_MouseMove);
      this.textBox_DungeonDetail.MouseDown += new MouseEventHandler(this.textBox_DungeonDetail_MouseDown);
      this.listView_Result.Columns.AddRange(new ColumnHeader[22]
      {
        this.columnHeader_Seed,
        this.columnHeader_Rank,
        this.columnHeader_MapName,
        this.columnHeader_MapName1,
        this.columnHeader_MapName2,
        this.columnHeader_MapName3,
        this.columnHeader_MapLevel,
        this.columnHeader_MapType,
        this.columnHeader_FloorCount,
        this.columnHeader_MonsterRank,
        this.columnHeader_Boss,
        this.columnHeader_SRank,
        this.columnHeader_ARank,
        this.columnHeader_BRank,
        this.columnHeader_CRank,
        this.columnHeader_DRank,
        this.columnHeader_ERank,
        this.columnHeader_FRank,
        this.columnHeader_GRank,
        this.columnHeader_HRank,
        this.columnHeader_IRank,
        this.columnHeader_Total
      });
      this.listView_Result.FullRowSelect = true;
      this.listView_Result.GridLines = true;
      this.listView_Result.Location = new Point(6, 36);
      this.listView_Result.MultiSelect = false;
      this.listView_Result.Name = "listView_Result";
      this.listView_Result.Size = new Size(988, 251);
      this.listView_Result.TabIndex = 4;
      this.listView_Result.UseCompatibleStateImageBehavior = false;
      this.listView_Result.View = View.Details;
      this.listView_Result.VirtualMode = true;
      this.listView_Result.SelectedIndexChanged += new EventHandler(this.listView_Result_SelectedIndexChanged);
      this.listView_Result.ColumnClick += new ColumnClickEventHandler(this.listView_Result_ColumnClick);
      this.listView_Result.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(this.listView_Result_RetrieveVirtualItem);
      this.listView_Result.CacheVirtualItems += new CacheVirtualItemsEventHandler(this.listView_Result_CacheVirtualItems);
      this.columnHeader_Seed.Text = "Seed";
      this.columnHeader_Seed.Width = 40;
      this.columnHeader_Rank.Text = "Rank";
      this.columnHeader_Rank.Width = 40;
      this.columnHeader_MapName.Text = "Map Name";
      this.columnHeader_MapName.Width = 153;
      this.columnHeader_MapName1.Text = "Name 1";
      this.columnHeader_MapName2.Text = "Name 2";
      this.columnHeader_MapName3.Text = "Name 3";
      this.columnHeader_MapLevel.Text = "LV";
      this.columnHeader_MapLevel.Width = 34;
      this.columnHeader_MapType.Text = "Type";
      this.columnHeader_MapType.Width = 65;
      this.columnHeader_FloorCount.DisplayIndex = 10;
      this.columnHeader_FloorCount.Text = "Floors";
      this.columnHeader_FloorCount.Width = 36;
      this.columnHeader_MonsterRank.DisplayIndex = 8;
      this.columnHeader_MonsterRank.Text = "M.Rank";
      this.columnHeader_MonsterRank.Width = 54;
      this.columnHeader_Boss.DisplayIndex = 9;
      this.columnHeader_Boss.Text = "Boss";
      this.columnHeader_Boss.Width = 114;
      this.columnHeader_SRank.Text = "S";
      this.columnHeader_SRank.Width = 20;
      this.columnHeader_ARank.Text = "A";
      this.columnHeader_ARank.Width = 20;
      this.columnHeader_BRank.Text = "B";
      this.columnHeader_BRank.Width = 20;
      this.columnHeader_CRank.Text = "C";
      this.columnHeader_CRank.Width = 20;
      this.columnHeader_DRank.Text = "D";
      this.columnHeader_DRank.Width = 20;
      this.columnHeader_ERank.Text = "E";
      this.columnHeader_ERank.Width = 20;
      this.columnHeader_FRank.Text = "F";
      this.columnHeader_FRank.Width = 20;
      this.columnHeader_GRank.Text = "G";
      this.columnHeader_GRank.Width = 20;
      this.columnHeader_HRank.Text = "H";
      this.columnHeader_HRank.Width = 20;
      this.columnHeader_IRank.Text = "I";
      this.columnHeader_IRank.Width = 20;
      this.columnHeader_Total.Text = "# treasures";
      this.columnHeader_Total.Width = 49;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1008, 548);
      this.Controls.Add((Control) this.splitContainer_Horizontal);
      this.Controls.Add((Control) this.splitter1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (MapSearchWindow);
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Treasure Map Search";
      this.Shown += new EventHandler(this.MapSearchWindow_Shown);
      this.groupBox1.ResumeLayout(false);
      this.splitContainer_Horizontal.Panel1.ResumeLayout(false);
      this.splitContainer_Horizontal.Panel2.ResumeLayout(false);
      this.splitContainer_Horizontal.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      e.Cancel = true;
      this.Visible = false;
    }

    private void MapSearchWindow_Disposed(object sender, EventArgs e)
    {
      this._mapSearchConditionEdit.Dispose();
    }

    private void button_AddCondition_Click(object sender, EventArgs e)
    {
      this._mapSearchConditionEdit.Condition = (SearchConditionBase) null;
      if (this._mapSearchConditionEdit.ShowDialog() != DialogResult.OK)
        return;
      this.listBox_SearchCondition.Items.Add((object) this._mapSearchConditionEdit.Condition);
    }

    private void EditCondition(int index)
    {
      if (index < 0 || index >= this.listBox_SearchCondition.Items.Count)
        return;
      this._mapSearchConditionEdit.Condition = this.listBox_SearchCondition.SelectedItem as SearchConditionBase;
      if (this._mapSearchConditionEdit.ShowDialog() != DialogResult.OK)
        return;
      this.listBox_SearchCondition.BeginUpdate();
      this.listBox_SearchCondition.Items.RemoveAt(index);
      this.listBox_SearchCondition.Items.Insert(index, (object) this._mapSearchConditionEdit.Condition);
      this.listBox_SearchCondition.EndUpdate();
    }

    private void RemoveCondition(int index)
    {
      if (index < 0 || index >= this.listBox_SearchCondition.Items.Count)
        return;
      this.listBox_SearchCondition.Items.RemoveAt(index);
    }

    private void listBox_SearchCondition_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.EditCondition(this.listBox_SearchCondition.IndexFromPoint(e.Location));
    }

    private void listBox_SearchCondition_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Delete)
        return;
      this.RemoveCondition(this.listBox_SearchCondition.SelectedIndex);
    }

    private void button_DeleteCondition_Click(object sender, EventArgs e)
    {
      this.RemoveCondition(this.listBox_SearchCondition.SelectedIndex);
    }

    private void button_EditCondition_Click(object sender, EventArgs e)
    {
      this.EditCondition(this.listBox_SearchCondition.SelectedIndex);
    }

    private void button_Search_Click(object sender, EventArgs e)
    {
      this._dispRenewal = true;
      this.RenewalDungeonDetail(false);
      this.listView_Result.BeginUpdate();
      this.listView_Result.Items.Clear();
      this._resultsCount = 0;
      int index1 = 0;
      for (ushort seed = 0; seed < (ushort) 32768; ++seed)
      {
        if (TreasureMapDataTable.GetReverseSeedTable(seed) != null)
        {
          for (byte index2 = 0; index2 < (byte) 12; ++index2)
          {
            bool flag = true;
            SearchDungeonData dungeonData = SearchDataFile.DungeonData[index1];
            foreach (SearchConditionBase searchConditionBase in this.listBox_SearchCondition.Items)
            {
              if (!searchConditionBase.IsHit(dungeonData))
              {
                flag = false;
                break;
              }
            }
            if (flag)
            {
              this._resultDatas[this._resultsCount] = dungeonData;
              ++this._resultsCount;
            }
            ++index1;
          }
        }
      }
      this.listView_Result.VirtualListSize = this._resultsCount;
      this.listView_Result.EndUpdate();
      this.RenewalResultInfo();
    }

    private void listView_Result_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
    {
      int index = e.ItemIndex - this._dispStartIndex;
      if (index < 0)
        index = 0;
      if (index >= this._dispItems.Length)
        index = this._dispItems.Length - 1;
      e.Item = this._dispItems[index];
    }

    private void MapSearchWindow_Shown(object sender, EventArgs e)
    {
      this._resultsCount = 0;
      this.listView_Result.VirtualListSize = 0;
      this._dispRenewal = true;
      this.RenewalResultInfo();
    }

    private void RenewalResultInfo()
    {
      this.label_ResultCount.Text = string.Format("{0} / {1}", (object) this._resultsCount, (object) SearchDataFile.TotalCount);
    }

    private void listView_Result_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
    {
      int length = e.EndIndex - e.StartIndex + 1;
      if (!this._dispRenewal && this._dispItems != null && this._dispStartIndex <= e.StartIndex && this._dispStartIndex + this._dispItems.Length > e.EndIndex || length <= 0)
        return;
      this._dispRenewal = false;
      this._dispItems = new ListViewItem[length];
      int startIndex = e.StartIndex;
      this._dispStartIndex = e.StartIndex;
      for (int index = 0; index < length; ++index)
      {
        SearchDungeonData resultData = this._resultDatas[startIndex];
        this._dispItems[index] = new ListViewItem();
        this._dispItems[index].Text = string.Format("{0:X04}", (object) resultData.Seed);
        this._dispItems[index].SubItems.Add(string.Format("{0:X02}", (object) resultData.Rank));
        this._dispItems[index].SubItems.Add(resultData.MapName);
        this._dispItems[index].SubItems.Add(resultData.MapName1);
        this._dispItems[index].SubItems.Add(resultData.MapName3);
        this._dispItems[index].SubItems.Add(resultData.MapName2);
        this._dispItems[index].SubItems.Add(resultData.MapLevel.ToString());
        this._dispItems[index].SubItems.Add(TreasureMapDataTable.TreasureMapMapTypeName_Table[(int) resultData.MapType]);
        this._dispItems[index].SubItems.Add(resultData.Depth.ToString());
        this._dispItems[index].SubItems.Add(resultData.MonsterRank.ToString());
        this._dispItems[index].SubItems.Add(MonsterDataList.List[282 + (int) resultData.Boss]);
        this._dispItems[index].SubItems.Add(resultData.SBoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.ABoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.BBoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.CBoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.DBoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.EBoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.FBoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.GBoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.HBoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.IBoxCount.ToString());
        this._dispItems[index].SubItems.Add(resultData.TotalBoxCount.ToString());
        ++startIndex;
      }
    }

    private void listView_Result_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (this._resultsCount <= 0)
        return;
      this._comparer[e.Column].Up = !this._comparer[e.Column].Up;
      Array.Sort((Array) this._resultDatas, 0, this._resultsCount, (IComparer) this._comparer[e.Column]);
      this._dispRenewal = true;
      this.listView_Result.Invalidate();
    }

    private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
    {
    }

    private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
    {
      this.richTextBox_dummy.Height = this.splitContainer1.Panel2.Height - 16;
      this.richTextBox_dummy.Width = this.splitContainer1.Panel2.Width - 16;
      this.textBox_DungeonDetail.Height = this.splitContainer1.Panel2.Height - 16;
      this.textBox_DungeonDetail.Width = this.splitContainer1.Panel2.Width - 16;
    }

    private void splitContainer_Horizontal_Panel2_Resize(object sender, EventArgs e)
    {
      this.label_ResultCount.Left = this.splitContainer_Horizontal.Panel2.Width - this.label_ResultCount.Width - 8;
      this.listView_Result.Width = this.splitContainer_Horizontal.Panel2.Width - 16;
      this.listView_Result.Height = this.splitContainer_Horizontal.Panel2.Height - this.listView_Result.Top - 8;
    }

    private void listView_Result_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._listViewItemSelection.Count > 0)
      {
        int index = this._listViewItemSelection[0];
        this._treasureMapDetailData.MapSeed = this._resultDatas[index].Seed;
        this._treasureMapDetailData.MapRank = this._resultDatas[index].Rank;
        this._treasureMapDetailData.CalculateDetail(true);
        this.RenewalDungeonDetail(true);
      }
      else
        this.RenewalDungeonDetail(false);
    }

    private void RenewalDungeonDetail(bool disp)
    {
      if (disp)
      {
        this.richTextBox_dummy.Visible = true;
        this.textBox_DungeonDetail.Text = string.Empty;
        StringBuilder stringBuilder = new StringBuilder();
        byte num1 = 0;
        for (int index = 0; index < SearchDataFile.RankList.Length; ++index)
        {
          if ((int) SearchDataFile.RankList[index] == (int) this._treasureMapDetailData.MapRank)
          {
            num1 = index != SearchDataFile.RankList.Length - 1 ? (byte) ((uint) SearchDataFile.RankList[index + 1] - 1U) : (byte) 248;
            break;
          }
        }
        stringBuilder.AppendFormat("Rank: 0x{0:X2} - 0x{1:X2}, Seed: 0x{2:X4}\n", (object) this._treasureMapDetailData.MapRank, (object) num1, (object) this._treasureMapDetailData.MapSeed);
        stringBuilder.AppendFormat("{0}\n", (object) this._treasureMapDetailData.MapName);
        if (this._treasureMapDetailData.MapRank <= (byte) 50 && num1 > (byte) 50)
        {
          stringBuilder.Append("Locations up to Rank 0x32:");
          foreach (byte lowRankValidPlace in this._treasureMapDetailData.LowRankValidPlaceList)
            stringBuilder.AppendFormat(" 0x{0:X2}({1})", (object) lowRankValidPlace, (object) TreasureMapDataTable.TreasureMapPlaceName_Table[(int) TreasureMapDataTable.TreasureMapPlace_Table[(int) lowRankValidPlace]]);
          stringBuilder.Append("\n");
          stringBuilder.Append("Locations up to Rank 0x37:");
          foreach (byte middleRankValidPlace in this._treasureMapDetailData.MiddleRankValidPlaceList)
            stringBuilder.AppendFormat(" 0x{0:X2}({1})", (object) middleRankValidPlace, (object) TreasureMapDataTable.TreasureMapPlaceName_Table[(int) TreasureMapDataTable.TreasureMapPlace_Table[(int) middleRankValidPlace]]);
        }
        else
        {
          stringBuilder.Append("Locations:");
          foreach (byte validPlace in this._treasureMapDetailData.ValidPlaceList)
            stringBuilder.AppendFormat(" 0x{0:X2}({1})", (object) validPlace, (object) TreasureMapDataTable.TreasureMapPlaceName_Table[(int) TreasureMapDataTable.TreasureMapPlace_Table[(int) validPlace]]);
        }
        stringBuilder.Append("\n");
        stringBuilder.AppendFormat("Type: {0}\n", (object) this._treasureMapDetailData.MapTypeName);
        stringBuilder.AppendFormat("Floors: {0}\n", (object) this._treasureMapDetailData.FloorCount);
        stringBuilder.AppendFormat("Monster rank: {0}\n", (object) this._treasureMapDetailData.MonsterRank);
        stringBuilder.AppendFormat("Boss: {0}\n", (object) this._treasureMapDetailData.BossName);
        int treasureBoxCount = this._treasureMapDetailData.GetTreasureBoxCount(0);
        stringBuilder.AppendFormat("Number of chests: {0}\n", (object) treasureBoxCount);
        if (treasureBoxCount > 0)
        {
          stringBuilder.Append(" By rank:\n  ");
          for (int rank = 10; rank > 0; --rank)
            stringBuilder.AppendFormat(" {0}:{1}", (object) MapSearchWindow._treasureBoxRankSymbol[0, rank - 1], (object) this._treasureMapDetailData.GetTreasureBoxCount(rank));
          stringBuilder.Append("\n");
          stringBuilder.Append(" By floor:\n");
          for (int floor = 0; floor < this._treasureMapDetailData.FloorCount; ++floor)
          {
            if (this._treasureMapDetailData.GetTreasureBoxCountPerFloor(floor) > 0)
            {
              stringBuilder.AppendFormat("   B{0:D2}:", (object) (floor + 1));
              foreach (TreasureBoxInfo treasureBoxInfo in this._treasureMapDetailData.TreasureBoxInfoList[floor])
                stringBuilder.AppendFormat(" {0}", (object) MapSearchWindow._treasureBoxRankSymbol[0, treasureBoxInfo.Rank - 1]);
              stringBuilder.Append("\n");
            }
          }
        }
        for (int floor = 0; floor < this._treasureMapDetailData.FloorCount; ++floor)
        {
          this._treasureBoxCount[floor] = 0;
          byte[,] floorMap = this._treasureMapDetailData.GetFloorMap(floor);
          if (floorMap != null)
          {
            stringBuilder.Append("\n");
            stringBuilder.AppendFormat("B{0:D2}\n", (object) (floor + 1));
            for (int y = 0; y < this._treasureMapDetailData.GetFloorHeight(floor); ++y)
            {
              for (int x = 0; x < this._treasureMapDetailData.GetFloorWidth(floor); ++x)
              {
                if (floorMap[y, x] == (byte) 1 || floorMap[y, x] == (byte) 3)
                  stringBuilder.Append("■");
                else if (floorMap[y, x] == (byte) 4)
                {
                  if (this._treasureMapDetailData.IsUpStep(floor, x, y))
                    stringBuilder.Append("△");
                  else
                    stringBuilder.Append("　");
                }
                else if (floorMap[y, x] == (byte) 5)
                  stringBuilder.Append("▽");
                else if (floorMap[y, x] == (byte) 6)
                {
                  int num2 = this._treasureMapDetailData.IsTreasureBoxRank(floor, x, y);
                  if (num2 > 0)
                  {
                    int treasureBoxIndex = this._treasureMapDetailData.GetTreasureBoxIndex(floor, x, y);
                    this._treasureBoxIndexes[floor, treasureBoxIndex] = stringBuilder.Length;
                    stringBuilder.AppendFormat("{0}", (object) MapSearchWindow._treasureBoxRankSymbol[1, num2 - 1]);
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
              int rank = this._treasureMapDetailData.TreasureBoxInfoList[floor][index1].Rank;
              int index2 = this._treasureMapDetailData.TreasureBoxInfoList[floor][index1].Index;
              string treasureBoxItem = this._treasureMapDetailData.GetTreasureBoxItem(floor, index2, 2);
              stringBuilder.AppendFormat("({0:D2}, {1:D2}) {2} {3}\n", (object) this._treasureMapDetailData.TreasureBoxInfoList[floor][index1].X, (object) this._treasureMapDetailData.TreasureBoxInfoList[floor][index1].Y, (object) MapSearchWindow._treasureBoxRankSymbol[1, rank - 1], (object) treasureBoxItem);
            }
          }
        }
        this.textBox_DungeonDetail.Text = stringBuilder.ToString();
        using (Font font = new Font("ＭＳ ゴシック", 9f, FontStyle.Underline, GraphicsUnit.Point, (byte) 128))
        {
          for (int index3 = 0; index3 < this._treasureMapDetailData.FloorCount; ++index3)
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
        this.textBox_DungeonDetail.Enabled = true;
        this.richTextBox_dummy.Visible = false;
      }
      else
      {
        this.textBox_DungeonDetail.Enabled = false;
        this.textBox_DungeonDetail.Text = string.Empty;
      }
    }

    private void textBox_DungeonDetail_MouseMove(object sender, MouseEventArgs e)
    {
      if (this._listViewItemSelection.Count <= 0)
        return;
      int indexFromPosition = this.textBox_DungeonDetail.GetCharIndexFromPosition(new Point(e.X - 5, e.Y));
      for (int index1 = 0; index1 < this._treasureMapDetailData.FloorCount; ++index1)
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
      if (this._listViewItemSelection.Count <= 0)
        return;
      int indexFromPosition = this.textBox_DungeonDetail.GetCharIndexFromPosition(new Point(e.X - 5, e.Y));
      for (int floor = 0; floor < this._treasureMapDetailData.FloorCount; ++floor)
      {
        for (int boxIndex = 0; boxIndex < this._treasureBoxCount[floor]; ++boxIndex)
        {
          if (this._treasureBoxIndexes[floor, boxIndex] == indexFromPosition)
          {
            this.textBox_DungeonDetail.Cursor = Cursors.Arrow;
            using (TreasureBoxItemTableList boxItemTableList = new TreasureBoxItemTableList(this._treasureMapDetailData, floor, boxIndex))
            {
              foreach (TreasureBoxInfo treasureBoxInfo in this._treasureMapDetailData.TreasureBoxInfoList[floor])
              {
                if (treasureBoxInfo.Index == boxIndex)
                  boxItemTableList.Text = string.Format("Item Table B{0} ({1}, {2}) {3}", (object) (floor + 1), (object) treasureBoxInfo.X, (object) treasureBoxInfo.Y, (object) MapSearchWindow._treasureBoxRankSymbol[0, treasureBoxInfo.Rank - 1]);
              }
              int num = (int) boxItemTableList.ShowDialog();
              return;
            }
          }
        }
      }
      this.textBox_DungeonDetail.Cursor = Cursors.IBeam;
    }

    private class ABoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.ABoxCount - (int) searchDungeonData2.ABoxCount : (int) searchDungeonData2.ABoxCount - (int) searchDungeonData1.ABoxCount;
      }
    }

    private class BBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.BBoxCount - (int) searchDungeonData2.BBoxCount : (int) searchDungeonData2.BBoxCount - (int) searchDungeonData1.BBoxCount;
      }
    }

    private class BossComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.Boss - (int) searchDungeonData2.Boss : (int) searchDungeonData2.Boss - (int) searchDungeonData1.Boss;
      }
    }

    private class CBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.CBoxCount - (int) searchDungeonData2.CBoxCount : (int) searchDungeonData2.CBoxCount - (int) searchDungeonData1.CBoxCount;
      }
    }

    private abstract class ComparerBase : IComparer
    {
      protected bool _up;

      public bool Up
      {
        get => this._up;
        set => this._up = value;
      }

      public abstract int Compare(object x, object y);
    }

    private class DBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.DBoxCount - (int) searchDungeonData2.DBoxCount : (int) searchDungeonData2.DBoxCount - (int) searchDungeonData1.DBoxCount;
      }
    }

    private class DepthComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.Depth - (int) searchDungeonData2.Depth : (int) searchDungeonData2.Depth - (int) searchDungeonData1.Depth;
      }
    }

    private class EBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.EBoxCount - (int) searchDungeonData2.EBoxCount : (int) searchDungeonData2.EBoxCount - (int) searchDungeonData1.EBoxCount;
      }
    }

    private class FBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.FBoxCount - (int) searchDungeonData2.FBoxCount : (int) searchDungeonData2.FBoxCount - (int) searchDungeonData1.FBoxCount;
      }
    }

    private class GBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.GBoxCount - (int) searchDungeonData2.GBoxCount : (int) searchDungeonData2.GBoxCount - (int) searchDungeonData1.GBoxCount;
      }
    }

    private class HBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.HBoxCount - (int) searchDungeonData2.HBoxCount : (int) searchDungeonData2.HBoxCount - (int) searchDungeonData1.HBoxCount;
      }
    }

    private class IBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.IBoxCount - (int) searchDungeonData2.IBoxCount : (int) searchDungeonData2.IBoxCount - (int) searchDungeonData1.IBoxCount;
      }
    }

    private class MapLVComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.MapLevel - (int) searchDungeonData2.MapLevel : (int) searchDungeonData2.MapLevel - (int) searchDungeonData1.MapLevel;
      }
    }

    private class MapName1Comparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.MapName1Index - (int) searchDungeonData2.MapName1Index : (int) searchDungeonData2.MapName1Index - (int) searchDungeonData1.MapName1Index;
      }
    }

    private class MapName2Comparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.MapName2Index - (int) searchDungeonData2.MapName2Index : (int) searchDungeonData2.MapName2Index - (int) searchDungeonData1.MapName2Index;
      }
    }

    private class MapName3Comparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.MapName3Index - (int) searchDungeonData2.MapName3Index : (int) searchDungeonData2.MapName3Index - (int) searchDungeonData1.MapName3Index;
      }
    }

    private class MapNameComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        int num1 = (int) searchDungeonData1.MapName1Index + ((int) searchDungeonData1.MapName2Index << 5) + ((int) searchDungeonData1.MapName3Index << 10) + ((int) searchDungeonData1.MapLevel << 15);
        int num2 = (int) searchDungeonData2.MapName1Index + ((int) searchDungeonData2.MapName2Index << 5) + ((int) searchDungeonData2.MapName3Index << 10) + ((int) searchDungeonData2.MapLevel << 15);
        return this._up ? num1 - num2 : num2 - num1;
      }
    }

    private class MapTypeComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.MapType - (int) searchDungeonData2.MapType : (int) searchDungeonData2.MapType - (int) searchDungeonData1.MapType;
      }
    }

    private class MonsterRankComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.MonsterRank - (int) searchDungeonData2.MonsterRank : (int) searchDungeonData2.MonsterRank - (int) searchDungeonData1.MonsterRank;
      }
    }

    private class RankComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.Rank - (int) searchDungeonData2.Rank : (int) searchDungeonData2.Rank - (int) searchDungeonData1.Rank;
      }
    }

    private class SBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.SBoxCount - (int) searchDungeonData2.SBoxCount : (int) searchDungeonData2.SBoxCount - (int) searchDungeonData1.SBoxCount;
      }
    }

    private class SeedComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.Seed - (int) searchDungeonData2.Seed : (int) searchDungeonData2.Seed - (int) searchDungeonData1.Seed;
      }
    }

    private class TotalBoxComparer : MapSearchWindow.ComparerBase, IComparer
    {
      public override int Compare(object x, object y)
      {
        SearchDungeonData searchDungeonData1 = (SearchDungeonData) x;
        SearchDungeonData searchDungeonData2 = (SearchDungeonData) y;
        return this._up ? (int) searchDungeonData1.TotalBoxCount - (int) searchDungeonData2.TotalBoxCount : (int) searchDungeonData2.TotalBoxCount - (int) searchDungeonData1.TotalBoxCount;
      }
    }
  }
}
