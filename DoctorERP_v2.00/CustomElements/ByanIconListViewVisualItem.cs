using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static Contract_Management.Contract_ManagementDataSet;

namespace Contract_Management
{
    public class ByanIconListViewVisualItem : IconListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(IconListViewVisualItem);
            }
        }

        private readonly LightVisualElement companyName = new LightVisualElement();
        private readonly LightVisualElement cardStatus = new LightVisualElement();
        private readonly LightVisualElement parentName = new LightVisualElement();
        private readonly LightVisualElement endDate = new LightVisualElement(); 
        private readonly LightVisualElement PeriodDays = new LightVisualElement();
        private readonly LightVisualElement needsRepair = new LightVisualElement();
        private readonly StackLayoutElement verticalContainer = new StackLayoutElement();
        private readonly StackLayoutElement roomHeaderContainer = new StackLayoutElement(); 
        private readonly StackLayoutElement roomFooterContainer = new StackLayoutElement(); 

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            verticalContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            verticalContainer.NotifyParentOnMouseInput = true;
            verticalContainer.ShouldHandleMouseInput = false;
            verticalContainer.StretchHorizontally = true;
            verticalContainer.StretchVertically = true; 

            roomHeaderContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            roomHeaderContainer.NotifyParentOnMouseInput = true;
            roomHeaderContainer.ShouldHandleMouseInput = false;
            roomHeaderContainer.Children.Add(companyName);
            roomHeaderContainer.Children.Add(cardStatus);
            roomHeaderContainer.StretchHorizontally = true;

            companyName.NotifyParentOnMouseInput = true;
            companyName.ShouldHandleMouseInput = false;
            companyName.StretchHorizontally = true;
            //companyName.CustomFont = Utils.MainFont;
            companyName.CustomFontSize = 10;
            companyName.CustomFontStyle = FontStyle.Regular;
            //companyName.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            companyName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;

            cardStatus.NotifyParentOnMouseInput = true;
            cardStatus.ShouldHandleMouseInput = false;
            cardStatus.StretchHorizontally = false;
            //cardStatus.CustomFont = Utils.MainFont;
            cardStatus.CustomFontSize = 10;
            cardStatus.CustomFontStyle = FontStyle.Italic;
            //cardStatus.Margin = new System.Windows.Forms.Padding(0,5,0-5,0);

            roomFooterContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            roomFooterContainer.NotifyParentOnMouseInput = true;
            roomFooterContainer.ShouldHandleMouseInput = false;
            roomFooterContainer.StretchHorizontally = true;
            roomFooterContainer.DrawFill = true;
            roomFooterContainer.BackColor = Color.White;
            roomFooterContainer.GradientStyle = GradientStyles.Solid;
            roomFooterContainer.MinSize = new System.Drawing.Size(130, 20);
            roomFooterContainer.RightToLeftMode = StackLayoutElement.RightToLeftModes.ReverseOffset;
            roomFooterContainer.RightToLeft = true;
            roomFooterContainer.Margin = new System.Windows.Forms.Padding(0,0,-3,0);
            parentName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            parentName.StretchHorizontally = false;
            //parentName.Layout.LeftPart.Padding = new System.Windows.Forms.Padding(0, 0, 0 ,0);

            parentName.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            parentName.NotifyParentOnMouseInput = true;
            parentName.ShouldHandleMouseInput = false;
            //parentName.CustomFont = Utils.MainFont;
            parentName.CustomFontSize = 11;
            parentName.CustomFontStyle = FontStyle.Bold;

            endDate.NotifyParentOnMouseInput = true;
            endDate.ShouldHandleMouseInput = false;

            endDate.StretchVertically = true;
            PeriodDays.StretchVertically = true;
            roomFooterContainer.Children.Add(endDate);
            roomFooterContainer.Children.Add(PeriodDays);

            PeriodDays.NotifyParentOnMouseInput = true;
            PeriodDays.ShouldHandleMouseInput = false;
            PeriodDays.StretchHorizontally = false;
            PeriodDays.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            //PeriodDays.CustomFont = Utils.MainFont;
            PeriodDays.CustomFontSize = 9;
            PeriodDays.CustomFontStyle = FontStyle.Regular;

            endDate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            //endDate.CustomFont = Utils.MainFont;
            endDate.CustomFontSize = 9;
            endDate.CustomFontStyle = FontStyle.Regular;
            ////endDate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);    
            endDate.StretchHorizontally = false;
            verticalContainer.Children.Add(roomHeaderContainer);
            verticalContainer.Children.Add(parentName);
            verticalContainer.Children.Add(roomFooterContainer);
            //roomFooterContainer.StretchHorizontally = true;

            this.Children.Add(this.verticalContainer);
        }
        

        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();
            this.DrawText = false;
            this.BackColor = Color.White;
            this.DrawFill = true;
            this.DrawBorder = false;
            companyName.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            parentName.ImageLayout = System.Windows.Forms.ImageLayout.None;
            //parentName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0); 

            parentName.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            parentName.StretchHorizontally = true;
            parentName.ImageAlignment = ContentAlignment.MiddleLeft;
            parentName.TextAlignment = ContentAlignment.MiddleLeft;

            //endDate.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, -3, 0, 0);
            endDate.ForeColor = Color.FromArgb(200, 0, 0, 0);
            PeriodDays.ForeColor = Color.FromArgb(200, 0, 0, 0);
            //PeriodDays.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, -3, 0, 0);

            DataRowView datarow = this.Data.DataBoundItem as DataRowView;
            if (datarow.Row is ByanRow byan)
            {
                companyName.Text = byan.CompanyName;
                parentName.Text = byan.ParentName;

                Bitmap icon = null;
                Bitmap ScreenTipIcon = null;


                int Period = (byan.EndDate - DateTime.Now).Days;
                endDate.Text = byan.EndDate.ToString("yyyy/MM/dd");
                PeriodDays.Text = Period + " يوم";
                endDate.Image = Contract_Management.Properties.Resources.GlyphCalendar_small;


                if (Period <= 0)
                {
                    cardStatus.Text = "منتهي";

                    this.BackColor = Color.FromArgb(224, 79, 95);
                    PeriodDays.Image = Contract_Management.Properties.Resources.GlyphClose;
                    companyName.ForeColor = Color.White;
                    cardStatus.ForeColor = Color.White;
                    parentName.ForeColor = Color.White;

                    if (byan.ParentType == "سائق")
                    {
                        icon = Contract_Management.Properties.Resources.DriverRed_32;
                        ScreenTipIcon = Contract_Management.Properties.Resources.DriverRed_30;

                    }
                    else
                    {
                        icon = Contract_Management.Properties.Resources.CarRed_32;
                        ScreenTipIcon = Contract_Management.Properties.Resources.CarRed_30;

                    }

                }
                else
                {
if (Period <= 15)
                    {
                        cardStatus.Text = "أوشك";

                        this.BackColor = Color.DarkOrange;

                        PeriodDays.Image = Contract_Management.Properties.Resources.GlyphWrench;
                        companyName.ForeColor = Color.Black;
                        cardStatus.ForeColor = Color.Black;
                        parentName.ForeColor = Color.Black;

                        if (byan.ParentType == "سائق")
                        {
                            icon = Contract_Management.Properties.Resources.DriverOrange_32;
                            ScreenTipIcon = Contract_Management.Properties.Resources.DriverOrange_30;

                        }
                        else
                        {
                            icon = Contract_Management.Properties.Resources.CarOrange_32;
                            ScreenTipIcon = Contract_Management.Properties.Resources.CarOrange_30;

                        }

                    }
else
                    {


                    cardStatus.Text = "ساري";

                    this.BackColor = Color.SeaGreen;
                    PeriodDays.Image = Contract_Management.Properties.Resources.GlyphCheck_small;
                    companyName.ForeColor = Color.White;
                    cardStatus.ForeColor = Color.White;
                    parentName.ForeColor = Color.White;

                    if (byan.ParentType == "سائق")
                    {
                        icon = Contract_Management.Properties.Resources.DriverGreen_50;
                        ScreenTipIcon = Contract_Management.Properties.Resources.DriverGreen_30;

                    }
                    else
                    {
                        icon = Contract_Management.Properties.Resources.CarGreen_50;
                        ScreenTipIcon = Contract_Management.Properties.Resources.CarGreen_30;

                    }
                    }


                }
                parentName.Image = icon;

                RadOffice2007ScreenTipElement screenTip = new RadOffice2007ScreenTipElement();

                screenTip.RightToLeft = true;
                screenTip.FooterVisible = true;

                screenTip.CaptionLabel.Font = new Font("Traditional Arabic", 15, FontStyle.Bold);
                screenTip.CaptionLabel.TextAlignment = ContentAlignment.MiddleCenter;
                screenTip.CaptionLabel.Padding = new System.Windows.Forms.Padding(8);

                screenTip.CaptionLabel.Image = ScreenTipIcon;
                screenTip.CaptionLabel.Text = "المتبقي : " + Period + " يوم";

                string Header = " الأسم : " + byan.ParentName;
                string Content = " تاريخ البدء : " + byan.StartDate.ToString("yyyy/MM/dd");
                string Footer = " تاريخ الإنتهاء : " + byan.EndDate.ToString("yyyy/MM/dd");
                screenTip.MainTextLabel.Text = Header + "\n" +
                Content + "\n" +
                Footer;

                screenTip.MainTextLabel.Font = new Font("Traditional Arabic", 16, FontStyle.Bold);
                screenTip.MainTextLabel.TextAlignment = ContentAlignment.MiddleCenter;


                screenTip.FooterTextLabel.Text = " النوع : " + byan.ParentType + "\n" +
                    " الشركة : " + byan.CompanyName;

                screenTip.FooterTextLabel.Font = new Font("Traditional Arabic", 15, FontStyle.Bold);

                this.ScreenTip = screenTip;
                this.ScreenTip.ShouldApplyTheme = true;


               
            }

        }



        protected override void OnSelect()
        {
            base.OnSelect();
        }

        protected override void DoClick(EventArgs e)
        {
            base.DoClick(e);
            //this.BackColor = Color.CornflowerBlue;

            DataRowView datarow = this.Data.DataBoundItem as DataRowView;
            if (datarow.Row is ByanRow byan)
            {

                int Period = (byan.EndDate - DateTime.Now).Days;

                if (Period <= 0)
                {

                    if (byan.ParentType == "سائق")
                    {
                        //icon = DoctorERP_v2_00.Properties.Resources.DriverRed_32;
                        //ScreenTipIcon = DoctorERP_v2_00.Properties.Resources.DriverRed_30;

                    }
                    else
                    {
                        //icon = DoctorERP_v2_00.Properties.Resources.CarRed_32;
                        //ScreenTipIcon = DoctorERP_v2_00.Properties.Resources.CarRed_30;

                    }

                }
                else if (Period <= 15)
                {

                    if (byan.ParentType == "سائق")
                    {
                        //icon = DoctorERP_v2_00.Properties.Resources.DriverOrange_32;
                        //ScreenTipIcon = DoctorERP_v2_00.Properties.Resources.DriverOrange_30;

                    }
                    else
                    {
                        ////icon = DoctorERP_v2_00.Properties.Resources.CarOrange_32;
                        ////ScreenTipIcon = DoctorERP_v2_00.Properties.Resources.CarOrange_30;

                    }

                }
                else
                {

                    if (byan.ParentType == "سائق")
                    {
                        //icon = DoctorERP_v2_00.Properties.Resources.DriverGreen_50;
                        //ScreenTipIcon = DoctorERP_v2_00.Properties.Resources.DriverGreen_30;

                    }
                    else
                    {
                        //icon = DoctorERP_v2_00.Properties.Resources.CarGreen_50;
                        //ScreenTipIcon = DoctorERP_v2_00.Properties.Resources.CarGreen_30;

                    }

                }


            }

            //tbLand Land = this.Data.DataBoundItem as tbLand;

            //if (Land.status.ToString().Contains("مباع"))
            //{
            //    LandID.ForeColor = Color.White;

            //}
            //else if (Land.status.ToString().Contains("متاح"))
            //{
            //    this.BackColor = Color.Green;
            //    LandID.ForeColor = Color.White;

            //}
            //else if (Land.status.ToString().Contains("محجوز"))
            //{
            //    this.BackColor = Color.Gold;
            //    LandID.ForeColor = Color.Black;

            //}

        }



    }
}