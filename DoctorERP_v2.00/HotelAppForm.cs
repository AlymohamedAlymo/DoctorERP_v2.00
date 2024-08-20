using CustomControls;
using DoctorERP_v2_00.Data;
using HotelApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace HotelApp
{
    partial class HotelAppForm : RadToolbarForm
    {
        #region Fields

        private GridViewRowInfo draggedRowInfo = null;
        private string reportsInterval;
        private BindingList<Room> rooms = new BindingList<Room>();
        private BindingList<Guest> guests = new BindingList<Guest>();
        private BindingList<Booking> bookings = new BindingList<Booking>();
        private BindingList<HouseKeeper> houseKeepers = new BindingList<HouseKeeper>();
        private RoomDetailsUC roomDetailsUC = new RoomDetailsUC();
        private CultureInfo culture = new CultureInfo("ar-EG");

        #endregion

        #region Constructor & Initialization
        public HotelAppForm()
        {
            InitializeComponent();

            ThemeResolutionService.ApplicationThemeName = "Material";

            culture.DateTimeFormat.DayNames = new string[7]
            {
                "Sun",
                "Mon",
                "Tue",
                "Wed",
                "Thu",
                "Fri",
                "Sat"
            };
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.OverviewPage.Controls.Add(roomDetailsUC);
            roomDetailsUC.Visible = false;
            roomDetailsUC.Dock = DockStyle.Fill;
            this.OverviewPage.Controls.SetChildIndex(roomDetailsUC, 0);
            this.navigationPanelOverview.Visible = true;

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
                    AdjustMainColor();
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
            searchContainerOverview.RootElement.EnableElementShadow = false;
            searchContainerBookings.RootElement.EnableElementShadow = false;

            this.WireEvents();
            this.InitOverviewPage();
            this.InitBookingsPage();
        }

        private void InitOverviewPage()
        {
            #region OverviewPage

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

            this.overviewLeftView.ShowGroups = true;
            this.overviewLeftView.EnableGrouping = true;
            this.overviewLeftView.EnableCustomGrouping = true;
            this.overviewLeftView.ShowCheckBoxes = true;
            this.overviewLeftView.AllowEdit = false;
            this.overviewLeftView.RootElement.EnableElementShadow = false;
            this.overviewLeftView.HotTracking = false;
            this.bookingsLeftView.HotTracking = false;
            this.overviewLeftView.ListViewElement.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);

            this.PopulateData();

            this.overviewRoomsView.ShowGroups = true;
            this.overviewRoomsView.EnableGrouping = true;
            GroupDescriptor groupByValue = new GroupDescriptor(new SortDescriptor[]
            {
                new SortDescriptor("Type", ListSortDirection.Ascending)
            });

            this.overviewRoomsView.GroupDescriptors.Add(groupByValue);

            this.overviewRoomsView.ViewType = ListViewType.IconsView;
            this.overviewRoomsView.ItemSize = new Size(200, 120);
            this.overviewRoomsView.ItemSpacing = 10;
            this.overviewRoomsView.AllowEdit = false;
            this.overviewRoomsView.EnableFiltering = true;
            this.overviewRoomsView.HotTracking = false;

            this.overviewRoomsView.RootElement.BackColor = Color.Transparent;
            this.overviewRoomsView.BackColor = Color.Transparent;
            this.overviewRoomsView.ListViewElement.DrawFill = false;
            this.overviewRoomsView.ListViewElement.ViewElement.BackColor = Color.Transparent;
            this.overviewRoomsView.ListViewElement.Padding = new Padding(-9, 0, 0, 0);

            this.overviewRoomsView.RootElement.EnableElementShadow = false;
            this.overviewMainContainer.BackgroundImage = DoctorERP_v2_00.Properties.Resources.Background;
            this.overviewMainContainer.BackgroundImageLayout = ImageLayout.Stretch;
            this.overviewMainContainer.PanelElement.PanelFill.Visibility = ElementVisibility.Collapsed;
            this.bookingsMainContainer.PanelElement.PanelFill.Visibility = ElementVisibility.Hidden;
            this.bookingsMainContainer.BackgroundImage = DoctorERP_v2_00.Properties.Resources.Background;
            this.bookingsMainContainer.BackgroundImageLayout = ImageLayout.Stretch;

            this.radPanelEmptyOverview.RootElement.EnableElementShadow = false;
            this.radPanelEmptyBooking.RootElement.EnableElementShadow = false;
            this.bookingsLeftView.RootElement.EnableElementShadow = false;
            this.overviewRoomsView.GroupItemSize = new Size(0, 45);

            #endregion
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.reportsDaysToggleButton.PerformClick();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.AdjustMainColor();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void WireEvents()
        {
            //this.scheduleListView.VisualItemFormatting += leftView_VisualItemFormatting;
            //this.scheduleListView.SelectedItemChanging += view_SelectedItemChanging;
            //this.scheduleListView.VisualItemCreating += leftView_VisualItemCreating;
            //this.scheduleListView.ItemCheckedChanged += scheduleListView_ItemCheckedChanged;

            this.overviewLeftView.SelectedItemChanging += view_SelectedItemChanging;
            //this.houseKeepingListView.SelectedItemChanging += view_SelectedItemChanging;
            this.overviewLeftView.GroupExpanding += leftView_GroupExpanding;
            this.BookingsListView.GroupExpanding += leftView_GroupExpanding;
            //this.houseKeepingListView.GroupExpanding += leftView_GroupExpanding;
            //this.scheduleListView.GroupExpanding += leftView_GroupExpanding;
            this.overviewLeftView.ItemCheckedChanged += leftView_ItemCheckedChanged;
            this.overviewLeftView.VisualItemFormatting += leftView_VisualItemFormatting;
            this.overviewLeftView.VisualItemCreating += leftView_VisualItemCreating;
            this.overviewRoomsView.VisualItemCreating += roomsView_VisualItemCreating;
            this.searchTextBoxOverview.TextChanged += searchTextBox_TextChanged;

            this.overviewRoomsView.VisualItemFormatting += roomsView_VisualItemFormatting;
            this.overviewRoomsView.ItemMouseClick += roomsView_ItemMouseClick;

            this.bookingsLeftView.VisualItemFormatting += bookingsLeftView_VisualItemFormatting;

            this.bookingsLeftView.SelectedItemChanging += view_SelectedItemChanging;
            this.overviewRoomsView.GroupExpanding += roomsView_GroupExpanding;
            this.overviewRoomsView.SelectedItemChanging += roomsView_SelectedItemChanging;
            this.bookingInfoRightPanel.VisibleChanged += bookingInfoRightPanel_VisibleChanged;
            this.bookingsGrid.CurrentRowChanged += bookingsGrid_CurrentRowChanged;
            this.bookingsGrid.CreateCell += bookingsGrid_CreateCell;
            this.bookingsGrid.ViewCellFormatting += bookingsGrid_ViewCellFormatting;

            this.bookingsLeftView.VisualItemCreating += leftView_VisualItemCreating;
            this.bookingsLeftView.ItemCheckedChanged += bookingsLeftView_ItemCheckedChanged;


            this.bookingsGrid.CustomFiltering += bookingsGrid_CustomFiltering;
            this.searchTextBoxBookings.TextChanged += searchTextBoxBookings_TextChanged;
            this.PageView.SelectedPageChanged += PageView_SelectedPageChanged;
        }

        #region TitleBar

        private void HotelApp_Load(object sender, EventArgs e)
        {
            LightVisualElement lve = new LightVisualElement();
            ////lve.Image = DoctorERP_v2_00.Properties.Resources.stars;
            //this.FormElement.TitleBar.Children[2].Children.Insert(0, lve);
            lve.Margin = new Padding(15, 0, 0, 0);
            //this.FormElement.TitleBar.TitlePrimitive.Margin = new Padding(2, 2, 0, 0);
            //this.FormElement.TitleBar.TitlePrimitive.CustomFont = Utils.MainFont;
            //this.FormElement.TitleBar.TitlePrimitive.CustomFontSize = 10.5f;
            //this.FormElement.TitleBar.TitlePrimitive.TextAlignment = ContentAlignment.MiddleLeft;
            this.Text = "Hotel App";
            this.Size = new System.Drawing.Size(1365, 900);
            this.Icon = DoctorERP_v2_00.Properties.Resources.starsIcon;
            this.ShowIcon = true;
            //this.FormElement.TitleBar.IconPrimitive.Opacity = 0;
            //this.FormElement.TitleBar.TitlePrimitive.PositionOffset = new SizeF(-1 * this.Icon.Width, 0);


        }
        #endregion

        #endregion

        #region Properties

        public BindingList<Guest> Guests
        {
            get
            {
                return this.guests;
            }
        }

        public RadListView BookingsListView
        {
            get
            {
                return this.bookingsLeftView;
            }
        }

        public BindingList<HouseKeeper> HouseKeepers
        {
            get
            {
                return this.houseKeepers;
            }
        }

        public RadPanel NavigationPanel
        {
            get
            {
                return this.navigationPanelOverview;
            }
        }

        //public DateTime BookingsDate
        //{
        //    get
        //    {
        //        return this.dateNavigatorBookings.CurrentDate;
        //    }
        //    set
        //    {
        //        this.dateNavigatorBookings.DateTimePicker.Value = value;
        //    }
        //}

        public BindingList<Booking> Bookings
        {
            get
            {
                return this.bookings;
            }
        }

        public BindingList<Room> Rooms
        {
            get
            {
                return this.rooms;
            }
        }

        public RadListView RoomsListView
        {
            get
            {
                return this.overviewRoomsView;
            }
        }

        public RadPageView PageView
        {
            get
            {
                return this.mainContainer;
            }
        }

        public SearchTextBox OverviewSearch
        {
            get
            {
                return this.searchTextBoxOverview;
            }
        }

        #endregion
        private void AdjustMainColor()
        {
            //Utils.MainThemeColor = this.FormElement.TitleBar.FillPrimitive.BackColor;

            //////Utils.MainThemeColor = Color.DarkGreen;


            this.RoomsListView.ListViewElement.SynchronizeVisualItems();
            //this.reportsCurrentStatusLabel.ForeColor = Utils.MainThemeColor;
            //this.reportsBookingsByTypeLabel.ForeColor = Utils.MainThemeColor;
            this.labelBookings.ForeColor = Utils.MainThemeColor;
            ////this.scheduleRadSchedulerHeader.PanelElement.PanelFill.BackColor = Utils.MainThemeColor;
            ////this.ScheduleRadScheduler.SchedulerElement.RefreshViewElement();
            //RefreshView();
            //this.houseKeepingSchedulerHeaderLabel.LabelElement.LabelFill.BackColor = Utils.MainThemeColor;
            //this.notAssignedLabel.LabelElement.LabelFill.BackColor = Utils.MainThemeColor;
            GridViewRowInfo currentRow = this.bookingsGrid.CurrentRow;
            this.bookingsGrid.CurrentRow = null;
            this.bookingsGrid.CurrentRow = currentRow;
        }

        private void ActiveView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == "StartDate")
            //{
            //    this.houseKeepingDateNavigator.DateTimePicker.Value = this.houseKeepingScheduler.ActiveView.StartDate;
            //}
        }

        private object ConvertFrom(object item)
        {
            EventId resourceId = item as EventId;
            if (item != null && resourceId.KeyValue is int)
            {
                return resourceId.KeyValue;
            }

            return DBNull.Value;
        }

        private object ConvertTo(object item)
        {
            return new EventId(item);
        }

        private void view_SelectedItemChanging(object sender, ListViewItemCancelEventArgs e)
        {
            e.Cancel = true;
        }


        private void roomsView_SelectedItemChanging(object sender, ListViewItemCancelEventArgs e)
        {
            e.Cancel = e.Item is ListViewDataItemGroup;
        }

        private void roomsView_GroupExpanding(object sender, ListViewGroupCancelEventArgs e)
        {
            e.Cancel = e.Group.Expanded;
        }




        private void leftView_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            UpdateRooms();
            this.overviewLeftView.ListViewElement.SynchronizeVisualItems();
            this.overviewRoomsView.ListViewElement.SynchronizeVisualItems();
        }

        private void UpdateRooms()
        {
            foreach (ListViewDataItem item in this.overviewRoomsView.Items)
            {
                Room room = item.DataBoundItem as Room;
                bool isRoomItemVisible = true;
                foreach (ListViewDataItem leftViewItem in overviewLeftView.Items)
                {
                    if (leftViewItem.Group.Text == "STATUS")
                    {
                        RoomStatus roomStatus = (RoomStatus)Enum.Parse(typeof(RoomStatus), leftViewItem.Text);
                        if (leftViewItem.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
                        {
                            isRoomItemVisible = false;
                            break;
                        }
                    }
                    else if (leftViewItem.Group.Text == "TYPE")
                    {
                        ByanType ByanType = (ByanType)Enum.Parse(typeof(ByanType), leftViewItem.Text);
                        if (room.Type == ByanType && leftViewItem.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
                        {
                            isRoomItemVisible = false;
                            break;
                        }
                    }
                    else if (leftViewItem.Group.Text == "HOUSE KEEPING")
                    {
                        if (leftViewItem.Text == "Repair")
                        {
                            if (!room.NeedsRepairs && leftViewItem.CheckState == ToggleState.On)
                            {
                                isRoomItemVisible = false;
                                break;
                            }
                        }
                        else
                        {
                            HouseKeepingStatus roomHouseKeepingStatus = (HouseKeepingStatus)Enum.Parse(typeof(HouseKeepingStatus), leftViewItem.Text);
                            if (room.HouseKeepingStatus == roomHouseKeepingStatus && leftViewItem.CheckState == Telerik.WinControls.Enumerations.ToggleState.Off)
                            {
                                isRoomItemVisible = false;
                                break;
                            }
                        }
                    }
                }
                if (isRoomItemVisible == false)
                {
                    item.Visible = false;
                }
                else
                {
                    item.Visible = true;
                }
            }
        }

        private bool GetBoolValue(ToggleState toggleState)
        {
            bool value = false;
            if (toggleState == ToggleState.On)
            {
                value = true;
            }
            return value;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.searchTextBoxOverview.Text == string.Empty)
            {
                this.overviewRoomsView.FilterPredicate = null;
            }
            else
            {
                this.overviewRoomsView.FilterPredicate = null;
                this.overviewRoomsView.FilterPredicate = FilterRoomsPredicate;
            }
            this.overviewLeftView.ListViewElement.SynchronizeVisualItems();
            UpdateRooms();
        }

        private bool FilterRoomsPredicate(ListViewDataItem item)
        {
            if (this.searchTextBoxOverview.Text != string.Empty)
            {
                Room room = item.DataBoundItem as Room;
                if (room.Id.ToString().Contains(this.searchTextBoxOverview.Text))
                {
                    return true;
                }
                //Booking booking = GetBooking(room);
                //if (booking != null && booking.Name.ToLower().Contains(this.searchTextBoxOverview.Text.ToLower()))
                //{
                //    return true;
                //}
                return false;
            }

            return true;
        }

        //public Booking GetBooking(Room room)
        //{
        //    foreach (Booking booking in this.Bookings)
        //    {
        //        if (booking.RoomId == room.Id && booking.From <= this.dateNavigatorOverview.CurrentDate &&
        //            booking.To >= this.dateNavigatorOverview.CurrentDate)
        //        {
        //            return booking;
        //        }
        //    }

        //    return null;
        //}



        private void leftView_GroupExpanding(object sender, ListViewGroupCancelEventArgs e)
        {
            e.Cancel = true;
        }


        private void scheduleListView_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            UpdateRoomResources(e.Item.Group, e.Item.Text, e.Item.CheckState);
            //this.scheduleListView.ListViewElement.SynchronizeVisualItems();
        }

        private void UpdateRoomResources(ListViewDataItemGroup group, string itemText, ToggleState toggleState)
        {
            //SchedulerBindingDataSource schedulerSource = this.ScheduleRadScheduler.DataSource as SchedulerBindingDataSource;
            //BindingList<Room> rooms = schedulerSource.ResourceProvider.DataSource as BindingList<Room>;
            List<Room> toDelete = new List<Room>();
            if (group.Text == "STATUS")
            {
                if (toggleState == ToggleState.Off)
                {
                    foreach (Room r in rooms)
                    {
                        if (r.Status.ToString() == itemText)
                        {
                            toDelete.Add(r);
                        }
                    }
                    while (toDelete.Count > 0)
                    {
                        rooms.Remove(toDelete[0]);
                        toDelete.RemoveAt(0);
                    }
                }
                else
                {
                    foreach (Room r in this.Rooms)
                    {
                        if (!RoomExists(rooms, r.Id))
                        {
                            ListViewDataItem item = group.Items.FirstOrDefault<ListViewDataItem>(i => i.CheckState == ToggleState.On &&
                                                                                                      i.Text == r.Status.ToString());
                            if (item != null)
                            {
                                rooms.Add(new Room(r.Id, r.Status, r.Type, r.HouseKeepingStatus, r.NeedsRepairs, r.PricePerDay));
                            }
                        }
                    }
                }
            }
            else if (group.Text == "TYPE")
            {
                if (toggleState == ToggleState.Off)
                {
                    foreach (Room r in rooms)
                    {
                        if (r.Type.ToString() == itemText)
                        {
                            toDelete.Add(r);
                        }
                    }
                    while (toDelete.Count > 0)
                    {
                        rooms.Remove(toDelete[0]);
                        toDelete.RemoveAt(0);
                    }
                }
                else
                {
                    foreach (Room r in this.Rooms)
                    {
                        if (!RoomExists(rooms, r.Id))
                        {
                            ListViewDataItem item = group.Items.FirstOrDefault<ListViewDataItem>(i => i.CheckState == ToggleState.On &&
                                                                                                      i.Text == r.Type.ToString());
                            if (item != null)
                            {
                                rooms.Add(new Room(r.Id, r.Status, r.Type, r.HouseKeepingStatus, r.NeedsRepairs, r.PricePerDay));
                            }
                        }
                    }
                }
            }

            List<Room> sortedResources = new List<Room>();
            foreach (Room r in rooms)
            {
                sortedResources.Add(r);
            }
            sortedResources.Sort((Room X, Room Y) => X.Id.CompareTo(Y.Id));
            rooms.Clear();
            foreach (Room r in sortedResources)
            {
                rooms.Add(r);
            }
            //foreach (Resource r in this.ScheduleRadScheduler.Resources)
            //{
            //    r.Color = Color.White;
            //}

            //if (this.ScheduleRadScheduler.Resources.Count == 0)
            //{
            //    this.ScheduleRadScheduler.GroupType = GroupType.None;
            //}
            //else
            //{
            //    this.ScheduleRadScheduler.GroupType = GroupType.Resource;
            //}
            //this.ScheduleRadScheduler.SchedulerElement.RefreshViewElement();
            ////RefreshView();
        }

        private bool RoomExists(BindingList<Room> rooms, int roomId)
        {
            foreach (Room r in rooms)
            {
                if (r.Id == roomId)
                {
                    return true;
                }
            }
            return false;
        }

        private void PageView_SelectedPageChanged(object sender, EventArgs e)
        {
            this.roomDetailsUC.Visible = false;
            if (this.PageView.SelectedPage == this.OverviewPage)
            {
                navigationPanelOverview.Visible = true;
                this.RoomsListView.ListViewElement.SynchronizeVisualItems();
            }
            //else if (this.PageView.SelectedPage != this.SchedulePage)
            //{
            //    this.ScheduleRadScheduler.SelectionBehavior.ResetSelection();
            //    this.scheduleBookingPanel.Visible = false;
            //}
        }

        private void roomsView_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            Room room = e.Item.DataBoundItem as Room;
            if (room != null)
            {
                //Booking booking = GetBooking(room);
                //this.ShowRoomDetails(room, booking, "Overview");
            }
        }

        private void bookingsLeftView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {
            e.VisualItem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            SimpleListViewGroupVisualItem groupItem = e.VisualItem as SimpleListViewGroupVisualItem;
            if (groupItem != null)
            {
                e.VisualItem.CustomFont = Utils.MainFontMedium;
                e.VisualItem.CustomFontSize = 10.5f;
                e.VisualItem.CustomFontStyle = FontStyle.Regular;
                groupItem.ToggleElement.Visibility = ElementVisibility.Collapsed;
                e.VisualItem.ShowHorizontalLine = false;
            }
            else
            {
                SimpleListViewVisualItem simpleItem = e.VisualItem as SimpleListViewVisualItem;
                simpleItem.ToggleElement.Margin = new Padding(-20, 0, 0, 0);
                e.VisualItem.CustomFont = Utils.MainFont;
                e.VisualItem.CustomFontSize = 10.5f;
                e.VisualItem.CustomFontStyle = FontStyle.Regular;
                e.VisualItem.ResetValue(LightVisualElement.ShowHorizontalLineProperty, Telerik.WinControls.ValueResetFlags.Local);
            }
        }

        private void navigationButton_Click(object sender, EventArgs e)
        {
            this.overviewRoomsView.ListViewElement.SynchronizeVisualItems();
            this.overviewLeftView.ListViewElement.SynchronizeVisualItems();
            this.UpdateRooms();
        }

        private void leftView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is SimpleListViewVisualItem)
            {
                e.VisualItem = new OptionsSimpleListViewVisualItem();
            }
        }

        private void leftView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {
            e.VisualItem.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            SimpleListViewGroupVisualItem groupItem = e.VisualItem as SimpleListViewGroupVisualItem;
            if (groupItem != null)
            {
                e.VisualItem.CustomFont = Utils.MainFontMedium;
                e.VisualItem.CustomFontSize = 10.5f;
                e.VisualItem.CustomFontStyle = FontStyle.Regular;

                groupItem.ToggleElement.Visibility = ElementVisibility.Collapsed;
                e.VisualItem.ShowHorizontalLine = false;
            }
            else
            {
                e.VisualItem.CustomFont = Utils.MainFont;
                e.VisualItem.CustomFontSize = 10.5f;
                e.VisualItem.CustomFontStyle = FontStyle.Regular;
                e.VisualItem.ResetValue(LightVisualElement.ShowHorizontalLineProperty, Telerik.WinControls.ValueResetFlags.Local);
            }

            SimpleListViewVisualItem simpleItem = e.VisualItem as SimpleListViewVisualItem;
            if (simpleItem != null)
            {
                if (e.VisualItem.Data.Group.Text == "TYPE")
                {
                    e.VisualItem.Text = Utils.GetRoomType((ByanType)e.VisualItem.Data.Value);
                }
                else if (e.VisualItem.Data.Group.Text == "HOUSE KEEPING")
                {
                    if (!e.VisualItem.Text.Contains("Repair"))
                    {
                        e.VisualItem.Text = Utils.GetHouseKeepingStatus((HouseKeepingStatus)e.VisualItem.Data.Value);
                    }
                }
                simpleItem.ToggleElement.Margin = new Padding(-20, 0, 0, 0);
            }
        }

        private void roomsView_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {
            IconListViewGroupVisualItem groupItem = e.VisualItem as IconListViewGroupVisualItem;
            if (groupItem != null)
            {
                if (groupItem.HasVisibleItems())
                {
                    groupItem.Visibility = ElementVisibility.Visible;
                }
                else
                {
                    groupItem.Visibility = ElementVisibility.Collapsed;
                }
                groupItem.Text = Utils.GetRoomType((ByanType)Enum.Parse(typeof(ByanType), groupItem.Text));
                e.VisualItem.CustomFont = Utils.MainFont;
                e.VisualItem.CustomFontSize = 15;
                e.VisualItem.CustomFontStyle = FontStyle.Regular;
                groupItem.ToggleElement.Visibility = ElementVisibility.Collapsed;
                e.VisualItem.ShowHorizontalLine = false;
                e.VisualItem.Padding = new Padding(20, 0, 0, 0);
                e.VisualItem.TextAlignment = ContentAlignment.BottomLeft;
                e.VisualItem.EnableElementShadow = false;
            }
            else
            {
                e.VisualItem.EnableElementShadow = true;
                e.VisualItem.ShadowDepth = 1;
                e.VisualItem.Padding = new Padding(0);
                e.VisualItem.ResetValue(LightVisualElement.TextAlignmentProperty, Telerik.WinControls.ValueResetFlags.Local);
            }
        }

        private void roomsView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is IconListViewVisualItem)
            {
                e.VisualItem = new RoomIconListViewVisualItem();
            }
        }

        public void PopulateData()
        {
            houseKeepers.Add(new HouseKeeper(1, "أميرة", DoctorERP_v2_00.Properties.Resources.Millie));
            houseKeepers.Add(new HouseKeeper(2, "إسراء", DoctorERP_v2_00.Properties.Resources.Anna));
            houseKeepers.Add(new HouseKeeper(3, "احمد", DoctorERP_v2_00.Properties.Resources.Bobby));

            rooms.Add(new Room(1, RoomStatus.Available, ByanType.Cars, HouseKeepingStatus.NotClean, true, 50));
            rooms.Last().Priority = RoomPriority.Low;
            rooms.Add(new Room(102, RoomStatus.Occupied, ByanType.Driver, HouseKeepingStatus.Clean, false, 100));
            rooms.Add(new Room(103, RoomStatus.Occupied, ByanType.Company, HouseKeepingStatus.NotClean, true, 150));
            rooms.Add(new Room(105, RoomStatus.CheckedOut, ByanType.Cars, HouseKeepingStatus.NotClean, false, 50));
            rooms.Add(new Room(106, RoomStatus.Reserved, ByanType.Driver, HouseKeepingStatus.Clean, true, 100));
            rooms.Add(new Room(107, RoomStatus.Available, ByanType.Driver, HouseKeepingStatus.Clean, false, 100));
            rooms.Add(new Room(109, RoomStatus.Available, ByanType.Cars, HouseKeepingStatus.NotClean, false, 50));
            rooms.Last().Priority = RoomPriority.High;
            rooms.Add(new Room(110, RoomStatus.Reserved, ByanType.Cars, HouseKeepingStatus.NotClean, false, 50));
            rooms.Last().Priority = RoomPriority.Medium;
            rooms.Add(new Room(111, RoomStatus.Reserved, ByanType.Company, HouseKeepingStatus.Clean, false, 150));
            rooms.Add(new Room(112, RoomStatus.Occupied, ByanType.Company, HouseKeepingStatus.Clean, false, 150));

            rooms.Add(new Room(114, RoomStatus.Available, ByanType.Company, HouseKeepingStatus.Clean, false, 200));
            rooms.Add(new Room(115, RoomStatus.Available, ByanType.Company, HouseKeepingStatus.Clean, false, 200));

            guests.Add(new Guest("1", "علي محمد", "سائق", "مصر", "6155550169",
                new CreditCard("Driver", DateTime.Now.AddYears(3), 387)));
            guests.Add(new Guest("2", "فيرنا", "سيارة", "021524102", "615-555-0169",
                new CreditCard("Cars", DateTime.Now.AddYears(2), 124)));
            guests.Add(new Guest("3", "تيوتا", "سيارة. ", "South Windsor", "615-555-0169",
                new CreditCard("Cars", DateTime.Now.AddYears(6), 547)));
            guests.Add(new Guest("4", "فتحي سيد", "سائق.", "Melbourne", "615-555-0169",
                new CreditCard("Driver", DateTime.Now.AddYears(4), 138)));
            guests.Add(new Guest("5", "فرج عامر", "سائق", "Honolulu", "615-555-0169",
                new CreditCard("Driver", DateTime.Now.AddYears(1), 114)));
            guests.Add(new Guest("6", "تيوتا", "سيارة", "012052411", "615-555-0169",
                new CreditCard("Cars", DateTime.Now.AddYears(3), 864)));

            DateTime start = DateTime.Today;
            uint bookingId = 1;
            Random rand = new Random();

            bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 102, start.AddDays(-1), start.AddDays(1), 250, BookingStatus.Actual));
            bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 105, start.AddDays(-2), start, 250, BookingStatus.CheckedOut));
            bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 112, start, start.AddDays(1), 250, BookingStatus.Actual));
            bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 108, start.AddDays(-1), start, 250, BookingStatus.Cancelled));

            for (int i = 0; i < 15; i++)
            {
                bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 103, start.AddDays(i * 3), start.AddDays(i * 3).AddDays(2), 250, BookingStatus.Actual));
                bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 106, start.AddDays(i), start.AddDays(i).AddDays(i + 3), 400, BookingStatus.Actual));
                bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 101, start.AddDays(2).AddDays(i * 3), start.AddDays(2).AddDays(i * 3).AddDays(3), 300, BookingStatus.Reservation));
                bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 113, start.AddDays(1).AddDays(i * 3), start.AddDays(1).AddDays(i * 3).AddDays(1), 300, BookingStatus.Reservation));
                bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 104, start.AddDays(1).AddDays(i * 3), start.AddDays(1).AddDays(i * 3).AddDays(5), 300, BookingStatus.Reservation));
                bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 105, start.AddDays(-i * 3 + 1), start.AddDays(-i * 3 + 1).AddDays(1), 300, BookingStatus.CheckedOut));
            }

            for (int i = 0; i < 5; i++)
            {
                bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 110, start.AddDays(1).AddDays(i * 3), start.AddDays(1).AddDays(i * 3).AddDays(1), 300, BookingStatus.Reservation));
                bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 107, start.AddDays(1).AddDays(i * 3), start.AddDays(1).AddDays(i * 3).AddDays(5), 300, BookingStatus.Cancelled));
                bookings.Add(new Booking(bookingId++, guests[rand.Next(0, guests.Count)], 111, start.AddDays(-i * 3), start.AddDays(-i * 3).AddDays(1), 300, BookingStatus.Reservation));
            }

            List<string> CompaniesList = new List<string> { "الوقود و الطاقة", "أورانج", "الوقود والمتكاملة", "بترولات", "سفن بلس", "إينوك", "المعايير" };

            List< Byanat  > ByanatData = new List< Byanat >();

            foreach (var gest in guests)
            {
                Byanat byanat = new Byanat();
                byanat.Name = gest.Name;
                byanat.Id = int.Parse(gest.Id);
                byanat.Type = gest.CardDetails.CreditCardId;
                byanat.Company = CompaniesList[0].ToString();
                byanat.StartDate = new DateTime(2024, 03, 15);
                byanat.StartDate = new DateTime(2024, 08, 25);
                byanat.Description = DateTime.Compare(byanat.StartDate, byanat.EndDate).ToString();
                ByanatData.Add(byanat);
            }
            //this.overviewRoomsView.DataSource = rooms;

            this.overviewRoomsView.DataSource = ByanatData;
            this.overviewRoomsView.DisplayMember = "Id";

            ListViewDataItemGroup statusGroup = new ListViewDataItemGroup();
            statusGroup.Text = "النوع";
            ListViewDataItem DriverItem = new ListViewDataItem() { Text = "سائق", Tag = ByanType.Driver };
            DriverItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;

            this.overviewLeftView.Items.Add(DriverItem);
            DriverItem.Group = statusGroup;
            ListViewDataItem CarsItem = new ListViewDataItem() { Text = "سيارة" , Tag = ByanType.Cars};
            CarsItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.overviewLeftView.Items.Add(CarsItem);
            CarsItem.Group = statusGroup;

            ListViewDataItemGroup typesGroup = new ListViewDataItemGroup();
            typesGroup.Text = "الشركة";

            this.overviewLeftView.Groups.AddRange(new ListViewDataItemGroup[] { statusGroup, typesGroup });

            Array statusOptions = Enum.GetValues(typeof(RoomStatus));
            ////foreach (object item in statusOptions)
            ////{
            ////    ListViewDataItem statusItem = new ListViewDataItem(item.ToString());
            ////    statusItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
            ////    this.overviewLeftView.Items.Add(statusItem);
            ////    statusItem.Group = statusGroup;
            ////}

                //Enum.GetValues(typeof(ByanType));
            foreach (object item in CompaniesList)
            {
                ListViewDataItem roomTypeItem = new ListViewDataItem(item);
                roomTypeItem.Value = item;
                roomTypeItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                roomTypeItem.Group = typesGroup;
                this.overviewLeftView.Items.Add(roomTypeItem);
            }

        }

        internal ListViewDataItem GetItemByRoomId(int roomId)
        {
            foreach (ListViewDataItem item in this.overviewRoomsView.Items)
            {
                Room room = item.DataBoundItem as Room;
                if (room != null && room.Id == roomId)
                {
                    return item;
                }
            }
            return new ListViewDataItem() { Visible = false };
        }

        internal void ShowRoomDetails(Byanat room, Booking booking, string comingFrom)
        {
            this.mainContainer.SelectedPage = this.OverviewPage;
            this.roomDetailsUC.Visible = true;
            roomDetailsUC.InitializeData(room, booking, comingFrom);
            this.navigationPanelOverview.Visible = false;
        }

        public void HideRoomDetails()
        {
            this.roomDetailsUC.Visible = false;
            this.navigationPanelOverview.Visible = true;
            this.RoomsListView.ListViewElement.SynchronizeVisualItems();
        }

        private void overviewRoomsView_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void editGuestInfo_Load(object sender, EventArgs e)
        {

        }

        private void bookingsGrid_Click(object sender, EventArgs e)
        {

        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void radToolbarFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void overviewMainContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}