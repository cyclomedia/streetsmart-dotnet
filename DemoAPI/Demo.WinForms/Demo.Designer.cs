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
      this.grOpenByQuery = new System.Windows.Forms.GroupBox();
      this.cbPointCloud = new System.Windows.Forms.CheckBox();
      this.ckReplace = new System.Windows.Forms.CheckBox();
      this.txtOpenByQuery = new System.Windows.Forms.TextBox();
      this.cbPanorama = new System.Windows.Forms.CheckBox();
      this.cbOblique = new System.Windows.Forms.CheckBox();
      this.btnOpenViewerByQuery = new System.Windows.Forms.Button();
      this.plControl = new System.Windows.Forms.Panel();
      this.grCloseViewers = new System.Windows.Forms.GroupBox();
      this.btnSetPointStyle = new System.Windows.Forms.Button();
      this.cbPointStyle = new System.Windows.Forms.ComboBox();
      this.btnGetPointStyle = new System.Windows.Forms.Button();
      this.btnCloseObliqueViewer = new System.Windows.Forms.Button();
      this.btnClosePointViewer = new System.Windows.Forms.Button();
      this.grPanoramaList = new System.Windows.Forms.GroupBox();
      this.lbPanoramaList = new System.Windows.Forms.ListBox();
      this.grColorOverlay = new System.Windows.Forms.GroupBox();
      this.btnDemoWFSLayer = new System.Windows.Forms.Button();
      this.txtOverlayColor = new System.Windows.Forms.TextBox();
      this.btnToggleAddressOverlays = new System.Windows.Forms.Button();
      this.btnColorOverlay = new System.Windows.Forms.Button();
      this.rbColor = new System.Windows.Forms.RadioButton();
      this.rbSLD = new System.Windows.Forms.RadioButton();
      this.grSelectFeature = new System.Windows.Forms.GroupBox();
      this.ckShowAttributePanelOnFeatureClick = new System.Windows.Forms.CheckBox();
      this.txtValue = new System.Windows.Forms.TextBox();
      this.lblValue = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.lblPropertyName = new System.Windows.Forms.Label();
      this.btnSelectFeature = new System.Windows.Forms.Button();
      this.grSld = new System.Windows.Forms.GroupBox();
      this.txtSld = new System.Windows.Forms.TextBox();
      this.grButtonVisibility = new System.Windows.Forms.GroupBox();
      this.cbViewerButton = new System.Windows.Forms.ComboBox();
      this.btnSetButtonVisibility = new System.Windows.Forms.Button();
      this.btnGetButtonEnabled = new System.Windows.Forms.Button();
      this.grOverlay = new System.Windows.Forms.GroupBox();
      this.btnDrawDistance = new System.Windows.Forms.Button();
      this.txtDrawDistance = new System.Windows.Forms.TextBox();
      this.btnRemoveOverlay = new System.Windows.Forms.Button();
      this.txtOverlayGeoJson = new System.Windows.Forms.TextBox();
      this.btnAddOverlay = new System.Windows.Forms.Button();
      this.grMeasurement = new System.Windows.Forms.GroupBox();
      this.btnGetActiveMeasurement = new System.Windows.Forms.Button();
      this.rbMeasPolygon = new System.Windows.Forms.RadioButton();
      this.rbMeasLineString = new System.Windows.Forms.RadioButton();
      this.rbMeasPoint = new System.Windows.Forms.RadioButton();
      this.rbMeasDefault = new System.Windows.Forms.RadioButton();
      this.btnStartMeasurementMode = new System.Windows.Forms.Button();
      this.btnStopMeasurementMode = new System.Windows.Forms.Button();
      this.grDevTools = new System.Windows.Forms.GroupBox();
      this.btnCloseDefTools = new System.Windows.Forms.Button();
      this.btnShowDefTools = new System.Windows.Forms.Button();
      this.grRotationsZoomInOut = new System.Windows.Forms.GroupBox();
      this.btnGetViewers = new System.Windows.Forms.Button();
      this.btnClosePanoramaViewer = new System.Windows.Forms.Button();
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
      this.btnGetDebugLogs = new System.Windows.Forms.Button();
      this.txtYaw = new System.Windows.Forms.TextBox();
      this.lblYaw = new System.Windows.Forms.Label();
      this.lblPitch = new System.Windows.Forms.Label();
      this.txtPitch = new System.Windows.Forms.TextBox();
      this.lblhFov = new System.Windows.Forms.Label();
      this.txthFov = new System.Windows.Forms.TextBox();
      this.btnGetOrientation = new System.Windows.Forms.Button();
      this.btnSetOrientation = new System.Windows.Forms.Button();
      this.grOpenByImageId = new System.Windows.Forms.GroupBox();
      this.txtBrightnessContrast = new System.Windows.Forms.TextBox();
      this.btnContrast = new System.Windows.Forms.Button();
      this.btnBrightness = new System.Windows.Forms.Button();
      this.btnGetAddress = new System.Windows.Forms.Button();
      this.btnOpenByImageId = new System.Windows.Forms.Button();
      this.txtImageId = new System.Windows.Forms.TextBox();
      this.grCoordinate = new System.Windows.Forms.GroupBox();
      this.btnSetPointSize = new System.Windows.Forms.Button();
      this.txtPointSize = new System.Windows.Forms.TextBox();
      this.btnGetPointSize = new System.Windows.Forms.Button();
      this.btnSetPointBudget = new System.Windows.Forms.Button();
      this.cbPointBudget = new System.Windows.Forms.ComboBox();
      this.btnGetPointBudget = new System.Windows.Forms.Button();
      this.btnEdges = new System.Windows.Forms.Button();
      this.btnCameraPosition = new System.Windows.Forms.Button();
      this.txtlkAtX = new System.Windows.Forms.TextBox();
      this.txtlkAtY = new System.Windows.Forms.TextBox();
      this.txtlkAtZ = new System.Windows.Forms.TextBox();
      this.btnFlyTo = new System.Windows.Forms.Button();
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
      this.btnGetType = new System.Windows.Forms.Button();
      this.btnToggleSidebarExpandable = new System.Windows.Forms.Button();
      this.btnToggleSidebar = new System.Windows.Forms.Button();
      this.btnToggle3DCursor = new System.Windows.Forms.Button();
      this.btnToggleRecordingsVisible = new System.Windows.Forms.Button();
      this.btnToggleTimeTravelExpanded = new System.Windows.Forms.Button();
      this.btnToggleNavbarExpanded = new System.Windows.Forms.Button();
      this.btnToggleTimeTravelVisible = new System.Windows.Forms.Button();
      this.btnToggleNavbarVisible = new System.Windows.Forms.Button();
      this.grOpenByAddress = new System.Windows.Forms.GroupBox();
      this.lblAddress = new System.Windows.Forms.Label();
      this.txtAdress = new System.Windows.Forms.TextBox();
      this.btnOpenByAddress = new System.Windows.Forms.Button();
      this.grLogin = new System.Windows.Forms.GroupBox();
      this.lblSRS = new System.Windows.Forms.Label();
      this.txtSrs = new System.Windows.Forms.TextBox();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnLogout = new System.Windows.Forms.Button();
      this.lblAPIKey = new System.Windows.Forms.Label();
      this.txtAPIKey = new System.Windows.Forms.TextBox();
      this.lblUsername = new System.Windows.Forms.Label();
      this.lblPassword = new System.Windows.Forms.Label();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.btnLogin = new System.Windows.Forms.Button();
      this.colorOverlay = new System.Windows.Forms.ColorDialog();
      this.btnPointCloudLookAt = new System.Windows.Forms.Button();
      this.btnDown = new System.Windows.Forms.Button();
      this.btnLeft = new System.Windows.Forms.Button();
      this.btnRight = new System.Windows.Forms.Button();
      this.btnUp = new System.Windows.Forms.Button();
      this.grOpenByQuery.SuspendLayout();
      this.plControl.SuspendLayout();
      this.grCloseViewers.SuspendLayout();
      this.grPanoramaList.SuspendLayout();
      this.grColorOverlay.SuspendLayout();
      this.grSelectFeature.SuspendLayout();
      this.grSld.SuspendLayout();
      this.grButtonVisibility.SuspendLayout();
      this.grOverlay.SuspendLayout();
      this.grMeasurement.SuspendLayout();
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
      this.plStreetSmart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.plStreetSmart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.plStreetSmart.Location = new System.Drawing.Point(0, 0);
      this.plStreetSmart.Name = "plStreetSmart";
      this.plStreetSmart.Size = new System.Drawing.Size(647, 701);
      this.plStreetSmart.TabIndex = 0;
      // 
      // grOpenByQuery
      // 
      this.grOpenByQuery.Controls.Add(this.cbPointCloud);
      this.grOpenByQuery.Controls.Add(this.ckReplace);
      this.grOpenByQuery.Controls.Add(this.txtOpenByQuery);
      this.grOpenByQuery.Controls.Add(this.cbPanorama);
      this.grOpenByQuery.Controls.Add(this.cbOblique);
      this.grOpenByQuery.Controls.Add(this.btnOpenViewerByQuery);
      this.grOpenByQuery.Location = new System.Drawing.Point(480, 1);
      this.grOpenByQuery.Name = "grOpenByQuery";
      this.grOpenByQuery.Size = new System.Drawing.Size(220, 120);
      this.grOpenByQuery.TabIndex = 0;
      this.grOpenByQuery.TabStop = false;
      this.grOpenByQuery.Text = "Open / Close Viewer";
      // 
      // cbPointCloud
      // 
      this.cbPointCloud.AutoSize = true;
      this.cbPointCloud.Checked = true;
      this.cbPointCloud.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbPointCloud.Location = new System.Drawing.Point(146, 97);
      this.cbPointCloud.Name = "cbPointCloud";
      this.cbPointCloud.Size = new System.Drawing.Size(80, 17);
      this.cbPointCloud.TabIndex = 69;
      this.cbPointCloud.Text = "Point Cloud";
      this.cbPointCloud.UseVisualStyleBackColor = true;
      // 
      // ckReplace
      // 
      this.ckReplace.AutoSize = true;
      this.ckReplace.Checked = true;
      this.ckReplace.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckReplace.Location = new System.Drawing.Point(125, 15);
      this.ckReplace.Name = "ckReplace";
      this.ckReplace.Size = new System.Drawing.Size(66, 17);
      this.ckReplace.TabIndex = 68;
      this.ckReplace.Text = "Replace";
      this.ckReplace.UseVisualStyleBackColor = true;
      // 
      // txtOpenByQuery
      // 
      this.txtOpenByQuery.Location = new System.Drawing.Point(15, 50);
      this.txtOpenByQuery.Multiline = true;
      this.txtOpenByQuery.Name = "txtOpenByQuery";
      this.txtOpenByQuery.Size = new System.Drawing.Size(200, 40);
      this.txtOpenByQuery.TabIndex = 67;
      this.txtOpenByQuery.Text = "Lange Haven 145, Schiedam";
      // 
      // cbPanorama
      // 
      this.cbPanorama.AutoSize = true;
      this.cbPanorama.Checked = true;
      this.cbPanorama.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbPanorama.Location = new System.Drawing.Point(73, 95);
      this.cbPanorama.Name = "cbPanorama";
      this.cbPanorama.Size = new System.Drawing.Size(74, 17);
      this.cbPanorama.TabIndex = 66;
      this.cbPanorama.Text = "Panorama";
      this.cbPanorama.UseVisualStyleBackColor = true;
      // 
      // cbOblique
      // 
      this.cbOblique.AutoSize = true;
      this.cbOblique.Checked = true;
      this.cbOblique.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbOblique.Location = new System.Drawing.Point(15, 95);
      this.cbOblique.Name = "cbOblique";
      this.cbOblique.Size = new System.Drawing.Size(62, 17);
      this.cbOblique.TabIndex = 65;
      this.cbOblique.Text = "Oblique";
      this.cbOblique.UseVisualStyleBackColor = true;
      // 
      // btnOpenViewerByQuery
      // 
      this.btnOpenViewerByQuery.Location = new System.Drawing.Point(15, 15);
      this.btnOpenViewerByQuery.Name = "btnOpenViewerByQuery";
      this.btnOpenViewerByQuery.Size = new System.Drawing.Size(100, 30);
      this.btnOpenViewerByQuery.TabIndex = 64;
      this.btnOpenViewerByQuery.Text = "Open by query";
      this.btnOpenViewerByQuery.UseVisualStyleBackColor = true;
      this.btnOpenViewerByQuery.Click += new System.EventHandler(this.btnOpenViewerByQuery_Click);
      // 
      // plControl
      // 
      this.plControl.Controls.Add(this.grCloseViewers);
      this.plControl.Controls.Add(this.grPanoramaList);
      this.plControl.Controls.Add(this.grColorOverlay);
      this.plControl.Controls.Add(this.grSelectFeature);
      this.plControl.Controls.Add(this.grSld);
      this.plControl.Controls.Add(this.grButtonVisibility);
      this.plControl.Controls.Add(this.grOverlay);
      this.plControl.Controls.Add(this.grOpenByQuery);
      this.plControl.Controls.Add(this.grMeasurement);
      this.plControl.Controls.Add(this.grDevTools);
      this.plControl.Controls.Add(this.grRotationsZoomInOut);
      this.plControl.Controls.Add(this.grEvents);
      this.plControl.Controls.Add(this.grRecordingViewerColorPermissions);
      this.plControl.Controls.Add(this.grOrientation);
      this.plControl.Controls.Add(this.grOpenByImageId);
      this.plControl.Controls.Add(this.grCoordinate);
      this.plControl.Controls.Add(this.grAPIInfo);
      this.plControl.Controls.Add(this.grViewerToggles);
      this.plControl.Controls.Add(this.grOpenByAddress);
      this.plControl.Controls.Add(this.grLogin);
      this.plControl.Dock = System.Windows.Forms.DockStyle.Right;
      this.plControl.Location = new System.Drawing.Point(647, 0);
      this.plControl.Name = "plControl";
      this.plControl.Size = new System.Drawing.Size(902, 701);
      this.plControl.TabIndex = 1;
      // 
      // grCloseViewers
      // 
      this.grCloseViewers.Controls.Add(this.btnUp);
      this.grCloseViewers.Controls.Add(this.btnRight);
      this.grCloseViewers.Controls.Add(this.btnLeft);
      this.grCloseViewers.Controls.Add(this.btnDown);
      this.grCloseViewers.Controls.Add(this.btnPointCloudLookAt);
      this.grCloseViewers.Controls.Add(this.btnSetPointStyle);
      this.grCloseViewers.Controls.Add(this.cbPointStyle);
      this.grCloseViewers.Controls.Add(this.btnGetPointStyle);
      this.grCloseViewers.Controls.Add(this.btnCloseObliqueViewer);
      this.grCloseViewers.Controls.Add(this.btnClosePointViewer);
      this.grCloseViewers.Location = new System.Drawing.Point(700, 1);
      this.grCloseViewers.Name = "grCloseViewers";
      this.grCloseViewers.Size = new System.Drawing.Size(200, 120);
      this.grCloseViewers.TabIndex = 74;
      this.grCloseViewers.TabStop = false;
      this.grCloseViewers.Text = "Close viewers";
      // 
      // btnSetPointStyle
      // 
      this.btnSetPointStyle.Location = new System.Drawing.Point(95, 58);
      this.btnSetPointStyle.Name = "btnSetPointStyle";
      this.btnSetPointStyle.Size = new System.Drawing.Size(40, 25);
      this.btnSetPointStyle.TabIndex = 76;
      this.btnSetPointStyle.Text = "Set";
      this.btnSetPointStyle.UseVisualStyleBackColor = true;
      this.btnSetPointStyle.Click += new System.EventHandler(this.btnSetPointStyle_Click);
      // 
      // cbPointStyle
      // 
      this.cbPointStyle.FormattingEnabled = true;
      this.cbPointStyle.Location = new System.Drawing.Point(50, 61);
      this.cbPointStyle.Name = "cbPointStyle";
      this.cbPointStyle.Size = new System.Drawing.Size(40, 21);
      this.cbPointStyle.TabIndex = 75;
      // 
      // btnGetPointStyle
      // 
      this.btnGetPointStyle.Location = new System.Drawing.Point(5, 58);
      this.btnGetPointStyle.Name = "btnGetPointStyle";
      this.btnGetPointStyle.Size = new System.Drawing.Size(40, 25);
      this.btnGetPointStyle.TabIndex = 74;
      this.btnGetPointStyle.Text = "Get";
      this.btnGetPointStyle.UseVisualStyleBackColor = true;
      this.btnGetPointStyle.Click += new System.EventHandler(this.btnGetPointStyle_Click);
      // 
      // btnCloseObliqueViewer
      // 
      this.btnCloseObliqueViewer.Location = new System.Drawing.Point(5, 15);
      this.btnCloseObliqueViewer.Name = "btnCloseObliqueViewer";
      this.btnCloseObliqueViewer.Size = new System.Drawing.Size(80, 38);
      this.btnCloseObliqueViewer.TabIndex = 72;
      this.btnCloseObliqueViewer.Text = "Close obl. viewer";
      this.btnCloseObliqueViewer.UseVisualStyleBackColor = true;
      this.btnCloseObliqueViewer.Click += new System.EventHandler(this.btnCloseObliqueViewer_Click);
      // 
      // btnClosePointViewer
      // 
      this.btnClosePointViewer.Location = new System.Drawing.Point(90, 15);
      this.btnClosePointViewer.Name = "btnClosePointViewer";
      this.btnClosePointViewer.Size = new System.Drawing.Size(80, 38);
      this.btnClosePointViewer.TabIndex = 73;
      this.btnClosePointViewer.Text = "Close point. viewer";
      this.btnClosePointViewer.UseVisualStyleBackColor = true;
      this.btnClosePointViewer.Click += new System.EventHandler(this.btnClosePointViewer_Click);
      // 
      // grPanoramaList
      // 
      this.grPanoramaList.Controls.Add(this.lbPanoramaList);
      this.grPanoramaList.Location = new System.Drawing.Point(731, 243);
      this.grPanoramaList.Name = "grPanoramaList";
      this.grPanoramaList.Size = new System.Drawing.Size(160, 160);
      this.grPanoramaList.TabIndex = 71;
      this.grPanoramaList.TabStop = false;
      this.grPanoramaList.Text = "Viewer list";
      // 
      // lbPanoramaList
      // 
      this.lbPanoramaList.FormattingEnabled = true;
      this.lbPanoramaList.Location = new System.Drawing.Point(5, 15);
      this.lbPanoramaList.Name = "lbPanoramaList";
      this.lbPanoramaList.Size = new System.Drawing.Size(150, 134);
      this.lbPanoramaList.TabIndex = 70;
      this.lbPanoramaList.SelectedIndexChanged += new System.EventHandler(this.lbPanoramaList_SelectedIndexChanged);
      // 
      // grColorOverlay
      // 
      this.grColorOverlay.Controls.Add(this.btnDemoWFSLayer);
      this.grColorOverlay.Controls.Add(this.txtOverlayColor);
      this.grColorOverlay.Controls.Add(this.btnToggleAddressOverlays);
      this.grColorOverlay.Controls.Add(this.btnColorOverlay);
      this.grColorOverlay.Controls.Add(this.rbColor);
      this.grColorOverlay.Controls.Add(this.rbSLD);
      this.grColorOverlay.Location = new System.Drawing.Point(731, 403);
      this.grColorOverlay.Name = "grColorOverlay";
      this.grColorOverlay.Size = new System.Drawing.Size(160, 160);
      this.grColorOverlay.TabIndex = 69;
      this.grColorOverlay.TabStop = false;
      this.grColorOverlay.Text = "Overlay";
      // 
      // btnDemoWFSLayer
      // 
      this.btnDemoWFSLayer.Location = new System.Drawing.Point(5, 115);
      this.btnDemoWFSLayer.Name = "btnDemoWFSLayer";
      this.btnDemoWFSLayer.Size = new System.Drawing.Size(140, 30);
      this.btnDemoWFSLayer.TabIndex = 69;
      this.btnDemoWFSLayer.Text = "Add demo WFS Layer";
      this.btnDemoWFSLayer.UseVisualStyleBackColor = true;
      this.btnDemoWFSLayer.Click += new System.EventHandler(this.btnDemoWFSLayer_Click);
      // 
      // txtOverlayColor
      // 
      this.txtOverlayColor.Enabled = false;
      this.txtOverlayColor.Location = new System.Drawing.Point(5, 40);
      this.txtOverlayColor.Name = "txtOverlayColor";
      this.txtOverlayColor.Size = new System.Drawing.Size(140, 20);
      this.txtOverlayColor.TabIndex = 68;
      // 
      // btnToggleAddressOverlays
      // 
      this.btnToggleAddressOverlays.Location = new System.Drawing.Point(5, 80);
      this.btnToggleAddressOverlays.Name = "btnToggleAddressOverlays";
      this.btnToggleAddressOverlays.Size = new System.Drawing.Size(140, 30);
      this.btnToggleAddressOverlays.TabIndex = 57;
      this.btnToggleAddressOverlays.Text = "Toggle Address overlays";
      this.btnToggleAddressOverlays.UseVisualStyleBackColor = true;
      this.btnToggleAddressOverlays.Click += new System.EventHandler(this.btnToggleAddressOverlays_Click);
      // 
      // btnColorOverlay
      // 
      this.btnColorOverlay.Location = new System.Drawing.Point(5, 15);
      this.btnColorOverlay.Name = "btnColorOverlay";
      this.btnColorOverlay.Size = new System.Drawing.Size(140, 23);
      this.btnColorOverlay.TabIndex = 58;
      this.btnColorOverlay.Text = "Color overlay";
      this.btnColorOverlay.UseVisualStyleBackColor = true;
      this.btnColorOverlay.Click += new System.EventHandler(this.btnColorOverlay_Click);
      // 
      // rbColor
      // 
      this.rbColor.AutoSize = true;
      this.rbColor.Location = new System.Drawing.Point(50, 60);
      this.rbColor.Name = "rbColor";
      this.rbColor.Size = new System.Drawing.Size(49, 17);
      this.rbColor.TabIndex = 59;
      this.rbColor.Text = "Color";
      this.rbColor.UseVisualStyleBackColor = true;
      // 
      // rbSLD
      // 
      this.rbSLD.AutoSize = true;
      this.rbSLD.Checked = true;
      this.rbSLD.Location = new System.Drawing.Point(5, 60);
      this.rbSLD.Name = "rbSLD";
      this.rbSLD.Size = new System.Drawing.Size(46, 17);
      this.rbSLD.TabIndex = 58;
      this.rbSLD.TabStop = true;
      this.rbSLD.Text = "SLD";
      this.rbSLD.UseVisualStyleBackColor = true;
      // 
      // grSelectFeature
      // 
      this.grSelectFeature.Controls.Add(this.ckShowAttributePanelOnFeatureClick);
      this.grSelectFeature.Controls.Add(this.txtValue);
      this.grSelectFeature.Controls.Add(this.lblValue);
      this.grSelectFeature.Controls.Add(this.txtName);
      this.grSelectFeature.Controls.Add(this.lblPropertyName);
      this.grSelectFeature.Controls.Add(this.btnSelectFeature);
      this.grSelectFeature.Location = new System.Drawing.Point(731, 563);
      this.grSelectFeature.Name = "grSelectFeature";
      this.grSelectFeature.Size = new System.Drawing.Size(160, 130);
      this.grSelectFeature.TabIndex = 56;
      this.grSelectFeature.TabStop = false;
      this.grSelectFeature.Text = "Select Feature";
      // 
      // ckShowAttributePanelOnFeatureClick
      // 
      this.ckShowAttributePanelOnFeatureClick.AutoSize = true;
      this.ckShowAttributePanelOnFeatureClick.Checked = true;
      this.ckShowAttributePanelOnFeatureClick.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckShowAttributePanelOnFeatureClick.Location = new System.Drawing.Point(6, 96);
      this.ckShowAttributePanelOnFeatureClick.Name = "ckShowAttributePanelOnFeatureClick";
      this.ckShowAttributePanelOnFeatureClick.Size = new System.Drawing.Size(161, 17);
      this.ckShowAttributePanelOnFeatureClick.TabIndex = 67;
      this.ckShowAttributePanelOnFeatureClick.Text = "Show att. panel feature click";
      this.ckShowAttributePanelOnFeatureClick.UseVisualStyleBackColor = true;
      this.ckShowAttributePanelOnFeatureClick.CheckedChanged += new System.EventHandler(this.ckShowAttributePanelOnFeatureClick_CheckedChanged);
      // 
      // txtValue
      // 
      this.txtValue.Location = new System.Drawing.Point(85, 70);
      this.txtValue.Name = "txtValue";
      this.txtValue.Size = new System.Drawing.Size(70, 20);
      this.txtValue.TabIndex = 58;
      this.txtValue.Text = "Polygon-feature-cj7hkzyaj000b3e65n0c1brht";
      // 
      // lblValue
      // 
      this.lblValue.AutoSize = true;
      this.lblValue.Location = new System.Drawing.Point(85, 50);
      this.lblValue.Name = "lblValue";
      this.lblValue.Size = new System.Drawing.Size(75, 13);
      this.lblValue.TabIndex = 59;
      this.lblValue.Text = "Property value";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(5, 70);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(70, 20);
      this.txtName.TabIndex = 56;
      this.txtName.Text = "name";
      // 
      // lblPropertyName
      // 
      this.lblPropertyName.AutoSize = true;
      this.lblPropertyName.Location = new System.Drawing.Point(5, 50);
      this.lblPropertyName.Name = "lblPropertyName";
      this.lblPropertyName.Size = new System.Drawing.Size(75, 13);
      this.lblPropertyName.TabIndex = 57;
      this.lblPropertyName.Text = "Property name";
      // 
      // btnSelectFeature
      // 
      this.btnSelectFeature.Location = new System.Drawing.Point(5, 15);
      this.btnSelectFeature.Name = "btnSelectFeature";
      this.btnSelectFeature.Size = new System.Drawing.Size(150, 30);
      this.btnSelectFeature.TabIndex = 55;
      this.btnSelectFeature.Text = "Select feature";
      this.btnSelectFeature.UseVisualStyleBackColor = true;
      this.btnSelectFeature.Click += new System.EventHandler(this.btnSelectFeature_Click);
      // 
      // grSld
      // 
      this.grSld.Controls.Add(this.txtSld);
      this.grSld.Location = new System.Drawing.Point(561, 563);
      this.grSld.Name = "grSld";
      this.grSld.Size = new System.Drawing.Size(170, 130);
      this.grSld.TabIndex = 55;
      this.grSld.TabStop = false;
      this.grSld.Text = "Sld";
      // 
      // txtSld
      // 
      this.txtSld.Location = new System.Drawing.Point(6, 19);
      this.txtSld.Multiline = true;
      this.txtSld.Name = "txtSld";
      this.txtSld.Size = new System.Drawing.Size(160, 105);
      this.txtSld.TabIndex = 1;
      this.txtSld.Text = resources.GetString("txtSld.Text");
      // 
      // grButtonVisibility
      // 
      this.grButtonVisibility.Controls.Add(this.cbViewerButton);
      this.grButtonVisibility.Controls.Add(this.btnSetButtonVisibility);
      this.grButtonVisibility.Controls.Add(this.btnGetButtonEnabled);
      this.grButtonVisibility.Location = new System.Drawing.Point(329, 323);
      this.grButtonVisibility.Name = "grButtonVisibility";
      this.grButtonVisibility.Size = new System.Drawing.Size(151, 120);
      this.grButtonVisibility.TabIndex = 54;
      this.grButtonVisibility.TabStop = false;
      this.grButtonVisibility.Text = "Button visibility";
      // 
      // cbViewerButton
      // 
      this.cbViewerButton.FormattingEnabled = true;
      this.cbViewerButton.Location = new System.Drawing.Point(5, 85);
      this.cbViewerButton.Name = "cbViewerButton";
      this.cbViewerButton.Size = new System.Drawing.Size(140, 21);
      this.cbViewerButton.TabIndex = 51;
      // 
      // btnSetButtonVisibility
      // 
      this.btnSetButtonVisibility.Location = new System.Drawing.Point(5, 45);
      this.btnSetButtonVisibility.Name = "btnSetButtonVisibility";
      this.btnSetButtonVisibility.Size = new System.Drawing.Size(140, 30);
      this.btnSetButtonVisibility.TabIndex = 50;
      this.btnSetButtonVisibility.Text = "Toggle button enabled";
      this.btnSetButtonVisibility.UseVisualStyleBackColor = true;
      this.btnSetButtonVisibility.Click += new System.EventHandler(this.btnSetButtonVisibility_Click);
      // 
      // btnGetButtonEnabled
      // 
      this.btnGetButtonEnabled.Location = new System.Drawing.Point(5, 15);
      this.btnGetButtonEnabled.Name = "btnGetButtonEnabled";
      this.btnGetButtonEnabled.Size = new System.Drawing.Size(141, 30);
      this.btnGetButtonEnabled.TabIndex = 49;
      this.btnGetButtonEnabled.Text = "Get button enabled";
      this.btnGetButtonEnabled.UseVisualStyleBackColor = true;
      this.btnGetButtonEnabled.Click += new System.EventHandler(this.btnGetButtonEnabled_Click);
      // 
      // grOverlay
      // 
      this.grOverlay.Controls.Add(this.btnDrawDistance);
      this.grOverlay.Controls.Add(this.txtDrawDistance);
      this.grOverlay.Controls.Add(this.btnRemoveOverlay);
      this.grOverlay.Controls.Add(this.txtOverlayGeoJson);
      this.grOverlay.Controls.Add(this.btnAddOverlay);
      this.grOverlay.Location = new System.Drawing.Point(277, 563);
      this.grOverlay.Name = "grOverlay";
      this.grOverlay.Size = new System.Drawing.Size(280, 130);
      this.grOverlay.TabIndex = 53;
      this.grOverlay.TabStop = false;
      this.grOverlay.Text = "Load GeoJSON overlay";
      // 
      // btnDrawDistance
      // 
      this.btnDrawDistance.Location = new System.Drawing.Point(178, 75);
      this.btnDrawDistance.Name = "btnDrawDistance";
      this.btnDrawDistance.Size = new System.Drawing.Size(100, 23);
      this.btnDrawDistance.TabIndex = 68;
      this.btnDrawDistance.Text = "Set draw distance";
      this.btnDrawDistance.UseVisualStyleBackColor = true;
      this.btnDrawDistance.Click += new System.EventHandler(this.btnDrawDistance_Click);
      // 
      // txtDrawDistance
      // 
      this.txtDrawDistance.Location = new System.Drawing.Point(178, 105);
      this.txtDrawDistance.Name = "txtDrawDistance";
      this.txtDrawDistance.Size = new System.Drawing.Size(100, 20);
      this.txtDrawDistance.TabIndex = 67;
      this.txtDrawDistance.Text = "30";
      // 
      // btnRemoveOverlay
      // 
      this.btnRemoveOverlay.Location = new System.Drawing.Point(178, 15);
      this.btnRemoveOverlay.Name = "btnRemoveOverlay";
      this.btnRemoveOverlay.Size = new System.Drawing.Size(100, 23);
      this.btnRemoveOverlay.TabIndex = 2;
      this.btnRemoveOverlay.Text = "Remove overlay";
      this.btnRemoveOverlay.UseVisualStyleBackColor = true;
      this.btnRemoveOverlay.Click += new System.EventHandler(this.btnRemoveOverlay_Click);
      // 
      // txtOverlayGeoJson
      // 
      this.txtOverlayGeoJson.Location = new System.Drawing.Point(6, 19);
      this.txtOverlayGeoJson.Multiline = true;
      this.txtOverlayGeoJson.Name = "txtOverlayGeoJson";
      this.txtOverlayGeoJson.Size = new System.Drawing.Size(168, 105);
      this.txtOverlayGeoJson.TabIndex = 1;
      this.txtOverlayGeoJson.Text = resources.GetString("txtOverlayGeoJson.Text");
      // 
      // btnAddOverlay
      // 
      this.btnAddOverlay.Location = new System.Drawing.Point(178, 45);
      this.btnAddOverlay.Name = "btnAddOverlay";
      this.btnAddOverlay.Size = new System.Drawing.Size(100, 23);
      this.btnAddOverlay.TabIndex = 0;
      this.btnAddOverlay.Text = "Add overlay";
      this.btnAddOverlay.UseVisualStyleBackColor = true;
      this.btnAddOverlay.Click += new System.EventHandler(this.btnAddOverlay_Click);
      // 
      // grMeasurement
      // 
      this.grMeasurement.Controls.Add(this.btnGetActiveMeasurement);
      this.grMeasurement.Controls.Add(this.rbMeasPolygon);
      this.grMeasurement.Controls.Add(this.rbMeasLineString);
      this.grMeasurement.Controls.Add(this.rbMeasPoint);
      this.grMeasurement.Controls.Add(this.rbMeasDefault);
      this.grMeasurement.Controls.Add(this.btnStartMeasurementMode);
      this.grMeasurement.Controls.Add(this.btnStopMeasurementMode);
      this.grMeasurement.Location = new System.Drawing.Point(7, 558);
      this.grMeasurement.Name = "grMeasurement";
      this.grMeasurement.Size = new System.Drawing.Size(264, 135);
      this.grMeasurement.TabIndex = 52;
      this.grMeasurement.TabStop = false;
      this.grMeasurement.Text = "Measurement";
      // 
      // btnGetActiveMeasurement
      // 
      this.btnGetActiveMeasurement.Location = new System.Drawing.Point(5, 85);
      this.btnGetActiveMeasurement.Name = "btnGetActiveMeasurement";
      this.btnGetActiveMeasurement.Size = new System.Drawing.Size(150, 30);
      this.btnGetActiveMeasurement.TabIndex = 62;
      this.btnGetActiveMeasurement.Text = "Get Active Measurement";
      this.btnGetActiveMeasurement.UseVisualStyleBackColor = true;
      this.btnGetActiveMeasurement.Click += new System.EventHandler(this.btnGetMeasurementInfo_Click);
      // 
      // rbMeasPolygon
      // 
      this.rbMeasPolygon.AutoSize = true;
      this.rbMeasPolygon.Location = new System.Drawing.Point(165, 95);
      this.rbMeasPolygon.Name = "rbMeasPolygon";
      this.rbMeasPolygon.Size = new System.Drawing.Size(63, 17);
      this.rbMeasPolygon.TabIndex = 61;
      this.rbMeasPolygon.Text = "Polygon";
      this.rbMeasPolygon.UseVisualStyleBackColor = true;
      // 
      // rbMeasLineString
      // 
      this.rbMeasLineString.AutoSize = true;
      this.rbMeasLineString.Location = new System.Drawing.Point(165, 69);
      this.rbMeasLineString.Name = "rbMeasLineString";
      this.rbMeasLineString.Size = new System.Drawing.Size(73, 17);
      this.rbMeasLineString.TabIndex = 60;
      this.rbMeasLineString.Text = "Line string";
      this.rbMeasLineString.UseVisualStyleBackColor = true;
      // 
      // rbMeasPoint
      // 
      this.rbMeasPoint.AutoSize = true;
      this.rbMeasPoint.Location = new System.Drawing.Point(165, 38);
      this.rbMeasPoint.Name = "rbMeasPoint";
      this.rbMeasPoint.Size = new System.Drawing.Size(49, 17);
      this.rbMeasPoint.TabIndex = 59;
      this.rbMeasPoint.Text = "Point";
      this.rbMeasPoint.UseVisualStyleBackColor = true;
      // 
      // rbMeasDefault
      // 
      this.rbMeasDefault.AutoSize = true;
      this.rbMeasDefault.Checked = true;
      this.rbMeasDefault.Location = new System.Drawing.Point(165, 15);
      this.rbMeasDefault.Name = "rbMeasDefault";
      this.rbMeasDefault.Size = new System.Drawing.Size(59, 17);
      this.rbMeasDefault.TabIndex = 58;
      this.rbMeasDefault.TabStop = true;
      this.rbMeasDefault.Text = "Default";
      this.rbMeasDefault.UseVisualStyleBackColor = true;
      // 
      // btnStartMeasurementMode
      // 
      this.btnStartMeasurementMode.Location = new System.Drawing.Point(5, 15);
      this.btnStartMeasurementMode.Name = "btnStartMeasurementMode";
      this.btnStartMeasurementMode.Size = new System.Drawing.Size(150, 30);
      this.btnStartMeasurementMode.TabIndex = 57;
      this.btnStartMeasurementMode.Text = "Start Measurement Mode";
      this.btnStartMeasurementMode.UseVisualStyleBackColor = true;
      this.btnStartMeasurementMode.Click += new System.EventHandler(this.btnStartMeasurementMode_Click);
      // 
      // btnStopMeasurementMode
      // 
      this.btnStopMeasurementMode.Location = new System.Drawing.Point(6, 49);
      this.btnStopMeasurementMode.Name = "btnStopMeasurementMode";
      this.btnStopMeasurementMode.Size = new System.Drawing.Size(150, 30);
      this.btnStopMeasurementMode.TabIndex = 56;
      this.btnStopMeasurementMode.Text = "Stop Measurement Mode";
      this.btnStopMeasurementMode.UseVisualStyleBackColor = true;
      this.btnStopMeasurementMode.Click += new System.EventHandler(this.btnStopMeasurementMode_Click);
      // 
      // grDevTools
      // 
      this.grDevTools.Controls.Add(this.btnCloseDefTools);
      this.grDevTools.Controls.Add(this.btnShowDefTools);
      this.grDevTools.Location = new System.Drawing.Point(345, 265);
      this.grDevTools.Name = "grDevTools";
      this.grDevTools.Size = new System.Drawing.Size(135, 54);
      this.grDevTools.TabIndex = 51;
      this.grDevTools.TabStop = false;
      this.grDevTools.Text = "Dev tools";
      // 
      // btnCloseDefTools
      // 
      this.btnCloseDefTools.Location = new System.Drawing.Point(70, 15);
      this.btnCloseDefTools.Name = "btnCloseDefTools";
      this.btnCloseDefTools.Size = new System.Drawing.Size(60, 35);
      this.btnCloseDefTools.TabIndex = 49;
      this.btnCloseDefTools.Text = "Close dev tools";
      this.btnCloseDefTools.UseVisualStyleBackColor = true;
      this.btnCloseDefTools.Click += new System.EventHandler(this.btnCloseDevTools_Click);
      // 
      // btnShowDefTools
      // 
      this.btnShowDefTools.Location = new System.Drawing.Point(5, 15);
      this.btnShowDefTools.Name = "btnShowDefTools";
      this.btnShowDefTools.Size = new System.Drawing.Size(60, 35);
      this.btnShowDefTools.TabIndex = 48;
      this.btnShowDefTools.Text = "Show dev tools";
      this.btnShowDefTools.UseVisualStyleBackColor = true;
      this.btnShowDefTools.Click += new System.EventHandler(this.btnShowDevTools_Click);
      // 
      // grRotationsZoomInOut
      // 
      this.grRotationsZoomInOut.Controls.Add(this.btnGetViewers);
      this.grRotationsZoomInOut.Controls.Add(this.btnClosePanoramaViewer);
      this.grRotationsZoomInOut.Controls.Add(this.lblDeltaYawPitch);
      this.grRotationsZoomInOut.Controls.Add(this.txtDeltaYawPitch);
      this.grRotationsZoomInOut.Controls.Add(this.btnRotateDown);
      this.grRotationsZoomInOut.Controls.Add(this.btnRotateUp);
      this.grRotationsZoomInOut.Controls.Add(this.btnRotateRight);
      this.grRotationsZoomInOut.Controls.Add(this.btnZoomOut);
      this.grRotationsZoomInOut.Controls.Add(this.btRotateLeft);
      this.grRotationsZoomInOut.Controls.Add(this.btnZoomIn);
      this.grRotationsZoomInOut.Location = new System.Drawing.Point(0, 153);
      this.grRotationsZoomInOut.Name = "grRotationsZoomInOut";
      this.grRotationsZoomInOut.Size = new System.Drawing.Size(180, 162);
      this.grRotationsZoomInOut.TabIndex = 0;
      this.grRotationsZoomInOut.TabStop = false;
      this.grRotationsZoomInOut.Text = "Rotations / zoom in / zoom out";
      // 
      // btnGetViewers
      // 
      this.btnGetViewers.Location = new System.Drawing.Point(95, 119);
      this.btnGetViewers.Name = "btnGetViewers";
      this.btnGetViewers.Size = new System.Drawing.Size(80, 25);
      this.btnGetViewers.TabIndex = 62;
      this.btnGetViewers.Text = "Get viewers";
      this.btnGetViewers.UseVisualStyleBackColor = true;
      this.btnGetViewers.Click += new System.EventHandler(this.btnGetViewers_Click);
      // 
      // btnClosePanoramaViewer
      // 
      this.btnClosePanoramaViewer.Location = new System.Drawing.Point(6, 119);
      this.btnClosePanoramaViewer.Name = "btnClosePanoramaViewer";
      this.btnClosePanoramaViewer.Size = new System.Drawing.Size(80, 38);
      this.btnClosePanoramaViewer.TabIndex = 61;
      this.btnClosePanoramaViewer.Text = "Close pan. viewer";
      this.btnClosePanoramaViewer.UseVisualStyleBackColor = true;
      this.btnClosePanoramaViewer.Click += new System.EventHandler(this.btnClosePanoramaViewer_Click);
      // 
      // lblDeltaYawPitch
      // 
      this.lblDeltaYawPitch.AutoSize = true;
      this.lblDeltaYawPitch.Location = new System.Drawing.Point(5, 97);
      this.lblDeltaYawPitch.Name = "lblDeltaYawPitch";
      this.lblDeltaYawPitch.Size = new System.Drawing.Size(86, 13);
      this.lblDeltaYawPitch.TabIndex = 20;
      this.lblDeltaYawPitch.Text = "delta yaw / pitch";
      // 
      // txtDeltaYawPitch
      // 
      this.txtDeltaYawPitch.Location = new System.Drawing.Point(95, 97);
      this.txtDeltaYawPitch.Name = "txtDeltaYawPitch";
      this.txtDeltaYawPitch.Size = new System.Drawing.Size(80, 20);
      this.txtDeltaYawPitch.TabIndex = 21;
      this.txtDeltaYawPitch.Text = "1";
      // 
      // btnRotateDown
      // 
      this.btnRotateDown.Location = new System.Drawing.Point(95, 15);
      this.btnRotateDown.Name = "btnRotateDown";
      this.btnRotateDown.Size = new System.Drawing.Size(80, 25);
      this.btnRotateDown.TabIndex = 19;
      this.btnRotateDown.Text = "Rotate down";
      this.btnRotateDown.UseVisualStyleBackColor = true;
      this.btnRotateDown.Click += new System.EventHandler(this.btnRotateDown_Click);
      // 
      // btnRotateUp
      // 
      this.btnRotateUp.Location = new System.Drawing.Point(6, 15);
      this.btnRotateUp.Name = "btnRotateUp";
      this.btnRotateUp.Size = new System.Drawing.Size(80, 25);
      this.btnRotateUp.TabIndex = 18;
      this.btnRotateUp.Text = "Rotate up";
      this.btnRotateUp.UseVisualStyleBackColor = true;
      this.btnRotateUp.Click += new System.EventHandler(this.btnRotateUp_Click);
      // 
      // btnRotateRight
      // 
      this.btnRotateRight.Location = new System.Drawing.Point(6, 41);
      this.btnRotateRight.Name = "btnRotateRight";
      this.btnRotateRight.Size = new System.Drawing.Size(80, 25);
      this.btnRotateRight.TabIndex = 6;
      this.btnRotateRight.Text = "Rotate right";
      this.btnRotateRight.UseVisualStyleBackColor = true;
      this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
      // 
      // btnZoomOut
      // 
      this.btnZoomOut.Location = new System.Drawing.Point(95, 68);
      this.btnZoomOut.Name = "btnZoomOut";
      this.btnZoomOut.Size = new System.Drawing.Size(80, 25);
      this.btnZoomOut.TabIndex = 46;
      this.btnZoomOut.Text = "Zoom out";
      this.btnZoomOut.UseVisualStyleBackColor = true;
      this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
      // 
      // btRotateLeft
      // 
      this.btRotateLeft.Location = new System.Drawing.Point(6, 69);
      this.btRotateLeft.Name = "btRotateLeft";
      this.btRotateLeft.Size = new System.Drawing.Size(80, 25);
      this.btRotateLeft.TabIndex = 0;
      this.btRotateLeft.Text = "Rotate left";
      this.btRotateLeft.UseVisualStyleBackColor = true;
      this.btRotateLeft.Click += new System.EventHandler(this.btRotateLeft_Click);
      // 
      // btnZoomIn
      // 
      this.btnZoomIn.Location = new System.Drawing.Point(95, 41);
      this.btnZoomIn.Name = "btnZoomIn";
      this.btnZoomIn.Size = new System.Drawing.Size(80, 25);
      this.btnZoomIn.TabIndex = 45;
      this.btnZoomIn.Text = "Zoom in";
      this.btnZoomIn.UseVisualStyleBackColor = true;
      this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
      // 
      // grEvents
      // 
      this.grEvents.Controls.Add(this.lbViewerEvents);
      this.grEvents.Location = new System.Drawing.Point(6, 452);
      this.grEvents.Name = "grEvents";
      this.grEvents.Size = new System.Drawing.Size(728, 100);
      this.grEvents.TabIndex = 50;
      this.grEvents.TabStop = false;
      this.grEvents.Text = "Viewer events";
      // 
      // lbViewerEvents
      // 
      this.lbViewerEvents.FormattingEnabled = true;
      this.lbViewerEvents.Location = new System.Drawing.Point(5, 15);
      this.lbViewerEvents.Name = "lbViewerEvents";
      this.lbViewerEvents.Size = new System.Drawing.Size(714, 82);
      this.lbViewerEvents.TabIndex = 0;
      // 
      // grRecordingViewerColorPermissions
      // 
      this.grRecordingViewerColorPermissions.Controls.Add(this.txtRecordingViewerColorPermissions);
      this.grRecordingViewerColorPermissions.Controls.Add(this.btnGetPermissions);
      this.grRecordingViewerColorPermissions.Controls.Add(this.btnGetRecording);
      this.grRecordingViewerColorPermissions.Controls.Add(this.btnGetViewerColor);
      this.grRecordingViewerColorPermissions.Location = new System.Drawing.Point(5, 316);
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
      this.grOrientation.Controls.Add(this.btnGetDebugLogs);
      this.grOrientation.Controls.Add(this.txtYaw);
      this.grOrientation.Controls.Add(this.lblYaw);
      this.grOrientation.Controls.Add(this.lblPitch);
      this.grOrientation.Controls.Add(this.txtPitch);
      this.grOrientation.Controls.Add(this.lblhFov);
      this.grOrientation.Controls.Add(this.txthFov);
      this.grOrientation.Controls.Add(this.btnGetOrientation);
      this.grOrientation.Controls.Add(this.btnSetOrientation);
      this.grOrientation.Location = new System.Drawing.Point(489, 220);
      this.grOrientation.Name = "grOrientation";
      this.grOrientation.Size = new System.Drawing.Size(240, 115);
      this.grOrientation.TabIndex = 0;
      this.grOrientation.TabStop = false;
      this.grOrientation.Text = "Orientation";
      // 
      // btnGetDebugLogs
      // 
      this.btnGetDebugLogs.Location = new System.Drawing.Point(5, 45);
      this.btnGetDebugLogs.Name = "btnGetDebugLogs";
      this.btnGetDebugLogs.Size = new System.Drawing.Size(100, 30);
      this.btnGetDebugLogs.TabIndex = 28;
      this.btnGetDebugLogs.Text = "Get Debug logs";
      this.btnGetDebugLogs.UseVisualStyleBackColor = true;
      this.btnGetDebugLogs.Click += new System.EventHandler(this.btnGetDebugLogs_Click);
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
      this.grOpenByImageId.Controls.Add(this.txtBrightnessContrast);
      this.grOpenByImageId.Controls.Add(this.btnContrast);
      this.grOpenByImageId.Controls.Add(this.btnBrightness);
      this.grOpenByImageId.Controls.Add(this.btnGetAddress);
      this.grOpenByImageId.Controls.Add(this.btnOpenByImageId);
      this.grOpenByImageId.Controls.Add(this.txtImageId);
      this.grOpenByImageId.Location = new System.Drawing.Point(491, 338);
      this.grOpenByImageId.Name = "grOpenByImageId";
      this.grOpenByImageId.Size = new System.Drawing.Size(238, 105);
      this.grOpenByImageId.TabIndex = 44;
      this.grOpenByImageId.TabStop = false;
      this.grOpenByImageId.Text = "Open by imageId";
      // 
      // txtBrightnessContrast
      // 
      this.txtBrightnessContrast.Location = new System.Drawing.Point(120, 81);
      this.txtBrightnessContrast.Name = "txtBrightnessContrast";
      this.txtBrightnessContrast.Size = new System.Drawing.Size(110, 20);
      this.txtBrightnessContrast.TabIndex = 52;
      // 
      // btnContrast
      // 
      this.btnContrast.Location = new System.Drawing.Point(120, 47);
      this.btnContrast.Name = "btnContrast";
      this.btnContrast.Size = new System.Drawing.Size(110, 30);
      this.btnContrast.TabIndex = 51;
      this.btnContrast.Text = "Set Contrast";
      this.btnContrast.UseVisualStyleBackColor = true;
      this.btnContrast.Click += new System.EventHandler(this.btnContrast_Click);
      // 
      // btnBrightness
      // 
      this.btnBrightness.Location = new System.Drawing.Point(120, 15);
      this.btnBrightness.Name = "btnBrightness";
      this.btnBrightness.Size = new System.Drawing.Size(110, 30);
      this.btnBrightness.TabIndex = 50;
      this.btnBrightness.Text = "Set Brightness";
      this.btnBrightness.UseVisualStyleBackColor = true;
      this.btnBrightness.Click += new System.EventHandler(this.btnBrightness_Click);
      // 
      // btnGetAddress
      // 
      this.btnGetAddress.Location = new System.Drawing.Point(5, 75);
      this.btnGetAddress.Name = "btnGetAddress";
      this.btnGetAddress.Size = new System.Drawing.Size(100, 30);
      this.btnGetAddress.TabIndex = 49;
      this.btnGetAddress.Text = "Get address settings";
      this.btnGetAddress.UseVisualStyleBackColor = true;
      this.btnGetAddress.Click += new System.EventHandler(this.btnGetAddress_Click);
      // 
      // btnOpenByImageId
      // 
      this.btnOpenByImageId.Location = new System.Drawing.Point(5, 40);
      this.btnOpenByImageId.Name = "btnOpenByImageId";
      this.btnOpenByImageId.Size = new System.Drawing.Size(100, 30);
      this.btnOpenByImageId.TabIndex = 43;
      this.btnOpenByImageId.Text = "Open by ImageId";
      this.btnOpenByImageId.UseVisualStyleBackColor = true;
      this.btnOpenByImageId.Click += new System.EventHandler(this.btnOpenByImageId_Click);
      // 
      // txtImageId
      // 
      this.txtImageId.Location = new System.Drawing.Point(8, 15);
      this.txtImageId.Name = "txtImageId";
      this.txtImageId.Size = new System.Drawing.Size(100, 20);
      this.txtImageId.TabIndex = 42;
      this.txtImageId.Text = "5D4KX5SM";
      // 
      // grCoordinate
      // 
      this.grCoordinate.Controls.Add(this.btnSetPointSize);
      this.grCoordinate.Controls.Add(this.txtPointSize);
      this.grCoordinate.Controls.Add(this.btnGetPointSize);
      this.grCoordinate.Controls.Add(this.btnSetPointBudget);
      this.grCoordinate.Controls.Add(this.cbPointBudget);
      this.grCoordinate.Controls.Add(this.btnGetPointBudget);
      this.grCoordinate.Controls.Add(this.btnEdges);
      this.grCoordinate.Controls.Add(this.btnCameraPosition);
      this.grCoordinate.Controls.Add(this.txtlkAtX);
      this.grCoordinate.Controls.Add(this.txtlkAtY);
      this.grCoordinate.Controls.Add(this.txtlkAtZ);
      this.grCoordinate.Controls.Add(this.btnFlyTo);
      this.grCoordinate.Controls.Add(this.txtX);
      this.grCoordinate.Controls.Add(this.txtY);
      this.grCoordinate.Controls.Add(this.txtZ);
      this.grCoordinate.Controls.Add(this.lblX);
      this.grCoordinate.Controls.Add(this.lblY);
      this.grCoordinate.Controls.Add(this.lblZ);
      this.grCoordinate.Controls.Add(this.btnOpenByCoordinate);
      this.grCoordinate.Controls.Add(this.btnLookAtCoordinate);
      this.grCoordinate.Location = new System.Drawing.Point(484, 124);
      this.grCoordinate.Name = "grCoordinate";
      this.grCoordinate.Size = new System.Drawing.Size(415, 90);
      this.grCoordinate.TabIndex = 0;
      this.grCoordinate.TabStop = false;
      this.grCoordinate.Text = "Coordinate";
      // 
      // btnSetPointSize
      // 
      this.btnSetPointSize.Location = new System.Drawing.Point(375, 39);
      this.btnSetPointSize.Name = "btnSetPointSize";
      this.btnSetPointSize.Size = new System.Drawing.Size(40, 25);
      this.btnSetPointSize.TabIndex = 56;
      this.btnSetPointSize.Text = "Set";
      this.btnSetPointSize.UseVisualStyleBackColor = true;
      this.btnSetPointSize.Click += new System.EventHandler(this.btnSetPointSize_Click);
      // 
      // txtPointSize
      // 
      this.txtPointSize.Location = new System.Drawing.Point(330, 42);
      this.txtPointSize.Name = "txtPointSize";
      this.txtPointSize.Size = new System.Drawing.Size(40, 20);
      this.txtPointSize.TabIndex = 55;
      this.txtPointSize.Text = "0";
      // 
      // btnGetPointSize
      // 
      this.btnGetPointSize.Location = new System.Drawing.Point(285, 39);
      this.btnGetPointSize.Name = "btnGetPointSize";
      this.btnGetPointSize.Size = new System.Drawing.Size(40, 25);
      this.btnGetPointSize.TabIndex = 54;
      this.btnGetPointSize.Text = "Get";
      this.btnGetPointSize.UseVisualStyleBackColor = true;
      this.btnGetPointSize.Click += new System.EventHandler(this.btnGetPointSize_Click);
      // 
      // btnSetPointBudget
      // 
      this.btnSetPointBudget.Location = new System.Drawing.Point(375, 62);
      this.btnSetPointBudget.Name = "btnSetPointBudget";
      this.btnSetPointBudget.Size = new System.Drawing.Size(40, 25);
      this.btnSetPointBudget.TabIndex = 53;
      this.btnSetPointBudget.Text = "Set";
      this.btnSetPointBudget.UseVisualStyleBackColor = true;
      this.btnSetPointBudget.Click += new System.EventHandler(this.btnSetPointBudget_Click);
      // 
      // cbPointBudget
      // 
      this.cbPointBudget.FormattingEnabled = true;
      this.cbPointBudget.Location = new System.Drawing.Point(330, 65);
      this.cbPointBudget.Name = "cbPointBudget";
      this.cbPointBudget.Size = new System.Drawing.Size(40, 21);
      this.cbPointBudget.TabIndex = 52;
      // 
      // btnGetPointBudget
      // 
      this.btnGetPointBudget.Location = new System.Drawing.Point(285, 62);
      this.btnGetPointBudget.Name = "btnGetPointBudget";
      this.btnGetPointBudget.Size = new System.Drawing.Size(40, 25);
      this.btnGetPointBudget.TabIndex = 51;
      this.btnGetPointBudget.Text = "Get";
      this.btnGetPointBudget.UseVisualStyleBackColor = true;
      this.btnGetPointBudget.Click += new System.EventHandler(this.btnGetPointBudget_Click);
      // 
      // btnEdges
      // 
      this.btnEdges.Location = new System.Drawing.Point(375, 15);
      this.btnEdges.Name = "btnEdges";
      this.btnEdges.Size = new System.Drawing.Size(40, 25);
      this.btnEdges.TabIndex = 50;
      this.btnEdges.Text = "Edges";
      this.btnEdges.UseVisualStyleBackColor = true;
      this.btnEdges.Click += new System.EventHandler(this.btnEdges_Click);
      // 
      // btnCameraPosition
      // 
      this.btnCameraPosition.Location = new System.Drawing.Point(330, 15);
      this.btnCameraPosition.Name = "btnCameraPosition";
      this.btnCameraPosition.Size = new System.Drawing.Size(40, 25);
      this.btnCameraPosition.TabIndex = 49;
      this.btnCameraPosition.Text = "Pos";
      this.btnCameraPosition.UseVisualStyleBackColor = true;
      this.btnCameraPosition.Click += new System.EventHandler(this.btnCameraPosition_Click);
      // 
      // txtlkAtX
      // 
      this.txtlkAtX.Location = new System.Drawing.Point(215, 15);
      this.txtlkAtX.Name = "txtlkAtX";
      this.txtlkAtX.Size = new System.Drawing.Size(65, 20);
      this.txtlkAtX.TabIndex = 46;
      this.txtlkAtX.Text = "160855.585";
      // 
      // txtlkAtY
      // 
      this.txtlkAtY.Location = new System.Drawing.Point(215, 40);
      this.txtlkAtY.Name = "txtlkAtY";
      this.txtlkAtY.Size = new System.Drawing.Size(65, 20);
      this.txtlkAtY.TabIndex = 47;
      this.txtlkAtY.Text = "383928.326";
      // 
      // txtlkAtZ
      // 
      this.txtlkAtZ.Location = new System.Drawing.Point(215, 65);
      this.txtlkAtZ.Name = "txtlkAtZ";
      this.txtlkAtZ.Size = new System.Drawing.Size(65, 20);
      this.txtlkAtZ.TabIndex = 48;
      this.txtlkAtZ.Text = "4.5";
      // 
      // btnFlyTo
      // 
      this.btnFlyTo.Location = new System.Drawing.Point(285, 15);
      this.btnFlyTo.Name = "btnFlyTo";
      this.btnFlyTo.Size = new System.Drawing.Size(40, 25);
      this.btnFlyTo.TabIndex = 45;
      this.btnFlyTo.Text = "Fly to";
      this.btnFlyTo.UseVisualStyleBackColor = true;
      this.btnFlyTo.Click += new System.EventHandler(this.btnFlyTo_Click);
      // 
      // txtX
      // 
      this.txtX.Location = new System.Drawing.Point(145, 15);
      this.txtX.Name = "txtX";
      this.txtX.Size = new System.Drawing.Size(65, 20);
      this.txtX.TabIndex = 30;
      this.txtX.Text = "160850.585";
      // 
      // txtY
      // 
      this.txtY.Location = new System.Drawing.Point(145, 40);
      this.txtY.Name = "txtY";
      this.txtY.Size = new System.Drawing.Size(65, 20);
      this.txtY.TabIndex = 31;
      this.txtY.Text = "383923.326";
      // 
      // txtZ
      // 
      this.txtZ.Location = new System.Drawing.Point(145, 65);
      this.txtZ.Name = "txtZ";
      this.txtZ.Size = new System.Drawing.Size(65, 20);
      this.txtZ.TabIndex = 32;
      this.txtZ.Text = "4.0";
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
      this.btnLookAtCoordinate.Location = new System.Drawing.Point(5, 50);
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
      this.grAPIInfo.Location = new System.Drawing.Point(360, 78);
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
      this.grViewerToggles.Controls.Add(this.btnGetType);
      this.grViewerToggles.Controls.Add(this.btnToggleSidebarExpandable);
      this.grViewerToggles.Controls.Add(this.btnToggleSidebar);
      this.grViewerToggles.Controls.Add(this.btnToggle3DCursor);
      this.grViewerToggles.Controls.Add(this.btnToggleRecordingsVisible);
      this.grViewerToggles.Controls.Add(this.btnToggleTimeTravelExpanded);
      this.grViewerToggles.Controls.Add(this.btnToggleNavbarExpanded);
      this.grViewerToggles.Controls.Add(this.btnToggleTimeTravelVisible);
      this.grViewerToggles.Controls.Add(this.btnToggleNavbarVisible);
      this.grViewerToggles.Location = new System.Drawing.Point(180, 78);
      this.grViewerToggles.Name = "grViewerToggles";
      this.grViewerToggles.Size = new System.Drawing.Size(180, 237);
      this.grViewerToggles.TabIndex = 0;
      this.grViewerToggles.TabStop = false;
      this.grViewerToggles.Text = "Viewer toggles";
      // 
      // btnGetType
      // 
      this.btnGetType.Location = new System.Drawing.Point(5, 215);
      this.btnGetType.Name = "btnGetType";
      this.btnGetType.Size = new System.Drawing.Size(154, 22);
      this.btnGetType.TabIndex = 44;
      this.btnGetType.Text = "Get viewer type";
      this.btnGetType.UseVisualStyleBackColor = true;
      this.btnGetType.Click += new System.EventHandler(this.btnGetType_Click);
      // 
      // btnToggleSidebarExpandable
      // 
      this.btnToggleSidebarExpandable.Location = new System.Drawing.Point(5, 191);
      this.btnToggleSidebarExpandable.Name = "btnToggleSidebarExpandable";
      this.btnToggleSidebarExpandable.Size = new System.Drawing.Size(154, 22);
      this.btnToggleSidebarExpandable.TabIndex = 43;
      this.btnToggleSidebarExpandable.Text = "Toggle Sidebar expandable";
      this.btnToggleSidebarExpandable.UseVisualStyleBackColor = true;
      this.btnToggleSidebarExpandable.Click += new System.EventHandler(this.btnToggleSidebarExpandable_Click);
      // 
      // btnToggleSidebar
      // 
      this.btnToggleSidebar.Location = new System.Drawing.Point(5, 165);
      this.btnToggleSidebar.Name = "btnToggleSidebar";
      this.btnToggleSidebar.Size = new System.Drawing.Size(154, 22);
      this.btnToggleSidebar.TabIndex = 42;
      this.btnToggleSidebar.Text = "Toggle Sidebar expanded";
      this.btnToggleSidebar.UseVisualStyleBackColor = true;
      this.btnToggleSidebar.Click += new System.EventHandler(this.btnToggleSidebar_Click);
      // 
      // btnToggle3DCursor
      // 
      this.btnToggle3DCursor.Location = new System.Drawing.Point(5, 140);
      this.btnToggle3DCursor.Name = "btnToggle3DCursor";
      this.btnToggle3DCursor.Size = new System.Drawing.Size(154, 22);
      this.btnToggle3DCursor.TabIndex = 41;
      this.btnToggle3DCursor.Text = "Toggle 3D Cursor";
      this.btnToggle3DCursor.UseVisualStyleBackColor = true;
      this.btnToggle3DCursor.Click += new System.EventHandler(this.btnToggle3DCursor_Click);
      // 
      // btnToggleRecordingsVisible
      // 
      this.btnToggleRecordingsVisible.Location = new System.Drawing.Point(5, 14);
      this.btnToggleRecordingsVisible.Name = "btnToggleRecordingsVisible";
      this.btnToggleRecordingsVisible.Size = new System.Drawing.Size(154, 22);
      this.btnToggleRecordingsVisible.TabIndex = 36;
      this.btnToggleRecordingsVisible.Text = "Toggle recordings visible";
      this.btnToggleRecordingsVisible.UseVisualStyleBackColor = true;
      this.btnToggleRecordingsVisible.Click += new System.EventHandler(this.btnToggleRecordingsVisible_Click);
      // 
      // btnToggleTimeTravelExpanded
      // 
      this.btnToggleTimeTravelExpanded.Location = new System.Drawing.Point(5, 40);
      this.btnToggleTimeTravelExpanded.Name = "btnToggleTimeTravelExpanded";
      this.btnToggleTimeTravelExpanded.Size = new System.Drawing.Size(154, 22);
      this.btnToggleTimeTravelExpanded.TabIndex = 40;
      this.btnToggleTimeTravelExpanded.Text = "Toggle time travel expanded";
      this.btnToggleTimeTravelExpanded.UseVisualStyleBackColor = true;
      this.btnToggleTimeTravelExpanded.Click += new System.EventHandler(this.btnToggleTimeTravelExpanded_Click);
      // 
      // btnToggleNavbarExpanded
      // 
      this.btnToggleNavbarExpanded.Location = new System.Drawing.Point(5, 65);
      this.btnToggleNavbarExpanded.Name = "btnToggleNavbarExpanded";
      this.btnToggleNavbarExpanded.Size = new System.Drawing.Size(154, 22);
      this.btnToggleNavbarExpanded.TabIndex = 38;
      this.btnToggleNavbarExpanded.Text = "Toggle navbar expanded";
      this.btnToggleNavbarExpanded.UseVisualStyleBackColor = true;
      this.btnToggleNavbarExpanded.Click += new System.EventHandler(this.btnToggleNavbarExpanded_Click);
      // 
      // btnToggleTimeTravelVisible
      // 
      this.btnToggleTimeTravelVisible.Location = new System.Drawing.Point(5, 90);
      this.btnToggleTimeTravelVisible.Name = "btnToggleTimeTravelVisible";
      this.btnToggleTimeTravelVisible.Size = new System.Drawing.Size(154, 22);
      this.btnToggleTimeTravelVisible.TabIndex = 39;
      this.btnToggleTimeTravelVisible.Text = "Toggle time travel visible";
      this.btnToggleTimeTravelVisible.UseVisualStyleBackColor = true;
      this.btnToggleTimeTravelVisible.Click += new System.EventHandler(this.btnToggleTimeTravelVisible_Click);
      // 
      // btnToggleNavbarVisible
      // 
      this.btnToggleNavbarVisible.Location = new System.Drawing.Point(5, 115);
      this.btnToggleNavbarVisible.Name = "btnToggleNavbarVisible";
      this.btnToggleNavbarVisible.Size = new System.Drawing.Size(154, 22);
      this.btnToggleNavbarVisible.TabIndex = 37;
      this.btnToggleNavbarVisible.Text = "Toggle Navbar Visible";
      this.btnToggleNavbarVisible.UseVisualStyleBackColor = true;
      this.btnToggleNavbarVisible.Click += new System.EventHandler(this.btnToggleNavbarVisible_Click);
      // 
      // grOpenByAddress
      // 
      this.grOpenByAddress.Controls.Add(this.lblAddress);
      this.grOpenByAddress.Controls.Add(this.txtAdress);
      this.grOpenByAddress.Controls.Add(this.btnOpenByAddress);
      this.grOpenByAddress.Location = new System.Drawing.Point(180, 0);
      this.grOpenByAddress.Name = "grOpenByAddress";
      this.grOpenByAddress.Size = new System.Drawing.Size(300, 75);
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
      this.txtAdress.Text = "Lange Haven 145, Schiedam";
      // 
      // btnOpenByAddress
      // 
      this.btnOpenByAddress.Location = new System.Drawing.Point(5, 40);
      this.btnOpenByAddress.Name = "btnOpenByAddress";
      this.btnOpenByAddress.Size = new System.Drawing.Size(290, 30);
      this.btnOpenByAddress.TabIndex = 16;
      this.btnOpenByAddress.Text = "Open by address";
      this.btnOpenByAddress.UseVisualStyleBackColor = true;
      this.btnOpenByAddress.Click += new System.EventHandler(this.btnOpenByAddress_Click);
      // 
      // grLogin
      // 
      this.grLogin.Controls.Add(this.lblSRS);
      this.grLogin.Controls.Add(this.txtSrs);
      this.grLogin.Controls.Add(this.btnSave);
      this.grLogin.Controls.Add(this.btnLogout);
      this.grLogin.Controls.Add(this.lblAPIKey);
      this.grLogin.Controls.Add(this.txtAPIKey);
      this.grLogin.Controls.Add(this.lblUsername);
      this.grLogin.Controls.Add(this.lblPassword);
      this.grLogin.Controls.Add(this.txtUsername);
      this.grLogin.Controls.Add(this.txtPassword);
      this.grLogin.Controls.Add(this.btnLogin);
      this.grLogin.Location = new System.Drawing.Point(0, 0);
      this.grLogin.Name = "grLogin";
      this.grLogin.Size = new System.Drawing.Size(180, 152);
      this.grLogin.TabIndex = 49;
      this.grLogin.TabStop = false;
      this.grLogin.Text = "Login";
      // 
      // lblSRS
      // 
      this.lblSRS.AutoSize = true;
      this.lblSRS.Location = new System.Drawing.Point(5, 90);
      this.lblSRS.Name = "lblSRS";
      this.lblSRS.Size = new System.Drawing.Size(29, 13);
      this.lblSRS.TabIndex = 47;
      this.lblSRS.Text = "SRS";
      // 
      // txtSrs
      // 
      this.txtSrs.Location = new System.Drawing.Point(65, 90);
      this.txtSrs.Name = "txtSrs";
      this.txtSrs.Size = new System.Drawing.Size(110, 20);
      this.txtSrs.TabIndex = 48;
      this.txtSrs.Text = "EPSG:28992";
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(125, 114);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(50, 30);
      this.btnSave.TabIndex = 9;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnLogout
      // 
      this.btnLogout.Location = new System.Drawing.Point(65, 114);
      this.btnLogout.Name = "btnLogout";
      this.btnLogout.Size = new System.Drawing.Size(50, 30);
      this.btnLogout.TabIndex = 8;
      this.btnLogout.Text = "Logout";
      this.btnLogout.UseVisualStyleBackColor = true;
      this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
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
      this.txtAPIKey.TextChanged += new System.EventHandler(this.txtAPIKey_TextChanged);
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
      this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(65, 40);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(110, 20);
      this.txtPassword.TabIndex = 4;
      this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
      // 
      // btnLogin
      // 
      this.btnLogin.Location = new System.Drawing.Point(5, 114);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(50, 30);
      this.btnLogin.TabIndex = 5;
      this.btnLogin.Text = "Login";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.EnabledChanged += new System.EventHandler(this.btnLogin_EnabledChanged);
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // btnPointCloudLookAt
      // 
      this.btnPointCloudLookAt.Location = new System.Drawing.Point(136, 58);
      this.btnPointCloudLookAt.Name = "btnPointCloudLookAt";
      this.btnPointCloudLookAt.Size = new System.Drawing.Size(55, 25);
      this.btnPointCloudLookAt.TabIndex = 77;
      this.btnPointCloudLookAt.Text = "Look At";
      this.btnPointCloudLookAt.UseVisualStyleBackColor = true;
      this.btnPointCloudLookAt.Click += new System.EventHandler(this.btnPointCloudLookAt_Click);
      // 
      // btnDown
      // 
      this.btnDown.Location = new System.Drawing.Point(5, 87);
      this.btnDown.Name = "btnDown";
      this.btnDown.Size = new System.Drawing.Size(40, 25);
      this.btnDown.TabIndex = 78;
      this.btnDown.Text = "Down";
      this.btnDown.UseVisualStyleBackColor = true;
      this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
      // 
      // btnLeft
      // 
      this.btnLeft.Location = new System.Drawing.Point(50, 86);
      this.btnLeft.Name = "btnLeft";
      this.btnLeft.Size = new System.Drawing.Size(40, 25);
      this.btnLeft.TabIndex = 79;
      this.btnLeft.Text = "Left";
      this.btnLeft.UseVisualStyleBackColor = true;
      this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
      // 
      // btnRight
      // 
      this.btnRight.Location = new System.Drawing.Point(95, 86);
      this.btnRight.Name = "btnRight";
      this.btnRight.Size = new System.Drawing.Size(40, 25);
      this.btnRight.TabIndex = 80;
      this.btnRight.Text = "Right";
      this.btnRight.UseVisualStyleBackColor = true;
      this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
      // 
      // btnUp
      // 
      this.btnUp.Location = new System.Drawing.Point(136, 86);
      this.btnUp.Name = "btnUp";
      this.btnUp.Size = new System.Drawing.Size(40, 25);
      this.btnUp.TabIndex = 81;
      this.btnUp.Text = "Up";
      this.btnUp.UseVisualStyleBackColor = true;
      this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
      // 
      // Demo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1549, 701);
      this.Controls.Add(this.plControl);
      this.Controls.Add(this.plStreetSmart);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Demo";
      this.Text = "Demo StreetSmart";
      this.grOpenByQuery.ResumeLayout(false);
      this.grOpenByQuery.PerformLayout();
      this.plControl.ResumeLayout(false);
      this.grCloseViewers.ResumeLayout(false);
      this.grPanoramaList.ResumeLayout(false);
      this.grColorOverlay.ResumeLayout(false);
      this.grColorOverlay.PerformLayout();
      this.grSelectFeature.ResumeLayout(false);
      this.grSelectFeature.PerformLayout();
      this.grSld.ResumeLayout(false);
      this.grSld.PerformLayout();
      this.grButtonVisibility.ResumeLayout(false);
      this.grOverlay.ResumeLayout(false);
      this.grOverlay.PerformLayout();
      this.grMeasurement.ResumeLayout(false);
      this.grMeasurement.PerformLayout();
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
    private System.Windows.Forms.Button btnApiReadyState;
    private System.Windows.Forms.Button btnGetPermissions;
    private System.Windows.Forms.Button btnApplicationName;
    private System.Windows.Forms.Button btnApplicationVersion;
    private System.Windows.Forms.TextBox txtAdress;
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
    private System.Windows.Forms.Button btnOpenByCoordinate;
    private System.Windows.Forms.Button btnZoomOut;
    private System.Windows.Forms.Button btnZoomIn;
    private System.Windows.Forms.GroupBox grLogin;
    private System.Windows.Forms.GroupBox grViewerToggles;
    private System.Windows.Forms.GroupBox grOpenByAddress;
    private System.Windows.Forms.GroupBox grRotationsZoomInOut;
    private System.Windows.Forms.Label lblDeltaYawPitch;
    private System.Windows.Forms.TextBox txtDeltaYawPitch;
    private System.Windows.Forms.GroupBox grOpenByQuery;
    private System.Windows.Forms.GroupBox grAPIInfo;
    private System.Windows.Forms.Label lblResult;
    private System.Windows.Forms.TextBox txtAPIResult;
    private System.Windows.Forms.GroupBox grCoordinate;
    private System.Windows.Forms.GroupBox grOpenByImageId;
    private System.Windows.Forms.GroupBox grOrientation;
    private System.Windows.Forms.GroupBox grRecordingViewerColorPermissions;
    private System.Windows.Forms.TextBox txtRecordingViewerColorPermissions;
    private System.Windows.Forms.Button btnGetAddress;
    private System.Windows.Forms.GroupBox grEvents;
    private System.Windows.Forms.ListBox lbViewerEvents;
    private System.Windows.Forms.Label lblAPIKey;
    private System.Windows.Forms.TextBox txtAPIKey;
    private System.Windows.Forms.GroupBox grDevTools;
    private System.Windows.Forms.Button btnShowDefTools;
    private System.Windows.Forms.Button btnCloseDefTools;
    private System.Windows.Forms.TextBox txtOpenByQuery;
    private System.Windows.Forms.CheckBox cbPanorama;
    private System.Windows.Forms.CheckBox cbOblique;
    private System.Windows.Forms.Button btnOpenViewerByQuery;
    private System.Windows.Forms.GroupBox grMeasurement;
    private System.Windows.Forms.RadioButton rbMeasPoint;
    private System.Windows.Forms.RadioButton rbMeasDefault;
    private System.Windows.Forms.Button btnStartMeasurementMode;
    private System.Windows.Forms.Button btnStopMeasurementMode;
    private System.Windows.Forms.RadioButton rbMeasPolygon;
    private System.Windows.Forms.RadioButton rbMeasLineString;
    private System.Windows.Forms.Button btnGetActiveMeasurement;
    private System.Windows.Forms.GroupBox grOverlay;
    private System.Windows.Forms.TextBox txtOverlayGeoJson;
    private System.Windows.Forms.Button btnAddOverlay;
    private System.Windows.Forms.Button btnLogout;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.GroupBox grButtonVisibility;
    private System.Windows.Forms.Button btnGetButtonEnabled;
    private System.Windows.Forms.Button btnSetButtonVisibility;
    private System.Windows.Forms.ComboBox cbViewerButton;
    private System.Windows.Forms.Button btnGetDebugLogs;
    private System.Windows.Forms.Button btnRemoveOverlay;
    private System.Windows.Forms.GroupBox grSld;
    private System.Windows.Forms.TextBox txtSld;
    private System.Windows.Forms.CheckBox ckReplace;
    private System.Windows.Forms.Label lblSRS;
    private System.Windows.Forms.TextBox txtSrs;
        private System.Windows.Forms.Button btnGetViewers;
        private System.Windows.Forms.Button btnClosePanoramaViewer;
        private System.Windows.Forms.TextBox txtBrightnessContrast;
        private System.Windows.Forms.Button btnContrast;
        private System.Windows.Forms.Button btnBrightness;
    private System.Windows.Forms.Button btnToggle3DCursor;
    private System.Windows.Forms.Button btnDrawDistance;
    private System.Windows.Forms.TextBox txtDrawDistance;
    private System.Windows.Forms.GroupBox grSelectFeature;
    private System.Windows.Forms.TextBox txtValue;
    private System.Windows.Forms.Label lblValue;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblPropertyName;
    private System.Windows.Forms.Button btnSelectFeature;
    private System.Windows.Forms.CheckBox ckShowAttributePanelOnFeatureClick;
    private System.Windows.Forms.Button btnToggleAddressOverlays;
    private System.Windows.Forms.ColorDialog colorOverlay;
    private System.Windows.Forms.Button btnColorOverlay;
    private System.Windows.Forms.GroupBox grColorOverlay;
    private System.Windows.Forms.TextBox txtOverlayColor;
    private System.Windows.Forms.RadioButton rbColor;
    private System.Windows.Forms.RadioButton rbSLD;
    private System.Windows.Forms.Button btnDemoWFSLayer;
    private System.Windows.Forms.GroupBox grPanoramaList;
    private System.Windows.Forms.ListBox lbPanoramaList;
        private System.Windows.Forms.Button btnToggleSidebar;
        private System.Windows.Forms.Button btnToggleSidebarExpandable;
        private System.Windows.Forms.CheckBox cbPointCloud;
    private System.Windows.Forms.Button btnClosePointViewer;
    private System.Windows.Forms.Button btnCloseObliqueViewer;
    private System.Windows.Forms.GroupBox grCloseViewers;
    private System.Windows.Forms.Button btnGetType;
    private System.Windows.Forms.Button btnFlyTo;
    private System.Windows.Forms.TextBox txtlkAtX;
    private System.Windows.Forms.TextBox txtlkAtY;
    private System.Windows.Forms.TextBox txtlkAtZ;
    private System.Windows.Forms.Button btnCameraPosition;
    private System.Windows.Forms.Button btnEdges;
    private System.Windows.Forms.Button btnGetPointBudget;
    private System.Windows.Forms.ComboBox cbPointBudget;
    private System.Windows.Forms.Button btnSetPointBudget;
    private System.Windows.Forms.TextBox txtPointSize;
    private System.Windows.Forms.Button btnGetPointSize;
    private System.Windows.Forms.Button btnSetPointSize;
    private System.Windows.Forms.Button btnSetPointStyle;
    private System.Windows.Forms.ComboBox cbPointStyle;
    private System.Windows.Forms.Button btnGetPointStyle;
    private System.Windows.Forms.Button btnPointCloudLookAt;
    private System.Windows.Forms.Button btnUp;
    private System.Windows.Forms.Button btnRight;
    private System.Windows.Forms.Button btnLeft;
    private System.Windows.Forms.Button btnDown;
  }
}

