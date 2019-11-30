using Microsoft.Extensions.Configuration;
using OrderDisplay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace OrderDisplay.CustomerUI.Helper
{
    public class HttpHelper
    {
        private readonly Configuration _configuration;
        public HttpHelper()
        {
            _configuration = new Configuration();
        }

        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri(_configuration.ApiUrl);
            return Client;
        }
    }
}
