using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using MailManager.Class;
using MailManager.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailManager
{
    public partial class CreateAccountView : Form
    {
        private readonly List<MailsCreatePanel> panels;
        private readonly List<AdvancedMailsPanel> panelsAdvanced;
        private readonly MainView view;
        private bool advancedOption = false;

        public CreateAccountView(MainView mainView)
        {
            InitializeComponent();

            view = mainView;
            panels = new List<MailsCreatePanel>();
            panelsAdvanced = new List<AdvancedMailsPanel>();

            panels.Add(new MailsCreatePanel());
            pnlAccountMails.Controls.Add(panels[panels.Count - 1]);
        }

        private void btnAddPanel_Click(object sender, EventArgs e)
        {
            if (!advancedOption)
            {
                panels.Add(new MailsCreatePanel());
                pnlAccountMails.Controls.Add(panels[panels.Count - 1]);
            }
            else
            {
                panelsAdvanced.Add(new AdvancedMailsPanel());
                pnlAccountMails.Controls.Add(panelsAdvanced[panelsAdvanced.Count - 1]);
            }

        }

        private void btnRemovePanel_Click(object sender, EventArgs e)
        {
            if (!advancedOption)
            {
                if (panels.Count > 1)
                {
                    pnlAccountMails.Controls.RemoveAt(panels.Count - 1);
                    panels.RemoveAt(panels.Count - 1);
                }
            }
            else
            {
                if (panelsAdvanced.Count > 1)
                {
                    pnlAccountMails.Controls.RemoveAt(panelsAdvanced.Count - 1);
                    panelsAdvanced.RemoveAt(panelsAdvanced.Count - 1);
                }
            }

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            view.ChangeView(new Login(view));
            Dispose();
            Close();
        }

        private async void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtPassword.Text)
                && !string.IsNullOrEmpty(txtVerificationMail.Text))
            {
                FirebaseClient client = FireConfig.GetClient();
                FirebaseAuthProvider authProvider = FireConfig.GetAuthProvider();
                FirebaseAuthLink createUser = null;
                
                try
                {
                    createUser = await authProvider.CreateUserWithEmailAndPasswordAsync(
                    txtVerificationMail.Text,
                    txtPassword.Text,
                    txtName.Text,
                    true);
                }
                catch (FirebaseAuthException)
                {
                    MessageBox.Show(
                        "Este correo ya esta registrado",
                        "Error");
                    return;
                }

                List<MailAccount> mails = new List<MailAccount>();
                AES.CryptoConfigure();
                
                if (!advancedOption)
                {
                    foreach (MailsCreatePanel a in panels)
                    {
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
                    foreach (AdvancedMailsPanel a in panelsAdvanced)
                    {
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
                
                _ = await client
                    .Child("User Account")
                    .Child($"{user.DisplayName} Mails")
                    .PostAsync(mails);

                MessageBox.Show(
                    "Le hemos enviado un correo de verificación a su correo",
                    "Exito");

                view.ChangeView(new Login(view));
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

        private void txtPassword_Leave(object sender, EventArgs e)
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

        private void txtVerificationMail_Leave(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!advancedOption)
            {
                btnAdvancedOptions.Text = "Opciones normales >>";
                pnlAccountMails.Controls.Clear();
                panels.Clear();
                panelsAdvanced.Add(new AdvancedMailsPanel());
                pnlAccountMails.Controls.Add(panelsAdvanced[panelsAdvanced.Count - 1]);
                advancedOption = true;
            }
            else
            {
                btnAdvancedOptions.Text = "Opciones avanzadas >>";
                pnlAccountMails.Controls.Clear();
                panelsAdvanced.Clear();
                panels.Add(new MailsCreatePanel());
                pnlAccountMails.Controls.Add(panels[panels.Count - 1]);
                advancedOption = false;
            }
        }
    }
}
