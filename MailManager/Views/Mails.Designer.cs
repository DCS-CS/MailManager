namespace MailManager
{
    partial class Mails
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlMailsView = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnSaveZip = new System.Windows.Forms.Button();
            this.pnlMailsView.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(173, 525);
            this.treeView1.TabIndex = 1;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1360, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(128, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlMailsView
            // 
            this.pnlMailsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMailsView.AutoScroll = true;
            this.pnlMailsView.Controls.Add(this.lblTitle);
            this.pnlMailsView.Location = new System.Drawing.Point(191, 45);
            this.pnlMailsView.Name = "pnlMailsView";
            this.pnlMailsView.Size = new System.Drawing.Size(1297, 492);
            this.pnlMailsView.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(500, 228);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(327, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Seleccione una carpeta para visualizar los correos";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(200, 18);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(136, 21);
            this.chkSelectAll.TabIndex = 3;
            this.chkSelectAll.Text = "Seleccionar todo";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnSaveZip
            // 
            this.btnSaveZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveZip.Location = new System.Drawing.Point(1227, 11);
            this.btnSaveZip.Name = "btnSaveZip";
            this.btnSaveZip.Size = new System.Drawing.Size(127, 32);
            this.btnSaveZip.TabIndex = 4;
            this.btnSaveZip.Text = "Guardar en .Zip";
            this.btnSaveZip.UseVisualStyleBackColor = true;
            this.btnSaveZip.Click += new System.EventHandler(this.btnSaveZip_Click);
            // 
            // Mails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1500, 550);
            this.Controls.Add(this.btnSaveZip);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pnlMailsView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mails";
            this.Text = "Mails";
            this.Load += new System.EventHandler(this.Mails_Load);
            this.pnlMailsView.ResumeLayout(false);
            this.pnlMailsView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlMailsView;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSaveZip;
    }
}