namespace MailManager
{
    using MailKit.Net.Pop3;
    using MimeKit;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Pop3
    {
        private readonly Pop3Client client = new Pop3Client();

        public void Connect(string host, int port, bool SSL, string mail, string password)
        {
            client.Connect(host, port, SSL);
            client.Authenticate(mail, password);
        }

        public async void GetEmails(Mails mails)
        {
            for (int i = 0; i < client.Count; i++)
            {
                await Task.Run( () =>
                {
                    var message = client.GetMessage(i);

                    MailObject mailObject = new MailObject(null, message);

                    var headers = message.Headers;
                    foreach (var header in headers)
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

                    mails.AddControl(mailObject);
                }, CancellationToken.None);
            }
        }

        public void DownloadAttachment(MimeMessage message, string pathMail)
        {
            foreach (var attachment in message.Attachments)
            {
                var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;

                using (var stream = File.Create($"{pathMail}\\{fileName}"))
                {
                    if (attachment is MessagePart)
                    {
                        var rfc822 = (MessagePart)attachment;

                        rfc822.Message.WriteTo(stream);
                    }
                    else
                    {
                        var part = (MimePart)attachment;

                        part.Content.DecodeTo(stream);
                    }
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
