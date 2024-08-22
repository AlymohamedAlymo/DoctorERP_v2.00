using DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters;
using DoctorERP_v2_00.Dialogs;
using HotelApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.SplashScreen;
using static DoctorERP_v2_00.Contract_ManagementDataSet;

namespace HotelApp
{
    partial class HotelAppForm : RadToolbarForm
    {
        #region Initialization
        public HotelAppForm()
        {
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
            this.bookingsLeftView.HotTracking = false;
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
            this.radPanelEmptyBooking.RootElement.EnableElementShadow = false;
            this.bookingsLeftView.RootElement.EnableElementShadow = false;
            this.ByanatView.GroupItemSize = new Size(0, 45);

            //radPanel1.RootElement.BackColor = Color.Transparent;
            ////this.LeftView.VisualItemFormatting += leftView_VisualItemFormatting;
            this.ByanatView.VisualItemCreating += roomsView_VisualItemCreating;
            //this.searchTextBoxOverview.TextChanged += searchTextBox_TextChanged;
            //this.ByanatView.VisualItemFormatting += roomsView_VisualItemFormatting;
            //this.ByanatView.ItemMouseClick += roomsView_ItemMouseClick;
            //this.bookingsLeftView.VisualItemFormatting += bookingsLeftView_VisualItemFormatting;

            RadFlyoutManager.FlyoutClosed -= this.RadFlyoutManager_FlyoutClosed;
            RadFlyoutManager.FlyoutClosed += this.RadFlyoutManager_FlyoutClosed;


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
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.NotificationView' table. You can move, or remove it, as needed.
            this.notificationViewTableAdapter.Fill(this.contract_ManagementDataSet.NotificationView);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Companies' table. You can move, or remove it, as needed.
            this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Byan' table. You can move, or remove it, as needed.
            this.byanTableAdapter.Fill(this.contract_ManagementDataSet.Byan);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Notifications' table. You can move, or remove it, as needed.
            this.notificationsTableAdapter.Fill(this.contract_ManagementDataSet.Notifications);

            this.ByanatView.DataSource = this.contract_ManagementDataSet.Byan;
            this.ByanatView.DisplayMember = "ParentType";


            ListViewDataItemGroup TypeGroup = new ListViewDataItemGroup
            {
                Text = "النوع"
            };
            ListViewDataItemGroup CompaniesGroup = new ListViewDataItemGroup
            {
                Text = "الشركة"
            };

            ListViewDataItem DriverItem = new ListViewDataItem
            {
                Text = "سائق",
                Tag = ByanType.Driver,
                CheckState = Telerik.WinControls.Enumerations.ToggleState.On
            };

            ListViewDataItem CarsItem = new ListViewDataItem
            {
                Text = "سيارة",
                Tag = ByanType.Cars,
                CheckState = Telerik.WinControls.Enumerations.ToggleState.On
            };
            DriverItem.Group = TypeGroup;
            CarsItem.Group = TypeGroup;

            this.LeftView.Groups.AddRange(new ListViewDataItemGroup[] { TypeGroup, CompaniesGroup });

            this.LeftView.Items.AddRange(DriverItem, CarsItem);

           
            foreach (CompaniesRow item in this.contract_ManagementDataSet.Companies.Rows)
            {
                ListViewDataItem roomTypeItem = new ListViewDataItem(item.CompanyName);
                roomTypeItem.Value = item.CompanyName;
                roomTypeItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                roomTypeItem.Group = CompaniesGroup;
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

        //private void UpdateRooms()
        //{
        //    foreach (ListViewDataItem item in this.ByanatView.Items)
        //    {
        //        Room room = item.DataBoundItem as Room;
        //        bool isRoomItemVisible = true;
        //        foreach (ListViewDataItem leftViewItem in LeftView.Items)
        //        {
        //            if (leftViewItem.Group.Text == "STATUS")
        //            {
        //                RoomStatus roomStatus = (RoomStatus)Enum.Parse(typeof(RoomStatus), leftViewItem.Text);
        //                if (leftViewItem.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
        //                {
        //                    isRoomItemVisible = false;
        //                    break;
        //                }
        //            }
        //            else if (leftViewItem.Group.Text == "TYPE")
        //            {
        //                ByanType ByanType = (ByanType)Enum.Parse(typeof(ByanType), leftViewItem.Text);
        //                if (room.Type == ByanType && leftViewItem.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
        //                {
        //                    isRoomItemVisible = false;
        //                    break;
        //                }
        //            }
        //            else if (leftViewItem.Group.Text == "HOUSE KEEPING")
        //            {
        //                if (leftViewItem.Text == "Repair")
        //                {
        //                    if (!room.NeedsRepairs && leftViewItem.CheckState == ToggleState.On)
        //                    {
        //                        isRoomItemVisible = false;
        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    HouseKeepingStatus roomHouseKeepingStatus = (HouseKeepingStatus)Enum.Parse(typeof(HouseKeepingStatus), leftViewItem.Text);
        //                    if (room.HouseKeepingStatus == roomHouseKeepingStatus && leftViewItem.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
        //                    {
        //                        isRoomItemVisible = false;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        if (isRoomItemVisible == false)
        //        {
        //            item.Visible = false;
        //        }
        //        else
        //        {
        //            item.Visible = true;
        //        }
        //    }
        //}

        //private void searchTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.searchTextBoxOverview.Text == string.Empty)
        //    {
        //        this.ByanatView.FilterPredicate = null;
        //    }
        //    else
        //    {
        //        this.ByanatView.FilterPredicate = null;
        //        this.ByanatView.FilterPredicate = FilterRoomsPredicate;
        //    }
        //    this.LeftView.ListViewElement.SynchronizeVisualItems();
        //    UpdateRooms();
        //}

        //private bool FilterRoomsPredicate(ListViewDataItem item)
        //{
        //    if (this.searchTextBoxOverview.Text != string.Empty)
        //    {
        //        Room room = item.DataBoundItem as Room;
        //        if (room.Id.ToString().Contains(this.searchTextBoxOverview.Text))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }

        //    return true;
        //}

        //private void UpdateRoomResources(ListViewDataItemGroup group, string itemText, ToggleState toggleState)
        //{
        //    List<Room> toDelete = new List<Room>();
        //    if (group.Text == "STATUS")
        //    {
        //        if (toggleState == ToggleState.Off)
        //        {
        //            foreach (Room r in rooms)
        //            {
        //                if (r.Status.ToString() == itemText)
        //                {
        //                    toDelete.Add(r);
        //                }
        //            }
        //            while (toDelete.Count > 0)
        //            {
        //                rooms.Remove(toDelete[0]);
        //                toDelete.RemoveAt(0);
        //            }
        //        }
        //        else
        //        {
        //            foreach (Room r in this.Rooms)
        //            {
        //                if (!RoomExists(rooms, r.Id))
        //                {
        //                    ListViewDataItem item = group.Items.FirstOrDefault<ListViewDataItem>(i => i.CheckState == ToggleState.On &&
        //                                                                                              i.Text == r.Status.ToString());
        //                    if (item != null)
        //                    {
        //                        rooms.Add(new Room(r.Id, r.Status, r.Type, r.HouseKeepingStatus, r.NeedsRepairs, r.PricePerDay));
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    else if (group.Text == "TYPE")
        //    {
        //        if (toggleState == ToggleState.Off)
        //        {
        //            foreach (Room r in rooms)
        //            {
        //                if (r.Type.ToString() == itemText)
        //                {
        //                    toDelete.Add(r);
        //                }
        //            }
        //            while (toDelete.Count > 0)
        //            {
        //                rooms.Remove(toDelete[0]);
        //                toDelete.RemoveAt(0);
        //            }
        //        }
        //        else
        //        {
        //            foreach (Room r in this.Rooms)
        //            {
        //                if (!RoomExists(rooms, r.Id))
        //                {
        //                    ListViewDataItem item = group.Items.FirstOrDefault<ListViewDataItem>(i => i.CheckState == ToggleState.On &&
        //                                                                                              i.Text == r.Type.ToString());
        //                    if (item != null)
        //                    {
        //                        rooms.Add(new Room(r.Id, r.Status, r.Type, r.HouseKeepingStatus, r.NeedsRepairs, r.PricePerDay));
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    List<Room> sortedResources = new List<Room>();
        //    foreach (Room r in rooms)
        //    {
        //        sortedResources.Add(r);
        //    }
        //    sortedResources.Sort((Room X, Room Y) => X.Id.CompareTo(Y.Id));
        //    rooms.Clear();
        //    foreach (Room r in sortedResources)
        //    {
        //        rooms.Add(r);
        //    }
        //    //foreach (Resource r in this.ScheduleRadScheduler.Resources)
        //    //{
        //    //    r.Color = Color.White;
        //    //}

        //    //if (this.ScheduleRadScheduler.Resources.Count == 0)
        //    //{
        //    //    this.ScheduleRadScheduler.GroupType = GroupType.None;
        //    //}
        //    //else
        //    //{
        //    //    this.ScheduleRadScheduler.GroupType = GroupType.Resource;
        //    //}
        //    //this.ScheduleRadScheduler.SchedulerElement.RefreshViewElement();
        //    ////RefreshView();
        //}

        //private bool RoomExists(BindingList<Room> rooms, int roomId)
        //{
        //    foreach (Room r in rooms)
        //    {
        //        if (r.Id == roomId)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private void roomsView_ItemMouseClick(object sender, ListViewItemEventArgs e)
        //{
        //    Room room = e.Item.DataBoundItem as Room;
        //    if (room != null)
        //    {
        //        //Booking booking = GetBooking(room);
        //        //this.ShowRoomDetails(room, booking, "Overview");
        //    }
        //}

        //private void bookingsLeftView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        //{
        //    e.VisualItem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        //    SimpleListViewGroupVisualItem groupItem = e.VisualItem as SimpleListViewGroupVisualItem;
        //    if (groupItem != null)
        //    {
        //        e.VisualItem.CustomFont = Utils.MainFontMedium;
        //        e.VisualItem.CustomFontSize = 10.5f;
        //        e.VisualItem.CustomFontStyle = FontStyle.Regular;
        //        groupItem.ToggleElement.Visibility = ElementVisibility.Collapsed;
        //        e.VisualItem.ShowHorizontalLine = false;
        //    }
        //    else
        //    {
        //        SimpleListViewVisualItem simpleItem = e.VisualItem as SimpleListViewVisualItem;
        //        simpleItem.ToggleElement.Margin = new Padding(-20, 0, 0, 0);
        //        e.VisualItem.CustomFont = Utils.MainFont;
        //        e.VisualItem.CustomFontSize = 10.5f;
        //        e.VisualItem.CustomFontStyle = FontStyle.Regular;
        //        e.VisualItem.ResetValue(LightVisualElement.ShowHorizontalLineProperty, Telerik.WinControls.ValueResetFlags.Local);
        //    }
        //}

        //private void navigationButton_Click(object sender, EventArgs e)
        //{
        //    this.ByanatView.ListViewElement.SynchronizeVisualItems();
        //    this.LeftView.ListViewElement.SynchronizeVisualItems();
        //    this.UpdateRooms();
        //}

        //private void leftView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        //{
        //    if (e.VisualItem is SimpleListViewVisualItem)
        //    {
        //        e.VisualItem = new OptionsSimpleListViewVisualItem();
        //    }
        //}

        //private void leftView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        //{
        //    e.VisualItem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
        //    SimpleListViewGroupVisualItem groupItem = e.VisualItem as SimpleListViewGroupVisualItem;
        //    if (groupItem != null)
        //    {
        //        e.VisualItem.CustomFont = Utils.MainFontMedium;
        //        e.VisualItem.CustomFontSize = 10.5f;
        //        e.VisualItem.CustomFontStyle = FontStyle.Regular;

        //        groupItem.ToggleElement.Visibility = ElementVisibility.Collapsed;
        //        e.VisualItem.ShowHorizontalLine = false;
        //    }
        //    else
        //    {
        //        e.VisualItem.CustomFont = Utils.MainFont;
        //        e.VisualItem.CustomFontSize = 10.5f;
        //        e.VisualItem.CustomFontStyle = FontStyle.Regular;
        //        e.VisualItem.ResetValue(LightVisualElement.ShowHorizontalLineProperty, Telerik.WinControls.ValueResetFlags.Local);
        //    }

        //    //////////////////SimpleListViewVisualItem simpleItem = e.VisualItem as SimpleListViewVisualItem;
        //    //////////////////if (simpleItem != null)
        //    //////////////////{
        //    //////////////////    if (e.VisualItem.Data.Group.Text == "TYPE")
        //    //////////////////    {
        //    //////////////////        e.VisualItem.Text = Utils.GetRoomType((ByanType)e.VisualItem.Data.Value);
        //    //////////////////    }
        //    //////////////////    else if (e.VisualItem.Data.Group.Text == "HOUSE KEEPING")
        //    //////////////////    {
        //    //////////////////        if (!e.VisualItem.Text.Contains("Repair"))
        //    //////////////////        {
        //    //////////////////            e.VisualItem.Text = Utils.GetHouseKeepingStatus((HouseKeepingStatus)e.VisualItem.Data.Value);
        //    //////////////////        }
        //    //////////////////    }
        //    //////////////////    simpleItem.ToggleElement.Margin = new Padding(-20, 0, 0, 0);
        //    //////////////////}
        //}

        //private void roomsView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        //{
        //    IconListViewGroupVisualItem groupItem = e.VisualItem as IconListViewGroupVisualItem;
        //    if (groupItem != null)
        //    {
        //        if (groupItem.HasVisibleItems())
        //        {
        //            groupItem.Visibility = ElementVisibility.Visible;
        //        }
        //        else
        //        {
        //            groupItem.Visibility = ElementVisibility.Collapsed;
        //        }
        //        groupItem.Text = Utils.GetRoomType((ByanType)Enum.Parse(typeof(ByanType), groupItem.Text));
        //        e.VisualItem.CustomFont = Utils.MainFont;
        //        e.VisualItem.CustomFontSize = 15;
        //        e.VisualItem.CustomFontStyle = FontStyle.Regular;
        //        groupItem.ToggleElement.Visibility = ElementVisibility.Collapsed;
        //        e.VisualItem.ShowHorizontalLine = false;
        //        e.VisualItem.Padding = new Padding(20, 0, 0, 0);
        //        e.VisualItem.TextAlignment = ContentAlignment.BottomLeft;
        //        e.VisualItem.EnableElementShadow = false;
        //    }
        //    else
        //    {
        //        e.VisualItem.EnableElementShadow = true;
        //        e.VisualItem.ShadowDepth = 1;
        //        e.VisualItem.Padding = new Padding(0);
        //        e.VisualItem.ResetValue(LightVisualElement.TextAlignmentProperty, Telerik.WinControls.ValueResetFlags.Local);
        //    }
        //}

        private void roomsView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is IconListViewVisualItem)
            {
                e.VisualItem = new RoomIconListViewVisualItem();
            }
        }

        private void overviewMainContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void ByanatView_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));


        }


        //internal ListViewDataItem GetItemByRoomId(int roomId)
        //{
        //    foreach (ListViewDataItem item in this.ByanatView.Items)
        //    {
        //        Room room = item.DataBoundItem as Room;
        //        if (room != null && room.Id == roomId)
        //        {
        //            return item;
        //        }
        //    }
        //    return new ListViewDataItem() { Visible = false };
        //}

        ////internal void ShowRoomDetails(Byanat room, Booking booking, string comingFrom)
        ////{
        ////    this.mainContainer.SelectedPage = this.OverviewPage;
        ////    this.roomDetailsUC.Visible = true;
        ////    roomDetailsUC.InitializeData(room, booking, comingFrom);
        ////    this.navigationPanelOverview.Visible = false;
        ////}

        //public void HideRoomDetails()
        //{
        //    this.navigationPanelOverview.Visible = true;
        //}
    }
}