namespace MailManager
{
    public class MailAccount
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Hostname { get; }
        public int Puerto { get; }
        public string Protocol { get; }
        public bool SSL { get; }

        public MailAccount(string mail, string password, string hostname, int puerto, string protocol, bool sSL)
        {
            Mail = mail;
            Password = password;
            Hostname = hostname;
            Puerto = puerto;
            Protocol = protocol;
            SSL = sSL;
        }

    }
}
