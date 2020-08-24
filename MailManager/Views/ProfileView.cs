using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using MailManager.Components;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailManager.Views
{
    public partial class ProfileView : Form
    {
        private int posX = 0;
        private int posY = 0;
        private readonly FirebaseAuthLink signIn;
        private readonly User userApp;

        public ProfileView(FirebaseAuthLink signIn, User userApp)
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

            this.signIn = signIn;
            this.userApp = userApp;
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
            string auth = "fHpWjVWQYzXVy4nwZpqmpvkMySYzRM9I4csjFWAt";
            string url = "https://mailmanager-49f1c.firebaseio.com";
            FirebaseClient client = new FirebaseClient(
                url,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(auth)
                });
            txtVerificationMail.Text = userApp.Email;
            txtName.Text = userApp.DisplayName;

            List<MailAccount> mails = null;

            var query2 = await client
            .Child("User Account")
            .Child($"{userApp.DisplayName} Mails")
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
                AdvancedMailsPanel mailsPanel = new AdvancedMailsPanel();
                mailsPanel.TxtMail.Text = AES.Dencrypt(account.Mail);
                mailsPanel.TxtPasswordMail.Text = AES.Dencrypt(account.Password);
                mailsPanel.CbProtocol.SelectedItem = AES.Dencrypt(account.Protocol);
                mailsPanel.TxtPort.Text = Convert.ToString(account.Puerto);
                
                if(!string.IsNullOrEmpty(account.Hostname))
                mailsPanel.TxtHostname.Text = AES.Dencrypt(account.Hostname);

                panel1.Controls.Add(mailsPanel);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
