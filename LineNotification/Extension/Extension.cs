using LineNotification.Adapters.Interface;
using System.Runtime.CompilerServices;

namespace LineNotification.Extension
{
    public static class Extension
    {
        public static bool IsEmptyToken(this IServerConfig obj)
        {
            return (string.IsNullOrEmpty(obj.TestToken) && string.IsNullOrEmpty(obj.ProductionToken));
        }
        public static string GetToken(this IServerConfig obj, bool IsTest)
        {
            if (IsTest)
                return obj.TestToken;
            else
                return obj.ProductionToken;
        }
    }
}
