// Decompiled with JetBrains decompiler
// Type: DQ9_Cheat.AboutBox
// Assembly: DQ9_Cheat, Version=0.7.0.57, Culture=neutral, PublicKeyToken=null
// MVID: 9E5BE672-CBE6-45FB-AC35-96531044560E
// Assembly location: C:\Users\yzsco\Downloads\dq9_save_editor_0.7\DQCheat.Patched.0.7.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace DQ9_Cheat
{
  internal class AboutBox : Form
  {
    private IContainer components;
    private Label labelProductName;
    private Label labelVersion;
    private Label labelCopyright;
    private LinkLabel linkURL;
    private Button button_OK;
    private Label translatedBy;
    private LinkLabel translateURL;
    private Label labelSlash;
    private LinkLabel translateURL2;

    public AboutBox()
    {
      this.InitializeComponent();
      this.Text = string.Format("{0}  About", (object) this.AssemblyProduct);
      this.labelProductName.Text = this.AssemblyTitle;
      this.labelVersion.Text = string.Format("Version {0}", (object) this.AssemblyVersion);
      this.labelCopyright.Text = string.Format("Copyright {0}", (object) this.AssemblyCopyright);
      this.linkURL.Text = this.GetURL();
      this.linkURL.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkURL_LinkClicked);
    }

    private void linkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(this.linkURL.Text);
    }

    public string AssemblyTitle
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
        if (customAttributes.Length > 0)
        {
          AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute) customAttributes[0];
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
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
      }
    }

    public string AssemblyProduct
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyProductAttribute) customAttributes[0]).Product;
      }
    }

    public string AssemblyCopyright
    {
      get
      {
        object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
        return customAttributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
      }
    }

    private string GetURL()
    {
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      byte[] numArray = new byte[8]
      {
        (byte) 59,
        (byte) 5,
        (byte) 79,
        (byte) 32,
        (byte) 66,
        (byte) 121,
        (byte) 32,
        (byte) 65
      };
      cryptoServiceProvider.Key = numArray;
      cryptoServiceProvider.IV = numArray;
      using (MemoryStream memoryStream = new MemoryStream(new byte[24]
      {
        (byte) 116,
        (byte) 48,
        (byte) 224,
        (byte) 159,
        (byte) 119,
        (byte) 45,
        (byte) 252,
        (byte) 55,
        (byte) 75,
        (byte) 108,
        (byte) 102,
        (byte) 200,
        (byte) 31,
        (byte) 58,
        (byte) 169,
        (byte) 53,
        (byte) 230,
        (byte) 171,
        (byte) 206,
        (byte) 138,
        (byte) 76,
        (byte) 249,
        (byte) 53,
        (byte) 164
      }))
      {
        using (ICryptoTransform decryptor = cryptoServiceProvider.CreateDecryptor())
        {
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
          {
            using (StreamReader streamReader = new StreamReader((Stream) cryptoStream, Encoding.UTF8))
              return streamReader.ReadToEnd();
          }
        }
      }
    }

    private void button_OK_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.labelProductName = new Label();
      this.labelVersion = new Label();
      this.labelCopyright = new Label();
      this.linkURL = new LinkLabel();
      this.button_OK = new Button();
      this.translatedBy = new Label();
      this.translateURL = new LinkLabel();
      this.labelSlash = new Label();
      this.translateURL2 = new LinkLabel();
      this.SuspendLayout();
      this.labelProductName.AutoSize = true;
      this.labelProductName.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelProductName.SetBounds(57, 24, 242, 21);
      this.labelProductName.Name = "labelProductName";
      this.labelProductName.TabIndex = 0;
      this.labelProductName.Text = "Dragon Quest IX Save Data Editor";
      this.labelVersion.Location = new Point(123, 52);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new Size(109, 22);
      this.labelVersion.TabIndex = 1;
      this.labelVersion.Text = "Version 0.0.0.0";
      this.labelVersion.TextAlign = ContentAlignment.MiddleCenter;
      this.labelCopyright.AutoSize = true;
      this.labelCopyright.Location = new Point(133, 74);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new Size(88, 12);
      this.labelCopyright.TabIndex = 2;
      this.labelCopyright.Text = "Copyright asa-o";
      this.linkURL.Location = new Point(85, 95);
      this.linkURL.Name = "linkURL";
      this.linkURL.Size = new Size(185, 23);
      this.linkURL.TabIndex = 3;
      this.linkURL.TextAlign = ContentAlignment.MiddleCenter;
      this.button_OK.Location = new Point(140, 153);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new Size(75, 23);
      this.button_OK.TabIndex = 8;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new EventHandler(this.button_OK_Click);
      this.translatedBy.AutoSize = true;
      this.translatedBy.SetBounds(112, 125, 73, 13);
      this.translatedBy.Name = "labelTranslate";
      this.translatedBy.Text = "Translation by";
      this.translatedBy.TabIndex = 4;
      this.translatedBy.TextAlign = ContentAlignment.MiddleCenter;
      this.translateURL.SetBounds(182, 125, 32, 13);
      this.translateURL.Tag = (object) "http://friedginger.com/";
      this.translateURL.Text = "Yumil";
      this.translateURL.TabIndex = 5;
      this.translateURL.LinkClicked += new LinkLabelLinkClickedEventHandler(this.translateURL_LinkClicked);
      this.labelSlash.SetBounds(211, 125, 12, 13);
      this.labelSlash.Text = "/";
      this.labelSlash.TabIndex = 6;
      this.translateURL2.SetBounds(220, 125, 24, 13);
      this.translateURL2.Tag = (object) "http://www.yabd.org/";
      this.translateURL2.Text = "yab";
      this.translateURL2.TabIndex = 7;
      this.translateURL2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.translateURL_LinkClicked);
      this.AcceptButton = (IButtonControl) this.button_OK;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button_OK;
      this.ClientSize = new Size(355, 189);
      this.Controls.Add((Control) this.button_OK);
      this.Controls.Add((Control) this.linkURL);
      this.Controls.Add((Control) this.labelCopyright);
      this.Controls.Add((Control) this.labelVersion);
      this.Controls.Add((Control) this.labelProductName);
      this.Controls.Add((Control) this.translatedBy);
      this.Controls.Add((Control) this.translateURL);
      this.Controls.Add((Control) this.labelSlash);
      this.Controls.Add((Control) this.translateURL2);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AboutBox);
      this.Padding = new Padding(9, 8, 9, 8);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "About";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public void translateURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start((string) ((Control) sender).Tag);
    }
  }
}
