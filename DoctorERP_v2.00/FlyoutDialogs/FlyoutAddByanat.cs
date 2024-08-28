using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Contract_Management.Dialogs
{
    public partial class FlyoutAddByanat : UserControl
    {
        public FlyoutAddByanat()
        {
            InitializeComponent();
            this.Result = DialogResult.Cancel;

            RadIdLabel.TextAlignment = ContentAlignment.TopLeft;
            radLabel1.TextAlignment = ContentAlignment.TopLeft;
            radLabel5.TextAlignment = ContentAlignment.TopLeft;
            radLabel2.TextAlignment = ContentAlignment.TopLeft;

            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ar-EG");
            DTPEndDate.Culture = cultureInfo;


        }

        public DialogResult Result
        {
            get; set;
        }

        public string Type
        {
            get { return this.CMBParentType.Text; }
        }

        public string ParentName
        {
            get { return CMBParentType.SelectedIndex == 0? this.MCCDriverName.Text : this.MCCCarName.Text; }
        }
        public string Company
        {
            get { return this.MCCCompanyName.Text; }
        }
        public DateTime EndDate
        {
            get { return this.DTPEndDate.Value; }
        }
        public string Note
        {
            get { return this.TXBNote.Text; }
        }

        private bool ValidateData()
        {
            if (CMBParentType.SelectedIndex == 0)
            {
                if (string.IsNullOrWhiteSpace(this.MCCDriverName.Text))
                {
                    RadCallout callout = new RadCallout
                    {
                        ArrowType = Telerik.WinControls.UI.Callout.CalloutArrowType.Triangle,
                        ArrowDirection = Telerik.WinControls.ArrowDirection.Right,
                        AutoClose = true,
                        CalloutType = Telerik.WinControls.UI.Callout.CalloutType.RoundedRectangle,
                        DropShadow = true
                    };
                    RadControl cn = MCCDriverName as RadControl;
                    RadCallout.Show(callout, cn, "يجب إختيار السائق أولاً", "إضافة البيانات", "إختر السائق ثم إضغط علي زر حفظ مرة آخرى");

                    return false;
                }

            }
            else if (CMBParentType.SelectedIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(this.MCCCarName.Text))
                {
                    RadCallout callout = new RadCallout
                    {
                        ArrowType = Telerik.WinControls.UI.Callout.CalloutArrowType.Triangle,
                        ArrowDirection = Telerik.WinControls.ArrowDirection.Right,
                        AutoClose = true,
                        CalloutType = Telerik.WinControls.UI.Callout.CalloutType.RoundedRectangle,
                        DropShadow = true
                    };
                    RadControl cn = MCCCarName as RadControl;
                    RadCallout.Show(callout, cn, "يجب إختيار السيارة أولاً", "إضافة البيانات", "إختر السيارة ثم إضغط علي زر حفظ مرة آخرى");

                    return false;
                }

            }

            if (string.IsNullOrWhiteSpace(this.MCCCompanyName.Text))
            {
                RadCallout callout = new RadCallout
                {
                    ArrowType = Telerik.WinControls.UI.Callout.CalloutArrowType.Triangle,
                    ArrowDirection = Telerik.WinControls.ArrowDirection.Right,
                    AutoClose = true,
                    CalloutType = Telerik.WinControls.UI.Callout.CalloutType.RoundedRectangle,
                    DropShadow = true
                };
                RadControl cn = MCCCompanyName as RadControl;
                RadCallout.Show(callout, cn, "يجب إختيار الشركة أولاً", "إضافة البيانات", "إختر الشركة ثم إضغط علي زر حفظ مرة آخرى");

                return false;
            }

            return true;
        }
        private void RadButtonOK_Click(object sender, EventArgs e)
        {
            if (!this.ValidateData())
            {
                return;
            }

            this.Result = DialogResult.OK;
            RadFlyoutManager.Close();
        }

        private void RadButtonCancel_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.Cancel;
            RadFlyoutManager.Close();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.Yes;
            RadFlyoutManager.Close();

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.No;
            RadFlyoutManager.Close();

        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            if (radButton3.Text == "إلغاء")
            {
                this.Result = DialogResult.Abort;
                MCCDriverName.SelectedItem = null;
                MCCCarName.SelectedItem = null;
                MCCCompanyName.SelectedItem = null;
                DTPEndDate.Value = DateTime.Now;
                TXBNote.Text = "";
                MCCDriverName.Select();


            }
            else if (radButton3.Text == "حذف")
            {
                this.Result = DialogResult.Abort;
                RadFlyoutManager.Close();

            }

        }

        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (CMBParentType.SelectedIndex == 0)
            {
                RadIdLabel.Text = "السائق";
                MCCDriverName.Visible = true;
                MCCCarName.Visible = false;

            }
            if (CMBParentType.SelectedIndex == 1)
            {
                RadIdLabel.Text = "السيارة";

                MCCDriverName.Visible = false;
                MCCCarName.Visible = true;

            }

        }

        private void FlyoutAddByanat_Load(object sender, EventArgs e)
        {
            MCCCarName.Select();


        }

        private void editPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RadIdLabel_Click(object sender, EventArgs e)
        {

        }

        private void MCCCarName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        private void MCCCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DTPEndDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
