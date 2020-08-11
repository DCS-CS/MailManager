namespace MailManager
{
    using Firebase.Auth;
    using Firebase.Database;
    using Firebase.Database.Query;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class CreateAccountView : Form
    {
        private readonly List<MailsCreatePanel> panels = new List<MailsCreatePanel>();
        private readonly MainView view;

        public CreateAccountView(MainView mainView)
        {
            InitializeComponent();

            view = mainView;
            panels.Add(new MailsCreatePanel());
            pnlAccountMails.Controls.Add(panels[panels.Count - 1]);
        }

        private void btnAddPanel_Click(object sender, EventArgs e)
        {
            panels.Add(new MailsCreatePanel());
            pnlAccountMails.Controls.Add(panels[panels.Count - 1]);
        }

        private void btnRemovePanel_Click(object sender, EventArgs e)
        {
            if (panels.Count > 1)
            {
                pnlAccountMails.Controls.RemoveAt(panels.Count - 1);
                panels.RemoveAt(panels.Count - 1);
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
                string auth = "fHpWjVWQYzXVy4nwZpqmpvkMySYzRM9I4csjFWAt";
                string auth2 = "AIzaSyCX0f-fX3B1EWpUtGWuF-WEzebQihg3H-E";
                string url = "https://mailmanager-49f1c.firebaseio.com";
                FirebaseClient client = new FirebaseClient(
                    url,
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(auth)
                    });

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(auth2));

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

                foreach (MailsCreatePanel a in panels)
                {
                    string mailEncrypted = AES.Encrypt(a.TxtMail.Text);
                    string passwordEncrypted = AES.Encrypt(a.TxtPasswordMail.Text);
                    string protocolEncrypted = AES.Encrypt("Imap");

                    mails.Add(new MailAccount(mailEncrypted, passwordEncrypted, null, 993, protocolEncrypted, true));
                }

                User user = await authProvider.GetUserAsync(createUser.FirebaseToken);

                var mailsFirebase = await client
                    .Child("User Account")
                    .Child(user.DisplayName + " Mails")
                    .PostAsync(mails);

                MessageBox.Show(
                    "Cuenta creada",
                    "Exito");
            }
            else
            {
                MessageBox.Show(
                    "Ni el correo ni la contraseña ni el nombre pueden estar vacíos",
                    "Error");
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
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

        private void txtVerificationMail_Leave(object sender, EventArgs e)
        {
            int longitud = txtVerificationMail.Text.Length;
            int count = 0;

            for(int i = 0; i < longitud-1; i++)
            {
                if (txtVerificationMail.Text.Substring(i, 1).Equals("@"))
                {
                    count++;
                }
            }

            if(count > 1 || count == 0)
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
}
