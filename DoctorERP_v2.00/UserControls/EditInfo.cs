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
using Telerik.WinControls.UI;

namespace Contract_Management.CustomControls
{
    public partial class EditInfo : UserControl
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

        public EditInfo()
        {
            InitializeComponent();

            this.headerPanel.RootElement.EnableElementShadow = false;

            this.guestInfoLabel.RootElement.EnableElementShadow = false;
            //this.guestInfoLabel.LabelElement.CustomFont = Utils.MainFontMedium;
            this.guestInfoLabel.LabelElement.CustomFontSize = 12.5f;
            this.guestInfoLabel.LabelElement.CustomFontStyle = FontStyle.Bold;
            this.guestInfoLabel.LabelElement.LabelText.Margin = new Padding(5, 15, 0, 0);

            //////this.nameLabel.LabelElement.CustomFont = Utils.MainFont;
            this.nameLabel.LabelElement.CustomFontSize = 10.5f;
            this.nameLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.nameLabel.TextAlignment = ContentAlignment.BottomLeft;

            //this.nameTextBox.TextBoxElement.CustomFont = Utils.MainFont;
            this.nameTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.nameTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            //this.idLabel.LabelElement.CustomFont = Utils.MainFont;
            this.idLabel.LabelElement.CustomFontSize = 10.5f;
            this.idLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.idLabel.TextAlignment = ContentAlignment.BottomLeft;

            ////this.idTextBox.TextBoxElement.CustomFont = Utils.MainFont;
            this.idTextBox.TextBoxElement.CustomFontSize = 10.5f;
            this.idTextBox.ForeColor = Color.FromArgb(33, 33, 33);

            //this.noteLabel.LabelElement.CustomFont = Utils.MainFont;
            this.noteLabel.LabelElement.CustomFontSize = 10.5f;
            this.noteLabel.ForeColor = Color.FromArgb(89, 89, 89);
            this.noteLabel.TextAlignment = ContentAlignment.BottomLeft;

            //this.noteTextBox.TextBoxElement.CustomFont = Utils.MainFont;
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
            this.closeButton.Image = Contract_Management.Properties.Resources.not_clean;

            this.nameLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.idLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);
            this.noteLabel.LabelElement.LabelText.Margin = new Padding(5, 0, 0, 0);

            this.nameTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.noteTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;
            this.idTextBox.TextBoxElement.Border.Visibility = ElementVisibility.Collapsed;

            this.nameSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);
            this.idSeparator.SeparatorElement.Line1.BackColor = Color.FromArgb(209, 209, 209);

            //this.saveButton.ButtonElement.CustomFont = Utils.MainFontMedium;
            this.saveButton.ButtonElement.CustomFontSize = 10.5f;
            this.saveButton.ButtonElement.ForeColor = Color.FromArgb(33, 33, 33);
            guestInfoLabel.TextAlignment = ContentAlignment.MiddleLeft;



        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            //HotelAppForm form = this.FindForm() as HotelAppForm;
            //if (form != null)
            //{
            //    form.com
            //    //if (form.PageView.SelectedPage == form.PageView.Pages[1])
            //    //{
            //    //    this.Parent.Visible = false;
            //    //}
            //    //else
            //    //{
            //    //    this.Visible = false;
            //    //    this.Parent.Controls[0].Visible = true;
            //    //}
            //}

            if (saveButton.Text == "حذف")
            {

            }
            else if (saveButton.Text == "إلغاء")
            {

            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            AppForm form = this.FindForm() as AppForm;
            if (form != null)
            {

                if (IsValidData())
                {
                    if (saveButton.Text == "حفظ")
                    {

                        ListChangedEventArgs ListChangedEvent = new ListChangedEventArgs(ListChangedType.ItemAdded, form.GridViewCompanies.CurrentRow.Index);

                        form.GridViewCompanies.MasterView.TableAddNewRow.Cells[1].Value = this.nameTextBox.Text;
                        form.GridViewCompanies.MasterView.TableAddNewRow.Cells[2].Value = this.idTextBox.Text;
                        form.GridViewCompanies.MasterView.TableAddNewRow.Cells[3].Value = this.noteTextBox.Text;


                        form.CompaniesBindingSource_ListChanged(new BindingSource(), ListChangedEvent);

                        saveButton.Text = "تعديل";
                        deleteButton.Text = "حذف";

                        //form.ISNew = true;

                        //if (!form.MessageWarning("هل أنت متأكد من الإضافة ؟", "إضافة شركة جديدة", "إذا ضغت علي زر نعم سوف يتم إضافة الشركة الجديد \r\n إذا ضغط علي زر لا سوف يتم تجاهل الإضافة"))
                        //{
                        //    form.companiesBindingSource.CancelEdit();
                        //    form.companiesTableAdapter.Fill(form.contract_ManagementDataSet.Companies);
                        //    form.companiesBindingSource.ResetBindings(form);
                        //    form.companiesBindingSource.DataSource = form.contract_ManagementDataSet.Companies;
                        //    return;

                        //}

                        //string CompanyName = form.GridViewCompanies.MasterView.TableAddNewRow.Cells[1].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[1].Value.ToString() : string.Empty;
                        //string ClintID = form.GridViewCompanies.MasterView.TableAddNewRow.Cells[2].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[2].Value.ToString() : string.Empty;
                        //string Note = form.GridViewCompanies.MasterView.TableAddNewRow.Cells[3].Value != null ? GridViewCompanies.MasterView.TableAddNewRow.Cells[3].Value.ToString() : string.Empty;
                        //int Result = form.companiesTableAdapter.Insert(CompanyName, ClintID, Note);


                        //if (Result > 0)
                        //{
                        //    ShowDesktopAlert("إضافة شركة", "تمت عملية إضافة الشركة بنجاح", $"عملية إضافة الشركة  {CompanyName}  تمت بنجاح ", "تمت عملية إضافة الشركة الجديد يمكن القيام بالعمليات عليه الأن.");
                        //    // RadCallout.Show(callout, GridViewCompanies, $"عملية إضافة الشركة  {CompanyName}  تمت بنجاح ", "تمت العملية بنجاح");

                        //    this.companiesBindingSource.CancelEdit();
                        //    this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
                        //    this.companiesBindingSource.ResetBindings(true);
                        //    this.companiesBindingSource.DataSource = this.contract_ManagementDataSet.Companies;

                        //}
                        //else
                        //{
                        //    // RadCallout.Show(callout, this.GridViewCompanies, "فشلت عملية إضافة الشركة !", "فشلت العملية");
                        //    this.companiesBindingSource.CancelEdit();
                        //    this.companiesTableAdapter.Fill(this.contract_ManagementDataSet.Companies);
                        //    this.companiesBindingSource.ResetBindings(true);
                        //    this.companiesBindingSource.DataSource = this.contract_ManagementDataSet.Companies;

                        //}

                    }
                    else if (saveButton.Text == "تعديل")
                    {
                        //form.GridViewCompanies.SelectAll();
                        ListChangedEventArgs ListChangedEvent = new ListChangedEventArgs(ListChangedType.ItemChanged, form.GridViewCompanies.CurrentRow.Index);

                        //form.GridViewCompanies.CurrentRow.Cells[1].Value = this.nameTextBox.Text;
                        //form.GridViewCompanies.CurrentRow.Cells[2].Value = this.idTextBox.Text;
                        //form.GridViewCompanies.CurrentRow.Cells[3].Value = this.noteTextBox.Text;


                        form.CompaniesBindingSource_ListChanged(new BindingSource(), ListChangedEvent);

                    }

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
        }

        private bool IsValidData()
        {
            this.errorLabel.Text = "";
            this.errorLabel.ForeColor = Color.Red;
            if (this.nameTextBox.Text == "")
            {
                this.errorLabel.Text = "الأسم لا يمكنم ان يكون فارغاَ!";
                return false;
            }
            if (this.idTextBox.Text == "")
            {
                this.errorLabel.Text = "رقم البطاقة لا يمكنم ان يكون فارغاَ!";
                return false;
            }
            return true;
        }

        private void EditInfo_Load(object sender, EventArgs e)
        {
            AppForm form = this.FindForm() as AppForm;
            if (form != null)
            {

                Binding nameControlBinding = new System.Windows.Forms.Binding("Text", form.companiesBindingSource, "CompanyName", false);
                nameTextBox.DataBindings.Clear();
                nameTextBox.DataBindings.Add(nameControlBinding);
                Binding idControlBinding = new System.Windows.Forms.Binding("Text", form.companiesBindingSource, "ClientID", false);
                idTextBox.DataBindings.Clear();
                idTextBox.DataBindings.Add(idControlBinding);

                Binding NoteControlBinding = new System.Windows.Forms.Binding("Text", form.companiesBindingSource, "Note", false);
                noteTextBox.DataBindings.Clear();
                noteTextBox.DataBindings.Add(NoteControlBinding);

            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}