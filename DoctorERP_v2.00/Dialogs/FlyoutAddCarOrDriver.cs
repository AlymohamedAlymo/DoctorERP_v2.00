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

namespace DoctorERP_v2_00.Dialogs
{
    public partial class FlyoutAddCarOrDriver : UserControl
    {
        public FlyoutAddCarOrDriver()
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

        //public string ReserveReason
        //{
        //    get { return this.RadTextboxReserveReason.Text; }
        //}
        //private bool ValidateData()
        //{
        //    if (string.IsNullOrWhiteSpace(this.ReserveReason))
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        private void RadButtonOK_Click(object sender, EventArgs e)
        {
            //if (!this.ValidateData())
            //{
            //    return;
            //}

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

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        private void radLabel2_Click(object sender, EventArgs e)
        {

        }

        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (radDropDownList1.SelectedIndex == 0)
            {
                idLabel.Text = "اسم السائق";
                radTextBox2.NullText = "ادخل اسم السائق";

            }
            if (radDropDownList1.SelectedIndex == 1)
            {
                idLabel.Text = "رقم الصهريج";
                radTextBox2.NullText = "ادخل رقم الصهريج";

            }


        }

        private void FlyoutAddCarOrDriver_Load(object sender, EventArgs e)
        {

            radDropDownList1.SelectedIndex = 0;
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void radTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
