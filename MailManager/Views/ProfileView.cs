using Firebase.Database;
using Firebase.Database.Query;
using MailManager.Class;
using MailManager.Components;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MailManager.Views
{
    public partial class ProfileView : Form
    {
        private int posX = 0;
        private int posY = 0;

        public ProfileView()
        {
            InitializeComponent();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                pnlTitle.MouseDown += new MouseEventHandler(pnlTitle_MouseDown);
            }
            else
            {
                pnlTitle.MouseMove += new MouseEventHandler(pnlTitle_MouseMove);
            }
        }

        private void IconClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left += (e.X - posX);
                Top += Top + (e.Y - posY);
            }
        }

        private async void ProfileView_Load(object sender, EventArgs e)
        {
            FirebaseClient client = FireConfig.GetClient();

            txtVerificationMail.Text = MainView.UserApp.Email;
            txtName.Text = MainView.UserApp.DisplayName;

            List<MailAccount> mails = null;

            var query2 = await client
            .Child("User Account")
            .Child($"{MainView.UserApp.DisplayName} Mails")
            .OrderByKey()
            .OnceAsync<List<MailAccount>>();

            foreach (var account in query2)
            {
                mails = account.Object;
            }

            AES.CryptoConfigure();

            foreach (MailAccount account in mails)
            {
                AdvancedMailsPanel mailsPanel = new AdvancedMailsPanel();
                mailsPanel.TxtMail.Text = AES.Dencrypt(account.Mail);
                mailsPanel.TxtPasswordMail.Text = AES.Dencrypt(account.Password);
                mailsPanel.CbProtocol.SelectedItem = AES.Dencrypt(account.Protocol);
                mailsPanel.TxtPort.Text = Convert.ToString(account.Puerto);

                if (!string.IsNullOrEmpty(account.Hostname))
                {
                    mailsPanel.TxtHostname.Text = AES.Dencrypt(account.Hostname);
                }

                pnlMails.Controls.Add(mailsPanel);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                await MainView.AuthProvider.ChangeUserPassword(MainView.SignIn.FirebaseToken, txtNewPassword.Text);
                MessageBox.Show(
                    "Contraseña cambiada",
                    "Exito");
            }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            List<MailAccount> mails = new List<MailAccount>();
            foreach (AdvancedMailsPanel a in pnlMails.Controls)
            {
                string hostname = null;
                if (!string.IsNullOrEmpty(a.TxtHostname.Text))
                {
                    hostname = AES.Encrypt(a.TxtHostname.Text);
                }

                mails.Add(new MailAccount(
                    AES.Encrypt(a.TxtMail.Text),
                    AES.Encrypt(a.TxtPasswordMail.Text),
                    hostname,
                    Convert.ToInt32(a.TxtPort.Text),
                    AES.Encrypt(a.CbProtocol.Text),
                    true
                    ));
            }

            FirebaseClient client = FireConfig.GetClient();

            await client
                .Child("User Account")
                .Child($"{MainView.UserApp.DisplayName} Mails")
                .DeleteAsync();

            await client
                .Child("User Account")
                .Child($"{MainView.UserApp.DisplayName} Mails")
                .PostAsync(mails);

            MessageBox.Show(
                "Cambios guardados",
                "Exito");

            Close();
            Dispose();
        }

        private void btnAddMail_Click(object sender, EventArgs e)
        {
            pnlMails.Controls.Add(new AdvancedMailsPanel());
        }
    }
}
