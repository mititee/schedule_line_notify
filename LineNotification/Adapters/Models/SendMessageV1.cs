using LineNotification.Adapters.Interface;
using System.Net.Http.Headers;

namespace LineNotification.Adapters.Models
{
    public class SendMessageV1 : ISendMessage
    {

        public string Host { get ; set ; }
        public string Message { get ; set; }
        public string Token { get ; set; }

        public async Task<HttpResponseMessage> Send()
        {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(this.Host);
                client.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.Token);
                var nvc = new List<KeyValuePair<string, string>>();
                nvc.Add(new KeyValuePair<string, string>("message", this.Message));
                var req = new HttpRequestMessage(HttpMethod.Post, Host) { Content = new FormUrlEncodedContent(nvc) };
                var res = await client.SendAsync(req);
                return res;
            
        }
    }
}
