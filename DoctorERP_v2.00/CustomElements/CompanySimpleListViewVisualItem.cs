using System;
using System.Drawing;
using Telerik.WinControls.UI;

namespace Contract_Management
{
    public class CompanySimpleListViewVisualItem : SimpleListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(SimpleListViewVisualItem);
            }
        }

        private StackLayoutElement layout = new StackLayoutElement();
        private LightVisualElement CarscountElement = new LightVisualElement();
        private LightVisualElement CarscountImage = new LightVisualElement();

        private LightVisualElement DrivercountElement = new LightVisualElement();
        private LightVisualElement DrivercountImage = new LightVisualElement();

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            this.layout.ShouldHandleMouseInput = false;
            this.CarscountImage.ShouldHandleMouseInput = false;
            this.CarscountElement.NotifyParentOnMouseInput = true;
            this.CarscountElement.ShouldHandleMouseInput = false;
            this.CarscountElement.StretchHorizontally = false;
            this.CarscountElement.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CarscountElement.MinSize = CarscountElement.MaxSize = new System.Drawing.Size(15, 0);

            this.CarscountImage.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CarscountImage.ImageAlignment = ContentAlignment.MiddleRight;
            this.CarscountImage.StretchHorizontally = false;

            this.DrivercountImage.ShouldHandleMouseInput = false;
            this.DrivercountElement.NotifyParentOnMouseInput = true;
            this.DrivercountElement.ShouldHandleMouseInput = false;
            this.DrivercountElement.StretchHorizontally = false;
            this.DrivercountElement.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.DrivercountElement.MinSize = DrivercountElement.MaxSize = new System.Drawing.Size(15, 0);

            this.DrivercountImage.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DrivercountImage.ImageAlignment = ContentAlignment.MiddleRight;
            this.DrivercountImage.StretchHorizontally = false;

            this.layout.Children.Add(CarscountImage);
            this.layout.Children.Add(CarscountElement);


            this.layout.Children.Add(DrivercountImage);
            this.layout.Children.Add(DrivercountElement);

            this.layout.StretchHorizontally = true;
            this.Children.Add(layout);
        }

        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();


            this.DrawText = false;
            this.ToggleElement.Text = this.Text;

            //this.ToggleElement.CustomFont = Utils.MainFont;
            this.ToggleElement.CustomFontSize = 11.5f;

            int[] ints = this.dataItem.Tag as int[];

            if (ints == null)
            {
                return;
            }

            //this.DrivercountElement.CustomFont = Utils.MainFont;
            this.DrivercountElement.CustomFontSize = 11.5f;
            this.DrivercountElement.CustomFontStyle = FontStyle.Bold;

            this.DrivercountElement.Text = ints[0].ToString();

            this.DrivercountImage.Image = Contract_Management.Properties.Resources.Car_40;
            this.DrivercountImage.ImageAlignment = ContentAlignment.MiddleCenter;
            this.DrivercountElement.ForeColor = Color.DimGray;
            this.DrivercountElement.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.DrivercountImage.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);



            //this.CarscountElement.CustomFont = Utils.MainFont;
            this.CarscountElement.CustomFontSize = 11.5f;
            this.CarscountElement.CustomFontStyle = FontStyle.Bold;
            this.CarscountElement.Text = ints[1].ToString();
            this.CarscountElement.ForeColor = Color.DimGray;
            this.CarscountElement.ImageAlignment = ContentAlignment.MiddleCenter;

            this.CarscountImage.Image = Contract_Management.Properties.Resources.Driver_40;
            this.CarscountElement.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.CarscountImage.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);


            RadOffice2007ScreenTipElement screenTip = new RadOffice2007ScreenTipElement();

            screenTip.RightToLeft = true;
            screenTip.FooterVisible = false;

            screenTip.CaptionLabel.Font = new Font("Traditional Arabic", 15, FontStyle.Bold);
            screenTip.CaptionLabel.TextAlignment = ContentAlignment.MiddleCenter;
            screenTip.CaptionLabel.Padding = new System.Windows.Forms.Padding(8);

            screenTip.CaptionLabel.Text = this.Text;
            screenTip.MainTextLabel.Children.Clear();

            StackLayoutElement verticalContainer = new StackLayoutElement();
            verticalContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            verticalContainer.NotifyParentOnMouseInput = true;
            verticalContainer.ShouldHandleMouseInput = false;
            verticalContainer.StretchHorizontally = true;
            verticalContainer.StretchVertically = true;

            RadLabelElement element = new RadLabelElement();
            element.Text = " عدد السيارات : " + ints[0].ToString();
            element.Image = Contract_Management.Properties.Resources.Car_40;
            element.ImageAlignment = ContentAlignment.MiddleRight;
            element.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            verticalContainer.Children.Add(element);

            RadLabelElement element2 = new RadLabelElement();
            element2.Text = " عدد السائقين : " + ints[1].ToString();
            element2.Image = Contract_Management.Properties.Resources.Driver_40;
            element2.ImageAlignment = ContentAlignment.MiddleRight;

            element2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            verticalContainer.Children.Add(element2);

            screenTip.MainTextLabel.Children.Add(verticalContainer);

            screenTip.MainTextLabel.Font = new Font("Traditional Arabic", 16, FontStyle.Bold);
            screenTip.MainTextLabel.TextAlignment = ContentAlignment.MiddleCenter;

            this.ScreenTip = screenTip;
            this.ScreenTip.ShouldApplyTheme = true;



        }

    }
}