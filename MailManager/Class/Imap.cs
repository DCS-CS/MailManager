namespace MailManager
{
    using MailKit;
    using MailKit.Net.Imap;
    using MailKit.Search;
    using MimeKit;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    internal class Imap
    {
        private readonly ImapClient client = new ImapClient();
        private IMailFolder box;
        public void Connect(string host, int port, bool SSL, string mail, string password)
        {
            client.Connect(host, port, SSL);
            client.Authenticate(mail, password);
        }

        public async void GetEmails(string folder, Mails mails)
        {
            box = GetFolderEmails(folder);

            box.Open(FolderAccess.ReadOnly);
            var query = SearchQuery.SubjectContains("*");
            var uids = box.Search(query);
            var prueba = box.Fetch(uids, MessageSummaryItems.UniqueId | MessageSummaryItems.Headers);

            foreach (var pro in prueba)
            {
                await Task.Run(() =>
                {
                    MailObject mailObject = new MailObject(this);
                    foreach (var header in pro.Headers)
                    {
                        if (header.Field.Equals("Date"))
                        {
                            mailObject.Date.Text = header.Value;
                        }

                        if (header.Field.Equals("From"))
                        {
                            if (header.Value.Contains("<"))
                            {
                                int character = header.Value.IndexOf("<");
                                string from = header.Value.Substring(0, character - 1);
                                mailObject.From.Text = from;
                            }
                        }

                        if (header.Field.Equals("Subject"))
                        {
                            mailObject.Subject.Text = header.Value;
                        }
                    }

                    mailObject.UniqueId = pro.UniqueId;

                    mails.AddControl(mailObject);
                }, CancellationToken.None);
            }
        }

        public string GetBodyMail(UniqueId uniqueId)
        {
            var bodyStructure = box.Fetch(new List<UniqueId> { uniqueId }, MessageSummaryItems.BodyStructure);

            TextPart htmlString = null;

            foreach (var body in bodyStructure)
            {
                var htmlPart = body.HtmlBody;

                htmlString = (TextPart)box.GetBodyPart(uniqueId, htmlPart);

            }

            return htmlString.Text;
        }

        private IMailFolder GetFolderEmails(string folder)
        {
            var list = client.GetFolders(client.PersonalNamespaces[0]);
            IMailFolder box = null;
            foreach (var fol in list)
            {
                if (fol.Name.Equals(folder))
                {
                    box = fol;
                }

            }
            return box;
        }

        public void Folders(TreeView tree)
        {
            var list = client.GetFolders(client.PersonalNamespaces[0]);

            foreach (var folder in list)
            {
                if (!folder.Name.Equals("[Gmail]"))
                {
                    tree.Nodes.Add(folder.Name);
                }

            }

        }

        public void Disconnect()
        {
            if (client.IsConnected)
            {
                client.Disconnect(true);
            }
        }
    }
}
