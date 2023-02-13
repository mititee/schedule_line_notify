namespace LineNotification.Adapters.Interface
{
    public interface IServerConfig
    {
        string LineHost { get; }
        string TestToken { get; }
        string ProductionToken { get; }
        void ReadConfig();
    }
}
