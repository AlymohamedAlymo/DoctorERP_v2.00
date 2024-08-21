using DoctorERP_v2_00.Contract_ManagementDataSetTableAdapters;
using HotelApp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static DoctorERP_v2_00.Contract_ManagementDataSet;

namespace HotelApp
{
    public class RoomIconListViewVisualItem : IconListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(IconListViewVisualItem);
            }
        }

        private LightVisualElement companyName = new LightVisualElement();
        private LightVisualElement cardStatus = new LightVisualElement();
        private LightVisualElement parentName = new LightVisualElement();
        private LightVisualElement endDate = new LightVisualElement(); 
        private LightVisualElement PeriodDays = new LightVisualElement();
        private LightVisualElement needsRepair = new LightVisualElement();
        private StackLayoutElement verticalContainer = new StackLayoutElement();
        private StackLayoutElement roomHeaderContainer = new StackLayoutElement(); 
        private StackLayoutElement roomFooterContainer = new StackLayoutElement(); 

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
            companyName.CustomFont = Utils.MainFont;
            companyName.CustomFontSize = 10;
            companyName.CustomFontStyle = FontStyle.Bold;
            companyName.Margin = new System.Windows.Forms.Padding(5, 10, 0, 0);
            companyName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;

            cardStatus.NotifyParentOnMouseInput = true;
            cardStatus.ShouldHandleMouseInput = false;
            cardStatus.StretchHorizontally = false;
            cardStatus.CustomFont = Utils.MainFont;
            cardStatus.CustomFontSize = 10;
            cardStatus.CustomFontStyle = FontStyle.Italic;
            cardStatus.Margin = new System.Windows.Forms.Padding(0,5,5,0);

            roomFooterContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            roomFooterContainer.NotifyParentOnMouseInput = true;
            roomFooterContainer.ShouldHandleMouseInput = false;
            roomFooterContainer.StretchHorizontally = true;
            roomFooterContainer.DrawFill = true;
            roomFooterContainer.BackColor = Color.White;
            roomFooterContainer.GradientStyle = GradientStyles.Solid;
            roomFooterContainer.MinSize = new System.Drawing.Size(0, 30);

            parentName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            parentName.StretchHorizontally = false;
            parentName.Layout.LeftPart.Padding = new System.Windows.Forms.Padding(24, 0, 8, 0);

            parentName.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            parentName.NotifyParentOnMouseInput = true;
            parentName.ShouldHandleMouseInput = false;
            parentName.CustomFont = Utils.MainFont;
            parentName.CustomFontSize = 12;
            parentName.CustomFontStyle = FontStyle.Regular;

            //needsRepair.Text = "أوشك علي الإنتهاء";
            endDate.NotifyParentOnMouseInput = true;
            endDate.ShouldHandleMouseInput = false;

            endDate.StretchVertically = true;
            PeriodDays.StretchVertically = true;
            //needsRepair.StretchVertically = true;
            roomFooterContainer.Children.Add(endDate);
            roomFooterContainer.Children.Add(PeriodDays);
            //roomFooterContainer.Children.Add(needsRepair); 

            //needsRepair.NotifyParentOnMouseInput = true;
            //needsRepair.ShouldHandleMouseInput = false;
            //needsRepair.StretchHorizontally = false;
            //needsRepair.Alignment = ContentAlignment.MiddleRight;
            //needsRepair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;           
            //needsRepair.CustomFont = Utils.MainFont;
            //needsRepair.CustomFontSize = 9;
            //needsRepair.CustomFontStyle = FontStyle.Regular;

            PeriodDays.NotifyParentOnMouseInput = true;
            PeriodDays.ShouldHandleMouseInput = false;
            PeriodDays.StretchHorizontally = false;
            PeriodDays.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            PeriodDays.CustomFont = Utils.MainFont;
            PeriodDays.CustomFontSize = 12;
            PeriodDays.CustomFontStyle = FontStyle.Regular;

            endDate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            endDate.CustomFont = Utils.MainFont;
            endDate.CustomFontSize = 12;
            endDate.CustomFontStyle = FontStyle.Regular;
            endDate.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);    
            endDate.StretchHorizontally = false; 
             
            verticalContainer.Children.Add(roomHeaderContainer);
            verticalContainer.Children.Add(parentName);
            verticalContainer.Children.Add(roomFooterContainer);

            this.Children.Add(this.verticalContainer);
        }
        
        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();
            this.DrawText = false;
            this.BackColor = Color.White;
            this.DrawFill = true;
            this.DrawBorder = false;
            companyName.Margin = new System.Windows.Forms.Padding(8,8,0,0);
            parentName.ImageLayout = System.Windows.Forms.ImageLayout.None;
            parentName.Margin = new System.Windows.Forms.Padding(24, 0, 0, 0); 
            
            parentName.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            parentName.StretchHorizontally = true;
            parentName.ImageAlignment = ContentAlignment.MiddleLeft;
            parentName.TextAlignment = ContentAlignment.MiddleLeft;
             
            endDate.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, -3, 0, 0);
            endDate.ForeColor = Color.FromArgb(200, 0, 0, 0);
            PeriodDays.ForeColor = Color.FromArgb(200, 0, 0, 0);
            PeriodDays.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, -3, 0, 0);
            //needsRepair.ForeColor = Color.FromArgb(200, 0, 0, 0);
            //needsRepair.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, -3, 0, 0);



            DataRowView datarow = this.Data.DataBoundItem as DataRowView;
            ByanRow byan = datarow.Row as ByanRow;
            if (byan != null)
            {
                companyName.Text = "الشركة : " + byan.CompanyName;
                parentName.Text = byan.ParentName;
                if (byan.ParentType == "سائق")
                {
                    parentName.Image = DoctorERP_v2_00.Properties.Resources.DriverIcon_32;
                }
                else
                {
                    parentName.Image = DoctorERP_v2_00.Properties.Resources.CarsIcon_32;

                }

                //parentName.Image = Utils.GetImageByRoomType(ByanType.Cars);
                int Period = (byan.EndDate - DateTime.Now).Days;
                endDate.Text = byan.EndDate.ToString("yyyy/MM/dd") ;
                PeriodDays.Text = Period + " يوم";
                //needsRepair.Image = DoctorERP_v2_00.Properties.Resources.GlyphWrench;
                endDate.Image = DoctorERP_v2_00.Properties.Resources.GlyphCalendar_small;

                if (Period <= 0)
                {
                    cardStatus.Text = "منتهي";

                    //this.BackColor = Color.FromArgb(247, 247, 247);
                    this.BackColor = Color.DarkRed;

                    PeriodDays.Image = DoctorERP_v2_00.Properties.Resources.GlyphClose;
                    //needsRepair.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                    companyName.ForeColor = Color.White;
                    cardStatus.ForeColor = Color.White;
                    parentName.ForeColor = Color.White;

                }
                else if (Period <= 15)
                {
                    cardStatus.Text = "أوشك";

                    //this.BackColor = Color.FromArgb(247, 247, 247);
                    this.BackColor = Color.Gold;

                    PeriodDays.Image = DoctorERP_v2_00.Properties.Resources.GlyphWrench;
                    //needsRepair.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                    companyName.ForeColor = Color.Black;
                    cardStatus.ForeColor = Color.Black;
                    parentName.ForeColor = Color.Black;

                }

                else
                {
                    cardStatus.Text = "ساري";

                    //this.BackColor = Color.FromArgb(232, 232, 232);
                    this.BackColor = Color.DarkGreen;

                    PeriodDays.Image = DoctorERP_v2_00.Properties.Resources.GlyphCheck_small;
                    //needsRepair.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
                    companyName.ForeColor = Color.White;
                    cardStatus.ForeColor = Color.White;
                    parentName.ForeColor = Color.White;


                }
            }
        }
    }
}