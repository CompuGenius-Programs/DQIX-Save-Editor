// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MainWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using DQ9_Cheat.Controls;
using DQ9_Cheat.Controls.MapSearch;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.MapSearch;
using JS_Framework.Controls;

namespace DQ9_Cheat;

public class MainWindow : Form
{
    private const string ApplicationTitle = "Dragon Quest IX Save Data Editor";
    private static MainWindow _instance;
    private AlchemyDataControl _alchemyDataControl;
    private bool _initialized;
    private ItemCollectionDataControl _itemCollectionDataControl;
    private ItemDataControl _itemDataControl;
    private readonly MapSearchWindow _mapSearchWindow;
    private MonsterDataControl _monsterDataControl;
    private ProcessFlagControl _processFlagControl;
    private QuestDataControl _questDataControl;
    private SmartItemDataControl _smartItemDataControl;
    private TitleDataControl _titleDataControl;
    private IContainer components;
    private MenuStrip mainMenu;
    private ToolStrip mainToolbar;
    private ToolStripMenuItem menuEdit;
    private ToolStripMenuItem menuEdit_CopyData1;
    private ToolStripMenuItem menuEdit_CopyData2;
    private ToolStripMenuItem menuEdit_Redo;
    private ToolStripMenuItem menuEdit_RemoveIntermission;
    private ToolStripMenuItem menuEdit_Undo;
    private ToolStripMenuItem menuFile;
    private ToolStripMenuItem menuFile_Exit;
    private ToolStripMenuItem menuFile_Open;
    private ToolStripMenuItem menuFile_Save;
    private ToolStripMenuItem menuFile_SaveAs;
    private ToolStripMenuItem menuTool;
    private ToolStripMenuItem menuTool_CreateSearchData;
    private ToolStripMenuItem menuTool_SearchMap;
    private ToolStripMenuItem menuVersion;
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;
    private TabPage tabPage_Alchemy;
    private TabPage tabPage_basisData;
    private TabPage tabPage_CharacterData;
    private TabPage tabPage_FirstClearData;
    private TabPage tabPage_Item;
    private TabPage tabPage_ItemCollection;
    private TabPage tabPage_Monster;
    private TabPage tabPage_ProcessFlag;
    private TabPage tabPage_Quest;
    private TabPage tabPage_Rikka;
    private TabPage tabPage_Smart;
    private TabPage tabPage_Tilte;
    private TabPage tabPage_Treasure;
    private TabPage tabPage_WifiShopping;
    private TextBox textBox_dummy;
    private ToolStripButton toolButton_Open;
    private ToolStripButton toolButton_Redo;
    private ToolStripButton toolButton_Save;
    private ToolStripButton toolButton_SaveAs;
    private ToolStripButton toolButton_Undo;
    private ToolStripContainer toolStripContainer1;
    private ToolStripRadioButton toolStripRadioButton_Data1;
    private ToolStripRadioButton toolStripRadioButton_Data2;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripSeparator toolStripSeparator5;

    private MainWindow()
    {
        _mapSearchWindow = new MapSearchWindow();
        Disposed += MainWindow_Disposed;
    }

    public float DpiX { get; private set; }

    public float DpiY { get; private set; }

    public float DpiRateX { get; private set; }

    public float DpiRateY { get; private set; }

    public bool SaveCancel { get; set; }

    public static MainWindow Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MainWindow();
            return _instance;
        }
    }

    public TabControl TabControl { get; private set; }

    public StatusStrip StatusStrip { get; private set; }

    public ToolStripStatusLabel StatusBarText { get; private set; }

    public BasisDataControl BasisDataControl { get; private set; }

    public CharacterDataControl CharacterDataControl { get; private set; }

    public FirstClearDataControl FirstClearDataControl { get; private set; }

    public RikkaInnDataControl RikkaInnDataControl { get; private set; }

    public TreasureMapDataControl TreasureMapDataControl { get; private set; }

    public WifiShoppingDataControl WifiShopDataControl { get; private set; }

    private void MainWindow_Disposed(object sender, EventArgs e)
    {
        _mapSearchWindow.Dispose();
    }

    public void Initialize()
    {
        if (_initialized)
            return;
        using (var graphics = Graphics.FromHwnd(Handle))
        {
            DpiX = graphics.DpiX;
            DpiY = graphics.DpiY;
            DpiRateX = DpiX / 96f;
            DpiRateY = DpiY / 96f;
        }

        InitializeComponent();
        CharacterDataControl.Initialize();
        _itemDataControl.Initialize();
        _titleDataControl.Initialize();
        _smartItemDataControl.Initialize();
        _itemCollectionDataControl.Initialize();
        _alchemyDataControl.Initialize();
        SaveDataManager.Instance.UndoRedoMgr.SavedIndexChanged += UndoRedoMgr_SavedIndexChanged;
        _initialized = true;
        var commandLineArgs = Environment.GetCommandLineArgs();
        if (commandLineArgs.Length <= 1 || !File.Exists(commandLineArgs[1]))
            return;
        OpenFile(commandLineArgs[1]);
    }

    private void UndoRedoMgr_SavedIndexChanged()
    {
        RenewalCaption();
        RenewalToolbar();
        RenewalMenu();
    }

    private void RenewalToolbar()
    {
        toolButton_Save.Enabled = SaveDataManager.Instance.DataFilePath != null;
        toolButton_SaveAs.Enabled = SaveDataManager.Instance.DataFilePath != null;
        toolButton_Undo.Enabled = SaveDataManager.Instance.UndoRedoMgr.IsUndo;
        toolButton_Redo.Enabled = SaveDataManager.Instance.UndoRedoMgr.IsRedo;
        toolStripRadioButton_Data1.Enabled = SaveDataManager.Instance.DataFilePath != null;
        toolStripRadioButton_Data2.Enabled = SaveDataManager.Instance.DataFilePath != null &&
                                             SaveDataManager.Instance.IsThereIntermissionData;
        if (!toolStripRadioButton_Data2.Checked || toolStripRadioButton_Data2.Enabled)
            return;
        toolStripRadioButton_Data1.Checked = true;
    }

    private void RenewalMenu()
    {
        menuFile_Save.Enabled = SaveDataManager.Instance.DataFilePath != null;
        menuFile_SaveAs.Enabled = SaveDataManager.Instance.DataFilePath != null;
        menuEdit_Undo.Enabled = SaveDataManager.Instance.UndoRedoMgr.IsUndo;
        menuEdit_Redo.Enabled = SaveDataManager.Instance.UndoRedoMgr.IsRedo;
        menuEdit_CopyData1.Enabled = true;
        menuEdit_CopyData2.Enabled = SaveDataManager.Instance.GetSaveData(1).IsIntermission.Value == 1;
        menuEdit_RemoveIntermission.Enabled = SaveDataManager.Instance.GetSaveData(1).IsIntermission.Value == 1;
    }

    public void FocusControl(Control control)
    {
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void menuFile_Exit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void toolButton_Open_Click(object sender, EventArgs e)
    {
        OpenFile();
    }

    private void OpenFile()
    {
        OpenFile(null);
    }

    private bool OpenFile(string filePath)
    {
        textBox_dummy.Focus();
        if (!ConfirmSave())
            return false;
        if (filePath == null)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return false;
            filePath = openFileDialog.FileName;
        }

        if (File.Exists(filePath))
        {
            using (var input = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var br = new BinaryReader(input))
                {
                    long num1 = SaveDataManager.Instance.CheckFile(br);
                    if (num1 == -1L)
                    {
                        var num2 = (int)MessageBox.Show("File is either in incorrect format or corrupted. Load failed.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }

                    input.Position = num1;
                    SaveDataManager.Instance.ReadData(br);
                }
            }

            SaveDataManager.Instance.DataFilePath = filePath;
            TabControl.Enabled = true;
            OnLoaded();
            RenewalControl();
            RenewalCaption();
            RenewalToolbar();
            RenewalMenu();
        }

        return true;
    }

    private bool SaveFile()
    {
        return SaveFile(false);
    }

    private bool SaveFile(bool isNewFile)
    {
        textBox_dummy.Focus();
        if (SaveCancel)
            return false;
        var path = SaveDataManager.Instance.DataFilePath;
        if (!File.Exists(path) || path == null || isNewFile)
        {
            if (string.IsNullOrEmpty(path))
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(path);
                saveFileDialog.FileName = Path.GetFileName(path);
            }

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return false;
            path = saveFileDialog.FileName;
        }

        using (var output = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            using (var bw = new BinaryWriter(output))
            {
                SaveDataManager.Instance.WriteData(bw);
            }
        }

        RenewalCaption();
        return true;
    }

    private bool ConfirmSave()
    {
        if (SaveDataManager.Instance.UndoRedoMgr.EditFlag)
            switch (MessageBox.Show("Do you want to save the changes?", "Save - Dragon Quest IX Save Data Editor",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
            {
                case DialogResult.Cancel:
                    return false;
                case DialogResult.Yes:
                    SaveFile();
                    break;
            }

        return true;
    }

    private void RenewalCaption()
    {
        string str;
        if (SaveDataManager.Instance.DataFilePath != null)
        {
            var dataFilePath = SaveDataManager.Instance.DataFilePath;
            if (SaveDataManager.Instance.UndoRedoMgr.EditFlag)
                dataFilePath += " *";
            str = dataFilePath + " - Dragon Quest IX Save Data Editor";
        }
        else
        {
            str = "Dragon Quest IX Save Data Editor";
        }

        Text = str;
    }

    private void OnLoaded()
    {
        BasisDataControl.DataFileLoaded();
        FirstClearDataControl.DataFileLoaded();
        CharacterDataControl.DataFileLoaded();
        RikkaInnDataControl.DataFileLoaded();
        _itemDataControl.DataFileLoaded();
        _processFlagControl.DataFileLoaded();
        _questDataControl.DataFileLoaded();
        _titleDataControl.DataFileLoaded();
        TreasureMapDataControl.DataFileLoaded();
        _monsterDataControl.DataFileLoaded();
        _smartItemDataControl.DataFileLoaded();
        _itemCollectionDataControl.DataFileLoaded();
        _alchemyDataControl.DataFileLoaded();
        WifiShopDataControl.DataFileLoaded();
    }

    private void RenewalControl()
    {
        BasisDataControl.ValueUpdated();
        FirstClearDataControl.ValueUpdated();
        CharacterDataControl.ValueUpdated();
        RikkaInnDataControl.ValueUpdated();
        _itemDataControl.ValueUpdated();
        _processFlagControl.ValueUpdated();
        _questDataControl.ValueUpdated();
        _titleDataControl.ValueUpdated();
        TreasureMapDataControl.ValueUpdated();
        _monsterDataControl.ValueUpdated();
        _smartItemDataControl.ValueUpdated();
        _itemCollectionDataControl.ValueUpdated();
        _alchemyDataControl.ValueUpdated();
        WifiShopDataControl.ValueUpdated();
    }

    private void menuFile_Save_Click(object sender, EventArgs e)
    {
        SaveFile();
    }

    private void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
        {
            OpenFile();
        }
        else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
        {
            if (SaveDataManager.Instance.DataFilePath == null)
                return;
            SaveFile();
        }
        else if (e.KeyCode == Keys.S && e.Modifiers == (Keys.Shift | Keys.Control))
        {
            if (SaveDataManager.Instance.DataFilePath == null)
                return;
            SaveFile(true);
        }
        else if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
        {
            Undo();
        }
        else
        {
            if (e.KeyCode != Keys.Y || e.Modifiers != Keys.Control)
                return;
            Redo();
        }
    }

    private void Undo()
    {
        if (!SaveDataManager.Instance.UndoRedoMgr.Undo())
            return;
        SaveDataManager.Instance.SaveData.OnUndo();
        RenewalControl();
        RenewalMenu();
    }

    private void Redo()
    {
        if (!SaveDataManager.Instance.UndoRedoMgr.Redo())
            return;
        SaveDataManager.Instance.SaveData.OnRedo();
        RenewalControl();
        RenewalMenu();
    }

    private void menuEdit_Undo_Click(object sender, EventArgs e)
    {
        Undo();
    }

    private void menuEdit_Redo_Click(object sender, EventArgs e)
    {
        Redo();
    }

    private void toolButton_Undo_Click(object sender, EventArgs e)
    {
        Undo();
    }

    private void toolButton_Redo_Click(object sender, EventArgs e)
    {
        Redo();
    }

    private void toolStripRadioButton_Data_CheckedChanged(object sender, EventArgs e)
    {
        if (!(sender is ToolStripRadioButton stripRadioButton) ||
            SaveDataManager.Instance.SelectedDataIndex == (int)stripRadioButton.Tag)
            return;
        SaveDataManager.Instance.SelectedDataIndex = (int)stripRadioButton.Tag;
        RenewalControl();
    }

    private void toolStripRadioButtonData_Click(object sender, EventArgs e)
    {
    }

    private void toolButton_Save_Click(object sender, EventArgs e)
    {
        SaveFile();
    }

    private void menuFile_SaveAs_Click(object sender, EventArgs e)
    {
        SaveFile(true);
    }

    private void toolButton_SaveAs_Click(object sender, EventArgs e)
    {
        SaveFile(true);
    }

    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (ConfirmSave())
            return;
        e.Cancel = true;
    }

    private void MainWindow_DragDrop(object sender, DragEventArgs e)
    {
        if (!IsAllowDragDrop(e))
            return;
        OpenFile((e.Data.GetData(DataFormats.FileDrop) as string[])[0]);
    }

    private void MainWindow_DragOver(object sender, DragEventArgs e)
    {
        e.Effect = IsAllowDragDrop(e) ? DragDropEffects.Copy : DragDropEffects.None;
    }

    private bool IsAllowDragDrop(DragEventArgs e)
    {
        return e.Data.GetDataPresent(DataFormats.FileDrop) && e.Data.GetData(DataFormats.FileDrop) is string[] data &&
               data.Length == 1 && File.Exists(data[0]);
    }

    private void menuFile_Open_Click(object sender, EventArgs e)
    {
        OpenFile();
    }

    private void menuEdit_CopyData1_Click(object sender, EventArgs e)
    {
        SaveDataManager.Instance.CopyIntermissionData(0);
        RenewalControl();
    }

    private void menuEdit_CopyData2_Click(object sender, EventArgs e)
    {
        SaveDataManager.Instance.CopyIntermissionData(1);
        RenewalControl();
    }

    private void menuVersion_Click(object sender, EventArgs e)
    {
        using (var aboutBox = new AboutBox())
        {
            var num = (int)aboutBox.ShowDialog();
        }
    }

    private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        RenewalWindowSize();
    }

    private void menuEdit_RemoveIntermission_Click(object sender, EventArgs e)
    {
        SaveDataManager.Instance.RemoveIntermissionData();
        RenewalMenu();
    }

    private void RenewalWindowSize()
    {
        var num1 = (int)(519.0 * DpiRateX);
        var num2 = (int)(848.0 * DpiRateY);
        foreach (Control control in (ArrangedElementCollection)TabControl.SelectedTab.Controls)
            if (control is DataControlBase dataControlBase)
            {
                switch (dataControlBase)
                {
                    case CharacterDataControl _:
                    case RikkaInnDataControl _:
                        num1 = (int)(599.0 * DpiRateY);
                        break;
                    default:
                        num1 = (int)(519.0 * DpiRateY);
                        break;
                }

                num2 = !(dataControlBase is RikkaInnDataControl) ? (int)(848.0 * DpiRateX) : (int)(1020.0 * DpiRateX);
                break;
            }

        var height = num1 + toolStripContainer1.TopToolStripPanel.Height +
                     toolStripContainer1.BottomToolStripPanel.Height;
        Size = new Size(
            num2 + toolStripContainer1.LeftToolStripPanel.Width + toolStripContainer1.RightToolStripPanel.Width,
            height);
    }

    private void toolStripContainer_ToolStripPanel_Resize(object sender, EventArgs e)
    {
        RenewalWindowSize();
    }

    private void menuTool_CreateSearchData_Click(object sender, EventArgs e)
    {
        if (File.Exists(SearchDataFile.FilePath) && MessageBox.Show("DB file already exists.\nRebuild it?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            return;
        var num = (int)new CreateMapDataBaseDialog().ShowDialog();
    }

    private void menuTool_SearchMap_Click(object sender, EventArgs e)
    {
        if (!File.Exists(SearchDataFile.FilePath))
        {
            var num = (int)MessageBox.Show(
                "Could not find file MapSearch.dat.\nPlease create the file using \"Create map data\".", "Information",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
            _mapSearchWindow.Show();
            _mapSearchWindow.Activate();
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        var componentResourceManager = new ComponentResourceManager(typeof(MainWindow));
        StatusStrip = new StatusStrip();
        StatusBarText = new ToolStripStatusLabel();
        openFileDialog = new OpenFileDialog();
        saveFileDialog = new SaveFileDialog();
        textBox_dummy = new TextBox();
        toolStripContainer1 = new ToolStripContainer();
        TabControl = new TabControl();
        tabPage_basisData = new TabPage();
        BasisDataControl = new BasisDataControl();
        tabPage_FirstClearData = new TabPage();
        FirstClearDataControl = new FirstClearDataControl();
        tabPage_ProcessFlag = new TabPage();
        _processFlagControl = new ProcessFlagControl();
        tabPage_CharacterData = new TabPage();
        CharacterDataControl = new CharacterDataControl();
        tabPage_Rikka = new TabPage();
        RikkaInnDataControl = new RikkaInnDataControl();
        tabPage_Quest = new TabPage();
        _questDataControl = new QuestDataControl();
        tabPage_Item = new TabPage();
        _itemDataControl = new ItemDataControl();
        tabPage_Monster = new TabPage();
        _monsterDataControl = new MonsterDataControl();
        tabPage_Smart = new TabPage();
        _smartItemDataControl = new SmartItemDataControl();
        tabPage_ItemCollection = new TabPage();
        _itemCollectionDataControl = new ItemCollectionDataControl();
        tabPage_Alchemy = new TabPage();
        _alchemyDataControl = new AlchemyDataControl();
        tabPage_Tilte = new TabPage();
        _titleDataControl = new TitleDataControl();
        tabPage_Treasure = new TabPage();
        TreasureMapDataControl = new TreasureMapDataControl();
        tabPage_WifiShopping = new TabPage();
        WifiShopDataControl = new WifiShoppingDataControl();
        mainMenu = new MenuStrip();
        menuFile = new ToolStripMenuItem();
        menuFile_Open = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        menuFile_Save = new ToolStripMenuItem();
        menuFile_SaveAs = new ToolStripMenuItem();
        toolStripSeparator3 = new ToolStripSeparator();
        menuFile_Exit = new ToolStripMenuItem();
        menuEdit = new ToolStripMenuItem();
        menuEdit_Undo = new ToolStripMenuItem();
        menuEdit_Redo = new ToolStripMenuItem();
        toolStripSeparator5 = new ToolStripSeparator();
        menuEdit_CopyData1 = new ToolStripMenuItem();
        menuEdit_CopyData2 = new ToolStripMenuItem();
        menuEdit_RemoveIntermission = new ToolStripMenuItem();
        menuTool = new ToolStripMenuItem();
        menuTool_SearchMap = new ToolStripMenuItem();
        menuTool_CreateSearchData = new ToolStripMenuItem();
        menuVersion = new ToolStripMenuItem();
        mainToolbar = new ToolStrip();
        toolButton_Open = new ToolStripButton();
        toolButton_Save = new ToolStripButton();
        toolButton_SaveAs = new ToolStripButton();
        toolStripSeparator4 = new ToolStripSeparator();
        toolButton_Undo = new ToolStripButton();
        toolButton_Redo = new ToolStripButton();
        toolStripSeparator1 = new ToolStripSeparator();
        toolStripRadioButton_Data1 = new ToolStripRadioButton();
        toolStripRadioButton_Data2 = new ToolStripRadioButton();
        StatusStrip.SuspendLayout();
        toolStripContainer1.ContentPanel.SuspendLayout();
        toolStripContainer1.TopToolStripPanel.SuspendLayout();
        toolStripContainer1.SuspendLayout();
        TabControl.SuspendLayout();
        tabPage_basisData.SuspendLayout();
        tabPage_FirstClearData.SuspendLayout();
        tabPage_ProcessFlag.SuspendLayout();
        tabPage_CharacterData.SuspendLayout();
        tabPage_Rikka.SuspendLayout();
        tabPage_Quest.SuspendLayout();
        tabPage_Item.SuspendLayout();
        tabPage_Monster.SuspendLayout();
        tabPage_Smart.SuspendLayout();
        tabPage_ItemCollection.SuspendLayout();
        tabPage_Alchemy.SuspendLayout();
        tabPage_Tilte.SuspendLayout();
        tabPage_Treasure.SuspendLayout();
        tabPage_WifiShopping.SuspendLayout();
        mainMenu.SuspendLayout();
        mainToolbar.SuspendLayout();
        SuspendLayout();
        StatusStrip.Items.AddRange(new ToolStripItem[1]
        {
            StatusBarText
        });
        StatusStrip.Location = new Point(0, 521);
        StatusStrip.Name = "StatusStrip";
        StatusStrip.Size = new Size(842, 22);
        StatusStrip.SizingGrip = false;
        StatusStrip.TabIndex = 0;
        StatusStrip.Text = "statusStrip1";
        StatusBarText.AutoSize = false;
        StatusBarText.Name = "StatusBarText";
        StatusBarText.Size = new Size(600, 17);
        StatusBarText.TextAlign = ContentAlignment.MiddleLeft;
        openFileDialog.DefaultExt = "sav";
        openFileDialog.Filter =
            "Save (*.sav)|*.sav|DUC (*.duc)|*.duc|DAT (*.dat)|*.dat|DSV (*.dsv)|*.dsv|Show All (*.*)|*.*";
        saveFileDialog.DefaultExt = "sav";
        saveFileDialog.Filter =
            "Save (*.sav)|*.sav|DUC (*.duc)|*.duc|DAT (*.dat)|*.dat|DSV (*.dsv)|*.dsv|Show All (*.*)|*.*";
        textBox_dummy.Location = new Point(-200, -200);
        textBox_dummy.Name = "textBox_dummy";
        textBox_dummy.Size = new Size(100, 19);
        textBox_dummy.TabIndex = 2;
        toolStripContainer1.BottomToolStripPanel.Resize += toolStripContainer_ToolStripPanel_Resize;
        toolStripContainer1.ContentPanel.Controls.Add(TabControl);
        toolStripContainer1.ContentPanel.Size = new Size(842, 470);
        toolStripContainer1.Dock = DockStyle.Fill;
        toolStripContainer1.LeftToolStripPanel.Resize += toolStripContainer_ToolStripPanel_Resize;
        toolStripContainer1.Location = new Point(0, 0);
        toolStripContainer1.Name = "toolStripContainer1";
        toolStripContainer1.RightToolStripPanel.Resize += toolStripContainer_ToolStripPanel_Resize;
        toolStripContainer1.Size = new Size(842, 521);
        toolStripContainer1.TabIndex = 1;
        toolStripContainer1.Text = "toolStripContainer1";
        toolStripContainer1.TopToolStripPanel.Controls.Add(mainMenu);
        toolStripContainer1.TopToolStripPanel.Controls.Add(mainToolbar);
        toolStripContainer1.TopToolStripPanel.Resize += toolStripContainer_ToolStripPanel_Resize;
        TabControl.Controls.Add(tabPage_basisData);
        TabControl.Controls.Add(tabPage_FirstClearData);
        TabControl.Controls.Add(tabPage_ProcessFlag);
        TabControl.Controls.Add(tabPage_CharacterData);
        TabControl.Controls.Add(tabPage_Rikka);
        TabControl.Controls.Add(tabPage_Quest);
        TabControl.Controls.Add(tabPage_Item);
        TabControl.Controls.Add(tabPage_Monster);
        TabControl.Controls.Add(tabPage_Smart);
        TabControl.Controls.Add(tabPage_ItemCollection);
        TabControl.Controls.Add(tabPage_Alchemy);
        TabControl.Controls.Add(tabPage_Tilte);
        TabControl.Controls.Add(tabPage_Treasure);
        TabControl.Controls.Add(tabPage_WifiShopping);
        TabControl.Dock = DockStyle.Fill;
        TabControl.Enabled = false;
        TabControl.Location = new Point(0, 0);
        TabControl.Name = "TabControl";
        TabControl.SelectedIndex = 0;
        TabControl.Size = new Size(842, 470);
        TabControl.TabIndex = 0;
        TabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
        tabPage_basisData.Controls.Add(BasisDataControl);
        tabPage_basisData.Location = new Point(4, 22);
        tabPage_basisData.Name = "tabPage_basisData";
        tabPage_basisData.Padding = new Padding(3);
        tabPage_basisData.Size = new Size(834, 444);
        tabPage_basisData.TabIndex = 0;
        tabPage_basisData.Text = "General";
        tabPage_basisData.UseVisualStyleBackColor = true;
        BasisDataControl.Dock = DockStyle.Fill;
        BasisDataControl.Location = new Point(3, 3);
        BasisDataControl.Name = "BasisDataControl";
        BasisDataControl.Size = new Size(828, 438);
        BasisDataControl.TabIndex = 0;
        tabPage_FirstClearData.Controls.Add(FirstClearDataControl);
        tabPage_FirstClearData.Location = new Point(4, 22);
        tabPage_FirstClearData.Name = "tabPage_FirstClearData";
        tabPage_FirstClearData.Size = new Size(834, 444);
        tabPage_FirstClearData.TabIndex = 7;
        tabPage_FirstClearData.Text = "First Clear";
        tabPage_FirstClearData.UseVisualStyleBackColor = true;
        FirstClearDataControl.Dock = DockStyle.Fill;
        FirstClearDataControl.Location = new Point(0, 0);
        FirstClearDataControl.Name = "FirstClearDataControl";
        FirstClearDataControl.Size = new Size(834, 444);
        FirstClearDataControl.TabIndex = 0;
        tabPage_ProcessFlag.Controls.Add(_processFlagControl);
        tabPage_ProcessFlag.Location = new Point(4, 22);
        tabPage_ProcessFlag.Name = "tabPage_ProcessFlag";
        tabPage_ProcessFlag.Size = new Size(834, 444);
        tabPage_ProcessFlag.TabIndex = 4;
        tabPage_ProcessFlag.Text = "Flags";
        tabPage_ProcessFlag.UseVisualStyleBackColor = true;
        _processFlagControl.Dock = DockStyle.Fill;
        _processFlagControl.Location = new Point(0, 0);
        _processFlagControl.Name = "_processFlagControl";
        _processFlagControl.Size = new Size(834, 444);
        _processFlagControl.TabIndex = 0;
        tabPage_CharacterData.Controls.Add(CharacterDataControl);
        tabPage_CharacterData.Location = new Point(4, 22);
        tabPage_CharacterData.Name = "tabPage_CharacterData";
        tabPage_CharacterData.Padding = new Padding(3);
        tabPage_CharacterData.Size = new Size(834, 444);
        tabPage_CharacterData.TabIndex = 1;
        tabPage_CharacterData.Text = "Party";
        tabPage_CharacterData.UseVisualStyleBackColor = true;
        CharacterDataControl.Dock = DockStyle.Fill;
        CharacterDataControl.Location = new Point(3, 3);
        CharacterDataControl.Name = "CharacterDataControl";
        CharacterDataControl.Size = new Size(828, 438);
        CharacterDataControl.TabIndex = 0;
        tabPage_Rikka.Controls.Add(RikkaInnDataControl);
        tabPage_Rikka.Location = new Point(4, 22);
        tabPage_Rikka.Name = "tabPage_Rikka";
        tabPage_Rikka.Size = new Size(834, 444);
        tabPage_Rikka.TabIndex = 8;
        tabPage_Rikka.Text = "Inn";
        tabPage_Rikka.UseVisualStyleBackColor = true;
        RikkaInnDataControl.Dock = DockStyle.Fill;
        RikkaInnDataControl.Location = new Point(0, 0);
        RikkaInnDataControl.Name = "RikkaInnDataControl";
        RikkaInnDataControl.Size = new Size(834, 444);
        RikkaInnDataControl.TabIndex = 0;
        tabPage_Quest.Controls.Add(_questDataControl);
        tabPage_Quest.Location = new Point(4, 22);
        tabPage_Quest.Name = "tabPage_Quest";
        tabPage_Quest.Size = new Size(834, 444);
        tabPage_Quest.TabIndex = 5;
        tabPage_Quest.Text = "Quest";
        tabPage_Quest.UseVisualStyleBackColor = true;
        _questDataControl.Dock = DockStyle.Fill;
        _questDataControl.Location = new Point(0, 0);
        _questDataControl.Name = "_questDataControl";
        _questDataControl.Size = new Size(834, 444);
        _questDataControl.TabIndex = 0;
        tabPage_Item.Controls.Add(_itemDataControl);
        tabPage_Item.Location = new Point(4, 22);
        tabPage_Item.Name = "tabPage_Item";
        tabPage_Item.Size = new Size(834, 444);
        tabPage_Item.TabIndex = 3;
        tabPage_Item.Text = "Items";
        tabPage_Item.UseVisualStyleBackColor = true;
        _itemDataControl.Dock = DockStyle.Fill;
        _itemDataControl.Location = new Point(0, 0);
        _itemDataControl.Name = "_itemDataControl";
        _itemDataControl.Size = new Size(834, 444);
        _itemDataControl.TabIndex = 0;
        tabPage_Monster.Controls.Add(_monsterDataControl);
        tabPage_Monster.Location = new Point(4, 22);
        tabPage_Monster.Name = "tabPage_Monster";
        tabPage_Monster.Size = new Size(834, 444);
        tabPage_Monster.TabIndex = 10;
        tabPage_Monster.Text = "Monster";
        tabPage_Monster.UseVisualStyleBackColor = true;
        _monsterDataControl.Dock = DockStyle.Fill;
        _monsterDataControl.Location = new Point(0, 0);
        _monsterDataControl.Name = "_monsterDataControl";
        _monsterDataControl.Size = new Size(834, 444);
        _monsterDataControl.TabIndex = 0;
        tabPage_Smart.Controls.Add(_smartItemDataControl);
        tabPage_Smart.Location = new Point(4, 22);
        tabPage_Smart.Name = "tabPage_Smart";
        tabPage_Smart.Size = new Size(834, 444);
        tabPage_Smart.TabIndex = 13;
        tabPage_Smart.Text = "Wardrobe";
        tabPage_Smart.UseVisualStyleBackColor = true;
        _smartItemDataControl.Dock = DockStyle.Fill;
        _smartItemDataControl.Location = new Point(0, 0);
        _smartItemDataControl.Name = "_smartItemDataControl";
        _smartItemDataControl.Size = new Size(834, 444);
        _smartItemDataControl.TabIndex = 0;
        tabPage_ItemCollection.Controls.Add(_itemCollectionDataControl);
        tabPage_ItemCollection.Location = new Point(4, 22);
        tabPage_ItemCollection.Name = "tabPage_ItemCollection";
        tabPage_ItemCollection.Size = new Size(834, 444);
        tabPage_ItemCollection.TabIndex = 11;
        tabPage_ItemCollection.Text = "Item List";
        tabPage_ItemCollection.UseVisualStyleBackColor = true;
        _itemCollectionDataControl.Dock = DockStyle.Fill;
        _itemCollectionDataControl.Location = new Point(0, 0);
        _itemCollectionDataControl.Name = "_itemCollectionDataControl";
        _itemCollectionDataControl.Size = new Size(834, 444);
        _itemCollectionDataControl.TabIndex = 0;
        tabPage_Alchemy.Controls.Add(_alchemyDataControl);
        tabPage_Alchemy.Location = new Point(4, 22);
        tabPage_Alchemy.Name = "tabPage_Alchemy";
        tabPage_Alchemy.Size = new Size(834, 444);
        tabPage_Alchemy.TabIndex = 12;
        tabPage_Alchemy.Text = "Alchemy";
        tabPage_Alchemy.UseVisualStyleBackColor = true;
        _alchemyDataControl.Dock = DockStyle.Fill;
        _alchemyDataControl.Location = new Point(0, 0);
        _alchemyDataControl.Name = "_alchemyDataControl";
        _alchemyDataControl.Size = new Size(834, 444);
        _alchemyDataControl.TabIndex = 0;
        tabPage_Tilte.Controls.Add(_titleDataControl);
        tabPage_Tilte.Location = new Point(4, 22);
        tabPage_Tilte.Name = "tabPage_Tilte";
        tabPage_Tilte.Size = new Size(834, 444);
        tabPage_Tilte.TabIndex = 6;
        tabPage_Tilte.Text = "Accolades";
        tabPage_Tilte.UseVisualStyleBackColor = true;
        _titleDataControl.Dock = DockStyle.Fill;
        _titleDataControl.Location = new Point(0, 0);
        _titleDataControl.Name = "_titleDataControl";
        _titleDataControl.Size = new Size(834, 444);
        _titleDataControl.TabIndex = 0;
        tabPage_Treasure.Controls.Add(TreasureMapDataControl);
        tabPage_Treasure.Location = new Point(4, 22);
        tabPage_Treasure.Name = "tabPage_Treasure";
        tabPage_Treasure.Size = new Size(834, 444);
        tabPage_Treasure.TabIndex = 14;
        tabPage_Treasure.Text = "Grottoes";
        tabPage_Treasure.UseVisualStyleBackColor = true;
        TreasureMapDataControl.Dock = DockStyle.Fill;
        TreasureMapDataControl.Location = new Point(0, 0);
        TreasureMapDataControl.Name = "TreasureMapDataControl";
        TreasureMapDataControl.Size = new Size(834, 444);
        TreasureMapDataControl.TabIndex = 0;
        tabPage_WifiShopping.Controls.Add(WifiShopDataControl);
        tabPage_WifiShopping.Location = new Point(4, 22);
        tabPage_WifiShopping.Name = "tabPage_WifiShopping";
        tabPage_WifiShopping.Size = new Size(834, 444);
        tabPage_WifiShopping.TabIndex = 9;
        tabPage_WifiShopping.Text = "Wi-Fi Shop";
        tabPage_WifiShopping.UseVisualStyleBackColor = true;
        WifiShopDataControl.Dock = DockStyle.Fill;
        WifiShopDataControl.Location = new Point(0, 0);
        WifiShopDataControl.Name = "WifiShopDataControl";
        WifiShopDataControl.Size = new Size(834, 444);
        WifiShopDataControl.TabIndex = 0;
        mainMenu.Dock = DockStyle.None;
        mainMenu.GripStyle = ToolStripGripStyle.Visible;
        mainMenu.Items.AddRange(new ToolStripItem[4]
        {
            menuFile,
            menuEdit,
            menuTool,
            menuVersion
        });
        mainMenu.Location = new Point(0, 0);
        mainMenu.Name = "mainMenu";
        mainMenu.Size = new Size(842, 26);
        mainMenu.TabIndex = 0;
        mainMenu.Text = "menuStrip1";
        menuFile.DropDownItems.AddRange(new ToolStripItem[6]
        {
            menuFile_Open,
            toolStripSeparator2,
            menuFile_Save,
            menuFile_SaveAs,
            toolStripSeparator3,
            menuFile_Exit
        });
        menuFile.Name = "menuFile";
        menuFile.Size = new Size(85, 22);
        menuFile.Text = "File(&F)";
        menuFile_Open.Name = "menuFile_Open";
        menuFile_Open.ShortcutKeyDisplayString = "Ctrl+O";
        menuFile_Open.Size = new Size(274, 22);
        menuFile_Open.Text = "Open(&O)";
        menuFile_Open.Click += menuFile_Open_Click;
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(271, 6);
        menuFile_Save.Enabled = false;
        menuFile_Save.Name = "menuFile_Save";
        menuFile_Save.ShortcutKeyDisplayString = "Ctrl+S";
        menuFile_Save.Size = new Size(274, 22);
        menuFile_Save.Text = "Save(&S)";
        menuFile_Save.Click += menuFile_Save_Click;
        menuFile_SaveAs.Enabled = false;
        menuFile_SaveAs.Name = "menuFile_SaveAs";
        menuFile_SaveAs.ShortcutKeyDisplayString = "Shift+Ctrl+S";
        menuFile_SaveAs.Size = new Size(274, 22);
        menuFile_SaveAs.Text = "Save As...(&A)";
        menuFile_SaveAs.Click += menuFile_SaveAs_Click;
        toolStripSeparator3.Name = "toolStripSeparator3";
        toolStripSeparator3.Size = new Size(271, 6);
        menuFile_Exit.Name = "menuFile_Exit";
        menuFile_Exit.ShortcutKeyDisplayString = "Alt+F4";
        menuFile_Exit.Size = new Size(274, 22);
        menuFile_Exit.Text = "Exit(&X)";
        menuFile_Exit.Click += menuFile_Exit_Click;
        menuEdit.DropDownItems.AddRange(new ToolStripItem[6]
        {
            menuEdit_Undo,
            menuEdit_Redo,
            toolStripSeparator5,
            menuEdit_CopyData1,
            menuEdit_CopyData2,
            menuEdit_RemoveIntermission
        });
        menuEdit.Name = "menuEdit";
        menuEdit.Size = new Size(61, 22);
        menuEdit.Text = "Edit(&E)";
        menuEdit_Undo.Enabled = false;
        menuEdit_Undo.Name = "menuEdit_Undo";
        menuEdit_Undo.ShortcutKeyDisplayString = "Ctrl+Z";
        menuEdit_Undo.Size = new Size(244, 22);
        menuEdit_Undo.Text = "Undo(&U)";
        menuEdit_Undo.Click += menuEdit_Undo_Click;
        menuEdit_Redo.Enabled = false;
        menuEdit_Redo.Name = "menuEdit_Redo";
        menuEdit_Redo.ShortcutKeyDisplayString = "Ctrl+Y";
        menuEdit_Redo.Size = new Size(244, 22);
        menuEdit_Redo.Text = "Redo(&R)";
        menuEdit_Redo.Click += menuEdit_Redo_Click;
        toolStripSeparator5.Name = "toolStripSeparator5";
        toolStripSeparator5.Size = new Size(241, 6);
        menuEdit_CopyData1.Enabled = false;
        menuEdit_CopyData1.Name = "menuEdit_CopyData1";
        menuEdit_CopyData1.Size = new Size(244, 22);
        menuEdit_CopyData1.Text = "Copy Confessed Save to Quick Save";
        menuEdit_CopyData1.Click += menuEdit_CopyData1_Click;
        menuEdit_CopyData2.Enabled = false;
        menuEdit_CopyData2.Name = "menuEdit_CopyData2";
        menuEdit_CopyData2.Size = new Size(244, 22);
        menuEdit_CopyData2.Text = "Copy Quick Save to Confessed Save";
        menuEdit_CopyData2.Click += menuEdit_CopyData2_Click;
        menuEdit_RemoveIntermission.Enabled = false;
        menuEdit_RemoveIntermission.Name = "menuEdit_RemoveIntermission";
        menuEdit_RemoveIntermission.Size = new Size(244, 22);
        menuEdit_RemoveIntermission.Text = "Remove Quick Save";
        menuEdit_RemoveIntermission.Click += menuEdit_RemoveIntermission_Click;
        menuTool.DropDownItems.AddRange(new ToolStripItem[2]
        {
            menuTool_SearchMap,
            menuTool_CreateSearchData
        });
        menuTool.Name = "menuTool";
        menuTool.Size = new Size(74, 22);
        menuTool.Text = "Treasure Data(&T)";
        menuTool_SearchMap.Name = "menuTool_SearchMap";
        menuTool_SearchMap.Size = new Size(166, 22);
        menuTool_SearchMap.Text = "Search map...(&S)";
        menuTool_SearchMap.Click += menuTool_SearchMap_Click;
        menuTool_CreateSearchData.Name = "menuTool_CreateSearchData";
        menuTool_CreateSearchData.Size = new Size(166, 22);
        menuTool_CreateSearchData.Text = "Create map data";
        menuTool_CreateSearchData.Click += menuTool_CreateSearchData_Click;
        menuVersion.Name = "menuVersion";
        menuVersion.Size = new Size(122, 22);
        menuVersion.Text = "About...(&V)";
        menuVersion.Click += menuVersion_Click;
        mainToolbar.Dock = DockStyle.None;
        mainToolbar.Items.AddRange(new ToolStripItem[9]
        {
            toolButton_Open,
            toolButton_Save,
            toolButton_SaveAs,
            toolStripSeparator4,
            toolButton_Undo,
            toolButton_Redo,
            toolStripSeparator1,
            toolStripRadioButton_Data1,
            toolStripRadioButton_Data2
        });
        mainToolbar.Location = new Point(3, 26);
        mainToolbar.Name = "mainToolbar";
        mainToolbar.Size = new Size(299, 25);
        mainToolbar.TabIndex = 0;
        mainToolbar.Text = "toolStrip1";
        toolButton_Open.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_Open.Image = (Image)componentResourceManager.GetObject("toolButton_Open.Image");
        toolButton_Open.ImageTransparentColor = Color.Lime;
        toolButton_Open.Name = "toolButton_Open";
        toolButton_Open.Size = new Size(23, 22);
        toolButton_Open.Text = "Open";
        toolButton_Open.Click += toolButton_Open_Click;
        toolButton_Save.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_Save.Enabled = false;
        toolButton_Save.Image = (Image)componentResourceManager.GetObject("toolButton_Save.Image");
        toolButton_Save.ImageTransparentColor = Color.Lime;
        toolButton_Save.Name = "toolButton_Save";
        toolButton_Save.Size = new Size(23, 22);
        toolButton_Save.Text = "Save";
        toolButton_Save.Click += toolButton_Save_Click;
        toolButton_SaveAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_SaveAs.Enabled = false;
        toolButton_SaveAs.Image = (Image)componentResourceManager.GetObject("toolButton_SaveAs.Image");
        toolButton_SaveAs.ImageTransparentColor = Color.Lime;
        toolButton_SaveAs.Name = "toolButton_SaveAs";
        toolButton_SaveAs.Size = new Size(23, 22);
        toolButton_SaveAs.Text = "Save as";
        toolButton_SaveAs.Click += toolButton_SaveAs_Click;
        toolStripSeparator4.Name = "toolStripSeparator4";
        toolStripSeparator4.Size = new Size(6, 25);
        toolButton_Undo.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_Undo.Enabled = false;
        toolButton_Undo.Image = (Image)componentResourceManager.GetObject("toolButton_Undo.Image");
        toolButton_Undo.ImageTransparentColor = Color.Lime;
        toolButton_Undo.Name = "toolButton_Undo";
        toolButton_Undo.Size = new Size(23, 22);
        toolButton_Undo.Text = "Undo";
        toolButton_Undo.Click += toolButton_Undo_Click;
        toolButton_Redo.DisplayStyle = ToolStripItemDisplayStyle.Image;
        toolButton_Redo.Enabled = false;
        toolButton_Redo.Image = (Image)componentResourceManager.GetObject("toolButton_Redo.Image");
        toolButton_Redo.ImageTransparentColor = Color.Lime;
        toolButton_Redo.Name = "toolButton_Redo";
        toolButton_Redo.Size = new Size(23, 22);
        toolButton_Redo.Text = "Redo";
        toolButton_Redo.Click += toolButton_Redo_Click;
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(6, 25);
        toolStripRadioButton_Data1.BackColor = Color.Transparent;
        toolStripRadioButton_Data1.Checked = true;
        toolStripRadioButton_Data1.Enabled = false;
        toolStripRadioButton_Data1.Name = "toolStripRadioButton_Data1";
        toolStripRadioButton_Data1.Size = new Size(74, 22);
        toolStripRadioButton_Data1.Tag = 0;
        toolStripRadioButton_Data1.Text = "Confessed Save";
        toolStripRadioButton_Data1.CheckedChanged += toolStripRadioButton_Data_CheckedChanged;
        toolStripRadioButton_Data1.Click += toolStripRadioButtonData_Click;
        toolStripRadioButton_Data2.BackColor = Color.Transparent;
        toolStripRadioButton_Data2.Checked = false;
        toolStripRadioButton_Data2.Enabled = false;
        toolStripRadioButton_Data2.Name = "toolStripRadioButton_Data2";
        toolStripRadioButton_Data2.Size = new Size(86, 22);
        toolStripRadioButton_Data2.Tag = 1;
        toolStripRadioButton_Data2.Text = "Quick Save";
        toolStripRadioButton_Data2.CheckedChanged += toolStripRadioButton_Data_CheckedChanged;
        AllowDrop = true;
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(842, 543);
        Controls.Add(textBox_dummy);
        Controls.Add(toolStripContainer1);
        Controls.Add(StatusStrip);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
        KeyPreview = true;
        MainMenuStrip = mainMenu;
        Name = nameof(MainWindow);
        Text = "Dragon Quest IX Save Data Editor";
        Load += Form1_Load;
        DragDrop += MainWindow_DragDrop;
        FormClosing += MainWindow_FormClosing;
        KeyDown += MainWindow_KeyDown;
        DragOver += MainWindow_DragOver;
        StatusStrip.ResumeLayout(false);
        StatusStrip.PerformLayout();
        toolStripContainer1.ContentPanel.ResumeLayout(false);
        toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
        toolStripContainer1.TopToolStripPanel.PerformLayout();
        toolStripContainer1.ResumeLayout(false);
        toolStripContainer1.PerformLayout();
        TabControl.ResumeLayout(false);
        tabPage_basisData.ResumeLayout(false);
        tabPage_FirstClearData.ResumeLayout(false);
        tabPage_ProcessFlag.ResumeLayout(false);
        tabPage_CharacterData.ResumeLayout(false);
        tabPage_Rikka.ResumeLayout(false);
        tabPage_Quest.ResumeLayout(false);
        tabPage_Item.ResumeLayout(false);
        tabPage_Monster.ResumeLayout(false);
        tabPage_Smart.ResumeLayout(false);
        tabPage_ItemCollection.ResumeLayout(false);
        tabPage_Alchemy.ResumeLayout(false);
        tabPage_Tilte.ResumeLayout(false);
        tabPage_Treasure.ResumeLayout(false);
        tabPage_WifiShopping.ResumeLayout(false);
        mainMenu.ResumeLayout(false);
        mainMenu.PerformLayout();
        mainToolbar.ResumeLayout(false);
        mainToolbar.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}