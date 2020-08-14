using System;
using System.Windows.Forms;

namespace MailManager.Components
{
    internal class AdvancedMailsPanel : MailsCreatePanel
    {
        public TextBox TxtHostname { get; set; }
        public ComboBox CbProtocol { get; set; }
        public TextBox TxtPort { get; set; }

        public AdvancedMailsPanel()
        {
            TxtHostname = new TextBox();
            TxtPort = new TextBox();
            CbProtocol = new ComboBox();
            Label lblHostname = new Label();
            Label lblPort = new Label();
            Label lblProtocol = new Label();

            Controls.Add(TxtHostname);
            Controls.Add(TxtPort);
            Controls.Add(CbProtocol);
            Controls.Add(lblPort);
            Controls.Add(lblHostname);
            Controls.Add(lblProtocol);
            //
            // TxtHostname
            //
            TxtHostname.Location = new System.Drawing.Point(240, 70);
            TxtHostname.Size = new System.Drawing.Size(125, 25);
            TxtHostname.Name = "TxtHostname";
            TxtHostname.TabIndex = 4;
            //
            // lblHostname
            //
            lblHostname.AutoSize = true;
            lblHostname.Location = new System.Drawing.Point(240, 50);
            lblHostname.Name = "lblHostname";
            lblHostname.Text = "Servidor:";
            //
            // TxtPort
            //
            TxtPort.Location = new System.Drawing.Point(150, 70);
            TxtPort.Size = new System.Drawing.Size(50, 25);
            TxtPort.Name = "TxtHostname";
            TxtPort.TabIndex = 4;
            TxtPort.KeyPress += new KeyPressEventHandler(TxtPort_KeyPress);
            //
            // lblPort
            //
            lblPort.AutoSize = true;
            lblPort.Location = new System.Drawing.Point(150, 50);
            lblPort.Name = "lblPort";
            lblPort.Text = "Puerto:";
            //
            // CbProtocol
            //
            CbProtocol.Location = new System.Drawing.Point(4, 70);
            CbProtocol.FormattingEnabled = true;
            CbProtocol.Size = new System.Drawing.Size(80, 25);
            CbProtocol.SelectedIndexChanged += new EventHandler(CbProtocol_SelectedIndexChanged);
            CbProtocol.Items.AddRange(new string[]
            {
                "IMAP",
                "POP"
            }
            );
            //
            // lblProtocol
            //
            lblProtocol.AutoSize = true;
            lblProtocol.Location = new System.Drawing.Point(4, 50);
            lblProtocol.Name = "lblProtocol";
            lblProtocol.Text = "Protocolo:";
        }

        private void CbProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbProtocol.SelectedItem.Equals("IMAP"))
            {
                TxtHostname.Text = "imap.";
                TxtPort.Text = "993";
            }
            else
            {
                TxtHostname.Text = "pop.";
                TxtPort.Text = "995";
            }
        }

        private void TxtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
