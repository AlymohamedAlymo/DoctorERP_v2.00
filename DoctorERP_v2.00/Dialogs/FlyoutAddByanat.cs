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

            idLabel.TextAlignment = ContentAlignment.TopLeft;
            radLabel1.TextAlignment = ContentAlignment.TopLeft;
            radLabel5.TextAlignment = ContentAlignment.TopLeft;
            radLabel4.TextAlignment = ContentAlignment.TopLeft;
            radLabel2.TextAlignment = ContentAlignment.TopLeft;

            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ar-EG");
            radDateTimePicker1.Culture = cultureInfo;
            radDateTimePicker2.Culture = cultureInfo;

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

        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (radDropDownList1.SelectedIndex == 0)
            {
                DriverMultiColumnComboBox.Visible = true;
                CarsMultiColumnComboBox.Visible = false;

            }
            if (radDropDownList1.SelectedIndex == 1)
            {
                DriverMultiColumnComboBox.Visible = false;
                CarsMultiColumnComboBox.Visible = true;

            }

        }

        private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {

        }

        private void radMultiColumnComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void editPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void FlyoutAddByanat_Load(object sender, EventArgs e)
        {
            this.driverTableAdapter.Fill(this.contract_ManagementDataSet.Driver);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Companies' table. You can move, or remove it, as needed.
            this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.contract_ManagementDataSet.Cars);
            // TODO: This line of code loads data into the 'contract_ManagementDataSet.Companies' table. You can move, or remove it, as needed.
            this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);

            radDropDownList1.SelectedIndex = 0;
        }

        private void radMultiColumnComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radLabel3_Click(object sender, EventArgs e)
        {

        }

        private void radLabel4_Click(object sender, EventArgs e)
        {

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void radLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
