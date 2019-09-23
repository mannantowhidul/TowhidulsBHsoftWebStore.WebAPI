using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.TowhidulsBHsoftWebStore.WebAPI.Helper;
using UI.TowhidulsBHsoftWebStore.WebAPI.Models;

namespace UI.TowhidulsBHsoftWebStore.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        AdminAPI _api = new AdminAPI();

        public async Task<IActionResult> Index()
        {
            List<AdminAPI> admin = new List<AdminAPI>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/admin");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                admin = JsonConvert.DeserializeObject<List<AdminAPI>>(results);
            }
            return View(admin);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
