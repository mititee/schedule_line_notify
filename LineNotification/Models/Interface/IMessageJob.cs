
namespace LineNotification.Models.Interface
{
    public interface IMessageJob
    {
        bool IsTest { set; get; }
        string Message { set; get; }
        string ResponseMessage { get; }
        void Send();
    }
}
