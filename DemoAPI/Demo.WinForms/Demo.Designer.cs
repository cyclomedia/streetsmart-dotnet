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
            plStreetSmart = new System.Windows.Forms.Panel();
            grOpenByQuery = new System.Windows.Forms.GroupBox();
            cbPointCloud = new System.Windows.Forms.CheckBox();
            ckReplace = new System.Windows.Forms.CheckBox();
            txtOpenByQuery = new System.Windows.Forms.TextBox();
            cbPanorama = new System.Windows.Forms.CheckBox();
            cbOblique = new System.Windows.Forms.CheckBox();
            btnOpenViewerByQuery = new System.Windows.Forms.Button();
            plControl = new System.Windows.Forms.Panel();
            grShortCuts = new System.Windows.Forms.GroupBox();
            txtShortcutResult = new System.Windows.Forms.TextBox();
            cbShortCuts = new System.Windows.Forms.ComboBox();
            btnDisableShortCut = new System.Windows.Forms.Button();
            btnEnableShortCut = new System.Windows.Forms.Button();
            grCloseViewers = new System.Windows.Forms.GroupBox();
            btnUp = new System.Windows.Forms.Button();
            btnRight = new System.Windows.Forms.Button();
            btnLeft = new System.Windows.Forms.Button();
            btnDown = new System.Windows.Forms.Button();
            btnPointCloudLookAt = new System.Windows.Forms.Button();
            btnSetPointStyle = new System.Windows.Forms.Button();
            cbPointStyle = new System.Windows.Forms.ComboBox();
            btnGetPointStyle = new System.Windows.Forms.Button();
            btnCloseObliqueViewer = new System.Windows.Forms.Button();
            btnClosePointViewer = new System.Windows.Forms.Button();
            grPanoramaList = new System.Windows.Forms.GroupBox();
            lbPanoramaList = new System.Windows.Forms.ListBox();
            grColorOverlay = new System.Windows.Forms.GroupBox();
            btnDemoWFSLayer = new System.Windows.Forms.Button();
            txtOverlayColor = new System.Windows.Forms.TextBox();
            btnToggleAddressOverlays = new System.Windows.Forms.Button();
            btnColorOverlay = new System.Windows.Forms.Button();
            rbColor = new System.Windows.Forms.RadioButton();
            rbSLD = new System.Windows.Forms.RadioButton();
            grSelectFeature = new System.Windows.Forms.GroupBox();
            ckShowAttributePanelOnFeatureClick = new System.Windows.Forms.CheckBox();
            txtValue = new System.Windows.Forms.TextBox();
            lblValue = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblPropertyName = new System.Windows.Forms.Label();
            btnSelectFeature = new System.Windows.Forms.Button();
            grSld = new System.Windows.Forms.GroupBox();
            txtSld = new System.Windows.Forms.TextBox();
            grButtonVisibility = new System.Windows.Forms.GroupBox();
            cbViewerButton = new System.Windows.Forms.ComboBox();
            btnSetButtonVisibility = new System.Windows.Forms.Button();
            btnGetButtonEnabled = new System.Windows.Forms.Button();
            grOverlay = new System.Windows.Forms.GroupBox();
            btnDrawDistance = new System.Windows.Forms.Button();
            txtDrawDistance = new System.Windows.Forms.TextBox();
            btnRemoveOverlay = new System.Windows.Forms.Button();
            txtOverlayGeoJson = new System.Windows.Forms.TextBox();
            btnAddOverlay = new System.Windows.Forms.Button();
            grMeasurement = new System.Windows.Forms.GroupBox();
            cbUnit = new System.Windows.Forms.ComboBox();
            btnGetUnitPreference = new System.Windows.Forms.Button();
            btnSetUnitPreference = new System.Windows.Forms.Button();
            grMeasurementMethod = new System.Windows.Forms.GroupBox();
            rbMethodDefault = new System.Windows.Forms.RadioButton();
            rbMethodDepthMap = new System.Windows.Forms.RadioButton();
            rbMethodForwardIntersection = new System.Windows.Forms.RadioButton();
            rbMethodSmartClick = new System.Windows.Forms.RadioButton();
            grMeasurementType = new System.Windows.Forms.GroupBox();
            rbMeasDefault = new System.Windows.Forms.RadioButton();
            rbMeasPoint = new System.Windows.Forms.RadioButton();
            rbMeasPolygon = new System.Windows.Forms.RadioButton();
            rbMeasLineString = new System.Windows.Forms.RadioButton();
            btnGetActiveMeasurement = new System.Windows.Forms.Button();
            btnStartMeasurementMode = new System.Windows.Forms.Button();
            btnStopMeasurementMode = new System.Windows.Forms.Button();
            grDevTools = new System.Windows.Forms.GroupBox();
            btnCloseDefTools = new System.Windows.Forms.Button();
            btnShowDefTools = new System.Windows.Forms.Button();
            grRotationsZoomInOut = new System.Windows.Forms.GroupBox();
            btnGetViewers = new System.Windows.Forms.Button();
            btnClosePanoramaViewer = new System.Windows.Forms.Button();
            lblDeltaYawPitch = new System.Windows.Forms.Label();
            txtDeltaYawPitch = new System.Windows.Forms.TextBox();
            btnRotateDown = new System.Windows.Forms.Button();
            btnRotateUp = new System.Windows.Forms.Button();
            btnRotateRight = new System.Windows.Forms.Button();
            btnZoomOut = new System.Windows.Forms.Button();
            btRotateLeft = new System.Windows.Forms.Button();
            btnZoomIn = new System.Windows.Forms.Button();
            grEvents = new System.Windows.Forms.GroupBox();
            lbViewerEvents = new System.Windows.Forms.ListBox();
            grRecordingViewerColorPermissions = new System.Windows.Forms.GroupBox();
            txtRecordingViewerColorPermissions = new System.Windows.Forms.TextBox();
            btnGetPermissions = new System.Windows.Forms.Button();
            btnGetRecording = new System.Windows.Forms.Button();
            btnGetViewerColor = new System.Windows.Forms.Button();
            grOrientation = new System.Windows.Forms.GroupBox();
            btnGetDebugLogs = new System.Windows.Forms.Button();
            txtYaw = new System.Windows.Forms.TextBox();
            lblYaw = new System.Windows.Forms.Label();
            lblPitch = new System.Windows.Forms.Label();
            txtPitch = new System.Windows.Forms.TextBox();
            lblhFov = new System.Windows.Forms.Label();
            txthFov = new System.Windows.Forms.TextBox();
            btnGetOrientation = new System.Windows.Forms.Button();
            btnSetOrientation = new System.Windows.Forms.Button();
            grOpenByImageId = new System.Windows.Forms.GroupBox();
            txtBrightnessContrast = new System.Windows.Forms.TextBox();
            btnContrast = new System.Windows.Forms.Button();
            btnBrightness = new System.Windows.Forms.Button();
            btnGetAddress = new System.Windows.Forms.Button();
            btnOpenByImageId = new System.Windows.Forms.Button();
            txtImageId = new System.Windows.Forms.TextBox();
            grCoordinate = new System.Windows.Forms.GroupBox();
            btnSetPointSize = new System.Windows.Forms.Button();
            txtPointSize = new System.Windows.Forms.TextBox();
            btnGetPointSize = new System.Windows.Forms.Button();
            btnSetPointBudget = new System.Windows.Forms.Button();
            cbPointBudget = new System.Windows.Forms.ComboBox();
            btnGetPointBudget = new System.Windows.Forms.Button();
            btnEdges = new System.Windows.Forms.Button();
            btnCameraPosition = new System.Windows.Forms.Button();
            txtlkAtX = new System.Windows.Forms.TextBox();
            txtlkAtY = new System.Windows.Forms.TextBox();
            txtlkAtZ = new System.Windows.Forms.TextBox();
            btnFlyTo = new System.Windows.Forms.Button();
            txtX = new System.Windows.Forms.TextBox();
            txtY = new System.Windows.Forms.TextBox();
            txtZ = new System.Windows.Forms.TextBox();
            lblX = new System.Windows.Forms.Label();
            lblY = new System.Windows.Forms.Label();
            lblZ = new System.Windows.Forms.Label();
            btnOpenByCoordinate = new System.Windows.Forms.Button();
            btnLookAtCoordinate = new System.Windows.Forms.Button();
            grAPIInfo = new System.Windows.Forms.GroupBox();
            lblResult = new System.Windows.Forms.Label();
            txtAPIResult = new System.Windows.Forms.TextBox();
            btnApiReadyState = new System.Windows.Forms.Button();
            btnApplicationVersion = new System.Windows.Forms.Button();
            btnApplicationName = new System.Windows.Forms.Button();
            grViewerToggles = new System.Windows.Forms.GroupBox();
            btnGetType = new System.Windows.Forms.Button();
            btnToggleSidebarExpandable = new System.Windows.Forms.Button();
            btnToggleSidebar = new System.Windows.Forms.Button();
            btnToggle3DCursor = new System.Windows.Forms.Button();
            btnToggleRecordingsVisible = new System.Windows.Forms.Button();
            btnToggleTimeTravelExpanded = new System.Windows.Forms.Button();
            btnToggleNavbarExpanded = new System.Windows.Forms.Button();
            btnToggleTimeTravelVisible = new System.Windows.Forms.Button();
            btnToggleNavbarVisible = new System.Windows.Forms.Button();
            grOpenByAddress = new System.Windows.Forms.GroupBox();
            lblAddress = new System.Windows.Forms.Label();
            txtAdress = new System.Windows.Forms.TextBox();
            btnOpenByAddress = new System.Windows.Forms.Button();
            grLogin = new System.Windows.Forms.GroupBox();
            lblClientId = new System.Windows.Forms.Label();
            txtClientId = new System.Windows.Forms.TextBox();
            lblSRS = new System.Windows.Forms.Label();
            txtSrs = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnLogout = new System.Windows.Forms.Button();
            lblAPIKey = new System.Windows.Forms.Label();
            txtAPIKey = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            lblPassword = new System.Windows.Forms.Label();
            txtUsername = new System.Windows.Forms.TextBox();
            txtPassword = new System.Windows.Forms.TextBox();
            btnLogin = new System.Windows.Forms.Button();
            colorOverlay = new System.Windows.Forms.ColorDialog();
            grOpenByQuery.SuspendLayout();
            plControl.SuspendLayout();
            grShortCuts.SuspendLayout();
            grCloseViewers.SuspendLayout();
            grPanoramaList.SuspendLayout();
            grColorOverlay.SuspendLayout();
            grSelectFeature.SuspendLayout();
            grSld.SuspendLayout();
            grButtonVisibility.SuspendLayout();
            grOverlay.SuspendLayout();
            grMeasurement.SuspendLayout();
            grMeasurementMethod.SuspendLayout();
            grMeasurementType.SuspendLayout();
            grDevTools.SuspendLayout();
            grRotationsZoomInOut.SuspendLayout();
            grEvents.SuspendLayout();
            grRecordingViewerColorPermissions.SuspendLayout();
            grOrientation.SuspendLayout();
            grOpenByImageId.SuspendLayout();
            grCoordinate.SuspendLayout();
            grAPIInfo.SuspendLayout();
            grViewerToggles.SuspendLayout();
            grOpenByAddress.SuspendLayout();
            grLogin.SuspendLayout();
            SuspendLayout();
            // 
            // plStreetSmart
            // 
            plStreetSmart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            plStreetSmart.BackColor = System.Drawing.Color.Transparent;
            plStreetSmart.Location = new System.Drawing.Point(0, 0);
            plStreetSmart.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            plStreetSmart.Name = "plStreetSmart";
            plStreetSmart.Size = new System.Drawing.Size(1219, 1295);
            plStreetSmart.TabIndex = 0;
            // 
            // grOpenByQuery
            // 
            grOpenByQuery.Controls.Add(cbPointCloud);
            grOpenByQuery.Controls.Add(ckReplace);
            grOpenByQuery.Controls.Add(txtOpenByQuery);
            grOpenByQuery.Controls.Add(cbPanorama);
            grOpenByQuery.Controls.Add(cbOblique);
            grOpenByQuery.Controls.Add(btnOpenViewerByQuery);
            grOpenByQuery.Location = new System.Drawing.Point(1200, 4);
            grOpenByQuery.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOpenByQuery.Name = "grOpenByQuery";
            grOpenByQuery.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOpenByQuery.Size = new System.Drawing.Size(549, 342);
            grOpenByQuery.TabIndex = 0;
            grOpenByQuery.TabStop = false;
            grOpenByQuery.Text = "Open / Close Viewer";
            // 
            // cbPointCloud
            // 
            cbPointCloud.AutoSize = true;
            cbPointCloud.Location = new System.Drawing.Point(366, 276);
            cbPointCloud.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            cbPointCloud.Name = "cbPointCloud";
            cbPointCloud.Size = new System.Drawing.Size(188, 41);
            cbPointCloud.TabIndex = 69;
            cbPointCloud.Text = "Point Cloud";
            cbPointCloud.UseVisualStyleBackColor = true;
            // 
            // ckReplace
            // 
            ckReplace.AutoSize = true;
            ckReplace.Checked = true;
            ckReplace.CheckState = System.Windows.Forms.CheckState.Checked;
            ckReplace.Location = new System.Drawing.Point(313, 41);
            ckReplace.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            ckReplace.Name = "ckReplace";
            ckReplace.Size = new System.Drawing.Size(141, 41);
            ckReplace.TabIndex = 68;
            ckReplace.Text = "Replace";
            ckReplace.UseVisualStyleBackColor = true;
            // 
            // txtOpenByQuery
            // 
            txtOpenByQuery.Location = new System.Drawing.Point(38, 144);
            txtOpenByQuery.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtOpenByQuery.Multiline = true;
            txtOpenByQuery.Name = "txtOpenByQuery";
            txtOpenByQuery.Size = new System.Drawing.Size(493, 106);
            txtOpenByQuery.TabIndex = 67;
            txtOpenByQuery.Text = "Lange Haven 145, Schiedam";
            // 
            // cbPanorama
            // 
            cbPanorama.AutoSize = true;
            cbPanorama.Checked = true;
            cbPanorama.CheckState = System.Windows.Forms.CheckState.Checked;
            cbPanorama.Location = new System.Drawing.Point(182, 270);
            cbPanorama.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            cbPanorama.Name = "cbPanorama";
            cbPanorama.Size = new System.Drawing.Size(168, 41);
            cbPanorama.TabIndex = 66;
            cbPanorama.Text = "Panorama";
            cbPanorama.UseVisualStyleBackColor = true;
            // 
            // cbOblique
            // 
            cbOblique.AutoSize = true;
            cbOblique.Location = new System.Drawing.Point(38, 270);
            cbOblique.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            cbOblique.Name = "cbOblique";
            cbOblique.Size = new System.Drawing.Size(144, 41);
            cbOblique.TabIndex = 65;
            cbOblique.Text = "Oblique";
            cbOblique.UseVisualStyleBackColor = true;
            // 
            // btnOpenViewerByQuery
            // 
            btnOpenViewerByQuery.Location = new System.Drawing.Point(38, 41);
            btnOpenViewerByQuery.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnOpenViewerByQuery.Name = "btnOpenViewerByQuery";
            btnOpenViewerByQuery.Size = new System.Drawing.Size(249, 85);
            btnOpenViewerByQuery.TabIndex = 64;
            btnOpenViewerByQuery.Text = "Open by query";
            btnOpenViewerByQuery.UseVisualStyleBackColor = true;
            btnOpenViewerByQuery.Click += btnOpenViewerByQuery_Click;
            // 
            // plControl
            // 
            plControl.Controls.Add(grShortCuts);
            plControl.Controls.Add(grCloseViewers);
            plControl.Controls.Add(grPanoramaList);
            plControl.Controls.Add(grColorOverlay);
            plControl.Controls.Add(grSelectFeature);
            plControl.Controls.Add(grSld);
            plControl.Controls.Add(grButtonVisibility);
            plControl.Controls.Add(grOverlay);
            plControl.Controls.Add(grOpenByQuery);
            plControl.Controls.Add(grMeasurement);
            plControl.Controls.Add(grDevTools);
            plControl.Controls.Add(grRotationsZoomInOut);
            plControl.Controls.Add(grEvents);
            plControl.Controls.Add(grRecordingViewerColorPermissions);
            plControl.Controls.Add(grOrientation);
            plControl.Controls.Add(grOpenByImageId);
            plControl.Controls.Add(grCoordinate);
            plControl.Controls.Add(grAPIInfo);
            plControl.Controls.Add(grViewerToggles);
            plControl.Controls.Add(grOpenByAddress);
            plControl.Controls.Add(grLogin);
            plControl.Dock = System.Windows.Forms.DockStyle.Right;
            plControl.Location = new System.Drawing.Point(1352, 0);
            plControl.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            plControl.Name = "plControl";
            plControl.Size = new System.Drawing.Size(2256, 1952);
            plControl.TabIndex = 1;
            // 
            // grShortCuts
            // 
            grShortCuts.Controls.Add(txtShortcutResult);
            grShortCuts.Controls.Add(cbShortCuts);
            grShortCuts.Controls.Add(btnDisableShortCut);
            grShortCuts.Controls.Add(btnEnableShortCut);
            grShortCuts.Location = new System.Drawing.Point(1828, 620);
            grShortCuts.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grShortCuts.Name = "grShortCuts";
            grShortCuts.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grShortCuts.Size = new System.Drawing.Size(399, 185);
            grShortCuts.TabIndex = 75;
            grShortCuts.TabStop = false;
            grShortCuts.Text = "Short cuts";
            // 
            // txtShortcutResult
            // 
            txtShortcutResult.Location = new System.Drawing.Point(276, 115);
            txtShortcutResult.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtShortcutResult.Name = "txtShortcutResult";
            txtShortcutResult.Size = new System.Drawing.Size(94, 43);
            txtShortcutResult.TabIndex = 68;
            // 
            // cbShortCuts
            // 
            cbShortCuts.FormattingEnabled = true;
            cbShortCuts.Location = new System.Drawing.Point(13, 115);
            cbShortCuts.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            cbShortCuts.Name = "cbShortCuts";
            cbShortCuts.Size = new System.Drawing.Size(244, 45);
            cbShortCuts.TabIndex = 67;
            // 
            // btnDisableShortCut
            // 
            btnDisableShortCut.Location = new System.Drawing.Point(163, 41);
            btnDisableShortCut.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnDisableShortCut.Name = "btnDisableShortCut";
            btnDisableShortCut.Size = new System.Drawing.Size(137, 57);
            btnDisableShortCut.TabIndex = 66;
            btnDisableShortCut.Text = "Disable";
            btnDisableShortCut.UseVisualStyleBackColor = true;
            btnDisableShortCut.Click += btnDisableShortCut_Click;
            // 
            // btnEnableShortCut
            // 
            btnEnableShortCut.Location = new System.Drawing.Point(13, 41);
            btnEnableShortCut.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnEnableShortCut.Name = "btnEnableShortCut";
            btnEnableShortCut.Size = new System.Drawing.Size(137, 57);
            btnEnableShortCut.TabIndex = 65;
            btnEnableShortCut.Text = "Enable";
            btnEnableShortCut.UseVisualStyleBackColor = true;
            btnEnableShortCut.Click += btnEnableShortCut_Click;
            // 
            // grCloseViewers
            // 
            grCloseViewers.Controls.Add(btnUp);
            grCloseViewers.Controls.Add(btnRight);
            grCloseViewers.Controls.Add(btnLeft);
            grCloseViewers.Controls.Add(btnDown);
            grCloseViewers.Controls.Add(btnPointCloudLookAt);
            grCloseViewers.Controls.Add(btnSetPointStyle);
            grCloseViewers.Controls.Add(cbPointStyle);
            grCloseViewers.Controls.Add(btnGetPointStyle);
            grCloseViewers.Controls.Add(btnCloseObliqueViewer);
            grCloseViewers.Controls.Add(btnClosePointViewer);
            grCloseViewers.Location = new System.Drawing.Point(1749, 4);
            grCloseViewers.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grCloseViewers.Name = "grCloseViewers";
            grCloseViewers.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grCloseViewers.Size = new System.Drawing.Size(501, 342);
            grCloseViewers.TabIndex = 74;
            grCloseViewers.TabStop = false;
            grCloseViewers.Text = "Close viewers";
            // 
            // btnUp
            // 
            btnUp.Location = new System.Drawing.Point(339, 244);
            btnUp.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnUp.Name = "btnUp";
            btnUp.Size = new System.Drawing.Size(99, 70);
            btnUp.TabIndex = 81;
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnRight
            // 
            btnRight.Location = new System.Drawing.Point(238, 244);
            btnRight.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnRight.Name = "btnRight";
            btnRight.Size = new System.Drawing.Size(99, 70);
            btnRight.TabIndex = 80;
            btnRight.UseVisualStyleBackColor = true;
            btnRight.Click += btnRight_Click;
            // 
            // btnLeft
            // 
            btnLeft.Location = new System.Drawing.Point(126, 244);
            btnLeft.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new System.Drawing.Size(99, 70);
            btnLeft.TabIndex = 79;
            btnLeft.UseVisualStyleBackColor = true;
            btnLeft.Click += btnLeft_Click;
            // 
            // btnDown
            // 
            btnDown.Location = new System.Drawing.Point(13, 248);
            btnDown.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnDown.Name = "btnDown";
            btnDown.Size = new System.Drawing.Size(99, 70);
            btnDown.TabIndex = 78;
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnPointCloudLookAt
            // 
            btnPointCloudLookAt.Location = new System.Drawing.Point(339, 165);
            btnPointCloudLookAt.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnPointCloudLookAt.Name = "btnPointCloudLookAt";
            btnPointCloudLookAt.Size = new System.Drawing.Size(137, 70);
            btnPointCloudLookAt.TabIndex = 77;
            btnPointCloudLookAt.UseVisualStyleBackColor = true;
            btnPointCloudLookAt.Click += btnPointCloudLookAt_Click;
            // 
            // btnSetPointStyle
            // 
            btnSetPointStyle.Location = new System.Drawing.Point(238, 165);
            btnSetPointStyle.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnSetPointStyle.Name = "btnSetPointStyle";
            btnSetPointStyle.Size = new System.Drawing.Size(99, 70);
            btnSetPointStyle.TabIndex = 76;
            btnSetPointStyle.Text = "Set";
            btnSetPointStyle.UseVisualStyleBackColor = true;
            btnSetPointStyle.Click += btnSetPointStyle_Click;
            // 
            // cbPointStyle
            // 
            cbPointStyle.FormattingEnabled = true;
            cbPointStyle.Location = new System.Drawing.Point(126, 174);
            cbPointStyle.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            cbPointStyle.Name = "cbPointStyle";
            cbPointStyle.Size = new System.Drawing.Size(94, 45);
            cbPointStyle.TabIndex = 75;
            // 
            // btnGetPointStyle
            // 
            btnGetPointStyle.Location = new System.Drawing.Point(13, 165);
            btnGetPointStyle.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetPointStyle.Name = "btnGetPointStyle";
            btnGetPointStyle.Size = new System.Drawing.Size(99, 70);
            btnGetPointStyle.TabIndex = 74;
            btnGetPointStyle.Text = "Get";
            btnGetPointStyle.UseVisualStyleBackColor = true;
            btnGetPointStyle.Click += btnGetPointStyle_Click;
            // 
            // btnCloseObliqueViewer
            // 
            btnCloseObliqueViewer.Location = new System.Drawing.Point(13, 41);
            btnCloseObliqueViewer.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnCloseObliqueViewer.Name = "btnCloseObliqueViewer";
            btnCloseObliqueViewer.Size = new System.Drawing.Size(201, 107);
            btnCloseObliqueViewer.TabIndex = 72;
            btnCloseObliqueViewer.Text = "Close obl. viewer";
            btnCloseObliqueViewer.UseVisualStyleBackColor = true;
            btnCloseObliqueViewer.Click += btnCloseObliqueViewer_Click;
            // 
            // btnClosePointViewer
            // 
            btnClosePointViewer.Location = new System.Drawing.Point(225, 41);
            btnClosePointViewer.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnClosePointViewer.Name = "btnClosePointViewer";
            btnClosePointViewer.Size = new System.Drawing.Size(201, 107);
            btnClosePointViewer.TabIndex = 73;
            btnClosePointViewer.Text = "Close point. viewer";
            btnClosePointViewer.UseVisualStyleBackColor = true;
            btnClosePointViewer.Click += btnClosePointViewer_Click;
            // 
            // grPanoramaList
            // 
            grPanoramaList.Controls.Add(lbPanoramaList);
            grPanoramaList.Location = new System.Drawing.Point(1828, 805);
            grPanoramaList.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grPanoramaList.Name = "grPanoramaList";
            grPanoramaList.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grPanoramaList.Size = new System.Drawing.Size(399, 342);
            grPanoramaList.TabIndex = 71;
            grPanoramaList.TabStop = false;
            grPanoramaList.Text = "Viewer list";
            // 
            // lbPanoramaList
            // 
            lbPanoramaList.FormattingEnabled = true;
            lbPanoramaList.ItemHeight = 37;
            lbPanoramaList.Location = new System.Drawing.Point(13, 41);
            lbPanoramaList.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            lbPanoramaList.Name = "lbPanoramaList";
            lbPanoramaList.Size = new System.Drawing.Size(370, 263);
            lbPanoramaList.TabIndex = 70;
            lbPanoramaList.SelectedIndexChanged += lbPanoramaList_SelectedIndexChanged;
            // 
            // grColorOverlay
            // 
            grColorOverlay.Controls.Add(btnDemoWFSLayer);
            grColorOverlay.Controls.Add(txtOverlayColor);
            grColorOverlay.Controls.Add(btnToggleAddressOverlays);
            grColorOverlay.Controls.Add(btnColorOverlay);
            grColorOverlay.Controls.Add(rbColor);
            grColorOverlay.Controls.Add(rbSLD);
            grColorOverlay.Location = new System.Drawing.Point(1828, 1147);
            grColorOverlay.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grColorOverlay.Name = "grColorOverlay";
            grColorOverlay.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grColorOverlay.Size = new System.Drawing.Size(399, 455);
            grColorOverlay.TabIndex = 69;
            grColorOverlay.TabStop = false;
            grColorOverlay.Text = "Overlay";
            // 
            // btnDemoWFSLayer
            // 
            btnDemoWFSLayer.Location = new System.Drawing.Point(13, 329);
            btnDemoWFSLayer.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnDemoWFSLayer.Name = "btnDemoWFSLayer";
            btnDemoWFSLayer.Size = new System.Drawing.Size(351, 85);
            btnDemoWFSLayer.TabIndex = 69;
            btnDemoWFSLayer.Text = "Add demo WFS Layer";
            btnDemoWFSLayer.UseVisualStyleBackColor = true;
            btnDemoWFSLayer.Click += btnDemoWFSLayer_Click;
            // 
            // txtOverlayColor
            // 
            txtOverlayColor.Enabled = false;
            txtOverlayColor.Location = new System.Drawing.Point(13, 115);
            txtOverlayColor.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtOverlayColor.Name = "txtOverlayColor";
            txtOverlayColor.Size = new System.Drawing.Size(343, 43);
            txtOverlayColor.TabIndex = 68;
            // 
            // btnToggleAddressOverlays
            // 
            btnToggleAddressOverlays.Location = new System.Drawing.Point(13, 226);
            btnToggleAddressOverlays.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnToggleAddressOverlays.Name = "btnToggleAddressOverlays";
            btnToggleAddressOverlays.Size = new System.Drawing.Size(351, 85);
            btnToggleAddressOverlays.TabIndex = 57;
            btnToggleAddressOverlays.Text = "Toggle Address overlays";
            btnToggleAddressOverlays.UseVisualStyleBackColor = true;
            btnToggleAddressOverlays.Click += btnToggleAddressOverlays_Click;
            // 
            // btnColorOverlay
            // 
            btnColorOverlay.Location = new System.Drawing.Point(13, 41);
            btnColorOverlay.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnColorOverlay.Name = "btnColorOverlay";
            btnColorOverlay.Size = new System.Drawing.Size(351, 65);
            btnColorOverlay.TabIndex = 58;
            btnColorOverlay.Text = "Color overlay";
            btnColorOverlay.UseVisualStyleBackColor = true;
            btnColorOverlay.Click += btnColorOverlay_Click;
            // 
            // rbColor
            // 
            rbColor.AutoSize = true;
            rbColor.Location = new System.Drawing.Point(126, 170);
            rbColor.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbColor.Name = "rbColor";
            rbColor.Size = new System.Drawing.Size(113, 41);
            rbColor.TabIndex = 59;
            rbColor.Text = "Color";
            rbColor.UseVisualStyleBackColor = true;
            // 
            // rbSLD
            // 
            rbSLD.AutoSize = true;
            rbSLD.Checked = true;
            rbSLD.Location = new System.Drawing.Point(13, 170);
            rbSLD.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbSLD.Name = "rbSLD";
            rbSLD.Size = new System.Drawing.Size(94, 41);
            rbSLD.TabIndex = 58;
            rbSLD.TabStop = true;
            rbSLD.Text = "SLD";
            rbSLD.UseVisualStyleBackColor = true;
            // 
            // grSelectFeature
            // 
            grSelectFeature.Controls.Add(ckShowAttributePanelOnFeatureClick);
            grSelectFeature.Controls.Add(txtValue);
            grSelectFeature.Controls.Add(lblValue);
            grSelectFeature.Controls.Add(txtName);
            grSelectFeature.Controls.Add(lblPropertyName);
            grSelectFeature.Controls.Add(btnSelectFeature);
            grSelectFeature.Location = new System.Drawing.Point(1828, 1602);
            grSelectFeature.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grSelectFeature.Name = "grSelectFeature";
            grSelectFeature.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grSelectFeature.Size = new System.Drawing.Size(399, 370);
            grSelectFeature.TabIndex = 56;
            grSelectFeature.TabStop = false;
            grSelectFeature.Text = "Select Feature";
            // 
            // ckShowAttributePanelOnFeatureClick
            // 
            ckShowAttributePanelOnFeatureClick.AutoSize = true;
            ckShowAttributePanelOnFeatureClick.Checked = true;
            ckShowAttributePanelOnFeatureClick.CheckState = System.Windows.Forms.CheckState.Checked;
            ckShowAttributePanelOnFeatureClick.Location = new System.Drawing.Point(15, 274);
            ckShowAttributePanelOnFeatureClick.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            ckShowAttributePanelOnFeatureClick.Name = "ckShowAttributePanelOnFeatureClick";
            ckShowAttributePanelOnFeatureClick.Size = new System.Drawing.Size(380, 41);
            ckShowAttributePanelOnFeatureClick.TabIndex = 67;
            ckShowAttributePanelOnFeatureClick.Text = "Show att. panel feature click";
            ckShowAttributePanelOnFeatureClick.UseVisualStyleBackColor = true;
            ckShowAttributePanelOnFeatureClick.CheckedChanged += ckShowAttributePanelOnFeatureClick_CheckedChanged;
            // 
            // txtValue
            // 
            txtValue.Location = new System.Drawing.Point(212, 200);
            txtValue.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtValue.Name = "txtValue";
            txtValue.Size = new System.Drawing.Size(169, 43);
            txtValue.TabIndex = 58;
            txtValue.Text = "Polygon-feature-cj7hkzyaj000b3e65n0c1brht";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new System.Drawing.Point(212, 144);
            lblValue.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblValue.Name = "lblValue";
            lblValue.Size = new System.Drawing.Size(188, 37);
            lblValue.TabIndex = 59;
            lblValue.Text = "Property value";
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(13, 200);
            txtName.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(169, 43);
            txtName.TabIndex = 56;
            txtName.Text = "name";
            // 
            // lblPropertyName
            // 
            lblPropertyName.AutoSize = true;
            lblPropertyName.Location = new System.Drawing.Point(13, 144);
            lblPropertyName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblPropertyName.Name = "lblPropertyName";
            lblPropertyName.Size = new System.Drawing.Size(191, 37);
            lblPropertyName.TabIndex = 57;
            lblPropertyName.Text = "Property name";
            // 
            // btnSelectFeature
            // 
            btnSelectFeature.Location = new System.Drawing.Point(13, 41);
            btnSelectFeature.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnSelectFeature.Name = "btnSelectFeature";
            btnSelectFeature.Size = new System.Drawing.Size(375, 85);
            btnSelectFeature.TabIndex = 55;
            btnSelectFeature.Text = "Select feature";
            btnSelectFeature.UseVisualStyleBackColor = true;
            btnSelectFeature.Click += btnSelectFeature_Click;
            // 
            // grSld
            // 
            grSld.Controls.Add(txtSld);
            grSld.Location = new System.Drawing.Point(1402, 1602);
            grSld.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grSld.Name = "grSld";
            grSld.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grSld.Size = new System.Drawing.Size(426, 370);
            grSld.TabIndex = 55;
            grSld.TabStop = false;
            grSld.Text = "Sld";
            // 
            // txtSld
            // 
            txtSld.Location = new System.Drawing.Point(15, 54);
            txtSld.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtSld.Multiline = true;
            txtSld.Name = "txtSld";
            txtSld.Size = new System.Drawing.Size(394, 291);
            txtSld.TabIndex = 1;
            txtSld.Text = resources.GetString("txtSld.Text");
            // 
            // grButtonVisibility
            // 
            grButtonVisibility.Controls.Add(cbViewerButton);
            grButtonVisibility.Controls.Add(btnSetButtonVisibility);
            grButtonVisibility.Controls.Add(btnGetButtonEnabled);
            grButtonVisibility.Location = new System.Drawing.Point(823, 921);
            grButtonVisibility.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grButtonVisibility.Name = "grButtonVisibility";
            grButtonVisibility.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grButtonVisibility.Size = new System.Drawing.Size(377, 342);
            grButtonVisibility.TabIndex = 54;
            grButtonVisibility.TabStop = false;
            grButtonVisibility.Text = "Button visibility";
            // 
            // cbViewerButton
            // 
            cbViewerButton.FormattingEnabled = true;
            cbViewerButton.Location = new System.Drawing.Point(13, 242);
            cbViewerButton.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            cbViewerButton.Name = "cbViewerButton";
            cbViewerButton.Size = new System.Drawing.Size(343, 45);
            cbViewerButton.TabIndex = 51;
            // 
            // btnSetButtonVisibility
            // 
            btnSetButtonVisibility.Location = new System.Drawing.Point(13, 128);
            btnSetButtonVisibility.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnSetButtonVisibility.Name = "btnSetButtonVisibility";
            btnSetButtonVisibility.Size = new System.Drawing.Size(351, 85);
            btnSetButtonVisibility.TabIndex = 50;
            btnSetButtonVisibility.Text = "Toggle button enabled";
            btnSetButtonVisibility.UseVisualStyleBackColor = true;
            btnSetButtonVisibility.Click += btnSetButtonVisibility_Click;
            // 
            // btnGetButtonEnabled
            // 
            btnGetButtonEnabled.Location = new System.Drawing.Point(13, 41);
            btnGetButtonEnabled.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetButtonEnabled.Name = "btnGetButtonEnabled";
            btnGetButtonEnabled.Size = new System.Drawing.Size(352, 85);
            btnGetButtonEnabled.TabIndex = 49;
            btnGetButtonEnabled.Text = "Get button enabled";
            btnGetButtonEnabled.UseVisualStyleBackColor = true;
            btnGetButtonEnabled.Click += btnGetButtonEnabled_Click;
            // 
            // grOverlay
            // 
            grOverlay.Controls.Add(btnDrawDistance);
            grOverlay.Controls.Add(txtDrawDistance);
            grOverlay.Controls.Add(btnRemoveOverlay);
            grOverlay.Controls.Add(txtOverlayGeoJson);
            grOverlay.Controls.Add(btnAddOverlay);
            grOverlay.Location = new System.Drawing.Point(692, 1602);
            grOverlay.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOverlay.Name = "grOverlay";
            grOverlay.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOverlay.Size = new System.Drawing.Size(699, 370);
            grOverlay.TabIndex = 53;
            grOverlay.TabStop = false;
            grOverlay.Text = "Load GeoJSON overlay";
            // 
            // btnDrawDistance
            // 
            btnDrawDistance.Location = new System.Drawing.Point(444, 213);
            btnDrawDistance.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnDrawDistance.Name = "btnDrawDistance";
            btnDrawDistance.Size = new System.Drawing.Size(249, 65);
            btnDrawDistance.TabIndex = 68;
            btnDrawDistance.Text = "Set draw distance";
            btnDrawDistance.UseVisualStyleBackColor = true;
            btnDrawDistance.Click += btnDrawDistance_Click;
            // 
            // txtDrawDistance
            // 
            txtDrawDistance.Location = new System.Drawing.Point(444, 300);
            txtDrawDistance.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtDrawDistance.Name = "txtDrawDistance";
            txtDrawDistance.Size = new System.Drawing.Size(244, 43);
            txtDrawDistance.TabIndex = 67;
            txtDrawDistance.Text = "30";
            // 
            // btnRemoveOverlay
            // 
            btnRemoveOverlay.Location = new System.Drawing.Point(444, 41);
            btnRemoveOverlay.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnRemoveOverlay.Name = "btnRemoveOverlay";
            btnRemoveOverlay.Size = new System.Drawing.Size(249, 65);
            btnRemoveOverlay.TabIndex = 2;
            btnRemoveOverlay.Text = "Remove overlay";
            btnRemoveOverlay.UseVisualStyleBackColor = true;
            btnRemoveOverlay.Click += btnRemoveOverlay_Click;
            // 
            // txtOverlayGeoJson
            // 
            txtOverlayGeoJson.Location = new System.Drawing.Point(15, 54);
            txtOverlayGeoJson.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtOverlayGeoJson.Multiline = true;
            txtOverlayGeoJson.Name = "txtOverlayGeoJson";
            txtOverlayGeoJson.Size = new System.Drawing.Size(415, 291);
            txtOverlayGeoJson.TabIndex = 1;
            txtOverlayGeoJson.Text = resources.GetString("txtOverlayGeoJson.Text");
            // 
            // btnAddOverlay
            // 
            btnAddOverlay.Location = new System.Drawing.Point(444, 128);
            btnAddOverlay.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnAddOverlay.Name = "btnAddOverlay";
            btnAddOverlay.Size = new System.Drawing.Size(249, 65);
            btnAddOverlay.TabIndex = 0;
            btnAddOverlay.Text = "Add overlay";
            btnAddOverlay.UseVisualStyleBackColor = true;
            btnAddOverlay.Click += btnAddOverlay_Click;
            // 
            // grMeasurement
            // 
            grMeasurement.Controls.Add(cbUnit);
            grMeasurement.Controls.Add(btnGetUnitPreference);
            grMeasurement.Controls.Add(btnSetUnitPreference);
            grMeasurement.Controls.Add(grMeasurementMethod);
            grMeasurement.Controls.Add(grMeasurementType);
            grMeasurement.Controls.Add(btnGetActiveMeasurement);
            grMeasurement.Controls.Add(btnStartMeasurementMode);
            grMeasurement.Controls.Add(btnStopMeasurementMode);
            grMeasurement.Location = new System.Drawing.Point(17, 1587);
            grMeasurement.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grMeasurement.Name = "grMeasurement";
            grMeasurement.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grMeasurement.Size = new System.Drawing.Size(660, 385);
            grMeasurement.TabIndex = 52;
            grMeasurement.TabStop = false;
            grMeasurement.Text = "Measurement";
            // 
            // cbUnit
            // 
            cbUnit.FormattingEnabled = true;
            cbUnit.Location = new System.Drawing.Point(287, 313);
            cbUnit.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            cbUnit.Name = "cbUnit";
            cbUnit.Size = new System.Drawing.Size(244, 45);
            cbUnit.TabIndex = 67;
            // 
            // btnGetUnitPreference
            // 
            btnGetUnitPreference.Location = new System.Drawing.Point(437, 242);
            btnGetUnitPreference.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetUnitPreference.Name = "btnGetUnitPreference";
            btnGetUnitPreference.Size = new System.Drawing.Size(137, 57);
            btnGetUnitPreference.TabIndex = 66;
            btnGetUnitPreference.Text = "Get Unit";
            btnGetUnitPreference.UseVisualStyleBackColor = true;
            btnGetUnitPreference.Click += btnGetUnitPreference_Click;
            // 
            // btnSetUnitPreference
            // 
            btnSetUnitPreference.Location = new System.Drawing.Point(287, 242);
            btnSetUnitPreference.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnSetUnitPreference.Name = "btnSetUnitPreference";
            btnSetUnitPreference.Size = new System.Drawing.Size(137, 57);
            btnSetUnitPreference.TabIndex = 65;
            btnSetUnitPreference.Text = "Set Unit";
            btnSetUnitPreference.UseVisualStyleBackColor = true;
            btnSetUnitPreference.Click += btnSetUnitPreference_Click;
            // 
            // grMeasurementMethod
            // 
            grMeasurementMethod.Controls.Add(rbMethodDefault);
            grMeasurementMethod.Controls.Add(rbMethodDepthMap);
            grMeasurementMethod.Controls.Add(rbMethodForwardIntersection);
            grMeasurementMethod.Controls.Add(rbMethodSmartClick);
            grMeasurementMethod.Location = new System.Drawing.Point(474, 0);
            grMeasurementMethod.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grMeasurementMethod.Name = "grMeasurementMethod";
            grMeasurementMethod.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grMeasurementMethod.Size = new System.Drawing.Size(201, 226);
            grMeasurementMethod.TabIndex = 64;
            grMeasurementMethod.TabStop = false;
            grMeasurementMethod.Text = "Method";
            // 
            // rbMethodDefault
            // 
            rbMethodDefault.AutoSize = true;
            rbMethodDefault.Checked = true;
            rbMethodDefault.Location = new System.Drawing.Point(13, 41);
            rbMethodDefault.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbMethodDefault.Name = "rbMethodDefault";
            rbMethodDefault.Size = new System.Drawing.Size(134, 41);
            rbMethodDefault.TabIndex = 58;
            rbMethodDefault.TabStop = true;
            rbMethodDefault.Text = "Default";
            rbMethodDefault.UseVisualStyleBackColor = true;
            // 
            // rbMethodDepthMap
            // 
            rbMethodDepthMap.AutoSize = true;
            rbMethodDepthMap.Location = new System.Drawing.Point(13, 85);
            rbMethodDepthMap.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbMethodDepthMap.Name = "rbMethodDepthMap";
            rbMethodDepthMap.Size = new System.Drawing.Size(175, 41);
            rbMethodDepthMap.TabIndex = 59;
            rbMethodDepthMap.Text = "DepthMap";
            rbMethodDepthMap.UseVisualStyleBackColor = true;
            // 
            // rbMethodForwardIntersection
            // 
            rbMethodForwardIntersection.AutoSize = true;
            rbMethodForwardIntersection.Location = new System.Drawing.Point(13, 170);
            rbMethodForwardIntersection.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbMethodForwardIntersection.Name = "rbMethodForwardIntersection";
            rbMethodForwardIntersection.Size = new System.Drawing.Size(156, 41);
            rbMethodForwardIntersection.TabIndex = 61;
            rbMethodForwardIntersection.Text = "Forw. Int.";
            rbMethodForwardIntersection.UseVisualStyleBackColor = true;
            // 
            // rbMethodSmartClick
            // 
            rbMethodSmartClick.AutoSize = true;
            rbMethodSmartClick.Location = new System.Drawing.Point(13, 128);
            rbMethodSmartClick.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbMethodSmartClick.Name = "rbMethodSmartClick";
            rbMethodSmartClick.Size = new System.Drawing.Size(180, 41);
            rbMethodSmartClick.TabIndex = 60;
            rbMethodSmartClick.Text = "Smart Click";
            rbMethodSmartClick.UseVisualStyleBackColor = true;
            // 
            // grMeasurementType
            // 
            grMeasurementType.Controls.Add(rbMeasDefault);
            grMeasurementType.Controls.Add(rbMeasPoint);
            grMeasurementType.Controls.Add(rbMeasPolygon);
            grMeasurementType.Controls.Add(rbMeasLineString);
            grMeasurementType.Location = new System.Drawing.Point(276, 0);
            grMeasurementType.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grMeasurementType.Name = "grMeasurementType";
            grMeasurementType.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grMeasurementType.Size = new System.Drawing.Size(201, 226);
            grMeasurementType.TabIndex = 63;
            grMeasurementType.TabStop = false;
            grMeasurementType.Text = "Type";
            // 
            // rbMeasDefault
            // 
            rbMeasDefault.AutoSize = true;
            rbMeasDefault.Checked = true;
            rbMeasDefault.Location = new System.Drawing.Point(13, 41);
            rbMeasDefault.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbMeasDefault.Name = "rbMeasDefault";
            rbMeasDefault.Size = new System.Drawing.Size(134, 41);
            rbMeasDefault.TabIndex = 58;
            rbMeasDefault.TabStop = true;
            rbMeasDefault.Text = "Default";
            rbMeasDefault.UseVisualStyleBackColor = true;
            // 
            // rbMeasPoint
            // 
            rbMeasPoint.AutoSize = true;
            rbMeasPoint.Location = new System.Drawing.Point(13, 85);
            rbMeasPoint.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbMeasPoint.Name = "rbMeasPoint";
            rbMeasPoint.Size = new System.Drawing.Size(109, 41);
            rbMeasPoint.TabIndex = 59;
            rbMeasPoint.Text = "Point";
            rbMeasPoint.UseVisualStyleBackColor = true;
            // 
            // rbMeasPolygon
            // 
            rbMeasPolygon.AutoSize = true;
            rbMeasPolygon.Location = new System.Drawing.Point(13, 170);
            rbMeasPolygon.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbMeasPolygon.Name = "rbMeasPolygon";
            rbMeasPolygon.Size = new System.Drawing.Size(145, 41);
            rbMeasPolygon.TabIndex = 61;
            rbMeasPolygon.Text = "Polygon";
            rbMeasPolygon.UseVisualStyleBackColor = true;
            // 
            // rbMeasLineString
            // 
            rbMeasLineString.AutoSize = true;
            rbMeasLineString.Location = new System.Drawing.Point(13, 128);
            rbMeasLineString.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            rbMeasLineString.Name = "rbMeasLineString";
            rbMeasLineString.Size = new System.Drawing.Size(171, 41);
            rbMeasLineString.TabIndex = 60;
            rbMeasLineString.Text = "Line string";
            rbMeasLineString.UseVisualStyleBackColor = true;
            // 
            // btnGetActiveMeasurement
            // 
            btnGetActiveMeasurement.Location = new System.Drawing.Point(13, 242);
            btnGetActiveMeasurement.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetActiveMeasurement.Name = "btnGetActiveMeasurement";
            btnGetActiveMeasurement.Size = new System.Drawing.Size(262, 85);
            btnGetActiveMeasurement.TabIndex = 62;
            btnGetActiveMeasurement.Text = "Get Measurement";
            btnGetActiveMeasurement.UseVisualStyleBackColor = true;
            btnGetActiveMeasurement.Click += btnGetMeasurementInfo_Click;
            // 
            // btnStartMeasurementMode
            // 
            btnStartMeasurementMode.Location = new System.Drawing.Point(13, 41);
            btnStartMeasurementMode.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnStartMeasurementMode.Name = "btnStartMeasurementMode";
            btnStartMeasurementMode.Size = new System.Drawing.Size(262, 85);
            btnStartMeasurementMode.TabIndex = 57;
            btnStartMeasurementMode.Text = "Start Measurement";
            btnStartMeasurementMode.UseVisualStyleBackColor = true;
            btnStartMeasurementMode.Click += btnStartMeasurementMode_Click;
            // 
            // btnStopMeasurementMode
            // 
            btnStopMeasurementMode.Location = new System.Drawing.Point(15, 139);
            btnStopMeasurementMode.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnStopMeasurementMode.Name = "btnStopMeasurementMode";
            btnStopMeasurementMode.Size = new System.Drawing.Size(262, 85);
            btnStopMeasurementMode.TabIndex = 56;
            btnStopMeasurementMode.Text = "Stop Measurement";
            btnStopMeasurementMode.UseVisualStyleBackColor = true;
            btnStopMeasurementMode.Click += btnStopMeasurementMode_Click;
            // 
            // grDevTools
            // 
            grDevTools.Controls.Add(btnCloseDefTools);
            grDevTools.Controls.Add(btnShowDefTools);
            grDevTools.Location = new System.Drawing.Point(862, 755);
            grDevTools.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grDevTools.Name = "grDevTools";
            grDevTools.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grDevTools.Size = new System.Drawing.Size(338, 152);
            grDevTools.TabIndex = 51;
            grDevTools.TabStop = false;
            grDevTools.Text = "Dev tools";
            // 
            // btnCloseDefTools
            // 
            btnCloseDefTools.Location = new System.Drawing.Point(174, 41);
            btnCloseDefTools.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnCloseDefTools.Name = "btnCloseDefTools";
            btnCloseDefTools.Size = new System.Drawing.Size(150, 100);
            btnCloseDefTools.TabIndex = 49;
            btnCloseDefTools.Text = "Close dev tools";
            btnCloseDefTools.UseVisualStyleBackColor = true;
            btnCloseDefTools.Click += btnCloseDevTools_Click;
            // 
            // btnShowDefTools
            // 
            btnShowDefTools.Location = new System.Drawing.Point(13, 41);
            btnShowDefTools.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnShowDefTools.Name = "btnShowDefTools";
            btnShowDefTools.Size = new System.Drawing.Size(150, 100);
            btnShowDefTools.TabIndex = 48;
            btnShowDefTools.Text = "Show dev tools";
            btnShowDefTools.UseVisualStyleBackColor = true;
            btnShowDefTools.Click += btnShowDevTools_Click;
            // 
            // grRotationsZoomInOut
            // 
            grRotationsZoomInOut.Controls.Add(btnGetViewers);
            grRotationsZoomInOut.Controls.Add(btnClosePanoramaViewer);
            grRotationsZoomInOut.Controls.Add(lblDeltaYawPitch);
            grRotationsZoomInOut.Controls.Add(txtDeltaYawPitch);
            grRotationsZoomInOut.Controls.Add(btnRotateDown);
            grRotationsZoomInOut.Controls.Add(btnRotateUp);
            grRotationsZoomInOut.Controls.Add(btnRotateRight);
            grRotationsZoomInOut.Controls.Add(btnZoomOut);
            grRotationsZoomInOut.Controls.Add(btRotateLeft);
            grRotationsZoomInOut.Controls.Add(btnZoomIn);
            grRotationsZoomInOut.Location = new System.Drawing.Point(0, 435);
            grRotationsZoomInOut.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grRotationsZoomInOut.Name = "grRotationsZoomInOut";
            grRotationsZoomInOut.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grRotationsZoomInOut.Size = new System.Drawing.Size(450, 461);
            grRotationsZoomInOut.TabIndex = 0;
            grRotationsZoomInOut.TabStop = false;
            grRotationsZoomInOut.Text = "Rotations / zoom in / zoom out";
            // 
            // btnGetViewers
            // 
            btnGetViewers.Location = new System.Drawing.Point(238, 337);
            btnGetViewers.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetViewers.Name = "btnGetViewers";
            btnGetViewers.Size = new System.Drawing.Size(201, 70);
            btnGetViewers.TabIndex = 62;
            btnGetViewers.Text = "Get viewers";
            btnGetViewers.UseVisualStyleBackColor = true;
            btnGetViewers.Click += btnGetViewers_Click;
            // 
            // btnClosePanoramaViewer
            // 
            btnClosePanoramaViewer.Location = new System.Drawing.Point(15, 337);
            btnClosePanoramaViewer.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnClosePanoramaViewer.Name = "btnClosePanoramaViewer";
            btnClosePanoramaViewer.Size = new System.Drawing.Size(201, 107);
            btnClosePanoramaViewer.TabIndex = 61;
            btnClosePanoramaViewer.Text = "Close pan. viewer";
            btnClosePanoramaViewer.UseVisualStyleBackColor = true;
            btnClosePanoramaViewer.Click += btnClosePanoramaViewer_Click;
            // 
            // lblDeltaYawPitch
            // 
            lblDeltaYawPitch.AutoSize = true;
            lblDeltaYawPitch.Location = new System.Drawing.Point(13, 276);
            lblDeltaYawPitch.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblDeltaYawPitch.Name = "lblDeltaYawPitch";
            lblDeltaYawPitch.Size = new System.Drawing.Size(215, 37);
            lblDeltaYawPitch.TabIndex = 20;
            lblDeltaYawPitch.Text = "delta yaw / pitch";
            // 
            // txtDeltaYawPitch
            // 
            txtDeltaYawPitch.Location = new System.Drawing.Point(238, 276);
            txtDeltaYawPitch.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtDeltaYawPitch.Name = "txtDeltaYawPitch";
            txtDeltaYawPitch.Size = new System.Drawing.Size(193, 43);
            txtDeltaYawPitch.TabIndex = 21;
            txtDeltaYawPitch.Text = "1";
            // 
            // btnRotateDown
            // 
            btnRotateDown.Location = new System.Drawing.Point(238, 41);
            btnRotateDown.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnRotateDown.Name = "btnRotateDown";
            btnRotateDown.Size = new System.Drawing.Size(201, 70);
            btnRotateDown.TabIndex = 19;
            btnRotateDown.Text = "Rotate down";
            btnRotateDown.UseVisualStyleBackColor = true;
            btnRotateDown.Click += btnRotateDown_Click;
            // 
            // btnRotateUp
            // 
            btnRotateUp.Location = new System.Drawing.Point(15, 41);
            btnRotateUp.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnRotateUp.Name = "btnRotateUp";
            btnRotateUp.Size = new System.Drawing.Size(201, 70);
            btnRotateUp.TabIndex = 18;
            btnRotateUp.Text = "Rotate up";
            btnRotateUp.UseVisualStyleBackColor = true;
            btnRotateUp.Click += btnRotateUp_Click;
            // 
            // btnRotateRight
            // 
            btnRotateRight.Location = new System.Drawing.Point(15, 115);
            btnRotateRight.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnRotateRight.Name = "btnRotateRight";
            btnRotateRight.Size = new System.Drawing.Size(201, 70);
            btnRotateRight.TabIndex = 6;
            btnRotateRight.Text = "Rotate right";
            btnRotateRight.UseVisualStyleBackColor = true;
            btnRotateRight.Click += btnRotateRight_Click;
            // 
            // btnZoomOut
            // 
            btnZoomOut.Location = new System.Drawing.Point(238, 194);
            btnZoomOut.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new System.Drawing.Size(201, 70);
            btnZoomOut.TabIndex = 46;
            btnZoomOut.Text = "Zoom out";
            btnZoomOut.UseVisualStyleBackColor = true;
            btnZoomOut.Click += btnZoomOut_Click;
            // 
            // btRotateLeft
            // 
            btRotateLeft.Location = new System.Drawing.Point(15, 196);
            btRotateLeft.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btRotateLeft.Name = "btRotateLeft";
            btRotateLeft.Size = new System.Drawing.Size(201, 70);
            btRotateLeft.TabIndex = 0;
            btRotateLeft.Text = "Rotate left";
            btRotateLeft.UseVisualStyleBackColor = true;
            btRotateLeft.Click += btRotateLeft_Click;
            // 
            // btnZoomIn
            // 
            btnZoomIn.Location = new System.Drawing.Point(238, 115);
            btnZoomIn.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new System.Drawing.Size(201, 70);
            btnZoomIn.TabIndex = 45;
            btnZoomIn.Text = "Zoom in";
            btnZoomIn.UseVisualStyleBackColor = true;
            btnZoomIn.Click += btnZoomIn_Click;
            // 
            // grEvents
            // 
            grEvents.Controls.Add(lbViewerEvents);
            grEvents.Location = new System.Drawing.Point(15, 1286);
            grEvents.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grEvents.Name = "grEvents";
            grEvents.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grEvents.Size = new System.Drawing.Size(1821, 285);
            grEvents.TabIndex = 50;
            grEvents.TabStop = false;
            grEvents.Text = "Viewer events";
            // 
            // lbViewerEvents
            // 
            lbViewerEvents.FormattingEnabled = true;
            lbViewerEvents.ItemHeight = 37;
            lbViewerEvents.Location = new System.Drawing.Point(13, 41);
            lbViewerEvents.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            lbViewerEvents.Name = "lbViewerEvents";
            lbViewerEvents.Size = new System.Drawing.Size(1780, 226);
            lbViewerEvents.TabIndex = 0;
            // 
            // grRecordingViewerColorPermissions
            // 
            grRecordingViewerColorPermissions.Controls.Add(txtRecordingViewerColorPermissions);
            grRecordingViewerColorPermissions.Controls.Add(btnGetPermissions);
            grRecordingViewerColorPermissions.Controls.Add(btnGetRecording);
            grRecordingViewerColorPermissions.Controls.Add(btnGetViewerColor);
            grRecordingViewerColorPermissions.Location = new System.Drawing.Point(13, 899);
            grRecordingViewerColorPermissions.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grRecordingViewerColorPermissions.Name = "grRecordingViewerColorPermissions";
            grRecordingViewerColorPermissions.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grRecordingViewerColorPermissions.Size = new System.Drawing.Size(801, 385);
            grRecordingViewerColorPermissions.TabIndex = 0;
            grRecordingViewerColorPermissions.TabStop = false;
            grRecordingViewerColorPermissions.Text = "Recording / Viewer color / Permissions";
            // 
            // txtRecordingViewerColorPermissions
            // 
            txtRecordingViewerColorPermissions.Location = new System.Drawing.Point(276, 41);
            txtRecordingViewerColorPermissions.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtRecordingViewerColorPermissions.Multiline = true;
            txtRecordingViewerColorPermissions.Name = "txtRecordingViewerColorPermissions";
            txtRecordingViewerColorPermissions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtRecordingViewerColorPermissions.Size = new System.Drawing.Size(506, 320);
            txtRecordingViewerColorPermissions.TabIndex = 49;
            // 
            // btnGetPermissions
            // 
            btnGetPermissions.Location = new System.Drawing.Point(13, 41);
            btnGetPermissions.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetPermissions.Name = "btnGetPermissions";
            btnGetPermissions.Size = new System.Drawing.Size(249, 85);
            btnGetPermissions.TabIndex = 11;
            btnGetPermissions.Text = "Get Permissions";
            btnGetPermissions.UseVisualStyleBackColor = true;
            btnGetPermissions.Click += btnPermissions_Click;
            // 
            // btnGetRecording
            // 
            btnGetRecording.Location = new System.Drawing.Point(13, 185);
            btnGetRecording.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetRecording.Name = "btnGetRecording";
            btnGetRecording.Size = new System.Drawing.Size(249, 85);
            btnGetRecording.TabIndex = 28;
            btnGetRecording.Text = "Get Recording";
            btnGetRecording.UseVisualStyleBackColor = true;
            btnGetRecording.Click += btnGetRecording_Click;
            // 
            // btnGetViewerColor
            // 
            btnGetViewerColor.Location = new System.Drawing.Point(13, 285);
            btnGetViewerColor.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetViewerColor.Name = "btnGetViewerColor";
            btnGetViewerColor.Size = new System.Drawing.Size(249, 85);
            btnGetViewerColor.TabIndex = 17;
            btnGetViewerColor.Text = "Get Viewer Color";
            btnGetViewerColor.UseVisualStyleBackColor = true;
            btnGetViewerColor.Click += btnGetViewerColor_Click;
            // 
            // grOrientation
            // 
            grOrientation.Controls.Add(btnGetDebugLogs);
            grOrientation.Controls.Add(txtYaw);
            grOrientation.Controls.Add(lblYaw);
            grOrientation.Controls.Add(lblPitch);
            grOrientation.Controls.Add(txtPitch);
            grOrientation.Controls.Add(lblhFov);
            grOrientation.Controls.Add(txthFov);
            grOrientation.Controls.Add(btnGetOrientation);
            grOrientation.Controls.Add(btnSetOrientation);
            grOrientation.Location = new System.Drawing.Point(1222, 625);
            grOrientation.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOrientation.Name = "grOrientation";
            grOrientation.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOrientation.Size = new System.Drawing.Size(600, 329);
            grOrientation.TabIndex = 0;
            grOrientation.TabStop = false;
            grOrientation.Text = "Orientation";
            // 
            // btnGetDebugLogs
            // 
            btnGetDebugLogs.Location = new System.Drawing.Point(13, 128);
            btnGetDebugLogs.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetDebugLogs.Name = "btnGetDebugLogs";
            btnGetDebugLogs.Size = new System.Drawing.Size(249, 85);
            btnGetDebugLogs.TabIndex = 28;
            btnGetDebugLogs.Text = "Get Debug logs";
            btnGetDebugLogs.UseVisualStyleBackColor = true;
            btnGetDebugLogs.Click += btnGetDebugLogs_Click;
            // 
            // txtYaw
            // 
            txtYaw.Location = new System.Drawing.Point(362, 41);
            txtYaw.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtYaw.Name = "txtYaw";
            txtYaw.Size = new System.Drawing.Size(220, 43);
            txtYaw.TabIndex = 23;
            txtYaw.Text = "0.0";
            // 
            // lblYaw
            // 
            lblYaw.AutoSize = true;
            lblYaw.Location = new System.Drawing.Point(276, 41);
            lblYaw.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblYaw.Name = "lblYaw";
            lblYaw.Size = new System.Drawing.Size(64, 37);
            lblYaw.TabIndex = 21;
            lblYaw.Text = "Yaw";
            // 
            // lblPitch
            // 
            lblPitch.AutoSize = true;
            lblPitch.Location = new System.Drawing.Point(276, 115);
            lblPitch.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblPitch.Name = "lblPitch";
            lblPitch.Size = new System.Drawing.Size(75, 37);
            lblPitch.TabIndex = 22;
            lblPitch.Text = "Pitch";
            // 
            // txtPitch
            // 
            txtPitch.Location = new System.Drawing.Point(362, 115);
            txtPitch.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtPitch.Name = "txtPitch";
            txtPitch.Size = new System.Drawing.Size(220, 43);
            txtPitch.TabIndex = 24;
            txtPitch.Text = "0.0";
            // 
            // lblhFov
            // 
            lblhFov.AutoSize = true;
            lblhFov.Location = new System.Drawing.Point(276, 185);
            lblhFov.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblhFov.Name = "lblhFov";
            lblhFov.Size = new System.Drawing.Size(74, 37);
            lblhFov.TabIndex = 25;
            lblhFov.Text = "hFov";
            // 
            // txthFov
            // 
            txthFov.Location = new System.Drawing.Point(362, 185);
            txthFov.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txthFov.Name = "txthFov";
            txthFov.Size = new System.Drawing.Size(220, 43);
            txthFov.TabIndex = 26;
            txthFov.Text = "90.0";
            // 
            // btnGetOrientation
            // 
            btnGetOrientation.Location = new System.Drawing.Point(13, 41);
            btnGetOrientation.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetOrientation.Name = "btnGetOrientation";
            btnGetOrientation.Size = new System.Drawing.Size(249, 85);
            btnGetOrientation.TabIndex = 20;
            btnGetOrientation.Text = "Get Orientation";
            btnGetOrientation.UseVisualStyleBackColor = true;
            btnGetOrientation.Click += btnOrientation_Click;
            // 
            // btnSetOrientation
            // 
            btnSetOrientation.Location = new System.Drawing.Point(13, 226);
            btnSetOrientation.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnSetOrientation.Name = "btnSetOrientation";
            btnSetOrientation.Size = new System.Drawing.Size(249, 85);
            btnSetOrientation.TabIndex = 27;
            btnSetOrientation.Text = "Set Orientation";
            btnSetOrientation.UseVisualStyleBackColor = true;
            btnSetOrientation.Click += btnSetOrientation_Click;
            // 
            // grOpenByImageId
            // 
            grOpenByImageId.Controls.Add(txtBrightnessContrast);
            grOpenByImageId.Controls.Add(btnContrast);
            grOpenByImageId.Controls.Add(btnBrightness);
            grOpenByImageId.Controls.Add(btnGetAddress);
            grOpenByImageId.Controls.Add(btnOpenByImageId);
            grOpenByImageId.Controls.Add(txtImageId);
            grOpenByImageId.Location = new System.Drawing.Point(1228, 962);
            grOpenByImageId.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOpenByImageId.Name = "grOpenByImageId";
            grOpenByImageId.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOpenByImageId.Size = new System.Drawing.Size(594, 300);
            grOpenByImageId.TabIndex = 44;
            grOpenByImageId.TabStop = false;
            grOpenByImageId.Text = "Open by imageId";
            // 
            // txtBrightnessContrast
            // 
            txtBrightnessContrast.Location = new System.Drawing.Point(300, 231);
            txtBrightnessContrast.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtBrightnessContrast.Name = "txtBrightnessContrast";
            txtBrightnessContrast.Size = new System.Drawing.Size(268, 43);
            txtBrightnessContrast.TabIndex = 52;
            // 
            // btnContrast
            // 
            btnContrast.Location = new System.Drawing.Point(300, 133);
            btnContrast.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnContrast.Name = "btnContrast";
            btnContrast.Size = new System.Drawing.Size(276, 85);
            btnContrast.TabIndex = 51;
            btnContrast.Text = "Set Contrast";
            btnContrast.UseVisualStyleBackColor = true;
            btnContrast.Click += btnContrast_Click;
            // 
            // btnBrightness
            // 
            btnBrightness.Location = new System.Drawing.Point(300, 41);
            btnBrightness.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnBrightness.Name = "btnBrightness";
            btnBrightness.Size = new System.Drawing.Size(276, 85);
            btnBrightness.TabIndex = 50;
            btnBrightness.Text = "Set Brightness";
            btnBrightness.UseVisualStyleBackColor = true;
            btnBrightness.Click += btnBrightness_Click;
            // 
            // btnGetAddress
            // 
            btnGetAddress.Location = new System.Drawing.Point(13, 213);
            btnGetAddress.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetAddress.Name = "btnGetAddress";
            btnGetAddress.Size = new System.Drawing.Size(249, 85);
            btnGetAddress.TabIndex = 49;
            btnGetAddress.Text = "Get address settings";
            btnGetAddress.UseVisualStyleBackColor = true;
            btnGetAddress.Click += btnGetAddress_Click;
            // 
            // btnOpenByImageId
            // 
            btnOpenByImageId.Location = new System.Drawing.Point(13, 115);
            btnOpenByImageId.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnOpenByImageId.Name = "btnOpenByImageId";
            btnOpenByImageId.Size = new System.Drawing.Size(249, 85);
            btnOpenByImageId.TabIndex = 43;
            btnOpenByImageId.Text = "Open by ImageId";
            btnOpenByImageId.UseVisualStyleBackColor = true;
            btnOpenByImageId.Click += btnOpenByImageId_Click;
            // 
            // txtImageId
            // 
            txtImageId.Location = new System.Drawing.Point(21, 41);
            txtImageId.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtImageId.Name = "txtImageId";
            txtImageId.Size = new System.Drawing.Size(244, 43);
            txtImageId.TabIndex = 42;
            txtImageId.Text = "5D4KX5SM";
            // 
            // grCoordinate
            // 
            grCoordinate.Controls.Add(btnSetPointSize);
            grCoordinate.Controls.Add(txtPointSize);
            grCoordinate.Controls.Add(btnGetPointSize);
            grCoordinate.Controls.Add(btnSetPointBudget);
            grCoordinate.Controls.Add(cbPointBudget);
            grCoordinate.Controls.Add(btnGetPointBudget);
            grCoordinate.Controls.Add(btnEdges);
            grCoordinate.Controls.Add(btnCameraPosition);
            grCoordinate.Controls.Add(txtlkAtX);
            grCoordinate.Controls.Add(txtlkAtY);
            grCoordinate.Controls.Add(txtlkAtZ);
            grCoordinate.Controls.Add(btnFlyTo);
            grCoordinate.Controls.Add(txtX);
            grCoordinate.Controls.Add(txtY);
            grCoordinate.Controls.Add(txtZ);
            grCoordinate.Controls.Add(lblX);
            grCoordinate.Controls.Add(lblY);
            grCoordinate.Controls.Add(lblZ);
            grCoordinate.Controls.Add(btnOpenByCoordinate);
            grCoordinate.Controls.Add(btnLookAtCoordinate);
            grCoordinate.Location = new System.Drawing.Point(1209, 353);
            grCoordinate.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grCoordinate.Name = "grCoordinate";
            grCoordinate.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grCoordinate.Size = new System.Drawing.Size(1037, 255);
            grCoordinate.TabIndex = 0;
            grCoordinate.TabStop = false;
            grCoordinate.Text = "Coordinate";
            // 
            // btnSetPointSize
            // 
            btnSetPointSize.Location = new System.Drawing.Point(938, 111);
            btnSetPointSize.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnSetPointSize.Name = "btnSetPointSize";
            btnSetPointSize.Size = new System.Drawing.Size(99, 70);
            btnSetPointSize.TabIndex = 56;
            btnSetPointSize.Text = "Set";
            btnSetPointSize.UseVisualStyleBackColor = true;
            btnSetPointSize.Click += btnSetPointSize_Click;
            // 
            // txtPointSize
            // 
            txtPointSize.Location = new System.Drawing.Point(825, 120);
            txtPointSize.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtPointSize.Name = "txtPointSize";
            txtPointSize.Size = new System.Drawing.Size(94, 43);
            txtPointSize.TabIndex = 55;
            txtPointSize.Text = "0";
            // 
            // btnGetPointSize
            // 
            btnGetPointSize.Location = new System.Drawing.Point(712, 111);
            btnGetPointSize.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetPointSize.Name = "btnGetPointSize";
            btnGetPointSize.Size = new System.Drawing.Size(99, 70);
            btnGetPointSize.TabIndex = 54;
            btnGetPointSize.Text = "Get";
            btnGetPointSize.UseVisualStyleBackColor = true;
            btnGetPointSize.Click += btnGetPointSize_Click;
            // 
            // btnSetPointBudget
            // 
            btnSetPointBudget.Location = new System.Drawing.Point(938, 176);
            btnSetPointBudget.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnSetPointBudget.Name = "btnSetPointBudget";
            btnSetPointBudget.Size = new System.Drawing.Size(99, 70);
            btnSetPointBudget.TabIndex = 53;
            btnSetPointBudget.Text = "Set";
            btnSetPointBudget.UseVisualStyleBackColor = true;
            btnSetPointBudget.Click += btnSetPointBudget_Click;
            // 
            // cbPointBudget
            // 
            cbPointBudget.FormattingEnabled = true;
            cbPointBudget.Location = new System.Drawing.Point(825, 185);
            cbPointBudget.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            cbPointBudget.Name = "cbPointBudget";
            cbPointBudget.Size = new System.Drawing.Size(94, 45);
            cbPointBudget.TabIndex = 52;
            // 
            // btnGetPointBudget
            // 
            btnGetPointBudget.Location = new System.Drawing.Point(712, 176);
            btnGetPointBudget.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetPointBudget.Name = "btnGetPointBudget";
            btnGetPointBudget.Size = new System.Drawing.Size(99, 70);
            btnGetPointBudget.TabIndex = 51;
            btnGetPointBudget.Text = "Get";
            btnGetPointBudget.UseVisualStyleBackColor = true;
            btnGetPointBudget.Click += btnGetPointBudget_Click;
            // 
            // btnEdges
            // 
            btnEdges.Location = new System.Drawing.Point(938, 41);
            btnEdges.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnEdges.Name = "btnEdges";
            btnEdges.Size = new System.Drawing.Size(99, 70);
            btnEdges.TabIndex = 50;
            btnEdges.Text = "Edges";
            btnEdges.UseVisualStyleBackColor = true;
            btnEdges.Click += btnEdges_Click;
            // 
            // btnCameraPosition
            // 
            btnCameraPosition.Location = new System.Drawing.Point(825, 41);
            btnCameraPosition.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnCameraPosition.Name = "btnCameraPosition";
            btnCameraPosition.Size = new System.Drawing.Size(99, 70);
            btnCameraPosition.TabIndex = 49;
            btnCameraPosition.UseVisualStyleBackColor = true;
            btnCameraPosition.Click += btnCameraPosition_Click;
            // 
            // txtlkAtX
            // 
            txtlkAtX.Location = new System.Drawing.Point(538, 41);
            txtlkAtX.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtlkAtX.Name = "txtlkAtX";
            txtlkAtX.Size = new System.Drawing.Size(156, 43);
            txtlkAtX.TabIndex = 46;
            txtlkAtX.Text = "160855.585";
            // 
            // txtlkAtY
            // 
            txtlkAtY.Location = new System.Drawing.Point(538, 115);
            txtlkAtY.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtlkAtY.Name = "txtlkAtY";
            txtlkAtY.Size = new System.Drawing.Size(156, 43);
            txtlkAtY.TabIndex = 47;
            txtlkAtY.Text = "383928.326";
            // 
            // txtlkAtZ
            // 
            txtlkAtZ.Location = new System.Drawing.Point(538, 185);
            txtlkAtZ.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtlkAtZ.Name = "txtlkAtZ";
            txtlkAtZ.Size = new System.Drawing.Size(156, 43);
            txtlkAtZ.TabIndex = 48;
            txtlkAtZ.Text = "4.5";
            // 
            // btnFlyTo
            // 
            btnFlyTo.Location = new System.Drawing.Point(712, 41);
            btnFlyTo.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnFlyTo.Name = "btnFlyTo";
            btnFlyTo.Size = new System.Drawing.Size(99, 70);
            btnFlyTo.TabIndex = 45;
            btnFlyTo.UseVisualStyleBackColor = true;
            btnFlyTo.Click += btnFlyTo_Click;
            // 
            // txtX
            // 
            txtX.Location = new System.Drawing.Point(362, 41);
            txtX.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtX.Name = "txtX";
            txtX.Size = new System.Drawing.Size(156, 43);
            txtX.TabIndex = 30;
            txtX.Text = "160850.585";
            // 
            // txtY
            // 
            txtY.Location = new System.Drawing.Point(362, 115);
            txtY.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtY.Name = "txtY";
            txtY.Size = new System.Drawing.Size(156, 43);
            txtY.TabIndex = 31;
            txtY.Text = "383923.326";
            // 
            // txtZ
            // 
            txtZ.Location = new System.Drawing.Point(362, 185);
            txtZ.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtZ.Name = "txtZ";
            txtZ.Size = new System.Drawing.Size(156, 43);
            txtZ.TabIndex = 32;
            txtZ.Text = "4.0";
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Location = new System.Drawing.Point(300, 41);
            lblX.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblX.Name = "lblX";
            lblX.Size = new System.Drawing.Size(33, 37);
            lblX.TabIndex = 33;
            lblX.Text = "X";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new System.Drawing.Point(300, 115);
            lblY.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblY.Name = "lblY";
            lblY.Size = new System.Drawing.Size(32, 37);
            lblY.TabIndex = 34;
            lblY.Text = "Y";
            // 
            // lblZ
            // 
            lblZ.AutoSize = true;
            lblZ.Location = new System.Drawing.Point(300, 185);
            lblZ.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblZ.Name = "lblZ";
            lblZ.Size = new System.Drawing.Size(32, 37);
            lblZ.TabIndex = 35;
            lblZ.Text = "Z";
            // 
            // btnOpenByCoordinate
            // 
            btnOpenByCoordinate.Location = new System.Drawing.Point(13, 41);
            btnOpenByCoordinate.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnOpenByCoordinate.Name = "btnOpenByCoordinate";
            btnOpenByCoordinate.Size = new System.Drawing.Size(276, 85);
            btnOpenByCoordinate.TabIndex = 44;
            btnOpenByCoordinate.Text = "Open by coordinate";
            btnOpenByCoordinate.UseVisualStyleBackColor = true;
            btnOpenByCoordinate.Click += btnOpenByCoordinate_Click;
            // 
            // btnLookAtCoordinate
            // 
            btnLookAtCoordinate.Location = new System.Drawing.Point(13, 144);
            btnLookAtCoordinate.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnLookAtCoordinate.Name = "btnLookAtCoordinate";
            btnLookAtCoordinate.Size = new System.Drawing.Size(276, 85);
            btnLookAtCoordinate.TabIndex = 29;
            btnLookAtCoordinate.Text = "Look at coordinate";
            btnLookAtCoordinate.UseVisualStyleBackColor = true;
            btnLookAtCoordinate.Click += btnLookAtCoordinate_Click;
            // 
            // grAPIInfo
            // 
            grAPIInfo.Controls.Add(lblResult);
            grAPIInfo.Controls.Add(txtAPIResult);
            grAPIInfo.Controls.Add(btnApiReadyState);
            grAPIInfo.Controls.Add(btnApplicationVersion);
            grAPIInfo.Controls.Add(btnApplicationName);
            grAPIInfo.Location = new System.Drawing.Point(900, 222);
            grAPIInfo.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grAPIInfo.Name = "grAPIInfo";
            grAPIInfo.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grAPIInfo.Size = new System.Drawing.Size(300, 540);
            grAPIInfo.TabIndex = 0;
            grAPIInfo.TabStop = false;
            grAPIInfo.Text = "API Info";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new System.Drawing.Point(13, 342);
            lblResult.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(94, 37);
            lblResult.TabIndex = 22;
            lblResult.Text = "Result:";
            // 
            // txtAPIResult
            // 
            txtAPIResult.Location = new System.Drawing.Point(13, 440);
            txtAPIResult.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtAPIResult.Name = "txtAPIResult";
            txtAPIResult.Size = new System.Drawing.Size(268, 43);
            txtAPIResult.TabIndex = 23;
            // 
            // btnApiReadyState
            // 
            btnApiReadyState.Location = new System.Drawing.Point(13, 41);
            btnApiReadyState.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnApiReadyState.Name = "btnApiReadyState";
            btnApiReadyState.Size = new System.Drawing.Size(276, 85);
            btnApiReadyState.TabIndex = 8;
            btnApiReadyState.Text = "API Ready State";
            btnApiReadyState.UseVisualStyleBackColor = true;
            btnApiReadyState.Click += btnApiReadyState_Click;
            // 
            // btnApplicationVersion
            // 
            btnApplicationVersion.Location = new System.Drawing.Point(13, 144);
            btnApplicationVersion.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnApplicationVersion.Name = "btnApplicationVersion";
            btnApplicationVersion.Size = new System.Drawing.Size(276, 85);
            btnApplicationVersion.TabIndex = 9;
            btnApplicationVersion.Text = "Application version";
            btnApplicationVersion.UseVisualStyleBackColor = true;
            btnApplicationVersion.Click += btnApplicationVersion_Click;
            // 
            // btnApplicationName
            // 
            btnApplicationName.Location = new System.Drawing.Point(13, 242);
            btnApplicationName.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnApplicationName.Name = "btnApplicationName";
            btnApplicationName.Size = new System.Drawing.Size(276, 85);
            btnApplicationName.TabIndex = 10;
            btnApplicationName.Text = "Application name";
            btnApplicationName.UseVisualStyleBackColor = true;
            btnApplicationName.Click += btnApplicationName_Click;
            // 
            // grViewerToggles
            // 
            grViewerToggles.Controls.Add(btnGetType);
            grViewerToggles.Controls.Add(btnToggleSidebarExpandable);
            grViewerToggles.Controls.Add(btnToggleSidebar);
            grViewerToggles.Controls.Add(btnToggle3DCursor);
            grViewerToggles.Controls.Add(btnToggleRecordingsVisible);
            grViewerToggles.Controls.Add(btnToggleTimeTravelExpanded);
            grViewerToggles.Controls.Add(btnToggleNavbarExpanded);
            grViewerToggles.Controls.Add(btnToggleTimeTravelVisible);
            grViewerToggles.Controls.Add(btnToggleNavbarVisible);
            grViewerToggles.Location = new System.Drawing.Point(450, 222);
            grViewerToggles.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grViewerToggles.Name = "grViewerToggles";
            grViewerToggles.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grViewerToggles.Size = new System.Drawing.Size(450, 675);
            grViewerToggles.TabIndex = 0;
            grViewerToggles.TabStop = false;
            grViewerToggles.Text = "Viewer toggles";
            // 
            // btnGetType
            // 
            btnGetType.Location = new System.Drawing.Point(13, 612);
            btnGetType.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnGetType.Name = "btnGetType";
            btnGetType.Size = new System.Drawing.Size(384, 63);
            btnGetType.TabIndex = 44;
            btnGetType.Text = "Get viewer type";
            btnGetType.UseVisualStyleBackColor = true;
            btnGetType.Click += btnGetType_Click;
            // 
            // btnToggleSidebarExpandable
            // 
            btnToggleSidebarExpandable.Location = new System.Drawing.Point(13, 544);
            btnToggleSidebarExpandable.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnToggleSidebarExpandable.Name = "btnToggleSidebarExpandable";
            btnToggleSidebarExpandable.Size = new System.Drawing.Size(384, 63);
            btnToggleSidebarExpandable.TabIndex = 43;
            btnToggleSidebarExpandable.Text = "Toggle Sidebar expandable";
            btnToggleSidebarExpandable.UseVisualStyleBackColor = true;
            btnToggleSidebarExpandable.Click += btnToggleSidebarExpandable_Click;
            // 
            // btnToggleSidebar
            // 
            btnToggleSidebar.Location = new System.Drawing.Point(13, 470);
            btnToggleSidebar.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnToggleSidebar.Name = "btnToggleSidebar";
            btnToggleSidebar.Size = new System.Drawing.Size(384, 63);
            btnToggleSidebar.TabIndex = 42;
            btnToggleSidebar.Text = "Toggle Sidebar expanded";
            btnToggleSidebar.UseVisualStyleBackColor = true;
            btnToggleSidebar.Click += btnToggleSidebar_Click;
            // 
            // btnToggle3DCursor
            // 
            btnToggle3DCursor.Location = new System.Drawing.Point(13, 398);
            btnToggle3DCursor.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnToggle3DCursor.Name = "btnToggle3DCursor";
            btnToggle3DCursor.Size = new System.Drawing.Size(384, 63);
            btnToggle3DCursor.TabIndex = 41;
            btnToggle3DCursor.Text = "Toggle 3D Cursor";
            btnToggle3DCursor.UseVisualStyleBackColor = true;
            btnToggle3DCursor.Click += btnToggle3DCursor_Click;
            // 
            // btnToggleRecordingsVisible
            // 
            btnToggleRecordingsVisible.Location = new System.Drawing.Point(13, 41);
            btnToggleRecordingsVisible.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnToggleRecordingsVisible.Name = "btnToggleRecordingsVisible";
            btnToggleRecordingsVisible.Size = new System.Drawing.Size(384, 63);
            btnToggleRecordingsVisible.TabIndex = 36;
            btnToggleRecordingsVisible.Text = "Toggle recordings visible";
            btnToggleRecordingsVisible.UseVisualStyleBackColor = true;
            btnToggleRecordingsVisible.Click += btnToggleRecordingsVisible_Click;
            // 
            // btnToggleTimeTravelExpanded
            // 
            btnToggleTimeTravelExpanded.Location = new System.Drawing.Point(13, 115);
            btnToggleTimeTravelExpanded.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnToggleTimeTravelExpanded.Name = "btnToggleTimeTravelExpanded";
            btnToggleTimeTravelExpanded.Size = new System.Drawing.Size(384, 63);
            btnToggleTimeTravelExpanded.TabIndex = 40;
            btnToggleTimeTravelExpanded.Text = "Toggle time travel expanded";
            btnToggleTimeTravelExpanded.UseVisualStyleBackColor = true;
            btnToggleTimeTravelExpanded.Click += btnToggleTimeTravelExpanded_Click;
            // 
            // btnToggleNavbarExpanded
            // 
            btnToggleNavbarExpanded.Location = new System.Drawing.Point(13, 185);
            btnToggleNavbarExpanded.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnToggleNavbarExpanded.Name = "btnToggleNavbarExpanded";
            btnToggleNavbarExpanded.Size = new System.Drawing.Size(384, 63);
            btnToggleNavbarExpanded.TabIndex = 38;
            btnToggleNavbarExpanded.Text = "Toggle navbar expanded";
            btnToggleNavbarExpanded.UseVisualStyleBackColor = true;
            btnToggleNavbarExpanded.Click += btnToggleNavbarExpanded_Click;
            // 
            // btnToggleTimeTravelVisible
            // 
            btnToggleTimeTravelVisible.Location = new System.Drawing.Point(13, 255);
            btnToggleTimeTravelVisible.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnToggleTimeTravelVisible.Name = "btnToggleTimeTravelVisible";
            btnToggleTimeTravelVisible.Size = new System.Drawing.Size(384, 63);
            btnToggleTimeTravelVisible.TabIndex = 39;
            btnToggleTimeTravelVisible.Text = "Toggle time travel visible";
            btnToggleTimeTravelVisible.UseVisualStyleBackColor = true;
            btnToggleTimeTravelVisible.Click += btnToggleTimeTravelVisible_Click;
            // 
            // btnToggleNavbarVisible
            // 
            btnToggleNavbarVisible.Location = new System.Drawing.Point(13, 329);
            btnToggleNavbarVisible.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnToggleNavbarVisible.Name = "btnToggleNavbarVisible";
            btnToggleNavbarVisible.Size = new System.Drawing.Size(384, 63);
            btnToggleNavbarVisible.TabIndex = 37;
            btnToggleNavbarVisible.Text = "Toggle Navbar Visible";
            btnToggleNavbarVisible.UseVisualStyleBackColor = true;
            btnToggleNavbarVisible.Click += btnToggleNavbarVisible_Click;
            // 
            // grOpenByAddress
            // 
            grOpenByAddress.Controls.Add(lblAddress);
            grOpenByAddress.Controls.Add(txtAdress);
            grOpenByAddress.Controls.Add(btnOpenByAddress);
            grOpenByAddress.Location = new System.Drawing.Point(450, 0);
            grOpenByAddress.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOpenByAddress.Name = "grOpenByAddress";
            grOpenByAddress.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grOpenByAddress.Size = new System.Drawing.Size(750, 213);
            grOpenByAddress.TabIndex = 0;
            grOpenByAddress.TabStop = false;
            grOpenByAddress.Text = "Open by address";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new System.Drawing.Point(13, 41);
            lblAddress.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new System.Drawing.Size(111, 37);
            lblAddress.TabIndex = 12;
            lblAddress.Text = "Address";
            // 
            // txtAdress
            // 
            txtAdress.Location = new System.Drawing.Point(163, 41);
            txtAdress.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtAdress.Name = "txtAdress";
            txtAdress.Size = new System.Drawing.Size(568, 43);
            txtAdress.TabIndex = 14;
            txtAdress.Text = "Lange Haven 145, Schiedam";
            // 
            // btnOpenByAddress
            // 
            btnOpenByAddress.Location = new System.Drawing.Point(13, 115);
            btnOpenByAddress.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnOpenByAddress.Name = "btnOpenByAddress";
            btnOpenByAddress.Size = new System.Drawing.Size(726, 85);
            btnOpenByAddress.TabIndex = 16;
            btnOpenByAddress.Text = "Open by address";
            btnOpenByAddress.UseVisualStyleBackColor = true;
            btnOpenByAddress.Click += btnOpenByAddress_Click;
            // 
            // grLogin
            // 
            grLogin.Controls.Add(lblClientId);
            grLogin.Controls.Add(txtClientId);
            grLogin.Controls.Add(lblSRS);
            grLogin.Controls.Add(txtSrs);
            grLogin.Controls.Add(btnSave);
            grLogin.Controls.Add(btnLogout);
            grLogin.Controls.Add(lblAPIKey);
            grLogin.Controls.Add(txtAPIKey);
            grLogin.Controls.Add(lblUsername);
            grLogin.Controls.Add(lblPassword);
            grLogin.Controls.Add(txtUsername);
            grLogin.Controls.Add(txtPassword);
            grLogin.Controls.Add(btnLogin);
            grLogin.Location = new System.Drawing.Point(0, 0);
            grLogin.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grLogin.Name = "grLogin";
            grLogin.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
            grLogin.Size = new System.Drawing.Size(450, 433);
            grLogin.TabIndex = 49;
            grLogin.TabStop = false;
            grLogin.Text = "Login";
            // 
            // lblClientId
            // 
            lblClientId.AutoSize = true;
            lblClientId.Location = new System.Drawing.Point(13, 194);
            lblClientId.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblClientId.Name = "lblClientId";
            lblClientId.Size = new System.Drawing.Size(109, 37);
            lblClientId.TabIndex = 50;
            lblClientId.Text = "ClientId";
            // 
            // txtClientId
            // 
            txtClientId.Location = new System.Drawing.Point(163, 194);
            txtClientId.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new System.Drawing.Size(268, 43);
            txtClientId.TabIndex = 49;
            txtClientId.TextChanged += txtClientId_TextChanged;
            // 
            // lblSRS
            // 
            lblSRS.AutoSize = true;
            lblSRS.Location = new System.Drawing.Point(13, 250);
            lblSRS.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblSRS.Name = "lblSRS";
            lblSRS.Size = new System.Drawing.Size(61, 37);
            lblSRS.TabIndex = 47;
            lblSRS.Text = "SRS";
            // 
            // txtSrs
            // 
            txtSrs.Location = new System.Drawing.Point(163, 250);
            txtSrs.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtSrs.Name = "txtSrs";
            txtSrs.Size = new System.Drawing.Size(268, 43);
            txtSrs.TabIndex = 48;
            txtSrs.Text = "EPSG:28992";
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(313, 324);
            btnSave.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(126, 85);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new System.Drawing.Point(163, 324);
            btnLogout.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new System.Drawing.Size(126, 85);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblAPIKey
            // 
            lblAPIKey.AutoSize = true;
            lblAPIKey.Location = new System.Drawing.Point(13, 139);
            lblAPIKey.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblAPIKey.Name = "lblAPIKey";
            lblAPIKey.Size = new System.Drawing.Size(106, 37);
            lblAPIKey.TabIndex = 6;
            lblAPIKey.Text = "API Key";
            // 
            // txtAPIKey
            // 
            txtAPIKey.Location = new System.Drawing.Point(163, 139);
            txtAPIKey.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtAPIKey.Name = "txtAPIKey";
            txtAPIKey.Size = new System.Drawing.Size(268, 43);
            txtAPIKey.TabIndex = 7;
            txtAPIKey.TextChanged += txtAPIKey_TextChanged;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(13, 28);
            lblUsername.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(136, 37);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(13, 83);
            lblPassword.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(128, 37);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new System.Drawing.Point(163, 28);
            txtUsername.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(268, 43);
            txtUsername.TabIndex = 3;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(163, 83);
            txtPassword.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(268, 43);
            txtPassword.TabIndex = 4;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new System.Drawing.Point(13, 324);
            btnLogin.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(126, 85);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.EnabledChanged += btnLogin_EnabledChanged;
            btnLogin.Click += btnLogin_Click;
            // 
            // Demo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(3608, 1952);
            Controls.Add(plControl);
            Controls.Add(plStreetSmart);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            Name = "Demo";
            Text = "Demo StreetSmart";
            grOpenByQuery.ResumeLayout(false);
            grOpenByQuery.PerformLayout();
            plControl.ResumeLayout(false);
            grShortCuts.ResumeLayout(false);
            grShortCuts.PerformLayout();
            grCloseViewers.ResumeLayout(false);
            grPanoramaList.ResumeLayout(false);
            grColorOverlay.ResumeLayout(false);
            grColorOverlay.PerformLayout();
            grSelectFeature.ResumeLayout(false);
            grSelectFeature.PerformLayout();
            grSld.ResumeLayout(false);
            grSld.PerformLayout();
            grButtonVisibility.ResumeLayout(false);
            grOverlay.ResumeLayout(false);
            grOverlay.PerformLayout();
            grMeasurement.ResumeLayout(false);
            grMeasurementMethod.ResumeLayout(false);
            grMeasurementMethod.PerformLayout();
            grMeasurementType.ResumeLayout(false);
            grMeasurementType.PerformLayout();
            grDevTools.ResumeLayout(false);
            grRotationsZoomInOut.ResumeLayout(false);
            grRotationsZoomInOut.PerformLayout();
            grEvents.ResumeLayout(false);
            grRecordingViewerColorPermissions.ResumeLayout(false);
            grRecordingViewerColorPermissions.PerformLayout();
            grOrientation.ResumeLayout(false);
            grOrientation.PerformLayout();
            grOpenByImageId.ResumeLayout(false);
            grOpenByImageId.PerformLayout();
            grCoordinate.ResumeLayout(false);
            grCoordinate.PerformLayout();
            grAPIInfo.ResumeLayout(false);
            grAPIInfo.PerformLayout();
            grViewerToggles.ResumeLayout(false);
            grOpenByAddress.ResumeLayout(false);
            grOpenByAddress.PerformLayout();
            grLogin.ResumeLayout(false);
            grLogin.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grMeasurementMethod;
        private System.Windows.Forms.RadioButton rbMethodDefault;
        private System.Windows.Forms.RadioButton rbMethodDepthMap;
        private System.Windows.Forms.RadioButton rbMethodForwardIntersection;
        private System.Windows.Forms.RadioButton rbMethodSmartClick;
        private System.Windows.Forms.GroupBox grMeasurementType;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Button btnGetUnitPreference;
        private System.Windows.Forms.Button btnSetUnitPreference;
        private System.Windows.Forms.GroupBox grShortCuts;
        private System.Windows.Forms.ComboBox cbShortCuts;
        private System.Windows.Forms.Button btnDisableShortCut;
        private System.Windows.Forms.Button btnEnableShortCut;
        private System.Windows.Forms.TextBox txtShortcutResult;
        private System.Windows.Forms.Label lblClientId;
        private System.Windows.Forms.TextBox txtClientId;
  }
}

