using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Config
{
    public class ApiGatewayUrl
    {
        public ApiGatewayUrl(string url)
        {
            Value = url;
        }

        public readonly string Value;
    }
}
