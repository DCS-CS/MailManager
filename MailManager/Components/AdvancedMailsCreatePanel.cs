using System.Windows.Forms;

namespace MailManager.Components
{
    internal class AdvancedMailsCreatePanel : MailsCreatePanel
    {
        public TextBox TxtHostname { get; set; }
        public ComboBox CbProtocol { get; set; }
        public TextBox TxtPort { get; set; }

        public AdvancedMailsCreatePanel()
        {
            TxtHostname = new TextBox();
            TxtPort = new TextBox();
            CbProtocol = new ComboBox();
            Label lblHostname = new Label();
            Label lblPort = new Label();
            Label lblProtocol = new Label();

            Controls.Add(TxtHostname);
            Controls.Add(TxtPort);
            Controls.Add(lblPort);
            Controls.Add(lblHostname);
            Controls.Add(lblProtocol);
            //
            // TxtHostname
            //
            TxtHostname.Location = new System.Drawing.Point(476, 22);
            TxtHostname.Size = new System.Drawing.Size(100, 25);
            TxtHostname.Name = "TxtHostname";
            TxtHostname.TabIndex = 4;
            //
            // lblHostname
            //
            lblHostname.AutoSize = true;
            lblHostname.Location = new System.Drawing.Point(476, 2);
            lblHostname.Name = "lblHostname";
            lblHostname.Text = "Servidor:";
            //
            // TxtPort
            //
            TxtPort.Location = new System.Drawing.Point(590, 22);
            TxtPort.Size = new System.Drawing.Size(100, 25);
            TxtPort.Name = "TxtHostname";
            TxtPort.TabIndex = 4;
            //
            // lblPort
            //
            lblHostname.AutoSize = true;
            lblHostname.Location = new System.Drawing.Point(590, 2);
            lblHostname.Name = "lblPort";
            lblHostname.Text = "Puerto:";
            //
            // CbProtocol
            //

        }
    }
}
