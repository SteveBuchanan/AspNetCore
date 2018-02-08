using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog.Web;
using WebApplication3.Models;


using NLog.Config;
using Microsoft.Extensions.Logging;
using NLog.Targets;
using NLog;
using Microsoft.Extensions.Caching.Memory;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkItemsService _myWorkItmSvc;
        //private readonly NLog.ILogger _logger;
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _memCache;

        private List<ToDoItem> _listOfToDoItems = null;




        public HomeController(IWorkItemsService workitmsvc, ILogger<HomeController> logger, IMemoryCache mc)
        {
            _myWorkItmSvc = workitmsvc;
            _listOfToDoItems = _myWorkItmSvc.GetAllToDoItems().ToList();
            MySettingsService mySettingsService = new MySettingsService(mc);
            mySettingsService.GetSettings();
            _logger = logger;
            this._memCache = mc;
        }

        public IActionResult Index()
        {
            IEnumerable<ToDoItem> mylist = _memCache.Get("blah-cache-key") as IEnumerable<ToDoItem>;

            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            // Step 3. Set target properties 
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            fileTarget.FileName = "${basedir}/file.txt";
            //            fileTarget.Layout = "${message}";
            fileTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            // Step 4. Define rules
            var rule1 = new LoggingRule("*", NLog.LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", NLog.LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule2);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;

            // Example usage
            Logger logger = LogManager.GetLogger("Example");
            logger.Trace("trace log message");
            logger.Debug("debug log message");
            logger.Info("info log message");
            logger.Warn("warn log message");
            logger.Error("error log message");
            logger.Fatal("fatal log message");



            _logger.LogError("test error");

            _logger.LogInformation(_listOfToDoItems[0].Name, "test message", 1);


            ViewData["test"] = _listOfToDoItems[0].Name;
            return View();
        }

        public IActionResult About()
        {
            _logger.LogError("from about action");
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
