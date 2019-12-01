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
            //LoadData();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Users");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(result);
            }
        }

        //public async IActionResult LoadData()
        //{
        //    var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
        //    // Skiping number of Rows count  
        //    var start = Request.Form["start"].FirstOrDefault();
        //    // Paging Length 10,20  
        //    var length = Request.Form["length"].FirstOrDefault();
        //    // Sort Column Name  
        //    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //    // Sort Column Direction ( asc ,desc)  
        //    var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        //    // Search Value from (Search box)  
        //    var searchValue = Request.Form["search[value]"].FirstOrDefault();

        //    //Paging Size (10,20,50,100)  
        //    int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //    int skip = start != null ? Convert.ToInt32(start) : 0;
        //    int recordsTotal = 0;

        //    // Getting all Customer data  
        //    HttpClient client = _api.Initial();
        //    HttpResponseMessage res = await client.GetAsync("api/Users");
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var result = res.Content.ReadAsStringAsync().Result;
        //        users = JsonConvert.DeserializeObject<List<User>>(result);
        //    }

        //    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        //    {
        //        users = users.OrderBy(sortColumn + " " + sortColumnDirection);
        //    }
        //    //Search  
        //    if (!string.IsNullOrEmpty(searchValue))
        //    {
        //        users = users.Where(m => m.Name == searchValue);
        //    }

        //    //total number of rows count   
        //    recordsTotal = users.Count();
        //    //Paging   
        //    var data = users.Skip(skip).Take(pageSize).ToList();
        //    //Returning Json Data  
        //    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        //}
    }
}
