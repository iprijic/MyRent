using Microsoft.AspNetCore.Mvc;
using MyRent.API.Business.Model;
using System.Diagnostics;
using WebApplication1.Models;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Entities _entites;

        public HomeController(ILogger<HomeController> logger, Entities entites)
        {
            _logger = logger;
            _entites = entites;

            //var owners = entites.Owners.Select(o => o).ToList();
        }

        public IActionResult Index()
        {
            var owners = _entites.Owners.Select(o => o).ToList();

           // return Content("Da da", "text/xml");
            return View(owners);
        }

        public IActionResult TestConn()
        {
            var owners = _entites.Owners.Select(o => o).ToList();
            string jsonString = JsonSerializer.Serialize(owners);

            return Content(jsonString, "application/json");
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