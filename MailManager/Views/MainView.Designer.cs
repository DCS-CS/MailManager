namespace MailManager
{
    partial class MainView
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.IconMinimized = new System.Windows.Forms.PictureBox();
            this.IconMaximized = new System.Windows.Forms.PictureBox();
            this.IconRestore = new System.Windows.Forms.PictureBox();
            this.iconClose = new System.Windows.Forms.PictureBox();
            this.mnuFile = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlView = new System.Windows.Forms.Panel();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconMinimized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconMaximized)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).BeginInit();
            this.mnuFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.White;
            this.pnlTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitle.Controls.Add(this.IconMinimized);
            this.pnlTitle.Controls.Add(this.IconMaximized);
            this.pnlTitle.Controls.Add(this.IconRestore);
            this.pnlTitle.Controls.Add(this.iconClose);
            this.pnlTitle.Controls.Add(this.mnuFile);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(515, 36);
            this.pnlTitle.TabIndex = 3;
            // 
            // IconMinimized
            // 
            this.IconMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IconMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconMinimized.Image = global::MailManager.Properties.Resources.icono_minimizar;
            this.IconMinimized.Location = new System.Drawing.Point(408, 2);
            this.IconMinimized.Name = "IconMinimized";
            this.IconMinimized.Size = new System.Drawing.Size(30, 30);
            this.IconMinimized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconMinimized.TabIndex = 3;
            this.IconMinimized.TabStop = false;
            this.IconMinimized.Click += new System.EventHandler(this.IconMinimized_Click);
            // 
            // IconMaximized
            // 
            this.IconMaximized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IconMaximized.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconMaximized.Image = global::MailManager.Properties.Resources.icono_maximizar;
            this.IconMaximized.Location = new System.Drawing.Point(444, 2);
            this.IconMaximized.Name = "IconMaximized";
            this.IconMaximized.Size = new System.Drawing.Size(30, 30);
            this.IconMaximized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconMaximized.TabIndex = 2;
            this.IconMaximized.TabStop = false;
            this.IconMaximized.Click += new System.EventHandler(this.IconMaximized_Click);
            // 
            // IconRestore
            // 
            this.IconRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IconRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconRestore.Image = global::MailManager.Properties.Resources.icono_restaurar;
            this.IconRestore.Location = new System.Drawing.Point(444, 2);
            this.IconRestore.Name = "IconRestore";
            this.IconRestore.Size = new System.Drawing.Size(30, 30);
            this.IconRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconRestore.TabIndex = 1;
            this.IconRestore.TabStop = false;
            this.IconRestore.Click += new System.EventHandler(this.IconRestore_Click);
            // 
            // iconClose
            // 
            this.iconClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconClose.Image = global::MailManager.Properties.Resources.icono_cerrar;
            this.iconClose.Location = new System.Drawing.Point(480, 2);
            this.iconClose.Name = "iconClose";
            this.iconClose.Size = new System.Drawing.Size(30, 30);
            this.iconClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconClose.TabIndex = 0;
            this.iconClose.TabStop = false;
            this.iconClose.Click += new System.EventHandler(this.IconClose_Click);
            // 
            // mnuFile
            // 
            this.mnuFile.BackColor = System.Drawing.Color.Transparent;
            this.mnuFile.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuFile.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.mnuFile.Location = new System.Drawing.Point(9, 2);
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(296, 28);
            this.mnuFile.TabIndex = 4;
            this.mnuFile.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            // 
            // pnlView
            // 
            this.pnlView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 36);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(515, 441);
            this.pnlView.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 477);
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.pnlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.mnuFile;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.Load += new System.EventHandler(this.LoginView_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconMinimized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconMaximized)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).EndInit();
            this.mnuFile.ResumeLayout(false);
            this.mnuFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox IconMinimized;
        private System.Windows.Forms.PictureBox IconMaximized;
        private System.Windows.Forms.PictureBox IconRestore;
        private System.Windows.Forms.PictureBox iconClose;
        private System.Windows.Forms.MenuStrip mnuFile;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.Panel pnlView;
    }
}

