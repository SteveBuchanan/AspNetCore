using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebConfigAttemp2.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace WebConfigAttemp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<MyOptions> _optionsAccessor;
        private readonly IOptions<MySubOptions> _subOptionsAccessor;

        //private readonly MyOptionsWithDelegateConfig _optionsWithDelegateConfig;
        //private readonly MySubOptions _subOptions;
        //private readonly MyOptions _snapshotOptions;
        //private readonly MyOptions _named_options_1;
        //private readonly MyOptions _named_options_2;
        private IConfiguration _configuration;

        //public HomeController(IConfiguration Configuration)
        //{
        //    _configuration = Configuration;
        //}

        public HomeController(IOptions<MyOptions> optionsAccessor,IOptions<MySubOptions> subOptionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
            _subOptionsAccessor = subOptionsAccessor;
        }

        public IActionResult Index()
        {


            //MyOptions x = IOptions<MyOptions>();

            //IOptions< MyOptionsWithDelegateConfig > optionsAccessorWithDelegateConfig; 
            //IOptions<MySubOptions> subOptionsAccessor;
            //IOptionsSnapshot< MyOptions > snapshotOptionsAccessor;
            //IOptionsSnapshot<MyOptions> namedOptionsAccessor;

            // _options = optionsAccessor.Value;
            //_optionsWithDelegateConfig = optionsAccessorWithDelegateConfig.Value;
            //_subOptions = subOptionsAccessor.Value;
            //_snapshotOptions = snapshotOptionsAccessor.Value;
            //_named_options_1 = namedOptionsAccessor.Get("named_options_1");
            //_named_options_2 = namedOptionsAccessor.Get("named_options_2");
            //ViewData["Steve"] = _options.Option1;
            //           ViewData["Steve"] = _configuration["option1"];

            MyOptions options = _optionsAccessor.Value;
            MySubOptions subOptions = _subOptionsAccessor.Value;


            ViewData["Steve"] = options.Option1;
            ViewData["tst"] = options.Option2;
            ViewData["SubOption1"] = subOptions.SubOption1;
            ViewData["SubOption2"] = subOptions.SubOption2;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
