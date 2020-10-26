using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using MailManager.Class;
using MailManager.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MailManager
{
    public partial class LoginView : Form
    {
        private readonly MainView view;

        public LoginView(MainView mainView)
        {
            InitializeComponent();
            view = mainView;
        }
        // Evento que abre la ventana para crear una cuenta.
        private void lklblNewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            view.ChangeView(new CreateAccountView(view));
            Dispose();
            Close();
        }
        /*
         * Evento que se encarga de logear verificar los datos introducidos en las
         * cajas de texto y si son correctos:
         * + Se extraerán los emails guardados en firebase correspondientes a la cuenta.
         * + Se cambiará a la ventana ManagedAccountView
         * Si son incorrectos se mostrará a un error en pantalla.
         */
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            FirebaseClient client = UtilsMailManager.GetClient();
            FirebaseAuthProvider authProvider = UtilsMailManager.GetAuthProvider();

            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(
                    "Los campos de usuario y contraseña son obligatorios",
                    "Error");
            }
            else
            {
                try
                {
                    var signIn = await authProvider.SignInWithEmailAndPasswordAsync(txtUser.Text, txtPassword.Text);
                    User user = await authProvider.GetUserAsync(signIn.FirebaseToken);
                    if (user.IsEmailVerified)
                    {
                        List<MailAccount> mails = null;

                        var query2 = await client
                        .Child("User Account")
                        .Child($"{user.DisplayName} Mails")
                        .OrderByKey()
                        .OnceAsync<List<MailAccount>>();

                        foreach (var account in query2)
                        {
                            mails = account.Object;
                        }

                        AES.CryptoConfigure();

                        List<MailAccount> mailsDencrypt = new List<MailAccount>();

                        foreach (MailAccount account in mails)
                        {
                            string hostname = null;
                            if (!string.IsNullOrEmpty(account.Hostname))
                            {
                                hostname = AES.Dencrypt(account.Hostname);
                            }

                            mailsDencrypt.Add(new MailAccount(
                                AES.Dencrypt(account.Mail),
                                AES.Dencrypt(account.Password),
                                hostname,
                                account.Puerto,
                                AES.Dencrypt(account.Protocol),
                                account.SSL));
                        }
                        if (string.IsNullOrEmpty(mailsDencrypt[0].Mail))
                        {
                            return;
                        }

                        view.ChangeView(new ManagedAccountView(mailsDencrypt));
                        view.Location = new Point(200, 100);

                        MainView.SignIn = signIn;
                        MainView.UserApp = user;
                        MainView.AuthProvider = authProvider;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Verifica la cuenta",
                            "Error");
                    }
                }
                catch (FirebaseAuthException)
                {
                    MessageBox.Show(
                        "Los datos son incorrectos",
                        "Error");
                }
            }
        }
        // Evento para abrir la ventana de cambio de contraseña
        private void LklblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            view.ChangeView(new ChangePassword(view));
            Dispose();
            Close();
        }
    }
}
