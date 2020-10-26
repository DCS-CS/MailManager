using Firebase.Auth;
using MailManager.Class;
using System;
using System.Windows.Forms;

namespace MailManager.Views
{
    public partial class ChangePassword : Form
    {
        private readonly MainView view;

        public ChangePassword(MainView view)
        {
            InitializeComponent();
            this.view = view;
        }
        // Evento para enviar un correo al correo deseado y cambiar contraseña
        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                FirebaseAuthProvider firebaseAuthProvider = UtilsMailManager.GetAuthProvider();
                firebaseAuthProvider.SendPasswordResetEmailAsync(txtEmail.Text);
                MessageBox.Show(
                    "Correo Enviado",
                    "Exito");
                BackLogin();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Introduce un correo valido",
                    "Error");
            }
        }
        // Evento para volver a la ventana de login
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BackLogin();
        }
        // Método para volver al login
        private void BackLogin()
        {
            view.ChangeView(new LoginView(view));
            Dispose();
            Close();
        }
    }
}
