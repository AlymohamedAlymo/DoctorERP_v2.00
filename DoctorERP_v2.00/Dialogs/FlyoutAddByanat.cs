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
    public partial class FlyoutAddByanat : UserControl
    {
        public FlyoutAddByanat()
        {
            InitializeComponent();
            this.Result = DialogResult.Cancel;

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

        private void radButton3_Click(object sender, EventArgs e)
        {
            this.Result = DialogResult.Abort;
            RadFlyoutManager.Close();

        }
    }
}
