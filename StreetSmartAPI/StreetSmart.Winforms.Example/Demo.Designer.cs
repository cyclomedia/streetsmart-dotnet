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
      panel1 = new Panel();
      txtAPIKey = new TextBox();
      btnLogin = new Button();
      lblSRS = new Label();
      lblAPIKey = new Label();
      txtSrs = new TextBox();
      btnLogout = new Button();
      btnSave = new Button();
      grLogin = new GroupBox();
      plLoginWay = new Panel();
      grLoginWay = new GroupBox();
      rbBasicLogin = new RadioButton();
      rbOAuthLogin = new RadioButton();
      plUsernamePassword = new Panel();
      lblUsername = new Label();
      lblClientId = new Label();
      lblPassword = new Label();
      txtClientId = new TextBox();
      txtPassword = new TextBox();
      txtUsername = new TextBox();
      tabPage2 = new TabPage();
      plControls.SuspendLayout();
      tbFunctionality.SuspendLayout();
      tpLogin.SuspendLayout();
      panel1.SuspendLayout();
      grLogin.SuspendLayout();
      plLoginWay.SuspendLayout();
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
      tpLogin.Controls.Add(panel1);
      tpLogin.Controls.Add(grLogin);
      tpLogin.Location = new Point(4, 24);
      tpLogin.Name = "tpLogin";
      tpLogin.Padding = new Padding(3);
      tpLogin.Size = new Size(1129, 257);
      tpLogin.TabIndex = 0;
      tpLogin.Text = "Login";
      tpLogin.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      panel1.Controls.Add(txtAPIKey);
      panel1.Controls.Add(btnLogin);
      panel1.Controls.Add(lblSRS);
      panel1.Controls.Add(lblAPIKey);
      panel1.Controls.Add(txtSrs);
      panel1.Controls.Add(btnLogout);
      panel1.Controls.Add(btnSave);
      panel1.Dock = DockStyle.Fill;
      panel1.Location = new Point(503, 3);
      panel1.Name = "panel1";
      panel1.Size = new Size(623, 251);
      panel1.TabIndex = 65;
      // 
      // txtAPIKey
      // 
      txtAPIKey.Location = new Point(88, 26);
      txtAPIKey.Margin = new Padding(4);
      txtAPIKey.Name = "txtAPIKey";
      txtAPIKey.Size = new Size(127, 23);
      txtAPIKey.TabIndex = 57;
      // 
      // btnLogin
      // 
      btnLogin.Location = new Point(9, 88);
      btnLogin.Margin = new Padding(4);
      btnLogin.Name = "btnLogin";
      btnLogin.Size = new Size(100, 35);
      btnLogin.TabIndex = 55;
      btnLogin.Text = "Login";
      btnLogin.UseVisualStyleBackColor = true;
      btnLogin.Click += btnLogin_Click;
      // 
      // lblSRS
      // 
      lblSRS.AutoSize = true;
      lblSRS.Location = new Point(12, 55);
      lblSRS.Margin = new Padding(4, 0, 4, 0);
      lblSRS.Name = "lblSRS";
      lblSRS.Size = new Size(26, 15);
      lblSRS.TabIndex = 60;
      lblSRS.Text = "SRS";
      // 
      // lblAPIKey
      // 
      lblAPIKey.AutoSize = true;
      lblAPIKey.Location = new Point(12, 25);
      lblAPIKey.Margin = new Padding(4, 0, 4, 0);
      lblAPIKey.Name = "lblAPIKey";
      lblAPIKey.Size = new Size(47, 15);
      lblAPIKey.TabIndex = 56;
      lblAPIKey.Text = "API Key";
      // 
      // txtSrs
      // 
      txtSrs.Location = new Point(88, 57);
      txtSrs.Margin = new Padding(4);
      txtSrs.Name = "txtSrs";
      txtSrs.Size = new Size(127, 23);
      txtSrs.TabIndex = 61;
      txtSrs.Text = "EPSG:28992";
      // 
      // btnLogout
      // 
      btnLogout.Location = new Point(115, 88);
      btnLogout.Margin = new Padding(4);
      btnLogout.Name = "btnLogout";
      btnLogout.Size = new Size(100, 35);
      btnLogout.TabIndex = 58;
      btnLogout.Text = "Logout";
      btnLogout.UseVisualStyleBackColor = true;
      // 
      // btnSave
      // 
      btnSave.Location = new Point(9, 131);
      btnSave.Margin = new Padding(4);
      btnSave.Name = "btnSave";
      btnSave.Size = new Size(206, 34);
      btnSave.TabIndex = 59;
      btnSave.Text = "Save";
      btnSave.UseVisualStyleBackColor = true;
      // 
      // grLogin
      // 
      grLogin.Controls.Add(plLoginWay);
      grLogin.Controls.Add(plUsernamePassword);
      grLogin.Dock = DockStyle.Left;
      grLogin.Location = new Point(3, 3);
      grLogin.Name = "grLogin";
      grLogin.Size = new Size(500, 251);
      grLogin.TabIndex = 64;
      grLogin.TabStop = false;
      grLogin.Text = "login information";
      // 
      // plLoginWay
      // 
      plLoginWay.Controls.Add(grLoginWay);
      plLoginWay.Dock = DockStyle.Fill;
      plLoginWay.Location = new Point(3, 132);
      plLoginWay.Name = "plLoginWay";
      plLoginWay.Size = new Size(494, 116);
      plLoginWay.TabIndex = 68;
      // 
      // grLoginWay
      // 
      grLoginWay.Controls.Add(rbBasicLogin);
      grLoginWay.Controls.Add(rbOAuthLogin);
      grLoginWay.Dock = DockStyle.Fill;
      grLoginWay.Location = new Point(0, 0);
      grLoginWay.Margin = new Padding(4);
      grLoginWay.Name = "grLoginWay";
      grLoginWay.Padding = new Padding(4);
      grLoginWay.Size = new Size(494, 116);
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
      // plUsernamePassword
      // 
      plUsernamePassword.Controls.Add(lblUsername);
      plUsernamePassword.Controls.Add(lblClientId);
      plUsernamePassword.Controls.Add(lblPassword);
      plUsernamePassword.Controls.Add(txtClientId);
      plUsernamePassword.Controls.Add(txtPassword);
      plUsernamePassword.Controls.Add(txtUsername);
      plUsernamePassword.Dock = DockStyle.Top;
      plUsernamePassword.Location = new Point(3, 19);
      plUsernamePassword.Name = "plUsernamePassword";
      plUsernamePassword.Size = new Size(494, 113);
      plUsernamePassword.TabIndex = 67;
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
      // lblClientId
      // 
      lblClientId.AutoSize = true;
      lblClientId.Location = new Point(244, 15);
      lblClientId.Margin = new Padding(4, 0, 4, 0);
      lblClientId.Name = "lblClientId";
      lblClientId.Size = new Size(48, 15);
      lblClientId.TabIndex = 66;
      lblClientId.Text = "ClientId";
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
      // txtClientId
      // 
      txtClientId.Location = new Point(314, 15);
      txtClientId.Margin = new Padding(4);
      txtClientId.Name = "txtClientId";
      txtClientId.Size = new Size(150, 23);
      txtClientId.TabIndex = 65;
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
      // txtUsername
      // 
      txtUsername.Location = new Point(74, 15);
      txtUsername.Margin = new Padding(4);
      txtUsername.Name = "txtUsername";
      txtUsername.Size = new Size(150, 23);
      txtUsername.TabIndex = 53;
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
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      grLogin.ResumeLayout(false);
      plLoginWay.ResumeLayout(false);
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
    private Label lblClientId;
    private TextBox txtClientId;
    private GroupBox grLoginWay;
    private RadioButton rbBasicLogin;
    private RadioButton rbOAuthLogin;
    private Panel plUsernamePassword;
    private Panel plLoginWay;
    private Panel panel1;
  }
}