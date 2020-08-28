namespace MailManager
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class ManagedAccountView : Form
    {
        private readonly List<MailAccount> mails;

        public ManagedAccountView(List<MailAccount> mailsDencrypt)
        {
            InitializeComponent();
            mails = mailsDencrypt;

            foreach (MailAccount mail in mails)
            {
                Mails mailpage = new Mails(mail);
                TabPage page = new TabPage
                {
                    Location = new Point(4, 25),
                    Padding = new Padding(3),
                    TabIndex = 0,
                    Text = mail.Mail,
                    UseVisualStyleBackColor = true
                };
                mailpage.Dock = DockStyle.Fill;
                mailpage.TopLevel = false;
                page.Controls.Add(mailpage);        
                Height = mailpage.Height + 20;
                Width = mailpage.Width + 15;
                mailpage.Show();

                tabControl1.TabPages.Add(page);
            }
        }
    }
}
