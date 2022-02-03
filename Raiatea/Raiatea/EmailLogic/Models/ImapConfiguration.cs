namespace Raiatea.EmailLogic.Models
{
    public class ImapConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }

        public ImapConfiguration() { }
        public ImapConfiguration(string host, int port, bool useSsl)
        {
            Host = host;
            Port = port;
            UseSsl = useSsl;
        }
    }
}
