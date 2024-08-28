using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace Contract_Management.FlyoutDialogs
{
    public partial class FlyoutAddCar : UserControl
    {
        public FlyoutAddCar()
        {
            InitializeComponent();
            this.Result = DialogResult.Cancel;

            idLabel.TextAlignment = ContentAlignment.TopLeft;
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
                RadCallout.Show(callout, cn, "يجب إدخال رقم الصهريج أولاً", "إضافة البيانات", "ادخل رقم الصهريج ثم إضغط علي زر حفظ مرة آخرى");

                return false;
            }

            return true;
        }

        private void FlyoutAddCar_Load(object sender, EventArgs e)
        {
            radTextBox2.Select();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.No;
            this.Result = DialogResult.Abort;
            radTextBox2.Text = string.Empty;
            radTextBox1.Text = string.Empty;
            radTextBox2.Select();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.Cancel;
            RadFlyoutManager.Close();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!this.ValidateData())
            {
                return;
            }

            this.Result = DialogResult.OK;
            RadFlyoutManager.Close();

        }

        private void radTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void radLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
