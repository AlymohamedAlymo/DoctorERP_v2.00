using HotelApp.Data;
using System;
using System.Drawing;
using Telerik.WinControls.UI;

namespace HotelApp
{
    public class OptionsSimpleListViewVisualItem : SimpleListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(SimpleListViewVisualItem);
            }
        }

        private StackLayoutElement layout = new StackLayoutElement();
        private LightVisualElement countElement = new LightVisualElement();
        private LightVisualElement countImage = new LightVisualElement();

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            this.layout.ShouldHandleMouseInput = false;
            this.countImage.ShouldHandleMouseInput = false;
            this.countElement.NotifyParentOnMouseInput = true;
            this.countElement.ShouldHandleMouseInput = false;
            this.countElement.StretchHorizontally = false;
            this.countElement.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.countElement.MinSize = countElement.MaxSize = new System.Drawing.Size(30, 0);

            this.countImage.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.countImage.ImageAlignment = ContentAlignment.MiddleRight;
            this.countImage.StretchHorizontally = true;

            this.layout.Children.Add(countImage);
            this.layout.Children.Add(countElement);

            this.layout.StretchHorizontally = true;
            this.Children.Add(layout);
        }

        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();

            this.DrawText = false;
            this.ToggleElement.Text = this.Text;

            this.ToggleElement.CustomFont = Utils.MainFont;
            this.ToggleElement.CustomFontSize = 11.5f;
            ////this.ToggleElement.TextElement.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);

            this.countElement.CustomFont = Utils.MainFont;
            this.countElement.CustomFontSize = 11.5f;
            this.countElement.CustomFontStyle = FontStyle.Bold;
            this.countElement.Text = this.dataItem.Tag.ToString();
            this.countImage.Image = DoctorERP_v2_00.Properties.Resources.Count_32;

        }

    }
}