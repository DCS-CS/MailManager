using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using MailManager.Class;
using MailManager.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace MailManager
{
    public partial class CreateAccountView : Form
    {
        private readonly MainView view;
        private bool advancedOption = false;

        // Constructor de la clase en el cuál se inicializa los componentes.
        public CreateAccountView(MainView mainView)
        {
            InitializeComponent();

            view = mainView;

            pnlAccountMails.Controls.Add(new MailsCreatePanel());
        }
        // Evento que añade un control a pnlAccountMails.
        private void BtnAddPanel_Click(object sender, EventArgs e)
        {
            if (!advancedOption)
            {
                pnlAccountMails.Controls.Add(new MailsCreatePanel());
            }
            else
            {
                pnlAccountMails.Controls.Add(new AdvancedMailsPanel());
            }

        }
        // Evento que elimina un control de pnlAccountMails.
        private void BtnRemovePanel_Click(object sender, EventArgs e)
        {
            if (pnlAccountMails.Controls.Count > 1)
            {
                pnlAccountMails.Controls.RemoveAt(pnlAccountMails.Controls.Count - 1);
            }
        }
        // Evento para volver a la ventana de login
        private void BtnBack_Click(object sender, EventArgs e)
        {
            view.ChangeView(new LoginView(view));
            Dispose();
            Close();
        }
        // Evento que crea el usuario y guarda los correos en firebase
        private async void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPassword.Text)
                && !string.IsNullOrEmpty(txtVerificationMail.Text))
            { // verifico el correo, la contraseña y el nombre introducidos para que no esten vacios
                FirebaseClient client = UtilsMailManager.GetClient();
                FirebaseAuthProvider authProvider = UtilsMailManager.GetAuthProvider();
                FirebaseAuthLink createUser = null;

                var query2 = await client
                        .Child("User Account")
                        .Child($"{txtName.Text} Mails")
                        .OrderByKey()
                        .OnceAsync<List<MailAccount>>();

                List<MailAccount> mailsQuery = null;
                foreach (var account in query2)
                {
                    mailsQuery = account.Object;
                }

                if(mailsQuery == null)
                {
                    MessageBox.Show(
                        "El nombre ya existe",
                        "Error");
                    return;
                }

                try //Creo el usuario
                {
                    createUser = await authProvider.CreateUserWithEmailAndPasswordAsync(
                    txtVerificationMail.Text, // Correo
                    txtPassword.Text,   // Contraseña
                    txtName.Text,   // Nombre
                    true);      // Booleano que sirve para enviar correo de verificación
                }
                catch (FirebaseAuthException)
                {
                    MessageBox.Show(
                        "Error en la creación del usuario",
                        "Error");
                    return;
                }

                List<MailAccount> mails = new List<MailAccount>();
                AES.CryptoConfigure(); // Configuro el lenguage de encriptacion
                
                if (!advancedOption) // Creo, dependiendo si se utilizan las opciones avanzadas o no, una lista de MailAccount
                {
                    foreach (MailsCreatePanel a in pnlAccountMails.Controls.OfType<MailsCreatePanel>().ToList())
                    {
                        if(string.IsNullOrEmpty(a.TxtMail.Text) || string.IsNullOrEmpty(a.TxtPasswordMail.Text))
                        {
                            MessageBox.Show(
                                "Debe registrar un correo con su contraseña",
                                "Error");
                            return;
                        }
                        mails.Add(new MailAccount(
                            AES.Encrypt(a.TxtMail.Text),
                            AES.Encrypt(a.TxtPasswordMail.Text), 
                            null, 
                            993,
                            AES.Encrypt("IMAP"), 
                            true));
                    }
                }
                else
                {
                    foreach (AdvancedMailsPanel a in pnlAccountMails.Controls.OfType<AdvancedMailsPanel>().ToList())
                    {
                        if (string.IsNullOrEmpty(a.TxtMail.Text) || string.IsNullOrEmpty(a.TxtPasswordMail.Text)
                            || string.IsNullOrEmpty(a.TxtPort.Text) || string.IsNullOrEmpty(a.TxtHostname.Text))
                        {
                            MessageBox.Show(
                                "Debe registrar un correo con su contraseña, puerto y hostname",
                                "Error");
                            return;
                        }
                        mails.Add(new MailAccount(
                            AES.Encrypt(a.TxtMail.Text),
                            AES.Encrypt(a.TxtPasswordMail.Text),
                            AES.Encrypt(a.TxtHostname.Text), 
                            Convert.ToInt32(a.TxtPort.Text),
                            AES.Encrypt(a.CbProtocol.SelectedItem.ToString()), 
                            true));
                    }
                }
                User user = await authProvider.GetUserAsync(createUser.FirebaseToken);
                
                _ = await client // query para guardar en la base de datos de firebase los correos introducidos.
                    .Child("User Account")
                    .Child($"{user.DisplayName} Mails")
                    .PostAsync(mails);

                MessageBox.Show(
                    "Le hemos enviado un correo de verificación a su correo",
                    "Exito");

                view.ChangeView(new LoginView(view));
                Dispose();
                Close();
            }
            else
            {
                MessageBox.Show(
                    "El correo, la contraseña y el nombre son obligatorios",
                    "Error");
            }
        }
        // Evento que verifica si la contraseña introducida tiene entre 6 y 16 caracteres
        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                if (txtPassword.Text.Length > 16 || txtPassword.Text.Length < 6)
                {
                    erp.SetError(txtPassword, "Escribe entre 6 y 16 caracteres para la contraseña");
                    txtPassword.Focus();
                }
                else
                {
                    erp.Clear();
                }
            }
        }
        // Evento que verifica si el correo introducido tiene contiene un "@" 
        private void TxtVerificationMail_Leave(object sender, EventArgs e)
        {
            int longitud = txtVerificationMail.Text.Length;
            int count = 0;

            if (!string.IsNullOrEmpty(txtVerificationMail.Text))
            {
                for (int i = 0; i < longitud - 1; i++)
                {
                    if (txtVerificationMail.Text.Substring(i, 1).Equals("@"))
                    {
                        count++;
                    }
                }

                if (count > 1 || count == 0)
                {
                    erp.SetError(txtVerificationMail, "Formato de correo desconocido");
                    txtVerificationMail.Focus();
                }
                else
                {
                    erp.Clear();
                }
            }
        }
        // Evento para cambiar los controles de pnlAccountMails
        private void BtnAdvancedOptions_Click(object sender, EventArgs e)
        {
            if (!advancedOption)
            {
                btnAdvancedOptions.Text = "Opciones simples >>";
                pnlAccountMails.Controls.Clear();
                pnlAccountMails.Controls.Add(new AdvancedMailsPanel());
                advancedOption = true;
            }
            else
            {
                btnAdvancedOptions.Text = "Opciones avanzadas >>";
                pnlAccountMails.Controls.Clear();
                pnlAccountMails.Controls.Add(new MailsCreatePanel());
                advancedOption = false;
            }
        }
    }
}
