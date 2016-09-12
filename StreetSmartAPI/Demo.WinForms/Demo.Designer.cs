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
      this.txtDomElementScript = new System.Windows.Forms.TextBox();
      this.btnOpen2eViewer = new System.Windows.Forms.Button();
      this.btnZoomOut = new System.Windows.Forms.Button();
      this.btnZoomIn = new System.Windows.Forms.Button();
      this.btnOpenByCoordinate = new System.Windows.Forms.Button();
      this.btnOpenByImageId = new System.Windows.Forms.Button();
      this.txtImageId = new System.Windows.Forms.TextBox();
      this.lblImageId = new System.Windows.Forms.Label();
      this.btnToggleTimeTravelExpanded = new System.Windows.Forms.Button();
      this.btnToggleTimeTravelVisible = new System.Windows.Forms.Button();
      this.btnToggleNavbarExpanded = new System.Windows.Forms.Button();
      this.btnToggleNavbarVisible = new System.Windows.Forms.Button();
      this.btnToggleRecordingsVisible = new System.Windows.Forms.Button();
      this.lblZ = new System.Windows.Forms.Label();
      this.lblY = new System.Windows.Forms.Label();
      this.lblX = new System.Windows.Forms.Label();
      this.txtZ = new System.Windows.Forms.TextBox();
      this.txtY = new System.Windows.Forms.TextBox();
      this.txtX = new System.Windows.Forms.TextBox();
      this.btnLookAtCoordinate = new System.Windows.Forms.Button();
      this.btnGetRecording = new System.Windows.Forms.Button();
      this.btnSetOrientation = new System.Windows.Forms.Button();
      this.txthFov = new System.Windows.Forms.TextBox();
      this.lblhFov = new System.Windows.Forms.Label();
      this.txtPitch = new System.Windows.Forms.TextBox();
      this.txtYaw = new System.Windows.Forms.TextBox();
      this.lblPitch = new System.Windows.Forms.Label();
      this.lblYaw = new System.Windows.Forms.Label();
      this.btnOrientation = new System.Windows.Forms.Button();
      this.btnRotateDown = new System.Windows.Forms.Button();
      this.btnRotateUp = new System.Windows.Forms.Button();
      this.btnGetViewerColor = new System.Windows.Forms.Button();
      this.btnOpenByAddress = new System.Windows.Forms.Button();
      this.txtSrs = new System.Windows.Forms.TextBox();
      this.txtAdress = new System.Windows.Forms.TextBox();
      this.lblSrs = new System.Windows.Forms.Label();
      this.lblAddress = new System.Windows.Forms.Label();
      this.btnPermissions = new System.Windows.Forms.Button();
      this.btnApplicationName = new System.Windows.Forms.Button();
      this.btnApplicationVersion = new System.Windows.Forms.Button();
      this.btnApiReadyState = new System.Windows.Forms.Button();
      this.btnDestroyViewer = new System.Windows.Forms.Button();
      this.btnRotateRight = new System.Windows.Forms.Button();
      this.btnLogin = new System.Windows.Forms.Button();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.lblPassword = new System.Windows.Forms.Label();
      this.lblUsername = new System.Windows.Forms.Label();
      this.btRotateLeft = new System.Windows.Forms.Button();
      this.plControl.SuspendLayout();
      this.SuspendLayout();
      // 
      // plStreetSmart
      // 
      this.plStreetSmart.Dock = System.Windows.Forms.DockStyle.Left;
      this.plStreetSmart.Location = new System.Drawing.Point(0, 0);
      this.plStreetSmart.Name = "plStreetSmart";
      this.plStreetSmart.Size = new System.Drawing.Size(900, 662);
      this.plStreetSmart.TabIndex = 0;
      // 
      // plControl
      // 
      this.plControl.Controls.Add(this.txtDomElementScript);
      this.plControl.Controls.Add(this.btnOpen2eViewer);
      this.plControl.Controls.Add(this.btnZoomOut);
      this.plControl.Controls.Add(this.btnZoomIn);
      this.plControl.Controls.Add(this.btnOpenByCoordinate);
      this.plControl.Controls.Add(this.btnOpenByImageId);
      this.plControl.Controls.Add(this.txtImageId);
      this.plControl.Controls.Add(this.lblImageId);
      this.plControl.Controls.Add(this.btnToggleTimeTravelExpanded);
      this.plControl.Controls.Add(this.btnToggleTimeTravelVisible);
      this.plControl.Controls.Add(this.btnToggleNavbarExpanded);
      this.plControl.Controls.Add(this.btnToggleNavbarVisible);
      this.plControl.Controls.Add(this.btnToggleRecordingsVisible);
      this.plControl.Controls.Add(this.lblZ);
      this.plControl.Controls.Add(this.lblY);
      this.plControl.Controls.Add(this.lblX);
      this.plControl.Controls.Add(this.txtZ);
      this.plControl.Controls.Add(this.txtY);
      this.plControl.Controls.Add(this.txtX);
      this.plControl.Controls.Add(this.btnLookAtCoordinate);
      this.plControl.Controls.Add(this.btnGetRecording);
      this.plControl.Controls.Add(this.btnSetOrientation);
      this.plControl.Controls.Add(this.txthFov);
      this.plControl.Controls.Add(this.lblhFov);
      this.plControl.Controls.Add(this.txtPitch);
      this.plControl.Controls.Add(this.txtYaw);
      this.plControl.Controls.Add(this.lblPitch);
      this.plControl.Controls.Add(this.lblYaw);
      this.plControl.Controls.Add(this.btnOrientation);
      this.plControl.Controls.Add(this.btnRotateDown);
      this.plControl.Controls.Add(this.btnRotateUp);
      this.plControl.Controls.Add(this.btnGetViewerColor);
      this.plControl.Controls.Add(this.btnOpenByAddress);
      this.plControl.Controls.Add(this.txtSrs);
      this.plControl.Controls.Add(this.txtAdress);
      this.plControl.Controls.Add(this.lblSrs);
      this.plControl.Controls.Add(this.lblAddress);
      this.plControl.Controls.Add(this.btnPermissions);
      this.plControl.Controls.Add(this.btnApplicationName);
      this.plControl.Controls.Add(this.btnApplicationVersion);
      this.plControl.Controls.Add(this.btnApiReadyState);
      this.plControl.Controls.Add(this.btnDestroyViewer);
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
      this.plControl.Size = new System.Drawing.Size(484, 662);
      this.plControl.TabIndex = 1;
      // 
      // txtDomElementScript
      // 
      this.txtDomElementScript.Location = new System.Drawing.Point(3, 572);
      this.txtDomElementScript.Multiline = true;
      this.txtDomElementScript.Name = "txtDomElementScript";
      this.txtDomElementScript.Size = new System.Drawing.Size(478, 90);
      this.txtDomElementScript.TabIndex = 48;
      // 
      // btnOpen2eViewer
      // 
      this.btnOpen2eViewer.Location = new System.Drawing.Point(10, 536);
      this.btnOpen2eViewer.Name = "btnOpen2eViewer";
      this.btnOpen2eViewer.Size = new System.Drawing.Size(100, 30);
      this.btnOpen2eViewer.TabIndex = 47;
      this.btnOpen2eViewer.Text = "Open 2e viewer";
      this.btnOpen2eViewer.UseVisualStyleBackColor = true;
      this.btnOpen2eViewer.Click += new System.EventHandler(this.btnOpen2eViewer_Click);
      // 
      // btnZoomOut
      // 
      this.btnZoomOut.Location = new System.Drawing.Point(380, 208);
      this.btnZoomOut.Name = "btnZoomOut";
      this.btnZoomOut.Size = new System.Drawing.Size(80, 30);
      this.btnZoomOut.TabIndex = 46;
      this.btnZoomOut.Text = "Zoom out";
      this.btnZoomOut.UseVisualStyleBackColor = true;
      this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
      // 
      // btnZoomIn
      // 
      this.btnZoomIn.Location = new System.Drawing.Point(380, 172);
      this.btnZoomIn.Name = "btnZoomIn";
      this.btnZoomIn.Size = new System.Drawing.Size(80, 30);
      this.btnZoomIn.TabIndex = 45;
      this.btnZoomIn.Text = "Zoom in";
      this.btnZoomIn.UseVisualStyleBackColor = true;
      this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
      // 
      // btnOpenByCoordinate
      // 
      this.btnOpenByCoordinate.Location = new System.Drawing.Point(196, 365);
      this.btnOpenByCoordinate.Name = "btnOpenByCoordinate";
      this.btnOpenByCoordinate.Size = new System.Drawing.Size(110, 30);
      this.btnOpenByCoordinate.TabIndex = 44;
      this.btnOpenByCoordinate.Text = "Open by Coordinate";
      this.btnOpenByCoordinate.UseVisualStyleBackColor = true;
      this.btnOpenByCoordinate.Click += new System.EventHandler(this.btnOpenByCoordinate_Click);
      // 
      // btnOpenByImageId
      // 
      this.btnOpenByImageId.Location = new System.Drawing.Point(150, 509);
      this.btnOpenByImageId.Name = "btnOpenByImageId";
      this.btnOpenByImageId.Size = new System.Drawing.Size(100, 30);
      this.btnOpenByImageId.TabIndex = 43;
      this.btnOpenByImageId.Text = "Open by ImageId";
      this.btnOpenByImageId.UseVisualStyleBackColor = true;
      this.btnOpenByImageId.Click += new System.EventHandler(this.btnOpenByImageId_Click);
      // 
      // txtImageId
      // 
      this.txtImageId.Location = new System.Drawing.Point(321, 509);
      this.txtImageId.Name = "txtImageId";
      this.txtImageId.Size = new System.Drawing.Size(100, 20);
      this.txtImageId.TabIndex = 42;
      // 
      // lblImageId
      // 
      this.lblImageId.AutoSize = true;
      this.lblImageId.Location = new System.Drawing.Point(256, 509);
      this.lblImageId.Name = "lblImageId";
      this.lblImageId.Size = new System.Drawing.Size(45, 13);
      this.lblImageId.TabIndex = 41;
      this.lblImageId.Text = "ImageId";
      // 
      // btnToggleTimeTravelExpanded
      // 
      this.btnToggleTimeTravelExpanded.Location = new System.Drawing.Point(320, 125);
      this.btnToggleTimeTravelExpanded.Name = "btnToggleTimeTravelExpanded";
      this.btnToggleTimeTravelExpanded.Size = new System.Drawing.Size(160, 30);
      this.btnToggleTimeTravelExpanded.TabIndex = 40;
      this.btnToggleTimeTravelExpanded.Text = "Toggle Time Travel Expanded";
      this.btnToggleTimeTravelExpanded.UseVisualStyleBackColor = true;
      this.btnToggleTimeTravelExpanded.Click += new System.EventHandler(this.btnToggleTimeTravelExpanded_Click);
      // 
      // btnToggleTimeTravelVisible
      // 
      this.btnToggleTimeTravelVisible.Location = new System.Drawing.Point(168, 172);
      this.btnToggleTimeTravelVisible.Name = "btnToggleTimeTravelVisible";
      this.btnToggleTimeTravelVisible.Size = new System.Drawing.Size(140, 30);
      this.btnToggleTimeTravelVisible.TabIndex = 39;
      this.btnToggleTimeTravelVisible.Text = "Toggle Time Travel Visible";
      this.btnToggleTimeTravelVisible.UseVisualStyleBackColor = true;
      this.btnToggleTimeTravelVisible.Click += new System.EventHandler(this.btnToggleTimeTravelVisible_Click);
      // 
      // btnToggleNavbarExpanded
      // 
      this.btnToggleNavbarExpanded.Location = new System.Drawing.Point(166, 125);
      this.btnToggleNavbarExpanded.Name = "btnToggleNavbarExpanded";
      this.btnToggleNavbarExpanded.Size = new System.Drawing.Size(140, 30);
      this.btnToggleNavbarExpanded.TabIndex = 38;
      this.btnToggleNavbarExpanded.Text = "Toggle Navbar Expanded";
      this.btnToggleNavbarExpanded.UseVisualStyleBackColor = true;
      this.btnToggleNavbarExpanded.Click += new System.EventHandler(this.btnToggleNavbarExpanded_Click);
      // 
      // btnToggleNavbarVisible
      // 
      this.btnToggleNavbarVisible.Location = new System.Drawing.Point(10, 172);
      this.btnToggleNavbarVisible.Name = "btnToggleNavbarVisible";
      this.btnToggleNavbarVisible.Size = new System.Drawing.Size(140, 30);
      this.btnToggleNavbarVisible.TabIndex = 37;
      this.btnToggleNavbarVisible.Text = "Toggle Navbar Visible";
      this.btnToggleNavbarVisible.UseVisualStyleBackColor = true;
      this.btnToggleNavbarVisible.Click += new System.EventHandler(this.btnToggleNavbarVisible_Click);
      // 
      // btnToggleRecordingsVisible
      // 
      this.btnToggleRecordingsVisible.Location = new System.Drawing.Point(10, 125);
      this.btnToggleRecordingsVisible.Name = "btnToggleRecordingsVisible";
      this.btnToggleRecordingsVisible.Size = new System.Drawing.Size(140, 30);
      this.btnToggleRecordingsVisible.TabIndex = 36;
      this.btnToggleRecordingsVisible.Text = "Toggle Recordings Visible";
      this.btnToggleRecordingsVisible.UseVisualStyleBackColor = true;
      this.btnToggleRecordingsVisible.Click += new System.EventHandler(this.btnToggleRecordingsVisible_Click);
      // 
      // lblZ
      // 
      this.lblZ.AutoSize = true;
      this.lblZ.Location = new System.Drawing.Point(332, 457);
      this.lblZ.Name = "lblZ";
      this.lblZ.Size = new System.Drawing.Size(14, 13);
      this.lblZ.TabIndex = 35;
      this.lblZ.Text = "Z";
      // 
      // lblY
      // 
      this.lblY.AutoSize = true;
      this.lblY.Location = new System.Drawing.Point(332, 431);
      this.lblY.Name = "lblY";
      this.lblY.Size = new System.Drawing.Size(14, 13);
      this.lblY.TabIndex = 34;
      this.lblY.Text = "Y";
      // 
      // lblX
      // 
      this.lblX.AutoSize = true;
      this.lblX.Location = new System.Drawing.Point(332, 401);
      this.lblX.Name = "lblX";
      this.lblX.Size = new System.Drawing.Size(14, 13);
      this.lblX.TabIndex = 33;
      this.lblX.Text = "X";
      // 
      // txtZ
      // 
      this.txtZ.Location = new System.Drawing.Point(372, 457);
      this.txtZ.Name = "txtZ";
      this.txtZ.Size = new System.Drawing.Size(100, 20);
      this.txtZ.TabIndex = 32;
      // 
      // txtY
      // 
      this.txtY.Location = new System.Drawing.Point(372, 431);
      this.txtY.Name = "txtY";
      this.txtY.Size = new System.Drawing.Size(100, 20);
      this.txtY.TabIndex = 31;
      this.txtY.Text = "0.0";
      // 
      // txtX
      // 
      this.txtX.Location = new System.Drawing.Point(372, 401);
      this.txtX.Name = "txtX";
      this.txtX.Size = new System.Drawing.Size(100, 20);
      this.txtX.TabIndex = 30;
      this.txtX.Text = "0.0";
      // 
      // btnLookAtCoordinate
      // 
      this.btnLookAtCoordinate.Location = new System.Drawing.Point(196, 401);
      this.btnLookAtCoordinate.Name = "btnLookAtCoordinate";
      this.btnLookAtCoordinate.Size = new System.Drawing.Size(110, 30);
      this.btnLookAtCoordinate.TabIndex = 29;
      this.btnLookAtCoordinate.Text = "Look at Coordinate";
      this.btnLookAtCoordinate.UseVisualStyleBackColor = true;
      this.btnLookAtCoordinate.Click += new System.EventHandler(this.btnLookAtCoordinate_Click);
      // 
      // btnGetRecording
      // 
      this.btnGetRecording.Location = new System.Drawing.Point(206, 447);
      this.btnGetRecording.Name = "btnGetRecording";
      this.btnGetRecording.Size = new System.Drawing.Size(100, 30);
      this.btnGetRecording.TabIndex = 28;
      this.btnGetRecording.Text = "Get Recording";
      this.btnGetRecording.UseVisualStyleBackColor = true;
      this.btnGetRecording.Click += new System.EventHandler(this.btnGetRecording_Click);
      // 
      // btnSetOrientation
      // 
      this.btnSetOrientation.Location = new System.Drawing.Point(189, 279);
      this.btnSetOrientation.Name = "btnSetOrientation";
      this.btnSetOrientation.Size = new System.Drawing.Size(100, 30);
      this.btnSetOrientation.TabIndex = 27;
      this.btnSetOrientation.Text = "Set Orientation";
      this.btnSetOrientation.UseVisualStyleBackColor = true;
      this.btnSetOrientation.Click += new System.EventHandler(this.btnSetOrientation_Click);
      // 
      // txthFov
      // 
      this.txthFov.Location = new System.Drawing.Point(360, 335);
      this.txthFov.Name = "txthFov";
      this.txthFov.Size = new System.Drawing.Size(100, 20);
      this.txthFov.TabIndex = 26;
      // 
      // lblhFov
      // 
      this.lblhFov.AutoSize = true;
      this.lblhFov.Location = new System.Drawing.Point(295, 335);
      this.lblhFov.Name = "lblhFov";
      this.lblhFov.Size = new System.Drawing.Size(31, 13);
      this.lblhFov.TabIndex = 25;
      this.lblhFov.Text = "hFov";
      // 
      // txtPitch
      // 
      this.txtPitch.Location = new System.Drawing.Point(360, 309);
      this.txtPitch.Name = "txtPitch";
      this.txtPitch.Size = new System.Drawing.Size(100, 20);
      this.txtPitch.TabIndex = 24;
      // 
      // txtYaw
      // 
      this.txtYaw.Location = new System.Drawing.Point(360, 279);
      this.txtYaw.Name = "txtYaw";
      this.txtYaw.Size = new System.Drawing.Size(100, 20);
      this.txtYaw.TabIndex = 23;
      // 
      // lblPitch
      // 
      this.lblPitch.AutoSize = true;
      this.lblPitch.Location = new System.Drawing.Point(295, 309);
      this.lblPitch.Name = "lblPitch";
      this.lblPitch.Size = new System.Drawing.Size(31, 13);
      this.lblPitch.TabIndex = 22;
      this.lblPitch.Text = "Pitch";
      // 
      // lblYaw
      // 
      this.lblYaw.AutoSize = true;
      this.lblYaw.Location = new System.Drawing.Point(295, 279);
      this.lblYaw.Name = "lblYaw";
      this.lblYaw.Size = new System.Drawing.Size(28, 13);
      this.lblYaw.TabIndex = 21;
      this.lblYaw.Text = "Yaw";
      // 
      // btnOrientation
      // 
      this.btnOrientation.Location = new System.Drawing.Point(10, 279);
      this.btnOrientation.Name = "btnOrientation";
      this.btnOrientation.Size = new System.Drawing.Size(100, 30);
      this.btnOrientation.TabIndex = 20;
      this.btnOrientation.Text = "Get Orientation";
      this.btnOrientation.UseVisualStyleBackColor = true;
      this.btnOrientation.Click += new System.EventHandler(this.btnOrientation_Click);
      // 
      // btnRotateDown
      // 
      this.btnRotateDown.Location = new System.Drawing.Point(266, 221);
      this.btnRotateDown.Name = "btnRotateDown";
      this.btnRotateDown.Size = new System.Drawing.Size(80, 30);
      this.btnRotateDown.TabIndex = 19;
      this.btnRotateDown.Text = "Rotate Down";
      this.btnRotateDown.UseVisualStyleBackColor = true;
      this.btnRotateDown.Click += new System.EventHandler(this.btnRotateDown_Click);
      // 
      // btnRotateUp
      // 
      this.btnRotateUp.Location = new System.Drawing.Point(180, 221);
      this.btnRotateUp.Name = "btnRotateUp";
      this.btnRotateUp.Size = new System.Drawing.Size(80, 30);
      this.btnRotateUp.TabIndex = 18;
      this.btnRotateUp.Text = "Rotate Up";
      this.btnRotateUp.UseVisualStyleBackColor = true;
      this.btnRotateUp.Click += new System.EventHandler(this.btnRotateUp_Click);
      // 
      // btnGetViewerColor
      // 
      this.btnGetViewerColor.Location = new System.Drawing.Point(335, 69);
      this.btnGetViewerColor.Name = "btnGetViewerColor";
      this.btnGetViewerColor.Size = new System.Drawing.Size(100, 30);
      this.btnGetViewerColor.TabIndex = 17;
      this.btnGetViewerColor.Text = "Get Viewer Color";
      this.btnGetViewerColor.UseVisualStyleBackColor = true;
      this.btnGetViewerColor.Click += new System.EventHandler(this.btnGetViewerColor_Click);
      // 
      // btnOpenByAddress
      // 
      this.btnOpenByAddress.Location = new System.Drawing.Point(208, 69);
      this.btnOpenByAddress.Name = "btnOpenByAddress";
      this.btnOpenByAddress.Size = new System.Drawing.Size(100, 30);
      this.btnOpenByAddress.TabIndex = 16;
      this.btnOpenByAddress.Text = "Open By Address";
      this.btnOpenByAddress.UseVisualStyleBackColor = true;
      this.btnOpenByAddress.Click += new System.EventHandler(this.btnOpenByAddress_Click);
      // 
      // txtSrs
      // 
      this.txtSrs.Location = new System.Drawing.Point(248, 43);
      this.txtSrs.Name = "txtSrs";
      this.txtSrs.Size = new System.Drawing.Size(212, 20);
      this.txtSrs.TabIndex = 15;
      this.txtSrs.Text = "EPSG:28992";
      // 
      // txtAdress
      // 
      this.txtAdress.Location = new System.Drawing.Point(248, 12);
      this.txtAdress.Name = "txtAdress";
      this.txtAdress.Size = new System.Drawing.Size(212, 20);
      this.txtAdress.TabIndex = 14;
      this.txtAdress.Text = "Van Voordenpark 1B, Zaltbommel";
      // 
      // lblSrs
      // 
      this.lblSrs.AutoSize = true;
      this.lblSrs.Location = new System.Drawing.Point(193, 43);
      this.lblSrs.Name = "lblSrs";
      this.lblSrs.Size = new System.Drawing.Size(22, 13);
      this.lblSrs.TabIndex = 13;
      this.lblSrs.Text = "Srs";
      // 
      // lblAddress
      // 
      this.lblAddress.AutoSize = true;
      this.lblAddress.Location = new System.Drawing.Point(193, 9);
      this.lblAddress.Name = "lblAddress";
      this.lblAddress.Size = new System.Drawing.Size(45, 13);
      this.lblAddress.TabIndex = 12;
      this.lblAddress.Text = "Address";
      // 
      // btnPermissions
      // 
      this.btnPermissions.Location = new System.Drawing.Point(10, 509);
      this.btnPermissions.Name = "btnPermissions";
      this.btnPermissions.Size = new System.Drawing.Size(100, 30);
      this.btnPermissions.TabIndex = 11;
      this.btnPermissions.Text = "Permissions";
      this.btnPermissions.UseVisualStyleBackColor = true;
      this.btnPermissions.Click += new System.EventHandler(this.btnPermissions_Click);
      // 
      // btnApplicationName
      // 
      this.btnApplicationName.Location = new System.Drawing.Point(10, 473);
      this.btnApplicationName.Name = "btnApplicationName";
      this.btnApplicationName.Size = new System.Drawing.Size(100, 30);
      this.btnApplicationName.TabIndex = 10;
      this.btnApplicationName.Text = "Application Name";
      this.btnApplicationName.UseVisualStyleBackColor = true;
      this.btnApplicationName.Click += new System.EventHandler(this.btnApplicationName_Click);
      // 
      // btnApplicationVersion
      // 
      this.btnApplicationVersion.Location = new System.Drawing.Point(10, 437);
      this.btnApplicationVersion.Name = "btnApplicationVersion";
      this.btnApplicationVersion.Size = new System.Drawing.Size(121, 30);
      this.btnApplicationVersion.TabIndex = 9;
      this.btnApplicationVersion.Text = "ApplicationVersion";
      this.btnApplicationVersion.UseVisualStyleBackColor = true;
      this.btnApplicationVersion.Click += new System.EventHandler(this.btnApplicationVersion_Click);
      // 
      // btnApiReadyState
      // 
      this.btnApiReadyState.Location = new System.Drawing.Point(10, 401);
      this.btnApiReadyState.Name = "btnApiReadyState";
      this.btnApiReadyState.Size = new System.Drawing.Size(100, 30);
      this.btnApiReadyState.TabIndex = 8;
      this.btnApiReadyState.Text = "Api Ready State";
      this.btnApiReadyState.UseVisualStyleBackColor = true;
      this.btnApiReadyState.Click += new System.EventHandler(this.btnApiReadyState_Click);
      // 
      // btnDestroyViewer
      // 
      this.btnDestroyViewer.Location = new System.Drawing.Point(31, 350);
      this.btnDestroyViewer.Name = "btnDestroyViewer";
      this.btnDestroyViewer.Size = new System.Drawing.Size(100, 30);
      this.btnDestroyViewer.TabIndex = 7;
      this.btnDestroyViewer.Text = "Destroy viewer";
      this.btnDestroyViewer.UseVisualStyleBackColor = true;
      this.btnDestroyViewer.Click += new System.EventHandler(this.btnDestroyViewer_Click);
      // 
      // btnRotateRight
      // 
      this.btnRotateRight.Location = new System.Drawing.Point(94, 221);
      this.btnRotateRight.Name = "btnRotateRight";
      this.btnRotateRight.Size = new System.Drawing.Size(80, 30);
      this.btnRotateRight.TabIndex = 6;
      this.btnRotateRight.Text = "Rotate Right";
      this.btnRotateRight.UseVisualStyleBackColor = true;
      this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
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
      this.btRotateLeft.Location = new System.Drawing.Point(8, 221);
      this.btRotateLeft.Name = "btRotateLeft";
      this.btRotateLeft.Size = new System.Drawing.Size(80, 30);
      this.btRotateLeft.TabIndex = 0;
      this.btRotateLeft.Text = "Rotate Left";
      this.btRotateLeft.UseVisualStyleBackColor = true;
      this.btRotateLeft.Click += new System.EventHandler(this.btRotateLeft_Click);
      // 
      // Demo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1384, 662);
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
    private System.Windows.Forms.Button btnDestroyViewer;
    private System.Windows.Forms.Button btnApiReadyState;
    private System.Windows.Forms.Button btnPermissions;
    private System.Windows.Forms.Button btnApplicationName;
    private System.Windows.Forms.Button btnApplicationVersion;
    private System.Windows.Forms.TextBox txtSrs;
    private System.Windows.Forms.TextBox txtAdress;
    private System.Windows.Forms.Label lblSrs;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.Button btnOpenByAddress;
    private System.Windows.Forms.Button btnGetViewerColor;
    private System.Windows.Forms.Button btnRotateDown;
    private System.Windows.Forms.Button btnRotateUp;
    private System.Windows.Forms.Button btnOrientation;
    private System.Windows.Forms.Button btnSetOrientation;
    private System.Windows.Forms.TextBox txthFov;
    private System.Windows.Forms.Label lblhFov;
    private System.Windows.Forms.TextBox txtPitch;
    private System.Windows.Forms.TextBox txtYaw;
    private System.Windows.Forms.Label lblPitch;
    private System.Windows.Forms.Label lblYaw;
    private System.Windows.Forms.Button btnGetRecording;
    private System.Windows.Forms.Button btnLookAtCoordinate;
    private System.Windows.Forms.Label lblZ;
    private System.Windows.Forms.Label lblY;
    private System.Windows.Forms.Label lblX;
    private System.Windows.Forms.TextBox txtZ;
    private System.Windows.Forms.TextBox txtY;
    private System.Windows.Forms.TextBox txtX;
    private System.Windows.Forms.Button btnToggleRecordingsVisible;
    private System.Windows.Forms.Button btnToggleNavbarVisible;
    private System.Windows.Forms.Button btnToggleNavbarExpanded;
    private System.Windows.Forms.Button btnToggleTimeTravelVisible;
    private System.Windows.Forms.Button btnToggleTimeTravelExpanded;
    private System.Windows.Forms.Button btnOpenByImageId;
    private System.Windows.Forms.TextBox txtImageId;
    private System.Windows.Forms.Label lblImageId;
    private System.Windows.Forms.Button btnOpenByCoordinate;
    private System.Windows.Forms.Button btnZoomOut;
    private System.Windows.Forms.Button btnZoomIn;
    private System.Windows.Forms.Button btnOpen2eViewer;
    private System.Windows.Forms.TextBox txtDomElementScript;
  }
}

