using CustomControls;
using Telerik.WinControls.UI;

namespace HotelApp
{
    partial class HotelAppForm
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn7 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn8 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn3 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn4 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn9 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn10 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn12 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition6 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn11 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition5 = new Telerik.WinControls.UI.TableViewDefinition();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.mainContainer = new Telerik.WinControls.UI.RadPageView();
            this.OverviewPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.overviewMainContainer = new Telerik.WinControls.UI.RadPanel();
            this.ByanatView = new Telerik.WinControls.UI.RadListView();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.LeftView = new Telerik.WinControls.UI.RadListView();
            this.navigationPanelOverview = new Telerik.WinControls.UI.RadPanel();
            this.searchContainerOverview = new Telerik.WinControls.UI.RadPanel();
            this.radPanelEmptyOverview = new Telerik.WinControls.UI.RadPanel();
            this.BookingsPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.bookingsMainContainer = new Telerik.WinControls.UI.RadPanel();
            this.bookingsGrid = new Telerik.WinControls.UI.RadGridView();
            this.radGridView2 = new Telerik.WinControls.UI.RadGridView();
            this.labelBookings = new Telerik.WinControls.UI.RadLabel();
            this.bookingInfoRightPanel = new Telerik.WinControls.UI.RadPanel();
            this.bookingsLeftView = new Telerik.WinControls.UI.RadListView();
            this.navigationPanelBookings = new Telerik.WinControls.UI.RadPanel();
            this.searchContainerBookings = new Telerik.WinControls.UI.RadPanel();
            this.radPanelEmptyBooking = new Telerik.WinControls.UI.RadPanel();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.materialPinkTheme1 = new Telerik.WinControls.Themes.MaterialPinkTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.radToolbarFormControl2 = new Telerik.WinControls.UI.RadToolbarFormControl();
            this.byanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contract_ManagementDataSet = new DoctorERP_v2_00.Contract_ManagementDataSet();
            this.notificationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notificationsTableAdapter = new DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.NotificationsTableAdapter();
            this.byanTableAdapter = new DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.ByanTableAdapter();
            this.carsTableAdapter = new DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.CarsTableAdapter();
            this.companiesTableAdapter = new DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.CompaniesTableAdapter();
            this.notificationViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notificationViewTableAdapter = new DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.NotificationViewTableAdapter();
            this.searchTextBoxOverview = new CustomControls.SearchTextBox();
            this.editGuestInfo = new CustomControls.EditGuestInfo();
            this.bookingInfoUC = new CustomControls.BookingInfo();
            this.searchTextBoxBookings = new CustomControls.SearchTextBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radTaskbarButton1 = new Telerik.WinControls.UI.RadTaskbarButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.SuspendLayout();
            this.OverviewPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overviewMainContainer)).BeginInit();
            this.overviewMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ByanatView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanelOverview)).BeginInit();
            this.navigationPanelOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchContainerOverview)).BeginInit();
            this.searchContainerOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelEmptyOverview)).BeginInit();
            this.BookingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsMainContainer)).BeginInit();
            this.bookingsMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGrid.MasterTemplate)).BeginInit();
            this.bookingsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingInfoRightPanel)).BeginInit();
            this.bookingInfoRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsLeftView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanelBookings)).BeginInit();
            this.navigationPanelBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchContainerBookings)).BeginInit();
            this.searchContainerBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelEmptyBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToolbarFormControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.byanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contract_ManagementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companiesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBoxOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBoxBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Controls.Add(this.OverviewPage);
            this.mainContainer.Controls.Add(this.BookingsPage);
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 41);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.SelectedPage = this.OverviewPage;
            this.mainContainer.Size = new System.Drawing.Size(1077, 653);
            this.mainContainer.TabIndex = 0;
            // 
            // OverviewPage
            // 
            this.OverviewPage.Controls.Add(this.overviewMainContainer);
            this.OverviewPage.Controls.Add(this.navigationPanelOverview);
            this.OverviewPage.ItemSize = new System.Drawing.SizeF(53F, 25F);
            this.OverviewPage.Location = new System.Drawing.Point(6, 36);
            this.OverviewPage.Name = "OverviewPage";
            this.OverviewPage.Size = new System.Drawing.Size(1065, 611);
            this.OverviewPage.Text = "الرئيسية";
            // 
            // overviewMainContainer
            // 
            this.overviewMainContainer.Controls.Add(this.radGridView1);
            this.overviewMainContainer.Controls.Add(this.LeftView);
            this.overviewMainContainer.Controls.Add(this.ByanatView);
            this.overviewMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overviewMainContainer.Location = new System.Drawing.Point(0, 60);
            this.overviewMainContainer.Margin = new System.Windows.Forms.Padding(0);
            this.overviewMainContainer.Name = "overviewMainContainer";
            this.overviewMainContainer.Size = new System.Drawing.Size(1065, 551);
            this.overviewMainContainer.TabIndex = 3;
            this.overviewMainContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.overviewMainContainer_Paint);
            // 
            // ByanatView
            // 
            this.ByanatView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ByanatView.DisplayMember = null;
            this.ByanatView.GroupItemSize = new System.Drawing.Size(200, 28);
            this.ByanatView.ItemSize = new System.Drawing.Size(200, 28);
            this.ByanatView.Location = new System.Drawing.Point(3, 3);
            this.ByanatView.Margin = new System.Windows.Forms.Padding(0);
            this.ByanatView.Name = "ByanatView";
            this.ByanatView.Size = new System.Drawing.Size(793, 296);
            this.ByanatView.TabIndex = 2;
            this.ByanatView.SelectedItemChanged += new System.EventHandler(this.ByanatView_SelectedItemChanged);
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.AutoScroll = true;
            this.radGridView1.EnterKeyMode = Telerik.WinControls.UI.RadGridViewEnterKeyMode.EnterMovesToNextCell;
            this.radGridView1.Location = new System.Drawing.Point(23, 317);
            this.radGridView1.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGridView1.MasterTemplate.AllowColumnReorder = false;
            this.radGridView1.MasterTemplate.AllowColumnResize = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowDragToGroup = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.radGridView1.MasterTemplate.AllowRowResize = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn7.DataType = typeof(int);
            gridViewDecimalColumn7.FieldName = "ByanID";
            gridViewDecimalColumn7.HeaderText = "ByanID";
            gridViewDecimalColumn7.IsAutoGenerated = true;
            gridViewDecimalColumn7.IsVisible = false;
            gridViewDecimalColumn7.Name = "ByanID";
            gridViewDecimalColumn7.Width = 174;
            gridViewDecimalColumn8.DataType = typeof(int);
            gridViewDecimalColumn8.FieldName = "Byan_ID";
            gridViewDecimalColumn8.HeaderText = "Byan_ID";
            gridViewDecimalColumn8.IsAutoGenerated = true;
            gridViewDecimalColumn8.IsVisible = false;
            gridViewDecimalColumn8.Name = "Byan_ID";
            gridViewDecimalColumn8.Width = 61;
            gridViewTextBoxColumn11.FieldName = "Byan_ParentType";
            gridViewTextBoxColumn11.HeaderText = "النوع";
            gridViewTextBoxColumn11.IsAutoGenerated = true;
            gridViewTextBoxColumn11.Name = "Byan_ParentType";
            gridViewTextBoxColumn11.Width = 126;
            gridViewTextBoxColumn12.FieldName = "Byan_ParentName";
            gridViewTextBoxColumn12.HeaderText = "الأسم";
            gridViewTextBoxColumn12.IsAutoGenerated = true;
            gridViewTextBoxColumn12.Name = "Byan_ParentName";
            gridViewTextBoxColumn12.Width = 126;
            gridViewTextBoxColumn13.FieldName = "Byan_CompanyName";
            gridViewTextBoxColumn13.HeaderText = "الشركة";
            gridViewTextBoxColumn13.IsAutoGenerated = true;
            gridViewTextBoxColumn13.Name = "Byan_CompanyName";
            gridViewTextBoxColumn13.Width = 126;
            gridViewDateTimeColumn3.FieldName = "Byan_StartDate";
            gridViewDateTimeColumn3.HeaderText = "تاريخ البدء";
            gridViewDateTimeColumn3.IsAutoGenerated = true;
            gridViewDateTimeColumn3.Name = "Byan_StartDate";
            gridViewDateTimeColumn3.Width = 126;
            gridViewDateTimeColumn4.FieldName = "Byan_EndDate";
            gridViewDateTimeColumn4.HeaderText = "تاريخ الإنتهاء";
            gridViewDateTimeColumn4.IsAutoGenerated = true;
            gridViewDateTimeColumn4.Name = "Byan_EndDate";
            gridViewDateTimeColumn4.Width = 126;
            gridViewDecimalColumn9.DataType = typeof(int);
            gridViewDecimalColumn9.FieldName = "المتبقي";
            gridViewDecimalColumn9.HeaderText = "المتبقي";
            gridViewDecimalColumn9.IsAutoGenerated = true;
            gridViewDecimalColumn9.Name = "PeriodDays";
            gridViewDecimalColumn9.Width = 123;
            gridViewDecimalColumn10.DataType = typeof(int);
            gridViewDecimalColumn10.FieldName = "Notifications_ID";
            gridViewDecimalColumn10.HeaderText = "Notifications_ID";
            gridViewDecimalColumn10.IsAutoGenerated = true;
            gridViewDecimalColumn10.IsVisible = false;
            gridViewDecimalColumn10.Name = "Notifications_ID";
            gridViewDecimalColumn10.Width = 66;
            gridViewTextBoxColumn14.FieldName = "Byan_Note";
            gridViewTextBoxColumn14.HeaderText = "ملاحظات البيان";
            gridViewTextBoxColumn14.IsAutoGenerated = true;
            gridViewTextBoxColumn14.IsVisible = false;
            gridViewTextBoxColumn14.Name = "Byan_Note";
            gridViewTextBoxColumn14.Width = 79;
            gridViewTextBoxColumn15.FieldName = "Notifications_Note";
            gridViewTextBoxColumn15.HeaderText = "Notifications_Note";
            gridViewTextBoxColumn15.IsAutoGenerated = true;
            gridViewTextBoxColumn15.IsVisible = false;
            gridViewTextBoxColumn15.Name = "Notifications_Note";
            gridViewTextBoxColumn15.Width = 76;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn7,
            gridViewDecimalColumn8,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewDateTimeColumn3,
            gridViewDateTimeColumn4,
            gridViewDecimalColumn9,
            gridViewDecimalColumn10,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15});
            this.radGridView1.MasterTemplate.DataSource = this.notificationViewBindingSource;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.EnableSorting = false;
            this.radGridView1.MasterTemplate.ShowColumnHeaders = false;
            this.radGridView1.MasterTemplate.ShowFilteringRow = false;
            this.radGridView1.MasterTemplate.ShowRowHeaderColumn = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(753, 228);
            this.radGridView1.TabIndex = 5;
            this.radGridView1.ThemeName = "Material";
            this.radGridView1.TitleText = "التنبيهات";
            this.radGridView1.Click += new System.EventHandler(this.radGridView1_Click);
            // 
            // LeftView
            // 
            this.LeftView.Dock = System.Windows.Forms.DockStyle.Right;
            this.LeftView.GroupItemSize = new System.Drawing.Size(200, 28);
            this.LeftView.ItemSize = new System.Drawing.Size(200, 28);
            this.LeftView.Location = new System.Drawing.Point(796, 0);
            this.LeftView.Margin = new System.Windows.Forms.Padding(0);
            this.LeftView.Name = "LeftView";
            this.LeftView.Size = new System.Drawing.Size(269, 551);
            this.LeftView.TabIndex = 1;
            // 
            // navigationPanelOverview
            // 
            this.navigationPanelOverview.Controls.Add(this.radButton1);
            this.navigationPanelOverview.Controls.Add(this.searchContainerOverview);
            this.navigationPanelOverview.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPanelOverview.Location = new System.Drawing.Point(0, 0);
            this.navigationPanelOverview.Margin = new System.Windows.Forms.Padding(0);
            this.navigationPanelOverview.Name = "navigationPanelOverview";
            this.navigationPanelOverview.Size = new System.Drawing.Size(1065, 60);
            this.navigationPanelOverview.TabIndex = 0;
            // 
            // searchContainerOverview
            // 
            this.searchContainerOverview.Controls.Add(this.searchTextBoxOverview);
            this.searchContainerOverview.Controls.Add(this.radPanelEmptyOverview);
            this.searchContainerOverview.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchContainerOverview.Location = new System.Drawing.Point(433, 0);
            this.searchContainerOverview.Name = "searchContainerOverview";
            this.searchContainerOverview.Size = new System.Drawing.Size(632, 60);
            this.searchContainerOverview.TabIndex = 1;
            // 
            // radPanelEmptyOverview
            // 
            this.radPanelEmptyOverview.BackColor = System.Drawing.Color.Transparent;
            this.radPanelEmptyOverview.Dock = System.Windows.Forms.DockStyle.Right;
            this.radPanelEmptyOverview.Location = new System.Drawing.Point(592, 0);
            this.radPanelEmptyOverview.Name = "radPanelEmptyOverview";
            this.radPanelEmptyOverview.Size = new System.Drawing.Size(40, 60);
            this.radPanelEmptyOverview.TabIndex = 1;
            // 
            // BookingsPage
            // 
            this.BookingsPage.Controls.Add(this.bookingsMainContainer);
            this.BookingsPage.Controls.Add(this.navigationPanelBookings);
            this.BookingsPage.ItemSize = new System.Drawing.SizeF(56F, 25F);
            this.BookingsPage.Location = new System.Drawing.Point(6, 36);
            this.BookingsPage.Name = "BookingsPage";
            this.BookingsPage.Size = new System.Drawing.Size(1065, 611);
            this.BookingsPage.Text = "السجلات";
            // 
            // bookingsMainContainer
            // 
            this.bookingsMainContainer.Controls.Add(this.bookingsGrid);
            this.bookingsMainContainer.Controls.Add(this.labelBookings);
            this.bookingsMainContainer.Controls.Add(this.bookingInfoRightPanel);
            this.bookingsMainContainer.Controls.Add(this.bookingsLeftView);
            this.bookingsMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookingsMainContainer.Location = new System.Drawing.Point(0, 60);
            this.bookingsMainContainer.Name = "bookingsMainContainer";
            this.bookingsMainContainer.Size = new System.Drawing.Size(1065, 551);
            this.bookingsMainContainer.TabIndex = 3;
            // 
            // bookingsGrid
            // 
            this.bookingsGrid.Controls.Add(this.radGridView2);
            this.bookingsGrid.Location = new System.Drawing.Point(270, 50);
            this.bookingsGrid.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            // 
            // 
            // 
            this.bookingsGrid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn12.DataType = typeof(int);
            gridViewDecimalColumn12.FieldName = "ID";
            gridViewDecimalColumn12.HeaderText = "ID";
            gridViewDecimalColumn12.IsAutoGenerated = true;
            gridViewDecimalColumn12.Name = "ID";
            gridViewDecimalColumn12.Width = 180;
            gridViewTextBoxColumn18.FieldName = "CarName";
            gridViewTextBoxColumn18.HeaderText = "CarName";
            gridViewTextBoxColumn18.IsAutoGenerated = true;
            gridViewTextBoxColumn18.Name = "CarName";
            gridViewTextBoxColumn18.Width = 180;
            gridViewTextBoxColumn19.FieldName = "CardID";
            gridViewTextBoxColumn19.HeaderText = "CardID";
            gridViewTextBoxColumn19.IsAutoGenerated = true;
            gridViewTextBoxColumn19.Name = "CardID";
            gridViewTextBoxColumn19.Width = 180;
            gridViewTextBoxColumn20.FieldName = "Note";
            gridViewTextBoxColumn20.HeaderText = "Note";
            gridViewTextBoxColumn20.IsAutoGenerated = true;
            gridViewTextBoxColumn20.Name = "Note";
            gridViewTextBoxColumn20.Width = 179;
            this.bookingsGrid.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn12,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20});
            this.bookingsGrid.MasterTemplate.DataSource = this.carsBindingSource;
            this.bookingsGrid.MasterTemplate.ViewDefinition = tableViewDefinition6;
            this.bookingsGrid.Name = "bookingsGrid";
            this.bookingsGrid.Size = new System.Drawing.Size(741, 504);
            this.bookingsGrid.TabIndex = 5;
            // 
            // radGridView2
            // 
            this.radGridView2.Location = new System.Drawing.Point(8, 8);
            this.radGridView2.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            // 
            // 
            // 
            this.radGridView2.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewDecimalColumn11.DataType = typeof(int);
            gridViewDecimalColumn11.FieldName = "ID";
            gridViewDecimalColumn11.HeaderText = "ID";
            gridViewDecimalColumn11.IsAutoGenerated = true;
            gridViewDecimalColumn11.Name = "ID";
            gridViewDecimalColumn11.Width = 316;
            gridViewTextBoxColumn16.FieldName = "Note";
            gridViewTextBoxColumn16.HeaderText = "Note";
            gridViewTextBoxColumn16.IsAutoGenerated = true;
            gridViewTextBoxColumn16.Name = "Note";
            gridViewTextBoxColumn16.Width = 314;
            gridViewTextBoxColumn17.FieldName = "CompanyName";
            gridViewTextBoxColumn17.HeaderText = "CompanyName";
            gridViewTextBoxColumn17.IsAutoGenerated = true;
            gridViewTextBoxColumn17.Name = "CompanyName";
            gridViewTextBoxColumn17.Width = 89;
            this.radGridView2.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn11,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17});
            this.radGridView2.MasterTemplate.DataSource = this.companiesBindingSource;
            this.radGridView2.MasterTemplate.ViewDefinition = tableViewDefinition5;
            this.radGridView2.Name = "radGridView2";
            this.radGridView2.Size = new System.Drawing.Size(741, 504);
            this.radGridView2.TabIndex = 6;
            // 
            // labelBookings
            // 
            this.labelBookings.AutoSize = false;
            this.labelBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBookings.Location = new System.Drawing.Point(270, 0);
            this.labelBookings.Name = "labelBookings";
            this.labelBookings.Size = new System.Drawing.Size(526, 50);
            this.labelBookings.TabIndex = 4;
            this.labelBookings.Text = "السجلات";
            this.labelBookings.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // bookingInfoRightPanel
            // 
            this.bookingInfoRightPanel.Controls.Add(this.editGuestInfo);
            this.bookingInfoRightPanel.Controls.Add(this.bookingInfoUC);
            this.bookingInfoRightPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.bookingInfoRightPanel.Location = new System.Drawing.Point(0, 0);
            this.bookingInfoRightPanel.Name = "bookingInfoRightPanel";
            this.bookingInfoRightPanel.Size = new System.Drawing.Size(270, 551);
            this.bookingInfoRightPanel.TabIndex = 1;
            // 
            // bookingsLeftView
            // 
            this.bookingsLeftView.Dock = System.Windows.Forms.DockStyle.Right;
            this.bookingsLeftView.GroupItemSize = new System.Drawing.Size(200, 28);
            this.bookingsLeftView.ItemSize = new System.Drawing.Size(200, 28);
            this.bookingsLeftView.Location = new System.Drawing.Point(796, 0);
            this.bookingsLeftView.Name = "bookingsLeftView";
            this.bookingsLeftView.Size = new System.Drawing.Size(269, 551);
            this.bookingsLeftView.TabIndex = 2;
            // 
            // navigationPanelBookings
            // 
            this.navigationPanelBookings.Controls.Add(this.searchContainerBookings);
            this.navigationPanelBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPanelBookings.Location = new System.Drawing.Point(0, 0);
            this.navigationPanelBookings.Name = "navigationPanelBookings";
            this.navigationPanelBookings.Size = new System.Drawing.Size(1065, 60);
            this.navigationPanelBookings.TabIndex = 1;
            // 
            // searchContainerBookings
            // 
            this.searchContainerBookings.Controls.Add(this.searchTextBoxBookings);
            this.searchContainerBookings.Controls.Add(this.radPanelEmptyBooking);
            this.searchContainerBookings.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchContainerBookings.Location = new System.Drawing.Point(433, 0);
            this.searchContainerBookings.Name = "searchContainerBookings";
            this.searchContainerBookings.Size = new System.Drawing.Size(632, 60);
            this.searchContainerBookings.TabIndex = 1;
            // 
            // radPanelEmptyBooking
            // 
            this.radPanelEmptyBooking.Dock = System.Windows.Forms.DockStyle.Right;
            this.radPanelEmptyBooking.Location = new System.Drawing.Point(592, 0);
            this.radPanelEmptyBooking.Name = "radPanelEmptyBooking";
            this.radPanelEmptyBooking.Size = new System.Drawing.Size(40, 60);
            this.radPanelEmptyBooking.TabIndex = 1;
            // 
            // radToolbarFormControl2
            // 
            this.radToolbarFormControl2.AutoSize = true;
            this.radToolbarFormControl2.CausesValidation = false;
            this.radToolbarFormControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radToolbarFormControl2.Location = new System.Drawing.Point(0, 0);
            this.radToolbarFormControl2.Name = "radToolbarFormControl2";
            this.radToolbarFormControl2.ShowIcon = true;
            this.radToolbarFormControl2.Size = new System.Drawing.Size(1077, 41);
            this.radToolbarFormControl2.TabIndex = 1;
            // 
            // byanBindingSource
            // 
            this.byanBindingSource.DataMember = "Byan";
            this.byanBindingSource.DataSource = this.contract_ManagementDataSet;
            // 
            // contract_ManagementDataSet
            // 
            this.contract_ManagementDataSet.DataSetName = "Contract_ManagementDataSet";
            this.contract_ManagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // notificationsBindingSource
            // 
            this.notificationsBindingSource.DataMember = "Notifications";
            this.notificationsBindingSource.DataSource = this.contract_ManagementDataSet;
            // 
            // companiesBindingSource
            // 
            this.companiesBindingSource.DataMember = "Companies";
            this.companiesBindingSource.DataSource = this.contract_ManagementDataSet;
            // 
            // carsBindingSource
            // 
            this.carsBindingSource.DataMember = "Cars";
            this.carsBindingSource.DataSource = this.contract_ManagementDataSet;
            // 
            // notificationsTableAdapter
            // 
            this.notificationsTableAdapter.ClearBeforeFill = true;
            // 
            // byanTableAdapter
            // 
            this.byanTableAdapter.ClearBeforeFill = true;
            // 
            // carsTableAdapter
            // 
            this.carsTableAdapter.ClearBeforeFill = true;
            // 
            // companiesTableAdapter
            // 
            this.companiesTableAdapter.ClearBeforeFill = true;
            // 
            // notificationViewBindingSource
            // 
            this.notificationViewBindingSource.DataMember = "NotificationView";
            this.notificationViewBindingSource.DataSource = this.contract_ManagementDataSet;
            // 
            // notificationViewTableAdapter
            // 
            this.notificationViewTableAdapter.ClearBeforeFill = true;
            // 
            // searchTextBoxOverview
            // 
            this.searchTextBoxOverview.AutoSize = false;
            this.searchTextBoxOverview.Location = new System.Drawing.Point(3, 10);
            this.searchTextBoxOverview.Name = "searchTextBoxOverview";
            this.searchTextBoxOverview.NullText = "ابحث عن سائق او سيارة";
            // 
            // 
            // 
            this.searchTextBoxOverview.RootElement.CustomFont = "Roboto";
            this.searchTextBoxOverview.RootElement.CustomFontSize = 8F;
            this.searchTextBoxOverview.Size = new System.Drawing.Size(590, 29);
            this.searchTextBoxOverview.TabIndex = 0;
            // 
            // editGuestInfo
            // 
            this.editGuestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editGuestInfo.Location = new System.Drawing.Point(0, 0);
            this.editGuestInfo.Name = "editGuestInfo";
            this.editGuestInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editGuestInfo.Size = new System.Drawing.Size(270, 551);
            this.editGuestInfo.TabIndex = 1;
            // 
            // bookingInfoUC
            // 
            this.bookingInfoUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookingInfoUC.Location = new System.Drawing.Point(0, 0);
            this.bookingInfoUC.Name = "bookingInfoUC";
            this.bookingInfoUC.Size = new System.Drawing.Size(270, 551);
            this.bookingInfoUC.TabIndex = 0;
            // 
            // searchTextBoxBookings
            // 
            this.searchTextBoxBookings.AutoSize = false;
            this.searchTextBoxBookings.Location = new System.Drawing.Point(3, 10);
            this.searchTextBoxBookings.Name = "searchTextBoxBookings";
            this.searchTextBoxBookings.NullText = "ابحث عن سائق او سيارة او شركة";
            // 
            // 
            // 
            this.searchTextBoxBookings.RootElement.CustomFont = "Roboto";
            this.searchTextBoxBookings.RootElement.CustomFontSize = 8F;
            this.searchTextBoxBookings.Size = new System.Drawing.Size(590, 29);
            this.searchTextBoxBookings.TabIndex = 0;
            // 
            // radButton1
            // 
            this.radButton1.Image = global::DoctorERP_v2_00.Properties.Resources.plus;
            this.radButton1.Location = new System.Drawing.Point(307, 8);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(120, 36);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "إضافة بيان";
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.radButton1.ThemeName = "Material";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radTaskbarButton1
            // 
            this.radTaskbarButton1.OwnerForm = this;
            // 
            // HotelAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 694);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.radToolbarFormControl2);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Name = "HotelAppForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة التعاقدات";
            this.ThemeName = "Material";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HotelApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.OverviewPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overviewMainContainer)).EndInit();
            this.overviewMainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ByanatView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanelOverview)).EndInit();
            this.navigationPanelOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchContainerOverview)).EndInit();
            this.searchContainerOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanelEmptyOverview)).EndInit();
            this.BookingsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookingsMainContainer)).EndInit();
            this.bookingsMainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGrid)).EndInit();
            this.bookingsGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingInfoRightPanel)).EndInit();
            this.bookingInfoRightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookingsLeftView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanelBookings)).EndInit();
            this.navigationPanelBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchContainerBookings)).EndInit();
            this.searchContainerBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanelEmptyBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToolbarFormControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.byanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contract_ManagementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companiesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBoxOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBoxBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.MaterialTheme materialTheme1;
        private Telerik.WinControls.UI.RadPageView mainContainer;
        private Telerik.WinControls.UI.RadPageViewPage OverviewPage;
        private Telerik.WinControls.UI.RadPageViewPage BookingsPage;
        private Telerik.WinControls.UI.RadPanel navigationPanelOverview;
        private Telerik.WinControls.UI.RadListView LeftView;
        private Telerik.WinControls.UI.RadListView ByanatView;
        private Telerik.WinControls.UI.RadPanel searchContainerOverview;
        private SearchTextBox searchTextBoxOverview;
        private Telerik.WinControls.UI.RadPanel radPanelEmptyOverview;
        private Telerik.WinControls.UI.RadPanel navigationPanelBookings;
        private Telerik.WinControls.UI.RadPanel searchContainerBookings;
        private SearchTextBox searchTextBoxBookings;
        private Telerik.WinControls.UI.RadPanel radPanelEmptyBooking;
        private Telerik.WinControls.UI.RadListView bookingsLeftView;
        private Telerik.WinControls.UI.RadPanel bookingsMainContainer;
        private Telerik.WinControls.UI.RadGridView bookingsGrid;
        private Telerik.WinControls.UI.RadLabel labelBookings;
        private Telerik.WinControls.UI.RadPanel overviewMainContainer;
        private Telerik.WinControls.UI.RadPanel bookingInfoRightPanel;
        private BookingInfo bookingInfoUC;
        private EditGuestInfo editGuestInfo;
        private Telerik.WinControls.Themes.MaterialTealTheme materialTealTheme1;
        private Telerik.WinControls.Themes.MaterialPinkTheme materialPinkTheme1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private RadToolbarFormControl radToolbarFormControl1;
        private RadGridView radGridView1;
        private DoctorERP_v2_00.Contract_ManagementDataSet contract_ManagementDataSet;
        private System.Windows.Forms.BindingSource notificationsBindingSource;
        private DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.NotificationsTableAdapter notificationsTableAdapter;
        private System.Windows.Forms.BindingSource byanBindingSource;
        private DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.ByanTableAdapter byanTableAdapter;
        private System.Windows.Forms.BindingSource carsBindingSource;
        private DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.CarsTableAdapter carsTableAdapter;
        private RadToolbarFormControl radToolbarFormControl2;
        private RadGridView radGridView2;
        private System.Windows.Forms.BindingSource companiesBindingSource;
        private DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.CompaniesTableAdapter companiesTableAdapter;
        private System.Windows.Forms.BindingSource notificationViewBindingSource;
        private DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters.NotificationViewTableAdapter notificationViewTableAdapter;
        private RadButton radButton1;
        private RadTaskbarButton radTaskbarButton1;
    }
}