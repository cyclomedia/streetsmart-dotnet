namespace Demo.WinForms
{
  partial class Demo
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Demo));
      this.plStreetSmart = new System.Windows.Forms.Panel();
      this.plControl = new System.Windows.Forms.Panel();
      this.btnLogin = new System.Windows.Forms.Button();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.lblPassword = new System.Windows.Forms.Label();
      this.lblUsername = new System.Windows.Forms.Label();
      this.btRotateLeft = new System.Windows.Forms.Button();
      this.btnRotateRight = new System.Windows.Forms.Button();
      this.plControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // plStreetSmart
      // 
      this.plStreetSmart.Dock = System.Windows.Forms.DockStyle.Left;
      this.plStreetSmart.Location = new System.Drawing.Point(0, 0);
      this.plStreetSmart.Name = "plStreetSmart";
      this.plStreetSmart.Size = new System.Drawing.Size(900, 562);
      this.plStreetSmart.TabIndex = 0;
      // 
      // plControl
      // 
      this.plControl.Controls.Add(this.btnRotateRight);
      this.plControl.Controls.Add(this.btnLogin);
      this.plControl.Controls.Add(this.txtPassword);
      this.plControl.Controls.Add(this.txtUsername);
      this.plControl.Controls.Add(this.lblPassword);
      this.plControl.Controls.Add(this.lblUsername);
      this.plControl.Controls.Add(this.btRotateLeft);
      this.plControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.plControl.Location = new System.Drawing.Point(900, 0);
      this.plControl.Name = "plControl";
      this.plControl.Size = new System.Drawing.Size(184, 562);
      this.plControl.TabIndex = 1;
      // 
      // btnLogin
      // 
      this.btnLogin.Location = new System.Drawing.Point(10, 80);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(100, 30);
      this.btnLogin.TabIndex = 5;
      this.btnLogin.Text = "Login";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(70, 40);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(100, 20);
      this.txtPassword.TabIndex = 4;
      // 
      // txtUsername
      // 
      this.txtUsername.Location = new System.Drawing.Point(70, 10);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new System.Drawing.Size(100, 20);
      this.txtUsername.TabIndex = 3;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Location = new System.Drawing.Point(5, 40);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(53, 13);
      this.lblPassword.TabIndex = 2;
      this.lblPassword.Text = "Password";
      // 
      // lblUsername
      // 
      this.lblUsername.AutoSize = true;
      this.lblUsername.Location = new System.Drawing.Point(5, 10);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(55, 13);
      this.lblUsername.TabIndex = 1;
      this.lblUsername.Text = "Username";
      // 
      // btRotateLeft
      // 
      this.btRotateLeft.Location = new System.Drawing.Point(31, 126);
      this.btRotateLeft.Name = "btRotateLeft";
      this.btRotateLeft.Size = new System.Drawing.Size(100, 30);
      this.btRotateLeft.TabIndex = 0;
      this.btRotateLeft.Text = "Rotate Left";
      this.btRotateLeft.UseVisualStyleBackColor = true;
      this.btRotateLeft.Click += new System.EventHandler(this.btRotateLeft_Click);
      // 
      // btnRotateRight
      // 
      this.btnRotateRight.Location = new System.Drawing.Point(42, 266);
      this.btnRotateRight.Name = "btnRotateRight";
      this.btnRotateRight.Size = new System.Drawing.Size(100, 30);
      this.btnRotateRight.TabIndex = 6;
      this.btnRotateRight.Text = "Rotate Right";
      this.btnRotateRight.UseVisualStyleBackColor = true;
      this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
      // 
      // Demo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1084, 562);
      this.Controls.Add(this.plControl);
      this.Controls.Add(this.plStreetSmart);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Demo";
      this.Text = "Demo StreetSmart";
      this.plControl.ResumeLayout(false);
      this.plControl.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel plStreetSmart;
    private System.Windows.Forms.Panel plControl;
    private System.Windows.Forms.Button btRotateLeft;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.Button btnRotateRight;
  }
}

