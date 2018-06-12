namespace MultipleAPICreation
{
  partial class MultipleDemo
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
      this.plStreetSmart = new System.Windows.Forms.Panel();
      this.txtSearch = new System.Windows.Forms.TextBox();
      this.lblSearch = new System.Windows.Forms.Label();
      this.btnInit = new System.Windows.Forms.Button();
      this.btnOpen = new System.Windows.Forms.Button();
      this.btnDestroy = new System.Windows.Forms.Button();
      this.btnDevTools = new System.Windows.Forms.Button();
      this.plStreetSmart.SuspendLayout();
      this.SuspendLayout();
      // 
      // plStreetSmart
      // 
      this.plStreetSmart.Controls.Add(this.btnDevTools);
      this.plStreetSmart.Controls.Add(this.txtSearch);
      this.plStreetSmart.Controls.Add(this.lblSearch);
      this.plStreetSmart.Controls.Add(this.btnInit);
      this.plStreetSmart.Controls.Add(this.btnOpen);
      this.plStreetSmart.Controls.Add(this.btnDestroy);
      this.plStreetSmart.Dock = System.Windows.Forms.DockStyle.Fill;
      this.plStreetSmart.Location = new System.Drawing.Point(0, 0);
      this.plStreetSmart.Name = "plStreetSmart";
      this.plStreetSmart.Size = new System.Drawing.Size(800, 450);
      this.plStreetSmart.TabIndex = 0;
      // 
      // txtSearch
      // 
      this.txtSearch.Location = new System.Drawing.Point(250, 45);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(225, 20);
      this.txtSearch.TabIndex = 4;
      this.txtSearch.Text = "Boschdijk 7, Eindhoven";
      // 
      // lblSearch
      // 
      this.lblSearch.AutoSize = true;
      this.lblSearch.Location = new System.Drawing.Point(200, 45);
      this.lblSearch.Name = "lblSearch";
      this.lblSearch.Size = new System.Drawing.Size(44, 13);
      this.lblSearch.TabIndex = 3;
      this.lblSearch.Text = "Search:";
      // 
      // btnInit
      // 
      this.btnInit.Enabled = false;
      this.btnInit.Location = new System.Drawing.Point(300, 10);
      this.btnInit.Name = "btnInit";
      this.btnInit.Size = new System.Drawing.Size(75, 25);
      this.btnInit.TabIndex = 2;
      this.btnInit.Text = "Init API";
      this.btnInit.UseVisualStyleBackColor = true;
      this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
      // 
      // btnOpen
      // 
      this.btnOpen.Enabled = false;
      this.btnOpen.Location = new System.Drawing.Point(400, 10);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(75, 25);
      this.btnOpen.TabIndex = 1;
      this.btnOpen.Text = "Open";
      this.btnOpen.UseVisualStyleBackColor = true;
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // btnDestroy
      // 
      this.btnDestroy.Enabled = false;
      this.btnDestroy.Location = new System.Drawing.Point(200, 10);
      this.btnDestroy.Name = "btnDestroy";
      this.btnDestroy.Size = new System.Drawing.Size(75, 25);
      this.btnDestroy.TabIndex = 0;
      this.btnDestroy.Text = "Destroy API";
      this.btnDestroy.UseVisualStyleBackColor = true;
      this.btnDestroy.Click += new System.EventHandler(this.btnDestroy_Click);
      // 
      // btnDevTools
      // 
      this.btnDevTools.Location = new System.Drawing.Point(500, 10);
      this.btnDevTools.Name = "btnDevTools";
      this.btnDevTools.Size = new System.Drawing.Size(75, 25);
      this.btnDevTools.TabIndex = 5;
      this.btnDevTools.Text = "dev. tools";
      this.btnDevTools.UseVisualStyleBackColor = true;
      this.btnDevTools.Click += new System.EventHandler(this.btnDevTools_Click);
      // 
      // MultipleDemo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.plStreetSmart);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Name = "MultipleDemo";
      this.Text = "Multiple API Initialisation Demo";
      this.plStreetSmart.ResumeLayout(false);
      this.plStreetSmart.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel plStreetSmart;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.Button btnDestroy;
    private System.Windows.Forms.Button btnInit;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Label lblSearch;
    private System.Windows.Forms.Button btnDevTools;
  }
}

