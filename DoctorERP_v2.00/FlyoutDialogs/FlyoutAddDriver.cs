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

namespace DoctorERP_v2_00.Dialogs
{
    public partial class FlyoutAddDriver : UserControl
    {
        public FlyoutAddDriver()
        {
            InitializeComponent();
            this.Result = DialogResult.Cancel;

            idLabel.TextAlignment = ContentAlignment.TopLeft;
            radLabel1.TextAlignment = ContentAlignment.TopLeft;
            radLabel2.TextAlignment = ContentAlignment.TopLeft;

        }

        public DialogResult Result
        {
            get; set;
        }

        public string ParentName
        {
            get { return this.radTextBox2.Text; }
        }
        public string ParentCardID
        {
            get { return this.idTextBox.Text; }
        }
        public string Note
        {
            get { return this.radTextBox1.Text; }
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(this.ParentName))
            {
                RadCallout callout = new RadCallout
                {
                    ArrowType = Telerik.WinControls.UI.Callout.CalloutArrowType.Triangle,
                    ArrowDirection = Telerik.WinControls.ArrowDirection.Right,
                    AutoClose = true,
                    CalloutType = Telerik.WinControls.UI.Callout.CalloutType.RoundedRectangle,
                    DropShadow = true
                };
                RadControl cn = radTextBox2;
                RadCallout.Show(callout, cn, "يجب إدخال اسم السائق أولاً", "إضافة البيانات", "ادخل اسم السائق ثم إضغط علي زر حفظ مرة آخرى");

                return false;
            }
            if (string.IsNullOrWhiteSpace(this.ParentCardID))
            {
                RadCallout callout = new RadCallout
                {
                    ArrowType = Telerik.WinControls.UI.Callout.CalloutArrowType.Triangle,
                    ArrowDirection = Telerik.WinControls.ArrowDirection.Right,
                    AutoClose = true,
                    CalloutType = Telerik.WinControls.UI.Callout.CalloutType.RoundedRectangle,
                    DropShadow = true
                };
                RadControl cn = idTextBox;
                RadCallout.Show(callout, cn, "يجب إختيار رقم البطاقة أولاً", "إضافة البيانات", "ادخل رقم البطاقة ثم إضغط علي زر حفظ مرة آخرى");

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

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.No;
            this.Result = DialogResult.Abort;
            radTextBox2.Text = string.Empty;
            idTextBox.Text = string.Empty;
            radTextBox1.Text = string.Empty;

        }

        private void FlyoutAddDriver_Load(object sender, EventArgs e)
        {
            radTextBox2.Select();
        }
    }
}
