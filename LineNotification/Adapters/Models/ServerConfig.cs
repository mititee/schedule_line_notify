using LineNotification.Adapters.Interface;

namespace LineNotification.Adapters.Models
{
    public class ServerConfig : IServerConfig
    {
        public string LineHost { get; private set; }


        public string TestToken { get; private set; }

        public string ProductionToken { get; private set; }
        private IConfiguration configuration;
        public ServerConfig(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        public void ReadConfig()
        {
            this.LineHost = configuration.GetSection("LineServer").GetSection("Host")?.Value ?? string.Empty;
            this.TestToken = configuration.GetSection("Token").GetSection("Develop")?.Value ?? string.Empty;
            this.ProductionToken = configuration.GetSection("Token").GetSection("Production")?.Value ?? string.Empty;
        }
    }
}
