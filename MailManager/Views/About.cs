using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailManager.Views
{
    public partial class About : Form
    {
        private int posX = 0;
        private int posY = 0;

        public About()
        {
            InitializeComponent();
        }
        // Evento para cerrar la ventana
        private void iconClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
