using DoctorERP_v2_00.Dialogs;
using DoctorERP_v2_00.FlyoutDialogs;
using DoctorHelper.Helpers;
using DoctorHelper.Reports;
using Helper.Helpers;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        #region Construction
        private bool ISNew = false, IsGrid = false, IsUpdate = false;
        private string FlyOutTypeReturn = string.Empty,FlyOutNoteReturn = string.Empty, FlyOutDriverReturn = null, FlyOutCartReturn = null, FlyOutCompanyReturn = null;
        private DateTime FlyOutEndDateReturn;
        #endregion

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

            #region Initialize Controls

            searchContainerOverview.RootElement.EnableElementShadow = false;

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

            this.CompaniesView.ShowGroups = true;
            this.CompaniesView.EnableGrouping = true;
            this.CompaniesView.EnableCustomGrouping = true;
            this.CompaniesView.ShowCheckBoxes = true;
            this.CompaniesView.AllowEdit = false;
            this.CompaniesView.RootElement.EnableElementShadow = false;
            this.CompaniesView.HotTracking = false;
            this.CompaniesView.ListViewElement.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);

            this.ByanatView.ViewType = ListViewType.IconsView;
            this.ByanatView.ItemSize = new Size(150, 80);
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

            this.labelBookings.TextAlignment = ContentAlignment.MiddleLeft;
            editGuestInfo.guestInfoLabel.TextAlignment = ContentAlignment.MiddleLeft;


            this.ByanatView.VisualItemCreating += View_VisualItemCreating;
            this.CompaniesView.VisualItemCreating += LeftView_VisualItemCreating;

            RadFlyoutManager.FlyoutClosed -= this.RadFlyoutManager_FlyoutClosed;
            RadFlyoutManager.FlyoutClosed += this.RadFlyoutManager_FlyoutClosed;


            RadFlyoutManager.ContentCreated -= this.RadFlyoutManager_ContentCreated;
            RadFlyoutManager.ContentCreated += this.RadFlyoutManager_ContentCreated;

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

            radLabel3.RootElement.CustomFont = "TelerikWebUI";
            radLabel3.RootElement.CustomFontSize = 12;
            radLabel3.RootElement.ForeColor = Color.Gray;
            radLabel3.RootElement.MaxSize = new System.Drawing.Size(40, 35);
            radLabel3.Text = "\ue13E";

            CommandBarLocalizationProvider.CurrentProvider = new MyArabicCommandBarLocalizationProvider();
            commandBarButton1.UpdateLayout();
            commandBarButton2.UpdateLayout();
            commandBarButton3.UpdateLayout();
            commandBarButton4.UpdateLayout();
            commandBarButton5.UpdateLayout();
            commandBarButton6.UpdateLayout();
            commandBarLabel1.UpdateLayout();
            commandBarRowElement1.UpdateLayout();
            commandBarStripElement1.UpdateLayout();
            commandBarStripElement2.UpdateLayout();
            //commandBarTextBox1.UpdateLayout();
            radBindingNavigator1.ContextMenuOpening += radBindingNavigator1_ContextMenuOpening;

            #endregion

        }

        #region Method

        private void radBindingNavigator1_ContextMenuOpening(object sender,  CancelEventArgs e)
        {
            e.Cancel = true;

        }
        private void ShowNotification(string Header, string Content, string Note)
        {
            radToastNotificationManager1.ToastNotifications[0].Xml = "<toast launch=\"readMoreArg\">\r\n  <visual>\r\n    <binding template=\"ToastGeneric\">\r\n   " +
                "   <text>" + Header + "</text>\r\n   " +
                "   <text>" + Content + "</text>\r\n  " +
                "    <text placement=\"attribution\">" + Note + "</text>\r\n    </binding>\r\n  </visual>\r\n</toast>";
            radToastNotificationManager1.ShowNotification(0);

        }
        private bool MessageWarning(string Heading, string Body, string FootNote)
        {
            RadTaskDialogPage page = new RadTaskDialogPage()
            {
                Caption = " ",
                Heading = Heading,
                Text = Body,
                RightToLeft = true,
                CustomFont = "Robot",
                Icon = RadTaskDialogIcon.ShieldWarningYellowBar,
                AllowCancel = true,
                Footnote = new RadTaskDialogFootnote("ملحوظة: " + FootNote),
                CommandAreaButtons = {
                    RadTaskDialogButton.Yes,
                    RadTaskDialogButton.No
                },
                                RightToLeftLayout = true,

            };
            page.CommandAreaButtons[0].Text = "نعم";
            page.CommandAreaButtons[1].Text = "لا";
            page.CommandAreaButtons[0].Select();
            RadTaskDialogButton result = RadTaskDialog.ShowDialog(page, RadTaskDialogStartupLocation.CenterScreen);
            if (result == null || result == RadTaskDialogButton.No)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool MessageException(string Heading, string Body, string FootNote)
        {
            RadTaskDialogPage page = new RadTaskDialogPage()
            {

                Caption = " ",
                Heading = Heading,
                Text = Body,
                RightToLeft = true,
                CustomFont = "Robot",
                Icon = RadTaskDialogIcon.ShieldErrorRedBar,
                Footnote = new RadTaskDialogFootnote("ملحوظة: " + FootNote),
                CommandAreaButtons = {
                    RadTaskDialogButton.OK,
                }

            };
            page.CommandAreaButtons[0].Select();
            page.CommandAreaButtons[0].Focus();
            page.CommandAreaButtons[0].Text = "موافق";
            RadTaskDialogButton result = RadTaskDialog.ShowDialog(page, RadTaskDialogStartupLocation.CenterScreen);
            return true;
        }
        private void ShowDesktopAlert(string Header, string Content, string ContentHighlight, string Footer)
        {
            Content = TextHelper.ReverseText(Content);
            ContentHighlight = TextHelper.ReverseText(ContentHighlight);
            Footer = TextHelper.ReverseText(Footer);

            radDesktopAlert1.RightToLeft = RightToLeft.Yes;
            radDesktopAlert1.CaptionText = "<html><b>\n" + Header;
            radDesktopAlert1.ContentText = "<html><i>" +
                Content +
                "</i><b><span><color=Blue>" +
                "\n" + ContentHighlight + "\n" +
                "</span></b>" +
                Footer;
            radDesktopAlert1.ContentImage = DoctorERP_v2_00.Properties.Resources.information50;
            radDesktopAlert1.Opacity = 0.9f;
            radDesktopAlert1.Show();

        }

        private void NotificationMethod()
        {
            foreach (ByanRow item in this.contract_ManagementDataSet.Byan.Rows)
            {
                int Period = (item.EndDate - DateTime.Now).Days;

                if (Period <= 15)
                {

                    if (this.contract_ManagementDataSet.Notifications.Any(u => u.ByanID == item.ID)) { continue; }

                    int Result = notificationsTableAdapter.Insert(item.ID, item.EndDate, string.Empty);

                    if (Result > 0)
                    {
                        this.notificationsTableAdapter.Fill(this.contract_ManagementDataSet.Notifications);
                        this.notificationViewTableAdapter.Fill(this.contract_ManagementDataSet.NotificationView);
                        this.GridViewNotification.MasterTemplate.Refresh();
                        NotificationGridLayout();
                        ShowNotification("تنبيه بإنتهاء بطاقة", $"البطاقة الخاصة بال{item.ParentType}  {item.ParentName} أوشكت علي الإنتهاء", $"البيان دخل حيز فترة الإخطار المحددة ب15 يوماً و سوف ينتهي التصريح بتاريخ {item.EndDate.ToString("yyyy/MM/dd)")} .");
                        ShowDesktopAlert("تنبيه بإنتهاء بطاقة", "البطاقة أوشكت علي الإنتهاء", $"البطاقة الخاصة بال{item.ParentType}  {item.ParentName} أوشكت علي الإنتهاء", $"البيان دخل حيز فترة الإخطار المحددة ب15 يوماً و سوف ينتهي التصريح بتاريخ {item.EndDate.ToString("yyyy/MM/dd)")} .");

                    }
                }
            }

        }
        private void NotificationGridLayout()
        {

            this.GridViewNotification.AutoGenerateHierarchy = true;
            this.GridViewNotification.TableElement.CellSpacing = 10;
            this.GridViewNotification.RootElement.EnableElementShadow = false;
            this.GridViewNotification.GridViewElement.DrawFill = false;
            this.GridViewNotification.TableElement.Margin = new Padding(15, 0, 15, 0);
            this.GridViewNotification.BackColor = Color.Transparent;
            this.GridViewNotification.GridViewElement.DrawFill = true;
            this.GridViewNotification.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            foreach (GridViewDataColumn col in this.GridViewNotification.Columns)
            {
                col.TextAlignment = ContentAlignment.MiddleCenter;
                col.HeaderTextAlignment = ContentAlignment.MiddleCenter;
            }

            GridViewDateTimeColumn fromColumn = this.GridViewNotification.Columns["Byan_EndDate"] as GridViewDateTimeColumn;
            fromColumn.Format = DateTimePickerFormat.Custom;
            fromColumn.CustomFormat = "yyyy/MM/dd";
            fromColumn.FormatString = "{0:yyyy/MM/dd}";

            foreach (GridViewRowInfo row in GridViewNotification.Rows)
            {
                int Period = ((DateTime)row.Cells[7].Value - DateTime.Now).Days;
                if (Period <= 0)
                {
                    if (row.Cells[3].Value.ToString() == "سائق")
                    {
                        row.Cells[0].Value = DoctorERP_v2_00.Properties.Resources.DriverRed_32;
                    }
                    else
                    {
                        row.Cells[0].Value = DoctorERP_v2_00.Properties.Resources.CarRed_32;

                    }
                    row.Cells[13].Value = "منذ " + -Period + " يوم";

                    row.Cells[14].Value = "منتهي";

                }
                else
                {
                    if (row.Cells[3].Value.ToString() == "سائق")
                    {
                        row.Cells[0].Value = DoctorERP_v2_00.Properties.Resources.DriverOrange_32;
                    }
                    else
                    {
                        row.Cells[0].Value = DoctorERP_v2_00.Properties.Resources.CarOrange_32;

                    }
                    row.Cells[13].Value = "باقي " + Period + "يوم";

                    row.Cells[14].Value = "أوشك";
                }


                //row.Cells[12].Value = ((DateTime)row.Cells[7].Value).ToString("yyyy/MM/dd");

            }


        }

        #endregion


        #region Flyout
        private void RadFlyoutManager_ContentCreated(ContentCreatedEventArgs e)
        {
            Telerik.WinControls.Extensions.Action action = new Telerik.WinControls.Extensions.Action(() =>
            {
                if (e.Content is FlyoutAddByanat)
                {

                    FlyoutAddByanat content = e.Content as FlyoutAddByanat;
                    if (content != null)
                    {

                        this.driverTableAdapter.Fill(this.contract_ManagementDataSet.Driver);
                        this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
                        this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);

                        content.driverBindingSource.DataSource = this.contract_ManagementDataSet;
                        content.carsBindingSource.DataSource = this.contract_ManagementDataSet;
                        content.companiesBindingSource.DataSource = this.contract_ManagementDataSet;

                        if (FlyOutTypeReturn != string.Empty) 
                        {
                            if (FlyOutTypeReturn == "سائق")
                            {
                                content.CMBParentType.SelectedIndex = 0;
                                FlyOutTypeReturn = string.Empty;

                            }
                            else if (FlyOutTypeReturn == "سيارة")
                            {
                                content.CMBParentType.SelectedIndex = 1;
                                FlyOutTypeReturn = string.Empty;
                            }

                            if (FlyOutDriverReturn != null) { content.MCCDriverName.SelectedValue = int.Parse(FlyOutDriverReturn); }
                            FlyOutDriverReturn = null;
                            if (FlyOutCartReturn != null) { content.MCCCarName.SelectedValue = FlyOutCartReturn; }
                            FlyOutCartReturn = null;
                            if (FlyOutCompanyReturn != null) { content.MCCCompanyName.SelectedValue = FlyOutCompanyReturn; }
                            FlyOutCompanyReturn = null;
                            content.DTPEndDate.Value = FlyOutEndDateReturn;
                            FlyOutEndDateReturn = DateTime.Now;
                            content.TXBNote.Text = FlyOutNoteReturn;
                            FlyOutNoteReturn = null;
                            return;
                        }

                        if (ISNew)
                        {
                            ISNew = false;
                            content.CMBParentType.SelectedIndex = 0;
                            content.MCCDriverName.SelectedItem = null;
                            content.MCCCarName.SelectedItem = null;
                            content.MCCCompanyName.SelectedItem = null;
                            content.saveButton.Text = "حفظ";
                            content.radButton3.Text = "إلغاء";
                            return;
                        }

                        DataRowView data = ByanatView.CurrentItem.DataBoundItem as DataRowView;
                        ByanRow row = data.Row as ByanRow;

                        if (row.ParentType == "سائق")
                        {
                            content.CMBParentType.SelectedIndex = 0;
                            content.MCCDriverName.SelectedItem = this.contract_ManagementDataSet.Driver.Where(u => u.DriverName == row.ParentName).FirstOrDefault();

                        }
                        else
                        {
                            content.CMBParentType.SelectedIndex = 1;
                            content.MCCCarName.SelectedItem = this.contract_ManagementDataSet.Cars.Where(u => u.CarName == row.ParentName).FirstOrDefault();
                        }
                        content.MCCCompanyName.Text = row.CompanyName;
                        content.DTPEndDate.Value = row.EndDate;
                        if (!(row.ItemArray[6] is DBNull))
                        {
                            content.TXBNote.Text = row.Note;
                        }

                        content.saveButton.Text = "تعديل";
                        content.radButton3.Text = "حذف";
                        content.MCCDriverName.Select();

                    }
                }
            });

            this.Invoke(action);
        }

        private void RadFlyoutManager_FlyoutClosed(FlyoutClosedEventArgs e)
        {
            Telerik.WinControls.Extensions.Action action = new Telerik.WinControls.Extensions.Action(() =>
            {

                if (e.Content is FlyoutAddByanat)
                {
                    RadCallout callout = new RadCallout();
                    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Up;

                    if (e.Content is FlyoutAddByanat contentFlyoutAddByanat)
                    {
                        if (contentFlyoutAddByanat.Result == DialogResult.No)
                        {
                            FlyOutTypeReturn = contentFlyoutAddByanat.CMBParentType.Text;
                            if (contentFlyoutAddByanat.MCCDriverName.SelectedValue != null) { FlyOutDriverReturn = contentFlyoutAddByanat.MCCDriverName.SelectedValue.ToString(); }
                            if (contentFlyoutAddByanat.MCCCarName.SelectedValue != null) { FlyOutCartReturn = contentFlyoutAddByanat.MCCCarName.SelectedValue.ToString(); }
                            if (contentFlyoutAddByanat.MCCCompanyName.SelectedValue != null) { FlyOutCompanyReturn = contentFlyoutAddByanat.MCCCompanyName.SelectedValue.ToString(); }
                            FlyOutEndDateReturn = contentFlyoutAddByanat.DTPEndDate.Value;
                            FlyOutNoteReturn = contentFlyoutAddByanat.TXBNote.Text;

                            RadFlyoutManager.Show(this, typeof(FlyoutAddCompany));

                        }
                        else if (contentFlyoutAddByanat.Result == DialogResult.Yes)
                        {
                            if (contentFlyoutAddByanat.CMBParentType.Text == "سائق")
                            {
                                FlyOutTypeReturn = contentFlyoutAddByanat.CMBParentType.Text;
                                if (contentFlyoutAddByanat.MCCDriverName.SelectedValue != null) { FlyOutDriverReturn = contentFlyoutAddByanat.MCCDriverName.SelectedValue.ToString(); }
                                if (contentFlyoutAddByanat.MCCCarName.SelectedValue != null) { FlyOutCartReturn = contentFlyoutAddByanat.MCCCarName.SelectedValue.ToString(); }
                                if (contentFlyoutAddByanat.MCCCompanyName.SelectedValue != null) { FlyOutCompanyReturn = contentFlyoutAddByanat.MCCCompanyName.SelectedValue.ToString(); }
                                FlyOutEndDateReturn = contentFlyoutAddByanat.DTPEndDate.Value;
                                FlyOutNoteReturn = contentFlyoutAddByanat.TXBNote.Text;

                                RadFlyoutManager.Show(this, typeof(FlyoutAddDriver));

                            }
                            else if (contentFlyoutAddByanat.CMBParentType.Text == "سيارة")
                            {
                                FlyOutTypeReturn = contentFlyoutAddByanat.CMBParentType.Text;
                                if (contentFlyoutAddByanat.MCCDriverName.SelectedValue != null) { FlyOutDriverReturn = contentFlyoutAddByanat.MCCDriverName.SelectedValue.ToString(); }
                                if (contentFlyoutAddByanat.MCCCarName.SelectedValue != null) { FlyOutCartReturn = contentFlyoutAddByanat.MCCCarName.SelectedValue.ToString(); }
                                if (contentFlyoutAddByanat.MCCCompanyName.SelectedValue != null) { FlyOutCompanyReturn = contentFlyoutAddByanat.MCCCompanyName.SelectedValue.ToString(); }
                                FlyOutEndDateReturn = contentFlyoutAddByanat.DTPEndDate.Value;
                                FlyOutNoteReturn = contentFlyoutAddByanat.TXBNote.Text;

                                RadFlyoutManager.Show(this, typeof(FlyoutAddCar));

                            }


                        }
                        else if (contentFlyoutAddByanat.Result == DialogResult.OK)
                        {
                            if (contentFlyoutAddByanat.saveButton.Text == "حفظ")
                            {
                                if (!MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة بيان جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة البيان الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
                                    return;

                                int Result = byanTableAdapter.Insert(contentFlyoutAddByanat.Type, contentFlyoutAddByanat.ParentName,
                                    contentFlyoutAddByanat.Company, DateTime.Now, contentFlyoutAddByanat.EndDate, contentFlyoutAddByanat.Note);

                                if (Result > 0)
                                {
                                    this.byanTableAdapter.Fill(this.contract_ManagementDataSet.Byan);
                                    ShowDesktopAlert("إضافة بيان", "تمت عملية إضافة البيان", $"عملية إضافة البيان  {contentFlyoutAddByanat.ParentName}  تمت بنجاح " + $" و المرتبط بشركة  {contentFlyoutAddByanat.Company} ", "تمت عملية إضافة البيان يمكن القيام بالعمليات عليه الأن.");
                                    RadCallout.Show(callout, this.radButton1, $"عملية إضافة البيان  {contentFlyoutAddByanat.ParentName}  تمت بنجاح " + $" و المرتبط بشركة  {contentFlyoutAddByanat.Company} ", "تمت العملية بنجاح");

                                }
                                else
                                {
                                    RadCallout.Show(callout, this.radButton1, "فشلت عملية إضافة البيان !", "فشلت العملية");
                                }
                            }
                            else if (contentFlyoutAddByanat.saveButton.Text == "تعديل")
                            {
                                if (!MessageWarning("هل أنت متأكد من التعديل ؟", "تعديل بيان", "إذا ضغت علي زر نعم سوف يتم تعديل البيان \r\n إذا ضغط علي زر لا سوف يتم تجاهل التعديل"))
                                    return;

                                DataRowView data = ByanatView.CurrentItem.DataBoundItem as DataRowView;
                                ByanRow row = data.Row as ByanRow;
                                ByanRow dataRow = this.contract_ManagementDataSet.Byan.Where(u => u.ID == row.ID).FirstOrDefault();
                                dataRow.ParentType = contentFlyoutAddByanat.Type;
                                dataRow.ParentName = contentFlyoutAddByanat.ParentName;
                                dataRow.CompanyName = contentFlyoutAddByanat.Company;
                                dataRow.EndDate = contentFlyoutAddByanat.EndDate;
                                dataRow.Note = contentFlyoutAddByanat.Note;
                                int Result = byanTableAdapter.Update(dataRow);

                                if (Result > 0)
                                {
                                    this.byanTableAdapter.Fill(this.contract_ManagementDataSet.Byan);
                                    ShowDesktopAlert("تعديل بيان", "تمت عملية تعديل البيان", $"عملية تعديل البيان  {contentFlyoutAddByanat.ParentName}  تمت بنجاح " + $" و المرتبط بشركة  {contentFlyoutAddByanat.Company} ", "تم تعديل البيان يمكن القيام بالعمليات عليه الأن.");
                                    RadCallout.Show(callout, this.radButton1, $"عملية تعديل البيان  {contentFlyoutAddByanat.ParentName}  تمت بنجاح " + $" و المرتبط بشركة  {contentFlyoutAddByanat.Company} ", "تمت العملية بنجاح");

                                }
                                else
                                {
                                    RadCallout.Show(callout, this.radButton1, "فشلت عملية تعديل البيان !", "فشلت العملية");
                                }

                            }

                        }
                        else if (contentFlyoutAddByanat.Result == DialogResult.Abort)
                        {
                            if (!MessageWarning("هل أنت متأكد من الحذف ؟", "حذف بيان", "إذا ضغت علي زر نعم سوف يتم حذف البيان \r\n إذا ضغط علي زر لا سوف يتم تجاهل الحذف"))
                                return;

                            DataRowView data = ByanatView.CurrentItem.DataBoundItem as DataRowView;
                            ByanRow row = data.Row as ByanRow;
                            ByanRow dataRow = this.contract_ManagementDataSet.Byan.Where(u => u.ID == row.ID).FirstOrDefault();
                            int Result = byanTableAdapter.Delete(dataRow.ID, dataRow.ParentType, dataRow.ParentName, dataRow.CompanyName, dataRow.StartDate, dataRow.EndDate);
                            if (Result > 0)
                            {
                                this.byanTableAdapter.Fill(this.contract_ManagementDataSet.Byan);
                                ShowDesktopAlert("حذف بيان", "تمت عملية حذف البيان بنجاح", $"عملية حذف البيان  {contentFlyoutAddByanat.ParentName}  تمت بنجاح " + $" و المرتبط بشركة  {contentFlyoutAddByanat.Company} ", "تمت عملية حذف البيان من قاعدة البيانات بنجاح.");
                                RadCallout.Show(callout, this.radButton1, $"عملية حذف البيان  {contentFlyoutAddByanat.ParentName}  تمت بنجاح " + $" و المرتبط بشركة  {contentFlyoutAddByanat.Company} ", "تمت العملية بنجاح");

                            }
                            else
                            {
                                RadCallout.Show(callout, this.radButton1, "فشلت عملية حذف البيان !", "فشلت العملية");
                            }
                        }
                    }
                }
                else if (e.Content is FlyoutAddDriver)
                {
                    RadCallout callout = new RadCallout();
                    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Up;

                    if (e.Content is FlyoutAddDriver contentFlyoutAddDriver)
                    {
                        if (contentFlyoutAddDriver.Result == DialogResult.OK)
                        {
                            if (!MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة سائق جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة السائق الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
                                return;

                            int Result = driverTableAdapter.Insert(contentFlyoutAddDriver.ParentName, contentFlyoutAddDriver.ParentCardID,
                                contentFlyoutAddDriver.Note);

                            if (Result > 0)
                            {
                                this.driverTableAdapter.Fill(this.contract_ManagementDataSet.Driver);
                                this.GridViewDriver.MasterTemplate.Refresh();
                                ShowDesktopAlert("إضافة سائق", "تمت عملية إضافة السائق بنجاح", $"عملية إضافة السائق  {contentFlyoutAddDriver.ParentName}  تمت بنجاح ", "تمت عملية إضافة السائق الجديد يمكن القيام بالعمليات عليه الأن.");
                                RadCallout.Show(callout, this.radButton1, $"عملية إضافة السائق  {contentFlyoutAddDriver.ParentName}  تمت بنجاح ", "تمت العملية بنجاح");
                            }
                            else
                            {
                                RadCallout.Show(callout, this.radButton1, "فشلت عملية إضافة السائق !", "فشلت العملية");
                            }

                        }
                        RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));
                    }
                }
                else if (e.Content is FlyoutAddCar)
                {
                    RadCallout callout = new RadCallout();
                    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Up;

                    if (e.Content is FlyoutAddCar contentFlyoutAddCar)
                    {
                        if (contentFlyoutAddCar.Result == DialogResult.OK)
                        {
                            if (!MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة سيارة جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة السيارة الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
                                return;

                            int Result = carsTableAdapter.Insert(contentFlyoutAddCar.ParentName, contentFlyoutAddCar.ParentName, contentFlyoutAddCar.Note);

                            if (Result > 0)
                            {
                                this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);
                                this.GridViewCars.MasterTemplate.Refresh();
                                ShowDesktopAlert("إضافة سيارة", "تمت عملية إضافة السيارة بنجاح", $"عملية إضافة السيارة  {contentFlyoutAddCar.ParentName}  تمت بنجاح ", "تمت عملية إضافة السيارة الجديد يمكن القيام بالعمليات عليها الأن");
                                RadCallout.Show(callout, this.radButton1, $"عملية إضافة السيارة  {contentFlyoutAddCar.ParentName}  تمت بنجاح ", "تمت العملية بنجاح");
                            }
                            else
                            {
                                RadCallout.Show(callout, this.radButton1, "فشلت عملية إضافة السيارة !", "فشلت العملية");
                            }
                        }
                        RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));
                    }
                }
                else if (e.Content is FlyoutAddCompany)
                {
                    RadCallout callout = new RadCallout();
                    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Up;

                    if (e.Content is FlyoutAddCompany contentFlyoutAddCompany)
                    {
                        if (contentFlyoutAddCompany.Result == DialogResult.OK)
                        {
                            if (!MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة شركة جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة الشركة الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
                                return;

                            int Result = companiesTableAdapter.Insert(contentFlyoutAddCompany.ParentName, contentFlyoutAddCompany.ParentName,
                                contentFlyoutAddCompany.Note);

                            if (Result > 0)
                            {
                                this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
                                this.GridViewCompanies.MasterTemplate.Refresh();
                                ShowDesktopAlert("إضافة شركة", "تمت عملية إضافة الشركة بنجاح", $"عملية إضافة الشركة   {contentFlyoutAddCompany.ParentName}  تمت بنجاح ", "تمت عملية إضافة الشركة الجديد يمكن القيام بالعمليات عليها الأن");
                                RadCallout.Show(callout, this.radButton1, $"عملية إضافة الشركة  {contentFlyoutAddCompany.ParentName}  تمت بنجاح ", "تمت عملية الإضافة بنجاح");
                            }
                            else
                            {
                                RadCallout.Show(callout, this.radButton1, "فشلت عملية إضافة الشركة !", "فشلت العملية");
                            }
                        }
                        RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));
                    }
                }
            });

            this.Invoke(action);
        }

        #endregion


        #region List View 
        private void LeftView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is SimpleListViewVisualItem)
            {
                e.VisualItem = new OptionsSimpleListViewVisualItem();
            }
        }

        private void OverViewList_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            try
            {
                DataRowView data = e.Item.DataBoundItem as DataRowView;
                if (data.Row is ByanRow row)
                {
                    RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));
                }

            }
            catch { return; }
        }

        private bool ClearSelectCase()
        {
            foreach (ListViewDataItem item in CompaniesView.Items)
            {
                if (item.CheckState == ToggleState.Off) { return false; }

            }
            return true;
        }

        private void LeftView_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.CheckState == ToggleState.On)
            {
                foreach (ListViewDataItem item in ByanatView.Items)
                {
                    DataRowView data = item.DataBoundItem as DataRowView;
                    ByanRow row = data.Row as ByanRow;
                    if (e.Item.Text == row.CompanyName)
                    {
                        if (item.Group.Visible) { item.Visible = true; }

                    }

                }
                if (ClearSelectCase()) { ButtonSelectAllCompanies.Text = "إلغاء الكل"; }
            }
            else if (e.Item.CheckState == ToggleState.Off)
            {
                foreach (ListViewDataItem item in ByanatView.Items)
                {
                    DataRowView data = item.DataBoundItem as DataRowView;
                    ByanRow row = data.Row as ByanRow;
                    if (e.Item.Text == row.CompanyName)
                    {
                        item.Visible = false;

                    }

                }
                ButtonSelectAllCompanies.Text = "تحديد الكل";
            }

        }
        private void View_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is IconListViewVisualItem)
            {
                e.VisualItem = new RoomIconListViewVisualItem();
            }
        }

        #endregion

        #endregion

        #region Binding Events

        private void DriverBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //try
            //{
                
            //RadCallout callout = new RadCallout();
            
            //callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Right;

            //if (GridViewDriver.MasterView.TableAddNewRow.Cells[0].Value != null)
            //{
            //    if (this.contract_ManagementDataSet.Driver.Any(u => u.ID.ToString() == GridViewDriver.MasterView.TableAddNewRow.Cells[0].Value.ToString())) { return; }

            //}

            //if (e.ListChangedType == ListChangedType.ItemAdded)
            //{
            //    if (ISNew) { ISNew = false; return; }
            //    if (!MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة سائق جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة السائق الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
            //        return;

            //    int Result = driverTableAdapter.Insert(
            //        GridViewDriver.MasterView.TableAddNewRow.Cells[1].Value != null ? GridViewDriver.MasterView.TableAddNewRow.Cells[1].Value.ToString() : string.Empty,
            //        GridViewDriver.MasterView.TableAddNewRow.Cells[2].Value != null ? GridViewDriver.MasterView.TableAddNewRow.Cells[2].Value.ToString() : string.Empty,
            //        GridViewDriver.MasterView.TableAddNewRow.Cells[3].Value != null ? GridViewDriver.MasterView.TableAddNewRow.Cells[3].Value.ToString(): string.Empty);

            //    ISNew = true;
            //    if (Result > 0)
            //    {
            //        ShowDesktopAlert("إضافة سائق", "تمت عملية إضافة السائق بنجاح", $" عملية إضافة السائق  {GridViewDriver.MasterView.TableAddNewRow.Cells[1].Value.ToString()}  تمت بنجاح ", "تمت عملية إضافة السائق الجديد يمكن القيام بالعمليات عليه الأن.");
            //        RadCallout.Show(callout, GridViewDriver, $"عملية إضافة السائق  {GridViewDriver.MasterView.TableAddNewRow.Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
            //        //GridViewDriver.DataSource = null;
            //        //GridViewDriver.Rows.Clear();
            //        //this.driverTableAdapter.Fill(this.contract_ManagementDataSet.Driver);
            //        //GridViewDriver.DataSource = this.driverBindingSource;
            //    }
            //    else
            //    {
            //        RadCallout.Show(callout, this.GridViewDriver, "فشلت عملية إضافة السائق !", "فشلت العملية");
            //    }

            //    return;
            //}
            //else if (e.ListChangedType == ListChangedType.ItemChanged)
            //{
            //    if (ISNew) { ISNew = false; return; }
            //    if (!MessageWarning("هل أنت متأكد من التعديل ؟", "تعديل سائق", "إذا ضغت علي زر نعم سوف يتم تعديل السائق \r\n إذا ضغط علي زر لا سوف يتم تجاهل التعديل"))
            //        return;

            //    DriverRow dataRow = this.contract_ManagementDataSet.Driver.Where(u => u.ID.ToString() == GridViewDriver.Rows[e.NewIndex].Cells[0].Value.ToString()).FirstOrDefault();
            //    dataRow.DriverName = GridViewDriver.Rows[e.NewIndex].Cells[1].Value.ToString();
            //    dataRow.CardID = GridViewDriver.Rows[e.NewIndex].Cells[2].Value.ToString();
            //    dataRow.Note = GridViewDriver.Rows[e.NewIndex].Cells[3].Value.ToString();
            //    int Result = driverTableAdapter.Update(dataRow);

            //    if (Result > 0)
            //    {
            //        ShowDesktopAlert("تعديل سائق", "تمت عملية تعديل السائق", $"عملية تعديل السائق  {GridViewDriver.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تم تعديل السائق يمكن القيام بالعمليات عليه الأن.");
            //        RadCallout.Show(callout, this.GridViewDriver, $"عملية تعديل السائق  {GridViewDriver.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
            //        //this.driverTableAdapter.Fill(this.contract_ManagementDataSet.Driver);
            //        //GridViewDriver.MasterView.Refresh();

            //    }
            //    else
            //    {
            //        RadCallout.Show(callout, this.GridViewDriver, "فشلت عملية تعديل السائق !", "فشلت العملية");
            //    }

            //}
            //else if (e.ListChangedType == ListChangedType.ItemDeleted)
            //{
            //    if (!MessageWarning("هل أنت متأكد من الحذف ؟", "حذف سائق", "إذا ضغت علي زر نعم سوف يتم حذف السائق \r\n إذا ضغط علي زر لا سوف يتم تجاهل الحذف"))
            //        return;

            //    DriverRow dataRow = this.contract_ManagementDataSet.Driver.Where(u => u.ID.ToString() == GridViewDriver.Rows[e.NewIndex].Cells[0].Value.ToString()).FirstOrDefault();
            //    int Result = driverTableAdapter.Delete(dataRow.ID, dataRow.DriverName, dataRow.CardID);

            //    if (Result > 0)
            //    {
            //        ShowDesktopAlert("حذف سائق", "تمت عملية حذف السائق بنجاح", $"عملية حذف السائق  {GridViewDriver.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت عملية حذف السائق من قاعدة البيانات بنجاح.");
            //        RadCallout.Show(callout, this.GridViewDriver, $"عملية حذف السائق  {GridViewDriver.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
            //        //this.driverTableAdapter.Fill(this.contract_ManagementDataSet.Driver);
            //        //GridViewDriver.MasterView.Refresh();

            //    }
            //    else
            //    {
            //        RadCallout.Show(callout, this.GridViewDriver, "فشلت عملية حذف السائق !", "فشلت العملية");
            //    }

            //}
            //}
            //catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void CarsBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
    ////        RadCallout callout = new RadCallout();
    ////        callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Right;

    ////        if (e.ListChangedType == ListChangedType.ItemAdded)
    ////        {
    ////            if (ISNew) { ISNew = false; return; }


    ////            if (!MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة سيارة جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة السيارة الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
    ////                return;


    ////            int Result = carsTableAdapter.Insert(
    ////GridViewCars.MasterView.TableAddNewRow.Cells[1].Value != null ? GridViewCars.MasterView.TableAddNewRow.Cells[1].Value.ToString() : string.Empty,
    ////GridViewCars.MasterView.TableAddNewRow.Cells[2].Value != null ? GridViewCars.MasterView.TableAddNewRow.Cells[2].Value.ToString() : string.Empty,
    ////GridViewCars.MasterView.TableAddNewRow.Cells[3].Value != null ? GridViewCars.MasterView.TableAddNewRow.Cells[3].Value.ToString() : string.Empty);
    ////            ISNew = true;

    ////            if (Result > 0)
    ////            {
    ////                ShowDesktopAlert("إضافة سيارة", "تمت عملية إضافة السيارة بنجاح", $"عملية إضافة السيارة  {GridViewCars.MasterView.TableAddNewRow.Cells[1].Value.ToString()}  تمت بنجاح ", "تمت عملية إضافة السيارة الجديد يمكن القيام بالعمليات عليه الأن.");
    ////                RadCallout.Show(callout, GridViewCars, $"عملية إضافة السيارة  {GridViewCars.MasterView.TableAddNewRow.Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
    ////                ////this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);
    ////                ////GridViewCars.MasterView.Refresh();

    ////            }
    ////            else
    ////            {
    ////                RadCallout.Show(callout, this.GridViewCars, "فشلت عملية إضافة السيارة !", "فشلت العملية");
    ////            }

    ////        }
    ////        else if (e.ListChangedType == ListChangedType.ItemChanged)
    ////        {
    ////            if (!MessageWarning("هل أنت متأكد من التعديل ؟", "تعديل سيارة", "إذا ضغت علي زر نعم سوف يتم تعديل السيارة \r\n إذا ضغط علي زر لا سوف يتم تجاهل التعديل"))
    ////                return;

    ////            CarsRow dataRow = this.contract_ManagementDataSet.Cars.Where(u => u.ID.ToString() == GridViewCars.Rows[e.NewIndex].Cells[0].Value.ToString()).FirstOrDefault();
    ////            dataRow.CarName = GridViewCars.Rows[e.NewIndex].Cells[1].Value.ToString();
    ////            dataRow.CardID = GridViewCars.Rows[e.NewIndex].Cells[2].Value.ToString();
    ////            dataRow.Note = GridViewCars.Rows[e.NewIndex].Cells[3].Value.ToString();
    ////            int Result = carsTableAdapter.Update(dataRow);

    ////            if (Result > 0)
    ////            {
    ////                ShowDesktopAlert("تعديل سيارة", "تمت عملية تعديل السيارة", $"عملية تعديل السيارة  {GridViewCars.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تم تعديل السيارة يمكن القيام بالعمليات عليها الأن.");
    ////                RadCallout.Show(callout, this.GridViewCars, $"عملية تعديل السيارة  {GridViewCars.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
    ////                ////this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);
    ////                ////GridViewCars.MasterView.Refresh();
    ////            }
    ////            else
    ////            {
    ////                RadCallout.Show(callout, this.GridViewCars, "فشلت عملية تعديل السيارة !", "فشلت العملية");
    ////            }

    ////        }
    ////        else if (e.ListChangedType == ListChangedType.ItemDeleted)
    ////        {
    ////            if (!MessageWarning("هل أنت متأكد من الحذف ؟", "حذف سيارة", "إذا ضغت علي زر نعم سوف يتم حذف السيارة \r\n إذا ضغط علي زر لا سوف يتم تجاهل الحذف"))
    ////                return;

    ////            CarsRow dataRow = this.contract_ManagementDataSet.Cars.Where(u => u.ID.ToString() == GridViewCars.Rows[e.NewIndex].Cells[1].Value.ToString()).FirstOrDefault();
    ////            int Result = carsTableAdapter.Delete(dataRow.ID, dataRow.CarName, dataRow.CardID);
    ////            if (Result > 0)
    ////            {
    ////                ShowDesktopAlert("حذف سيارة", "تمت عملية حذف السيارة بنجاح", $"عملية حذف السيارة  {GridViewCars.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت عملية حذف السيارة من قاعدة البيانات بنجاح.");
    ////                RadCallout.Show(callout, this.GridViewCars, $"عملية حذف السيارة  {GridViewCars.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
    ////                ////this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);
    ////                ////GridViewCars.MasterView.Refresh();
    ////            }
    ////            else
    ////            {
    ////                RadCallout.Show(callout, this.GridViewCars, "فشلت عملية حذف السيارة !", "فشلت العملية");
    ////            }
    ////        }
        }

        private void CompaniesBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {


            if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted)
            {


                this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
                this.companiesBindingSource.ResetBindings(false);


                //GridViewCompanies.DataSource = null;
                //companiesTableAdapter.ClearBeforeFill = true;

                // contract_ManagementDataSet.Companies.Reset();

                ////this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);

                //companiesBindingSource.ResetBindings(true);


                //this.companiesTableAdapter.GetData();

                //GridViewCompanies.DataSource = ii;

                //this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
                // this.companiesBindingSource.DataSource = this.contract_ManagementDataSet;
                //this.companiesBindingSource.DataMember = "Companies";

                //this.GridViewCompanies.MasterTemplate.DataSource = this.companiesBindingSource;

            }
            //companiesBindingSource.Clear();


            //GridViewCompanies
            //            if (IsGrid) { IsGrid = false; return; }
            //            RadCallout callout = new RadCallout();
            //            callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Right;

            //            if (e.ListChangedType == ListChangedType.ItemAdded)
            //            {
            //                if (ISNew) { ISNew = false; return; }

            //                if (!MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة شركة جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة الشركة الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
            //                    return;

            //                int Result = carsTableAdapter.Insert(
            //GridViewCompanies.MasterView.TableAddNewRow.Cells[1].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[1].Value.ToString() : string.Empty,
            //GridViewCompanies.MasterView.TableAddNewRow.Cells[2].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[2].Value.ToString() : string.Empty,
            //GridViewCompanies.MasterView.TableAddNewRow.Cells[3].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[3].Value.ToString() : string.Empty);
            //                ISNew = true;

            //                if (Result > 0)
            //                {
            //                    ShowDesktopAlert("إضافة شركة", "تمت عملية إضافة الشركة بنجاح", $"عملية إضافة الشركة  {GridViewCars.MasterView.TableAddNewRow.Cells[1].Value.ToString()}  تمت بنجاح ", "تمت عملية إضافة الشركة الجديد يمكن القيام بالعمليات عليه الأن.");
            //                    RadCallout.Show(callout, GridViewCompanies, $"عملية إضافة الشركة  {GridViewCars.MasterView.TableAddNewRow.Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
            //                    //this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
            //                    //GridViewCompanies.MasterView.Refresh();

            //                }
            //                else
            //                {
            //                    RadCallout.Show(callout, this.GridViewCompanies, "فشلت عملية إضافة الشركة !", "فشلت العملية");
            //                }
            //            }
            //            else if (e.ListChangedType == ListChangedType.ItemChanged)
            //            {

            //            }
            //            else if (e.ListChangedType == ListChangedType.ItemDeleted)
            //            {
            //                if (!MessageWarning("هل أنت متأكد من الحذف ؟", "حذف شركة", "إذا ضغت علي زر نعم سوف يتم حذف الشركة \r\n إذا ضغط علي زر لا سوف يتم تجاهل الحذف"))
            //                    return;

            //                CompaniesRow dataRow = this.contract_ManagementDataSet.Companies.Where(u => u.ID.ToString() == GridViewCompanies.Rows[e.NewIndex].Cells[1].Value.ToString()).FirstOrDefault();
            //                int Result = companiesTableAdapter.Delete(dataRow.ID, dataRow.CompanyName, dataRow.ClientID);
            //                if (Result > 0)
            //                {
            //                    ShowDesktopAlert("حذف شركة", "تمت عملية حذف الشركة بنجاح", $"عملية حذف الشركة  {GridViewCompanies.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت عملية حذف الشركة من قاعدة البيانات بنجاح.");
            //                    RadCallout.Show(callout, this.GridViewCompanies, $"عملية حذف الشركة  {GridViewCompanies.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
            //                    //////this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
            //                    //////GridViewCompanies.MasterView.Refresh();

            //                }
            //                else
            //                {
            //                    RadCallout.Show(callout, this.GridViewCompanies, "فشلت عملية حذف الشركة !", "فشلت العملية");
            //                }

            //            }

        }



        #endregion


        #region Form Events
        private void HotelApp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Notifications' table. You can move, or remove it, as needed.
            this.notificationsTableAdapter.Fill(this.contract_ManagementDataSet.Notifications);
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

            this.ByanatView.DataSource = this.contract_ManagementDataSet.Byan;
            this.ByanatView.DisplayMember = "ParentType";


            foreach (CompaniesRow item in this.contract_ManagementDataSet.Companies.Rows)
            {
                ListViewDataItem roomTypeItem = new ListViewDataItem(item.CompanyName);
                roomTypeItem.Value = item.CompanyName;
                var CompanyData = contract_ManagementDataSet.Byan.Where(u => u.CompanyName == item.CompanyName).ToList();
                var CarsCount = CompanyData.Where(u => u.ParentType == "سيارة").Count();
                var DriversCount = CompanyData.Where(u => u.ParentType == "سائق").Count();
                int[] ints = new int[] { CarsCount, DriversCount };
                roomTypeItem.Tag = ints;

                roomTypeItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                this.CompaniesView.Items.Add(roomTypeItem);
            }


            this.ByanatView.ShowGroups = true;
            this.ByanatView.EnableGrouping = true;
            GroupDescriptor groupByValue = new GroupDescriptor(new SortDescriptor[]
            {
                new SortDescriptor("ParentType", ListSortDirection.Ascending)
            });

            this.ByanatView.GroupDescriptors.Add(groupByValue);

            ByanatView.SelectedItem = null;

            NotificationGridLayout();

            GridViewDriver.Visible = true;
            GridViewCars.Visible = false;
            GridViewCompanies.Visible = false;
            radBindingNavigator1.BindingSource = this.driverBindingSource;
            editGuestInfo.guestInfoLabel.Text = "بيانات السائق";
            editGuestInfo.nameLabel.Text = "اسم السائق";
            editGuestInfo.nameTextBox.NullText = "ادخل أسم السائق";
            Binding nameControlBinding = new System.Windows.Forms.Binding("Text", this.driverBindingSource, "DriverName", false);
            editGuestInfo.nameTextBox.DataBindings.Clear();

            editGuestInfo.nameTextBox.DataBindings.Add(nameControlBinding);

            editGuestInfo.idLabel.Text = "رقم البطاقة";
            editGuestInfo.idTextBox.NullText = "ادخل رقم البطاقة";
            Binding idControlBinding = new System.Windows.Forms.Binding("Text", this.driverBindingSource, "CardID", false);
            editGuestInfo.idTextBox.DataBindings.Clear();

            editGuestInfo.idTextBox.DataBindings.Add(idControlBinding);

            this.GridViewDriver.AutoGenerateHierarchy = true;
            this.GridViewDriver.TableElement.CellSpacing = 10;
            this.GridViewDriver.RootElement.EnableElementShadow = false;
            this.GridViewDriver.GridViewElement.DrawFill = false;
            this.GridViewDriver.TableElement.Margin = new Padding(15, 0, 15, 0);
            this.GridViewDriver.BackColor = Color.Transparent;
            this.GridViewDriver.GridViewElement.DrawFill = true;
            this.GridViewDriver.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            foreach (GridViewDataColumn col in this.GridViewDriver.Columns)
            {
                col.TextAlignment = ContentAlignment.MiddleCenter;
                col.HeaderTextAlignment = ContentAlignment.MiddleCenter;
            }

            this.GridViewCars.AutoGenerateHierarchy = true;
            this.GridViewCars.TableElement.CellSpacing = 10;
            this.GridViewCars.RootElement.EnableElementShadow = false;
            this.GridViewCars.GridViewElement.DrawFill = false;
            this.GridViewCars.TableElement.Margin = new Padding(15, 0, 15, 0);
            this.GridViewCars.BackColor = Color.Transparent;
            this.GridViewCars.GridViewElement.DrawFill = true;
            this.GridViewCars.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            foreach (GridViewDataColumn col in this.GridViewCars.Columns)
            {
                col.TextAlignment = ContentAlignment.MiddleCenter;
                col.HeaderTextAlignment = ContentAlignment.MiddleCenter;
            }

            this.GridViewCompanies.AutoGenerateHierarchy = true;
            this.GridViewCompanies.TableElement.CellSpacing = 10;
            this.GridViewCompanies.RootElement.EnableElementShadow = false;
            this.GridViewCompanies.GridViewElement.DrawFill = false;
            this.GridViewCompanies.TableElement.Margin = new Padding(15, 0, 15, 0);
            this.GridViewCompanies.BackColor = Color.Transparent;
            this.GridViewCompanies.GridViewElement.DrawFill = true;
            this.GridViewCompanies.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            foreach (GridViewDataColumn col in this.GridViewCompanies.Columns)
            {
                col.TextAlignment = ContentAlignment.MiddleCenter;
                col.HeaderTextAlignment = ContentAlignment.MiddleCenter;
            }

        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            try
            {
                RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));
                ISNew = true;
            }
            catch { return; }

        }

        private void MenuStripOverviewLandsView_Opening(object sender, CancelEventArgs e)
        {
            if (ByanatView.SelectedItem == null) { e.Cancel = true; return; }
        }

        private void RadioButtonDriver_CheckStateChanged(object sender, EventArgs e)
        {

            if (RadioButtonDriver.CheckState == CheckState.Checked)
            {
                GridViewDriver.Visible = true;
                GridViewCars.Visible = false;
                GridViewCompanies.Visible = false;
                radBindingNavigator1.BindingSource = this.driverBindingSource;
                editGuestInfo.guestInfoLabel.Text ="بيانات السائق";
                editGuestInfo.nameLabel.Text = "اسم السائق";
                editGuestInfo.nameTextBox.NullText = "ادخل أسم السائق";
                Binding nameControlBinding = new System.Windows.Forms.Binding("Text", this.driverBindingSource, "DriverName", false);
                editGuestInfo.nameTextBox.DataBindings.Clear();

                editGuestInfo.nameTextBox.DataBindings.Add(nameControlBinding);

                editGuestInfo.idLabel.Text = "رقم البطاقة";
                editGuestInfo.idTextBox.NullText = "ادخل رقم البطاقة";
                Binding idControlBinding = new System.Windows.Forms.Binding("Text", this.driverBindingSource, "CardID", false);
                editGuestInfo.idTextBox.DataBindings.Clear();

                editGuestInfo.idTextBox.DataBindings.Add(idControlBinding);

                labelBookings.Text = "   الساقين";
            }
            else
            {
                if (RadioButtonCars.CheckState == CheckState.Checked)
                {
                    GridViewCars.Visible = true;
                    GridViewDriver.Visible = false;
                    GridViewCompanies.Visible = false;

                    editGuestInfo.guestInfoLabel.Text = "بيانات السيارة";
                    editGuestInfo.nameLabel.Text = "رقم الصهريج";
                    editGuestInfo.nameTextBox.NullText = "ادخل رقم الصهريج";
                    editGuestInfo.nameLabel.Text = "رقم البطاقة";
                    editGuestInfo.nameTextBox.NullText = "ادخل رقم البطاقة";

                    radBindingNavigator1.BindingSource = this.carsBindingSource;
                    Binding nameControlBinding = new System.Windows.Forms.Binding("Text", this.carsBindingSource, "CarName", false);
                    editGuestInfo.nameTextBox.DataBindings.Clear();

                    editGuestInfo.nameTextBox.DataBindings.Add(nameControlBinding);
                    Binding idControlBinding = new System.Windows.Forms.Binding("Text", this.carsBindingSource, "CardID", false);
                    editGuestInfo.idTextBox.DataBindings.Clear();

                    editGuestInfo.idTextBox.DataBindings.Add(idControlBinding);
                    labelBookings.Text = "   السيارات";

                }
                else
                {
                    GridViewCompanies.Visible = true;
                    GridViewDriver.Visible = false;
                    GridViewCars.Visible = false;

                    editGuestInfo.guestInfoLabel.Text = "بيانات الشركة";
                    editGuestInfo.nameLabel.Text = "اسم الشركة";
                    editGuestInfo.nameTextBox.NullText = "ادخل اسم الشركة";
                    editGuestInfo.nameLabel.Text = "رقم العميل";
                    editGuestInfo.nameTextBox.NullText = "ادخل رقم العميل";

                    radBindingNavigator1.BindingSource = this.companiesBindingSource;
                    Binding nameControlBinding = new System.Windows.Forms.Binding("Text", this.companiesBindingSource, "CompanyName", false);
                    editGuestInfo.nameTextBox.DataBindings.Clear();
                    editGuestInfo.nameTextBox.DataBindings.Add(nameControlBinding);
                    Binding idControlBinding = new System.Windows.Forms.Binding("Text", this.companiesBindingSource, "ClientID", false);
                    editGuestInfo.idTextBox.DataBindings.Clear();
                    editGuestInfo.idTextBox.DataBindings.Add(idControlBinding);
                    labelBookings.Text = "   الشركات";

                }

            }


        }

        private void ButtonSelectAllType_Click(object sender, EventArgs e)
        {
            if (ButtonSelectAllType.Text == "تحديد الكل")
            {
                CheckBoxCars.Checked = true;
                CheckBoxDrivers.Checked = true;
            }
            else if (ButtonSelectAllType.Text == "إلغاء الكل")
            {
                CheckBoxCars.Checked = false;
                CheckBoxDrivers.Checked = false;

            }

        }

        private void CheckBoxDrivers_CheckStateChanged(object sender, EventArgs e)
        {
            if (CheckBoxDrivers.Checked) 
            {
                ByanatView.Groups[0].Visible = true;

                foreach (ListViewDataItem item in ByanatView.Groups[0].Items)
                {
                    DataRowView data = item.DataBoundItem as DataRowView;
                    ByanRow row = data.Row as ByanRow;
                    var companyItem = CompaniesView.Items.Where(u => u.Text == row.CompanyName).FirstOrDefault();
                    if (companyItem.CheckState == ToggleState.On)
                    {
                        item.Visible = true;

                    }

                }

                if (CheckBoxDrivers.Checked && CheckBoxCars.Checked) { ButtonSelectAllType.Text = "إلغاء الكل"; }
            }
            else if (!CheckBoxDrivers.Checked)
            {

                ByanatView.Groups[0].Visible = false;

                foreach(var item in ByanatView.Groups[0].Items)
                {
                    item.Visible = false;

                }

                ButtonSelectAllType.Text = "تحديد الكل";
            }

        }

        private void CheckBoxCars_CheckStateChanged(object sender, EventArgs e)
        {
            if (CheckBoxCars.Checked)
            {
                ByanatView.Groups[1].Visible = true;

                foreach (ListViewDataItem item in ByanatView.Groups[1].Items)
                {
                    DataRowView data = item.DataBoundItem as DataRowView;
                    ByanRow row = data.Row as ByanRow;
                    var companyItem = CompaniesView.Items.Where(u => u.Text == row.CompanyName).FirstOrDefault();
                    if (companyItem.CheckState == ToggleState.On)
                    {
                        item.Visible = true;

                    }

                }
                if (CheckBoxDrivers.Checked && CheckBoxCars.Checked) { ButtonSelectAllType.Text = "إلغاء الكل"; }
            }
            else if (!CheckBoxCars.Checked)
            {
                ByanatView.Groups[1].Visible = false;

                foreach (ListViewDataItem item in ByanatView.Groups[1].Items)
                {
                    item.Visible = false;

                }
                ButtonSelectAllType.Text = "تحديد الكل";
            }

        }

        private void ButtonSelectAllCompanies_Click(object sender, EventArgs e)
        {
            if (ButtonSelectAllCompanies.Text == "تحديد الكل")
            {
                foreach (ListViewDataItem item in CompaniesView.Items)
                {
                    item.CheckState = ToggleState.On;
                }

            }
            else if (ButtonSelectAllCompanies.Text == "إلغاء الكل")
            {
                foreach (ListViewDataItem item in CompaniesView.Items)
                {
                    item.CheckState = ToggleState.Off;
                }

            }

        }

        private void TmrStatic_Tick(object sender, EventArgs e)
        {
            NotificationMethod();
        }

        private void HotelAppForm_Shown(object sender, EventArgs e)
        {
            TmrStatic.Start();

        }

        #endregion

        #region Search

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.searchTextBoxOverview.Text == string.Empty)
            {
                this.ByanatView.FilterPredicate = null;
            }
            else
            {
                this.ByanatView.FilterPredicate = null;
                this.ByanatView.FilterPredicate = FilterPredicate;
            }
        }

        private bool FilterPredicate(ListViewDataItem item)
        {
            if (this.searchTextBoxOverview.Text != string.Empty)
            {
                DataRowView data = item.DataBoundItem as DataRowView;
                ByanRow row = data.Row as ByanRow;
                if (row.ID.ToString().ToLower().Contains(this.searchTextBoxOverview.Text.ToLower()))
                {
                    return true;
                }
                else if (row.ParentType.ToString().ToLower().Contains(this.searchTextBoxOverview.Text.ToLower()))
                {
                    return true;
                }
                else if (row.ParentName.ToString().ToLower().Contains(this.searchTextBoxOverview.Text.ToLower()))
                {
                    return true;
                }
                else if (row.CompanyName.ToString().ToLower().Contains(this.searchTextBoxOverview.Text.ToLower()))
                {
                    return true;
                }
                else if (row.EndDate.ToString().ToLower().Contains(this.searchTextBoxOverview.Text.ToLower()))
                {
                    return true;
                }
                if (!(row.ItemArray[6] is DBNull))
                {
                    if (row.ItemArray[6].ToString().Contains(this.searchTextBoxOverview.Text))
                    {
                        return true;
                    }

                }

                return false;
            }

            return true;
        }

//        private void GridViewDriver_UserAddedRow(object sender, GridViewRowEventArgs e)
//        {

//            RadCallout callout = new RadCallout
//            {
//                ArrowDirection = Telerik.WinControls.ArrowDirection.Right
//            };

//            if (ISNew) { ISNew = false; return; }

//            if (!MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة شركة جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة الشركة الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
//                return;

//            int Result = carsTableAdapter.Insert(
//GridViewCompanies.MasterView.TableAddNewRow.Cells[1].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[1].Value.ToString() : string.Empty,
//GridViewCompanies.MasterView.TableAddNewRow.Cells[2].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[2].Value.ToString() : string.Empty,
//GridViewCompanies.MasterView.TableAddNewRow.Cells[3].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[3].Value.ToString() : string.Empty);
//            ISNew = true;

//            if (Result > 0)
//            {
//                ShowDesktopAlert("إضافة شركة", "تمت عملية إضافة الشركة بنجاح", $"عملية إضافة الشركة  {GridViewCars.MasterView.TableAddNewRow.Cells[1].Value.ToString()}  تمت بنجاح ", "تمت عملية إضافة الشركة الجديد يمكن القيام بالعمليات عليه الأن.");
//                RadCallout.Show(callout, GridViewCompanies, $"عملية إضافة الشركة  {GridViewCars.MasterView.TableAddNewRow.Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
//                //this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
//                //GridViewCompanies.MasterView.Refresh();

//            }
//            else
//            {
//                RadCallout.Show(callout, this.GridViewCompanies, "فشلت عملية إضافة الشركة !", "فشلت العملية");
//            }


//            // DataRow[] rows = new DataRow[e.Rows.Length];
//            //for (int i = 0; i < e.Rows.Length; i++)
//            //{
//            //    DataRowView dataRowView = e.Rows[i].DataBoundItem as DataRowView;
//            //    if (dataRowView != null)
//            //    {
//            //        rows[i] = dataRowView.Row;
//            //    }
//            //}
//            //this.employeesTableAdapter.Update(rows);
//        }


        private void commandBarLabel1_TextChanged(object sender, EventArgs e)
        {
            string NewTxt = commandBarLabel1.Text.Replace("of", "من");
            commandBarLabel1.Text = NewTxt;

        }

        //private void GridViewDriver_UserDeletedRow(object sender, GridViewRowEventArgs e)
        //{
        //    RadCallout callout = new RadCallout();
        //    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Right;

        //    if (!MessageWarning("هل أنت متأكد من الحذف ؟", "حذف شركة", "إذا ضغت علي زر نعم سوف يتم حذف الشركة \r\n إذا ضغط علي زر لا سوف يتم تجاهل الحذف"))
        //        return;

        //    //CompaniesRow dataRow = this.contract_ManagementDataSet.Companies.Where(u => u.ID.ToString() == GridViewCompanies.Rows[e.NewIndex].Cells[1].Value.ToString()).FirstOrDefault();
        //    //int Result = companiesTableAdapter.Delete(dataRow.ID, dataRow.CompanyName, dataRow.ClientID);
        //    //if (Result > 0)
        //    //{
        //    //    //ShowDesktopAlert("حذف شركة", "تمت عملية حذف الشركة بنجاح", $"عملية حذف الشركة  {GridViewCompanies.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت عملية حذف الشركة من قاعدة البيانات بنجاح.");
        //    //    //RadCallout.Show(callout, this.GridViewCompanies, $"عملية حذف الشركة  {GridViewCompanies.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
        //    //    //////this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
        //    //    //////GridViewCompanies.MasterView.Refresh();

        //    //}
        //    //else
        //    //{
        //    //    RadCallout.Show(callout, this.GridViewCompanies, "فشلت عملية حذف الشركة !", "فشلت العملية");
        //    //}

        //}

        //private void GridViewDriver_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        //{

        //}

        //private void GridViewDriver_RowValidated(object sender, RowValidatedEventArgs e)
        //{
        //    ////if (!MessageWarning("هل أنت متأكد من التعديل ؟", "تعديل شركة", "إذا ضغت علي زر نعم سوف يتم تعديل الشركة \r\n إذا ضغط علي زر لا سوف يتم تجاهل التعديل"))
        //    ////    return;

        //    //CompaniesRow dataRow = this.contract_ManagementDataSet.Companies.Where(u => u.ID.ToString() == GridViewCompanies.Rows[e.NewIndex].Cells[0].Value.ToString()).FirstOrDefault();
        //    //dataRow.CompanyName = GridViewCompanies.Rows[e.NewIndex].Cells[1].Value.ToString();
        //    //dataRow.ClientID = GridViewCompanies.Rows[e.NewIndex].Cells[2].Value.ToString();
        //    //dataRow.Note = GridViewCompanies.Rows[e.NewIndex].Cells[3].Value.ToString();
        //    //int Result = companiesTableAdapter.Update(dataRow);

        //    //if (Result > 0)
        //    //{
        //    //    ShowDesktopAlert("تعديل شركة", "تمت عملية تعديل الشركة", $"عملية تعديل الشركة  {GridViewCompanies.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تم تعديل الشركة يمكن القيام بالعمليات عليها الأن.");
        //    //    RadCallout.Show(callout, this.GridViewCompanies, $"عملية تعديل الشركة  {GridViewCompanies.Rows[e.NewIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");
        //    //    //this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
        //    //    //GridViewCompanies.MasterView.Refresh();

        //    //}
        //    //else
        //    //{
        //    //    RadCallout.Show(callout, this.GridViewCompanies, "فشلت عملية تعديل الشركة !", "فشلت العملية");
        //    //}

        //}

        //private void GridViewCompanies_UserAddedRow(object sender, GridViewRowEventArgs e)
        //{

        //}

        //private void GridViewCompanies_UserDeletedRow(object sender, GridViewRowEventArgs e)
        //{

        //}

        //private void GridViewCompanies_UserAddingRow(object sender, GridViewRowCancelEventArgs e)
        //{

        //    if (ISNew) { ISNew = false; return; }

        //    if (!MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة شركة جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة الشركة الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
        //    {
        //        e.Cancel = true;
        //        return;

        //    }

        //    IsGrid = true;

        //    string CarName = GridViewCompanies.MasterView.TableAddNewRow.Cells[1].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[1].Value.ToString() : string.Empty;
        //    string CardID = GridViewCompanies.MasterView.TableAddNewRow.Cells[2].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[2].Value.ToString() : string.Empty;
        //    string Note = GridViewCompanies.MasterView.TableAddNewRow.Cells[3].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[3].Value.ToString() : string.Empty;

        //    int Result = carsTableAdapter.Insert(CarName, CardID, Note);

        //    ISNew = true;

        //    RadCallout callout = new RadCallout
        //    {
        //        ArrowDirection = Telerik.WinControls.ArrowDirection.Right
        //    };

        //    if (Result > 0)
        //    {
               
        //        ShowDesktopAlert("إضافة شركة", "تمت عملية إضافة الشركة بنجاح", $"عملية إضافة الشركة  {CarName}  تمت بنجاح ", "تمت عملية إضافة الشركة الجديد يمكن القيام بالعمليات عليه الأن.");
        //        RadCallout.Show(callout, GridViewCompanies, $"عملية إضافة الشركة  {CarName}  تمت بنجاح ", "تمت العملية بنجاح");

        //    }
        //    else
        //    {
        //        RadCallout.Show(callout, this.GridViewCompanies, "فشلت عملية إضافة الشركة !", "فشلت العملية");
        //    }

        //}

        //private void GridViewCompanies_UserDeletingRow(object sender, GridViewRowCancelEventArgs e)
        //{

        //}

        //private void GridViewCompanies_Validating(object sender, CancelEventArgs e)
        //{

        //}

        //private void GridViewCompanies_RowValidating(object sender, RowValidatingEventArgs e)
        //{

        //}

        //private void GridViewCompanies_Click(object sender, EventArgs e)
        //{

        //}

        //private void commandBarButton5_Click(object sender, EventArgs e)
        //{
        //    ISNew = true;
        //}

        //private void GridViewCompanies_RowsChanging(object sender, GridViewCollectionChangingEventArgs e)
        //{
        //    if (e.NewStartingIndex == -1) { return; }
        //    if (e.Action == NotifyCollectionChangedAction.ItemChanging)
        //    {
        //        if (e.NewValue  != e.OldValue) 
        //        {
        //            IsUpdate = true;
        //            if (!IsUpdate) { IsUpdate = false; return; }

        //            if (ISNew)
        //            {
        //                return;
        //            }
        //            if (!MessageWarning("هل أنت متأكد من التعديل ؟", "تعديل شركة", "إذا ضغت علي زر نعم سوف يتم تعديل الشركة \r\n إذا ضغط علي زر لا سوف يتم تجاهل التعديل"))
        //            {
        //                e.Cancel = true;
        //                IsUpdate = false;

        //                companiesBindingSource.ResetCurrentItem();
        //                companiesBindingSource.ResetItem(e.NewStartingIndex);
        //                //GridViewCompanies.Rows[e.NewStartingIndex].Cells[1].Value = e.Row.Cells[1].Value;
        //                //GridViewCompanies.Rows[e.RowIndex].Cells[2].Value = e.Row.Cells[2].Value;
        //                //GridViewCompanies.Rows[e.RowIndex].Cells[3].Value = e.Row.Cells[3].Value;
        //                return;

        //            }

        //            CompaniesRow dataRow = this.contract_ManagementDataSet.Companies.Where(u => u.ID.ToString() == GridViewCompanies.Rows[e.NewStartingIndex].Cells[0].Value.ToString()).FirstOrDefault();
        //            dataRow.CompanyName = GridViewCompanies.Rows[e.NewStartingIndex].Cells[1].Value.ToString();
        //            dataRow.ClientID = GridViewCompanies.Rows[e.NewStartingIndex].Cells[2].Value.ToString();
        //            dataRow.Note = GridViewCompanies.Rows[e.NewStartingIndex].Cells[3].Value.ToString();
        //            int Result = companiesTableAdapter.Update(dataRow);

        //            RadCallout callout = new RadCallout
        //            {
        //                ArrowDirection = Telerik.WinControls.ArrowDirection.Right
        //            };

        //            if (Result > 0)
        //            {
        //                ShowDesktopAlert("تعديل شركة", "تمت عملية تعديل الشركة", $"عملية تعديل الشركة  {GridViewCompanies.Rows[e.NewStartingIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تم تعديل الشركة يمكن القيام بالعمليات عليها الأن.");
        //                RadCallout.Show(callout, this.GridViewCompanies, $"عملية تعديل الشركة  {GridViewCompanies.Rows[e.NewStartingIndex].Cells[1].Value.ToString()}  تمت بنجاح ", "تمت العملية بنجاح");

        //            }
        //            else
        //            {
        //                RadCallout.Show(callout, this.GridViewCompanies, "فشلت عملية تعديل الشركة !", "فشلت العملية");
        //            }

        //        }
        //    }

        //}



        #endregion

        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {
            DoctorHelper.Reports.Reports.InitReport(rpt, "CarsReport.frx", false);

            DataSet dataSet = new DataSet();

            DataTable dt = new DataTable();
            dt = contract_ManagementDataSet.Driver.Copy();
            dt.TableName = "data";
            dataSet.Tables.Add(dt);

            rpt.RegisterData(dt, "data");
            return true;
        }

        private void MenuDesign_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            if (Readyreport(report))
                Reports.DesignReport(report);
        }


        private void MenuPreview_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            if (Readyreport(report))
                report.Show();
        }

        private void MenuPrint_Click(object sender, EventArgs e)
        {
            FastReport.Report report = new FastReport.Report();
            if (Readyreport(report))
                report.Print();
        }

        #endregion


    }
}