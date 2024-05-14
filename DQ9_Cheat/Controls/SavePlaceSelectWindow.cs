// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.SavePlaceSelectWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls;

public class SavePlaceSelectWindow : Form
{
    private readonly bool _afterEnding;
    private ItemType _itemType;
    private Button button_Cancel;
    private Button button_OK;
    private ComboBox comboBox_SelectType;
    private IContainer components;
    private Label label_Search;
    private Label label_TypeName;
    private ListBox listBox_SavePlaceList;
    private TextBox textBox_SearchString;

    public SavePlaceSelectWindow(bool afterEnding)
    {
        InitializeComponent();
        _afterEnding = afterEnding;
        comboBox_SelectType.SelectedIndex = 1;
        RenewalList();
    }

    public SavePlace SelectedSavePlace { get; private set; }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        textBox_SearchString = new TextBox();
        label_Search = new Label();
        listBox_SavePlaceList = new ListBox();
        button_OK = new Button();
        button_Cancel = new Button();
        comboBox_SelectType = new ComboBox();
        label_TypeName = new Label();
        SuspendLayout();
        textBox_SearchString.Location = new Point(58, 32);
        textBox_SearchString.Name = "textBox_SearchString";
        textBox_SearchString.Size = new Size(sbyte.MaxValue, 20);
        textBox_SearchString.TabIndex = 0;
        textBox_SearchString.TextChanged += textBox_SearchString_TextChanged;
        label_Search.AutoSize = true;
        label_Search.Location = new Point(15, 35);
        label_Search.Name = "label_Search";
        label_Search.Size = new Size(41, 13);
        label_Search.TabIndex = 1;
        label_Search.Text = "Search";
        listBox_SavePlaceList.FormattingEnabled = true;
        listBox_SavePlaceList.ItemHeight = 12;
        listBox_SavePlaceList.Location = new Point(14, 57);
        listBox_SavePlaceList.Name = "listBox_SavePlaceList";
        listBox_SavePlaceList.Size = new Size(221, 251);
        listBox_SavePlaceList.TabIndex = 1;
        listBox_SavePlaceList.MouseDoubleClick += listBox_ItemList_MouseDoubleClick;
        listBox_SavePlaceList.SelectedIndexChanged += listBox_ItemList_SelectedIndexChanged;
        button_OK.DialogResult = DialogResult.OK;
        button_OK.Enabled = false;
        button_OK.Location = new Point(108, 317);
        button_OK.Name = "button_OK";
        button_OK.Size = new Size(61, 23);
        button_OK.TabIndex = 2;
        button_OK.Text = "OK";
        button_OK.UseVisualStyleBackColor = true;
        button_OK.Click += button_OK_Click;
        button_Cancel.DialogResult = DialogResult.Cancel;
        button_Cancel.Location = new Point(175, 317);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new Size(61, 23);
        button_Cancel.TabIndex = 3;
        button_Cancel.Text = "Cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        comboBox_SelectType.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_SelectType.FormattingEnabled = true;
        comboBox_SelectType.Items.AddRange([
            "All",
            "Church",
            "Town, etc.",
            "Field",
            "Dungeon",
            "Other"
        ]);
        comboBox_SelectType.Location = new Point(58, 7);
        comboBox_SelectType.Name = "comboBox_SelectType";
        comboBox_SelectType.Size = new Size(sbyte.MaxValue, 21);
        comboBox_SelectType.TabIndex = 4;
        comboBox_SelectType.SelectedIndexChanged += comboBox_SelectType_SelectedIndexChanged;
        label_TypeName.AutoSize = true;
        label_TypeName.Location = new Point(25, 10);
        label_TypeName.Name = "label_TypeName";
        label_TypeName.Size = new Size(31, 13);
        label_TypeName.TabIndex = 5;
        label_TypeName.Text = "Type";
        AcceptButton = button_OK;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = button_Cancel;
        ClientSize = new Size(247, 342);
        Controls.Add(label_TypeName);
        Controls.Add(comboBox_SelectType);
        Controls.Add(button_Cancel);
        Controls.Add(button_OK);
        Controls.Add(listBox_SavePlaceList);
        Controls.Add(label_Search);
        Controls.Add(textBox_SearchString);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = nameof(SavePlaceSelectWindow);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        Text = "Select Save Location";
        ResumeLayout(false);
        PerformLayout();
    }

    private void RenewalList()
    {
        var list = SavePlaceList.GetList((SavePlaceType)comboBox_SelectType.SelectedIndex, textBox_SearchString.Text);
        listBox_SavePlaceList.BeginUpdate();
        listBox_SavePlaceList.Items.Clear();
        foreach (var savePlace in list)
            if (_afterEnding || savePlace.Index != ushort.MaxValue)
                listBox_SavePlaceList.Items.Add(savePlace);
        listBox_SavePlaceList.EndUpdate();
        button_OK.Enabled = false;
    }

    private void textBox_SearchString_TextChanged(object sender, EventArgs e)
    {
        RenewalList();
    }

    private void listBox_ItemList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (listBox_SavePlaceList.IndexFromPoint(e.Location) == -1)
            return;
        SelectedSavePlace = listBox_SavePlaceList.SelectedItem as SavePlace;
        DialogResult = DialogResult.OK;
    }

    private void listBox_ItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        button_OK.Enabled = listBox_SavePlaceList.SelectedIndex != -1;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
        SelectedSavePlace = listBox_SavePlaceList.SelectedItem as SavePlace;
    }

    private void comboBox_SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        textBox_SearchString.Text = string.Empty;
        RenewalList();
    }
}