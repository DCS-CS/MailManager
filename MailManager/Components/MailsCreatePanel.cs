namespace MailManager
{
    using System;
    using System.Windows.Forms;

    internal class MailsCreatePanel : Panel
    {
        public TextBox TxtPasswordMail { get; set; }
        public TextBox TxtMail { get; set; }
        public Label LblPasswordMail { get; set; }
        public Label LblMail { get; set; }

        ErrorProvider erp;

        public MailsCreatePanel()
        {
            erp = new ErrorProvider();
            TxtPasswordMail = new TextBox();
            TxtMail = new TextBox();
            LblPasswordMail = new Label();
            LblMail = new Label();

            Controls.Add(TxtPasswordMail);
            Controls.Add(LblPasswordMail);
            Controls.Add(TxtMail);
            Controls.Add(LblMail);
            Name = "grbMails";
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Size = new System.Drawing.Size(400, 80);
            Dock = DockStyle.Top;
            TabIndex = 2;
            TabStop = false;
            // 
            // txtPasswordMail
            // 
            TxtPasswordMail.Location = new System.Drawing.Point(240, 22);
            TxtPasswordMail.Name = "txtPasswordMail";
            TxtPasswordMail.PasswordChar = '*';
            TxtPasswordMail.Size = new System.Drawing.Size(150, 25);
            TxtPasswordMail.TabIndex = 3;
            // 
            // lblPasswordMail
            // 
            LblPasswordMail.AutoSize = true;
            LblPasswordMail.Location = new System.Drawing.Point(240, 2);
            LblPasswordMail.Name = "lblPasswordMail";
            LblPasswordMail.Size = new System.Drawing.Size(85, 17);
            LblPasswordMail.TabIndex = 2;
            LblPasswordMail.Text = "Contraseña:";
            // 
            // txtMail
            // 
            TxtMail.Location = new System.Drawing.Point(4, 22);
            TxtMail.Name = "txtMail";
            TxtMail.Size = new System.Drawing.Size(230, 25);
            TxtMail.TabIndex = 1;
            TxtMail.Leave += new EventHandler(checkMail);
            // 
            // lblMail
            // 
            LblMail.AutoSize = true;
            LblMail.Location = new System.Drawing.Point(4, 2);
            LblMail.Name = "lblMail";
            LblMail.Size = new System.Drawing.Size(55, 17);
            LblMail.TabIndex = 0;
            LblMail.Text = "Correo:";
        }

        private void checkMail(object sender, EventArgs e)
        {
            
            int longitud = TxtMail.Text.Length;
            int count = 0;

            for (int i = 0; i < longitud - 1; i++)
            {
                if (TxtMail.Text.Substring(i, 1).Equals("@"))
                {
                    count++;
                }
            }

            if (count > 1 || count == 0)
            {
                erp.SetError(TxtMail, "Formato de correo desconocido");
                TxtMail.Focus();
            }
            else
            {
                erp.Clear();
            }
        }
    }
}
