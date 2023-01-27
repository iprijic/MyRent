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

        public IActionResult TestConn()
        {
            var owners = _entites.Owners.Select(o => o).ToList();
            string jsonString = JsonSerializer.Serialize(owners);

            return Content(jsonString, "application/json");
        }
    }
}