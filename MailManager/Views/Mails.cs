namespace MailManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class Mails : Form
    {
        private readonly MailAccount mails;

        private delegate void DelegatePanel(Control panel);
        private readonly Imap imp;

        public Mails(MailAccount mail)
        {
            InitializeComponent();
            mails = mail;
            imp = new Imap();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: Guardar los correos en un pdf
        }

        private void Mails_Load(object sender, EventArgs e)
        {
            int port;
            if (mails.Puerto != 0)
            {
                port = mails.Puerto;
            }
            else
            {
                port = 993;
            }
            imp.Connect(GetHostName(mails.Mail), port, mails.SSL, mails.Mail, mails.Password);
            imp.Folders(treeView1);
        }

        private async void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView tv = sender as TreeView;
            if (tv != null)
            {
                TreeNode selected = e.Node;
                if (selected != null)
                {
                    pnlMailsView.Controls.Clear();
                    tv.Enabled = false;
                    await Task.Run(() => { imp.GetEmails(selected.Text, this); });

                }
            }
            tv.Enabled = true;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            List<MailObject> mails = pnlMailsView.Controls.OfType<MailObject>().ToList();

            foreach (MailObject a in mails)
            {
                if (a.ChkSelect.Checked)
                {
                    a.ChkSelect.Checked = false;
                }
                else
                {
                    a.ChkSelect.Checked = true;
                }
            }
        }

        public void AddControl(Control panel)
        {
            if (pnlMailsView.InvokeRequired)
            {
                DelegatePanel d = new DelegatePanel(AddControl);
                Invoke(d, new object[] { panel });
            }
            else
            {
                pnlMailsView.Controls.Add(panel);
            }
        }

        private string GetHostName(string mail)
        {
            string host = null;
            if (mail.Contains("@"))
            {
                int position = mail.IndexOf('@');
                host = mail.Substring(position + 1);
            }
            //TODO: Terminar de añadir hostname
            Dictionary<string, string> hostNameList = new Dictionary<string, string>
            {
                { "gmail.com", "imap.gmail.com" },
                { "alumnado.fundacionloyola.net", "imap.gmail.com" },
                { "fundacionloyola.es", "imap.gmail.com" },
                { "hotmail.com", "imap-mail.outlook.com" },
                { "outlook.com", "imap-mail.outlook.com" }
            };

            return hostNameList[host];
        }

    }
}
