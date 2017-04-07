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
      this.grOpenCloseViewer = new System.Windows.Forms.GroupBox();
      this.txtOpenByQuery = new System.Windows.Forms.TextBox();
      this.cbPanorama = new System.Windows.Forms.CheckBox();
      this.cbOblique = new System.Windows.Forms.CheckBox();
      this.btnOpenViewerByQuery = new System.Windows.Forms.Button();
      this.txtLeft = new System.Windows.Forms.TextBox();
      this.lblLeft = new System.Windows.Forms.Label();
      this.txtWidth = new System.Windows.Forms.TextBox();
      this.txtHeight = new System.Windows.Forms.TextBox();
      this.txtTop = new System.Windows.Forms.TextBox();
      this.lblWidth = new System.Windows.Forms.Label();
      this.lblHeight = new System.Windows.Forms.Label();
      this.lblTop = new System.Windows.Forms.Label();
      this.rbParameters = new System.Windows.Forms.RadioButton();
      this.rbDefault = new System.Windows.Forms.RadioButton();
      this.btnOpenViewer = new System.Windows.Forms.Button();
      this.btnDestroyViewer = new System.Windows.Forms.Button();
      this.plControl = new System.Windows.Forms.Panel();
      this.grDevTools = new System.Windows.Forms.GroupBox();
      this.btnCloseDefTools = new System.Windows.Forms.Button();
      this.btnShowDefTools = new System.Windows.Forms.Button();
      this.grRotationsZoomInOut = new System.Windows.Forms.GroupBox();
      this.lblDeltaYawPitch = new System.Windows.Forms.Label();
      this.txtDeltaYawPitch = new System.Windows.Forms.TextBox();
      this.btnRotateDown = new System.Windows.Forms.Button();
      this.btnRotateUp = new System.Windows.Forms.Button();
      this.btnRotateRight = new System.Windows.Forms.Button();
      this.btnZoomOut = new System.Windows.Forms.Button();
      this.btRotateLeft = new System.Windows.Forms.Button();
      this.btnZoomIn = new System.Windows.Forms.Button();
      this.grEvents = new System.Windows.Forms.GroupBox();
      this.lbViewerEvents = new System.Windows.Forms.ListBox();
      this.grRecordingViewerColorPermissions = new System.Windows.Forms.GroupBox();
      this.txtRecordingViewerColorPermissions = new System.Windows.Forms.TextBox();
      this.btnGetPermissions = new System.Windows.Forms.Button();
      this.btnGetRecording = new System.Windows.Forms.Button();
      this.btnGetViewerColor = new System.Windows.Forms.Button();
      this.grOrientation = new System.Windows.Forms.GroupBox();
      this.txtYaw = new System.Windows.Forms.TextBox();
      this.lblYaw = new System.Windows.Forms.Label();
      this.lblPitch = new System.Windows.Forms.Label();
      this.txtPitch = new System.Windows.Forms.TextBox();
      this.lblhFov = new System.Windows.Forms.Label();
      this.txthFov = new System.Windows.Forms.TextBox();
      this.btnGetOrientation = new System.Windows.Forms.Button();
      this.btnSetOrientation = new System.Windows.Forms.Button();
      this.grOpenByImageId = new System.Windows.Forms.GroupBox();
      this.btnGetAddress = new System.Windows.Forms.Button();
      this.lblOpenByImageSrs = new System.Windows.Forms.Label();
      this.txtOpenByImageSrs = new System.Windows.Forms.TextBox();
      this.btnOpenByImageId = new System.Windows.Forms.Button();
      this.lblImageId = new System.Windows.Forms.Label();
      this.txtImageId = new System.Windows.Forms.TextBox();
      this.grCoordinate = new System.Windows.Forms.GroupBox();
      this.lblCoordinateSrs = new System.Windows.Forms.Label();
      this.txtCoordinateSrs = new System.Windows.Forms.TextBox();
      this.txtX = new System.Windows.Forms.TextBox();
      this.txtY = new System.Windows.Forms.TextBox();
      this.txtZ = new System.Windows.Forms.TextBox();
      this.lblX = new System.Windows.Forms.Label();
      this.lblY = new System.Windows.Forms.Label();
      this.lblZ = new System.Windows.Forms.Label();
      this.btnOpenByCoordinate = new System.Windows.Forms.Button();
      this.btnLookAtCoordinate = new System.Windows.Forms.Button();
      this.grAPIInfo = new System.Windows.Forms.GroupBox();
      this.lblResult = new System.Windows.Forms.Label();
      this.txtAPIResult = new System.Windows.Forms.TextBox();
      this.btnApiReadyState = new System.Windows.Forms.Button();
      this.btnApplicationVersion = new System.Windows.Forms.Button();
      this.btnApplicationName = new System.Windows.Forms.Button();
      this.grViewerToggles = new System.Windows.Forms.GroupBox();
      this.btnToggleRecordingsVisible = new System.Windows.Forms.Button();
      this.btnToggleTimeTravelExpanded = new System.Windows.Forms.Button();
      this.btnToggleNavbarExpanded = new System.Windows.Forms.Button();
      this.btnToggleTimeTravelVisible = new System.Windows.Forms.Button();
      this.btnToggleNavbarVisible = new System.Windows.Forms.Button();
      this.grOpenByAddress = new System.Windows.Forms.GroupBox();
      this.lblAddress = new System.Windows.Forms.Label();
      this.txtAdress = new System.Windows.Forms.TextBox();
      this.lblAddressSrs = new System.Windows.Forms.Label();
      this.txtAddressSrs = new System.Windows.Forms.TextBox();
      this.btnOpenByAddress = new System.Windows.Forms.Button();
      this.grLogin = new System.Windows.Forms.GroupBox();
      this.lblAPIKey = new System.Windows.Forms.Label();
      this.txtAPIKey = new System.Windows.Forms.TextBox();
      this.lblUsername = new System.Windows.Forms.Label();
      this.lblPassword = new System.Windows.Forms.Label();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.btnLogin = new System.Windows.Forms.Button();
      this.grOpenCloseViewer.SuspendLayout();
      this.plControl.SuspendLayout();
      this.grDevTools.SuspendLayout();
      this.grRotationsZoomInOut.SuspendLayout();
      this.grEvents.SuspendLayout();
      this.grRecordingViewerColorPermissions.SuspendLayout();
      this.grOrientation.SuspendLayout();
      this.grOpenByImageId.SuspendLayout();
      this.grCoordinate.SuspendLayout();
      this.grAPIInfo.SuspendLayout();
      this.grViewerToggles.SuspendLayout();
      this.grOpenByAddress.SuspendLayout();
      this.grLogin.SuspendLayout();
      this.SuspendLayout();
      // 
      // plStreetSmart
      // 
      this.plStreetSmart.Dock = System.Windows.Forms.DockStyle.Left;
      this.plStreetSmart.Location = new System.Drawing.Point(0, 0);
      this.plStreetSmart.Name = "plStreetSmart";
      this.plStreetSmart.Size = new System.Drawing.Size(900, 762);
      this.plStreetSmart.TabIndex = 0;
      // 
      // grOpenCloseViewer
      // 
      this.grOpenCloseViewer.Controls.Add(this.txtOpenByQuery);
      this.grOpenCloseViewer.Controls.Add(this.cbPanorama);
      this.grOpenCloseViewer.Controls.Add(this.cbOblique);
      this.grOpenCloseViewer.Controls.Add(this.btnOpenViewerByQuery);
      this.grOpenCloseViewer.Controls.Add(this.txtLeft);
      this.grOpenCloseViewer.Controls.Add(this.lblLeft);
      this.grOpenCloseViewer.Controls.Add(this.txtWidth);
      this.grOpenCloseViewer.Controls.Add(this.txtHeight);
      this.grOpenCloseViewer.Controls.Add(this.txtTop);
      this.grOpenCloseViewer.Controls.Add(this.lblWidth);
      this.grOpenCloseViewer.Controls.Add(this.lblHeight);
      this.grOpenCloseViewer.Controls.Add(this.lblTop);
      this.grOpenCloseViewer.Controls.Add(this.rbParameters);
      this.grOpenCloseViewer.Controls.Add(this.rbDefault);
      this.grOpenCloseViewer.Controls.Add(this.btnOpenViewer);
      this.grOpenCloseViewer.Controls.Add(this.btnDestroyViewer);
      this.grOpenCloseViewer.Location = new System.Drawing.Point(0, 290);
      this.grOpenCloseViewer.Name = "grOpenCloseViewer";
      this.grOpenCloseViewer.Size = new System.Drawing.Size(360, 120);
      this.grOpenCloseViewer.TabIndex = 0;
      this.grOpenCloseViewer.TabStop = false;
      this.grOpenCloseViewer.Text = "Open / Close Viewer";
      // 
      // txtOpenByQuery
      // 
      this.txtOpenByQuery.Location = new System.Drawing.Point(240, 50);
      this.txtOpenByQuery.Multiline = true;
      this.txtOpenByQuery.Name = "txtOpenByQuery";
      this.txtOpenByQuery.Size = new System.Drawing.Size(100, 40);
      this.txtOpenByQuery.TabIndex = 67;
      this.txtOpenByQuery.Text = "5D123456";
      // 
      // cbPanorama
      // 
      this.cbPanorama.AutoSize = true;
      this.cbPanorama.Checked = true;
      this.cbPanorama.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbPanorama.Location = new System.Drawing.Point(305, 95);
      this.cbPanorama.Name = "cbPanorama";
      this.cbPanorama.Size = new System.Drawing.Size(45, 17);
      this.cbPanorama.TabIndex = 66;
      this.cbPanorama.Text = "Pan";
      this.cbPanorama.UseVisualStyleBackColor = true;
      // 
      // cbOblique
      // 
      this.cbOblique.AutoSize = true;
      this.cbOblique.Checked = true;
      this.cbOblique.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbOblique.Location = new System.Drawing.Point(240, 95);
      this.cbOblique.Name = "cbOblique";
      this.cbOblique.Size = new System.Drawing.Size(62, 17);
      this.cbOblique.TabIndex = 65;
      this.cbOblique.Text = "Oblique";
      this.cbOblique.UseVisualStyleBackColor = true;
      // 
      // btnOpenViewerByQuery
      // 
      this.btnOpenViewerByQuery.Location = new System.Drawing.Point(240, 15);
      this.btnOpenViewerByQuery.Name = "btnOpenViewerByQuery";
      this.btnOpenViewerByQuery.Size = new System.Drawing.Size(100, 30);
      this.btnOpenViewerByQuery.TabIndex = 64;
      this.btnOpenViewerByQuery.Text = "Open by query";
      this.btnOpenViewerByQuery.UseVisualStyleBackColor = true;
      this.btnOpenViewerByQuery.Click += new System.EventHandler(this.btnOpenViewerByQuery_Click);
      // 
      // txtLeft
      // 
      this.txtLeft.Location = new System.Drawing.Point(145, 90);
      this.txtLeft.Name = "txtLeft";
      this.txtLeft.Size = new System.Drawing.Size(90, 20);
      this.txtLeft.TabIndex = 62;
      this.txtLeft.Text = "400";
      // 
      // lblLeft
      // 
      this.lblLeft.AutoSize = true;
      this.lblLeft.Location = new System.Drawing.Point(105, 95);
      this.lblLeft.Name = "lblLeft";
      this.lblLeft.Size = new System.Drawing.Size(25, 13);
      this.lblLeft.TabIndex = 63;
      this.lblLeft.Text = "Left";
      // 
      // txtWidth
      // 
      this.txtWidth.Location = new System.Drawing.Point(145, 15);
      this.txtWidth.Name = "txtWidth";
      this.txtWidth.Size = new System.Drawing.Size(90, 20);
      this.txtWidth.TabIndex = 56;
      this.txtWidth.Text = "40";
      // 
      // txtHeight
      // 
      this.txtHeight.Location = new System.Drawing.Point(145, 40);
      this.txtHeight.Name = "txtHeight";
      this.txtHeight.Size = new System.Drawing.Size(90, 20);
      this.txtHeight.TabIndex = 57;
      this.txtHeight.Text = "40";
      // 
      // txtTop
      // 
      this.txtTop.Location = new System.Drawing.Point(145, 65);
      this.txtTop.Name = "txtTop";
      this.txtTop.Size = new System.Drawing.Size(90, 20);
      this.txtTop.TabIndex = 58;
      this.txtTop.Text = "300";
      // 
      // lblWidth
      // 
      this.lblWidth.AutoSize = true;
      this.lblWidth.Location = new System.Drawing.Point(105, 20);
      this.lblWidth.Name = "lblWidth";
      this.lblWidth.Size = new System.Drawing.Size(35, 13);
      this.lblWidth.TabIndex = 59;
      this.lblWidth.Text = "Width";
      // 
      // lblHeight
      // 
      this.lblHeight.AutoSize = true;
      this.lblHeight.Location = new System.Drawing.Point(105, 45);
      this.lblHeight.Name = "lblHeight";
      this.lblHeight.Size = new System.Drawing.Size(38, 13);
      this.lblHeight.TabIndex = 60;
      this.lblHeight.Text = "Height";
      // 
      // lblTop
      // 
      this.lblTop.AutoSize = true;
      this.lblTop.Location = new System.Drawing.Point(105, 70);
      this.lblTop.Name = "lblTop";
      this.lblTop.Size = new System.Drawing.Size(26, 13);
      this.lblTop.TabIndex = 61;
      this.lblTop.Text = "Top";
      // 
      // rbParameters
      // 
      this.rbParameters.AutoSize = true;
      this.rbParameters.Location = new System.Drawing.Point(10, 65);
      this.rbParameters.Name = "rbParameters";
      this.rbParameters.Size = new System.Drawing.Size(78, 17);
      this.rbParameters.TabIndex = 55;
      this.rbParameters.Text = "Parameters";
      this.rbParameters.UseVisualStyleBackColor = true;
      // 
      // rbDefault
      // 
      this.rbDefault.AutoSize = true;
      this.rbDefault.Checked = true;
      this.rbDefault.Location = new System.Drawing.Point(10, 45);
      this.rbDefault.Name = "rbDefault";
      this.rbDefault.Size = new System.Drawing.Size(59, 17);
      this.rbDefault.TabIndex = 54;
      this.rbDefault.TabStop = true;
      this.rbDefault.Text = "Default";
      this.rbDefault.UseVisualStyleBackColor = true;
      // 
      // btnOpenViewer
      // 
      this.btnOpenViewer.Location = new System.Drawing.Point(5, 15);
      this.btnOpenViewer.Name = "btnOpenViewer";
      this.btnOpenViewer.Size = new System.Drawing.Size(100, 30);
      this.btnOpenViewer.TabIndex = 47;
      this.btnOpenViewer.Text = "Open viewer";
      this.btnOpenViewer.UseVisualStyleBackColor = true;
      this.btnOpenViewer.Click += new System.EventHandler(this.btnOpenViewer_Click);
      // 
      // btnDestroyViewer
      // 
      this.btnDestroyViewer.Location = new System.Drawing.Point(5, 85);
      this.btnDestroyViewer.Name = "btnDestroyViewer";
      this.btnDestroyViewer.Size = new System.Drawing.Size(100, 30);
      this.btnDestroyViewer.TabIndex = 7;
      this.btnDestroyViewer.Text = "Destroy viewer";
      this.btnDestroyViewer.UseVisualStyleBackColor = true;
      this.btnDestroyViewer.Click += new System.EventHandler(this.btnDestroyViewer_Click);
      // 
      // plControl
      // 
      this.plControl.Controls.Add(this.grDevTools);
      this.plControl.Controls.Add(this.grRotationsZoomInOut);
      this.plControl.Controls.Add(this.grEvents);
      this.plControl.Controls.Add(this.grRecordingViewerColorPermissions);
      this.plControl.Controls.Add(this.grOrientation);
      this.plControl.Controls.Add(this.grOpenByImageId);
      this.plControl.Controls.Add(this.grCoordinate);
      this.plControl.Controls.Add(this.grOpenCloseViewer);
      this.plControl.Controls.Add(this.grAPIInfo);
      this.plControl.Controls.Add(this.grViewerToggles);
      this.plControl.Controls.Add(this.grOpenByAddress);
      this.plControl.Controls.Add(this.grLogin);
      this.plControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.plControl.Location = new System.Drawing.Point(900, 0);
      this.plControl.Name = "plControl";
      this.plControl.Size = new System.Drawing.Size(484, 762);
      this.plControl.TabIndex = 1;
      // 
      // grDevTools
      // 
      this.grDevTools.Controls.Add(this.btnCloseDefTools);
      this.grDevTools.Controls.Add(this.btnShowDefTools);
      this.grDevTools.Location = new System.Drawing.Point(360, 290);
      this.grDevTools.Name = "grDevTools";
      this.grDevTools.Size = new System.Drawing.Size(120, 120);
      this.grDevTools.TabIndex = 51;
      this.grDevTools.TabStop = false;
      this.grDevTools.Text = "Dev tools";
      // 
      // btnCloseDefTools
      // 
      this.btnCloseDefTools.Location = new System.Drawing.Point(5, 85);
      this.btnCloseDefTools.Name = "btnCloseDefTools";
      this.btnCloseDefTools.Size = new System.Drawing.Size(100, 30);
      this.btnCloseDefTools.TabIndex = 49;
      this.btnCloseDefTools.Text = "Close def tools";
      this.btnCloseDefTools.UseVisualStyleBackColor = true;
      this.btnCloseDefTools.Click += new System.EventHandler(this.btnCloseDefTools_Click);
      // 
      // btnShowDefTools
      // 
      this.btnShowDefTools.Location = new System.Drawing.Point(5, 15);
      this.btnShowDefTools.Name = "btnShowDefTools";
      this.btnShowDefTools.Size = new System.Drawing.Size(100, 30);
      this.btnShowDefTools.TabIndex = 48;
      this.btnShowDefTools.Text = "Show def tools";
      this.btnShowDefTools.UseVisualStyleBackColor = true;
      this.btnShowDefTools.Click += new System.EventHandler(this.btnShowDefTools_Click);
      // 
      // grRotationsZoomInOut
      // 
      this.grRotationsZoomInOut.Controls.Add(this.lblDeltaYawPitch);
      this.grRotationsZoomInOut.Controls.Add(this.txtDeltaYawPitch);
      this.grRotationsZoomInOut.Controls.Add(this.btnRotateDown);
      this.grRotationsZoomInOut.Controls.Add(this.btnRotateUp);
      this.grRotationsZoomInOut.Controls.Add(this.btnRotateRight);
      this.grRotationsZoomInOut.Controls.Add(this.btnZoomOut);
      this.grRotationsZoomInOut.Controls.Add(this.btRotateLeft);
      this.grRotationsZoomInOut.Controls.Add(this.btnZoomIn);
      this.grRotationsZoomInOut.Location = new System.Drawing.Point(0, 135);
      this.grRotationsZoomInOut.Name = "grRotationsZoomInOut";
      this.grRotationsZoomInOut.Size = new System.Drawing.Size(180, 155);
      this.grRotationsZoomInOut.TabIndex = 0;
      this.grRotationsZoomInOut.TabStop = false;
      this.grRotationsZoomInOut.Text = "Rotations / zoom in / zoom out";
      // 
      // lblDeltaYawPitch
      // 
      this.lblDeltaYawPitch.AutoSize = true;
      this.lblDeltaYawPitch.Location = new System.Drawing.Point(5, 120);
      this.lblDeltaYawPitch.Name = "lblDeltaYawPitch";
      this.lblDeltaYawPitch.Size = new System.Drawing.Size(86, 13);
      this.lblDeltaYawPitch.TabIndex = 20;
      this.lblDeltaYawPitch.Text = "delta yaw / pitch";
      // 
      // txtDeltaYawPitch
      // 
      this.txtDeltaYawPitch.Location = new System.Drawing.Point(95, 120);
      this.txtDeltaYawPitch.Name = "txtDeltaYawPitch";
      this.txtDeltaYawPitch.Size = new System.Drawing.Size(80, 20);
      this.txtDeltaYawPitch.TabIndex = 21;
      this.txtDeltaYawPitch.Text = "1";
      // 
      // btnRotateDown
      // 
      this.btnRotateDown.Location = new System.Drawing.Point(95, 15);
      this.btnRotateDown.Name = "btnRotateDown";
      this.btnRotateDown.Size = new System.Drawing.Size(80, 30);
      this.btnRotateDown.TabIndex = 19;
      this.btnRotateDown.Text = "Rotate down";
      this.btnRotateDown.UseVisualStyleBackColor = true;
      this.btnRotateDown.Click += new System.EventHandler(this.btnRotateDown_Click);
      // 
      // btnRotateUp
      // 
      this.btnRotateUp.Location = new System.Drawing.Point(5, 15);
      this.btnRotateUp.Name = "btnRotateUp";
      this.btnRotateUp.Size = new System.Drawing.Size(80, 30);
      this.btnRotateUp.TabIndex = 18;
      this.btnRotateUp.Text = "Rotate up";
      this.btnRotateUp.UseVisualStyleBackColor = true;
      this.btnRotateUp.Click += new System.EventHandler(this.btnRotateUp_Click);
      // 
      // btnRotateRight
      // 
      this.btnRotateRight.Location = new System.Drawing.Point(5, 50);
      this.btnRotateRight.Name = "btnRotateRight";
      this.btnRotateRight.Size = new System.Drawing.Size(80, 30);
      this.btnRotateRight.TabIndex = 6;
      this.btnRotateRight.Text = "Rotate right";
      this.btnRotateRight.UseVisualStyleBackColor = true;
      this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
      // 
      // btnZoomOut
      // 
      this.btnZoomOut.Location = new System.Drawing.Point(95, 85);
      this.btnZoomOut.Name = "btnZoomOut";
      this.btnZoomOut.Size = new System.Drawing.Size(80, 30);
      this.btnZoomOut.TabIndex = 46;
      this.btnZoomOut.Text = "Zoom out";
      this.btnZoomOut.UseVisualStyleBackColor = true;
      this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
      // 
      // btRotateLeft
      // 
      this.btRotateLeft.Location = new System.Drawing.Point(5, 85);
      this.btRotateLeft.Name = "btRotateLeft";
      this.btRotateLeft.Size = new System.Drawing.Size(80, 30);
      this.btRotateLeft.TabIndex = 0;
      this.btRotateLeft.Text = "Rotate left";
      this.btRotateLeft.UseVisualStyleBackColor = true;
      this.btRotateLeft.Click += new System.EventHandler(this.btRotateLeft_Click);
      // 
      // btnZoomIn
      // 
      this.btnZoomIn.Location = new System.Drawing.Point(95, 50);
      this.btnZoomIn.Name = "btnZoomIn";
      this.btnZoomIn.Size = new System.Drawing.Size(80, 30);
      this.btnZoomIn.TabIndex = 45;
      this.btnZoomIn.Text = "Zoom in";
      this.btnZoomIn.UseVisualStyleBackColor = true;
      this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
      // 
      // grEvents
      // 
      this.grEvents.Controls.Add(this.lbViewerEvents);
      this.grEvents.Location = new System.Drawing.Point(0, 660);
      this.grEvents.Name = "grEvents";
      this.grEvents.Size = new System.Drawing.Size(480, 100);
      this.grEvents.TabIndex = 50;
      this.grEvents.TabStop = false;
      this.grEvents.Text = "Viewer events";
      // 
      // lbViewerEvents
      // 
      this.lbViewerEvents.FormattingEnabled = true;
      this.lbViewerEvents.Location = new System.Drawing.Point(14, 17);
      this.lbViewerEvents.Name = "lbViewerEvents";
      this.lbViewerEvents.Size = new System.Drawing.Size(470, 82);
      this.lbViewerEvents.TabIndex = 0;
      // 
      // grRecordingViewerColorPermissions
      // 
      this.grRecordingViewerColorPermissions.Controls.Add(this.txtRecordingViewerColorPermissions);
      this.grRecordingViewerColorPermissions.Controls.Add(this.btnGetPermissions);
      this.grRecordingViewerColorPermissions.Controls.Add(this.btnGetRecording);
      this.grRecordingViewerColorPermissions.Controls.Add(this.btnGetViewerColor);
      this.grRecordingViewerColorPermissions.Location = new System.Drawing.Point(160, 525);
      this.grRecordingViewerColorPermissions.Name = "grRecordingViewerColorPermissions";
      this.grRecordingViewerColorPermissions.Size = new System.Drawing.Size(320, 135);
      this.grRecordingViewerColorPermissions.TabIndex = 0;
      this.grRecordingViewerColorPermissions.TabStop = false;
      this.grRecordingViewerColorPermissions.Text = "Recording / Viewer color / Permissions";
      // 
      // txtRecordingViewerColorPermissions
      // 
      this.txtRecordingViewerColorPermissions.Location = new System.Drawing.Point(110, 15);
      this.txtRecordingViewerColorPermissions.Multiline = true;
      this.txtRecordingViewerColorPermissions.Name = "txtRecordingViewerColorPermissions";
      this.txtRecordingViewerColorPermissions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtRecordingViewerColorPermissions.Size = new System.Drawing.Size(205, 115);
      this.txtRecordingViewerColorPermissions.TabIndex = 49;
      // 
      // btnGetPermissions
      // 
      this.btnGetPermissions.Location = new System.Drawing.Point(5, 15);
      this.btnGetPermissions.Name = "btnGetPermissions";
      this.btnGetPermissions.Size = new System.Drawing.Size(100, 30);
      this.btnGetPermissions.TabIndex = 11;
      this.btnGetPermissions.Text = "Get Permissions";
      this.btnGetPermissions.UseVisualStyleBackColor = true;
      this.btnGetPermissions.Click += new System.EventHandler(this.btnPermissions_Click);
      // 
      // btnGetRecording
      // 
      this.btnGetRecording.Location = new System.Drawing.Point(5, 65);
      this.btnGetRecording.Name = "btnGetRecording";
      this.btnGetRecording.Size = new System.Drawing.Size(100, 30);
      this.btnGetRecording.TabIndex = 28;
      this.btnGetRecording.Text = "Get Recording";
      this.btnGetRecording.UseVisualStyleBackColor = true;
      this.btnGetRecording.Click += new System.EventHandler(this.btnGetRecording_Click);
      // 
      // btnGetViewerColor
      // 
      this.btnGetViewerColor.Location = new System.Drawing.Point(5, 100);
      this.btnGetViewerColor.Name = "btnGetViewerColor";
      this.btnGetViewerColor.Size = new System.Drawing.Size(100, 30);
      this.btnGetViewerColor.TabIndex = 17;
      this.btnGetViewerColor.Text = "Get Viewer Color";
      this.btnGetViewerColor.UseVisualStyleBackColor = true;
      this.btnGetViewerColor.Click += new System.EventHandler(this.btnGetViewerColor_Click);
      // 
      // grOrientation
      // 
      this.grOrientation.Controls.Add(this.txtYaw);
      this.grOrientation.Controls.Add(this.lblYaw);
      this.grOrientation.Controls.Add(this.lblPitch);
      this.grOrientation.Controls.Add(this.txtPitch);
      this.grOrientation.Controls.Add(this.lblhFov);
      this.grOrientation.Controls.Add(this.txthFov);
      this.grOrientation.Controls.Add(this.btnGetOrientation);
      this.grOrientation.Controls.Add(this.btnSetOrientation);
      this.grOrientation.Location = new System.Drawing.Point(240, 410);
      this.grOrientation.Name = "grOrientation";
      this.grOrientation.Size = new System.Drawing.Size(240, 115);
      this.grOrientation.TabIndex = 0;
      this.grOrientation.TabStop = false;
      this.grOrientation.Text = "Orientation";
      // 
      // txtYaw
      // 
      this.txtYaw.Location = new System.Drawing.Point(145, 15);
      this.txtYaw.Name = "txtYaw";
      this.txtYaw.Size = new System.Drawing.Size(90, 20);
      this.txtYaw.TabIndex = 23;
      this.txtYaw.Text = "0.0";
      // 
      // lblYaw
      // 
      this.lblYaw.AutoSize = true;
      this.lblYaw.Location = new System.Drawing.Point(110, 15);
      this.lblYaw.Name = "lblYaw";
      this.lblYaw.Size = new System.Drawing.Size(28, 13);
      this.lblYaw.TabIndex = 21;
      this.lblYaw.Text = "Yaw";
      // 
      // lblPitch
      // 
      this.lblPitch.AutoSize = true;
      this.lblPitch.Location = new System.Drawing.Point(110, 40);
      this.lblPitch.Name = "lblPitch";
      this.lblPitch.Size = new System.Drawing.Size(31, 13);
      this.lblPitch.TabIndex = 22;
      this.lblPitch.Text = "Pitch";
      // 
      // txtPitch
      // 
      this.txtPitch.Location = new System.Drawing.Point(145, 40);
      this.txtPitch.Name = "txtPitch";
      this.txtPitch.Size = new System.Drawing.Size(90, 20);
      this.txtPitch.TabIndex = 24;
      this.txtPitch.Text = "0.0";
      // 
      // lblhFov
      // 
      this.lblhFov.AutoSize = true;
      this.lblhFov.Location = new System.Drawing.Point(110, 65);
      this.lblhFov.Name = "lblhFov";
      this.lblhFov.Size = new System.Drawing.Size(31, 13);
      this.lblhFov.TabIndex = 25;
      this.lblhFov.Text = "hFov";
      // 
      // txthFov
      // 
      this.txthFov.Location = new System.Drawing.Point(145, 65);
      this.txthFov.Name = "txthFov";
      this.txthFov.Size = new System.Drawing.Size(90, 20);
      this.txthFov.TabIndex = 26;
      this.txthFov.Text = "90.0";
      // 
      // btnGetOrientation
      // 
      this.btnGetOrientation.Location = new System.Drawing.Point(5, 15);
      this.btnGetOrientation.Name = "btnGetOrientation";
      this.btnGetOrientation.Size = new System.Drawing.Size(100, 30);
      this.btnGetOrientation.TabIndex = 20;
      this.btnGetOrientation.Text = "Get Orientation";
      this.btnGetOrientation.UseVisualStyleBackColor = true;
      this.btnGetOrientation.Click += new System.EventHandler(this.btnOrientation_Click);
      // 
      // btnSetOrientation
      // 
      this.btnSetOrientation.Location = new System.Drawing.Point(5, 80);
      this.btnSetOrientation.Name = "btnSetOrientation";
      this.btnSetOrientation.Size = new System.Drawing.Size(100, 30);
      this.btnSetOrientation.TabIndex = 27;
      this.btnSetOrientation.Text = "Set Orientation";
      this.btnSetOrientation.UseVisualStyleBackColor = true;
      this.btnSetOrientation.Click += new System.EventHandler(this.btnSetOrientation_Click);
      // 
      // grOpenByImageId
      // 
      this.grOpenByImageId.Controls.Add(this.btnGetAddress);
      this.grOpenByImageId.Controls.Add(this.lblOpenByImageSrs);
      this.grOpenByImageId.Controls.Add(this.txtOpenByImageSrs);
      this.grOpenByImageId.Controls.Add(this.btnOpenByImageId);
      this.grOpenByImageId.Controls.Add(this.lblImageId);
      this.grOpenByImageId.Controls.Add(this.txtImageId);
      this.grOpenByImageId.Location = new System.Drawing.Point(0, 525);
      this.grOpenByImageId.Name = "grOpenByImageId";
      this.grOpenByImageId.Size = new System.Drawing.Size(160, 130);
      this.grOpenByImageId.TabIndex = 44;
      this.grOpenByImageId.TabStop = false;
      this.grOpenByImageId.Text = "Open by imageId";
      // 
      // btnGetAddress
      // 
      this.btnGetAddress.Location = new System.Drawing.Point(5, 100);
      this.btnGetAddress.Name = "btnGetAddress";
      this.btnGetAddress.Size = new System.Drawing.Size(150, 30);
      this.btnGetAddress.TabIndex = 49;
      this.btnGetAddress.Text = "Get address settings";
      this.btnGetAddress.UseVisualStyleBackColor = true;
      this.btnGetAddress.Click += new System.EventHandler(this.btnGetAddress_Click);
      // 
      // lblOpenByImageSrs
      // 
      this.lblOpenByImageSrs.AutoSize = true;
      this.lblOpenByImageSrs.Location = new System.Drawing.Point(5, 40);
      this.lblOpenByImageSrs.Name = "lblOpenByImageSrs";
      this.lblOpenByImageSrs.Size = new System.Drawing.Size(20, 13);
      this.lblOpenByImageSrs.TabIndex = 47;
      this.lblOpenByImageSrs.Text = "srs";
      // 
      // txtOpenByImageSrs
      // 
      this.txtOpenByImageSrs.Location = new System.Drawing.Point(55, 40);
      this.txtOpenByImageSrs.Name = "txtOpenByImageSrs";
      this.txtOpenByImageSrs.Size = new System.Drawing.Size(100, 20);
      this.txtOpenByImageSrs.TabIndex = 48;
      this.txtOpenByImageSrs.Text = "EPSG:28992";
      // 
      // btnOpenByImageId
      // 
      this.btnOpenByImageId.Location = new System.Drawing.Point(5, 65);
      this.btnOpenByImageId.Name = "btnOpenByImageId";
      this.btnOpenByImageId.Size = new System.Drawing.Size(150, 30);
      this.btnOpenByImageId.TabIndex = 43;
      this.btnOpenByImageId.Text = "Open by ImageId";
      this.btnOpenByImageId.UseVisualStyleBackColor = true;
      this.btnOpenByImageId.Click += new System.EventHandler(this.btnOpenByImageId_Click);
      // 
      // lblImageId
      // 
      this.lblImageId.AutoSize = true;
      this.lblImageId.Location = new System.Drawing.Point(5, 15);
      this.lblImageId.Name = "lblImageId";
      this.lblImageId.Size = new System.Drawing.Size(45, 13);
      this.lblImageId.TabIndex = 41;
      this.lblImageId.Text = "ImageId";
      // 
      // txtImageId
      // 
      this.txtImageId.Location = new System.Drawing.Point(55, 15);
      this.txtImageId.Name = "txtImageId";
      this.txtImageId.Size = new System.Drawing.Size(100, 20);
      this.txtImageId.TabIndex = 42;
      this.txtImageId.Text = "5D123456";
      // 
      // grCoordinate
      // 
      this.grCoordinate.Controls.Add(this.lblCoordinateSrs);
      this.grCoordinate.Controls.Add(this.txtCoordinateSrs);
      this.grCoordinate.Controls.Add(this.txtX);
      this.grCoordinate.Controls.Add(this.txtY);
      this.grCoordinate.Controls.Add(this.txtZ);
      this.grCoordinate.Controls.Add(this.lblX);
      this.grCoordinate.Controls.Add(this.lblY);
      this.grCoordinate.Controls.Add(this.lblZ);
      this.grCoordinate.Controls.Add(this.btnOpenByCoordinate);
      this.grCoordinate.Controls.Add(this.btnLookAtCoordinate);
      this.grCoordinate.Location = new System.Drawing.Point(0, 410);
      this.grCoordinate.Name = "grCoordinate";
      this.grCoordinate.Size = new System.Drawing.Size(240, 115);
      this.grCoordinate.TabIndex = 0;
      this.grCoordinate.TabStop = false;
      this.grCoordinate.Text = "Coordinate";
      // 
      // lblCoordinateSrs
      // 
      this.lblCoordinateSrs.AutoSize = true;
      this.lblCoordinateSrs.Location = new System.Drawing.Point(120, 90);
      this.lblCoordinateSrs.Name = "lblCoordinateSrs";
      this.lblCoordinateSrs.Size = new System.Drawing.Size(20, 13);
      this.lblCoordinateSrs.TabIndex = 45;
      this.lblCoordinateSrs.Text = "srs";
      // 
      // txtCoordinateSrs
      // 
      this.txtCoordinateSrs.Location = new System.Drawing.Point(145, 90);
      this.txtCoordinateSrs.Name = "txtCoordinateSrs";
      this.txtCoordinateSrs.Size = new System.Drawing.Size(90, 20);
      this.txtCoordinateSrs.TabIndex = 46;
      this.txtCoordinateSrs.Text = "EPSG:28992";
      // 
      // txtX
      // 
      this.txtX.Location = new System.Drawing.Point(145, 15);
      this.txtX.Name = "txtX";
      this.txtX.Size = new System.Drawing.Size(90, 20);
      this.txtX.TabIndex = 30;
      this.txtX.Text = "160850.585";
      // 
      // txtY
      // 
      this.txtY.Location = new System.Drawing.Point(145, 40);
      this.txtY.Name = "txtY";
      this.txtY.Size = new System.Drawing.Size(90, 20);
      this.txtY.TabIndex = 31;
      this.txtY.Text = "383923.326";
      // 
      // txtZ
      // 
      this.txtZ.Location = new System.Drawing.Point(145, 65);
      this.txtZ.Name = "txtZ";
      this.txtZ.Size = new System.Drawing.Size(90, 20);
      this.txtZ.TabIndex = 32;
      // 
      // lblX
      // 
      this.lblX.AutoSize = true;
      this.lblX.Location = new System.Drawing.Point(120, 15);
      this.lblX.Name = "lblX";
      this.lblX.Size = new System.Drawing.Size(14, 13);
      this.lblX.TabIndex = 33;
      this.lblX.Text = "X";
      // 
      // lblY
      // 
      this.lblY.AutoSize = true;
      this.lblY.Location = new System.Drawing.Point(120, 40);
      this.lblY.Name = "lblY";
      this.lblY.Size = new System.Drawing.Size(14, 13);
      this.lblY.TabIndex = 34;
      this.lblY.Text = "Y";
      // 
      // lblZ
      // 
      this.lblZ.AutoSize = true;
      this.lblZ.Location = new System.Drawing.Point(120, 65);
      this.lblZ.Name = "lblZ";
      this.lblZ.Size = new System.Drawing.Size(14, 13);
      this.lblZ.TabIndex = 35;
      this.lblZ.Text = "Z";
      // 
      // btnOpenByCoordinate
      // 
      this.btnOpenByCoordinate.Location = new System.Drawing.Point(5, 15);
      this.btnOpenByCoordinate.Name = "btnOpenByCoordinate";
      this.btnOpenByCoordinate.Size = new System.Drawing.Size(110, 30);
      this.btnOpenByCoordinate.TabIndex = 44;
      this.btnOpenByCoordinate.Text = "Open by coordinate";
      this.btnOpenByCoordinate.UseVisualStyleBackColor = true;
      this.btnOpenByCoordinate.Click += new System.EventHandler(this.btnOpenByCoordinate_Click);
      // 
      // btnLookAtCoordinate
      // 
      this.btnLookAtCoordinate.Location = new System.Drawing.Point(5, 80);
      this.btnLookAtCoordinate.Name = "btnLookAtCoordinate";
      this.btnLookAtCoordinate.Size = new System.Drawing.Size(110, 30);
      this.btnLookAtCoordinate.TabIndex = 29;
      this.btnLookAtCoordinate.Text = "Look at coordinate";
      this.btnLookAtCoordinate.UseVisualStyleBackColor = true;
      this.btnLookAtCoordinate.Click += new System.EventHandler(this.btnLookAtCoordinate_Click);
      // 
      // grAPIInfo
      // 
      this.grAPIInfo.Controls.Add(this.lblResult);
      this.grAPIInfo.Controls.Add(this.txtAPIResult);
      this.grAPIInfo.Controls.Add(this.btnApiReadyState);
      this.grAPIInfo.Controls.Add(this.btnApplicationVersion);
      this.grAPIInfo.Controls.Add(this.btnApplicationName);
      this.grAPIInfo.Location = new System.Drawing.Point(360, 100);
      this.grAPIInfo.Name = "grAPIInfo";
      this.grAPIInfo.Size = new System.Drawing.Size(120, 190);
      this.grAPIInfo.TabIndex = 0;
      this.grAPIInfo.TabStop = false;
      this.grAPIInfo.Text = "API Info";
      // 
      // lblResult
      // 
      this.lblResult.AutoSize = true;
      this.lblResult.Location = new System.Drawing.Point(5, 120);
      this.lblResult.Name = "lblResult";
      this.lblResult.Size = new System.Drawing.Size(40, 13);
      this.lblResult.TabIndex = 22;
      this.lblResult.Text = "Result:";
      // 
      // txtAPIResult
      // 
      this.txtAPIResult.Location = new System.Drawing.Point(5, 155);
      this.txtAPIResult.Name = "txtAPIResult";
      this.txtAPIResult.Size = new System.Drawing.Size(110, 20);
      this.txtAPIResult.TabIndex = 23;
      // 
      // btnApiReadyState
      // 
      this.btnApiReadyState.Location = new System.Drawing.Point(5, 15);
      this.btnApiReadyState.Name = "btnApiReadyState";
      this.btnApiReadyState.Size = new System.Drawing.Size(110, 30);
      this.btnApiReadyState.TabIndex = 8;
      this.btnApiReadyState.Text = "API Ready State";
      this.btnApiReadyState.UseVisualStyleBackColor = true;
      this.btnApiReadyState.Click += new System.EventHandler(this.btnApiReadyState_Click);
      // 
      // btnApplicationVersion
      // 
      this.btnApplicationVersion.Location = new System.Drawing.Point(5, 50);
      this.btnApplicationVersion.Name = "btnApplicationVersion";
      this.btnApplicationVersion.Size = new System.Drawing.Size(110, 30);
      this.btnApplicationVersion.TabIndex = 9;
      this.btnApplicationVersion.Text = "Application version";
      this.btnApplicationVersion.UseVisualStyleBackColor = true;
      this.btnApplicationVersion.Click += new System.EventHandler(this.btnApplicationVersion_Click);
      // 
      // btnApplicationName
      // 
      this.btnApplicationName.Location = new System.Drawing.Point(5, 85);
      this.btnApplicationName.Name = "btnApplicationName";
      this.btnApplicationName.Size = new System.Drawing.Size(110, 30);
      this.btnApplicationName.TabIndex = 10;
      this.btnApplicationName.Text = "Application name";
      this.btnApplicationName.UseVisualStyleBackColor = true;
      this.btnApplicationName.Click += new System.EventHandler(this.btnApplicationName_Click);
      // 
      // grViewerToggles
      // 
      this.grViewerToggles.Controls.Add(this.btnToggleRecordingsVisible);
      this.grViewerToggles.Controls.Add(this.btnToggleTimeTravelExpanded);
      this.grViewerToggles.Controls.Add(this.btnToggleNavbarExpanded);
      this.grViewerToggles.Controls.Add(this.btnToggleTimeTravelVisible);
      this.grViewerToggles.Controls.Add(this.btnToggleNavbarVisible);
      this.grViewerToggles.Location = new System.Drawing.Point(180, 100);
      this.grViewerToggles.Name = "grViewerToggles";
      this.grViewerToggles.Size = new System.Drawing.Size(180, 190);
      this.grViewerToggles.TabIndex = 0;
      this.grViewerToggles.TabStop = false;
      this.grViewerToggles.Text = "Viewer toggles";
      // 
      // btnToggleRecordingsVisible
      // 
      this.btnToggleRecordingsVisible.Location = new System.Drawing.Point(5, 15);
      this.btnToggleRecordingsVisible.Name = "btnToggleRecordingsVisible";
      this.btnToggleRecordingsVisible.Size = new System.Drawing.Size(150, 30);
      this.btnToggleRecordingsVisible.TabIndex = 36;
      this.btnToggleRecordingsVisible.Text = "Toggle recordings visible";
      this.btnToggleRecordingsVisible.UseVisualStyleBackColor = true;
      this.btnToggleRecordingsVisible.Click += new System.EventHandler(this.btnToggleRecordingsVisible_Click);
      // 
      // btnToggleTimeTravelExpanded
      // 
      this.btnToggleTimeTravelExpanded.Location = new System.Drawing.Point(5, 50);
      this.btnToggleTimeTravelExpanded.Name = "btnToggleTimeTravelExpanded";
      this.btnToggleTimeTravelExpanded.Size = new System.Drawing.Size(150, 30);
      this.btnToggleTimeTravelExpanded.TabIndex = 40;
      this.btnToggleTimeTravelExpanded.Text = "Toggle time travel expanded";
      this.btnToggleTimeTravelExpanded.UseVisualStyleBackColor = true;
      this.btnToggleTimeTravelExpanded.Click += new System.EventHandler(this.btnToggleTimeTravelExpanded_Click);
      // 
      // btnToggleNavbarExpanded
      // 
      this.btnToggleNavbarExpanded.Location = new System.Drawing.Point(5, 85);
      this.btnToggleNavbarExpanded.Name = "btnToggleNavbarExpanded";
      this.btnToggleNavbarExpanded.Size = new System.Drawing.Size(150, 30);
      this.btnToggleNavbarExpanded.TabIndex = 38;
      this.btnToggleNavbarExpanded.Text = "Toggle navbar expanded";
      this.btnToggleNavbarExpanded.UseVisualStyleBackColor = true;
      this.btnToggleNavbarExpanded.Click += new System.EventHandler(this.btnToggleNavbarExpanded_Click);
      // 
      // btnToggleTimeTravelVisible
      // 
      this.btnToggleTimeTravelVisible.Location = new System.Drawing.Point(5, 120);
      this.btnToggleTimeTravelVisible.Name = "btnToggleTimeTravelVisible";
      this.btnToggleTimeTravelVisible.Size = new System.Drawing.Size(150, 30);
      this.btnToggleTimeTravelVisible.TabIndex = 39;
      this.btnToggleTimeTravelVisible.Text = "Toggle time travel visible";
      this.btnToggleTimeTravelVisible.UseVisualStyleBackColor = true;
      this.btnToggleTimeTravelVisible.Click += new System.EventHandler(this.btnToggleTimeTravelVisible_Click);
      // 
      // btnToggleNavbarVisible
      // 
      this.btnToggleNavbarVisible.Location = new System.Drawing.Point(5, 155);
      this.btnToggleNavbarVisible.Name = "btnToggleNavbarVisible";
      this.btnToggleNavbarVisible.Size = new System.Drawing.Size(150, 30);
      this.btnToggleNavbarVisible.TabIndex = 37;
      this.btnToggleNavbarVisible.Text = "Toggle Navbar Visible";
      this.btnToggleNavbarVisible.UseVisualStyleBackColor = true;
      this.btnToggleNavbarVisible.Click += new System.EventHandler(this.btnToggleNavbarVisible_Click);
      // 
      // grOpenByAddress
      // 
      this.grOpenByAddress.Controls.Add(this.lblAddress);
      this.grOpenByAddress.Controls.Add(this.txtAdress);
      this.grOpenByAddress.Controls.Add(this.lblAddressSrs);
      this.grOpenByAddress.Controls.Add(this.txtAddressSrs);
      this.grOpenByAddress.Controls.Add(this.btnOpenByAddress);
      this.grOpenByAddress.Location = new System.Drawing.Point(180, 0);
      this.grOpenByAddress.Name = "grOpenByAddress";
      this.grOpenByAddress.Size = new System.Drawing.Size(300, 100);
      this.grOpenByAddress.TabIndex = 0;
      this.grOpenByAddress.TabStop = false;
      this.grOpenByAddress.Text = "Open by address";
      // 
      // lblAddress
      // 
      this.lblAddress.AutoSize = true;
      this.lblAddress.Location = new System.Drawing.Point(5, 15);
      this.lblAddress.Name = "lblAddress";
      this.lblAddress.Size = new System.Drawing.Size(45, 13);
      this.lblAddress.TabIndex = 12;
      this.lblAddress.Text = "Address";
      // 
      // txtAdress
      // 
      this.txtAdress.Location = new System.Drawing.Point(65, 15);
      this.txtAdress.Name = "txtAdress";
      this.txtAdress.Size = new System.Drawing.Size(230, 20);
      this.txtAdress.TabIndex = 14;
      this.txtAdress.Text = "Boschdijk 7, Eindhoven";
      // 
      // lblAddressSrs
      // 
      this.lblAddressSrs.AutoSize = true;
      this.lblAddressSrs.Location = new System.Drawing.Point(5, 40);
      this.lblAddressSrs.Name = "lblAddressSrs";
      this.lblAddressSrs.Size = new System.Drawing.Size(20, 13);
      this.lblAddressSrs.TabIndex = 13;
      this.lblAddressSrs.Text = "srs";
      // 
      // txtAddressSrs
      // 
      this.txtAddressSrs.Location = new System.Drawing.Point(65, 40);
      this.txtAddressSrs.Name = "txtAddressSrs";
      this.txtAddressSrs.Size = new System.Drawing.Size(230, 20);
      this.txtAddressSrs.TabIndex = 15;
      this.txtAddressSrs.Text = "EPSG:28992";
      // 
      // btnOpenByAddress
      // 
      this.btnOpenByAddress.Location = new System.Drawing.Point(5, 65);
      this.btnOpenByAddress.Name = "btnOpenByAddress";
      this.btnOpenByAddress.Size = new System.Drawing.Size(290, 30);
      this.btnOpenByAddress.TabIndex = 16;
      this.btnOpenByAddress.Text = "Open by address";
      this.btnOpenByAddress.UseVisualStyleBackColor = true;
      this.btnOpenByAddress.Click += new System.EventHandler(this.btnOpenByAddress_Click);
      // 
      // grLogin
      // 
      this.grLogin.Controls.Add(this.lblAPIKey);
      this.grLogin.Controls.Add(this.txtAPIKey);
      this.grLogin.Controls.Add(this.lblUsername);
      this.grLogin.Controls.Add(this.lblPassword);
      this.grLogin.Controls.Add(this.txtUsername);
      this.grLogin.Controls.Add(this.txtPassword);
      this.grLogin.Controls.Add(this.btnLogin);
      this.grLogin.Location = new System.Drawing.Point(0, 0);
      this.grLogin.Name = "grLogin";
      this.grLogin.Size = new System.Drawing.Size(180, 135);
      this.grLogin.TabIndex = 49;
      this.grLogin.TabStop = false;
      this.grLogin.Text = "Login";
      // 
      // lblAPIKey
      // 
      this.lblAPIKey.AutoSize = true;
      this.lblAPIKey.Location = new System.Drawing.Point(5, 65);
      this.lblAPIKey.Name = "lblAPIKey";
      this.lblAPIKey.Size = new System.Drawing.Size(45, 13);
      this.lblAPIKey.TabIndex = 6;
      this.lblAPIKey.Text = "API Key";
      // 
      // txtAPIKey
      // 
      this.txtAPIKey.Location = new System.Drawing.Point(65, 65);
      this.txtAPIKey.Name = "txtAPIKey";
      this.txtAPIKey.Size = new System.Drawing.Size(110, 20);
      this.txtAPIKey.TabIndex = 7;
      // 
      // lblUsername
      // 
      this.lblUsername.AutoSize = true;
      this.lblUsername.Location = new System.Drawing.Point(5, 15);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(55, 13);
      this.lblUsername.TabIndex = 1;
      this.lblUsername.Text = "Username";
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
      // txtUsername
      // 
      this.txtUsername.Location = new System.Drawing.Point(65, 15);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new System.Drawing.Size(110, 20);
      this.txtUsername.TabIndex = 3;
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(65, 40);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(110, 20);
      this.txtPassword.TabIndex = 4;
      // 
      // btnLogin
      // 
      this.btnLogin.Location = new System.Drawing.Point(5, 100);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(170, 30);
      this.btnLogin.TabIndex = 5;
      this.btnLogin.Text = "Login";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // Demo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1384, 762);
      this.Controls.Add(this.plControl);
      this.Controls.Add(this.plStreetSmart);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Demo";
      this.Text = "Demo StreetSmart";
      this.grOpenCloseViewer.ResumeLayout(false);
      this.grOpenCloseViewer.PerformLayout();
      this.plControl.ResumeLayout(false);
      this.grDevTools.ResumeLayout(false);
      this.grRotationsZoomInOut.ResumeLayout(false);
      this.grRotationsZoomInOut.PerformLayout();
      this.grEvents.ResumeLayout(false);
      this.grRecordingViewerColorPermissions.ResumeLayout(false);
      this.grRecordingViewerColorPermissions.PerformLayout();
      this.grOrientation.ResumeLayout(false);
      this.grOrientation.PerformLayout();
      this.grOpenByImageId.ResumeLayout(false);
      this.grOpenByImageId.PerformLayout();
      this.grCoordinate.ResumeLayout(false);
      this.grCoordinate.PerformLayout();
      this.grAPIInfo.ResumeLayout(false);
      this.grAPIInfo.PerformLayout();
      this.grViewerToggles.ResumeLayout(false);
      this.grOpenByAddress.ResumeLayout(false);
      this.grOpenByAddress.PerformLayout();
      this.grLogin.ResumeLayout(false);
      this.grLogin.PerformLayout();
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
    private System.Windows.Forms.Button btnGetPermissions;
    private System.Windows.Forms.Button btnApplicationName;
    private System.Windows.Forms.Button btnApplicationVersion;
    private System.Windows.Forms.TextBox txtAddressSrs;
    private System.Windows.Forms.TextBox txtAdress;
    private System.Windows.Forms.Label lblAddressSrs;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.Button btnOpenByAddress;
    private System.Windows.Forms.Button btnGetViewerColor;
    private System.Windows.Forms.Button btnRotateDown;
    private System.Windows.Forms.Button btnRotateUp;
    private System.Windows.Forms.Button btnGetOrientation;
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
    private System.Windows.Forms.Button btnOpenViewer;
    private System.Windows.Forms.GroupBox grLogin;
    private System.Windows.Forms.GroupBox grViewerToggles;
    private System.Windows.Forms.GroupBox grOpenByAddress;
    private System.Windows.Forms.GroupBox grRotationsZoomInOut;
    private System.Windows.Forms.Label lblDeltaYawPitch;
    private System.Windows.Forms.TextBox txtDeltaYawPitch;
    private System.Windows.Forms.GroupBox grOpenCloseViewer;
    private System.Windows.Forms.GroupBox grAPIInfo;
    private System.Windows.Forms.Label lblResult;
    private System.Windows.Forms.TextBox txtAPIResult;
    private System.Windows.Forms.GroupBox grCoordinate;
    private System.Windows.Forms.Label lblCoordinateSrs;
    private System.Windows.Forms.TextBox txtCoordinateSrs;
    private System.Windows.Forms.GroupBox grOpenByImageId;
    private System.Windows.Forms.Label lblOpenByImageSrs;
    private System.Windows.Forms.TextBox txtOpenByImageSrs;
    private System.Windows.Forms.GroupBox grOrientation;
    private System.Windows.Forms.GroupBox grRecordingViewerColorPermissions;
    private System.Windows.Forms.TextBox txtRecordingViewerColorPermissions;
    private System.Windows.Forms.Button btnGetAddress;
    private System.Windows.Forms.RadioButton rbParameters;
    private System.Windows.Forms.RadioButton rbDefault;
    private System.Windows.Forms.GroupBox grEvents;
    private System.Windows.Forms.ListBox lbViewerEvents;
    private System.Windows.Forms.Label lblAPIKey;
    private System.Windows.Forms.TextBox txtAPIKey;
    private System.Windows.Forms.GroupBox grDevTools;
    private System.Windows.Forms.Button btnShowDefTools;
    private System.Windows.Forms.Button btnCloseDefTools;
    private System.Windows.Forms.TextBox txtWidth;
    private System.Windows.Forms.TextBox txtHeight;
    private System.Windows.Forms.TextBox txtTop;
    private System.Windows.Forms.Label lblWidth;
    private System.Windows.Forms.Label lblHeight;
    private System.Windows.Forms.Label lblTop;
    private System.Windows.Forms.TextBox txtLeft;
    private System.Windows.Forms.Label lblLeft;
    private System.Windows.Forms.TextBox txtOpenByQuery;
    private System.Windows.Forms.CheckBox cbPanorama;
    private System.Windows.Forms.CheckBox cbOblique;
    private System.Windows.Forms.Button btnOpenViewerByQuery;
  }
}

