namespace Contract_Management.CustomControls
{
    partial class EditInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new Telerik.WinControls.UI.RadPanel();
            this.guestInfoLabel = new Telerik.WinControls.UI.RadLabel();
            this.closeButton = new Telerik.WinControls.UI.RadButton();
            this.saveButton = new Telerik.WinControls.UI.RadButton();
            this.editPanel = new Telerik.WinControls.UI.RadPanel();
            this.noteTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.noteLabel = new Telerik.WinControls.UI.RadLabel();
            this.idTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.idSeparator = new Telerik.WinControls.UI.RadSeparator();
            this.idLabel = new Telerik.WinControls.UI.RadLabel();
            this.nameTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.nameSeparator = new Telerik.WinControls.UI.RadSeparator();
            this.nameLabel = new Telerik.WinControls.UI.RadLabel();
            this.errorLabel = new Telerik.WinControls.UI.RadLabel();
            this.deleteButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guestInfoLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanel)).BeginInit();
            this.editPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noteTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextBox)).BeginInit();
            this.idTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextBox)).BeginInit();
            this.nameTextBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameSeparator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteButton)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.guestInfoLabel);
            this.headerPanel.Controls.Add(this.closeButton);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(270, 40);
            this.headerPanel.TabIndex = 0;
            // 
            // guestInfoLabel
            // 
            this.guestInfoLabel.AutoSize = false;
            this.guestInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guestInfoLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestInfoLabel.Location = new System.Drawing.Point(30, 0);
            this.guestInfoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.guestInfoLabel.Name = "guestInfoLabel";
            this.guestInfoLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.guestInfoLabel.Size = new System.Drawing.Size(240, 40);
            this.guestInfoLabel.TabIndex = 2;
            this.guestInfoLabel.Text = "بيانات السائق";
            this.guestInfoLabel.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.closeButton.Location = new System.Drawing.Point(0, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 40);
            this.closeButton.TabIndex = 1;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(152, 553);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 24);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "تعديل";
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.noteTextBox);
            this.editPanel.Controls.Add(this.noteLabel);
            this.editPanel.Controls.Add(this.idTextBox);
            this.editPanel.Controls.Add(this.idLabel);
            this.editPanel.Controls.Add(this.nameTextBox);
            this.editPanel.Controls.Add(this.nameLabel);
            this.editPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.editPanel.Location = new System.Drawing.Point(0, 40);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(270, 290);
            this.editPanel.TabIndex = 3;
            // 
            // noteTextBox
            // 
            this.noteTextBox.AutoSize = false;
            this.noteTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.noteTextBox.Location = new System.Drawing.Point(0, 200);
            this.noteTextBox.Multiline = true;
            this.noteTextBox.Name = "noteTextBox";
            this.noteTextBox.NullText = "ادخل الملاحظات ان وجدت";
            this.noteTextBox.ShowNullText = true;
            this.noteTextBox.Size = new System.Drawing.Size(270, 87);
            this.noteTextBox.TabIndex = 3;
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = false;
            this.noteLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.noteLabel.Location = new System.Drawing.Point(0, 160);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.noteLabel.Size = new System.Drawing.Size(270, 40);
            this.noteLabel.TabIndex = 6;
            this.noteLabel.Text = "ملاحظات:";
            this.noteLabel.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // idTextBox
            // 
            this.idTextBox.AutoSize = false;
            this.idTextBox.Controls.Add(this.idSeparator);
            this.idTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.idTextBox.Location = new System.Drawing.Point(0, 120);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.NullText = "ادخل رقم البطاقة";
            this.idTextBox.Size = new System.Drawing.Size(270, 40);
            this.idTextBox.TabIndex = 2;
            // 
            // idSeparator
            // 
            this.idSeparator.Location = new System.Drawing.Point(29, 33);
            this.idSeparator.Name = "idSeparator";
            this.idSeparator.Size = new System.Drawing.Size(230, 4);
            this.idSeparator.TabIndex = 2;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = false;
            this.idLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.idLabel.Location = new System.Drawing.Point(0, 80);
            this.idLabel.Name = "idLabel";
            this.idLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.idLabel.Size = new System.Drawing.Size(270, 40);
            this.idLabel.TabIndex = 2;
            this.idLabel.Text = "رقم البطاقة:";
            this.idLabel.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // nameTextBox
            // 
            this.nameTextBox.AutoSize = false;
            this.nameTextBox.Controls.Add(this.nameSeparator);
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameTextBox.Location = new System.Drawing.Point(0, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.NullText = "ادخل اسم السائق";
            this.nameTextBox.Size = new System.Drawing.Size(270, 40);
            this.nameTextBox.TabIndex = 0;
            // 
            // nameSeparator
            // 
            this.nameSeparator.Location = new System.Drawing.Point(29, 33);
            this.nameSeparator.Name = "nameSeparator";
            this.nameSeparator.Size = new System.Drawing.Size(230, 4);
            this.nameSeparator.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = false;
            this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameLabel.Location = new System.Drawing.Point(0, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.nameLabel.Size = new System.Drawing.Size(270, 40);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "الأسم:";
            this.nameLabel.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = false;
            this.errorLabel.Location = new System.Drawing.Point(135, 610);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(132, 57);
            this.errorLabel.TabIndex = 6;
            this.errorLabel.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(20, 553);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 24);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "حذف";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // EditInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.headerPanel);
            this.Name = "EditInfo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(270, 604);
            this.Load += new System.EventHandler(this.EditInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guestInfoLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPanel)).EndInit();
            this.editPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.noteTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idTextBox)).EndInit();
            this.idTextBox.ResumeLayout(false);
            this.idTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextBox)).EndInit();
            this.nameTextBox.ResumeLayout(false);
            this.nameTextBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameSeparator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel headerPanel;
        private Telerik.WinControls.UI.RadButton closeButton;
        private Telerik.WinControls.UI.RadPanel editPanel;
        private Telerik.WinControls.UI.RadSeparator nameSeparator;
        private Telerik.WinControls.UI.RadSeparator idSeparator;
        private Telerik.WinControls.UI.RadLabel errorLabel;
        private Telerik.WinControls.UI.RadTextBox idTextBox;
        private Telerik.WinControls.UI.RadTextBox nameTextBox;
        private Telerik.WinControls.UI.RadTextBox noteTextBox;
        private Telerik.WinControls.UI.RadLabel noteLabel;
        private Telerik.WinControls.UI.RadLabel idLabel;
        private Telerik.WinControls.UI.RadLabel nameLabel;
        private Telerik.WinControls.UI.RadLabel guestInfoLabel;
        public Telerik.WinControls.UI.RadButton saveButton;
        public Telerik.WinControls.UI.RadButton deleteButton;
    }
}
