using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkItemsService _myWorkItmSvc;
        private List<ToDoItem> _listOfToDoItems = null;
        public HomeController(IWorkItemsService workitmsvc)
        {
            _myWorkItmSvc = workitmsvc;
            _listOfToDoItems = _myWorkItmSvc.GetAllToDoItems().ToList();

        }

        public IActionResult Index()
        {


            ViewData["test"] = _listOfToDoItems[0].Name;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["test"] = _listOfToDoItems[1].Name;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewData["test"] = _listOfToDoItems[2].Name;

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
