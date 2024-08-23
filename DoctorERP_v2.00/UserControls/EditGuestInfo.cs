using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using HotelApp;
using Telerik.WinControls.UI;
using HotelApp.Data;

namespace CustomControls
{
    public partial class EditGuestInfo : UserControl
    {

        public RadPanel HeaderPanel
        {
            get
            {
                return this.headerPanel;
            }
        }

        public RadButton SaveButton
        {
            get
            {
                return this.saveButton;
            }
        }

        public EditGuestInfo()
        {
            InitializeComponent();

            this.headerPanel.RootElement.EnableElementShadow = false;

            this.guestInfoLabel.RootElement.EnableElementShadow = false;
            this.guestInfoLabel.LabelElement.CustomFont = Utils.MainFontMedium;
            this.guestInfoLabel.LabelElement.CustomFontSize = 12.5f;
            this.guestInfoLabel.LabelElement.CustomFontStyle = FontStyle.Bold;
            this.guestInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            this.nameLabel.LabelElement.CustomFont = Utils.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.nameTextBox.TextBoxElement.CustomFont = Utils.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.idLabel.LabelElement.CustomFont = Utils.MainFont;
            this.idLabel.LabelElement.CustomFontSize = 10.5f;
            this.idLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.idLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.idTextBox.TextBoxElement.CustomFont = Utils.MainFont;
            this.idTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.idTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.noteLabel.LabelElement.CustomFont = Utils.MainFont;
            this.noteLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.noteLabel.TextAlignment = ContentAlignment.BottomLeft;

            this.noteTextBox.TextBoxElement.CustomFont = Utils.MainFont;
            this.noteTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.noteTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            this.editPanel.RootElement.EnableElementShadow = false;
            foreach (RadControl c in this.editPanel.Controls)
            {
                c.RootElement.EnableElementShadow = false;
            }

            this.closeButton.RootElement.EnableElementShadow = false;
            this.closeButton.ButtonElement.Padding = new Padding(0);
            this.closeButton.ImageAlignment = ContentAlignment.TopRight;
            this.closeButton.DisplayStyle = Telerik.WinControls.DisplayStyle.Image;
            this.closeButton.Image = DoctorERP_v2_00.Properties.Resources.not_clean;

            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.idLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.noteLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.noteTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.idTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.idSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            //this.addressSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            this.saveButton.ButtonElement.CustomFont = Utils.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);

        }

        //public Guest CurrentGuest
        //{
        //    get
        //    {
        //        return this.currentGuest;
        //    }
        //}

        private void closeButton_Click(object sender, EventArgs e)
        {
            HotelAppForm form = this.FindForm() as HotelAppForm;
            if (form != null)
            {
                //if (form.PageView.SelectedPage == form.PageView.Pages[1])
                //{
                //    this.Parent.Visible = false;
                //}
                //else
                //{
                //    this.Visible = false;
                //    this.Parent.Controls[0].Visible = true;
                //}
            }
        }

        //internal void Initialize(HotelApp.Guest guest, Booking booking)
        //{
        //    currentGuest = guest;
        //    this.booking = booking;
        //    if (currentGuest == null)
        //    {
        //        return;
        //    }
        //    this.guestInfoLabel.Text = "EDIT GUEST INFORMATION";
        //    this.idTextBox.Text = guest.Id;
        //    this.nameTextBox.Text = guest.Name;
        //    this.addressTextBox.Text = guest.Address;
        //    this.cityTextBox.Text = guest.City;
        //    this.phoneTextBox.Text = guest.Phone;
        //    if (guest.CardDetails != null)
        //    {
        //        this.creditCardNumberTexBox.Text = guest.CardDetails.CreditCardId;
        //        this.validDateTimePicker.Value = guest.CardDetails.ExpiresOn;
        //        this.ccvTextBox.Text = guest.CardDetails.CCV.ToString();
        //    }
            
        //    if (booking != null && !booking.Guests.Contains(guest))
        //    {
        //        booking.Guests.Add(guest);
        //        booking.Name = booking.Guests.First().Name;
        //    }
        //}

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                //if (currentGuest == null)
                //{
                //    currentGuest = new Guest();
                //    currentGuest.CardDetails = new CreditCard();
                //}
                //this.currentGuest.Name = this.nameTextBox.Text;
                //this.currentGuest.Id = this.idTextBox.Text;
                //this.currentGuest.Address = this.addressTextBox.Text;
                //this.currentGuest.City = this.cityTextBox.Text;
                //this.currentGuest.Phone = this.phoneTextBox.Text;
                //this.currentGuest.CardDetails.CreditCardId = this.creditCardNumberTexBox.Text;
                //this.currentGuest.CardDetails.ExpiresOn = this.validDateTimePicker.Value;
                //this.currentGuest.CardDetails.CCV = uint.Parse(this.ccvTextBox.Text);
                //if (!this.booking.Guests.Contains(this.currentGuest))
                //{
                //    this.booking.Guests.Add(this.currentGuest);
                //}
                //booking.Name = booking.Guests.First().Name;
                //HotelAppForm form = this.FindForm() as HotelAppForm;
                //if (form != null && !form.Bookings.Contains(this.booking))
                //{
                //    form.Bookings.Add(this.booking);
                //}
                //this.saveButton.DialogResult = DialogResult.OK;
                //this.closeButton.PerformClick();
            }
            else
            {
                this.saveButton.DialogResult = DialogResult.Cancel;
            }
        }

        private bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorLabel.ForeColor = Color.Red;
            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = "Name is not allowed to be empty!";
                return false;
            }
            if (this.idTextBox.Text == "")
            {
                this.errorLabel.Text = "Id is not allowed to be empty!";
                return false;
            }
            if (this.noteTextBox.Text == "")
            {
                this.errorLabel.Text = "Address is not allowed to be empty!";
                return false;
            }
            return true;
        }

        private void EditGuestInfo_Load(object sender, EventArgs e)
        {

        }

        private void editPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addressLabel_Click(object sender, EventArgs e)
        {

        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void idSeparator_Click(object sender, EventArgs e)
        {

        }

        private void radSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void noteTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}