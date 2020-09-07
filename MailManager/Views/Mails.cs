using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailManager
{
    public partial class Mails : Form
    {
        private readonly MailAccount mails;
        private delegate void DelegatePanel(Control panel);
        private readonly Imap imp;
        private readonly Pop3 pop;

        public Mails(MailAccount mail)
        {
            InitializeComponent();
            mails = mail;
            if (mails.Protocol.Equals("IMAP"))
            {
                imp = new Imap();
            }
            else
            {
                pop = new Pop3();
                lblTitle.Visible = false;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            string path = null;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath;
                folder.Dispose();
            }
            else
            {
                folder.Dispose();
                return;
            }

            await Task.Run(() =>
            {
                List<MailObject> mailsList = pnlMailsView.Controls.OfType<MailObject>().ToList();
                List<MailObject> ids = new List<MailObject>();

                foreach (MailObject mail in mailsList)
                {
                    if (mail.ChkSelect.Checked)
                    {
                        ids.Add(mail);
                    }
                }

                foreach (MailObject mail in ids)
                {
                    string pathMail = $"{path}\\{mail.Subject.Text}";
                    Directory.CreateDirectory(pathMail);
                    FileStream file = new FileStream($"{pathMail}\\body.pdf", FileMode.OpenOrCreate, FileAccess.Write);

                    HtmlToPdf converter = new HtmlToPdf();
                    PdfDocument doc = null;
                    if (mails.Protocol.Equals("IMAP"))
                    {
                        doc = converter.ConvertHtmlString(imp.GetBodyMail(mail.UniqueId));
                    }
                    else
                    {
                        doc = converter.ConvertHtmlString(mail.message.HtmlBody);
                    }
                    doc.Save(file);
                    file.Close();
                    doc.Close();

                    if (mails.Protocol.Equals("IMAP"))
                    {
                        imp.DownLoadAttachment(mail.UniqueId, pathMail);
                    }
                    else
                    {
                        pop.DownloadAttachment(mail.message, pathMail);
                    }
                }
            }, CancellationToken.None);

            MessageBox.Show("Correo guardado", "Exito");
        }

        private void Mails_Load(object sender, EventArgs e)
        {
            if (mails.Protocol.Equals("IMAP"))
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
                string hostname;
                if (!string.IsNullOrEmpty(mails.Hostname))
                {
                    hostname = mails.Hostname;
                }
                else
                {
                    hostname = GetHostName(mails.Mail);
                }

                imp.Connect(hostname, port, mails.SSL, mails.Mail, mails.Password);
                imp.Folders(treeView1);
            }
            else
            {
                pop.Connect(mails.Hostname, mails.Puerto, mails.SSL, mails.Mail, mails.Password);
                pop.GetEmails(this);
            }
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
                { "gmail.es", "imap.gmail.com" },
                { "alumnado.fundacionloyola.net", "imap.gmail.com" },
                { "fundacionloyola.es", "imap.gmail.com" },
                { "hotmail.com", "imap-mail.outlook.com" },
                { "hotmail.es", "imap-mail.outlook.com" },
                { "outlook.com", "imap-mail.outlook.com" },
                { "yahoo.com", "imap.mail.yahoo.com" }
            };

            return hostNameList[host];
        }

        private async void btnSaveZip_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            string path = null;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath;
                folder.Dispose();
            }
            else
            {
                folder.Dispose();
                return;
            }

            string pathTemp = $"{Path.GetTempPath()}{treeView1.SelectedNode.Text}";

            await Task.Run(() => 
            {
                List<MailObject> list = pnlMailsView.Controls.OfType<MailObject>().ToList();
                List<MailObject> ids = new List<MailObject>();

                foreach (MailObject mail in list)
                {
                    if (mail.ChkSelect.Checked)
                    {
                        ids.Add(mail);
                    }
                }

                Directory.CreateDirectory(pathTemp);
                foreach (var mail in ids)
                {
                    string pathMail = $"{pathTemp}\\{mail.Subject.Text}";
                    Directory.CreateDirectory(pathMail);
                    FileStream file = new FileStream($"{pathMail}\\body.pdf", FileMode.OpenOrCreate, FileAccess.Write);

                    HtmlToPdf converter = new HtmlToPdf();
                    PdfDocument doc = null;
                    if (mails.Protocol.Equals("IMAP"))
                    {
                        doc = converter.ConvertHtmlString(imp.GetBodyMail(mail.UniqueId));
                    }
                    else
                    {
                        doc = converter.ConvertHtmlString(mail.message.HtmlBody);
                    }
                    doc.Save(file);
                    file.Close();
                    doc.Close();

                    if (mails.Protocol.Equals("IMAP"))
                    {
                        imp.DownLoadAttachment(mail.UniqueId, pathMail);
                    }
                    else
                    {
                        pop.DownloadAttachment(mail.message, pathMail);
                    }
                }

                ZipFile.CreateFromDirectory(pathTemp, $"{path}Correos.zip");
                Directory.Delete(pathTemp, true);
            });
        }
    }
}
