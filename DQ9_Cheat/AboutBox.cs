// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.AboutBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DQ9_Cheat;

internal class AboutBox : Form
{
    private Button button_OK;
    private IContainer components;
    private Label labelCopyright;
    private Label labelProductName;
    private Label labelSlash;
    private Label labelVersion;
    private LinkLabel linkURL;
    private Label translatedBy;
    private LinkLabel translateURL;
    private LinkLabel translateURL2;

    public AboutBox()
    {
        InitializeComponent();
        Text = string.Format("{0}  About", AssemblyProduct);
        labelProductName.Text = AssemblyTitle;
        labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
        labelCopyright.Text = string.Format("Copyright {0}", AssemblyCopyright);
        linkURL.Text = GetURL();
        linkURL.LinkClicked += linkURL_LinkClicked;
    }

    public string AssemblyTitle
    {
        get
        {
            var customAttributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (customAttributes.Length > 0)
            {
                var assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
                if (assemblyTitleAttribute.Title != "")
                    return assemblyTitleAttribute.Title;
            }

            return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }
    }

    public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    public string AssemblyDescription
    {
        get
        {
            var customAttributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            return customAttributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
        }
    }

    public string AssemblyProduct
    {
        get
        {
            var customAttributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            return customAttributes.Length == 0 ? "" : ((AssemblyProductAttribute)customAttributes[0]).Product;
        }
    }

    public string AssemblyCopyright
    {
        get
        {
            var customAttributes = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            return customAttributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
        }
    }

    private void linkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(linkURL.Text);
    }

    private string GetURL()
    {
        var cryptoServiceProvider = new DESCryptoServiceProvider();
        var numArray = new byte[8]
        {
            59,
            5,
            79,
            32,
            66,
            121,
            32,
            65
        };
        cryptoServiceProvider.Key = numArray;
        cryptoServiceProvider.IV = numArray;
        using (var memoryStream = new MemoryStream(new byte[24]
               {
                   116,
                   48,
                   224,
                   159,
                   119,
                   45,
                   252,
                   55,
                   75,
                   108,
                   102,
                   200,
                   31,
                   58,
                   169,
                   53,
                   230,
                   171,
                   206,
                   138,
                   76,
                   249,
                   53,
                   164
               }))
        {
            using (var decryptor = cryptoServiceProvider.CreateDecryptor())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (var streamReader = new StreamReader(cryptoStream, Encoding.UTF8))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

    private void button_OK_Click(object sender, EventArgs e)
    {
        Close();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        labelProductName = new Label();
        labelVersion = new Label();
        labelCopyright = new Label();
        linkURL = new LinkLabel();
        button_OK = new Button();
        translatedBy = new Label();
        translateURL = new LinkLabel();
        labelSlash = new Label();
        translateURL2 = new LinkLabel();
        SuspendLayout();
        labelProductName.AutoSize = true;
        labelProductName.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelProductName.SetBounds(57, 24, 242, 21);
        labelProductName.Name = "labelProductName";
        labelProductName.TabIndex = 0;
        labelProductName.Text = "Dragon Quest IX Save Data Editor";
        labelVersion.Location = new Point(123, 52);
        labelVersion.Name = "labelVersion";
        labelVersion.Size = new Size(109, 22);
        labelVersion.TabIndex = 1;
        labelVersion.Text = "Version 0.0.0.0";
        labelVersion.TextAlign = ContentAlignment.MiddleCenter;
        labelCopyright.AutoSize = true;
        labelCopyright.Location = new Point(133, 74);
        labelCopyright.Name = "labelCopyright";
        labelCopyright.Size = new Size(88, 12);
        labelCopyright.TabIndex = 2;
        labelCopyright.Text = "Copyright asa-o";
        linkURL.Location = new Point(85, 95);
        linkURL.Name = "linkURL";
        linkURL.Size = new Size(185, 23);
        linkURL.TabIndex = 3;
        linkURL.TextAlign = ContentAlignment.MiddleCenter;
        button_OK.Location = new Point(140, 153);
        button_OK.Name = "button_OK";
        button_OK.Size = new Size(75, 23);
        button_OK.TabIndex = 8;
        button_OK.Text = "OK";
        button_OK.UseVisualStyleBackColor = true;
        button_OK.Click += button_OK_Click;
        translatedBy.AutoSize = true;
        translatedBy.SetBounds(112, 125, 73, 13);
        translatedBy.Name = "labelTranslate";
        translatedBy.Text = "Translation by";
        translatedBy.TabIndex = 4;
        translatedBy.TextAlign = ContentAlignment.MiddleCenter;
        translateURL.SetBounds(182, 125, 32, 13);
        translateURL.Tag = "http://friedginger.com/";
        translateURL.Text = "Yumil";
        translateURL.TabIndex = 5;
        translateURL.LinkClicked += translateURL_LinkClicked;
        labelSlash.SetBounds(211, 125, 12, 13);
        labelSlash.Text = "/";
        labelSlash.TabIndex = 6;
        translateURL2.SetBounds(220, 125, 24, 13);
        translateURL2.Tag = "http://www.yabd.org/";
        translateURL2.Text = "yab";
        translateURL2.TabIndex = 7;
        translateURL2.LinkClicked += translateURL_LinkClicked;
        AcceptButton = button_OK;
        AutoScaleDimensions = new SizeF(6f, 12f);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = button_OK;
        ClientSize = new Size(355, 189);
        Controls.Add(button_OK);
        Controls.Add(linkURL);
        Controls.Add(labelCopyright);
        Controls.Add(labelVersion);
        Controls.Add(labelProductName);
        Controls.Add(translatedBy);
        Controls.Add(translateURL);
        Controls.Add(labelSlash);
        Controls.Add(translateURL2);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = nameof(AboutBox);
        Padding = new Padding(9, 8, 9, 8);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "About";
        ResumeLayout(false);
        PerformLayout();
    }

    public void translateURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start((string)((Control)sender).Tag);
    }
}