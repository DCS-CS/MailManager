﻿using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailManager
{
    internal class Imap
    {
        private readonly ImapClient client = new ImapClient();
        private IMailFolder box;
        // Constructor para iniciar conexion con el servidor y cuenta indicados.
        public void Connect(string host, int port, bool SSL, string mail, string password)
        {
            try
            {
                client.Connect(host, port, SSL);
            }
            catch
            {
                MessageBox.Show("Error con los datos de conexion con el proveedor. \nMire su configuración 'Archivo>>Configuración'" +
                    " y cambie los datos", "Error");
            }

            try
            {
                client.Authenticate(mail, password);
            }
            catch
            {
                MessageBox.Show("El correo o la contraseña dados son incorrectos. \nMire su configuración 'Archivo>>Configuración'" +
                    " y cambie los datos", "Error");
            }
        }
        // Método para obtener los correos de la cuenta.
        public async void GetEmails(string folder, Mails mails)
        {
            box = GetFolderEmails(folder);

            box.Open(FolderAccess.ReadOnly);
            var query = SearchQuery.All;
            var uids = box.Search(query);
            var prueba = box.Fetch(uids, MessageSummaryItems.UniqueId | MessageSummaryItems.Headers);

            foreach (var pro in prueba)
            {
                await Task.Run(() =>
                {
                    MailObject mailObject = new MailObject(this, null);
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
                                string from = null;
                                if (character == 0)
                                {
                                    from = header.Value.Substring(0);
                                }
                                else
                                {
                                    from = header.Value.Substring(0, character - 1);
                                }
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
        // Método para obtener el texto del mensaje con formato html.
        public string GetBodyMail(UniqueId uniqueId)
        {
            var bodyStructure = box.Fetch(new List<UniqueId> { uniqueId }, MessageSummaryItems.BodyStructure);

            TextPart htmlString = null;

            foreach (var body in bodyStructure)
            {
                var htmlPart = body.HtmlBody;

                if (htmlPart == null)
                {
                    htmlPart = body.TextBody;
                }
                htmlString = (TextPart)box.GetBodyPart(uniqueId, htmlPart);

            }

            return htmlString.Text;
        }
        // Método para obtener una lista de botones correspondientes a los archivos adjuntos del correo. 
        public List<Button> GetAttachmentsMail(UniqueId uniqueId)
        {
            var bodyStructure = box.Fetch(new List<UniqueId> { uniqueId }, MessageSummaryItems.BodyStructure);
            List<Button> attachmentsList = null;

            foreach (var body in bodyStructure)
            {
                attachmentsList = new List<Button>();

                foreach (var attachment in body.Attachments)
                {
                    attachmentsList.Add(new Button()
                    {
                        Text = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name,
                        AutoSize = true
                    });
                }
            }
            return attachmentsList;
        }
        // Método para descargar los archivos adjuntos.
        public void DownLoadAttachment(UniqueId uniqueId, string path)
        {
            MimeMessage message = box.GetMessage(uniqueId);

            foreach (var attachment in message.Attachments)
            {
                var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;

                using (var stream = File.Create($"{path}\\{fileName}"))
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
        // Método para obtener la carpeta seleccionada en el TreeView.
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
        // Método para obtener todos las carpetas de la cuenta.
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
