using Firebase.Auth;
using MailManager.Views;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MailManager
{
    public partial class MainView : Form
    {
        private int posX = 0;
        private int posY = 0;

        public static User UserApp { get; set; }
        public static FirebaseAuthLink SignIn { get; set; }
        public static FirebaseAuthProvider AuthProvider { get; set; }

        public MainView()
        {
            InitializeComponent();

            //TODO: Hacer ventana de configuración de cuenta obteniendo los datos de firebase y poder modificar los mismos

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                pnlTitle.MouseDown += new MouseEventHandler(pnlTitle_MouseDown);
            }
            else
            {
                pnlTitle.MouseMove += new MouseEventHandler(pnlTitle_MouseMove);
            }

            
        }

        public void ChangeView(Form viewChange)
        {
            if (pnlView.Controls.Count > 0)
            {
                pnlView.Controls.RemoveAt(0);
            }

            Form view = viewChange;
            view.TopLevel = false;
            view.Dock = DockStyle.Fill;
            pnlView.Controls.Add(view);
            pnlView.Tag = view;
            Width = view.Width + 30;
            Height = view.Height + 30;
            view.Show();
            configuraciónToolStripMenuItem.Enabled = true;
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            ChangeView(new Login(this));
            configuraciónToolStripMenuItem.Enabled = false;
        }

        private void IconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IconMaximized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            IconMaximized.Visible = false;
            IconRestore.Visible = true;
        }

        private void IconRestore_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            IconMaximized.Visible = true;
            IconRestore.Visible = false;
        }

        private void IconMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

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

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Imap.Disconnect();
            // Hallar una forma de desconectar el IMAP
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProfileView(SignIn, UserApp, AuthProvider).ShowDialog();
        }
    }
}
