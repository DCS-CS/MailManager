namespace MailManager
{
    using MailKit.Net.Pop3;
    using System.Windows.Forms;

    internal class Pop3
    {
        private static readonly Pop3Client client = new Pop3Client();

        public static void Connect(string host, int port, bool SSL, string mail, string password)
        {
            client.Connect(host, port, SSL);
            client.Authenticate(mail, password);
        }

        public static void GetEmails(Panel panel)
        {
            for (int i = 0; i < client.Count; i++)
            {
                var message = client.GetMessage(i);
                //MailObject mail = new MailObject(message);

                //panel.Controls.Add(mail);
            }
        }

        public static void Disconnect()
        {
            if (client.IsConnected)
            {
                client.Disconnect(true);
            }
        }
    }
}
