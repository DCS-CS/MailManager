namespace MailManager.Views
{
    partial class AdvancedOptionsCreateAccountView
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
            this.txtVerificationMail = new System.Windows.Forms.TextBox();
            this.lblVerificationMail = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlAccountMails = new System.Windows.Forms.Panel();
            this.btnRemovePanel = new System.Windows.Forms.Button();
            this.btnAddPanel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVerificationMail
            // 
            this.txtVerificationMail.Location = new System.Drawing.Point(15, 29);
            this.txtVerificationMail.Name = "txtVerificationMail";
            this.txtVerificationMail.Size = new System.Drawing.Size(263, 22);
            this.txtVerificationMail.TabIndex = 12;
            // 
            // lblVerificationMail
            // 
            this.lblVerificationMail.AutoSize = true;
            this.lblVerificationMail.Location = new System.Drawing.Point(12, 9);
            this.lblVerificationMail.Name = "lblVerificationMail";
            this.lblVerificationMail.Size = new System.Drawing.Size(59, 17);
            this.lblVerificationMail.TabIndex = 17;
            this.lblVerificationMail.Text = "Correo: ";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(303, 29);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(202, 22);
            this.txtPassword.TabIndex = 14;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(523, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(193, 22);
            this.txtName.TabIndex = 16;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(300, 9);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(85, 17);
            this.lblPassword.TabIndex = 15;
            this.lblPassword.Text = "Contraseña:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(520, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 17);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Nombre:";
            // 
            // pnlAccountMails
            // 
            this.pnlAccountMails.AutoScroll = true;
            this.pnlAccountMails.Location = new System.Drawing.Point(12, 114);
            this.pnlAccountMails.Name = "pnlAccountMails";
            this.pnlAccountMails.Size = new System.Drawing.Size(773, 260);
            this.pnlAccountMails.TabIndex = 21;
            // 
            // btnRemovePanel
            // 
            this.btnRemovePanel.BackColor = System.Drawing.Color.Transparent;
            this.btnRemovePanel.Location = new System.Drawing.Point(93, 77);
            this.btnRemovePanel.Name = "btnRemovePanel";
            this.btnRemovePanel.Size = new System.Drawing.Size(75, 31);
            this.btnRemovePanel.TabIndex = 19;
            this.btnRemovePanel.Text = "Quitar";
            this.btnRemovePanel.UseVisualStyleBackColor = false;
            // 
            // btnAddPanel
            // 
            this.btnAddPanel.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddPanel.Location = new System.Drawing.Point(12, 77);
            this.btnAddPanel.Name = "btnAddPanel";
            this.btnAddPanel.Size = new System.Drawing.Size(75, 31);
            this.btnAddPanel.TabIndex = 18;
            this.btnAddPanel.Text = "Añadir";
            this.btnAddPanel.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 382);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(149, 31);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Volver atras";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Location = new System.Drawing.Point(677, 382);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(108, 31);
            this.btnCreateAccount.TabIndex = 23;
            this.btnCreateAccount.Text = "Crear cuenta";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            // 
            // AdvancedOptionsCreateAccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlAccountMails);
            this.Controls.Add(this.btnRemovePanel);
            this.Controls.Add(this.btnAddPanel);
            this.Controls.Add(this.txtVerificationMail);
            this.Controls.Add(this.lblVerificationMail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdvancedOptionsCreateAccountView";
            this.Text = "AdvancedOptionsCreateAccountView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVerificationMail;
        private System.Windows.Forms.Label lblVerificationMail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlAccountMails;
        private System.Windows.Forms.Button btnRemovePanel;
        private System.Windows.Forms.Button btnAddPanel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCreateAccount;
    }
}