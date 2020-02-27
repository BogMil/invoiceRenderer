using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using invoiceRenderer.Models;
using Microsoft.AspNetCore.Authorization;
using Rotativa.AspNetCore;

namespace invoiceRenderer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        List<Customer> customerList = new List<Customer>()
        {
            new Customer { CustomerID = 1, Address = "Taj Lands Ends 1", City = "Mumbai" , Country ="India", Name ="Sai", Phoneno ="9000000000"},
            new Customer { CustomerID = 2, Address = "Taj Lands Ends 2", City = "Mumbai" , Country ="India", Name ="Ram", Phoneno ="9000000000"},
            new Customer { CustomerID = 3, Address = "Taj Lands Ends 3", City = "Mumbai" , Country ="India", Name ="Sainesh", Phoneno ="9000000000"},
            new Customer { CustomerID = 4, Address = "Taj Lands Ends 4", City = "Mumbai" , Country ="India", Name ="Saineshwar", Phoneno ="9000000000"},
            new Customer { CustomerID = 5, Address = "Taj Lands Ends 5", City = "Mumbai" , Country ="India", Name ="Saibags", Phoneno ="9000000000"},


        };
        public IActionResult DemoViewAsPDF()
        {
            

            string customSwitches = string.Format("--print-media-type --allow {0} --footer-html {0} --header-html {1} ",
                Url.Action("Footer","Home", new { area = "" }, "https"),
                Url.Action("Header", "Home", new { area = "" }, "https"));

            return new ViewAsPdf("Demo",customerList)
            {
                //FileName = "Report.pdf",
                CustomSwitches = customSwitches
            };
        }

        [AllowAnonymous]
        public ActionResult Footer()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Header()
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View("Demo", customerList);
        }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phoneno { get; set; }
    }
}
