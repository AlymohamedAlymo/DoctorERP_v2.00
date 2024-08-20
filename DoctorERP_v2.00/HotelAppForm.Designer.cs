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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.mainContainer = new Telerik.WinControls.UI.RadPageView();
            this.OverviewPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.overviewMainContainer = new Telerik.WinControls.UI.RadPanel();
            this.overviewRoomsView = new Telerik.WinControls.UI.RadListView();
            this.overviewLeftView = new Telerik.WinControls.UI.RadListView();
            this.navigationPanelOverview = new Telerik.WinControls.UI.RadPanel();
            this.searchContainerOverview = new Telerik.WinControls.UI.RadPanel();
            this.searchTextBoxOverview = new CustomControls.SearchTextBox();
            this.radPanelEmptyOverview = new Telerik.WinControls.UI.RadPanel();
            this.BookingsPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.bookingsMainContainer = new Telerik.WinControls.UI.RadPanel();
            this.bookingsGrid = new Telerik.WinControls.UI.RadGridView();
            this.labelBookings = new Telerik.WinControls.UI.RadLabel();
            this.bookingInfoRightPanel = new Telerik.WinControls.UI.RadPanel();
            this.editGuestInfo = new CustomControls.EditGuestInfo();
            this.bookingInfoUC = new CustomControls.BookingInfo();
            this.bookingsLeftView = new Telerik.WinControls.UI.RadListView();
            this.navigationPanelBookings = new Telerik.WinControls.UI.RadPanel();
            this.searchContainerBookings = new Telerik.WinControls.UI.RadPanel();
            this.searchTextBoxBookings = new CustomControls.SearchTextBox();
            this.radPanelEmptyBooking = new Telerik.WinControls.UI.RadPanel();
            this.materialTealTheme1 = new Telerik.WinControls.Themes.MaterialTealTheme();
            this.materialPinkTheme1 = new Telerik.WinControls.Themes.MaterialPinkTheme();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.radToolbarFormControl1 = new Telerik.WinControls.UI.RadToolbarFormControl();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.editGuestInfo1 = new CustomControls.EditGuestInfo();
            this.bookingInfo1 = new CustomControls.BookingInfo();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.SuspendLayout();
            this.OverviewPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overviewMainContainer)).BeginInit();
            this.overviewMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overviewRoomsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overviewLeftView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanelOverview)).BeginInit();
            this.navigationPanelOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchContainerOverview)).BeginInit();
            this.searchContainerOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBoxOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelEmptyOverview)).BeginInit();
            this.BookingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsMainContainer)).BeginInit();
            this.bookingsMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingInfoRightPanel)).BeginInit();
            this.bookingInfoRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsLeftView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanelBookings)).BeginInit();
            this.navigationPanelBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchContainerBookings)).BeginInit();
            this.searchContainerBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBoxBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelEmptyBooking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToolbarFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
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
            this.mainContainer.Size = new System.Drawing.Size(1292, 656);
            this.mainContainer.TabIndex = 0;
            // 
            // OverviewPage
            // 
            this.OverviewPage.Controls.Add(this.overviewMainContainer);
            this.OverviewPage.Controls.Add(this.navigationPanelOverview);
            this.OverviewPage.ItemSize = new System.Drawing.SizeF(55F, 29F);
            this.OverviewPage.Location = new System.Drawing.Point(6, 36);
            this.OverviewPage.Name = "OverviewPage";
            this.OverviewPage.Size = new System.Drawing.Size(1280, 614);
            this.OverviewPage.Text = "الرئيسية";
            // 
            // overviewMainContainer
            // 
            this.overviewMainContainer.Controls.Add(this.overviewRoomsView);
            this.overviewMainContainer.Controls.Add(this.radPanel1);
            this.overviewMainContainer.Controls.Add(this.overviewLeftView);
            this.overviewMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overviewMainContainer.Location = new System.Drawing.Point(0, 60);
            this.overviewMainContainer.Margin = new System.Windows.Forms.Padding(0);
            this.overviewMainContainer.Name = "overviewMainContainer";
            this.overviewMainContainer.Size = new System.Drawing.Size(1280, 554);
            this.overviewMainContainer.TabIndex = 3;
            this.overviewMainContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.overviewMainContainer_Paint);
            // 
            // overviewRoomsView
            // 
            this.overviewRoomsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overviewRoomsView.GroupItemSize = new System.Drawing.Size(200, 28);
            this.overviewRoomsView.ItemSize = new System.Drawing.Size(200, 28);
            this.overviewRoomsView.Location = new System.Drawing.Point(0, 0);
            this.overviewRoomsView.Margin = new System.Windows.Forms.Padding(0);
            this.overviewRoomsView.Name = "overviewRoomsView";
            this.overviewRoomsView.Size = new System.Drawing.Size(1011, 317);
            this.overviewRoomsView.TabIndex = 2;
            this.overviewRoomsView.SelectedItemChanged += new System.EventHandler(this.overviewRoomsView_SelectedItemChanged);
            // 
            // overviewLeftView
            // 
            this.overviewLeftView.Dock = System.Windows.Forms.DockStyle.Right;
            this.overviewLeftView.GroupItemSize = new System.Drawing.Size(200, 28);
            this.overviewLeftView.ItemSize = new System.Drawing.Size(200, 28);
            this.overviewLeftView.Location = new System.Drawing.Point(1011, 0);
            this.overviewLeftView.Margin = new System.Windows.Forms.Padding(0);
            this.overviewLeftView.Name = "overviewLeftView";
            this.overviewLeftView.Size = new System.Drawing.Size(269, 554);
            this.overviewLeftView.TabIndex = 1;
            // 
            // navigationPanelOverview
            // 
            this.navigationPanelOverview.Controls.Add(this.searchContainerOverview);
            this.navigationPanelOverview.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPanelOverview.Location = new System.Drawing.Point(0, 0);
            this.navigationPanelOverview.Margin = new System.Windows.Forms.Padding(0);
            this.navigationPanelOverview.Name = "navigationPanelOverview";
            this.navigationPanelOverview.Size = new System.Drawing.Size(1280, 60);
            this.navigationPanelOverview.TabIndex = 0;
            // 
            // searchContainerOverview
            // 
            this.searchContainerOverview.Controls.Add(this.searchTextBoxOverview);
            this.searchContainerOverview.Controls.Add(this.radPanelEmptyOverview);
            this.searchContainerOverview.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchContainerOverview.Location = new System.Drawing.Point(648, 0);
            this.searchContainerOverview.Name = "searchContainerOverview";
            this.searchContainerOverview.Size = new System.Drawing.Size(632, 60);
            this.searchContainerOverview.TabIndex = 1;
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
            this.BookingsPage.ItemSize = new System.Drawing.SizeF(58F, 29F);
            this.BookingsPage.Location = new System.Drawing.Point(6, 36);
            this.BookingsPage.Name = "BookingsPage";
            this.BookingsPage.Size = new System.Drawing.Size(1280, 614);
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
            this.bookingsMainContainer.Size = new System.Drawing.Size(1280, 554);
            this.bookingsMainContainer.TabIndex = 3;
            // 
            // bookingsGrid
            // 
            this.bookingsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookingsGrid.Location = new System.Drawing.Point(269, 50);
            this.bookingsGrid.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            // 
            // 
            // 
            this.bookingsGrid.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.bookingsGrid.Name = "bookingsGrid";
            this.bookingsGrid.Size = new System.Drawing.Size(741, 504);
            this.bookingsGrid.TabIndex = 5;
            this.bookingsGrid.Click += new System.EventHandler(this.bookingsGrid_Click);
            // 
            // labelBookings
            // 
            this.labelBookings.AutoSize = false;
            this.labelBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBookings.Location = new System.Drawing.Point(269, 0);
            this.labelBookings.Name = "labelBookings";
            this.labelBookings.Size = new System.Drawing.Size(741, 50);
            this.labelBookings.TabIndex = 4;
            this.labelBookings.Text = "السجلات";
            this.labelBookings.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // bookingInfoRightPanel
            // 
            this.bookingInfoRightPanel.Controls.Add(this.editGuestInfo);
            this.bookingInfoRightPanel.Controls.Add(this.bookingInfoUC);
            this.bookingInfoRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.bookingInfoRightPanel.Location = new System.Drawing.Point(1010, 0);
            this.bookingInfoRightPanel.Name = "bookingInfoRightPanel";
            this.bookingInfoRightPanel.Size = new System.Drawing.Size(270, 554);
            this.bookingInfoRightPanel.TabIndex = 1;
            // 
            // editGuestInfo
            // 
            this.editGuestInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editGuestInfo.Location = new System.Drawing.Point(0, 0);
            this.editGuestInfo.Name = "editGuestInfo";
            this.editGuestInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editGuestInfo.Size = new System.Drawing.Size(270, 554);
            this.editGuestInfo.TabIndex = 1;
            this.editGuestInfo.Load += new System.EventHandler(this.editGuestInfo_Load);
            // 
            // bookingInfoUC
            // 
            this.bookingInfoUC.Booking = null;
            this.bookingInfoUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookingInfoUC.Location = new System.Drawing.Point(0, 0);
            this.bookingInfoUC.Name = "bookingInfoUC";
            this.bookingInfoUC.Room = null;
            this.bookingInfoUC.Size = new System.Drawing.Size(270, 554);
            this.bookingInfoUC.TabIndex = 0;
            // 
            // bookingsLeftView
            // 
            this.bookingsLeftView.Dock = System.Windows.Forms.DockStyle.Left;
            this.bookingsLeftView.GroupItemSize = new System.Drawing.Size(200, 28);
            this.bookingsLeftView.ItemSize = new System.Drawing.Size(200, 28);
            this.bookingsLeftView.Location = new System.Drawing.Point(0, 0);
            this.bookingsLeftView.Name = "bookingsLeftView";
            this.bookingsLeftView.Size = new System.Drawing.Size(269, 554);
            this.bookingsLeftView.TabIndex = 2;
            // 
            // navigationPanelBookings
            // 
            this.navigationPanelBookings.Controls.Add(this.searchContainerBookings);
            this.navigationPanelBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationPanelBookings.Location = new System.Drawing.Point(0, 0);
            this.navigationPanelBookings.Name = "navigationPanelBookings";
            this.navigationPanelBookings.Size = new System.Drawing.Size(1280, 60);
            this.navigationPanelBookings.TabIndex = 1;
            // 
            // searchContainerBookings
            // 
            this.searchContainerBookings.Controls.Add(this.searchTextBoxBookings);
            this.searchContainerBookings.Controls.Add(this.radPanelEmptyBooking);
            this.searchContainerBookings.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchContainerBookings.Location = new System.Drawing.Point(648, 0);
            this.searchContainerBookings.Name = "searchContainerBookings";
            this.searchContainerBookings.Size = new System.Drawing.Size(632, 60);
            this.searchContainerBookings.TabIndex = 1;
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
            // radPanelEmptyBooking
            // 
            this.radPanelEmptyBooking.Dock = System.Windows.Forms.DockStyle.Right;
            this.radPanelEmptyBooking.Location = new System.Drawing.Point(592, 0);
            this.radPanelEmptyBooking.Name = "radPanelEmptyBooking";
            this.radPanelEmptyBooking.Size = new System.Drawing.Size(40, 60);
            this.radPanelEmptyBooking.TabIndex = 1;
            // 
            // radToolbarFormControl1
            // 
            this.radToolbarFormControl1.AutoSize = true;
            this.radToolbarFormControl1.CausesValidation = false;
            this.radToolbarFormControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radToolbarFormControl1.Location = new System.Drawing.Point(0, 0);
            this.radToolbarFormControl1.Name = "radToolbarFormControl1";
            this.radToolbarFormControl1.Size = new System.Drawing.Size(1292, 41);
            this.radToolbarFormControl1.TabIndex = 1;
            this.radToolbarFormControl1.Click += new System.EventHandler(this.radToolbarFormControl1_Click);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radGridView1);
            this.radPanel1.Controls.Add(this.radLabel1);
            this.radPanel1.Controls.Add(this.radPanel2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPanel1.Location = new System.Drawing.Point(0, 317);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1011, 237);
            this.radPanel1.TabIndex = 4;
            this.radPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.radPanel1_Paint);
            // 
            // radGridView1
            // 
            this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGridView1.Location = new System.Drawing.Point(0, 50);
            this.radGridView1.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(741, 187);
            this.radGridView1.TabIndex = 5;
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(741, 50);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "السجلات";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.editGuestInfo1);
            this.radPanel2.Controls.Add(this.bookingInfo1);
            this.radPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.radPanel2.Location = new System.Drawing.Point(741, 0);
            this.radPanel2.Name = "radPanel2";
            this.radPanel2.Size = new System.Drawing.Size(270, 237);
            this.radPanel2.TabIndex = 1;
            // 
            // editGuestInfo1
            // 
            this.editGuestInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editGuestInfo1.Location = new System.Drawing.Point(0, 0);
            this.editGuestInfo1.Name = "editGuestInfo1";
            this.editGuestInfo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.editGuestInfo1.Size = new System.Drawing.Size(270, 237);
            this.editGuestInfo1.TabIndex = 1;
            // 
            // bookingInfo1
            // 
            this.bookingInfo1.Booking = null;
            this.bookingInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookingInfo1.Location = new System.Drawing.Point(0, 0);
            this.bookingInfo1.Name = "bookingInfo1";
            this.bookingInfo1.Room = null;
            this.bookingInfo1.Size = new System.Drawing.Size(270, 237);
            this.bookingInfo1.TabIndex = 0;
            // 
            // HotelAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 697);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.radToolbarFormControl1);
            this.Name = "HotelAppForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HotelApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.OverviewPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overviewMainContainer)).EndInit();
            this.overviewMainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overviewRoomsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overviewLeftView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanelOverview)).EndInit();
            this.navigationPanelOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchContainerOverview)).EndInit();
            this.searchContainerOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBoxOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelEmptyOverview)).EndInit();
            this.BookingsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookingsMainContainer)).EndInit();
            this.bookingsMainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingInfoRightPanel)).EndInit();
            this.bookingInfoRightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookingsLeftView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationPanelBookings)).EndInit();
            this.navigationPanelBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchContainerBookings)).EndInit();
            this.searchContainerBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBoxBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanelEmptyBooking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToolbarFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
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
        private Telerik.WinControls.UI.RadListView overviewLeftView;
        private Telerik.WinControls.UI.RadListView overviewRoomsView;
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
        private RadPanel radPanel1;
        private RadGridView radGridView1;
        private RadLabel radLabel1;
        private RadPanel radPanel2;
        private EditGuestInfo editGuestInfo1;
        private BookingInfo bookingInfo1;
    }
}