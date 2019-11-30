using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderDisplay.CustomerUI.Helper;
using OrdersDisplay.Domain;

namespace OrderDisplay.CustomerUI.Pages
{
    public class IndexModel : PageModel
    {       
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpHelper _api;

        public IEnumerable<User> users { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _api = new HttpHelper();
        }

        public async Task OnGet()
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Users");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(result);
            }
        }
    }
}
