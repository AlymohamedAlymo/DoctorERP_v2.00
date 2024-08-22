using DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters;
using DoctorERP_v2_00.Dialogs;
using Helper.Helpers;
using HotelApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI.SplashScreen;
using static DoctorERP_v2_00.Contract_ManagementDataSet;

namespace HotelApp
{
    partial class HotelAppForm : RadToolbarForm
    {
        #region Initialization
        public HotelAppForm()
        {

            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ar-EG");

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;


            InitializeComponent();

            #region Themes Setting

            ThemeResolutionService.ApplicationThemeName = "Material";

            RadPageViewStripElement stripElement = this.mainContainer.ViewElement as RadPageViewStripElement;
            RadDropDownListElement themesDropDown = new RadDropDownListElement();
            stripElement.StripButtons = ~StripViewButtons.All;
            stripElement.ItemContainer.ButtonsPanel.Children.Add(themesDropDown);
            themesDropDown.MinSize = new System.Drawing.Size(200, 40);
            themesDropDown.EnableElementShadow = false;
            themesDropDown.FindDescendant<FillPrimitive>().BackColor = Color.Transparent;
            themesDropDown.DropDownStyle = RadDropDownStyle.DropDownList;
            stripElement.ItemContainer.ButtonsPanel.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            themesDropDown.Items.AddRange(new RadListDataItem[]
            {
                new RadListDataItem("Material") { Image = DoctorERP_v2_00.Properties.Resources.default_small }, new RadListDataItem("MaterialPink") { Image = DoctorERP_v2_00.Properties.Resources.pink_blue_small },
                new RadListDataItem("MaterialTeal") { Image = DoctorERP_v2_00.Properties.Resources.teal_red_small }, new RadListDataItem("MaterialBlueGrey") { Image = DoctorERP_v2_00.Properties.Resources.blue_grey_green_small }
            });
            themesDropDown.SelectedIndex = 0;
            themesDropDown.SelectedIndexChanged += delegate (object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
            {
                if (e.Position > -1)
                {
                    ThemeResolutionService.ApplicationThemeName = themesDropDown.Items[e.Position].Text;
                }
            };

            stripElement.DrawBorder = false;
            stripElement.ContentArea.DrawBorder = true;
            stripElement.ContentArea.BorderBoxStyle = BorderBoxStyle.FourBorders;
            stripElement.ContentArea.BorderLeftColor = Color.FromArgb(232, 232, 232);
            stripElement.ContentArea.BorderTopWidth = 0;
            stripElement.ContentArea.BorderBottomWidth = 0;
            stripElement.ContentArea.BorderRightWidth = 0;
            stripElement.ContentArea.Padding = new System.Windows.Forms.Padding(0);


            #endregion


            searchContainerOverview.RootElement.EnableElementShadow = false;
            searchContainerBookings.RootElement.EnableElementShadow = false;

            this.overviewMainContainer.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            this.navigationPanelOverview.BackgroundImage = DoctorERP_v2_00.Properties.Resources.fasha_no_borders;
            this.navigationPanelOverview.BackgroundImageLayout = ImageLayout.Stretch;
            this.navigationPanelOverview.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            this.navigationPanelOverview.PanelElement.PanelFill.BackColor = Color.Transparent;
            this.navigationPanelOverview.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            this.searchContainerOverview.PanelElement.PanelFill.BackColor = Color.Transparent;
            this.searchContainerOverview.BackColor = Color.Transparent;
            this.searchContainerOverview.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            this.radPanelEmptyOverview.PanelElement.PanelFill.BackColor = Color.Transparent;
            this.radPanelEmptyOverview.BackColor = Color.Transparent;
            this.radPanelEmptyOverview.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            this.LeftView.ShowGroups = true;
            this.LeftView.EnableGrouping = true;
            this.LeftView.EnableCustomGrouping = true;
            this.LeftView.ShowCheckBoxes = true;
            this.LeftView.AllowEdit = false;
            this.LeftView.RootElement.EnableElementShadow = false;
            this.LeftView.HotTracking = false;
            this.LeftView.ListViewElement.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);

            this.ByanatView.ViewType = ListViewType.IconsView;
            this.ByanatView.ItemSize = new Size(200, 120);
            this.ByanatView.ItemSpacing = 10;
            this.ByanatView.AllowEdit = false;
            this.ByanatView.EnableFiltering = true;
            this.ByanatView.HotTracking = false;

            this.ByanatView.RootElement.BackColor = Color.Transparent;
            this.ByanatView.BackColor = Color.Transparent;
            this.ByanatView.ListViewElement.DrawFill = false;
            this.ByanatView.ListViewElement.ViewElement.BackColor = Color.Transparent;
            this.ByanatView.ListViewElement.Padding = new Padding(-9, 0, 0, 0);

            this.ByanatView.RootElement.EnableElementShadow = false;
            this.overviewMainContainer.BackgroundImage = DoctorERP_v2_00.Properties.Resources.Background;
            this.overviewMainContainer.BackgroundImageLayout = ImageLayout.Stretch;
            this.overviewMainContainer.PanelElement.PanelFill.Visibility = ElementVisibility.Collapsed;
            this.bookingsMainContainer.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;
            this.bookingsMainContainer.BackgroundImage = DoctorERP_v2_00.Properties.Resources.Background;
            this.bookingsMainContainer.BackgroundImageLayout = ImageLayout.Stretch;

            this.radPanelEmptyOverview.RootElement.EnableElementShadow = false;

            this.radPanel5.RootElement.EnableElementShadow = false;

            this.radPanel5.PanelElement.PanelFill.BackColor = Color.Transparent;
            this.radPanel5.BackColor = Color.Transparent;
            this.radPanel5.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;


            this.radPanel3.BackgroundImage = DoctorERP_v2_00.Properties.Resources.fasha_no_borders;
            this.radPanel3.BackgroundImageLayout = ImageLayout.Stretch;
            this.radPanel3.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;

            this.radPanel3.PanelElement.PanelFill.BackColor = Color.Transparent;
            this.radPanel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;

            radPanel4.RootElement.EnableElementShadow = false;

            this.radPanel4.PanelElement.PanelFill.BackColor = Color.Transparent;
            this.radPanel4.BackColor = Color.Transparent;
            this.radPanel4.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;


            this.ByanatView.GroupItemSize = new Size(0, 45);

            this.radLabel1.TextAlignment = ContentAlignment.TopLeft;
            this.radLabel2.TextAlignment = ContentAlignment.TopLeft;
            this.radLabel4.TextAlignment = ContentAlignment.TopLeft;

            
            this.ByanatView.VisualItemCreating += roomsView_VisualItemCreating;
            this.LeftView.VisualItemCreating += leftView_VisualItemCreating;

            RadFlyoutManager.FlyoutClosed -= this.RadFlyoutManager_FlyoutClosed;
            RadFlyoutManager.FlyoutClosed += this.RadFlyoutManager_FlyoutClosed;

            RadGridLocalizationProvider.CurrentProvider = new MyArabicRadGridLocalizationProvider();
            GridViewNotification.TableElement.UpdateView();
            GridViewCompanies.TableElement.UpdateView();
            GridViewDriver.TableElement.UpdateView();
            GridViewCars.TableElement.UpdateView();

            this.RadioButtonDriver.CheckState = CheckState.Checked;
            this.editGuestInfo.idTextBox.NullText = "ادخل رقم البطاقة";
            this.editGuestInfo.nameTextBox.NullText = "ادخل اسم السائق";
            this.editGuestInfo.noteTextBox.NullText = "ادخل الملاحظات أن وجدت";

            this.editGuestInfo.idLabel.Text = "رقم البطاقة";
            this.editGuestInfo.nameLabel.Text = "اسم السائق";

            GridViewDriver.Visible = true;
            GridViewNotification.TableElement.TableHeaderHeight = 30;

            mainContainer.SelectedPage = OverviewPage;

        }


        private void leftView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is SimpleListViewVisualItem)
            {
                e.VisualItem = new OptionsSimpleListViewVisualItem();
            }
        }


        private void RadFlyoutManager_FlyoutClosed(FlyoutClosedEventArgs e)
        {
            Action action = new Action(() =>
            {
                if (e.Content is FlyoutAddByanat)
                {
                    RadCallout callout = new RadCallout();
                    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Up;

                    FlyoutAddByanat content = e.Content as FlyoutAddByanat;
                    if (content != null)
                    {
                        if (content.Result == DialogResult.Yes)
                        {
                            RadFlyoutManager.Show(this, typeof(FlyoutAddCarOrDriver));

                        }

                        //tbAgent Agent = (tbAgent)Bs.Current;
                        //if (content.Result == DialogResult.OK)
                        //{
                        //    DBConnect.StartTransAction();
                        //    radstatus.Text = Agent.note = "غير نشط";
                        //    BtnReservation.Text = "تنشيط";
                        //    Agent.Update();
                        //    if (DBConnect.CommitTransAction())
                        //    {
                        //        ShowDesktopAlert("تنشيط بطاقة عميل", "تنشيط بطاقة العميل", "تمت عملية تنشيط البطاقة بنجاح", "تم تنشيط بطاقة العميل يمكن القيام بالعمليات عليها الأن.");
                        //        FrmMain.DataHasChanged = true;
                        //    }

                        //    string ReserveReason = $"{content.ReserveReason}";
                        //    RadCallout.Show(callout, this.BtnReservation, $"عملية تنشيط بطاقة العميل بسبب{ReserveReason} تمت!", "تمت العملية بنجاح");
                    }
                    else
                        {
                            //RadCallout.Show(callout, this.BtnReservation, "فشلت عملية تنشيط بطاقة العميل!", "فشلت العملية");
                        }
                    }

            });

            this.Invoke(action);
        }

        private void HotelApp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Driver' table. You can move, or remove it, as needed.
            this.driverTableAdapter.Fill(this.contract_ManagementDataSet.Driver);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Companies' table. You can move, or remove it, as needed.
            this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.NotificationView' table. You can move, or remove it, as needed.
            this.notificationViewTableAdapter.Fill(this.contract_ManagementDataSet.NotificationView);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Byan' table. You can move, or remove it, as needed.
            this.byanTableAdapter.Fill(this.contract_ManagementDataSet.Byan);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.NotificationView' table. You can move, or remove it, as needed.
            this.notificationViewTableAdapter.Fill(this.contract_ManagementDataSet.NotificationView);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Companies' table. You can move, or remove it, as needed.
            this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Byan' table. You can move, or remove it, as needed.
            this.byanTableAdapter.Fill(this.contract_ManagementDataSet.Byan);

            this.ByanatView.DataSource = this.contract_ManagementDataSet.Byan;
            this.ByanatView.DisplayMember = "ParentType";


            //ListViewDataItemGroup CompaniesGroup = new ListViewDataItemGroup
            //{
            //    Text = "الشركة"
            //};

            //this.LeftView.Groups.AddRange(new ListViewDataItemGroup[] { CompaniesGroup });

            foreach (CompaniesRow item in this.contract_ManagementDataSet.Companies.Rows)
            {
                ListViewDataItem roomTypeItem = new ListViewDataItem(item.CompanyName);
                roomTypeItem.Value = item.CompanyName;
                int count = contract_ManagementDataSet.Byan.Where(u => u.CompanyName == item.CompanyName).Count();
                roomTypeItem.Tag = count;

                roomTypeItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                //roomTypeItem.Group = CompaniesGroup;
                this.LeftView.Items.Add(roomTypeItem);
            }


            this.ByanatView.ShowGroups = true;
            this.ByanatView.EnableGrouping = true;
            GroupDescriptor groupByValue = new GroupDescriptor(new SortDescriptor[]
            {
                new SortDescriptor("ParentType", ListSortDirection.Ascending)
            });

            this.ByanatView.GroupDescriptors.Add(groupByValue);



        }

        #endregion

        private void roomsView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is IconListViewVisualItem)
            {
                e.VisualItem = new RoomIconListViewVisualItem();
            }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));


        }

        private void overviewMainContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GridViewNotification_Click(object sender, EventArgs e)
        {

        }

        private void radPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GridViewDriver_Click(object sender, EventArgs e)
        {

        }

        private void idSeparator_Click(object sender, EventArgs e)
        {

        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ByanatView_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void mainContainer_SelectedPageChanged(object sender, EventArgs e)
        {

        }
    }
}