namespace MultipleAPI.WinForms
{
  partial class FrmBase
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnOpenNewWindow = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnOpenNewWindow
      // 
      this.btnOpenNewWindow.Location = new System.Drawing.Point(20, 20);
      this.btnOpenNewWindow.Name = "btnOpenNewWindow";
      this.btnOpenNewWindow.Size = new System.Drawing.Size(150, 50);
      this.btnOpenNewWindow.TabIndex = 2;
      this.btnOpenNewWindow.Text = "Open new window";
      this.btnOpenNewWindow.UseVisualStyleBackColor = true;
      this.btnOpenNewWindow.Click += new System.EventHandler(this.btnOpenNewWindow_Click);
      // 
      // FrmBase
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(194, 91);
      this.Controls.Add(this.btnOpenNewWindow);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "FrmBase";
      this.Text = "Test open more windows";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnOpenNewWindow;
  }
}