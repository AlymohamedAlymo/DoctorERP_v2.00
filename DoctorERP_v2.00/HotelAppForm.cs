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
using Telerik.WinControls.Extensions;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI.SplashScreen;
using static DoctorERP_v2_00.Contract_ManagementDataSet;

namespace HotelApp
{
    partial class HotelAppForm : RadToolbarForm
    {
        private bool ISNew = false;
        private string FlyOutTypeReturn = string.Empty, FlyOutParenterReturn = string.Empty, FlyOutCompanyReturn = string.Empty, FlyOutNoteReturn = string.Empty;
        private DateTime FlyOutEndDateReturn;



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


            this.ByanatView.VisualItemCreating += roomsView_VisualItemCreating;
            this.CompaniesView.VisualItemCreating += leftView_VisualItemCreating;

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

            //RadButtonElement searchButton = new RadButtonElement();

            //searchButton.ButtonFillElement.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            //searchButton.ShowBorder = false;
            //searchButton.EnableElementShadow = false;
            //this.searchTextBoxOverview.TextBoxElement.Padding = new Padding(0);
            //this.searchTextBoxOverview.ShowClearButton = true;
            //searchButton.Margin = new Padding(0, 0, 0, 0);
            //this.searchTextBoxOverview.TextBoxElement.TextBoxItem.CustomFont = Utils.MainFont;
            //this.searchTextBoxOverview.TextBoxElement.TextBoxItem.CustomFontSize = 9;
            radLabel3.RootElement.CustomFont = "TelerikWebUI";
            radLabel3.RootElement.CustomFontSize = 12;
            radLabel3.RootElement.ForeColor = Color.Gray;
            radLabel3.RootElement.MaxSize = new System.Drawing.Size(40, 35);
            radLabel3.Text = "\ue13E";
            //StackLayoutElement stackPanel = new StackLayoutElement();
            //stackPanel.Orientation = Orientation.Horizontal;
            //stackPanel.Margin = new Padding(1, 0, 1, 0);
            //stackPanel.Children.Add(searchButton);
            //RadTextBoxItem tbItem = this.searchTextBoxOverview.TextBoxElement.TextBoxItem;
            ////this.searchTextBoxOverview.TextBoxElement.Children.Remove(tbItem);
            //DockLayoutPanel dockPanel = new DockLayoutPanel();
            //dockPanel.Children.Add(stackPanel);
            //dockPanel.Children.Add(tbItem);
            //DockLayoutPanel.SetDock(tbItem, Telerik.WinControls.Layouts.Dock.Left);
            //DockLayoutPanel.SetDock(stackPanel, Telerik.WinControls.Layouts.Dock.Right);
            //this.searchTextBoxOverview.TextBoxElement.Children.Add(dockPanel);
            //this.searchTextBoxOverview.ShowClearButton = true;
            //this.searchTextBoxOverview.TextBoxElement.ClearButton.Visibility = ElementVisibility.Visible;


            #endregion

        }

        #region Method

        //private void ShowNotification(string Header, string Content, string Note)
        //{
        //    radToastNotificationManager1.ToastNotifications[0].Xml = "<toast launch=\"readMoreArg\">\r\n  <visual>\r\n    <binding template=\"ToastGeneric\">\r\n   " +
        //        "   <text>" + Header + "</text>\r\n   " +
        //        "   <text>" + Content + "</text>\r\n  " +
        //        "    <text placement=\"attribution\">" + Note + "</text>\r\n    </binding>\r\n  </visual>\r\n</toast>";
        //    radToastNotificationManager1.ShowNotification(0);

        //}
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
                }

            };
            page.CommandAreaButtons[0].Text = "نعم";
            page.CommandAreaButtons[1].Text = "لا";
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
            page.CommandAreaButtons[0].Text = "موافق";
            RadTaskDialogButton result = RadTaskDialog.ShowDialog(page, RadTaskDialogStartupLocation.CenterScreen);
            return true;
        }
        private void ShowDesktopAlert(string Header, string Content, string ContentHighlight, string Footer)
        {
            Content = TextHelper.ReverseText(Content);
            ContentHighlight = TextHelper.ReverseText(ContentHighlight);
            Footer = TextHelper.ReverseText(Footer);

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

        #endregion


        #region Flyout
        private void RadFlyoutManager_ContentCreated(ContentCreatedEventArgs e)
        {
            Telerik.WinControls.Extensions.Action action = new Telerik.WinControls.Extensions.Action(() =>
            {
                if (e.Content is FlyoutAddByanat)
                {
                    RadCallout callout = new RadCallout();
                    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Up;

                    FlyoutAddByanat content = e.Content as FlyoutAddByanat;
                    if (content != null)
                    {




                        content.driverBindingSource.DataSource = this.contract_ManagementDataSet;
                        content.carsBindingSource.DataSource = this.contract_ManagementDataSet;
                        content.companiesBindingSource.DataSource = this.contract_ManagementDataSet;


                        if (FlyOutTypeReturn != string.Empty) 
                        {
                            if (FlyOutTypeReturn == "سائق")
                            {
                                content.CMBParentType.SelectedIndex = 0;
                                FlyOutTypeReturn = string.Empty;
                                return;

                            }
                            else if (FlyOutTypeReturn == "سيارة")
                            {
                                content.CMBParentType.SelectedIndex = 1;
                                FlyOutTypeReturn = string.Empty;

                                return;

                            }


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
                        content.TXBNote.Text = row.Note;


                        content.saveButton.Text = "تعديل";
                        content.radButton3.Text = "حذف";

                        content.MCCDriverName.Select();

                    }
                    else
                    {
                        //RadCallout.Show(callout, this.BtnReservation, "فشلت عملية تنشيط بطاقة العميل!", "فشلت العملية");
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

                    FlyoutAddByanat content = e.Content as FlyoutAddByanat;
                    if (content != null)
                    {
                        if (content.Result == DialogResult.No)
                        {
                            FlyOutTypeReturn = content.CMBParentType.Text;

                            RadFlyoutManager.Show(this, typeof(FlyoutAddCompany));

                        }
                        else if (content.Result == DialogResult.Yes)
                        {
                            if (content.CMBParentType.Text == "سائق")
                            {
                                FlyOutTypeReturn = content.CMBParentType.Text;
                                RadFlyoutManager.Show(this, typeof(FlyoutAddDriver));

                            }
                            else if (content.CMBParentType.Text == "سيارة")
                            {
                                FlyOutTypeReturn = content.CMBParentType.Text;

                                RadFlyoutManager.Show(this, typeof(FlyoutAddCar));

                            }


                        }
                        else if (content.Result == DialogResult.OK)
                        {
                            if (content.saveButton.Text == "حفظ")
                            {
                                int Result = byanTableAdapter.Insert(content.Type, content.ParentName, content.Company, DateTime.Now, content.EndDate, content.Note);

                                if (Result > 0)
                                {
                                    this.byanTableAdapter.Fill(this.contract_ManagementDataSet.Byan);
                                    ShowDesktopAlert("تنشيط بطاقة عميل", "تنشيط بطاقة العميل", "تمت عملية تنشيط البطاقة بنجاح", "تم تنشيط بطاقة العميل يمكن القيام بالعمليات عليها الأن.");
                                    RadCallout.Show(callout, this.radButton1, $"عملية إضافة البيان {content.ParentName} تمت!" + $"و المرتبط بشركة  {content.Company}", "تمت العملية بنجاح");

                                }
                                else
                                {
                                    RadCallout.Show(callout, this.radButton1, "فشلت عملية إضافة البيان !", "فشلت العملية");

                                }

                            }
                            else if (content.saveButton.Text == "تعديل")
                            {

                                DataRowView data = ByanatView.CurrentItem.DataBoundItem as DataRowView;
                                ByanRow row = data.Row as ByanRow;

                                ByanRow dataRow = this.contract_ManagementDataSet.Byan.Where(u => u.ID == row.ID).FirstOrDefault();
                                dataRow.ParentType = content.Type;
                                dataRow.ParentName = content.ParentName;
                                dataRow.CompanyName = content.Company;
                                dataRow.EndDate = content.EndDate;
                                dataRow.Note = content.Note;
                                int Result = byanTableAdapter.Update(dataRow);

                                if (Result > 0)
                                {
                                    this.byanTableAdapter.Fill(this.contract_ManagementDataSet.Byan);
                                    ShowDesktopAlert("تنشيط بطاقة عميل", "تنشيط بطاقة العميل", "تمت عملية تنشيط البطاقة بنجاح", "تم تنشيط بطاقة العميل يمكن القيام بالعمليات عليها الأن.");
                                    RadCallout.Show(callout, this.radButton1, $"عملية تعديل البيان {content.ParentName} تمت!" + $"و المرتبط بشركة  {content.Company}", "تمت العملية بنجاح");

                                }
                                else
                                {
                                    RadCallout.Show(callout, this.radButton1, "فشلت عملية تعديل البيان !", "فشلت العملية");

                                }

                            }

                        }
                        else if (content.Result == DialogResult.Abort)
                        {

                            DataRowView data = ByanatView.CurrentItem.DataBoundItem as DataRowView;
                            ByanRow row = data.Row as ByanRow;

                            ByanRow dataRow = this.contract_ManagementDataSet.Byan.Where(u => u.ID == row.ID).FirstOrDefault();
                            int Result = byanTableAdapter.Delete(dataRow.ID, dataRow.ParentType, dataRow.ParentName, dataRow.CompanyName, dataRow.StartDate, dataRow.EndDate);
                            if (Result > 0)
                            {
                                this.byanTableAdapter.Fill(this.contract_ManagementDataSet.Byan);
                                ShowDesktopAlert("حذف بيان", "عملية حذف بيان", "تمت عملية حذف البيان بنجاح", "تمت عملية حذف البيان من قاعدة البيانات بنجاح.");
                                RadCallout.Show(callout, this.radButton1, $"عملية حذف البيان {content.ParentName} تمت!" + $"و المرتبط بشركة  {content.Company}", "تمت العملية بنجاح");

                            }
                            else
                            {
                                RadCallout.Show(callout, this.radButton1, "فشلت عملية حذف البيان !", "فشلت العملية");

                            }


                        }

                    }
                    else
                        {
                            //RadCallout.Show(callout, this.BtnReservation, "فشلت عملية تنشيط بطاقة العميل!", "فشلت العملية");
                        }
                    }
                else if (e.Content is FlyoutAddDriver)
                {
                    RadCallout callout = new RadCallout();
                    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Up;

                    FlyoutAddDriver content = e.Content as FlyoutAddDriver;
                    if (content != null)
                    {
                        if (content.Result == DialogResult.OK)
                        {

                            int Result = driverTableAdapter.Insert(content.ParentName, content.ParentCardID, content.Note);

                            if (Result > 0)
                            {
                                this.driverTableAdapter.Fill(this.contract_ManagementDataSet.Driver);
                                ShowDesktopAlert("إضافة سائق", "إضافة سائق جديد", "تمت عملية إضافة سائق الجديد بنجاح", "تمت عملية إضافة سائق الجديد يمكن القيام بالعمليات عليها الأن.");
                                RadCallout.Show(callout, this.radButton1, $"عملية إضافة السائق {content.ParentName} تمت!", "تمت العملية بنجاح");

                            }
                            else
                            {
                                RadCallout.Show(callout, this.radButton1, "فشلت عملية إضافة السائق !", "فشلت العملية");

                            }

                        }
                        RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));

                    }
                    else
                    {
                        //RadCallout.Show(callout, this.BtnReservation, "فشلت عملية تنشيط بطاقة العميل!", "فشلت العملية");
                    }
                }
                else if (e.Content is FlyoutAddCar)
                {
                    RadCallout callout = new RadCallout();
                    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Up;

                    FlyoutAddCar content = e.Content as FlyoutAddCar;
                    if (content != null)
                    {
                        if (content.Result == DialogResult.OK)
                        {

                            int Result = carsTableAdapter.Insert(content.ParentName, content.ParentName, content.Note);

                            if (Result > 0)
                            {
                                this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);
                                ShowDesktopAlert("إضافة سيارة", "إضافة سيارة جديد", "تمت عملية إضافة سيارة الجديد بنجاح", "تمت عملية إضافة السيارة الجديد يمكن القيام بالعمليات عليها الأن.");
                                RadCallout.Show(callout, this.radButton1, $"عملية إضافة السيارة {content.ParentName} تمت!", "تمت العملية بنجاح");

                            }
                            else
                            {
                                RadCallout.Show(callout, this.radButton1, "فشلت عملية إضافة السيارة !", "فشلت العملية");

                            }

                        }
                        RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));

                    }
                    else
                    {
                        //RadCallout.Show(callout, this.BtnReservation, "فشلت عملية تنشيط بطاقة العميل!", "فشلت العملية");
                    }
                }
                else if (e.Content is FlyoutAddCompany)
                {
                    RadCallout callout = new RadCallout();
                    callout.ArrowDirection = Telerik.WinControls.ArrowDirection.Up;

                    FlyoutAddCompany content = e.Content as FlyoutAddCompany;
                    if (content != null)
                    {
                        if (content.Result == DialogResult.OK)
                        {

                            int Result = companiesTableAdapter.Insert(content.ParentName, content.ParentName, content.Note);

                            if (Result > 0)
                            {
                                this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
                                ShowDesktopAlert("إضافة شركة", "إضافة شركة جديد", "تمت عملية إضافة الشركة الجديد بنجاح", "تمت عملية إضافة الشركة الجديد يمكن القيام بالعمليات عليها الأن.");
                                RadCallout.Show(callout, this.radButton1, $"عملية إضافة الشركة {content.ParentName} تمت!", "تمت العملية بنجاح");

                            }
                            else
                            {
                                RadCallout.Show(callout, this.radButton1, "فشلت عملية إضافة الشركة !", "فشلت العملية");

                            }

                        }
                        RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));

                    }
                    else
                    {
                        //RadCallout.Show(callout, this.BtnReservation, "فشلت عملية تنشيط بطاقة العميل!", "فشلت العملية");
                    }
                }


            });

            this.Invoke(action);
        }

        #endregion


        #region List View 
        private void leftView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is SimpleListViewVisualItem)
            {
                e.VisualItem = new OptionsSimpleListViewVisualItem();
            }
        }

        private void OverViewList_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            DataRowView data = e.Item.DataBoundItem as DataRowView;
            ByanRow row = data.Row as ByanRow;
            if (row != null)
            {
                RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));
            }
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
                ButtonSelectAllCompanies.Text = "إلغاء الكل";
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
        private void roomsView_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.VisualItem is IconListViewVisualItem)
            {
                e.VisualItem = new RoomIconListViewVisualItem();
            }
        }

        #endregion

        #endregion

        #region Form Events
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
                var CompanyData = contract_ManagementDataSet.Byan.Where(u => u.CompanyName == item.CompanyName).ToList();
                var CarsCount = CompanyData.Where(u => u.ParentType == "سيارة").Count();
                var DriversCount = CompanyData.Where(u => u.ParentType == "سائق").Count();
                int[] ints = new int[] { CarsCount, DriversCount };
                roomTypeItem.Tag = ints;

                roomTypeItem.CheckState = Telerik.WinControls.Enumerations.ToggleState.On;
                //roomTypeItem.Group = CompaniesGroup;
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


            //GridViewNotification.DataSource = this.contract_ManagementDataSet.NotificationView;
            //foreach (var row in GridViewNotification.Rows)
            //{
            //    row.Cells[0].Value = DoctorERP_v2_00.Properties.Resources.DriverRed_30;
            //    row.Cells[12].Value = "منتهي";


            //}
            GridViewNotification.Rows[0].Cells[0].Value = DoctorERP_v2_00.Properties.Resources.DriverRed_32;
            GridViewNotification.Rows[0].Cells[11].Value = "منتهي";
            GridViewNotification.Rows[1].Cells[0].Value = DoctorERP_v2_00.Properties.Resources.DriverOrange_32;
            GridViewNotification.Rows[1].Cells[11].Value = "أوشك";

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





        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                RadFlyoutManager.Close();
                RadFlyoutManager.Show(this, typeof(FlyoutAddByanat));
                ISNew = true;


            }
            catch { }

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

                ButtonSelectAllType.Text = "إلغاء الكل";
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
                ButtonSelectAllType.Text = "إلغاء الكل";
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
            //this.CompaniesView.ListViewElement.SynchronizeVisualItems();
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
                else if (row.CompanyName.ToString().ToLower().Contains(this.searchTextBoxOverview.Text.ToLower()))
                {
                    return true;
                }
                else if (row.ParentName.ToString().ToLower().Contains(this.searchTextBoxOverview.Text.ToLower()))
                {
                    return true;
                }
                else if (row.ParentType.ToString().ToLower().Contains(this.searchTextBoxOverview.Text.ToLower()))
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

        #endregion

        #region report and print
        private bool Readyreport(FastReport.Report rpt)
        {
            //Reports.GenerateReport(ReportTitle, DataGridMain, dgvManager.mBoundDataView.ToTable());
            DoctorHelper.Reports.Reports.InitReport(rpt, "CarsReport.frx", false);

            //rpt.SetParameterValue("UserName", FrmMain.CurrentUser.name);

            //rpt.SetParameterValue("StartDate", dtStartDate.Value);
            //rpt.SetParameterValue("EndDate", dtEndDate.Value);

            //decimal bank = CalcColumnTotal(DataGridMain, DataGridMain.Columns["bank"]);
            //decimal cash = CalcColumnTotal(DataGridMain, DataGridMain.Columns["cash"]);

            //tbAgent.Fill("agenttype", 0);


            DataSet dataSet = new DataSet();

            DataTable dt = new DataTable();
            dt = contract_ManagementDataSet.Driver.Copy();
            dt.TableName = "data";
            dataSet.Tables.Add(dt);

            rpt.RegisterData(dt, "data");
            //////rpt.RegisterData(tbAgent.dtData, "ownerdata");



            //rpt.SetParameterValue("totaltext", ArabicFigures.GetArabicFigure((long)(bank + cash), ArabicFigures.Con));

            //rpt.RegisterData(dgvManager.mBoundDataView.ToTable(), "data");

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

        ////private void MenuPrint_Click(object sender, EventArgs e)
        ////{
        ////    FastReport.Report report = new FastReport.Report();
        ////    if (Readyreport(report))
        ////        report.Print();
        ////}

        #endregion


    }
}