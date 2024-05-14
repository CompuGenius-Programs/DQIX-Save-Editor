// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.MainWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using DQ9_Cheat.Controls;
using DQ9_Cheat.Controls.MapSearch;
using DQ9_Cheat.DataManager;
using DQ9_Cheat.MapSearch;
using JS_Framework.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

#nullable disable
namespace DQ9_Cheat
{
  public class MainWindow : Form
  {
    private const string ApplicationTitle = "Dragon Quest IX Save Data Editor";
    private MapSearchWindow _mapSearchWindow;
    private float _dpiX;
    private float _dpiY;
    private float _dpiRateX;
    private float _dpiRateY;
    private bool _saveCancel;
    private bool _initialized;
    private static MainWindow _instance;
    private IContainer components;
    private StatusStrip statusStrip1;
    private ToolStripContainer toolStripContainer1;
    private MenuStrip mainMenu;
    private ToolStripMenuItem menuFile;
    private ToolStripMenuItem menuFile_Exit;
    private ToolStrip mainToolbar;
    private ToolStripButton toolButton_Open;
    private TabControl tabControl;
    private TabPage tabPage_basisData;
    private TabPage tabPage_CharacterData;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripRadioButton toolStripRadioButton_Data1;
    private ToolStripRadioButton toolStripRadioButton_Data2;
    private ToolStripMenuItem menuFile_Open;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem menuFile_Save;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem menuFile_SaveAs;
    private ToolStripMenuItem menuEdit;
    private ToolStripMenuItem menuEdit_Undo;
    private ToolStripMenuItem menuEdit_Redo;
    private ToolStripButton toolButton_Save;
    private ToolStripButton toolButton_SaveAs;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripButton toolButton_Undo;
    private ToolStripButton toolButton_Redo;
    private OpenFileDialog openFileDialog;
    private SaveFileDialog saveFileDialog;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripMenuItem menuEdit_CopyData2;
    private CharacterDataControl _characterDataControl;
    private TextBox textBox_dummy;
    private TabPage tabPage_Item;
    private ItemDataControl _itemDataControl;
    private ToolStripStatusLabel _statusBarText;
    private TabPage tabPage_ProcessFlag;
    private ProcessFlagControl _processFlagControl;
    private TabPage tabPage_Quest;
    private QuestDataControl _questDataControl;
    private ToolStripMenuItem menuVersion;
    private TabPage tabPage_Tilte;
    private TitleDataControl _titleDataControl;
    private BasisDataControl _basisDataControl;
    private TabPage tabPage_FirstClearData;
    private FirstClearDataControl _firstClearDataControl;
    private TabPage tabPage_Rikka;
    private RikkaInnDataControl _rikkaInnDataControl;
    private TabPage tabPage_WifiShopping;
    private WifiShoppingDataControl _wifiShoppingDataControl;
    private TabPage tabPage_Monster;
    private TabPage tabPage_Smart;
    private TabPage tabPage_ItemCollection;
    private TabPage tabPage_Alchemy;
    private TabPage tabPage_Treasure;
    private TreasureMapDataControl _treasureMapDataControl;
    private ToolStripMenuItem menuEdit_RemoveIntermission;
    private MonsterDataControl _monsterDataControl;
    private SmartItemDataControl _smartItemDataControl;
    private ItemCollectionDataControl _itemCollectionDataControl;
    private AlchemyDataControl _alchemyDataControl;
    private ToolStripMenuItem menuEdit_CopyData1;
    private ToolStripMenuItem menuTool;
    private ToolStripMenuItem menuTool_SearchMap;
    private ToolStripMenuItem menuTool_CreateSearchData;

    private MainWindow()
    {
      this._mapSearchWindow = new MapSearchWindow();
      this.Disposed += new EventHandler(this.MainWindow_Disposed);
    }

    public float DpiX => this._dpiX;

    public float DpiY => this._dpiY;

    public float DpiRateX => this._dpiRateX;

    public float DpiRateY => this._dpiRateY;

    public bool SaveCancel
    {
      get => this._saveCancel;
      set => this._saveCancel = value;
    }

    private void MainWindow_Disposed(object sender, EventArgs e) => this._mapSearchWindow.Dispose();

    public void Initialize()
    {
      if (this._initialized)
        return;
      using (Graphics graphics = Graphics.FromHwnd(this.Handle))
      {
        this._dpiX = graphics.DpiX;
        this._dpiY = graphics.DpiY;
        this._dpiRateX = this._dpiX / 96f;
        this._dpiRateY = this._dpiY / 96f;
      }
      this.InitializeComponent();
      this._characterDataControl.Initialize();
      this._itemDataControl.Initialize();
      this._titleDataControl.Initialize();
      this._smartItemDataControl.Initialize();
      this._itemCollectionDataControl.Initialize();
      this._alchemyDataControl.Initialize();
      SaveDataManager.Instance.UndoRedoMgr.SavedIndexChanged += new UndoRedoManager.SavedIndexChangedHandler(this.UndoRedoMgr_SavedIndexChanged);
      this._initialized = true;
      string[] commandLineArgs = Environment.GetCommandLineArgs();
      if (commandLineArgs.Length <= 1 || !File.Exists(commandLineArgs[1]))
        return;
      this.OpenFile(commandLineArgs[1]);
    }

    private void UndoRedoMgr_SavedIndexChanged()
    {
      this.RenewalCaption();
      this.RenewalToolbar();
      this.RenewalMenu();
    }

    private void RenewalToolbar()
    {
      this.toolButton_Save.Enabled = SaveDataManager.Instance.DataFilePath != null;
      this.toolButton_SaveAs.Enabled = SaveDataManager.Instance.DataFilePath != null;
      this.toolButton_Undo.Enabled = SaveDataManager.Instance.UndoRedoMgr.IsUndo;
      this.toolButton_Redo.Enabled = SaveDataManager.Instance.UndoRedoMgr.IsRedo;
      this.toolStripRadioButton_Data1.Enabled = SaveDataManager.Instance.DataFilePath != null;
      this.toolStripRadioButton_Data2.Enabled = SaveDataManager.Instance.DataFilePath != null && SaveDataManager.Instance.IsThereIntermissionData;
      if (!this.toolStripRadioButton_Data2.Checked || this.toolStripRadioButton_Data2.Enabled)
        return;
      this.toolStripRadioButton_Data1.Checked = true;
    }

    private void RenewalMenu()
    {
      this.menuFile_Save.Enabled = SaveDataManager.Instance.DataFilePath != null;
      this.menuFile_SaveAs.Enabled = SaveDataManager.Instance.DataFilePath != null;
      this.menuEdit_Undo.Enabled = SaveDataManager.Instance.UndoRedoMgr.IsUndo;
      this.menuEdit_Redo.Enabled = SaveDataManager.Instance.UndoRedoMgr.IsRedo;
      this.menuEdit_CopyData1.Enabled = true;
      this.menuEdit_CopyData2.Enabled = SaveDataManager.Instance.GetSaveData(1).IsIntermission.Value == (byte) 1;
      this.menuEdit_RemoveIntermission.Enabled = SaveDataManager.Instance.GetSaveData(1).IsIntermission.Value == (byte) 1;
    }

    public void FocusControl(Control control)
    {
    }

    public static MainWindow Instance
    {
      get
      {
        if (MainWindow._instance == null)
          MainWindow._instance = new MainWindow();
        return MainWindow._instance;
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void menuFile_Exit_Click(object sender, EventArgs e) => this.Close();

    private void toolButton_Open_Click(object sender, EventArgs e) => this.OpenFile();

    private void OpenFile() => this.OpenFile((string) null);

    private bool OpenFile(string filePath)
    {
      this.textBox_dummy.Focus();
      if (!this.ConfirmSave())
        return false;
      if (filePath == null)
      {
        if (this.openFileDialog.ShowDialog() != DialogResult.OK)
          return false;
        filePath = this.openFileDialog.FileName;
      }
      if (File.Exists(filePath))
      {
        using (FileStream input = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
          using (BinaryReader br = new BinaryReader((Stream) input))
          {
            long num1 = (long) SaveDataManager.Instance.CheckFile(br);
            if (num1 == -1L)
            {
              int num2 = (int) MessageBox.Show("File is either in incorrect format or corrupted. Load failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
              return false;
            }
            input.Position = num1;
            SaveDataManager.Instance.ReadData(br);
          }
        }
        SaveDataManager.Instance.DataFilePath = filePath;
        this.tabControl.Enabled = true;
        this.OnLoaded();
        this.RenewalControl();
        this.RenewalCaption();
        this.RenewalToolbar();
        this.RenewalMenu();
      }
      return true;
    }

    private bool SaveFile() => this.SaveFile(false);

    private bool SaveFile(bool isNewFile)
    {
      this.textBox_dummy.Focus();
      if (this._saveCancel)
        return false;
      string path = SaveDataManager.Instance.DataFilePath;
      if (!File.Exists(path) || path == null || isNewFile)
      {
        if (string.IsNullOrEmpty(path))
        {
          this.saveFileDialog.InitialDirectory = Path.GetDirectoryName(path);
          this.saveFileDialog.FileName = Path.GetFileName(path);
        }
        if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
          return false;
        path = this.saveFileDialog.FileName;
      }
      using (FileStream output = new FileStream(path, FileMode.Create, FileAccess.Write))
      {
        using (BinaryWriter bw = new BinaryWriter((Stream) output))
          SaveDataManager.Instance.WriteData(bw);
      }
      this.RenewalCaption();
      return true;
    }

    private bool ConfirmSave()
    {
      if (SaveDataManager.Instance.UndoRedoMgr.EditFlag)
      {
        switch (MessageBox.Show("Do you want to save the changes?", "Save - Dragon Quest IX Save Data Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
        {
          case DialogResult.Cancel:
            return false;
          case DialogResult.Yes:
            this.SaveFile();
            break;
        }
      }
      return true;
    }

    private void RenewalCaption()
    {
      string str;
      if (SaveDataManager.Instance.DataFilePath != null)
      {
        string dataFilePath = SaveDataManager.Instance.DataFilePath;
        if (SaveDataManager.Instance.UndoRedoMgr.EditFlag)
          dataFilePath += " *";
        str = dataFilePath + " - Dragon Quest IX Save Data Editor";
      }
      else
        str = "Dragon Quest IX Save Data Editor";
      this.Text = str;
    }

    private void OnLoaded()
    {
      this._basisDataControl.DataFileLoaded();
      this._firstClearDataControl.DataFileLoaded();
      this._characterDataControl.DataFileLoaded();
      this._rikkaInnDataControl.DataFileLoaded();
      this._itemDataControl.DataFileLoaded();
      this._processFlagControl.DataFileLoaded();
      this._questDataControl.DataFileLoaded();
      this._titleDataControl.DataFileLoaded();
      this._treasureMapDataControl.DataFileLoaded();
      this._monsterDataControl.DataFileLoaded();
      this._smartItemDataControl.DataFileLoaded();
      this._itemCollectionDataControl.DataFileLoaded();
      this._alchemyDataControl.DataFileLoaded();
      this._wifiShoppingDataControl.DataFileLoaded();
    }

    private void RenewalControl()
    {
      this._basisDataControl.ValueUpdated();
      this._firstClearDataControl.ValueUpdated();
      this._characterDataControl.ValueUpdated();
      this._rikkaInnDataControl.ValueUpdated();
      this._itemDataControl.ValueUpdated();
      this._processFlagControl.ValueUpdated();
      this._questDataControl.ValueUpdated();
      this._titleDataControl.ValueUpdated();
      this._treasureMapDataControl.ValueUpdated();
      this._monsterDataControl.ValueUpdated();
      this._smartItemDataControl.ValueUpdated();
      this._itemCollectionDataControl.ValueUpdated();
      this._alchemyDataControl.ValueUpdated();
      this._wifiShoppingDataControl.ValueUpdated();
    }

    private void menuFile_Save_Click(object sender, EventArgs e) => this.SaveFile();

    private void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
        this.OpenFile();
      else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
      {
        if (SaveDataManager.Instance.DataFilePath == null)
          return;
        this.SaveFile();
      }
      else if (e.KeyCode == Keys.S && e.Modifiers == (Keys.Shift | Keys.Control))
      {
        if (SaveDataManager.Instance.DataFilePath == null)
          return;
        this.SaveFile(true);
      }
      else if (e.KeyCode == Keys.Z && e.Modifiers == Keys.Control)
      {
        this.Undo();
      }
      else
      {
        if (e.KeyCode != Keys.Y || e.Modifiers != Keys.Control)
          return;
        this.Redo();
      }
    }

    private void Undo()
    {
      if (!SaveDataManager.Instance.UndoRedoMgr.Undo())
        return;
      SaveDataManager.Instance.SaveData.OnUndo();
      this.RenewalControl();
      this.RenewalMenu();
    }

    private void Redo()
    {
      if (!SaveDataManager.Instance.UndoRedoMgr.Redo())
        return;
      SaveDataManager.Instance.SaveData.OnRedo();
      this.RenewalControl();
      this.RenewalMenu();
    }

    private void menuEdit_Undo_Click(object sender, EventArgs e) => this.Undo();

    private void menuEdit_Redo_Click(object sender, EventArgs e) => this.Redo();

    private void toolButton_Undo_Click(object sender, EventArgs e) => this.Undo();

    private void toolButton_Redo_Click(object sender, EventArgs e) => this.Redo();

    private void toolStripRadioButton_Data_CheckedChanged(object sender, EventArgs e)
    {
      if (!(sender is ToolStripRadioButton stripRadioButton) || SaveDataManager.Instance.SelectedDataIndex == (int) stripRadioButton.Tag)
        return;
      SaveDataManager.Instance.SelectedDataIndex = (int) stripRadioButton.Tag;
      this.RenewalControl();
    }

    private void toolStripRadioButtonData_Click(object sender, EventArgs e)
    {
    }

    private void toolButton_Save_Click(object sender, EventArgs e) => this.SaveFile();

    private void menuFile_SaveAs_Click(object sender, EventArgs e) => this.SaveFile(true);

    private void toolButton_SaveAs_Click(object sender, EventArgs e) => this.SaveFile(true);

    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.ConfirmSave())
        return;
      e.Cancel = true;
    }

    private void MainWindow_DragDrop(object sender, DragEventArgs e)
    {
      if (!this.IsAllowDragDrop(e))
        return;
      this.OpenFile((e.Data.GetData(DataFormats.FileDrop) as string[])[0]);
    }

    private void MainWindow_DragOver(object sender, DragEventArgs e)
    {
      e.Effect = this.IsAllowDragDrop(e) ? DragDropEffects.Copy : DragDropEffects.None;
    }

    private bool IsAllowDragDrop(DragEventArgs e)
    {
      return e.Data.GetDataPresent(DataFormats.FileDrop) && e.Data.GetData(DataFormats.FileDrop) is string[] data && data.Length == 1 && File.Exists(data[0]);
    }

    private void menuFile_Open_Click(object sender, EventArgs e) => this.OpenFile();

    private void menuEdit_CopyData1_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.CopyIntermissionData(0);
      this.RenewalControl();
    }

    private void menuEdit_CopyData2_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.CopyIntermissionData(1);
      this.RenewalControl();
    }

    private void menuVersion_Click(object sender, EventArgs e)
    {
      using (AboutBox aboutBox = new AboutBox())
      {
        int num = (int) aboutBox.ShowDialog();
      }
    }

    private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.RenewalWindowSize();
    }

    private void menuEdit_RemoveIntermission_Click(object sender, EventArgs e)
    {
      SaveDataManager.Instance.RemoveIntermissionData();
      this.RenewalMenu();
    }

    private void RenewalWindowSize()
    {
      int num1 = (int) (519.0 * (double) this._dpiRateX);
      int num2 = (int) (848.0 * (double) this._dpiRateY);
      foreach (Control control in (ArrangedElementCollection) this.tabControl.SelectedTab.Controls)
      {
        if (control is DataControlBase dataControlBase)
        {
          switch (dataControlBase)
          {
            case CharacterDataControl _:
            case RikkaInnDataControl _:
              num1 = (int) (599.0 * (double) this._dpiRateY);
              break;
            default:
              num1 = (int) (519.0 * (double) this._dpiRateY);
              break;
          }
          num2 = !(dataControlBase is RikkaInnDataControl) ? (int) (848.0 * (double) this._dpiRateX) : (int) (1020.0 * (double) this._dpiRateX);
          break;
        }
      }
      int height = num1 + (this.toolStripContainer1.TopToolStripPanel.Height + this.toolStripContainer1.BottomToolStripPanel.Height);
      this.Size = new Size(num2 + (this.toolStripContainer1.LeftToolStripPanel.Width + this.toolStripContainer1.RightToolStripPanel.Width), height);
    }

    private void toolStripContainer_ToolStripPanel_Resize(object sender, EventArgs e)
    {
      this.RenewalWindowSize();
    }

    private void menuTool_CreateSearchData_Click(object sender, EventArgs e)
    {
      if (File.Exists(SearchDataFile.FilePath) && MessageBox.Show("DB file already exists.\nRebuild it?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      int num = (int) new CreateMapDataBaseDialog().ShowDialog();
    }

    private void menuTool_SearchMap_Click(object sender, EventArgs e)
    {
      if (!File.Exists(SearchDataFile.FilePath))
      {
        int num = (int) MessageBox.Show("Could not find file MapSearch.dat.\nPlease create the file using \"Create map data\".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        this._mapSearchWindow.Show();
        this._mapSearchWindow.Activate();
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainWindow));
      this.statusStrip1 = new StatusStrip();
      this._statusBarText = new ToolStripStatusLabel();
      this.openFileDialog = new OpenFileDialog();
      this.saveFileDialog = new SaveFileDialog();
      this.textBox_dummy = new TextBox();
      this.toolStripContainer1 = new ToolStripContainer();
      this.tabControl = new TabControl();
      this.tabPage_basisData = new TabPage();
      this._basisDataControl = new BasisDataControl();
      this.tabPage_FirstClearData = new TabPage();
      this._firstClearDataControl = new FirstClearDataControl();
      this.tabPage_ProcessFlag = new TabPage();
      this._processFlagControl = new ProcessFlagControl();
      this.tabPage_CharacterData = new TabPage();
      this._characterDataControl = new CharacterDataControl();
      this.tabPage_Rikka = new TabPage();
      this._rikkaInnDataControl = new RikkaInnDataControl();
      this.tabPage_Quest = new TabPage();
      this._questDataControl = new QuestDataControl();
      this.tabPage_Item = new TabPage();
      this._itemDataControl = new ItemDataControl();
      this.tabPage_Monster = new TabPage();
      this._monsterDataControl = new MonsterDataControl();
      this.tabPage_Smart = new TabPage();
      this._smartItemDataControl = new SmartItemDataControl();
      this.tabPage_ItemCollection = new TabPage();
      this._itemCollectionDataControl = new ItemCollectionDataControl();
      this.tabPage_Alchemy = new TabPage();
      this._alchemyDataControl = new AlchemyDataControl();
      this.tabPage_Tilte = new TabPage();
      this._titleDataControl = new TitleDataControl();
      this.tabPage_Treasure = new TabPage();
      this._treasureMapDataControl = new TreasureMapDataControl();
      this.tabPage_WifiShopping = new TabPage();
      this._wifiShoppingDataControl = new WifiShoppingDataControl();
      this.mainMenu = new MenuStrip();
      this.menuFile = new ToolStripMenuItem();
      this.menuFile_Open = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.menuFile_Save = new ToolStripMenuItem();
      this.menuFile_SaveAs = new ToolStripMenuItem();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.menuFile_Exit = new ToolStripMenuItem();
      this.menuEdit = new ToolStripMenuItem();
      this.menuEdit_Undo = new ToolStripMenuItem();
      this.menuEdit_Redo = new ToolStripMenuItem();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.menuEdit_CopyData1 = new ToolStripMenuItem();
      this.menuEdit_CopyData2 = new ToolStripMenuItem();
      this.menuEdit_RemoveIntermission = new ToolStripMenuItem();
      this.menuTool = new ToolStripMenuItem();
      this.menuTool_SearchMap = new ToolStripMenuItem();
      this.menuTool_CreateSearchData = new ToolStripMenuItem();
      this.menuVersion = new ToolStripMenuItem();
      this.mainToolbar = new ToolStrip();
      this.toolButton_Open = new ToolStripButton();
      this.toolButton_Save = new ToolStripButton();
      this.toolButton_SaveAs = new ToolStripButton();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.toolButton_Undo = new ToolStripButton();
      this.toolButton_Redo = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripRadioButton_Data1 = new ToolStripRadioButton();
      this.toolStripRadioButton_Data2 = new ToolStripRadioButton();
      this.statusStrip1.SuspendLayout();
      this.toolStripContainer1.ContentPanel.SuspendLayout();
      this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer1.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.tabPage_basisData.SuspendLayout();
      this.tabPage_FirstClearData.SuspendLayout();
      this.tabPage_ProcessFlag.SuspendLayout();
      this.tabPage_CharacterData.SuspendLayout();
      this.tabPage_Rikka.SuspendLayout();
      this.tabPage_Quest.SuspendLayout();
      this.tabPage_Item.SuspendLayout();
      this.tabPage_Monster.SuspendLayout();
      this.tabPage_Smart.SuspendLayout();
      this.tabPage_ItemCollection.SuspendLayout();
      this.tabPage_Alchemy.SuspendLayout();
      this.tabPage_Tilte.SuspendLayout();
      this.tabPage_Treasure.SuspendLayout();
      this.tabPage_WifiShopping.SuspendLayout();
      this.mainMenu.SuspendLayout();
      this.mainToolbar.SuspendLayout();
      this.SuspendLayout();
      this.statusStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this._statusBarText
      });
      this.statusStrip1.Location = new Point(0, 521);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(842, 22);
      this.statusStrip1.SizingGrip = false;
      this.statusStrip1.TabIndex = 0;
      this.statusStrip1.Text = "statusStrip1";
      this._statusBarText.AutoSize = false;
      this._statusBarText.Name = "_statusBarText";
      this._statusBarText.Size = new Size(600, 17);
      this._statusBarText.TextAlign = ContentAlignment.MiddleLeft;
      this.openFileDialog.DefaultExt = "sav";
      this.openFileDialog.Filter = "Save (*.sav)|*.sav|DUC (*.duc)|*.duc|DAT (*.dat)|*.dat|DSV (*.dsv)|*.dsv|Show All (*.*)|*.*";
      this.saveFileDialog.DefaultExt = "sav";
      this.saveFileDialog.Filter = "Save (*.sav)|*.sav|DUC (*.duc)|*.duc|DAT (*.dat)|*.dat|DSV (*.dsv)|*.dsv|Show All (*.*)|*.*";
      this.textBox_dummy.Location = new Point(-200, -200);
      this.textBox_dummy.Name = "textBox_dummy";
      this.textBox_dummy.Size = new Size(100, 19);
      this.textBox_dummy.TabIndex = 2;
      this.toolStripContainer1.BottomToolStripPanel.Resize += new EventHandler(this.toolStripContainer_ToolStripPanel_Resize);
      this.toolStripContainer1.ContentPanel.Controls.Add((Control) this.tabControl);
      this.toolStripContainer1.ContentPanel.Size = new Size(842, 470);
      this.toolStripContainer1.Dock = DockStyle.Fill;
      this.toolStripContainer1.LeftToolStripPanel.Resize += new EventHandler(this.toolStripContainer_ToolStripPanel_Resize);
      this.toolStripContainer1.Location = new Point(0, 0);
      this.toolStripContainer1.Name = "toolStripContainer1";
      this.toolStripContainer1.RightToolStripPanel.Resize += new EventHandler(this.toolStripContainer_ToolStripPanel_Resize);
      this.toolStripContainer1.Size = new Size(842, 521);
      this.toolStripContainer1.TabIndex = 1;
      this.toolStripContainer1.Text = "toolStripContainer1";
      this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control) this.mainMenu);
      this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control) this.mainToolbar);
      this.toolStripContainer1.TopToolStripPanel.Resize += new EventHandler(this.toolStripContainer_ToolStripPanel_Resize);
      this.tabControl.Controls.Add((Control) this.tabPage_basisData);
      this.tabControl.Controls.Add((Control) this.tabPage_FirstClearData);
      this.tabControl.Controls.Add((Control) this.tabPage_ProcessFlag);
      this.tabControl.Controls.Add((Control) this.tabPage_CharacterData);
      this.tabControl.Controls.Add((Control) this.tabPage_Rikka);
      this.tabControl.Controls.Add((Control) this.tabPage_Quest);
      this.tabControl.Controls.Add((Control) this.tabPage_Item);
      this.tabControl.Controls.Add((Control) this.tabPage_Monster);
      this.tabControl.Controls.Add((Control) this.tabPage_Smart);
      this.tabControl.Controls.Add((Control) this.tabPage_ItemCollection);
      this.tabControl.Controls.Add((Control) this.tabPage_Alchemy);
      this.tabControl.Controls.Add((Control) this.tabPage_Tilte);
      this.tabControl.Controls.Add((Control) this.tabPage_Treasure);
      this.tabControl.Controls.Add((Control) this.tabPage_WifiShopping);
      this.tabControl.Dock = DockStyle.Fill;
      this.tabControl.Enabled = false;
      this.tabControl.Location = new Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new Size(842, 470);
      this.tabControl.TabIndex = 0;
      this.tabControl.SelectedIndexChanged += new EventHandler(this.tabControl_SelectedIndexChanged);
      this.tabPage_basisData.Controls.Add((Control) this._basisDataControl);
      this.tabPage_basisData.Location = new Point(4, 22);
      this.tabPage_basisData.Name = "tabPage_basisData";
      this.tabPage_basisData.Padding = new Padding(3);
      this.tabPage_basisData.Size = new Size(834, 444);
      this.tabPage_basisData.TabIndex = 0;
      this.tabPage_basisData.Text = "General";
      this.tabPage_basisData.UseVisualStyleBackColor = true;
      this._basisDataControl.Dock = DockStyle.Fill;
      this._basisDataControl.Location = new Point(3, 3);
      this._basisDataControl.Name = "_basisDataControl";
      this._basisDataControl.Size = new Size(828, 438);
      this._basisDataControl.TabIndex = 0;
      this.tabPage_FirstClearData.Controls.Add((Control) this._firstClearDataControl);
      this.tabPage_FirstClearData.Location = new Point(4, 22);
      this.tabPage_FirstClearData.Name = "tabPage_FirstClearData";
      this.tabPage_FirstClearData.Size = new Size(834, 444);
      this.tabPage_FirstClearData.TabIndex = 7;
      this.tabPage_FirstClearData.Text = "First Clear";
      this.tabPage_FirstClearData.UseVisualStyleBackColor = true;
      this._firstClearDataControl.Dock = DockStyle.Fill;
      this._firstClearDataControl.Location = new Point(0, 0);
      this._firstClearDataControl.Name = "_firstClearDataControl";
      this._firstClearDataControl.Size = new Size(834, 444);
      this._firstClearDataControl.TabIndex = 0;
      this.tabPage_ProcessFlag.Controls.Add((Control) this._processFlagControl);
      this.tabPage_ProcessFlag.Location = new Point(4, 22);
      this.tabPage_ProcessFlag.Name = "tabPage_ProcessFlag";
      this.tabPage_ProcessFlag.Size = new Size(834, 444);
      this.tabPage_ProcessFlag.TabIndex = 4;
      this.tabPage_ProcessFlag.Text = "Flags";
      this.tabPage_ProcessFlag.UseVisualStyleBackColor = true;
      this._processFlagControl.Dock = DockStyle.Fill;
      this._processFlagControl.Location = new Point(0, 0);
      this._processFlagControl.Name = "_processFlagControl";
      this._processFlagControl.Size = new Size(834, 444);
      this._processFlagControl.TabIndex = 0;
      this.tabPage_CharacterData.Controls.Add((Control) this._characterDataControl);
      this.tabPage_CharacterData.Location = new Point(4, 22);
      this.tabPage_CharacterData.Name = "tabPage_CharacterData";
      this.tabPage_CharacterData.Padding = new Padding(3);
      this.tabPage_CharacterData.Size = new Size(834, 444);
      this.tabPage_CharacterData.TabIndex = 1;
      this.tabPage_CharacterData.Text = "Party";
      this.tabPage_CharacterData.UseVisualStyleBackColor = true;
      this._characterDataControl.Dock = DockStyle.Fill;
      this._characterDataControl.Location = new Point(3, 3);
      this._characterDataControl.Name = "_characterDataControl";
      this._characterDataControl.Size = new Size(828, 438);
      this._characterDataControl.TabIndex = 0;
      this.tabPage_Rikka.Controls.Add((Control) this._rikkaInnDataControl);
      this.tabPage_Rikka.Location = new Point(4, 22);
      this.tabPage_Rikka.Name = "tabPage_Rikka";
      this.tabPage_Rikka.Size = new Size(834, 444);
      this.tabPage_Rikka.TabIndex = 8;
      this.tabPage_Rikka.Text = "Inn";
      this.tabPage_Rikka.UseVisualStyleBackColor = true;
      this._rikkaInnDataControl.Dock = DockStyle.Fill;
      this._rikkaInnDataControl.Location = new Point(0, 0);
      this._rikkaInnDataControl.Name = "_rikkaInnDataControl";
      this._rikkaInnDataControl.Size = new Size(834, 444);
      this._rikkaInnDataControl.TabIndex = 0;
      this.tabPage_Quest.Controls.Add((Control) this._questDataControl);
      this.tabPage_Quest.Location = new Point(4, 22);
      this.tabPage_Quest.Name = "tabPage_Quest";
      this.tabPage_Quest.Size = new Size(834, 444);
      this.tabPage_Quest.TabIndex = 5;
      this.tabPage_Quest.Text = "Quest";
      this.tabPage_Quest.UseVisualStyleBackColor = true;
      this._questDataControl.Dock = DockStyle.Fill;
      this._questDataControl.Location = new Point(0, 0);
      this._questDataControl.Name = "_questDataControl";
      this._questDataControl.Size = new Size(834, 444);
      this._questDataControl.TabIndex = 0;
      this.tabPage_Item.Controls.Add((Control) this._itemDataControl);
      this.tabPage_Item.Location = new Point(4, 22);
      this.tabPage_Item.Name = "tabPage_Item";
      this.tabPage_Item.Size = new Size(834, 444);
      this.tabPage_Item.TabIndex = 3;
      this.tabPage_Item.Text = "Items";
      this.tabPage_Item.UseVisualStyleBackColor = true;
      this._itemDataControl.Dock = DockStyle.Fill;
      this._itemDataControl.Location = new Point(0, 0);
      this._itemDataControl.Name = "_itemDataControl";
      this._itemDataControl.Size = new Size(834, 444);
      this._itemDataControl.TabIndex = 0;
      this.tabPage_Monster.Controls.Add((Control) this._monsterDataControl);
      this.tabPage_Monster.Location = new Point(4, 22);
      this.tabPage_Monster.Name = "tabPage_Monster";
      this.tabPage_Monster.Size = new Size(834, 444);
      this.tabPage_Monster.TabIndex = 10;
      this.tabPage_Monster.Text = "Monster";
      this.tabPage_Monster.UseVisualStyleBackColor = true;
      this._monsterDataControl.Dock = DockStyle.Fill;
      this._monsterDataControl.Location = new Point(0, 0);
      this._monsterDataControl.Name = "_monsterDataControl";
      this._monsterDataControl.Size = new Size(834, 444);
      this._monsterDataControl.TabIndex = 0;
      this.tabPage_Smart.Controls.Add((Control) this._smartItemDataControl);
      this.tabPage_Smart.Location = new Point(4, 22);
      this.tabPage_Smart.Name = "tabPage_Smart";
      this.tabPage_Smart.Size = new Size(834, 444);
      this.tabPage_Smart.TabIndex = 13;
      this.tabPage_Smart.Text = "Wardrobe";
      this.tabPage_Smart.UseVisualStyleBackColor = true;
      this._smartItemDataControl.Dock = DockStyle.Fill;
      this._smartItemDataControl.Location = new Point(0, 0);
      this._smartItemDataControl.Name = "_smartItemDataControl";
      this._smartItemDataControl.Size = new Size(834, 444);
      this._smartItemDataControl.TabIndex = 0;
      this.tabPage_ItemCollection.Controls.Add((Control) this._itemCollectionDataControl);
      this.tabPage_ItemCollection.Location = new Point(4, 22);
      this.tabPage_ItemCollection.Name = "tabPage_ItemCollection";
      this.tabPage_ItemCollection.Size = new Size(834, 444);
      this.tabPage_ItemCollection.TabIndex = 11;
      this.tabPage_ItemCollection.Text = "Item List";
      this.tabPage_ItemCollection.UseVisualStyleBackColor = true;
      this._itemCollectionDataControl.Dock = DockStyle.Fill;
      this._itemCollectionDataControl.Location = new Point(0, 0);
      this._itemCollectionDataControl.Name = "_itemCollectionDataControl";
      this._itemCollectionDataControl.Size = new Size(834, 444);
      this._itemCollectionDataControl.TabIndex = 0;
      this.tabPage_Alchemy.Controls.Add((Control) this._alchemyDataControl);
      this.tabPage_Alchemy.Location = new Point(4, 22);
      this.tabPage_Alchemy.Name = "tabPage_Alchemy";
      this.tabPage_Alchemy.Size = new Size(834, 444);
      this.tabPage_Alchemy.TabIndex = 12;
      this.tabPage_Alchemy.Text = "Alchemy";
      this.tabPage_Alchemy.UseVisualStyleBackColor = true;
      this._alchemyDataControl.Dock = DockStyle.Fill;
      this._alchemyDataControl.Location = new Point(0, 0);
      this._alchemyDataControl.Name = "_alchemyDataControl";
      this._alchemyDataControl.Size = new Size(834, 444);
      this._alchemyDataControl.TabIndex = 0;
      this.tabPage_Tilte.Controls.Add((Control) this._titleDataControl);
      this.tabPage_Tilte.Location = new Point(4, 22);
      this.tabPage_Tilte.Name = "tabPage_Tilte";
      this.tabPage_Tilte.Size = new Size(834, 444);
      this.tabPage_Tilte.TabIndex = 6;
      this.tabPage_Tilte.Text = "Accolades";
      this.tabPage_Tilte.UseVisualStyleBackColor = true;
      this._titleDataControl.Dock = DockStyle.Fill;
      this._titleDataControl.Location = new Point(0, 0);
      this._titleDataControl.Name = "_titleDataControl";
      this._titleDataControl.Size = new Size(834, 444);
      this._titleDataControl.TabIndex = 0;
      this.tabPage_Treasure.Controls.Add((Control) this._treasureMapDataControl);
      this.tabPage_Treasure.Location = new Point(4, 22);
      this.tabPage_Treasure.Name = "tabPage_Treasure";
      this.tabPage_Treasure.Size = new Size(834, 444);
      this.tabPage_Treasure.TabIndex = 14;
      this.tabPage_Treasure.Text = "Grottoes";
      this.tabPage_Treasure.UseVisualStyleBackColor = true;
      this._treasureMapDataControl.Dock = DockStyle.Fill;
      this._treasureMapDataControl.Location = new Point(0, 0);
      this._treasureMapDataControl.Name = "_treasureMapDataControl";
      this._treasureMapDataControl.Size = new Size(834, 444);
      this._treasureMapDataControl.TabIndex = 0;
      this.tabPage_WifiShopping.Controls.Add((Control) this._wifiShoppingDataControl);
      this.tabPage_WifiShopping.Location = new Point(4, 22);
      this.tabPage_WifiShopping.Name = "tabPage_WifiShopping";
      this.tabPage_WifiShopping.Size = new Size(834, 444);
      this.tabPage_WifiShopping.TabIndex = 9;
      this.tabPage_WifiShopping.Text = "Wi-Fi Shop";
      this.tabPage_WifiShopping.UseVisualStyleBackColor = true;
      this._wifiShoppingDataControl.Dock = DockStyle.Fill;
      this._wifiShoppingDataControl.Location = new Point(0, 0);
      this._wifiShoppingDataControl.Name = "_wifiShoppingDataControl";
      this._wifiShoppingDataControl.Size = new Size(834, 444);
      this._wifiShoppingDataControl.TabIndex = 0;
      this.mainMenu.Dock = DockStyle.None;
      this.mainMenu.GripStyle = ToolStripGripStyle.Visible;
      this.mainMenu.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.menuFile,
        (ToolStripItem) this.menuEdit,
        (ToolStripItem) this.menuTool,
        (ToolStripItem) this.menuVersion
      });
      this.mainMenu.Location = new Point(0, 0);
      this.mainMenu.Name = "mainMenu";
      this.mainMenu.Size = new Size(842, 26);
      this.mainMenu.TabIndex = 0;
      this.mainMenu.Text = "menuStrip1";
      this.menuFile.DropDownItems.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.menuFile_Open,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.menuFile_Save,
        (ToolStripItem) this.menuFile_SaveAs,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.menuFile_Exit
      });
      this.menuFile.Name = "menuFile";
      this.menuFile.Size = new Size(85, 22);
      this.menuFile.Text = "File(&F)";
      this.menuFile_Open.Name = "menuFile_Open";
      this.menuFile_Open.ShortcutKeyDisplayString = "Ctrl+O";
      this.menuFile_Open.Size = new Size(274, 22);
      this.menuFile_Open.Text = "Open(&O)";
      this.menuFile_Open.Click += new EventHandler(this.menuFile_Open_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(271, 6);
      this.menuFile_Save.Enabled = false;
      this.menuFile_Save.Name = "menuFile_Save";
      this.menuFile_Save.ShortcutKeyDisplayString = "Ctrl+S";
      this.menuFile_Save.Size = new Size(274, 22);
      this.menuFile_Save.Text = "Save(&S)";
      this.menuFile_Save.Click += new EventHandler(this.menuFile_Save_Click);
      this.menuFile_SaveAs.Enabled = false;
      this.menuFile_SaveAs.Name = "menuFile_SaveAs";
      this.menuFile_SaveAs.ShortcutKeyDisplayString = "Shift+Ctrl+S";
      this.menuFile_SaveAs.Size = new Size(274, 22);
      this.menuFile_SaveAs.Text = "Save As...(&A)";
      this.menuFile_SaveAs.Click += new EventHandler(this.menuFile_SaveAs_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(271, 6);
      this.menuFile_Exit.Name = "menuFile_Exit";
      this.menuFile_Exit.ShortcutKeyDisplayString = "Alt+F4";
      this.menuFile_Exit.Size = new Size(274, 22);
      this.menuFile_Exit.Text = "Exit(&X)";
      this.menuFile_Exit.Click += new EventHandler(this.menuFile_Exit_Click);
      this.menuEdit.DropDownItems.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.menuEdit_Undo,
        (ToolStripItem) this.menuEdit_Redo,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.menuEdit_CopyData1,
        (ToolStripItem) this.menuEdit_CopyData2,
        (ToolStripItem) this.menuEdit_RemoveIntermission
      });
      this.menuEdit.Name = "menuEdit";
      this.menuEdit.Size = new Size(61, 22);
      this.menuEdit.Text = "Edit(&E)";
      this.menuEdit_Undo.Enabled = false;
      this.menuEdit_Undo.Name = "menuEdit_Undo";
      this.menuEdit_Undo.ShortcutKeyDisplayString = "Ctrl+Z";
      this.menuEdit_Undo.Size = new Size(244, 22);
      this.menuEdit_Undo.Text = "Undo(&U)";
      this.menuEdit_Undo.Click += new EventHandler(this.menuEdit_Undo_Click);
      this.menuEdit_Redo.Enabled = false;
      this.menuEdit_Redo.Name = "menuEdit_Redo";
      this.menuEdit_Redo.ShortcutKeyDisplayString = "Ctrl+Y";
      this.menuEdit_Redo.Size = new Size(244, 22);
      this.menuEdit_Redo.Text = "Redo(&R)";
      this.menuEdit_Redo.Click += new EventHandler(this.menuEdit_Redo_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(241, 6);
      this.menuEdit_CopyData1.Enabled = false;
      this.menuEdit_CopyData1.Name = "menuEdit_CopyData1";
      this.menuEdit_CopyData1.Size = new Size(244, 22);
      this.menuEdit_CopyData1.Text = "Copy Confessed Save to Quick Save";
      this.menuEdit_CopyData1.Click += new EventHandler(this.menuEdit_CopyData1_Click);
      this.menuEdit_CopyData2.Enabled = false;
      this.menuEdit_CopyData2.Name = "menuEdit_CopyData2";
      this.menuEdit_CopyData2.Size = new Size(244, 22);
      this.menuEdit_CopyData2.Text = "Copy Quick Save to Confessed Save";
      this.menuEdit_CopyData2.Click += new EventHandler(this.menuEdit_CopyData2_Click);
      this.menuEdit_RemoveIntermission.Enabled = false;
      this.menuEdit_RemoveIntermission.Name = "menuEdit_RemoveIntermission";
      this.menuEdit_RemoveIntermission.Size = new Size(244, 22);
      this.menuEdit_RemoveIntermission.Text = "Remove Quick Save";
      this.menuEdit_RemoveIntermission.Click += new EventHandler(this.menuEdit_RemoveIntermission_Click);
      this.menuTool.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.menuTool_SearchMap,
        (ToolStripItem) this.menuTool_CreateSearchData
      });
      this.menuTool.Name = "menuTool";
      this.menuTool.Size = new Size(74, 22);
      this.menuTool.Text = "Treasure Data(&T)";
      this.menuTool_SearchMap.Name = "menuTool_SearchMap";
      this.menuTool_SearchMap.Size = new Size(166, 22);
      this.menuTool_SearchMap.Text = "Search map...(&S)";
      this.menuTool_SearchMap.Click += new EventHandler(this.menuTool_SearchMap_Click);
      this.menuTool_CreateSearchData.Name = "menuTool_CreateSearchData";
      this.menuTool_CreateSearchData.Size = new Size(166, 22);
      this.menuTool_CreateSearchData.Text = "Create map data";
      this.menuTool_CreateSearchData.Click += new EventHandler(this.menuTool_CreateSearchData_Click);
      this.menuVersion.Name = "menuVersion";
      this.menuVersion.Size = new Size(122, 22);
      this.menuVersion.Text = "About...(&V)";
      this.menuVersion.Click += new EventHandler(this.menuVersion_Click);
      this.mainToolbar.Dock = DockStyle.None;
      this.mainToolbar.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.toolButton_Open,
        (ToolStripItem) this.toolButton_Save,
        (ToolStripItem) this.toolButton_SaveAs,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.toolButton_Undo,
        (ToolStripItem) this.toolButton_Redo,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripRadioButton_Data1,
        (ToolStripItem) this.toolStripRadioButton_Data2
      });
      this.mainToolbar.Location = new Point(3, 26);
      this.mainToolbar.Name = "mainToolbar";
      this.mainToolbar.Size = new Size(299, 25);
      this.mainToolbar.TabIndex = 0;
      this.mainToolbar.Text = "toolStrip1";
      this.toolButton_Open.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_Open.Image = (Image) componentResourceManager.GetObject("toolButton_Open.Image");
      this.toolButton_Open.ImageTransparentColor = Color.Lime;
      this.toolButton_Open.Name = "toolButton_Open";
      this.toolButton_Open.Size = new Size(23, 22);
      this.toolButton_Open.Text = "Open";
      this.toolButton_Open.Click += new EventHandler(this.toolButton_Open_Click);
      this.toolButton_Save.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_Save.Enabled = false;
      this.toolButton_Save.Image = (Image) componentResourceManager.GetObject("toolButton_Save.Image");
      this.toolButton_Save.ImageTransparentColor = Color.Lime;
      this.toolButton_Save.Name = "toolButton_Save";
      this.toolButton_Save.Size = new Size(23, 22);
      this.toolButton_Save.Text = "Save";
      this.toolButton_Save.Click += new EventHandler(this.toolButton_Save_Click);
      this.toolButton_SaveAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_SaveAs.Enabled = false;
      this.toolButton_SaveAs.Image = (Image) componentResourceManager.GetObject("toolButton_SaveAs.Image");
      this.toolButton_SaveAs.ImageTransparentColor = Color.Lime;
      this.toolButton_SaveAs.Name = "toolButton_SaveAs";
      this.toolButton_SaveAs.Size = new Size(23, 22);
      this.toolButton_SaveAs.Text = "Save as";
      this.toolButton_SaveAs.Click += new EventHandler(this.toolButton_SaveAs_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(6, 25);
      this.toolButton_Undo.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_Undo.Enabled = false;
      this.toolButton_Undo.Image = (Image) componentResourceManager.GetObject("toolButton_Undo.Image");
      this.toolButton_Undo.ImageTransparentColor = Color.Lime;
      this.toolButton_Undo.Name = "toolButton_Undo";
      this.toolButton_Undo.Size = new Size(23, 22);
      this.toolButton_Undo.Text = "Undo";
      this.toolButton_Undo.Click += new EventHandler(this.toolButton_Undo_Click);
      this.toolButton_Redo.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolButton_Redo.Enabled = false;
      this.toolButton_Redo.Image = (Image) componentResourceManager.GetObject("toolButton_Redo.Image");
      this.toolButton_Redo.ImageTransparentColor = Color.Lime;
      this.toolButton_Redo.Name = "toolButton_Redo";
      this.toolButton_Redo.Size = new Size(23, 22);
      this.toolButton_Redo.Text = "Redo";
      this.toolButton_Redo.Click += new EventHandler(this.toolButton_Redo_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.toolStripRadioButton_Data1.BackColor = Color.Transparent;
      this.toolStripRadioButton_Data1.Checked = true;
      this.toolStripRadioButton_Data1.Enabled = false;
      this.toolStripRadioButton_Data1.Name = "toolStripRadioButton_Data1";
      this.toolStripRadioButton_Data1.Size = new Size(74, 22);
      this.toolStripRadioButton_Data1.Tag = (object) 0;
      this.toolStripRadioButton_Data1.Text = "Confessed Save";
      this.toolStripRadioButton_Data1.CheckedChanged += new EventHandler(this.toolStripRadioButton_Data_CheckedChanged);
      this.toolStripRadioButton_Data1.Click += new EventHandler(this.toolStripRadioButtonData_Click);
      this.toolStripRadioButton_Data2.BackColor = Color.Transparent;
      this.toolStripRadioButton_Data2.Checked = false;
      this.toolStripRadioButton_Data2.Enabled = false;
      this.toolStripRadioButton_Data2.Name = "toolStripRadioButton_Data2";
      this.toolStripRadioButton_Data2.Size = new Size(86, 22);
      this.toolStripRadioButton_Data2.Tag = (object) 1;
      this.toolStripRadioButton_Data2.Text = "Quick Save";
      this.toolStripRadioButton_Data2.CheckedChanged += new EventHandler(this.toolStripRadioButton_Data_CheckedChanged);
      this.AllowDrop = true;
      this.AutoScaleMode = AutoScaleMode.None;
      this.ClientSize = new Size(842, 543);
      this.Controls.Add((Control) this.textBox_dummy);
      this.Controls.Add((Control) this.toolStripContainer1);
      this.Controls.Add((Control) this.statusStrip1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MainMenuStrip = this.mainMenu;
      this.Name = nameof (MainWindow);
      this.Text = "Dragon Quest IX Save Data Editor";
      this.Load += new EventHandler(this.Form1_Load);
      this.DragDrop += new DragEventHandler(this.MainWindow_DragDrop);
      this.FormClosing += new FormClosingEventHandler(this.MainWindow_FormClosing);
      this.KeyDown += new KeyEventHandler(this.MainWindow_KeyDown);
      this.DragOver += new DragEventHandler(this.MainWindow_DragOver);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.toolStripContainer1.ContentPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.PerformLayout();
      this.toolStripContainer1.ResumeLayout(false);
      this.toolStripContainer1.PerformLayout();
      this.tabControl.ResumeLayout(false);
      this.tabPage_basisData.ResumeLayout(false);
      this.tabPage_FirstClearData.ResumeLayout(false);
      this.tabPage_ProcessFlag.ResumeLayout(false);
      this.tabPage_CharacterData.ResumeLayout(false);
      this.tabPage_Rikka.ResumeLayout(false);
      this.tabPage_Quest.ResumeLayout(false);
      this.tabPage_Item.ResumeLayout(false);
      this.tabPage_Monster.ResumeLayout(false);
      this.tabPage_Smart.ResumeLayout(false);
      this.tabPage_ItemCollection.ResumeLayout(false);
      this.tabPage_Alchemy.ResumeLayout(false);
      this.tabPage_Tilte.ResumeLayout(false);
      this.tabPage_Treasure.ResumeLayout(false);
      this.tabPage_WifiShopping.ResumeLayout(false);
      this.mainMenu.ResumeLayout(false);
      this.mainMenu.PerformLayout();
      this.mainToolbar.ResumeLayout(false);
      this.mainToolbar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public TabControl TabControl => this.tabControl;

    public StatusStrip StatusStrip => this.statusStrip1;

    public ToolStripStatusLabel StatusBarText => this._statusBarText;

    public BasisDataControl BasisDataControl => this._basisDataControl;

    public CharacterDataControl CharacterDataControl => this._characterDataControl;

    public FirstClearDataControl FirstClearDataControl => this._firstClearDataControl;

    public RikkaInnDataControl RikkaInnDataControl => this._rikkaInnDataControl;

    public TreasureMapDataControl TreasureMapDataControl => this._treasureMapDataControl;

    public WifiShoppingDataControl WifiShopDataControl => this._wifiShoppingDataControl;
  }
}
