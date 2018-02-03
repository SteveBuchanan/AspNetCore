using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotNetCore20Config.Models;
using Microsoft.Extensions.Configuration;

namespace DotNetCore20Config.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public IActionResult Index()
        {
            // Read configuration using Key string
            ViewData["MySectionMyFirstConfig"] = _configuration["MySection:MyFirstConfig"];

            // Read configuration using GetSection method
            ViewData["MySectionMySecondConfigMyFirstSubConfig"] = _configuration.GetSection("MySection").GetSection("MySecondConfig").GetSection("MyFirstSubConfig");

            // Read configuration using mixed options with GetSection method and Key string
            ViewData["MySectionMySecondConfigMySecondSubConfig"] = _configuration.GetSection("MySection")["MySecondConfig:MySecondSubConfig"];

            ViewData["MyConnectionString"] = _configuration.GetConnectionString("localDB");
            return View();


        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
