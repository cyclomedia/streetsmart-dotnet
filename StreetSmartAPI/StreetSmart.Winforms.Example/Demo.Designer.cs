namespace StreetSmart.Winforms.Example
{
  partial class Demo
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      plStreetSmart = new Panel();
      plControls = new Panel();
      tbFunctionality = new TabControl();
      tpLogin = new TabPage();
      grLogin = new GroupBox();
      label1 = new Label();
      textBox1 = new TextBox();
      grLoginWay = new GroupBox();
      rbBasicLogin = new RadioButton();
      rbOAuthLogin = new RadioButton();
      txtUsername = new TextBox();
      txtPassword = new TextBox();
      lblPassword = new Label();
      lblUsername = new Label();
      lblSRS = new Label();
      txtSrs = new TextBox();
      btnSave = new Button();
      btnLogout = new Button();
      lblAPIKey = new Label();
      txtAPIKey = new TextBox();
      btnLogin = new Button();
      tabPage2 = new TabPage();
      plUsernamePassword = new Panel();
      plControls.SuspendLayout();
      tbFunctionality.SuspendLayout();
      tpLogin.SuspendLayout();
      grLogin.SuspendLayout();
      grLoginWay.SuspendLayout();
      plUsernamePassword.SuspendLayout();
      SuspendLayout();
      // 
      // plStreetSmart
      // 
      plStreetSmart.Dock = DockStyle.Top;
      plStreetSmart.Location = new Point(0, 0);
      plStreetSmart.Name = "plStreetSmart";
      plStreetSmart.Size = new Size(1137, 250);
      plStreetSmart.TabIndex = 0;
      // 
      // plControls
      // 
      plControls.Controls.Add(tbFunctionality);
      plControls.Dock = DockStyle.Fill;
      plControls.Location = new Point(0, 250);
      plControls.Name = "plControls";
      plControls.Size = new Size(1137, 285);
      plControls.TabIndex = 1;
      // 
      // tbFunctionality
      // 
      tbFunctionality.Controls.Add(tpLogin);
      tbFunctionality.Controls.Add(tabPage2);
      tbFunctionality.Dock = DockStyle.Fill;
      tbFunctionality.Location = new Point(0, 0);
      tbFunctionality.Name = "tbFunctionality";
      tbFunctionality.SelectedIndex = 0;
      tbFunctionality.Size = new Size(1137, 285);
      tbFunctionality.TabIndex = 0;
      // 
      // tpLogin
      // 
      tpLogin.Controls.Add(grLogin);
      tpLogin.Controls.Add(lblSRS);
      tpLogin.Controls.Add(txtSrs);
      tpLogin.Controls.Add(btnSave);
      tpLogin.Controls.Add(btnLogout);
      tpLogin.Controls.Add(lblAPIKey);
      tpLogin.Controls.Add(txtAPIKey);
      tpLogin.Controls.Add(btnLogin);
      tpLogin.Location = new Point(4, 24);
      tpLogin.Name = "tpLogin";
      tpLogin.Padding = new Padding(3);
      tpLogin.Size = new Size(1129, 257);
      tpLogin.TabIndex = 0;
      tpLogin.Text = "Login";
      tpLogin.UseVisualStyleBackColor = true;
      // 
      // grLogin
      // 
      grLogin.Controls.Add(plUsernamePassword);
      grLogin.Controls.Add(grLoginWay);
      grLogin.Dock = DockStyle.Left;
      grLogin.Location = new Point(3, 3);
      grLogin.Name = "grLogin";
      grLogin.Size = new Size(500, 251);
      grLogin.TabIndex = 64;
      grLogin.TabStop = false;
      grLogin.Text = "login information";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(244, 15);
      label1.Margin = new Padding(4, 0, 4, 0);
      label1.Name = "label1";
      label1.Size = new Size(48, 15);
      label1.TabIndex = 66;
      label1.Text = "ClientId";
      // 
      // textBox1
      // 
      textBox1.Location = new Point(314, 15);
      textBox1.Margin = new Padding(4);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(150, 23);
      textBox1.TabIndex = 65;
      // 
      // grLoginWay
      // 
      grLoginWay.Controls.Add(rbBasicLogin);
      grLoginWay.Controls.Add(rbOAuthLogin);
      grLoginWay.Location = new Point(7, 147);
      grLoginWay.Margin = new Padding(4);
      grLoginWay.Name = "grLoginWay";
      grLoginWay.Padding = new Padding(4);
      grLoginWay.Size = new Size(200, 50);
      grLoginWay.TabIndex = 64;
      grLoginWay.TabStop = false;
      grLoginWay.Text = "Login way";
      // 
      // rbBasicLogin
      // 
      rbBasicLogin.AutoSize = true;
      rbBasicLogin.Checked = true;
      rbBasicLogin.Location = new Point(10, 20);
      rbBasicLogin.Margin = new Padding(4);
      rbBasicLogin.Name = "rbBasicLogin";
      rbBasicLogin.Size = new Size(85, 19);
      rbBasicLogin.TabIndex = 58;
      rbBasicLogin.TabStop = true;
      rbBasicLogin.Text = "basic Login";
      rbBasicLogin.UseVisualStyleBackColor = true;
      // 
      // rbOAuthLogin
      // 
      rbOAuthLogin.AutoSize = true;
      rbOAuthLogin.Location = new Point(100, 20);
      rbOAuthLogin.Margin = new Padding(4);
      rbOAuthLogin.Name = "rbOAuthLogin";
      rbOAuthLogin.Size = new Size(60, 19);
      rbOAuthLogin.TabIndex = 59;
      rbOAuthLogin.Text = "OAuth";
      rbOAuthLogin.UseVisualStyleBackColor = true;
      // 
      // txtUsername
      // 
      txtUsername.Location = new Point(74, 15);
      txtUsername.Margin = new Padding(4);
      txtUsername.Name = "txtUsername";
      txtUsername.Size = new Size(150, 23);
      txtUsername.TabIndex = 53;
      // 
      // txtPassword
      // 
      txtPassword.Location = new Point(74, 45);
      txtPassword.Margin = new Padding(4);
      txtPassword.Name = "txtPassword";
      txtPassword.PasswordChar = '*';
      txtPassword.Size = new Size(150, 23);
      txtPassword.TabIndex = 54;
      // 
      // lblPassword
      // 
      lblPassword.AutoSize = true;
      lblPassword.Location = new Point(4, 45);
      lblPassword.Margin = new Padding(4, 0, 4, 0);
      lblPassword.Name = "lblPassword";
      lblPassword.Size = new Size(57, 15);
      lblPassword.TabIndex = 52;
      lblPassword.Text = "Password";
      // 
      // lblUsername
      // 
      lblUsername.AutoSize = true;
      lblUsername.Location = new Point(4, 15);
      lblUsername.Margin = new Padding(4, 0, 4, 0);
      lblUsername.Name = "lblUsername";
      lblUsername.Size = new Size(60, 15);
      lblUsername.TabIndex = 51;
      lblUsername.Text = "Username";
      // 
      // lblSRS
      // 
      lblSRS.AutoSize = true;
      lblSRS.Location = new Point(655, 120);
      lblSRS.Margin = new Padding(4, 0, 4, 0);
      lblSRS.Name = "lblSRS";
      lblSRS.Size = new Size(26, 15);
      lblSRS.TabIndex = 60;
      lblSRS.Text = "SRS";
      // 
      // txtSrs
      // 
      txtSrs.Location = new Point(724, 120);
      txtSrs.Margin = new Padding(4);
      txtSrs.Name = "txtSrs";
      txtSrs.Size = new Size(127, 23);
      txtSrs.TabIndex = 61;
      txtSrs.Text = "EPSG:28992";
      // 
      // btnSave
      // 
      btnSave.Location = new Point(794, 150);
      btnSave.Margin = new Padding(4);
      btnSave.Name = "btnSave";
      btnSave.Size = new Size(59, 34);
      btnSave.TabIndex = 59;
      btnSave.Text = "Save";
      btnSave.UseVisualStyleBackColor = true;
      // 
      // btnLogout
      // 
      btnLogout.Location = new Point(724, 150);
      btnLogout.Margin = new Padding(4);
      btnLogout.Name = "btnLogout";
      btnLogout.Size = new Size(59, 34);
      btnLogout.TabIndex = 58;
      btnLogout.Text = "Logout";
      btnLogout.UseVisualStyleBackColor = true;
      // 
      // lblAPIKey
      // 
      lblAPIKey.AutoSize = true;
      lblAPIKey.Location = new Point(655, 76);
      lblAPIKey.Margin = new Padding(4, 0, 4, 0);
      lblAPIKey.Name = "lblAPIKey";
      lblAPIKey.Size = new Size(47, 15);
      lblAPIKey.TabIndex = 56;
      lblAPIKey.Text = "API Key";
      // 
      // txtAPIKey
      // 
      txtAPIKey.Location = new Point(724, 75);
      txtAPIKey.Margin = new Padding(4);
      txtAPIKey.Name = "txtAPIKey";
      txtAPIKey.Size = new Size(127, 23);
      txtAPIKey.TabIndex = 57;
      // 
      // btnLogin
      // 
      btnLogin.Location = new Point(654, 150);
      btnLogin.Margin = new Padding(4);
      btnLogin.Name = "btnLogin";
      btnLogin.Size = new Size(59, 34);
      btnLogin.TabIndex = 55;
      btnLogin.Text = "Login";
      btnLogin.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      tabPage2.Location = new Point(4, 24);
      tabPage2.Name = "tabPage2";
      tabPage2.Padding = new Padding(3);
      tabPage2.Size = new Size(1129, 257);
      tabPage2.TabIndex = 1;
      tabPage2.Text = "tabPage2";
      tabPage2.UseVisualStyleBackColor = true;
      // 
      // plUsernamePassword
      // 
      plUsernamePassword.Controls.Add(lblUsername);
      plUsernamePassword.Controls.Add(label1);
      plUsernamePassword.Controls.Add(lblPassword);
      plUsernamePassword.Controls.Add(textBox1);
      plUsernamePassword.Controls.Add(txtPassword);
      plUsernamePassword.Controls.Add(txtUsername);
      plUsernamePassword.Dock = DockStyle.Top;
      plUsernamePassword.Location = new Point(3, 19);
      plUsernamePassword.Name = "plUsernamePassword";
      plUsernamePassword.Size = new Size(494, 113);
      plUsernamePassword.TabIndex = 67;
      // 
      // Demo
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1137, 535);
      Controls.Add(plControls);
      Controls.Add(plStreetSmart);
      Name = "Demo";
      Text = "Street Smart Demo";
      plControls.ResumeLayout(false);
      tbFunctionality.ResumeLayout(false);
      tpLogin.ResumeLayout(false);
      tpLogin.PerformLayout();
      grLogin.ResumeLayout(false);
      grLoginWay.ResumeLayout(false);
      grLoginWay.PerformLayout();
      plUsernamePassword.ResumeLayout(false);
      plUsernamePassword.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private Panel plStreetSmart;
    private Panel plControls;
    private TabControl tbFunctionality;
    private TabPage tpLogin;
    private TabPage tabPage2;
    private Label lblSRS;
    private TextBox txtSrs;
    private Button btnSave;
    private Button btnLogout;
    private Label lblAPIKey;
    private TextBox txtAPIKey;
    private Label lblUsername;
    private Label lblPassword;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
    private GroupBox grLogin;
    private Label label1;
    private TextBox textBox1;
    private GroupBox grLoginWay;
    private RadioButton rbBasicLogin;
    private RadioButton rbOAuthLogin;
    private Panel plUsernamePassword;
  }
}