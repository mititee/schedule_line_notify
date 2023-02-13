using LineNotification.Adapters.Interface;
using LineNotification.Extension;
using LineNotification.Models.Interface;
using Microsoft.Extensions.Configuration;

namespace LineNotification.Models.Job
{
    public sealed class MessageJobV1 : IMessageJob
    {
        public bool IsTest { get; set; }
        public string Message { get; set; }

        public string ResponseMessage { get; private set; }
        private ISendMessage _SendMessageService;
        private IServerConfig configuration;
        private Timer _timer;
        private HttpResponseMessage _responseMessage;
        private int round;
        public MessageJobV1(ISendMessage SendMessageService, IServerConfig serverConfig)
        {
            this.IsTest = false;
            this.Message = string.Empty;
            this.ResponseMessage = string.Empty;
            configuration = serverConfig;
            _SendMessageService = SendMessageService;
            _responseMessage = new HttpResponseMessage();
            round = 1;
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
        }
        public async void Send()
        {
            configuration.ReadConfig();

            _SendMessageService.Host = configuration.LineHost;
            _SendMessageService.Token = configuration.GetToken(IsTest);


            _SendMessageService.Message = this.Message;

            if (configuration.IsEmptyToken())
            {
                Console.WriteLine($"Empty Token {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}  Message: {this.Message}");
            }
            else
            {
                _responseMessage = await _SendMessageService.Send();
                Console.WriteLine($"StatusCode: {_responseMessage.StatusCode} {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}  Message: {this.Message}");
               
            }

        }

        private void DoWork(object obj)
        {

            this.Message = $"Sent: {round} IsTest: {this.IsTest}";
            Send();
        }

    }
}
