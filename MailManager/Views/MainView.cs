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

        // Constructor de la clase en el cual se inicializa los componentes
        // y da evento a pnlTitle cuando se mantiene el click para 
        // poder desplazar la ventana.
        public MainView()
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

        // Método para cambiar, la ventana visualizada en el panel
        // por la que recibe como parametro.
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

        // Evento que se ejecuta cuando carga la ventana y en él se cambia 
        // la ventana del panel pnlView para que muestre la ventana de login.
        private void LoginView_Load(object sender, EventArgs e)
        {
            ChangeView(new Login(this));
            configuraciónToolStripMenuItem.Enabled = false;
        }

        //Evento que cierra la aplicación al hacer click en el icono de cerrar.
        private void IconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Evento para máximizar la ventana al hacer click en el icono de máximizar.
        private void IconMaximized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            IconMaximized.Visible = false;
            IconRestore.Visible = true;
        }

        //Evento para restaurar el tamaño de la ventana al hacer click  el icono de restaurar.
        private void IconRestore_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            IconMaximized.Visible = true;
            IconRestore.Visible = false;
        }

        //Evento para mínimizar la ventana al hacer click en el icono de mínimizar.
        private void IconMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Evento para poder desplazar la aplicacion por la pantalla usando dll de windows.
        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Evento para poder desplazar la aplicación por la ventana sin usar ninguna dll.
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

        // Evento que abre la ventana de perfil de usuario cuando hace login
        // en la aplicación y hace click en el boton de "Configuración".
        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ProfileView().ShowDialog();
        }
        // Evento que abre la ventana Acerca De.
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
