namespace MailManager
{
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
                    Name = "tab" + mail.Mail,
                    Padding = new Padding(3),
                    Size = new Size(1262, 628),
                    TabIndex = 0,
                    Text = mail.Mail,
                    UseVisualStyleBackColor = true
                };

                mailpage.TopLevel = false;
                page.Controls.Add(mailpage);
                tabControl1.Height = mailpage.Height;
                tabControl1.Width = mailpage.Width;
                page.Height = mailpage.Height;
                page.Width = mailpage.Width;
                panel1.Height = mailpage.Height;
                panel1.Width = mailpage.Width;
                Height = mailpage.Height + 20;
                Width = mailpage.Width + 15;
                mailpage.Show();

                tabControl1.Controls.Add(page);
            }
        }
    }
}
