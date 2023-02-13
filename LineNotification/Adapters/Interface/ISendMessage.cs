namespace LineNotification.Adapters.Interface
{
    public interface ISendMessage
    {
        string Host { set; get; }
        string Message { set; get; }
        string Token { set; get; }
        Task<HttpResponseMessage> Send();
    }
}
