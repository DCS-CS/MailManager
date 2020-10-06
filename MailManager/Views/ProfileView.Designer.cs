namespace MailManager.Views
{
    partial class ProfileView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconClose = new System.Windows.Forms.PictureBox();
            this.pnlMails = new System.Windows.Forms.Panel();
            this.txtVerificationMail = new System.Windows.Forms.TextBox();
            this.lblVerificationMail = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.btnDeleteMail = new System.Windows.Forms.Button();
            this.btnAddMail = new System.Windows.Forms.Button();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblPnlMails = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitle.Controls.Add(this.pictureBox1);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Controls.Add(this.iconClose);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(963, 36);
            this.pnlTitle.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MailManager.Properties.Resources.Icon_Mail_Manager;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Perfil de usuario";
            // 
            // iconClose
            // 
            this.iconClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconClose.Image = global::MailManager.Properties.Resources.icono_cerrar;
            this.iconClose.Location = new System.Drawing.Point(928, 3);
            this.iconClose.Name = "iconClose";
            this.iconClose.Size = new System.Drawing.Size(30, 30);
            this.iconClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconClose.TabIndex = 0;
            this.iconClose.TabStop = false;
            this.iconClose.Click += new System.EventHandler(this.IconClose_Click);
            // 
            // pnlMails
            // 
            this.pnlMails.Location = new System.Drawing.Point(11, 116);
            this.pnlMails.Name = "pnlMails";
            this.pnlMails.Size = new System.Drawing.Size(937, 243);
            this.pnlMails.TabIndex = 5;
            // 
            // txtVerificationMail
            // 
            this.txtVerificationMail.Enabled = false;
            this.txtVerificationMail.Location = new System.Drawing.Point(32, 38);
            this.txtVerificationMail.Name = "txtVerificationMail";
            this.txtVerificationMail.Size = new System.Drawing.Size(263, 22);
            this.txtVerificationMail.TabIndex = 12;
            // 
            // lblVerificationMail
            // 
            this.lblVerificationMail.AutoSize = true;
            this.lblVerificationMail.Location = new System.Drawing.Point(29, 18);
            this.lblVerificationMail.Name = "lblVerificationMail";
            this.lblVerificationMail.Size = new System.Drawing.Size(59, 17);
            this.lblVerificationMail.TabIndex = 17;
            this.lblVerificationMail.Text = "Correo: ";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(322, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(193, 22);
            this.txtName.TabIndex = 16;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(319, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 17);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Nombre:";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(756, 37);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(157, 23);
            this.btnChangePassword.TabIndex = 18;
            this.btnChangePassword.Text = "Cambiar contraseña";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(812, 365);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(136, 39);
            this.btnSaveChanges.TabIndex = 19;
            this.btnSaveChanges.Text = "Guardar cambios";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.BtnSaveChanges_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(658, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 39);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContainer.Controls.Add(this.btnDeleteMail);
            this.pnlContainer.Controls.Add(this.btnAddMail);
            this.pnlContainer.Controls.Add(this.txtNewPassword);
            this.pnlContainer.Controls.Add(this.lblNewPassword);
            this.pnlContainer.Controls.Add(this.lblPnlMails);
            this.pnlContainer.Controls.Add(this.btnSaveChanges);
            this.pnlContainer.Controls.Add(this.lblVerificationMail);
            this.pnlContainer.Controls.Add(this.btnCancel);
            this.pnlContainer.Controls.Add(this.lblName);
            this.pnlContainer.Controls.Add(this.txtName);
            this.pnlContainer.Controls.Add(this.pnlMails);
            this.pnlContainer.Controls.Add(this.btnChangePassword);
            this.pnlContainer.Controls.Add(this.txtVerificationMail);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 36);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(963, 417);
            this.pnlContainer.TabIndex = 21;
            // 
            // btnDeleteMail
            // 
            this.btnDeleteMail.Location = new System.Drawing.Point(593, 82);
            this.btnDeleteMail.Name = "btnDeleteMail";
            this.btnDeleteMail.Size = new System.Drawing.Size(157, 24);
            this.btnDeleteMail.TabIndex = 25;
            this.btnDeleteMail.Text = "Borrar correo";
            this.btnDeleteMail.UseVisualStyleBackColor = true;
            this.btnDeleteMail.Click += new System.EventHandler(this.BtnDeleteMail_Click);
            // 
            // btnAddMail
            // 
            this.btnAddMail.Location = new System.Drawing.Point(756, 82);
            this.btnAddMail.Name = "btnAddMail";
            this.btnAddMail.Size = new System.Drawing.Size(157, 24);
            this.btnAddMail.TabIndex = 24;
            this.btnAddMail.Text = "Añadir correo";
            this.btnAddMail.UseVisualStyleBackColor = true;
            this.btnAddMail.Click += new System.EventHandler(this.BtnAddMail_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(549, 38);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(177, 22);
            this.txtNewPassword.TabIndex = 23;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(546, 18);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(128, 17);
            this.lblNewPassword.TabIndex = 22;
            this.lblNewPassword.Text = "Nueva contraseña:";
            // 
            // lblPnlMails
            // 
            this.lblPnlMails.AutoSize = true;
            this.lblPnlMails.Location = new System.Drawing.Point(11, 86);
            this.lblPnlMails.Name = "lblPnlMails";
            this.lblPnlMails.Size = new System.Drawing.Size(66, 17);
            this.lblPnlMails.TabIndex = 21;
            this.lblPnlMails.Text = "Correos: ";
            // 
            // ProfileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(963, 453);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProfileView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ProfileView";
            this.Load += new System.EventHandler(this.ProfileView_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox iconClose;
        private System.Windows.Forms.Panel pnlMails;
        private System.Windows.Forms.TextBox txtVerificationMail;
        private System.Windows.Forms.Label lblVerificationMail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblPnlMails;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Button btnAddMail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDeleteMail;
    }
}