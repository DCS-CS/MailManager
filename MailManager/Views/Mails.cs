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

        // Constructor de la clase Mails en él se inicializa los componentes
        // y se inicializa los campos dependiendo del protocolo del MailAccount 
        // que se reciba.
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
        // Evento para guardar los correos seleccionados en la carpeta seleccionada.
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            string path = null;
            // Obtengo la carpeta en donde quiero guardar los corrreos.
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
                // Obtengo todos los correos seleccionados y los guardo en ids.
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
                    Directory.CreateDirectory(pathMail);// Creo una carpeta con el nombre del asunto del correo, en la direccion especificada
                    FileStream file = new FileStream($"{pathMail}\\body.pdf", FileMode.OpenOrCreate, FileAccess.Write);// Creo el archivo PDF.

                    HtmlToPdf converter = new HtmlToPdf();
                    PdfDocument doc = null; // Creo el documento PDF convirtiendo el html a PDF
                    if (mails.Protocol.Equals("IMAP"))
                    {
                        doc = converter.ConvertHtmlString(imp.GetBodyMail(mail.UniqueId));
                    }
                    else
                    {
                        doc = converter.ConvertHtmlString(mail.message.HtmlBody);
                    }
                    doc.Save(file);// Guardo el documento en el archivo.
                    file.Close();// Cierro el archivo.
                    doc.Close();// Cierro el documento.
                    //Se descargan los archivos adjuntos del correo y se guardan en la carpeta.
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
        // Evento para conectarse al servidor y a la cuenta de correos dependiendo del protocolo
        // cuando se carga la ventana.
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
        // Evento para mostrar los correo cuando haces click en una de las carpetas mostradas en el TreeView.
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
        // Evento para que al pulsar en el check "seleccionar todo" se seleccionen todos los correos.
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
        // Metodo para insertar controles en el pnlMailsView desde hilos o tareas en segundo plano
        // utilizando el delegado.
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
        // Metodo que te devuelve un hostname para poder conectarte al servidor de tu proveedor.
        // Si el Hostname de tu servidor no está, debes insertarlo manualmente ya sea al crear la cuenta 
        // utilizando las opciones avanzadas o modificando tu perfil.
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
        // Evento para guardar los correos seleccionados en un archivo ZIP
        private async void btnSaveZip_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            string path = null;
            // Obtengo la carpeta donde quiero guardar el ZIP.
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
                // Creo una carpeta temporal en la carpeta de Archivos temporales.
                Directory.CreateDirectory(pathTemp);
                foreach (var mail in ids)// guardo los correos en en la carpeta temporal.
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
                    // Guardo los archivos adjuntos en la carpeta temporal
                    if (mails.Protocol.Equals("IMAP"))
                    {
                        imp.DownLoadAttachment(mail.UniqueId, pathMail);
                    }
                    else
                    {
                        pop.DownloadAttachment(mail.message, pathMail);
                    }
                }

                ZipFile.CreateFromDirectory(pathTemp, $"{path}\\Correos.zip");// Creo el archivo ZIP usando la carpeta temporal.
                Directory.Delete(pathTemp, true);// Borro la carpeta temporal.
            });

            MessageBox.Show("Archivo .Zip creado", "Exito");
        }
        // Evento que cierra la conexion con el correo.
        private void Mails_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mails.Protocol.Equals("IMAP"))
            {
                imp.Disconnect();
            }
            else
            {
                pop.Disconnect();
            }
        }
    }
}
