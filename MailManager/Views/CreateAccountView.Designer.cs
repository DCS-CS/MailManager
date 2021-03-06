﻿namespace MailManager
{
    partial class CreateAccountView
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
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAddPanel = new System.Windows.Forms.Button();
            this.btnRemovePanel = new System.Windows.Forms.Button();
            this.pnlAccountMails = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnAdvancedOptions = new System.Windows.Forms.Button();
            this.lblVerificationMail = new System.Windows.Forms.Label();
            this.txtVerificationMail = new System.Windows.Forms.TextBox();
            this.lblManagerMail = new System.Windows.Forms.Label();
            this.erp = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(543, 41);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(320, 41);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(85, 17);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Contraseña:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(546, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(193, 22);
            this.txtName.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(323, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(202, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Leave += new System.EventHandler(this.TxtPassword_Leave);
            // 
            // btnAddPanel
            // 
            this.btnAddPanel.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddPanel.Location = new System.Drawing.Point(16, 144);
            this.btnAddPanel.Name = "btnAddPanel";
            this.btnAddPanel.Size = new System.Drawing.Size(75, 31);
            this.btnAddPanel.TabIndex = 3;
            this.btnAddPanel.Text = "Añadir";
            this.btnAddPanel.UseVisualStyleBackColor = false;
            this.btnAddPanel.Click += new System.EventHandler(this.BtnAddPanel_Click);
            // 
            // btnRemovePanel
            // 
            this.btnRemovePanel.BackColor = System.Drawing.Color.Transparent;
            this.btnRemovePanel.Location = new System.Drawing.Point(97, 144);
            this.btnRemovePanel.Name = "btnRemovePanel";
            this.btnRemovePanel.Size = new System.Drawing.Size(75, 31);
            this.btnRemovePanel.TabIndex = 4;
            this.btnRemovePanel.Text = "Quitar";
            this.btnRemovePanel.UseVisualStyleBackColor = false;
            this.btnRemovePanel.Click += new System.EventHandler(this.BtnRemovePanel_Click);
            // 
            // pnlAccountMails
            // 
            this.pnlAccountMails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAccountMails.AutoScroll = true;
            this.pnlAccountMails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccountMails.Location = new System.Drawing.Point(16, 181);
            this.pnlAccountMails.Name = "pnlAccountMails";
            this.pnlAccountMails.Size = new System.Drawing.Size(908, 291);
            this.pnlAccountMails.TabIndex = 6;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Location = new System.Drawing.Point(12, 484);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(91, 31);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "<< Login";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAccount.Location = new System.Drawing.Point(812, 484);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(112, 31);
            this.btnCreateAccount.TabIndex = 8;
            this.btnCreateAccount.Text = "Crear Cuenta";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.BtnCreateAccount_Click);
            // 
            // btnAdvancedOptions
            // 
            this.btnAdvancedOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvancedOptions.Location = new System.Drawing.Point(752, 144);
            this.btnAdvancedOptions.Name = "btnAdvancedOptions";
            this.btnAdvancedOptions.Size = new System.Drawing.Size(172, 31);
            this.btnAdvancedOptions.TabIndex = 5;
            this.btnAdvancedOptions.Text = "Opciones avanzadas >>";
            this.btnAdvancedOptions.UseVisualStyleBackColor = true;
            this.btnAdvancedOptions.Click += new System.EventHandler(this.BtnAdvancedOptions_Click);
            // 
            // lblVerificationMail
            // 
            this.lblVerificationMail.AutoSize = true;
            this.lblVerificationMail.Location = new System.Drawing.Point(32, 41);
            this.lblVerificationMail.Name = "lblVerificationMail";
            this.lblVerificationMail.Size = new System.Drawing.Size(59, 17);
            this.lblVerificationMail.TabIndex = 11;
            this.lblVerificationMail.Text = "Correo: ";
            // 
            // txtVerificationMail
            // 
            this.txtVerificationMail.Location = new System.Drawing.Point(35, 61);
            this.txtVerificationMail.Name = "txtVerificationMail";
            this.txtVerificationMail.Size = new System.Drawing.Size(263, 22);
            this.txtVerificationMail.TabIndex = 0;
            this.txtVerificationMail.Leave += new System.EventHandler(this.TxtVerificationMail_Leave);
            // 
            // lblManagerMail
            // 
            this.lblManagerMail.AutoSize = true;
            this.lblManagerMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerMail.Location = new System.Drawing.Point(12, 114);
            this.lblManagerMail.Name = "lblManagerMail";
            this.lblManagerMail.Size = new System.Drawing.Size(108, 18);
            this.lblManagerMail.TabIndex = 13;
            this.lblManagerMail.Text = "Datos correos:";
            // 
            // erp
            // 
            this.erp.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Datos de acceso:";
            // 
            // CreateAccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(937, 532);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblManagerMail);
            this.Controls.Add(this.txtVerificationMail);
            this.Controls.Add(this.lblVerificationMail);
            this.Controls.Add(this.btnAdvancedOptions);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlAccountMails);
            this.Controls.Add(this.btnRemovePanel);
            this.Controls.Add(this.btnAddPanel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateAccountView";
            this.Text = "CreateAccount";
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAddPanel;
        private System.Windows.Forms.Button btnRemovePanel;
        private System.Windows.Forms.Panel pnlAccountMails;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Button btnAdvancedOptions;
        private System.Windows.Forms.Label lblVerificationMail;
        private System.Windows.Forms.TextBox txtVerificationMail;
        private System.Windows.Forms.Label lblManagerMail;
        private System.Windows.Forms.ErrorProvider erp;
        private System.Windows.Forms.Label label1;
    }
}