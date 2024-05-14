// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.Controls.HandleSelectWindow
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DQ9_Cheat.GameData;

namespace DQ9_Cheat.Controls;

public class HandleSelectWindow : Form
{
    private readonly int _sex;
    private Button button_Cancel;
    private Button button_OK;
    private ComboBox comboBox_SelectType;
    private IContainer components;
    private Label label_Search;
    private Label label_TypeName;
    private ListBox listBox_HandleList;
    private TextBox textBox_SearchString;

    public HandleSelectWindow(int sex)
    {
        InitializeComponent();
        comboBox_SelectType.SelectedIndex = 0;
        _sex = sex;
        RenewalList();
    }

    public Handle SelectedHandle { get; private set; }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        button_Cancel = new Button();
        button_OK = new Button();
        listBox_HandleList = new ListBox();
        label_Search = new Label();
        textBox_SearchString = new TextBox();
        label_TypeName = new Label();
        comboBox_SelectType = new ComboBox();
        SuspendLayout();
        button_Cancel.DialogResult = DialogResult.Cancel;
        button_Cancel.Location = new Point(111, 317);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new Size(61, 23);
        button_Cancel.TabIndex = 8;
        button_Cancel.Text = "Cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        button_OK.DialogResult = DialogResult.OK;
        button_OK.Enabled = false;
        button_OK.Location = new Point(44, 317);
        button_OK.Name = "button_OK";
        button_OK.Size = new Size(61, 23);
        button_OK.TabIndex = 7;
        button_OK.Text = "OK";
        button_OK.UseVisualStyleBackColor = true;
        button_OK.Click += button_OK_Click;
        listBox_HandleList.FormattingEnabled = true;
        listBox_HandleList.ItemHeight = 12;
        listBox_HandleList.Location = new Point(12, 57);
        listBox_HandleList.Name = "listBox_HandleList";
        listBox_HandleList.Size = new Size(160, 256);
        listBox_HandleList.TabIndex = 6;
        listBox_HandleList.MouseDoubleClick += listBox_TitleList_MouseDoubleClick;
        listBox_HandleList.SelectedIndexChanged += listBox_TitleList_SelectedIndexChanged;
        label_Search.AutoSize = true;
        label_Search.Location = new Point(4, 35);
        label_Search.Name = "label_Search";
        label_Search.Size = new Size(41, 13);
        label_Search.TabIndex = 5;
        label_Search.Text = "Search";
        textBox_SearchString.Location = new Point(45, 32);
        textBox_SearchString.Name = "textBox_SearchString";
        textBox_SearchString.Size = new Size(sbyte.MaxValue, 20);
        textBox_SearchString.TabIndex = 4;
        textBox_SearchString.TextChanged += textBox_SearchString_TextChanged;
        label_TypeName.AutoSize = true;
        label_TypeName.Location = new Point(14, 9);
        label_TypeName.Name = "label_TypeName";
        label_TypeName.Size = new Size(31, 13);
        label_TypeName.TabIndex = 10;
        label_TypeName.Text = "Type";
        comboBox_SelectType.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBox_SelectType.FormattingEnabled = true;
        comboBox_SelectType.Items.AddRange([
            "Occupations",
            "Accolades"
        ]);
        comboBox_SelectType.Location = new Point(45, 6);
        comboBox_SelectType.Name = "comboBox_SelectType";
        comboBox_SelectType.Size = new Size(sbyte.MaxValue, 21);
        comboBox_SelectType.TabIndex = 9;
        comboBox_SelectType.SelectedIndexChanged += comboBox_SelectType_SelectedIndexChanged;
        AcceptButton = button_OK;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = button_Cancel;
        ClientSize = new Size(180, 345);
        Controls.Add(label_TypeName);
        Controls.Add(comboBox_SelectType);
        Controls.Add(button_Cancel);
        Controls.Add(button_OK);
        Controls.Add(listBox_HandleList);
        Controls.Add(label_Search);
        Controls.Add(textBox_SearchString);
        FormBorderStyle = FormBorderStyle.Fixed3D;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = nameof(HandleSelectWindow);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        Text = "Select Profile Title";
        ResumeLayout(false);
        PerformLayout();
    }

    private void textBox_SearchString_TextChanged(object sender, EventArgs e)
    {
        RenewalList();
    }

    private void RenewalList()
    {
        listBox_HandleList.BeginUpdate();
        Regex regex = null;
        if (!string.IsNullOrEmpty(textBox_SearchString.Text))
            regex = new Regex(textBox_SearchString.Text, RegexOptions.IgnoreCase);
        listBox_HandleList.Items.Clear();
        if (comboBox_SelectType.SelectedIndex == 0)
            foreach (var profileJob in ProfileJobList.List)
                if (regex != null)
                {
                    if (regex.IsMatch(profileJob.Name))
                        listBox_HandleList.Items.Add(profileJob);
                }
                else
                {
                    listBox_HandleList.Items.Add(profileJob);
                }
        else
            foreach (var titleElement in TitleDataList.List)
                if (regex != null)
                {
                    if (regex.IsMatch(_sex == 0 ? titleElement.MaleTitleName : titleElement.LadyTitleName))
                        listBox_HandleList.Items.Add(new TitleListBoxItem(_sex, titleElement));
                }
                else if ((_sex == 0 ? !string.IsNullOrEmpty(titleElement.MaleTitleName) ? 1 : 0 :
                             !string.IsNullOrEmpty(titleElement.LadyTitleName) ? 1 : 0) != 0)
                {
                    listBox_HandleList.Items.Add(new TitleListBoxItem(_sex, titleElement));
                }

        listBox_HandleList.EndUpdate();
        if (listBox_HandleList.Items.Count > 0)
        {
            listBox_HandleList.SelectedIndex = 0;
        }
        else
        {
            listBox_HandleList.SelectedIndex = -1;
            button_OK.Enabled = false;
        }
    }

    private void listBox_TitleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        button_OK.Enabled = listBox_HandleList.SelectedIndex != -1;
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
        if (listBox_HandleList.SelectedItem != null)
        {
            if (listBox_HandleList.SelectedItem is ProfileJob)
            {
                SelectedHandle = new Handle(listBox_HandleList.SelectedItem as ProfileJob);
            }
            else
            {
                if (!(listBox_HandleList.SelectedItem is TitleListBoxItem))
                    return;
                SelectedHandle = new Handle((listBox_HandleList.SelectedItem as TitleListBoxItem).TitleElement);
            }
        }
        else
        {
            DialogResult = DialogResult.None;
        }
    }

    private void listBox_TitleList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (listBox_HandleList.IndexFromPoint(e.Location) == -1)
            return;
        if (listBox_HandleList.SelectedItem != null)
        {
            if (listBox_HandleList.SelectedItem is ProfileJob)
                SelectedHandle = new Handle(listBox_HandleList.SelectedItem as ProfileJob);
            else if (listBox_HandleList.SelectedItem is TitleListBoxItem)
                SelectedHandle = new Handle((listBox_HandleList.SelectedItem as TitleListBoxItem).TitleElement);
            DialogResult = DialogResult.OK;
        }
        else
        {
            DialogResult = DialogResult.None;
        }
    }

    private void comboBox_SelectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        textBox_SearchString.Text = string.Empty;
        RenewalList();
    }

    private class TitleListBoxItem
    {
        private readonly int _sex;

        public TitleListBoxItem(int sex, TitleElement titleElement)
        {
            TitleElement = titleElement;
            _sex = sex;
        }

        public TitleElement TitleElement { get; }

        public override string ToString()
        {
            return _sex != 0 ? TitleElement.LadyTitleName : TitleElement.MaleTitleName;
        }
    }
}