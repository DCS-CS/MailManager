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
            this.label1 = new System.Windows.Forms.Label();
            this.iconClose = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVerificationMail = new System.Windows.Forms.TextBox();
            this.lblVerificationMail = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Controls.Add(this.iconClose);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(940, 36);
            this.pnlTitle.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 12);
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
            this.iconClose.Location = new System.Drawing.Point(907, 3);
            this.iconClose.Name = "iconClose";
            this.iconClose.Size = new System.Drawing.Size(30, 30);
            this.iconClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconClose.TabIndex = 0;
            this.iconClose.TabStop = false;
            this.iconClose.Click += new System.EventHandler(this.IconClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 267);
            this.panel1.TabIndex = 5;
            // 
            // txtVerificationMail
            // 
            this.txtVerificationMail.Location = new System.Drawing.Point(29, 69);
            this.txtVerificationMail.Name = "txtVerificationMail";
            this.txtVerificationMail.Size = new System.Drawing.Size(263, 22);
            this.txtVerificationMail.TabIndex = 12;
            // 
            // lblVerificationMail
            // 
            this.lblVerificationMail.AutoSize = true;
            this.lblVerificationMail.Location = new System.Drawing.Point(26, 49);
            this.lblVerificationMail.Name = "lblVerificationMail";
            this.lblVerificationMail.Size = new System.Drawing.Size(59, 17);
            this.lblVerificationMail.TabIndex = 17;
            this.lblVerificationMail.Text = "Correo: ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(319, 69);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(193, 22);
            this.txtName.TabIndex = 16;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(316, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 17);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Nombre:";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(540, 68);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(157, 23);
            this.btnChangePassword.TabIndex = 18;
            this.btnChangePassword.Text = "Cambiar contraseña";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(785, 403);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(136, 39);
            this.btnSaveChanges.TabIndex = 19;
            this.btnSaveChanges.Text = "Guardar cambios";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(634, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 39);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProfileView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(940, 453);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.txtVerificationMail);
            this.Controls.Add(this.lblVerificationMail);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProfileView";
            this.Text = "ProfileView";
            this.Load += new System.EventHandler(this.ProfileView_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox iconClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtVerificationMail;
        private System.Windows.Forms.Label lblVerificationMail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnCancel;
    }
}