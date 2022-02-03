namespace Raiatea.EmailLogic.Models
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }

        public SmtpConfiguration() { }
        public SmtpConfiguration(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
