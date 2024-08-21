using HotelApp.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace HotelApp
{
    public class CustomResourceHeaderCell : SchedulerResourceHeaderCellElement
    {
        public CustomResourceHeaderCell(RadScheduler scheduler, SchedulerView view) : base(scheduler, view)
        {
        }

        StackLayoutElement panel = new StackLayoutElement();
        LightVisualElement roomHeader = new LightVisualElement();
        LightVisualElement ByanType = new LightVisualElement();

        protected override void CreateChildElements()
        {
            base.CreateChildElements(); 
            this.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.BorderColor = Color.FromArgb(191, 198, 209);
            panel.Orientation = System.Windows.Forms.Orientation.Vertical;
            panel.StretchHorizontally = true;
            panel.StretchVertically = true;
            ByanType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            panel.Children.Add(roomHeader);
            roomHeader.StretchVertically = false;
            roomHeader.MinSize = new System.Drawing.Size(0, 40);
            ByanType.StretchHorizontally = true;
            ByanType.StretchVertically = true;
            panel.Children.Add(ByanType);
            this.Children.Add(panel);
            this.DrawText = false;

            ByanType.CustomFont = Utils.MainFont;
            ByanType.CustomFontSize = 9f ;
            ByanType.ForeColor = Color.FromArgb(102, 102, 102);
            ByanType.EnableElementShadow = false;
            roomHeader.EnableElementShadow=false;
            panel.EnableElementShadow = false;
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                roomHeader.Text = this.ResourceId + "";
                HotelAppForm form = this.Scheduler.FindForm() as HotelAppForm;
                if (form != null && this.ResourceId != null)
                {
                    //Room room = Utils.GetRoomById(int.Parse(this.ResourceId.ToString()), form.Rooms);
                    //ByanType.Text = Utils.GetRoomType(room.Type);
                    //ByanType.Image = Utils.GetImageByRoomType(room.Type);
                }
            }
        }

        protected override Type ThemeEffectiveType     
        { 
            get    
            { 
                return typeof(SchedulerResourceHeaderCellElement);     
            }
        }
    }

    public class MyElementProvider : SchedulerElementProvider
    {
        public MyElementProvider(RadScheduler scheduler) : base(scheduler)
        {
        }

        protected override T CreateElement<T>(SchedulerView view, object context)
        {
            if (typeof(T) == typeof(SchedulerResourceHeaderCellElement))
            {
                return new CustomResourceHeaderCell(this.Scheduler, view)as T;
            }

            return base.CreateElement<T>(view, context);
        }
    }
}